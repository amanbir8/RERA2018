using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Text;
using System.Web.Hosting;
using CRUD.Models.classProjectPmPayment;
using CRUD.Models.ProjectPmPayment;
using Hangfire;
using Newtonsoft.Json.Linq;

namespace CRUD.Jobs
{
    public class PaymentGatewayReverifyResult
    {
        public string TransactionId { get; set; }
        public int GatewayValue { get; set; }
        public int Status { get; set; }
        public int DatabaseStatus { get; set; }
        public string GatewayStatus { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
    }

    public class PaymentReverifyBatchResult
    {
        public string RunId { get; set; }
        public string LogFilePath { get; set; }
        public DateTime StartedOnUtc { get; set; }
        public DateTime CompletedOnUtc { get; set; }
        public int TotalTransactions { get; set; }
        public int VerifiedCount { get; set; }
        public int AlreadyUpdatedCount { get; set; }
        public int PendingCount { get; set; }
        public int FailedCount { get; set; }
        public int NotFoundCount { get; set; }
        public int ErrorCount { get; set; }
    }

    internal class PayuGatewaySettings
    {
        public string MerchantKey { get; set; }
        public string Salt { get; set; }
        public string ApiUrl { get; set; }
    }

    public class ProjectPmPaymentReverifyService
    {
        private static readonly object LogFileLock = new object();
        private readonly ClsMethod_ProjectPmApplication_PaymentIntegration _paymentRepository;

        public ProjectPmPaymentReverifyService()
        {
            _paymentRepository = new ClsMethod_ProjectPmApplication_PaymentIntegration();
        }

        public PaymentReverifyBatchResult ReverifyAllPendingEpayPayments()
        {
            string runId = Guid.NewGuid().ToString("N");
            PaymentReverifyBatchResult batchResult = new PaymentReverifyBatchResult
            {
                RunId = runId,
                LogFilePath = GetLogFilePath(DateTime.Now),
                StartedOnUtc = DateTime.UtcNow
            };

            WriteLogLine(runId, "START", "Nightly Epay reverify started.");

            DateTime toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime fromDate = DateTime.Now.AddDays(-GetLookbackDays()).Date;

            List<ClsPrp_PV_ePayApplication_PaymentIntegration> payments = _paymentRepository
                .Display_EpayPayments_ReVerify(toDate, fromDate)
                .Where(x => !string.IsNullOrWhiteSpace(x.PG_Transaction_ID))
                .GroupBy(x => string.Format("{0}|{1}", x.PG_Transaction_ID.Trim(), x.PaymentGatewayType))
                .Select(x => x.First())
                .ToList();

            batchResult.TotalTransactions = payments.Count;

            foreach (ClsPrp_PV_ePayApplication_PaymentIntegration payment in payments)
            {
                PaymentGatewayReverifyResult result = ReverifyTransaction(payment.PG_Transaction_ID, payment.PaymentGatewayType);

                switch (result.DatabaseStatus)
                {
                    case 1:
                        batchResult.VerifiedCount++;
                        break;
                    case 2:
                        batchResult.AlreadyUpdatedCount++;
                        break;
                    case 0:
                        batchResult.NotFoundCount++;
                        break;
                    default:
                        if (result.MessageType == "warning")
                        {
                            batchResult.PendingCount++;
                        }
                        else
                        {
                            batchResult.ErrorCount++;
                        }
                        break;
                }

                if (result.MessageType == "error" &&
                    (string.Equals(result.GatewayStatus, "failed", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(result.GatewayStatus, "bounced", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(result.GatewayStatus, "dropped", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(result.GatewayStatus, "userCancelled", StringComparison.OrdinalIgnoreCase)))
                {
                    batchResult.FailedCount++;
                }

                Trace.TraceInformation(
                    "Epay reverify txn {0} gateway {1} => status {2}, dbStatus {3}, message {4}",
                    result.TransactionId,
                    result.GatewayValue,
                    result.GatewayStatus ?? string.Empty,
                    result.DatabaseStatus,
                    result.Message ?? string.Empty);

                WritePaymentLogLine(runId, result);
            }

            batchResult.CompletedOnUtc = DateTime.UtcNow;
            WriteLogLine(
                runId,
                "SUMMARY",
                string.Format(
                    "Completed. Total={0}, Verified={1}, AlreadyUpdated={2}, Pending={3}, Failed={4}, NotFound={5}, Errors={6}",
                    batchResult.TotalTransactions,
                    batchResult.VerifiedCount,
                    batchResult.AlreadyUpdatedCount,
                    batchResult.PendingCount,
                    batchResult.FailedCount,
                    batchResult.NotFoundCount,
                    batchResult.ErrorCount));
            return batchResult;
        }

        public PaymentGatewayReverifyResult ReverifyTransaction(string gatewayTxnID, int gatewayVal)
        {
            PaymentGatewayReverifyResult result = new PaymentGatewayReverifyResult
            {
                TransactionId = Convert.ToString(gatewayTxnID),
                GatewayValue = gatewayVal,
                Status = 0,
                DatabaseStatus = -1,
                Message = "Payment verification did not complete.",
                MessageType = "error"
            };

            try
            {
                if (string.IsNullOrWhiteSpace(gatewayTxnID))
                {
                    result.Message = "Transaction ID is required.";
                    return result;
                }

                string transactionId = gatewayTxnID.Trim();
                WriteLogLine("MANUAL_OR_JOB", "REQUEST_START", string.Format("Starting payment verification for TxnId={0}, Gateway={1}", SafeForLog(transactionId), gatewayVal));
                PayuGatewaySettings settings = GetGatewaySettings(gatewayVal);
                string response = ExecuteVerifyPaymentRequest(transactionId, settings);
                WriteLogLine("MANUAL_OR_JOB", "REQUEST_END", string.Format("Received payment verification response for TxnId={0}, Gateway={1}", SafeForLog(transactionId), gatewayVal));
                JObject payload = JObject.Parse(response);

                string status = GetStringValue(payload["status"]);
                JObject transaction = payload["transaction_details"] != null
                    ? payload["transaction_details"][transactionId] as JObject
                    : null;

                if (status != "1" || transaction == null)
                {
                    result.Message = "No record found in payment gateway verification.";
                    return result;
                }

                string unmappedStatus = GetStringValue(transaction["unmappedstatus"]);
                string normalizedStatus = string.IsNullOrWhiteSpace(unmappedStatus)
                    ? GetStringValue(transaction["status"])
                    : unmappedStatus;

                result.GatewayStatus = normalizedStatus;

                if (string.Equals(normalizedStatus, "captured", StringComparison.OrdinalIgnoreCase))
                {
                    int dbStatus = _paymentRepository.Update_PaymentGatewayByAPI(
                        transactionId,
                        GetStringValue(transaction["mihpayid"]),
                        GetDecimalValue(transaction["amt"]),
                        GetStringValue(transaction["bank_ref_num"]),
                        GetStringValue(transaction["status"]),
                        GetDecimalValue(transaction["additional_charges"]),
                        GetStringValue(transaction["bankcode"]),
                        GetStringValue(transaction["mode"]),
                        GetStringValue(transaction["PG_TYPE"]),
                        GetStringValue(transaction["udf1"]),
                        GetStringValue(transaction["udf2"]),
                        GetStringValue(transaction["udf3"]),
                        GetIntStringValue(transaction["udf4"]),
                        GetIntStringValue(transaction["udf5"]));

                    result.Status = 1;
                    result.DatabaseStatus = dbStatus;

                    if (dbStatus == 1)
                    {
                        result.Message = "Payment verified and updated successfully.";
                        result.MessageType = "success";
                    }
                    else if (dbStatus == 2)
                    {
                        result.Message = "Payment was already updated earlier.";
                        result.MessageType = "warning";
                    }
                    else if (dbStatus == 0)
                    {
                        result.Message = "Transaction found, but no matching record was available to update.";
                        result.MessageType = "warning";
                    }
                    else
                    {
                        result.Message = "An error occurred while updating payment.";
                        result.MessageType = "error";
                    }

                    return result;
                }

                if (string.Equals(normalizedStatus, "userCancelled", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(normalizedStatus, "bounced", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(normalizedStatus, "dropped", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(normalizedStatus, "failed", StringComparison.OrdinalIgnoreCase))
                {
                    result.Message = normalizedStatus;
                    result.MessageType = "error";
                    return result;
                }

                result.Message = string.IsNullOrWhiteSpace(normalizedStatus) ? "Payment is still pending at gateway." : normalizedStatus;
                result.MessageType = "warning";
                return result;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Epay reverify failed for txn {0}. {1}", gatewayTxnID, ex);
                WriteLogLine("MANUAL_OR_JOB", "REQUEST_ERROR", string.Format("Payment verification failed for TxnId={0}, Gateway={1}, Error={2}", SafeForLog(gatewayTxnID), gatewayVal, SafeForLog(ex.Message)));
                result.Message = ex.Message;
                result.MessageType = "error";
                return result;
            }
        }

        private static int GetLookbackDays()
        {
            int lookbackDays;
            return int.TryParse(ConfigurationManager.AppSettings["Hangfire:EpayReverifyLookbackDays"], out lookbackDays) && lookbackDays > 0
                ? lookbackDays
                : 28;
        }

        private static int GetRequestTimeoutMilliseconds()
        {
            int timeoutMilliseconds;
            return int.TryParse(ConfigurationManager.AppSettings["Hangfire:EpayReverifyRequestTimeoutMs"], out timeoutMilliseconds) && timeoutMilliseconds > 0
                ? timeoutMilliseconds
                : 60000;
        }

        private static PayuGatewaySettings GetGatewaySettings(int gatewayVal)
        {
            switch (gatewayVal)
            {
                case 1002:
                    return new PayuGatewaySettings
                    {
                        MerchantKey = ConfigurationManager.AppSettings["payuMerchantKeyEpay"],
                        Salt = ConfigurationManager.AppSettings["payuSaltEpay"],
                        ApiUrl = ConfigurationManager.AppSettings["payuApiBaseURL"]
                    };
                case 1001:
                default:
                    return new PayuGatewaySettings
                    {
                        MerchantKey = ConfigurationManager.AppSettings["payuMerchantKey"],
                        Salt = ConfigurationManager.AppSettings["payuSalt"],
                        ApiUrl = ConfigurationManager.AppSettings["payuApiBaseURL"]
                    };
            }
        }

        private static string ExecuteVerifyPaymentRequest(string gatewayTxnID, PayuGatewaySettings settings)
        {
            string command = "verify_payment";
            string hashString = settings.MerchantKey + "|" + command + "|" + gatewayTxnID + "|" + settings.Salt;
            string hash = GenerateHash512(hashString);

            NameValueCollection values = new NameValueCollection
            {
                { "key", settings.MerchantKey },
                { "salt", settings.Salt },
                { "var1", gatewayTxnID },
                { "command", command },
                { "service_provider", "payu" },
                { "hash", hash }
            };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(settings.ApiUrl);
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.ConnectionGroupName = Guid.NewGuid().ToString();
            request.Timeout = GetRequestTimeoutMilliseconds();
            request.ReadWriteTimeout = GetRequestTimeoutMilliseconds();
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (StreamWriter requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(ToFormUrlEncoded(values));
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream receiveStream = response.GetResponseStream())
            using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
            {
                return readStream.ReadToEnd();
            }
        }

        private static string ToFormUrlEncoded(NameValueCollection values)
        {
            List<string> items = new List<string>();

            foreach (string key in values.AllKeys)
            {
                items.Add(string.Format("{0}={1}", key, values[key]));
            }

            return string.Join("&", items);
        }

        private static string GenerateHash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            using (SHA512Managed hashString = new SHA512Managed())
            {
                byte[] hashValue = hashString.ComputeHash(message);
                StringBuilder hex = new StringBuilder(hashValue.Length * 2);

                foreach (byte currentByte in hashValue)
                {
                    hex.AppendFormat("{0:x2}", currentByte);
                }

                return hex.ToString();
            }
        }

        private static decimal GetDecimalValue(JToken token)
        {
            decimal value;
            return decimal.TryParse(GetStringValue(token), out value) ? value : 0M;
        }

        private static string GetIntStringValue(JToken token)
        {
            int value;
            return int.TryParse(GetStringValue(token), out value) ? value.ToString() : "0";
        }

        private static string GetStringValue(JToken token)
        {
            return token == null ? string.Empty : Convert.ToString(token);
        }

        private static void WritePaymentLogLine(string runId, PaymentGatewayReverifyResult result)
        {
            string message = string.Format(
                "TxnId={0}, Gateway={1}, GatewayStatus={2}, DbStatus={3}, ResultType={4}, Message={5}",
                SafeForLog(result.TransactionId),
                result.GatewayValue,
                SafeForLog(result.GatewayStatus),
                result.DatabaseStatus,
                SafeForLog(result.MessageType),
                SafeForLog(result.Message));

            WriteLogLine(runId, "PAYMENT", message);
        }

        private static void WriteLogLine(string runId, string logType, string message)
        {
            string logFilePath = GetLogFilePath(DateTime.Now);
            string line = string.Format(
                "{0:yyyy-MM-dd HH:mm:ss}\tRunId={1}\tType={2}\t{3}",
                DateTime.Now,
                runId,
                logType,
                message);

            string directoryPath = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            lock (LogFileLock)
            {
                File.AppendAllText(logFilePath, line + Environment.NewLine);
            }
        }

        private static string GetLogFilePath(DateTime logDate)
        {
            string configuredPath = ConfigurationManager.AppSettings["Hangfire:EpayReverifyLogDirectory"];
            string basePath = string.IsNullOrWhiteSpace(configuredPath)
                ? HostingEnvironment.MapPath("~/App_Data/HangfireLogs")
                : configuredPath;

            if (string.IsNullOrWhiteSpace(basePath))
            {
                basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "HangfireLogs");
            }

            return Path.Combine(basePath, "epay-reverify-" + logDate.ToString("yyyyMMdd") + ".log");
        }

        private static string SafeForLog(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : value.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");
        }
    }

    public class ProjectPmPaymentRecurringJobs
    {
        [DisableConcurrentExecution(60 * 60)]
        public void ReverifyAllEpayPayments()
        {
            PaymentReverifyBatchResult result = new ProjectPmPaymentReverifyService().ReverifyAllPendingEpayPayments();

            Trace.TraceInformation(
                "Nightly Epay reverify finished. Total={0}, Verified={1}, AlreadyUpdated={2}, Pending={3}, Failed={4}, NotFound={5}, Errors={6}",
                result.TotalTransactions,
                result.VerifiedCount,
                result.AlreadyUpdatedCount,
                result.PendingCount,
                result.FailedCount,
                result.NotFoundCount,
                result.ErrorCount);

            Trace.TraceInformation("Nightly Epay reverify log file: {0}", result.LogFilePath ?? string.Empty);
        }
    }
}

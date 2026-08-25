using CRUD.Common;
using CRUD.Models.classAgentPayment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentPayment
{
    public static class AgentPaymentReverifyService
    {
        public static PaymentGatewayReverifyResult ReverifyTransaction(string zPG_Transaction_ID)
        {
            var result = new PaymentGatewayReverifyResult { MessageType = "info" };
            var sdb = new ClsMethod_AgentApplication_PaymentIntegration();

            try
            {
                string key = ConfigurationManager.AppSettings["payuMerchantKey"];
                string salt = ConfigurationManager.AppSettings["payuSalt"];
                string uri = ConfigurationManager.AppSettings["payuApiBaseURL"];

                dynamic array = PayuVerifyClient.Verify(zPG_Transaction_ID, key, salt, uri);
                string status = array["status"];
                var txn = array["transaction_details"][zPG_Transaction_ID];
                string unmappedStatus = txn["unmappedstatus"];

                if (status != "1")
                {
                    result.Message = "No record found in payment gateway verification.";
                    result.MessageType = "error";
                    return result;
                }

                if (unmappedStatus != "captured")
                {
                    result.Message = unmappedStatus;
                    result.MessageType = (unmappedStatus == "in progress" || unmappedStatus == "pending") ? "warning" : "error";
                    return result;
                }

                string mihpayid = txn["mihpayid"], bank_ref_num = txn["bank_ref_num"], pstatus = txn["status"];
                string bankcode = txn["bankcode"], payment_type = txn["mode"], payment_gateway = txn["PG_TYPE"];
                string udf1 = txn["udf1"], udf2 = txn["udf2"], udf3 = txn["udf3"], udf4 = txn["udf4"], udf5 = txn["udf5"];
                decimal amount = txn["amt"], additionalcharges = txn["additional_charges"];

                int dbStatus = sdb.Update_AgentPaymentGatewayByAPI(zPG_Transaction_ID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5);

                result.Status = dbStatus == 1 ? 1 : 0;
                result.MessageType = dbStatus == 1 ? "success" : (dbStatus == 2 || dbStatus == 0) ? "warning" : "error";
                result.Message = dbStatus == 1 ? "Payment verified and updated successfully."
                    : dbStatus == 2 ? "Payment was already updated earlier."
                    : dbStatus == 0 ? "Transaction found, but no matching record was available to update."
                    : "An error occurred while updating payment.";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.MessageType = "error";
            }

            return result;
        }
    }
}
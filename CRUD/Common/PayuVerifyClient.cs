using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using static CRUD.Controllers.classAgentPayment.AgentPaymentController;

namespace CRUD.Common
{
    public static class PayuVerifyClient
    {
        public static dynamic Verify(string gatewayTxnID, string key, string salt, string uri)
        {
            var myremoteapipost = new RemotePostAPI();
            myremoteapipost.Add("key", key);
            myremoteapipost.Add("salt", salt);
            myremoteapipost.Add("var1", gatewayTxnID);
            myremoteapipost.Add("command", "verify_payment");
            myremoteapipost.Add("service_provider", "payu");
            myremoteapipost.Add("hash", GenerateHash512($"{key}|verify_payment|{gatewayTxnID}|{salt}"));
            string myParameters = myremoteapipost.PostParameters();

            var myWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            myWebRequest.KeepAlive = false;
            myWebRequest.ProtocolVersion = HttpVersion.Version10;
            myWebRequest.ConnectionGroupName = Guid.NewGuid().ToString();
            myWebRequest.Timeout = -1;
            myWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            myWebRequest.Method = "POST";
            myWebRequest.ContentType = "application/x-www-form-urlencoded";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (var w = new StreamWriter(myWebRequest.GetRequestStream()))
                w.Write(myParameters);

            string response;
            using (var resp = (HttpWebResponse)myWebRequest.GetResponse())
            using (var stream = resp.GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
                response = reader.ReadToEnd();

            return Newtonsoft.Json.JsonConvert.DeserializeObject(response);
        }

        private static string GenerateHash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }

    public class PaymentGatewayReverifyResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
        // --- Diagnostics for detailed logging ---
        public string GatewayTxnId { get; set; }
        public string Mihpayid { get; set; }
        public decimal GatewayAmount { get; set; }
        public string GatewayPaymentDate { get; set; }   // "addedon" from PayU response
        public string GatewayUnmappedStatus { get; set; }
        public string GatewayTxnStatus { get; set; }
        public string SpMethodCalled { get; set; }
        public int DbStatusCode { get; set; }

        public DateTime GatewayCallStartedAt { get; set; }
        public DateTime GatewayCallCompletedAt { get; set; }
        public DateTime SpCallStartedAt { get; set; }
        public DateTime SpCallCompletedAt { get; set; }

        public TimeSpan GatewayCallDuration => GatewayCallCompletedAt - GatewayCallStartedAt;
        public TimeSpan SpCallDuration => SpCallCompletedAt - SpCallStartedAt;
    }
}
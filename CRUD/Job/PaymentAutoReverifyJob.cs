using System;
using System.Collections.Generic;
using System.Linq;
using Hangfire;
using System.Web;
using CRUD.Models.ClassComplaintPayment;
using static CRUD.Controllers.ComplaintPayment.ComplaintPaymentController;
using System.IO;
using CRUD.Models.ProjectPmPayment;
using CRUD.Models.classProjectPmPayment;
using CRUD.Models.AgentPayment;
using CRUD.Models.classAgentPayment;
using System.Text;
using CRUD.Common;
using System.Reflection;

namespace CRUD.Job
{
    [DisableConcurrentExecution(timeoutInSeconds: 600)]
    public static class PaymentAutoReverifyJob
    {
        public static void Run()
        {
            DateTime toDate28 = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime fromDate28 = DateTime.Now.AddDays(-28).Date;
            DateTime fromDate21 = DateTime.Now.AddDays(-21).Date;
            DateTime totoday = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime fromtoday = DateTime.Now.AddDays(-1).Date;

            // ---- Complaint Form-M / Form-N ----
            var objComplaint = new ClsMethod_ComplaintFormM_PaymentIntegration();
            //var formM = objComplaint.Display_ComplaintFormM_PaymentReVerify(toDate28, fromDate28);
            //var formN = objComplaint.Display_ComplaintFormN_PaymentReVerify(toDate28, fromDate28);
            var formN = objComplaint.Display_ComplaintFormN_PaymentReVerify(totoday, fromtoday);
            //Log($"Form-M pending={formM.Count()}, Form-N pending={formN.Count()}");
            Log($"Form-N pending={formN.Count()}");

            //foreach (var txn in formM)
            //{
            //    var r = PaymentReverifyService.ReverifyTransaction(txn.PG_Transaction_ID);
            //    //Log($"FormM/{txn.PG_Transaction_ID}: {r.MsgType} - {r.Message}");
            //    LogDetailed("FormM", r);
            //}
            foreach (var txn in formN)
            {
                //var r = PaymentReverifyService.ReverifyTransaction(txn.PG_Transaction_ID);
                ////Log($"FormN/{txn.PG_Transaction_ID}: {r.MsgType} - {r.Message}");
                //LogDetailed("FormN", r);
                var beforeGateway = objComplaint.GetComplaintFormNByTxnId(txn.PG_Transaction_ID);
                var beforeDetails = beforeGateway != null? objComplaint.GetComplaintFormNDetailsByComplaintId(beforeGateway.PaymentComplaint_RelatedComplainant_ID): null;

                var r = PaymentReverifyService.ReverifyTransaction(txn.PG_Transaction_ID);

                var afterGateway = objComplaint.GetComplaintFormNByTxnId(txn.PG_Transaction_ID);
                var afterDetails = beforeGateway != null? objComplaint.GetComplaintFormNDetailsByComplaintId(beforeGateway.PaymentComplaint_RelatedComplainant_ID): null;

                LogDetailed("FormN", r);
                Log($"FormN/{txn.PG_Transaction_ID} - PaymentGateway row diff:{Environment.NewLine}{RowDiffLogger.BuildDiff(beforeGateway, afterGateway)}");
                Log($"FormN/{txn.PG_Transaction_ID} - FormDetails row diff (ComplaintFormN_ID={beforeGateway?.PaymentComplaint_RelatedComplainant_ID}):{Environment.NewLine}{RowDiffLogger.BuildDiff(beforeDetails, afterDetails)}");
            }

            // ---- Agent ----
            //var objAgent = new ClsMethod_AgentApplication_PaymentIntegration();
            //var agentTxns = objAgent.Display_AgentApplication_PaymentReverify(toDate28, fromDate21);
            //Log($"Agent pending={agentTxns.Count()}");

            //foreach (var txn in agentTxns)
            //{
            //    var r = AgentPaymentReverifyService.ReverifyTransaction(txn.PG_Transaction_ID);
            //    Log($"Agent/{txn.PG_Transaction_ID}: {r.MessageType} - {r.Message}");
            //}

            //// ---- Project / Project Extension ----
            //var objProject = new ClsMethod_ProjectPmApplication_PaymentIntegration();
            //var projectTxns = objProject.Display_ProjectPmApplication_PaymentReverify(toDate28, fromDate28);
            //var projectExtnTxns = objProject.Display_ProjectPmExtensionApplication_PaymentReverify(toDate28, fromDate28);
            //Log($"Project pending={projectTxns.Count()}, ProjectExtn pending={projectExtnTxns.Count()}");

            //foreach (var txn in projectTxns)
            //{
            //    var r = ProjectPmPaymentReverifyService.ReverifyTransaction(txn.PG_Transaction_ID);
            //    Log($"Project/{txn.PG_Transaction_ID}: {r.MessageType} - {r.Message}");
            //}
            //foreach (var txn in projectExtnTxns)
            //{
            //    var r = ProjectPmPaymentReverifyService.ReverifyTransaction(txn.PG_Transaction_ID);
            //    Log($"ProjectExtn/{txn.PG_Transaction_ID}: {r.MessageType} - {r.Message}");
            //}

            //// ---- Epay ----
            //var epayTxns = objProject.Display_EpayPayments_ReVerify(toDate28, fromDate28);
            //Log($"Epay pending={epayTxns.Count()}");

            //foreach (var txn in epayTxns)
            //{
            //    // replace txn.GatewayVal with the actual property name on ClsPrp_PV_ePayApplication_PaymentIntegration
            //    var r = ProjectPmPaymentReverifyService.ReverifyEpayTransaction(txn.PG_Transaction_ID, txn.PaymentGatewayType);
            //    Log($"Epay/{txn.PG_Transaction_ID}: {r.MessageType} - {r.Message}");
            //}
        }

        private static void Log(string message)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string path = Path.Combine(folder, "autoreverify.log");
            File.AppendAllText(path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
        }
        private static void LogDetailed(string entityLabel, ReverifyResult r)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{entityLabel}/{r.GatewayTxnId}");
            sb.AppendLine($"    Gateway Status : {r.GatewayUnmappedStatus}");  
            sb.AppendLine($"    Gateway Payment Status : {r.GatewayTxnStatus}");   
            sb.AppendLine($"    Result         : {r.MsgType.ToUpper()} - {r.Message}");
            sb.AppendLine($"    DB Status      : {r.DbStatusCode}");
            sb.AppendLine($"    SP Called      : {r.SpMethodCalled ?? "(not reached)"}");
            sb.AppendLine($"    Mihpayid       : {r.Mihpayid}");
            sb.AppendLine($"    Amount         : {r.GatewayAmount}");
            sb.AppendLine($"    Gateway Payment Date   : {r.GatewayPaymentDate} (original success time on PayU)");
            sb.AppendLine($"    Gateway Call   : {r.GatewayCallStartedAt:HH:mm:ss.fff} -> {r.GatewayCallCompletedAt:HH:mm:ss.fff} ({r.GatewayCallDuration.TotalMilliseconds:F0}ms)");
            sb.AppendLine($"    SP Call        : {r.SpCallStartedAt:HH:mm:ss.fff} -> {r.SpCallCompletedAt:HH:mm:ss.fff} ({r.SpCallDuration.TotalMilliseconds:F0}ms)");

            Log(sb.ToString());
        }        
    }
}
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

using System.Collections.Generic;
using System;
using System.Globalization;
using System.Web.Mvc;
using System.Linq;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsMethodMIS_AgentPayment
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public IEnumerable<ClsprpMIS_AgentPayment> AgentPaymentGet()
        {
            connection();
            List<ClsprpMIS_AgentPayment> registarions = new List<ClsprpMIS_AgentPayment>();
            return registarions;
        }

        public IEnumerable<ClsprpMIS_AgentPayment> AgentPaymentPost(DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<ClsprpMIS_AgentPayment> AgentApplication_List = new List<ClsprpMIS_AgentPayment>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_Agent_PaymentMIS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string ddFromDate = FromDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Fromdate", ddFromDate);

                string ddToDate = ToDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Todate", ddToDate);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);

                DataTable dt1 = new DataTable();
                var rows = dt.Select().Where(p => (Convert.ToDateTime(p["PaymentSuccessDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["PaymentSuccessDate"]) <= Convert.ToDateTime(ddToDate)));
                if (rows.Any())
                {
                    dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["PaymentSuccessDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["PaymentSuccessDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
                }
                con.Close();

                foreach (DataRow dr in dt1.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsprpMIS_AgentPayment
                           {
                               Agent_Diary_Number = Convert.ToString(dr["DiaryNumber"]),
                               RealEstate_Agent_Name = Convert.ToString(dr["Agentname"]),
                               PG_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               PG_Phone = Convert.ToString(dr["PG_Customer_Phone"]),

                               Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                               Status = Convert.ToString(dr["FailureSuccessSummary"]),
                               PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                               PG_Payment_Description = Convert.ToString(dr["PG_Product_Info"]),

                               PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                               PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                               Amount = Convert.ToDecimal(dr["PG_Amount"]),
                               PG_Status = Convert.ToString(dr["PG_Status"]),

                               PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "REA" + Convert.ToString(dr["PG_UDF_3"]) + "PG" + Convert.ToString(dr["PG_UDF_4"]),
                               PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                               PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                               PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                               PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                               PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),

                               PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                               //PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                               PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                               PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),

                               //PaymentRefNumberAgent_IndexID = Convert.ToInt64(dr["PaymentRefNumberAgent_IndexID"]),
                               //PaymentRefNumberAgent_ID = Convert.ToInt64(dr["PaymentRefNumberAgent_ID"]),
                               //RelatedAgent_ID = Convert.ToInt64(dr["RelatedAgent_ID"]),
                               //RelatedAgent_Code = Convert.ToString(dr["RelatedAgent_Code"]),
                               //RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                               //User_ID = Convert.ToString(dr["User_ID"]),

                               //AgentType_IO = Convert.ToString(dr["AgentType_IO"]),
                               //User_Name = Convert.ToString(dr["User_Name"]),

                               //IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                               //FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                               //PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                               //PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                               //PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               //PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                               //PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                               //PG_City = Convert.ToString(dr["PG_City"]),

                               //PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),

                               //PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                               //PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                               //PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                               //PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                               //PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                               //PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                               //PG_State = Convert.ToString(dr["PG_State"]),
                               //PG_Country = Convert.ToString(dr["PG_Country"]),
                               //PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                               //Customer_First_Name = Convert.ToString(dr["Agentname"]),
                               //Customer_Last_Name = Convert.ToString(dr["PG_Shipping_Lastname"]),
                               //Customer__Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                               //Customer__Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                               //Customer__City = Convert.ToString(dr["PG_Shipping_City"]),
                               //Customer__State = Convert.ToString(dr["PG_Shipping_State"]),
                               //Customer__Country = Convert.ToString(dr["PG_Shipping_Country"]),
                               //Customer__Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                               //Customer__Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                               //PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                               //PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                               //PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                               //PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                               //PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                               //PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                               //PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                               //PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                               //Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               //A_column = Convert.ToString(dr["A_column"]),
                               //B_column = Convert.ToString(dr["B_column"]),
                               //C_column = Convert.ToString(dr["C_column"]),
                               //IsActive = Convert.ToInt32(dr["IsActive"]),
                               //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               //IsLock = Convert.ToInt32(dr["IsLock"]),
                               //IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                               //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }

        public IEnumerable<ClsprpMIS_AgentPayment> AgentRenewalPaymentGet()
        {
            connection();
            List<ClsprpMIS_AgentPayment> registarions = new List<ClsprpMIS_AgentPayment>();
            return registarions;
        }

        public IEnumerable<ClsprpMIS_AgentPayment> AgentRenewalPaymentPost(DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<ClsprpMIS_AgentPayment> AgentApplication_List = new List<ClsprpMIS_AgentPayment>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_AgentRenewal_PaymentMIS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string ddFromDate = FromDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Fromdate", ddFromDate);

                string ddToDate = ToDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Todate", ddToDate);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dtMain = new DataTable();

                con.Open();
                sd.Fill(dtMain);

                DataTable dtRnA = new DataTable();
                var rows = dtMain.Select().Where(p => (Convert.ToDateTime(p["PaymentSuccessDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["PaymentSuccessDate"]) <= Convert.ToDateTime(ddToDate)));
                if (rows.Any())
                {
                    dtRnA = dtMain.Select().Where(p => (Convert.ToDateTime(p["PaymentSuccessDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["PaymentSuccessDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
                }
                con.Close();

                foreach (DataRow dr in dtRnA.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsprpMIS_AgentPayment
                           {
                               Agent_Diary_Number = Convert.ToString(dr["DiaryNumber"]),
                               RealEstate_Agent_Name = Convert.ToString(dr["Agentname"]),
                               PG_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               PG_Phone = Convert.ToString(dr["PG_Customer_Phone"]),

                               Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                               Status = Convert.ToString(dr["FailureSuccessSummary"]),
                               PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                               PG_Payment_Description = Convert.ToString(dr["PG_Product_Info"]),

                               PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                               PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                               Amount = Convert.ToDecimal(dr["PG_Amount"]),
                               PG_Status = Convert.ToString(dr["PG_Status"]),

                               PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "REA" + Convert.ToString(dr["PG_UDF_3"]) + "PG" + Convert.ToString(dr["PG_UDF_4"]),
                               PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                               PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                               PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                               PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                               PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),

                               PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                           //PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                           PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                               PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),

                           //PaymentRefNumberAgent_IndexID = Convert.ToInt64(dr["PaymentRefNumberAgent_IndexID"]),
                           //PaymentRefNumberAgent_ID = Convert.ToInt64(dr["PaymentRefNumberAgent_ID"]),
                           //RelatedAgent_ID = Convert.ToInt64(dr["RelatedAgent_ID"]),
                           //RelatedAgent_Code = Convert.ToString(dr["RelatedAgent_Code"]),
                           //RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           //User_ID = Convert.ToString(dr["User_ID"]),

                           //AgentType_IO = Convert.ToString(dr["AgentType_IO"]),
                           //User_Name = Convert.ToString(dr["User_Name"]),

                           //IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                           //FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                           //PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                           //PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                           //PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                           //PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                           //PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                           //PG_City = Convert.ToString(dr["PG_City"]),

                           //PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),

                           //PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                           //PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                           //PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                           //PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                           //PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                           //PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                           //PG_State = Convert.ToString(dr["PG_State"]),
                           //PG_Country = Convert.ToString(dr["PG_Country"]),
                           //PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                           //Customer_First_Name = Convert.ToString(dr["Agentname"]),
                           //Customer_Last_Name = Convert.ToString(dr["PG_Shipping_Lastname"]),
                           //Customer__Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                           //Customer__Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                           //Customer__City = Convert.ToString(dr["PG_Shipping_City"]),
                           //Customer__State = Convert.ToString(dr["PG_Shipping_State"]),
                           //Customer__Country = Convert.ToString(dr["PG_Shipping_Country"]),
                           //Customer__Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                           //Customer__Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                           //PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                           //PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                           //PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                           //PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                           //PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                           //PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                           //PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                           //PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                           //Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           //A_column = Convert.ToString(dr["A_column"]),
                           //B_column = Convert.ToString(dr["B_column"]),
                           //C_column = Convert.ToString(dr["C_column"]),
                           //IsActive = Convert.ToInt32(dr["IsActive"]),
                           //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           //IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           //CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           //ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }


        #region EPAY AGENT

        //public IEnumerable<ClsprpMIS_AgentEpayPayment> AgentEpayPaymentGet()
        //{
        //    connection();
        //    List<ClsprpMIS_AgentEpayPayment> registarions = new List<ClsprpMIS_AgentEpayPayment>();

        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_TodayEpayAgent_PaymentMIS", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        string ddNowDate = DateTime.Now.ToString("yyyy-MM-dd");
        //        cmd.Parameters.AddWithValue("Nowdate", ddNowDate);

        //        MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        con.Open();
        //        sd.Fill(dt);
        //        con.Close();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            registarions.Add(
        //                   new ClsprpMIS_AgentEpayPayment
        //                   {

        //                       PaymentRegistration_ID = Convert.ToInt64(dr["PaymentRegistration_ID"]),
        //                       Payment_epayTxnID = Convert.ToInt64(dr["Payment_epayTxnID"]),
        //                       Payment_epayTxnNumber = Convert.ToString(dr["Payment_epayTxnNumber"]),
        //                       Payment_epayTxnYear = Convert.ToInt32(dr["Payment_epayTxnYear"]),
        //                       Payment_epayChallanNumber = Convert.ToString(dr["Payment_epayChallanNumber"]),
        //                       Payment_epayBankNumber = Convert.ToString(dr["Payment_epayBankNumber"]),

        //                       IsTransaction = Convert.ToInt32(dr["IsTransaction"]),
        //                       IsChallan = Convert.ToInt32(dr["IsChallan"]),
        //                       IsBankGateway = Convert.ToInt32(dr["IsBankGateway"]),
        //                       IsVerified = Convert.ToInt32(dr["IsVerified"]),

        //                       TransactionDate = Convert.ToDateTime(dr["TransactionDate"]),
        //                       ChallanDate = Convert.ToDateTime(dr["ChallanDate"]),
        //                       BankGatewayDate = Convert.ToDateTime(dr["BankGatewayDate"]),
        //                       VerifiedDate = Convert.ToDateTime(dr["VerifiedDate"]),

        //                       Payment_GroupID = Convert.ToInt32(dr["Payment_GroupID"]),
        //                       Payment_GroupName = Convert.ToString(dr["Payment_GroupName"]),
        //                       PaymentForCode = Convert.ToInt32(dr["PaymentForCode"]),
        //                       PaymentForName = Convert.ToString(dr["PaymentForName"]),

        //                       ReferenceChoiceCode = Convert.ToString(dr["ReferenceChoiceCode"]),
        //                       ReferenceChoiceName = Convert.ToString(dr["ReferenceChoiceName"]),
        //                       ReferenceChoiceValue = Convert.ToString(dr["ReferenceChoiceValue"]),


        //                       Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
        //                       RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
        //                       Agent_Name = Convert.ToString(dr["Agent_Name"]),
        //                       Agent_TypeName = Convert.ToString(dr["Agent_TypeName"]),
        //                       Agent_TypeID = Convert.ToInt32(dr["Agent_TypeID"]),
        //                       AgentAddress_DistrictCode = Convert.ToInt32(dr["AgentAddress_DistrictCode"]),
        //                       AgentAddress_DistrictName = Convert.ToString(dr["AgentAddress_DistrictName"]),


        //                       RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
        //                       RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
        //                       RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
        //                       PartyName = Convert.ToString(dr["PartyName"]),

        //                       PaymentReferenceID = Convert.ToInt32(dr["PaymentReferenceID"]),
        //                       PaymentReferenceName = Convert.ToString(dr["PaymentReferenceName"]),

        //                       BenchName = Convert.ToString(dr["BenchName"]),
        //                       BenchOrderNumber = Convert.ToString(dr["BenchOrderNumber"]),

        //                       Payment_Amount = Convert.ToDecimal(dr["Payment_Amount"]),
        //                       Payment_AmountWords = Convert.ToString(dr["Payment_AmountWords"]),
        //                       Payment_FilingDate = Convert.ToDateTime(dr["Payment_FilingDate"]),

        //                       Payment_AccountHead = Convert.ToString(dr["Payment_AccountHead"]),
        //                       Payment_AccountHead_Flag = Convert.ToString(dr["Payment_AccountHead_Flag"]),

        //                       Bank_Name = Convert.ToString(dr["Bank_Name"]),
        //                       Bank_Charges = dr["Bank_Charges"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dr["Bank_Charges"]),

        //                       Payment_EmailAddress = Convert.ToString(dr["Payment_EmailAddress"]),
        //                       Payment_MobileNumber = Convert.ToInt64(dr["Payment_MobileNumber"]),

        //                       Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
        //                       Payment_IAgree = Convert.ToInt32(dr["Payment_IAgree"]),

        //                       Payment_Status = Convert.ToString(dr["Payment_Status"]),
        //                       Payment_ErrorMessage = Convert.ToString(dr["Payment_ErrorMessage"]),

        //                       A_column = Convert.ToString(dr["A_column"]),
        //                       B_column = Convert.ToString(dr["B_column"]),
        //                       C_column = Convert.ToString(dr["C_column"]),

        //                       IsActive = Convert.ToInt32(dr["IsActive"]),
        //                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //                       IsLock = Convert.ToInt32(dr["IsLock"]),

        //                       CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //                       CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
        //                       ModifyBy = Convert.ToString(dr["ModifyBy"]),
        //                       ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

        //                       PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
        //                       PG_Date = Convert.ToDateTime(dr["PG_Date"]),
        //                       PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
        //                       PG_Status = Convert.ToString(dr["PG_Status"]),
        //                       //PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "REA" + Convert.ToString(dr["PG_UDF_3"]) + "PG" + Convert.ToString(dr["PG_UDF_4"]),
        //                       PG_PaymentRef_Number = Convert.ToString(dr["PG_PaymentRef_Number"]),
        //                       Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"]),
        //                   });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string strex = ex.ToString();
        //    }

        //    return registarions;
        //}

        //public IEnumerable<ClsprpMIS_AgentEpayPayment> AgentEpayPaymentPost(DateTime FromDate, DateTime ToDate)
        //{
        //    connection();
        //    List<ClsprpMIS_AgentEpayPayment> AgentApplication_List = new List<ClsprpMIS_AgentEpayPayment>();
        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_EpayAgent_PaymentMIS", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        string ddFromDate = FromDate.ToString("yyyy-MM-dd");
        //        cmd.Parameters.AddWithValue("Fromdate", ddFromDate);

        //        string ddToDate = ToDate.ToString("yyyy-MM-dd");
        //        cmd.Parameters.AddWithValue("Todate", ddToDate);

        //        MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        con.Open();
        //        sd.Fill(dt);

        //        DataTable dt1 = new DataTable();
        //        var rows = dt.Select().Where(p => (Convert.ToDateTime(p["PaymentSuccessDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["PaymentSuccessDate"]) <= Convert.ToDateTime(ddToDate)));
        //        if (rows.Any())
        //        {
        //            dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["PaymentSuccessDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["PaymentSuccessDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
        //        }
        //        con.Close();

        //        foreach (DataRow dr in dt1.Rows)
        //        {
        //            AgentApplication_List.Add(
        //                   new ClsprpMIS_AgentEpayPayment
        //                   {
                             
        //                       PaymentRegistration_ID = Convert.ToInt64(dr["PaymentRegistration_ID"]),
        //                       Payment_epayTxnID = Convert.ToInt64(dr["Payment_epayTxnID"]),
        //                       Payment_epayTxnNumber = Convert.ToString(dr["Payment_epayTxnNumber"]),
        //                       Payment_epayTxnYear = Convert.ToInt32(dr["Payment_epayTxnYear"]),
        //                       Payment_epayChallanNumber = Convert.ToString(dr["Payment_epayChallanNumber"]),
        //                       Payment_epayBankNumber = Convert.ToString(dr["Payment_epayBankNumber"]),

        //                       IsTransaction = Convert.ToInt32(dr["IsTransaction"]),
        //                       IsChallan = Convert.ToInt32(dr["IsChallan"]),
        //                       IsBankGateway = Convert.ToInt32(dr["IsBankGateway"]),
        //                       IsVerified = Convert.ToInt32(dr["IsVerified"]),

        //                       TransactionDate = Convert.ToDateTime(dr["TransactionDate"]),
        //                       ChallanDate = Convert.ToDateTime(dr["ChallanDate"]),
        //                       BankGatewayDate = Convert.ToDateTime(dr["BankGatewayDate"]),
        //                       VerifiedDate = Convert.ToDateTime(dr["VerifiedDate"]),

        //                       Payment_GroupID = Convert.ToInt32(dr["Payment_GroupID"]),
        //                       Payment_GroupName = Convert.ToString(dr["Payment_GroupName"]),
        //                       PaymentForCode = Convert.ToInt32(dr["PaymentForCode"]),
        //                       PaymentForName = Convert.ToString(dr["PaymentForName"]),

        //                       ReferenceChoiceCode = Convert.ToString(dr["ReferenceChoiceCode"]),
        //                       ReferenceChoiceName = Convert.ToString(dr["ReferenceChoiceName"]),
        //                       ReferenceChoiceValue = Convert.ToString(dr["ReferenceChoiceValue"]),


        //                       Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
        //                       RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
        //                       Agent_Name = Convert.ToString(dr["Agent_Name"]),
        //                       Agent_TypeName = Convert.ToString(dr["Agent_TypeName"]),
        //                       Agent_TypeID = Convert.ToInt32(dr["Agent_TypeID"]),
        //                       AgentAddress_DistrictCode = Convert.ToInt32(dr["AgentAddress_DistrictCode"]),
        //                       AgentAddress_DistrictName = Convert.ToString(dr["AgentAddress_DistrictName"]),
                               

        //                       RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
        //                       RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
        //                       RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
        //                       PartyName = Convert.ToString(dr["PartyName"]),

        //                       PaymentReferenceID = Convert.ToInt32(dr["PaymentReferenceID"]),
        //                       PaymentReferenceName = Convert.ToString(dr["PaymentReferenceName"]),

        //                       BenchName = Convert.ToString(dr["BenchName"]),
        //                       BenchOrderNumber = Convert.ToString(dr["BenchOrderNumber"]),

        //                       Payment_Amount = Convert.ToDecimal(dr["Payment_Amount"]),
        //                       Payment_AmountWords = Convert.ToString(dr["Payment_AmountWords"]),
        //                       Payment_FilingDate = Convert.ToDateTime(dr["Payment_FilingDate"]),

        //                       Payment_AccountHead = Convert.ToString(dr["Payment_AccountHead"]),
        //                       Payment_AccountHead_Flag = Convert.ToString(dr["Payment_AccountHead_Flag"]),

        //                       Bank_Name = Convert.ToString(dr["Bank_Name"]),
        //                       Bank_Charges = dr["Bank_Charges"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dr["Bank_Charges"]),

        //                       Payment_EmailAddress = Convert.ToString(dr["Payment_EmailAddress"]),
        //                       Payment_MobileNumber = Convert.ToInt64(dr["Payment_MobileNumber"]),

        //                       Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
        //                       Payment_IAgree = Convert.ToInt32(dr["Payment_IAgree"]),

        //                       Payment_Status = Convert.ToString(dr["Payment_Status"]),
        //                       Payment_ErrorMessage = Convert.ToString(dr["Payment_ErrorMessage"]),

        //                       A_column = Convert.ToString(dr["A_column"]),
        //                       B_column = Convert.ToString(dr["B_column"]),
        //                       C_column = Convert.ToString(dr["C_column"]),

        //                       IsActive = Convert.ToInt32(dr["IsActive"]),
        //                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //                       IsLock = Convert.ToInt32(dr["IsLock"]),

        //                       CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //                       CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
        //                       ModifyBy = Convert.ToString(dr["ModifyBy"]),
        //                       ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

        //                       PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
        //                       PG_Date = Convert.ToDateTime(dr["PG_Date"]),
        //                       PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
        //                       PG_Status = Convert.ToString(dr["PG_Status"]),
        //                       //PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "REA" + Convert.ToString(dr["PG_UDF_3"]) + "PG" + Convert.ToString(dr["PG_UDF_4"]),
        //                       PG_PaymentRef_Number = Convert.ToString(dr["PG_PaymentRef_Number"]),
        //                       Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"]),

        //                   });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string strex = ex.ToString();
        //    }
        //    return AgentApplication_List;
        //}

        #endregion

        #region EPAY AGENT updated
        public IEnumerable<ClsprpMIS_AgentEpayPayment> Display_AuthDesk_ePayAgentRegistrationPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag)
        {
            connection();
            List<ClsprpMIS_AgentEpayPayment> AgentReralist = new List<ClsprpMIS_AgentEpayPayment>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_EpayAgent_PaymentMIS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", prmUserID_Role);
            cmd.Parameters.AddWithValue("p_Fromdate", prmFromDate);
            cmd.Parameters.AddWithValue("p_Todate", prmToDate);
            cmd.Parameters.AddWithValue("p_SearchTypeFlag", prmSearchTypeFlag);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DateTime dtvalue = new DateTime(0001, 1, 1);

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new ClsprpMIS_AgentEpayPayment
                       {
                           PaymentRegistration_ID = Convert.ToInt64(dr["PaymentRegistration_ID"]),
                           Payment_epayTxnID = Convert.ToInt64(dr["Payment_epayTxnID"]),
                           Payment_epayTxnNumber = Convert.ToString(dr["Payment_epayTxnNumber"]),
                           Payment_epayTxnYear = Convert.ToInt32(dr["Payment_epayTxnYear"]),
                           Payment_epayChallanNumber = Convert.ToString(dr["Payment_epayChallanNumber"]),
                           Payment_epayBankNumber = Convert.ToString(dr["Payment_epayBankNumber"]),

                           IsTransaction = Convert.ToInt32(dr["IsTransaction"]),
                           IsChallan = Convert.ToInt32(dr["IsChallan"]),
                           IsBankGateway = Convert.ToInt32(dr["IsBankGateway"]),
                           IsVerified = Convert.ToInt32(dr["IsVerified"]),

                           TransactionDate = Convert.ToDateTime(dr["TransactionDate"]),
                           ChallanDate = Convert.ToDateTime(dr["ChallanDate"]),
                           BankGatewayDate = Convert.ToDateTime(dr["BankGatewayDate"]),
                           VerifiedDate = Convert.ToDateTime(dr["VerifiedDate"]),

                           Payment_GroupID = Convert.ToInt32(dr["Payment_GroupID"]),
                           Payment_GroupName = Convert.ToString(dr["Payment_GroupName"]),
                           PaymentForCode = Convert.ToInt32(dr["PaymentForCode"]),
                           PaymentForName = Convert.ToString(dr["PaymentForName"]),

                           ReferenceChoiceCode = Convert.ToString(dr["ReferenceChoiceCode"]),
                           ReferenceChoiceName = Convert.ToString(dr["ReferenceChoiceName"]),
                           ReferenceChoiceValue = Convert.ToString(dr["ReferenceChoiceValue"]),


                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_TypeName = Convert.ToString(dr["Agent_TypeName"]),
                           Agent_TypeID = Convert.ToInt32(dr["Agent_TypeID"]),
                           AgentAddress_DistrictCode = Convert.ToInt32(dr["AgentAddress_DistrictCode"]),
                           AgentAddress_DistrictName = Convert.ToString(dr["AgentAddress_DistrictName"]),


                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           PartyName = Convert.ToString(dr["PartyName"]),

                           PaymentReferenceID = Convert.ToInt32(dr["PaymentReferenceID"]),
                           PaymentReferenceName = Convert.ToString(dr["PaymentReferenceName"]),

                           BenchName = Convert.ToString(dr["BenchName"]),
                           BenchOrderNumber = Convert.ToString(dr["BenchOrderNumber"]),

                           Payment_Amount = Convert.ToDecimal(dr["Payment_Amount"]),
                           Payment_AmountWords = Convert.ToString(dr["Payment_AmountWords"]),
                           Payment_FilingDate = Convert.ToDateTime(dr["Payment_FilingDate"]),

                           Payment_AccountHead = Convert.ToString(dr["Payment_AccountHead"]),
                           Payment_AccountHead_Flag = Convert.ToString(dr["Payment_AccountHead_Flag"]),

                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Bank_Charges = dr["Bank_Charges"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dr["Bank_Charges"]),

                           Payment_EmailAddress = Convert.ToString(dr["Payment_EmailAddress"]),
                           Payment_MobileNumber = Convert.ToInt64(dr["Payment_MobileNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           Payment_IAgree = Convert.ToInt32(dr["Payment_IAgree"]),

                           Payment_Status = Convert.ToString(dr["Payment_Status"]),
                           Payment_ErrorMessage = Convert.ToString(dr["Payment_ErrorMessage"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                           PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                           PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                           PG_Status = Convert.ToString(dr["PG_Status"]),
                           //PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "REA" + Convert.ToString(dr["PG_UDF_3"]) + "PG" + Convert.ToString(dr["PG_UDF_4"]),
                           PG_PaymentRef_Number = Convert.ToString(dr["PG_PaymentRef_Number"]),
                           Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"])
                       });
            }
            return AgentReralist;
        }



        #endregion
    }
}
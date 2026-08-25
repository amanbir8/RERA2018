using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.classAgentRenewalPayment
{
    public class ClsMethod_AgentRenewalApplication_PaymentIntegration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_AgentRenewalApplication_Payment(ClsPrp_AgentRenewalApplication_PaymentIntegration smodel, string UID, string UserName, string txID, string UDF1)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_agentrenewal_paymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentRefNumberRenewalAgent_IndexID", smodel.PaymentRefNumberRenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefNumberRenewalAgent_ID", smodel.PaymentRefNumberRenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", smodel.Related_RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalOrderSequence", smodel.Related_RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_Related_RelatedRenewalAgent_Year", smodel.Related_RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "0" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", smodel.Related_Agent_Type);
            cmd.Parameters.AddWithValue("p_Related_UserID", String.IsNullOrEmpty(smodel.Related_UserID) ? "0" : smodel.Related_UserID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "0" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", DateTime.Now);

            cmd.Parameters.AddWithValue("p_RelatedAgent_Code", String.IsNullOrEmpty(smodel.RelatedAgent_Code) ? "0" : smodel.RelatedAgent_Code);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", smodel.RelatedPayment_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_AgentType_IO", String.IsNullOrEmpty(smodel.AgentType_IO) ? "" : smodel.AgentType_IO);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_Agent_BriefSummary", String.IsNullOrEmpty(smodel.Agent_BriefSummary) ? "" : smodel.Agent_BriefSummary);
            cmd.Parameters.AddWithValue("p_IsPaymentSuccessComplete", 0);
            cmd.Parameters.AddWithValue("p_PaymentSuccessDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_FailureSuccessSummary", String.IsNullOrEmpty(smodel.FailureSuccessSummary) ? "" : smodel.FailureSuccessSummary);

            cmd.Parameters.AddWithValue("p_PG_Transaction_ID", String.IsNullOrEmpty(txID) ? "0" : txID);
            cmd.Parameters.AddWithValue("p_PG_Date", DateTime.Now); //datefun(smodel.PG_Date.ToString()));
            cmd.Parameters.AddWithValue("p_PG_PayU_ID", smodel.PG_PayU_ID == null ? 0 : smodel.PG_PayU_ID);
            cmd.Parameters.AddWithValue("p_PG_Amount", smodel.PG_Amount);

            cmd.Parameters.AddWithValue("p_PG_Status", String.IsNullOrEmpty(smodel.PG_Status) ? "" : smodel.PG_Status);
            cmd.Parameters.AddWithValue("p_PG_Product_Info", String.IsNullOrEmpty(smodel.PG_Product_Info) ? "" : smodel.PG_Product_Info);
            cmd.Parameters.AddWithValue("p_PG_Customer_Name", String.IsNullOrEmpty(smodel.PG_Customer_Name) ? "" : smodel.PG_Customer_Name);
            cmd.Parameters.AddWithValue("p_PG_Last_Name", String.IsNullOrEmpty(smodel.PG_Last_Name) ? "" : smodel.PG_Last_Name);
            cmd.Parameters.AddWithValue("p_PG_Customer_Email", String.IsNullOrEmpty(smodel.PG_Customer_Email) ? "" : smodel.PG_Customer_Email);
            cmd.Parameters.AddWithValue("p_PG_Customer_Phone", String.IsNullOrEmpty(smodel.PG_Customer_Phone) ? "" : smodel.PG_Customer_Phone);
            cmd.Parameters.AddWithValue("p_PG_Customer_IP_Address", String.IsNullOrEmpty(smodel.PG_Customer_IP_Address) ? "" : smodel.PG_Customer_IP_Address);
            cmd.Parameters.AddWithValue("p_PG_City", String.IsNullOrEmpty(smodel.PG_City) ? "" : smodel.PG_City);
            cmd.Parameters.AddWithValue("p_PG_Merchant_Name", String.IsNullOrEmpty(smodel.PG_Merchant_Name) ? "" : smodel.PG_Merchant_Name);
            cmd.Parameters.AddWithValue("p_PG_Bank_Name", String.IsNullOrEmpty(smodel.PG_Bank_Name) ? "" : smodel.PG_Bank_Name);
            cmd.Parameters.AddWithValue("p_PG_Payment_Gateway", String.IsNullOrEmpty(smodel.PG_Payment_Gateway) ? "" : smodel.PG_Payment_Gateway);

            cmd.Parameters.AddWithValue("p_PG_Bank_Reference_No", String.IsNullOrEmpty(smodel.PG_Bank_Reference_No) ? "" : smodel.PG_Bank_Reference_No);
            cmd.Parameters.AddWithValue("p_PG_International_Domestic", String.IsNullOrEmpty(smodel.PG_International_Domestic) ? "" : smodel.PG_International_Domestic);
            cmd.Parameters.AddWithValue("p_PG_Payment_Type", String.IsNullOrEmpty(smodel.PG_Payment_Type) ? "" : smodel.PG_Payment_Type);
            cmd.Parameters.AddWithValue("p_PG_Error_Code", String.IsNullOrEmpty(smodel.PG_Error_Code) ? "" : smodel.PG_Error_Code);
            cmd.Parameters.AddWithValue("p_PG_Error_Message", String.IsNullOrEmpty(smodel.PG_Error_Message) ? "" : smodel.PG_Error_Message);
            cmd.Parameters.AddWithValue("p_PG_Name_on_Card", String.IsNullOrEmpty(smodel.PG_Name_on_Card) ? "" : smodel.PG_Name_on_Card);
            cmd.Parameters.AddWithValue("p_PG_Card_Number", String.IsNullOrEmpty(smodel.PG_Card_Number) ? "" : smodel.PG_Card_Number);

            cmd.Parameters.AddWithValue("p_PG_Address_Line1", String.IsNullOrEmpty(smodel.PG_Address_Line1) ? "" : smodel.PG_Address_Line1);
            cmd.Parameters.AddWithValue("p_PG_Address_Line2", String.IsNullOrEmpty(smodel.PG_Address_Line2) ? "" : smodel.PG_Address_Line2);
            cmd.Parameters.AddWithValue("p_PG_State", String.IsNullOrEmpty(smodel.PG_State) ? "" : smodel.PG_State);
            cmd.Parameters.AddWithValue("p_PG_Country", String.IsNullOrEmpty(smodel.PG_Country) ? "" : smodel.PG_Country);
            cmd.Parameters.AddWithValue("p_PG_ZipCode", String.IsNullOrEmpty(smodel.PG_ZipCode) ? "" : smodel.PG_ZipCode);

            cmd.Parameters.AddWithValue("p_PG_Shipping_Firstname", String.IsNullOrEmpty(smodel.PG_Shipping_Firstname) ? "" : smodel.PG_Shipping_Firstname);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Lastname", String.IsNullOrEmpty(smodel.PG_Shipping_Lastname) ? "" : smodel.PG_Shipping_Lastname);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Address1", String.IsNullOrEmpty(smodel.PG_Shipping_Address1) ? "" : smodel.PG_Shipping_Address1);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Address2", String.IsNullOrEmpty(smodel.PG_Shipping_Address2) ? "" : smodel.PG_Shipping_Address2);
            cmd.Parameters.AddWithValue("p_PG_Shipping_City", String.IsNullOrEmpty(smodel.PG_Shipping_City) ? "" : smodel.PG_Shipping_City);
            cmd.Parameters.AddWithValue("p_PG_Shipping_State", String.IsNullOrEmpty(smodel.PG_Shipping_State) ? "" : smodel.PG_Shipping_State);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Country", String.IsNullOrEmpty(smodel.PG_Shipping_Country) ? "" : smodel.PG_Shipping_Country);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Zipcode", String.IsNullOrEmpty(smodel.PG_Shipping_Zipcode) ? "" : smodel.PG_Shipping_Zipcode);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Phone", String.IsNullOrEmpty(smodel.PG_Shipping_Phone) ? "" : smodel.PG_Shipping_Phone);

            cmd.Parameters.AddWithValue("p_PG_Transaction_Fee", smodel.PG_Transaction_Fee);
            cmd.Parameters.AddWithValue("p_PG_Discount", smodel.PG_Discount == null ? 0 : smodel.PG_Discount);
            cmd.Parameters.AddWithValue("p_PG_Additional_Charges", smodel.PG_Additional_Charges);
            cmd.Parameters.AddWithValue("p_PG_Amount_INR", smodel.PG_Amount_INR);
            cmd.Parameters.AddWithValue("p_PG_UDF_1", String.IsNullOrEmpty(smodel.PG_UDF_1) ? "0" : smodel.PG_UDF_1);
            cmd.Parameters.AddWithValue("p_PG_UDF_2", String.IsNullOrEmpty(smodel.PG_UDF_2) ? "0" : smodel.PG_UDF_2);
            cmd.Parameters.AddWithValue("p_PG_UDF_3", String.IsNullOrEmpty(smodel.PG_UDF_3) ? "" : smodel.PG_UDF_3);
            cmd.Parameters.AddWithValue("p_PG_UDF_4", String.IsNullOrEmpty(smodel.PG_UDF_4) ? "" : smodel.PG_UDF_4);
            cmd.Parameters.AddWithValue("p_PG_UDF_5", String.IsNullOrEmpty(smodel.PG_UDF_5) ? "" : smodel.PG_UDF_5);

            cmd.Parameters.AddWithValue("p_PG_Device_Info", String.IsNullOrEmpty(smodel.PG_Device_Info) ? "" : smodel.PG_Device_Info);
            cmd.Parameters.AddWithValue("p_PG_HashKey", String.IsNullOrEmpty(smodel.PG_HashKey) ? "" : smodel.PG_HashKey);
            cmd.Parameters.AddWithValue("p_PG_ServiceProvider", String.IsNullOrEmpty(smodel.PG_ServiceProvider) ? "" : smodel.PG_ServiceProvider);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 0);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_IsConditional", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return AppId;
            else
                return 0;
        }

        public bool Update_AgentRenewalApplication_Payment(ClsPrp_AgentRenewalApplication_PaymentIntegration smodel, String UID, String UserName, Int32 IsPaymentSuccessCompleteFlag)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_agentrenewal_paymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentRefNumberRenewalAgent_IndexID", smodel.PaymentRefNumberRenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefNumberRenewalAgent_ID", smodel.PaymentRefNumberRenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", smodel.Related_RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalOrderSequence", smodel.Related_RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_Related_RelatedRenewalAgent_Year", smodel.Related_RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "0" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", smodel.Related_Agent_Type);
            cmd.Parameters.AddWithValue("p_Related_UserID", String.IsNullOrEmpty(smodel.Related_UserID) ? "0" : smodel.Related_UserID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "0" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", DateTime.Now);

            cmd.Parameters.AddWithValue("p_RelatedAgent_Code", String.IsNullOrEmpty(smodel.RelatedAgent_Code) ? "0" : smodel.RelatedAgent_Code);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", smodel.RelatedPayment_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_AgentType_IO", String.IsNullOrEmpty(smodel.AgentType_IO) ? "" : smodel.AgentType_IO);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_Agent_BriefSummary", String.IsNullOrEmpty(smodel.Agent_BriefSummary) ? "" : smodel.Agent_BriefSummary);
            cmd.Parameters.AddWithValue("p_IsPaymentSuccessComplete", IsPaymentSuccessCompleteFlag);
            cmd.Parameters.AddWithValue("p_PaymentSuccessDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_FailureSuccessSummary", String.IsNullOrEmpty(smodel.FailureSuccessSummary) ? "" : smodel.FailureSuccessSummary);

            cmd.Parameters.AddWithValue("p_PG_Transaction_ID", String.IsNullOrEmpty(smodel.PG_Transaction_ID) ? "0" : smodel.PG_Transaction_ID);
            cmd.Parameters.AddWithValue("p_PG_Date", DateTime.Now); //datefun(smodel.PG_Date.ToString()));
            cmd.Parameters.AddWithValue("p_PG_PayU_ID", smodel.PG_PayU_ID == null ? 0 : smodel.PG_PayU_ID);
            cmd.Parameters.AddWithValue("p_PG_Amount", smodel.PG_Amount);

            cmd.Parameters.AddWithValue("p_PG_Status", String.IsNullOrEmpty(smodel.PG_Status) ? "" : smodel.PG_Status);
            cmd.Parameters.AddWithValue("p_PG_Product_Info", String.IsNullOrEmpty(smodel.PG_Product_Info) ? "" : smodel.PG_Product_Info);
            cmd.Parameters.AddWithValue("p_PG_Customer_Name", String.IsNullOrEmpty(smodel.PG_Customer_Name) ? "" : smodel.PG_Customer_Name);
            cmd.Parameters.AddWithValue("p_PG_Last_Name", String.IsNullOrEmpty(smodel.PG_Last_Name) ? "" : smodel.PG_Last_Name);
            cmd.Parameters.AddWithValue("p_PG_Customer_Email", String.IsNullOrEmpty(smodel.PG_Customer_Email) ? "" : smodel.PG_Customer_Email);
            cmd.Parameters.AddWithValue("p_PG_Customer_Phone", String.IsNullOrEmpty(smodel.PG_Customer_Phone) ? "" : smodel.PG_Customer_Phone);
            cmd.Parameters.AddWithValue("p_PG_Customer_IP_Address", String.IsNullOrEmpty(smodel.PG_Customer_IP_Address) ? "" : smodel.PG_Customer_IP_Address);
            cmd.Parameters.AddWithValue("p_PG_City", String.IsNullOrEmpty(smodel.PG_City) ? "" : smodel.PG_City);
            cmd.Parameters.AddWithValue("p_PG_Merchant_Name", String.IsNullOrEmpty(smodel.PG_Merchant_Name) ? "" : smodel.PG_Merchant_Name);
            cmd.Parameters.AddWithValue("p_PG_Bank_Name", String.IsNullOrEmpty(smodel.PG_Bank_Name) ? "" : smodel.PG_Bank_Name);
            cmd.Parameters.AddWithValue("p_PG_Payment_Gateway", String.IsNullOrEmpty(smodel.PG_Payment_Gateway) ? "" : smodel.PG_Payment_Gateway);

            cmd.Parameters.AddWithValue("p_PG_Bank_Reference_No", String.IsNullOrEmpty(smodel.PG_Bank_Reference_No) ? "" : smodel.PG_Bank_Reference_No);
            cmd.Parameters.AddWithValue("p_PG_International_Domestic", String.IsNullOrEmpty(smodel.PG_International_Domestic) ? "" : smodel.PG_International_Domestic);
            cmd.Parameters.AddWithValue("p_PG_Payment_Type", String.IsNullOrEmpty(smodel.PG_Payment_Type) ? "" : smodel.PG_Payment_Type);
            cmd.Parameters.AddWithValue("p_PG_Error_Code", String.IsNullOrEmpty(smodel.PG_Error_Code) ? "" : smodel.PG_Error_Code);
            cmd.Parameters.AddWithValue("p_PG_Error_Message", String.IsNullOrEmpty(smodel.PG_Error_Message) ? "" : smodel.PG_Error_Message);
            cmd.Parameters.AddWithValue("p_PG_Name_on_Card", String.IsNullOrEmpty(smodel.PG_Name_on_Card) ? "" : smodel.PG_Name_on_Card);
            cmd.Parameters.AddWithValue("p_PG_Card_Number", String.IsNullOrEmpty(smodel.PG_Card_Number) ? "" : smodel.PG_Card_Number);

            cmd.Parameters.AddWithValue("p_PG_Address_Line1", String.IsNullOrEmpty(smodel.PG_Address_Line1) ? "" : smodel.PG_Address_Line1);
            cmd.Parameters.AddWithValue("p_PG_Address_Line2", String.IsNullOrEmpty(smodel.PG_Address_Line2) ? "" : smodel.PG_Address_Line2);
            cmd.Parameters.AddWithValue("p_PG_State", String.IsNullOrEmpty(smodel.PG_State) ? "" : smodel.PG_State);
            cmd.Parameters.AddWithValue("p_PG_Country", String.IsNullOrEmpty(smodel.PG_Country) ? "" : smodel.PG_Country);
            cmd.Parameters.AddWithValue("p_PG_ZipCode", String.IsNullOrEmpty(smodel.PG_ZipCode) ? "" : smodel.PG_ZipCode);

            cmd.Parameters.AddWithValue("p_PG_Shipping_Firstname", String.IsNullOrEmpty(smodel.PG_Shipping_Firstname) ? "" : smodel.PG_Shipping_Firstname);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Lastname", String.IsNullOrEmpty(smodel.PG_Shipping_Lastname) ? "" : smodel.PG_Shipping_Lastname);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Address1", String.IsNullOrEmpty(smodel.PG_Shipping_Address1) ? "" : smodel.PG_Shipping_Address1);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Address2", String.IsNullOrEmpty(smodel.PG_Shipping_Address2) ? "" : smodel.PG_Shipping_Address2);
            cmd.Parameters.AddWithValue("p_PG_Shipping_City", String.IsNullOrEmpty(smodel.PG_Shipping_City) ? "" : smodel.PG_Shipping_City);
            cmd.Parameters.AddWithValue("p_PG_Shipping_State", String.IsNullOrEmpty(smodel.PG_Shipping_State) ? "" : smodel.PG_Shipping_State);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Country", String.IsNullOrEmpty(smodel.PG_Shipping_Country) ? "" : smodel.PG_Shipping_Country);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Zipcode", String.IsNullOrEmpty(smodel.PG_Shipping_Zipcode) ? "" : smodel.PG_Shipping_Zipcode);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Phone", String.IsNullOrEmpty(smodel.PG_Shipping_Phone) ? "" : smodel.PG_Shipping_Phone);

            cmd.Parameters.AddWithValue("p_PG_Transaction_Fee", smodel.PG_Transaction_Fee);
            cmd.Parameters.AddWithValue("p_PG_Discount", smodel.PG_Discount == null ? 0 : smodel.PG_Discount);
            cmd.Parameters.AddWithValue("p_PG_Additional_Charges", smodel.PG_Additional_Charges);
            cmd.Parameters.AddWithValue("p_PG_Amount_INR", smodel.PG_Amount_INR);
            cmd.Parameters.AddWithValue("p_PG_UDF_1", String.IsNullOrEmpty(smodel.PG_UDF_1) ? "0" : smodel.PG_UDF_1);
            cmd.Parameters.AddWithValue("p_PG_UDF_2", String.IsNullOrEmpty(smodel.PG_UDF_2) ? "0" : smodel.PG_UDF_2);
            cmd.Parameters.AddWithValue("p_PG_UDF_3", String.IsNullOrEmpty(smodel.PG_UDF_3) ? "" : smodel.PG_UDF_3);
            cmd.Parameters.AddWithValue("p_PG_UDF_4", String.IsNullOrEmpty(smodel.PG_UDF_4) ? "" : smodel.PG_UDF_4);
            cmd.Parameters.AddWithValue("p_PG_UDF_5", String.IsNullOrEmpty(smodel.PG_UDF_5) ? "" : smodel.PG_UDF_5);

            cmd.Parameters.AddWithValue("p_PG_Device_Info", String.IsNullOrEmpty(smodel.PG_Device_Info) ? "" : smodel.PG_Device_Info);
            cmd.Parameters.AddWithValue("p_PG_HashKey", String.IsNullOrEmpty(smodel.PG_HashKey) ? "" : smodel.PG_HashKey);
            cmd.Parameters.AddWithValue("p_PG_ServiceProvider", String.IsNullOrEmpty(smodel.PG_ServiceProvider) ? "" : smodel.PG_ServiceProvider);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 0);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_IsConditional", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i < 1)
                return true;
            else
                return false;
        }

        public bool Update_AgentRenewalApplication_PaymentByAPI(ClsPrp_AgentRenewalApplication_PaymentIntegration smodel, String UID, String UserName, Int32 IsPaymentSuccessCompleteFlag)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_agentrenewal_paymentgateway_ByAPI", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentRefNumberRenewalAgent_IndexID", smodel.PaymentRefNumberRenewalAgent_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefNumberRenewalAgent_ID", smodel.PaymentRefNumberRenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", smodel.Related_RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalOrderSequence", smodel.Related_RenewalOrderSequence);
            cmd.Parameters.AddWithValue("p_Related_RelatedRenewalAgent_Year", smodel.Related_RelatedRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_AgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.Related_AgentDiaryNumber_Name) ? "0" : smodel.Related_AgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_Related_Agent_Type", smodel.Related_Agent_Type);
            cmd.Parameters.AddWithValue("p_Related_UserID", String.IsNullOrEmpty(smodel.Related_UserID) ? "0" : smodel.Related_UserID);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Related_RERAnumberRegistration) ? "0" : smodel.Related_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberIssueDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_RERAnumberRegUptoDate", DateTime.Now);

            cmd.Parameters.AddWithValue("p_RelatedAgent_Code", String.IsNullOrEmpty(smodel.RelatedAgent_Code) ? "0" : smodel.RelatedAgent_Code);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", smodel.RelatedPayment_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_AgentType_IO", String.IsNullOrEmpty(smodel.AgentType_IO) ? "" : smodel.AgentType_IO);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_Agent_BriefSummary", String.IsNullOrEmpty(smodel.Agent_BriefSummary) ? "" : smodel.Agent_BriefSummary);
            cmd.Parameters.AddWithValue("p_IsPaymentSuccessComplete", IsPaymentSuccessCompleteFlag);
            cmd.Parameters.AddWithValue("p_PaymentSuccessDate", smodel.PaymentSuccessDate == null ? dtvalue : smodel.PaymentSuccessDate); //DateTime.Now);
            cmd.Parameters.AddWithValue("p_FailureSuccessSummary", String.IsNullOrEmpty(smodel.FailureSuccessSummary) ? "" : smodel.FailureSuccessSummary);

            cmd.Parameters.AddWithValue("p_PG_Transaction_ID", String.IsNullOrEmpty(smodel.PG_Transaction_ID) ? "0" : smodel.PG_Transaction_ID);
            cmd.Parameters.AddWithValue("p_PG_Date", smodel.PG_Date == null ? dtvalue : smodel.PG_Date); //DateTime.Now); //datefun(smodel.PG_Date.ToString()));
            cmd.Parameters.AddWithValue("p_PG_PayU_ID", smodel.PG_PayU_ID == null ? 0 : smodel.PG_PayU_ID);
            cmd.Parameters.AddWithValue("p_PG_Amount", smodel.PG_Amount);

            cmd.Parameters.AddWithValue("p_PG_Status", String.IsNullOrEmpty(smodel.PG_Status) ? "" : smodel.PG_Status);
            cmd.Parameters.AddWithValue("p_PG_Product_Info", String.IsNullOrEmpty(smodel.PG_Product_Info) ? "" : smodel.PG_Product_Info);
            cmd.Parameters.AddWithValue("p_PG_Customer_Name", String.IsNullOrEmpty(smodel.PG_Customer_Name) ? "" : smodel.PG_Customer_Name);
            cmd.Parameters.AddWithValue("p_PG_Last_Name", String.IsNullOrEmpty(smodel.PG_Last_Name) ? "" : smodel.PG_Last_Name);
            cmd.Parameters.AddWithValue("p_PG_Customer_Email", String.IsNullOrEmpty(smodel.PG_Customer_Email) ? "" : smodel.PG_Customer_Email);
            cmd.Parameters.AddWithValue("p_PG_Customer_Phone", String.IsNullOrEmpty(smodel.PG_Customer_Phone) ? "" : smodel.PG_Customer_Phone);
            cmd.Parameters.AddWithValue("p_PG_Customer_IP_Address", String.IsNullOrEmpty(smodel.PG_Customer_IP_Address) ? "" : smodel.PG_Customer_IP_Address);
            cmd.Parameters.AddWithValue("p_PG_City", String.IsNullOrEmpty(smodel.PG_City) ? "" : smodel.PG_City);
            cmd.Parameters.AddWithValue("p_PG_Merchant_Name", String.IsNullOrEmpty(smodel.PG_Merchant_Name) ? "" : smodel.PG_Merchant_Name);
            cmd.Parameters.AddWithValue("p_PG_Bank_Name", String.IsNullOrEmpty(smodel.PG_Bank_Name) ? "" : smodel.PG_Bank_Name);
            cmd.Parameters.AddWithValue("p_PG_Payment_Gateway", String.IsNullOrEmpty(smodel.PG_Payment_Gateway) ? "" : smodel.PG_Payment_Gateway);

            cmd.Parameters.AddWithValue("p_PG_Bank_Reference_No", String.IsNullOrEmpty(smodel.PG_Bank_Reference_No) ? "" : smodel.PG_Bank_Reference_No);
            cmd.Parameters.AddWithValue("p_PG_International_Domestic", String.IsNullOrEmpty(smodel.PG_International_Domestic) ? "" : smodel.PG_International_Domestic);
            cmd.Parameters.AddWithValue("p_PG_Payment_Type", String.IsNullOrEmpty(smodel.PG_Payment_Type) ? "" : smodel.PG_Payment_Type);
            cmd.Parameters.AddWithValue("p_PG_Error_Code", String.IsNullOrEmpty(smodel.PG_Error_Code) ? "" : smodel.PG_Error_Code);
            cmd.Parameters.AddWithValue("p_PG_Error_Message", String.IsNullOrEmpty(smodel.PG_Error_Message) ? "" : smodel.PG_Error_Message);
            cmd.Parameters.AddWithValue("p_PG_Name_on_Card", String.IsNullOrEmpty(smodel.PG_Name_on_Card) ? "" : smodel.PG_Name_on_Card);
            cmd.Parameters.AddWithValue("p_PG_Card_Number", String.IsNullOrEmpty(smodel.PG_Card_Number) ? "" : smodel.PG_Card_Number);

            cmd.Parameters.AddWithValue("p_PG_Address_Line1", String.IsNullOrEmpty(smodel.PG_Address_Line1) ? "" : smodel.PG_Address_Line1);
            cmd.Parameters.AddWithValue("p_PG_Address_Line2", String.IsNullOrEmpty(smodel.PG_Address_Line2) ? "" : smodel.PG_Address_Line2);
            cmd.Parameters.AddWithValue("p_PG_State", String.IsNullOrEmpty(smodel.PG_State) ? "" : smodel.PG_State);
            cmd.Parameters.AddWithValue("p_PG_Country", String.IsNullOrEmpty(smodel.PG_Country) ? "" : smodel.PG_Country);
            cmd.Parameters.AddWithValue("p_PG_ZipCode", String.IsNullOrEmpty(smodel.PG_ZipCode) ? "" : smodel.PG_ZipCode);

            cmd.Parameters.AddWithValue("p_PG_Shipping_Firstname", String.IsNullOrEmpty(smodel.PG_Shipping_Firstname) ? "" : smodel.PG_Shipping_Firstname);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Lastname", String.IsNullOrEmpty(smodel.PG_Shipping_Lastname) ? "" : smodel.PG_Shipping_Lastname);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Address1", String.IsNullOrEmpty(smodel.PG_Shipping_Address1) ? "" : smodel.PG_Shipping_Address1);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Address2", String.IsNullOrEmpty(smodel.PG_Shipping_Address2) ? "" : smodel.PG_Shipping_Address2);
            cmd.Parameters.AddWithValue("p_PG_Shipping_City", String.IsNullOrEmpty(smodel.PG_Shipping_City) ? "" : smodel.PG_Shipping_City);
            cmd.Parameters.AddWithValue("p_PG_Shipping_State", String.IsNullOrEmpty(smodel.PG_Shipping_State) ? "" : smodel.PG_Shipping_State);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Country", String.IsNullOrEmpty(smodel.PG_Shipping_Country) ? "" : smodel.PG_Shipping_Country);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Zipcode", String.IsNullOrEmpty(smodel.PG_Shipping_Zipcode) ? "" : smodel.PG_Shipping_Zipcode);
            cmd.Parameters.AddWithValue("p_PG_Shipping_Phone", String.IsNullOrEmpty(smodel.PG_Shipping_Phone) ? "" : smodel.PG_Shipping_Phone);

            cmd.Parameters.AddWithValue("p_PG_Transaction_Fee", smodel.PG_Transaction_Fee);
            cmd.Parameters.AddWithValue("p_PG_Discount", smodel.PG_Discount == null ? 0 : smodel.PG_Discount);
            cmd.Parameters.AddWithValue("p_PG_Additional_Charges", smodel.PG_Additional_Charges);
            cmd.Parameters.AddWithValue("p_PG_Amount_INR",smodel.PG_Amount_INR);
            cmd.Parameters.AddWithValue("p_PG_UDF_1", String.IsNullOrEmpty(smodel.PG_UDF_1) ? "0" : smodel.PG_UDF_1);
            cmd.Parameters.AddWithValue("p_PG_UDF_2", String.IsNullOrEmpty(smodel.PG_UDF_2) ? "0" : smodel.PG_UDF_2);
            cmd.Parameters.AddWithValue("p_PG_UDF_3", String.IsNullOrEmpty(smodel.PG_UDF_3) ? "0" : smodel.PG_UDF_3);
            cmd.Parameters.AddWithValue("p_PG_UDF_4", String.IsNullOrEmpty(smodel.PG_UDF_4) ? "0" : smodel.PG_UDF_4);
            cmd.Parameters.AddWithValue("p_PG_UDF_5", String.IsNullOrEmpty(smodel.PG_UDF_5) ? "" : smodel.PG_UDF_5);

            cmd.Parameters.AddWithValue("p_PG_Device_Info", String.IsNullOrEmpty(smodel.PG_Device_Info) ? "" : smodel.PG_Device_Info);
            cmd.Parameters.AddWithValue("p_PG_HashKey", String.IsNullOrEmpty(smodel.PG_HashKey) ? "" : smodel.PG_HashKey);
            cmd.Parameters.AddWithValue("p_PG_ServiceProvider", String.IsNullOrEmpty(smodel.PG_ServiceProvider) ? "" : smodel.PG_ServiceProvider);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 0);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_IsConditional", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i < 1)
                return true;
            else
                return false;
        }

        public DateTime datefun(string valuedate)
        {
            DateTime defaultdate = new DateTime(1919, 1, 1);
            if (valuedate != DBNull.Value.ToString())
            {
                IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
                String datetime = valuedate.Trim();
                DateTime dt = DateTime.Parse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                return dt;
            }
            else
                return defaultdate;
        }

        public List<ClsPrp_AgentRenewalApplication_PaymentIntegration> Display_AgentRenewalApplication_Payment(Int64 Agent_ID, Int32 TypeAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalSequence_ID, Int32 Renewal_Year, string KeyFlag, string UserID)
        {
            connection();
            List<ClsPrp_AgentRenewalApplication_PaymentIntegration> AgentApplication_List = new List<ClsPrp_AgentRenewalApplication_PaymentIntegration>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_PaymentGatewayDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", TypeAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalSequence_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_Year", Renewal_Year);
                cmd.Parameters.AddWithValue("p_KeyFlag", KeyFlag);
                cmd.Parameters.AddWithValue("p_UserID", UserID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsPrp_AgentRenewalApplication_PaymentIntegration
                           {
                               PaymentRefNumberRenewalAgent_IndexID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_IndexID"]),
                               PaymentRefNumberRenewalAgent_ID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_ID"]),
                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                               Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? "0" : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                               Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                               Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? "0" : Convert.ToString(dr["Related_UserID"]),
                               Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? "0" : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                               Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),

                               RelatedAgent_Code = Convert.ToString(dr["RelatedAgent_Code"]),
                               RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               AgentType_IO = Convert.ToString(dr["AgentType_IO"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Agent_BriefSummary = Convert.ToString(dr["Agent_BriefSummary"]),
                               IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                               PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                               FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                               PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                               PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                               PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                               PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                               PG_Status = Convert.ToString(dr["PG_Status"]),
                               PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                               PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                               PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                               PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                               PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                               PG_City = Convert.ToString(dr["PG_City"]),
                               PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                               PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                               PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                               PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                               PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                               PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                               PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                               PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                               PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                               PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                               PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                               PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                               PG_State = Convert.ToString(dr["PG_State"]),
                               PG_Country = Convert.ToString(dr["PG_Country"]),
                               PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                               PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                               PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                               PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                               PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                               PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                               PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                               PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                               PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                               PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                               PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                               PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                               PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                               PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                               PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                               PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                               PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                               PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                               PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                               PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                               PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                               PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }

        public List<ClsPrp_AgentRenewalApplication_PaymentIntegration> Display_AgentRenewalApplication_PaymentById(Int64 Agent_ID, Int32 TypeAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalSequence_ID, Int32 Renewal_Year, Int64 AgentRenewalPayment_IndexID, Int64 AgentRenewalPayment_ID, Int64 Payment_ID, string KeyFlag)
        {
            connection();
            List<ClsPrp_AgentRenewalApplication_PaymentIntegration> AgentApplication_List = new List<ClsPrp_AgentRenewalApplication_PaymentIntegration>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_PaymentGatewayDetailsById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", TypeAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalSequence_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_Year", Renewal_Year);
                cmd.Parameters.AddWithValue("p_KeyFlag", KeyFlag);
                cmd.Parameters.AddWithValue("p_PaymentAgentRenewal_IndexID", AgentRenewalPayment_IndexID);
                cmd.Parameters.AddWithValue("p_PaymentAgentRenewal_ID", AgentRenewalPayment_ID);
                cmd.Parameters.AddWithValue("p_Payment_ID", Payment_ID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsPrp_AgentRenewalApplication_PaymentIntegration
                           {
                               PaymentRefNumberRenewalAgent_IndexID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_IndexID"]),
                               PaymentRefNumberRenewalAgent_ID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_ID"]),
                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                               Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? "0" : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                               Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                               Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? "0" : Convert.ToString(dr["Related_UserID"]),
                               Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? "0" : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                               Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),

                               RelatedAgent_Code = Convert.ToString(dr["RelatedAgent_Code"]),
                               RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               AgentType_IO = Convert.ToString(dr["AgentType_IO"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Agent_BriefSummary = Convert.ToString(dr["Agent_BriefSummary"]),
                               IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                               PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                               FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                               PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                               PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                               PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                               PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                               PG_Status = Convert.ToString(dr["PG_Status"]),
                               PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                               PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                               PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                               PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                               PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                               PG_City = Convert.ToString(dr["PG_City"]),
                               PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                               PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                               PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                               PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                               PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                               PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                               PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                               PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                               PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                               PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                               PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                               PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                               PG_State = Convert.ToString(dr["PG_State"]),
                               PG_Country = Convert.ToString(dr["PG_Country"]),
                               PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                               PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                               PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                               PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                               PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                               PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                               PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                               PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                               PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                               PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                               PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                               PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                               PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                               PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                               PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                               PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                               PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                               PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                               PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                               PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                               PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                               PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }

        public List<ClsPrp_AgentRenewalApplication_PaymentIntegration> Display_AgentRenewalApplication_PaymentByPRNumber(Int64 AgentRenewalApplication_PRNumber, string KayFlag)
        {
            connection();
            List<ClsPrp_AgentRenewalApplication_PaymentIntegration> AgentApplication_List = new List<ClsPrp_AgentRenewalApplication_PaymentIntegration>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_PaymentGatewayDetailsByPRN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_PaymentAgent_ID", AgentRenewalApplication_PRNumber);
                cmd.Parameters.AddWithValue("p_KayFlag", KayFlag);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsPrp_AgentRenewalApplication_PaymentIntegration
                           {
                               PaymentRefNumberRenewalAgent_IndexID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_IndexID"]),
                               PaymentRefNumberRenewalAgent_ID = Convert.ToInt64(dr["PaymentRefNumberRenewalAgent_ID"]),
                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                               Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentDiaryNumber_Name = String.IsNullOrEmpty(Convert.ToString(dr["Related_AgentDiaryNumber_Name"])) ? "0" : Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                               Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                               Related_UserID = String.IsNullOrEmpty(Convert.ToString(dr["Related_UserID"])) ? "0" : Convert.ToString(dr["Related_UserID"]),
                               Related_RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["Related_RERAnumberRegistration"])) ? "0" : Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                               Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),

                               RelatedAgent_Code = Convert.ToString(dr["RelatedAgent_Code"]),
                               RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               AgentType_IO = Convert.ToString(dr["AgentType_IO"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Agent_BriefSummary = Convert.ToString(dr["Agent_BriefSummary"]),
                               IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                               PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                               FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                               PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                               PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                               PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                               PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                               PG_Status = Convert.ToString(dr["PG_Status"]),
                               PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                               PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                               PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                               PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                               PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                               PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                               PG_City = Convert.ToString(dr["PG_City"]),
                               PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                               PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                               PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                               PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                               PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                               PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                               PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                               PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                               PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                               PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                               PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                               PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                               PG_State = Convert.ToString(dr["PG_State"]),
                               PG_Country = Convert.ToString(dr["PG_Country"]),
                               PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                               PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                               PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                               PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                               PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                               PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                               PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                               PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                               PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                               PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                               PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                               PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                               PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                               PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                               PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                               PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                               PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                               PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                               PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                               PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                               PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                               PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }

        public List<ClsPrp_AgentRenewalApplication_Ind_OTInd> Display_AgentRenewalApplication_ProfileByID(Int64 Agent_ID, Int32 TypeAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalSequence_ID, Int32 Renewal_Year, string KeyFlag)
        {
            connection();
            List<ClsPrp_AgentRenewalApplication_Ind_OTInd> AgentApplication_List = new List<ClsPrp_AgentRenewalApplication_Ind_OTInd>();

            try
            {              
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_ApplicationPaymentProfileByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", TypeAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalSequence_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_Year", Renewal_Year);
                cmd.Parameters.AddWithValue("p_KeyFlag", KeyFlag);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentApplication_List.Add(
                           new ClsPrp_AgentRenewalApplication_Ind_OTInd
                           {
                               RenewalAgent_IndexID = Convert.ToInt64(dr["RenewalAgent_IndexID"]),
                               RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),

                               Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                               Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                               Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                               Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                               Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                               Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                               Related_UserID = Convert.ToString(dr["Related_UserID"]),
                               Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                               Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                               Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                               Related_Agent_IndexID = Convert.ToInt64(dr["Related_Agent_IndexID"]),

                               IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                               Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                               Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                               Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                               Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                               Father_FirstName = Convert.ToString(dr["Father_FirstName"]),
                               Father_MiddleName = Convert.ToString(dr["Father_MiddleName"]),
                               Father_LastName = Convert.ToString(dr["Father_LastName"]),
                               Occupation = Convert.ToString(dr["Occupation"]),
                               Image_FileName = Convert.ToString(dr["Image_FileName"]),
                               Image_FilePath = Convert.ToString(dr["Image_FilePath"]),
                               P_AddressLine1 = Convert.ToString(dr["P_AddressLine1"]),
                               P_AddressLine2 = Convert.ToString(dr["P_AddressLine2"]),
                               P_AddressStateCode = Convert.ToString(dr["P_AddressStateCode"]),
                               P_AddressDistrictCode = Convert.ToString(dr["P_AddressDistrictCode"]),
                               P_AddressPIN = Convert.ToString(dr["P_AddressPIN"]),
                               Organization_Name = Convert.ToString(dr["Organization_Name"]),
                               Organization_TypeCode = Convert.ToInt32(dr["Organization_TypeCode"]),
                               Organization_MainObjects = Convert.ToString(dr["Organization_MainObjects"]),
                               RegOffice_AddressLine1 = Convert.ToString(dr["RegOffice_AddressLine1"]),
                               RegOffice_AddressLine2 = Convert.ToString(dr["RegOffice_AddressLine2"]),
                               RegOffice_AddressStateCode = Convert.ToString(dr["RegOffice_AddressStateCode"]),
                               RegOffice_AddressDistrictCode = Convert.ToString(dr["RegOffice_AddressDistrictCode"]),
                               RegOffice_AddressPIN = Convert.ToInt32(dr["RegOffice_AddressPIN"]),
                               BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                               BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                               BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                               BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                               BusinessPlace_AddressPIN = Convert.ToInt32(dr["BusinessPlace_AddressPIN"]),
                               IsSameBussinessAdd_CommAdd = Convert.ToString(dr["IsSameBussinessAdd_CommAdd"]),
                               BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                               BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                               BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                               BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                               BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),
                               AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                               AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                               AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                               MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                               PhoneNumber_STD = Convert.ToInt64(dr["PhoneNumber_STD"]),
                               PhoneNumber_Number = Convert.ToInt64(dr["PhoneNumber_Number"]),
                               EmailAddress = Convert.ToString(dr["EmailAddress"]),
                               PAN_Number = Convert.ToString(dr["PAN_Number"]),
                               Aadhaar_Number = Convert.ToInt64(dr["Aadhaar_Number"]),
                               IsOtherOrganizationMembers = Convert.ToString(dr["IsOtherOrganizationMembers"]),
                               IsOtherStateUT_RERAregistration = Convert.ToString(dr["IsOtherStateUT_RERAregistration"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               C_column = Convert.ToString(dr["C_column"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsConditional = Convert.ToInt32(dr["IsConditional"]),

                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch(Exception ex)
            {
                string strex = ex.ToString();
            }
            return AgentApplication_List;
        }

        public List<ClsPrp_AgentRenewalPayment> Display_AgentRenewalPaymentDetailsByID(Int64 Agent_ID, Int64 RenewalAgent_ID, Int32 RenewalSequence_ID, Int32 Renewal_Year, Int64 AgentPayment_ID, string KeyFlag)
        {
            connection();
            List<ClsPrp_AgentRenewalPayment> list_indPro = new List<ClsPrp_AgentRenewalPayment>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_AgentRenewalPaymentDetailsByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_AgentPayment_ID", AgentPayment_ID);
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Agent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalSequence_ID);
                cmd.Parameters.AddWithValue("p_RenewalAgent_Year", Renewal_Year);
                cmd.Parameters.AddWithValue("p_KeyFlag", KeyFlag);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list_indPro.Add(
                        new ClsPrp_AgentRenewalPayment
                        {
                            RenewalAgent_FeePayment_IndexID = Convert.ToInt64(dr["RenewalAgent_FeePayment_IndexID"]),
                            RenewalAgent_FeePayment_ID = Convert.ToInt64(dr["RenewalAgent_FeePayment_ID"]),

                            Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                            Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                            Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                            Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                            Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                            Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                            Related_UserID = Convert.ToString(dr["Related_UserID"]),
                            Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                            Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),
                            Related_AgentPayment_ID = Convert.ToInt64(dr["Related_AgentPayment_ID"]),

                            AgentPayment_TitleCode = Convert.ToInt32(dr["AgentPayment_TitleCode"]),
                            AgentPayment_TitleName = Convert.ToString(dr["AgentPayment_TitleName"]),
                            Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                            Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                            Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                            Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                            Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                            Bank_Name = Convert.ToString(dr["Bank_Name"]),
                            Branch_Name = Convert.ToString(dr["Branch_Name"]),
                            DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                            DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                            ImageDDorBankersCheque_FileName = Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                            ImageDDorBankersCheque_FilePath = Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),
                            Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        //A_column = Convert.ToString(dr["A_column"]),
                        //B_column = Convert.ToString(dr["B_column"]),
                        //C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                            IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            IsLock = Convert.ToInt32(dr["IsLock"]),
                            IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                            IsConditional = Convert.ToInt32(dr["IsConditional"]),

                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            ModifyOn = Convert.ToDateTime(dr["CreatedOn"]),//  Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return list_indPro;
        }
    }
}
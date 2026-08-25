using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.classProjectExtensionPayment
{
    public class ClsMethod_ProjectExtensionApplication_PaymentIntegration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_ProjectExtensionApplication_Payment(ClsPrp_ProjectExtensionApplication_PaymentIntegration smodel, string UID, string UserName, string txID, string UDF1)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_pg_insert_tbl_rera_project_paymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentRefNumberProjectPm_IndexID", smodel.PaymentRefNumberProjectPm_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefNumberProjectPm_ID", smodel.PaymentRefNumberProjectPm_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", smodel.RelatedProject_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", smodel.RelatedPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_Code", String.IsNullOrEmpty(smodel.RelatedProject_Code) ? "0" : smodel.RelatedProject_Code);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_Code", String.IsNullOrEmpty(smodel.RelatedPromoter_Code) ? "0" : smodel.RelatedPromoter_Code);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", smodel.RelatedPayment_ID);
            cmd.Parameters.AddWithValue("p_RelatedPayment_IndexID", smodel.RelatedPayment_IndexID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ProjectPmZoneType", String.IsNullOrEmpty(smodel.ProjectPmZoneType) ? "" : smodel.ProjectPmZoneType);
            cmd.Parameters.AddWithValue("p_PromoterType_IO", String.IsNullOrEmpty(smodel.PromoterType_IO) ? "" : smodel.PromoterType_IO);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);

            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_ID", smodel.Related_ProjectExtension_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_SequenceID", smodel.Related_ProjectExtension_SequenceID);
            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_Year", smodel.Related_ProjectExtension_Year);

            cmd.Parameters.AddWithValue("p_ProjectPm_BriefSummary", String.IsNullOrEmpty(smodel.ProjectPm_BriefSummary) ? "" : smodel.ProjectPm_BriefSummary);
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
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);

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

        public bool Update_ProjectExtensionApplication_Payment(ClsPrp_ProjectExtensionApplication_PaymentIntegration smodel, String UID, String UserName, Int32 IsPaymentSuccessCompleteFlag)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_pg_update_tbl_rera_project_paymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentRefNumberProjectPm_IndexID", smodel.PaymentRefNumberProjectPm_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefNumberProjectPm_ID", smodel.PaymentRefNumberProjectPm_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", smodel.RelatedProject_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", smodel.RelatedPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_Code", String.IsNullOrEmpty(smodel.RelatedProject_Code) ? "0" : smodel.RelatedProject_Code);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_Code", String.IsNullOrEmpty(smodel.RelatedPromoter_Code) ? "0" : smodel.RelatedPromoter_Code);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", smodel.RelatedPayment_ID);
            cmd.Parameters.AddWithValue("p_RelatedPayment_IndexID", smodel.RelatedPayment_IndexID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ProjectPmZoneType", String.IsNullOrEmpty(smodel.ProjectPmZoneType) ? "" : smodel.ProjectPmZoneType);
            cmd.Parameters.AddWithValue("p_PromoterType_IO", String.IsNullOrEmpty(smodel.PromoterType_IO) ? "" : smodel.PromoterType_IO);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);

            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_ID", smodel.Related_ProjectExtension_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_SequenceID", smodel.Related_ProjectExtension_SequenceID);
            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_Year", smodel.Related_ProjectExtension_Year);

            cmd.Parameters.AddWithValue("p_ProjectPm_BriefSummary", String.IsNullOrEmpty(smodel.ProjectPm_BriefSummary) ? "" : smodel.ProjectPm_BriefSummary);
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
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);

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

        public bool Update_ProjectExtensionApplication_PaymentByAPI(ClsPrp_ProjectExtensionApplication_PaymentIntegration smodel, String UID, String UserName, Int32 IsPaymentSuccessCompleteFlag)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_pg_update_tbl_rera_project_paymentgateway_ByAPI", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentRefNumberProjectPm_IndexID", smodel.PaymentRefNumberProjectPm_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefNumberProjectPm_ID", smodel.PaymentRefNumberProjectPm_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", smodel.RelatedProject_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", smodel.RelatedPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_Code", String.IsNullOrEmpty(smodel.RelatedProject_Code) ? "0" : smodel.RelatedProject_Code);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_Code", String.IsNullOrEmpty(smodel.RelatedPromoter_Code) ? "0" : smodel.RelatedPromoter_Code);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", smodel.RelatedPayment_ID);
            cmd.Parameters.AddWithValue("p_RelatedPayment_IndexID", smodel.RelatedPayment_IndexID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ProjectPmZoneType", String.IsNullOrEmpty(smodel.ProjectPmZoneType) ? "" : smodel.ProjectPmZoneType);
            cmd.Parameters.AddWithValue("p_PromoterType_IO", String.IsNullOrEmpty(smodel.PromoterType_IO) ? "" : smodel.PromoterType_IO);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);

            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_ID", smodel.Related_ProjectExtension_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_SequenceID", smodel.Related_ProjectExtension_SequenceID);
            cmd.Parameters.AddWithValue("p_Related_ProjectExtension_Year", smodel.Related_ProjectExtension_Year);

            cmd.Parameters.AddWithValue("p_ProjectPm_BriefSummary", String.IsNullOrEmpty(smodel.ProjectPm_BriefSummary) ? "" : smodel.ProjectPm_BriefSummary);
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
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);

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

        public List<ClsPrp_ProjectExtensionApplication_PaymentIntegration> Display_ProjectExtensionApplication_Payment(Int64 Project_ID, Int64 Promoter_ID, Int64 RelatedProjectExtn_ID, Int32 RelatedProjectExtn_SequenceID, Int32 RelatedProjectExtn_Year)
        {
            connection();
            List<ClsPrp_ProjectExtensionApplication_PaymentIntegration> ProjectExtensionApplication_List = new List<ClsPrp_ProjectExtensionApplication_PaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("usp_pg_Display_Rera_Project_PaymentGatewayDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_ID", RelatedProjectExtn_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_SequenceID", RelatedProjectExtn_SequenceID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_Year", RelatedProjectExtn_Year);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectExtensionApplication_List.Add(
                       new ClsPrp_ProjectExtensionApplication_PaymentIntegration
                       {
                           PaymentRefNumberProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_IndexID"]),
                           PaymentRefNumberProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),

                           Related_ProjectExtension_ID = Convert.ToInt64(dr["Related_ProjectExtension_ID"]),
                           Related_ProjectExtension_SequenceID = Convert.ToInt32(dr["Related_ProjectExtension_SequenceID"]),
                           Related_ProjectExtension_Year = Convert.ToInt32(dr["Related_ProjectExtension_Year"]),

                           ProjectPm_BriefSummary = Convert.ToString(dr["ProjectPm_BriefSummary"]),
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
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectExtensionApplication_List;
        }

        public List<ClsPrp_ProjectExtensionApplication_PaymentIntegration> Display_ProjectExtensionApplication_PaymentById(Int64 Project_ID, Int64 Promoter_ID, Int64 RelatedProjectExtn_ID, Int32 RelatedProjectExtn_SequenceID, Int32 RelatedProjectExtn_Year, Int64 ProjectPmPayment_IndexID, Int64 ProjectPmPayment_ID, Int64 RelatedPayment_ID)
        {

            connection();
            List<ClsPrp_ProjectExtensionApplication_PaymentIntegration> ProjectExtensionApplication_List = new List<ClsPrp_ProjectExtensionApplication_PaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("usp_pg_Display_Rera_Project_PaymentGatewayDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_ID", RelatedProjectExtn_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_SequenceID", RelatedProjectExtn_SequenceID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_Year", RelatedProjectExtn_Year);
            cmd.Parameters.AddWithValue("p_PaymentRefProject_IndexID", ProjectPmPayment_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentRefProject_ID", ProjectPmPayment_ID);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", RelatedPayment_ID);
            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();            

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectExtensionApplication_List.Add(
                       new ClsPrp_ProjectExtensionApplication_PaymentIntegration
                       {
                           PaymentRefNumberProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_IndexID"]),
                           PaymentRefNumberProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),

                           Related_ProjectExtension_ID = Convert.ToInt64(dr["Related_ProjectExtension_ID"]),
                           Related_ProjectExtension_SequenceID = Convert.ToInt32(dr["Related_ProjectExtension_SequenceID"]),
                           Related_ProjectExtension_Year = Convert.ToInt32(dr["Related_ProjectExtension_Year"]),

                           ProjectPm_BriefSummary = Convert.ToString(dr["ProjectPm_BriefSummary"]),
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
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectExtensionApplication_List;
        }

        public List<ClsPrp_ProjectExtensionApplication_PaymentIntegration> Display_ProjectExtensionApplication_PaymentByPRN(Int64 ProjectExtensionApplication_PRN, Int64 RelatedProjectExtn_ID, Int32 RelatedProjectExtn_SequenceID, Int32 RelatedProjectExtn_Year)
        {
            connection();
            List<ClsPrp_ProjectExtensionApplication_PaymentIntegration> ProjectExtensionApplication_List = new List<ClsPrp_ProjectExtensionApplication_PaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("usp_pg_Display_Rera_Project_PaymentGatewayDetailsByPRN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_PaymentProjectPRN_ID", ProjectExtensionApplication_PRN);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_ID", RelatedProjectExtn_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_SequenceID", RelatedProjectExtn_SequenceID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_Year", RelatedProjectExtn_Year);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectExtensionApplication_List.Add(
                       new ClsPrp_ProjectExtensionApplication_PaymentIntegration
                       {
                           PaymentRefNumberProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_IndexID"]),
                           PaymentRefNumberProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),

                           Related_ProjectExtension_ID = Convert.ToInt64(dr["Related_ProjectExtension_ID"]),
                           Related_ProjectExtension_SequenceID = Convert.ToInt32(dr["Related_ProjectExtension_SequenceID"]),
                           Related_ProjectExtension_Year = Convert.ToInt32(dr["Related_ProjectExtension_Year"]),

                           ProjectPm_BriefSummary = Convert.ToString(dr["ProjectPm_BriefSummary"]),
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
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectExtensionApplication_List;
        }

        public List<ClsPrp_ProjectExtensionApplication_Registration> Display_ProjectExtensionApplication_RegistrationByID(Int64 Project_ID, Int64 Promoter_ID, Int64 RelatedProjectExtn_ID, Int32 RelatedProjectExtn_SequenceID, Int32 RelatedProjectExtn_Year)
        {
            connection();
            List<ClsPrp_ProjectExtensionApplication_Registration> ProjectExtensionApplication_List = new List<ClsPrp_ProjectExtensionApplication_Registration>();

            MySqlCommand cmd = new MySqlCommand("usp_pg_Display_Rera_Project_RegistrationProfileByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_ID", RelatedProjectExtn_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_SequenceID", RelatedProjectExtn_SequenceID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_Year", RelatedProjectExtn_Year);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectExtensionApplication_List.Add(
                       new ClsPrp_ProjectExtensionApplication_Registration
                       {
                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Related_ProjectExtension_ID = Convert.ToInt64(dr["Related_ProjectExtension_ID"]),
                           Related_ProjectExtension_SequenceID = Convert.ToInt32(dr["Related_ProjectExtension_SequenceID"]),
                           Related_ProjectExtension_Year = Convert.ToInt32(dr["Related_ProjectExtension_Year"]),

                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           Project_Status = Convert.ToString(dr["Project_Status"]),
                           ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                           ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                           ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),
                           ProjectRegistrationProvided_Duration = Convert.ToString(dr["ProjectRegistrationProvided_Duration"]),
                           ProjectDelayReason_IfAny = Convert.ToString(dr["ProjectDelayReason_IfAny"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToInt32(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToInt32(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToInt32(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),
                           Project_PotentialZoneCode = Convert.ToInt32(dr["Project_PotentialZoneCode"]),
                           ProjectWebsite_WebLink = Convert.ToString(dr["ProjectWebsite_WebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),

                           IsProForma_AOS_RERAformat_AnnexureA = Convert.ToString(dr["IsProForma_AOS_RERAformat_AnnexureA"]),
                           IsProForma_AOS_RERAformat_No_IsApproved = Convert.ToString(dr["IsProForma_AOS_RERAformat_No_IsApproved"]),
                           IsProject_MegaProjectCategory = Convert.ToString(dr["IsProject_MegaProjectCategory"]),
                           IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToDecimal(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Used_ID = Convert.ToString(dr["Used_ID"]),

                           ProjectRegistration_RegdReraNumber = Convert.ToString(dr["ProjectRegistration_RegdReraNumber"]),
                           ProjectRegistration_IssueDate = Convert.ToDateTime(dr["ProjectRegistration_IssueDate"]),
                           ProjectRegistration_ValidUptoDate = Convert.ToDateTime(dr["ProjectRegistration_ValidUptoDate"]),

                           Project_AddressStateCodeName = Convert.ToString(dr["Project_AddressStateCodeName"]),
                           Project_AddressDistrictCodeName = Convert.ToString(dr["Project_AddressDistrictCodeName"]),
                           Project_AddressSubDivisionCodeName = Convert.ToString(dr["Project_AddressSubDivisionCodeName"]),
                           Project_PotentialZoneCodeName = Convert.ToString(dr["Project_PotentialZoneCodeName"]),
                           AuthorizedPerson_AddressStateCodeName = Convert.ToString(dr["AuthorizedPerson_AddressStateCodeName"]),
                           AuthorizedPerson_AddressDistrictCodeName = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCodeName"]),
                       });
            }
            return ProjectExtensionApplication_List;
        }

        public List<ClsPrp_ProjectExtensionPayment> Display_ProjectExtensionPaymentDetailsByID(Int64 Project_ID, Int64 Promoter_ID, Int64 ProjectExtensionPayment_ID, Int64 RelatedProjectExtn_ID, Int32 RelatedProjectExtn_SequenceID, Int32 RelatedProjectExtn_Year)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_pg_Display_Rera_Project_PaymentDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedPayment_ID", ProjectExtensionPayment_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_ID", RelatedProjectExtn_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_SequenceID", RelatedProjectExtn_SequenceID);
            cmd.Parameters.AddWithValue("p_RelatedProjectExtension_Year", RelatedProjectExtn_Year);

            connection();
            List<ClsPrp_ProjectExtensionPayment> list_projectExtension = new List<ClsPrp_ProjectExtensionPayment>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_projectExtension.Add(
                    new ClsPrp_ProjectExtensionPayment
                    {
                        ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                        ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),

                        ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                        //ProjectPaymentRelated_Promoter_ID = Convert.ToInt64(dr["ProjectPaymentRelated_Promoter_ID"]),

                        Related_ProjectExtension_ID = Convert.ToInt64(dr["Related_ProjectExtension_ID"]),
                        Related_ProjectExtension_SequenceID = Convert.ToInt32(dr["Related_ProjectExtension_SequenceID"]),
                        Related_ProjectExtension_Year = Convert.ToInt32(dr["Related_ProjectExtension_Year"]),

                        ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                        ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),

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
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        //C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return list_projectExtension;
        }
    }
}
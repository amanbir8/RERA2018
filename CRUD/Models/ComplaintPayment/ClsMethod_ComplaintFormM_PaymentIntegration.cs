using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.ComplaintPayment;

namespace CRUD.Models.ClassComplaintPayment
{
    public class ClsMethod_ComplaintFormM_PaymentIntegration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_ComplaintFormM_Payment(ClsPrp_ComplaintFormM_PaymentIntegration smodel, string UID, string UserName, string txID, string UDF1)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_paymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentComplaint_IndexID", smodel.PaymentComplaint_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", smodel.PaymentComplaint_ID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_ID", smodel.PaymentComplaint_RelatedComplainant_ID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_Code", String.IsNullOrEmpty(smodel.PaymentComplaint_RelatedComplainant_Code) ? "0" : smodel.PaymentComplaint_RelatedComplainant_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", String.IsNullOrEmpty(smodel.ComplaintType_MN) ? "" : smodel.ComplaintType_MN);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_Complaint_BriefSummary", String.IsNullOrEmpty(smodel.Complaint_BriefSummary) ? "" : smodel.Complaint_BriefSummary);
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
        public bool Update_ComplaintFormM_Payment(ClsPrp_ComplaintFormM_PaymentIntegration smodel, String UID, String UserName, Int32 IsPaymentSuccessCompleteFlag)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formm_paymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_PaymentComplaint_IndexID", smodel.PaymentComplaint_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", smodel.PaymentComplaint_ID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_ID", smodel.PaymentComplaint_RelatedComplainant_ID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_Code", String.IsNullOrEmpty(smodel.PaymentComplaint_RelatedComplainant_Code) ? "0" : smodel.PaymentComplaint_RelatedComplainant_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", String.IsNullOrEmpty(smodel.ComplaintType_MN) ? "" : smodel.ComplaintType_MN);
            cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_Complaint_BriefSummary", String.IsNullOrEmpty(smodel.Complaint_BriefSummary) ? "" : smodel.Complaint_BriefSummary);
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
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
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

        public List<ClsPrp_ComplaintFormM_PaymentIntegration> Display_ComplaintFormM_Payment(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_ComplaintFormM_PaymentIntegration> ComplaintFormM_List = new List<ClsPrp_ComplaintFormM_PaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_PaymentGatewayDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_List.Add(
                       new ClsPrp_ComplaintFormM_PaymentIntegration
                       {
                           PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                           PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                           PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                           PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
            return ComplaintFormM_List;
        }
        public List<ClsPrp_ComplaintFormM_PaymentIntegration> Display_ComplaintFormM_PaymentById(Int64 ComplaintFormM_ID, Int64 ComplaintPayment_IndexID, Int64 ComplaintPayment_ID)
        {

            connection();
            List<ClsPrp_ComplaintFormM_PaymentIntegration> ComplaintFormM_ID_List = new List<ClsPrp_ComplaintFormM_PaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_PaymentGatewayDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_IndexID", ComplaintPayment_IndexID);
            cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", ComplaintPayment_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_ID_List.Add(
                       new ClsPrp_ComplaintFormM_PaymentIntegration
                       {
                           PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                           PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                           PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                           PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
            return ComplaintFormM_ID_List;
        }

        public List<ClsPrp_ComplaintFormM_PaymentIntegration> Display_ComplaintFormM_PaymentByPRNumber(Int64 ComplaintFormM_PRNumber)
        {
            connection();
            List<ClsPrp_ComplaintFormM_PaymentIntegration> ComplaintFormM_List = new List<ClsPrp_ComplaintFormM_PaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_PaymentGatewayDetailsByPRN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", ComplaintFormM_PRNumber);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_List.Add(
                       new ClsPrp_ComplaintFormM_PaymentIntegration
                       {
                           PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                           PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                           PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                           PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
            return ComplaintFormM_List;
        }



        #region EXECUTION

        public List<ClsPrp_ComplaintExecutionForm_PaymentIntegration> Display_ComplaintFormExecution_Payment(Int64 ExecutionIndexId)
        {
            try
            {
                connection();
                List<ClsPrp_ComplaintExecutionForm_PaymentIntegration> ComplaintFormM_List = new List<ClsPrp_ComplaintExecutionForm_PaymentIntegration>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_PaymentGatewayDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintFormExecution_ID", ExecutionIndexId);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ComplaintFormM_List.Add(
                           new ClsPrp_ComplaintExecutionForm_PaymentIntegration
                           {
                               PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                               PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                               PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                               PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                               Related_ComplaintFormMId = Convert.ToInt64(dr["Related_ComplaintFormMId"]),
                               Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                               Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
                               Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
                               PG_Shipping_Aemail = Convert.ToString(dr["PG_Shipping_Aemail"]),

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
                return ComplaintFormM_List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 Add_ComplaintFormExecution_Payment(ClsPrp_ComplaintExecutionForm_PaymentIntegration smodel, string UID, string UserName, string txID, string UDF1)
        {
            try
            {
                connection();
                //MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_execution_form_paymentgateway", con);
                MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_form_execution_paymentgateway", con);
                cmd.CommandType = CommandType.StoredProcedure;

                #region Parameters
                cmd.Parameters.AddWithValue("p_PaymentComplaint_IndexID", smodel.PaymentComplaint_IndexID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", smodel.PaymentComplaint_ID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_ID", smodel.PaymentComplaint_RelatedComplainant_ID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_Code", String.IsNullOrEmpty(smodel.PaymentComplaint_RelatedComplainant_Code) ? "0" : smodel.PaymentComplaint_RelatedComplainant_Code);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_Related_ComplaintFormMId", smodel.Related_ComplaintFormMId == null ? 0 : smodel.Related_ComplaintFormMId);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_Related_FormExe_SequenceID", smodel.Related_FormExe_SequenceID == null ? 0 : smodel.Related_FormExe_SequenceID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_Related_FormExe_Year", smodel.Related_FormExe_Year == null ? 0 : smodel.Related_FormExe_Year);
                cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
                cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

                cmd.Parameters.AddWithValue("p_ComplaintType_MN", String.IsNullOrEmpty(smodel.ComplaintType_MN) ? "" : smodel.ComplaintType_MN);
                cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
                cmd.Parameters.AddWithValue("p_Complaint_BriefSummary", String.IsNullOrEmpty(smodel.Complaint_BriefSummary) ? "" : smodel.Complaint_BriefSummary);
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
                cmd.Parameters.AddWithValue("p_PG_Shipping_Aemail", String.IsNullOrEmpty(smodel.PG_Shipping_Aemail) ? "" : smodel.PG_Shipping_Aemail);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsPrp_ComplaintExecutionForm_PaymentIntegration> Display_ComplaintFormExe_PaymentByPRNumber(Int64 ComplaintFormM_PRNumber)
        {
            try
            {
                connection();
                List<ClsPrp_ComplaintExecutionForm_PaymentIntegration> ComplaintFormM_List = new List<ClsPrp_ComplaintExecutionForm_PaymentIntegration>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_PaymentGatewayDetailsByPRN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", ComplaintFormM_PRNumber);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ComplaintFormM_List.Add(
                           new ClsPrp_ComplaintExecutionForm_PaymentIntegration
                           {
                               PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                               PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                               PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                               PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                               Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
                return ComplaintFormM_List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_ComplaintFormExe_Payment(ClsPrp_ComplaintExecutionForm_PaymentIntegration smodel, String UID, String UserName, Int32 IsPaymentSuccessCompleteFlag)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_execution_form_paymentgateway", con);
                cmd.CommandType = CommandType.StoredProcedure;

                #region Parameters
                cmd.Parameters.AddWithValue("p_PaymentComplaint_IndexID", smodel.PaymentComplaint_IndexID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_ID", smodel.PaymentComplaint_ID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_ID", smodel.PaymentComplaint_RelatedComplainant_ID);
                cmd.Parameters.AddWithValue("p_PaymentComplaint_RelatedComplainant_Code", String.IsNullOrEmpty(smodel.PaymentComplaint_RelatedComplainant_Code) ? "0" : smodel.PaymentComplaint_RelatedComplainant_Code);
                cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
                cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);

                cmd.Parameters.AddWithValue("p_ComplaintType_MN", String.IsNullOrEmpty(smodel.ComplaintType_MN) ? "" : smodel.ComplaintType_MN);
                cmd.Parameters.AddWithValue("p_User_Name", String.IsNullOrEmpty(UserName) ? "" : UserName);
                cmd.Parameters.AddWithValue("p_Complaint_BriefSummary", String.IsNullOrEmpty(smodel.Complaint_BriefSummary) ? "" : smodel.Complaint_BriefSummary);
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
                cmd.Parameters.AddWithValue("p_IsDraft", 0);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        public List<ClsPrp_ComplaintFormM_PaymentIntegration> Display_ComplaintFormM_PaymentReVerify(DateTime To_date, DateTime From_Date)
        {
            try
            {
                connection();
                List<ClsPrp_ComplaintFormM_PaymentIntegration> ComplaintFormM_List = new List<ClsPrp_ComplaintFormM_PaymentIntegration>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_PaymentGatewayDetailsReVerify", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ToDate", To_date);
                cmd.Parameters.AddWithValue("p_FromDate", From_Date);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ComplaintFormM_List.Add(
                           new ClsPrp_ComplaintFormM_PaymentIntegration
                           {
                               PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                               PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                               PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                               PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                               Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
                return ComplaintFormM_List;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update_ComplaintFormMPaymentGatewayByAPI(string zPG_Transaction_ID, string mihpayid, decimal amount, string bank_ref_num, string pstatus, decimal additionalcharges, string bankcode, string payment_type, string payment_gateway, string udf1, string udf2, string udf3, string udf4, string udf5)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("usp_update_complaintformMpaymentgateway", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gatewayTxnID", zPG_Transaction_ID);
                cmd.Parameters.AddWithValue("p_mihpayid", Convert.ToInt64(mihpayid));
                cmd.Parameters.AddWithValue("p_bank_ref_num", bank_ref_num);
                cmd.Parameters.AddWithValue("p_amount", amount);
                cmd.Parameters.AddWithValue("p_pstatus", pstatus);
                cmd.Parameters.AddWithValue("p_additionalcharges", additionalcharges);
                cmd.Parameters.AddWithValue("p_bankcode", bankcode);
                cmd.Parameters.AddWithValue("p_payment_type", payment_type);
                cmd.Parameters.AddWithValue("p_payment_gateway", payment_gateway);
                cmd.Parameters.AddWithValue("p_udf1", udf1);
                cmd.Parameters.AddWithValue("p_udf2", udf2);
                cmd.Parameters.AddWithValue("p_udf3", udf3);
                cmd.Parameters.AddWithValue("p_udf4", udf4);
                cmd.Parameters.AddWithValue("p_udf5", udf5);

                MySqlParameter outParam = new MySqlParameter("p_valreturn", MySqlDbType.Int32);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                con.Open();
                cmd.ExecuteNonQuery();

                int result = Convert.ToInt32(outParam.Value);
                con.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_statusComplaintFormMPaymentGatewayByAPI(string zPG_Transaction_ID)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("usp_update_statuscomplaintformMpaymentgateway", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gatewayTxnID", zPG_Transaction_ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ClsPrp_ComplaintFormN_PaymentIntegration> Display_ComplaintFormN_PaymentReVerify(DateTime To_date, DateTime From_Date)
        {
            try
            {
                connection();
                List<ClsPrp_ComplaintFormN_PaymentIntegration> ComplaintFormN_List = new List<ClsPrp_ComplaintFormN_PaymentIntegration>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_PaymentGatewayDetailsReVerify", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ToDate", To_date);
                cmd.Parameters.AddWithValue("p_FromDate", From_Date);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ComplaintFormN_List.Add(
                           new ClsPrp_ComplaintFormN_PaymentIntegration
                           {
                               PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                               PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                               PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                               PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                               Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                               User_Name = Convert.ToString(dr["User_Name"]),
                               Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
                return ComplaintFormN_List;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update_ComplaintFormNPaymentGatewayByAPI(string zPG_Transaction_ID, string mihpayid, decimal amount, string bank_ref_num, string pstatus, decimal additionalcharges, string bankcode, string payment_type, string payment_gateway, string udf1, string udf2, string udf3, string udf4, string udf5)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("usp_update_complaintformNpaymentgateway", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gatewayTxnID", zPG_Transaction_ID);
                cmd.Parameters.AddWithValue("p_mihpayid", Convert.ToInt64(mihpayid));
                cmd.Parameters.AddWithValue("p_bank_ref_num", bank_ref_num);
                cmd.Parameters.AddWithValue("p_amount", amount);
                cmd.Parameters.AddWithValue("p_pstatus", pstatus);
                cmd.Parameters.AddWithValue("p_additionalcharges", additionalcharges);
                cmd.Parameters.AddWithValue("p_bankcode", bankcode);
                cmd.Parameters.AddWithValue("p_payment_type", payment_type);
                cmd.Parameters.AddWithValue("p_payment_gateway", payment_gateway);
                cmd.Parameters.AddWithValue("p_udf1", udf1);
                cmd.Parameters.AddWithValue("p_udf2", udf2);
                cmd.Parameters.AddWithValue("p_udf3", udf3);
                cmd.Parameters.AddWithValue("p_udf4", udf4);
                cmd.Parameters.AddWithValue("p_udf5", udf5);


                MySqlParameter outParam = new MySqlParameter("p_valreturn", MySqlDbType.Int32);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                con.Open();
                cmd.ExecuteNonQuery();

                int result = Convert.ToInt32(outParam.Value);
                con.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_statusComplaintFormNPaymentGatewayByAPI(string zPG_Transaction_ID)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("usp_update_statuscomplaintformNpaymentgateway", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gatewayTxnID", zPG_Transaction_ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ClsPrp_ComplaintFormN_PaymentIntegration GetComplaintFormNByTxnId(string txnId)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_PaymentGatewayDetails_ByTxnID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_TxnID", txnId);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                if (dt.Rows.Count == 0) return null;
                DataRow dr = dt.Rows[0];

                return new ClsPrp_ComplaintFormN_PaymentIntegration
                {
                    PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                    PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                    PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                    PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                    Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                    User_ID = Convert.ToString(dr["User_ID"]),
                    ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                    User_Name = Convert.ToString(dr["User_Name"]),
                    Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ComplaintFormNDetailsSnapshot GetComplaintFormNDetailsByComplaintId(long complaintFormNID)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_ComplaintFormN_Details_ByComplaintID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", complaintFormNID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                if (dt.Rows.Count == 0) return null;
                DataRow dr = dt.Rows[0];

                return new ComplaintFormNDetailsSnapshot
                {
                    ComplaintFormN_IndexID = Convert.ToInt64(dr["ComplaintFormN_IndexID"]),
                    ComplaintFormN_ID = Convert.ToInt64(dr["ComplaintFormN_ID"]),
                    ComplaintFormN_Code = Convert.ToString(dr["ComplaintFormN_Code"]),
                    Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                    User_ID = Convert.ToString(dr["User_ID"]),
                    ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                    IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                    IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                    IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                    IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                    ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                    IsActive = Convert.ToInt32(dr["IsActive"]),
                    IsDraft = Convert.ToInt32(dr["IsDraft"]),
                    IsLock = Convert.ToInt32(dr["IsLock"]),
                    IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                    CreatedBy = Convert.ToString(dr["CreatedBy"]),
                    CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                    ModifyBy = Convert.ToString(dr["ModifyBy"]),
                    ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public class ComplaintFormNDetailsSnapshot
        {
            public long ComplaintFormN_IndexID { get; set; }
            public long ComplaintFormN_ID { get; set; }
            public string ComplaintFormN_Code { get; set; }

            public long Profile_ID { get; set; }
            public string User_ID { get; set; }
            public string ComplaintType_MN { get; set; }

            public int IsComplaintComplete { get; set; }
            public int IsPaymentComplete { get; set; }
            public int IsDocumentsComplete { get; set; }

            public int IsVerificationComplete { get; set; }
            public DateTime ComplaintVerificationDate { get; set; }
            public int IsActive { get; set; }
            public int IsDraft { get; set; }
            public int IsLock { get; set; }
            public int IsPublicView { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public string ModifyBy { get; set; }
            public DateTime ModifyOn { get; set; }
        }



        public ClsPrp_ComplaintFormM_PaymentIntegration GetComplaintFormMByTxnId(string txnId)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_PaymentGatewayDetails_ByTxnID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_TxnID", txnId);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                if (dt.Rows.Count == 0) return null;
                DataRow dr = dt.Rows[0];

                return new ClsPrp_ComplaintFormM_PaymentIntegration
                {
                    PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                    PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                    PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                    PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                    Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                    User_ID = Convert.ToString(dr["User_ID"]),
                    ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                    User_Name = Convert.ToString(dr["User_Name"]),
                    Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
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
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ComplaintFormMDetailsSnapshot GetComplaintFormMDetailsByComplaintId(long complaintFormMID)
        {
            try
            {
                connection();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_ComplaintFormM_Details_ByComplaintID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", complaintFormMID);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                if (dt.Rows.Count == 0) return null;
                DataRow dr = dt.Rows[0];

                return new ComplaintFormMDetailsSnapshot
                {
                    ComplaintFormM_IndexID = Convert.ToInt64(dr["ComplaintFormM_IndexID"]),
                    ComplaintFormM_ID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
                    ComplaintFormM_Code = Convert.ToString(dr["ComplaintFormM_Code"]),
                    Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                    User_ID = Convert.ToString(dr["User_ID"]),
                    ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                    IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                    IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                    IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                    IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                    ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                    IsActive = Convert.ToInt32(dr["IsActive"]),
                    IsDraft = Convert.ToInt32(dr["IsDraft"]),
                    IsLock = Convert.ToInt32(dr["IsLock"]),
                    IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                    CreatedBy = Convert.ToString(dr["CreatedBy"]),
                    CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                    ModifyBy = Convert.ToString(dr["ModifyBy"]),
                    ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public class ComplaintFormMDetailsSnapshot
        {
            public long ComplaintFormM_IndexID { get; set; }
            public long ComplaintFormM_ID { get; set; }
            public string ComplaintFormM_Code { get; set; }

            public long Profile_ID { get; set; }
            public string User_ID { get; set; }
            public string ComplaintType_MN { get; set; }

            public int IsComplaintComplete { get; set; }
            public int IsPaymentComplete { get; set; }
            public int IsDocumentsComplete { get; set; }

            public int IsVerificationComplete { get; set; }
            public DateTime ComplaintVerificationDate { get; set; }
            public int IsActive { get; set; }
            public int IsDraft { get; set; }
            public int IsLock { get; set; }
            public int IsPublicView { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public string ModifyBy { get; set; }
            public DateTime ModifyOn { get; set; }
        }

    }
}
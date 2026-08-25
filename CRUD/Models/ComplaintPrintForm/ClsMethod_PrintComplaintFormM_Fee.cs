using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsMethod_PrintComplaintFormM_Fee
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Print_FormM_Fee> Display_ComplaintFormM_Payment_ForPrint(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_Print_FormM_Fee> ComplaintFormM_List = new List<ClsPrp_Print_FormM_Fee>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Fee_ForPrint", con);
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
                       new ClsPrp_Print_FormM_Fee
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

        public List<ClsPrp_Print_FormM_Fee> Display_ComplaintFormM_PaymentByID_ForPrint(Int64 ComplaintFormM_ID, Int64? ProfileFormM_ID)
        {
            connection();
            List<ClsPrp_Print_FormM_Fee> ComplaintFormM_List = new List<ClsPrp_Print_FormM_Fee>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_FeeByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ProfileFormM_ID", ProfileFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_List.Add(
                       new ClsPrp_Print_FormM_Fee
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

        public List<ClsPrp_Print_Formexecution_Fee> Display_ComplaintFormExe_Payment_ForPrint(Int64 ComplaintForm_ID)
        {
            connection();
            List<ClsPrp_Print_Formexecution_Fee> ComplaintFormexe_List = new List<ClsPrp_Print_Formexecution_Fee>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormExe_Fee_ForPrint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintForm_ID", ComplaintForm_ID);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ComplaintFormexe_List.Add(
                           new ClsPrp_Print_Formexecution_Fee
                           {
                               PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                               PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                               PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                           //PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                           //ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
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

            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return ComplaintFormexe_List;
        }

        #endregion
    }
}
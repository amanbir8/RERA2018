using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsMethodMIS_ComplaintFormN
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public IEnumerable<ClsprpMIS_ComplaintFormN> ComplaintNGet()
        {
            connection();
            List<ClsprpMIS_ComplaintFormN> registarions = new List<ClsprpMIS_ComplaintFormN>();
            return registarions;
        }

        public IEnumerable<ClsprpMIS_ComplaintFormN> ComplaintNPost(DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<ClsprpMIS_ComplaintFormN> Application_List = new List<ClsprpMIS_ComplaintFormN>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_ComplaintN_PaymentMIS", con);
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
                Application_List.Add(
                      new ClsprpMIS_ComplaintFormN
                      {
                          Application_Diary_Number = Convert.ToString(dr["DiaryNumber"]),
                          Applicant_Name = Convert.ToString(dr["PG_Shipping_Firstname"]),
                          Respondant_Name = Convert.ToString(dr["Respondent_Name"]),
                          PG_Complainant_Email = Convert.ToString(dr["PG_Customer_Email"]),
                          PG_Complainant_Phone = Convert.ToString(dr["PG_Customer_Phone"]),

                          Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                          Status = Convert.ToString(dr["FailureSuccessSummary"]),
                          PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                          PG_Payment_Description = Convert.ToString(dr["PG_Product_Info"]),

                          PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                          PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                          Amount = Convert.ToDecimal(dr["PG_Amount"]),
                          PG_Status = Convert.ToString(dr["PG_Status"]),
                          PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "N" + Convert.ToString(dr["PG_UDF_3"]),

                          PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                          PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                          PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                          PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                          PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),

                          PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
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

                          //Last_Name = Convert.ToString(dr["PG_Shipping_Lastname"]),
                          //Customer_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                          //Customer_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                          //Customer_City = Convert.ToString(dr["PG_Shipping_City"]),
                          //Customer_State = Convert.ToString(dr["PG_Shipping_State"]),
                          //Customer_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                          //Customer_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                          //Customer_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                          //PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
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
            return Application_List;
        }

        public IEnumerable<ClsprpMIS_ComplaintFormN> Display_AuthDesk_ComplaintNformPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsprpMIS_ComplaintFormN> ProjectReralist = new List<ClsprpMIS_ComplaintFormN>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Report_ComplaintN_PaymentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", prmUserID_Role);
            cmd.Parameters.AddWithValue("p_Fromdate", prmFromDate);
            cmd.Parameters.AddWithValue("p_Todate", prmToDate);
            cmd.Parameters.AddWithValue("p_SearchTypeFlag", prmSearchTypeFlag);
            cmd.Parameters.AddWithValue("p_SearchRangeFlag", prmSearchRangeFlag);
            cmd.Parameters.AddWithValue("p_EventMonth", prmEventMonth);
            cmd.Parameters.AddWithValue("p_EventYear", prmEventYear);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DateTime dtvalue = new DateTime(0001, 1, 1);

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ComplaintFormN
                       {
                           Application_Diary_Number = Convert.ToString(dr["DiaryNumber"]),
                           Applicant_Name = Convert.ToString(dr["PG_Shipping_Firstname"]),
                           Respondant_Name = Convert.ToString(dr["Respondent_Name"]),
                           PG_Complainant_Email = Convert.ToString(dr["PG_Customer_Email"]),
                           PG_Complainant_Phone = Convert.ToString(dr["PG_Customer_Phone"]),

                           Payment_Success_Date = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                           Status = Convert.ToString(dr["FailureSuccessSummary"]),
                           PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                           PG_Payment_Description = Convert.ToString(dr["PG_Product_Info"]),

                           PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                           PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                           Amount = Convert.ToDecimal(dr["PG_Amount"]),
                           PG_Status = Convert.ToString(dr["PG_Status"]),
                           PG_PaymentRef_Number = Convert.ToString(dr["PG_UDF_1"]) + "N" + Convert.ToString(dr["PG_UDF_3"]),

                           PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                           PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                           PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                           PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                           PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),

                           PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                           PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                           PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),

                           // Payment Search Option
                           Application_SearchOptionFlag = Convert.ToString(dr["Application_SearchOptionFlag"]),
                           Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                           ApplicationDate = Convert.ToString(dr["ApplicationDate"]),

                           Application_FromDate = Convert.ToDateTime(dr["Application_FromDate"]),
                           Application_ToDate = Convert.ToDateTime(dr["Application_ToDate"]),
                           EventMonth = Convert.ToInt32(dr["EventMonth"]),
                           EventYear = Convert.ToInt32(dr["EventYear"]),
                       });
            }
            return ProjectReralist;
        }

    }
}
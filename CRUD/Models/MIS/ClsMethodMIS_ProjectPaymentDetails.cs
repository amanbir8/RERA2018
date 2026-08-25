using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

using System.Collections.Generic;
using System;
using System.Globalization;
using System.Web.Mvc;
using System.Linq;
using CRUD.Models.MIS;

namespace CRUD.Models.PaymentToExcel_MIS
{
    public class ClsMethodMIS_ProjectPaymentDetails
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
            return AgentApplication_List;
        }

        public IEnumerable<ClsprpMIS_ProjectPaymentsRegistration> Display_AuthDesk_ProjectRegistrationPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsprpMIS_ProjectPaymentsRegistration> ProjectReralist = new List<ClsprpMIS_ProjectPaymentsRegistration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MISreports_ProjectPaymentsRegistrationDetail", con);
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
                       new ClsprpMIS_ProjectPaymentsRegistration
                       {
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["RERAnumberRegistration"])) ? "" : Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),

                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           PromoterType = Convert.ToString(dr["PromoterType"]),

                           //Project Payment Submission
                           ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                           ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPaymentRelated_Promoter_ID = Convert.ToInt64(dr["ProjectPaymentRelated_Promoter_ID"]),
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

                           // Project PaymentGateway
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

        public IEnumerable<ClsprpMIS_ProjectPaymentsRegistration> Display_AuthDesk_ProjectExtensionOfRegistrationPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsprpMIS_ProjectPaymentsRegistration> ProjectReralist = new List<ClsprpMIS_ProjectPaymentsRegistration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MISreports_ProjectPaymentsExtensionRegDetail", con);
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
                       new ClsprpMIS_ProjectPaymentsRegistration
                       {
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["RERAnumberRegistration"])) ? "" : Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),

                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           PromoterType = Convert.ToString(dr["PromoterType"]),

                           //Project Payment Submission
                           ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                           ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPaymentRelated_Promoter_ID = Convert.ToInt64(dr["ProjectPaymentRelated_Promoter_ID"]),
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

                           // Project PaymentGateway
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

        public IEnumerable<ClsprpMIS_ProjectPaymentsMiscAdditional> Display_AuthDesk_ProjectAdditionalPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsprpMIS_ProjectPaymentsMiscAdditional> ProjectReralist = new List<ClsprpMIS_ProjectPaymentsMiscAdditional>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MISreports_ProjectPaymentsAdditionalsDetail", con);
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
                       new ClsprpMIS_ProjectPaymentsMiscAdditional
                       {
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["RERAnumberRegistration"])) ? "" : Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),

                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           PromoterType = Convert.ToString(dr["PromoterType"]),

                           //Project Payment Submission
                           ProjectPaymentMiscFee_IndexID = Convert.ToInt64(dr["ProjectPaymentMiscFee_IndexID"]),
                           ProjectPaymentMiscFee_ID = Convert.ToInt64(dr["ProjectPaymentMiscFee_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPaymentRelated_Promoter_ID = Convert.ToInt64(dr["ProjectPaymentRelated_Promoter_ID"]),
                           ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                           ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),

                           RelatedRERAregNumber_Name = Convert.ToString(dr["RelatedRERAregNumber_Name"]),
                           RelatedRERAregNumber_ValidUptoDate = Convert.ToDateTime(dr["RelatedRERAregNumber_ValidUptoDate"]),
                           RelatedAnnualYear = Convert.ToInt32(dr["RelatedAnnualYear"]),
                           RelatedSessionYear_Name = Convert.ToString(dr["RelatedSessionYear_Name"]),

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

                           // Project PaymentGateway
                           PaymentRefNumberMiscProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberMiscProjectPm_IndexID"]),
                           PaymentRefNumberMiscProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberMiscProjectPm_ID"]),

                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           MiscFeeProject_Flag = Convert.ToString(dr["MiscFeeProject_Flag"]),
                           MiscFeeProject_Code = Convert.ToInt64(dr["MiscFeeProject_Code"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           MiscFeeProject_BriefSummary = Convert.ToString(dr["MiscFeeProject_BriefSummary"]),
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

        public IEnumerable<ClsprpMIS_ProjectPaymentsMiscAdditional> Display_AuthDesk_ProjectMiscPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsprpMIS_ProjectPaymentsMiscAdditional> ProjectReralist = new List<ClsprpMIS_ProjectPaymentsMiscAdditional>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MISreports_ProjectPaymentsMiscellaneousDetail", con);
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
                       new ClsprpMIS_ProjectPaymentsMiscAdditional
                       {
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           RERAnumberRegistration = String.IsNullOrEmpty(Convert.ToString(dr["RERAnumberRegistration"])) ? "" : Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]) == null ? dtvalue : Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),

                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           PromoterType = Convert.ToString(dr["PromoterType"]),

                           //Project Payment Submission
                           ProjectPaymentMiscFee_IndexID = Convert.ToInt64(dr["ProjectPaymentMiscFee_IndexID"]),
                           ProjectPaymentMiscFee_ID = Convert.ToInt64(dr["ProjectPaymentMiscFee_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPaymentRelated_Promoter_ID = Convert.ToInt64(dr["ProjectPaymentRelated_Promoter_ID"]),
                           ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                           ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),

                           RelatedRERAregNumber_Name = Convert.ToString(dr["RelatedRERAregNumber_Name"]),
                           RelatedRERAregNumber_ValidUptoDate = Convert.ToDateTime(dr["RelatedRERAregNumber_ValidUptoDate"]),
                           RelatedAnnualYear = Convert.ToInt32(dr["RelatedAnnualYear"]),
                           RelatedSessionYear_Name = Convert.ToString(dr["RelatedSessionYear_Name"]),

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

                           // Project PaymentGateway
                           PaymentRefNumberMiscProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberMiscProjectPm_IndexID"]),
                           PaymentRefNumberMiscProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberMiscProjectPm_ID"]),

                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           MiscFeeProject_Flag = Convert.ToString(dr["MiscFeeProject_Flag"]),
                           MiscFeeProject_Code = Convert.ToInt64(dr["MiscFeeProject_Code"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           MiscFeeProject_BriefSummary = Convert.ToString(dr["MiscFeeProject_BriefSummary"]),
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








        #region EPAY FEE
        public IEnumerable<ClsprpMIS_EpayProjectRegistration> Display_AuthDesk_ePayProjectRegistrationPaymentsDetail_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsprpMIS_EpayProjectRegistration> ProjectReralist = new List<ClsprpMIS_EpayProjectRegistration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MISreports_EPayProjectPaymentsRegistrationDetail", con);
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
                       new ClsprpMIS_EpayProjectRegistration
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

                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           ExtensionProject_ID = Convert.ToInt64(dr["ExtensionProject_ID"]),
                           TypeOfProject = Convert.ToInt32(dr["TypeOfProject"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),

                           ProjectAddress_DistrictCode = Convert.ToInt32(dr["ProjectAddress_DistrictCode"]),
                           ProjectAddress_DistrictName = Convert.ToString(dr["ProjectAddress_DistrictName"]),

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
                       });
            }
            return ProjectReralist;
        }
        #endregion
    }
}
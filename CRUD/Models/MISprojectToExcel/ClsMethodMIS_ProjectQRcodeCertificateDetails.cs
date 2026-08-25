using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsMethod_MIS_ProjectQRcodeCertificateDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_MIS_ProjectQRcodeCertificateDetails> Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForRERAnumberRegisteredProjects(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectQRcodeCertificateDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectQRcodeCertificateDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectQRcodeCertificateDetails
                       {
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Type = Convert.ToString(dr["Project_Type"]),
                           Project_TypeSTR = fnProjectReturnSTR(Convert.ToString(dr["RERAnumberRegistration"])),
                           Project_TotalArea = Convert.ToDecimal(dr["Project_TotalArea"]),
                           Project_TotalAreaSTR = Convert.ToString(dr["Project_TotalAreaSTR"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Promoter_Type = Convert.ToInt32(dr["Promoter_Type"]),
                           Promoter_TypeSTR = fnReturnSTR(Convert.ToString(dr["Promoter_Type"])),

                           BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                           BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                           BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                           BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                           BusinessPlace_AddressPIN = Convert.ToString(dr["BusinessPlace_AddressPIN"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           //public object QRcodeImage_A = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public byte[] QRcodeImage_B = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public string QRcodeImage_C = Convert.ToString(dr["Agent_Organization_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectQRcodeCertificateDetails> Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForRERAnumberRegisteredProjects_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_ProjectQRcodeCertificateDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectQRcodeCertificateDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            string ddFromDate = FromDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
            string ddToDate = ToDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Todate", ddToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            DataTable dt1 = new DataTable();
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RERAnumberIssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERAnumberIssueDate"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RERAnumberIssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERAnumberIssueDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectQRcodeCertificateDetails
                       {
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Type = Convert.ToString(dr["Project_Type"]),
                           Project_TypeSTR = fnProjectReturnSTR(Convert.ToString(dr["RERAnumberRegistration"])),
                           Project_TotalArea = Convert.ToDecimal(dr["Project_TotalArea"]),
                           Project_TotalAreaSTR = Convert.ToString(dr["Project_TotalAreaSTR"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Promoter_Type = Convert.ToInt32(dr["Promoter_Type"]),
                           Promoter_TypeSTR = fnReturnSTR(Convert.ToString(dr["Promoter_Type"])),

                           BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                           BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                           BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                           BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                           BusinessPlace_AddressPIN = Convert.ToString(dr["BusinessPlace_AddressPIN"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           //public object QRcodeImage_A = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public byte[] QRcodeImage_B = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public string QRcodeImage_C = Convert.ToString(dr["Agent_Organization_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }

        public List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails> Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForOfflineProjects(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectQRcodeCertificateDetails_OfflineProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails
                       {
                           OfflineProject_IndexID = Convert.ToInt64(dr["OfflineProject_IndexID"]),
                           OfflineProject_ID = Convert.ToInt64(dr["OfflineProject_ID"]),
                           OfflineProject_IssueDate = Convert.ToDateTime(dr["OfflineProject_IssueDate"]),
                           OfflineProject_ReferenceNumber = Convert.ToString(dr["OfflineProject_ReferenceNumber"]),

                           OfflineProject_Name = Convert.ToString(dr["OfflineProject_Name"]),
                           OfflineProject_Type = Convert.ToString(dr["OfflineProject_Type"]),
                           OfflineProject_TotalArea = Convert.ToString(dr["OfflineProject_TotalArea"]),
                           OfflineProject_Address = Convert.ToString(dr["OfflineProject_Address"]),
                           OfflineProject_BusinessPlaceDistrict = Convert.ToString(dr["OfflineProject_BusinessPlaceDistrict"]),

                           OfflinePromoter_Name = Convert.ToString(dr["OfflinePromoter_Name"]),
                           OfflinePromoter_Type = Convert.ToString(dr["OfflinePromoter_Type"]),
                           OfflinePromoter_BusinessPlace_Address = Convert.ToString(dr["OfflinePromoter_BusinessPlace_Address"]),

                           OfflineProject_RERAregistrationNumber = Convert.ToString(dr["OfflineProject_RERAregistrationNumber"]),
                           OfflineProject_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineProject_RERAregistrationIssueDate"]),
                           OfflineProject_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineProject_RERAregistrationValidUptoDate"]),

                           OfflineProject_ContactDetails = Convert.ToString(dr["OfflineProject_ContactDetails"]),
                           OfflineProject_RemarksIfAny = Convert.ToString(dr["OfflineProject_RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           //public object QRcodeImage_A = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public byte[] QRcodeImage_B = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public string QRcodeImage_C = Convert.ToString(dr["Agent_Organization_Name"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificate = Convert.ToInt32(dr["IsCertificate"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails> Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForOfflineProjects_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectQRcodeCertificateDetails_OfflineProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            string ddFromDate = FromDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
            string ddToDate = ToDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Todate", ddToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            DataTable dt1 = new DataTable();
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["OfflineProject_IssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["OfflineProject_IssueDate"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["OfflineProject_IssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["OfflineProject_IssueDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails
                       {
                           OfflineProject_IndexID = Convert.ToInt64(dr["OfflineProject_IndexID"]),
                           OfflineProject_ID = Convert.ToInt64(dr["OfflineProject_ID"]),
                           OfflineProject_IssueDate = Convert.ToDateTime(dr["OfflineProject_IssueDate"]),
                           OfflineProject_ReferenceNumber = Convert.ToString(dr["OfflineProject_ReferenceNumber"]),

                           OfflineProject_Name = Convert.ToString(dr["OfflineProject_Name"]),
                           OfflineProject_Type = Convert.ToString(dr["OfflineProject_Type"]),
                           OfflineProject_TotalArea = Convert.ToString(dr["OfflineProject_TotalArea"]),
                           OfflineProject_Address = Convert.ToString(dr["OfflineProject_Address"]),
                           OfflineProject_BusinessPlaceDistrict = Convert.ToString(dr["OfflineProject_BusinessPlaceDistrict"]),

                           OfflinePromoter_Name = Convert.ToString(dr["OfflinePromoter_Name"]),
                           OfflinePromoter_Type = Convert.ToString(dr["OfflinePromoter_Type"]),
                           OfflinePromoter_BusinessPlace_Address = Convert.ToString(dr["OfflinePromoter_BusinessPlace_Address"]),

                           OfflineProject_RERAregistrationNumber = Convert.ToString(dr["OfflineProject_RERAregistrationNumber"]),
                           OfflineProject_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineProject_RERAregistrationIssueDate"]),
                           OfflineProject_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineProject_RERAregistrationValidUptoDate"]),

                           OfflineProject_ContactDetails = Convert.ToString(dr["OfflineProject_ContactDetails"]),
                           OfflineProject_RemarksIfAny = Convert.ToString(dr["OfflineProject_RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           //public object QRcodeImage_A = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public byte[] QRcodeImage_B = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public string QRcodeImage_C = Convert.ToString(dr["Agent_Organization_Name"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificate = Convert.ToInt32(dr["IsCertificate"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }
        //pop-up modal screen
        public List<Clsprp_MIS_ProjectQRcodeCertificateDetails> Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForRERAnumberRegisteredProjects_ForMIS(Int64 Project_ID, Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectQRcodeCertificateDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectQRcodeCertificateDetails_RegdByParmID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectQRcodeCertificateDetails
                       {
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Type = Convert.ToString(dr["Project_Type"]),
                           Project_TypeSTR = fnProjectReturnSTR(Convert.ToString(dr["RERAnumberRegistration"])),
                           Project_TotalArea = Convert.ToDecimal(dr["Project_TotalArea"]),
                           Project_TotalAreaSTR = Convert.ToString(dr["Project_TotalAreaSTR"]),

                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),

                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Promoter_Type = Convert.ToInt32(dr["Promoter_Type"]),
                           Promoter_TypeSTR = fnReturnSTR(Convert.ToString(dr["Promoter_Type"])),

                           BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                           BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                           BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                           BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                           BusinessPlace_AddressPIN = Convert.ToString(dr["BusinessPlace_AddressPIN"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           //public object QRcodeImage_A = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public byte[] QRcodeImage_B = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public string QRcodeImage_C = Convert.ToString(dr["Agent_Organization_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails> Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForOfflineProjects_ForMIS(Int64 OfflineProject_ID, string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectQRcodeCertificateDetails_OfflineByParmID", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_OfflineProjectID", OfflineProject_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails
                       {
                           OfflineProject_IndexID = Convert.ToInt64(dr["OfflineProject_IndexID"]),
                           OfflineProject_ID = Convert.ToInt64(dr["OfflineProject_ID"]),
                           OfflineProject_IssueDate = Convert.ToDateTime(dr["OfflineProject_IssueDate"]),
                           OfflineProject_ReferenceNumber = Convert.ToString(dr["OfflineProject_ReferenceNumber"]),

                           OfflineProject_Name = Convert.ToString(dr["OfflineProject_Name"]),
                           OfflineProject_Type = Convert.ToString(dr["OfflineProject_Type"]),
                           OfflineProject_TotalArea = Convert.ToString(dr["OfflineProject_TotalArea"]),
                           OfflineProject_Address = Convert.ToString(dr["OfflineProject_Address"]),
                           OfflineProject_BusinessPlaceDistrict = Convert.ToString(dr["OfflineProject_BusinessPlaceDistrict"]),

                           OfflinePromoter_Name = Convert.ToString(dr["OfflinePromoter_Name"]),
                           OfflinePromoter_Type = Convert.ToString(dr["OfflinePromoter_Type"]),
                           OfflinePromoter_BusinessPlace_Address = Convert.ToString(dr["OfflinePromoter_BusinessPlace_Address"]),

                           OfflineProject_RERAregistrationNumber = Convert.ToString(dr["OfflineProject_RERAregistrationNumber"]),
                           OfflineProject_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineProject_RERAregistrationIssueDate"]),
                           OfflineProject_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineProject_RERAregistrationValidUptoDate"]),

                           OfflineProject_ContactDetails = Convert.ToString(dr["OfflineProject_ContactDetails"]),
                           OfflineProject_RemarksIfAny = Convert.ToString(dr["OfflineProject_RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           //public object QRcodeImage_A = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public byte[] QRcodeImage_B = Convert.ToString(dr["Agent_Organization_Name"]),
                           //public string QRcodeImage_C = Convert.ToString(dr["Agent_Organization_Name"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificate = Convert.ToInt32(dr["IsCertificate"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }

        private string fnReturnSTR(string var1)
        {
            string vargetSTR = string.Empty;
            switch (Convert.ToString(var1))
            {
                case "1":
                    vargetSTR = "Individual";
                    break;
                case "2":
                    vargetSTR = "Other Than Individual";
                    break;                
                default:
                    vargetSTR = "";
                    break;
            }
            return vargetSTR;
        }

        private string fnProjectReturnSTR(string var1)
        {
            string vargetSTR = string.Empty;
            string TruncateString = string.Empty;

            if(var1 != string.Empty)
            {
                TruncateString = var1.Substring(13, 2);
            }
            else
            {
                TruncateString = "NA";
            }          

            switch (Convert.ToString(TruncateString))
            {
                case "PR":
                    vargetSTR = "Residential";
                    break;
                case "PC":
                    vargetSTR = "Commercial";
                    break;
                case "PM":
                    vargetSTR = "Mixed";
                    break;
                case "PI":
                    vargetSTR = "Industrial";
                    break;
                case "NA":
                    vargetSTR = "NA";
                    break;
                default:
                    vargetSTR = "NA";
                    break;
            }
            return vargetSTR;
        }

        private string RegexRemoveEmailCheck(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "@";
            string replacement = "[at]";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
        }
    }
}
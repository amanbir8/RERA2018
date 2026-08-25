using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using CRUD.Models.HelpDeskAgent;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class ClsMethod_MIS_AgentQRcodeCertificateDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Online Registered Agents
        public List<Clsprp_MIS_AgentQRcodeCertificateDetails> Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificateDetails_RegdAgents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeCertificateDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Father_AuthorizedPerson_Name = Convert.ToString(dr["Agent_Father_AuthorizedPerson_Name"]),

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
            return AgentReralist;
        }
        public List<Clsprp_MIS_AgentQRcodeCertificateDetails> Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificateDetails_RegdAgents", con);
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
                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeCertificateDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Father_AuthorizedPerson_Name = Convert.ToString(dr["Agent_Father_AuthorizedPerson_Name"]),

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
            return AgentReralist;
        }

        //Offline Registered Agents
        public List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificateDetails_OfflineAgents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeOfflineCertificateDetails
                       {
                           OfflineAgents_IndexID = Convert.ToInt64(dr["OfflineAgents_IndexID"]),
                           OfflineAgents_ID = Convert.ToInt64(dr["OfflineAgents_ID"]),
                           OfflineAgents_IssueDate = Convert.ToDateTime(dr["OfflineAgents_IssueDate"]),
                           OfflineAgents_ReferenceNumber = Convert.ToString(dr["OfflineAgents_ReferenceNumber"]),

                           OfflineAgents_AgentType = Convert.ToString(dr["OfflineAgents_AgentType"]),
                           OfflineAgents_AgentName_OrganizationName = Convert.ToString(dr["OfflineAgents_AgentName_OrganizationName"]),
                           OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = Convert.ToString(dr["OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress"]),

                           OfflineAgents_RERAregistrationNumber = Convert.ToString(dr["OfflineAgents_RERAregistrationNumber"]),
                           OfflineAgents_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationIssueDate"]),
                           OfflineAgents_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationValidUptoDate"]),

                           OfflineAgents_PlaceOfBussinessAddress = Convert.ToString(dr["OfflineAgents_PlaceOfBussinessAddress"]),
                           OfflineAgents_BusinessPlaceDistrict = Convert.ToString(dr["OfflineAgents_BusinessPlaceDistrict"]),
                           OfflineAgents_ContactDetails = Convert.ToString(dr["OfflineAgents_ContactDetails"]),
                           OfflineAgents_RemarksIfAny = Convert.ToString(dr["OfflineAgents_RemarksIfAny"]),

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
            return AgentReralist;
        }
        public List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificateDetails_OfflineAgents", con);
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
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["OfflineAgents_RERAregistrationIssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["OfflineAgents_RERAregistrationIssueDate"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["OfflineAgents_RERAregistrationIssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["OfflineAgents_RERAregistrationIssueDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeOfflineCertificateDetails
                       {
                           OfflineAgents_IndexID = Convert.ToInt64(dr["OfflineAgents_IndexID"]),
                           OfflineAgents_ID = Convert.ToInt64(dr["OfflineAgents_ID"]),
                           OfflineAgents_IssueDate = Convert.ToDateTime(dr["OfflineAgents_IssueDate"]),
                           OfflineAgents_ReferenceNumber = Convert.ToString(dr["OfflineAgents_ReferenceNumber"]),

                           OfflineAgents_AgentType = Convert.ToString(dr["OfflineAgents_AgentType"]),
                           OfflineAgents_AgentName_OrganizationName = Convert.ToString(dr["OfflineAgents_AgentName_OrganizationName"]),
                           OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = Convert.ToString(dr["OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress"]),

                           OfflineAgents_RERAregistrationNumber = Convert.ToString(dr["OfflineAgents_RERAregistrationNumber"]),
                           OfflineAgents_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationIssueDate"]),
                           OfflineAgents_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationValidUptoDate"]),

                           OfflineAgents_PlaceOfBussinessAddress = Convert.ToString(dr["OfflineAgents_PlaceOfBussinessAddress"]),
                           OfflineAgents_BusinessPlaceDistrict = Convert.ToString(dr["OfflineAgents_BusinessPlaceDistrict"]),
                           OfflineAgents_ContactDetails = Convert.ToString(dr["OfflineAgents_ContactDetails"]),
                           OfflineAgents_RemarksIfAny = Convert.ToString(dr["OfflineAgents_RemarksIfAny"]),

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
            return AgentReralist;
        }

        //Renewal of Registration of Agents
        public List<Clsprp_MIS_RenewalAgentQRcodeCertificateDetails> Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalAgents(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_RenewalAgentQRcodeCertificateDetails> AgentReralist = new List<Clsprp_MIS_RenewalAgentQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificateDetails_RenewalAgents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_RenewalAgentQRcodeCertificateDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Reference_DiaryNumber = Convert.ToString(dr["Reference_DiaryNumber"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                           RenewalAgent_SequenceID = Convert.ToInt32(dr["RenewalAgent_SequenceID"]),
                           RenewalAgent_YearID = Convert.ToInt32(dr["RenewalAgent_YearID"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Father_AuthorizedPerson_Name = Convert.ToString(dr["Agent_Father_AuthorizedPerson_Name"]),

                           BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                           BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                           BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                           BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                           BusinessPlace_AddressPIN = Convert.ToString(dr["BusinessPlace_AddressPIN"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RERA_RenewalRegistrationNumber = Convert.ToString(dr["RERA_RenewalRegistrationNumber"]),
                           RERA_RenewalRegistrationNumber_IssueDate = Convert.ToDateTime(dr["RERA_RenewalRegistrationNumber_IssueDate"]),
                           RERA_RenewalRegistrationNumber_ValidUptoDate = Convert.ToDateTime(dr["RERA_RenewalRegistrationNumber_ValidUptoDate"]),

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
            return AgentReralist;
        }
        public List<Clsprp_MIS_RenewalAgentQRcodeCertificateDetails> Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalAgents_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<Clsprp_MIS_RenewalAgentQRcodeCertificateDetails> AgentReralist = new List<Clsprp_MIS_RenewalAgentQRcodeCertificateDetails>();

            //MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificateDetails_RenewalAgents", con);
            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_RAgentQRcodeCertificateDetails_RenewalAgents", con);
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
            //var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_IssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_IssueDate"]) <= Convert.ToDateTime(ddToDate)));
            //if (rows.Any())
            //{
            //    dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_IssueDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_IssueDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            //}
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_RenewalDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_RenewalDate"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_RenewalDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERA_RenewalRegistrationNumber_RenewalDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_RenewalAgentQRcodeCertificateDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Reference_DiaryNumber = Convert.ToString(dr["Reference_DiaryNumber"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                           RenewalAgent_SequenceID = Convert.ToInt32(dr["RenewalAgent_SequenceID"]),
                           RenewalAgent_YearID = Convert.ToInt32(dr["RenewalAgent_YearID"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Father_AuthorizedPerson_Name = Convert.ToString(dr["Agent_Father_AuthorizedPerson_Name"]),

                           BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                           BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                           BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                           BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                           BusinessPlace_AddressPIN = Convert.ToString(dr["BusinessPlace_AddressPIN"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RERA_RenewalRegistrationNumber = Convert.ToString(dr["RERA_RenewalRegistrationNumber"]),
                           RERA_RenewalRegistrationNumber_IssueDate = Convert.ToDateTime(dr["RERA_RenewalRegistrationNumber_IssueDate"]),
                           RERA_RenewalRegistrationNumber_ValidUptoDate = Convert.ToDateTime(dr["RERA_RenewalRegistrationNumber_ValidUptoDate"]),

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

                           RERA_RenewalRegistrationNumber_RenewalDate= Convert.ToDateTime(dr["RERA_RenewalRegistrationNumber_RenewalDate"])
                       });
            }
            return AgentReralist;
        }

        //pop-up modal screen
        public List<Clsprp_MIS_AgentQRcodeCertificateDetails> Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForRERAnumberRegisteredAgents_ForMIS(Int64 Agent_ID, string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificate_Regd_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentID", Agent_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeCertificateDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Father_AuthorizedPerson_Name = Convert.ToString(dr["Agent_Father_AuthorizedPerson_Name"]),

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
            return AgentReralist;
        }
        public List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> Display_AuthDesk_MIS_AgentQRcodeCertificateDetails_ForOfflineAgents_ForMIS(Int64 OfflineAgents_ID, string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeOfflineCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificate_OfflineRegd_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentID", OfflineAgents_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeOfflineCertificateDetails
                       {
                           OfflineAgents_IndexID = Convert.ToInt64(dr["OfflineAgents_IndexID"]),
                           OfflineAgents_ID = Convert.ToInt64(dr["OfflineAgents_ID"]),
                           OfflineAgents_IssueDate = Convert.ToDateTime(dr["OfflineAgents_IssueDate"]),
                           OfflineAgents_ReferenceNumber = Convert.ToString(dr["OfflineAgents_ReferenceNumber"]),

                           OfflineAgents_AgentType = Convert.ToString(dr["OfflineAgents_AgentType"]),
                           OfflineAgents_AgentName_OrganizationName = Convert.ToString(dr["OfflineAgents_AgentName_OrganizationName"]),
                           OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress = Convert.ToString(dr["OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress"]),

                           OfflineAgents_RERAregistrationNumber = Convert.ToString(dr["OfflineAgents_RERAregistrationNumber"]),
                           OfflineAgents_RERAregistrationIssueDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationIssueDate"]),
                           OfflineAgents_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["OfflineAgents_RERAregistrationValidUptoDate"]),

                           OfflineAgents_PlaceOfBussinessAddress = Convert.ToString(dr["OfflineAgents_PlaceOfBussinessAddress"]),
                           OfflineAgents_BusinessPlaceDistrict = Convert.ToString(dr["OfflineAgents_BusinessPlaceDistrict"]),
                           OfflineAgents_ContactDetails = Convert.ToString(dr["OfflineAgents_ContactDetails"]),
                           OfflineAgents_RemarksIfAny = Convert.ToString(dr["OfflineAgents_RemarksIfAny"]),

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
            return AgentReralist;
        }
        public List<Clsprp_MIS_AgentQRcodeCertificateDetails> Display_AuthDesk_MIS_RenewalAgentQRcodeCertificateDetails_ForRenewalRegistrationAgents_ForMIS(Int64 Agent_ID, Int32 AgentType_ID, Int64 RnAgent_ID, Int32 RnAgentSeq_ID, Int32 RnAgentYr_ID, string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_AgentQRcodeCertificateDetails> AgentReralist = new List<Clsprp_MIS_AgentQRcodeCertificateDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentQRcodeCertificate_RenewalAgent_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentType_ID);
            cmd.Parameters.AddWithValue("p_RnAgent_ID", RnAgent_ID);
            cmd.Parameters.AddWithValue("p_RnAgentSeq_ID", RnAgentSeq_ID);
            cmd.Parameters.AddWithValue("p_RnAgentYr_ID", RnAgentYr_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                AgentReralist.Add(
                       new Clsprp_MIS_AgentQRcodeCertificateDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Father_AuthorizedPerson_Name = Convert.ToString(dr["Agent_Father_AuthorizedPerson_Name"]),

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
            return AgentReralist;
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

        private string RegexRemoveEmailCheck(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "@";
            string replacement = "[at]";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
        }


        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> Display_Panel_RegisteredAgentReports(string UserID_Role, DateTime FromDate, DateTime ToDate, int AgentType)
        {
            try
            {
                connection();
                List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> AgentReralist = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_programmerDesk_AgentRegRERAnumberDetailsBydate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
                cmd.Parameters.AddWithValue("p_FromDate", FromDate);
                cmd.Parameters.AddWithValue("p_ToDate", ToDate);
                cmd.Parameters.AddWithValue("p_AgentType", AgentType);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);

                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentReralist.Add(
                         new ClsPrp_AuthorityDesk_AgentRERAnumberDetails
                         {
                             Agent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_IndexID"]),
                             Agent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_ID"]),
                             AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                             AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),

                             UserID = Convert.ToString(dr["UserID"]),
                             Agent_ID = Convert.ToInt64(dr["Agent_ID"]),

                             OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                             DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                             UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                             PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                             AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),

                             Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                             CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                             EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                             tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),

                             Project_ID = Convert.ToInt64(dr["Project_ID"]),
                             Project_Name = Convert.ToString(dr["Project_Name"]),
                             Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                             Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                             IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                             ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                             Agent_Type = Convert.ToString(dr["Agent_Type"]),
                             Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                             Agent_MiddleName = Convert.ToString(dr["Agent_MiddleName"]),
                             Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                             Organization_Name = Convert.ToString(dr["Organization_Name"]),
                             BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                             BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                             EmailAddress = Convert.ToString(dr["EmailAddress"]),
                             MobileNumber = Convert.ToInt64(dr["MobileNumber"]),

                             RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                             RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                             RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                             Extra2 = Convert.ToString("Extra2"),
                             Extra3 = Convert.ToString("Extra3"),
                             Extra4 = Convert.ToString("Extra4"),

                             IsActive = Convert.ToInt32(dr["IsActive"]),
                             IsDraft = Convert.ToInt32(dr["IsDraft"]),
                             IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                             IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                             IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                             IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                             IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                             CreatedBy = Convert.ToString(dr["CreatedBy"]),
                             CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                             ModifyBy = Convert.ToString(dr["ModifyBy"]),
                             ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                             Agent_Name = Convert.ToString(dr["Agent_Name"]),
                             Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                             Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),

                             EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                             EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                             EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                             EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                             Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                             EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                             EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                             AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                             AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                             AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                             AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                         });
                }
                return AgentReralist;
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                throw;
            }
        }
    }
}
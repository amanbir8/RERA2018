using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_MIS_ProjectExtensionDueDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        public List<ClsPrp_MIS_ProjectRERAnumberDetails> Display_AuthDesk_ProjectExtensionDueApplications_ByUserID(string UserID_Role)
        {
            connection();
            List<ClsPrp_MIS_ProjectRERAnumberDetails> ProjectReralist = new List<ClsPrp_MIS_ProjectRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectExtensionDueDetails", con);
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
                       new ClsPrp_MIS_ProjectRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                           ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }
        public List<ClsPrp_MIS_ProjectRERAnumberDetails> Display_AuthDesk_ProjectExtensionDueApplications_ByUserID(string UserID_Role,DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<ClsPrp_MIS_ProjectRERAnumberDetails> ProjectReralist = new List<ClsPrp_MIS_ProjectRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectExtensionDueDetails", con);
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
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_MIS_ProjectRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                           ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ProjectReralist;
        }
        public List<ClsPrp_MIS_ProjectRERAnumberDetails> Display_AuthDesk_ProjectExtensionDueApplications_ByUserID(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<ClsPrp_MIS_ProjectRERAnumberDetails> ProjectReralist = new List<ClsPrp_MIS_ProjectRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectExtensionDueDetailsWithMonth", con);
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

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_MIS_ProjectRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           ProjectRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectRegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ProjectRegDiaryNumber_NameYear = Convert.ToString(dr["ProjectRegDiaryNumber_NameYear"]),
                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),

                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           PromoterRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_tbl_IndexID"]),
                           PromoterRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["PromoterRegDiaryNumber_CreatedDate"]),

                           ProjectQuarterlyRegDiaryNumber_ID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_ID"]),
                           ProjectQuarterly_QuarterName = Convert.ToString(dr["ProjectQuarterly_QuarterName"]),
                           ProjectQuarterly_QuarterYear = Convert.ToInt64(dr["ProjectQuarterly_QuarterYear"]),
                           ProjectQuarterlyRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectQuarterlyRegDiaryNumber_tbl_IndexID"]),
                           ProjectQuarterly_CreatedDate = Convert.ToDateTime(dr["ProjectQuarterly_CreatedDate"]),

                           IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                           ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_District = Convert.ToString(dr["AuthorizedPerson_District"]),
                           AuthorizedPerson_State = Convert.ToString(dr["AuthorizedPerson_State"]),
                           AuthorizedPerson_PIN = Convert.ToString(dr["AuthorizedPerson_PIN"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),

                           Application_SearchTypeFlag = Convert.ToString(dr["Application_SearchTypeFlag"]),
                           Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                           Application_FromDate = Convert.ToDateTime(dr["Application_FromDate"]),
                           Application_ToDate = Convert.ToDateTime(dr["Application_ToDate"]),
                           EventMonth = Convert.ToInt32(dr["EventMonth"]),
                           EventYear = Convert.ToInt32(dr["EventYear"]),
                       });
            }
            return ProjectReralist;
        }

        public List<ClsprpMIS_ProjectCompletionRERAnumberDetails> Display_AuthDesk_ProjectCompletionCertificate_ByUserID(string UserID_Role, string SearchDocumentFlag, string SearchOptionFlag, string SearchRangeFlag, DateTime Application_FromDate, DateTime Application_ToDate, Int32 pMonth, Int32 pYear)
        {
            connection();
            List<ClsprpMIS_ProjectCompletionRERAnumberDetails> ProjectReralist = new List<ClsprpMIS_ProjectCompletionRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectCompletionCertificateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Application_CeritifcateFlag", SearchDocumentFlag);
            cmd.Parameters.AddWithValue("p_Application_SearchOptionFlag", SearchOptionFlag);
            cmd.Parameters.AddWithValue("p_Application_SearchRangeFlag", SearchRangeFlag);
            cmd.Parameters.AddWithValue("p_Application_FromDate", Application_FromDate);
            cmd.Parameters.AddWithValue("p_Application_ToDate", Application_ToDate);
            cmd.Parameters.AddWithValue("p_Application_Month", pMonth);
            cmd.Parameters.AddWithValue("p_Application_Year", pYear);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectCompletionRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           PCC_IndexID = Convert.ToInt64(dr["PCC_IndexID"]),
                           PCC_ID = Convert.ToInt64(dr["PCC_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterType = Convert.ToInt32(dr["PromoterType"]),

                           DName = Convert.ToString(dr["DName"]),
                           PCC_InfoDetails = Convert.ToString(dr["PCC_InfoDetails"]),
                           PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                           PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                           PCC_CertificateStatus = Convert.ToString(dr["PCC_CertificateStatus"]),
                           PCC_ReciptType = Convert.ToString(dr["PCC_ReciptType"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectCompletionCert_FilePath = Convert.ToString(dr["ProjectCompletionCert_FilePath"]),
                           ProjectCompletionCert_FileName = Convert.ToString(dr["ProjectCompletionCert_FileName"]),
                           ProjectCompletionCert_ReferenceNumber = Convert.ToString(dr["ProjectCompletionCert_ReferenceNumber"]),
                           ProjectCompletionCert_IssueDate = Convert.ToDateTime(dr["ProjectCompletionCert_IssueDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           Application_SearchDocumnetType = Convert.ToString(dr["Application_CeritifcateFlag"]),
                           Application_SearchOptionFlag = Convert.ToString(dr["Application_SearchOptionFlag"]),
                           Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                           Application_FromDate = Convert.ToDateTime(dr["Application_FromDate"]),
                           Application_ToDate = Convert.ToDateTime(dr["Application_ToDate"]),
                       });
            }
            return ProjectReralist;
        }
        public List<ClsprpMIS_ProjectCompletionRERAnumberDetails> Display_AuthDesk_ProjectCompletionCertificate_ByUserID(string UserID_Role, string SearchDocumentFlag, string SearchOptionFlag, string SearchRangeFlag, DateTime Application_FromDate, DateTime Application_ToDate, DateTime FromDate, DateTime ToDate, Int32 pMonth, Int32 pYear)
        {
            connection();
            List<ClsprpMIS_ProjectCompletionRERAnumberDetails> ProjectReralist = new List<ClsprpMIS_ProjectCompletionRERAnumberDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectCompletionCertificateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Application_CeritifcateFlag", SearchDocumentFlag);
            cmd.Parameters.AddWithValue("p_Application_SearchOptionFlag", SearchOptionFlag);
            cmd.Parameters.AddWithValue("p_Application_SearchRangeFlag", SearchRangeFlag);
            cmd.Parameters.AddWithValue("p_Application_FromDate", Application_FromDate);
            cmd.Parameters.AddWithValue("p_Application_ToDate", Application_ToDate);
            cmd.Parameters.AddWithValue("p_Application_Month", pMonth);
            cmd.Parameters.AddWithValue("p_Application_Year", pYear);

            ////string ddFromDate = FromDate.ToString("yyyy-MM-dd");
            ////cmd.Parameters.AddWithValue("Fromdate", ddFromDate);

            ////string ddToDate = ToDate.ToString("yyyy-MM-dd");
            ////cmd.Parameters.AddWithValue("Todate", ddToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            ////DataTable dt1 = new DataTable();
            ////var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) <= Convert.ToDateTime(ddToDate)));
            ////if (rows.Any())
            ////{
            ////    dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RERAnumberRegUptoDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            ////}

            con.Close();

            ////foreach (DataRow dr in dt1.Rows)
            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectCompletionRERAnumberDetails
                       {
                           Project_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_IndexID"]),
                           Project_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Project_RERAnumber_DiaryNumber_ID"]),

                           PCC_IndexID = Convert.ToInt64(dr["PCC_IndexID"]),
                           PCC_ID = Convert.ToInt64(dr["PCC_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectAddressLine1 = Convert.ToString(dr["ProjectAddressLine1"]),
                           ProjectAddressLine2 = Convert.ToString(dr["ProjectAddressLine2"]),
                           ProjectAddressState = Convert.ToString(dr["ProjectAddressState"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           ProjectAddressSubDivision = Convert.ToString(dr["ProjectAddressSubDivision"]),
                           ProjectAddressPIN = Convert.ToString(dr["ProjectAddressPIN"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterType = Convert.ToInt32(dr["PromoterType"]),

                           DName = Convert.ToString(dr["DName"]),
                           PCC_InfoDetails = Convert.ToString(dr["PCC_InfoDetails"]),
                           PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                           PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                           PCC_CertificateStatus = Convert.ToString(dr["PCC_CertificateStatus"]),
                           PCC_ReciptType = Convert.ToString(dr["PCC_ReciptType"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectCompletionCert_FilePath = Convert.ToString(dr["ProjectCompletionCert_FilePath"]),
                           ProjectCompletionCert_FileName = Convert.ToString(dr["ProjectCompletionCert_FileName"]),
                           ProjectCompletionCert_ReferenceNumber = Convert.ToString(dr["ProjectCompletionCert_ReferenceNumber"]),
                           ProjectCompletionCert_IssueDate = Convert.ToDateTime(dr["ProjectCompletionCert_IssueDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           Application_SearchDocumnetType = Convert.ToString(dr["Application_CeritifcateFlag"]),
                           Application_SearchOptionFlag = Convert.ToString(dr["Application_SearchOptionFlag"]),
                           Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                           Application_FromDate = Convert.ToDateTime(dr["Application_FromDate"]),
                           Application_ToDate = Convert.ToDateTime(dr["Application_ToDate"]),
                       });
            }
            return ProjectReralist;
        }
    }
}
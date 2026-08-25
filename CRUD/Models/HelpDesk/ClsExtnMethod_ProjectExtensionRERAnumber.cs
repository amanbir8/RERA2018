using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.HelpDesk
{
    public class ClsExtnMethod_ProjectExtensionRERAnumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Display Form Extension - Number Issue and Certificate
        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Display_AuthorityDesk_ProjectExtnFormRegistrationNumberDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Projectlist = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ExtnFormProjectRegNumberDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber
                       {
                           Project_ExtnRegd_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_IndexID"]),
                           Project_ExtnRegd_DiaryNumber_ID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_ID"]),
                           RelatedProjectRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_ID"]),
                           RelatedProjectRegDiaryNumber_Name = Convert.ToString(dr["RelatedProjectRegDiaryNumber_Name"]),
                           RelatedProjectRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedProjectRegDiaryNumber_NameYear"]),
                           RelatedProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_tbl_IndexID"]),
                           RelatedProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedProjectRegDiaryNumber_CreatedDate"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           RelatedExtnRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_ID"]),
                           RelatedExtnRegDiaryNumber_Name = Convert.ToString(dr["RelatedExtnRegDiaryNumber_Name"]),
                           RelatedExtnRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedExtnRegDiaryNumber_NameYear"]),
                           RelatedExtnRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_tbl_IndexID"]),
                           RelatedExtnRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedExtnRegDiaryNumber_CreatedDate"]),

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

                           ExtnRegistrationNumber = Convert.ToString(dr["ExtnRegistrationNumber"]),
                           ExtnRegistrationIssueDate = Convert.ToDateTime(dr["ExtnRegistrationIssueDate"]),
                           ExtnRegistrationRegUptoDate = Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),

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


                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

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
            return Projectlist;
        }

        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Display_AuthorityDesk_ProjectExtnFormRegistrationNumberDetailsByDate(int? approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Projectlist = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ExtnFormProjectRegNumberDetailsByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_approvalyear", approvalyear);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber
                       {
                           Project_ExtnRegd_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_IndexID"]),
                           Project_ExtnRegd_DiaryNumber_ID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_ID"]),
                           RelatedProjectRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_ID"]),
                           RelatedProjectRegDiaryNumber_Name = Convert.ToString(dr["RelatedProjectRegDiaryNumber_Name"]),
                           RelatedProjectRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedProjectRegDiaryNumber_NameYear"]),
                           RelatedProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_tbl_IndexID"]),
                           RelatedProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedProjectRegDiaryNumber_CreatedDate"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           RelatedExtnRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_ID"]),
                           RelatedExtnRegDiaryNumber_Name = Convert.ToString(dr["RelatedExtnRegDiaryNumber_Name"]),
                           RelatedExtnRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedExtnRegDiaryNumber_NameYear"]),
                           RelatedExtnRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_tbl_IndexID"]),
                           RelatedExtnRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedExtnRegDiaryNumber_CreatedDate"]),

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

                           ExtnRegistrationNumber = Convert.ToString(dr["ExtnRegistrationNumber"]),
                           ExtnRegistrationIssueDate = Convert.ToDateTime(dr["ExtnRegistrationIssueDate"]),
                           ExtnRegistrationRegUptoDate = Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),

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


                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

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
            return Projectlist;
        }

        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Display_AuthorityDesk_ProjectExtensionRegistrationNumber_IssueIdDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Projectlist = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ExtnRegistrationProjectIssueNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber
                       {
                           Project_ExtnRegd_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_IndexID"]),
                           Project_ExtnRegd_DiaryNumber_ID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_ID"]),
                           RelatedProjectRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_ID"]),
                           RelatedProjectRegDiaryNumber_Name = Convert.ToString(dr["RelatedProjectRegDiaryNumber_Name"]),
                           RelatedProjectRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedProjectRegDiaryNumber_NameYear"]),
                           RelatedProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_tbl_IndexID"]),
                           RelatedProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedProjectRegDiaryNumber_CreatedDate"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           RelatedExtnRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_ID"]),
                           RelatedExtnRegDiaryNumber_Name = Convert.ToString(dr["RelatedExtnRegDiaryNumber_Name"]),
                           RelatedExtnRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedExtnRegDiaryNumber_NameYear"]),
                           RelatedExtnRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_tbl_IndexID"]),
                           RelatedExtnRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedExtnRegDiaryNumber_CreatedDate"]),

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

                           ExtnRegistrationNumber = Convert.ToString(dr["ExtnRegistrationNumber"]),
                           ExtnRegistrationIssueDate = Convert.ToDateTime(dr["ExtnRegistrationIssueDate"]),
                           ExtnRegistrationRegUptoDate = Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),

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


                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

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
            return Projectlist;
        }

        // Add Extension of Registration Form-E
        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Display_AuthDesk_ProjectExtensionRegistrationNumber_ByIDandDNumber(Int64 ProjectId, Int64 PromoterId, string FormEDiaryNumber)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> ProjectList = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RERAnumberExtensionRegistration_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            cmd.Parameters.AddWithValue("p_FormE_DiaryNumber", FormEDiaryNumber);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                    new ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber
                    {
                        Project_ExtnRegd_DiaryNumber_IndexID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_IndexID"]),
                        Project_ExtnRegd_DiaryNumber_ID = Convert.ToInt64(dr["Project_ExtnRegd_DiaryNumber_ID"]),
                        RelatedProjectRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_ID"]),
                        RelatedProjectRegDiaryNumber_Name = Convert.ToString(dr["RelatedProjectRegDiaryNumber_Name"]),
                        RelatedProjectRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedProjectRegDiaryNumber_NameYear"]),
                        RelatedProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_tbl_IndexID"]),
                        RelatedProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedProjectRegDiaryNumber_CreatedDate"]),
                        RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                        RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),
                        RelatedExtnRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_ID"]),
                        RelatedExtnRegDiaryNumber_Name = Convert.ToString(dr["RelatedExtnRegDiaryNumber_Name"]),
                        RelatedExtnRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedExtnRegDiaryNumber_NameYear"]),
                        RelatedExtnRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedExtnRegDiaryNumber_tbl_IndexID"]),
                        RelatedExtnRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedExtnRegDiaryNumber_CreatedDate"]),

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

                        ExtnRegistrationNumber = Convert.ToString(dr["ExtnRegistrationNumber"]),
                        ExtnRegistrationIssueDate = Convert.ToDateTime(dr["ExtnRegistrationIssueDate"]),
                        ExtnRegistrationRegUptoDate = Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),

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
                    });
            }
            return ProjectList;
        }
       
        public bool Add_LDR_ProjectExtensionRegistrationNumber_DiaryNumber(ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber smodel, string User_Name, Int64 oProject_ID, Int64 oPromoter_ID, string oProjectDiaryNumber, string oProjectExtensionFormDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_ExtnForm_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ExtnRegd_DiaryNumber_IndexID", (smodel.Project_ExtnRegd_DiaryNumber_IndexID == 0) ? 0 : smodel.Project_ExtnRegd_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ExtnRegd_DiaryNumber_ID", (smodel.Project_ExtnRegd_DiaryNumber_ID == 0) ? 0 : smodel.Project_ExtnRegd_DiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_ID", (smodel.RelatedProjectRegDiaryNumber_ID == 0) ? 0 : smodel.RelatedProjectRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_Name", oProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedProjectRegDiaryNumber_NameYear) ? string.Empty : smodel.RelatedProjectRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_tbl_IndexID", (smodel.RelatedProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.RelatedProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_CreatedDate", smodel.RelatedProjectRegDiaryNumber_CreatedDate);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? string.Empty : smodel.User_ID);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_ID", (smodel.RelatedExtnRegDiaryNumber_ID == 0) ? 0 : smodel.RelatedExtnRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_Name", oProjectExtensionFormDiaryNumber);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedExtnRegDiaryNumber_NameYear) ? string.Empty : smodel.RelatedExtnRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_tbl_IndexID", (smodel.RelatedExtnRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.RelatedExtnRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_CreatedDate", smodel.RelatedExtnRegDiaryNumber_CreatedDate);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? string.Empty : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? string.Empty : smodel.ExistingRegistration);

            cmd.Parameters.AddWithValue("p_PromoterType", (smodel.PromoterType == 0) ? 0 : smodel.PromoterType);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterWebLink", String.IsNullOrEmpty(smodel.PromoterWebLink) ? string.Empty : smodel.PromoterWebLink);
            cmd.Parameters.AddWithValue("p_PromoterAuthSignFormB", String.IsNullOrEmpty(smodel.PromoterAuthSignFormB) ? string.Empty : smodel.PromoterAuthSignFormB);

            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine1", String.IsNullOrEmpty(smodel.ProjectAddressLine1) ? string.Empty : smodel.ProjectAddressLine1);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine2", String.IsNullOrEmpty(smodel.ProjectAddressLine2) ? string.Empty : smodel.ProjectAddressLine2);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_ProjectAddressState", String.IsNullOrEmpty(smodel.ProjectAddressState) ? string.Empty : smodel.ProjectAddressState);
            cmd.Parameters.AddWithValue("p_ProjectAddressSubDivision", String.IsNullOrEmpty(smodel.ProjectAddressSubDivision) ? string.Empty : smodel.ProjectAddressSubDivision);
            cmd.Parameters.AddWithValue("p_ProjectAddressPIN", String.IsNullOrEmpty(smodel.ProjectAddressPIN) ? string.Empty : smodel.ProjectAddressPIN);
            cmd.Parameters.AddWithValue("p_ProjectPotentialZone", String.IsNullOrEmpty(smodel.ProjectPotentialZone) ? string.Empty : smodel.ProjectPotentialZone);
            cmd.Parameters.AddWithValue("p_ProjectWebLink", String.IsNullOrEmpty(smodel.ProjectWebLink) ? string.Empty : smodel.ProjectWebLink);

            cmd.Parameters.AddWithValue("p_AuthorizedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorizedPerson_FirstName) ? string.Empty : smodel.AuthorizedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedPerson_LastName) ? string.Empty : smodel.AuthorizedPerson_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine1) ? string.Empty : smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? string.Empty : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_District", String.IsNullOrEmpty(smodel.AuthorizedPerson_District) ? string.Empty : smodel.AuthorizedPerson_District);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_State", String.IsNullOrEmpty(smodel.AuthorizedPerson_State) ? string.Empty : smodel.AuthorizedPerson_State);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_PIN", String.IsNullOrEmpty(smodel.AuthorizedPerson_PIN) ? string.Empty : smodel.AuthorizedPerson_PIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Email", String.IsNullOrEmpty(smodel.AuthorizedPerson_Email) ? string.Empty : smodel.AuthorizedPerson_Email);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Mobile", String.IsNullOrEmpty(smodel.AuthorizedPerson_Mobile) ? string.Empty : smodel.AuthorizedPerson_Mobile);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_ExtnRegistrationNumber", String.IsNullOrEmpty(smodel.ExtnRegistrationNumber) ? string.Empty : smodel.ExtnRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationIssueDate", smodel.ExtnRegistrationIssueDate);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationRegUptoDate", smodel.ExtnRegistrationRegUptoDate);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", (smodel.IsExtensionIssued == 0) ? 0 : smodel.IsExtensionIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
      
        public bool Update_LDR_ProjectExtensionRegistrationNumber_DiaryNumber(ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber smodel, string User_Name, Int64 oProject_ID, Int64 oPromoter_ID, string oProjectDiaryNumber, string oProjectExtensionFormDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Project_ExtnForm_AuthorityDesk_RERAnumberDNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Project_ExtnRegd_DiaryNumber_IndexID", (smodel.Project_ExtnRegd_DiaryNumber_IndexID == 0) ? 0 : smodel.Project_ExtnRegd_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_Project_ExtnRegd_DiaryNumber_ID", (smodel.Project_ExtnRegd_DiaryNumber_ID == 0) ? 0 : smodel.Project_ExtnRegd_DiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_ID", (smodel.RelatedProjectRegDiaryNumber_ID == 0) ? 0 : smodel.RelatedProjectRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_Name", oProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedProjectRegDiaryNumber_NameYear) ? string.Empty : smodel.RelatedProjectRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_tbl_IndexID", (smodel.RelatedProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.RelatedProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_CreatedDate", smodel.RelatedProjectRegDiaryNumber_CreatedDate);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? string.Empty : smodel.User_ID);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_ID", (smodel.RelatedExtnRegDiaryNumber_ID == 0) ? 0 : smodel.RelatedExtnRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_Name", oProjectExtensionFormDiaryNumber);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedExtnRegDiaryNumber_NameYear) ? string.Empty : smodel.RelatedExtnRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_tbl_IndexID", (smodel.RelatedExtnRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.RelatedExtnRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_RelatedExtnRegDiaryNumber_CreatedDate", smodel.RelatedExtnRegDiaryNumber_CreatedDate);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? string.Empty : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? string.Empty : smodel.ExistingRegistration);

            cmd.Parameters.AddWithValue("p_PromoterType", (smodel.PromoterType == 0) ? 0 : smodel.PromoterType);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterWebLink", String.IsNullOrEmpty(smodel.PromoterWebLink) ? string.Empty : smodel.PromoterWebLink);
            cmd.Parameters.AddWithValue("p_PromoterAuthSignFormB", String.IsNullOrEmpty(smodel.PromoterAuthSignFormB) ? string.Empty : smodel.PromoterAuthSignFormB);

            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine1", String.IsNullOrEmpty(smodel.ProjectAddressLine1) ? string.Empty : smodel.ProjectAddressLine1);
            cmd.Parameters.AddWithValue("p_ProjectAddressLine2", String.IsNullOrEmpty(smodel.ProjectAddressLine2) ? string.Empty : smodel.ProjectAddressLine2);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_ProjectAddressState", String.IsNullOrEmpty(smodel.ProjectAddressState) ? string.Empty : smodel.ProjectAddressState);
            cmd.Parameters.AddWithValue("p_ProjectAddressSubDivision", String.IsNullOrEmpty(smodel.ProjectAddressSubDivision) ? string.Empty : smodel.ProjectAddressSubDivision);
            cmd.Parameters.AddWithValue("p_ProjectAddressPIN", String.IsNullOrEmpty(smodel.ProjectAddressPIN) ? string.Empty : smodel.ProjectAddressPIN);
            cmd.Parameters.AddWithValue("p_ProjectPotentialZone", String.IsNullOrEmpty(smodel.ProjectPotentialZone) ? string.Empty : smodel.ProjectPotentialZone);
            cmd.Parameters.AddWithValue("p_ProjectWebLink", String.IsNullOrEmpty(smodel.ProjectWebLink) ? string.Empty : smodel.ProjectWebLink);

            cmd.Parameters.AddWithValue("p_AuthorizedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorizedPerson_FirstName) ? string.Empty : smodel.AuthorizedPerson_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedPerson_LastName) ? string.Empty : smodel.AuthorizedPerson_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine1) ? string.Empty : smodel.AuthorizedPerson_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedPerson_AddressLine2) ? string.Empty : smodel.AuthorizedPerson_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_District", String.IsNullOrEmpty(smodel.AuthorizedPerson_District) ? string.Empty : smodel.AuthorizedPerson_District);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_State", String.IsNullOrEmpty(smodel.AuthorizedPerson_State) ? string.Empty : smodel.AuthorizedPerson_State);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_PIN", String.IsNullOrEmpty(smodel.AuthorizedPerson_PIN) ? string.Empty : smodel.AuthorizedPerson_PIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Email", String.IsNullOrEmpty(smodel.AuthorizedPerson_Email) ? string.Empty : smodel.AuthorizedPerson_Email);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Mobile", String.IsNullOrEmpty(smodel.AuthorizedPerson_Mobile) ? string.Empty : smodel.AuthorizedPerson_Mobile);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_ExtnRegistrationNumber", String.IsNullOrEmpty(smodel.ExtnRegistrationNumber) ? string.Empty : smodel.ExtnRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationIssueDate", smodel.ExtnRegistrationIssueDate);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationRegUptoDate", smodel.ExtnRegistrationRegUptoDate);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", (smodel.IsExtensionIssued == 0) ? 0 : smodel.IsExtensionIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //Generate (Form-5) Registration Number
        public Tuple<string, string, DateTime, DateTime, DateTime, DateTime, Int32> Extract_AuthDesk_ProjectExtensionRegistrationNumberDateDetails_ByID(Int64 oProject_ID, Int64 oPromoter_ID, string oUserID)
        {
            connection();
            string retRegistrationDNumber = string.Empty;
            string retRegistrationFormFiveDNumber = string.Empty;
            string retRegistrationNumber = string.Empty;
            DateTime retIssueDate = DateTime.Now;
            DateTime retUptoDate = DateTime.Now;
            DateTime retExtnIssueDate = DateTime.Now;
            DateTime retExtnUptoDate = DateTime.Now;
            Int32 retRegisteredFlag = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectExtnFormRegdDateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_UserID", oUserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                retRegistrationDNumber = Convert.ToString(dr["registrationProjectDNumber"]);
                retRegistrationFormFiveDNumber = Convert.ToString(dr["registrationFormFiveDNumber"]);
                retRegistrationNumber = Convert.ToString(dr["registrationNumber"]);
                retIssueDate = Convert.ToDateTime(dr["registrationIssueDate"]);
                retUptoDate = Convert.ToDateTime(dr["registrationUptoDate"]);
                retExtnIssueDate = Convert.ToDateTime(dr["registrationExtnIssueDate"]);
                retExtnUptoDate = Convert.ToDateTime(dr["registrationExtnUptoDate"]);
                retRegisteredFlag = Convert.ToInt32(dr["registeredFlag"]);
            }
            return new Tuple<string, string, DateTime, DateTime, DateTime, DateTime, Int32>(string.Concat(retRegistrationFormFiveDNumber, " of ", retRegistrationDNumber), retRegistrationNumber, retIssueDate, retUptoDate, retExtnIssueDate, retExtnUptoDate, retRegisteredFlag);
        }

        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberExtnSummaryDetails> Display_AuthDesk_ProjectExtensionRegistrationNumberHistory_ByProjectID(Int64 prmProjectID, Int64 prmPromoterID, string prmUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberExtnSummaryDetails> Projectlist = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberExtnSummaryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectExtnFormRegdNumberHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", prmUserRole);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", prmProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", prmPromoterID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberExtnSummaryDetails
                       {
                           Project_RegistrationNumber = Convert.ToString(dr["vProject_RegistrationNumber"]),
                           Project_IssueDate = Convert.ToDateTime(dr["vProject_IssueDate"]),
                           Project_ValidUptoDate = Convert.ToDateTime(dr["vProject_ValidUptoDate"]),
                           ProjectFormFive_ValidUptoDate = Convert.ToDateTime(dr["vProjectFormFive_ValidUptoDate"]),
                           ProjectName = Convert.ToString(dr["vProjectName"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["vDiaryNumberName"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                       });
            }
            return Projectlist;
        }
    }
}
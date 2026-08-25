using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_LDRnumberRegisteredProjectDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber> Display_Project_RegisteredProjectDetails_ByID(Int64 pRelatedProjectID, Int64 pRelatedPromoterID, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber> ProjectList = new List<ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_LDR_RERAnumberRegistration_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProjectID", pRelatedProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoterID", pRelatedPromoterID);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_ProjectRERAnumberDiaryNumber
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
                       });
            }
            return ProjectList;
        }

        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> Display_Project_ExtensionRegisteredProject_ByID(Int64 pRelatedProjectID, Int64 pRelatedPromoterID, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber> ProjectList = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_LDR_RERAnumberExtnRegistration_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProjectID", pRelatedProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoterID", pRelatedPromoterID);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);

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

        public List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate> Display_Project_RegisteredProjectCertificateDocuments_ByID(Int64 pRelatedProjectID, Int64 pRelatedPromoterID, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate> ProjectDocList = new List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_LDR_RERAnumberAllCertificate_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProjectID", pRelatedProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoterID", pRelatedPromoterID);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectDocList.Add(
                    new ClsPrp_AuthorityDesk_ProjectRERA_Certificate
                    {
                        ProjectRERAcertificate_IndexID = Convert.ToInt64(dr["ProjectRERAcertificate_IndexID"]),
                        ProjectRERAcertificate_ID = Convert.ToInt64(dr["ProjectRERAcertificate_ID"]),
                        ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),

                        ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                        ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),

                        ProjectRERAcert_InfoCode = Convert.ToString(dr["ProjectRERAcert_InfoCode"]),
                        ProjectRERAcert_InfoName = Convert.ToString(dr["ProjectRERAcert_InfoName"]),
                        //ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                        ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),

                        ProjectRERAcert_FileSize = Convert.ToString(dr["ProjectRERAcert_FileSize"]),
                        ProjectRERAcert_FileFormat = Convert.ToString(dr["ProjectRERAcert_FileFormat"]),
                        ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                        ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                        ProjectRERAcert_IsGroup = Convert.ToInt32(dr["ProjectRERAcert_IsGroup"]),

                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

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
            return ProjectDocList;
        }
    }
}
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_LDRnumberRegisteredAgentDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> Display_Agent_RegisteredAgenttDetails_ByID(Int64 pRelatedAgentID, Int64 pRelatedRenewalAgentID, string pADNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber> AgentList = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_LDR_RERAnumberRegistration_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedAgentID", pRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentID", pRelatedRenewalAgentID);
            cmd.Parameters.AddWithValue("p_AgentDiaryNumber", pADNumber);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberDiaryNumber
                       {
                           Agent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_IndexID"]),
                           Agent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["Agent_RERAnumber_DiaryNumber_ID"]),
                           AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                           AgentRegDiaryNumber_NameYear = Convert.ToString(dr["AgentRegDiaryNumber_NameYear"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           UserID = Convert.ToString(dr["UserID"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                       });
            }
            return AgentList;
        }

        public List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber> Display_Agent_RenewalRegisteredAgent_ByID(Int64 pRelatedAgentID, Int64 pRelatedRenewalAgentID, string pRefRegdNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber> AgentList = new List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_LDR_RERAnumberRenewalRegistration_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedAgentID", pRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentID", pRelatedRenewalAgentID);
            cmd.Parameters.AddWithValue("p_RefRegdNumber", pRefRegdNumber);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                    new ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber
                    {
                        AgentRegRenewal_DiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegRenewal_DiaryNumber_IndexID"]),
                        AgentRegRenewal_DiaryNumber_ID = Convert.ToInt64(dr["AgentRegRenewal_DiaryNumber_ID"]),
                        RelatedAgent_ID = Convert.ToInt64(dr["RelatedAgent_ID"]),
                        RelatedRenewalAgent_ID = Convert.ToInt64(dr["RelatedRenewalAgent_ID"]),
                        RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                        RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                        RelatedAgentDiaryNumber_ID = Convert.ToInt64(dr["RelatedAgentDiaryNumber_ID"]),
                        RelatedAgentDiaryNumber_Name = Convert.ToString(dr["RelatedAgentDiaryNumber_Name"]),
                        RelatedAgentDiaryNumber_NameYear = Convert.ToString(dr["RelatedAgentDiaryNumber_NameYear"]),
                        RelatedRenewalAgentRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedRenewalAgentRegDiaryNumber_ID"]),
                        RelatedRenewalAgentRegDiaryNumber_Name = Convert.ToString(dr["RelatedRenewalAgentRegDiaryNumber_Name"]),
                        RelatedRenewalAgentRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedRenewalAgentRegDiaryNumber_NameYear"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                        DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                        UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                        PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                        AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),
                        CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                        EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                        tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),
                        ReferenceProject_ID = Convert.ToInt64(dr["ReferenceProject_ID"]),
                        ReferenceProject_Name = Convert.ToString(dr["ReferenceProject_Name"]),
                        ReferencePromoter_ID = Convert.ToInt64(dr["ReferencePromoter_ID"]),
                        ReferencePromoter_Name = Convert.ToString(dr["ReferencePromoter_Name"]),
                        IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                        ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                        Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                        BComm_Address_PIN = Convert.ToString(dr["BComm_Address_PIN"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
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
                        RenewalAgentRegistrationNumber = Convert.ToString(dr["RenewalAgentRegistrationNumber"]),
                        RenewalAgentRegistrationIssueDate = Convert.ToDateTime(dr["RenewalAgentRegistrationIssueDate"]),
                        RenewalAgentRegistrationRegUptoDate = Convert.ToDateTime(dr["RenewalAgentRegistrationRegUptoDate"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Extra4 = Convert.ToString(dr["Extra4"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                        IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsConditionAnnexureIssued = Convert.ToInt32(dr["IsConditionAnnexureIssued"]),
                        IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        Agent_Name = Convert.ToString(dr["Agent_Name"]),
                        Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                        Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                    });
            }
            return AgentList;
        }

        public List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber> Display_Agent_RenewalHistoryRegisteredAgent_ByID(Int64 pRelatedAgentID, Int64 pRelatedRenewalAgentID, string pRefRegdNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber> AgentList = new List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_LDR_RERAnumberRenewalHistory_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedAgentID", pRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentID", pRelatedRenewalAgentID);
            cmd.Parameters.AddWithValue("p_RefRegdNumber", pRefRegdNumber);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                    new ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber
                    {
                        AgentRegRenewal_DiaryNumber_IndexID = Convert.ToInt64(dr["AgentRegRenewal_DiaryNumber_IndexID"]),
                        AgentRegRenewal_DiaryNumber_ID = Convert.ToInt64(dr["AgentRegRenewal_DiaryNumber_ID"]),
                        RelatedAgent_ID = Convert.ToInt64(dr["RelatedAgent_ID"]),
                        RelatedRenewalAgent_ID = Convert.ToInt64(dr["RelatedRenewalAgent_ID"]),
                        RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                        RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                        RelatedAgentDiaryNumber_ID = Convert.ToInt64(dr["RelatedAgentDiaryNumber_ID"]),
                        RelatedAgentDiaryNumber_Name = Convert.ToString(dr["RelatedAgentDiaryNumber_Name"]),
                        RelatedAgentDiaryNumber_NameYear = Convert.ToString(dr["RelatedAgentDiaryNumber_NameYear"]),
                        RelatedRenewalAgentRegDiaryNumber_ID = Convert.ToInt64(dr["RelatedRenewalAgentRegDiaryNumber_ID"]),
                        RelatedRenewalAgentRegDiaryNumber_Name = Convert.ToString(dr["RelatedRenewalAgentRegDiaryNumber_Name"]),
                        RelatedRenewalAgentRegDiaryNumber_NameYear = Convert.ToString(dr["RelatedRenewalAgentRegDiaryNumber_NameYear"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        OtherMemDetailsCount = Convert.ToInt32(dr["OtherMemDetailsCount"]),
                        DocumentuploadsCount = Convert.ToInt32(dr["DocumentuploadsCount"]),
                        UTotherStateRERACount = Convert.ToInt32(dr["UTotherStateRERACount"]),
                        PaymentsCount = Convert.ToInt32(dr["PaymentsCount"]),
                        AgentDocumentCount = Convert.ToInt32(dr["AgentDocumentCount"]),
                        CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                        EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                        tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),
                        ReferenceProject_ID = Convert.ToInt64(dr["ReferenceProject_ID"]),
                        ReferenceProject_Name = Convert.ToString(dr["ReferenceProject_Name"]),
                        ReferencePromoter_ID = Convert.ToInt64(dr["ReferencePromoter_ID"]),
                        ReferencePromoter_Name = Convert.ToString(dr["ReferencePromoter_Name"]),
                        IsAlreadyRegistration = Convert.ToString(dr["IsAlreadyRegistration"]),
                        ExistingRegistration = Convert.ToString(dr["ExistingRegistration"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                        Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),
                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                        BComm_Address_PIN = Convert.ToString(dr["BComm_Address_PIN"]),
                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
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
                        RenewalAgentRegistrationNumber = Convert.ToString(dr["RenewalAgentRegistrationNumber"]),
                        RenewalAgentRegistrationIssueDate = Convert.ToDateTime(dr["RenewalAgentRegistrationIssueDate"]),
                        RenewalAgentRegistrationRegUptoDate = Convert.ToDateTime(dr["RenewalAgentRegistrationRegUptoDate"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Extra4 = Convert.ToString(dr["Extra4"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                        IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                        IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                        IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsConditionAnnexureIssued = Convert.ToInt32(dr["IsConditionAnnexureIssued"]),
                        IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        Agent_Name = Convert.ToString(dr["Agent_Name"]),
                        Agent_AddressDistrictName = Convert.ToString(dr["Agent_AddressDistrictName"]),
                        Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                    });
            }
            return AgentList;
        }

        public List<ClsPrp_AuthorityDesk_AgentRERA_Certificate> Display_Agent_RegisteredAgentCertificateDocuments_ByID(Int64 pRelatedAgentID, Int64 pRelatedRenewalAgentID, string pADNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERA_Certificate> AgentDocList = new List<ClsPrp_AuthorityDesk_AgentRERA_Certificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_LDR_RERAnumberAllCertificate_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedAgentID", pRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentID", pRelatedRenewalAgentID);
            cmd.Parameters.AddWithValue("p_AgentDiaryNumber", pADNumber);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentDocList.Add(
                    new ClsPrp_AuthorityDesk_AgentRERA_Certificate
                    {
                        AgentRERAcertificate_IndexID = Convert.ToInt64(dr["AgentRERAcertificate_IndexID"]),
                        AgentRERAcertificate_ID = Convert.ToInt64(dr["AgentRERAcertificate_ID"]),
                        AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        tbl_RegDiaryNumber_indexID = Convert.ToInt64(dr["tbl_RegDiaryNumber_indexID"]),
                        AgentRERAcert_InfoCode = Convert.ToString(dr["AgentRERAcert_InfoCode"]),
                        AgentRERAcert_InfoName = Convert.ToString(dr["AgentRERAcert_InfoName"]),
                        AgentDoc_RelatedSectionName = Convert.ToString(dr["AgentDoc_RelatedSectionName"]),
                        AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                        AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                        AgentRERAcert_FileSize = Convert.ToString(dr["AgentRERAcert_FileSize"]),
                        AgentRERAcert_FileFormat = Convert.ToString(dr["AgentRERAcert_FileFormat"]),
                        AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                        AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                        AgentRERAcert_IsGroup = Convert.ToInt32(dr["AgentRERAcert_IsGroup"]),
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
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return AgentDocList;
        }
    }
}
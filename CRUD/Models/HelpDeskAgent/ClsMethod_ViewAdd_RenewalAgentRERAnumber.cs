using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_ViewAdd_RenewalAgentRERAnumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber> Display_AuthDesk_RenewalAgentRERAnumber_ByIDandDiaryNumber(Int64 AgentID, Int32 AgentTypeID, Int64 RenewalAgentID, Int32 RenewalAgentSeqID, Int32 RenewalAgentYrID, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber> RenewalAgentList = new List<ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_RenewalAgent_RERAnumber_registration_ByID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentID", AgentID);
            cmd.Parameters.AddWithValue("p_AgentTypeID", AgentTypeID);
            cmd.Parameters.AddWithValue("p_RnAgentID", RenewalAgentID);
            cmd.Parameters.AddWithValue("p_RnAgentSeqID", RenewalAgentSeqID);
            cmd.Parameters.AddWithValue("p_RnAgentYrID", RenewalAgentYrID);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RenewalAgentList.Add(
                    new ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber
                    {
                        RenewalAgent_RERAnumber_DiaryNumber_IndexID = Convert.ToInt64(dr["RenewalAgent_RERAnumber_DiaryNumber_IndexID"]),
                        RenewalAgent_RERAnumber_DiaryNumber_ID = Convert.ToInt64(dr["RenewalAgent_RERAnumber_DiaryNumber_ID"]),
                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_RERAnumberIssueDate = Convert.ToDateTime(dr["Related_RERAnumberIssueDate"]),
                        Related_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Related_RERAnumberRegUptoDate"]),

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
                        Agent_Type = Convert.ToString(dr["Agent_Type"]), //int(11)
                        Agent_FirstName = Convert.ToString(dr["Agent_FirstName"]),
                        Agent_LastName = Convert.ToString(dr["Agent_LastName"]),
                        Organization_Name = Convert.ToString(dr["Organization_Name"]),

                        BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                        BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                        BComm_AddressStateCode = Convert.ToInt32(dr["BComm_AddressStateCode"]),
                        BComm_AddressDistrictCode = Convert.ToInt32(dr["BComm_AddressDistrictCode"]),
                        BComm_AddressPIN = Convert.ToInt32(dr["BComm_AddressPIN"]),
                        BComm_AddressStateName = Convert.ToString(dr["BComm_AddressStateName"]), //int(11)
                        BComm_AddressDistrictName = Convert.ToString(dr["BComm_AddressDistrictName"]), //int(11)

                        EmailAddress = Convert.ToString(dr["EmailAddress"]),
                        MobileNumber = Convert.ToInt64(dr["MobileNumber"]),

                        AuthorizedSignatory_FirstName = Convert.ToString(dr["AuthorizedSignatory_FirstName"]),
                        AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),

                        AuthorizedSignatory_AddressLine1 = Convert.ToString(dr["AuthorizedSignatory_AddressLine1"]),
                        AuthorizedSignatory_AddressLine2 = Convert.ToString(dr["AuthorizedSignatory_AddressLine2"]),
                        AuthorizedSignatory_AddressStateCode = Convert.ToInt32(dr["AuthorizedSignatory_AddressStateCode"]),
                        AuthorizedSignatory_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedSignatory_AddressDistrictCode"]),
                        AuthorizedSignatory_AddressPIN = Convert.ToInt32(dr["AuthorizedSignatory_AddressPIN"]),
                        AuthorizedSignatory_AddressStateName = Convert.ToString(dr["AuthorizedSignatory_AddressStateName"]), //int(11)
                        AuthorizedSignatory_AddressDistrictName = Convert.ToString(dr["AuthorizedSignatory_AddressDistrictName"]), //int(11)

                        AuthorizedSignatory_EmailAddress = Convert.ToString(dr["AuthorizedSignatory_EmailAddress"]),
                        AuthorizedSignatory_MobileNumber = Convert.ToInt64(dr["AuthorizedSignatory_MobileNumber"]),

                        Agent_RERAnumberRegistration = Convert.ToString(dr["Agent_RERAnumberRegistration"]),
                        Agent_RERAnumberIssueDate = Convert.ToDateTime(dr["Agent_RERAnumberIssueDate"]),
                        Agent_RERAnumberRegUptoDate = Convert.ToDateTime(dr["Agent_RERAnumberRegUptoDate"]),
                        LatestRenewalAgent_RERAnumberRegistration = Convert.ToString(dr["LatestRenewalAgent_RERAnumberRegistration"]),
                        LatestRenewalAgent_RERAnumberIssueDate = Convert.ToDateTime(dr["LatestRenewalAgent_RERAnumberIssueDate"]),
                        LatestRenewalAgent_RERAnumberRegUptoDate = Convert.ToDateTime(dr["LatestRenewalAgent_RERAnumberRegUptoDate"]),

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
                        IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                        IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return RenewalAgentList;
        }
        
        /// Save Method        
        public bool Add_LDR_RenewalAgent_RERAnumber_DiaryNumber(ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber smodel, string vUserName, string vRenewalAgentRN, string vRenewalAgentDN, Int64 vRelatedAgentID, Int32 vRelatedAgentTypeID, Int64 vRenewalAgentID, Int32 vRenewalAgentSeqID, Int32 vRenewalAgentYear)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_RenewalAgent_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentRegRenewal_DiaryNumber_IndexID", smodel.RenewalAgent_RERAnumber_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRegRenewal_DiaryNumber_ID", smodel.RenewalAgent_RERAnumber_DiaryNumber_ID);

            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", vRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_ID", vRenewalAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", vRenewalAgentYear);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", vRenewalAgentSeqID);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_ID", (smodel.RelatedAgentDiaryNumber_ID == 0) ? 0 : smodel.RelatedAgentDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.RelatedAgentDiaryNumber_Name) ? "" : smodel.RelatedAgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedAgentDiaryNumber_NameYear) ? "0" : smodel.RelatedAgentDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentRegDiaryNumber_ID", (smodel.RelatedRenewalAgentRegDiaryNumber_ID == 0) ? 0 : smodel.RelatedRenewalAgentRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentRegDiaryNumber_Name", String.IsNullOrEmpty(vRenewalAgentDN) ? "" : vRenewalAgentDN);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedRenewalAgentRegDiaryNumber_NameYear) ? "0" : smodel.RelatedRenewalAgentRegDiaryNumber_NameYear);

            cmd.Parameters.AddWithValue("p_RelatedUserID", String.IsNullOrEmpty(smodel.Related_UserID) ? "" : smodel.Related_UserID);

            cmd.Parameters.AddWithValue("p_OtherMemDetailsCount", (smodel.OtherMemDetailsCount == 0) ? 0 : smodel.OtherMemDetailsCount);
            cmd.Parameters.AddWithValue("p_DocumentuploadsCount", (smodel.DocumentuploadsCount == 0) ? 0 : smodel.DocumentuploadsCount);
            cmd.Parameters.AddWithValue("p_UTotherStateRERACount", (smodel.UTotherStateRERACount == 0) ? 0 : smodel.UTotherStateRERACount);
            cmd.Parameters.AddWithValue("p_PaymentsCount", (smodel.PaymentsCount == 0) ? 0 : smodel.PaymentsCount);
            cmd.Parameters.AddWithValue("p_AgentDocumentCount", (smodel.AgentDocumentCount == 0) ? 0 : smodel.AgentDocumentCount);

            cmd.Parameters.AddWithValue("p_CurrentEventcode", (smodel.CurrentEventcode == 0) ? 0 : smodel.CurrentEventcode);
            cmd.Parameters.AddWithValue("p_EventCodeDetails_indexID", (smodel.EventCodeDetails_indexID == 0) ? 0 : smodel.EventCodeDetails_indexID);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_ReferenceProject_ID", (smodel.ReferenceProject_ID == 0) ? 0 : smodel.ReferenceProject_ID);
            cmd.Parameters.AddWithValue("p_ReferenceProject_Name", String.IsNullOrEmpty(smodel.ReferenceProject_Name) ? "" : smodel.ReferenceProject_Name);
            cmd.Parameters.AddWithValue("p_ReferencePromoter_ID", (smodel.ReferencePromoter_ID == 0) ? 0 : smodel.ReferencePromoter_ID);
            cmd.Parameters.AddWithValue("p_ReferencePromoter_Name", String.IsNullOrEmpty(smodel.ReferencePromoter_Name) ? "" : smodel.ReferencePromoter_Name);
   
            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? "" : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? "" : smodel.ExistingRegistration);
            cmd.Parameters.AddWithValue("p_Agent_Type", vRelatedAgentTypeID);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", String.IsNullOrEmpty(smodel.Agent_FirstName) ? "" : smodel.Agent_FirstName);            
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Organization_Name", String.IsNullOrEmpty(smodel.Organization_Name) ? "" : smodel.Organization_Name);

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_Address_PIN", (smodel.BComm_AddressPIN == 0) ? 0 : smodel.BComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_MobileNumber", (smodel.MobileNumber == 0) ? 0 : smodel.MobileNumber);
            
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_FirstName) ? "" : smodel.AuthorizedSignatory_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_LastName) ? "" : smodel.AuthorizedSignatory_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", String.IsNullOrEmpty(smodel.AuthorizedSignatory_AddressLine1) ? "" : smodel.AuthorizedSignatory_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedSignatory_AddressLine2) ? "" : smodel.AuthorizedSignatory_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_State", smodel.AuthorizedSignatory_AddressStateCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_District", smodel.AuthorizedSignatory_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_PIN", (smodel.AuthorizedSignatory_AddressPIN == 0) ? 0 : smodel.AuthorizedSignatory_AddressPIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Email", String.IsNullOrEmpty(smodel.AuthorizedSignatory_EmailAddress) ? "" : smodel.AuthorizedSignatory_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Mobile", (smodel.AuthorizedSignatory_MobileNumber == 0) ? 0 : smodel.AuthorizedSignatory_MobileNumber);
            
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Agent_RERAnumberRegistration) ? "" : smodel.Agent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.Agent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.Agent_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_RenewalAgentRegistrationNumber", String.IsNullOrEmpty(smodel.LatestRenewalAgent_RERAnumberRegistration) ? "" : smodel.LatestRenewalAgent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RenewalAgentRegistrationIssueDate", smodel.LatestRenewalAgent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RenewalAgentRegistrationRegUptoDate", smodel.LatestRenewalAgent_RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? "" : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);           

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditionAnnexureIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", vUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", vUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        
        /// Update Method        
        public bool Update_LDR_RenewalAgent_RERAnumber_DiaryNumber(ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber smodel, string vUserName, string vRenewalAgentRN, string vRenewalAgentDN, Int64 vRelatedAgentID, Int32 vRelatedAgentTypeID, Int64 vRenewalAgentID, Int32 vRenewalAgentSeqID, Int32 vRenewalAgentYear)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_RenewalAgent_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentRegRenewal_DiaryNumber_IndexID", smodel.RenewalAgent_RERAnumber_DiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_AgentRegRenewal_DiaryNumber_ID", smodel.RenewalAgent_RERAnumber_DiaryNumber_ID);

            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", vRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_ID", vRenewalAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_Year", vRenewalAgentYear);
            cmd.Parameters.AddWithValue("p_RenewalOrderSequence", vRenewalAgentSeqID);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_ID", (smodel.RelatedAgentDiaryNumber_ID == 0) ? 0 : smodel.RelatedAgentDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_Name", String.IsNullOrEmpty(smodel.RelatedAgentDiaryNumber_Name) ? "" : smodel.RelatedAgentDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedAgentDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedAgentDiaryNumber_NameYear) ? "0" : smodel.RelatedAgentDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentRegDiaryNumber_ID", (smodel.RelatedRenewalAgentRegDiaryNumber_ID == 0) ? 0 : smodel.RelatedRenewalAgentRegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentRegDiaryNumber_Name", String.IsNullOrEmpty(vRenewalAgentDN) ? "" : vRenewalAgentDN);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentRegDiaryNumber_NameYear", String.IsNullOrEmpty(smodel.RelatedRenewalAgentRegDiaryNumber_NameYear) ? "0" : smodel.RelatedRenewalAgentRegDiaryNumber_NameYear);

            cmd.Parameters.AddWithValue("p_RelatedUserID", String.IsNullOrEmpty(smodel.Related_UserID) ? "" : smodel.Related_UserID);

            cmd.Parameters.AddWithValue("p_OtherMemDetailsCount", (smodel.OtherMemDetailsCount == 0) ? 0 : smodel.OtherMemDetailsCount);
            cmd.Parameters.AddWithValue("p_DocumentuploadsCount", (smodel.DocumentuploadsCount == 0) ? 0 : smodel.DocumentuploadsCount);
            cmd.Parameters.AddWithValue("p_UTotherStateRERACount", (smodel.UTotherStateRERACount == 0) ? 0 : smodel.UTotherStateRERACount);
            cmd.Parameters.AddWithValue("p_PaymentsCount", (smodel.PaymentsCount == 0) ? 0 : smodel.PaymentsCount);
            cmd.Parameters.AddWithValue("p_AgentDocumentCount", (smodel.AgentDocumentCount == 0) ? 0 : smodel.AgentDocumentCount);

            cmd.Parameters.AddWithValue("p_CurrentEventcode", (smodel.CurrentEventcode == 0) ? 0 : smodel.CurrentEventcode);
            cmd.Parameters.AddWithValue("p_EventCodeDetails_indexID", (smodel.EventCodeDetails_indexID == 0) ? 0 : smodel.EventCodeDetails_indexID);
            cmd.Parameters.AddWithValue("p_tbl_RegDiaryNumber_indexID", (smodel.tbl_RegDiaryNumber_indexID == 0) ? 0 : smodel.tbl_RegDiaryNumber_indexID);

            cmd.Parameters.AddWithValue("p_ReferenceProject_ID", (smodel.ReferenceProject_ID == 0) ? 0 : smodel.ReferenceProject_ID);
            cmd.Parameters.AddWithValue("p_ReferenceProject_Name", String.IsNullOrEmpty(smodel.ReferenceProject_Name) ? "" : smodel.ReferenceProject_Name);
            cmd.Parameters.AddWithValue("p_ReferencePromoter_ID", (smodel.ReferencePromoter_ID == 0) ? 0 : smodel.ReferencePromoter_ID);
            cmd.Parameters.AddWithValue("p_ReferencePromoter_Name", String.IsNullOrEmpty(smodel.ReferencePromoter_Name) ? "" : smodel.ReferencePromoter_Name);

            cmd.Parameters.AddWithValue("p_IsAlreadyRegistration", String.IsNullOrEmpty(smodel.IsAlreadyRegistration) ? "" : smodel.IsAlreadyRegistration);
            cmd.Parameters.AddWithValue("p_ExistingRegistration", String.IsNullOrEmpty(smodel.ExistingRegistration) ? "" : smodel.ExistingRegistration);
            cmd.Parameters.AddWithValue("p_Agent_Type", vRelatedAgentTypeID);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", String.IsNullOrEmpty(smodel.Agent_FirstName) ? "" : smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", String.IsNullOrEmpty(smodel.Agent_LastName) ? "" : smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Organization_Name", String.IsNullOrEmpty(smodel.Organization_Name) ? "" : smodel.Organization_Name);

            cmd.Parameters.AddWithValue("p_BComm_AddressLine1", String.IsNullOrEmpty(smodel.BComm_AddressLine1) ? "" : smodel.BComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_BComm_AddressLine2", String.IsNullOrEmpty(smodel.BComm_AddressLine2) ? "" : smodel.BComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", smodel.BComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_Address_PIN", (smodel.BComm_AddressPIN == 0) ? 0 : smodel.BComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_MobileNumber", (smodel.MobileNumber == 0) ? 0 : smodel.MobileNumber);

            cmd.Parameters.AddWithValue("p_AuthorizedPerson_FirstName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_FirstName) ? "" : smodel.AuthorizedSignatory_FirstName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_LastName", String.IsNullOrEmpty(smodel.AuthorizedSignatory_LastName) ? "" : smodel.AuthorizedSignatory_LastName);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine1", String.IsNullOrEmpty(smodel.AuthorizedSignatory_AddressLine1) ? "" : smodel.AuthorizedSignatory_AddressLine1);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_AddressLine2", String.IsNullOrEmpty(smodel.AuthorizedSignatory_AddressLine2) ? "" : smodel.AuthorizedSignatory_AddressLine2);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_State", smodel.AuthorizedSignatory_AddressStateCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_District", smodel.AuthorizedSignatory_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_PIN", (smodel.AuthorizedSignatory_AddressPIN == 0) ? 0 : smodel.AuthorizedSignatory_AddressPIN);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Email", String.IsNullOrEmpty(smodel.AuthorizedSignatory_EmailAddress) ? "" : smodel.AuthorizedSignatory_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedPerson_Mobile", (smodel.AuthorizedSignatory_MobileNumber == 0) ? 0 : smodel.AuthorizedSignatory_MobileNumber);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.Agent_RERAnumberRegistration) ? "" : smodel.Agent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.Agent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.Agent_RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_RenewalAgentRegistrationNumber", String.IsNullOrEmpty(smodel.LatestRenewalAgent_RERAnumberRegistration) ? "" : smodel.LatestRenewalAgent_RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RenewalAgentRegistrationIssueDate", smodel.LatestRenewalAgent_RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RenewalAgentRegistrationRegUptoDate", smodel.LatestRenewalAgent_RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? "" : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsConditionAnnexureIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", vUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", vUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

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

        //Generate Registration Number
        public bool Check_UniqueRenewalAgentRegistrationNumber(string RegdNumber)
        {
            bool rval = false;
            Int32 rvalcount = 0;
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_AgentRenewal_AlreadyExistRegistrationNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_RegistrationNumber", RegdNumber);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                rvalcount = Convert.ToInt32(dr["CountRegistrationNumber"]);
            }

            if (rvalcount > 0)
            {
                rval = true;
            }
            cmd.Dispose();
            con.Close();
            return rval;
        }

        //Renewal of Registration History
        public List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> Display_AuthDesk_RenewalAgent_RegistrationNumberHistory_ByID(Int64 prmAgentID, Int64 prmRnAgentID, Int32 prmRnAgentSeqID, Int32 prmRnAgentYearID, string prmUserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> Agentlist = new List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RenewalAgentRegistrationNumberHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_UserRole", prmUserRole);
            cmd.Parameters.AddWithValue("p_RelatedAgent_ID", prmAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgent_ID", prmRnAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalSequence_ID", prmRnAgentSeqID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalYear_ID", prmRnAgentYearID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agentlist.Add(
                       new ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails
                       {
                           Prepared_SequenceNumber = Convert.ToString(dr["vPrepared_SequenceNumber"]),
                           Prepared_AgentStateType = Convert.ToString(dr["vPrepared_AgentStateType"]),
                           Prepared_NumberTypeFlag = Convert.ToString(dr["vPrepared_NumberTypeFlag"]),

                           Prepared_RegistrationNumber = Convert.ToString(dr["vPrepared_RegistrationNumber"]),
                           Prepared_IssueDate = Convert.ToDateTime(dr["vPrepared_IssueDate"]),
                           Prepared_ValidUptoDate = Convert.ToDateTime(dr["vPrepared_ValidUptoDate"]),

                           Amount_PriceValue = Convert.ToDecimal(dr["vAmountPriceValue"]),
                           NumberAlreadyExisted_Flag = Convert.ToString(dr["vNumberAlreadyExisted_Flag"]),

                           RealEstateAgentName = Convert.ToString(dr["RealEstateAgentName"]),
                           RealEstateAgentRegDiaryNumber_Name = Convert.ToString(dr["RealEstateAgentRegDiaryNumber_Name"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                       });
            }
            return Agentlist;
        }

    }
}
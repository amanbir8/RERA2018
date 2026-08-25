using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsMethod_View_CP_AgentRevocationCancellation
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Register Revoke
        public List<ClsPrp_ControlPanel_View_AgentRevocationCancellation> Display_CP_AgentRegistrationRevocationCancellation_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_AgentRevocationCancellation> CPregistrationList = new List<ClsPrp_ControlPanel_View_AgentRevocationCancellation>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_AgentRegistrationDetailsForRevoke_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPregistrationList.Add(
                    new ClsPrp_ControlPanel_View_AgentRevocationCancellation
                    {
                        Agent_ID = Convert.ToInt64(dr["prmAgent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["prmAgent_Type"]),
                        AgentRegDiaryNumber_Name = Convert.ToString(dr["prmAgentRegDNumber_Name"]),
                        LatestAgentRenewalRegDiaryNumber_Name = Convert.ToString(dr["prmLatestRenewalRegDNumber_Name"]),
                        RERAnumberRegistration = Convert.ToString(dr["prmRERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["prmRERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberRegUptoDate"]),
                        IsRenewalRegistration = Convert.ToInt32(dr["prmIsRenewalRegistration"]),
                        RenewalAgent_ID = Convert.ToInt64(dr["prmRenewalAgent_ID"]),
                        RenewalAgent_Year = Convert.ToInt32(dr["prmRenewalAgent_Year"]),
                        LatestRenewalRegistrationNumber = Convert.ToString(dr["prmLatestRenewalRegistrationNumber"]),
                        LatestRenewalRegistrationIssueDate = Convert.ToDateTime(dr["prmLatestRenewalRegistrationIssueDate"]),
                        LatestRenewalRegistrationUptoDate = Convert.ToDateTime(dr["prmLatestRenewalRegistrationUptoDate"]),
                        AgentName = Convert.ToString(dr["prmAgentName"]),
                        OrganizationName = Convert.ToString(dr["prmOrganizationName"]),
                        AuthorizedPersonName = Convert.ToString(dr["prmAuthorizedPersonName"]),
                        AgentRegisteredDistrict = Convert.ToString(dr["prmAgentRegisteredDistrict"]),
                        AgentBussinessPlaceDistrict = Convert.ToString(dr["prmAgentBussinessPlaceDistrict"]),
                    });
            }
            return CPregistrationList;
        }

        public Tuple<bool, string> Add_AgentRevocationCancellation_DiaryNumber(ClsPrp_ControlPanel_View_AgentRevocationCancellation smodel, string User_Name, Int64 sAgent_ID, Int64 sRenewalAgent_ID, Int32 sRenewalAgent_Year, string sAgentDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_agent_revoke_regdiarynumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_IndexID", (smodel.RevokeAgent_RegDiaryNumber_IndexID == 0) ? 0 : smodel.RevokeAgent_RegDiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_ID", (smodel.RevokeAgent_RegDiaryNumber_ID == 0) ? 0 : smodel.RevokeAgent_RegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_Name", String.IsNullOrEmpty(smodel.RevokeAgent_RegDiaryNumber_Name) ? string.Empty : smodel.RevokeAgent_RegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_NameYear", (smodel.RevokeAgent_RegDiaryNumber_NameYear == 0) ? 0 : smodel.RevokeAgent_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_UserID", sUID);
            cmd.Parameters.AddWithValue("p_Agent_ID", sAgent_ID);
            cmd.Parameters.AddWithValue("p_Agent_Type", (smodel.Agent_Type == 0) ? 0 : smodel.Agent_Type);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", sAgentDiaryNumber);
            cmd.Parameters.AddWithValue("p_LatestAgentRenewalRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.LatestAgentRenewalRegDiaryNumber_Name) ? string.Empty : smodel.LatestAgentRenewalRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_IsRenewalRegistration", (smodel.IsRenewalRegistration == 0) ? 0 : smodel.IsRenewalRegistration);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", sRenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", sRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationNumber", String.IsNullOrEmpty(smodel.LatestRenewalRegistrationNumber) ? string.Empty : smodel.LatestRenewalRegistrationNumber);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationIssueDate", (smodel.IsRenewalRegistration == 0) ? DateTime.MinValue : smodel.LatestRenewalRegistrationIssueDate);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationUptoDate", (smodel.IsRenewalRegistration == 0) ? DateTime.MinValue : smodel.LatestRenewalRegistrationUptoDate);
            cmd.Parameters.AddWithValue("p_AgentName", String.IsNullOrEmpty(smodel.AgentName) ? string.Empty : smodel.AgentName);
            cmd.Parameters.AddWithValue("p_OrganizationName", String.IsNullOrEmpty(smodel.OrganizationName) ? string.Empty : smodel.OrganizationName);
            cmd.Parameters.AddWithValue("p_AuthorizedPersonName", String.IsNullOrEmpty(smodel.AuthorizedPersonName) ? string.Empty : smodel.AuthorizedPersonName);
            cmd.Parameters.AddWithValue("p_AgentRegisteredDistrict", String.IsNullOrEmpty(smodel.AgentRegisteredDistrict) ? string.Empty : smodel.AgentRegisteredDistrict);
            cmd.Parameters.AddWithValue("p_AgentBussinessPlaceDistrict", String.IsNullOrEmpty(smodel.AgentBussinessPlaceDistrict) ? string.Empty : smodel.AgentBussinessPlaceDistrict);
            cmd.Parameters.AddWithValue("p_Revoke_InfoDetails", String.IsNullOrEmpty(smodel.Revoke_InfoDetails) ? string.Empty : smodel.Revoke_InfoDetails);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceName", String.IsNullOrEmpty(smodel.Revoke_ReferenceName) ? string.Empty : smodel.Revoke_ReferenceName);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceDate", smodel.Revoke_ReferenceDate.HasValue ? smodel.Revoke_ReferenceDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Revoke_Category", String.IsNullOrEmpty(smodel.Revoke_Category) ? string.Empty : smodel.Revoke_Category);
            cmd.Parameters.AddWithValue("p_Revoke_ReciptType", String.IsNullOrEmpty(smodel.Revoke_ReciptType) ? string.Empty : smodel.Revoke_ReciptType);
            cmd.Parameters.AddWithValue("p_Revoke_Reasons", String.IsNullOrEmpty(smodel.Revoke_Reasons) ? string.Empty : smodel.Revoke_Reasons);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", (smodel.IsDraftHelpDesk == 0) ? 0 : smodel.IsDraftHelpDesk);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", (smodel.IsDraftEvaluation == 0) ? 0 : smodel.IsDraftEvaluation);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();            
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);            
        }

        public Tuple<bool, string> Update_AgentRevocationCancellation_DiaryNumber(ClsPrp_ControlPanel_View_AgentRevocationCancellation smodel, string User_Name, Int64 sAgent_ID, Int64 sRenewalAgent_ID, Int32 sRenewalAgent_Year, string sAgentDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_agent_revokedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_IndexID", (smodel.RevokeAgent_RegDiaryNumber_IndexID == 0) ? 0 : smodel.RevokeAgent_RegDiaryNumber_IndexID);
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_ID", (smodel.RevokeAgent_RegDiaryNumber_ID == 0) ? 0 : smodel.RevokeAgent_RegDiaryNumber_ID);
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_Name", String.IsNullOrEmpty(smodel.RevokeAgent_RegDiaryNumber_Name) ? string.Empty : smodel.RevokeAgent_RegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RevokeAgent_RegDiaryNumber_NameYear", (smodel.RevokeAgent_RegDiaryNumber_NameYear == 0) ? 0 : smodel.RevokeAgent_RegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_UserID", sUID);
            cmd.Parameters.AddWithValue("p_Agent_ID", sAgent_ID);
            cmd.Parameters.AddWithValue("p_Agent_Type", (smodel.Agent_Type == 0) ? 0 : smodel.Agent_Type);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", sAgentDiaryNumber);
            cmd.Parameters.AddWithValue("p_LatestAgentRenewalRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.LatestAgentRenewalRegDiaryNumber_Name) ? string.Empty : smodel.LatestAgentRenewalRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_IsRenewalRegistration", (smodel.IsRenewalRegistration == 0) ? 0 : smodel.IsRenewalRegistration);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", sRenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", sRenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationNumber", String.IsNullOrEmpty(smodel.LatestRenewalRegistrationNumber) ? string.Empty : smodel.LatestRenewalRegistrationNumber);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationIssueDate", (smodel.IsRenewalRegistration == 0) ? DateTime.MinValue : smodel.LatestRenewalRegistrationIssueDate);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationUptoDate", (smodel.IsRenewalRegistration == 0) ? DateTime.MinValue : smodel.LatestRenewalRegistrationUptoDate);
            cmd.Parameters.AddWithValue("p_AgentName", String.IsNullOrEmpty(smodel.AgentName) ? string.Empty : smodel.AgentName);
            cmd.Parameters.AddWithValue("p_OrganizationName", String.IsNullOrEmpty(smodel.OrganizationName) ? string.Empty : smodel.OrganizationName);
            cmd.Parameters.AddWithValue("p_AuthorizedPersonName", String.IsNullOrEmpty(smodel.AuthorizedPersonName) ? string.Empty : smodel.AuthorizedPersonName);
            cmd.Parameters.AddWithValue("p_AgentRegisteredDistrict", String.IsNullOrEmpty(smodel.AgentRegisteredDistrict) ? string.Empty : smodel.AgentRegisteredDistrict);
            cmd.Parameters.AddWithValue("p_AgentBussinessPlaceDistrict", String.IsNullOrEmpty(smodel.AgentBussinessPlaceDistrict) ? string.Empty : smodel.AgentBussinessPlaceDistrict);
            cmd.Parameters.AddWithValue("p_Revoke_InfoDetails", String.IsNullOrEmpty(smodel.Revoke_InfoDetails) ? string.Empty : smodel.Revoke_InfoDetails);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceName", String.IsNullOrEmpty(smodel.Revoke_ReferenceName) ? string.Empty : smodel.Revoke_ReferenceName);
            cmd.Parameters.AddWithValue("p_Revoke_ReferenceDate", smodel.Revoke_ReferenceDate.HasValue ? smodel.Revoke_ReferenceDate : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_Revoke_Category", String.IsNullOrEmpty(smodel.Revoke_Category) ? string.Empty : smodel.Revoke_Category);
            cmd.Parameters.AddWithValue("p_Revoke_ReciptType", String.IsNullOrEmpty(smodel.Revoke_ReciptType) ? string.Empty : smodel.Revoke_ReciptType);
            cmd.Parameters.AddWithValue("p_Revoke_Reasons", String.IsNullOrEmpty(smodel.Revoke_Reasons) ? string.Empty : smodel.Revoke_Reasons);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? string.Empty : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", (smodel.IsDraftHelpDesk == 0) ? 0 : smodel.IsDraftHelpDesk);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", (smodel.IsDraftEvaluation == 0) ? 0 : smodel.IsDraftEvaluation);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();            
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }

        //Status of PCC
        public List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> Display_CP_ProjectCompletionStatusDetails_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectCompletionCertificateStatus_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails
                    {
                        ProjectCompletionEventAction_ID = Convert.ToInt64(dr["ProjectCompletionEventAction_ID"]),
                        EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                        EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                        AssignedTo = Convert.ToString(dr["AssignedTo"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                        Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                        IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
                        ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                        PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                        RERAnumberRegistration_Input = Convert.ToString(dr["RERAnumberRegistration_Input"]),
                    });
            }
            return CPstatusList;
        }
    }
}
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
    public class ClsMethod_View_CP_Email_Agent
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_Email_Agent> Display_CP_AgentRegisteredAgentDetailsForEmailAddress_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Email_Agent> CPregistrationList = new List<ClsPrp_ControlPanel_View_Email_Agent>();

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
                    new ClsPrp_ControlPanel_View_Email_Agent
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

        public List<ClsPrp_ControlPanel_View_Email_Agent> Display_CP_EmailsAll_ForRegisteredAgents_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Email_Agent> CPregistrationList = new List<ClsPrp_ControlPanel_View_Email_Agent>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_EmailsAgentAllDetails_ByID", con);
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
                    new ClsPrp_ControlPanel_View_Email_Agent
                    {
                        AdditionalAgentEmail_IndexID = Convert.ToInt64(dr["AdditionalAgentEmail_IndexID"]),
                        AdditionalAgentEmail_ID = Convert.ToInt64(dr["AdditionalAgentEmail_ID"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                        AgentRegDiaryNumber_Name = Convert.ToString(dr["AgentRegDiaryNumber_Name"]),
                        LatestAgentRenewalRegDiaryNumber_Name = Convert.ToString(dr["LatestAgentRenewalRegDiaryNumber_Name"]),
                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        IsRenewalRegistration = Convert.ToInt32(dr["IsRenewalRegistration"]),
                        RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                        RenewalAgent_Year = Convert.ToInt32(dr["RenewalAgent_Year"]),
                        LatestRenewalRegistrationNumber = Convert.ToString(dr["LatestRenewalRegistrationNumber"]),
                        LatestRenewalRegistrationIssueDate = Convert.ToDateTime(dr["LatestRenewalRegistrationIssueDate"]),
                        LatestRenewalRegistrationUptoDate = Convert.ToDateTime(dr["LatestRenewalRegistrationUptoDate"]),
                        AgentName = Convert.ToString(dr["AgentName"]),
                        OrganizationName = Convert.ToString(dr["OrganizationName"]),
                        AuthorizedPersonName = Convert.ToString(dr["AuthorizedPersonName"]),
                        AgentRegisteredDistrict = Convert.ToString(dr["AgentRegisteredDistrict"]),
                        AgentBussinessPlaceDistrict = Convert.ToString(dr["AgentBussinessPlaceDistrict"]),

                        AE_ContactName = Convert.ToString(dr["AE_ContactName"]),
                        AE_Designation = Convert.ToString(dr["AE_Designation"]),
                        AE_ReferenceName = Convert.ToString(dr["AE_ReferenceName"]),
                        AE_ReferenceDate = Convert.ToDateTime(dr["AE_ReferenceDate"]),
                        AE_EmailType = Convert.ToString(dr["AE_EmailType"]),
                        AE_EmailAddress = Convert.ToString(dr["AE_EmailAddress"]),

                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsApproval = Convert.ToInt32(dr["IsApproval"]),
                        IsVerified = Convert.ToInt32(dr["IsVerified"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return CPregistrationList;
        }

        public Int32 Update_LockUnlockHandler_CP_EmailsAll_ForRegisteredAgentsByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string RelatedRefYear, string RelatedCode, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_agentemailaddressByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRefID", RelatedRefID);
            cmd.Parameters.AddWithValue("p_InputCode", RelatedCode);
            cmd.Parameters.AddWithValue("p_InputLockUnlockValue", LockUnlockCode);
            cmd.Parameters.AddWithValue("p_ByUserName", ByUserName);
            cmd.Parameters.AddWithValue("p_ByUserID", ByUserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", RelatedRefYear);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

        public Tuple<bool, string> Add_AgentRegisteredAgent_EmailAddress(ClsPrp_ControlPanel_View_Email_Agent smodel, string User_Name, Int64 sAgent_ID, Int64 sRenewalAgent_ID, Int32 sRenewalAgent_Year, string sAgentDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_CP_tbl_rera_agent_additionalemailaddress_agent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionalAgentEmail_IndexID", (smodel.AdditionalAgentEmail_IndexID == 0) ? 0 : smodel.AdditionalAgentEmail_IndexID);
            cmd.Parameters.AddWithValue("p_AdditionalAgentEmail_ID", (smodel.AdditionalAgentEmail_ID == 0) ? 0 : smodel.AdditionalAgentEmail_ID);
            cmd.Parameters.AddWithValue("p_UserID", String.IsNullOrEmpty(smodel.UserID) ? string.Empty : smodel.UserID);
            cmd.Parameters.AddWithValue("p_Agent_ID", (smodel.Agent_ID == 0) ? 0 : smodel.Agent_ID);
            cmd.Parameters.AddWithValue("p_Agent_Type", (smodel.Agent_Type == 0) ? 0 : smodel.Agent_Type);
            cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.AgentRegDiaryNumber_Name) ? string.Empty : smodel.AgentRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_LatestAgentRenewalRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.LatestAgentRenewalRegDiaryNumber_Name) ? string.Empty : smodel.LatestAgentRenewalRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate.HasValue ? smodel.RERAnumberIssueDate.Value : dtvalue);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate.HasValue ? smodel.RERAnumberRegUptoDate.Value : dtvalue);
            cmd.Parameters.AddWithValue("p_IsRenewalRegistration", (smodel.IsRenewalRegistration == 0) ? 0 : smodel.IsRenewalRegistration);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", (smodel.RenewalAgent_ID == 0) ? 0 : smodel.RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", (smodel.RenewalAgent_Year == 0) ? 0 : smodel.RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationNumber", String.IsNullOrEmpty(smodel.LatestRenewalRegistrationNumber) ? string.Empty : smodel.LatestRenewalRegistrationNumber);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationIssueDate", smodel.LatestRenewalRegistrationIssueDate.HasValue ? smodel.LatestRenewalRegistrationIssueDate.Value : dtvalue);
            cmd.Parameters.AddWithValue("p_LatestRenewalRegistrationUptoDate", smodel.LatestRenewalRegistrationUptoDate.HasValue ? smodel.LatestRenewalRegistrationUptoDate.Value : dtvalue);
            cmd.Parameters.AddWithValue("p_AgentName", String.IsNullOrEmpty(smodel.AgentName) ? string.Empty : smodel.AgentName);
            cmd.Parameters.AddWithValue("p_OrganizationName", String.IsNullOrEmpty(smodel.OrganizationName) ? string.Empty : smodel.OrganizationName);
            cmd.Parameters.AddWithValue("p_AuthorizedPersonName", String.IsNullOrEmpty(smodel.AuthorizedPersonName) ? string.Empty : smodel.AuthorizedPersonName);
            cmd.Parameters.AddWithValue("p_AgentRegisteredDistrict", String.IsNullOrEmpty(smodel.AgentRegisteredDistrict) ? string.Empty : smodel.AgentRegisteredDistrict);
            cmd.Parameters.AddWithValue("p_AgentBussinessPlaceDistrict", String.IsNullOrEmpty(smodel.AgentBussinessPlaceDistrict) ? string.Empty : smodel.AgentBussinessPlaceDistrict);

            cmd.Parameters.AddWithValue("p_AE_ContactName", String.IsNullOrEmpty(smodel.AE_ContactName) ? string.Empty : smodel.AE_ContactName);
            cmd.Parameters.AddWithValue("p_AE_Designation", String.IsNullOrEmpty(smodel.AE_Designation) ? string.Empty : smodel.AE_Designation);
            cmd.Parameters.AddWithValue("p_AE_ReferenceName", String.IsNullOrEmpty(smodel.AE_ReferenceName) ? string.Empty : smodel.AE_ReferenceName);
            cmd.Parameters.AddWithValue("p_AE_ReferenceDate", smodel.AE_ReferenceDate.HasValue ? smodel.AE_ReferenceDate.Value : dtvalue);
            cmd.Parameters.AddWithValue("p_AE_EmailType", String.IsNullOrEmpty(smodel.AE_EmailType) ? string.Empty : smodel.AE_EmailType);
            cmd.Parameters.AddWithValue("p_AE_EmailAddress", String.IsNullOrEmpty(smodel.AE_EmailAddress) ? string.Empty : smodel.AE_EmailAddress);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", 0);
            cmd.Parameters.AddWithValue("p_IsVerified", (smodel.IsVerified == 0) ? 0 : smodel.IsVerified);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

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
                
    }
}
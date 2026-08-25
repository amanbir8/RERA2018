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

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_RevocationCancellationAgentHelpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Display Agent Revoke
        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeNewApplication", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsNewReSubmittedApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeNewReSubmitted", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsReviewCL(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeReviewCL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsApprovedRevoke(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeApprovedRevoke", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsApprovedSuspension(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeApprovedSuspended", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsApprovedWithdrawn(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeApprovedWithdrawn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        #region BY DATE

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsApprovedRevokeByDate(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeApprovedRevokeByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsApprovedSuspensionByDate(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeApprovedSuspendedByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsApprovedWithdrawnByDate(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeApprovedWithdrawnByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        #endregion


        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsRejected(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeRejected", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsWithdrawn(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokeWithdrawn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewIssueRevoke(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewIssueRevCancel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewRevoke(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewRevCancel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewSuspended(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewRevSuspended", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewWithdrawn(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewRevWithdrawn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ListRevoke;
        }


        #region BY DATE

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewRevokeByDate(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewRevCancelByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewSuspendedByDate(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewRevSuspendedByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ListRevoke;
        }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> Display_AuthorityDesk_AgentRevokeDetailsPublicViewWithdrawnByDate(int currectYear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> ListRevoke = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Agent_RevokePublicViewRevWithdrawnByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_currectYear", currectYear);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListRevoke.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
                       {
                           RevokeAgent_RegDiaryNumber_IndexID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_IndexID"]),
                           RevokeAgent_RegDiaryNumber_ID = Convert.ToInt64(dr["RevokeAgent_RegDiaryNumber_ID"]),
                           RevokeAgent_RegDiaryNumber_Name = Convert.ToString(dr["RevokeAgent_RegDiaryNumber_Name"]),
                           RevokeAgent_RegDiaryNumber_NameYear = Convert.ToInt32(dr["RevokeAgent_RegDiaryNumber_NameYear"]),
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
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           AgentApplicationDate = Convert.ToDateTime(dr["AgentApplicationDate"]),
                           AgentRevokeApplicationDate = Convert.ToDateTime(dr["AgentRevokeApplicationDate"]),

                           getAgentName = Convert.ToString(dr["Agent_Name"]),
                           Agent_Name = Convert.ToString(dr["Agent_Name"]),
                           Agent_BussinessPlaceAddressDistrictName = Convert.ToString(dr["Agent_BussinessPlaceAddressDistrictName"]),

                           Agent_RERAregistrationNumber = Convert.ToString(dr["Agent_RERAregistrationNumber"]),
                           Agent_RERAregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERAregistrationIssueDate"]),
                           Agent_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERAregistrationValidUptoDate"]),
                           Agent_RERArenewalregistrationIssueDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationIssueDate"]),
                           Agent_RERArenewalregistrationValidUptoDate = Convert.ToDateTime(dr["Agent_RERArenewalregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           AgentRERAcert_FilePath = Convert.ToString(dr["AgentRERAcert_FilePath"]),
                           AgentRERAcert_FileName = Convert.ToString(dr["AgentRERAcert_FileName"]),
                           AgentRERAcert_ReferenceNumber = Convert.ToString(dr["AgentRERAcert_ReferenceNumber"]),
                           AgentRERAcert_IssueDate = Convert.ToDateTime(dr["AgentRERAcert_IssueDate"]),
                       });
            }
            return ListRevoke;
        }

        #endregion

        // Event Agent Revoke  
        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog> Display_AuthorityDesk_AgentRevokeEventLogDetails(Int64 Agent_ID, Int64 RenewalAgent_ID, string AgentDiaryNumber, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog> AgentList = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RevokeAgentEventLogDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_AgentDiaryNumber", AgentDiaryNumber);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog
                       {
                           AgentRevokeEventAction_ID = Convert.ToInt64(dr["AgentRevokeEventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                           Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                           Related_RenewalAgent_Year = Convert.ToInt32(dr["Related_RenewalAgent_Year"]),
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           LatestRenewalAgent_DiaryNumber = Convert.ToString(dr["LatestRenewalAgent_DiaryNumber"]),
                           Revoke_DiaryNumber = Convert.ToString(dr["Revoke_DiaryNumber"]),
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
                       });
            }
            return AgentList;
        }

        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> Display_AuthorityDesk_AgentRevokeEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEvent_Master> AgentList = new List<ClsPrp_AuthorityDesk_AgentEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_RevokeAgentEvent_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_AuthorityDesk_AgentEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AgentList;
        }

        public List<ClsPrp_AuthorityDesk_AgentEvent_Master> Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_AgentEvent_Master> AgentList = new List<ClsPrp_AuthorityDesk_AgentEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentEventDescriptionDetailsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Event_ID", Event_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentList.Add(
                       new ClsPrp_AuthorityDesk_AgentEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AgentList;
        }

        public bool Add_AgentRevocationCancellation_InfoEvent(ClsPrp_AuthorityDesk_RevocationCancellationAgentEventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Agent_Revoke_EventAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            //cmd.Parameters.AddWithValue("p_AgentRevokeEventAction_ID", smodel.AgentRevokeEventAction_ID);
            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_Agent_ID", smodel.Related_Agent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", smodel.Related_RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", smodel.Related_RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_Agent_DiaryNumber", String.IsNullOrEmpty(smodel.Agent_DiaryNumber) ? "" : smodel.Agent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_LatestRenewalAgent_DiaryNumber", String.IsNullOrEmpty(smodel.LatestRenewalAgent_DiaryNumber) ? "" : smodel.LatestRenewalAgent_DiaryNumber);
            cmd.Parameters.AddWithValue("p_Revoke_DiaryNumber", String.IsNullOrEmpty(smodel.Revoke_DiaryNumber) ? "" : smodel.Revoke_DiaryNumber);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationNumber", String.IsNullOrEmpty(smodel.AgentRegistrationNumberName) ? "" : smodel.AgentRegistrationNumberName);
            cmd.Parameters.AddWithValue("p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_EventAction_Relationship", UserRole);
            cmd.Parameters.AddWithValue("p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_IsBefore_TargetResolution", 0);
            cmd.Parameters.AddWithValue("p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            //return AppId;

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
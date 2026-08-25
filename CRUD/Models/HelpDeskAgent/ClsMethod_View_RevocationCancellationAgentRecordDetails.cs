using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.HelpdeskControlPanel;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_RevocationCancellationAgentRecordDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_AgentRevocationCancellation> Display_Agent_RevocationCancellationRecordDetails_ByID(Int64 pRelatedAgentID, Int64 pRelatedRenewalAgentID, string pRegistrationNumber, string pRevADNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_AgentRevocationCancellation> AgentList = new List<ClsPrp_ControlPanel_View_AgentRevocationCancellation>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_RevocationCancellationRecords_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedAgentID", pRelatedAgentID);
            cmd.Parameters.AddWithValue("p_RelatedRenewalAgentID", pRelatedRenewalAgentID);
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_RevokeAgentDiaryNumber", pRevADNumber);
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
                       new ClsPrp_ControlPanel_View_AgentRevocationCancellation
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
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                       });
            }
            return AgentList;
        }

    }
}
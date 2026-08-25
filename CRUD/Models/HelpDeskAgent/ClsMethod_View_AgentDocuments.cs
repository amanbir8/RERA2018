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
    public class ClsMethod_View_AgentDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthDesk_View_AgentDocuments> Display_AuthDesk_AgentDocuments_ByAgentId(Int64 AgentId)
        {
            connection();
            List<ClsPrp_AuthDesk_View_AgentDocuments> Agent_Documents_AgentId = new List<ClsPrp_AuthDesk_View_AgentDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Documents_AgentId_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agent_Documents_AgentId.Add(
                    new ClsPrp_AuthDesk_View_AgentDocuments
                    {
                        AgentDoc_IndexID = Convert.ToInt64(dr["AgentDoc_IndexID"]),
                        AgentDoc_ID = Convert.ToInt64(dr["AgentDoc_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        AgentDoc_InfoCode = Convert.ToInt32(dr["AgentDoc_InfoCode"]),
                        AgentDoc_InfoName = Convert.ToString(dr["AgentDoc_InfoName"]),
                        AgentDoc_ReferenceNumber = Convert.ToString(dr["AgentDoc_ReferenceNumber"]),
                        AgentDoc_IssueDate = Convert.ToDateTime(dr["AgentDoc_IssueDate"]),
                        AgentDoc_FileSize = Convert.ToString(dr["AgentDoc_FileSize"]),
                        AgentDoc_FileFormat = Convert.ToString(dr["AgentDoc_FileFormat"]),
                        AgentDoc_FilePath = Convert.ToString(dr["AgentDoc_FilePath"]),
                        AgentDoc_FileName = Convert.ToString(dr["AgentDoc_FileName"]),
                        AgentDoc_IsGroup = Convert.ToInt32(dr["AgentDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return Agent_Documents_AgentId;
        }

        public Int32 Update_LockUnLockHandler_Agent_DocumentsByList(Int64 AgentId, Int32 AgentTypeId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_agent_documentlistdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);            
            cmd.Parameters.AddWithValue("p_ReferenceAgentIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
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

        public Int32 Update_LockUnLockHandler_Agent_DocumentDetailsByIndex(Int64 AgentId, Int32 AgentTypeId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg, Int64 DocByIndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_agent_documentdetailsbyindex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);            
            cmd.Parameters.AddWithValue("p_ReferenceAgentIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_AgentDocByIndexID", DocByIndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
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

    }
}
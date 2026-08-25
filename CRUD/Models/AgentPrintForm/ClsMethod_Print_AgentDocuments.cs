using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsMethod_Print_AgentDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_Print_AgentDocuments> Display_Print_AgentDocuments_ByAgentId(Int64 AgentId)
        {
            connection();
            List<ClsPrp_Print_AgentDocuments> Agent_Documents_AgentId = new List<ClsPrp_Print_AgentDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Documents_AgentId_ForPrint", con);
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
                    new ClsPrp_Print_AgentDocuments
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

        public List<ClsPrp_Print_RenewalAgent_Documents> Display_Print_RenewalAgent_Documents_ById(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_Print_RenewalAgent_Documents> Agent_Documents_AgentId = new List<ClsPrp_Print_RenewalAgent_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_PrintAgentRenewal_Documents_ById_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_TypeOfAgent_ID", TypeOfAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_ID", RenewalAgent_ID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_SequenceID", RenewalAgent_SequenceID);
            cmd.Parameters.AddWithValue("p_RenewalAgent_Year", RenewalAgent_Year);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Agent_Documents_AgentId.Add(
                    new ClsPrp_Print_RenewalAgent_Documents
                    {
                        RenewalAgent_AgentDoc_IndexID = Convert.ToInt64(dr["RenewalAgentDoc_IndexID"]),
                        RenewalAgent_AgentDoc_ID = Convert.ToInt64(dr["RenewalAgentDoc_ID"]),

                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_AgentDoc_ID = Convert.ToInt64(dr["Related_RenewalAgentDoc_ID"]),

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
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsConditional = Convert.ToInt32(dr["IsConditional"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return Agent_Documents_AgentId;
        }
    }
}
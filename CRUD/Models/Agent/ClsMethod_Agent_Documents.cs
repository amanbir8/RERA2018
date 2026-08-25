using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.AgentDocument
{
    public class ClsMethod_Agent_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        /// <summary>
        /// Display Agent Documents By AgentID and AgentDocID
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Agent_Documents> Display_Agent_Documents_ByAgentDocID(Int64 AgentId, Int64 AgentDocID)
        {
            connection();
            List<Clsprp_Agent_Documents> AgentDocuments = new List<Clsprp_Agent_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Documents_ByAgentDocID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
            cmd.Parameters.AddWithValue("p_Agent_DocID", AgentDocID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentDocuments.Add(
                    new Clsprp_Agent_Documents
                    {
                        AgentDoc_IndexID = Convert.ToInt64(dr["AgentDoc_IndexID"]),
                        AgentDoc_ID = Convert.ToInt64(dr["AgentDoc_ID"]),
                        Agent_ID = Convert.ToInt64(dr["AgentDoc_ID"]),
                        AgentDoc_InfoCode = Convert.ToInt32(dr["AgentDoc_ID"]),
                        AgentDoc_InfoName = Convert.ToString(dr["AgentDoc_ID"]),
                        AgentDoc_ReferenceNumber = Convert.ToString(dr["AgentDoc_ID"]),
                        AgentDoc_IssueDate = Convert.ToDateTime(dr["AgentDoc_ID"]),
                        AgentDoc_FileSize = Convert.ToString(dr["AgentDoc_ID"]),
                        AgentDoc_FileFormat = Convert.ToString(dr["AgentDoc_ID"]),
                        AgentDoc_FilePath = Convert.ToString(dr["AgentDoc_ID"]),
                        AgentDoc_FileName = Convert.ToString(dr["AgentDoc_ID"]),
                        AgentDoc_IsGroup = Convert.ToInt32(dr["AgentDoc_ID"]),
                        Remarks_IfAny = Convert.ToString(dr["AgentDoc_ID"]),
                        A_column = Convert.ToString(dr["AgentDoc_ID"]),
                        B_column = Convert.ToString(dr["AgentDoc_ID"]),
                        C_column = Convert.ToString(dr["AgentDoc_ID"]),
                        IsActive = Convert.ToInt32(dr["AgentDoc_ID"]),
                        IsDraft = Convert.ToInt32(dr["AgentDoc_ID"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return AgentDocuments;
        }

        /// <summary>
        /// Save Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Add_Agent_Documents(Clsprp_Agent_Documents smodel, Int64 oAgent_ID, String oAgentDoc_FilePath, String oAgentDoc_FileName, String oAgentDoc_FileSize, String oAgentDoc_FileFormat, Int32 oAgentDoc_IsGroup)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Agent_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;                  

            cmd.Parameters.AddWithValue("p_AgentDoc_ID", (smodel.AgentDoc_ID == 0) ? 0 : smodel.AgentDoc_ID);          
            cmd.Parameters.AddWithValue("p_Agent_ID", oAgent_ID);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", smodel.AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoName", String.IsNullOrEmpty(smodel.AgentDoc_InfoName) ? "" : smodel.AgentDoc_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_ReferenceNumber", smodel.AgentDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentDoc_IssueDate",  smodel.AgentDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileSize", oAgentDoc_FileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileFormat",  oAgentDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_FilePath", oAgentDoc_FilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileName", oAgentDoc_FileName);
            cmd.Parameters.AddWithValue("p_AgentDoc_IsGroup", oAgentDoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column); 
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column); 
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column); 
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");          
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Update_Agent_Documents(Clsprp_Agent_Documents smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Agent_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentDoc_IndexID", smodel.AgentDoc_IndexID);
            cmd.Parameters.AddWithValue("p_AgentDoc_ID", smodel.AgentDoc_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", smodel.Agent_ID);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", smodel.AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoName", String.IsNullOrEmpty(smodel.AgentDoc_InfoName) ? "" : smodel.AgentDoc_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_ReferenceNumber", smodel.AgentDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_AgentDoc_IssueDate", smodel.AgentDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileSize", smodel.AgentDoc_FileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileFormat", smodel.AgentDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_FilePath", smodel.AgentDoc_FilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_FileName", smodel.AgentDoc_FileName);
            cmd.Parameters.AddWithValue("p_AgentDoc_IsGroup", smodel.AgentDoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Display Agent Documents By AgentID
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Agent_Documents> Display_Agent_Documents_AgentId(Int64 AgentId)
        {
            connection();
            List<Clsprp_Agent_Documents> Agent_Documents_AgentId = new List<Clsprp_Agent_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Documents_AgentId", con);
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
                    new Clsprp_Agent_Documents
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

        /// <summary>
        /// Validation Method - Count and Sum Size
        /// </summary>
        /// <param name="Agent_ID"></param>
        /// <param name="AgentDoc_InfoCode"></param>
        /// <returns></returns>
        public Tuple<Int64, Int64> Display_Agent_Documents_ByDocCodeInfoAgentID(Int64 Agent_ID, Int64 AgentDoc_InfoCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_Documents_ByDocCodeInfoAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentDoc_InfoCode", AgentDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"] );
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }

        /// <summary>
        /// Delete Agent Documents By Agent ID And IndexID
        /// </summary>
        /// <param name="oAgentDoc_IndexID"></param>
        /// <param name="oAgentDoc_ID"></param>
        /// <param name="oAgent_ID"></param>
        /// <returns></returns>
        public bool Delete_Agent_Documents(Int64? oAgentDoc_IndexID, Int64? oAgentDoc_ID, Int64? oAgent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Agent_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentDoc_IndexID", oAgentDoc_IndexID);
            cmd.Parameters.AddWithValue("p_AgentDoc_ID", oAgentDoc_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", oAgent_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
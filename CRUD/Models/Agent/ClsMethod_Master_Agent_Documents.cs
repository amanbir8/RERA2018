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
    public class ClsMethod_Master_Agent_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        /// <summary>
        /// Display only for Master ApplicationFee
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Master_Agent_Documents> Display_Master_Agent_Documents()
        {
            connection();
            List<Clsprp_Master_Agent_Documents> MasterAgentDocuments = new List<Clsprp_Master_Agent_Documents>();

            MySqlCommand cmd = new MySqlCommand("Select * from tbl_RERA_Master_Agent_Documents where AgentDoc_ValidCode=2", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterAgentDocuments.Add(
                    new Clsprp_Master_Agent_Documents
                    {

                        AgentDocMaster_IndexID = Convert.ToInt32(dr["AgentDocMaster_IndexID"]),
                        AgentDocMaster_InfoCode = Convert.ToInt32(dr["AgentDocMaster_InfoCode"]),
                        AgentDocMaster_InfoName = Convert.ToString(dr["AgentDocMaster_InfoName"]),
                        AgentDoc_SetFileSize = Convert.ToString(dr["AgentDoc_SetFileSize"]),
                        AgentDoc_SetFileFormat = Convert.ToString(dr["AgentDoc_SetFileFormat"]),
                        AgentDoc_SetFilePath = Convert.ToString(dr["AgentDoc_SetFilePath"]),
                        AgentDoc_ValidCode = Convert.ToInt32(dr["AgentDoc_ValidCode"]),
                        AgentDoc_ValidSubCode = Convert.ToInt32(dr["AgentDoc_ValidSubCode"]),
                        AgentDoc_ValidTinySubCode = Convert.ToInt32(dr["AgentDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterAgentDocuments;
        }


        public List<Clsprp_Master_Agent_Documents> Display_Master_Agent_Documents(Int32 ID)
        {
            connection();
            List<Clsprp_Master_Agent_Documents> MasterAgentDocuments = new List<Clsprp_Master_Agent_Documents>();
            
            //MySqlCommand cmd = new MySqlCommand("Select * from tbl_RERA_Master_Agent_Documents where AgentDocMaster_InfoCode=" + ID+" and IsActive=1", con);
            
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentDocMaster_ByAgentDocMaster_InfoCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentDocMaster_InfoCode", ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterAgentDocuments.Add(
                    new Clsprp_Master_Agent_Documents
                    {

                        AgentDocMaster_IndexID = Convert.ToInt32(dr["AgentDocMaster_IndexID"]),
                        AgentDocMaster_InfoCode = Convert.ToInt32(dr["AgentDocMaster_InfoCode"]),
                        AgentDocMaster_InfoName = Convert.ToString(dr["AgentDocMaster_InfoName"]),
                        AgentDoc_SetFileSize = Convert.ToString(dr["AgentDoc_SetFileSize"]),
                        AgentDoc_SetFileFormat = Convert.ToString(dr["AgentDoc_SetFileFormat"]),
                        AgentDoc_SetFilePath = Convert.ToString(dr["AgentDoc_SetFilePath"]),
                        AgentDoc_ValidCode = Convert.ToInt32(dr["AgentDoc_ValidCode"]),
                        AgentDoc_ValidSubCode = Convert.ToInt32(dr["AgentDoc_ValidSubCode"]),
                        AgentDoc_ValidTinySubCode = Convert.ToInt32(dr["AgentDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterAgentDocuments;
        }

        /// <summary>
        /// Display only for Master ApplicationFee
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Master_Agent_Documents> Display_Master_Agent_DocumentsByAgentID(Int64 Agent_ID)
        {
            connection();
            List<Clsprp_Master_Agent_Documents> MasterAgentDocuments = new List<Clsprp_Master_Agent_Documents>();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentDocMaster_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterAgentDocuments.Add(
                    new Clsprp_Master_Agent_Documents
                    {

                        AgentDocMaster_IndexID = Convert.ToInt32(dr["AgentDocMaster_IndexID"]),
                        AgentDocMaster_InfoCode = Convert.ToInt32(dr["AgentDocMaster_InfoCode"]),
                        AgentDocMaster_InfoName = Convert.ToString(dr["AgentDocMaster_InfoName"]),
                        AgentDoc_SetFileSize = Convert.ToString(dr["AgentDoc_SetFileSize"]),
                        AgentDoc_SetFileFormat = Convert.ToString(dr["AgentDoc_SetFileFormat"]),
                        AgentDoc_SetFilePath = Convert.ToString(dr["AgentDoc_SetFilePath"]),
                        AgentDoc_ValidCode = Convert.ToInt32(dr["AgentDoc_ValidCode"]),
                        AgentDoc_ValidSubCode = Convert.ToInt32(dr["AgentDoc_ValidSubCode"]),
                        AgentDoc_ValidTinySubCode = Convert.ToInt32(dr["AgentDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterAgentDocuments;
        }

        public List<Clsprp_Master_Agent_Documents> Display_Master_Agent_DocumentsDetailsByAgentID(Int64 Agent_ID)
        {
            connection();
            List<Clsprp_Master_Agent_Documents> MasterAgentDocuments = new List<Clsprp_Master_Agent_Documents>();            
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentDocMaster_ByDetailsID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterAgentDocuments.Add(
                    new Clsprp_Master_Agent_Documents
                    {
                        AgentDocMaster_IndexID = Convert.ToInt32(dr["AgentDocMaster_IndexID"]),
                        AgentDocMaster_InfoCode = Convert.ToInt32(dr["AgentDocMaster_InfoCode"]),
                        AgentDocMaster_InfoName = Convert.ToString(dr["AgentDocMaster_InfoName"]),
                        AgentDoc_SetFileSize = Convert.ToString(dr["AgentDoc_SetFileSize"]),
                        AgentDoc_SetFileFormat = Convert.ToString(dr["AgentDoc_SetFileFormat"]),
                        AgentDoc_SetFilePath = Convert.ToString(dr["AgentDoc_SetFilePath"]),
                        AgentDoc_ValidCode = Convert.ToInt32(dr["AgentDoc_ValidCode"]),
                        AgentDoc_ValidSubCode = Convert.ToInt32(dr["AgentDoc_ValidSubCode"]),
                        AgentDoc_ValidTinySubCode = Convert.ToInt32(dr["AgentDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterAgentDocuments;
        }

        /// <summary>
        /// Save Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Add_Master_Agent_Documents(Clsprp_Master_Agent_Documents smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Master_Agent_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("p_AgentDocMaster_InfoCode", smodel.AgentDocMaster_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDocMaster_InfoName", smodel.AgentDocMaster_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_SetFileSize", smodel.AgentDoc_SetFileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_SetFileFormat", String.IsNullOrEmpty(smodel.AgentDoc_SetFileFormat) ? "" : smodel.AgentDoc_SetFileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_SetFilePath", smodel.AgentDoc_SetFilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_ValidCode", smodel.AgentDoc_ValidCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_ValidSubCode", smodel.AgentDoc_ValidSubCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_ValidTinySubCode", smodel.AgentDoc_ValidTinySubCode);
            cmd.Parameters.AddWithValue("p_IsGroup", smodel.IsGroup);
            cmd.Parameters.AddWithValue("p_IsMandatory", smodel.IsMandatory);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");
           
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
        /// Update Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Update_Master_Agent_Documents(Clsprp_Master_Agent_Documents smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Master_Agent_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentDocMaster_IndexID", smodel.AgentDocMaster_IndexID);
            cmd.Parameters.AddWithValue("p_AgentDocMaster_InfoCode", smodel.AgentDocMaster_InfoCode);
            cmd.Parameters.AddWithValue("p_AgentDocMaster_InfoName", smodel.AgentDocMaster_InfoName);
            cmd.Parameters.AddWithValue("p_AgentDoc_SetFileSize", smodel.AgentDoc_SetFileSize);
            cmd.Parameters.AddWithValue("p_AgentDoc_SetFileFormat", String.IsNullOrEmpty(smodel.AgentDoc_SetFileFormat) ? "" : smodel.AgentDoc_SetFileFormat);
            cmd.Parameters.AddWithValue("p_AgentDoc_SetFilePath", smodel.AgentDoc_SetFilePath);
            cmd.Parameters.AddWithValue("p_AgentDoc_ValidCode", smodel.AgentDoc_ValidCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_ValidSubCode", smodel.AgentDoc_ValidSubCode);
            cmd.Parameters.AddWithValue("p_AgentDoc_ValidTinySubCode", smodel.AgentDoc_ValidTinySubCode);
            cmd.Parameters.AddWithValue("p_IsGroup", smodel.IsGroup);
            cmd.Parameters.AddWithValue("p_IsMandatory", smodel.IsMandatory);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");

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
        
    }
}
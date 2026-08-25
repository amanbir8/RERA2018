using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.Agent
{
    public class ClsMethodAgentOtherStateUT
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        // Add other State Agent Detail
        public bool AddOtherStateUTAgentDetail(ClsprpRERA_Agent_OtherStateUT_regRERAdetails smodel,Int64 Application_id, string FileName, string FilePath)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_RERA_Agent_OtherStateUT_regRERAdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("p_Agent_OtherStateUT_regRERA_ID", smodel.Agent_OtherStateUT_regRERA_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Application_id);
            cmd.Parameters.AddWithValue("p_StateCode", smodel.StateCode);
            cmd.Parameters.AddWithValue("p_RERAregistration_Number", String.IsNullOrEmpty(smodel.RERAregistration_Number) ? "" : smodel.RERAregistration_Number); //smodel.RERAregistration_Number);
            cmd.Parameters.AddWithValue("p_RERAregistration_IssueDate", smodel.RERAregistration_IssueDate);
            cmd.Parameters.AddWithValue("p_RERAregistration_ExpiryDate", smodel.RERAregistration_ExpiryDate);
            cmd.Parameters.AddWithValue("p_ImageRERAcert_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_ImageRERAcert_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", "");// smodel.Remarks_IfAny);
            // cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "CreatedBy");//smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_ModifyBy", "ModifyBy");// smodel.ModifyBy);
            // cmd.Parameters.AddWithValue("p_Get_AgentID )", smodel.Get_AgentID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool UpdateOtherStateUTAgentDetail(ClsprpRERA_Agent_OtherStateUT_regRERAdetails smodel, Int64 Application_id, string FileName, string FilePath)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_RERA_Agent_OtherStateUT_regRERAdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Agent_OtherStateUT_regRERA_ID", smodel.Agent_OtherStateUT_regRERA_ID);
            cmd.Parameters.AddWithValue("p_Agent_ID", Application_id);
            cmd.Parameters.AddWithValue("p_StateCode", smodel.StateCode);
            cmd.Parameters.AddWithValue("p_RERAregistration_Number", smodel.RERAregistration_Number);
            cmd.Parameters.AddWithValue("p_RERAregistration_IssueDate", smodel.RERAregistration_IssueDate);
            cmd.Parameters.AddWithValue("p_RERAregistration_ExpiryDate", smodel.RERAregistration_ExpiryDate);
            cmd.Parameters.AddWithValue("p_ImageRERAcert_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);
            cmd.Parameters.AddWithValue("p_ImageRERAcert_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath); 
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", "");// smodel.Remarks_IfAny);
            //cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "CreatedBy");//smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_ModifyBy", "ModifyBy");// smodel.ModifyBy);

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            Int64 AppId = Convert.ToInt64(AppPar.Value);

            if (i >= 1)
                return true;
            else
                return false;
        }

        //Display other state Agent Detail
        public List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> DisplayOtherStateUTAgentDetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_OtherStateUTAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            //connection();
            List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> list_indPro = new List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpRERA_Agent_OtherStateUT_regRERAdetails
                    {
                        Agent_OtherStateUT_regRERA_IndexID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_IndexID"]),
                        Agent_OtherStateUT_regRERA_ID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        StateCode = Convert.ToInt32(dr["StateCode"]),
                        RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                        RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                        RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                        ImageRERAcert_FileName = Convert.ToString(dr["ImageRERAcert_FileName"]),
                        ImageRERAcert_FilePath = Convert.ToString(dr["ImageRERAcert_FilePath"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;           
        }

        //, 
        public List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> DisplayAgentOtherStateUTDetailByOthermemberID(Int64 Agent_OtherStateUT_regRERA_IndexID, Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_OtherStateUTAgentIDUTID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_Agent_OtherStateUT_regRERA_ID", Agent_OtherStateUT_regRERA_IndexID);

            //connection();
            List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> list_indPro = new List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails>();

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsprpRERA_Agent_OtherStateUT_regRERAdetails
                    {
                        Agent_OtherStateUT_regRERA_ID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        StateCode = Convert.ToInt32(dr["StateCode"]),
                        RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                        RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                        RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                        ImageRERAcert_FileName = Convert.ToString(dr["ImageRERAcert_FileName"]),
                        ImageRERAcert_FilePath = Convert.ToString(dr["ImageRERAcert_FilePath"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),

                    });
            }
            return list_indPro;

            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }

        public bool Delete_AgentOthermemberDetail(Int64 Agent_ID, Int64 Agent_OtherStateUT_regRERA_IndexID)
        {            
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Agent_OtherStateUT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);
            cmd.Parameters.AddWithValue("p_Agent_OtherStateUT_regRERA_ID", Agent_OtherStateUT_regRERA_IndexID);

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
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsMethod_Print_AgentOtherStateUT_RERA
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_Print_AgentOtherStateUT_RERA> Display_AgentOtherStateUT_RERADetail(Int64 Agent_ID)
        {
            connection();
            List<ClsPrp_Print_AgentOtherStateUT_RERA> list_indPro = new List<ClsPrp_Print_AgentOtherStateUT_RERA>();

            MySqlCommand cmd = new MySqlCommand("Display_OtherStateUTAgentID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsPrp_Print_AgentOtherStateUT_RERA
                    {
                        Agent_OtherStateUT_regRERA_IndexID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_IndexID"]),
                        Agent_OtherStateUT_regRERA_ID = Convert.ToInt64(dr["Agent_OtherStateUT_regRERA_ID"]),
                        Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                        StateCode = Convert.ToString(dr["StateCode"]),
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

        public List<ClsPrp_Print_RenewalAgent_OtherStateUT_RERA> Display_RenewalAgent_OtherStateUT_RERADetail(Int64 Agent_ID, Int32 TypeOfAgent_ID, Int64 RenewalAgent_ID, Int32 RenewalAgent_SequenceID, Int32 RenewalAgent_Year, string UserID_Role)
        {
            connection();
            List<ClsPrp_Print_RenewalAgent_OtherStateUT_RERA> list_indPro = new List<ClsPrp_Print_RenewalAgent_OtherStateUT_RERA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_PrintAgentRenewal_OtherStateUT_RERA", con);
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
                list_indPro.Add(
                    new ClsPrp_Print_RenewalAgent_OtherStateUT_RERA
                    {
                        RenewalAgent_OtherStateUT_RERA_IndexID = Convert.ToInt64(dr["RenewalAgent_OtherStateUT_regRERA_IndexID"]),
                        RenewalAgent_OtherStateUT_RERA_ID = Convert.ToInt64(dr["RenewalAgent_OtherStateUT_regRERA_ID"]),

                        Related_RenewalAgent_ID = Convert.ToInt64(dr["Related_RenewalAgent_ID"]),
                        Related_RenewalOrderSequence = Convert.ToInt32(dr["Related_RenewalOrderSequence"]),
                        Related_RelatedRenewalAgent_Year = Convert.ToInt32(dr["Related_RelatedRenewalAgent_Year"]),
                        Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                        Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                        Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                        Related_UserID = Convert.ToString(dr["Related_UserID"]),
                        Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                        Related_Agent_OtherStateUT_RERA_ID = Convert.ToInt64(dr["Related_Agent_OtherStateUT_regRERA_ID"]),

                        StateCode = Convert.ToString(dr["StateCode"]),
                        RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                        RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                        RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),
                        ImageRERAcert_FileName = Convert.ToString(dr["ImageRERAcert_FileName"]),
                        ImageRERAcert_FilePath = Convert.ToString(dr["ImageRERAcert_FilePath"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        IsConditional = Convert.ToInt32(dr["IsConditional"]),

                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                    });
            }
            return list_indPro;
        }
    }
}
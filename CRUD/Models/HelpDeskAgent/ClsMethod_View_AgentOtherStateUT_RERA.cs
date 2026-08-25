using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsMethod_View_AgentOtherStateUT_RERA
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthDesk_View_AgentOtherStateUT_RERA> Display_AuthDesk_AgentOtherStateUT_RERADetail(Int64 Agent_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Display_OtherStateUTAgentID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Agent_ID", Agent_ID);

            //connection();
            List<ClsPrp_AuthDesk_View_AgentOtherStateUT_RERA> list_indPro = new List<ClsPrp_AuthDesk_View_AgentOtherStateUT_RERA>();


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list_indPro.Add(
                    new ClsPrp_AuthDesk_View_AgentOtherStateUT_RERA
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

        public List<ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA> Display_AuthDesk_Agent_RefRegistrations_RERADetail(Int64 AgentId, Int32 AgentTypeId, string AgentFlag, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA> RenAgentList = new List<ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Agent_RefRegistrationsRERADetail_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Agent_ID", AgentId);
                cmd.Parameters.AddWithValue("p_AgentType_ID", AgentTypeId);
                cmd.Parameters.AddWithValue("p_Agent_Flag", AgentFlag);
                cmd.Parameters.AddWithValue("p_UserRole", userRole);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RenAgentList.Add(
                        new ClsPrp_AuthDesk_View_Agent_RefRegistration_RERA
                        {
                            Agent_RefRegistration_regRERA_IndexID = Convert.ToInt64(dr["Agent_RefRegistration_regRERA_IndexID"]),
                            Agent_RefRegistration_regRERA_ID = Convert.ToInt64(dr["Agent_RefRegistration_regRERA_ID"]),
                            RenewalAgent_ID = Convert.ToInt64(dr["RenewalAgent_ID"]),
                            RenewalOrderSequence = Convert.ToInt32(dr["RenewalOrderSequence"]),
                            RelatedRenewalAgent_Year = Convert.ToInt32(dr["RelatedRenewalAgent_Year"]),
                            Related_Agent_ID = Convert.ToInt64(dr["Related_Agent_ID"]),
                            Related_AgentDiaryNumber_Name = Convert.ToString(dr["Related_AgentDiaryNumber_Name"]),
                            Related_Agent_Type = Convert.ToInt32(dr["Related_Agent_Type"]),
                            Related_UserID = Convert.ToString(dr["Related_UserID"]),
                            Related_RERAnumberRegistration = Convert.ToString(dr["Related_RERAnumberRegistration"]),
                            Related_Agent_RefRegistrations_RERA_ID = Convert.ToInt64(dr["Related_Agent_RefRegistrations_RERA_ID"]),

                            RERAregistration_Number = Convert.ToString(dr["RERAregistration_Number"]),
                            RERAregistration_IssueDate = Convert.ToDateTime(dr["RERAregistration_IssueDate"]),
                            RERAregistration_ExpiryDate = Convert.ToDateTime(dr["RERAregistration_ExpiryDate"]),

                            Agent_Reference_DiaryNumber = Convert.ToString(dr["Agent_Reference_DiaryNumber"]),
                            Agent_Reference_ApplicationDate = Convert.ToDateTime(dr["Agent_Reference_ApplicationDate"]),
                            Agent_Name = Convert.ToString(dr["Agent_Name"]),
                            Agent_Type = Convert.ToString(dr["Agent_Type"]),
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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return RenAgentList;
        }

        public Int32 Update_LockUnLockHandler_Agent_OtherStateUT_RERA(Int64 AgentId, Int32 AgentTypeId, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_agent_otherstateut_rera", con);
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

    }
}
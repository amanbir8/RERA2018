using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CRUD.Models.AgentRenewal
{
    public abstract class clscon
    {
        protected MySqlConnection con = new MySqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["reraConn"].ConnectionString;
        }
    }
    public class ClsMethod_ReviewConfirm_AgentRenewal_Registration : clscon
    {
        //Validation - Profile
        public Tuple<Int32, Int32, Int32> AgentRenewal_Count_IndOTIndProfile(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //TypeProfile/statusFlag/submitFlag
            Int32 val_TypeProfile = 0;
            Int32 val_statusFlag = 0;
            Int32 val_submitFlag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Count_IndOTIndProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_TypeProfile = Convert.ToInt32(dr["TypeProfile"]);
                    val_statusFlag = Convert.ToInt32(dr["statusFlag"]);
                    val_submitFlag = Convert.ToInt32(dr["submitFlag"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //TypeProfile/statusFlag/submitFlag
            return new Tuple<Int32, Int32, Int32>(val_TypeProfile, val_statusFlag, val_submitFlag);
        }

        //Validation - Other-Members
        public Tuple<Int32, Int32, Int32> AgentRenewal_Count_OtherOrganizationMembers(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //TypeMembers/statusFlag/submitFlag
            Int32 val_TypeMembersYN = 0;
            Int32 val_statusFlag = 0;
            Int32 val_submitFlag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Count_OtherMembers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_TypeMembersYN = Convert.ToInt32(dr["TypeMembersYN"]);
                    val_statusFlag = Convert.ToInt32(dr["statusFlag"]);
                    val_submitFlag = Convert.ToInt32(dr["submitFlag"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //TypeMembers/statusFlag/submitFlag
            return new Tuple<Int32, Int32, Int32>(val_TypeMembersYN, val_statusFlag, val_submitFlag);
        }

        //Validation - Documents
        public Tuple<Int32, Int32, Int32> AgentRenewal_Count_Documents(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //TypeProfile/statusFlag/submitFlag
            Int32 val_TypeProfile = 0;
            Int32 val_statusFlag = 0;
            Int32 val_submitFlag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Count_Documents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_TypeProfile = Convert.ToInt32(dr["TypeProfile"]);
                    val_statusFlag = Convert.ToInt32(dr["statusFlag"]);
                    val_submitFlag = Convert.ToInt32(dr["submitFlag"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //TypeProfile/statusFlag/submitFlag
            return new Tuple<Int32, Int32, Int32>(val_TypeProfile, val_statusFlag, val_submitFlag);
        }

        //Validation - Other-StateUT-RERA
        public Tuple<Int32, Int32, Int32> AgentRenewal_Count_OtherStateUTRERA(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //TypeOtherRERA/statusFlag/submitFlag
            Int32 val_TypeOtherRERA = 0;
            Int32 val_statusFlag = 0;
            Int32 val_submitFlag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Count_OtherStateRERA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_TypeOtherRERA = Convert.ToInt32(dr["TypeOtherRERA"]);
                    val_statusFlag = Convert.ToInt32(dr["statusFlag"]);
                    val_submitFlag = Convert.ToInt32(dr["submitFlag"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //TypeOtherRERA/statusFlag/submitFlag
            return new Tuple<Int32, Int32, Int32>(val_TypeOtherRERA, val_statusFlag, val_submitFlag);
        }

        //Validation - Registration-Fee-Payment
        public Tuple<Int32, Int32, Int32> AgentRenewal_Count_RegistrationFeePayment(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //TypeProfile/statusFlag/submitFlag
            Int32 val_TypeProfile = 0;
            Int32 val_statusFlag = 0;
            Int32 val_submitFlag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AgentRenewal_Count_RegistrationFeePayment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_TypeProfile = Convert.ToInt32(dr["TypeProfile"]);
                    val_statusFlag = Convert.ToInt32(dr["statusFlag"]);
                    val_submitFlag = Convert.ToInt32(dr["submitFlag"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //TypeProfile/statusFlag/submitFlag
            return new Tuple<Int32, Int32, Int32>(val_TypeProfile, val_statusFlag, val_submitFlag);
        }

        /// <summary>
        /// Agree Details, count exist in all tables to disable/enable - agree button
        /// </summary>
        public int AgentRenewal_Count_AgreeDetails(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_AgentRenewal_Count_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        /// <summary>
        /// Get Isdraft value From Diary Number table
        /// </summary>
        public int Extract_AgentRenewal_Isdraftvalue_FromDiaryNumber(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_AgentRenewal_Isdraftvalue_FromDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        /// <summary>
        /// Update Renewal-Agent Agree Details
        /// </summary>
        public string Update_AgentRenewalAgreeDetails(Int64 Related_Agent_ID, Int32 Related_TypeOfAgent_ID, Int64 Related_RenewalAgent_ID, Int32 Related_RenewalAgent_SequenceID, Int32 Related_RenewalAgent_Year, string Related_Agent_DiaryNumber, string Registration_Number, string Registration_Remarks, Int32 Flag, string UID, string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string AppId = string.Empty;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_insert_tbl_RERA_AgentRenewal_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", Related_Agent_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", Related_TypeOfAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", Related_RenewalAgent_ID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", Related_RenewalAgent_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", Related_RenewalAgent_Year);
                cmd.Parameters.AddWithValue("p_Related_Agent_DiaryNumber", Related_Agent_DiaryNumber);
                cmd.Parameters.AddWithValue("p_Related_Registration_Number", Registration_Number);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserID", UID);

                cmd.Parameters.AddWithValue("p_A_column", "NA");
                cmd.Parameters.AddWithValue("p_B_column", "NA");
                cmd.Parameters.AddWithValue("p_C_column", "NA");
                cmd.Parameters.AddWithValue("p_Remarks_IfAny", Registration_Remarks);

                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 1);
                cmd.Parameters.AddWithValue("p_IsLock", 1);
                cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
                cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
                cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
                cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);                
                cmd.Parameters.AddWithValue("p_CreatedBy", userName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", userName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                MySqlParameter AppPar = new MySqlParameter("p_Return_RenewalAgent_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
                AppPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(AppPar);

                int i = cmd.ExecuteNonQuery();
                AppId = Convert.ToString(AppPar.Value);
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return AppId;
        }

        //Update Profile
        public bool Update_AR_IndOTIndProfile(Int64 v_AgentID, Int32 v_TypeOfAgent, Int64 v_RenewalAgentID, Int32 v_RenewalSequenceID, Int32 v_RenewalAgentYear, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_AgentRenewal_IndOTIndProfile";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", v_AgentID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", v_TypeOfAgent);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", v_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", v_RenewalSequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", v_RenewalAgentYear);
                cmd.Parameters.AddWithValue("p_Flag", v_setFlag);
                cmd.Parameters.AddWithValue("p_UserNam", v_UserNam);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        //Update OtherMember
        public bool Update_AR_OtherMember(Int64 v_AgentID, Int32 v_TypeOfAgent, Int64 v_RenewalAgentID, Int32 v_RenewalSequenceID, Int32 v_RenewalAgentYear, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_AgentRenewal_OtherMember";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", v_AgentID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", v_TypeOfAgent);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", v_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", v_RenewalSequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", v_RenewalAgentYear);
                cmd.Parameters.AddWithValue("p_Flag", v_setFlag);
                cmd.Parameters.AddWithValue("p_UserNam", v_UserNam);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        //Update Document
        public bool Update_AR_Document(Int64 v_AgentID, Int32 v_TypeOfAgent, Int64 v_RenewalAgentID, Int32 v_RenewalSequenceID, Int32 v_RenewalAgentYear, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_AgentRenewal_Document";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", v_AgentID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", v_TypeOfAgent);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", v_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", v_RenewalSequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", v_RenewalAgentYear);
                cmd.Parameters.AddWithValue("p_Flag", v_setFlag);
                cmd.Parameters.AddWithValue("p_UserNam", v_UserNam);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        //Update OtherState-RERA
        public bool Update_AR_OtherStateRERA(Int64 v_AgentID, Int32 v_TypeOfAgent, Int64 v_RenewalAgentID, Int32 v_RenewalSequenceID, Int32 v_RenewalAgentYear, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_AgentRenewal_OtherStateRERA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", v_AgentID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", v_TypeOfAgent);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", v_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", v_RenewalSequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", v_RenewalAgentYear);
                cmd.Parameters.AddWithValue("p_Flag", v_setFlag);
                cmd.Parameters.AddWithValue("p_UserNam", v_UserNam);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        //Update PaymentFee
        public bool Update_AR_PaymentFee(Int64 v_AgentID, Int32 v_TypeOfAgent, Int64 v_RenewalAgentID, Int32 v_RenewalSequenceID, Int32 v_RenewalAgentYear, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_AgentRenewal_PaymentFee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Agent_ID", v_AgentID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfAgent_ID", v_TypeOfAgent);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_ID", v_RenewalAgentID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_SequenceID", v_RenewalSequenceID);
                cmd.Parameters.AddWithValue("p_Related_RenewalAgent_Year", v_RenewalAgentYear);
                cmd.Parameters.AddWithValue("p_Flag", v_setFlag);
                cmd.Parameters.AddWithValue("p_UserNam", v_UserNam);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
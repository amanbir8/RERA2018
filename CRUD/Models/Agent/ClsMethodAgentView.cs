using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.PromoterProject
{
    public abstract class clscon
    {
        protected MySqlConnection con = new MySqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["reraConn"].ConnectionString;
        }
    }
    public class ClsMethodAgentView : clscon
    {
        /// <summary>
        /// Get Agent Profile
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Profilecount(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Agent_profile";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }
        /// <summary>
        /// Update Agent Profile
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool Update(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_Agent_profile";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

                //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

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

        /// <summary>
        /// Get Other Member Detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int OtherMemberDetail(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_OtherMemberDetail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
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
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Isdraftvalue_FromDiaryNumber(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Agent_Isdraftvalue_FromDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
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
        /// Update Other Member Detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool Updateother(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_Agent_OtherMemberDetail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

                //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

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

        /// <summary>
        /// Get Document Upload
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int DocumentUpload(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_DocumentUpload";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
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
        /// Update Document Upload
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateDocumentUpload(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_Agent_DocumentUpload";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);


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

        /// <summary>
        /// Get Other State
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int OtherState(Int64 Application_ID)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_OtherStateUT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
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
        /// Update Other State
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateOtherState(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_Agent_OtherStateUT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);


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

        /// <summary>
        /// Get Payment Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int PaymentDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Payment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
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
        /// Update Payment Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdatePaymentDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_Agent_Payment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);


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

        /// <summary>
        /// I Agree Details count each application id exist in all tables to disable/enable the agree button
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int AgreeDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Agent_Count_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
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
        /// Update Agree Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public string UpdateAgreeDetails(Int64 Application_ID, string UID, string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string AppId = string.Empty;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_insert_tbl_Rera_Agent_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_ID", AgentRegDiaryNumber_ID);
                //cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_Name", AgentRegDiaryNumber_Name);
                //cmd.Parameters.AddWithValue("p_AgentRegDiaryNumber_NameYear", AgentRegDiaryNumber_NameYear);
                cmd.Parameters.AddWithValue("p_Agent_ID", Application_ID);
                cmd.Parameters.AddWithValue("p_UserID", UID);
                //cmd.Parameters.AddWithValue("p_othermemdetailCount", othermemdetailCount);
                //cmd.Parameters.AddWithValue("p_documentuploadCount", documentuploadCount);
                //cmd.Parameters.AddWithValue("p_UTOtherStateRERACount", UTOtherStateRERACount);
                //cmd.Parameters.AddWithValue("p_PaymentCount", PaymentCount);
                //cmd.Parameters.AddWithValue("p_AgentDocumentCount", AgentDocumentCount);
                cmd.Parameters.AddWithValue("p_Remarks_IfAny", "Remarks_IfAny");
                //cmd.Parameters.AddWithValue("p_IsActive", Active);
                cmd.Parameters.AddWithValue("p_IsDraft", 0);
                //cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", IsDraftHelpDesk);
                //cmd.Parameters.AddWithValue("p_IsDraftEvaluation", IsDraftEvaluation);
                //cmd.Parameters.AddWithValue("p_IsDraftSecMember", IsDraftSecMember);
                //cmd.Parameters.AddWithValue("p_IsDraftMember", IsDraftMember);
                cmd.Parameters.AddWithValue("p_CreatedBy", userName);

                cmd.Parameters.AddWithValue("p_ModifyBy", userName);


                MySqlParameter AppPar = new MySqlParameter("p_Return_AgentRegDiaryNumber_Name", MySqlDbType.VarChar, 50);
                AppPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(AppPar);


                int i = cmd.ExecuteNonQuery();

                AppId = Convert.ToString(AppPar.Value);

                con.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return AppId;
        }
    }
}
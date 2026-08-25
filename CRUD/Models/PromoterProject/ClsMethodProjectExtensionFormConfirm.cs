using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethodProjectExtensionFormConfirm: clscon
    {
        
        /// <summary>
        /// Get Payment  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ExtensionFormPayment(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_ProjectExtensionForm_Payment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }
        
        /// <summary>
        /// Get Documents Details  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ExtensionFormDocuments(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_ProjectExtensionForm_Documents";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }
        
        /// <summary>
        /// I Agree Details count each application id exist in all tables to disable/enable the agree button
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ProjectExtensionFormAgreeDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_ProjectExtensionForm_Count_RegDiaryNumber";
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
                string tex = ex.ToString();
            }
            return RecordCount;
        }
                
        /// <summary>
        /// Get Isdraft value From Diary Number table
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Isdraftvalue_ProjectExtensionForm_FromDiaryNumber(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_ProjectExtensionForm_Isdraftvalue_FromDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Update  Agree Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public string UpdateProjectExtensionFormAgreeDetails(Int64 PromoterApplicationId, Int64 Application_ID, string UID, string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_insert_tbl_RERA_ProjectExtensionForm_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterApplicationId);
            cmd.Parameters.AddWithValue("p_UserID", UID);
            cmd.Parameters.AddWithValue("p_Project_ID", Application_ID);

            cmd.Parameters.AddWithValue("p_Extra2", string.Empty);
            cmd.Parameters.AddWithValue("p_Extra3", string.Empty);
            cmd.Parameters.AddWithValue("p_Extra4", string.Empty);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);            

            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 0);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);

            MySqlParameter AppPar = new MySqlParameter("p_Return_ProjectExtForm_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            int i = cmd.ExecuteNonQuery();

            string AppId = Convert.ToString(AppPar.Value);
            con.Close();
            return AppId;
        }
        
        /// <summary>
        /// Update Payment
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateExtensionFormPayment(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_ProjectExtensionForm_Payment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// Update Documents
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateExtensionFormDocuments(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_ProjectExtensionForm_Document";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
                
    }
}
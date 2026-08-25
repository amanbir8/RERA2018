using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CRUD.Models.Promoter
{
    public abstract class clscon
    {
        protected MySqlConnection con = new MySqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["reraConn"].ConnectionString;
        }
    }
    public class ClsMethodPromoterConfirm:clscon
    {
        /// <summary>
        /// Get Promoter Profile
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Profilecount(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_IndividualPromoter_profile";
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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Promoter_OtherMemberDetail";
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
        /// Get Other Parent Entity
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ParentEntity(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Promoter_ParentEntity";
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
        /// Get Other Experience_Completed_OnGoing
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Experience_Completed_OnGoing(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Promoter_Experience_Completed_OnGoing";
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
        /// Get Litigations detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Litigations(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Promoter_Litigations";
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
        /// Get Litigations detail if any against promoter id
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Litigationsifany_Application_ID(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Promoter_LitigationsIFANY";
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
        /// Get Documents detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Documents(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Promoter_Documents";
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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Promoter_Isdraftvalue_FromDiaryNumber";
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
        /// Update Promoter Profile
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool Update(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Promoter_profile";
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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Promoter_OtherMemberDetail";
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

        /// <summary>
        /// Update Parent Entity Detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateParentEntitiy(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Promoter_ParentEntity";
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

        
        /// <summary>
        /// Update Parent Entity Detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateExperince(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Promoter_Experience";
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

        /// <summary>
        /// Update Litigations Detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateLitigations(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Promoter_Litigations";
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

        /// <summary>
        /// Update  Documents  Detail
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateDocumentsDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Promoter_Documents";
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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Promoter_Count_RegDiaryNumber";
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

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_insert_tbl_Rera_Promoter_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_ID", AgentRegDiaryNumber_ID);
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_Name", AgentRegDiaryNumber_Name);
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_NameYear", AgentRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Application_ID);
            cmd.Parameters.AddWithValue("p_UserID", UID);
            //cmd.Parameters.AddWithValue("p_othermemdetailCount", othermemdetailCount);
            //cmd.Parameters.AddWithValue("p_documentuploadCount", documentuploadCount);
            //cmd.Parameters.AddWithValue("p_UTOtherStateRERACount", UTOtherStateRERACount);
            //cmd.Parameters.AddWithValue("p_PaymentCount", PaymentCount);
            //cmd.Parameters.AddWithValue("p_PromoterDocumentCount", PromoterDocumentCount);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", "Remarks_IfAny");
            //cmd.Parameters.AddWithValue("p_IsActive", Active);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            //cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", IsDraftHelpDesk);
            //cmd.Parameters.AddWithValue("p_IsDraftEvaluation", IsDraftEvaluation);
            //cmd.Parameters.AddWithValue("p_IsDraftSecMember", IsDraftSecMember);
            //cmd.Parameters.AddWithValue("p_IsDraftMember", IsDraftMember);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);

            cmd.Parameters.AddWithValue("p_ModifyBy", userName);

            MySqlParameter AppPar = new MySqlParameter("p_Return_PromoterRegDiaryNumber_Name", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);


            int i = cmd.ExecuteNonQuery();
            string AppId = Convert.ToString(AppPar.Value);
            con.Close();
            return AppId;
        }


        /// <summary>
        /// Get JointPromoter-Litigations Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public Tuple<string, Int32> JointPromoterDetails_TrackRecordLitigations_ByID(Int64 Application_ID, string UID, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //JointPromoterProfileYN/statusFlag
            string val_JointPromoterYN = "N";
            Int32 val_TotalCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Count_Promoter_JointPromoterDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Application_id", Application_ID);
                cmd.Parameters.AddWithValue("p_Flag", UID);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_JointPromoterYN = Convert.ToString(dr["JointPromoterYN"]);
                    val_TotalCount = Convert.ToInt32(dr["TotalCount"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //JointPromoterProfileYN/statusFlag
            return new Tuple<string, Int32>(val_JointPromoterYN, val_TotalCount);
        }


    }
}
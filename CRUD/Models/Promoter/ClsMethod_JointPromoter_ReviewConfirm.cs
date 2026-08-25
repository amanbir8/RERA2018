using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CRUD.Models.JointPromoter
{
    public abstract class clscon
    {
        protected MySqlConnection con = new MySqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["reraConn"].ConnectionString;
        }
    }
    public class ClsMethod_JointPromoter_ReviewConfirm : clscon
    {

        //Validation - JointPromoter-Profile
        public Tuple<Int32, Int32, Int32> JointPromoter_Count_Profile(Int64 Related_Promoter_ID, Int32 Related_TypeOfPromoter_ID, Int64 Related_JointPromoter_ID, Int32 Related_JointPromoter_Type, Int32 Flag, string UserNam)
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
                MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_Count_Profile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Promoter_ID", Related_Promoter_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfPromoter_ID", Related_TypeOfPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", Related_JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Type", Related_JointPromoter_Type);
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
        
        //Validation - JointPromoter-Litigations
        public Tuple<Int32, Int32, Int32, Int32> JointPromoter_Count_TrackRecordLitigations(Int64 Related_Promoter_ID, Int32 Related_TypeOfPromoter_ID, Int64 Related_JointPromoter_ID, Int32 Related_JointPromoter_Type, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //TypeExperienceYN/TypeLitigationsYN/statusFlag/submitFlag
            Int32 val_TypeExperienceYN = 0;
            Int32 val_TypeLitigationsYN = 0;
            Int32 val_statusFlag = 0;
            Int32 val_submitFlag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_Count_TrackRecordLitigations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Related_Promoter_ID", Related_Promoter_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfPromoter_ID", Related_TypeOfPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", Related_JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Type", Related_JointPromoter_Type);
                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserNam", UserNam);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    val_TypeExperienceYN = Convert.ToInt32(dr["TypeExperienceYN"]);
                    val_TypeLitigationsYN = Convert.ToInt32(dr["TypeLitigationsYN"]);
                    val_statusFlag = Convert.ToInt32(dr["statusFlag"]);
                    val_submitFlag = Convert.ToInt32(dr["submitFlag"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //TypeProfile/statusFlag/submitFlag
            return new Tuple<Int32, Int32, Int32, Int32>(val_TypeExperienceYN, val_TypeLitigationsYN, val_statusFlag, val_submitFlag);
        }

        //Validation - JointPromoter-Litigations YN
        public Tuple<string, Int32> JointPromoter_YN_TrackRecordLitigations_ByID(Int64 Application_ID, Int32 Application_Type, string UserID, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //JointPromoterProfile(Y/N)/statusFlag(1/0)
            string val_JointPromoterYN = "N";
            Int32 val_TotalCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_PromoterDetail_YN_ByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Promoter_ID", Application_ID);
                cmd.Parameters.AddWithValue("p_Promoter_Type", Application_Type);
                cmd.Parameters.AddWithValue("p_UserID", UserID);
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
            //JointPromoterProfile(Y/N)/statusFlag(1/0)
            return new Tuple<string, Int32>(val_JointPromoterYN, val_TotalCount);
        }

        //Validation - JointPromoter-IAgree
        public int JointPromoter_Count_AgreeDetails(Int64 Related_Promoter_ID, Int32 Related_TypeOfPromoter_ID, Int64 Related_JointPromoter_ID, Int32 Related_JointPromoter_Type, Int32 Flag, string UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_JointPromoter_Count_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Promoter_ID", Related_Promoter_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfPromoter_ID", Related_TypeOfPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", Related_JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Type", Related_JointPromoter_Type);
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

        //Update JointPromoter-Profile
        public bool Update_JointPromoter_IndOTIndProfile(Int64 Promoter_ID, Int32 TypeOfPromoter_ID, Int64 JointPromoter_ID, Int32 JointPromoter_Type, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_JointPromoter_IndOTIndProfile";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Promoter_ID", Promoter_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfPromoter_ID", TypeOfPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Type", JointPromoter_Type);
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

        //Update JointPromoter-TrackRecord-Litigations
        public bool Update_JointPromoter_TrackRecordLitigations(Int64 Promoter_ID, Int32 TypeOfPromoter_ID, Int64 JointPromoter_ID, Int32 JointPromoter_Type, Int32 v_setFlag, string v_UserNam)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_Rera_Count_JointPromoter_TrackLitigations";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Related_Promoter_ID", Promoter_ID);
                cmd.Parameters.AddWithValue("p_Related_TypeOfPromoter_ID", TypeOfPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Type", JointPromoter_Type);
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

        /// <summary>
        /// Update Renewal-Agent Agree Details
        /// </summary>
        public string Update_JointPromoter_AgreeDetails(Int64 mJointPromoter_ID, Int32 mJointPromoter_Type, string mJointPromoter_DiaryNumber, string mJointPromoter_Name, string mRegistrationNumber, string Related_Promoter_DiaryNumber, Int64 Related_Promoter_ID, Int32 Related_Promoter_Type, string Related_Promoter_Name, Int32 OtherMember_YN_Flag, Int32 OtherParentEntity_YN_Flag, Int32 OtherExperience_YN_Flag, Int32 OtherLitigations_YN_Flag, string Registration_Remarks, Int32 Flag, string UID, string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string AppId = string.Empty;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_insert_tbl_RERA_JointPromoter_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_JointPromoter_Confirm_Step_IndexID", 0);
                cmd.Parameters.AddWithValue("p_JointPromoter_Confirm_Step_ID", 0);

                cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", mJointPromoter_ID);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Type", mJointPromoter_Type);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_DiaryNumber", mJointPromoter_DiaryNumber);
                cmd.Parameters.AddWithValue("p_Related_JointPromoter_Name", mJointPromoter_Name);
                cmd.Parameters.AddWithValue("p_Related_RegistrationNumber", mRegistrationNumber);

                cmd.Parameters.AddWithValue("p_Related_Promoter_DiaryNumber", Related_Promoter_DiaryNumber);
                cmd.Parameters.AddWithValue("p_Related_Promoter_ID", Related_Promoter_ID);
                cmd.Parameters.AddWithValue("p_Related_Promoter_Type", Related_Promoter_Type);
                cmd.Parameters.AddWithValue("p_Related_Promoter_Name", Related_Promoter_Name);

                cmd.Parameters.AddWithValue("p_Registration_OtherMember_YN_Flag", OtherMember_YN_Flag);
                cmd.Parameters.AddWithValue("p_Registration_OtherParentEntity_YN_Flag", OtherParentEntity_YN_Flag);
                cmd.Parameters.AddWithValue("p_Registration_OtherExperience_YN_Flag", OtherExperience_YN_Flag);
                cmd.Parameters.AddWithValue("p_Registration_OtherLitigations_YN_Flag", OtherLitigations_YN_Flag);

                cmd.Parameters.AddWithValue("p_Flag", Flag);
                cmd.Parameters.AddWithValue("p_UserID", UID);

                cmd.Parameters.AddWithValue("p_A_column", "NA");
                cmd.Parameters.AddWithValue("p_B_column", "NA");
                cmd.Parameters.AddWithValue("p_C_column", "NA");
                cmd.Parameters.AddWithValue("p_Remarks_IfAny", Registration_Remarks);

                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 1);
                cmd.Parameters.AddWithValue("p_IsLock", 1);
                cmd.Parameters.AddWithValue("p_IsFlag", 0);
                cmd.Parameters.AddWithValue("p_IsPublicView", 1);
                cmd.Parameters.AddWithValue("p_IsConditional", 0);
                cmd.Parameters.AddWithValue("p_IsDraftMember", 1);
                cmd.Parameters.AddWithValue("p_CreatedBy", userName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", userName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                MySqlParameter AppPar = new MySqlParameter("p_Return_JointPromoter_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
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


        /// <summary>
        /// Get Joint-Promoter Isdraft value From Diary Number table
        /// </summary>
        public int JointPromoter_Isdraftvalue_FromDiaryNumber(Int64 input_Promoter_ID, Int64 input_Promoter_Type, Int64 input_JointPromoter_ID, Int64 input_JointPromoter_Type)
        {
            int RecordCount = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_JointPromoter_Isdraftvalue_FromDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_Promoter_ID", input_Promoter_ID);
                cmd.Parameters.AddWithValue("p_Promoter_Type", input_Promoter_Type);
                cmd.Parameters.AddWithValue("p_JointPromoter_ID", input_JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_JointPromoter_Type", input_JointPromoter_Type);

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


    }
}
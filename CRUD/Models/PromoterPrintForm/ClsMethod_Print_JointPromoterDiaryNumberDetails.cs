using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.PromoterPrint
{
    public class ClsMethod_Print_JointPromoterDiaryNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_JointPromoter_Print_DiaryNumberDetails> Print_JointPromoter_RegDiaryNumberByID_ForPrint(Int64 Promoter_ID, Int64 JointPromoter_ID, Int32 JointPromoter_Type, string UserID_Name, string UserID_Role)
        {
            connection();
            List<ClsPrp_JointPromoter_Print_DiaryNumberDetails> JointPromoterList = new List<ClsPrp_JointPromoter_Print_DiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_Print_RegDiaryNumberByID_ForPrint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ID);
                cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_Type);
                cmd.Parameters.AddWithValue("p_UserName", UserID_Name);
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    JointPromoterList.Add(
                        new ClsPrp_JointPromoter_Print_DiaryNumberDetails
                        {
                            JointPromoter_RegDiaryNumber_IndexID = Convert.ToInt64(dr["JointPromoter_RegDiaryNumber_IndexID"]),

                            Promoter_RegDiaryNumber_ID = Convert.ToInt64(dr["Promoter_RegDiaryNumber_ID"]),
                            Promoter_RegDiaryNumber_Name = Convert.ToString(dr["Promoter_RegDiaryNumber_Name"]),
                            Promoter_RegDiaryNumber_NameYear = Convert.ToString(dr["Promoter_RegDiaryNumber_NameYear"]),

                            JointPromoter_RegDiaryNumber_ID = Convert.ToInt64(dr["JointPromoter_RegDiaryNumber_ID"]),
                            JointPromoter_RegDiaryNumber_Name = Convert.ToString(dr["JointPromoter_RegDiaryNumber_Name"]),
                            JointPromoter_RegDiaryNumber_NameYear = Convert.ToString(dr["JointPromoter_RegDiaryNumber_NameYear"]),

                            Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                            Promoter_Type = Convert.ToInt32(dr["Promoter_Type"]),

                            JointPromoter_ID = Convert.ToInt64(dr["JointPromoter_ID"]),
                            JointPromoter_Type = Convert.ToInt32(dr["JointPromoter_Type"]),
                            UserID = Convert.ToString(dr["UserID"]),

                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            C_column = Convert.ToString(dr["C_column"]),
                            D_column = Convert.ToString(dr["D_column"]),

                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            IsLock = Convert.ToInt32(dr["IsLock"]),
                            IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                            IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                            IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                            IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                            IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                            IsConditional = Convert.ToInt32(dr["IsConditional"]),

                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                            // Application ID
                            zipRelated_Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                            zipRelated_JointPromoter_ID = Convert.ToInt64(dr["JointPromoter_ID"]),
                            // Application Date
                            Promoter_ApplicationDate = Convert.ToDateTime(dr["Promoter_ApplicationDate"]),
                            JointPromoter_ApplicationDate = Convert.ToDateTime(dr["JointPromoter_ApplicationDate"]),
                            // Promoter Name/Diary Number
                            zipPromoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                            zipPromoterName = Convert.ToString(dr["Promoter_Name"]),
                            // Promoter Name/Diary Number
                            zipJointPromoter_DiaryNumber = Convert.ToString(dr["JointPromoter_DiaryNumber"]),
                            zipJointPromoterName = Convert.ToString(dr["JointPromoter_Name"]),

                            zipJointPromoterLastModifiedOn = DateTime.Now,
                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return JointPromoterList;
        }

    }
}
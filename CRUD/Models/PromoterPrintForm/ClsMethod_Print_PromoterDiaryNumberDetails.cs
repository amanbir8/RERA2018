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
    public class ClsMethod_Print_PromoterDiaryNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmPromoter_Print_DiaryNumberDetails> Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmPromoter_Print_DiaryNumberDetails> ProjectFivelist1 = new List<ClsPrp_PrmPromoter_Print_DiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_RegDiaryNumberByPromoterID_ForPrint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectFivelist1.Add(
                        new ClsPrp_PrmPromoter_Print_DiaryNumberDetails
                        {

                            PromoterRegDiaryNumber_IndexID = Convert.ToInt64(dr["PromoterRegDiaryNumber_IndexID"]),
                            PromoterRegDiaryNumber_ID = Convert.ToInt64(dr["PromoterRegDiaryNumber_ID"]),

                            PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                            PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                            Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                            UserID = Convert.ToString(dr["UserID"]),

                            ParentEntityCount = Convert.ToInt32(dr["ParentEntityCount"]),
                            OtherOrgMemberCount = Convert.ToInt32(dr["OtherOrgMemberCount"]),
                            TrackRecordCount = Convert.ToInt32(dr["TrackRecordCount"]),
                            LitigationCount = Convert.ToInt32(dr["LitigationCount"]),
                            PromoterDocumentCount = Convert.ToInt32(dr["PromoterDocumentCount"]),

                            Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            IsDraft = Convert.ToInt32(dr["IsDraft"]),
                            IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                            IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                            IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                            IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),


                            zipRelated_Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                            zipPromoter_DiaryNumber = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                            zipPromoterName = Convert.ToString(dr["Promoter_Name"]),
                            zipPromoterLastModifiedOn = DateTime.Now,

                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ProjectFivelist1;
        }

    }
}
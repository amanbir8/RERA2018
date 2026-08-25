using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_JointPromoter_ReviewMaster
    {

        public List<ClsPrp_JointPromoter_Confirm_ReviewMaster> FillDropdown_JointPromoterDetails_ByAppId(Int64 Promoter_ID, Int32 Promoter_Type, string RegdNumber, Int64 Flag, string UserNam)
        {
            List<ClsPrp_JointPromoter_Confirm_ReviewMaster> referencelist = new List<ClsPrp_JointPromoter_Confirm_ReviewMaster>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_ByAppId_Registration", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                    cmd.Parameters.AddWithValue("p_TypeOfPromoter_ID", Promoter_Type);
                    cmd.Parameters.AddWithValue("p_RegistrationNumber", RegdNumber);
                    cmd.Parameters.AddWithValue("p_Flag", Flag);
                    cmd.Parameters.AddWithValue("p_UserName", UserNam);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_JointPromoter_Confirm_ReviewMaster uobj = new ClsPrp_JointPromoter_Confirm_ReviewMaster();
                        uobj.Related_JointPromoter_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["JointPromoter_ID"].ToString());
                        uobj.Related_JointPromoter_Type = Convert.ToInt32(ds.Tables[0].Rows[i]["JointPromoter_Type"].ToString());
                        uobj.Related_JointPromoter_DiaryNumber = ds.Tables[0].Rows[i]["JointPromoter_DiaryNumber"].ToString();
                        uobj.Related_JointPromoter_Name = ds.Tables[0].Rows[i]["JointPromoter_Name"].ToString();
                        uobj.Related_RegistrationNumber = ds.Tables[0].Rows[i]["Registration_Number"].ToString();

                        uobj.Related_Promoter_DiaryNumber = ds.Tables[0].Rows[i]["Related_Promoter_DiaryNumber"].ToString();
                        uobj.Related_Promoter_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["Related_Promoter_ID"].ToString());
                        uobj.Related_Promoter_Type = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_Promoter_Type"].ToString());
                        uobj.Related_Promoter_Name = ds.Tables[0].Rows[i]["Related_Promoter_Name"].ToString();

                        uobj.Registration_OtherMember_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"]);
                        uobj.Registration_OtherParentEntity_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherParentEntity_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherParentEntity_YN_Flag"]);
                        uobj.Registration_OtherExperience_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherExperience_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherExperience_YN_Flag"]);
                        uobj.Registration_OtherLitigations_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherLitigations_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherLitigations_YN_Flag"]);

                        uobj.A_Column = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["A_Column"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["A_Column"]);
                        uobj.B_Column = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["B_Column"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["B_Column"]);
                        uobj.C_Column = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["C_Column"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["C_Column"]);

                        uobj.IsActive = Convert.ToInt32(ds.Tables[0].Rows[i]["IsActive"].ToString());
                        uobj.IsDraft = Convert.ToInt32(ds.Tables[0].Rows[i]["IsDraft"].ToString());
                        uobj.IsLock = Convert.ToInt32(ds.Tables[0].Rows[i]["IsLock"].ToString());
                        uobj.IsFlag = Convert.ToInt32(ds.Tables[0].Rows[i]["IsFlag"].ToString());
                        uobj.IsPublicView = Convert.ToInt32(ds.Tables[0].Rows[i]["IsPublicView"].ToString());
                        uobj.IsConditional = Convert.ToInt32(ds.Tables[0].Rows[i]["IsConditional"].ToString());
                        uobj.IsDraftMember = Convert.ToInt32(ds.Tables[0].Rows[i]["IsDraftMember"].ToString());

                        referencelist.Add(uobj);
                    }
                    return referencelist;
                }
            }
        }

        public List<ClsPrp_JointPromoter_ExtractDetails_ReviewMaster> FillDropdown_ExtarctDetails_RenewalAgent_ByAppId(Int64 Promoter_ID, Int32 Promoter_Type, Int64 JointPromoter_ID, Int32 JointPromoter_Type, Int32 Flag, string UserNam)
        {
            List<ClsPrp_JointPromoter_ExtractDetails_ReviewMaster> referencelist = new List<ClsPrp_JointPromoter_ExtractDetails_ReviewMaster>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_ByAppId_ExtractDetail", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                    cmd.Parameters.AddWithValue("p_TypeOfPromoter_ID", Promoter_Type);
                    cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ID);
                    cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_Type);
                    cmd.Parameters.AddWithValue("p_Flag", Flag);
                    cmd.Parameters.AddWithValue("p_UserName", UserNam);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_JointPromoter_ExtractDetails_ReviewMaster uobj = new ClsPrp_JointPromoter_ExtractDetails_ReviewMaster();
                        uobj.Related_JointPromoter_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["JointPromoter_ID"].ToString());
                        uobj.Related_JointPromoter_Type = Convert.ToInt32(ds.Tables[0].Rows[i]["JointPromoter_Type"].ToString());
                        uobj.Related_JointPromoter_DiaryNumber = ds.Tables[0].Rows[i]["JointPromoter_DiaryNumber"].ToString();
                        uobj.Related_JointPromoter_Name = ds.Tables[0].Rows[i]["JointPromoter_Name"].ToString();
                        uobj.Related_RegistrationNumber = ds.Tables[0].Rows[i]["Registration_Number"].ToString();

                        uobj.Related_Promoter_DiaryNumber = ds.Tables[0].Rows[i]["Related_Promoter_DiaryNumber"].ToString();
                        uobj.Related_Promoter_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["Related_Promoter_ID"].ToString());
                        uobj.Related_Promoter_Type = Convert.ToInt32(ds.Tables[0].Rows[i]["Related_Promoter_Type"].ToString());
                        uobj.Related_Promoter_Name = ds.Tables[0].Rows[i]["Related_Promoter_Name"].ToString();

                        uobj.Registration_OtherMember_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherMember_YN_Flag"]);
                        uobj.Registration_OtherParentEntity_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherParentEntity_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherParentEntity_YN_Flag"]);
                        uobj.Registration_OtherExperience_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherExperience_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherExperience_YN_Flag"]);
                        uobj.Registration_OtherLitigations_YN_Flag = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherLitigations_YN_Flag"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["Registration_OtherLitigations_YN_Flag"]);

                        uobj.A_Column = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["A_Column"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["A_Column"]);
                        uobj.B_Column = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["B_Column"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["B_Column"]);
                        uobj.C_Column = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["C_Column"])) ? "N" : Convert.ToString(ds.Tables[0].Rows[i]["C_Column"]);

                        referencelist.Add(uobj);
                    }
                    return referencelist;
                }
            }
        }

    }
}
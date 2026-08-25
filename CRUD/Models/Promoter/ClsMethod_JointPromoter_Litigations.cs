using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_JointPromoter_Litigations
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_JointPromoter_TrackRecord_LitigationsDetail(ClsPrp_JointPromoter_TrackLitigations smodel, Int64 applicationid, Int32 applicationtype, string userName, string userID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_Rera_JointPromoter_TrackRecord_Litigations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_JointPromoter_Litigations_IndexID", smodel.JointPromoter_Litigations_IndexID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Litigation_ID", smodel.JointPromoter_Litigation_ID);
            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", applicationid);
            cmd.Parameters.AddWithValue("p_Related_PromoterType", applicationtype);
            cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", smodel.Related_JointPromoter_ID);
            cmd.Parameters.AddWithValue("p_Related_JointPromoterType", smodel.Related_JointPromoterType);

            cmd.Parameters.AddWithValue("p_LitigationsRelated_JointPromoterName", string.IsNullOrEmpty(smodel.LitigationsRelated_JointPromoterName) ? "" : smodel.LitigationsRelated_JointPromoterName);
            cmd.Parameters.AddWithValue("p_LitigationsRelated_ProjectName", string.IsNullOrEmpty(smodel.LitigationsRelated_ProjectName) ? "" : smodel.LitigationsRelated_ProjectName);

            cmd.Parameters.AddWithValue("p_Project_Name", string.IsNullOrEmpty(smodel.Project_Name) ? "" : smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_Project_Type", string.IsNullOrEmpty(smodel.Project_Type) ? "" : smodel.Project_Type);
            cmd.Parameters.AddWithValue("p_Project_Status", string.IsNullOrEmpty(smodel.Project_Status) ? "" : smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_Project_AreaConstructed", smodel.Project_AreaConstructed);
            cmd.Parameters.AddWithValue("p_ProjectStartDate", DateTime.Now); //static data
            cmd.Parameters.AddWithValue("p_Case_Title", string.IsNullOrEmpty(smodel.Case_Title) ? "NA" : smodel.Case_Title);
            cmd.Parameters.AddWithValue("p_Case_Number", string.IsNullOrEmpty(smodel.Case_Number) ? "NA" : smodel.Case_Number);
            cmd.Parameters.AddWithValue("p_Authority_ForumName_CasePendingResolved", string.IsNullOrEmpty(smodel.Authority_ForumName_CasePendingResolved) ? "" : smodel.Authority_ForumName_CasePendingResolved);

            cmd.Parameters.AddWithValue("p_JointPromoter_LitigationsFlag", smodel.JointPromoter_LitigationsFlag);
            cmd.Parameters.AddWithValue("p_JointPromoter_LitigationsCondition", smodel.JointPromoter_LitigationsCondition);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 1);
            cmd.Parameters.AddWithValue("p_Flag", 0);
            cmd.Parameters.AddWithValue("p_Created_By", string.IsNullOrEmpty(userName) ? "sysadmin" : userName);
            cmd.Parameters.AddWithValue("p_Created_On", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Modify_By", string.IsNullOrEmpty(userName) ? "sysadmin" : userName);
            cmd.Parameters.AddWithValue("p_Modified_On", DateTime.Now);

            cmd.Parameters.AddWithValue("p_Extra1", string.IsNullOrEmpty(smodel.Extra1) ? "" : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", string.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", string.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", string.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_JointPromoter_TrackRecord_LitigationsDetail(ClsPrp_JointPromoter_TrackLitigations smodel, Int64 applicationid, Int32 applicationtype, string userName, string userID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_JointPromoter_TrackRecord_Litigations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_JointPromoter_Litigations_IndexID", smodel.JointPromoter_Litigations_IndexID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Litigation_ID", smodel.JointPromoter_Litigation_ID);
            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", applicationid);
            cmd.Parameters.AddWithValue("p_Related_PromoterType", applicationtype);
            cmd.Parameters.AddWithValue("p_Related_JointPromoter_ID", smodel.Related_JointPromoter_ID);
            cmd.Parameters.AddWithValue("p_Related_JointPromoterType", smodel.Related_JointPromoterType);

            cmd.Parameters.AddWithValue("p_LitigationsRelated_JointPromoterName", string.IsNullOrEmpty(smodel.LitigationsRelated_JointPromoterName) ? "" : smodel.LitigationsRelated_JointPromoterName);
            cmd.Parameters.AddWithValue("p_LitigationsRelated_ProjectName", string.IsNullOrEmpty(smodel.LitigationsRelated_ProjectName) ? "" : smodel.LitigationsRelated_ProjectName);

            cmd.Parameters.AddWithValue("p_Project_Name", string.IsNullOrEmpty(smodel.Project_Name) ? "" : smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_Project_Type", string.IsNullOrEmpty(smodel.Project_Type) ? "" : smodel.Project_Type);
            cmd.Parameters.AddWithValue("p_Project_Status", string.IsNullOrEmpty(smodel.Project_Status) ? "" : smodel.Project_Status);
            cmd.Parameters.AddWithValue("p_Project_AreaConstructed", smodel.Project_AreaConstructed);
            cmd.Parameters.AddWithValue("p_ProjectStartDate", DateTime.Now); //static data
            cmd.Parameters.AddWithValue("p_Case_Title", string.IsNullOrEmpty(smodel.Case_Title) ? "NA" : smodel.Case_Title);
            cmd.Parameters.AddWithValue("p_Case_Number", string.IsNullOrEmpty(smodel.Case_Number) ? "NA" : smodel.Case_Number);
            cmd.Parameters.AddWithValue("p_Authority_ForumName_CasePendingResolved", string.IsNullOrEmpty(smodel.Authority_ForumName_CasePendingResolved) ? "" : smodel.Authority_ForumName_CasePendingResolved);

            cmd.Parameters.AddWithValue("p_JointPromoter_LitigationsFlag", smodel.JointPromoter_LitigationsFlag);
            cmd.Parameters.AddWithValue("p_JointPromoter_LitigationsCondition", smodel.JointPromoter_LitigationsCondition);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 1);
            cmd.Parameters.AddWithValue("p_Flag", 0);
            cmd.Parameters.AddWithValue("p_Created_By", string.IsNullOrEmpty(userName) ? "sysadmin" : userName);
            cmd.Parameters.AddWithValue("p_Created_On", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Modify_By", string.IsNullOrEmpty(userName) ? "sysadmin" : userName);
            cmd.Parameters.AddWithValue("p_Modified_On", DateTime.Now);

            cmd.Parameters.AddWithValue("p_Extra1", string.IsNullOrEmpty(smodel.Extra1) ? "" : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", string.IsNullOrEmpty(smodel.Extra2) ? "" : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", string.IsNullOrEmpty(smodel.Extra3) ? "" : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", string.IsNullOrEmpty(smodel.Extra4) ? "" : smodel.Extra4);

            MySqlParameter RetParam = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            RetParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RetParam);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int IntReturn = Convert.ToInt32(RetParam.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_JointPromoter_TrackLitigations> Display_JointPromoter_TrackRecord_LitigationsByID(Int64 PromoterID, Int64 JointPromoterID, Int32 JointPromoterType, Int32 Flag, string UserRole, string UserID)
        {
            connection();
            List<ClsPrp_JointPromoter_TrackLitigations> PromoterList = new List<ClsPrp_JointPromoter_TrackLitigations>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_TrackRecord_Litigations_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_JointPromoterID", JointPromoterID);
            cmd.Parameters.AddWithValue("p_JointPromoterType", JointPromoterType);
            cmd.Parameters.AddWithValue("p_Flag", Flag);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterList.Add(
                    new ClsPrp_JointPromoter_TrackLitigations
                    {
                        JointPromoter_Litigations_IndexID = Convert.ToInt64(dr["JointPromoter_Litigations_IndexID"]),
                        JointPromoter_Litigation_ID = Convert.ToInt64(dr["JointPromoter_Litigation_ID"]),

                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_PromoterType = Convert.ToInt32(dr["Related_PromoterType"]),

                        Related_JointPromoter_ID = Convert.ToInt64(dr["Related_JointPromoter_ID"]),
                        Related_JointPromoterType = Convert.ToInt32(dr["Related_JointPromoterType"]),

                        LitigationsRelated_JointPromoterName = Convert.ToString(dr["LitigationsRelated_JointPromoterName"]),
                        LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
                        Project_Name = Convert.ToString(dr["Project_Name"]),
                        Project_Type = Convert.ToString(dr["Project_Type"]),
                        Project_Status = Convert.ToString(dr["Project_Status"]),
                        Project_AreaConstructed = Convert.ToDouble(dr["Project_AreaConstructed"]),

                        Case_Title = Convert.ToString(dr["Case_Title"]),
                        Case_Number = Convert.ToString(dr["Case_Number"]),
                        Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),

                        JointPromoter_LitigationsFlag = Convert.ToInt32(dr["JointPromoter_LitigationsFlag"]),
                        JointPromoter_LitigationsCondition = Convert.ToInt32(dr["JointPromoter_LitigationsCondition"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        Flag = Convert.ToInt32(dr["Flag"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        Created_On = Convert.ToDateTime(dr["Created_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),
                        Modified_On = Convert.ToDateTime(dr["Modified_On"]),

                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Extra4 = Convert.ToString(dr["Extra4"]),
                    });
            }
            return PromoterList;
        }        
        public List<ClsPrp_JointPromoter_TrackLitigations> Display_ByFilterID_JointPromoter_TrackRecord_LitigationsDetail(Int64 PromoterAppID, Int64 JointPromoter_ApplicationID, int JointPromoter_TypeFlag, Int64 JointPromoter_Litigation_IndexID, Int64 JointPromoter_Litigation_ID, string UserRole, string UserID)
        {
            List<ClsPrp_JointPromoter_TrackLitigations> PromoterList = new List<ClsPrp_JointPromoter_TrackLitigations>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_TrackRecord_Litigations_ByFilterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterAppID);
            cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ApplicationID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_TypeFlag);
            cmd.Parameters.AddWithValue("p_JointPromoter_Litigation_IndexID", JointPromoter_Litigation_IndexID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Litigation_ID", JointPromoter_Litigation_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterList.Add(
                   new ClsPrp_JointPromoter_TrackLitigations
                   {
                       JointPromoter_Litigations_IndexID = Convert.ToInt64(dr["JointPromoter_Litigations_IndexID"]),
                       JointPromoter_Litigation_ID = Convert.ToInt64(dr["JointPromoter_Litigation_ID"]),

                       Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                       Related_PromoterType = Convert.ToInt32(dr["Related_PromoterType"]),

                       Related_JointPromoter_ID = Convert.ToInt64(dr["Related_JointPromoter_ID"]),
                       Related_JointPromoterType = Convert.ToInt32(dr["Related_JointPromoterType"]),

                       LitigationsRelated_JointPromoterName = Convert.ToString(dr["LitigationsRelated_JointPromoterName"]),
                       LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
                       Project_Name = Convert.ToString(dr["Project_Name"]),
                       Project_Type = Convert.ToString(dr["Project_Type"]),
                       Project_Status = Convert.ToString(dr["Project_Status"]),
                       Project_AreaConstructed = Convert.ToDouble(dr["Project_AreaConstructed"]),

                       Case_Title = Convert.ToString(dr["Case_Title"]),
                       Case_Number = Convert.ToString(dr["Case_Number"]),
                       Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),

                       JointPromoter_LitigationsFlag = Convert.ToInt32(dr["JointPromoter_LitigationsFlag"]),
                       JointPromoter_LitigationsCondition = Convert.ToInt32(dr["JointPromoter_LitigationsCondition"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       IsLock = Convert.ToInt32(dr["IsLock"]),
                       IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                       Flag = Convert.ToInt32(dr["Flag"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),

                       Extra1 = Convert.ToString(dr["Extra1"]),
                       Extra2 = Convert.ToString(dr["Extra2"]),
                       Extra3 = Convert.ToString(dr["Extra3"]),
                       Extra4 = Convert.ToString(dr["Extra4"]),
                   });
            }
            return PromoterList;
        }

        public bool Delete_JointPromoter_TrackRecord_Litigations(Int64 PromoterAppID, int PromoterTypeFlag, Int64 jointPromoter_ApplicationID, Int64 JointPromoter_Litigations_IndexID, Int64 JointPromoter_Litigations_ID, string UserRole, string UserID)
        {
            int i = 0;
            connection();
            con.Open();
            using (MySqlTransaction transaction = con.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("Delete_Rera_JointPromoter_TrackRecord_Litigations", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterAppID);
                    cmd.Parameters.AddWithValue("p_Promoter_Type", PromoterTypeFlag);
                    cmd.Parameters.AddWithValue("p_JointPromoter_ID", jointPromoter_ApplicationID);
                    cmd.Parameters.AddWithValue("p_JointPromoter_LitigationsIndexID", JointPromoter_Litigations_IndexID);
                    cmd.Parameters.AddWithValue("p_JointPromoter_LitigationsID", JointPromoter_Litigations_ID);
                    cmd.Parameters.AddWithValue("p_UserRole", UserRole);
                    cmd.Parameters.AddWithValue("p_UserID", UserID);
                    
                    i = cmd.ExecuteNonQuery();
                    // Commit transaction, if no errors                                        
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    string strRET = ex.Message;
                    // Rollback transaction, if errors
                    transaction.Rollback();                    
                }
            }
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_OngoingProjectLFiveYears> Display_Master_ByFilterID_LitigationsRelatedProjectID_ongoingProject(Int64 Project_ID, Int64 Promoter_ID)
        {            
            List<ClsPrp_OngoingProjectLFiveYears> ProjectList = new List<ClsPrp_OngoingProjectLFiveYears>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_ExperinceProjectMaster_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                    new ClsPrp_OngoingProjectLFiveYears
                    {
                        Application_id = Convert.ToInt64(dr["RelatedProject_ID"]),
                        Id = Convert.ToInt32(dr["RelatedPromoter_ID"]),
                        ProjectType = Convert.ToString(dr["ProjectType"]),
                        ProjectStatus = Convert.ToString(dr["ProjectStatus"]),
                        AreaConUProject = Convert.ToDouble(dr["AreaConUProject"]),
                        ProjectStartDate = Convert.ToDateTime(dr["ProjectStartDate"]),
                    });
            }
            return ProjectList;
        }

    }
}
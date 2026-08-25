using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_Promoter_Litigations
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        // Add Litigations Detail
        public bool AddLitigationsDetail(ClsPrp_Promoter_Litigations smodel, Int64 Promoter_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Promoter_Litigation", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_LitigationsRelated_ProjectName", smodel.LitigationsRelated_ProjectName);
            cmd.Parameters.AddWithValue("p_Case_Title", smodel.Case_Title);
            cmd.Parameters.AddWithValue("p_Case_Number", smodel.Case_Number); 
            cmd.Parameters.AddWithValue("p_Authority_ForumName_CasePendingResolved", smodel.Authority_ForumName_CasePendingResolved);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_Created_By", "CreatedBy");
            cmd.Parameters.AddWithValue("p_Modify_By", "ModifyBy");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// update litigations   
        ///  public bool UpdateLitigationsDetail(ClsPrp_Promoter_Litigations smodel,Int64 Promoter_ID, Int64 Promoter_Litigations_IndexID, Int64? Promoter_Litigation_ID)

        public bool UpdateLitigationsDetail(ClsPrp_Promoter_Litigations smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter_Litigation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_Litigations_IndexID", smodel.Promoter_Litigations_IndexID);
            cmd.Parameters.AddWithValue("p_Promoter_Litigation_ID", smodel.Promoter_Litigation_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", smodel.Promoter_ID);

            cmd.Parameters.AddWithValue("p_LitigationsRelated_ProjectName", smodel.LitigationsRelated_ProjectName);
            cmd.Parameters.AddWithValue("p_Case_Title", smodel.Case_Title);
            cmd.Parameters.AddWithValue("p_Case_Number", smodel.Case_Number);
            cmd.Parameters.AddWithValue("p_Authority_ForumName_CasePendingResolved", smodel.Authority_ForumName_CasePendingResolved);

            cmd.Parameters.AddWithValue("p_IsDraft", 0); //smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_Created_By", "CreatedBy");
            cmd.Parameters.AddWithValue("p_Modify_By", "Modify_By");

            //cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1);
            //cmd.Parameters.AddWithValue("p_Extra2", smodel.Extra2);
            //cmd.Parameters.AddWithValue("p_Extra3", smodel.Extra3);
            //cmd.Parameters.AddWithValue("p_Extra4", smodel.Extra4);

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
        /// <summary>
        /// Display method by Application id, id
        /// </summary>
        /// <param name="Application_id"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ClsPrp_Promoter_Litigations> DisplayLitigationn( Int64 Promoter_ID, Int64 Promoter_Litigations_IndexID)
        {
            List<ClsPrp_Promoter_Litigations> ProjectFivelist = new List<ClsPrp_Promoter_Litigations>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_LitigationByApplicationIDandID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_Litigations_IndexID", Promoter_Litigations_IndexID);
              //cmd.Parameters.AddWithValue("p_Promoter_Litigation_ID", Promoter_Litigation_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);

            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_Promoter_Litigations clspro = new ClsPrp_Promoter_Litigations();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                   new ClsPrp_Promoter_Litigations
                   {
                       Promoter_Litigations_IndexID = Convert.ToInt32(dr["Promoter_Litigations_IndexID"]),
                       Promoter_Litigation_ID = Convert.ToInt64(dr["Promoter_Litigation_ID"]),
                       Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                       //LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
                       LitigationsRelated_ProjectName = Convert.ToString(dr["Projectname"]),
                       Case_Title = Convert.ToString(dr["Case_Title"]),
                       Case_Number = Convert.ToString(dr["Case_Number"]),
                       Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),
                       //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                       //ModifyBy = Convert.ToString(dr["ModifyBy"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),

                   });

            }


            return ProjectFivelist;
            
            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }

        /// <summary>
        /// Display method by Application id only
        /// </summary>
        /// <returns></returns>
        public List<ClsPrp_Promoter_Litigations> DisplayLitigationn(Int64 Promoter_ID)
        {
            List<ClsPrp_Promoter_Litigations> ProjectFivelist = new List<ClsPrp_Promoter_Litigations>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_LitigationApplicationID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);

            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            ClsPrp_Promoter_Litigations clspro = new ClsPrp_Promoter_Litigations();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                   new ClsPrp_Promoter_Litigations
                   {
                       Promoter_Litigations_IndexID = Convert.ToInt32(dr["Promoter_Litigations_IndexID"]),
                       Promoter_Litigation_ID = Convert.ToInt64(dr["Promoter_Litigation_ID"]),
                       Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                       //LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
                       LitigationsRelated_ProjectName = Convert.ToString(dr["Projectname"]),
                       Case_Title = Convert.ToString(dr["Case_Title"]),
                       Case_Number = Convert.ToString(dr["Case_Number"]),
                       Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),
                       //IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                       //ModifyBy = Convert.ToString(dr["ModifyBy"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),

                   });

            }


            return ProjectFivelist;

            ////int i = cmd.ExecuteNonQuery();
            ////con.Close();

            //// if (i >= 1)
            ////    return true;
            //// else
            ////     return false;
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="Application_id"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete_Litigation(Int64 Application_id, Int64 Id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Promoter_Litigation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Application_id);
            cmd.Parameters.AddWithValue("p_Promoter_Litigations_IndexID", Id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

       
    }
    }
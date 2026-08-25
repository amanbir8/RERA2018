using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_Project_Litigations
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************
        public bool Add_Project_Type_Litigations(ClsPrp_Project_Litigations smodel) //, string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_Litigations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            // cmd.Parameters.AddWithValue("p_p_ProjectLitigations_ID", smodel.ProjectLitigations_ID);
            cmd.Parameters.AddWithValue("p_p_LitigationsRelated_ProjectRegistration_ID", smodel.LitigationsRelated_ProjectRegistration_ID);//, smodel.LitigationsRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_Case_Title", smodel.Case_Title);
            cmd.Parameters.AddWithValue("p_p_Case_Number", smodel.Case_Number);
            cmd.Parameters.AddWithValue("p_p_AuthorityForumName_CasePendingResolved", smodel.AuthorityForumName_CasePendingResolved);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_p_A_column", "");
            cmd.Parameters.AddWithValue("p_p_B_column", "");
            cmd.Parameters.AddWithValue("p_p_C_column", "");

            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            //con.Close();
            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_Project_Type_Litigations(ClsPrp_Project_Litigations smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_Litigations", con);
            cmd.CommandType = CommandType.StoredProcedure;


            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectLitigations_IndexID", smodel.ProjectLitigations_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectLitigations_ID", smodel.ProjectLitigations_ID);
            cmd.Parameters.AddWithValue("p_p_LitigationsRelated_ProjectRegistration_ID", smodel.LitigationsRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_Case_Title", smodel.Case_Title);
            cmd.Parameters.AddWithValue("p_p_Case_Number", smodel.Case_Number);
            cmd.Parameters.AddWithValue("p_p_AuthorityForumName_CasePendingResolved", smodel.AuthorityForumName_CasePendingResolved);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");            

            cmd.Parameters.AddWithValue("p_p_A_column", "");
            cmd.Parameters.AddWithValue("p_p_B_column", "");
            cmd.Parameters.AddWithValue("p_p_C_column", "");

            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            //cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "p_ModifyBy");
            //  cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_Project_Litigations> Display_Project_Litigations(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_Litigations> ProjectFivelist1 = new List<ClsPrp_Project_Litigations>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Litigations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_Litigations
                       {
                           ProjectLitigations_IndexID = Convert.ToInt64(dr["ProjectLitigations_IndexID"]),
                           ProjectLitigations_ID = Convert.ToInt64(dr["ProjectLitigations_ID"]),
                           LitigationsRelated_ProjectRegistration_ID = Convert.ToInt64(dr["LitigationsRelated_ProjectRegistration_ID"]),
                           Case_Title = Convert.ToString(dr["Case_Title"]),
                           Case_Number = Convert.ToString(dr["Case_Number"]),
                           AuthorityForumName_CasePendingResolved = Convert.ToString(dr["AuthorityForumName_CasePendingResolved"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }
        public List<ClsPrp_Project_Litigations> Display_Project_LitigationsID(Int64 ProjectLitigations_IndexID, Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_Litigations> ProjectFivelist1 = new List<ClsPrp_Project_Litigations>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_LitigationsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectLitigations_IndexID", ProjectLitigations_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_Litigations
                       {
                           ProjectLitigations_IndexID = Convert.ToInt64(dr["ProjectLitigations_IndexID"]),
                           ProjectLitigations_ID = Convert.ToInt64(dr["ProjectLitigations_ID"]),
                           LitigationsRelated_ProjectRegistration_ID = Convert.ToInt64(dr["LitigationsRelated_ProjectRegistration_ID"]),
                           Case_Title = Convert.ToString(dr["Case_Title"]),
                           Case_Number = Convert.ToString(dr["Case_Number"]),
                           AuthorityForumName_CasePendingResolved = Convert.ToString(dr["AuthorityForumName_CasePendingResolved"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }

        public bool Delete_Project_Litigations(Int64 ProjectLitigations_IndexID, Int64 ProjectRegistration_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_Litigations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectLitigations_IndexID", ProjectLitigations_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
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
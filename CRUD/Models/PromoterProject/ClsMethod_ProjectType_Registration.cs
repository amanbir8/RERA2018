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
    public class ClsMethod_ProjectType_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************
        public void Add_Project_Type_Registration(Int64 projectid, string ProjectType_Code, string ProjectType_Name, string ProjectType_SubType_Code, string ProjectType_SubType_Name)// string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_ProjectType_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectTypeRelated_ProjectRegistration_ID", projectid);
            cmd.Parameters.AddWithValue("p_p_ProjectType_Code", ProjectType_Code);
            cmd.Parameters.AddWithValue("p_p_ProjectType_Name", ProjectType_Name);
            cmd.Parameters.AddWithValue("p_p_ProjectType_SubType_Code", ProjectType_SubType_Code);
            cmd.Parameters.AddWithValue("p_p_ProjectType_SubType_Name", ProjectType_SubType_Name);

            cmd.Parameters.AddWithValue("p_p_IsDraft", "0");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
        }

        public bool Update_Project_Type_Registration(Int64 projectid, string ProjectType_Code, string ProjectType_Name, string ProjectType_SubType_Code, string ProjectType_SubType_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_ProjectType_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectTypeRelated_ProjectRegistration_ID", projectid);
            cmd.Parameters.AddWithValue("p_p_ProjectType_Code", ProjectType_Code);
            cmd.Parameters.AddWithValue("p_p_ProjectType_Name", ProjectType_Name);
            cmd.Parameters.AddWithValue("p_p_ProjectType_SubType_Code", ProjectType_SubType_Code);
            cmd.Parameters.AddWithValue("p_p_ProjectType_SubType_Name", ProjectType_SubType_Name);

            cmd.Parameters.AddWithValue("p_p_IsDraft", "0");// smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); // smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By"); // smodel.ModifyBy);

            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_ProjectType_Registration> Display_Project_Registration(Int64 ProjectRegistration_ID)
        {


            List<ClsPrp_ProjectType_Registration> ProjectFivelist1 = new List<ClsPrp_ProjectType_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_OtherMemberDetailsByApplicationID", con);
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
                       new ClsPrp_ProjectType_Registration
                       {
                           ProjectType_Registration_ID = Convert.ToInt64(dr["ProjectType_Registration_ID"]),
                           ProjectTypeRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectTypeRelated_ProjectRegistration_ID"]),
                           ProjectType_Code = Convert.ToString(dr["ProjectType_Code"]),
                           ProjectType_Name = Convert.ToString(dr["ProjectType_Name"]),
                           ProjectType_SubType_Code = Convert.ToString(dr["ProjectType_SubType_Code"]),
                           ProjectType_SubType_Name = Convert.ToString(dr["ProjectType_SubType_Name"]),
                           //IsDraft = Convert.ToString(dr["IsDraft"]),
                           //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           //CreatedOn = Convert.ToString(dr["CreatedOn"]),
                           //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           //ModifyOn = Convert.ToString(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }

    }
}
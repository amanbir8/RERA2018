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
    public class ClsMethod_Project_KhasraAreaDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_KhasraAreaDetails(ClsPrp_Project_KhasraAreaDetails smodel)//, Int64 Project_id)//string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_KhasraAreaDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_ProjectKhasraArea_IndexID", smodel.ProjectKhasraArea_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectKhasraArea_ID", smodel.ProjectKhasraArea_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectKhasraAreaRelated_ProjectRegistration_ID", smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID);//smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_KhasraNumber_ProposedLand_TobeDeveloped", smodel.KhasraNumber_ProposedLand_TobeDeveloped);
            cmd.Parameters.AddWithValue("p_p_Area_ProposedLand_EachKhasraNumber", smodel.Area_ProposedLand_EachKhasraNumber);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            // cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
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

        public bool Update_Project_KhasraAreaDetails(ClsPrp_Project_KhasraAreaDetails smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_KhasraAreaDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectKhasraArea_IndexID", smodel.ProjectKhasraArea_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectKhasraArea_ID", smodel.ProjectKhasraArea_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectKhasraAreaRelated_ProjectRegistration_ID", smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_KhasraNumber_ProposedLand_TobeDeveloped", smodel.KhasraNumber_ProposedLand_TobeDeveloped);
            cmd.Parameters.AddWithValue("p_p_Area_ProposedLand_EachKhasraNumber", smodel.Area_ProposedLand_EachKhasraNumber);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "p_CreatedBy");        
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "p_ModifyBy");

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

        public List<ClsPrp_Project_KhasraAreaDetails> Display_Project_KhasraAreaDetails(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_Project_KhasraAreaDetails> ProjectFivelist1 = new List<ClsPrp_Project_KhasraAreaDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_KhasraAreaDetails", con);
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
                       new ClsPrp_Project_KhasraAreaDetails
                       {
                           ProjectKhasraArea_IndexID = Convert.ToInt64(dr["ProjectKhasraArea_IndexID"]),
                           ProjectKhasraArea_ID = Convert.ToInt64(dr["ProjectKhasraArea_ID"]),
                           ProjectKhasraAreaRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectKhasraAreaRelated_ProjectRegistration_ID"]),
                           KhasraNumber_ProposedLand_TobeDeveloped = Convert.ToString(dr["KhasraNumber_ProposedLand_TobeDeveloped"]),
                           Area_ProposedLand_EachKhasraNumber = Convert.ToDouble(dr["Area_ProposedLand_EachKhasraNumber"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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

        //ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID
        public List<ClsPrp_Project_KhasraAreaDetails> Display_Project_KhasraAreaDetailsById(Int64 ProjectKhasra_IndexID,Int64 ProjectKhasraRelated_ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_KhasraAreaDetails> ProjectFivelist1 = new List<ClsPrp_Project_KhasraAreaDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_KhasraAreaDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectKhasraRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectKhasra_IndexID", ProjectKhasra_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_KhasraAreaDetails
                       {
                           ProjectKhasraArea_IndexID = Convert.ToInt64(dr["ProjectKhasraArea_IndexID"]),
                           ProjectKhasraArea_ID = Convert.ToInt64(dr["ProjectKhasraArea_ID"]),
                           ProjectKhasraAreaRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectKhasraAreaRelated_ProjectRegistration_ID"]),
                           KhasraNumber_ProposedLand_TobeDeveloped = Convert.ToString(dr["KhasraNumber_ProposedLand_TobeDeveloped"]),
                           Area_ProposedLand_EachKhasraNumber = Convert.ToDouble(dr["Area_ProposedLand_EachKhasraNumber"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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
        public bool Delete_Project_KhasraAreaDetailsById(Int64 ProjectKhasra_IndexID, Int64 ProjectKhasraRelated_ProjectRegistration_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_KhasraAreaDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectKhasraRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectKhasra_IndexID", ProjectKhasra_IndexID);
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
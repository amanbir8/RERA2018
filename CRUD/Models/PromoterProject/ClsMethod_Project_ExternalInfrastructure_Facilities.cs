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
    public class ClsMethod_Project_ExternalInfrastructure_Facilities
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_ExternalInfrastructure_Facilities(ClsPrp_Project_ExternalInfrastructure_Facilities smodel, Int64 Project_id)// string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_ExternalInfrastructure_Facilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_ProjectInfrastructureFacilities_IndexID", Project_id);// smodel.ProjectInfrastructureFacilities_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectInfrastructureFacilities_ID", smodel.ProjectInfrastructureFacilities_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID", smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_InternalInfrastructureFacilities_Name", smodel.InternalInfrastructureFacilities_Name);

            cmd.Parameters.AddWithValue("p_p_InternalInfrastructureFacilities_Type",   smodel.InternalInfrastructureFacilities_Type);
            cmd.Parameters.AddWithValue("p_p_ExternalAgency_LocalAuthority_Name",  String.IsNullOrEmpty(smodel.ExternalAgency_LocalAuthority_Name) ? "": smodel.ExternalAgency_LocalAuthority_Name);

            cmd.Parameters.AddWithValue("p_p_Is_InternalInfrastructureFacilitiesApplicable", "NA");
            cmd.Parameters.AddWithValue("p_p_WorkProgress_Percentage", smodel.WorkProgress_Percentage);
            cmd.Parameters.AddWithValue("p_p_InternalInfrastructureFacilities_Details", smodel.InternalInfrastructureFacilities_Details);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            //cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);
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

        public bool Update_Project_ExternalInfrastructure_Facilities(ClsPrp_Project_ExternalInfrastructure_Facilities smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_ExternalInfrastructure_Facilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectInfrastructureFacilities_IndexID", smodel.ProjectInfrastructureFacilities_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectInfrastructureFacilities_ID", smodel.ProjectInfrastructureFacilities_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID", smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_InternalInfrastructureFacilities_Name", smodel.InternalInfrastructureFacilities_Name);

            cmd.Parameters.AddWithValue("p_p_InternalInfrastructureFacilities_Type",  smodel.InternalInfrastructureFacilities_Type);
            cmd.Parameters.AddWithValue("p_p_ExternalAgency_LocalAuthority_Name", String.IsNullOrEmpty(smodel.ExternalAgency_LocalAuthority_Name) ? "" : smodel.ExternalAgency_LocalAuthority_Name);

            cmd.Parameters.AddWithValue("p_p_Is_InternalInfrastructureFacilitiesApplicable", "NA");
            cmd.Parameters.AddWithValue("p_p_WorkProgress_Percentage", smodel.WorkProgress_Percentage);
            cmd.Parameters.AddWithValue("p_p_InternalInfrastructureFacilities_Details", smodel.InternalInfrastructureFacilities_Details);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            //cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");
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

        public List<ClsPrp_Project_ExternalInfrastructure_Facilities> Display_Project_ExternalInfrastructure_Facilities(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_Project_ExternalInfrastructure_Facilities> ProjectFivelist1 = new List<ClsPrp_Project_ExternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ExternalInfrastructure_Facilities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ExternalInfrastructure_Facilities
                       {
                           ProjectInfrastructureFacilities_IndexID = Convert.ToInt64(dr["ProjectInfrastructureFacilities_IndexID"]),
                           ProjectInfrastructureFacilities_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilities_ID"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           InternalInfrastructureFacilities_Name = Convert.ToString(dr["InternalInfrastructureFacilities_Name"]),
                           InternalInfrastructureFacilities_Type = Convert.ToString(dr["InternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),
                           WorkProgress_Percentage = Convert.ToDecimal(dr["WorkProgress_Percentage"]),
                           InternalInfrastructureFacilities_Details = Convert.ToString(dr["InternalInfrastructureFacilities_Details"]),
                           //Remarks_IfAny= Convert.ToString(dr["Remarks_IfAny,"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),


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

        public List<ClsPrp_Project_ExternalInfrastructure_Facilities> Display_Project_ExternalInfrastructure_Facilities(Int64 ProjectRegistration_ID, Int64 Id)
        {

            connection();
            List<ClsPrp_Project_ExternalInfrastructure_Facilities> ProjectFivelist1 = new List<ClsPrp_Project_ExternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ExternalInfrastructure_FacilitiesID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructureFacilities_IndexID", Id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ExternalInfrastructure_Facilities
                       {
                           ProjectInfrastructureFacilities_IndexID = Convert.ToInt64(dr["ProjectInfrastructureFacilities_IndexID"]),
                           ProjectInfrastructureFacilities_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilities_ID"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           InternalInfrastructureFacilities_Name = Convert.ToString(dr["InternalInfrastructureFacilities_Name"]),
                           InternalInfrastructureFacilities_Type = Convert.ToString(dr["InternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),
                           WorkProgress_Percentage = Convert.ToDecimal(dr["WorkProgress_Percentage"]),
                           InternalInfrastructureFacilities_Details = Convert.ToString(dr["InternalInfrastructureFacilities_Details"]),
                           //Remarks_IfAny= Convert.ToString(dr["Remarks_IfAny,"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),


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

        public bool Delete_ExternalInfrastructure_Facilities(Int64 ProjectInfrastructure_ProjectRegistration_ID, Int64 ProjectInfrastructureFacilities_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_ExternalInfrastructure_Facilities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectInfrastructure_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructureFacilities_IndexID", ProjectInfrastructureFacilities_IndexID);
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
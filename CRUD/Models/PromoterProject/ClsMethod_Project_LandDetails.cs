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
    public class ClsMethod_Project_LandDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************


        public bool Add_Project_Landdetails(ClsPrp_Project_LandDetails smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_LandDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_PutProjectLand_ID", smodel.PutProjectLand_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectLandRelated_ProjectRegistration_ID", smodel.ProjectLandRelated_ProjectRegistration_ID);// Project_id);// smodel.ProjectLandRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_TobeDeveloped_Area_Total", smodel.ProposedLand_TobeDeveloped_Area_Total);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_ResidentialGroupHousing", smodel.ProposedLand_Area_ResidentialGroupHousing);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_ResidentialPlotted", smodel.ProposedLand_Area_ResidentialPlotted);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_Commercial", smodel.ProposedLand_Area_Commercial);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_Industrial", smodel.ProposedLand_Area_Industrial);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_A_column", smodel.ProposedLand_Area_A_column);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_B_column", smodel.ProposedLand_Area_B_column);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_C_column", smodel.ProposedLand_Area_C_column);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_D_column", 0);//smodel.ProposedLand_Area_D_column);
            cmd.Parameters.AddWithValue("p_p_Name_of_Villages", smodel.Name_of_Villages);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_TobeDeveloped_TotalOpenArea", smodel.ProposedLand_TobeDeveloped_TotalOpenArea);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_TobeDeveloped_TotalCoveredArea", smodel.ProposedLand_TobeDeveloped_TotalCoveredArea);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_StartPoint_Longitude", smodel.ProposedProjectLand_StartPoint_Longitude);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_StartPoint_Latitude", smodel.ProposedProjectLand_StartPoint_Latitude);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_EndPoint_Longitude", smodel.ProposedProjectLand_EndPoint_Longitude);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_EndPoint_Latitude", smodel.ProposedProjectLand_EndPoint_Latitude);
            cmd.Parameters.AddWithValue("p_p_IsProjectLand_Status_OwnedByPromoter", String.IsNullOrEmpty(smodel.IsProjectLand_Status_OwnedByPromoter) ? "" : smodel.IsProjectLand_Status_OwnedByPromoter); //smodel.IsProjectLand_Status_OwnedByPromoter);//Collect both Owned(Y) & Not Owned(N)
            cmd.Parameters.AddWithValue("p_p_IsProjectLand_Status_NotOwnedByPromoter", "NA");//smodel.IsProjectLand_Status_NotOwnedByPromoter);
            cmd.Parameters.AddWithValue("p_p_IsLandEncumbrances_IfAny", String.IsNullOrEmpty(smodel.IsLandEncumbrances_IfAny) ? "" : smodel.IsLandEncumbrances_IfAny); //smodel.IsLandEncumbrances_IfAny);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", ""); //smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", ""); //smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_Project_Landdetails(ClsPrp_Project_LandDetails smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_LandDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectLand_IndexID", smodel.ProjectLand_IndexID);

            cmd.Parameters.AddWithValue("p_p_ProjectLand_ID", smodel.ProjectLand_ID);

            cmd.Parameters.AddWithValue("p_p_ProjectLandRelated_ProjectRegistration_ID", smodel.ProjectLandRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_TobeDeveloped_Area_Total", smodel.ProposedLand_TobeDeveloped_Area_Total);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_ResidentialGroupHousing", smodel.ProposedLand_Area_ResidentialGroupHousing);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_ResidentialPlotted", smodel.ProposedLand_Area_ResidentialPlotted);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_Commercial", smodel.ProposedLand_Area_Commercial);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_Industrial", smodel.ProposedLand_Area_Industrial);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_A_column", smodel.ProposedLand_Area_A_column);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_B_column", smodel.ProposedLand_Area_B_column);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_C_column", smodel.ProposedLand_Area_C_column);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_Area_D_column", 0);//smodel.ProposedLand_Area_D_column);
            cmd.Parameters.AddWithValue("p_p_Name_of_Villages", smodel.Name_of_Villages);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_TobeDeveloped_TotalOpenArea", smodel.ProposedLand_TobeDeveloped_TotalOpenArea);
            cmd.Parameters.AddWithValue("p_p_ProposedLand_TobeDeveloped_TotalCoveredArea", smodel.ProposedLand_TobeDeveloped_TotalCoveredArea);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_StartPoint_Longitude", smodel.ProposedProjectLand_StartPoint_Longitude);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_StartPoint_Latitude", smodel.ProposedProjectLand_StartPoint_Latitude);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_EndPoint_Longitude", smodel.ProposedProjectLand_EndPoint_Longitude);
            cmd.Parameters.AddWithValue("p_p_ProposedProjectLand_EndPoint_Latitude", smodel.ProposedProjectLand_EndPoint_Latitude);
            cmd.Parameters.AddWithValue("p_p_IsProjectLand_Status_OwnedByPromoter", String.IsNullOrEmpty(smodel.IsProjectLand_Status_OwnedByPromoter) ? "" : smodel.IsProjectLand_Status_OwnedByPromoter); //smodel.IsProjectLand_Status_OwnedByPromoter);//Collect both Owned(Y) & Not Owned(N)
            cmd.Parameters.AddWithValue("p_p_IsProjectLand_Status_NotOwnedByPromoter", "NA");//smodel.IsProjectLand_Status_NotOwnedByPromoter);
            cmd.Parameters.AddWithValue("p_p_IsLandEncumbrances_IfAny", String.IsNullOrEmpty(smodel.IsLandEncumbrances_IfAny) ? "" : smodel.IsLandEncumbrances_IfAny); //smodel.IsLandEncumbrances_IfAny);
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

        public List<ClsPrp_Project_LandDetails> Display_Project_Landdetails(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_LandDetails> ProjectFivelist1 = new List<ClsPrp_Project_LandDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Landdetails", con);
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
                       new ClsPrp_Project_LandDetails
                       {
                           ProjectLand_IndexID = Convert.ToInt64(dr["ProjectLand_IndexID"]),
                           ProjectLand_ID = Convert.ToInt64(dr["ProjectLand_ID"]),
                           ProjectLandRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectLandRelated_ProjectRegistration_ID"]),
                           ProposedLand_TobeDeveloped_Area_Total = Convert.ToDouble(dr["ProposedLand_TobeDeveloped_Area_Total"]),
                           ProposedLand_Area_ResidentialGroupHousing = Convert.ToDouble(dr["ProposedLand_Area_ResidentialGroupHousing"]),
                           ProposedLand_Area_ResidentialPlotted = Convert.ToDouble(dr["ProposedLand_Area_ResidentialPlotted"]),
                           ProposedLand_Area_Commercial = Convert.ToDouble(dr["ProposedLand_Area_Commercial"]),
                           ProposedLand_Area_Industrial = Convert.ToDouble(dr["ProposedLand_Area_Industrial"]),
                           ProposedLand_Area_A_column = Convert.ToDouble(dr["ProposedLand_Area_A_column"]),
                           ProposedLand_Area_B_column = Convert.ToDouble(dr["ProposedLand_Area_B_column"]),
                           ProposedLand_Area_C_column = Convert.ToDouble(dr["ProposedLand_Area_C_column"]),
                           ProposedLand_Area_D_column = Convert.ToDouble(dr["ProposedLand_Area_D_column"]),
                           Name_of_Villages = Convert.ToString(dr["Name_of_Villages"]),
                           ProposedLand_TobeDeveloped_TotalOpenArea = Convert.ToDouble(dr["ProposedLand_TobeDeveloped_TotalOpenArea"]),
                           ProposedLand_TobeDeveloped_TotalCoveredArea = Convert.ToDouble(dr["ProposedLand_TobeDeveloped_TotalCoveredArea"]),
                           ProposedProjectLand_StartPoint_Longitude = Convert.ToDouble(dr["ProposedProjectLand_StartPoint_Longitude"]),
                           ProposedProjectLand_StartPoint_Latitude = Convert.ToDouble(dr["ProposedProjectLand_StartPoint_Latitude"]),
                           ProposedProjectLand_EndPoint_Longitude = Convert.ToDouble(dr["ProposedProjectLand_EndPoint_Longitude"]),
                           ProposedProjectLand_EndPoint_Latitude = Convert.ToDouble(dr["ProposedProjectLand_EndPoint_Latitude"]),
                           IsProjectLand_Status_OwnedByPromoter = Convert.ToString(dr["IsProjectLand_Status_OwnedByPromoter"]),
                           IsProjectLand_Status_NotOwnedByPromoter = Convert.ToString(dr["IsProjectLand_Status_NotOwnedByPromoter"]),
                           IsLandEncumbrances_IfAny = Convert.ToString(dr["IsLandEncumbrances_IfAny"]),
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
        //p_ProjectLand_IndexID bigint,        p_ProjectConstructionRelated_ProjectRegistration_ID
        public List<ClsPrp_Project_LandDetails> Display_Project_LanddetailsIndexID(Int64? ProjectLand_IndexID, Int64? ProjectConstructionRelated_ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_LandDetails> ProjectFivelist1 = new List<ClsPrp_Project_LandDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_LanddetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectLand_IndexID", ProjectLand_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectConstructionRelated_ProjectRegistration_ID", ProjectConstructionRelated_ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_LandDetails
                       {   ProjectLand_IndexID= Convert.ToInt64(dr["ProjectLand_IndexID"]),
                           ProjectLand_ID = Convert.ToInt64(dr["ProjectLand_ID"]),
                ProjectLandRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectLandRelated_ProjectRegistration_ID"]),
                           ProposedLand_TobeDeveloped_Area_Total = Convert.ToDouble(dr["ProposedLand_TobeDeveloped_Area_Total"]),
                           ProposedLand_Area_ResidentialGroupHousing = Convert.ToDouble(dr["ProposedLand_Area_ResidentialGroupHousing"]),
                           ProposedLand_Area_ResidentialPlotted = Convert.ToDouble(dr["ProposedLand_Area_ResidentialPlotted"]),
                           ProposedLand_Area_Commercial = Convert.ToDouble(dr["ProposedLand_Area_Commercial"]),
                           ProposedLand_Area_Industrial = Convert.ToDouble(dr["ProposedLand_Area_Industrial"]),
                           ProposedLand_Area_A_column = Convert.ToDouble(dr["ProposedLand_Area_A_column"]),
                           ProposedLand_Area_B_column = Convert.ToDouble(dr["ProposedLand_Area_B_column"]),
                           ProposedLand_Area_C_column = Convert.ToDouble(dr["ProposedLand_Area_C_column"]),
                           ProposedLand_Area_D_column = Convert.ToDouble(dr["ProposedLand_Area_D_column"]),
                           Name_of_Villages = Convert.ToString(dr["Name_of_Villages"]),
                           ProposedLand_TobeDeveloped_TotalOpenArea = Convert.ToDouble(dr["ProposedLand_TobeDeveloped_TotalOpenArea"]),
                           ProposedLand_TobeDeveloped_TotalCoveredArea = Convert.ToDouble(dr["ProposedLand_TobeDeveloped_TotalCoveredArea"]),
                           ProposedProjectLand_StartPoint_Longitude = Convert.ToDouble(dr["ProposedProjectLand_StartPoint_Longitude"]),
                           ProposedProjectLand_StartPoint_Latitude = Convert.ToDouble(dr["ProposedProjectLand_StartPoint_Latitude"]),
                           ProposedProjectLand_EndPoint_Longitude = Convert.ToDouble(dr["ProposedProjectLand_EndPoint_Longitude"]),
                           ProposedProjectLand_EndPoint_Latitude = Convert.ToDouble(dr["ProposedProjectLand_EndPoint_Latitude"]),
                           IsProjectLand_Status_OwnedByPromoter = Convert.ToString(dr["IsProjectLand_Status_OwnedByPromoter"]),
                           IsProjectLand_Status_NotOwnedByPromoter = Convert.ToString(dr["IsProjectLand_Status_NotOwnedByPromoter"]),
                           IsLandEncumbrances_IfAny = Convert.ToString(dr["IsLandEncumbrances_IfAny"]),
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


        public bool Delete_Project_LandDetails(Int64? ProjectLand_IndexID, Int64? ProjectConstructionRelated_ProjectRegistration_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_LanddetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectLand_IndexID", ProjectLand_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectConstructionRelated_ProjectRegistration_ID", ProjectConstructionRelated_ProjectRegistration_ID);

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
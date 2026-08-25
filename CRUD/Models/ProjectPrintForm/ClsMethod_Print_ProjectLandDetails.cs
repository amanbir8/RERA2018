using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ProjectPrint
{
    public class ClsMethod_Print_ProjectLandDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_ProjectLandDetails> Display_Project_Landdetails(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_PrmProject_Print_ProjectLandDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectLandDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_LanddetailsForPrint", con);
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
                       new ClsPrp_PrmProject_Print_ProjectLandDetails
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
    }
}
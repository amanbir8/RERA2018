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
    public class ClsMethod_Print_Project_Updates_CIIEFP
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction> Display_AuthDesk_ProjectBuildingTowerBlock_Construction(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {
            connection();

            List<ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_BuildingTowerBlock_Construction_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction
                       {
                           ProjectConstruction_IndexID = Convert.ToInt64(dr["ProjectConstruction_IndexID"]),
                           ProjectConstruction_ID = Convert.ToInt64(dr["ProjectConstruction_ID"]),
                           ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectConstructionRelated_ProjectRegistration_ID"]),
                           BuildingTowerBlock_Name = Convert.ToString(dr["BuildingTowerBlock_Name"]),
                           Proposed_FloorPlotsNumber = Convert.ToInt32(dr["Proposed_FloorPlotsNumber"]),
                           CurrentlySanctioned_FloorPlotsNumber = Convert.ToInt32(dr["CurrentlySanctioned_FloorPlotsNumber"]),
                           Constructed_FloorsNumber = Convert.ToInt32(dr["Constructed_FloorsNumber"]),
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

        public List<ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory> Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {

            connection();
            List<ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_BuildingTowerBlock_Inventory_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInventory_ProjectRegistration_ID", ProjectRegistration_ID);                        
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory
                       {
                           ProjectInventory_IndexID = Convert.ToInt64(dr["ProjectInventory_IndexID"]),
                           ProjectInventory_ID = Convert.ToInt64(dr["ProjectInventory_ID"]),
                           ProjectInventoryRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInventoryRelated_ProjectRegistration_ID"]),
                           BuildingTowerBlock_Name = Convert.ToString(dr["BuildingTowerBlock_Name"]),
                           ApartmentShopPlot_Type = Convert.ToString(dr["ApartmentShopPlot_Type"]),
                           ApartmentShopPlot_CarpetArea = Convert.ToDouble(dr["ApartmentShopPlot_CarpetArea"]),
                           ApartmentShopPlot_ExclusiveOpenTerraceArea = Convert.ToDouble(dr["ApartmentShopPlot_ExclusiveOpenTerraceArea"]),
                           ApartmentShopPlot_ExclusiveBalconyVerandahArea = Convert.ToDouble(dr["ApartmentShopPlot_ExclusiveBalconyVerandahArea"]),
                           ApartmentShopPlot_AvailableforSaleNumber = Convert.ToInt32(dr["ApartmentShopPlot_AvailableforSaleNumber"]),
                           ApartmentShopPlot_AlreadySoldNumber = Convert.ToInt32(dr["ApartmentShopPlot_AlreadySoldNumber"]),
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

        public List<ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities> Display_AuthDesk_ProjectExternalInfrastructure_Facilities(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {

            connection();
            List<ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ExternalInfrastructure_Facilities_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistration_ID);            
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities
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

        public List<ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities> Display_AuthDesk_ProjectInternalInfrastructure_Facilities(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {

            connection();
            List<ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_InternalInfrastructure_Facilities_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInfrastructure_ProjectRegistration_ID", ProjectRegistration_ID);            
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities
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

        public List<ClsPrp_PrmProject_Print_ProjectParkingDetails> Display_AuthDesk_ProjectParkingDetails(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {

            connection();
            List<ClsPrp_PrmProject_Print_ProjectParkingDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ParkingDetails_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectParking_ProjectRegistration_ID", ProjectRegistration_ID);            
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectParkingDetails
                       {
                           ProjectParking_IndexID = Convert.ToInt64(dr["ProjectParking_IndexID"]),
                           ProjectParking_ID = Convert.ToInt64(dr["ProjectParking_ID"]),
                           ProjectParkingRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectParkingRelated_ProjectRegistration_ID"]),
                           ParkingType = Convert.ToString(dr["ParkingType"]),
                           ParkingSpace_AvailableforSale_Number = Convert.ToInt16(dr["ParkingSpace_AvailableforSale_Number"]),
                           ParkingSpace_Area_Total = Convert.ToDouble(dr["ParkingSpace_Area_Total"]),
                           ParkingSpace_BookedSold_Number = Convert.ToInt16(dr["ParkingSpace_BookedSold_Number"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
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

    }
}
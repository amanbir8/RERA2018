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
    public class ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory> Display_QUpdatesProject_ConstructionInventoryDetails(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory> ProjectFivelist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_BuildTowerBlock_Inventory_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdatesProject_ID);
            cmd.Parameters.AddWithValue("p_QUpdatesYear", QUpdatesYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdatesQuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                       new ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory
                       {
                           QUpdateProjectInventory_IndexID = Convert.ToInt64(dr["QUpdateProjectInventory_IndexID"]),
                           QUpdateProjectInventory_ID = Convert.ToInt64(dr["QUpdateProjectInventory_ID"]),
                           Related_ProjectInventoryIndexID = Convert.ToInt64(dr["Related_ProjectInventoryIndexID"]),
                           Related_ProjectInventory_ID = Convert.ToInt64(dr["Related_ProjectInventory_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           Related_ProjectRegistration_ID = Convert.ToInt64(dr["Related_ProjectRegistration_ID"]),
                           QUpdateInventory_Year = Convert.ToString(dr["QUpdateInventory_Year"]),
                           QUpdateInventory_QuarterName = Convert.ToString(dr["QUpdateInventory_QuarterName"]),

                           BuildingTowerBlock_Name = Convert.ToString(dr["BuildingTowerBlock_Name"]),
                           ApartmentShopPlot_Type = Convert.ToString(dr["ApartmentShopPlot_Type"]),
                           ApartmentShopPlot_InventoryType = Convert.ToString(dr["ApartmentShopPlot_InventoryType"]),

                           ApartmentShopPlot_CarpetArea = Convert.ToDouble(dr["ApartmentShopPlot_CarpetArea"]),
                           ApartmentShopPlot_ExclusiveOpenTerraceArea = Convert.ToDouble(dr["ApartmentShopPlot_ExclusiveOpenTerraceArea"]),
                           ApartmentShopPlot_ExclusiveBalconyVerandahArea = Convert.ToDouble(dr["ApartmentShopPlot_ExclusiveBalconyVerandahArea"]),

                           ApartmentShopPlot_NumberAvailableforSale = Convert.ToInt32(dr["ApartmentShopPlot_NumberAvailableforSale"]),
                           ApartmentShopPlot_NumberSoldUptoRegistration = Convert.ToInt32(dr["ApartmentShopPlot_NumberSoldUptoRegistration"]),
                           ApartmentShopPlot_NumberFloorsConstructedInQuarter = Convert.ToInt32(dr["ApartmentShopPlot_NumberFloorsConstructedInQuarter"]),
                           ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter = Convert.ToInt32(dr["ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter"]),
                           ApartmentShopPlot_NumberBookedInQuarter = Convert.ToInt32(dr["ApartmentShopPlot_NumberBookedInQuarter"]),
                           ApartmentShopPlot_NumberCanceledBookedInQuarter = Convert.ToInt32(dr["ApartmentShopPlot_NumberCanceledBookedInQuarter"]),
                           ApartmentShopPlot_NumberSoldInQuarter = Convert.ToInt32(dr["ApartmentShopPlot_NumberSoldInQuarter"]),
                           ApartmentShopPlot_TotalNumberFloorsConstructed = Convert.ToInt32(dr["ApartmentShopPlot_TotalNumberFloorsConstructed"]),
                           ApartmentShopPlot_TotalNumberBooked = Convert.ToInt32(dr["ApartmentShopPlot_TotalNumberBooked"]),
                           ApartmentShopPlot_TotalNumberSold = Convert.ToInt32(dr["ApartmentShopPlot_TotalNumberSold"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsRegisteredDiaryNumberLock = Convert.ToInt32(dr["Constructed_FloorsNumber"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist;
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails> Display_QUpdatesProject_ParkingDetails(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails> ProjectFivelist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ParkingDetails_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdatesProject_ID);
            cmd.Parameters.AddWithValue("p_QUpdatesYear", QUpdatesYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdatesQuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist.Add(
                       new ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails
                       {
                           QUpdateProjectParking_IndexID = Convert.ToInt64(dr["QUpdateProjectParking_IndexID"]),
                           QUpdateProjectParking_ID = Convert.ToInt64(dr["QUpdateProjectParking_ID"]),
                           Related_ProjectParking_IndexID = Convert.ToInt64(dr["Related_ProjectParking_IndexID"]),
                           Related_ProjectParking_ID = Convert.ToInt64(dr["Related_ProjectParking_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           Related_ParkingProjectRegistration_ID = Convert.ToInt64(dr["Related_ParkingProjectRegistration_ID"]),
                           QUpdateParking_Year = Convert.ToString(dr["QUpdateParking_Year"]),
                           QUpdateParking_QuarterName = Convert.ToString(dr["QUpdateParking_QuarterName"]),
                           ParkingType = Convert.ToString(dr["ParkingType"]),
                           ParkingSpaceUnits_TotalArea = Convert.ToDouble(dr["ParkingSpaceUnits_TotalArea"]),
                           ParkingSpaceUnits_NumberAvailableforSale = Convert.ToInt32(dr["ParkingSpaceUnits_NumberAvailableforSale"]),
                           ParkingSpaceUnits_NumberBookedSoldUptoRegistration = Convert.ToInt32(dr["ParkingSpaceUnits_NumberBookedSoldUptoRegistration"]),
                           ParkingSpaceUnits_NumberBookedInQuarter = Convert.ToInt32(dr["ParkingSpaceUnits_NumberBookedInQuarter"]),
                           ParkingSpaceUnits_NumberCanceledBookedInQuarter = Convert.ToInt32(dr["ParkingSpaceUnits_NumberCanceledBookedInQuarter"]),
                           ParkingSpaceUnits_NumberSoldInQuarter = Convert.ToInt32(dr["ParkingSpaceUnits_NumberSoldInQuarter"]),
                           ParkingSpaceUnits_TotalNumberBooked = Convert.ToInt32(dr["ParkingSpaceUnits_TotalNumberBooked"]),
                           ParkingSpaceUnits_TotalNumberSold = Convert.ToInt32(dr["ParkingSpaceUnits_TotalNumberSold"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsRegisteredDiaryNumberLock = Convert.ToInt32(dr["IsRegisteredDiaryNumberLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist;
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs> Display_QUpdatesProject_StatusConstructionPhotographs(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs> Projectlist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ConstructionPhotographs_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdatesProject_ID);
            cmd.Parameters.AddWithValue("p_QUpdatesYear", QUpdatesYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdatesQuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs
                       {
                           QUpdateProjectPhotographs_IndexID = Convert.ToInt64(dr["QUpdateProjectPhotographs_IndexID"]),
                           QUpdateProjectPhotographs_ID = Convert.ToInt64(dr["QUpdateProjectPhotographs_ID"]),
                           Related_ProjectPhotographsIndexID = Convert.ToInt64(dr["Related_ProjectPhotographsIndexID"]),
                           Related_ProjectPhotographsID = Convert.ToInt64(dr["Related_ProjectPhotographsID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           ProjectPhotographsRelated_Project_ID = Convert.ToInt64(dr["ProjectPhotographsRelated_Project_ID"]),
                           QUpdatePhotographs_Year = Convert.ToString(dr["QUpdatePhotographs_Year"]),
                           QUpdatePhotographs_QuarterName = Convert.ToString(dr["QUpdatePhotographs_QuarterName"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           BuildingTowerBlock_ComArea_ConStatusCode = Convert.ToInt32(dr["BuildingTowerBlock_ComArea_ConStatusCode"]),
                           BuildingTowerBlock_ComArea_ConStatusName = Convert.ToString(dr["BuildingTowerBlock_ComArea_ConStatusName"]),
                           BuildingTowerBlock_InfoCode = Convert.ToString(dr["BuildingTowerBlock_InfoCode"]),
                           BuildingTowerBlock_InfoName = Convert.ToString(dr["BuildingTowerBlock_InfoName"]),
                           BuildingTowerBlock_FloorsNumber = Convert.ToInt32(dr["BuildingTowerBlock_FloorsNumber"]),
                           BuildingTowerBlock_Type = Convert.ToString(dr["BuildingTowerBlock_Type"]),
                           BuildingTowerBlock_PhotographType = Convert.ToString(dr["BuildingTowerBlock_PhotographType"]),
                           Photographs_Title = Convert.ToString(dr["Photographs_Title"]),
                           Photographs_Status = Convert.ToString(dr["Photographs_Status"]),
                           Photographs_ClickDate = Convert.ToDateTime(dr["Photographs_ClickDate"]),
                           Photographs_FileSize = Convert.ToString(dr["Photographs_FileSize"]),
                           Photographs_FileFormat = Convert.ToString(dr["Photographs_FileFormat"]),
                           Photographs_FilePath = Convert.ToString(dr["Photographs_FilePath"]),
                           Photographs_FileName = Convert.ToString(dr["Photographs_FileName"]),
                           Photographs_IsGroup = Convert.ToInt32(dr["Photographs_IsGroup"]),
                           PhotoGeoPoint_Navigator = Convert.ToString(dr["PhotoGeoPoint_Navigator"]),
                           PhotoGeoPoint_Reference = Convert.ToString(dr["PhotoGeoPoint_Reference"]),
                           PhotoGeoPoint_Bounds = Convert.ToString(dr["PhotoGeoPoint_Bounds"]),
                           PhotoGeoPoint_GeometryType = Convert.ToString(dr["PhotoGeoPoint_GeometryType"]),
                           PhotoGeoPoint_Longitude = Convert.ToDouble(dr["PhotoGeoPoint_Longitude"]),
                           PhotoGeoPoint_Latitude = Convert.ToDouble(dr["PhotoGeoPoint_Latitude"]),
                           PhotoGeoPoint_LongitudeX = Convert.ToString(dr["PhotoGeoPoint_LongitudeX"]),
                           PhotoGeoPoint_LatitudeX = Convert.ToString(dr["PhotoGeoPoint_LatitudeX"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToInt64(dr["D_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsRegisteredDiaryNumberLock = Convert.ToInt32(dr["IsRegisteredDiaryNumberLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities> Display_QUpdatesProject_InternalInfrastructureFacilities(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities> Projectlist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_InternalFacilities_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdatesProject_ID);
            cmd.Parameters.AddWithValue("p_QUpdatesYear", QUpdatesYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdatesQuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities
                       {
                           QUpdateProjectInfraFacilities_IndexID = Convert.ToInt64(dr["QUpdateProjectInfraFacilities_IndexID"]),
                           QUpdateProjectInfraFacilities_ID = Convert.ToInt64(dr["QUpdateProjectInfraFacilities_ID"]),
                           Related_ProjectInfrastructureFacilitiesIndexID = Convert.ToInt64(dr["Related_ProjectInfrastructureFacilitiesIndexID"]),
                           Related_ProjectInfrastructureFacilitiesID = Convert.ToInt64(dr["Related_ProjectInfrastructureFacilitiesID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           QUpdateInfraFacilities_Year = Convert.ToString(dr["QUpdateInfraFacilities_Year"]),
                           QUpdateInfraFacilities_QuarterName = Convert.ToString(dr["QUpdateInfraFacilities_QuarterName"]),
                           InternalInfrastructureFacilities_Name = Convert.ToString(dr["InternalInfrastructureFacilities_Name"]),
                           InternalInfrastructureFacilities_Type = Convert.ToString(dr["InternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),
                           WorkProgress_PercentageUptoRegistration = Convert.ToDecimal(dr["WorkProgress_PercentageUptoRegistration"]),
                           InternalInfrastructureFacilitiesUptoRegistration_Details = Convert.ToString(dr["InternalInfrastructureFacilitiesUptoRegistration_Details"]),
                           WorkProgress_PercentageInQuarter = Convert.ToDecimal(dr["WorkProgress_PercentageInQuarter"]),
                           InternalInfrastructureFacilitiesInQuarter_Details = Convert.ToString(dr["InternalInfrastructureFacilitiesInQuarter_Details"]),
                           WorkProgress_PercentageTotal = Convert.ToDecimal(dr["WorkProgress_PercentageTotal"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsRegisteredDiaryNumberLock = Convert.ToInt32(dr["IsRegisteredDiaryNumberLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities> Display_QUpdatesProject_ExternalInfrastructureFacilities(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities> Projectlist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ExternalFacilities_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdatesProject_ID);
            cmd.Parameters.AddWithValue("p_QUpdatesYear", QUpdatesYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdatesQuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities
                       {
                           QUpdateProjectInfraExFacilities_IndexID = Convert.ToInt64(dr["QUpdateProjectInfraExFacilities_IndexID"]),
                           QUpdateProjectInfraExFacilities_ID = Convert.ToInt64(dr["QUpdateProjectInfraExFacilities_ID"]),
                           Related_ProjectInfrastructureExFacilitiesIndexID = Convert.ToInt64(dr["Related_ProjectInfrastructureExFacilitiesIndexID"]),
                           Related_ProjectInfrastructureExFacilitiesID = Convert.ToInt64(dr["Related_ProjectInfrastructureExFacilitiesID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]),
                           QUpdateInfraExFacilities_Year = Convert.ToString(dr["QUpdateInfraExFacilities_Year"]),
                           QUpdateInfraExFacilities_QuarterName = Convert.ToString(dr["QUpdateInfraExFacilities_QuarterName"]),
                           ExternalInfrastructureFacilities_Name = Convert.ToString(dr["ExternalInfrastructureFacilities_Name"]),
                           ExternalInfrastructureFacilities_Type = Convert.ToString(dr["ExternalInfrastructureFacilities_Type"]),
                           ExternalAgency_LocalAuthority_Name = Convert.ToString(dr["ExternalAgency_LocalAuthority_Name"]),
                           Is_InternalInfrastructureFacilitiesApplicable = Convert.ToString(dr["Is_InternalInfrastructureFacilitiesApplicable"]),
                           WorkProgress_PercentageUptoRegistration = Convert.ToDecimal(dr["WorkProgress_PercentageUptoRegistration"]),
                           ExternalInfrastructureFacilitiesUptoRegistration_Details = Convert.ToString(dr["ExternalInfrastructureFacilitiesUptoRegistration_Details"]),
                           WorkProgress_PercentageInQuarter = Convert.ToDecimal(dr["WorkProgress_PercentageInQuarter"]),
                           ExternalInfrastructureFacilitiesInQuarter_Details = Convert.ToString(dr["ExternalInfrastructureFacilitiesInQuarter_Details"]),
                           WorkProgress_PercentageTotal = Convert.ToDecimal(dr["WorkProgress_PercentageTotal"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsRegisteredDiaryNumberLock = Convert.ToInt32(dr["IsRegisteredDiaryNumberLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails> Display_QUpdatesProject_ProjectApprovals(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails> Projectlist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_Approvals_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdatesProject_ID);
            cmd.Parameters.AddWithValue("p_QUpdatesYear", QUpdatesYear);
            cmd.Parameters.AddWithValue("p_QUpdatesQuarterName", QUpdatesQuarterName);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails
                       {
                           QUpdateProjectApproval_IndexID = Convert.ToInt64(dr["QUpdateProjectApproval_IndexID"]),
                           QUpdateProjectApproval_ID = Convert.ToInt64(dr["QUpdateProjectApproval_ID"]),
                           Related_ProjectApproval_IndexID = Convert.ToInt64(dr["Related_ProjectApproval_IndexID"]),
                           Related_ProjectApproval_ID = Convert.ToInt64(dr["Related_ProjectApproval_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           Related_ApprovalProjectRegistration_ID = Convert.ToInt64(dr["Related_ApprovalProjectRegistration_ID"]),
                           QUpdateApproval_Year = Convert.ToString(dr["QUpdateApproval_Year"]),
                           QUpdateApproval_QuarterName = Convert.ToString(dr["QUpdateApproval_QuarterName"]),
                           DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                           DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                           DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                           DocumentType_IfOtherSpecifyName = Convert.ToString(dr["DocumentType_IfOtherSpecifyName"]),
                           DocumentType_Status = Convert.ToString(dr["DocumentType_Status"]),
                           Date_ApplicationPlannedorExpectedReceipt = Convert.ToDateTime(dr["Date_ApplicationPlannedorExpectedReceipt"]),
                           DocumentType_FileSize = Convert.ToString(dr["DocumentType_FileSize"]),
                           DocumentType_FileFormat = Convert.ToString(dr["DocumentType_FileFormat"]),
                           DocumentType_FilePath = Convert.ToString(dr["DocumentType_FilePath"]),
                           DocumentType_FileName = Convert.ToString(dr["DocumentType_FileName"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           //IsRegisteredDiaryNumberLock = Convert.ToInt32(dr["IsRegisteredDiaryNumberLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }
    }
}
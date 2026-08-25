using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_QuarterlyUpdatesProjectStatusConstructionPhotographs
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs> Display_QuarterlyUpdatesProject_StatusOfConstructionPhotographs(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_StatusOfConsPhotographsForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdates_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdates_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdates_Flag", viewCriteriaFlag);
            cmd.Parameters.AddWithValue("p_QUpdates_UserRole", UserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs
                       {
                           QUpdateProjectPhotographs_IndexID = Convert.ToInt64(dr["QUpdateProjectPhotographs_IndexID"]),
                           QUpdateProjectPhotographs_ID = Convert.ToInt64(dr["QUpdateProjectPhotographs_ID"]),
                           Related_ProjectPhotographsIndexID = Convert.ToInt64(dr["Related_ProjectPhotographsIndexID"]),
                           Related_ProjectPhotographsID = Convert.ToInt64(dr["Related_ProjectPhotographsID"]),

                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           ProjectPhotographsRelated_Project_ID = Convert.ToInt64(dr["ProjectPhotographsRelated_Project_ID"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           QUpdatePhotographs_Year = Convert.ToString(dr["QUpdatePhotographs_Year"]),
                           QUpdatePhotographs_QuarterName = Convert.ToString(dr["QUpdatePhotographs_QuarterName"]),

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
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           PhotoGeoPoint_Navigator = Convert.ToString(dr["PhotoGeoPoint_Navigator"]),
                           PhotoGeoPoint_Reference = Convert.ToString(dr["PhotoGeoPoint_Reference"]),
                           PhotoGeoPoint_Bounds = Convert.ToString(dr["PhotoGeoPoint_Bounds"]),
                           PhotoGeoPoint_GeometryType = Convert.ToString(dr["PhotoGeoPoint_GeometryType"]),
                           PhotoGeoPoint_Longitude = Convert.ToDouble(dr["PhotoGeoPoint_Longitude"]),
                           PhotoGeoPoint_Latitude = Convert.ToDouble(dr["PhotoGeoPoint_Latitude"]),
                           PhotoGeoPoint_LongitudeX = Convert.ToString(dr["PhotoGeoPoint_LongitudeX"]),
                           PhotoGeoPoint_LatitudeX = Convert.ToString(dr["PhotoGeoPoint_LatitudeX"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToInt64(dr["D_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           setQUpdateProject_QuarterName = Convert.ToString(dr["setQUpdateProject_QuarterName"]),
                       });
            }
            return ProjectList;
        }

        public Int32 Update_PublicUnpublicHandler_QuarterlyUpdatesProject_StatusConstructionPhotographsByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, string PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_tbl_rera_QUpdatesProject_PhotographsByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", 0);
            cmd.Parameters.AddWithValue("p_RelatedRefIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_RelatedRefID", RelatedRefID);
            cmd.Parameters.AddWithValue("p_PublicUnpublicValue", PublicUnpublicCode);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }


        public List<ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails> PrintPDF_QUpdatesProject_RegDiaryNumberByProjectIDandQTRs(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails> ProjectFivelist = new List<ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectQUpdate_RegDiaryNumberByID_ForAuthPDF", con);
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
                           new ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails
                           {
                               QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                               QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                               QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                               QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                               QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                               QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               PromoterID = Convert.ToInt64(dr["PromoterID"]),
                               ProjectID = Convert.ToInt64(dr["ProjectID"]),
                               InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                               ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                               GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                               InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                               ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                               ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),
                               RERAnumber = Convert.ToString(dr["RERAnumber"]),
                               RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                               RERAnumberValidUptoDate = Convert.ToDateTime(dr["RERAnumberVlaidUptoDate"]),
                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),
                               Extra4 = Convert.ToString(dr["Extra4"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               zipProject_DiaryNumber = Convert.ToString(dr["Project_DiaryNumberName"]),
                               zipProjectName = Convert.ToString(dr["Project_Name"]),
                               zipProjectDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                               zipPromoterName = Convert.ToString(dr["Promoter_Name"]),
                           });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ProjectFivelist;
        }

        public List<ClsPrp_PrintPDF_QUpdatesProjectStatusConstructionPhotographs> PrintPDF_QUpdatesProject_StatusConstructionPhotographsByProjectIDandQTRs(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrintPDF_QUpdatesProjectStatusConstructionPhotographs> Projectlist = new List<ClsPrp_PrintPDF_QUpdatesProjectStatusConstructionPhotographs>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ConstructionPhotographs_ForAuthPDF", con);
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
                       new ClsPrp_PrintPDF_QUpdatesProjectStatusConstructionPhotographs
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

    }
}
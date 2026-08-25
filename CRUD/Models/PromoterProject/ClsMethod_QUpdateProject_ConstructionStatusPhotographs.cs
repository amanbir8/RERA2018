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
    public class ClsMethod_QUpdateProject_ConstructionStatusPhotographs
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ProjectQUpdate_ConstructionStatusPhotographs(ClsPrp_QUpdateProject_ConstructionStatusPhotographs smodel, Int64 oPromoter_ID, String oPromoterDoc_FilePath, String oPromoterDoc_FileName, String oPromoterDoc_FileSize, String oPromoterDoc_FileFormat, Int32 oPromoterDoc_IsGroup, string oUserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_quarterlyupdate_GeoPhotographs", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_QUpdateProjectPhotographs_IndexID", (smodel.QUpdateProjectPhotographs_IndexID == 0) ? 0 : smodel.QUpdateProjectPhotographs_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectPhotographs_ID", (smodel.QUpdateProjectPhotographs_ID == 0) ? 0 : smodel.QUpdateProjectPhotographs_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectPhotographsIndexID", (smodel.Related_ProjectPhotographsIndexID == 0) ? 0 : smodel.Related_ProjectPhotographsIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectPhotographsID", (smodel.Related_ProjectPhotographsID == 0) ? 0 : smodel.Related_ProjectPhotographsID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_IsQuarterlyDataValid", 1); //QUP data flag (smodel.IsQuarterlyDataValid == 0) ? 0 : smodel.IsQuarterlyDataValid);
            cmd.Parameters.AddWithValue("p_ProjectPhotographsRelated_Project_ID", (smodel.ProjectPhotographsRelated_Project_ID == 0) ? 0 : smodel.ProjectPhotographsRelated_Project_ID);
            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_QUpdatePhotographs_Year", String.IsNullOrEmpty(smodel.QUpdatePhotographs_Year) ? "0" : smodel.QUpdatePhotographs_Year);
            cmd.Parameters.AddWithValue("p_QUpdatePhotographs_QuarterName", String.IsNullOrEmpty(smodel.QUpdatePhotographs_QuarterName) ? "" : smodel.QUpdatePhotographs_QuarterName);

            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_ComArea_ConStatusCode", (smodel.BuildingTowerBlock_ComArea_ConStatusCode == 0) ? 0 : smodel.BuildingTowerBlock_ComArea_ConStatusCode);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_ComArea_ConStatusName", String.IsNullOrEmpty(smodel.BuildingTowerBlock_ComArea_ConStatusName) ? "" : smodel.BuildingTowerBlock_ComArea_ConStatusName);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_InfoCode", String.IsNullOrEmpty(smodel.BuildingTowerBlock_InfoCode) ? "0" : smodel.BuildingTowerBlock_InfoCode);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_InfoName", String.IsNullOrEmpty(smodel.BuildingTowerBlock_InfoName) ? "" : smodel.BuildingTowerBlock_InfoName);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_FloorsNumber", (smodel.BuildingTowerBlock_FloorsNumber == 0) ? 0 : smodel.BuildingTowerBlock_FloorsNumber);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_Type", String.IsNullOrEmpty(smodel.BuildingTowerBlock_Type) ? "0" : smodel.BuildingTowerBlock_Type);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_PhotographType", String.IsNullOrEmpty(smodel.BuildingTowerBlock_PhotographType) ? "0" : smodel.BuildingTowerBlock_PhotographType);

            cmd.Parameters.AddWithValue("p_Photographs_Title", String.IsNullOrEmpty(smodel.Photographs_Title) ? "" : smodel.Photographs_Title);
            cmd.Parameters.AddWithValue("p_Photographs_Status", String.IsNullOrEmpty(smodel.Photographs_Status) ? "" : smodel.Photographs_Status);
            cmd.Parameters.AddWithValue("p_Photographs_ClickDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Photographs_FileSize", oPromoterDoc_FileSize);
            cmd.Parameters.AddWithValue("p_Photographs_FileFormat", oPromoterDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_Photographs_FilePath", oPromoterDoc_FilePath);
            cmd.Parameters.AddWithValue("p_Photographs_FileName", oPromoterDoc_FileName);
            cmd.Parameters.AddWithValue("p_Photographs_IsGroup", oPromoterDoc_IsGroup);

            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_Navigator", String.IsNullOrEmpty(smodel.PhotoGeoPoint_Navigator) ? "" : smodel.PhotoGeoPoint_Navigator);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_Reference", String.IsNullOrEmpty(smodel.PhotoGeoPoint_Reference) ? "" : smodel.PhotoGeoPoint_Reference);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_Bounds", String.IsNullOrEmpty(smodel.PhotoGeoPoint_Bounds) ? "" : smodel.PhotoGeoPoint_Bounds);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_GeometryType", String.IsNullOrEmpty(smodel.PhotoGeoPoint_GeometryType) ? "" : smodel.PhotoGeoPoint_GeometryType);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_Longitude", (smodel.PhotoGeoPoint_Longitude == 0) ? 0 : smodel.PhotoGeoPoint_Longitude);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_Latitude", (smodel.PhotoGeoPoint_Latitude == 0) ? 0 : smodel.PhotoGeoPoint_Latitude);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_LongitudeX", String.IsNullOrEmpty(smodel.PhotoGeoPoint_LongitudeX) ? "" : smodel.PhotoGeoPoint_LongitudeX);
            cmd.Parameters.AddWithValue("p_PhotoGeoPoint_LatitudeX", String.IsNullOrEmpty(smodel.PhotoGeoPoint_LatitudeX) ? "" : smodel.PhotoGeoPoint_LatitudeX);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", (smodel.D_column == 0) ? 0 : smodel.D_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(oUserName) ? "UID" : oUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(oUserName) ? "UID" : oUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_QUpdateProject_ConstructionStatusPhotographs> Display_QUpdateProject_ConstructionStatusPhotographs(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName)
        {
            connection();
            List<ClsPrp_QUpdateProject_ConstructionStatusPhotographs> ProjectFivelist1 = new List<ClsPrp_QUpdateProject_ConstructionStatusPhotographs>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectQUpdate_ConstructionStatusGeoPhotographs", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectQUStatusPhoto_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectQUStatusPhoto_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_QUpdateProject_ConstructionStatusPhotographs
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
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ProjectFivelist1;
        }

        public bool Delete_ProjectQUpdate_ConstructionStatusPhotographs(Int64? ProjectRegistrationID, Int64? ImageIndexID, Int64? ImageID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_ProjectQUpdate_StatusGeoPhotographsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectRegistrationID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ImageIndexID", ImageIndexID);
            cmd.Parameters.AddWithValue("p_ImageID", ImageID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64, Int64, Int64> Display_ProjectQUpdate_ConstructionStatusPhotographs_ByDocCodeByID(Int64? Promoter_ID, Int64? Project_ID, Int32? varYear, string varQuater, Int32? ConstructionCode, Int64? BlockCode, Int32? StatusConstructionCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;
            Int64 sumTotalVal = 0;
            Int64 cntTotalVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectQUpdate_Photographs_ByPhotoCodeInfoProjectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_varYear", varYear);
            cmd.Parameters.AddWithValue("p_varQuater", varQuater);
            cmd.Parameters.AddWithValue("p_ConstructionCode", ConstructionCode);
            cmd.Parameters.AddWithValue("p_BlockCode", BlockCode);
            cmd.Parameters.AddWithValue("p_StatusConstructionCode", StatusConstructionCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"]);
                cntVal = Convert.ToInt64(dr["CountFileType"]);
                sumTotalVal = Convert.ToInt64(dr["sumTotalFileSize"]);
                cntTotalVal = Convert.ToInt64(dr["CountTotalFileType"]);
            }
            return new Tuple<Int64, Int64, Int64, Int64>(sumVal, cntVal, sumTotalVal, cntTotalVal);
        }

        public List<Clsprp_Master_Project_PhotographFileSizeCount> Display_Master_ProjectQUpdate_ConstructionStatusPhotographsByID(Int64 Promoter_ID, Int64 Project_ID, Int32? ConstructionCode, Int32? StatusConstructionCode)
        {
            connection();
            List<Clsprp_Master_Project_PhotographFileSizeCount> MasterList = new List<Clsprp_Master_Project_PhotographFileSizeCount>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectQUpdate_Master_DocPhotographsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
                cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                cmd.Parameters.AddWithValue("p_ConstructionCode", ConstructionCode);
                cmd.Parameters.AddWithValue("p_StatusConstructionCode", StatusConstructionCode);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    MasterList.Add(
                        new Clsprp_Master_Project_PhotographFileSizeCount
                        {
                            StatusTitleList_IndexID = Convert.ToInt32(dr["StatusTitleList_IndexID"]),
                            StatusTitleList_ID = Convert.ToInt32(dr["StatusTitleList_ID"]),
                            StatusTitleListName = Convert.ToString(dr["StatusTitleListName"]),
                            StatusTitleListDescription = Convert.ToString(dr["StatusTitleListDescription"]),
                            StatusImg_RelatedSectionName = Convert.ToString(dr["StatusImg_RelatedSectionName"]),
                            StatusImg_SetFileSize = Convert.ToString(dr["StatusImg_SetFileSize"]),
                            StatusImg_SetFileFormat = Convert.ToString(dr["StatusImg_SetFileFormat"]),
                            StatusImg_SetFilePath = Convert.ToString(dr["StatusImg_SetFilePath"]),
                            StatusTitleFlag = Convert.ToInt32(dr["StatusTitleFlag"]),
                            StatusImg_ValidCode = Convert.ToInt32(dr["StatusImg_ValidCode"]),
                            StatusImg_ValidSubCode = Convert.ToInt32(dr["StatusImg_ValidSubCode"]),
                            IsGroup = Convert.ToInt32(dr["IsGroup"]),
                            IsMandatory = Convert.ToInt32(dr["IsMandatory"]),
                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return MasterList;
        }

        //Master Inventory List
        public List<Clsprp_Master_Project_InventoryList> Display_Master_QUpdateProject_InventoryList()
        {
            connection();
            List<Clsprp_Master_Project_InventoryList> MasterList = new List<Clsprp_Master_Project_InventoryList>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ProjectInventoryList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterList.Add(
                       new Clsprp_Master_Project_InventoryList
                       {
                           InventoryList_IndexID = Convert.ToInt32(dr["InventoryList_IndexID"]),
                           InventoryList_ID = Convert.ToInt32(dr["InventoryList_ID"]),
                           InventoryListName = Convert.ToString(dr["InventoryListName"]),
                           InventoryListDescription = Convert.ToString(dr["InventoryListDescription"]),
                       });
            }
            return MasterList;
        }
        public List<Clsprp_Master_Project_InventoryList> Display_Master_QUpdateProject_InventoryInfraCommonList()
        {
            connection();
            List<Clsprp_Master_Project_InventoryList> MasterList = new List<Clsprp_Master_Project_InventoryList>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ProjectInventoryInfraCommonList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterList.Add(
                       new Clsprp_Master_Project_InventoryList
                       {
                           InventoryList_IndexID = Convert.ToInt32(dr["InventoryList_IndexID"]),
                           InventoryList_ID = Convert.ToInt32(dr["InventoryList_ID"]),
                           InventoryListName = Convert.ToString(dr["InventoryListName"]),
                           InventoryListDescription = Convert.ToString(dr["InventoryListDescription"]),
                       });
            }
            return MasterList;
        }
        public List<Clsprp_Master_Project_PhotographStatusTitleList> Display_Master_QUpdateProject_PhotographStatusTitleList()
        {
            connection();
            List<Clsprp_Master_Project_PhotographStatusTitleList> MasterList = new List<Clsprp_Master_Project_PhotographStatusTitleList>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ProjectPhotographStatusTitleList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterList.Add(
                       new Clsprp_Master_Project_PhotographStatusTitleList
                       {
                           StatusTitleList_IndexID = Convert.ToInt32(dr["StatusTitleList_IndexID"]),
                           StatusTitleList_ID = Convert.ToInt32(dr["StatusTitleList_ID"]),
                           StatusTitleListName = Convert.ToString(dr["StatusTitleListName"]),
                           StatusTitleListDescription = Convert.ToString(dr["StatusTitleListDescription"]),
                       });
            }
            return MasterList;
        }
    }
}
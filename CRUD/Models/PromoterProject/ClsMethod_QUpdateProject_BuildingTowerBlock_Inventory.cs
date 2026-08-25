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
    public class ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_QUpdateProject_BuildingTowerBlock_InventoryDetails(ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_quarterlyupdate_Inventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventory_IndexID", smodel.QUpdateProjectInventory_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventory_ID", smodel.QUpdateProjectInventory_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInventoryIndexID", smodel.Related_ProjectInventoryIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInventory_ID", smodel.Related_ProjectInventory_ID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_Related_ProjectRegistration_ID", smodel.Related_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateInventory_Year", String.IsNullOrEmpty(smodel.QUpdateInventory_Year) ? "0" : smodel.QUpdateInventory_Year);
            cmd.Parameters.AddWithValue("p_QUpdateInventory_QuarterName", String.IsNullOrEmpty(smodel.QUpdateInventory_QuarterName) ? "" : smodel.QUpdateInventory_QuarterName);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_Name", String.IsNullOrEmpty(smodel.BuildingTowerBlock_Name) ? "" : smodel.BuildingTowerBlock_Name);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_Type", String.IsNullOrEmpty(smodel.ApartmentShopPlot_Type) ? "" : smodel.ApartmentShopPlot_Type);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_InventoryType", String.IsNullOrEmpty(smodel.ApartmentShopPlot_InventoryType) ? "" : smodel.ApartmentShopPlot_InventoryType);

            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_CarpetArea", smodel.ApartmentShopPlot_CarpetArea);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_ExclusiveOpenTerraceArea", smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_ExclusiveBalconyVerandahArea", smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberAvailableforSale", smodel.ApartmentShopPlot_NumberAvailableforSale);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberSoldUptoRegistration", smodel.ApartmentShopPlot_NumberSoldUptoRegistration);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberFloorsConstructedInQuarter", smodel.ApartmentShopPlot_NumberFloorsConstructedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter", smodel.ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberBookedInQuarter", smodel.ApartmentShopPlot_NumberBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberCanceledBookedInQuarter", smodel.ApartmentShopPlot_NumberCanceledBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberSoldInQuarter", smodel.ApartmentShopPlot_NumberSoldInQuarter);

            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_TotalNumberFloorsConstructed", smodel.ApartmentShopPlot_TotalNumberFloorsConstructed);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_TotalNumberBooked", smodel.ApartmentShopPlot_TotalNumberBooked);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_TotalNumberSold", smodel.ApartmentShopPlot_TotalNumberSold);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == "true" ? "YES" : "NO");
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", UName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", UName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //if (i >= 0)
            //    return AppId;
            //else
            //    return 0;

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_QUpdateProject_BuildingTowerBlock_InventoryDetails(ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_quarterlyupdate_Inventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventory_IndexID", smodel.QUpdateProjectInventory_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventory_ID", smodel.QUpdateProjectInventory_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInventoryIndexID", smodel.Related_ProjectInventoryIndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectInventory_ID", smodel.Related_ProjectInventory_ID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_Related_ProjectRegistration_ID", smodel.Related_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateInventory_Year", String.IsNullOrEmpty(smodel.QUpdateInventory_Year) ? "0" : smodel.QUpdateInventory_Year);
            cmd.Parameters.AddWithValue("p_QUpdateInventory_QuarterName", String.IsNullOrEmpty(smodel.QUpdateInventory_QuarterName) ? "" : smodel.QUpdateInventory_QuarterName);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_Name", String.IsNullOrEmpty(smodel.BuildingTowerBlock_Name) ? "" : smodel.BuildingTowerBlock_Name);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_Type", String.IsNullOrEmpty(smodel.ApartmentShopPlot_Type) ? "" : smodel.ApartmentShopPlot_Type);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_InventoryType", String.IsNullOrEmpty(smodel.ApartmentShopPlot_InventoryType) ? "" : smodel.ApartmentShopPlot_InventoryType);

            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_CarpetArea", smodel.ApartmentShopPlot_CarpetArea);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_ExclusiveOpenTerraceArea", smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_ExclusiveBalconyVerandahArea", smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberAvailableforSale", smodel.ApartmentShopPlot_NumberAvailableforSale);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberSoldUptoRegistration", smodel.ApartmentShopPlot_NumberSoldUptoRegistration);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberFloorsConstructedInQuarter", smodel.ApartmentShopPlot_NumberFloorsConstructedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter", smodel.ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberBookedInQuarter", smodel.ApartmentShopPlot_NumberBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberCanceledBookedInQuarter", smodel.ApartmentShopPlot_NumberCanceledBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_NumberSoldInQuarter", smodel.ApartmentShopPlot_NumberSoldInQuarter);

            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_TotalNumberFloorsConstructed", smodel.ApartmentShopPlot_TotalNumberFloorsConstructed);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_TotalNumberBooked", smodel.ApartmentShopPlot_TotalNumberBooked);
            cmd.Parameters.AddWithValue("p_ApartmentShopPlot_TotalNumberSold", smodel.ApartmentShopPlot_TotalNumberSold);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == "true" ? "YES" : "NO");
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", UName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", UName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
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

        public List<ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory> Display_QUpdateProject_BuildingTowerBlock_Inventory(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName)
        {
            connection();
            List<ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory> ProjectList = new List<ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_BuildingTowerBlock_Inventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInventory_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectInventory_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInventory_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory
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
                           ApartmentShopPlot_InventoryType = Convert.ToString(dr["ApartmentShopPlot_InventoryType"]), //(Apartment/ Commercial/ Individual House/ Plots/ Others)
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
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectList;
        }

        public List<ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory> Display_QUpdateProject_BuildingTowerBlock_InventoryByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectInventoryIndexID, Int64 QUpdateProjectInventoryID, Int64 RelatedProjectInventoryIndexID, Int64 RelatedProjectInventoryID)
        {
            connection();
            List<ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory> ProjectList = new List<ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_BuildingTowerBlock_InventoryByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInventory_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectInventory_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInventory_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventoryIndexID", QUpdateProjectInventoryIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventoryID", QUpdateProjectInventoryID);
            cmd.Parameters.AddWithValue("p_RelatedProjectInventoryIndexID", RelatedProjectInventoryIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectInventoryID", RelatedProjectInventoryID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory
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
                           ApartmentShopPlot_InventoryType = Convert.ToString(dr["ApartmentShopPlot_InventoryType"]), //(Apartment/ Commercial/ Individual House/ Plots/ Others)
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
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectList;
        }

        public bool Delete_QUpdateProject_BuildingTowerBlock_InventoryByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectInventoryIndexID, Int64 QUpdateProjectInventoryID, Int64 RelatedProjectInventoryIndexID, Int64 RelatedProjectInventoryID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_ProjectQUpdate_BuildingTowerBlock_InventoryByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectInventory_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectInventory_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectInventory_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventoryIndexID", QUpdateProjectInventoryIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectInventoryID", QUpdateProjectInventoryID);
            cmd.Parameters.AddWithValue("p_RelatedProjectInventoryIndexID", RelatedProjectInventoryIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectInventoryID", RelatedProjectInventoryID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

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
    }
}
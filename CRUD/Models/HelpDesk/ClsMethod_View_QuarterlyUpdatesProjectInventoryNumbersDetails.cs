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
    public class ClsMethod_View_QuarterlyUpdatesProjectInventoryNumbersDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthorityDesk_QUpdatesProject_InventoryDetails> Display_QuarterlyUpdatesProject_InventoryNumbersDetails(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProject_InventoryDetails> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProject_InventoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_InventoryNumbersDetailsForDesk", con);
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
                       new ClsPrp_AuthorityDesk_QUpdatesProject_InventoryDetails
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
                           setQUpdateProject_QuarterName = Convert.ToString(dr["setQUpdateProject_QuarterName"]),
                       });
            }
            return ProjectList;
        }

    }
}
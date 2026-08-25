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
    public class ClsMethod_Project_BuildingTowerBlock_Inventory
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_BuildingTowerBlock_Inventory(ClsPrp_Project_BuildingTowerBlock_Inventory smodel, Int64 Project_id)//,, string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_BuildingTowerBlock_Inventory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            //cmd.Parameters.AddWithValue("p_p_ProjectInventory_IndexID", smodel.ProjectInventory_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectInventory_ID", smodel.ProjectInventory_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectInventoryRelated_ProjectRegistration_ID",  smodel.ProjectInventoryRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_BuildingTowerBlock_Name", smodel.BuildingTowerBlock_Name);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_Type", smodel.ApartmentShopPlot_Type);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_CarpetArea", smodel.ApartmentShopPlot_CarpetArea);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_ExclusiveOpenTerraceArea", smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea == null? 0: smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_ExclusiveBalconyVerandahArea", smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_AvailableforSaleNumber", smodel.ApartmentShopPlot_AvailableforSaleNumber);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_AlreadySoldNumber", smodel.ApartmentShopPlot_AlreadySoldNumber);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);

            // cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");


            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);


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

        public bool Update_Project_BuildingTowerBlock_Inventory(ClsPrp_Project_BuildingTowerBlock_Inventory smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_BuildingTowerBlock_Inventory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectInventory_IndexID", smodel.ProjectInventory_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectInventory_ID", smodel.ProjectInventory_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectInventoryRelated_ProjectRegistration_ID", smodel.ProjectInventoryRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_BuildingTowerBlock_Name", smodel.BuildingTowerBlock_Name);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_Type", smodel.ApartmentShopPlot_Type);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_CarpetArea", smodel.ApartmentShopPlot_CarpetArea);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_ExclusiveOpenTerraceArea", smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveOpenTerraceArea);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_ExclusiveBalconyVerandahArea", smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea == null ? 0 : smodel.ApartmentShopPlot_ExclusiveBalconyVerandahArea);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_AvailableforSaleNumber", smodel.ApartmentShopPlot_AvailableforSaleNumber);
            cmd.Parameters.AddWithValue("p_p_ApartmentShopPlot_AlreadySoldNumber", smodel.ApartmentShopPlot_AlreadySoldNumber);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", "");
            //cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
           // cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "ModifyBy");
            // cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);
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

        public List<ClsPrp_Project_BuildingTowerBlock_Inventory> Display_Project_BuildingTowerBlock_Inventory(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_Project_BuildingTowerBlock_Inventory> ProjectFivelist1 = new List<ClsPrp_Project_BuildingTowerBlock_Inventory>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_BuildingTowerBlock_Inventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInventory_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_BuildingTowerBlock_Inventory
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


        public List<ClsPrp_Project_BuildingTowerBlock_Inventory> Display_Project_BuildingTowerBlock_InventoryById(Int64 ProjectRegistration_ID,Int64 ProjectInventory_IndexID)
        {

            connection();
            List<ClsPrp_Project_BuildingTowerBlock_Inventory> ProjectFivelist1 = new List<ClsPrp_Project_BuildingTowerBlock_Inventory>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_BuildingTowerBlock_InventoryById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectInventory_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectInventory_IndexID", ProjectInventory_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_BuildingTowerBlock_Inventory
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

        public bool Delete_BuildingTowerBlock_Inventory(Int64 ProjectRegistration_ID, Int64 ProjectInventory_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_Project_BuildingTowerBlock_InventoryById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_p_ProjectInventory_IndexID", ProjectInventory_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectInventory_ProjectReg_ID", ProjectRegistration_ID);


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
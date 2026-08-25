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
    public class ClsMethod_Project_ConstructionStatusPhotographs
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_Project_ConstructionStatusPhotographs(ClsPrp_Project_ConstructionStatusPhotographs smodel, Int64 oPromoter_ID, String oPromoterDoc_FilePath, String oPromoterDoc_FileName, String oPromoterDoc_FileSize, String oPromoterDoc_FileFormat, Int32 oPromoterDoc_IsGroup)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Project_ConstructionStatusPhotographs", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectPhotographs_IndexID", 0);
            cmd.Parameters.AddWithValue("p_ProjectPhotographs_ID", (smodel.ProjectPhotographs_ID == 0) ? 0 : smodel.ProjectPhotographs_ID);
            cmd.Parameters.AddWithValue("p_ProjectPhotographsRelated_Project_ID", (smodel.ProjectPhotographsRelated_Project_ID == 0) ? 0 : smodel.ProjectPhotographsRelated_Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);

            cmd.Parameters.AddWithValue("p_TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code", (smodel.TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code == 0) ? 0 : smodel.TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code);
            cmd.Parameters.AddWithValue("p_TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Name", String.IsNullOrEmpty(smodel.TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Name) ? "" : smodel.TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Name);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_InfoCode", String.IsNullOrEmpty(smodel.BuildingTowerBlock_InfoCode) ? "" : smodel.BuildingTowerBlock_InfoCode); 
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_InfoName", String.IsNullOrEmpty(smodel.BuildingTowerBlock_InfoName) ? "" : smodel.BuildingTowerBlock_InfoName);
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_FloorsNumber", (smodel.BuildingTowerBlock_FloorsNumber == 0) ? 0 : smodel.BuildingTowerBlock_FloorsNumber); 
            cmd.Parameters.AddWithValue("p_BuildingTowerBlock_PhotographType", String.IsNullOrEmpty(smodel.BuildingTowerBlock_PhotographType) ? "" : smodel.BuildingTowerBlock_PhotographType);

            cmd.Parameters.AddWithValue("p_Photographs_Title", String.IsNullOrEmpty(smodel.Photographs_Title) ? "" : smodel.Photographs_Title);
            cmd.Parameters.AddWithValue("p_Photographs_ClickDate", DateTime.Now);// smodel.Photographs_ClickDate);

            cmd.Parameters.AddWithValue("p_Photographs_FileSize", oPromoterDoc_FileSize);
            cmd.Parameters.AddWithValue("p_Photographs_FileFormat", oPromoterDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_Photographs_FilePath", oPromoterDoc_FilePath);
            cmd.Parameters.AddWithValue("p_Photographs_FileName", oPromoterDoc_FileName);
            cmd.Parameters.AddWithValue("p_Photographs_IsGroup", oPromoterDoc_IsGroup);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", (smodel.D_column == 0) ? 0 : smodel.D_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_Project_ConstructionStatusPhotographs> Display_Project_ConstructionStatusPhotographs(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_ConstructionStatusPhotographs> ProjectFivelist1 = new List<ClsPrp_Project_ConstructionStatusPhotographs>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ConstructionStatusPhotographs", con);
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
                       new ClsPrp_Project_ConstructionStatusPhotographs
                       {
                           ProjectPhotographs_IndexID = Convert.ToInt64(dr["ProjectPhotographs_IndexID"]),
                           ProjectPhotographs_ID = Convert.ToInt64(dr["ProjectPhotographs_ID"]),
                           ProjectPhotographsRelated_Project_ID = Convert.ToInt64(dr["ProjectPhotographsRelated_Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code = Convert.ToInt32(dr["TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code"]),
                           TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Name = Convert.ToString(dr["TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Name"]),

                           BuildingTowerBlock_InfoCode = Convert.ToString(dr["BuildingTowerBlock_InfoCode"]),
                           BuildingTowerBlock_InfoName = Convert.ToString(dr["BuildingTowerBlock_InfoName"]),
                           BuildingTowerBlock_FloorsNumber = Convert.ToInt32(dr["BuildingTowerBlock_FloorsNumber"]),
                           BuildingTowerBlock_PhotographType = Convert.ToString(dr["BuildingTowerBlock_PhotographType"]),

                           Photographs_Title = Convert.ToString(dr["Photographs_Title"]),
                           Photographs_ClickDate = Convert.ToDateTime(dr["Photographs_ClickDate"]),
                           Photographs_FileSize = Convert.ToString(dr["Photographs_FileSize"]),
                           Photographs_FileFormat = Convert.ToString(dr["Photographs_FileFormat"]),
                           Photographs_FilePath = Convert.ToString(dr["Photographs_FilePath"]),
                           Photographs_FileName = Convert.ToString(dr["Photographs_FileName"]),
                           Photographs_IsGroup = Convert.ToInt32(dr["Photographs_IsGroup"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToInt64(dr["D_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ProjectFivelist1;
        }

        public bool Delete_Project_ConstructionStatusPhotographs(Int64? ProjectRegistration_ID, Int64? Id, Int64? Photograph_Id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_ConstructionStatusPhotographs_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Project_id", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_Indexid", Id);
            cmd.Parameters.AddWithValue("p_Photograph_id", Photograph_Id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validation Method - Count and Sum Size
        /// </summary>
        /// <param name="Promoter_ID"></param>
        /// <param name="PromoterDoc_InfoCode"></param>
        /// <returns></returns>
        public Tuple<Int64, Int64> Display_Project_ConstructionStatusPhotographs_ByDocCodeInfoPromoterID(Int64? Promoter_ID, Int64? Project_ID, Int32? varYear, string varQuater, Int32? ConstructionCode, Int64? BlockCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Photographs_ByPhotoCodeInfoProjectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_varYear", varYear);
            cmd.Parameters.AddWithValue("p_varQuater", varQuater);
            cmd.Parameters.AddWithValue("p_ConstructionCode", ConstructionCode);
            cmd.Parameters.AddWithValue("p_BlockCode", BlockCode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"]);
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }
    }
}
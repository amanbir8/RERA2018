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
    public class ClsMethod_View_Project_Updates_ConstructionStatusPhotographs
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs> Display_AuthDesk_Project_ConstructionStatusPhotographs(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {
            connection();

            List<ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs> ProjectFivelist1 = new List<ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ConstructionStatusPhotographsForDesk", con);
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
                       new ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs
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

        public Int32 Update_LockUnLockHandler_Project_AdvtPhotographDetails(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg, string QuarterName, Int32 QuarterYear)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_advtphotographdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_AdvtPhotographIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
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

    }
}
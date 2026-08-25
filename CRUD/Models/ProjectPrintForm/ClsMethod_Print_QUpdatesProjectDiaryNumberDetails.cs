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
    public class ClsMethod_Print_QUpdatesProjectDiaryNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails> Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(Int64 QUpdatesProject_ID, Int32 QUpdatesYear, string QUpdatesQuarterName, string UserID_Role)
        {
            connection();
            List<ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails> ProjectFivelist = new List<ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectQUpdate_RegDiaryNumberByID_ForPrint", con);
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
                           new ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails
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

    }
}
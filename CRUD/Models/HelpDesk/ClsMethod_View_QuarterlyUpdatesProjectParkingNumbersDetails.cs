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
    public class ClsMethod_View_QuarterlyUpdatesProjectParkingNumbersDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthorityDesk_QUpdatesProject_ParkingDetails> Display_QuarterlyUpdatesProject_ParkingNumbersDetails(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProject_ParkingDetails> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProject_ParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_ParkingNumbersDetailsForDesk", con);
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
                       new ClsPrp_AuthorityDesk_QUpdatesProject_ParkingDetails
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
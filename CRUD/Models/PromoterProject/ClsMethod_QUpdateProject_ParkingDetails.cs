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
    public class ClsMethod_QUpdateProject_ParkingDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_QUpdateProject_ParkingDetails(ClsPrp_QUpdateProject_ParkingDetails smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_quarterlyupdate_parkingdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectParking_IndexID", smodel.QUpdateProjectParking_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectParking_ID", smodel.QUpdateProjectParking_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectParking_IndexID", smodel.Related_ProjectParking_IndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectParking_ID", smodel.Related_ProjectParking_ID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_Related_ParkingProjectRegistration_ID", smodel.Related_ParkingProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateParking_Year", String.IsNullOrEmpty(smodel.QUpdateParking_Year) ? "0" : smodel.QUpdateParking_Year);
            cmd.Parameters.AddWithValue("p_QUpdateParking_QuarterName", String.IsNullOrEmpty(smodel.QUpdateParking_QuarterName) ? "" : smodel.QUpdateParking_QuarterName);

            cmd.Parameters.AddWithValue("p_ParkingType", String.IsNullOrEmpty(smodel.ParkingType) ? "" : smodel.ParkingType);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_TotalArea", smodel.ParkingSpaceUnits_TotalArea);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberAvailableforSale", smodel.ParkingSpaceUnits_NumberAvailableforSale);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberBookedSoldUptoRegistration", smodel.ParkingSpaceUnits_NumberBookedSoldUptoRegistration);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberBookedInQuarter", smodel.ParkingSpaceUnits_NumberBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberCanceledBookedInQuarter", smodel.ParkingSpaceUnits_NumberCanceledBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberSoldInQuarter", smodel.ParkingSpaceUnits_NumberSoldInQuarter);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_TotalNumberBooked", smodel.ParkingSpaceUnits_TotalNumberBooked);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_TotalNumberSold", smodel.ParkingSpaceUnits_TotalNumberSold);

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

        public bool Update_QUpdateProject_ParkingDetails(ClsPrp_QUpdateProject_ParkingDetails smodel, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_quarterlyupdate_parkingdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectParking_IndexID", smodel.QUpdateProjectParking_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectParking_ID", smodel.QUpdateProjectParking_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectParking_IndexID", smodel.Related_ProjectParking_IndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectParking_ID", smodel.Related_ProjectParking_ID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_Related_ParkingProjectRegistration_ID", smodel.Related_ParkingProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateParking_Year", String.IsNullOrEmpty(smodel.QUpdateParking_Year) ? "0" : smodel.QUpdateParking_Year);
            cmd.Parameters.AddWithValue("p_QUpdateParking_QuarterName", String.IsNullOrEmpty(smodel.QUpdateParking_QuarterName) ? "" : smodel.QUpdateParking_QuarterName);

            cmd.Parameters.AddWithValue("p_ParkingType", String.IsNullOrEmpty(smodel.ParkingType) ? "" : smodel.ParkingType);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_TotalArea", smodel.ParkingSpaceUnits_TotalArea);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberAvailableforSale", smodel.ParkingSpaceUnits_NumberAvailableforSale);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberBookedSoldUptoRegistration", smodel.ParkingSpaceUnits_NumberBookedSoldUptoRegistration);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberBookedInQuarter", smodel.ParkingSpaceUnits_NumberBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberCanceledBookedInQuarter", smodel.ParkingSpaceUnits_NumberCanceledBookedInQuarter);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_NumberSoldInQuarter", smodel.ParkingSpaceUnits_NumberSoldInQuarter);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_TotalNumberBooked", smodel.ParkingSpaceUnits_TotalNumberBooked);
            cmd.Parameters.AddWithValue("p_ParkingSpaceUnits_TotalNumberSold", smodel.ParkingSpaceUnits_TotalNumberSold);

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

        public List<ClsPrp_QUpdateProject_ParkingDetails> Display_QUpdateProject_ParkingDetails(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName)
        {
            connection();
            List<ClsPrp_QUpdateProject_ParkingDetails> Projectlist = new List<ClsPrp_QUpdateProject_ParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ParkingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectParking_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectParking_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectParking_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_QUpdateProject_ParkingDetails
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
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_QUpdateProject_ParkingDetails> Display_QUpdateProject_ParkingDetailsByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectParkingIndexID, Int64 QUpdateProjectParkingID, Int64 RelatedProjectParkingIndexID, Int64 RelatedProjectParkingID)
        {
            connection();
            List<ClsPrp_QUpdateProject_ParkingDetails> ProjectList = new List<ClsPrp_QUpdateProject_ParkingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ParkingDetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectParking_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectParking_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectParking_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectParkingIndexID", QUpdateProjectParkingIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectParkingID", QUpdateProjectParkingID);
            cmd.Parameters.AddWithValue("p_RelatedProjectParkingIndexID", RelatedProjectParkingIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectParkingID", RelatedProjectParkingID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_QUpdateProject_ParkingDetails
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
                       });
            }
            return ProjectList;
        }

        public bool Delete_QUpdateProject_ParkingDetailsByID(Int64 ProjectRegistrationID, Int32 QuarterYear, string QuarterName, Int64 QUpdateProjectParkingIndexID, Int64 QUpdateProjectParkingID, Int64 RelatedProjectParkingIndexID, Int64 RelatedProjectParkingID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_ProjectQUpdate_ParkingDetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectParking_ProjectRegistration_ID", ProjectRegistrationID);
            cmd.Parameters.AddWithValue("p_ProjectParking_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectParking_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectParkingIndexID", QUpdateProjectParkingIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectParkingID", QUpdateProjectParkingID);
            cmd.Parameters.AddWithValue("p_RelatedProjectParkingIndexID", RelatedProjectParkingIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectParkingID", RelatedProjectParkingID);

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
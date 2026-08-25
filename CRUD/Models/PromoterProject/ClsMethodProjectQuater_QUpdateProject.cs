using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CRUD.Models.PromoterProject
{
    
    public class ClsMethodProjectQuater_QUpdateProject : clscon
    {
        // I Agree Details count each application id exist in all tables to disable/enable the agree button
        public int QUpdateProjectQuaterAgreeDetails(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            // RecordCount 1 => All tables with records (exists) //(I_Agree => Unlock)
            // RecordCount 0 => Invalid records in all tables //(I_Agree => Lock)
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Quater_Count_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);
                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        // Get Isdraft value From Diary Number table
        public int GetQUValue_FromDiaryNumber(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_IsDraftValue_FromDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Project_ID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_Quarter_Year", QUpdateYear);
                cmd.Parameters.AddWithValue("p_Quarter_Name", QUpdateName);
                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }


        // DISPLAY-QUP (Quaterly Updates)
        #region
        // Get QUpdate Project Inventory and Construction        
        public int QUpdateProjectInventoryConstruction(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Count_InventoryConstruction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Dispose();
                con.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            // retValue (1 Pending, 2 Complete, 3 Confirmed, 4 Closed, 5 Optional, 6 NoRecordsFound)
            return RecordCount;
        }

        // Get QUpdate ParkingDetails  
        public int QUpdateProjectParkingDetails(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Count_ParkingDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        // Get QUpdate Photograph Status with GeoTagging  
        public int QUpdateProjectPhotographStatus(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Count_PhotographStatusDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        // Get QUpdate Internal Facilities  
        public int QUpdateProjectInternalFacilities(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Count_InternalFacilities";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        // Get QUpdate External Facilities  
        public int QUpdateProjectExternalFacilities(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Count_ExternalFacilities";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        // Get QUpdate Approvals
        public int QUpdateProjectApprovals(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_RERA_ProjectQUpdate_Count_ApprovalDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }
        #endregion


        // UPDATE-QUP (Quaterly Updates)
        #region  
        // Update QUP Agree Details
        public string UpdateQUpdateQuaterAgreeDetails(Int64 QUpdatePromoterID, Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName, string UID, string userName)
        {
            string AppId = string.Empty;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_insert_tbl_RERA_Project_QuarterlyUpdate_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                #region Parameters
                cmd.Parameters.AddWithValue("p_QUpdateProject_Year", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateProject_QuarterName", QUpdateName);
                cmd.Parameters.AddWithValue("p_QUpdatePromoter_ID", QUpdatePromoterID);
                cmd.Parameters.AddWithValue("p_QUpdateProject_ID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateUserID", UID);

                cmd.Parameters.AddWithValue("p_QUpdateRERAnumber", "NA");
                cmd.Parameters.AddWithValue("p_QUpdateRERAnumberIssueDate", DateTime.Now);
                cmd.Parameters.AddWithValue("p_QUpdateRERAnumberValidUptoDate", DateTime.Now);

                cmd.Parameters.AddWithValue("p_Extra2", "PRJDiaryNo");
                cmd.Parameters.AddWithValue("p_Extra3", string.Empty);
                cmd.Parameters.AddWithValue("p_Extra4", string.Empty);

                cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);
                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 1);
                cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 0);
                cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
                cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
                cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
                cmd.Parameters.AddWithValue("p_IsActiveProvider", 0);
                cmd.Parameters.AddWithValue("p_IsLock", 1);

                cmd.Parameters.AddWithValue("p_CreatedBy", userName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", userName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

                MySqlParameter AppPar = new MySqlParameter("p_Return_QUProjectRegDiaryNumber_Name", MySqlDbType.VarChar, 50);
                AppPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(AppPar);
                #endregion

                int i = cmd.ExecuteNonQuery();

                AppId = Convert.ToString(AppPar.Value);
                cmd.Dispose();
                con.Close();                
            }
            catch (Exception ex)
            {
                ex.ToString();
                AppId = Convert.ToString("Error");
            }
            return AppId;
        }

        // Update QUpdate Project Inventory and Construction
        public bool UpdateQUpdateProjectInventoryConstruction(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_RERA_ProjectQUpdate_Count_InventoryConstruction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        // Update QUpdate Project Parking Details
        public bool UpdateQUpdateProjectParkingDetails(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_RERA_ProjectQUpdate_Count_ParkingDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        // Update QUpdate Photograph Status with GeoTagging
        public bool UpdateQUpdatePhotographStatusGeoTagging(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_RERA_ProjectQUpdate_Count_PhotographStatusGeoTagging";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        // Update QUpdate Internal Facilities
        public bool UpdateQUpdateInternalFacilities(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_RERA_ProjectQUpdate_Count_InternalFacilities";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        // Update QUpdate External Facilities
        public bool UpdateQUpdateExternalFacilities(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_RERA_ProjectQUpdate_Count_ExternalFacilities";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }

        // Update QUpdate Approvals
        public bool UpdateQUpdateApprovals(Int64 QUpdateProjectID, Int32 QUpdateYear, string QUpdateName)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_update_RERA_ProjectQUpdate_Count_ProjectApprovals";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_QUpdateProjectID", QUpdateProjectID);
                cmd.Parameters.AddWithValue("p_QUpdateYear", QUpdateYear);
                cmd.Parameters.AddWithValue("p_QUpdateName", QUpdateName);

                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion
    }
}
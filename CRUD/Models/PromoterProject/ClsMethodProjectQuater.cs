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
    
    public class ClsMethodProjectQuater : clscon
    {
        /// <summary>
        /// Get Project Construction
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>  
        public int Construction(Int64 Application_ID,string A_column,string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_Construction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Dispose();
                con.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return RecordCount;
        }

        /// <summary>
        /// Get Inventory  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Inventory(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_Inventory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);
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

        /// <summary>
        /// Get Facilities  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Facilities(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_Facilities";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);
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

        /// <summary>
        /// Get External Facilities  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ExternalFacilities(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_ExternalFacilities";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);
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


        /// <summary>
        /// Get ParkingDetails  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ParkingDetails(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_ParkingDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);
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

        /// <summary>
        /// Get ProfessionalDetails  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ProfessionalDetails(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_ProfessionalDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);
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

        /// <summary>
        /// Get Documents photograph  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int photograph(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_photograph";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);
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
        /// <summary>
        /// I Agree Details count each application id exist in all tables to disable/enable the agree button
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ProjectQuaterAgreeDetails(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Project_Quater_Count_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
                cmd.Parameters.AddWithValue("p_A_column", A_column);
                cmd.Parameters.AddWithValue("p_B_column", B_column);
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
        /// <summary>
        /// Get Isdraft value From Diary Number table
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Isdraftvalue_FromDiaryNumber(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Project_Quater_Isdraftvalue_FromDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
                cmd.Parameters.AddWithValue("p_A_column", A_column);
                cmd.Parameters.AddWithValue("p_B_column", B_column);
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
        /////UPDATE Quater STARTS
        /// <summary>
        /// Update Quater Agree Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public string UpdateQuaterAgreeDetails(Int64 PromoterApplicationId,Int64 Application_ID, string A_column, string B_column, string UID, string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_insert_tbl_RERA_Project_Quater_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
      
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_ID", AgentRegDiaryNumber_ID);
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_Name", AgentRegDiaryNumber_Name);
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_NameYear", AgentRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterApplicationId);
            cmd.Parameters.AddWithValue("p_UserID", UID);
            cmd.Parameters.AddWithValue("p_Project_ID", Application_ID);//project id 

            cmd.Parameters.AddWithValue("p_Quater", A_column);
            cmd.Parameters.AddWithValue("p_Year", B_column);

            cmd.Parameters.AddWithValue("p_Extra2", " ");
            cmd.Parameters.AddWithValue("p_Extra3", " ");
            cmd.Parameters.AddWithValue("p_Extra4", " ");
            
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", "Remarks_IfAny");
            //cmd.Parameters.AddWithValue("p_IsActive", Active);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
             cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 0);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);

            cmd.Parameters.AddWithValue("p_ModifyBy", userName);

            MySqlParameter AppPar = new MySqlParameter("p_Return_Project_QuaterRegDiaryNumber_Name", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);



            int i = cmd.ExecuteNonQuery();


            string AppId = Convert.ToString(AppPar.Value);
            con.Close();
            return AppId;





        }
        #region  


        /// <summary>
        /// Update Construction
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateConstruction(Int64 Application_ID,string A_column,string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Construction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column);cmd.Parameters.AddWithValue("p_B_column", B_column);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Inventory
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateInventory(Int64 Application_ID,string A_column,string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Inventory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column);cmd.Parameters.AddWithValue("p_B_column", B_column);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Facilities
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateFacilities(Int64 Application_ID,string A_column,string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Facilities";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column);cmd.Parameters.AddWithValue("p_B_column", B_column);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Update External Facilities
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateExternalFacilities(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_ExternalFacilities";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Update ParkingDetails
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateParkingDetails(Int64 Application_ID,string A_column,string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_ParkingDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column);cmd.Parameters.AddWithValue("p_B_column", B_column);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update ProfessionalDetails
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateProfessionalDetails(Int64 Application_ID,string A_column,string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_ProfessionalDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column);cmd.Parameters.AddWithValue("p_B_column", B_column);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Update Photograhp
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool Updatephotograph(Int64 Application_ID, string A_column, string B_column)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_photograph";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID); cmd.Parameters.AddWithValue("p_A_column", A_column); cmd.Parameters.AddWithValue("p_B_column", B_column);


            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion
    }
}
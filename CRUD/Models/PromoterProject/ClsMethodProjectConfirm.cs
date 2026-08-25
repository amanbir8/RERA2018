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
    public class ClsMethodProjectConfirm: clscon
    {
        /// <summary>
        /// Get Project Reg
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int projectReg(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_Registration";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get Litigations  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Litigations(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_Litigations";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get Project Litigation View Flag  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public string ProjectLitigationViewFlag(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string ProjectLitigationViewFlag = "NO";

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Count_Project_LitigationViewFlag";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
                cmd.ExecuteNonQuery();
                int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();  
                              
                if (RecordCount == 22)
                {
                    ProjectLitigationViewFlag = "YES";
                }
            }
            catch(Exception ex)
            {
                string varEX = ex.ToString();
            }
            return ProjectLitigationViewFlag;
        }

        /// <summary>
        /// Get LandDetails  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int LandDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_LandDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get ApprovalDetails  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ApprovalDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_ApprovalDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get KhasraAreaDetails  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int KhasraAreaDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_KhasraAreaDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get Payment  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Payment(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_Payment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get SpecialBankAccountDetails  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int SpecialBankAccountDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_SpecialBankAccountDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Get Documents Details  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Documents(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_Document";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }
        /// <summary>
        /// Get Documents photograph  
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int photograph(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_Project_photograph";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }

        /// <summary>
        /// Project Quater Detail 
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Method_Quater_Project(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Count_ProjectQuaterDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }


        /// <summary>
        /// I Agree Details count each application id exist in all tables to disable/enable the agree button
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int ProjectAgreeDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int RecordCount = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Display_Rera_Project_Count_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

                cmd.ExecuteNonQuery();
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                string tex = ex.ToString();
            }
            return RecordCount;


        }

        
        /// <summary>
        /// Get Isdraft value From Diary Number table
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public int Isdraftvalue_FromDiaryNumber(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Display_Rera_Project_Isdraftvalue_FromDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);
            cmd.ExecuteNonQuery();
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RecordCount;
        }
        /////UPDATE STARTS

        /// <summary>
        /// Update  Agree Details
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public string UpdateAgreeDetails(Int64 PromoterApplicationId, Int64 Application_ID, string UID, string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_insert_tbl_RERA_Project_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_ID", AgentRegDiaryNumber_ID);
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_Name", AgentRegDiaryNumber_Name);
            //cmd.Parameters.AddWithValue("p_PromoterRegDiaryNumber_NameYear", AgentRegDiaryNumber_NameYear);
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterApplicationId);
            cmd.Parameters.AddWithValue("p_UserID", UID);
            cmd.Parameters.AddWithValue("p_Project_ID", Application_ID);//project id 

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

            MySqlParameter AppPar = new MySqlParameter("p_Return_Project_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);



            int i = cmd.ExecuteNonQuery();


            string AppId = Convert.ToString(AppPar.Value);
            con.Close();
            return AppId;





        }
        #region  


        /// <summary>
        /// Update Registration
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateRegistration(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Registration";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update Litigations
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateLitigations(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Litigations";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update LandDetails
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateLandDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_LandDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update KhasraAreaDetails
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateKhasraAreaDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_KhasraAreaDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update ApprovalDetails
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateApprovalDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_ApprovalDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update Payment
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdatePayment(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Payment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update SpecialBankAccountDetails
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateSpecialBankAccountDetails(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_SpecialBankAccountDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

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
        /// Update Documents
        /// </summary>
        /// <param name="Application_ID"></param>
        /// <returns></returns>
        public bool UpdateDocuments(Int64 Application_ID)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_update_Rera_Count_Project_Document";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

            //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



        ///////// <summary>
        ///////// Update Photograhp
        ///////// </summary>
        ///////// <param name="Application_ID"></param>
        ///////// <returns></returns>
        //////public bool Updatephotograph(Int64 Application_ID)
        //////{
        //////    if (con.State == ConnectionState.Closed)
        //////    {
        //////        con.Open();
        //////    }

        //////    MySqlCommand cmd = new MySqlCommand();
        //////    cmd.CommandText = "usp_update_Rera_Count_Project_photograph";
        //////    cmd.CommandType = CommandType.StoredProcedure;
        //////    cmd.Connection = con;
        //////    cmd.Parameters.AddWithValue("p_Application_ID", Application_ID);

        //////    //  int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

        //////    int i = cmd.ExecuteNonQuery();
        //////    cmd.Dispose();
        //////    con.Close();

        //////    if (i >= 1)
        //////        return true;
        //////    else
        //////        return false;
        //////}
        #endregion
    }
}
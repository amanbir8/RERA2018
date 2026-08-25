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
    public class ClsMethod_View_Project_Updates_ProfessionalDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
                
        public List<ClsPrp_AuthDesk_View_ProjectProfessionalDetails> Display_AuthDesk_ProjectProfessionalDetails(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {
            connection();

            List<ClsPrp_AuthDesk_View_ProjectProfessionalDetails> ProjectFivelist1 = new List<ClsPrp_AuthDesk_View_ProjectProfessionalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ProfessionalDetailsForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectProfessional_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_View_ProjectProfessionalDetails
                       {
                           ProjectProfessional_IndexID = Convert.ToInt64(dr["ProjectProfessional_IndexID"]),
                           ProjectProfessional_ID = Convert.ToInt64(dr["ProjectProfessional_ID"]),
                           ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectProfessionalRelated_ProjectRegistration_ID"]),
                           Associated_Consultant_Type = Convert.ToString(dr["Associated_Consultant_Type"]),
                           Name_of_Professional = Convert.ToString(dr["Name_of_Professional"]),
                           RERA_ID_IfAgent = Convert.ToString(dr["RERA_ID_IfAgent"]),
                           Name_and_Year_of_Establishment_of_Promoter = Convert.ToString(dr["Name_and_Year_of_Establishment_of_Promoter"]),
                           Name_and_Profile_of_Key_ProjectsCompleted = Convert.ToString(dr["Name_and_Profile_of_Key_ProjectsCompleted"]),
                           OfficialComm_AddressLine1 = Convert.ToString(dr["OfficialComm_AddressLine1"]),
                           OfficialComm_AddressLine2 = Convert.ToString(dr["OfficialComm_AddressLine2"]),
                           OfficialComm_AddressStateCode = Convert.ToString(dr["OfficialComm_AddressStateCode"]),
                           OfficialComm_AddressDistrictCode = Convert.ToString(dr["OfficialComm_AddressDistrictCode"]),
                           OfficialComm_AddressPIN = Convert.ToString(dr["OfficialComm_AddressPIN"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           Phone_STD = Convert.ToInt64(dr["Phone_STD"]),
                           Phone_Number = Convert.ToInt64(dr["Phone_Number"]),
                           Email_ID = Convert.ToString(dr["Email_ID"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),


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
        
        public Int32 Update_LockUnLockHandler_Project_ProfessionalDetails(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg, string QuarterName, Int32 QuarterYear)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_projectprofessionaldetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_ProfessionalsIndexID", IndexID);
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
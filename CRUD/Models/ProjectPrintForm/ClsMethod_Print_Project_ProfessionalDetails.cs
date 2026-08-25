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
    public class ClsMethod_Print_Project_ProfessionalDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        
        public List<ClsPrp_PrmProject_Print_ProjectProfessionalDetails> Display_AuthDesk_ProjectProfessionalDetails(Int64 ProjectRegistration_ID, Int64 QuarterYear, string QuarterName)
        {
            connection();

            List<ClsPrp_PrmProject_Print_ProjectProfessionalDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectProfessionalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ProfessionalDetails_ForPrint", con);
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
                       new ClsPrp_PrmProject_Print_ProjectProfessionalDetails
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
    }
}
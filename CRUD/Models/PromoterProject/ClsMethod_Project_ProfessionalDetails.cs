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
    public class ClsMethod_Project_ProfessionalDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_ProfessionalDetails(ClsPrp_Project_ProfessionalDetails smodel, Int64 Project_id)//, string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_ProfessionalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_ProjectProfessional_IndexID", smodel.ProjectProfessional_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectProfessional_ID", smodel.ProjectProfessional_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectProfessionalRelated_ProjectRegistration_ID", smodel.ProjectProfessionalRelated_ProjectRegistration_ID);//// smodel.ProjectProfessionalRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_Associated_Consultant_Type", smodel.Associated_Consultant_Type);
            cmd.Parameters.AddWithValue("p_p_Name_of_Professional", smodel.Name_of_Professional);

            cmd.Parameters.AddWithValue("p_p_RERA_ID_IfAgent", String.IsNullOrEmpty(smodel.RERA_ID_IfAgent) ? "" : smodel.RERA_ID_IfAgent);
            cmd.Parameters.AddWithValue("p_p_Name_and_Year_of_Establishment_of_Promoter", smodel.Name_and_Year_of_Establishment_of_Promoter);
            cmd.Parameters.AddWithValue("p_p_Name_and_Profile_of_Key_ProjectsCompleted", smodel.Name_and_Profile_of_Key_ProjectsCompleted);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressLine1", smodel.OfficialComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressLine2", String.IsNullOrEmpty(smodel.OfficialComm_AddressLine2)?"": smodel.OfficialComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressStateCode", smodel.OfficialComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressDistrictCode", smodel.OfficialComm_AddressDistrictCode);

            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressPIN", smodel.OfficialComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_MobileNumber", smodel.MobileNumber);

            cmd.Parameters.AddWithValue("p_p_Phone_STD", smodel.Phone_STD);
            cmd.Parameters.AddWithValue("p_p_Phone_Number", (smodel.Phone_Number==null) ? 0: smodel.Phone_Number);
            cmd.Parameters.AddWithValue("p_p_Email_ID", smodel.Email_ID);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");//smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            //cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            //con.Close();
            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update_Project_ApprovalDetails(ClsPrp_Project_ProfessionalDetails smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_ProfessionalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectProfessional_IndexID", smodel.ProjectProfessional_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectProfessional_ID", smodel.ProjectProfessional_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectProfessionalRelated_ProjectRegistration_ID", smodel.ProjectProfessionalRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_Associated_Consultant_Type", smodel.Associated_Consultant_Type);
            cmd.Parameters.AddWithValue("p_p_Name_of_Professional", smodel.Name_of_Professional);
            cmd.Parameters.AddWithValue("p_p_RERA_ID_IfAgent", String.IsNullOrEmpty(smodel.RERA_ID_IfAgent) ? "" : smodel.RERA_ID_IfAgent);
            cmd.Parameters.AddWithValue("p_p_Name_and_Year_of_Establishment_of_Promoter", smodel.Name_and_Year_of_Establishment_of_Promoter);
            cmd.Parameters.AddWithValue("p_p_Name_and_Profile_of_Key_ProjectsCompleted", smodel.Name_and_Profile_of_Key_ProjectsCompleted);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressLine1", smodel.OfficialComm_AddressLine1);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressLine2", String.IsNullOrEmpty(smodel.OfficialComm_AddressLine2) ? "" : smodel.OfficialComm_AddressLine2);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressStateCode", smodel.OfficialComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressDistrictCode", smodel.OfficialComm_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_p_OfficialComm_AddressPIN", smodel.OfficialComm_AddressPIN);
            cmd.Parameters.AddWithValue("p_p_MobileNumber", smodel.MobileNumber);
            cmd.Parameters.AddWithValue("p_p_Phone_STD", smodel.Phone_STD);
            cmd.Parameters.AddWithValue("p_p_Phone_Number", (smodel.Phone_Number == null) ? 0 : smodel.Phone_Number);
            cmd.Parameters.AddWithValue("p_p_Email_ID", smodel.Email_ID);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", "");
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            // cmd.Parameters.AddWithValue("p_p_C_column", "");
            //cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            // cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "ModifyBy");
            // cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);
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

        public List<ClsPrp_Project_ProfessionalDetails> Display_Project_ProfessionalDetails(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_ProfessionalDetails> ProjectFivelist1 = new List<ClsPrp_Project_ProfessionalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ProfessionalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectProfessional_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ProfessionalDetails
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
                           OfficialComm_AddressStateCode = Convert.ToInt32(dr["OfficialComm_AddressStateCode"]),
                           OfficialComm_AddressDistrictCode = Convert.ToInt32(dr["OfficialComm_AddressDistrictCode"]),
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
        public List<ClsPrp_Project_ProfessionalDetails> Display_Project_ApprovalDetailsById(Int64 ProjectRegistration_ID,Int64 ProjectProfessional_IndexID)
        {

            connection();
            List<ClsPrp_Project_ProfessionalDetails> ProjectFivelist1 = new List<ClsPrp_Project_ProfessionalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ProfessionalDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectProfessional_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectProfessional_IndexID", ProjectProfessional_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ProfessionalDetails
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
                           OfficialComm_AddressStateCode = Convert.ToInt32(dr["OfficialComm_AddressStateCode"]),
                           OfficialComm_AddressDistrictCode = Convert.ToInt32(dr["OfficialComm_AddressDistrictCode"]),
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

        public bool Delete_ProfessionalDetails(Int64 ProjectProfessionalDetailsRelated_ProjectRegistration_ID, Int64 ProjectProfessionalDetails_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_ProfessionalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectProfessionalDetails_IndexID", ProjectProfessionalDetails_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectProfessionalDetailsRelated_ProjectRegistration_ID", ProjectProfessionalDetailsRelated_ProjectRegistration_ID);
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
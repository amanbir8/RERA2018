using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_FormMisc_DiaryNumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> Display_AuthDesk_ComplaintFormMisc_RegDiaryNumber(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMisc_RegDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormMisc_DiaryNumber
                       {
                           ComplaintMisc_IndexID = Convert.ToInt64(dr["ComplaintMisc_IndexID"]),
                           ComplaintMisc_ID = Convert.ToInt64(dr["ComplaintMisc_ID"]),
                           ComplaintMisc_Year = Convert.ToInt64(dr["ComplaintMisc_Year"]),
                           ComplaintMisc_Code = Convert.ToString(dr["ComplaintMisc_Code"]),
                           ComplaintType_MNG = Convert.ToString(dr["ComplaintType_MNG"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineNumber = Convert.ToInt64(dr["Complainant_LandlineNumber"]),
                           Address_for_Communication = Convert.ToString(dr["Address_for_Communication"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Address = Convert.ToString(dr["Project_Address"]),
                           Village_Sector_Tehsil_Location_of_Project = Convert.ToString(dr["Village_Sector_Tehsil_Location_of_Project"]),
                           Complaint_Information_Details = Convert.ToString(dr["Complaint_Information_Details"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> Display_AuthDesk_ComplaintFormMisc_RegDiaryNumberNonMaintainable(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMisc_RegDiaryNumberNonMntble", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormMisc_DiaryNumber
                       {
                           ComplaintMisc_IndexID = Convert.ToInt64(dr["ComplaintMisc_IndexID"]),
                           ComplaintMisc_ID = Convert.ToInt64(dr["ComplaintMisc_ID"]),
                           ComplaintMisc_Year = Convert.ToInt64(dr["ComplaintMisc_Year"]),
                           ComplaintMisc_Code = Convert.ToString(dr["ComplaintMisc_Code"]),
                           ComplaintType_MNG = Convert.ToString(dr["ComplaintType_MNG"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineNumber = Convert.ToInt64(dr["Complainant_LandlineNumber"]),
                           Address_for_Communication = Convert.ToString(dr["Address_for_Communication"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Address = Convert.ToString(dr["Project_Address"]),
                           Village_Sector_Tehsil_Location_of_Project = Convert.ToString(dr["Village_Sector_Tehsil_Location_of_Project"]),
                           Complaint_Information_Details = Convert.ToString(dr["Complaint_Information_Details"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormMisc_RegDiaryNumber(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMisc_RegDiaryNumberForPS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormMisc_DiaryNumber
                       {
                           ComplaintMisc_IndexID = Convert.ToInt64(dr["ComplaintMisc_IndexID"]),
                           ComplaintMisc_ID = Convert.ToInt64(dr["ComplaintMisc_ID"]),
                           ComplaintMisc_Year = Convert.ToInt64(dr["ComplaintMisc_Year"]),
                           ComplaintMisc_Code = Convert.ToString(dr["ComplaintMisc_Code"]),
                           ComplaintType_MNG = Convert.ToString(dr["ComplaintType_MNG"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineNumber = Convert.ToInt64(dr["Complainant_LandlineNumber"]),
                           Address_for_Communication = Convert.ToString(dr["Address_for_Communication"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Address = Convert.ToString(dr["Project_Address"]),
                           Village_Sector_Tehsil_Location_of_Project = Convert.ToString(dr["Village_Sector_Tehsil_Location_of_Project"]),
                           Complaint_Information_Details = Convert.ToString(dr["Complaint_Information_Details"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormMisc_RegDiaryNumberInBox(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMisc_RegDiaryNumberForPSIB", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormMisc_DiaryNumber
                       {
                           ComplaintMisc_IndexID = Convert.ToInt64(dr["ComplaintMisc_IndexID"]),
                           ComplaintMisc_ID = Convert.ToInt64(dr["ComplaintMisc_ID"]),
                           ComplaintMisc_Year = Convert.ToInt64(dr["ComplaintMisc_Year"]),
                           ComplaintMisc_Code = Convert.ToString(dr["ComplaintMisc_Code"]),
                           ComplaintType_MNG = Convert.ToString(dr["ComplaintType_MNG"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineNumber = Convert.ToInt64(dr["Complainant_LandlineNumber"]),
                           Address_for_Communication = Convert.ToString(dr["Address_for_Communication"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Address = Convert.ToString(dr["Project_Address"]),
                           Village_Sector_Tehsil_Location_of_Project = Convert.ToString(dr["Village_Sector_Tehsil_Location_of_Project"]),
                           Complaint_Information_Details = Convert.ToString(dr["Complaint_Information_Details"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> Display_AuthDesk_ComplaintFormMisc_RegDiaryNumberNewComplaint(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMisc_RegDiaryNumberNewCompt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormMisc_DiaryNumber
                       {
                           ComplaintMisc_IndexID = Convert.ToInt64(dr["ComplaintMisc_IndexID"]),
                           ComplaintMisc_ID = Convert.ToInt64(dr["ComplaintMisc_ID"]),
                           ComplaintMisc_Year = Convert.ToInt64(dr["ComplaintMisc_Year"]),
                           ComplaintMisc_Code = Convert.ToString(dr["ComplaintMisc_Code"]),
                           ComplaintType_MNG = Convert.ToString(dr["ComplaintType_MNG"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineNumber = Convert.ToInt64(dr["Complainant_LandlineNumber"]),
                           Address_for_Communication = Convert.ToString(dr["Address_for_Communication"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Address = Convert.ToString(dr["Project_Address"]),
                           Village_Sector_Tehsil_Location_of_Project = Convert.ToString(dr["Village_Sector_Tehsil_Location_of_Project"]),
                           Complaint_Information_Details = Convert.ToString(dr["Complaint_Information_Details"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> Display_AuthDesk_ComplaintFormMisc_RegDiaryNumberOrderJudgements(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormMisc_RegDiaryNumberForOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormMisc_DiaryNumber
                       {
                           ComplaintMisc_IndexID = Convert.ToInt64(dr["ComplaintMisc_IndexID"]),
                           ComplaintMisc_ID = Convert.ToInt64(dr["ComplaintMisc_ID"]),
                           ComplaintMisc_Year = Convert.ToInt64(dr["ComplaintMisc_Year"]),
                           ComplaintMisc_Code = Convert.ToString(dr["ComplaintMisc_Code"]),
                           ComplaintType_MNG = Convert.ToString(dr["ComplaintType_MNG"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineNumber = Convert.ToInt64(dr["Complainant_LandlineNumber"]),
                           Address_for_Communication = Convert.ToString(dr["Address_for_Communication"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Address = Convert.ToString(dr["Project_Address"]),
                           Village_Sector_Tehsil_Location_of_Project = Convert.ToString(dr["Village_Sector_Tehsil_Location_of_Project"]),
                           Complaint_Information_Details = Convert.ToString(dr["Complaint_Information_Details"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }
    }
}
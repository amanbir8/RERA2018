using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsMethod_PrintComplaintFormMisc_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }      

        public List<ClsPrp_Print_FormMisc_Registration> Display_ComplaintFormMisc_Registration_ForPrint(Int64 ComplaintMisc_ID)
        {
            connection();
            List<ClsPrp_Print_FormMisc_Registration> ProjectFivelist1 = new List<ClsPrp_Print_FormMisc_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_Misc_Registrationdetails_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormMisc_ID", ComplaintMisc_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Print_FormMisc_Registration
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

                           ComplaintDocI_InfoName = Convert.ToString(dr["ComplaintDocI_InfoName"]),
                           ComplaintDocI_IssueDate = Convert.ToDateTime(dr["ComplaintDocI_IssueDate"]),
                           ComplaintDocI_FileSize = Convert.ToString(dr["ComplaintDocI_FileSize"]),
                           ComplaintDocI_FileFormat = Convert.ToString(dr["ComplaintDocI_FileFormat"]),
                           ComplaintDocI_FilePath = Convert.ToString(dr["ComplaintDocI_FilePath"]),
                           ComplaintDocI_FileName = Convert.ToString(dr["ComplaintDocI_FileName"]),
                           ComplaintDocI_PageStartNumber = Convert.ToInt32(dr["ComplaintDocI_PageStartNumber"]),
                           ComplaintDocI_PageEndNumber = Convert.ToInt32(dr["ComplaintDocI_PageEndNumber"]),

                           ComplaintDocII_InfoName = Convert.ToString(dr["ComplaintDocII_InfoName"]),
                           ComplaintDocII_IssueDate = Convert.ToDateTime(dr["ComplaintDocII_IssueDate"]),
                           ComplaintDocII_FileSize = Convert.ToString(dr["ComplaintDocII_FileSize"]),
                           ComplaintDocII_FileFormat = Convert.ToString(dr["ComplaintDocII_FileFormat"]),
                           ComplaintDocII_FilePath = Convert.ToString(dr["ComplaintDocII_FilePath"]),
                           ComplaintDocII_FileName = Convert.ToString(dr["ComplaintDocII_FileName"]),
                           ComplaintDocII_PageStartNumber = Convert.ToInt32(dr["ComplaintDocII_PageStartNumber"]),
                           ComplaintDocII_PageEndNumber = Convert.ToInt32(dr["ComplaintDocII_PageEndNumber"]),

                           ComplaintDocIII_InfoName = Convert.ToString(dr["ComplaintDocIII_InfoName"]),
                           ComplaintDocIII_IssueDate = Convert.ToDateTime(dr["ComplaintDocIII_IssueDate"]),
                           ComplaintDocIII_FileSize = Convert.ToString(dr["ComplaintDocIII_FileSize"]),
                           ComplaintDocIII_FileFormat = Convert.ToString(dr["ComplaintDocIII_FileFormat"]),
                           ComplaintDocIII_FilePath = Convert.ToString(dr["ComplaintDocIII_FilePath"]),
                           ComplaintDocIII_FileName = Convert.ToString(dr["ComplaintDocIII_FileName"]),
                           ComplaintDocIII_PageStartNumber = Convert.ToInt32(dr["ComplaintDocIII_PageStartNumber"]),
                           ComplaintDocIII_PageEndNumber = Convert.ToInt32(dr["ComplaintDocIII_PageEndNumber"]),

                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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
                       });
            }
            return ProjectFivelist1;
        }
    }
}
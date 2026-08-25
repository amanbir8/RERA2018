using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_ComplaintMisc_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public string Add_ComplaintMisc_Registration(ClsPrp_AuthorityDesk_Misc_Registration smodel, string filepathI, string fileNameI, string filesizeI, string fileformatI, string filepathII, string fileNameII, string filesizeII, string fileformatII)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_misc_RegDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintMisc_IndexID", smodel.ComplaintMisc_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintMisc_ID",  smodel.ComplaintMisc_ID);
            cmd.Parameters.AddWithValue("p_ComplaintMisc_Year", smodel.ComplaintMisc_Year);
            cmd.Parameters.AddWithValue("p_ComplaintMisc_Code", String.IsNullOrEmpty(smodel.ComplaintMisc_Code) ? "" : smodel.ComplaintMisc_Code);
            cmd.Parameters.AddWithValue("p_ComplaintType_MNG", "FormTypeMISC");
            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? "" : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", String.IsNullOrEmpty(smodel.Complainant_EmailAddress) ? "" : smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber == null ? 0 : smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineNumber", smodel.Complainant_LandlineNumber == null ? 0 : smodel.Complainant_LandlineNumber);
            cmd.Parameters.AddWithValue("p_Address_for_Communication", String.IsNullOrEmpty(smodel.Address_for_Communication) ? "" : smodel.Address_for_Communication);
            cmd.Parameters.AddWithValue("p_Project_Name", String.IsNullOrEmpty(smodel.Project_Name) ? "" : smodel.Project_Name);
            cmd.Parameters.AddWithValue("p_Project_Address", String.IsNullOrEmpty(smodel.Project_Address) ? "" : smodel.Project_Address);
            cmd.Parameters.AddWithValue("p_Village_Sector_Tehsil_Location_of_Project", String.IsNullOrEmpty(smodel.Village_Sector_Tehsil_Location_of_Project) ? "" : smodel.Village_Sector_Tehsil_Location_of_Project);
            cmd.Parameters.AddWithValue("p_Complaint_Information_Details", String.IsNullOrEmpty(smodel.Complaint_Information_Details) ? "" : smodel.Complaint_Information_Details);

            cmd.Parameters.AddWithValue("p_ComplaintDocI_InfoName", String.IsNullOrEmpty(smodel.ComplaintDocI_InfoName) ? "" : smodel.ComplaintDocI_InfoName);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_IssueDate", smodel.ComplaintDocI_IssueDate == null ? dtvalue : smodel.ComplaintDocI_IssueDate);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_FileSize", String.IsNullOrEmpty(filesizeI) ? "" : filesizeI);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_FileFormat", String.IsNullOrEmpty(fileformatI) ? "" : fileformatI);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_FilePath", String.IsNullOrEmpty(filepathI) ? "" : filepathI);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_FileName", String.IsNullOrEmpty(fileNameI) ? "" : fileNameI);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_PageStartNumber", smodel.ComplaintDocI_PageStartNumber == null ? 0 : smodel.ComplaintDocI_PageStartNumber);
            cmd.Parameters.AddWithValue("p_ComplaintDocI_PageEndNumber", smodel.ComplaintDocI_PageEndNumber == null ? 0 : smodel.ComplaintDocI_PageEndNumber);

            cmd.Parameters.AddWithValue("p_ComplaintDocII_InfoName", String.IsNullOrEmpty(smodel.ComplaintDocII_InfoName) ? "" : smodel.ComplaintDocII_InfoName);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_IssueDate", smodel.ComplaintDocII_IssueDate == null ? dtvalue : smodel.ComplaintDocII_IssueDate);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_FileSize", String.IsNullOrEmpty(filesizeII) ? "" : filesizeII);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_FileFormat", String.IsNullOrEmpty(fileformatII) ? "" : fileformatII);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_FilePath", String.IsNullOrEmpty(filepathII) ? "" : filepathII);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_FileName", String.IsNullOrEmpty(fileNameII) ? "" : fileNameII);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_PageStartNumber", smodel.ComplaintDocII_PageStartNumber == null ? 0 : smodel.ComplaintDocII_PageStartNumber);
            cmd.Parameters.AddWithValue("p_ComplaintDocII_PageEndNumber", smodel.ComplaintDocII_PageEndNumber == null ? 0 : smodel.ComplaintDocII_PageEndNumber);

            cmd.Parameters.AddWithValue("p_ComplaintDocIII_InfoName", String.IsNullOrEmpty(smodel.ComplaintDocIII_InfoName) ? "" : smodel.ComplaintDocIII_InfoName);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_IssueDate", smodel.ComplaintDocIII_IssueDate == null ? dtvalue : smodel.ComplaintDocIII_IssueDate);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_FileSize", String.IsNullOrEmpty(smodel.ComplaintDocIII_FileSize) ? "" : smodel.ComplaintDocIII_FileSize);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_FileFormat", String.IsNullOrEmpty(smodel.ComplaintDocIII_FileFormat) ? "" : smodel.ComplaintDocIII_FileFormat);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_FilePath", String.IsNullOrEmpty(smodel.ComplaintDocIII_FilePath) ? "" : smodel.ComplaintDocIII_FilePath);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_FileName", String.IsNullOrEmpty(smodel.ComplaintDocIII_FileName) ? "" : smodel.ComplaintDocIII_FileName);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_PageStartNumber", smodel.ComplaintDocIII_PageStartNumber == null ? 0 : smodel.ComplaintDocIII_PageStartNumber);
            cmd.Parameters.AddWithValue("p_ComplaintDocIII_PageEndNumber", smodel.ComplaintDocIII_PageEndNumber == null ? 0 : smodel.ComplaintDocIII_PageEndNumber);

            cmd.Parameters.AddWithValue("p_IsVerificationComplete", 1);
            cmd.Parameters.AddWithValue("p_ComplaintVerificationDate", smodel.ComplaintVerificationDate == null ? dtvalue : smodel.ComplaintVerificationDate);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 0);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);

            cmd.Parameters.AddWithValue("p_CreatedBy", "MiscComplainant");
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", "MiscComplainant");
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);            
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_Return_ComplaintMISC_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = Convert.ToString(AppPar.Value);
            con.Close();

            if (i >= 0)
                return AppId;
            else
                return "0";
        }
        
        public DateTime datefun(string valuedate)
        {
            DateTime defaultdate = new DateTime(1919, 1, 1);
            if (valuedate != DBNull.Value.ToString())
            {
                IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
                String datetime = valuedate.Trim();
                DateTime dt = DateTime.Parse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                return dt;
            }
            else
                return defaultdate;
        }

        public List<ClsPrp_AuthorityDesk_Misc_Registration> Display_ComplaintMisc_Registration_ForDesk(Int64 ComplaintMisc_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_Misc_Registration> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_Misc_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_Misc_Registrationdetails_ForDesk", con);
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
                       new ClsPrp_AuthorityDesk_Misc_Registration
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
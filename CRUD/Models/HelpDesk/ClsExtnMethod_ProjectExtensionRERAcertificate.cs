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
    public class ClsExtnMethod_ProjectExtensionRERAcertificate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_LDR_ExtensionFormProject_RERAcertifcate_DiaryNumber(ClsPrp_ExtensionAuthorityDesk_ProjectExtnForm_RegistrationCertificate smodel, Int64 vProject_id, Int64 vPromoter_id, String vFileName, String vFilePath, string vUser_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_ExtnForm_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters 
            cmd.Parameters.AddWithValue("p_ExtnRegdProjectCertificate_IndexID", (smodel.ExtnRegdProjectCertificate_IndexID == 0) ? 0 : smodel.ExtnRegdProjectCertificate_IndexID);
            cmd.Parameters.AddWithValue("p_ExtnRegdProjectCertificate_ID", (smodel.ExtnRegdProjectCertificate_ID == 0) ? 0 : smodel.ExtnRegdProjectCertificate_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.RelatedProjectRegDiaryNumber_Name) ? "0" : smodel.RelatedProjectRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedExtnProjectRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.RelatedExtnProjectRegDiaryNumber_Name) ? "0" : smodel.RelatedExtnProjectRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_tbl_IndexID", (smodel.RelatedProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.RelatedProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", (vPromoter_id == 0) ? 0 : vPromoter_id);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", (vProject_id == 0) ? 0 : vProject_id);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoCode", (smodel.ProjectRERAcert_InfoCode == 0) ? 0 : smodel.ProjectRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoName", String.IsNullOrEmpty(smodel.ProjectRERAcert_InfoName) ? "" : smodel.ProjectRERAcert_InfoName);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.ProjectRERAcert_ReferenceNumber) ? "" : smodel.ProjectRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IssueDate", smodel.ProjectRERAcert_IssueDate);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileSize", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileSize) ? "" : smodel.ProjectRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileFormat", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileFormat) ? "" : smodel.ProjectRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FilePath", String.IsNullOrEmpty(vFilePath) ? "" : vFilePath);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileName", String.IsNullOrEmpty(vFileName) ? "" : vFileName);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IsGroup", (smodel.ProjectRERAcert_IsGroup == 0) ? 0 : smodel.ProjectRERAcert_IsGroup);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_ExtnRegistrationNumber", String.IsNullOrEmpty(smodel.ExtnRegistrationNumber) ? "" : smodel.ExtnRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationIssueDate", smodel.ExtnRegistrationIssueDate);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationRegUptoDate", smodel.ExtnRegistrationRegUptoDate);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", 1);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", vUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", vUser_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_LDR_ExtensionFormProject_RERAcertifcate_DiaryNumber(ClsPrp_ExtensionAuthorityDesk_ProjectExtnForm_RegistrationCertificate smodel, Int64 vProject_id, Int64 vPromoter_id, String vFileName, String vFilePath, string vUser_Name)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Project_ExtnForm_AuthorityDesk_RERAnumberCert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ExtnRegdProjectCertificate_IndexID", (smodel.ExtnRegdProjectCertificate_IndexID == 0) ? 0 : smodel.ExtnRegdProjectCertificate_IndexID);
            cmd.Parameters.AddWithValue("p_ExtnRegdProjectCertificate_ID", (smodel.ExtnRegdProjectCertificate_ID == 0) ? 0 : smodel.ExtnRegdProjectCertificate_ID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.RelatedProjectRegDiaryNumber_Name) ? "0" : smodel.RelatedProjectRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedExtnProjectRegDiaryNumber_Name", String.IsNullOrEmpty(smodel.RelatedExtnProjectRegDiaryNumber_Name) ? "0" : smodel.RelatedExtnProjectRegDiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_tbl_IndexID", (smodel.RelatedProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.RelatedProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectRegDiaryNumber_CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_RelatedPromoter_ID", (vPromoter_id == 0) ? 0 : vPromoter_id);
            cmd.Parameters.AddWithValue("p_RelatedProject_ID", (vProject_id == 0) ? 0 : vProject_id);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoCode", (smodel.ProjectRERAcert_InfoCode == 0) ? 0 : smodel.ProjectRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoName", String.IsNullOrEmpty(smodel.ProjectRERAcert_InfoName) ? "" : smodel.ProjectRERAcert_InfoName);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.ProjectRERAcert_ReferenceNumber) ? "" : smodel.ProjectRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IssueDate", smodel.ProjectRERAcert_IssueDate);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileSize", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileSize) ? "" : smodel.ProjectRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileFormat", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileFormat) ? "" : smodel.ProjectRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FilePath", String.IsNullOrEmpty(vFilePath) ? "" : vFilePath);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileName", String.IsNullOrEmpty(vFileName) ? "" : vFileName);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IsGroup", (smodel.ProjectRERAcert_IsGroup == 0) ? 0 : smodel.ProjectRERAcert_IsGroup);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? "" : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_ExtnRegistrationNumber", String.IsNullOrEmpty(smodel.ExtnRegistrationNumber) ? "" : smodel.ExtnRegistrationNumber);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationIssueDate", smodel.ExtnRegistrationIssueDate);
            cmd.Parameters.AddWithValue("p_ExtnRegistrationRegUptoDate", smodel.ExtnRegistrationRegUptoDate);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", (smodel.IsDraftMember == 0) ? 0 : smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", (smodel.IsCertificateIssued == 0) ? 0 : smodel.IsCertificateIssued);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", 1);
            cmd.Parameters.AddWithValue("p_IsWithdrawn", (smodel.IsWithdrawn == 0) ? 0 : smodel.IsWithdrawn);

            cmd.Parameters.AddWithValue("p_CreatedBy", vUser_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", vUser_Name);
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

        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnForm_RegistrationCertificate> Display_AuthDesk_ProjectExtnForm_RERAcertificate_ByIDandDNumber(Int64 pProject_ID, Int64 pPromoter_ID, string pExtnFormDNumber)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnForm_RegistrationCertificate> ProjectList = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnForm_RegistrationCertificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RERAnumberExtensionCertificate_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", pProject_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", pPromoter_ID);
            cmd.Parameters.AddWithValue("p_ExtnForm_DiaryNumber", pExtnFormDNumber);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_ExtensionAuthorityDesk_ProjectExtnForm_RegistrationCertificate
                       {
                           ExtnRegdProjectCertificate_IndexID = Convert.ToInt64(dr["ExtnRegdProjectCertificate_IndexID"]),
                           ExtnRegdProjectCertificate_ID = Convert.ToInt64(dr["ExtnRegdProjectCertificate_ID"]),
                           RelatedProjectRegDiaryNumber_Name = Convert.ToString(dr["RelatedProjectRegDiaryNumber_Name"]),
                           RelatedExtnProjectRegDiaryNumber_Name = Convert.ToString(dr["RelatedExtnProjectRegDiaryNumber_Name"]),
                           RelatedProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["RelatedProjectRegDiaryNumber_tbl_IndexID"]),
                           RelatedProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["RelatedProjectRegDiaryNumber_CreatedDate"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectRERAcert_InfoCode = Convert.ToInt32(dr["ProjectRERAcert_InfoCode"]),
                           ProjectRERAcert_InfoName = Convert.ToString(dr["ProjectRERAcert_InfoName"]),
                           //ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           ProjectRERAcert_FileSize = Convert.ToString(dr["ProjectRERAcert_FileSize"]),
                           ProjectRERAcert_FileFormat = Convert.ToString(dr["ProjectRERAcert_FileFormat"]),
                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_IsGroup = Convert.ToInt32(dr["ProjectRERAcert_IsGroup"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ExtnRegistrationNumber = Convert.ToString(dr["ExtnRegistrationNumber"]),
                           ExtnRegistrationIssueDate = Convert.ToDateTime(dr["ExtnRegistrationIssueDate"]),
                           ExtnRegistrationRegUptoDate = Convert.ToDateTime(dr["ExtnRegistrationRegUptoDate"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsCertificateIssued = Convert.ToInt32(dr["IsCertificateIssued"]),
                           IsExtensionIssued = Convert.ToInt32(dr["IsExtensionIssued"]),
                           IsWithdrawn = Convert.ToInt32(dr["IsWithdrawn"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectList;
        }

        public bool Delete_AuthDesk_ExtensionFormProjectRERAcertificateDetailsById(Int64? mExtnFormCert_IndexID, Int64? mExtnFormCert_ID, Int64? mProject_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_Project_ExtnForm_RegistrationCertificateByID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ExtnFormCert_IndexID", mExtnFormCert_IndexID);
            cmd.Parameters.AddWithValue("p_ExtnFormCert_ID", mExtnFormCert_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", mProject_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public Int32 Update_PublicUnpublicHandler_ProjectExtensionCertificateByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, string PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_project_ExtensionCertificateByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", 0);
            cmd.Parameters.AddWithValue("p_RelatedRefIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_RelatedRefID", RelatedRefID);
            cmd.Parameters.AddWithValue("p_PublicUnpublicValue", PublicUnpublicCode);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
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
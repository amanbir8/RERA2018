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
    public class ClsMethod_ViewAdd_ProjectRERAcertificate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_LDR_Project_RERAcertifcate_DiaryNumber(ClsPrp_AuthorityDesk_ProjectRERA_Certificate smodel, Int64 vProject_id, Int64 vPromoter_id, String vPhoto_Address, String vextpath, string vUser_Name, string vUserID, string vProject_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters                        
            cmd.Parameters.AddWithValue("p_ProjectRERAcertificate_IndexID", (smodel.ProjectRERAcertificate_IndexID == 0) ? 0 : smodel.ProjectRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRERAcertificate_ID", (smodel.ProjectRERAcertificate_ID == 0) ? 0 : smodel.ProjectRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", String.IsNullOrEmpty(vProject_DiaryNumber) ? "" : vProject_DiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_tbl_IndexID", (smodel.ProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.ProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Promoter_ID", (vPromoter_id == 0) ? 0 : vPromoter_id);
            cmd.Parameters.AddWithValue("p_Project_ID", (vProject_id == 0) ? 0 : vProject_id);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(vUserID) ? "" : vUserID);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoCode", String.IsNullOrEmpty(smodel.ProjectRERAcert_InfoCode) ? "0" : smodel.ProjectRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoName", String.IsNullOrEmpty(smodel.ProjectRERAcert_InfoName) ? "" : smodel.ProjectRERAcert_InfoName);            
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.ProjectRERAcert_ReferenceNumber) ? "" : smodel.ProjectRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IssueDate", smodel.ProjectRERAcert_IssueDate);
            
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileSize", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileSize) ? "" : smodel.ProjectRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileFormat", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileFormat) ? "" : smodel.ProjectRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FilePath", String.IsNullOrEmpty(vextpath) ? "" : vextpath);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileName", String.IsNullOrEmpty(vPhoto_Address) ? "" : vPhoto_Address);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IsGroup", (smodel.ProjectRERAcert_IsGroup == 0) ? 0 : smodel.ProjectRERAcert_IsGroup);
            
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
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", 1);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", (smodel.IsExtensionIssued == 0) ? 0 : smodel.IsExtensionIssued);
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

        public bool Update_LDR_Project_RERAcertifcate_DiaryNumber(ClsPrp_AuthorityDesk_ProjectRERA_Certificate smodel, Int64 vProject_id, Int64 vPromoter_id, String vPhoto_Address, String vextpath, string vUser_Name, string vUserID, string vProject_DiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Project_AuthorityDesk_RERAnumberCertificate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectRERAcertificate_IndexID", (smodel.ProjectRERAcertificate_IndexID == 0) ? 0 : smodel.ProjectRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRERAcertificate_ID", (smodel.ProjectRERAcertificate_ID == 0) ? 0 : smodel.ProjectRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", String.IsNullOrEmpty(vProject_DiaryNumber) ? "" : vProject_DiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_tbl_IndexID", (smodel.ProjectRegDiaryNumber_tbl_IndexID == 0) ? 0 : smodel.ProjectRegDiaryNumber_tbl_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Promoter_ID", (vPromoter_id == 0) ? 0 : vPromoter_id);
            cmd.Parameters.AddWithValue("p_Project_ID", (vProject_id == 0) ? 0 : vProject_id);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(vUserID) ? "" : vUserID);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoCode", String.IsNullOrEmpty(smodel.ProjectRERAcert_InfoCode) ? "0" : smodel.ProjectRERAcert_InfoCode);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_InfoName", String.IsNullOrEmpty(smodel.ProjectRERAcert_InfoName) ? "" : smodel.ProjectRERAcert_InfoName);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_ReferenceNumber", String.IsNullOrEmpty(smodel.ProjectRERAcert_ReferenceNumber) ? "" : smodel.ProjectRERAcert_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IssueDate", smodel.ProjectRERAcert_IssueDate);

            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileSize", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileSize) ? "" : smodel.ProjectRERAcert_FileSize);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileFormat", String.IsNullOrEmpty(smodel.ProjectRERAcert_FileFormat) ? "" : smodel.ProjectRERAcert_FileFormat);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FilePath", String.IsNullOrEmpty(vextpath) ? "" : vextpath);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_FileName", String.IsNullOrEmpty(vPhoto_Address) ? "" : vPhoto_Address);
            cmd.Parameters.AddWithValue("p_ProjectRERAcert_IsGroup", (smodel.ProjectRERAcert_IsGroup == 0) ? 0 : smodel.ProjectRERAcert_IsGroup);

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
            cmd.Parameters.AddWithValue("p_IsCertificateIssued", 1);
            cmd.Parameters.AddWithValue("p_IsExtensionIssued", (smodel.IsExtensionIssued == 0) ? 0 : smodel.IsExtensionIssued);
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

        public List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate> Display_AuthDesk_ProjectRERAcertificate_ByProjectIdandDiaryNumber(Int64 pProject_ID, Int64 pPromoter_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate> ProjectReralist = new List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RERAnumberCertificate_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", pProject_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", pPromoter_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_ProjectRERA_Certificate
                       {
                           ProjectRERAcertificate_IndexID = Convert.ToInt64(dr["ProjectRERAcertificate_IndexID"]),
                           ProjectRERAcertificate_ID = Convert.ToInt64(dr["ProjectRERAcertificate_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),

                           ProjectRegDiaryNumber_tbl_IndexID = Convert.ToInt64(dr["ProjectRegDiaryNumber_tbl_IndexID"]),
                           ProjectRegDiaryNumber_CreatedDate = Convert.ToDateTime(dr["ProjectRegDiaryNumber_CreatedDate"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectRERAcert_InfoCode = Convert.ToString(dr["ProjectRERAcert_InfoCode"]),
                           ProjectRERAcert_InfoName = Convert.ToString(dr["ProjectRERAcert_InfoName"]),
                           //ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),

                           ProjectRERAcert_FileSize = Convert.ToString(dr["ProjectRERAcert_FileSize"]),
                           ProjectRERAcert_FileFormat = Convert.ToString(dr["ProjectRERAcert_FileFormat"]),
                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_IsGroup = Convert.ToInt32(dr["ProjectRERAcert_IsGroup"]),

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
            return ProjectReralist;
        }

        public bool Delete_AuthDesk_ProjectRERAcertificateDetailsById(Int64? mProjectRERAcertificate_IndexID, Int64? mProjectRERAcertificate_ID, Int64? mProject_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_Project_RERAcertificateDetailsById_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectRERAcertificate_IndexID", mProjectRERAcertificate_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectRERAcertificate_ID", mProjectRERAcertificate_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", mProject_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public Int32 Update_PublicUnpublicHandler_ProjectRegistrationCertificateByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, string PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_project_RegistrationCertificateByIndex", con);
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
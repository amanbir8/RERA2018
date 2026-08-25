using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_ProjectDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }       

        public List<Clsprp_AuthDesk_View_ProjectDocuments> Display_Project_Documents_ByProjectId(Int64? ProjectId)
        {
            connection();
            List<Clsprp_AuthDesk_View_ProjectDocuments> Promoter_Documents_PromoterId = new List<Clsprp_AuthDesk_View_ProjectDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Documents_Project_ID_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_AuthDesk_View_ProjectDocuments
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"])

                    });
            }
            return Promoter_Documents_PromoterId;
        }

        public List<Clsprp_AuthDesk_View_ProjectDocuments> Display_Project_Documents_ByProjectIdandFlag(Int64 pProject_ID, string pUserID_Role, Int32 pDocumentCode, Int32 pDocumentSubCode, Int32 pDocumentFlag)
        {
            connection();
            List<Clsprp_AuthDesk_View_ProjectDocuments> Promoter_Documents_PromoterId = new List<Clsprp_AuthDesk_View_ProjectDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Documents_Project_ID_ForDeskByFlag", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", pProject_ID);
            cmd.Parameters.AddWithValue("p_UserID_Role", pUserID_Role);
            cmd.Parameters.AddWithValue("p_Document_Code", pDocumentCode);
            cmd.Parameters.AddWithValue("p_Document_SubCode", pDocumentSubCode);
            cmd.Parameters.AddWithValue("p_Document_Flag", pDocumentFlag);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_AuthDesk_View_ProjectDocuments
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"])

                    });
            }
            return Promoter_Documents_PromoterId;
        }

        public List<Clsprp_AuthDesk_View_ProjectDocuments> Display_Project_TrashDocuments_ByIdFlag(Int64 pProjectID, string pUserID_Role, Int64 pPromoterID, Int32 pDocumentFlag)
        {
            connection();
            List<Clsprp_AuthDesk_View_ProjectDocuments> Promoter_Documents_PromoterId = new List<Clsprp_AuthDesk_View_ProjectDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Documents_Project_ID_TrashByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectID", pProjectID);
            cmd.Parameters.AddWithValue("p_UserIDRole", pUserID_Role);
            cmd.Parameters.AddWithValue("p_PromoterID", pPromoterID);
            cmd.Parameters.AddWithValue("p_DocumentFlag", pDocumentFlag);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_AuthDesk_View_ProjectDocuments
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"])

                    });
            }
            return Promoter_Documents_PromoterId;
        }

        public Int32 Update_LockUnLockHandler_Project_DocumentsListDetails(Int64 ProjectID, Int64 PromoterID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_documentslistdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
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
        
        public Int32 Update_LockUnLockHandler_Project_DocumentDetailsByIndex(Int64 ProjectID, Int64 PromoterID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg, Int64 IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_documentdetailsbyindex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_ProjectDocIndexID", IndexID);            
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
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

        public Int32 Update_PublicUnpublicHandler_Project_DocumentDetailsByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, string PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_tbl_rera_project_documentdetailsbyindex", con);
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
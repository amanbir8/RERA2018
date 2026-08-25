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
    public class ClsMethod_View_QuarterlyUpdatesProjectApprovals
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails> Display_QuarterlyUpdatesProject_StatusOfApprovals(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_StatusOfApprovalsForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdates_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdates_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdates_Flag", viewCriteriaFlag);
            cmd.Parameters.AddWithValue("p_QUpdates_UserRole", UserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails
                       {
                           QUpdateProjectApproval_IndexID = Convert.ToInt64(dr["QUpdateProjectApproval_IndexID"]),
                           QUpdateProjectApproval_ID = Convert.ToInt64(dr["QUpdateProjectApproval_ID"]),
                           Related_ProjectApproval_IndexID = Convert.ToInt64(dr["Related_ProjectApproval_IndexID"]),
                           Related_ProjectApproval_ID = Convert.ToInt64(dr["Related_ProjectApproval_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           Related_ApprovalProjectRegistration_ID = Convert.ToInt64(dr["Related_ApprovalProjectRegistration_ID"]),
                           QUpdateApproval_Year = Convert.ToString(dr["QUpdateApproval_Year"]),
                           QUpdateApproval_QuarterName = Convert.ToString(dr["QUpdateApproval_QuarterName"]),

                           DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                           DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                           DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                           DocumentType_IfOtherSpecifyName = Convert.ToString(dr["DocumentType_IfOtherSpecifyName"]),
                           DocumentType_Status = Convert.ToString(dr["DocumentType_Status"]),
                           Date_ApplicationPlannedorExpectedReceipt = Convert.ToDateTime(dr["Date_ApplicationPlannedorExpectedReceipt"]),
                           DocumentType_FileSize = Convert.ToString(dr["DocumentType_FileSize"]),
                           DocumentType_FileFormat = Convert.ToString(dr["DocumentType_FileFormat"]),
                           DocumentType_FilePath = Convert.ToString(dr["DocumentType_FilePath"]),
                           DocumentType_FileName = Convert.ToString(dr["DocumentType_FileName"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           setQUpdateProject_QuarterName = Convert.ToString(dr["setQUpdateProject_QuarterName"]),
                       });
            }
            return ProjectList;
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails> Display_QuarterlyUpdatesProject_StatusOfApprovalAllRecords(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_StatusOfApprovalsByCodeForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdates_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdates_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_QUpdates_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdates_Flag", viewCriteriaFlag);
            cmd.Parameters.AddWithValue("p_QUpdates_UserRole", UserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProject_ApprovalDetails
                       {
                           QUpdateProjectApproval_IndexID = Convert.ToInt64(dr["QUpdateProjectApproval_IndexID"]),
                           QUpdateProjectApproval_ID = Convert.ToInt64(dr["QUpdateProjectApproval_ID"]),
                           Related_ProjectApproval_IndexID = Convert.ToInt64(dr["Related_ProjectApproval_IndexID"]),
                           Related_ProjectApproval_ID = Convert.ToInt64(dr["Related_ProjectApproval_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           Related_ApprovalProjectRegistration_ID = Convert.ToInt64(dr["Related_ApprovalProjectRegistration_ID"]),
                           QUpdateApproval_Year = Convert.ToString(dr["QUpdateApproval_Year"]),
                           QUpdateApproval_QuarterName = Convert.ToString(dr["QUpdateApproval_QuarterName"]),

                           DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                           DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                           DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                           DocumentType_IfOtherSpecifyName = Convert.ToString(dr["DocumentType_IfOtherSpecifyName"]),
                           DocumentType_Status = Convert.ToString(dr["DocumentType_Status"]),
                           Date_ApplicationPlannedorExpectedReceipt = Convert.ToDateTime(dr["Date_ApplicationPlannedorExpectedReceipt"]),
                           DocumentType_FileSize = Convert.ToString(dr["DocumentType_FileSize"]),
                           DocumentType_FileFormat = Convert.ToString(dr["DocumentType_FileFormat"]),
                           DocumentType_FilePath = Convert.ToString(dr["DocumentType_FilePath"]),
                           DocumentType_FileName = Convert.ToString(dr["DocumentType_FileName"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           setQUpdateProject_QuarterName = Convert.ToString(dr["setQUpdateProject_QuarterName"]),
                       });
            }
            return ProjectList;
        }

        public Int32 Update_PublicUnpublicHandler_QuarterlyUpdatesProject_StatusOfApprovalsByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, string PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_tbl_rera_QUpdatesProject_ApprovalStatusByIndex", con);
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


        //EXTRA-START
        public List<ClsPrp_AuthDesk_View_ProjectApprovalDetails> Display_Project_TrashApprovals_ByIdFlag(Int64 pProjectID, string pUserID_Role, Int64 pPromoterID, Int32 pDocumentFlag)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectApprovalDetails> ProjectApproval = new List<ClsPrp_AuthDesk_View_ProjectApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ApprovalDetails_TrashByID", con);
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
                ProjectApproval.Add(
                    new ClsPrp_AuthDesk_View_ProjectApprovalDetails
                    {
                        ProjectApproval_IndexID = Convert.ToInt64(dr["ProjectApproval_IndexID"]),
                        ProjectApproval_ID = Convert.ToInt64(dr["ProjectApproval_ID"]),
                        ProjectApprovalRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectApprovalRelated_ProjectRegistration_ID"]),
                        DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                        DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                        DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                        DocumentType_Status = Convert.ToString(dr["DocumentType_Status"]),
                        Date_ApplicationPlannedorExpectedReceipt = Convert.ToDateTime(dr["Date_ApplicationPlannedorExpectedReceipt"]),
                        DocumentType_FileSize = Convert.ToString(dr["DocumentType_FileSize"]),
                        DocumentType_FileFormat = Convert.ToString(dr["DocumentType_FileFormat"]),
                        DocumentType_FilePath = Convert.ToString(dr["DocumentType_FilePath"]),
                        DocumentType_FileName = Convert.ToString(dr["DocumentType_FileName"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                    });
            }
            return ProjectApproval;
        }

        public Int32 Update_LockUnLockHandler_Project_ApprovalsListDetails(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_approvalslistdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectApprovalsIndexID", IndexID);
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
        
        public Int32 Update_LockUnLockHandler_Project_ApprovalDetailsByIndex(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_approvaldetailsByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectApprovalsIndexID", IndexID);
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
        //EXTRA-END
    }
}
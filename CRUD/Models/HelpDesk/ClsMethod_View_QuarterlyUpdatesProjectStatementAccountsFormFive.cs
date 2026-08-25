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
    public class ClsMethod_View_QuarterlyUpdatesProjectStatementAccountsFormFive
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive> Display_QuarterlyUpdatesProject_AAReportOnStatementAccountsFormFiveDetails(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_StatementofAccountsFormFive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdates_Flag", viewCriteriaFlag);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive
                       {
                           ProjectStatementofAccounts_IndexID = Convert.ToInt64(dr["ProjectStatementofAccounts_IndexID"]),
                           ProjectStatementofAccounts_ID = Convert.ToInt64(dr["ProjectStatementofAccounts_ID"]),

                           ProjectStatementofAccounts_DiaryNumber = Convert.ToString(dr["ProjectStatementofAccounts_DiaryNumber"]),
                           ProjectStatementofAccounts_DiaryID = Convert.ToInt64(dr["ProjectStatementofAccounts_DiaryID"]),
                           ProjectStatementofAccounts_DiaryYear = Convert.ToInt64(dr["ProjectStatementofAccounts_DiaryYear"]),

                           ProjectStatementofAccountsRelated_ProjectID = Convert.ToInt64(dr["ProjectStatementofAccountsRelated_ProjectID"]),
                           ProjectStatementofAccountsRelated_ProjectName = Convert.ToString(dr["ProjectStatementofAccountsRelated_ProjectName"]),
                           ProjectStatementofAccountsRelated_ProjectDiaryNumber = Convert.ToString(dr["ProjectStatementofAccountsRelated_ProjectDiaryNumber"]),

                           ProjectStatementofAccountsRelated_PromoterID = Convert.ToInt64(dr["ProjectStatementofAccountsRelated_PromoterID"]),
                           ProjectStatementofAccountsRelated_UserID = Convert.ToString(dr["ProjectStatementofAccountsRelated_UserID"]),

                           FinancialYear_EndingOnDate = Convert.ToDateTime(dr["FinancialYear_EndingOnDate"]),
                           FormB_CompletionDate = Convert.ToDateTime(dr["FormB_CompletionDate"]),
                           Percentage_of_Completion = Convert.ToDouble(dr["Percentage_of_Completion"]),
                           ExplanatoryNote = Convert.ToString(dr["ExplanatoryNote"]),
                           CollectedDuring_FinancialYear_Amount_INR = Convert.ToDouble(dr["CollectedDuring_FinancialYear_Amount_INR"]),
                           CollectedTillDate_Amount_INR = Convert.ToDouble(dr["CollectedTillDate_Amount_INR"]),
                           WithdrawDuring_FinancialYear_Amount_INR = Convert.ToDouble(dr["WithdrawDuring_FinancialYear_Amount_INR"]),
                           WithdrawnTillDate_Amount_INR = Convert.ToDouble(dr["WithdrawnTillDate_Amount_INR"]),

                           Amount_A_column = Convert.ToDouble(dr["Amount_A_column"]),
                           Amount_B_column = Convert.ToDouble(dr["Amount_B_column"]),

                           ImageFormFive_FileName = Convert.ToString(dr["ImageFormFive_FileName"]),
                           ImageFormFive_FilePath = Convert.ToString(dr["ImageFormFive_FilePath"]),
                           ImageFormFive_FileSize = Convert.ToString(dr["ImageFormFive_FileSize"]),
                           ImageFormFive_FileFormat = Convert.ToString(dr["ImageFormFive_FileFormat"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsEvaluationDraft = Convert.ToInt32(dr["IsEvaluationDraft"]),
                           IsMemberDraft = Convert.ToInt32(dr["IsMemberDraft"]),
                           IsSecretaryDraft = Convert.ToInt32(dr["IsSecretaryDraft"]),
                           IsAuthorityDraft = Convert.ToInt32(dr["IsAuthorityDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                       });
            }
            return ProjectList;
        }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive> Display_QuarterlyUpdatesProject_AAReportOnStatementAccountsFormFiveAllRecords(Int64 ProjectID, Int64 PromoterID, Int32 QuarterYear, string QuarterName, Int32 viewCriteriaFlag, string UserRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive> ProjectList = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_QUpdatesProject_StatementofAccountsFormFiveForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_QuarterYear", QuarterYear);
            cmd.Parameters.AddWithValue("p_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUpdates_Flag", viewCriteriaFlag);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectStatementofAccountsFormFive
                       {
                           ProjectStatementofAccounts_IndexID = Convert.ToInt64(dr["ProjectStatementofAccounts_IndexID"]),
                           ProjectStatementofAccounts_ID = Convert.ToInt64(dr["ProjectStatementofAccounts_ID"]),

                           ProjectStatementofAccounts_DiaryNumber = Convert.ToString(dr["ProjectStatementofAccounts_DiaryNumber"]),
                           ProjectStatementofAccounts_DiaryID = Convert.ToInt64(dr["ProjectStatementofAccounts_DiaryID"]),
                           ProjectStatementofAccounts_DiaryYear = Convert.ToInt64(dr["ProjectStatementofAccounts_DiaryYear"]),

                           ProjectStatementofAccountsRelated_ProjectID = Convert.ToInt64(dr["ProjectStatementofAccountsRelated_ProjectID"]),
                           ProjectStatementofAccountsRelated_ProjectName = Convert.ToString(dr["ProjectStatementofAccountsRelated_ProjectName"]),
                           ProjectStatementofAccountsRelated_ProjectDiaryNumber = Convert.ToString(dr["ProjectStatementofAccountsRelated_ProjectDiaryNumber"]),

                           ProjectStatementofAccountsRelated_PromoterID = Convert.ToInt64(dr["ProjectStatementofAccountsRelated_PromoterID"]),
                           ProjectStatementofAccountsRelated_UserID = Convert.ToString(dr["ProjectStatementofAccountsRelated_UserID"]),

                           FinancialYear_EndingOnDate = Convert.ToDateTime(dr["FinancialYear_EndingOnDate"]),
                           FormB_CompletionDate = Convert.ToDateTime(dr["FormB_CompletionDate"]),
                           Percentage_of_Completion = Convert.ToDouble(dr["Percentage_of_Completion"]),
                           ExplanatoryNote = Convert.ToString(dr["ExplanatoryNote"]),
                           CollectedDuring_FinancialYear_Amount_INR = Convert.ToDouble(dr["CollectedDuring_FinancialYear_Amount_INR"]),
                           CollectedTillDate_Amount_INR = Convert.ToDouble(dr["CollectedTillDate_Amount_INR"]),
                           WithdrawDuring_FinancialYear_Amount_INR = Convert.ToDouble(dr["WithdrawDuring_FinancialYear_Amount_INR"]),
                           WithdrawnTillDate_Amount_INR = Convert.ToDouble(dr["WithdrawnTillDate_Amount_INR"]),

                           Amount_A_column = Convert.ToDouble(dr["Amount_A_column"]),
                           Amount_B_column = Convert.ToDouble(dr["Amount_B_column"]),

                           ImageFormFive_FileName = Convert.ToString(dr["ImageFormFive_FileName"]),
                           ImageFormFive_FilePath = Convert.ToString(dr["ImageFormFive_FilePath"]),
                           ImageFormFive_FileSize = Convert.ToString(dr["ImageFormFive_FileSize"]),
                           ImageFormFive_FileFormat = Convert.ToString(dr["ImageFormFive_FileFormat"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsEvaluationDraft = Convert.ToInt32(dr["IsEvaluationDraft"]),
                           IsMemberDraft = Convert.ToInt32(dr["IsMemberDraft"]),
                           IsSecretaryDraft = Convert.ToInt32(dr["IsSecretaryDraft"]),
                           IsAuthorityDraft = Convert.ToInt32(dr["IsAuthorityDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                       });
            }
            return ProjectList;
        }

        public Int32 Update_PublicUnpublicHandler_QuarterlyUpdatesProject_FormFiveDetailsByIndex(Int64 ProjectID, Int64 RelatedRefIndexID, Int64 RelatedRefID, Int32 PublicUnpublicCode, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_setpublicview_tbl_rera_project_formfiveByIndex", con);
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

        //Quarterly-Updates-ToolbarSummarySheet
        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive> Display_AuthDesk_QuarterlyUpdatesProjectsToolbarFormFiveSummarySheet_ByUserID(Int64 QUpdates_ProjectID, Int64 QUpdates_PromoterID, Int32 QUpdates_Flag, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive> ProjectReralist = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_QuarterlyUpdatesProjectToolbarFrmFive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_QUpdatesProjectID", QUpdates_ProjectID);
            cmd.Parameters.AddWithValue("p_QUpdatesPromoterID", QUpdates_PromoterID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsPrp_AuthorityDesk_QUpdatesProjectStatusFormFive
                       {
                           ProjectStatementofAccounts_IndexID = Convert.ToInt64(dr["ProjectStatementofAccounts_IndexID"]),
                           ProjectStatementofAccounts_ID = Convert.ToInt64(dr["ProjectStatementofAccounts_ID"]),
                           ProjectStatementofAccounts_DiaryNumber = Convert.ToString(dr["ProjectStatementofAccounts_DiaryNumber"]),
                           ProjectStatementofAccounts_DiaryID = Convert.ToInt64(dr["ProjectStatementofAccounts_DiaryID"]),
                           ProjectStatementofAccounts_DiaryYear = Convert.ToInt64(dr["ProjectStatementofAccounts_DiaryYear"]),

                           ProjectStatementofAccountsRelated_ProjectID = Convert.ToInt64(dr["ProjectStatementofAccountsRelated_ProjectID"]),
                           ProjectStatementofAccountsRelated_ProjectName = Convert.ToString(dr["ProjectStatementofAccountsRelated_ProjectName"]),
                           ProjectStatementofAccountsRelated_ProjectDiaryNumber = Convert.ToString(dr["ProjectStatementofAccountsRelated_ProjectDiaryNumber"]),
                           ProjectStatementofAccountsRelated_PromoterID = Convert.ToInt64(dr["ProjectStatementofAccountsRelated_PromoterID"]),
                           ProjectStatementofAccountsRelated_UserID = Convert.ToString(dr["ProjectStatementofAccountsRelated_UserID"]),

                           FinancialYear_EndingOnDate = Convert.ToDateTime(dr["FinancialYear_EndingOnDate"]),
                           FormB_CompletionDate = Convert.ToDateTime(dr["FormB_CompletionDate"]),
                           Percentage_of_Completion = Convert.ToDouble(dr["Percentage_of_Completion"]),
                           ExplanatoryNote = Convert.ToString(dr["ExplanatoryNote"]),
                           CollectedDuring_FinancialYear_Amount_INR = Convert.ToDouble(dr["CollectedDuring_FinancialYear_Amount_INR"]),
                           CollectedTillDate_Amount_INR = Convert.ToDouble(dr["CollectedTillDate_Amount_INR"]),
                           WithdrawDuring_FinancialYear_Amount_INR = Convert.ToDouble(dr["WithdrawDuring_FinancialYear_Amount_INR"]),
                           WithdrawnTillDate_Amount_INR = Convert.ToDouble(dr["WithdrawnTillDate_Amount_INR"]),

                           Amount_A_column = Convert.ToDouble(dr["Amount_A_column"]),
                           Amount_B_column = Convert.ToDouble(dr["Amount_B_column"]),

                           ImageFormFive_FileName = Convert.ToString(dr["ImageFormFive_FileName"]),
                           ImageFormFive_FilePath = Convert.ToString(dr["ImageFormFive_FilePath"]),
                           ImageFormFive_FileSize = Convert.ToString(dr["ImageFormFive_FileSize"]),
                           ImageFormFive_FileFormat = Convert.ToString(dr["ImageFormFive_FileFormat"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsEvaluationDraft = Convert.ToInt32(dr["IsEvaluationDraft"]),
                           IsMemberDraft = Convert.ToInt32(dr["IsMemberDraft"]),
                           IsSecretaryDraft = Convert.ToInt32(dr["IsSecretaryDraft"]),
                           IsAuthorityDraft = Convert.ToInt32(dr["IsAuthorityDraft"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           setQuarterValue_Year = Convert.ToString(dr["setQuarterValue_Year"]),
                           setQuarterValue_Name = Convert.ToString(dr["setQuarterValue_Name"]),
                           QuarterlySubmittedDate = Convert.ToDateTime(dr["QuarterlySubmittedDate"]),
                       });
            }
            return ProjectReralist;
        }
    }
}
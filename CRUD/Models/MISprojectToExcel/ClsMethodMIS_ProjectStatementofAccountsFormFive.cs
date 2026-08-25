using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsMethodMIS_ProjectStatementofAccountsFormFive
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsprpMIS_ProjectStatementofAccountsFormFive> Display_AuthDesk_MIS_ProjectFormFiveDetails_ForRegisteredProjects(string UserID_Role)
        {
            connection();
            List<ClsprpMIS_ProjectStatementofAccountsFormFive> ProjectReralist = new List<ClsprpMIS_ProjectStatementofAccountsFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFormFiveDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectStatementofAccountsFormFive
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
            return ProjectReralist;
        }
        public List<ClsprpMIS_ProjectStatementofAccountsFormFive> Display_AuthDesk_MIS_ProjectFormFiveDetails_ForRegisteredProjects_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate)
        {
            connection();
            List<ClsprpMIS_ProjectStatementofAccountsFormFive> ProjectReralist = new List<ClsprpMIS_ProjectStatementofAccountsFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFormFiveDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            string ddFromDate = FromDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
            string ddToDate = ToDate.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("Todate", ddToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);

            DataTable dt1 = new DataTable();
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["ModifyOn"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["ModifyOn"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["ModifyOn"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["ModifyOn"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectStatementofAccountsFormFive
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
            return ProjectReralist;
        }

        //pop-up modal screen
        public List<ClsprpMIS_ProjectStatementofAccountsFormFive> Display_AuthDesk_MIS_ProjectFormFiveDetails_ForRegisteredProjects_ForMIS(Int64 Project_ID, Int64 Promoter_ID, Int64 formfive_ID, string formfive_DNID, string UserID_Role)
        {
            connection();
            List<ClsprpMIS_ProjectStatementofAccountsFormFive> ProjectReralist = new List<ClsprpMIS_ProjectStatementofAccountsFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFormFiveDetails_RegdProjectsByParmID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_Frmfive_ID", formfive_ID);
            cmd.Parameters.AddWithValue("p_Frmfive_DNID", formfive_DNID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectStatementofAccountsFormFive
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
            return ProjectReralist;
        }

        private string fnProjectReturnSTR(string var1)
        {
            string vargetSTR = string.Empty;
            string TruncateString = string.Empty;

            if(var1 != string.Empty)
            {
                TruncateString = var1.Substring(13, 2);
            }
            else
            {
                TruncateString = "NA";
            }          

            switch (Convert.ToString(TruncateString))
            {
                case "PR":
                    vargetSTR = "Residential";
                    break;
                case "PC":
                    vargetSTR = "Commercial";
                    break;
                case "PM":
                    vargetSTR = "Mixed";
                    break;
                case "PI":
                    vargetSTR = "Industrial";
                    break;
                case "NA":
                    vargetSTR = "NA";
                    break;
                default:
                    vargetSTR = "NA";
                    break;
            }
            return vargetSTR;
        }

        private string RegexRemoveEmailCheck(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "@";
            string replacement = "[at]";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
        }
    }
}
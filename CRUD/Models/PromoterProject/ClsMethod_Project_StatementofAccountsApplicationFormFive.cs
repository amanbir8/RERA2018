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
    public class ClsMethod_Project_StatementofAccountsApplicationFormFive
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_Project_StatementofAccountsApplicationFormFivedetails(ClsPrp_Project_StatementofAccountsApplicationFormFive smodel, Int64 Project_id, string File_Name, string File_Path, string File_Ext, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_project_StatementofAccountsFormFivedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_IndexID", smodel.ProjectStatementofAccounts_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_ID", smodel.ProjectStatementofAccounts_ID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_DiaryNumber", String.IsNullOrEmpty(smodel.ProjectStatementofAccounts_DiaryNumber) ? "" : smodel.ProjectStatementofAccounts_DiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_DiaryID", smodel.ProjectStatementofAccounts_DiaryID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_DiaryYear", smodel.ProjectStatementofAccounts_DiaryYear);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectID", smodel.ProjectStatementofAccountsRelated_ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectName", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_ProjectName) ? "" : smodel.ProjectStatementofAccountsRelated_ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectDiaryNumber", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_ProjectDiaryNumber) ? "" : smodel.ProjectStatementofAccountsRelated_ProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_PromoterID", smodel.ProjectStatementofAccountsRelated_PromoterID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_UserID", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_UserID) ? "" : smodel.ProjectStatementofAccountsRelated_UserID);

            cmd.Parameters.AddWithValue("p_FinancialYear_EndingOnDate", smodel.FinancialYear_EndingOnDate == null ? dtvalue : smodel.FinancialYear_EndingOnDate);
            cmd.Parameters.AddWithValue("p_FormB_CompletionDate", smodel.FormB_CompletionDate == null ? dtvalue : smodel.FormB_CompletionDate);
            cmd.Parameters.AddWithValue("p_Percentage_of_Completion", smodel.Percentage_of_Completion);
            cmd.Parameters.AddWithValue("p_ExplanatoryNote", String.IsNullOrEmpty(smodel.ExplanatoryNote) ? "" : smodel.ExplanatoryNote);
            cmd.Parameters.AddWithValue("p_CollectedDuring_FinancialYear_Amount_INR", smodel.CollectedDuring_FinancialYear_Amount_INR);
            cmd.Parameters.AddWithValue("p_CollectedTillDate_Amount_INR", smodel.CollectedTillDate_Amount_INR);
            cmd.Parameters.AddWithValue("p_WithdrawDuring_FinancialYear_Amount_INR", smodel.WithdrawDuring_FinancialYear_Amount_INR);
            cmd.Parameters.AddWithValue("p_WithdrawnTillDate_Amount_INR", smodel.WithdrawnTillDate_Amount_INR);
            cmd.Parameters.AddWithValue("p_Amount_A_column", smodel.Amount_A_column);
            cmd.Parameters.AddWithValue("p_Amount_B_column", smodel.Amount_B_column);

            cmd.Parameters.AddWithValue("p_ImageFormFive_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_ImageFormFive_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_ImageFormFive_FileSize", String.IsNullOrEmpty(smodel.ImageFormFive_FileSize) ? "" : smodel.ImageFormFive_FileSize);
            cmd.Parameters.AddWithValue("p_ImageFormFive_FileFormat", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsEvaluationDraft", smodel.IsEvaluationDraft);
            cmd.Parameters.AddWithValue("p_IsMemberDraft", smodel.IsMemberDraft);
            cmd.Parameters.AddWithValue("p_IsSecretaryDraft", smodel.IsSecretaryDraft);
            cmd.Parameters.AddWithValue("p_IsAuthorityDraft", smodel.IsAuthorityDraft);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_Project_StatementofAccountsApplicationFormFivedetails(ClsPrp_Project_StatementofAccountsApplicationFormFive smodel, Int64 Project_id, string File_Name, string File_Path, string File_Ext, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_project_StatementofAccountsFormFivedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_IndexID", smodel.ProjectStatementofAccounts_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_ID", smodel.ProjectStatementofAccounts_ID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_DiaryNumber", String.IsNullOrEmpty(smodel.ProjectStatementofAccounts_DiaryNumber) ? "" : smodel.ProjectStatementofAccounts_DiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_DiaryID", smodel.ProjectStatementofAccounts_DiaryID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_DiaryYear", smodel.ProjectStatementofAccounts_DiaryYear);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectID", smodel.ProjectStatementofAccountsRelated_ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectName", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_ProjectName) ? "" : smodel.ProjectStatementofAccountsRelated_ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectDiaryNumber", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_ProjectDiaryNumber) ? "" : smodel.ProjectStatementofAccountsRelated_ProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_PromoterID", smodel.ProjectStatementofAccountsRelated_PromoterID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_UserID", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_UserID) ? "" : smodel.ProjectStatementofAccountsRelated_UserID);

            cmd.Parameters.AddWithValue("p_FinancialYear_EndingOnDate", smodel.FinancialYear_EndingOnDate == null ? dtvalue : smodel.FinancialYear_EndingOnDate);
            cmd.Parameters.AddWithValue("p_FormB_CompletionDate", smodel.FormB_CompletionDate == null ? dtvalue : smodel.FormB_CompletionDate);
            cmd.Parameters.AddWithValue("p_Percentage_of_Completion", smodel.Percentage_of_Completion);
            cmd.Parameters.AddWithValue("p_ExplanatoryNote", String.IsNullOrEmpty(smodel.ExplanatoryNote) ? "" : smodel.ExplanatoryNote);
            cmd.Parameters.AddWithValue("p_CollectedDuring_FinancialYear_Amount_INR", smodel.CollectedDuring_FinancialYear_Amount_INR);
            cmd.Parameters.AddWithValue("p_CollectedTillDate_Amount_INR", smodel.CollectedTillDate_Amount_INR);
            cmd.Parameters.AddWithValue("p_WithdrawDuring_FinancialYear_Amount_INR", smodel.WithdrawDuring_FinancialYear_Amount_INR);
            cmd.Parameters.AddWithValue("p_WithdrawnTillDate_Amount_INR", smodel.WithdrawnTillDate_Amount_INR);
            cmd.Parameters.AddWithValue("p_Amount_A_column", smodel.Amount_A_column);
            cmd.Parameters.AddWithValue("p_Amount_B_column", smodel.Amount_B_column);

            cmd.Parameters.AddWithValue("p_ImageFormFive_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_ImageFormFive_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_ImageFormFive_FileSize", String.IsNullOrEmpty(smodel.ImageFormFive_FileSize) ? "" : smodel.ImageFormFive_FileSize);
            cmd.Parameters.AddWithValue("p_ImageFormFive_FileFormat", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsEvaluationDraft", smodel.IsEvaluationDraft);
            cmd.Parameters.AddWithValue("p_IsMemberDraft", smodel.IsMemberDraft);
            cmd.Parameters.AddWithValue("p_IsSecretaryDraft", smodel.IsSecretaryDraft);
            cmd.Parameters.AddWithValue("p_IsAuthorityDraft", smodel.IsAuthorityDraft);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_Project_StatementofAccountsApplicationFormFive> Display_Project_StatementofAccountsApplicationFormFivedetails(Int64 ProjectRegistration_ID)
        {
            connection();
            List<ClsPrp_Project_StatementofAccountsApplicationFormFive> Projectlist = new List<ClsPrp_Project_StatementofAccountsApplicationFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_StatementofAccountsFormFivedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_Project_StatementofAccountsApplicationFormFive
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
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_Project_StatementofAccountsApplicationFormFive> Display_Project_StatementofAccountsApplicationFormFivedetails_ByID(Int64? ProjectRegistration_ID, Int64? ProjectStatementofAccounts_IndexID)
        {
            connection();
            List<ClsPrp_Project_StatementofAccountsApplicationFormFive> Projectlist = new List<ClsPrp_Project_StatementofAccountsApplicationFormFive>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_StatementofAccountsFormFivedetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_IndexID", ProjectStatementofAccounts_IndexID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_Project_StatementofAccountsApplicationFormFive
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
                       });
            }
            return Projectlist;
        }
        
        public bool Delete_Project_StatementofAccountsApplicationFormFivedetails(Int64? ProjectRegistration_ID, Int64? ProjectStatementofAccounts_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Project_StatementofAccountsFormFivedetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_IndexID", ProjectStatementofAccounts_IndexID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Confirm_Project_StatementofAccountsApplicationFormFivedetails(ClsPrp_Project_StatementofAccountsApplicationFormFive smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_confirm_tbl_RERA_project_StatementofAccountsFormFivedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_IndexID", smodel.ProjectStatementofAccounts_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccounts_ID", smodel.ProjectStatementofAccounts_ID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_ProjectID", smodel.ProjectStatementofAccountsRelated_ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectStatementofAccountsRelated_UserID", String.IsNullOrEmpty(smodel.ProjectStatementofAccountsRelated_UserID) ? "" : smodel.ProjectStatementofAccountsRelated_UserID);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(smodel.ModifyBy) ? "" : smodel.ModifyBy);          

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //return AppId;
            if (i >= 1)
                return false;
            else
                return true;
        }


    }
}
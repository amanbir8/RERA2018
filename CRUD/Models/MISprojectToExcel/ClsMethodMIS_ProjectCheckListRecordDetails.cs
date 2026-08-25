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
    public class ClsMethodMIS_ProjectCheckListRecordDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Project Checklist Record Details Display
        public List<Clsprp_MIS_ProjectCheckListRecordDetails> Display_AuthDesk_MIS_ProjectChecklistRecordsFileTimeDetails_ForProjects(string inprmUserIDrole)
        {
            connection();
            Int32 inprmIsApplicationCategoryFlag = 0;
            Int32 inprmIsActionDateTypeFlag = 0;
            DateTime inprmInputEntry_FromDate = DateTime.Now;
            DateTime inprmInputEntry_ToDate = DateTime.Now;
            Int32 prmRangeValueDateInputFlag = 0;
            Int32 prmInputEntry_Month = 0;
            Int32 prmInputEntry_Year = 0;

            List<Clsprp_MIS_ProjectCheckListRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectCheckListRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileChecklistRecordsDetails_RegProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ApplicationCategoryFlag", inprmIsApplicationCategoryFlag);
                cmd.Parameters.AddWithValue("p_ActionDateTypeFlag", inprmIsActionDateTypeFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
                cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);
                cmd.Parameters.AddWithValue("p_RangeInputFlag", prmRangeValueDateInputFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_Month", prmInputEntry_Month);
                cmd.Parameters.AddWithValue("p_InputEntry_Year", prmInputEntry_Year);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectReralist.Add(
                           new Clsprp_MIS_ProjectCheckListRecordDetails
                           {
                               Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                               PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                               PromoterRegDiaryNumber_NameYear = Convert.ToInt64(dr["PromoterRegDiaryNumber_NameYear"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               EventAction_NoReplybyPromoter_Days = Convert.ToString(dr["EventAction_NoReplybyPromoter_Days"]),

                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Project_Status = Convert.ToString(dr["Project_Status"]),

                               ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                               ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                               ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),

                               Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                               Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                               Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),

                               varLandTitleSearchReport = Convert.ToString(dr["varLandTitleSearchReport"]),
                               varLatestCopyJamabandiCertificate = Convert.ToString(dr["varLatestCopyJamabandiCertificate"]),
                               varLandEncumbrancesNECertificate = Convert.ToString(dr["varLandEncumbrancesNECertificate"]),
                               varCLUCertificate = Convert.ToString(dr["varCLUCertificate"]),
                               varLicenseDevelopSocietyColonyFromCompetentAuthority = Convert.ToString(dr["varLicenseDevelopSocietyColonyFromCompetentAuthority"]),
                               varRegistrationAsPromoter = Convert.ToString(dr["varRegistrationAsPromoter"]),
                               varFinanceYesNo = Convert.ToString(dr["varFinanceYesNo"]),

                               VariableValue = Convert.ToString(dr["VariableValue"]),
                               PercentageValue = Convert.ToDecimal(dr["PercentageValue"]),

                               RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                               Registration_IssueDate = Convert.ToDateTime(dr["Registration_IssueDate"]),
                               Registration_UptoDate = Convert.ToDateTime(dr["Registration_UptoDate"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationTypeFlag = Convert.ToInt32(dr["IsApplicationTypeFlag"]),
                               IsApplicationStatisticsCategory = Convert.ToInt32(dr["IsApplicationStatisticsCategory"]),

                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                               IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                               EventMonth = Convert.ToInt32(dr["EventMonth"]),
                               EventYear = Convert.ToInt32(dr["EventYear"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectCheckListRecordDetails> Display_AuthDesk_MIS_ProjectChecklistRecordsFileTimeDetailsByID_ForProjects(string inprmUserIDrole, Int32 inprmIsApplicationCategoryFlag, Int32 inprmIsActionDateTypeFlag, DateTime inprmInputEntry_FromDate, DateTime inprmInputEntry_ToDate, Int32 prmRange, Int32 prmMonth, Int32 prmYear)
        {
            connection();
            List<Clsprp_MIS_ProjectCheckListRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectCheckListRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileChecklistRecordsDetails_RegProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ApplicationCategoryFlag", inprmIsApplicationCategoryFlag);
                cmd.Parameters.AddWithValue("p_ActionDateTypeFlag", inprmIsActionDateTypeFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
                cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);
                cmd.Parameters.AddWithValue("p_RangeInputFlag", prmRange);
                cmd.Parameters.AddWithValue("p_InputEntry_Month", prmMonth);
                cmd.Parameters.AddWithValue("p_InputEntry_Year", prmYear);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectReralist.Add(
                           new Clsprp_MIS_ProjectCheckListRecordDetails
                           {
                               Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                               PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                               PromoterRegDiaryNumber_NameYear = Convert.ToInt64(dr["PromoterRegDiaryNumber_NameYear"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               EventAction_NoReplybyPromoter_Days = Convert.ToString(dr["EventAction_NoReplybyPromoter_Days"]),

                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Project_Status = Convert.ToString(dr["Project_Status"]),

                               ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                               ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                               ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),

                               Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                               Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                               Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),

                               varLandTitleSearchReport = Convert.ToString(dr["varLandTitleSearchReport"]),
                               varLatestCopyJamabandiCertificate = Convert.ToString(dr["varLatestCopyJamabandiCertificate"]),
                               varLandEncumbrancesNECertificate = Convert.ToString(dr["varLandEncumbrancesNECertificate"]),
                               varCLUCertificate = Convert.ToString(dr["varCLUCertificate"]),
                               varLicenseDevelopSocietyColonyFromCompetentAuthority = Convert.ToString(dr["varLicenseDevelopSocietyColonyFromCompetentAuthority"]),
                               varRegistrationAsPromoter = Convert.ToString(dr["varRegistrationAsPromoter"]),
                               varFinanceYesNo = Convert.ToString(dr["varFinanceYesNo"]),

                               VariableValue = Convert.ToString(dr["VariableValue"]),
                               PercentageValue = Convert.ToDecimal(dr["PercentageValue"]),

                               RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                               Registration_IssueDate = Convert.ToDateTime(dr["Registration_IssueDate"]),
                               Registration_UptoDate = Convert.ToDateTime(dr["Registration_UptoDate"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationTypeFlag = Convert.ToInt32(dr["IsApplicationTypeFlag"]),
                               IsApplicationStatisticsCategory = Convert.ToInt32(dr["IsApplicationStatisticsCategory"]),

                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                               IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                               EventMonth = Convert.ToInt32(dr["EventMonth"]),
                               EventYear = Convert.ToInt32(dr["EventYear"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }

        // Extension Checklist Record Details Display
        public List<Clsprp_MIS_ProjectCheckListRecordDetails> Display_AuthDesk_MIS_ProjectExtensionChecklistRecordsFileTimeDetails_ForProjects(string inprmUserIDrole)
        {
            connection();
            Int32 inprmIsApplicationCategoryFlag = 0;
            Int32 inprmIsActionDateTypeFlag = 0;
            DateTime inprmInputEntry_FromDate = DateTime.Now;
            DateTime inprmInputEntry_ToDate = DateTime.Now;
            Int32 prmRangeValueDateInputFlag = 0;
            Int32 prmInputEntry_Month = 0;
            Int32 prmInputEntry_Year = 0;

            List<Clsprp_MIS_ProjectCheckListRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectCheckListRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileChecklistRecordsDetails_ExtnProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ApplicationCategoryFlag", inprmIsApplicationCategoryFlag);
                cmd.Parameters.AddWithValue("p_ActionDateTypeFlag", inprmIsActionDateTypeFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
                cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);
                cmd.Parameters.AddWithValue("p_RangeInputFlag", prmRangeValueDateInputFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_Month", prmInputEntry_Month);
                cmd.Parameters.AddWithValue("p_InputEntry_Year", prmInputEntry_Year);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectReralist.Add(
                           new Clsprp_MIS_ProjectCheckListRecordDetails
                           {
                               Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                               PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                               PromoterRegDiaryNumber_NameYear = Convert.ToInt64(dr["PromoterRegDiaryNumber_NameYear"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               EventAction_NoReplybyPromoter_Days = Convert.ToString(dr["EventAction_NoReplybyPromoter_Days"]),

                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Project_Status = Convert.ToString(dr["Project_Status"]),

                               ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                               ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                               ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),

                               Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                               Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                               Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),

                               varLandTitleSearchReport = Convert.ToString(dr["varLandTitleSearchReport"]),
                               varLatestCopyJamabandiCertificate = Convert.ToString(dr["varLatestCopyJamabandiCertificate"]),
                               varLandEncumbrancesNECertificate = Convert.ToString(dr["varLandEncumbrancesNECertificate"]),
                               varCLUCertificate = Convert.ToString(dr["varCLUCertificate"]),
                               varLicenseDevelopSocietyColonyFromCompetentAuthority = Convert.ToString(dr["varLicenseDevelopSocietyColonyFromCompetentAuthority"]),
                               varRegistrationAsPromoter = Convert.ToString(dr["varRegistrationAsPromoter"]),
                               varFinanceYesNo = Convert.ToString(dr["varFinanceYesNo"]),

                               VariableValue = Convert.ToString(dr["VariableValue"]),
                               PercentageValue = Convert.ToDecimal(dr["PercentageValue"]),

                               RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                               Registration_IssueDate = Convert.ToDateTime(dr["Registration_IssueDate"]),
                               Registration_UptoDate = Convert.ToDateTime(dr["Registration_UptoDate"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationTypeFlag = Convert.ToInt32(dr["IsApplicationTypeFlag"]),
                               IsApplicationStatisticsCategory = Convert.ToInt32(dr["IsApplicationStatisticsCategory"]),

                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                               IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                               EventMonth = Convert.ToInt32(dr["EventMonth"]),
                               EventYear = Convert.ToInt32(dr["EventYear"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectCheckListRecordDetails> Display_AuthDesk_MIS_ProjectExtensionChecklistRecordsFileTimeDetailsByID_ForProjects(string inprmUserIDrole, Int32 inprmIsApplicationCategoryFlag, Int32 inprmIsActionDateTypeFlag, DateTime inprmInputEntry_FromDate, DateTime inprmInputEntry_ToDate, Int32 prmRange, Int32 prmMonth, Int32 prmYear)
        {
            connection();
            List<Clsprp_MIS_ProjectCheckListRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectCheckListRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileChecklistRecordsDetails_ExtnProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ApplicationCategoryFlag", inprmIsApplicationCategoryFlag);
                cmd.Parameters.AddWithValue("p_ActionDateTypeFlag", inprmIsActionDateTypeFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
                cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);
                cmd.Parameters.AddWithValue("p_RangeInputFlag", prmRange);
                cmd.Parameters.AddWithValue("p_InputEntry_Month", prmMonth);
                cmd.Parameters.AddWithValue("p_InputEntry_Year", prmYear);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectReralist.Add(
                           new Clsprp_MIS_ProjectCheckListRecordDetails
                           {
                               Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                               PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                               PromoterRegDiaryNumber_NameYear = Convert.ToInt64(dr["PromoterRegDiaryNumber_NameYear"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               EventAction_NoReplybyPromoter_Days = Convert.ToString(dr["EventAction_NoReplybyPromoter_Days"]),

                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Project_Status = Convert.ToString(dr["Project_Status"]),

                               ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                               ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                               ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),

                               Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                               Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                               Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),

                               varLandTitleSearchReport = Convert.ToString(dr["varLandTitleSearchReport"]),
                               varLatestCopyJamabandiCertificate = Convert.ToString(dr["varLatestCopyJamabandiCertificate"]),
                               varLandEncumbrancesNECertificate = Convert.ToString(dr["varLandEncumbrancesNECertificate"]),
                               varCLUCertificate = Convert.ToString(dr["varCLUCertificate"]),
                               varLicenseDevelopSocietyColonyFromCompetentAuthority = Convert.ToString(dr["varLicenseDevelopSocietyColonyFromCompetentAuthority"]),
                               varRegistrationAsPromoter = Convert.ToString(dr["varRegistrationAsPromoter"]),
                               varFinanceYesNo = Convert.ToString(dr["varFinanceYesNo"]),

                               VariableValue = Convert.ToString(dr["VariableValue"]),
                               PercentageValue = Convert.ToDecimal(dr["PercentageValue"]),

                               RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                               Registration_IssueDate = Convert.ToDateTime(dr["Registration_IssueDate"]),
                               Registration_UptoDate = Convert.ToDateTime(dr["Registration_UptoDate"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationTypeFlag = Convert.ToInt32(dr["IsApplicationTypeFlag"]),
                               IsApplicationStatisticsCategory = Convert.ToInt32(dr["IsApplicationStatisticsCategory"]),

                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                               IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                               EventMonth = Convert.ToInt32(dr["EventMonth"]),
                               EventYear = Convert.ToInt32(dr["EventYear"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }
        
        private string fnReturnSTR(string var1)
        {
            string vargetSTR = string.Empty;
            switch (Convert.ToString(var1))
            {
                case "1":
                    vargetSTR = "Individual";
                    break;
                case "2":
                    vargetSTR = "Other Than Individual";
                    break;                
                default:
                    vargetSTR = "";
                    break;
            }
            return vargetSTR;
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
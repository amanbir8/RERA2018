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
    public class ClsMethodMIS_ProjectSpecialBankAccountNumberDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Project Special Bank Account Record Details Display
        public List<ClsprpMIS_ProjectSpecialBankAccountDetails> Display_AuthDesk_MIS_ProjectSpecialBankAccountRecords_ForProjects(string inprmUserIDrole)
        {
            connection();
            string inprmIsActionBankFlag = "0";
            Int32 inprmIsBankCode = 0;
            Int32 inprmIsRegistrationDateFlag = 0;
            Int32 prmRangeValueDateInputFlag = 0;
            DateTime inprmInputEntry_FromDate = DateTime.Now;
            DateTime inprmInputEntry_ToDate = DateTime.Now;
            Int32 prmInputEntry_Month = 0;
            Int32 prmInputEntry_Year = 0;

            List<ClsprpMIS_ProjectSpecialBankAccountDetails> ProjectReralist = new List<ClsprpMIS_ProjectSpecialBankAccountDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_SpecialBankAccountNumberRecordsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ActionBankFlag", inprmIsActionBankFlag);
                cmd.Parameters.AddWithValue("p_BankCode", inprmIsBankCode);
                cmd.Parameters.AddWithValue("p_RegistrationDateFlag", inprmIsRegistrationDateFlag);
                cmd.Parameters.AddWithValue("p_RangeInputFlag", prmRangeValueDateInputFlag);
                cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
                cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);
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
                           new ClsprpMIS_ProjectSpecialBankAccountDetails
                           {
                               SpecialBankAccount_IndexID = Convert.ToInt64(dr["SpecialBankAccount_IndexID"]),
                               SpecialBankAccount_ID = Convert.ToInt64(dr["SpecialBankAccount_ID"]),
                               SpecialBankAccountRelated_ProjectRegistration_ID = Convert.ToInt64(dr["SpecialBankAccountRelated_ProjectRegistration_ID"]),
                               Bank_Name = Convert.ToString(dr["Bank_Name"]),
                               Branch_Name = Convert.ToString(dr["Branch_Name"]),
                               Bank_AccountNumber = Convert.ToString(dr["Bank_AccountNumber"]),
                               Bank_IFSC_Code = Convert.ToString(dr["Bank_IFSC_Code"]),
                               Bank_AddressLine1 = Convert.ToString(dr["Bank_AddressLine1"]),
                               Bank_AddressLine2 = Convert.ToString(dr["Bank_AddressLine2"]),
                               Bank_AddressStateCode = Convert.ToInt32(dr["Bank_AddressStateCode"]),
                               Bank_AddressDistrictCode = Convert.ToInt32(dr["Bank_AddressDistrictCode"]),
                               Bank_AddressPIN = Convert.ToString(dr["Bank_AddressPIN"]),
                               ImageCancelledCheque_FileName = Convert.ToString(dr["ImageCancelledCheque_FileName"]),
                               ImageCancelledCheque_FilePath = Convert.ToString(dr["ImageCancelledCheque_FilePath"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                               Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                               Project_ID = Convert.ToInt64(dr["Project_ID"]),
                               RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                               RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                               RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                               Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                               Account_FormDate = Convert.ToDateTime(dr["Account_FormDate"]),
                               Account_ToDate = Convert.ToDateTime(dr["Account_ToDate"]),
                               IsConditionAnnexure = Convert.ToInt32(dr["IsConditionAnnexure"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsRegistrationHistory = Convert.ToString(dr["IsRegistrationHistory"]),

                               Application_SearchOptionFlag = Convert.ToString(dr["Application_SearchOptionFlag"]),
                               Application_SearchOptionDateFlag = Convert.ToString(dr["Application_SearchOptionDateFlag"]),
                               Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                               BankName_Input = Convert.ToString(dr["BankName_Input"]),
                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),
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

        public List<ClsprpMIS_ProjectSpecialBankAccountDetails> Display_AuthDesk_MIS_ProjectSpecialBankAccountRecordsByID_ForProjects(string inprmUserIDrole, string inprmIsActionBankFlag, Int32 inprmIsBankCode, Int32 inprmIsRegistrationDateFlag, Int32 prmRange, DateTime inprmInputEntry_FromDate, DateTime inprmInputEntry_ToDate, Int32 prmMonth, Int32 prmYear)
        {
            connection();
            List<ClsprpMIS_ProjectSpecialBankAccountDetails> ProjectReralist = new List<ClsprpMIS_ProjectSpecialBankAccountDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_SpecialBankAccountNumberRecordsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ActionBankFlag", inprmIsActionBankFlag);
                cmd.Parameters.AddWithValue("p_BankCode", inprmIsBankCode);
                cmd.Parameters.AddWithValue("p_RegistrationDateFlag", inprmIsRegistrationDateFlag);
                cmd.Parameters.AddWithValue("p_RangeInputFlag", prmRange);
                cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
                cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);
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
                           new ClsprpMIS_ProjectSpecialBankAccountDetails
                           {
                               SpecialBankAccount_IndexID = Convert.ToInt64(dr["SpecialBankAccount_IndexID"]),
                               SpecialBankAccount_ID = Convert.ToInt64(dr["SpecialBankAccount_ID"]),
                               SpecialBankAccountRelated_ProjectRegistration_ID = Convert.ToInt64(dr["SpecialBankAccountRelated_ProjectRegistration_ID"]),
                               Bank_Name = Convert.ToString(dr["Bank_Name"]),
                               Branch_Name = Convert.ToString(dr["Branch_Name"]),
                               Bank_AccountNumber = Convert.ToString(dr["Bank_AccountNumber"]),
                               Bank_IFSC_Code = Convert.ToString(dr["Bank_IFSC_Code"]),
                               Bank_AddressLine1 = Convert.ToString(dr["Bank_AddressLine1"]),
                               Bank_AddressLine2 = Convert.ToString(dr["Bank_AddressLine2"]),
                               Bank_AddressStateCode = Convert.ToInt32(dr["Bank_AddressStateCode"]),
                               Bank_AddressDistrictCode = Convert.ToInt32(dr["Bank_AddressDistrictCode"]),
                               Bank_AddressPIN = Convert.ToString(dr["Bank_AddressPIN"]),
                               ImageCancelledCheque_FileName = Convert.ToString(dr["ImageCancelledCheque_FileName"]),
                               ImageCancelledCheque_FilePath = Convert.ToString(dr["ImageCancelledCheque_FilePath"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToString(dr["B_column"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                               Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                               Project_ID = Convert.ToInt64(dr["Project_ID"]),
                               RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                               RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                               RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                               Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                               Account_FormDate = Convert.ToDateTime(dr["Account_FormDate"]),
                               Account_ToDate = Convert.ToDateTime(dr["Account_ToDate"]),
                               IsConditionAnnexure = Convert.ToInt32(dr["IsConditionAnnexure"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               IsRegistrationHistory = Convert.ToString(dr["IsRegistrationHistory"]),

                               Application_SearchOptionFlag = Convert.ToString(dr["Application_SearchOptionFlag"]),
                               Application_SearchOptionDateFlag = Convert.ToString(dr["Application_SearchOptionDateFlag"]),
                               Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                               BankName_Input = Convert.ToString(dr["BankName_Input"]),
                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),
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
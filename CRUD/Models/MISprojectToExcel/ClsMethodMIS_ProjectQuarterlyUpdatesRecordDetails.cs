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
    public class ClsMethodMIS_ProjectQuarterlyUpdatesRecordDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Project Quarterly Updates Record Details Display
        public List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails> Display_AuthDesk_MIS_ProjectQuarterlyUpdateRecordsDetails_ForProjects(string inprmUserIDrole)
        {
            connection();
            Int32 inprmIsActionDistrictFlag = 0;
            Int32 inprmIsDistrictCode = 0;
            Int32 prmRangeValueDateInputFlag = 0;
            DateTime inprmInputEntry_FromDate = DateTime.Now;
            DateTime inprmInputEntry_ToDate = DateTime.Now;
            String prmInputEntry_Month = string.Empty;
            Int32 prmInputEntry_Year = 0;

            List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_QuarterUpdateProjectRecordsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ActionDistrictFlag", inprmIsActionDistrictFlag);
                cmd.Parameters.AddWithValue("p_DistrictCode", inprmIsDistrictCode);
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
                           new Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails
                           {
                               QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                               QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                               QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                               QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                               QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                               QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               PromoterID = Convert.ToInt64(dr["PromoterID"]),
                               ProjectID = Convert.ToInt64(dr["ProjectID"]),

                               InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                               ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                               GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                               InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                               ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                               ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),

                               RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                               RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                               RERAnumberValidUptoDate = Convert.ToDateTime(dr["RERAnumberValidUptoDate"]),

                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),
                               Extra4 = Convert.ToString(dr["Extra4"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),

                               QUP_SubmittedOnTimebyPromoter_Name = Convert.ToString(dr["QUP_SubmittedOnTimebyPromoter_Name"]),
                               QUP_SubmittedOnTimebyPromoter_Flag = Convert.ToInt32(dr["QUP_SubmittedOnTimebyPromoter_Flag"]),
                               QUP_SubmittedOnTimebyPromoter_Days = Convert.ToString(dr["QUP_SubmittedOnTimebyPromoter_Days"]),

                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                               Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                               Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),

                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               QuarterValue_Year = Convert.ToString(dr["QuarterValue_Year"]),
                               QuarterValue_Name = Convert.ToString(dr["QuarterValue_Name"]),

                               VariableValue = Convert.ToString(dr["VariableValue"]),
                               PercentageValue = Convert.ToDecimal(dr["PercentageValue"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationTypeFlag = Convert.ToInt32(dr["IsApplicationTypeFlag"]),
                               IsApplicationStatisticsCategory = Convert.ToInt32(dr["IsApplicationStatisticsCategory"]),
                               IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),
                               EventMonth = Convert.ToString(dr["EventMonth"]),
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
        public List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails> Display_AuthDesk_MIS_ProjectQuarterlyUpdateRecordsDetailsByID_ForProjects(string inprmUserIDrole, Int32 inprmIsActionDistrictFlag, Int32 inprmIsDistrictCode, Int32 prmRange, DateTime inprmInputEntry_FromDate, DateTime inprmInputEntry_ToDate, String prmMonth, Int32 prmYear)
        {
            connection();
            List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_QuarterUpdateProjectRecordsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ActionDistrictFlag", inprmIsActionDistrictFlag);
                cmd.Parameters.AddWithValue("p_DistrictCode", inprmIsDistrictCode);
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
                           new Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails
                           {
                               QUpdateProject_RegDiaryNumber_IndexID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_IndexID"]),
                               QUpdateProject_RegDiaryNumber_ID = Convert.ToInt64(dr["QUpdateProject_RegDiaryNumber_ID"]),
                               QUpdateProject_RegDiaryNumber_Name = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_Name"]),
                               QUpdateProject_RegDiaryNumber_NameYear = Convert.ToString(dr["QUpdateProject_RegDiaryNumber_NameYear"]),
                               QUpdateProject_Year = Convert.ToInt32(dr["QUpdateProject_Year"]),
                               QUpdateProject_QuarterName = Convert.ToString(dr["QUpdateProject_QuarterName"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               PromoterID = Convert.ToInt64(dr["PromoterID"]),
                               ProjectID = Convert.ToInt64(dr["ProjectID"]),

                               InventoryCount = Convert.ToInt32(dr["InventoryCount"]),
                               ParkingDetailsCount = Convert.ToInt32(dr["ParkingDetailsCount"]),
                               GeoTaggingPhotographCount = Convert.ToInt32(dr["GeoTaggingPhotographCount"]),
                               InternalFacilitiesCount = Convert.ToInt32(dr["InternalFacilitiesCount"]),
                               ExternalFacilitiesCount = Convert.ToInt32(dr["ExternalFacilitiesCount"]),
                               ApprovalsCount = Convert.ToInt32(dr["ApprovalsCount"]),

                               RERAregistrationnumber = Convert.ToString(dr["RERAregistrationnumber"]),
                               RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                               RERAnumberValidUptoDate = Convert.ToDateTime(dr["RERAnumberValidUptoDate"]),

                               Extra2 = Convert.ToString(dr["Extra2"]),
                               Extra3 = Convert.ToString(dr["Extra3"]),
                               Extra4 = Convert.ToString(dr["Extra4"]),
                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                               IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                               IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                               IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                               EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),

                               QUP_SubmittedOnTimebyPromoter_Name = Convert.ToString(dr["QUP_SubmittedOnTimebyPromoter_Name"]),
                               QUP_SubmittedOnTimebyPromoter_Flag = Convert.ToInt32(dr["QUP_SubmittedOnTimebyPromoter_Flag"]),
                               QUP_SubmittedOnTimebyPromoter_Days = Convert.ToString(dr["QUP_SubmittedOnTimebyPromoter_Days"]),

                               Application_Date = Convert.ToDateTime(dr["Application_Date"]),

                               Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                               Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                               Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),

                               Project_Name = Convert.ToString(dr["Project_Name"]),
                               Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                               QuarterValue_Year = Convert.ToString(dr["QuarterValue_Year"]),
                               QuarterValue_Name = Convert.ToString(dr["QuarterValue_Name"]),

                               VariableValue = Convert.ToString(dr["VariableValue"]),
                               PercentageValue = Convert.ToDecimal(dr["PercentageValue"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationTypeFlag = Convert.ToInt32(dr["IsApplicationTypeFlag"]),
                               IsApplicationStatisticsCategory = Convert.ToInt32(dr["IsApplicationStatisticsCategory"]),
                               IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),
                               EventMonth = Convert.ToString(dr["EventMonth"]),
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
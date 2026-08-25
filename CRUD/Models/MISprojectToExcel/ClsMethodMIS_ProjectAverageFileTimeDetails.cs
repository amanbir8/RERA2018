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
    public class ClsMethodMIS_ProjectAverageFileTimeDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Elementary Display
        public List<Clsprp_MIS_ProjectAverageFileTimeDetails> Display_AuthDesk_MIS_ProjectElementaryFileTimeDetails_ForProjects(string inprmUserIDrole)
        {
            connection();
            Int32 inprmIsApplicationModeFlag = 0;
            Int32 inprmIsApplicationDateFlag = 0;
            DateTime inprmInputEntry_FromDate = DateTime.Now;
            DateTime inprmInputEntry_ToDate = DateTime.Now;

            List<Clsprp_MIS_ProjectAverageFileTimeDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeElementaryDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inprmIsApplicationModeFlag);
            cmd.Parameters.AddWithValue("p_ApplicationDateFlag", inprmIsApplicationDateFlag);
            cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
            cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAverageFileTimeDetails
                       {
                           IndexCode = Convert.ToInt64(dr["IndexCode"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           NumberOfApplications = Convert.ToInt64(dr["NumberOfApplications"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),

                           IsApplicationDateFlag = Convert.ToInt32(dr["IsApplicationDateFlag"]),
                           IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                           InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                           InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectAverageFileTimeDetails> Display_AuthDesk_MIS_ProjectElementaryFileTimeDetailsByID_ForProjects(string inprmUserIDrole, Int32 inprmIsApplicationModeFlag, Int32 inprmIsApplicationDateFlag, DateTime inprmInputEntry_FromDate, DateTime inprmInputEntry_ToDate)
        {
            connection();           
            List<Clsprp_MIS_ProjectAverageFileTimeDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeElementaryDetails_RegdProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inprmIsApplicationModeFlag);
            cmd.Parameters.AddWithValue("p_ApplicationDateFlag", inprmIsApplicationDateFlag);
            cmd.Parameters.AddWithValue("p_InputEntry_FromDate", inprmInputEntry_FromDate);
            cmd.Parameters.AddWithValue("p_InputEntry_ToDate", inprmInputEntry_ToDate);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_MIS_ProjectAverageFileTimeDetails
                       {
                           IndexCode = Convert.ToInt64(dr["IndexCode"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           NumberOfApplications = Convert.ToInt64(dr["NumberOfApplications"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),

                           IsApplicationDateFlag = Convert.ToInt32(dr["IsApplicationDateFlag"]),
                           IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                           InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                           InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }

        // Record Details Display
        public List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails> Display_AuthDesk_MIS_ProjectRecordsFileTimeDetails_ForProjects(string inprmUserIDrole)
        {
            connection();
            Int32 inprmIsApplicationModeFlag = 0;
            Int32 inprmIsApplicationDateFlag = 0;
            DateTime inprmInputEntry_FromDate = DateTime.Now;
            DateTime inprmInputEntry_ToDate = DateTime.Now;
            Int32 prmRangeValueDateInputFlag = 0;
            Int32 prmInputEntry_Month = 0;
            Int32 prmInputEntry_Year = 0;

            List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeRecordsDetails_RegdProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inprmIsApplicationModeFlag);
                cmd.Parameters.AddWithValue("p_ApplicationDateFlag", inprmIsApplicationDateFlag);
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
                           new Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails
                           {
                               IndexCode = Convert.ToInt64(dr["IndexCode"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                               ApplicationDate_IdentifiedOn = Convert.ToDateTime(dr["ApplicationDate_IdentifiedOn"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),

                               LastActivity_EventAction_Type = Convert.ToInt64(dr["LastActivity_EventAction_Type"]),
                               LastActivity_EventAction_Aggregate = Convert.ToString(dr["LastActivity_EventAction_Aggregate"]),
                               LastActivity_EventAction_IdentifiedOn = Convert.ToDateTime(dr["LastActivity_EventAction_IdentifiedOn"]),

                               ApplicationApprovalDate = Convert.ToDateTime(dr["ApplicationApprovalDate"]),

                               RegistrationApproval_Days = Convert.ToString(dr["RegistrationApproval_Days"]),
                               LastActionbyRERA_Days = Convert.ToString(dr["LastActionbyRERA_Days"]),
                               ApplicationRecipt_Days = Convert.ToString(dr["ApplicationRecipt_Days"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationDateFlag = Convert.ToInt32(dr["IsApplicationDateFlag"]),
                               IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails> Display_AuthDesk_MIS_ProjectRecordsFileTimeDetailsByID_ForProjects(string inprmUserIDrole, Int32 inprmIsApplicationModeFlag, Int32 inprmIsApplicationDateFlag, DateTime inprmInputEntry_FromDate, DateTime inprmInputEntry_ToDate, Int32 prmRange, Int32 prmMonth, Int32 prmYear)
        {
            connection();
            List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails>();

            try
            {               
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeRecordsDetails_RegdProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", inprmUserIDrole);
                cmd.Parameters.AddWithValue("p_ApplicationModeFlag", inprmIsApplicationModeFlag);
                cmd.Parameters.AddWithValue("p_ApplicationDateFlag", inprmIsApplicationDateFlag);
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
                           new Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails
                           {
                               IndexCode = Convert.ToInt64(dr["IndexCode"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                               ApplicationDate_IdentifiedOn = Convert.ToDateTime(dr["ApplicationDate_IdentifiedOn"]),
                               Project_Name = Convert.ToString(dr["Project_Name"]),

                               LastActivity_EventAction_Type = Convert.ToInt64(dr["LastActivity_EventAction_Type"]),
                               LastActivity_EventAction_Aggregate = Convert.ToString(dr["LastActivity_EventAction_Aggregate"]),
                               LastActivity_EventAction_IdentifiedOn = Convert.ToDateTime(dr["LastActivity_EventAction_IdentifiedOn"]),

                               ApplicationApprovalDate = Convert.ToDateTime(dr["ApplicationApprovalDate"]),

                               RegistrationApproval_Days = Convert.ToString(dr["RegistrationApproval_Days"]),
                               LastActionbyRERA_Days = Convert.ToString(dr["LastActionbyRERA_Days"]),
                               ApplicationRecipt_Days = Convert.ToString(dr["ApplicationRecipt_Days"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),

                               IsApplicationDateFlag = Convert.ToInt32(dr["IsApplicationDateFlag"]),
                               IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                               InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                               InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
            }
            catch(Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters> Display_AuthDesk_MIS_ProjectRecordsFileTimeNoReplyFromPromotersByID(string Role_UserID, Int32 ApplicationModeFlag, Int64 ProjectCode, Int64 PromoterCode)
        {
            connection();
            List<Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeNoReplyFromPromotersByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", Role_UserID);
                cmd.Parameters.AddWithValue("p_ApplicationModeFlag", ApplicationModeFlag);
                cmd.Parameters.AddWithValue("p_RelatedProjectID", ProjectCode);
                cmd.Parameters.AddWithValue("p_RelatedPromoterID", PromoterCode);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectReralist.Add(
                           new Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters
                           {
                               IndexCode = Convert.ToInt64(dr["IndexCode"]),
                               Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                               Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                               Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                               FromDate_EventAction_IdentifiedOn = Convert.ToDateTime(dr["FromDate_EventAction_IdentifiedOn"]),
                               ToDate_EventAction_IdentifiedOn = Convert.ToDateTime(dr["ToDate_EventAction_IdentifiedOn"]),
                               NoReplybyPromoters_Days = Convert.ToString(dr["NoReplybyPromoters_Days"]),

                               A_column = Convert.ToString(dr["A_column"]),
                               B_column = Convert.ToInt64(dr["B_column"]),
                               C_column = Convert.ToDateTime(dr["C_column"]),
                               D_column = Convert.ToDateTime(dr["D_column"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return ProjectReralist;
        }

        // Average Record Details Display
        public List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails> Display_AuthDesk_MIS_ProjectAverageRecordsFileTimeDetails_ForProjects(string prmUserIDrole)
        {
            connection();
            Int32 prmIsApplicationModeFlag = 0;
            Int64 prmEventActionTypeCode = 0;
            Int32 prmRangeNumberValue = 0;
            DateTime prmInputEntry_FromDate = DateTime.Now;
            DateTime prmInputEntry_ToDate = DateTime.Now;
            Int32 prmRangeValueDateInputFlag = 0;
            Int32 prmInputEntry_Month = 0;
            Int32 prmInputEntry_Year = 0;

            List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeAverageRecordsDetails_Projects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", prmUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", prmIsApplicationModeFlag);
            cmd.Parameters.AddWithValue("p_EventActionTypeFlag", prmEventActionTypeCode);
            cmd.Parameters.AddWithValue("p_RangeNumberFlag", prmRangeNumberValue);
            cmd.Parameters.AddWithValue("p_InputEntry_FromDate", prmInputEntry_FromDate);
            cmd.Parameters.AddWithValue("p_InputEntry_ToDate", prmInputEntry_ToDate);
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
                       new Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails
                       {
                           IndexCode = Convert.ToInt64(dr["IndexCode"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           ApplicationSubmitted_Date = Convert.ToDateTime(dr["ApplicationSubmitted_Date"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           DaysInNumber = Convert.ToString(dr["DaysInNumber"]),
                           DaysRangeLevel_Title = Convert.ToString(dr["DaysRangeLevel_Title"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),

                           //IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                           //ApplicationEventTypeCode = Convert.ToInt64(dr["ApplicationEventTypeCode"]),
                           //RangeNumberValue = Convert.ToInt32(dr["RangeNumberValue"]),
                           //IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                           //InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                           //InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),
                           EventMonth = Convert.ToInt32(dr["EventMonth"]),
                           EventYear = Convert.ToInt32(dr["EventYear"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }
        public List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails> Display_AuthDesk_MIS_ProjectAverageRecordsFileTimeDetailsByID_ForProjects(string prmUserIDrole, Int32 prmIsApplicationModeFlag, Int64 prmEventActionTypeCode, Int32 prmRangeNumberValue, DateTime prmInputEntry_FromDate, DateTime prmInputEntry_ToDate, Int32 prmRange, Int32 prmMonth, Int32 prmYear)
        {
            connection();
            List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails> ProjectReralist = new List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectFileTimeAverageRecordsDetails_Projects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", prmUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationModeFlag", prmIsApplicationModeFlag);
            cmd.Parameters.AddWithValue("p_EventActionTypeFlag", prmEventActionTypeCode);
            cmd.Parameters.AddWithValue("p_RangeNumberFlag", prmRangeNumberValue);
            cmd.Parameters.AddWithValue("p_InputEntry_FromDate", prmInputEntry_FromDate);
            cmd.Parameters.AddWithValue("p_InputEntry_ToDate", prmInputEntry_ToDate);
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
                       new Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails
                       {
                           IndexCode = Convert.ToInt64(dr["IndexCode"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),

                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           ApplicationSubmitted_Date = Convert.ToDateTime(dr["ApplicationSubmitted_Date"]),
                           Project_Name = Convert.ToString(dr["Project_Name"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           DaysInNumber = Convert.ToString(dr["DaysInNumber"]),
                           DaysRangeLevel_Title = Convert.ToString(dr["DaysRangeLevel_Title"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToInt64(dr["B_column"]),
                           C_column = Convert.ToDateTime(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),

                           //IsApplicationModeFlag = Convert.ToInt32(dr["IsApplicationModeFlag"]),
                           //ApplicationEventTypeCode = Convert.ToInt64(dr["ApplicationEventTypeCode"]),
                           //RangeNumberValue = Convert.ToInt32(dr["RangeNumberValue"]),
                           //IsRangeValueDateInputFlag = Convert.ToInt32(dr["IsRangeValueDateInputFlag"]),
                           //InputEntry_FromDate = Convert.ToDateTime(dr["InputEntry_FromDate"]),
                           //InputEntry_ToDate = Convert.ToDateTime(dr["InputEntry_ToDate"]),
                           EventMonth = Convert.ToInt32(dr["EventMonth"]),
                           EventYear = Convert.ToInt32(dr["EventYear"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectReralist;
        }

        // Master Event
        public List<Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent> Display_Master_MIS_ProjectExtensionCompletionDetailsByID_ForProjects(string prmUserIDrole, Int32 prmApplicationTypeFlag, string prmForEventAction)
        {
            connection();
            List<Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent> ProjectReralist = new List<Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_ForReportsEventActionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", prmUserIDrole);
            cmd.Parameters.AddWithValue("p_ApplicationTypeFlag", prmApplicationTypeFlag);
            cmd.Parameters.AddWithValue("p_ForEventAction", prmForEventAction);            

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent
                       {
                           IndexCode = Convert.ToInt64(dr["IndexCode"]),
                           EventAction_Code = Convert.ToInt32(dr["EventAction_Code"]),
                           EventAction_Name = Convert.ToString(dr["EventAction_Name"]),
                           A_column = Convert.ToString(dr["A_column"]),
                       });
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
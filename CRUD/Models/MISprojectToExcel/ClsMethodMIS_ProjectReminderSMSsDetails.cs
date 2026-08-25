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
    public class ClsMethodMIS_ProjectReminderSMSgatewayDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> Display_AuthDesk_MIS_ProjectReminderSMSgatewayDetails_ForRegisteredProjects(string UserID_Role)
        {
            connection();
            List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> ProjectReralist = new List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectReminderSMSsDetails_RegdProjects", con);
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
                       new ClsprpMIS_ProjectInCompleteRemindersSMSgateway
                       {
                           ProjectReminderLogSMS_IndexID = Convert.ToInt64(dr["ProjectReminderLogSMS_IndexID"]),
                           ProjectReminderLogSMS_ID = Convert.ToInt64(dr["ProjectReminderLogSMS_ID"]),
                           Related_ProjectReminderSMS_IndexID = Convert.ToInt64(dr["Related_ProjectReminderSMS_IndexID"]),
                           Related_ProjectReminderSMS_ID = Convert.ToInt64(dr["Related_ProjectReminderSMS_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),

                           Event_Type = Convert.ToInt64(dr["Event_Type"]),
                           Event_IdentifiedOnDate = Convert.ToDateTime(dr["Event_IdentifiedOnDate"]),
                           Event_AggregateName = Convert.ToString(dr["Event_AggregateName"]),

                           ReminderType = Convert.ToString(dr["ReminderType"]),
                           ReminderTargetDate = Convert.ToDateTime(dr["ReminderTargetDate"]),
                           ReminderResolutionDate = Convert.ToDateTime(dr["ReminderResolutionDate"]),
                           SMSsMainAddress = Convert.ToString(dr["SMSsMainAddress"]),
                           SMSsAddressDetails = Convert.ToString(dr["SMSsAddressDetails"]),
                           SMSsAddressCount = Convert.ToInt32(dr["SMSsAddressCount"]),
                           SMS_SentDate = Convert.ToDateTime(dr["SMS_SentDate"]),
                           SMS_TitleSubject = Convert.ToString(dr["SMS_TitleSubject"]),
                           SMS_ContentBody = Convert.ToString(dr["SMS_ContentBody"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToInt32(dr["C_Column"]),
                           D_Column = Convert.ToDateTime(dr["D_Column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ROneFlag = Convert.ToInt32(dr["ROneFlag"]),
                           DateROne = Convert.ToDateTime(dr["DateROne"]),
                           RTwoFlag = Convert.ToInt32(dr["RTwoFlag"]),
                           DateRTwo = Convert.ToDateTime(dr["DateRTwo"]),

                           RThreeFlag = Convert.ToInt32(dr["RThreeFlag"]),
                           DateRThree = Convert.ToDateTime(dr["DateRThree"]),
                           RFourFlag = Convert.ToInt32(dr["RFourFlag"]),
                           DateRFour = Convert.ToDateTime(dr["DateRFour"]),
                       });
            }
            return ProjectReralist;
        }
        public List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> Display_AuthDesk_MIS_ProjectReminderSMSgatewayDetails_ForRegisteredProjects_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate, Int32 ReminderNumberType, string ReminderCasesType)
        {
            connection();
            List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> ProjectReralist = new List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectReminderSMSsDetails_RegdProjects", con);
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
            var rows = dt.Select().Where(p => (Convert.ToDateTime(p["Project_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["Project_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate)));
            if (rows.Any())
            {
                dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["Project_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["Project_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
            }

            con.Close();

            foreach (DataRow dr in dt1.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectInCompleteRemindersSMSgateway
                       {
                           ProjectReminderLogSMS_IndexID = Convert.ToInt64(dr["ProjectReminderLogSMS_IndexID"]),
                           ProjectReminderLogSMS_ID = Convert.ToInt64(dr["ProjectReminderLogSMS_ID"]),
                           Related_ProjectReminderSMS_IndexID = Convert.ToInt64(dr["Related_ProjectReminderSMS_IndexID"]),
                           Related_ProjectReminderSMS_ID = Convert.ToInt64(dr["Related_ProjectReminderSMS_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),

                           Event_Type = Convert.ToInt64(dr["Event_Type"]),
                           Event_IdentifiedOnDate = Convert.ToDateTime(dr["Event_IdentifiedOnDate"]),
                           Event_AggregateName = Convert.ToString(dr["Event_AggregateName"]),

                           ReminderType = Convert.ToString(dr["ReminderType"]),
                           ReminderTargetDate = Convert.ToDateTime(dr["ReminderTargetDate"]),
                           ReminderResolutionDate = Convert.ToDateTime(dr["ReminderResolutionDate"]),
                           SMSsMainAddress = Convert.ToString(dr["SMSsMainAddress"]),
                           SMSsAddressDetails = Convert.ToString(dr["SMSsAddressDetails"]),
                           SMSsAddressCount = Convert.ToInt32(dr["SMSsAddressCount"]),
                           SMS_SentDate = Convert.ToDateTime(dr["SMS_SentDate"]),
                           SMS_TitleSubject = Convert.ToString(dr["SMS_TitleSubject"]),
                           SMS_ContentBody = Convert.ToString(dr["SMS_ContentBody"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToInt32(dr["C_Column"]),
                           D_Column = Convert.ToDateTime(dr["D_Column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ROneFlag = Convert.ToInt32(dr["ROneFlag"]),
                           DateROne = Convert.ToDateTime(dr["DateROne"]),
                           RTwoFlag = Convert.ToInt32(dr["RTwoFlag"]),
                           DateRTwo = Convert.ToDateTime(dr["DateRTwo"]),

                           RThreeFlag = Convert.ToInt32(dr["RThreeFlag"]),
                           DateRThree = Convert.ToDateTime(dr["DateRThree"]),
                           RFourFlag = Convert.ToInt32(dr["RFourFlag"]),
                           DateRFour = Convert.ToDateTime(dr["DateRFour"]),
                       });
            }
            return ProjectReralist;
        }

        //pop-up modal screen
        public List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> Display_AuthDesk_MIS_ProjectReminderSMSgatewayDetails_ForRegisteredProjects_ShowContent(Int64 Project_ID, Int64 Promoter_ID, string UserID_Role, Int64 ReminderLog_ID)
        {
            connection();
            List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> ProjectReralist = new List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectReminderSMSs_RegdProjectsByParmID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_ReminderLog_ID", ReminderLog_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectInCompleteRemindersSMSgateway
                       {
                           ProjectReminderLogSMS_IndexID = Convert.ToInt64(dr["ProjectReminderLogSMS_IndexID"]),
                           ProjectReminderLogSMS_ID = Convert.ToInt64(dr["ProjectReminderLogSMS_ID"]),
                           Related_ProjectReminderSMS_IndexID = Convert.ToInt64(dr["Related_ProjectReminderSMS_IndexID"]),
                           Related_ProjectReminderSMS_ID = Convert.ToInt64(dr["Related_ProjectReminderSMS_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),

                           Event_Type = Convert.ToInt64(dr["Event_Type"]),
                           Event_IdentifiedOnDate = Convert.ToDateTime(dr["Event_IdentifiedOnDate"]),
                           Event_AggregateName = Convert.ToString(dr["Event_AggregateName"]),

                           ReminderType = Convert.ToString(dr["ReminderType"]),
                           ReminderTargetDate = Convert.ToDateTime(dr["ReminderTargetDate"]),
                           ReminderResolutionDate = Convert.ToDateTime(dr["ReminderResolutionDate"]),
                           SMSsMainAddress = Convert.ToString(dr["SMSsMainAddress"]),
                           SMSsAddressDetails = Convert.ToString(dr["SMSsAddressDetails"]),
                           SMSsAddressCount = Convert.ToInt32(dr["SMSsAddressCount"]),
                           SMS_SentDate = Convert.ToDateTime(dr["SMS_SentDate"]),
                           SMS_TitleSubject = Convert.ToString(dr["SMS_TitleSubject"]),
                           SMS_ContentBody = Convert.ToString(dr["SMS_ContentBody"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToInt32(dr["C_Column"]),
                           D_Column = Convert.ToDateTime(dr["D_Column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ROneFlag = Convert.ToInt32(dr["ROneFlag"]),
                           DateROne = Convert.ToDateTime(dr["DateROne"]),
                           RTwoFlag = Convert.ToInt32(dr["RTwoFlag"]),
                           DateRTwo = Convert.ToDateTime(dr["DateRTwo"]),

                           RThreeFlag = Convert.ToInt32(dr["RThreeFlag"]),
                           DateRThree = Convert.ToDateTime(dr["DateRThree"]),
                           RFourFlag = Convert.ToInt32(dr["RFourFlag"]),
                           DateRFour = Convert.ToDateTime(dr["DateRFour"]),
                       });
            }
            return ProjectReralist;
        }
        
        //pop-up modal at Desk Level screen
        public List<ClsprpMIS_ProjectInCompleteRemindersSchedulerSMSgateway> Display_AuthDesk_MIS_ProjectSchedulerReminderSMSsDetails_ForProjects(Int64 Project_ID, Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<ClsprpMIS_ProjectInCompleteRemindersSchedulerSMSgateway> ProjectReralist = new List<ClsprpMIS_ProjectInCompleteRemindersSchedulerSMSgateway>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ProjectReminderSMSsSchedulerDetails_Projects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ProjectInCompleteRemindersSchedulerSMSgateway
                       {
                           ProjectReminderSMS_IndexID = Convert.ToInt64(dr["ProjectReminderSMS_IndexID"]),
                           ProjectReminderSMS_ID = Convert.ToInt64(dr["ProjectReminderSMS_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),

                           Event_Type = Convert.ToInt64(dr["Event_Type"]),
                           Event_IdentifiedOnDate = Convert.ToDateTime(dr["Event_IdentifiedOnDate"]),

                           ROneFlag = Convert.ToInt32(dr["ROneFlag"]),
                           DateROne = Convert.ToDateTime(dr["DateROne"]),

                           RTwoFlag = Convert.ToInt32(dr["RTwoFlag"]),
                           DateRTwo = Convert.ToDateTime(dr["DateRTwo"]),

                           RThreeFlag = Convert.ToInt32(dr["RThreeFlag"]),
                           DateRThree = Convert.ToDateTime(dr["DateRThree"]),

                           RFourFlag = Convert.ToInt32(dr["RFourFlag"]),
                           DateRFour = Convert.ToDateTime(dr["DateRFour"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToInt32(dr["C_Column"]),
                           D_Column = Convert.ToDateTime(dr["D_Column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
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
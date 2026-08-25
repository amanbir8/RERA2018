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
    public class ClsMethodMIS_ExtnFormProjectReminderSMSgatewayDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //pop-up modal at Desk Level screen
        public List<ClsprpMIS_ExtnFormProjectInCompleteRemindersSchedulerSMSgateway> Display_AuthDesk_MIS_ExtnFormProjectSchedulerReminderSMSsDetails_ForProjects(Int64 Project_ID, Int64 Promoter_ID, string ExtnForm_DNumber, string UserID_Role)
        {
            connection();
            List<ClsprpMIS_ExtnFormProjectInCompleteRemindersSchedulerSMSgateway> ProjectReralist = new List<ClsprpMIS_ExtnFormProjectInCompleteRemindersSchedulerSMSgateway>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ExtnFormReminderSMSsSchedulerDetails_Projects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_ExtnForm_DNumber", ExtnForm_DNumber);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectReralist.Add(
                       new ClsprpMIS_ExtnFormProjectInCompleteRemindersSchedulerSMSgateway
                       {
                           ExtnProjectReminderSMS_IndexID = Convert.ToInt64(dr["ExtnProjectReminderSMS_IndexID"]),
                           ExtnProjectReminderSMS_ID = Convert.ToInt64(dr["ExtnProjectReminderSMS_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           ExtnProject_ID = Convert.ToInt64(dr["ExtnProject_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           ExtnProject_DiaryNumber = Convert.ToString(dr["ExtnProject_DiaryNumber"]),
                           Project_Diary_ApplicationDate = Convert.ToDateTime(dr["Project_Diary_ApplicationDate"]),

                           RERA_Registration_Number = Convert.ToString(dr["RERA_Registration_Number"]),
                           RERA_Registration_ValiduptoDate = Convert.ToDateTime(dr["RERA_Registration_ValiduptoDate"]),

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
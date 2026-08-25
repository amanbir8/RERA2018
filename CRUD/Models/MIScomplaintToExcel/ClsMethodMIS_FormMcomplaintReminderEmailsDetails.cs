using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CRUD.Models.MIScomplaintToExcel
{
    public class ClsMethodMIS_FormMcomplaintReminderEmailsDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //pop-up modal at Desk Level screen
        public List<ClsprpMIS_FormMInCompleteRemindersSchedulerEmails> Display_AuthDesk_MIS_FormMcomplaintSchedulerReminderEmailsDetails_ByID(Int64 Complaint_ID, Int64 Complaint_Code, string Complaint_DNumber, string UserID_Role)
        {
            connection();
            List<ClsprpMIS_FormMInCompleteRemindersSchedulerEmails> Complaintlist = new List<ClsprpMIS_FormMInCompleteRemindersSchedulerEmails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_ComplaintReminderEmailSchedulerDetails_FormM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Complaint_ID", Complaint_ID);
            cmd.Parameters.AddWithValue("p_Complaint_Code", Complaint_Code);
            cmd.Parameters.AddWithValue("p_Complaint_DNumber", Complaint_DNumber);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Complaintlist.Add(
                       new ClsprpMIS_FormMInCompleteRemindersSchedulerEmails
                       {
                           FormM_Reminder_IndexID = Convert.ToInt64(dr["FormM_Reminder_IndexID"]),
                           FormM_Reminder_ID = Convert.ToInt64(dr["FormM_Reminder_ID"]),
                           RelatedComplaintFormM_ID = Convert.ToInt64(dr["RelatedComplaintFormM_ID"]),

                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
                           Complainant_Mobile_Number = Convert.ToInt64(dr["Complainant_Mobile_Number"]),
                           Complainant_Email_ID = Convert.ToString(dr["Complainant_Email_ID"]),

                           RelatedComplaintFormM_DiaryNumber = Convert.ToString(dr["RelatedComplaintFormM_DiaryNumber"]),                           
                           ApplicationDateFormM = Convert.ToDateTime(dr["ApplicationDateFormM"]),

                           RelatedComplaint_ID = Convert.ToInt64(dr["RelatedComplaint_ID"]),
                           RelatedComplaint_DiaryNumber = Convert.ToString(dr["RelatedComplaint_DiaryNumber"]),
                           
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           IsTransferCase = Convert.ToInt32(dr["IsTransferCase"]),
                           TransferTypeOption = Convert.ToString(dr["TransferTypeOption"]),
                           TransferDate = Convert.ToDateTime(dr["TransferDate"]),

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
            return Complaintlist;
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
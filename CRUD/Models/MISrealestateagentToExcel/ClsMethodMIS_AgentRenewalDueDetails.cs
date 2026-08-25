using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class ClsMethod_MIS_AgentRenewalDueDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_MIS_AgentDuePendingRenewal> Display_Agent_DueRenewalApplications(string prmUserID_Role, DateTime prmFromDate, DateTime prmToDate, String prmSearchTypeFlag, String prmSearchRangeFlag, Int32 prmEventMonth, Int32 prmEventYear)
        {
            connection();
            List<Clsprp_MIS_AgentDuePendingRenewal> AgentReralist = new List<Clsprp_MIS_AgentDuePendingRenewal>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_AgentRenewalDueDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", prmUserID_Role);
            cmd.Parameters.AddWithValue("p_Fromdate", prmFromDate);
            cmd.Parameters.AddWithValue("p_Todate", prmToDate);
            cmd.Parameters.AddWithValue("p_SearchTypeFlag", prmSearchTypeFlag);
            cmd.Parameters.AddWithValue("p_SearchRangeFlag", prmSearchRangeFlag);
            cmd.Parameters.AddWithValue("p_EventMonth", prmEventMonth);
            cmd.Parameters.AddWithValue("p_EventYear", prmEventYear);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_AgentDuePendingRenewal
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),

                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_TypeSTR = Convert.ToString(dr["Agent_TypeSTR"]),
                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_RERA_No = Convert.ToString(dr["Agent_RERA_No"]),
                           Agent_RERA_IssueDate = Convert.ToDateTime(dr["Agent_RERA_IssueDate"]),
                           Agent_RERA_ValidDate = Convert.ToDateTime(dr["Agent_RERA_ValidDate"]),

                           P_AddressLine1 = Convert.ToString(dr["P_AddressLine1"]),
                           P_AddressLine2 = Convert.ToString(dr["P_AddressLine2"]),
                           P_AddressStateCode = Convert.ToString(dr["P_AddressStateCode"]),
                           P_AddressDistrictCode = Convert.ToString(dr["P_AddressDistrictCode"]),
                           P_AddressPIN = Convert.ToString(dr["P_AddressPIN"]),

                           RegOffice_AddressLine1 = Convert.ToString(dr["RegOffice_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["RegOffice_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["RegOffice_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["RegOffice_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["RegOffice_AddressPIN"]),

                           BusinessPlace_AddressLine1 = Convert.ToString(dr["BusinessPlace_AddressLine1"]),
                           BusinessPlace_AddressLine2 = Convert.ToString(dr["BusinessPlace_AddressLine2"]),
                           BusinessPlace_AddressStateCode = Convert.ToString(dr["BusinessPlace_AddressStateCode"]),
                           BusinessPlace_AddressDistrictCode = Convert.ToString(dr["BusinessPlace_AddressDistrictCode"]),
                           BusinessPlace_AddressPIN = Convert.ToString(dr["BusinessPlace_AddressPIN"]),

                           BComm_AddressLine1 = Convert.ToString(dr["BComm_AddressLine1"]),
                           BComm_AddressLine2 = Convert.ToString(dr["BComm_AddressLine2"]),
                           BComm_AddressStateCode = Convert.ToString(dr["BComm_AddressStateCode"]),
                           BComm_AddressDistrictCode = Convert.ToString(dr["BComm_AddressDistrictCode"]),
                           BComm_AddressPIN = Convert.ToString(dr["BComm_AddressPIN"]),
                           AuthorizedSignatory_Name = Convert.ToString(dr["AuthorizedSignatory_Name"]),
                           AuthorizedSignatory_MiddleName = Convert.ToString(dr["AuthorizedSignatory_MiddleName"]),
                           AuthorizedSignatory_LastName = Convert.ToString(dr["AuthorizedSignatory_LastName"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           EmailAddress = Convert.ToString(dr["EmailAddress"]),

                           Merge_Mode = Convert.ToInt32(dr["Merge_Mode"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Application_SearchTypeFlag = Convert.ToString(dr["Application_SearchTypeFlag"]),
                           Application_SearchRangeFlag = Convert.ToString(dr["Application_SearchRangeFlag"]),
                           Application_FromDate = Convert.ToDateTime(dr["Application_FromDate"]),
                           Application_ToDate = Convert.ToDateTime(dr["Application_ToDate"]),
                           EventMonth = Convert.ToInt32(dr["EventMonth"]),
                           EventYear = Convert.ToInt32(dr["EventYear"]),
                       });
            }
            return AgentReralist;
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
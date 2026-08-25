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
    public class ClsMethod_MIS_AgentAddressDirectoryDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_MIS_AgentAddressDirectoryDetails> Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForInProcessApplication(string UserID_Role)
        {
            try
            {
                connection();
                List<Clsprp_MIS_AgentAddressDirectoryDetails> AgentReralist = new List<Clsprp_MIS_AgentAddressDirectoryDetails>();

                //MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentAddressDirectoryDetails_InProcess", con);
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_GETAgentAddressDirectoryDetails_InProcess", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    AgentReralist.Add(
                           new Clsprp_MIS_AgentAddressDirectoryDetails
                           {
                               Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                               reranumber = Convert.ToString(dr["reranumber"]),
                               Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                               Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                               Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                               Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                               Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),

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

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
                return AgentReralist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Clsprp_MIS_AgentAddressDirectoryDetails> Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForInProcessApplication_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate, string AgentRegType)
        {
            try
            {
                connection();
                List<Clsprp_MIS_AgentAddressDirectoryDetails> AgentReralist = new List<Clsprp_MIS_AgentAddressDirectoryDetails>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_RAgentAddressDirectoryDetails_InProcess", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);


                string ddFromDate = FromDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
                string ddToDate = ToDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Todate", ddToDate);

                cmd.Parameters.AddWithValue("p_AgentRegType", AgentRegType);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);

                DataTable dt1 = new DataTable();
                if (AgentRegType == "1")
                {
                    var rows = dt.Select().Where(p => (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate)));
                    if (rows.Any())
                    {
                        dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
                    }
                }
                else
                {
                    var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate)));
                    if (rows.Any())
                    {
                        dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
                    }
                }

                con.Close();

                foreach (DataRow dr in dt1.Rows)
                {
                    //DateTime? appDate = AgentRegType == "1"? (dr["Agent_Diary_ApplicationDate"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"])): (dr["RenewalAgent_Diary_ApplicationDate"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(dr["RenewalAgent_Diary_ApplicationDate"]));
                    //DateTime? appDate = null;

                    //if (AgentRegType == "1" && dt1.Columns.Contains("Agent_Diary_ApplicationDate"))
                    //{
                    //    appDate = dr["Agent_Diary_ApplicationDate"] == DBNull.Value
                    //        ? (DateTime?)null
                    //        : Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]);
                    //}
                    //else if (AgentRegType == "2" && dt1.Columns.Contains("RenewalAgent_Diary_ApplicationDate"))
                    //{
                    //    appDate = dr["RenewalAgent_Diary_ApplicationDate"] == DBNull.Value
                    //        ? (DateTime?)null
                    //        : Convert.ToDateTime(dr["RenewalAgent_Diary_ApplicationDate"]);
                    //}
                    DateTime? agentDate = null;
                    DateTime? renewalDate = null;

                    // Agent Date
                    if (dt1.Columns.Contains("Agent_Diary_ApplicationDate"))
                    {
                        agentDate = dr["Agent_Diary_ApplicationDate"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]);
                    }

                    // Renewal Date
                    if (dt1.Columns.Contains("RenewalAgent_Diary_ApplicationDate"))
                    {
                        renewalDate = dr["RenewalAgent_Diary_ApplicationDate"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(dr["RenewalAgent_Diary_ApplicationDate"]);
                    }

                    AgentReralist.Add(
                           new Clsprp_MIS_AgentAddressDirectoryDetails
                           {
                               Agent_DiaryNumber = dt1.Columns.Contains("Agent_DiaryNumber")? Convert.ToString(dr["Agent_DiaryNumber"]): null,
                               reranumber = dt1.Columns.Contains("reranumber") ? Convert.ToString(dr["reranumber"]): null,
                               RenewalAgent_DiaryNumber = dt1.Columns.Contains("RenewalAgent_DiaryNumber")? Convert.ToString(dr["RenewalAgent_DiaryNumber"]): null,

                               Agent_Diary_ApplicationDate = agentDate,
                               RenewalAgent_Diary_ApplicationDate = renewalDate,

                               Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                               RenewalAgent_ID = dt1.Columns.Contains("RenewalAgent_ID") ? Convert.ToInt64(dr["RenewalAgent_ID"]): 0,

                               Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                               Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                               Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),

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

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
                return AgentReralist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Clsprp_MIS_AgentAddressDirectoryDetails> Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForRegisteredAgents(string UserID_Role)
        {
            connection();
            List<Clsprp_MIS_AgentAddressDirectoryDetails> AgentReralist = new List<Clsprp_MIS_AgentAddressDirectoryDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentAddressDirectoryDetails_RegdAgents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AgentReralist.Add(
                       new Clsprp_MIS_AgentAddressDirectoryDetails
                       {
                           Agent_DiaryNumber = Convert.ToString(dr["Agent_DiaryNumber"]),
                           Agent_Diary_ApplicationDate = Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]),
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),

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

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AgentReralist;
        }
        public List<Clsprp_MIS_AgentAddressDirectoryDetails> Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForRegisteredAgents_ByParmDate(string UserID_Role, DateTime FromDate, DateTime ToDate, string AgentRegType)
        {
            try
            {
                connection();
                List<Clsprp_MIS_AgentAddressDirectoryDetails> AgentReralist = new List<Clsprp_MIS_AgentAddressDirectoryDetails>();

                //MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentAddressDirectoryDetails_RegdAgents", con);
                MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_RAgentAddressDirectoryDetails_RegdAgents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                string ddFromDate = FromDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Fromdate", ddFromDate);
                string ddToDate = ToDate.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Todate", ddToDate);

                cmd.Parameters.AddWithValue("p_AgentRegType", AgentRegType);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);

                DataTable dt1 = new DataTable();
                if (AgentRegType == "1")
                {
                    var rows = dt.Select().Where(p => (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate)));
                    if (rows.Any())
                    {
                        dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["Agent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
                    }
                }
                else
                {
                    var rows = dt.Select().Where(p => (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate)));
                    if (rows.Any())
                    {
                        dt1 = dt.Select().Where(p => (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) >= Convert.ToDateTime(ddFromDate)) && (Convert.ToDateTime(p["RenewalAgent_Diary_ApplicationDate"]) <= Convert.ToDateTime(ddToDate))).CopyToDataTable();
                    }
                }

                con.Close();

                foreach (DataRow dr in dt1.Rows)
                {
                    //DateTime? appDate = AgentRegType == "1"? (dr["Agent_Diary_ApplicationDate"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"])): (dr["RenewalAgent_Diary_ApplicationDate"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(dr["RenewalAgent_Diary_ApplicationDate"]));
                    //DateTime? appDate = null;

                    //if (AgentRegType == "1" && dt1.Columns.Contains("Agent_Diary_ApplicationDate"))
                    //{
                    //    appDate = dr["Agent_Diary_ApplicationDate"] == DBNull.Value
                    //        ? (DateTime?)null
                    //        : Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]);
                    //}
                    //else if (AgentRegType == "2" && dt1.Columns.Contains("RenewalAgent_Diary_ApplicationDate"))
                    //{
                    //    appDate = dr["RenewalAgent_Diary_ApplicationDate"] == DBNull.Value
                    //        ? (DateTime?)null
                    //        : Convert.ToDateTime(dr["RenewalAgent_Diary_ApplicationDate"]);
                    //}
                    DateTime? agentDate = null;
                    DateTime? renewalDate = null;

                    // Agent Date
                    if (dt1.Columns.Contains("Agent_Diary_ApplicationDate"))
                    {
                        agentDate = dr["Agent_Diary_ApplicationDate"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(dr["Agent_Diary_ApplicationDate"]);
                    }

                    // Renewal Date
                    if (dt1.Columns.Contains("RenewalAgent_Diary_ApplicationDate"))
                    {
                        renewalDate = dr["RenewalAgent_Diary_ApplicationDate"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(dr["RenewalAgent_Diary_ApplicationDate"]);
                    }

                    AgentReralist.Add(
                           new Clsprp_MIS_AgentAddressDirectoryDetails
                           {
                               Agent_DiaryNumber = dt1.Columns.Contains("Agent_DiaryNumber") ? Convert.ToString(dr["Agent_DiaryNumber"]) : null,
                               RenewalAgent_DiaryNumber = dt1.Columns.Contains("RenewalAgent_DiaryNumber") ? Convert.ToString(dr["RenewalAgent_DiaryNumber"]) : null,
                               reranumber= Convert.ToString(dr["reranumber"]),
                               Agent_Diary_ApplicationDate = agentDate,
                               RenewalAgent_Diary_ApplicationDate = renewalDate,

                               Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                               RenewalAgent_ID = dt1.Columns.Contains("RenewalAgent_ID") ? Convert.ToInt64(dr["RenewalAgent_ID"]) : 0,

                               Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                               Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                               Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),

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

                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           });
                }
                return AgentReralist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //pop-up modal screen
        public List<Clsprp_MIS_AgentAddressDirectoryDetails> Display_AuthDesk_MIS_AgentAddressDirectoryDetails_ForMIS(Int64 Agent_ID, string UserID_Role, string AgentRegType)
        {
            connection();
            List<Clsprp_MIS_AgentAddressDirectoryDetails> AgentReralist = new List<Clsprp_MIS_AgentAddressDirectoryDetails>();

            //MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_AgentAddressDirectoryDetails_ByAgentID", con);
            MySqlCommand cmd = new MySqlCommand("Display_Rera_MIS_RAgentAddressDirectoryDetails_ByAgentID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AgentID", Agent_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_AgentRegType", AgentRegType);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                AgentReralist.Add(
                       new Clsprp_MIS_AgentAddressDirectoryDetails
                       {

                           Agent_DiaryNumber = dt.Columns.Contains("Agent_DiaryNumber")? Convert.ToString(dr["Agent_DiaryNumber"]): null,
                           RenewalAgent_DiaryNumber = dt.Columns.Contains("RenewalAgent_DiaryNumber")? Convert.ToString(dr["RenewalAgent_DiaryNumber"]): null,
                           Agent_ID = Convert.ToInt64(dr["Agent_ID"]),
                           RenewalAgent_ID = dt.Columns.Contains("RenewalAgent_ID") ? Convert.ToInt64(dr["RenewalAgent_ID"]) : 0,
                           Agent_Type = Convert.ToInt32(dr["Agent_Type"]),
                           Agent_TypeSTR = fnReturnSTR(Convert.ToString(dr["Agent_Type"])),

                           Agent_Organization_Name = Convert.ToString(dr["Agent_Organization_Name"]),

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

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
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



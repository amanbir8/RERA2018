using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_FormN_LogCommunication
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public List<ClsPrp_AuthDesk_FormN_LogCommunication> Display_AuthDesk_ComplaintFormN_LogCommunicationByID(Int64 ComplaintFormN_ID, Int64 UserLog_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_LogCommunication> UserLogList = new List<ClsPrp_AuthDesk_FormN_LogCommunication>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_LogCommunicationByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_UserLog_ID", UserLog_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                UserLogList.Add(
                       new ClsPrp_AuthDesk_FormN_LogCommunication
                       {
                           CommUserLog_IndexID = Convert.ToInt64(dr["CommUserLog_IndexID"]),
                           Complaint_ID = Convert.ToInt64(dr["Complaint_ID"]),
                           Complaint_DiaryNumber = Convert.ToString(dr["Complaint_DiaryNumber"]),
                           CommunicationTitleName = Convert.ToString(dr["CommunicationTitleName"]),
                           SignInDate = Convert.ToDateTime(dr["SignInDate"]),
                           CommunicationActivity = Convert.ToString(dr["CommunicationActivity"]),
                           DestinationEmailAddress = Convert.ToString(dr["DestinationEmailAddress"]),
                           SourceHostName = Convert.ToString(dr["SourceHostName"]),
                           SourceIP = Convert.ToString(dr["SourceIP"]),
                           Activity = Convert.ToString(dr["Activity"]),
                           ActivityDescription = Convert.ToString(dr["ActivityDescription"]),
                           RERAnumber = Convert.ToString(dr["RERAnumber"]),
                           ComplaintAganistName = Convert.ToString(dr["ComplaintAganistName"]),
                           UserName = Convert.ToString(dr["UserName"]),
                           HearingDate = Convert.ToDateTime(dr["HearingDate"]),
                           HearingTime = Convert.ToString(dr["HearingTime"]),
                           HearingBench = Convert.ToString(dr["HearingBench"]),
                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return UserLogList;
        }        
    }
}
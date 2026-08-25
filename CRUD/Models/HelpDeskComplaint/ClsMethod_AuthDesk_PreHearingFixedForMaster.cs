using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_PreHearingFixedForMaster
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> Display_AuthDesk_Complaint_PreHearingDateFixedForMaster(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> ProjectFivelist1 = new List<ClsPrp_AuthDesk_PreHearingFixedFor_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_Complaint_PreHearingFixedForMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_PreHearingFixedFor_Master
                       {
                           PreHearingDate_IndexID = Convert.ToInt64(dr["PreHearingDate_IndexID"]),
                           PreHearingDate_ID = Convert.ToInt64(dr["PreHearingDate_ID"]),
                           PreHearingFixedForCode = Convert.ToString(dr["PreHearingFixedForCode"]), //ToInt64
                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           PreHearingType = Convert.ToString(dr["PreHearingType"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> Display_AuthDesk_Complaint_PreHearingDateFormNFixedForMaster(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> ProjectFivelist1 = new List<ClsPrp_AuthDesk_PreHearingFixedFor_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_Complaint_PreHearingNFixedForMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_PreHearingFixedFor_Master
                       {
                           PreHearingDate_IndexID = Convert.ToInt64(dr["PreHearingDate_IndexID"]),
                           PreHearingDate_ID = Convert.ToInt64(dr["PreHearingDate_ID"]),
                           PreHearingFixedForCode = Convert.ToString(dr["PreHearingFixedForCode"]), //ToInt64
                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           PreHearingType = Convert.ToString(dr["PreHearingType"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }
    }
}
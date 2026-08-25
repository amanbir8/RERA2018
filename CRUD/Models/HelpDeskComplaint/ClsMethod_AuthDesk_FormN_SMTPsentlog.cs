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
    public class ClsMethod_AuthDesk_FormN_SMTPsentlog
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_ComplaintFormN_SMTPsentlog(ClsPrp_AuthDesk_FormN_SMTPsentlog smodel, string UserName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formn_smtpsentlog", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_SentemailUserLogID", smodel.SentemailUserLogID);
            cmd.Parameters.AddWithValue("p_ComplaintDiaryNumber", String.IsNullOrEmpty(smodel.ComplaintDiaryNumber) ? "" : smodel.ComplaintDiaryNumber);
            cmd.Parameters.AddWithValue("p_ComplaintID", smodel.ComplaintID);
            cmd.Parameters.AddWithValue("p_SignInDate", smodel.SignInDate == null ? dtvalue : smodel.SignInDate);
            cmd.Parameters.AddWithValue("p_UserName", String.IsNullOrEmpty(UserName) ? "" : UserName);
            cmd.Parameters.AddWithValue("p_DestinationEmailAddress", String.IsNullOrEmpty(smodel.DestinationEmailAddress) ? "" : smodel.DestinationEmailAddress);
            cmd.Parameters.AddWithValue("p_SourceHostName", String.IsNullOrEmpty(smodel.SourceHostName) ? "" : smodel.SourceHostName);
            cmd.Parameters.AddWithValue("p_SourceIP", String.IsNullOrEmpty(smodel.SourceIP) ? "" : smodel.SourceIP);
            cmd.Parameters.AddWithValue("p_Activity", String.IsNullOrEmpty(smodel.Activity) ? "" : smodel.Activity);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return true;
            else
                return false;
        }        
    }
}
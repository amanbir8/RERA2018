using MySql.Data.MySqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models;
using System.Data;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CRUD.Controllers
{
    public class ActivityLogger
    {

        #region LOGIN/LOGOUT
        public static void LogActivity(string userId, int userroleid)
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            //string browser = HttpContext.Current.Request.Browser.Browser + " " + HttpContext.Current.Request.Browser.Version;
            string browser = HttpContext.Current.Request.UserAgent;
            //string ip = HttpContext.Current.Request.UserHostAddress;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Insert_UserActivityLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_UserId", userId);
                    cmd.Parameters.AddWithValue("p_Userroleid", userroleid);
                    cmd.Parameters.AddWithValue("p_Browser", browser);
                    cmd.Parameters.AddWithValue("p_IPAddress", ip);
                    cmd.Parameters.AddWithValue("p_sign_intime", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public static void LogLogout(string userid)
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Update_UserActivityLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_userid", userid);
                    cmd.Parameters.AddWithValue("p_LogoutTime", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion


        public static void LogEventActivity(string userId, string menuName, string action)
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Insert_UserLogEventActivityLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_UserId", userId);
                    cmd.Parameters.AddWithValue("p_MenuName", menuName);
                    cmd.Parameters.AddWithValue("p_Action", action);
                    cmd.Parameters.AddWithValue("p_sign_intime", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        //[HttpPost]
        //[AllowAnonymous] 
        //public void AutoLogout()
        //{
        //    try
        //    {
        //        var userId = HttpContext.Current?.User?.Identity?.GetUserId();

        //        if (!string.IsNullOrEmpty(userId))
        //        {
        //            LogLogout(userId);
        //        }
        //    }
        //    catch
        //    {
        //        // silently ignore (important for beacon)
        //    }
        //}
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AutoLogout(string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    LogLogout(userId);
                }
            }
            catch{}
            return new HttpStatusCodeResult(200);
        }
    }
}
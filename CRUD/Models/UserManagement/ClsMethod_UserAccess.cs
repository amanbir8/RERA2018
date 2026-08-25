using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace CRUD.Models.UserAccess
{
    public class ClsMethod_UserAccess
    {
        public abstract class clscon
        {
            //protected SqlConnection con = new SqlConnection();
            protected MySqlConnection con = new MySqlConnection();
            public clscon()
            {
                //con.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConn"].ConnectionString;
                con.ConnectionString = ConfigurationManager.ConnectionStrings["reraConn"].ConnectionString;
            }
        }
        public class ClassMain : clscon
        {
            //public ClsPrp_UserAccessType DisplayUserAccess(string UserID, Int32 UserRole)
            //{
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    } 
            //    //Agent               
            //    //SqlCommand cmd = new SqlCommand("usp_Display_RERA_UserAccessAgent", con);
            //    //Promoter
            //    //SqlCommand cmd = new SqlCommand("usp_Display_RERA_UserAccess", con);
            //    //ALL working
            //    SqlCommand cmd = new SqlCommand("usp_Display_RERA_UserAccessLogin", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@UserID", UserID);
            //    cmd.Parameters.AddWithValue("@UserRole", UserRole);

            //    SqlDataAdapter sd = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
                
            //    sd.Fill(dt);
            //    ClsPrp_UserAccessType clspro = new ClsPrp_UserAccessType();

            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        clspro.User_id = Convert.ToString(dr["User_ID"]);
            //        clspro.Application_id = Convert.ToInt64(dr["RegNumber"]);
            //        clspro.User_Type = Convert.ToInt32(dr["RegTypeFlag"]);
            //        clspro.User_ParentEntityFlag = Convert.ToInt32(dr["RegParentEntityFlag"]);
            //        clspro.User_TrackRecordFlag = Convert.ToInt32(dr["RegTrackRecordFlag"]);
            //        clspro.MobileNumber = Convert.ToInt64(dr["MobileNumber"]);
            //        clspro.EmailID = Convert.ToString(dr["EmailAddress"]);
            //    }
            //    cmd.Dispose();
            //    con.Close();
            //    return clspro;
            //}

            private MySqlConnection conms;
            private void connection()
            {
                string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
                conms = new MySqlConnection(constring);
            }
            public bool AlreadyExistUserName(string Username)
            {
                connection();
                bool rval = false;
                Int32 rvalcount = 0;
                if (conms.State == ConnectionState.Closed)
                {
                    conms.Open();
                }
                MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_AlreadyExistUserNameN", conms);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserName", Username);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);                
                foreach (DataRow dr in dt.Rows)
                {
                    rvalcount = Convert.ToInt32(dr["p_CountUserName"]);                    
                }

                if (rvalcount==0)
                {
                    rval = true;
                }
                cmd.Dispose();
                conms.Close();
                return rval;
            }

            public ClsPrp_UserAccessType DisplayUserAccess(string UserID, Int32 UserRole)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Agent               
                //SqlCommand cmd = new SqlCommand("usp_Display_RERA_UserAccessAgent", con);
                //Promoter
                //SqlCommand cmd = new SqlCommand("usp_Display_RERA_UserAccess", con);
                //ALL working
                ClsPrp_UserAccessType clspro = new ClsPrp_UserAccessType();
                try
                {
                    MySqlCommand cmd = new MySqlCommand("usp_Display_RERA_UserAccessLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_UserID", UserID);
                    cmd.Parameters.AddWithValue("p_UserRole", UserRole);

                    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sd.Fill(dt);
                    

                    foreach (DataRow dr in dt.Rows)
                    {
                        clspro.User_id = Convert.ToString(dr["User_ID"]);
                        clspro.Application_id = Convert.ToInt64(dr["RegNumber"]);
                        clspro.User_Type = Convert.ToInt32(dr["RegTypeFlag"]);
                        clspro.User_ParentEntityFlag = Convert.ToInt32(dr["RegParentEntityFlag"]);
                        clspro.User_TrackRecordFlag = Convert.ToInt32(dr["RegTrackRecordFlag"]);
                        clspro.MobileNumber = Convert.ToInt64(dr["MobileNumber"]);
                        clspro.EmailID = Convert.ToString(dr["EmailAddress"]);
                    }
                    cmd.Dispose();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string varEx = ex.ToString();
                }
                return clspro;
            }
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CRUD.Models
{
    public class UserDBHandler
    {


        public UserDetails dropdownlist_display()
        {
            List<UserDetails> userlist = new List<UserDetails>();
            List<UserDetails> userlist1 = new List<UserDetails>();

            UserDetails objuser = new UserDetails();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from userdetails", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserDetails uobj = new UserDetails();
                        uobj.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["userid"].ToString());
                        uobj.UserName = ds.Tables[0].Rows[i]["username"].ToString();
                        uobj.Education = ds.Tables[0].Rows[i]["education"].ToString();
                        uobj.Location = ds.Tables[0].Rows[i]["location"].ToString();
                        userlist.Add(uobj);
                        
                    }
                  objuser.usersinfo = userlist;
                }

                 

                con.Close();
            }




            return objuser;

        }
           
        }

    }

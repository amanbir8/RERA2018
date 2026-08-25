using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace CRUD.Models
{

    public class VM_user_district_DBhandler
    {
        public VM_User_Dist GetBlogComment()
        {
            VM_User_Dist BCVM = new VM_User_Dist();
            BCVM.user = dropdownlist_display();
            BCVM.district = dropdownlist_display1();
            return BCVM;
        }

        public List<UserDetails> dropdownlist_display()
        {
            List<UserDetails> userlist = new List<UserDetails>();
            

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
                    //objuser.usersinfo = userlist;
                    
                }

                

                con.Close();
            }


            return userlist;

            // return objuser;

        }
        public List<District> dropdownlist_display1()
        {
             
            List<District> userlist1 = new List<District>();

            District objuser = new District();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["SQLConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from DistrictMaster", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        District uobj = new District();
                        uobj.DistrictId = Convert.ToInt32(ds.Tables[0].Rows[i]["districtid"].ToString());
                        uobj.DistrictName = ds.Tables[0].Rows[i]["districtname"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.usersinfo = userlist1;
                    con.Close();
                    return userlist1;
                }



                
            }




           

        }

    }
}
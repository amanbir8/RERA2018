using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethodProject
    {
        public List<ClsPrp_Project_Master> FillDropdown_Project_ByAppId(Int64 Application_ID, Int64 tempParm)
        {

            List<ClsPrp_Project_Master> userlist1 = new List<ClsPrp_Project_Master>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ByAppIdN", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Application_ID);


                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Project_Master uobj = new ClsPrp_Project_Master();
                        uobj.ProjectRegistration_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectRegistration_ID"].ToString());
                        uobj.Project_Name = ds.Tables[0].Rows[i]["Project_Name"].ToString();

                        userlist1.Add(uobj);

                    }

                    con.Close();
                    return userlist1;
                }
            }
        }
        public List<ClsPrp_Project_Master> FillDropdown_Project_ByAppId_litigations(Int64 Application_ID, Int64 Project_Id)
        {

            List<ClsPrp_Project_Master> userlist1 = new List<ClsPrp_Project_Master>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Litigations_ByAppIdandprojectidN", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Application_ID);
                    cmd.Parameters.AddWithValue("p_Project_Id", Project_Id);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Project_Master uobj = new ClsPrp_Project_Master();
                        uobj.ProjectRegistration_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectRegistration_ID"].ToString());
                        uobj.Project_Name = ds.Tables[0].Rows[i]["Project_Name"].ToString();

                        userlist1.Add(uobj);

                    }

                    con.Close();
                    return userlist1;
                }

            }

        }

        public List<ClsPrp_Project_Master> FillDropdown_Project_ByAppId_FormFive(Int64 Promoter_ID, Int64 Project_ID)
        {
            List<ClsPrp_Project_Master> userlist1 = new List<ClsPrp_Project_Master>();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ByAppId_FormFive", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                    cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);                    

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Project_Master uobj = new ClsPrp_Project_Master();
                        uobj.ProjectRegistration_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectRegistration_ID"].ToString());
                        uobj.Project_Name = ds.Tables[0].Rows[i]["Project_Name"].ToString();
                        userlist1.Add(uobj);
                    }

                    con.Close();
                    return userlist1;
                }
            }
        }
        public List<ClsPrp_Project_Master> FillDropdown_Project_ByAppId_ExtensionForm(Int64 Promoter_ID, Int64 Project_ID)
        {
            List<ClsPrp_Project_Master> userlist1 = new List<ClsPrp_Project_Master>();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ByAppId_ExtensionForm", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                    cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Project_Master uobj = new ClsPrp_Project_Master();
                        uobj.ProjectRegistration_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectRegistration_ID"].ToString());
                        uobj.Project_Name = ds.Tables[0].Rows[i]["Project_Name"].ToString();
                        userlist1.Add(uobj);
                    }

                    con.Close();
                    return userlist1;
                }
            }
        }

        public List<ClsPrp_Project_Master> FillDropdown_Project_ByAppId_QuaterlyUpdates(Int64 Promoter_ID, Int64 Project_ID)
        {
            List<ClsPrp_Project_Master> userlist1 = new List<ClsPrp_Project_Master>();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ByAppId_QuaterlyUpdates", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                    cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Project_Master uobj = new ClsPrp_Project_Master();
                        uobj.ProjectRegistration_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectRegistration_ID"].ToString());
                        uobj.Project_Name = ds.Tables[0].Rows[i]["Project_Name"].ToString();
                        userlist1.Add(uobj);
                    }

                    con.Close();
                    return userlist1;
                }
            }
        }
    }
}
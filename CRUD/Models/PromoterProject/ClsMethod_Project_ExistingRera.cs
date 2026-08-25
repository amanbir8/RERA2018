using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_Project_ExistingRera
    {
        public List<ClsPrp_Project_ExistingRERA> Fill_Existing_detail(String RERAregistration_Number)
        {

            List<ClsPrp_Project_ExistingRERA> userlist1 = new List<ClsPrp_Project_ExistingRERA>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_ExistingRERA", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("p_RERAregistration_Number", RERAregistration_Number);


                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Project_ExistingRERA uobj = new ClsPrp_Project_ExistingRERA();
                     

                        uobj.ProjectExistingRERA_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProjectExistingRERA_ID"].ToString());
                        uobj.RERAregistration_Number = ds.Tables[0].Rows[i]["RERAregistration_Number"].ToString();
                        //uobj.RERAregistration_IssueDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["RERAregistration_IssueDate"].ToString());
                        //uobj.RERAregistration_ExpiryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["RERAregistration_ExpiryDate"].ToString());
                        //uobj.Date_of_Issue = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date_of_Issue"].ToString());
                        uobj.PromoterName = ds.Tables[0].Rows[i]["PromoterName"].ToString();
                        uobj.ProjectName = ds.Tables[0].Rows[i]["ProjectName"].ToString();
                        uobj.RERARegistrationNumber = ds.Tables[0].Rows[i]["RERARegistrationNumber"].ToString();
                        uobj.TypeofProject = ds.Tables[0].Rows[i]["TypeofProject"].ToString();
                        uobj.DistrictName = ds.Tables[0].Rows[i]["DistrictName"].ToString();
                        uobj.A_column = ds.Tables[0].Rows[i]["A_column"].ToString();
                        uobj.B_column = ds.Tables[0].Rows[i]["B_column"].ToString();
                        uobj.C_column = ds.Tables[0].Rows[i]["C_column"].ToString();
                        uobj.IsActive = Convert.ToInt32(ds.Tables[0].Rows[i]["IsActive"].ToString());
                        uobj.CreatedBy = ds.Tables[0].Rows[i]["CreatedBy"].ToString();
                 
                        uobj.ModifyBy = ds.Tables[0].Rows[i]["ModifyBy"].ToString();
                   

                        userlist1.Add(uobj);

                    }

                    con.Close();
                    return userlist1;
                }




            }





        }
    }
}
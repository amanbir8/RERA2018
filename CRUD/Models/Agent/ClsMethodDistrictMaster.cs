using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUD.Models.Agent;


namespace CRUD.Models.Agent
{
    public class ClsMethodDistrictMaster
    {
        public List<Agent.Clsprp_DistrictMaster> dropdownlist_display1()
        {

            List<Agent.Clsprp_DistrictMaster> userlist1 = new List<Agent.Clsprp_DistrictMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["SQLConn"].ToString();
            SqlConnection con = new SqlConnection();
            using (con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDistrictList", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Agent.Clsprp_DistrictMaster uobj = new Agent.Clsprp_DistrictMaster();
                        uobj.DistrictId = Convert.ToInt32(ds.Tables[0].Rows[i]["districtid"].ToString());
                        uobj.DistrictName = ds.Tables[0].Rows[i]["districtname"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }




            }






        }
        public List<Agent.ClsPrp_StateMaster> State_list()
        {

            List<ClsPrp_StateMaster> userlist1 = new List<ClsPrp_StateMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["SQLConn"].ToString();
            SqlConnection con = new SqlConnection();
            using (con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetStates", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    

                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_StateMaster uobj = new ClsPrp_StateMaster();
                        uobj.StateId = Convert.ToInt32(ds.Tables[0].Rows[i]["State_Code"].ToString());
                        uobj.StateName = ds.Tables[0].Rows[i]["State_Name"].ToString();

                        userlist1.Add(uobj);

                    }

                    con.Close();
                    return userlist1;
                }




            }






        }

        public List<Agent.Clsprp_DistrictMaster> dropdownlist_display1(int stateid)
        {

            List<Clsprp_DistrictMaster> userlist1 = new List<Clsprp_DistrictMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["SQLConn"].ToString();
            SqlConnection con = new SqlConnection();
            using (con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDistrictByStateId", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stateid", stateid);
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Clsprp_DistrictMaster uobj = new Clsprp_DistrictMaster();
                        uobj.DistrictId = Convert.ToInt32(ds.Tables[0].Rows[i]["districtid"].ToString());
                        uobj.DistrictName = ds.Tables[0].Rows[i]["districtName"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }




            }






        }
        
    }
}
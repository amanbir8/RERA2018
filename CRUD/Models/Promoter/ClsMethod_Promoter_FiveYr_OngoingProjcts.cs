using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CRUD.Models.Promoter
{
    public class ClsMethod_Promoter_FiveYr_OngoingProjcts
    {

        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        public List<Clsprp_Promoter_FiveYr_OngoingProjcts> DisplayFiveYrProj(Int64 Application_id)
        {

            List<Clsprp_Promoter_FiveYr_OngoingProjcts> userlist1 = new List<Clsprp_Promoter_FiveYr_OngoingProjcts>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Display_by_id_CompltdProj_FiveYrs_Rera_Tbl_Promoter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Application_id", Application_id);


                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                ad.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Clsprp_Promoter_FiveYr_OngoingProjcts uobj = new Clsprp_Promoter_FiveYr_OngoingProjcts();
                    uobj.Ind_Org_CompltdProj_FiveYrs = Convert.ToInt32(ds.Tables[0].Rows[i]["Ind_Org_CompltdProj_FiveYrs"]);
                    uobj.Ind_Org_TotalArea_Constructed = Convert.ToDecimal(ds.Tables[0].Rows[i]["Ind_Org_TotalArea_Constructed"]);

                    userlist1.Add(uobj);

                }
                // objuser.districtMaster = userlist1;
                con.Close();
                return userlist1;
            }
        }

        public List<Clsprp_Promoter_FiveYr_OngoingProjcts> DisplayOngoingProj(Int64 Application_id)
        {

            List<Clsprp_Promoter_FiveYr_OngoingProjcts> userlist1 = new List<Clsprp_Promoter_FiveYr_OngoingProjcts>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Display_by_id_OngoingProjects_Rera_Tbl_Promoter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Application_id", Application_id);


                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                ad.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Clsprp_Promoter_FiveYr_OngoingProjcts uobj = new Clsprp_Promoter_FiveYr_OngoingProjcts();
                    uobj.Ind_Org_OngoingProjects = Convert.ToInt32(ds.Tables[0].Rows[i]["Ind_Org_OngoingProjects"]);
                    uobj.Ind_Org_AreaToBe_Constructed = Convert.ToDecimal(ds.Tables[0].Rows[i]["Ind_Org_AreaToBe_Constructed"]);

                    userlist1.Add(uobj);

                }
                // objuser.districtMaster = userlist1;
                con.Close();
                return userlist1;
            }
        }
    }
}
       
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CRUD.Models.Agent
{
    public class ClsMethodAgent_ExisitingRera
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        // Add  Rera Agent Exisiting

        public bool AddReraAgentExisiting(ClsprpAgent_ExisitingRera smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Agent_ExisitingRera", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AgentExistingRERA_ID", smodel.AgentExistingRERA_ID);
            cmd.Parameters.AddWithValue("p_RERA_RegNumber", smodel.RERA_RegNumber);
            cmd.Parameters.AddWithValue("p_Date_of_Issue", smodel.Date_of_Issue);
            cmd.Parameters.AddWithValue("p_Agent_FirstName", smodel.Agent_FirstName);
            cmd.Parameters.AddWithValue("p_Agent_MiddleName", smodel.Agent_MiddleName);
            cmd.Parameters.AddWithValue("p_Agent_LastName", smodel.Agent_LastName);
            cmd.Parameters.AddWithValue("p_Organization_Name", smodel.Organization_Name);
            cmd.Parameters.AddWithValue("p_Organization_TypeCode", smodel.Organization_TypeCode);
            cmd.Parameters.AddWithValue("p_P_AddressStateCode", smodel.P_AddressStateCode);
            cmd.Parameters.AddWithValue("p_P_AddressDistrictCode", smodel.P_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressStateCode", smodel.BusinessPlace_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BusinessPlace_AddressDistrictCode", smodel.BusinessPlace_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressStateCode", smodel.BComm_AddressStateCode);
            cmd.Parameters.AddWithValue("p_BComm_AddressDistrictCode", smodel.BComm_AddressDistrictCode);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;

        }

        public List<ClsprpAgent_ExisitingRera> Fill_Existing_detail(String RERA_RegNumber)
        {

            List<ClsprpAgent_ExisitingRera> userlist1 = new List<ClsprpAgent_ExisitingRera>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_ExistingAgent", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_RERA_RegNumber", RERA_RegNumber);


                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsprpAgent_ExisitingRera uobj = new ClsprpAgent_ExisitingRera();


                        uobj.AgentExistingRERA_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["AgentExistingRERA_ID"].ToString());
                        uobj.RERA_RegNumber = ds.Tables[0].Rows[i]["RERA_RegNumber"].ToString();
                        //uobj.RERAregistration_IssueDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["RERAregistration_IssueDate"].ToString());
                        //uobj.RERAregistration_ExpiryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["RERAregistration_ExpiryDate"].ToString());
                        uobj.Date_of_Issue = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date_of_Issue"].ToString());
                        uobj.Agent_FirstName = ds.Tables[0].Rows[i]["Agent_FirstName"].ToString();
                        uobj.Agent_MiddleName = ds.Tables[0].Rows[i]["Agent_MiddleName"].ToString(); 
                        uobj.Agent_LastName = ds.Tables[0].Rows[i]["Agent_LastName"].ToString();
                        uobj.Organization_Name = ds.Tables[0].Rows[i]["Organization_Name"].ToString(); 
                        //uobj.ProjectName = ds.Tables[0].Rows[i]["ProjectName"].ToString();
                        //uobj.RERARegistrationNumber = ds.Tables[0].Rows[i]["RERARegistrationNumber"].ToString();
                        //uobj.TypeofProject = ds.Tables[0].Rows[i]["TypeofProject"].ToString();
                        //uobj.DistrictName = ds.Tables[0].Rows[i]["DistrictName"].ToString();
                        //uobj.A_column = ds.Tables[0].Rows[i]["A_column"].ToString();
                        //uobj.B_column = ds.Tables[0].Rows[i]["B_column"].ToString();
                        //uobj.C_column = ds.Tables[0].Rows[i]["C_column"].ToString();
                        //uobj.IsActive = Convert.ToInt32(ds.Tables[0].Rows[i]["IsActive"].ToString());
                        //uobj.CreatedBy = ds.Tables[0].Rows[i]["CreatedBy"].ToString();

                        //uobj.ModifyBy = ds.Tables[0].Rows[i]["ModifyBy"].ToString();


                        userlist1.Add(uobj);

                    }

                    con.Close();
                    return userlist1;
                }
            }



        }

        public List<ClsprpAgent_ExisitingRera> Fill_Existing_detail_ByID(string RERA_registrationNumber, string stateNam, Int32 typeAgent, Int32 resetFlag, string UserID)
        {
            List<ClsprpAgent_ExisitingRera> numberlist = new List<ClsprpAgent_ExisitingRera>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_ExistingAgent_ByID", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_RERA_RegNumber", RERA_registrationNumber);
                    cmd.Parameters.AddWithValue("p_StateName", stateNam);
                    cmd.Parameters.AddWithValue("p_typeAgent", typeAgent);
                    cmd.Parameters.AddWithValue("p_ResetFlag", resetFlag);
                    cmd.Parameters.AddWithValue("p_UserID", UserID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsprpAgent_ExisitingRera uobj = new ClsprpAgent_ExisitingRera();

                        uobj.AgentExistingRERA_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["AgentExistingRERA_ID"].ToString());
                        uobj.RERA_RegNumber = ds.Tables[0].Rows[i]["RERA_RegNumber"].ToString();
                        uobj.Date_of_Issue = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date_of_Issue"].ToString());
                        uobj.Agent_FirstName = ds.Tables[0].Rows[i]["Agent_FirstName"].ToString();
                        uobj.Agent_MiddleName = ds.Tables[0].Rows[i]["Agent_MiddleName"].ToString();
                        uobj.Agent_LastName = ds.Tables[0].Rows[i]["Agent_LastName"].ToString();
                        uobj.Organization_Name = ds.Tables[0].Rows[i]["Organization_Name"].ToString();
                        uobj.EnableStatus = ds.Tables[0].Rows[i]["EnableStatus"].ToString();
                        uobj.FlagStatus = ds.Tables[0].Rows[i]["FlagStatus"].ToString();
                        uobj.MessageStatus = ds.Tables[0].Rows[i]["MessageStatus"].ToString();

                        numberlist.Add(uobj);
                    }
                    con.Close();
                    return numberlist;
                }
            }
        }

    }
}
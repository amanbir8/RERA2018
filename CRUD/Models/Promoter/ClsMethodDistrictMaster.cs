using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUD.Models.ComplaintExecution;
using MySql.Data.MySqlClient;

namespace CRUD.Models.Promoter
{
    public class ClsMethodDistrictMaster
    {
        public List<ClsPrp_DistrictMaster> dropdownlist_display1()
        {
            List<ClsPrp_DistrictMaster> userlist1 = new List<ClsPrp_DistrictMaster>();
            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from Rera_Tbl_DistrictMaster where isactive=1 order by districtname asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_DistrictMaster uobj = new ClsPrp_DistrictMaster();
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

        public List<ClsPrp_StateMaster> State_list()
        {
            List<ClsPrp_StateMaster> userlist1 = new List<ClsPrp_StateMaster>();
            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select State_Code, State_Name from tbl_RERA_Master_StateDetails where isactive=1 order by State_Name asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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

        public List<ClsPrp_StateMaster> State_listByCode(int stateid)
        {
            List<ClsPrp_StateMaster> statelist = new List<ClsPrp_StateMaster>();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select State_Code, State_Name from tbl_RERA_Master_StateDetails where State_Code='" + stateid + "' and isactive=1 order by State_Name asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_StateMaster uobj = new ClsPrp_StateMaster();
                        uobj.StateId = Convert.ToInt32(ds.Tables[0].Rows[i]["State_Code"].ToString());
                        uobj.StateName = ds.Tables[0].Rows[i]["State_Name"].ToString();

                        statelist.Add(uobj);
                    }
                    con.Close();
                    return statelist;
                }
            }
        }

        public List<ClsPrp_DistrictMaster> dropdownlist_display1(int stateid)
        {
            List<ClsPrp_DistrictMaster> userlist1 = new List<ClsPrp_DistrictMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from Rera_Tbl_DistrictMaster where State_ID='" + stateid + "' and isactive=1 order by districtname asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_DistrictMaster uobj = new ClsPrp_DistrictMaster();
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

        public List<ClsPrp_SubdivMaster> dropdownlist_diplaySubdiv(int Distid)
        {

            List<ClsPrp_SubdivMaster> userlist1 = new List<ClsPrp_SubdivMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_RERA_Master_SubDivisionDetails where District_ID='" + Distid + "' and isactive=1 and IsValidForProjectAgent in (1) order by SubDivision_Name asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_SubdivMaster uobj = new ClsPrp_SubdivMaster();
                        uobj.SubDivision_Code = Convert.ToInt32(ds.Tables[0].Rows[i]["SubDivision_Code"].ToString());
                        uobj.SubDivision_Name = ds.Tables[0].Rows[i]["SubDivision_Name"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }
            }
        }

        public List<ClsPrp_SubdivMaster> dropdownlist_diplaySubdiv()
        {

            List<ClsPrp_SubdivMaster> userlist1 = new List<ClsPrp_SubdivMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_RERA_Master_SubDivisionDetails where isactive=1 and IsValidForProjectAgent in (1) order by SubDivision_Name asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_SubdivMaster uobj = new ClsPrp_SubdivMaster();
                        uobj.SubDivision_Code = Convert.ToInt32(ds.Tables[0].Rows[i]["SubDivision_Code"].ToString());
                        uobj.SubDivision_Name = ds.Tables[0].Rows[i]["SubDivision_Name"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }
            }
        }

        public List<ClsPrp_SubdivMaster> dropdownlist_diplaySubdivForAgent()
        {

            List<ClsPrp_SubdivMaster> userlist1 = new List<ClsPrp_SubdivMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_RERA_Master_SubDivisionDetails where isactive=1 and IsValidForProjectAgent in (1,2) order by SubDivision_Name asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_SubdivMaster uobj = new ClsPrp_SubdivMaster();
                        uobj.SubDivision_Code = Convert.ToInt32(ds.Tables[0].Rows[i]["SubDivision_Code"].ToString());
                        uobj.SubDivision_Name = ds.Tables[0].Rows[i]["SubDivision_Name"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }
            }
        }

        public List<ClsPrp_SubdivMaster> dropdownlist_diplaySubdivForAgent(int Distid)
        {

            List<ClsPrp_SubdivMaster> userlist1 = new List<ClsPrp_SubdivMaster>();

            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_RERA_Master_SubDivisionDetails where District_ID='" + Distid + "' and isactive=1 and IsValidForProjectAgent in (1,2) order by SubDivision_Name asc;", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_SubdivMaster uobj = new ClsPrp_SubdivMaster();
                        uobj.SubDivision_Code = Convert.ToInt32(ds.Tables[0].Rows[i]["SubDivision_Code"].ToString());
                        uobj.SubDivision_Name = ds.Tables[0].Rows[i]["SubDivision_Name"].ToString();

                        userlist1.Add(uobj);

                    }
                    // objuser.districtMaster = userlist1;
                    con.Close();
                    return userlist1;
                }
            }
        }

        public string State_Name(int? SCode)
        {
            //List<ClsPrp_StateMaster> userlist1 = new List<ClsPrp_StateMaster>();
            string simpleValue = string.Empty;
            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select State_Name from tbl_RERA_Master_StateDetails where State_Code='" + SCode + "' and isactive=1 order by State_Name asc;", con))
                {
                    con.Open();
                    //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    //da.Fill(ds);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        simpleValue = dr[0].ToString();
                    }
                    con.Close();
                    return simpleValue;
                }
            }
        }

        public string District_Name(int? DistrictCode)
        {
            //List<ClsPrp_StateMaster> userlist1 = new List<ClsPrp_StateMaster>();
            string simpleValue = string.Empty;
            //Clsprp_Promoter objuser = new Clsprp_Promoter();
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("select districtname from Rera_Tbl_DistrictMaster where districtid='" + DistrictCode + "' and isactive=1 order by districtname asc;", con))
                {
                    con.Open();
                    //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    //da.Fill(ds);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        simpleValue = dr[0].ToString();
                    }

                    con.Close();
                    return simpleValue;
                }
            }
        }

        public string SubDivision_Name(int? SubDivisionCode)
        {
            string simpleValue = string.Empty;
            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select SubDivision_Name from tbl_rera_master_subdivisiondetails where SubDivision_Code='" + SubDivisionCode + "' and isactive=1 order by SubDivision_Name asc;", con))
                {
                    con.Open();                    
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            simpleValue = dr[0].ToString();
                        }
                    }
                    else
                    {
                        simpleValue = "Not Available";
                    }                    
                    con.Close();                    
                }
            }
            return simpleValue;
        }


        public List<ClsPrp_Master_HearingBenchDetails> dropdownlist_HearingBenchList()
        {
            List<ClsPrp_Master_HearingBenchDetails> userlist = new List<ClsPrp_Master_HearingBenchDetails>();

            DataTable dt = new DataTable();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();
            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Master_ComplaintPublicView_HearingBench", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    foreach (DataRow dr in dt.Rows)
                    {
                        userlist.Add(
                            new ClsPrp_Master_HearingBenchDetails
                            {
                                PreHearingBench_IndexID = Convert.ToInt32(dr["PreHearingBench_IndexID"]),
                                PreHearingBench_ID = Convert.ToInt32(dr["PreHearingBench_ID"]),
                                PreHearingBenchCode = Convert.ToInt32(dr["PreHearingBenchCode"]),
                                PreHearingBenchName = Convert.ToString(dr["PreHearingBenchName"]),
                                PreHearingType = Convert.ToString(dr["PreHearingType"]),
                                Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                                A_column = Convert.ToString(dr["A_column"]),
                                B_column = Convert.ToString(dr["B_column"]),
                                IsActive = Convert.ToInt32(dr["IsActive"]),
                                IsDraft = Convert.ToInt32(dr["IsDraft"]),
                                CreatedBy = Convert.ToString(dr["CreatedBy"]),
                                CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                                ModifyBy = Convert.ToString(dr["ModifyBy"]),
                                ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                            });
                    }
                    return userlist;
                }
            }
        }

    }
}
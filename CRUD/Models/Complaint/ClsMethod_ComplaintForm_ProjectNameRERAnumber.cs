using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintForm_ProjectNameRERAnumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ComplaintForm_ProjectNameRERAnumber> Get_ProjectAgentAllotteeNameByReraID(String RERAregistration_Number, String ReraNumberType)
        {
            List<ClsPrp_ComplaintForm_ProjectNameRERAnumber> userlist1 = new List<ClsPrp_ComplaintForm_ProjectNameRERAnumber>();

            if (ReraNumberType != null)
            {
                DataSet ds = new DataSet();
                string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
                MySqlConnection con = new MySqlConnection();

                using (con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectAgentAllotteeName_ByRERAnumber", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_RERAnumberRegistration", RERAregistration_Number);
                        cmd.Parameters.AddWithValue("p_ReraNumberType", ReraNumberType);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ClsPrp_ComplaintForm_ProjectNameRERAnumber uobj = new ClsPrp_ComplaintForm_ProjectNameRERAnumber();
                            uobj.ProjectName = ds.Tables[0].Rows[i]["ProjectName"].ToString();
                            userlist1.Add(uobj);
                        }

                        con.Close();
                        return userlist1;
                    }
                }
            }
            else
            {
                return userlist1;
            }
        }
    }
}
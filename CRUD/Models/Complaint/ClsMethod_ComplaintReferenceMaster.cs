using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintReferenceMaster
    {
        public List<ClsPrp_Complaint_ReferenceNumberMaster> FillDropdown_ComplaintReference_ByAppId(Int64 ComplaintProfile_ID, Int64 tempParm)
        {

            List<ClsPrp_Complaint_ReferenceNumberMaster> userlist1 = new List<ClsPrp_Complaint_ReferenceNumberMaster>();

            DataSet ds = new DataSet();
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            MySqlConnection con = new MySqlConnection();

            using (con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_RefereceMaster_ByAppId", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", ComplaintProfile_ID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsPrp_Complaint_ReferenceNumberMaster uobj = new ClsPrp_Complaint_ReferenceNumberMaster();
                        uobj.ComplaintRegistration_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["ComplaintRegistration_ID"].ToString());
                        uobj.Complaint_Name_ReferenceNumber = ds.Tables[0].Rows[i]["Complaint_Name_ReferenceNumber"].ToString();

                        userlist1.Add(uobj);

                    }

                    con.Close();
                    return userlist1;
                }
            }
        }        
    }
}
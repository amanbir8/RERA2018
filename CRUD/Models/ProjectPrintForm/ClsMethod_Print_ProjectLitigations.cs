using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ProjectPrint
{
    public class ClsMethod_Print_ProjectLitigations
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_PrmProject_Print_ProjectLitigations> Display_Project_Litigations(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_PrmProject_Print_ProjectLitigations> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectLitigations>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Litigations_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectLitigations
                       {
                           ProjectLitigations_IndexID = Convert.ToInt64(dr["ProjectLitigations_IndexID"]),
                           ProjectLitigations_ID = Convert.ToInt64(dr["ProjectLitigations_ID"]),
                           LitigationsRelated_ProjectRegistration_ID = Convert.ToInt64(dr["LitigationsRelated_ProjectRegistration_ID"]),
                           Case_Title = Convert.ToString(dr["Case_Title"]),
                           Case_Number = Convert.ToString(dr["Case_Number"]),
                           AuthorityForumName_CasePendingResolved = Convert.ToString(dr["AuthorityForumName_CasePendingResolved"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }
    }
}
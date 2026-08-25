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
    public class ClsMethod_Print_ProjectKhasraAreaDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }      

        public List<ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails> Display_Project_KhasraAreaDetails(Int64 ProjectRegistration_ID)
        {

            connection();
            List<ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_KhasraAreaDetails_ForPrint", con);
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
                       new ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails
                       {
                           ProjectKhasraArea_IndexID = Convert.ToInt64(dr["ProjectKhasraArea_IndexID"]),
                           ProjectKhasraArea_ID = Convert.ToInt64(dr["ProjectKhasraArea_ID"]),
                           ProjectKhasraAreaRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectKhasraAreaRelated_ProjectRegistration_ID"]),
                           KhasraNumber_ProposedLand_TobeDeveloped = Convert.ToString(dr["KhasraNumber_ProposedLand_TobeDeveloped"]),
                           Area_ProposedLand_EachKhasraNumber = Convert.ToDouble(dr["Area_ProposedLand_EachKhasraNumber"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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
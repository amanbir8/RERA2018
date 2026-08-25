using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUD.Models.PromoterProject;

namespace CRUD.Models.Master
{
    public class ClsMethod_master_BuildingTowerName
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Project_BuildingTowerBlock_Construction> Display_BuildingTowerBlock_Construction(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_BuildingTowerBlock_Construction> ProjectFivelist1 = new List<ClsPrp_Project_BuildingTowerBlock_Construction>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_BuildingTowerBlockName", con);
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
                       new ClsPrp_Project_BuildingTowerBlock_Construction
                       {
                           //ProjectConstruction_IndexID = Convert.ToInt64(dr["ProjectConstruction_IndexID"]),
                           ProjectConstruction_ID = Convert.ToInt64(dr["ProjectConstruction_ID"]),
                           //ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectConstructionRelated_ProjectRegistration_ID"]),
                           BuildingTowerBlock_Name = Convert.ToString(dr["BuildingTowerBlock_Name"]),

                       });
            }
            return ProjectFivelist1;
        }
    }
}
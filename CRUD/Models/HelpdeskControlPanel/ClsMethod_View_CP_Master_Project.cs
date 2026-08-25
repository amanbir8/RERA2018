using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsMethod_View_CP_Master_Project
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone> Display_CP_MasterProject_RegistrationZone_ByIDandUserRole(Int32 pRequestID, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone> CPuserList = new List<ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_Project_RegistrationAreaZone", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pUserName", pUserRole);
            cmd.Parameters.AddWithValue("pSearchFlag", pRequestID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPuserList.Add(
                    new ClsPrp_ControlPanel_View_Master_Project_RegistrationAreaZone
                    {
                        Zone_IndexID = Convert.ToInt32(dr["Zone_IndexID"]),
                        Zone_ID = Convert.ToInt32(dr["Zone_ID"]),
                        Zone_TitleCode = Convert.ToInt32(dr["Zone_TitleCode"]),
                        Zone_TitleName = Convert.ToString(dr["Zone_TitleName"]),
                        Zone_StateID = Convert.ToInt32(dr["Zone_StateID"]),
                        Mode = Convert.ToString(dr["Mode"]),
                        ActRegulationReference = Convert.ToString(dr["ActRegulationReference"]),
                        ResidentialPlotted_ChargesPerSquareYard = Convert.ToDecimal(dr["ResidentialPlotted_ChargesPerSquareYard"]),
                        GroupHousing_ChargesPerSquareYard = Convert.ToDecimal(dr["GroupHousing_ChargesPerSquareYard"]),
                        Commercial_ChargesPerSquareYard = Convert.ToDecimal(dr["Commercial_ChargesPerSquareYard"]),
                        Industrial_ChargesPerSquareYard = Convert.ToDecimal(dr["Industrial_ChargesPerSquareYard"]),
                        CommonArea_ChargesPerSquareYard = Convert.ToDecimal(dr["CommonArea_ChargesPerSquareYard"]),
                        ClubSchoolBuliding_ChargesPerSquareYard = Convert.ToDecimal(dr["ClubSchoolBuliding_ChargesPerSquareYard"]),
                        EWS_ChargesPerSquareYard = Convert.ToDecimal(dr["EWS_ChargesPerSquareYard"]),
                        A_ChargesPerSquareYard = Convert.ToDecimal(dr["A_ChargesPerSquareYard"]),
                        B_ChargesPerSquareYard = Convert.ToDecimal(dr["B_ChargesPerSquareYard"]),
                        Fee_ValidCode = Convert.ToInt32(dr["Fee_ValidCode"]),
                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return CPuserList;
        }
    }
}
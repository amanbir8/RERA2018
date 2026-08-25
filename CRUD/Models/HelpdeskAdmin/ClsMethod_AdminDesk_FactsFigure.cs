using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsMethod_AdminDesk_FactsFigure
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_AdminDesk_FactsFigureDetails(ClsPrp_AdminDesk_FactsFigure smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_FactFiguresDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_FactsFigure_IndexID", smodel.FactsFigure_IndexID);
            cmd.Parameters.AddWithValue("p_FactsFigure_ID", smodel.FactsFigure_ID);
            cmd.Parameters.AddWithValue("p_FactsFigure_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_Number_RegisteredProjects", smodel.Number_RegisteredProjects);
            cmd.Parameters.AddWithValue("p_Number_RegisteredAgents", smodel.Number_RegisteredAgents);
            cmd.Parameters.AddWithValue("p_Number_DisposedComplaints", smodel.Number_DisposedComplaints);
            cmd.Parameters.AddWithValue("p_Number_PendingProjects", smodel.Number_PendingProjects);

            cmd.Parameters.AddWithValue("p_Title_RegisteredProjects", "Registered Projects");
            cmd.Parameters.AddWithValue("p_Title_RegisteredAgents", "Registered Real Estate Agents");
            cmd.Parameters.AddWithValue("p_Title_DisposedComplaints", "Disposed Complaints");
            cmd.Parameters.AddWithValue("p_Title_PendingProjects", "Pending Projects");

            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_RegisteredProjects", "ਰਜਿਸਟਰਡ ਪ੍ਰੋਜੈਕਟ");
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_RegisteredAgents", "ਰਜਿਸਟਰਡ ਰੀਅਲ ਅਸਟੇਟ ਏਜੰਟ");
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_DisposedComplaints", "ਨਿੱਪਟਾਰਾ ਸ਼ਿਕਾਇਤਾਂ");
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_PendingProjects", "ਬਕਾਇਆ ਪ੍ਰੋਜੈਕਟ");

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_AdminDesk_FactsFigureDetails(ClsPrp_AdminDesk_FactsFigure smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_FactFiguresDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_FactsFigure_IndexID", smodel.FactsFigure_IndexID);
            cmd.Parameters.AddWithValue("p_FactsFigure_ID", smodel.FactsFigure_ID);
            cmd.Parameters.AddWithValue("p_FactsFigure_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_Number_RegisteredProjects", smodel.Number_RegisteredProjects);
            cmd.Parameters.AddWithValue("p_Number_RegisteredAgents", smodel.Number_RegisteredAgents);
            cmd.Parameters.AddWithValue("p_Number_DisposedComplaints", smodel.Number_DisposedComplaints);
            cmd.Parameters.AddWithValue("p_Number_PendingProjects", smodel.Number_PendingProjects);

            cmd.Parameters.AddWithValue("p_Title_RegisteredProjects", "Registered Projects");
            cmd.Parameters.AddWithValue("p_Title_RegisteredAgents", "Registered Real Estate Agents");
            cmd.Parameters.AddWithValue("p_Title_DisposedComplaints", "Disposed Complaints");
            cmd.Parameters.AddWithValue("p_Title_PendingProjects", "Pending Projects");

            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_RegisteredProjects", "ਰਜਿਸਟਰਡ ਪ੍ਰੋਜੈਕਟ");
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_RegisteredAgents", "ਰਜਿਸਟਰਡ ਰੀਅਲ ਅਸਟੇਟ ਏਜੰਟ");
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_DisposedComplaints", "ਨਿੱਪਟਾਰਾ ਸ਼ਿਕਾਇਤਾਂ");
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Title_PendingProjects", "ਬਕਾਇਆ ਪ੍ਰੋਜੈਕਟ");

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AdminDesk_FactsFigure> Display_AdminDesk_FactsFigureDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_FactsFigure> AdminDeskparameters = new List<ClsPrp_AdminDesk_FactsFigure>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_FactFigures", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_FactsFigure
                       {
                           FactsFigure_IndexID = Convert.ToInt64(dr["FactsFigure_IndexID"]),
                           FactsFigure_ID = Convert.ToInt64(dr["FactsFigure_ID"]),
                           FactsFigure_LanguageFlag = Convert.ToString(dr["FactsFigure_LanguageFlag"]),

                           Number_RegisteredProjects = Convert.ToInt32(dr["Number_RegisteredProjects"]),
                           Number_RegisteredAgents = Convert.ToInt32(dr["Number_RegisteredAgents"]),
                           Number_DisposedComplaints = Convert.ToInt32(dr["Number_DisposedComplaints"]),
                           Number_PendingProjects = Convert.ToInt32(dr["Number_PendingProjects"]),

                           Title_RegisteredProjects = Convert.ToString(dr["Title_RegisteredProjects"]),
                           Title_RegisteredAgents = Convert.ToString(dr["Title_RegisteredAgents"]),
                           Title_DisposedComplaints = Convert.ToString(dr["Title_DisposedComplaints"]),
                           Title_PendingProjects = Convert.ToString(dr["Title_PendingProjects"]),
                           CulturePunjabi_Title_RegisteredProjects = Convert.ToString(dr["CulturePunjabi_Title_RegisteredProjects"]),
                           CulturePunjabi_Title_RegisteredAgents = Convert.ToString(dr["CulturePunjabi_Title_RegisteredAgents"]),
                           CulturePunjabi_Title_DisposedComplaints = Convert.ToString(dr["CulturePunjabi_Title_DisposedComplaints"]),
                           CulturePunjabi_Title_PendingProjects = Convert.ToString(dr["CulturePunjabi_Title_PendingProjects"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_FactsFigure> Display_AdminDesk_FactsFigureDetailsByID(Int64 IndexID,Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_FactsFigure> AdminDeskparameters = new List<ClsPrp_AdminDesk_FactsFigure>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_FactFiguresByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_FactsFigure_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_FactsFigure_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_FactsFigure
                       {
                           FactsFigure_IndexID = Convert.ToInt64(dr["FactsFigure_IndexID"]),
                           FactsFigure_ID = Convert.ToInt64(dr["FactsFigure_ID"]),
                           FactsFigure_LanguageFlag = Convert.ToString(dr["FactsFigure_LanguageFlag"]),

                           Number_RegisteredProjects = Convert.ToInt32(dr["Number_RegisteredProjects"]),
                           Number_RegisteredAgents = Convert.ToInt32(dr["Number_RegisteredAgents"]),
                           Number_DisposedComplaints = Convert.ToInt32(dr["Number_DisposedComplaints"]),
                           Number_PendingProjects = Convert.ToInt32(dr["Number_PendingProjects"]),

                           Title_RegisteredProjects = Convert.ToString(dr["Title_RegisteredProjects"]),
                           Title_RegisteredAgents = Convert.ToString(dr["Title_RegisteredAgents"]),
                           Title_DisposedComplaints = Convert.ToString(dr["Title_DisposedComplaints"]),
                           Title_PendingProjects = Convert.ToString(dr["Title_PendingProjects"]),
                           CulturePunjabi_Title_RegisteredProjects = Convert.ToString(dr["CulturePunjabi_Title_RegisteredProjects"]),
                           CulturePunjabi_Title_RegisteredAgents = Convert.ToString(dr["CulturePunjabi_Title_RegisteredAgents"]),
                           CulturePunjabi_Title_DisposedComplaints = Convert.ToString(dr["CulturePunjabi_Title_DisposedComplaints"]),
                           CulturePunjabi_Title_PendingProjects = Convert.ToString(dr["CulturePunjabi_Title_PendingProjects"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Delete_AdminDesk_FactsFigureDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_FactFiguresByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_FactsFigure_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_FactsFigure_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
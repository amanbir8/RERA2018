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
    public class ClsMethod_AdminDesk_SpotLight
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_AdminDesk_SpotLightDetails(ClsPrp_AdminDesk_SpotLight smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_SpotLightDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_SpotLight_IndexID", smodel.SpotLight_IndexID);
            cmd.Parameters.AddWithValue("p_SpotLight_ID", smodel.SpotLight_ID);
            cmd.Parameters.AddWithValue("p_SpotLight_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_SpotLight_PriorityFlag", smodel.SpotLight_PriorityFlag); //smodel.SpotLight_PriorityFlag == null ? 0 : smodel.SpotLight_PriorityFlag);
            cmd.Parameters.AddWithValue("p_SpotLight_IssueDate", smodel.SpotLight_IssueDate == null ? dtvalue : smodel.SpotLight_IssueDate);
            cmd.Parameters.AddWithValue("p_SpotLight_ReferenceNumber", String.IsNullOrEmpty(smodel.SpotLight_ReferenceNumber) ? "" : smodel.SpotLight_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_SpotLight_Category", String.IsNullOrEmpty(smodel.SpotLight_Category) ? "" : smodel.SpotLight_Category);
            cmd.Parameters.AddWithValue("p_SpotLight_Title", String.IsNullOrEmpty(smodel.SpotLight_Title) ? "" : smodel.SpotLight_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_SpotLight_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_SpotLight_Category) ? "" : smodel.CulturePunjabi_SpotLight_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_SpotLight_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_SpotLight_Title) ? "" : smodel.CulturePunjabi_SpotLight_Title);

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

        public bool Update_AdminDesk_SpotLightDetails(ClsPrp_AdminDesk_SpotLight smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_SpotLightDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_SpotLight_IndexID", smodel.SpotLight_IndexID);
            cmd.Parameters.AddWithValue("p_SpotLight_ID", smodel.SpotLight_ID);
            cmd.Parameters.AddWithValue("p_SpotLight_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_SpotLight_PriorityFlag", smodel.SpotLight_PriorityFlag); //smodel.SpotLight_PriorityFlag == null ? 0 : smodel.SpotLight_PriorityFlag);
            cmd.Parameters.AddWithValue("p_SpotLight_IssueDate", smodel.SpotLight_IssueDate == null ? dtvalue : smodel.SpotLight_IssueDate);
            cmd.Parameters.AddWithValue("p_SpotLight_ReferenceNumber", String.IsNullOrEmpty(smodel.SpotLight_ReferenceNumber) ? "" : smodel.SpotLight_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_SpotLight_Category", String.IsNullOrEmpty(smodel.SpotLight_Category) ? "" : smodel.SpotLight_Category);
            cmd.Parameters.AddWithValue("p_SpotLight_Title", String.IsNullOrEmpty(smodel.SpotLight_Title) ? "" : smodel.SpotLight_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_SpotLight_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_SpotLight_Category) ? "" : smodel.CulturePunjabi_SpotLight_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_SpotLight_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_SpotLight_Title) ? "" : smodel.CulturePunjabi_SpotLight_Title);

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

        public List<ClsPrp_AdminDesk_SpotLight> Display_AdminDesk_SpotLightDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_SpotLight> AdminDeskparameters = new List<ClsPrp_AdminDesk_SpotLight>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_SpotLight", con);
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
                       new ClsPrp_AdminDesk_SpotLight
                       {
                           SpotLight_IndexID = Convert.ToInt64(dr["SpotLight_IndexID"]),
                           SpotLight_ID = Convert.ToInt64(dr["SpotLight_ID"]),
                           SpotLight_LanguageFlag = Convert.ToString(dr["SpotLight_LanguageFlag"]),

                           SpotLight_PriorityFlag = Convert.ToInt32(dr["SpotLight_PriorityFlag"]),
                           SpotLight_IssueDate = Convert.ToDateTime(dr["SpotLight_IssueDate"]),
                           SpotLight_ReferenceNumber = Convert.ToString(dr["SpotLight_ReferenceNumber"]),
                           SpotLight_Category = Convert.ToString(dr["SpotLight_Category"]),
                           SpotLight_Title = Convert.ToString(dr["SpotLight_Title"]),
                           CulturePunjabi_SpotLight_Category = Convert.ToString(dr["CulturePunjabi_SpotLight_Category"]),
                           CulturePunjabi_SpotLight_Title = Convert.ToString(dr["CulturePunjabi_SpotLight_Title"]),

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

        public List<ClsPrp_AdminDesk_SpotLight> Display_AdminDesk_SpotLightDetailsByID(Int64 IndexID,Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_SpotLight> AdminDeskparameters = new List<ClsPrp_AdminDesk_SpotLight>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_SpotLightByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_SpotLight_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_SpotLight_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_SpotLight
                       {
                           SpotLight_IndexID = Convert.ToInt64(dr["SpotLight_IndexID"]),
                           SpotLight_ID = Convert.ToInt64(dr["SpotLight_ID"]),
                           SpotLight_LanguageFlag = Convert.ToString(dr["SpotLight_LanguageFlag"]),

                           SpotLight_PriorityFlag = Convert.ToInt32(dr["SpotLight_PriorityFlag"]),
                           SpotLight_IssueDate = Convert.ToDateTime(dr["SpotLight_IssueDate"]),
                           SpotLight_ReferenceNumber = Convert.ToString(dr["SpotLight_ReferenceNumber"]),
                           SpotLight_Category = Convert.ToString(dr["SpotLight_Category"]),
                           SpotLight_Title = Convert.ToString(dr["SpotLight_Title"]),
                           CulturePunjabi_SpotLight_Category = Convert.ToString(dr["CulturePunjabi_SpotLight_Category"]),
                           CulturePunjabi_SpotLight_Title = Convert.ToString(dr["CulturePunjabi_SpotLight_Title"]),

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

        public bool Delete_AdminDesk_SpotLightDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_SpotLightByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_SpotLight_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_SpotLight_ID", KeyID);

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
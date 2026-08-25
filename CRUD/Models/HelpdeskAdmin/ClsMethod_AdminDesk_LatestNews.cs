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
    public class ClsMethod_AdminDesk_LatestNews
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_AdminDesk_latestnewsDetails(ClsPrp_AdminDesk_LatestNews smodel, string File_BasicUrl, string LatestNews_Url, string LatestNews_ExtraUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_latestnews", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_LatestNews_IndexID", smodel.LatestNews_IndexID);
            cmd.Parameters.AddWithValue("p_LatestNews_ID", smodel.LatestNews_ID);

            cmd.Parameters.AddWithValue("p_LatestNews_LanguageFlag", "PB");
            cmd.Parameters.AddWithValue("p_LatestNews_PriorityFlag",smodel.LatestNews_PriorityFlag);
            cmd.Parameters.AddWithValue("p_LatestNews_IssueDate", smodel.LatestNews_IssueDate == null ? dtvalue : smodel.LatestNews_IssueDate);
            cmd.Parameters.AddWithValue("p_LatestNews_ReferenceNumber", String.IsNullOrEmpty(smodel.LatestNews_ReferenceNumber) ? "" : smodel.LatestNews_ReferenceNumber);

            cmd.Parameters.AddWithValue("p_LatestNews_Category", String.IsNullOrEmpty(smodel.LatestNews_Category) ? "" : smodel.LatestNews_Category);
            cmd.Parameters.AddWithValue("p_LatestNews_Title", String.IsNullOrEmpty(smodel.LatestNews_Title) ? "" : smodel.LatestNews_Title);
            cmd.Parameters.AddWithValue("p_LatestNews_Description", String.IsNullOrEmpty(smodel.LatestNews_Description) ? "" : smodel.LatestNews_Description);
            cmd.Parameters.AddWithValue("p_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.LatestNews_RelatedTo_IfAny) ? "" : smodel.LatestNews_RelatedTo_IfAny);
                         
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Category) ? "" : smodel.CulturePunjabi_LatestNews_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Title) ? "" : smodel.CulturePunjabi_LatestNews_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Description", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Description) ? "" : smodel.CulturePunjabi_LatestNews_Description);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny) ? "" : smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny);
 
            cmd.Parameters.AddWithValue("p_IsHyperlinkorFileDirectoryPath", smodel.IsHyperlinkorFileDirectoryPath); 
            cmd.Parameters.AddWithValue("p_LatestNews_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_LatestNews_Url", String.IsNullOrEmpty(LatestNews_Url) ? "" : LatestNews_Url);
            cmd.Parameters.AddWithValue("p_LatestNews_ExtraUrl", String.IsNullOrEmpty(LatestNews_ExtraUrl) ? "" : LatestNews_ExtraUrl);
             
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

        public bool Update_AdminDesk_latestnewsDetails(ClsPrp_AdminDesk_LatestNews smodel, string File_BasicUrl, string LatestNews_Url, string LatestNews_ExtraUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_latestnews", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_LatestNews_IndexID", smodel.LatestNews_IndexID);
            cmd.Parameters.AddWithValue("p_LatestNews_ID", smodel.LatestNews_ID);

            cmd.Parameters.AddWithValue("p_LatestNews_LanguageFlag", "PB");
            cmd.Parameters.AddWithValue("p_LatestNews_PriorityFlag", smodel.LatestNews_PriorityFlag);
            cmd.Parameters.AddWithValue("p_LatestNews_IssueDate", smodel.LatestNews_IssueDate == null ? dtvalue : smodel.LatestNews_IssueDate);
            cmd.Parameters.AddWithValue("p_LatestNews_ReferenceNumber", String.IsNullOrEmpty(smodel.LatestNews_ReferenceNumber) ? "" : smodel.LatestNews_ReferenceNumber);

            cmd.Parameters.AddWithValue("p_LatestNews_Category", String.IsNullOrEmpty(smodel.LatestNews_Category) ? "" : smodel.LatestNews_Category);
            cmd.Parameters.AddWithValue("p_LatestNews_Title", String.IsNullOrEmpty(smodel.LatestNews_Title) ? "" : smodel.LatestNews_Title);
            cmd.Parameters.AddWithValue("p_LatestNews_Description", String.IsNullOrEmpty(smodel.LatestNews_Description) ? "" : smodel.LatestNews_Description);
            cmd.Parameters.AddWithValue("p_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.LatestNews_RelatedTo_IfAny) ? "" : smodel.LatestNews_RelatedTo_IfAny);

            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Category) ? "" : smodel.CulturePunjabi_LatestNews_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Title) ? "" : smodel.CulturePunjabi_LatestNews_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Description", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Description) ? "" : smodel.CulturePunjabi_LatestNews_Description);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny) ? "" : smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny);

            cmd.Parameters.AddWithValue("p_IsHyperlinkorFileDirectoryPath", smodel.IsHyperlinkorFileDirectoryPath);
            cmd.Parameters.AddWithValue("p_LatestNews_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_LatestNews_Url", String.IsNullOrEmpty(LatestNews_Url) ? "" : LatestNews_Url);
            cmd.Parameters.AddWithValue("p_LatestNews_ExtraUrl", String.IsNullOrEmpty(LatestNews_ExtraUrl) ? "" : LatestNews_ExtraUrl);

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

        public bool Add_AdminDesk_latestnewsByLinkDetails(ClsPrp_AdminDesk_LatestNews smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_latestnews", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_LatestNews_IndexID", smodel.LatestNews_IndexID);
            cmd.Parameters.AddWithValue("p_LatestNews_ID", smodel.LatestNews_ID);

            cmd.Parameters.AddWithValue("p_LatestNews_LanguageFlag", "PB");
            cmd.Parameters.AddWithValue("p_LatestNews_PriorityFlag", smodel.LatestNews_PriorityFlag);
            cmd.Parameters.AddWithValue("p_LatestNews_IssueDate", smodel.LatestNews_IssueDate == null ? dtvalue : smodel.LatestNews_IssueDate);
            cmd.Parameters.AddWithValue("p_LatestNews_ReferenceNumber", String.IsNullOrEmpty(smodel.LatestNews_ReferenceNumber) ? "" : smodel.LatestNews_ReferenceNumber);

            cmd.Parameters.AddWithValue("p_LatestNews_Category", String.IsNullOrEmpty(smodel.LatestNews_Category) ? "" : smodel.LatestNews_Category);
            cmd.Parameters.AddWithValue("p_LatestNews_Title", String.IsNullOrEmpty(smodel.LatestNews_Title) ? "" : smodel.LatestNews_Title);
            cmd.Parameters.AddWithValue("p_LatestNews_Description", String.IsNullOrEmpty(smodel.LatestNews_Description) ? "" : smodel.LatestNews_Description);
            cmd.Parameters.AddWithValue("p_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.LatestNews_RelatedTo_IfAny) ? "" : smodel.LatestNews_RelatedTo_IfAny);

            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Category) ? "" : smodel.CulturePunjabi_LatestNews_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Title) ? "" : smodel.CulturePunjabi_LatestNews_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Description", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Description) ? "" : smodel.CulturePunjabi_LatestNews_Description);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny) ? "" : smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny);

            cmd.Parameters.AddWithValue("p_IsHyperlinkorFileDirectoryPath", smodel.IsHyperlinkorFileDirectoryPath);
            cmd.Parameters.AddWithValue("p_LatestNews_BaseUrl", String.IsNullOrEmpty(smodel.LatestNews_BaseUrl) ? "" : smodel.LatestNews_BaseUrl);
            cmd.Parameters.AddWithValue("p_LatestNews_Url", String.IsNullOrEmpty(smodel.LatestNews_Url) ? "" : smodel.LatestNews_Url);
            cmd.Parameters.AddWithValue("p_LatestNews_ExtraUrl", String.IsNullOrEmpty(smodel.LatestNews_ExtraUrl) ? "" : smodel.LatestNews_ExtraUrl);

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

        public bool Update_AdminDesk_latestnewsByLinkDetails(ClsPrp_AdminDesk_LatestNews smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_latestnews", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_LatestNews_IndexID", smodel.LatestNews_IndexID);
            cmd.Parameters.AddWithValue("p_LatestNews_ID", smodel.LatestNews_ID);

            cmd.Parameters.AddWithValue("p_LatestNews_LanguageFlag", "PB");
            cmd.Parameters.AddWithValue("p_LatestNews_PriorityFlag", smodel.LatestNews_PriorityFlag);
            cmd.Parameters.AddWithValue("p_LatestNews_IssueDate", smodel.LatestNews_IssueDate == null ? dtvalue : smodel.LatestNews_IssueDate);
            cmd.Parameters.AddWithValue("p_LatestNews_ReferenceNumber", String.IsNullOrEmpty(smodel.LatestNews_ReferenceNumber) ? "" : smodel.LatestNews_ReferenceNumber);

            cmd.Parameters.AddWithValue("p_LatestNews_Category", String.IsNullOrEmpty(smodel.LatestNews_Category) ? "" : smodel.LatestNews_Category);
            cmd.Parameters.AddWithValue("p_LatestNews_Title", String.IsNullOrEmpty(smodel.LatestNews_Title) ? "" : smodel.LatestNews_Title);
            cmd.Parameters.AddWithValue("p_LatestNews_Description", String.IsNullOrEmpty(smodel.LatestNews_Description) ? "" : smodel.LatestNews_Description);
            cmd.Parameters.AddWithValue("p_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.LatestNews_RelatedTo_IfAny) ? "" : smodel.LatestNews_RelatedTo_IfAny);

            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Category) ? "" : smodel.CulturePunjabi_LatestNews_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Title) ? "" : smodel.CulturePunjabi_LatestNews_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_Description", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_Description) ? "" : smodel.CulturePunjabi_LatestNews_Description);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_LatestNews_RelatedTo_IfAny", String.IsNullOrEmpty(smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny) ? "" : smodel.CulturePunjabi_LatestNews_RelatedTo_IfAny);

            cmd.Parameters.AddWithValue("p_IsHyperlinkorFileDirectoryPath", smodel.IsHyperlinkorFileDirectoryPath);
            cmd.Parameters.AddWithValue("p_LatestNews_BaseUrl", String.IsNullOrEmpty(smodel.LatestNews_BaseUrl) ? "" : smodel.LatestNews_BaseUrl);
            cmd.Parameters.AddWithValue("p_LatestNews_Url", String.IsNullOrEmpty(smodel.LatestNews_Url) ? "" : smodel.LatestNews_Url);
            cmd.Parameters.AddWithValue("p_LatestNews_ExtraUrl", String.IsNullOrEmpty(smodel.LatestNews_ExtraUrl) ? "" : smodel.LatestNews_ExtraUrl);

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

        public List<ClsPrp_AdminDesk_LatestNews> Display_AdminDesk_latestnewsDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_LatestNews> AdminDeskparameters = new List<ClsPrp_AdminDesk_LatestNews>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_latestnews", con);
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
                       new ClsPrp_AdminDesk_LatestNews
                       {
                           LatestNews_IndexID = Convert.ToInt64(dr["LatestNews_IndexID"]),
                           LatestNews_ID = Convert.ToInt64(dr["LatestNews_ID"]),

                           LatestNews_LanguageFlag = Convert.ToString(dr["LatestNews_LanguageFlag"]),
                           LatestNews_PriorityFlag = Convert.ToInt32(dr["LatestNews_PriorityFlag"]),
                           LatestNews_IssueDate = Convert.ToDateTime(dr["LatestNews_IssueDate"]),
                           LatestNews_ReferenceNumber = Convert.ToString(dr["LatestNews_ReferenceNumber"]),

                           LatestNews_Category = Convert.ToString(dr["LatestNews_Category"]),
                           LatestNews_Title = Convert.ToString(dr["LatestNews_Title"]),
                           LatestNews_Description = Convert.ToString(dr["LatestNews_Description"]),
                           LatestNews_RelatedTo_IfAny = Convert.ToString(dr["LatestNews_RelatedTo_IfAny"]),

                           CulturePunjabi_LatestNews_Category = Convert.ToString(dr["CulturePunjabi_LatestNews_Category"]),
                           CulturePunjabi_LatestNews_Title = Convert.ToString(dr["CulturePunjabi_LatestNews_Title"]),
                           CulturePunjabi_LatestNews_Description = Convert.ToString(dr["CulturePunjabi_LatestNews_Description"]),
                           CulturePunjabi_LatestNews_RelatedTo_IfAny = Convert.ToString(dr["CulturePunjabi_LatestNews_RelatedTo_IfAny"]),

                           IsHyperlinkorFileDirectoryPath = Convert.ToInt32(dr["IsHyperlinkorFileDirectoryPath"]),
                           LatestNews_BaseUrl = Convert.ToString(dr["LatestNews_BaseUrl"]),
                           LatestNews_Url = Convert.ToString(dr["LatestNews_Url"]),
                           LatestNews_ExtraUrl = Convert.ToString(dr["LatestNews_ExtraUrl"]),

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

        public List<ClsPrp_AdminDesk_LatestNews> Display_AdminDesk_latestnewsDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_LatestNews> AdminDeskparameters = new List<ClsPrp_AdminDesk_LatestNews>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_latestnewsByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_LatestNews_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_LatestNews_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_LatestNews
                       {
                           LatestNews_IndexID = Convert.ToInt64(dr["LatestNews_IndexID"]),
                           LatestNews_ID = Convert.ToInt64(dr["LatestNews_ID"]),

                           LatestNews_LanguageFlag = Convert.ToString(dr["LatestNews_LanguageFlag"]),
                           LatestNews_PriorityFlag = Convert.ToInt32(dr["LatestNews_PriorityFlag"]),
                           LatestNews_IssueDate = Convert.ToDateTime(dr["LatestNews_IssueDate"]),
                           LatestNews_ReferenceNumber = Convert.ToString(dr["LatestNews_ReferenceNumber"]),

                           LatestNews_Category = Convert.ToString(dr["LatestNews_Category"]),
                           LatestNews_Title = Convert.ToString(dr["LatestNews_Title"]),
                           LatestNews_Description = Convert.ToString(dr["LatestNews_Description"]),
                           LatestNews_RelatedTo_IfAny = Convert.ToString(dr["LatestNews_RelatedTo_IfAny"]),

                           CulturePunjabi_LatestNews_Category = Convert.ToString(dr["CulturePunjabi_LatestNews_Category"]),
                           CulturePunjabi_LatestNews_Title = Convert.ToString(dr["CulturePunjabi_LatestNews_Title"]),
                           CulturePunjabi_LatestNews_Description = Convert.ToString(dr["CulturePunjabi_LatestNews_Description"]),
                           CulturePunjabi_LatestNews_RelatedTo_IfAny = Convert.ToString(dr["CulturePunjabi_LatestNews_RelatedTo_IfAny"]),

                           IsHyperlinkorFileDirectoryPath = Convert.ToInt32(dr["IsHyperlinkorFileDirectoryPath"]),
                           LatestNews_BaseUrl = Convert.ToString(dr["LatestNews_BaseUrl"]),
                           LatestNews_Url = Convert.ToString(dr["LatestNews_Url"]),
                           LatestNews_ExtraUrl = Convert.ToString(dr["LatestNews_ExtraUrl"]),

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

        public bool Delete_AdminDesk_latestnewsDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_latestnewsIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_LatestNews_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_LatestNews_ID", KeyID);

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
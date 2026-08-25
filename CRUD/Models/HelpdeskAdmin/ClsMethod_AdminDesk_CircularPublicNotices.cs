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
    public class ClsMethod_AdminDesk_CircularPublicNotices
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }


        #region CircularPublicNotices

        public bool Add_AdminDesk_CircularPublicNoticesDetails(ClsPrp_AdminDesk_CircularPublicNotice smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_CircularPublicNoticeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", smodel.CircularPublicNotice_IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", smodel.CircularPublicNotice_ID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_Circular_Number", String.IsNullOrEmpty(smodel.Circular_Number) ? "" : smodel.Circular_Number);
            cmd.Parameters.AddWithValue("p_Circular_IssueDate", smodel.Circular_IssueDate == null ? dtvalue : smodel.Circular_IssueDate);
            cmd.Parameters.AddWithValue("p_Circular_Category", String.IsNullOrEmpty(smodel.Circular_Category) ? "" : smodel.Circular_Category);
            cmd.Parameters.AddWithValue("p_Circular_Title", String.IsNullOrEmpty(smodel.Circular_Title) ? "" : smodel.Circular_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Category) ? "" : smodel.CulturePunjabi_Circular_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Title) ? "" : smodel.CulturePunjabi_Circular_Title);

            cmd.Parameters.AddWithValue("p_Circular_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_Circular_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_Circular_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_Circular_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

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

        public bool Update_AdminDesk_CircularPublicNoticesDetails(ClsPrp_AdminDesk_CircularPublicNotice smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_CircularPublicNoticeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", smodel.CircularPublicNotice_IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", smodel.CircularPublicNotice_ID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_Circular_Number", String.IsNullOrEmpty(smodel.Circular_Number) ? "" : smodel.Circular_Number);
            cmd.Parameters.AddWithValue("p_Circular_IssueDate", smodel.Circular_IssueDate == null ? dtvalue : smodel.Circular_IssueDate);
            cmd.Parameters.AddWithValue("p_Circular_Category", String.IsNullOrEmpty(smodel.Circular_Category) ? "" : smodel.Circular_Category);
            cmd.Parameters.AddWithValue("p_Circular_Title", String.IsNullOrEmpty(smodel.Circular_Title) ? "" : smodel.Circular_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Category) ? "" : smodel.CulturePunjabi_Circular_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Title) ? "" : smodel.CulturePunjabi_Circular_Title);

            cmd.Parameters.AddWithValue("p_Circular_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_Circular_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_Circular_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_Circular_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

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

        public List<ClsPrp_AdminDesk_CircularPublicNotice> Display_AdminDesk_CircularPublicNoticesDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_CircularPublicNotice> AdminDeskparameters = new List<ClsPrp_AdminDesk_CircularPublicNotice>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_CircularPublicNotice", con);
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
                       new ClsPrp_AdminDesk_CircularPublicNotice
                       {
                           CircularPublicNotice_IndexID = Convert.ToInt64(dr["CircularPublicNotice_IndexID"]),
                           CircularPublicNotice_ID = Convert.ToInt64(dr["CircularPublicNotice_ID"]),
                           CircularPublicNotice_LanguageFlag = Convert.ToString(dr["CircularPublicNotice_LanguageFlag"]),

                           Circular_Number = Convert.ToString(dr["Circular_Number"]),
                           Circular_IssueDate = Convert.ToDateTime(dr["Circular_IssueDate"]),
                           Circular_Category = Convert.ToString(dr["Circular_Category"]),
                           Circular_Title = Convert.ToString(dr["Circular_Title"]),
                           CulturePunjabi_Circular_Category = Convert.ToString(dr["CulturePunjabi_Circular_Category"]),
                           CulturePunjabi_Circular_Title = Convert.ToString(dr["CulturePunjabi_Circular_Title"]),

                           Circular_BaseUrl = Convert.ToString(dr["Circular_BaseUrl"]),
                           Circular_FilePath = Convert.ToString(dr["Circular_FilePath"]),
                           Circular_FileName = Convert.ToString(dr["Circular_FileName"]),
                           Circular_FileType = Convert.ToString(dr["Circular_FileType"]),

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

        public List<ClsPrp_AdminDesk_CircularPublicNotice> Display_AdminDesk_CircularPublicNoticesDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_CircularPublicNotice> AdminDeskparameters = new List<ClsPrp_AdminDesk_CircularPublicNotice>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_CircularPublicNoticeByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_CircularPublicNotice
                       {
                           CircularPublicNotice_IndexID = Convert.ToInt64(dr["CircularPublicNotice_IndexID"]),
                           CircularPublicNotice_ID = Convert.ToInt64(dr["CircularPublicNotice_ID"]),
                           CircularPublicNotice_LanguageFlag = Convert.ToString(dr["CircularPublicNotice_LanguageFlag"]),

                           Circular_Number = Convert.ToString(dr["Circular_Number"]),
                           Circular_IssueDate = Convert.ToDateTime(dr["Circular_IssueDate"]),
                           Circular_Category = Convert.ToString(dr["Circular_Category"]),
                           Circular_Title = Convert.ToString(dr["Circular_Title"]),
                           CulturePunjabi_Circular_Category = Convert.ToString(dr["CulturePunjabi_Circular_Category"]),
                           CulturePunjabi_Circular_Title = Convert.ToString(dr["CulturePunjabi_Circular_Title"]),

                           Circular_BaseUrl = Convert.ToString(dr["Circular_BaseUrl"]),
                           Circular_FilePath = Convert.ToString(dr["Circular_FilePath"]),
                           Circular_FileName = Convert.ToString(dr["Circular_FileName"]),
                           Circular_FileType = Convert.ToString(dr["Circular_FileType"]),

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

        public bool Delete_AdminDesk_CircularPublicNoticesDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_CircularPublicNoticeByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        #endregion



        #region REAT

        public List<ClsPrp_AdminDesk_ReatCircularPublicNotice> Display_AdminDesk_ReatCircularPublicNoticesDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_ReatCircularPublicNotice> AdminDeskparameters = new List<ClsPrp_AdminDesk_ReatCircularPublicNotice>();

            MySqlCommand cmd = new MySqlCommand("Display_Reat_AdminDesk_CircularPublicNotice", con);
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
                       new ClsPrp_AdminDesk_ReatCircularPublicNotice
                       {
                           CircularPublicNotice_IndexID = Convert.ToInt64(dr["CircularPublicNotice_IndexID"]),
                           CircularPublicNotice_ID = Convert.ToInt64(dr["CircularPublicNotice_ID"]),
                           CircularPublicNotice_LanguageFlag = Convert.ToString(dr["CircularPublicNotice_LanguageFlag"]),

                           Circular_Number = Convert.ToString(dr["Circular_Number"]),
                           Circular_IssueDate = Convert.ToDateTime(dr["Circular_IssueDate"]),
                           Circular_Category = Convert.ToString(dr["Circular_Category"]),
                           Circular_Title = Convert.ToString(dr["Circular_Title"]),
                           CulturePunjabi_Circular_Category = Convert.ToString(dr["CulturePunjabi_Circular_Category"]),
                           CulturePunjabi_Circular_Title = Convert.ToString(dr["CulturePunjabi_Circular_Title"]),

                           Circular_BaseUrl = Convert.ToString(dr["Circular_BaseUrl"]),
                           Circular_FilePath = Convert.ToString(dr["Circular_FilePath"]),
                           Circular_FileName = Convert.ToString(dr["Circular_FileName"]),
                           Circular_FileType = Convert.ToString(dr["Circular_FileType"]),

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


        public bool Add_AdminDesk_ReatCircularPublicNoticesDetails(ClsPrp_AdminDesk_ReatCircularPublicNotice smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_REAT_AdminDesk_CircularPublicNoticeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", smodel.CircularPublicNotice_IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", smodel.CircularPublicNotice_ID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_Circular_Number", String.IsNullOrEmpty(smodel.Circular_Number) ? "" : smodel.Circular_Number);
            cmd.Parameters.AddWithValue("p_Circular_IssueDate", smodel.Circular_IssueDate == null ? dtvalue : smodel.Circular_IssueDate);
            cmd.Parameters.AddWithValue("p_Circular_Category", String.IsNullOrEmpty(smodel.Circular_Category) ? "" : smodel.Circular_Category);
            cmd.Parameters.AddWithValue("p_Circular_Title", String.IsNullOrEmpty(smodel.Circular_Title) ? "" : smodel.Circular_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Category) ? "" : smodel.CulturePunjabi_Circular_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Title) ? "" : smodel.CulturePunjabi_Circular_Title);

            cmd.Parameters.AddWithValue("p_Circular_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_Circular_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_Circular_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_Circular_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

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

        public bool Update_AdminDesk_ReatCircularPublicNoticesDetails(ClsPrp_AdminDesk_ReatCircularPublicNotice smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_REAT_AdminDesk_CircularPublicNoticeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", smodel.CircularPublicNotice_IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", smodel.CircularPublicNotice_ID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_LanguageFlag", "PB");

            cmd.Parameters.AddWithValue("p_Circular_Number", String.IsNullOrEmpty(smodel.Circular_Number) ? "" : smodel.Circular_Number);
            cmd.Parameters.AddWithValue("p_Circular_IssueDate", smodel.Circular_IssueDate == null ? dtvalue : smodel.Circular_IssueDate);
            cmd.Parameters.AddWithValue("p_Circular_Category", String.IsNullOrEmpty(smodel.Circular_Category) ? "" : smodel.Circular_Category);
            cmd.Parameters.AddWithValue("p_Circular_Title", String.IsNullOrEmpty(smodel.Circular_Title) ? "" : smodel.Circular_Title);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Category", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Category) ? "" : smodel.CulturePunjabi_Circular_Category);
            cmd.Parameters.AddWithValue("p_CulturePunjabi_Circular_Title", String.IsNullOrEmpty(smodel.CulturePunjabi_Circular_Title) ? "" : smodel.CulturePunjabi_Circular_Title);

            cmd.Parameters.AddWithValue("p_Circular_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_Circular_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_Circular_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_Circular_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

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

        public List<ClsPrp_AdminDesk_ReatCircularPublicNotice> Display_AdminDesk_ReatCircularPublicNoticesDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_ReatCircularPublicNotice> AdminDeskparameters = new List<ClsPrp_AdminDesk_ReatCircularPublicNotice>();

            MySqlCommand cmd = new MySqlCommand("Display_Reat_AdminDesk_CircularPublicNoticeByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_ReatCircularPublicNotice
                       {
                           CircularPublicNotice_IndexID = Convert.ToInt64(dr["CircularPublicNotice_IndexID"]),
                           CircularPublicNotice_ID = Convert.ToInt64(dr["CircularPublicNotice_ID"]),
                           CircularPublicNotice_LanguageFlag = Convert.ToString(dr["CircularPublicNotice_LanguageFlag"]),

                           Circular_Number = Convert.ToString(dr["Circular_Number"]),
                           Circular_IssueDate = Convert.ToDateTime(dr["Circular_IssueDate"]),
                           Circular_Category = Convert.ToString(dr["Circular_Category"]),
                           Circular_Title = Convert.ToString(dr["Circular_Title"]),
                           CulturePunjabi_Circular_Category = Convert.ToString(dr["CulturePunjabi_Circular_Category"]),
                           CulturePunjabi_Circular_Title = Convert.ToString(dr["CulturePunjabi_Circular_Title"]),

                           Circular_BaseUrl = Convert.ToString(dr["Circular_BaseUrl"]),
                           Circular_FilePath = Convert.ToString(dr["Circular_FilePath"]),
                           Circular_FileName = Convert.ToString(dr["Circular_FileName"]),
                           Circular_FileType = Convert.ToString(dr["Circular_FileType"]),

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

        public bool Delete_AdminDesk_ReatCircularPublicNoticesDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Reat_AdminDesk_CircularPublicNoticeByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_CircularPublicNotice_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CircularPublicNotice_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion



        #region Appellate Tribunal

        public List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> Display_AdminDesk_OrderJudgementByATDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> AdminDeskparameters = new List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal>();

            MySqlCommand cmd = new MySqlCommand("Display_Reat_AdminDesk_AppellateTribunal", con);
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
                       new ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal
                       {
                           AppellateTribunalOrder_IndexID = Convert.ToInt64(dr["AppellateTribunalOrder_IndexID"]),
                           AppellateTribunalOrder_ID = Convert.ToInt64(dr["AppellateTribunalOrder_ID"]),
                           Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                           Related_DiaryNumber = Convert.ToString(dr["Related_DiaryNumber"]),
                           Related_ComplaintType_MN = Convert.ToString(dr["Related_ComplaintType_MN"]),
                           Related_Complaint_OrderRefNumber = Convert.ToString(dr["Related_Complaint_OrderRefNumber"]),
                           Related_Complaint_OrderDate = Convert.ToDateTime(dr["Related_Complaint_OrderDate"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                           ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                           ComplainantName = Convert.ToString(dr["ComplainantName"]),
                           RespondentName = Convert.ToString(dr["RespondentName"]),
                           Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),
                           Appeal_RefNumber = Convert.ToString(dr["Appeal_RefNumber"]),
                           Appeal_FilingDate = Convert.ToDateTime(dr["Appeal_FilingDate"]),
                           Appeal_InstitutionDate = Convert.ToDateTime(dr["Appeal_InstitutionDate"]),
                           Related_PreHearingDate_IndexID = Convert.ToInt64(dr["Related_PreHearingDate_IndexID"]),
                           Related_PreHearingDate_ID = Convert.ToInt64(dr["Related_PreHearingDate_ID"]),
                           Related_PreHearingDate = Convert.ToDateTime(dr["Related_PreHearingDate"]),
                           Related_PreHearingTime = Convert.ToString(dr["Related_PreHearingTime"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           HearingBenchType = Convert.ToString(dr["HearingBenchType"]),

                           AppealOrderDoc_InfoCode = Convert.ToInt32(dr["AppealOrderDoc_InfoCode"]),
                           AppealOrderDoc_InfoName = Convert.ToString(dr["AppealOrderDoc_InfoName"]),
                           AppealOrderDoc_ReferenceNumber = Convert.ToString(dr["AppealOrderDoc_ReferenceNumber"]),
                           AppealOrderDoc_IssueDate = Convert.ToDateTime(dr["AppealOrderDoc_IssueDate"]),
                           AppealOrderDoc_FileSize = Convert.ToString(dr["AppealOrderDoc_FileSize"]),
                           AppealOrderDoc_FileFormat = Convert.ToString(dr["AppealOrderDoc_FileFormat"]),
                           AppealOrderDoc_FilePath = Convert.ToString(dr["AppealOrderDoc_FilePath"]),
                           AppealOrderDoc_FileName = Convert.ToString(dr["AppealOrderDoc_FileName"]),
                           AppealOrderDoc_IsGroup = Convert.ToInt32(dr["AppealOrderDoc_IsGroup"]),
                           Upload_SerialNumber = Convert.ToString(dr["Upload_SerialNumber"]),
                           Upload_PageStartNumber = Convert.ToInt32(dr["Upload_PageStartNumber"]),
                           Upload_PageEndNumber = Convert.ToInt32(dr["Upload_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsFlag = Convert.ToInt32(dr["IsFlag"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Related_TypeofOrder = Convert.ToString(dr["Related_TypeofOrder"])
                       });
            }
            return AdminDeskparameters;
        }



        public bool Add_AdminDesk_OrderJudgementByATDetails(ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal smodel, string File_Name, string File_Path, string File_Ext, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_OrderJudgementByATDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters

            cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_IndexID", smodel.AppellateTribunalOrder_IndexID);
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_ID", smodel.AppellateTribunalOrder_ID);

            // Related Complaint defaults
            cmd.Parameters.AddWithValue("p_Related_ComplaintID", 0);
            cmd.Parameters.AddWithValue("p_Related_DiaryNumber", "NA");
            cmd.Parameters.AddWithValue("p_Related_ComplaintType_MN", "FormTypeMN");
            //cmd.Parameters.AddWithValue("p_Related_Complaint_OrderRefNumber", "0");
            cmd.Parameters.AddWithValue("p_Related_Complaint_OrderDate", dtvalue);

            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            // Main complaint details
            cmd.Parameters.AddWithValue("p_ComplaintNumber", string.IsNullOrEmpty(smodel.ComplaintNumber) ? "" : smodel.ComplaintNumber);
            cmd.Parameters.AddWithValue("p_ComplainantName", string.IsNullOrEmpty(smodel.ComplainantName) ? "" : smodel.ComplainantName);
            cmd.Parameters.AddWithValue("p_RespondentName", string.IsNullOrEmpty(smodel.RespondentName) ? "" : smodel.RespondentName);
            cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.Date_of_Decision == null ? dtvalue : smodel.Date_of_Decision);

            // Appeal related
            cmd.Parameters.AddWithValue("p_Appeal_RefNumber", string.IsNullOrEmpty(smodel.Appeal_RefNumber) ? "" : smodel.Appeal_RefNumber);
            cmd.Parameters.AddWithValue("p_Appeal_FilingDate", smodel.Appeal_FilingDate == null ? dtvalue : smodel.Appeal_FilingDate);
            cmd.Parameters.AddWithValue("p_Appeal_InstitutionDate", dtvalue);

            // Pre-hearing defaults
            cmd.Parameters.AddWithValue("p_Related_PreHearingDate_IndexID", 0);
            //cmd.Parameters.AddWithValue("p_Related_PreHearingDate_ID", 0);
            cmd.Parameters.AddWithValue("p_Related_PreHearingDate", dtvalue);
            //cmd.Parameters.AddWithValue("p_Related_PreHearingTime", "00:00 AM");

            // Bench defaults
            cmd.Parameters.AddWithValue("p_UserId", string.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);
            //cmd.Parameters.AddWithValue("p_HearingBenchCode", "0");
            //cmd.Parameters.AddWithValue("p_HearingBenchName", "NA");
            //cmd.Parameters.AddWithValue("p_HearingBenchType", "REAT");

            // Document info
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_InfoCode", smodel.AppealOrderDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_InfoName", string.IsNullOrEmpty(smodel.AppealOrderDoc_InfoName) ? "" : smodel.AppealOrderDoc_InfoName);
            //cmd.Parameters.AddWithValue("p_AppealOrderDoc_ReferenceNumber", "ONLINE SHEET");
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_IssueDate", smodel.AppealOrderDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_FileSize", string.IsNullOrEmpty(smodel.AppealOrderDoc_FileSize) ? "1" : smodel.AppealOrderDoc_FileSize);
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_FileFormat", string.IsNullOrEmpty(File_Ext) ? "" : File_Ext);
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_FilePath", string.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_FileName", string.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_AppealOrderDoc_IsGroup", 10);

            // Upload defaults
            //cmd.Parameters.AddWithValue("p_Upload_SerialNumber", "1");
            //cmd.Parameters.AddWithValue("p_Upload_PageStartNumber", 0);
            //cmd.Parameters.AddWithValue("p_Upload_PageEndNumber", 0);

            // Remarks / extra columns
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", string.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", string.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", string.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            //cmd.Parameters.AddWithValue("p_IsActive", 1);
            //cmd.Parameters.AddWithValue("p_IsDraft", 1);
            //cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsFlag", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            // Audit
            cmd.Parameters.AddWithValue("p_CreatedBy", string.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyBy", string.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);

           // cmd.Parameters.AddWithValue("p_Related_TypeofOrder", smodel.Related_TypeofOrder);

            // Return value
            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            return (i >= 1);
        }


        public bool Update_AdminDesk_OrderJudgementByATDetails(ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal smodel, string File_Name, string File_Path, string File_Ext, string userName)
        {

            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_OrderJudgementByATDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                #region Parameters
                cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_IndexID", smodel.AppellateTribunalOrder_IndexID);
                cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_ID", smodel.AppellateTribunalOrder_ID);
                cmd.Parameters.AddWithValue("p_Related_Complaint_OrderDate", dtvalue);
                cmd.Parameters.AddWithValue("p_ComplaintNumber", smodel.ComplaintNumber);
                cmd.Parameters.AddWithValue("p_ComplainantName", smodel.ComplainantName);
                cmd.Parameters.AddWithValue("p_RespondentName", smodel.RespondentName);
                cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.Date_of_Decision);
                cmd.Parameters.AddWithValue("p_Appeal_RefNumber", smodel.Appeal_RefNumber);
                cmd.Parameters.AddWithValue("p_Appeal_FilingDate", smodel.Appeal_FilingDate);
                cmd.Parameters.AddWithValue("p_Appeal_InstitutionDate", dtvalue);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_FilePath", smodel.AppealOrderDoc_FilePath);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_FileName", smodel.AppealOrderDoc_FileName);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_FileFormat", smodel.AppealOrderDoc_FileFormat);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_FileSize", string.IsNullOrEmpty(smodel.AppealOrderDoc_FileSize) ? "1" : smodel.AppealOrderDoc_FileSize);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_InfoName", smodel.AppealOrderDoc_InfoName);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_InfoCode", smodel.AppealOrderDoc_InfoCode);
                cmd.Parameters.AddWithValue("p_AppealOrderDoc_IssueDate", smodel.AppealOrderDoc_IssueDate);
                cmd.Parameters.AddWithValue("p_Related_PreHearingDate", dtvalue);
                cmd.Parameters.AddWithValue("p_UserId", smodel.User_ID);
               // cmd.Parameters.AddWithValue("p_Related_TypeofOrder", smodel.Related_TypeofOrder);
                cmd.Parameters.AddWithValue("p_A_column", string.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
                cmd.Parameters.AddWithValue("p_B_column", string.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
                cmd.Parameters.AddWithValue("p_C_column", string.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
                cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
                cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
                cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);
                cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
                cmd.Parameters.AddWithValue("p_CreatedBy", userName);
                cmd.Parameters.AddWithValue("p_ModifyBy", userName);
                cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);

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
            catch (Exception ex)
            {
                // throw ex;
                return false;
            }
        }

        public List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> Display_AdminDesk_OrderJudgementByATDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal> AdminDeskparameters = new List<ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_OrderJudgementATByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_OrderJugmentByAppelateTribunal
                       {
                           AppellateTribunalOrder_IndexID = Convert.ToInt64(dr["AppellateTribunalOrder_IndexID"]),
                           AppellateTribunalOrder_ID = Convert.ToInt64(dr["AppellateTribunalOrder_ID"]),
                           Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                           Related_DiaryNumber = Convert.ToString(dr["Related_DiaryNumber"]),
                           Related_ComplaintType_MN = Convert.ToString(dr["Related_ComplaintType_MN"]),
                           Related_Complaint_OrderRefNumber = Convert.ToString(dr["Related_Complaint_OrderRefNumber"]),
                           Related_Complaint_OrderDate = Convert.ToDateTime(dr["Related_Complaint_OrderDate"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                           ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                           ComplainantName = Convert.ToString(dr["ComplainantName"]),
                           RespondentName = Convert.ToString(dr["RespondentName"]),
                           Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),
                           Appeal_RefNumber = Convert.ToString(dr["Appeal_RefNumber"]),
                           Appeal_FilingDate = Convert.ToDateTime(dr["Appeal_FilingDate"]),
                           Appeal_InstitutionDate = Convert.ToDateTime(dr["Appeal_InstitutionDate"]),
                           Related_PreHearingDate_IndexID = Convert.ToInt64(dr["Related_PreHearingDate_IndexID"]),
                           Related_PreHearingDate_ID = Convert.ToInt64(dr["Related_PreHearingDate_ID"]),
                           Related_PreHearingDate = Convert.ToDateTime(dr["Related_PreHearingDate"]),
                           Related_PreHearingTime = Convert.ToString(dr["Related_PreHearingTime"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           HearingBenchType = Convert.ToString(dr["HearingBenchType"]),

                           AppealOrderDoc_InfoCode = Convert.ToInt32(dr["AppealOrderDoc_InfoCode"]),
                           AppealOrderDoc_InfoName = Convert.ToString(dr["AppealOrderDoc_InfoName"]),
                           AppealOrderDoc_ReferenceNumber = Convert.ToString(dr["AppealOrderDoc_ReferenceNumber"]),
                           AppealOrderDoc_IssueDate = Convert.ToDateTime(dr["AppealOrderDoc_IssueDate"]),
                           AppealOrderDoc_FileSize = Convert.ToString(dr["AppealOrderDoc_FileSize"]),
                           AppealOrderDoc_FileFormat = Convert.ToString(dr["AppealOrderDoc_FileFormat"]),
                           AppealOrderDoc_FilePath = Convert.ToString(dr["AppealOrderDoc_FilePath"]),
                           AppealOrderDoc_FileName = Convert.ToString(dr["AppealOrderDoc_FileName"]),
                           AppealOrderDoc_IsGroup = Convert.ToInt32(dr["AppealOrderDoc_IsGroup"]),
                           Upload_SerialNumber = Convert.ToString(dr["Upload_SerialNumber"]),
                           Upload_PageStartNumber = Convert.ToInt32(dr["Upload_PageStartNumber"]),
                           Upload_PageEndNumber = Convert.ToInt32(dr["Upload_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsFlag = Convert.ToInt32(dr["IsFlag"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Related_TypeofOrder = Convert.ToString(dr["Related_TypeofOrder"])
                       });
            }
            return AdminDeskparameters;
        }


        public bool Delete_AdminDesk_OrderJudgementByATDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_AppellateTribunalByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrder_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_TypeOfOrder> Display_Rera_TyeOfOrderDropdown()
        {
            connection();
            List<ClsPrp_TypeOfOrder> TyeofOrderList = new List<ClsPrp_TypeOfOrder>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_TypeOfOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                TyeofOrderList.Add(
                       new ClsPrp_TypeOfOrder
                       {
                           typeofOrder_IndexID = Convert.ToInt32(dr["typeofOrder_IndexID"]),
                           typeofOrder_ID = Convert.ToInt32(dr["typeofOrder_ID"]),
                           typeofOrderCode = Convert.ToInt32(dr["typeofOrderCode"]),
                           typeofOrderName = Convert.ToString(dr["typeofOrderName"]),
                           typeofOrderType = Convert.ToString(dr["typeofOrderType"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return TyeofOrderList;
        }
        #endregion



        #region Execution Appellate Tribunal

        public List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> Display_AdminDesk_OrderJudgementInExecutionByATDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> AdminDeskparameters = new List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal>();

            MySqlCommand cmd = new MySqlCommand("Display_Reat_AdminDesk_OJInExecutionByAppellateTribunal", con);
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
                       new ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal
                       {
                           AppellateTribunalOrderExecution_IndexID = Convert.ToInt64(dr["AppellateTribunalOrderExecution_IndexID"]),
                           AppellateTribunalOrderExecution_ID = Convert.ToInt64(dr["AppellateTribunalOrderExecution_ID"]),
                           Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                           Related_DiaryNumber = Convert.ToString(dr["Related_DiaryNumber"]),
                           Related_ComplaintType_MN = Convert.ToString(dr["Related_ComplaintType_MN"]),
                           Related_Appeal_RefNumber = Convert.ToString(dr["Related_Appeal_RefNumber"]),
                           Related_Appeal_OrderDate = Convert.ToDateTime(dr["Related_Appeal_OrderDate"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                           ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                           ComplainantName = Convert.ToString(dr["ComplainantName"]),
                           RespondentName = Convert.ToString(dr["RespondentName"]),
                           Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),
                           Execution_RefNumber = Convert.ToString(dr["Execution_RefNumber"]),
                           Execution_FilingDate = Convert.ToDateTime(dr["Execution_FilingDate"]),
                           Execution_InstitutionDate = Convert.ToDateTime(dr["Execution_InstitutionDate"]),
                           Related_PreHearingDate_IndexID = Convert.ToInt64(dr["Related_PreHearingDate_IndexID"]),
                           Related_PreHearingDate_ID = Convert.ToInt64(dr["Related_PreHearingDate_ID"]),
                           Related_PreHearingDate = Convert.ToDateTime(dr["Related_PreHearingDate"]),
                           Related_PreHearingTime = Convert.ToString(dr["Related_PreHearingTime"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           HearingBenchType = Convert.ToString(dr["HearingBenchType"]),

                           ExecutionOrderDoc_InfoCode = Convert.ToInt32(dr["ExecutionOrderDoc_InfoCode"]),
                           ExecutionOrderDoc_InfoName = Convert.ToString(dr["ExecutionOrderDoc_InfoName"]),
                           ExecutionOrderDoc_ReferenceNumber = Convert.ToString(dr["ExecutionOrderDoc_ReferenceNumber"]),
                           ExecutionOrderDoc_IssueDate = Convert.ToDateTime(dr["ExecutionOrderDoc_IssueDate"]),
                           ExecutionOrderDoc_FileSize = Convert.ToString(dr["ExecutionOrderDoc_FileSize"]),
                           ExecutionOrderDoc_FileFormat = Convert.ToString(dr["ExecutionOrderDoc_FileFormat"]),
                           ExecutionOrderDoc_FilePath = Convert.ToString(dr["ExecutionOrderDoc_FilePath"]),
                           ExecutionOrderDoc_FileName = Convert.ToString(dr["ExecutionOrderDoc_FileName"]),
                           ExecutionOrderDoc_IsGroup = Convert.ToInt32(dr["ExecutionOrderDoc_IsGroup"]),
                           Upload_SerialNumber = Convert.ToString(dr["Upload_SerialNumber"]),
                           Upload_PageStartNumber = Convert.ToInt32(dr["Upload_PageStartNumber"]),
                           Upload_PageEndNumber = Convert.ToInt32(dr["Upload_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsFlag = Convert.ToInt32(dr["IsFlag"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Related_TypeofOrder = Convert.ToString(dr["Related_TypeofOrder"])
                       });
            }
            return AdminDeskparameters;
        }

        public bool Add_AdminDesk_OrderJudgementInExecutionByATDetails(ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal smodel, string File_Name, string File_Path, string File_Ext, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_REAT_AdminDesk_OrderJudgementEXByAT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters

            cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_IndexID", smodel.AppellateTribunalOrderExecution_IndexID);
            //cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_ID", smodel.AppellateTribunalOrderExecution_ID);

            // Related Complaint defaults
            cmd.Parameters.AddWithValue("p_Related_ComplaintID", 0);
            cmd.Parameters.AddWithValue("p_Related_DiaryNumber", "NA");
            cmd.Parameters.AddWithValue("p_Related_ComplaintType_MN", "FormTypeMN");
            cmd.Parameters.AddWithValue("p_Related_Appeal_RefNumber", smodel.Related_Appeal_RefNumber);
            cmd.Parameters.AddWithValue("p_Related_Appeal_OrderDate", dtvalue);

            // Main complaint details
            cmd.Parameters.AddWithValue("p_ComplaintNumber", "NA");
            cmd.Parameters.AddWithValue("p_ComplainantName", string.IsNullOrEmpty(smodel.ComplainantName) ? "" : smodel.ComplainantName);
            cmd.Parameters.AddWithValue("p_RespondentName", string.IsNullOrEmpty(smodel.RespondentName) ? "" : smodel.RespondentName);
            cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.Date_of_Decision == null ? dtvalue : smodel.Date_of_Decision);

            // Appeal related
            cmd.Parameters.AddWithValue("p_Execution_RefNumber", string.IsNullOrEmpty(smodel.Execution_RefNumber) ? "" : smodel.Execution_RefNumber);
            cmd.Parameters.AddWithValue("p_Execution_FilingDate", smodel.Execution_FilingDate == null ? dtvalue : smodel.Execution_FilingDate);
            cmd.Parameters.AddWithValue("p_Execution_InstitutionDate", dtvalue);

            // Pre-hearing defaults
            cmd.Parameters.AddWithValue("p_Related_PreHearingDate_IndexID", 0);
            cmd.Parameters.AddWithValue("p_Related_PreHearingDate_ID", 0);
            cmd.Parameters.AddWithValue("p_Related_PreHearingDate", dtvalue);
            cmd.Parameters.AddWithValue("p_Related_PreHearingTime", "00:00 AM");


            cmd.Parameters.AddWithValue("p_UserId", string.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);
            cmd.Parameters.AddWithValue("p_HearingBenchCode", "0");
            cmd.Parameters.AddWithValue("p_HearingBenchName", "NA");
            cmd.Parameters.AddWithValue("p_HearingBenchType", "REAT");

            // Document info
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_InfoCode", smodel.ExecutionOrderDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_InfoName", string.IsNullOrEmpty(smodel.ExecutionOrderDoc_InfoName) ? "" : smodel.ExecutionOrderDoc_InfoName);
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_ReferenceNumber", "NA");
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_IssueDate", smodel.ExecutionOrderDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FileSize", "1");
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FileFormat", string.IsNullOrEmpty(File_Ext) ? "" : File_Ext);
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FilePath", string.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FileName", string.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_ExecutionlOrderDoc_IsGroup", 10);

            // Upload defaults
            cmd.Parameters.AddWithValue("p_Upload_SerialNumber", "1");
            cmd.Parameters.AddWithValue("p_Upload_PageStartNumber", 0);
            cmd.Parameters.AddWithValue("p_Upload_PageEndNumber", 0);

            // Remarks / extra columns
            //cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            //cmd.Parameters.AddWithValue("p_A_column", string.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            //cmd.Parameters.AddWithValue("p_B_column", string.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            //cmd.Parameters.AddWithValue("p_C_column", string.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            //cmd.Parameters.AddWithValue("p_IsActive", 1);
            //cmd.Parameters.AddWithValue("p_IsDraft", 1);
            //cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            //cmd.Parameters.AddWithValue("p_IsFlag", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            // Audit
            cmd.Parameters.AddWithValue("p_CreatedBy", string.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyBy", string.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);

            //cmd.Parameters.AddWithValue("p_Related_TypeofOrder", smodel.Related_TypeofOrder);

            // Return value
            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            return (i >= 1);
        }

        public bool Delete_AdminDesk_OrderJudgementInExecutionByATDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_REAT_AdminDesk_EXAppellateTribunalByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> Display_AdminDesk_OrderJudgementInExecutionByATDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> AdminDeskparameters = new List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal>();

            MySqlCommand cmd = new MySqlCommand("Display_REAT_AdminDesk_OrderJudgementInEX_ATByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal
                       {
                           AppellateTribunalOrderExecution_IndexID = Convert.ToInt64(dr["AppellateTribunalOrderExecution_IndexID"]),
                           AppellateTribunalOrderExecution_ID = Convert.ToInt64(dr["AppellateTribunalOrderExecution_ID"]),
                           Related_ComplaintID = Convert.ToInt64(dr["Related_ComplaintID"]),
                           Related_DiaryNumber = Convert.ToString(dr["Related_DiaryNumber"]),
                           Related_ComplaintType_MN = Convert.ToString(dr["Related_ComplaintType_MN"]),
                           Related_Appeal_RefNumber = Convert.ToString(dr["Related_Appeal_RefNumber"]),
                           Related_Appeal_OrderDate = Convert.ToDateTime(dr["Related_Appeal_OrderDate"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                           ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                           ComplainantName = Convert.ToString(dr["ComplainantName"]),
                           RespondentName = Convert.ToString(dr["RespondentName"]),
                           Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),
                           Execution_RefNumber = Convert.ToString(dr["Execution_RefNumber"]),
                           Execution_FilingDate = Convert.ToDateTime(dr["Execution_FilingDate"]),
                           Execution_InstitutionDate = Convert.ToDateTime(dr["Execution_InstitutionDate"]),
                           Related_PreHearingDate_IndexID = Convert.ToInt64(dr["Related_PreHearingDate_IndexID"]),
                           Related_PreHearingDate_ID = Convert.ToInt64(dr["Related_PreHearingDate_ID"]),
                           Related_PreHearingDate = Convert.ToDateTime(dr["Related_PreHearingDate"]),
                           Related_PreHearingTime = Convert.ToString(dr["Related_PreHearingTime"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           HearingBenchType = Convert.ToString(dr["HearingBenchType"]),

                           ExecutionOrderDoc_InfoCode = Convert.ToInt32(dr["ExecutionOrderDoc_InfoCode"]),
                           ExecutionOrderDoc_InfoName = Convert.ToString(dr["ExecutionOrderDoc_InfoName"]),
                           ExecutionOrderDoc_ReferenceNumber = Convert.ToString(dr["ExecutionOrderDoc_ReferenceNumber"]),
                           ExecutionOrderDoc_IssueDate = Convert.ToDateTime(dr["ExecutionOrderDoc_IssueDate"]),
                           ExecutionOrderDoc_FileSize = Convert.ToString(dr["ExecutionOrderDoc_FileSize"]),
                           ExecutionOrderDoc_FileFormat = Convert.ToString(dr["ExecutionOrderDoc_FileFormat"]),
                           ExecutionOrderDoc_FilePath = Convert.ToString(dr["ExecutionOrderDoc_FilePath"]),
                           ExecutionOrderDoc_FileName = Convert.ToString(dr["ExecutionOrderDoc_FileName"]),
                           ExecutionOrderDoc_IsGroup = Convert.ToInt32(dr["ExecutionOrderDoc_IsGroup"]),
                           Upload_SerialNumber = Convert.ToString(dr["Upload_SerialNumber"]),
                           Upload_PageStartNumber = Convert.ToInt32(dr["Upload_PageStartNumber"]),
                           Upload_PageEndNumber = Convert.ToInt32(dr["Upload_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsFlag = Convert.ToInt32(dr["IsFlag"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Related_TypeofOrder = Convert.ToString(dr["Related_TypeofOrder"])
                       });
            }
            return AdminDeskparameters;
        }

        public bool Update_AdminDesk_OrderJudgementInExecutionByATDetails(ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal smodel, string File_Name, string File_Path, string File_Ext, string userName)
        {

            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand("usp_update_tbl_REAT_AdminDesk_OrderJudgementInEXByATDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                #region Parameters
                cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_IndexID", smodel.AppellateTribunalOrderExecution_IndexID);
                cmd.Parameters.AddWithValue("p_AppellateTribunalOrderExecution_ID", smodel.AppellateTribunalOrderExecution_ID);

                cmd.Parameters.AddWithValue("p_Related_ComplaintID", 0);
                cmd.Parameters.AddWithValue("p_Related_DiaryNumber", "NA");
                cmd.Parameters.AddWithValue("p_Related_ComplaintType_MN", "FormTypeMN");
                cmd.Parameters.AddWithValue("p_Related_Appeal_RefNumber", smodel.Related_Appeal_RefNumber);
                cmd.Parameters.AddWithValue("p_Related_Appeal_OrderDate", dtvalue);

                cmd.Parameters.AddWithValue("p_ComplaintNumber", "NA");
                cmd.Parameters.AddWithValue("p_ComplainantName", string.IsNullOrEmpty(smodel.ComplainantName) ? "" : smodel.ComplainantName);
                cmd.Parameters.AddWithValue("p_RespondentName", string.IsNullOrEmpty(smodel.RespondentName) ? "" : smodel.RespondentName);
                cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.Date_of_Decision == null ? dtvalue : smodel.Date_of_Decision);

                cmd.Parameters.AddWithValue("p_Execution_RefNumber", string.IsNullOrEmpty(smodel.Execution_RefNumber) ? "" : smodel.Execution_RefNumber);
                cmd.Parameters.AddWithValue("p_Execution_FilingDate", smodel.Execution_FilingDate == null ? dtvalue : smodel.Execution_FilingDate);
                cmd.Parameters.AddWithValue("p_Execution_InstitutionDate", dtvalue);

                cmd.Parameters.AddWithValue("p_Related_PreHearingDate_IndexID", 0);
                cmd.Parameters.AddWithValue("p_Related_PreHearingDate_ID", 0);
                cmd.Parameters.AddWithValue("p_Related_PreHearingDate", dtvalue);
                cmd.Parameters.AddWithValue("p_Related_PreHearingTime", "00:00 AM");


                cmd.Parameters.AddWithValue("p_UserId", string.IsNullOrEmpty(smodel.User_ID) ? "" : smodel.User_ID);
                cmd.Parameters.AddWithValue("p_HearingBenchCode", "0");
                cmd.Parameters.AddWithValue("p_HearingBenchName", "NA");
                cmd.Parameters.AddWithValue("p_HearingBenchType", "REAT");

                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_InfoCode", smodel.ExecutionOrderDoc_InfoCode);
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_InfoName", string.IsNullOrEmpty(smodel.ExecutionOrderDoc_InfoName) ? "" : smodel.ExecutionOrderDoc_InfoName);
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_ReferenceNumber", "NA");
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_IssueDate", smodel.ExecutionOrderDoc_IssueDate);
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FileSize", "1");
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FileFormat", string.IsNullOrEmpty(File_Ext) ? "" : File_Ext);
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FilePath", string.IsNullOrEmpty(File_Path) ? "" : File_Path);
                cmd.Parameters.AddWithValue("p_ExecutionOrderDoc_FileName", string.IsNullOrEmpty(File_Name) ? "" : File_Name);
                cmd.Parameters.AddWithValue("p_ExecutionlOrderDoc_IsGroup", 10);

                // Upload defaults
                cmd.Parameters.AddWithValue("p_Upload_SerialNumber", "1");
                cmd.Parameters.AddWithValue("p_Upload_PageStartNumber", 0);
                cmd.Parameters.AddWithValue("p_Upload_PageEndNumber", 0);

                cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
                cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

                cmd.Parameters.AddWithValue("p_CreatedBy", string.IsNullOrEmpty(userName) ? "" : userName);
                cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
                cmd.Parameters.AddWithValue("p_ModifyBy", string.IsNullOrEmpty(userName) ? "" : userName);
                cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);

                cmd.Parameters.AddWithValue("p_Related_TypeofOrder", smodel.Related_TypeofOrder);

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
            catch (Exception ex)
            {
                // throw ex;
                return false;
            }
        }

        #endregion

    }
}
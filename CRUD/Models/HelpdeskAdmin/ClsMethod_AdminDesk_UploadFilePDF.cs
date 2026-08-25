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
    public class ClsMethod_AdminDesk_UploadFilePDF
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AdminDesk_UploadFilePDF> Display_AdminDesk_ProjectsUploadListDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_UploadFilePDF> AdminDeskparameters = new List<ClsPrp_AdminDesk_UploadFilePDF>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_ProjectsUploadList", con);
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
                       new ClsPrp_AdminDesk_UploadFilePDF
                       {
                           UploadFilePDF_IndexID = Convert.ToInt64(dr["UploadFilePDF_IndexID"]),
                           UploadFilePDF_ID = Convert.ToInt64(dr["UploadFilePDF_ID"]),

                           FileReferenceType = Convert.ToString(dr["FileReferenceType"]),
                           FileReferenceName = Convert.ToString(dr["FileReferenceName"]),
                           Date_of_UploadorIssue = Convert.ToDateTime(dr["Date_of_UploadorIssue"]),

                           UploadFilePDF_BaseUrl = Convert.ToString(dr["UploadFilePDF_BaseUrl"]),
                           UploadFilePDF_FilePath = Convert.ToString(dr["UploadFilePDF_FilePath"]),
                           UploadFilePDF_FileName = Convert.ToString(dr["UploadFilePDF_FileName"]),
                           UploadFilePDF_FileType = Convert.ToString(dr["UploadFilePDF_FileType"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_UploadFilePDF> Display_AdminDesk_AgentsUploadListDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_UploadFilePDF> AdminDeskparameters = new List<ClsPrp_AdminDesk_UploadFilePDF>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_AgentUploadList", con);
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
                       new ClsPrp_AdminDesk_UploadFilePDF
                       {
                           UploadFilePDF_IndexID = Convert.ToInt64(dr["UploadFilePDF_IndexID"]),
                           UploadFilePDF_ID = Convert.ToInt64(dr["UploadFilePDF_ID"]),

                           FileReferenceType = Convert.ToString(dr["FileReferenceType"]),
                           FileReferenceName = Convert.ToString(dr["FileReferenceName"]),
                           Date_of_UploadorIssue = Convert.ToDateTime(dr["Date_of_UploadorIssue"]),

                           UploadFilePDF_BaseUrl = Convert.ToString(dr["UploadFilePDF_BaseUrl"]),
                           UploadFilePDF_FilePath = Convert.ToString(dr["UploadFilePDF_FilePath"]),
                           UploadFilePDF_FileName = Convert.ToString(dr["UploadFilePDF_FileName"]),
                           UploadFilePDF_FileType = Convert.ToString(dr["UploadFilePDF_FileType"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_UploadFilePDF> Display_AdminDesk_PendingProjectsUploadListDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_UploadFilePDF> AdminDeskparameters = new List<ClsPrp_AdminDesk_UploadFilePDF>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_PendingProjectsUploadList", con);
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
                       new ClsPrp_AdminDesk_UploadFilePDF
                       {
                           UploadFilePDF_IndexID = Convert.ToInt64(dr["UploadFilePDF_IndexID"]),
                           UploadFilePDF_ID = Convert.ToInt64(dr["UploadFilePDF_ID"]),

                           FileReferenceType = Convert.ToString(dr["FileReferenceType"]),
                           FileReferenceName = Convert.ToString(dr["FileReferenceName"]),
                           Date_of_UploadorIssue = Convert.ToDateTime(dr["Date_of_UploadorIssue"]),

                           UploadFilePDF_BaseUrl = Convert.ToString(dr["UploadFilePDF_BaseUrl"]),
                           UploadFilePDF_FilePath = Convert.ToString(dr["UploadFilePDF_FilePath"]),
                           UploadFilePDF_FileName = Convert.ToString(dr["UploadFilePDF_FileName"]),
                           UploadFilePDF_FileType = Convert.ToString(dr["UploadFilePDF_FileType"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Add_AdminDesk_ProjectsUploadList(ClsPrp_AdminDesk_UploadFilePDF smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_ProjectsUploadList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_UploadFilePDF_IndexID", smodel.UploadFilePDF_IndexID);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_ID", smodel.UploadFilePDF_ID);

            cmd.Parameters.AddWithValue("p_FileReferenceType", String.IsNullOrEmpty(smodel.FileReferenceType) ? "" : smodel.FileReferenceType);
            cmd.Parameters.AddWithValue("p_FileReferenceName", String.IsNullOrEmpty(smodel.FileReferenceName) ? "" : smodel.FileReferenceName);
            cmd.Parameters.AddWithValue("p_Date_of_UploadorIssue", smodel.Date_of_UploadorIssue == null ? dtvalue : smodel.Date_of_UploadorIssue);

            cmd.Parameters.AddWithValue("p_UploadFilePDF_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 1);

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
             
        public bool Add_AdminDesk_AgentsUploadList(ClsPrp_AdminDesk_UploadFilePDF smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_AgentsUploadList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_UploadFilePDF_IndexID", smodel.UploadFilePDF_IndexID);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_ID", smodel.UploadFilePDF_ID);

            cmd.Parameters.AddWithValue("p_FileReferenceType", String.IsNullOrEmpty(smodel.FileReferenceType) ? "" : smodel.FileReferenceType);
            cmd.Parameters.AddWithValue("p_FileReferenceName", String.IsNullOrEmpty(smodel.FileReferenceName) ? "" : smodel.FileReferenceName);
            cmd.Parameters.AddWithValue("p_Date_of_UploadorIssue", smodel.Date_of_UploadorIssue == null ? dtvalue : smodel.Date_of_UploadorIssue);

            cmd.Parameters.AddWithValue("p_UploadFilePDF_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 1);

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
                
        public bool Add_AdminDesk_PendingProjectsUploadList(ClsPrp_AdminDesk_UploadFilePDF smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_PendingProjectsUploadList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_UploadFilePDF_IndexID", smodel.UploadFilePDF_IndexID);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_ID", smodel.UploadFilePDF_ID);

            cmd.Parameters.AddWithValue("p_FileReferenceType", String.IsNullOrEmpty(smodel.FileReferenceType) ? "" : smodel.FileReferenceType);
            cmd.Parameters.AddWithValue("p_FileReferenceName", String.IsNullOrEmpty(smodel.FileReferenceName) ? "" : smodel.FileReferenceName);
            cmd.Parameters.AddWithValue("p_Date_of_UploadorIssue", smodel.Date_of_UploadorIssue == null ? dtvalue : smodel.Date_of_UploadorIssue);

            cmd.Parameters.AddWithValue("p_UploadFilePDF_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_UploadFilePDF_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 1);

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

    }
}
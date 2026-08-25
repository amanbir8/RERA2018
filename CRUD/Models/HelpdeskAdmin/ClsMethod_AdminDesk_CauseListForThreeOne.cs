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
    public class ClsMethod_AdminDesk_CauseListForThreeOne
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_AdminDesk_CauseListForThreeOneDetails(ClsPrp_AdminDesk_CauseListForThreeOne smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_CauseListForThreeOne", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CauseListFormMN_IndexID", smodel.CauseListFormMN_IndexID);
            cmd.Parameters.AddWithValue("p_CauseListFormMN_ID", smodel.CauseListFormMN_ID);

            cmd.Parameters.AddWithValue("p_CauseListDate", smodel.CauseListDate == null ? dtvalue : smodel.CauseListDate); 
            cmd.Parameters.AddWithValue("p_CauseListDay", String.IsNullOrEmpty(smodel.CauseListDay) ? "" : smodel.CauseListDay);
            
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl); 
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path); 
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name); 
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext); 

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
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

        public bool Update_AdminDesk_CauseListForThreeOneDetails(ClsPrp_AdminDesk_CauseListForThreeOne smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_CauseListForThreeOne", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_CauseListFormMN_IndexID", smodel.CauseListFormMN_IndexID);
            cmd.Parameters.AddWithValue("p_CauseListFormMN_ID", smodel.CauseListFormMN_ID);

            cmd.Parameters.AddWithValue("p_CauseListDate", smodel.CauseListDate == null ? dtvalue : smodel.CauseListDate);
            cmd.Parameters.AddWithValue("p_CauseListDay", String.IsNullOrEmpty(smodel.CauseListDay) ? "" : smodel.CauseListDay);

            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl);
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path); 
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name);
            cmd.Parameters.AddWithValue("p_ViewCauseListFormMN_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext); 

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
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

        public List<ClsPrp_AdminDesk_CauseListForThreeOne> Display_AdminDesk_CauseListForThreeOneDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_CauseListForThreeOne> AdminDeskparameters = new List<ClsPrp_AdminDesk_CauseListForThreeOne>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_CauseListForThreeOne", con);
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
                       new ClsPrp_AdminDesk_CauseListForThreeOne
                       {
                           CauseListFormMN_IndexID = Convert.ToInt64(dr["CauseListFormMN_IndexID"]),
                           CauseListFormMN_ID = Convert.ToInt64(dr["CauseListFormMN_ID"]),

                           CauseListDate = Convert.ToDateTime(dr["CauseListDate"]),
                           CauseListDay = Convert.ToString(dr["CauseListDay"]),

                           ViewCauseListFormMN_BaseUrl = Convert.ToString(dr["ViewCauseListFormMN_BaseUrl"]),
                           ViewCauseListFormMN_FilePath = Convert.ToString(dr["ViewCauseListFormMN_FilePath"]),
                           ViewCauseListFormMN_FileName = Convert.ToString(dr["ViewCauseListFormMN_FileName"]),
                           ViewCauseListFormMN_FileType = Convert.ToString(dr["ViewCauseListFormMN_FileType"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_CauseListForThreeOne> Display_AdminDesk_CauseListForThreeOneDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_CauseListForThreeOne> AdminDeskparameters = new List<ClsPrp_AdminDesk_CauseListForThreeOne>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_CauseListForThreeOneByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_CauseListFormMN_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CauseListFormMN_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_CauseListForThreeOne
                       {
                           CauseListFormMN_IndexID = Convert.ToInt64(dr["CauseListFormMN_IndexID"]),
                           CauseListFormMN_ID = Convert.ToInt64(dr["CauseListFormMN_ID"]),
                                                     
                           CauseListDate = Convert.ToDateTime(dr["CauseListDate"]),
                           CauseListDay = Convert.ToString(dr["CauseListDay"]),
                           
                           ViewCauseListFormMN_BaseUrl = Convert.ToString(dr["ViewCauseListFormMN_BaseUrl"]),
                           ViewCauseListFormMN_FilePath = Convert.ToString(dr["ViewCauseListFormMN_FilePath"]),
                           ViewCauseListFormMN_FileName = Convert.ToString(dr["ViewCauseListFormMN_FileName"]),
                           ViewCauseListFormMN_FileType = Convert.ToString(dr["ViewCauseListFormMN_FileType"]),

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Delete_AdminDesk_CauseListForThreeOneByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_CauseListForThreeOneByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_CauseListFormMN_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_CauseListFormMN_ID", KeyID);

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
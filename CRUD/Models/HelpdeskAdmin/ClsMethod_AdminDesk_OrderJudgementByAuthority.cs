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
    public class ClsMethod_AdminDesk_OrderJudgementByAuthority
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_AdminDesk_OrderJudgementByAuthorityDetails(ClsPrp_AdminDesk_OrderJudgementByAuthority smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_OrderJudgementByAuthorityDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_IndexID", smodel.OrderJudgementByAuthority_IndexID);
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_ID", smodel.OrderJudgementByAuthority_ID);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_ComplaintNumber", String.IsNullOrEmpty(smodel.ComplaintNumber) ? "" : smodel.ComplaintNumber);
            cmd.Parameters.AddWithValue("p_ComplainantName", String.IsNullOrEmpty(smodel.ComplainantName) ? "" : smodel.ComplainantName);
            cmd.Parameters.AddWithValue("p_RespondentName", String.IsNullOrEmpty(smodel.RespondentName) ? "" : smodel.RespondentName);
            cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.Date_of_Decision == null ? dtvalue : smodel.Date_of_Decision);

            cmd.Parameters.AddWithValue("p_ViewJugdement_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl); //String.IsNullOrEmpty(smodel.ViewJugdement_BaseUrl) ? "" : smodel.ViewJugdement_BaseUrl);
            cmd.Parameters.AddWithValue("p_ViewJugdement_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path); // String.IsNullOrEmpty(smodel.ViewJugdement_FilePath) ? "" : smodel.ViewJugdement_FilePath);
            cmd.Parameters.AddWithValue("p_ViewJugdement_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name); // String.IsNullOrEmpty(smodel.ViewJugdement_FileName) ? "" : smodel.ViewJugdement_FileName);
            cmd.Parameters.AddWithValue("p_ViewJugdement_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext); // String.IsNullOrEmpty(smodel.ViewJugdement_FileType) ? "" : smodel.ViewJugdement_FileType);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "0" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "NA" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "0" : smodel.C_column);

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

        public bool Update_AdminDesk_OrderJudgementByAuthorityDetails(ClsPrp_AdminDesk_OrderJudgementByAuthority smodel, string File_Name, string File_Path, string File_Ext, string File_BasicUrl, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_OrderJudgementByAuthorityDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_IndexID", smodel.OrderJudgementByAuthority_IndexID);
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_ID", smodel.OrderJudgementByAuthority_ID);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_ComplaintNumber", String.IsNullOrEmpty(smodel.ComplaintNumber) ? "" : smodel.ComplaintNumber);
            cmd.Parameters.AddWithValue("p_ComplainantName", String.IsNullOrEmpty(smodel.ComplainantName) ? "" : smodel.ComplainantName);
            cmd.Parameters.AddWithValue("p_RespondentName", String.IsNullOrEmpty(smodel.RespondentName) ? "" : smodel.RespondentName);
            cmd.Parameters.AddWithValue("p_Date_of_Decision", smodel.Date_of_Decision == null ? dtvalue : smodel.Date_of_Decision);

            cmd.Parameters.AddWithValue("p_ViewJugdement_BaseUrl", String.IsNullOrEmpty(File_BasicUrl) ? "" : File_BasicUrl); //String.IsNullOrEmpty(smodel.ViewJugdement_BaseUrl) ? "" : smodel.ViewJugdement_BaseUrl);
            cmd.Parameters.AddWithValue("p_ViewJugdement_FilePath", String.IsNullOrEmpty(File_Path) ? "" : File_Path); // String.IsNullOrEmpty(smodel.ViewJugdement_FilePath) ? "" : smodel.ViewJugdement_FilePath);
            cmd.Parameters.AddWithValue("p_ViewJugdement_FileName", String.IsNullOrEmpty(File_Name) ? "" : File_Name); // String.IsNullOrEmpty(smodel.ViewJugdement_FileName) ? "" : smodel.ViewJugdement_FileName);
            cmd.Parameters.AddWithValue("p_ViewJugdement_FileType", String.IsNullOrEmpty(File_Ext) ? "" : File_Ext); // String.IsNullOrEmpty(smodel.ViewJugdement_FileType) ? "" : smodel.ViewJugdement_FileType);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "0" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "NA" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "0" : smodel.C_column);

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

        public List<ClsPrp_AdminDesk_OrderJudgementByAuthority> Display_AdminDesk_OrderJudgementByAuthorityDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_OrderJudgementByAuthority> AdminDeskparameters = new List<ClsPrp_AdminDesk_OrderJudgementByAuthority>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_OrderJudgementByAuthority", con);
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
                       new ClsPrp_AdminDesk_OrderJudgementByAuthority
                       {
                           OrderJudgementByAuthority_IndexID = Convert.ToInt64(dr["OrderJudgementByAuthority_IndexID"]),
                           OrderJudgementByAuthority_ID = Convert.ToInt64(dr["OrderJudgementByAuthority_ID"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                           ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                           ComplainantName = Convert.ToString(dr["ComplainantName"]),
                           RespondentName = Convert.ToString(dr["RespondentName"]),
                           Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),

                           ViewJugdement_BaseUrl = Convert.ToString(dr["ViewJugdement_BaseUrl"]),
                           ViewJugdement_FilePath = Convert.ToString(dr["ViewJugdement_FilePath"]),
                           ViewJugdement_FileName = Convert.ToString(dr["ViewJugdement_FileName"]),
                           ViewJugdement_FileType = Convert.ToString(dr["ViewJugdement_FileType"]),

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

        public List<ClsPrp_AdminDesk_OrderJudgementByAuthority> Display_AdminDesk_OrderJudgementByAuthorityDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_OrderJudgementByAuthority> AdminDeskparameters = new List<ClsPrp_AdminDesk_OrderJudgementByAuthority>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_OrderJudgementAuthorityByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_OrderJudgementByAuthority
                       {
                           OrderJudgementByAuthority_IndexID = Convert.ToInt64(dr["OrderJudgementByAuthority_IndexID"]),
                           OrderJudgementByAuthority_ID = Convert.ToInt64(dr["OrderJudgementByAuthority_ID"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),
                           ComplaintNumber = Convert.ToString(dr["ComplaintNumber"]),
                           ComplainantName = Convert.ToString(dr["ComplainantName"]),
                           RespondentName = Convert.ToString(dr["RespondentName"]),
                           Date_of_Decision = Convert.ToDateTime(dr["Date_of_Decision"]),

                           ViewJugdement_BaseUrl = Convert.ToString(dr["ViewJugdement_BaseUrl"]),
                           ViewJugdement_FilePath = Convert.ToString(dr["ViewJugdement_FilePath"]),
                           ViewJugdement_FileName = Convert.ToString(dr["ViewJugdement_FileName"]),
                           ViewJugdement_FileType = Convert.ToString(dr["ViewJugdement_FileType"]),

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

        public bool Delete_AdminDesk_OrderJudgementByAuthorityDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_OrderJudgementAuthorityByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_OrderJudgementByAuthority_ID", KeyID);

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
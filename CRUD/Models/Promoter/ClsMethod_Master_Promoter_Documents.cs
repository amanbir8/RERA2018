using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.Document
{
    public class ClsMethod_Master_Promoter_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        /// <summary>
        /// Display only for Master ApplicationFee
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Master_Promoter_Documents> Display_Master_Promoter_Documents()
        {
            connection();
            List<Clsprp_Master_Promoter_Documents> MasterPromoterDocuments = new List<Clsprp_Master_Promoter_Documents>();

            MySqlCommand cmd = new MySqlCommand("Select * from tbl_RERA_Master_Promoter_Documents where PromoterDoc_ValidCode=2", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterPromoterDocuments.Add(
                    new Clsprp_Master_Promoter_Documents
                    {

                        PromoterDocMaster_IndexID = Convert.ToInt32(dr["PromoterDocMaster_IndexID"]),
                        PromoterDocMaster_InfoCode = Convert.ToInt32(dr["PromoterDocMaster_InfoCode"]),
                        PromoterDocMaster_InfoName = Convert.ToString(dr["PromoterDocMaster_InfoName"]),
                        PromoterDoc_SetFileSize = Convert.ToString(dr["PromoterDoc_SetFileSize"]),
                        PromoterDoc_SetFileFormat = Convert.ToString(dr["PromoterDoc_SetFileFormat"]),
                        PromoterDoc_SetFilePath = Convert.ToString(dr["PromoterDoc_SetFilePath"]),
                        PromoterDoc_ValidCode = Convert.ToInt32(dr["PromoterDoc_ValidCode"]),
                        PromoterDoc_ValidSubCode = Convert.ToInt32(dr["PromoterDoc_ValidSubCode"]),
                        PromoterDoc_ValidTinySubCode = Convert.ToInt32(dr["PromoterDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterPromoterDocuments;
        }

        public List<Clsprp_Master_Promoter_Documents> Display_Master_Promoter_Documents(Int32 ID)
        {
            connection();
            List<Clsprp_Master_Promoter_Documents> MasterPromoterDocuments = new List<Clsprp_Master_Promoter_Documents>();

            //MySqlCommand cmd = new MySqlCommand("Select * from tbl_RERA_Master_Promoter_Documents where PromoterDocMaster_InfoCode=" + ID+" and IsActive=1", con);
            
            MySqlCommand cmd = new MySqlCommand("Display_Rera_PromoterDocMaster_ByPromoterDocMaster_InfoCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_PromoterDocMaster_InfoCode", ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterPromoterDocuments.Add(
                    new Clsprp_Master_Promoter_Documents
                    {

                        PromoterDocMaster_IndexID = Convert.ToInt32(dr["PromoterDocMaster_IndexID"]),
                        PromoterDocMaster_InfoCode = Convert.ToInt32(dr["PromoterDocMaster_InfoCode"]),
                        PromoterDocMaster_InfoName = Convert.ToString(dr["PromoterDocMaster_InfoName"]),
                        PromoterDoc_SetFileSize = Convert.ToString(dr["PromoterDoc_SetFileSize"]),
                        PromoterDoc_SetFileFormat = Convert.ToString(dr["PromoterDoc_SetFileFormat"]),
                        PromoterDoc_SetFilePath = Convert.ToString(dr["PromoterDoc_SetFilePath"]),
                        PromoterDoc_ValidCode = Convert.ToInt32(dr["PromoterDoc_ValidCode"]),
                        PromoterDoc_ValidSubCode = Convert.ToInt32(dr["PromoterDoc_ValidSubCode"]),
                        PromoterDoc_ValidTinySubCode = Convert.ToInt32(dr["PromoterDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterPromoterDocuments;
        }

        /// <summary>
        /// Display only for Master ApplicationFee
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Master_Promoter_Documents> Display_Master_Promoter_DocumentsByPromoterID(Int64 Promoter_ID)
        {
            connection();
            List<Clsprp_Master_Promoter_Documents> MasterPromoterDocuments = new List<Clsprp_Master_Promoter_Documents>();
            //Select* from tbl_RERA_Master_Promoter_Documents where PromoterDoc_ValidCode = 2
            MySqlCommand cmd = new MySqlCommand("Display_Rera_PromoterDocMaster_ByPromoterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterPromoterDocuments.Add(
                    new Clsprp_Master_Promoter_Documents
                    {

                        PromoterDocMaster_IndexID = Convert.ToInt32(dr["PromoterDocMaster_IndexID"]),
                        PromoterDocMaster_InfoCode = Convert.ToInt32(dr["PromoterDocMaster_InfoCode"]),
                        PromoterDocMaster_InfoName = Convert.ToString(dr["PromoterDocMaster_InfoName"]),
                        PromoterDoc_SetFileSize = Convert.ToString(dr["PromoterDoc_SetFileSize"]),
                        PromoterDoc_SetFileFormat = Convert.ToString(dr["PromoterDoc_SetFileFormat"]),
                        PromoterDoc_SetFilePath = Convert.ToString(dr["PromoterDoc_SetFilePath"]),
                        PromoterDoc_ValidCode = Convert.ToInt32(dr["PromoterDoc_ValidCode"]),
                        PromoterDoc_ValidSubCode = Convert.ToInt32(dr["PromoterDoc_ValidSubCode"]),
                        PromoterDoc_ValidTinySubCode = Convert.ToInt32(dr["PromoterDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterPromoterDocuments;
        }

        /// <summary>
        /// Save Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Add_Master_Promoter_Documents(Clsprp_Master_Promoter_Documents smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Insert_Master_Promoter_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("p_PromoterDocMaster_InfoCode", smodel.PromoterDocMaster_InfoCode);
            cmd.Parameters.AddWithValue("p_PromoterDocMaster_InfoName", smodel.PromoterDocMaster_InfoName);
            cmd.Parameters.AddWithValue("p_PromoterDoc_SetFileSize", smodel.PromoterDoc_SetFileSize);
            cmd.Parameters.AddWithValue("p_PromoterDoc_SetFileFormat", String.IsNullOrEmpty(smodel.PromoterDoc_SetFileFormat) ? "" : smodel.PromoterDoc_SetFileFormat);
            cmd.Parameters.AddWithValue("p_PromoterDoc_SetFilePath", smodel.PromoterDoc_SetFilePath);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ValidCode", smodel.PromoterDoc_ValidCode);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ValidSubCode", smodel.PromoterDoc_ValidSubCode);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ValidTinySubCode", smodel.PromoterDoc_ValidTinySubCode);
            cmd.Parameters.AddWithValue("p_IsGroup", smodel.IsGroup);
            cmd.Parameters.AddWithValue("p_IsMandatory", smodel.IsMandatory);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");
           
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Update_Master_Promoter_Documents(Clsprp_Master_Promoter_Documents smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Master_Promoter_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_PromoterDocMaster_IndexID", smodel.PromoterDocMaster_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterDocMaster_InfoCode", smodel.PromoterDocMaster_InfoCode);
            cmd.Parameters.AddWithValue("p_PromoterDocMaster_InfoName", smodel.PromoterDocMaster_InfoName);
            cmd.Parameters.AddWithValue("p_PromoterDoc_SetFileSize", smodel.PromoterDoc_SetFileSize);
            cmd.Parameters.AddWithValue("p_PromoterDoc_SetFileFormat", String.IsNullOrEmpty(smodel.PromoterDoc_SetFileFormat) ? "" : smodel.PromoterDoc_SetFileFormat);
            cmd.Parameters.AddWithValue("p_PromoterDoc_SetFilePath", smodel.PromoterDoc_SetFilePath);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ValidCode", smodel.PromoterDoc_ValidCode);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ValidSubCode", smodel.PromoterDoc_ValidSubCode);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ValidTinySubCode", smodel.PromoterDoc_ValidTinySubCode);
            cmd.Parameters.AddWithValue("p_IsGroup", smodel.IsGroup);
            cmd.Parameters.AddWithValue("p_IsMandatory", smodel.IsMandatory);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");

            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);


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
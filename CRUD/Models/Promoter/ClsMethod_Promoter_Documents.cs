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
    public class ClsMethod_Promoter_Documents
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        /// <summary>
        /// Display Promoter Documents By PromoterID and PromoterDocID
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Promoter_Documents> Display_Promoter_Documents_ByPromoterDocID(Int64 PromoterId, Int64 PromoterDocID)
        {
            connection();
            List<Clsprp_Promoter_Documents> PromoterDocuments = new List<Clsprp_Promoter_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Documents_ByPromoterDocID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            cmd.Parameters.AddWithValue("p_Promoter_DocID", PromoterDocID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                PromoterDocuments.Add(
                    new Clsprp_Promoter_Documents
                    {
                        PromoterDoc_IndexID = Convert.ToInt64(dr["PromoterDoc_IndexID"]),
                        PromoterDoc_ID = Convert.ToInt64(dr["PromoterDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["PromoterDoc_ID"]),
                        PromoterDoc_InfoCode = Convert.ToInt32(dr["PromoterDoc_ID"]),
                        PromoterDoc_InfoName = Convert.ToString(dr["PromoterDoc_ID"]),
                        PromoterDoc_ReferenceNumber = Convert.ToString(dr["PromoterDoc_ID"]),
                        PromoterDoc_IssueDate = Convert.ToDateTime(dr["PromoterDoc_ID"]),
                        PromoterDoc_FileSize = Convert.ToString(dr["PromoterDoc_ID"]),
                        PromoterDoc_FileFormat = Convert.ToString(dr["PromoterDoc_ID"]),
                        PromoterDoc_FilePath = Convert.ToString(dr["PromoterDoc_ID"]),
                        PromoterDoc_FileName = Convert.ToString(dr["PromoterDoc_ID"]),
                        PromoterDoc_IsGroup = Convert.ToInt32(dr["PromoterDoc_ID"]),
                        Remarks_IfAny = Convert.ToString(dr["PromoterDoc_ID"]),
                        A_column = Convert.ToString(dr["PromoterDoc_ID"]),
                        B_column = Convert.ToString(dr["PromoterDoc_ID"]),
                        C_column = Convert.ToString(dr["PromoterDoc_ID"]),
                        IsActive = Convert.ToInt32(dr["PromoterDoc_ID"]),
                        IsDraft = Convert.ToInt32(dr["PromoterDoc_ID"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return PromoterDocuments;
        }

        /// <summary>
        /// Save Method
        /// </summary>
        /// <param name="smodel"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public bool Add_Promoter_Documents(Clsprp_Promoter_Documents smodel, Int64 oPromoter_ID, String oPromoterDoc_FilePath, String oPromoterDoc_FileName, String oPromoterDoc_FileSize, String oPromoterDoc_FileFormat, Int32 oPromoterDoc_IsGroup)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("Insert_Rera_Promoter_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;                  

            cmd.Parameters.AddWithValue("p_PromoterDoc_ID", (smodel.PromoterDoc_ID == 0) ? 0 : smodel.PromoterDoc_ID);          
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_PromoterDoc_InfoCode", smodel.PromoterDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_PromoterDoc_InfoName", String.IsNullOrEmpty(smodel.PromoterDoc_InfoName) ? "" : smodel.PromoterDoc_InfoName);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ReferenceNumber", smodel.PromoterDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PromoterDoc_IssueDate",  smodel.PromoterDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FileSize", oPromoterDoc_FileSize);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FileFormat",  oPromoterDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FilePath", oPromoterDoc_FilePath);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FileName", oPromoterDoc_FileName);
            cmd.Parameters.AddWithValue("p_PromoterDoc_IsGroup", oPromoterDoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column); 
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column); 
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column); 
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");          
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

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
        public bool Update_Promoter_Documents(Clsprp_Promoter_Documents smodel)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Update_Rera_Promoter_Documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_PromoterDoc_IndexID", smodel.PromoterDoc_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ID", smodel.PromoterDoc_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", smodel.Promoter_ID);
            cmd.Parameters.AddWithValue("p_PromoterDoc_InfoCode", smodel.PromoterDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_PromoterDoc_InfoName", String.IsNullOrEmpty(smodel.PromoterDoc_InfoName) ? "" : smodel.PromoterDoc_InfoName);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ReferenceNumber", smodel.PromoterDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_PromoterDoc_IssueDate", smodel.PromoterDoc_IssueDate);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FileSize", smodel.PromoterDoc_FileSize);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FileFormat", smodel.PromoterDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FilePath", smodel.PromoterDoc_FilePath);
            cmd.Parameters.AddWithValue("p_PromoterDoc_FileName", smodel.PromoterDoc_FileName);
            cmd.Parameters.AddWithValue("p_PromoterDoc_IsGroup", smodel.PromoterDoc_IsGroup);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", "Created_By");
            cmd.Parameters.AddWithValue("p_ModifyBy", "Modify_By");
            cmd.Parameters.AddWithValue("p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_ModifyOn", smodel.ModifyOn);


            MySqlParameter RetParam = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            RetParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RetParam);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            int IntReturn = Convert.ToInt32(RetParam.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Display Promoter Documents By PromoterID
        /// </summary>
        /// <returns></returns>
        public List<Clsprp_Promoter_Documents> Display_Promoter_Documents_PromoterId(Int64 PromoterId)
        {
            connection();
            List<Clsprp_Promoter_Documents> Promoter_Documents_PromoterId = new List<Clsprp_Promoter_Documents>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Documents_PromoterId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_Promoter_Documents
                    {
                        PromoterDoc_IndexID = Convert.ToInt64(dr["PromoterDoc_IndexID"]),
                        PromoterDoc_ID = Convert.ToInt64(dr["PromoterDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        PromoterDoc_InfoCode = Convert.ToInt32(dr["PromoterDoc_InfoCode"]),
                        PromoterDoc_InfoName = Convert.ToString(dr["PromoterDoc_InfoName"]),
                        PromoterDoc_ReferenceNumber = Convert.ToString(dr["PromoterDoc_ReferenceNumber"]),
                        PromoterDoc_IssueDate = Convert.ToDateTime(dr["PromoterDoc_IssueDate"]),
                        PromoterDoc_FileSize = Convert.ToString(dr["PromoterDoc_FileSize"]),
                        PromoterDoc_FileFormat = Convert.ToString(dr["PromoterDoc_FileFormat"]),
                        PromoterDoc_FilePath = Convert.ToString(dr["PromoterDoc_FilePath"]),
                        PromoterDoc_FileName = Convert.ToString(dr["PromoterDoc_FileName"]),
                        PromoterDoc_IsGroup = Convert.ToInt32(dr["PromoterDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return Promoter_Documents_PromoterId;
        }

        /// <summary>
        /// Validation Method - Count and Sum Size
        /// </summary>
        /// <param name="Promoter_ID"></param>
        /// <param name="PromoterDoc_InfoCode"></param>
        /// <returns></returns>
        public Tuple<Int64, Int64> Display_Promoter_Documents_ByDocCodeInfoPromoterID(Int64 Promoter_ID, Int64 PromoterDoc_InfoCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Documents_ByDocCodeInfoPromoterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_PromoterDoc_InfoCode", PromoterDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"] );
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }

        /// <summary>
        /// Delete Promoter Documents By Promoter ID And IndexID
        /// </summary>
        /// <param name="oPromoterDoc_IndexID"></param>
        /// <param name="oPromoterDoc_ID"></param>
        /// <param name="oPromoter_ID"></param>
        /// <returns></returns>
        public bool Delete_Promoter_Documents(Int64? oPromoterDoc_IndexID, Int64? oPromoterDoc_ID, Int64? oPromoter_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Promoter_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_PromoterDoc_IndexID", oPromoterDoc_IndexID);
            cmd.Parameters.AddWithValue("p_PromoterDoc_ID", oPromoterDoc_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Clsprp_Promoter_DocumentsUploadedList> Display_Promoter_DocumentsUploadedList_PromoterId(Int64 PromoterId)
        {
            connection();
            List<Clsprp_Promoter_DocumentsUploadedList> Promoter_Documents_PromoterId = new List<Clsprp_Promoter_DocumentsUploadedList>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_DocumentsUploadedList_PromoterId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new Clsprp_Promoter_DocumentsUploadedList
                    {                        
                        PromoterDoc_InfoCode = Convert.ToInt32(dr["PromoterDoc_InfoCode"]),
                        PromoterDoc_InfoName = Convert.ToString(dr["PromoterDoc_InfoName"]),                        
                    });
            }
            return Promoter_Documents_PromoterId;
        }
    }
}
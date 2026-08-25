using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.PromoterPrint
{
    public class ClsMethod_Print_PromoterDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        
        public List<Clsprp_PrmPromoter_Print_PromoterDocuments> Display_PrmPromoter_Promoter_Documents_PromoterId(Int64 PromoterId)
        {
            connection();
            List<Clsprp_PrmPromoter_Print_PromoterDocuments> Promoter_Documents_PromoterId = new List<Clsprp_PrmPromoter_Print_PromoterDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_Documents_PromoterId_ForPrint", con);
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
                    new Clsprp_PrmPromoter_Print_PromoterDocuments
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
    }
}
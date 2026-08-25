using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_Master_Project_ExtensionFormDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }


        public List<Clsprp_Master_Project_ExtensionFormDocuments> Display_Master_Project_ExtensionFormDocumentsByProjectDocInfoID(Int32 ID)
        {
            connection();
            List<Clsprp_Master_Project_ExtensionFormDocuments> MasterPromoterDocuments = new List<Clsprp_Master_Project_ExtensionFormDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectExtensionFormDocMaster_ByDocMasterCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectDocMaster_InfoCode", ID);          

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterPromoterDocuments.Add(
                    new Clsprp_Master_Project_ExtensionFormDocuments
                    {

                        ProjectDocMaster_IndexID = Convert.ToInt32(dr["ProjectDocMaster_IndexID"]),
                        ProjectDocMaster_InfoCode = Convert.ToInt32(dr["ProjectDocMaster_InfoCode"]),
                        ProjectDocMaster_InfoName = Convert.ToString(dr["ProjectDocMaster_InfoName"]),
                        ProjectDocMaster_RelatedSectionName = Convert.ToString(dr["ProjectDocMaster_RelatedSectionName"]),
                        ProjectDoc_SetFileSize = Convert.ToString(dr["ProjectDoc_SetFileSize"]),
                        ProjectDoc_SetFileFormat = Convert.ToString(dr["ProjectDoc_SetFileFormat"]),
                        ProjectDoc_SetFilePath = Convert.ToString(dr["ProjectDoc_SetFilePath"]),
                        ProjectDoc_ValidCode = Convert.ToInt32(dr["ProjectDoc_ValidCode"]),
                        ProjectDoc_ValidSubCode = Convert.ToInt32(dr["ProjectDoc_ValidSubCode"]),
                        ProjectDoc_ValidTinySubCode = Convert.ToInt32(dr["ProjectDoc_ValidTinySubCode"]),
                        IsGroup = Convert.ToInt32(dr["IsGroup"]),
                        IsMandatory = Convert.ToString(dr["IsMandatory"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"])

                    });
            }
            return MasterPromoterDocuments;
        }

        public List<Clsprp_Master_Project_ExtensionFormDocuments> Display_Master_Project_ExtensionFormDocumentsByProjectIDandPromoterID(Int64 Promoter_ID, Int64 Project_ID)
        {
            connection();
            List<Clsprp_Master_Project_ExtensionFormDocuments> MasterPromoterDocuments = new List<Clsprp_Master_Project_ExtensionFormDocuments>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_ProjectExtensionFormDocMaster_ByProjIDandPromID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
                cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    MasterPromoterDocuments.Add(
                        new Clsprp_Master_Project_ExtensionFormDocuments
                        {
                            ProjectDocMaster_IndexID = Convert.ToInt32(dr["ProjectDocMaster_IndexID"]),
                            ProjectDocMaster_InfoCode = Convert.ToInt32(dr["ProjectDocMaster_InfoCode"]),
                            ProjectDocMaster_InfoName = Convert.ToString(dr["ProjectDocMaster_InfoName"]),
                            ProjectDocMaster_RelatedSectionName = Convert.ToString(dr["ProjectDocMaster_RelatedSectionName"]),
                            ProjectDoc_SetFileSize = Convert.ToString(dr["ProjectDoc_SetFileSize"]),
                            ProjectDoc_SetFileFormat = Convert.ToString(dr["ProjectDoc_SetFileFormat"]),
                            ProjectDoc_SetFilePath = Convert.ToString(dr["ProjectDoc_SetFilePath"]),
                            ProjectDoc_ValidCode = Convert.ToInt32(dr["ProjectDoc_ValidCode"]),
                            ProjectDoc_ValidSubCode = Convert.ToInt32(dr["ProjectDoc_ValidSubCode"]),
                            ProjectDoc_ValidTinySubCode = Convert.ToInt32(dr["ProjectDoc_ValidTinySubCode"]),
                            IsGroup = Convert.ToInt32(dr["IsGroup"]),
                            IsMandatory = Convert.ToString(dr["IsMandatory"]),
                            A_column = Convert.ToString(dr["A_column"]),
                            B_column = Convert.ToString(dr["B_column"]),
                            C_column = Convert.ToString(dr["C_column"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToString(dr["CreatedBy"]),
                            CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                            ModifyBy = Convert.ToString(dr["ModifyBy"]),
                            ModifyOn = Convert.ToDateTime(dr["ModifyOn"])

                        });
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return MasterPromoterDocuments;
        }      
    }
}
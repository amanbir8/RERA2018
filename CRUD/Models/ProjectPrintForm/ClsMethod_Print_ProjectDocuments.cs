using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.ProjectPrint
{
    public class ClsMethod_Print_ProjectDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }       

        public List<ClsPrp_PrmProject_Print_ProjectDocuments> Display_Project_Documents_ByProjectId(Int64? ProjectId)
        {
            connection();
            List<ClsPrp_PrmProject_Print_ProjectDocuments> Promoter_Documents_PromoterId = new List<ClsPrp_PrmProject_Print_ProjectDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_Documents_Project_ID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Promoter_Documents_PromoterId.Add(
                    new ClsPrp_PrmProject_Print_ProjectDocuments
                    {
                        ProjectDoc_IndexID = Convert.ToInt64(dr["ProjectDoc_IndexID"]),
                        ProjectDoc_ID = Convert.ToInt64(dr["ProjectDoc_ID"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        ProjectDoc_InfoCode = Convert.ToInt32(dr["ProjectDoc_InfoCode"]),
                        ProjectDoc_InfoName = Convert.ToString(dr["ProjectDoc_InfoName"]),
                        ProjectDoc_RelatedSectionName = Convert.ToString(dr["ProjectDoc_RelatedSectionName"]),
                        ProjectDoc_ReferenceNumber = Convert.ToString(dr["ProjectDoc_ReferenceNumber"]),
                        ProjectDoc_IssueDate = Convert.ToDateTime(dr["ProjectDoc_IssueDate"]),
                        ProjectDoc_FileSize = Convert.ToString(dr["ProjectDoc_FileSize"]),
                        ProjectDoc_FileFormat = Convert.ToString(dr["ProjectDoc_FileFormat"]),
                        ProjectDoc_FilePath = Convert.ToString(dr["ProjectDoc_FilePath"]),
                        ProjectDoc_FileName = Convert.ToString(dr["ProjectDoc_FileName"]),
                        ProjectDoc_IsGroup = Convert.ToInt32(dr["ProjectDoc_IsGroup"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToString(dr["D_column"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"])

                    });
            }
            return Promoter_Documents_PromoterId;
        }
    }
}
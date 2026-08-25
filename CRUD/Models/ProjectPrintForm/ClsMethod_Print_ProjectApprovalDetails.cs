using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ProjectPrint
{
    public class ClsMethod_Print_ProjectApprovalDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_PrmProject_Print_ProjectApprovalDetails> Display_Project_ApprovalDetails(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_PrmProject_Print_ProjectApprovalDetails> ProjectFivelist1 = new List<ClsPrp_PrmProject_Print_ProjectApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ApprovalDetails_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectApproval_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_PrmProject_Print_ProjectApprovalDetails
                       {
                           ProjectApproval_IndexID = Convert.ToInt64(dr["ProjectApproval_IndexID"]),
                           ProjectApproval_ID = Convert.ToInt64(dr["ProjectApproval_ID"]),
                           ProjectApprovalRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectApprovalRelated_ProjectRegistration_ID"]),
                           DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                           DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                           DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                           DocumentType_Status = Convert.ToString(dr["DocumentType_Status"]),
                           Date_ApplicationPlannedorExpectedReceipt = Convert.ToDateTime(dr["Date_ApplicationPlannedorExpectedReceipt"]),
                           DocumentType_FileSize = Convert.ToString(dr["DocumentType_FileSize"]),
                           DocumentType_FileFormat = Convert.ToString(dr["DocumentType_FileFormat"]),
                           DocumentType_FilePath = Convert.ToString(dr["DocumentType_FilePath"]),
                           DocumentType_FileName = Convert.ToString(dr["DocumentType_FileName"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }        
    }
}
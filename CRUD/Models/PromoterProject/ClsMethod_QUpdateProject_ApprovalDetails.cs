using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.PromoterProject
{
    public class ClsMethod_QUpdateProject_ApprovalDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public bool Add_QUpdateProject_ApprovalDetails(ClsPrp_QUpdateProject_ApprovalDetails smodel, String FileName, String FilePath, String FileExtn, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_quarterlyupdate_ApprovalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectApproval_IndexID", smodel.QUpdateProjectApproval_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectApproval_ID", smodel.QUpdateProjectApproval_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectApproval_IndexID", smodel.Related_ProjectApproval_IndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectApproval_ID", smodel.Related_ProjectApproval_ID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_IsQuarterlyDataValid", 1); //QUP valid data flag
            cmd.Parameters.AddWithValue("p_Related_ApprovalProjectRegistration_ID", smodel.Related_ApprovalProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateApproval_Year", String.IsNullOrEmpty(smodel.QUpdateApproval_Year) ? "0" : smodel.QUpdateApproval_Year);
            cmd.Parameters.AddWithValue("p_QUpdateApproval_QuarterName", String.IsNullOrEmpty(smodel.QUpdateApproval_QuarterName) ? "" : smodel.QUpdateApproval_QuarterName);

            cmd.Parameters.AddWithValue("p_DocumentType_CategoryName", String.IsNullOrEmpty(smodel.DocumentType_CategoryName) ? "" : smodel.DocumentType_CategoryName);
            cmd.Parameters.AddWithValue("p_DocumentType_Code", String.IsNullOrEmpty(smodel.DocumentType_Code) ? "0" : smodel.DocumentType_Code);
            cmd.Parameters.AddWithValue("p_DocumentType_Name", String.IsNullOrEmpty(smodel.DocumentType_Name) ? "" : smodel.DocumentType_Name);
            cmd.Parameters.AddWithValue("p_DocumentType_IfOtherSpecifyName", String.IsNullOrEmpty(smodel.DocumentType_IfOtherSpecifyName) ? "" : smodel.DocumentType_IfOtherSpecifyName);
            cmd.Parameters.AddWithValue("p_DocumentType_Status", String.IsNullOrEmpty(smodel.DocumentType_Status) ? "" : smodel.DocumentType_Status);

            cmd.Parameters.AddWithValue("p_Date_ApplicationPlannedorExpectedReceipt", smodel.Date_ApplicationPlannedorExpectedReceipt == null ? dtvalue : smodel.Date_ApplicationPlannedorExpectedReceipt);
            cmd.Parameters.AddWithValue("p_DocumentType_FileSize", String.IsNullOrEmpty(FileName) ? "FileSize" : "FileSize");
            cmd.Parameters.AddWithValue("p_DocumentType_FileFormat", String.IsNullOrEmpty(FileExtn) ? "" : FileExtn);
            cmd.Parameters.AddWithValue("p_DocumentType_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);
            cmd.Parameters.AddWithValue("p_DocumentType_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == "true" ? "YES" : "NO");
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", UName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", UName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_QUpdateProject_ApprovalDetails(ClsPrp_QUpdateProject_ApprovalDetails smodel, String FileName, String FilePath, String FileExtn, Int64 ProjectID, Int32 QUPQuarterYear, string QUPQuarterName, string UName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_quarterlyupdate_ApprovalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_QUpdateProjectApproval_IndexID", smodel.QUpdateProjectApproval_IndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectApproval_ID", smodel.QUpdateProjectApproval_ID);
            cmd.Parameters.AddWithValue("p_Related_ProjectApproval_IndexID", smodel.Related_ProjectApproval_IndexID);
            cmd.Parameters.AddWithValue("p_Related_ProjectApproval_ID", smodel.Related_ProjectApproval_ID);
            cmd.Parameters.AddWithValue("p_IsQuarterlyData", 2); //QUP data flag
            cmd.Parameters.AddWithValue("p_IsQuarterlyDataValid", 1); //QUP valid data flag
            cmd.Parameters.AddWithValue("p_Related_ApprovalProjectRegistration_ID", smodel.Related_ApprovalProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_QUpdateApproval_Year", String.IsNullOrEmpty(smodel.QUpdateApproval_Year) ? "0" : smodel.QUpdateApproval_Year);
            cmd.Parameters.AddWithValue("p_QUpdateApproval_QuarterName", String.IsNullOrEmpty(smodel.QUpdateApproval_QuarterName) ? "" : smodel.QUpdateApproval_QuarterName);

            cmd.Parameters.AddWithValue("p_DocumentType_CategoryName", String.IsNullOrEmpty(smodel.DocumentType_CategoryName) ? "" : smodel.DocumentType_CategoryName);
            cmd.Parameters.AddWithValue("p_DocumentType_Code", String.IsNullOrEmpty(smodel.DocumentType_Code) ? "0" : smodel.DocumentType_Code);
            cmd.Parameters.AddWithValue("p_DocumentType_Name", String.IsNullOrEmpty(smodel.DocumentType_Name) ? "" : smodel.DocumentType_Name);
            cmd.Parameters.AddWithValue("p_DocumentType_IfOtherSpecifyName", String.IsNullOrEmpty(smodel.DocumentType_IfOtherSpecifyName) ? "" : smodel.DocumentType_IfOtherSpecifyName);
            cmd.Parameters.AddWithValue("p_DocumentType_Status", String.IsNullOrEmpty(smodel.DocumentType_Status) ? "" : smodel.DocumentType_Status);

            cmd.Parameters.AddWithValue("p_Date_ApplicationPlannedorExpectedReceipt", smodel.Date_ApplicationPlannedorExpectedReceipt == null ? dtvalue : smodel.Date_ApplicationPlannedorExpectedReceipt);
            cmd.Parameters.AddWithValue("p_DocumentType_FileSize", String.IsNullOrEmpty(FileName) ? "FileSize" : "FileSize");
            cmd.Parameters.AddWithValue("p_DocumentType_FileFormat", String.IsNullOrEmpty(FileExtn) ? "" : FileExtn);
            cmd.Parameters.AddWithValue("p_DocumentType_FilePath", String.IsNullOrEmpty(FilePath) ? "" : FilePath);
            cmd.Parameters.AddWithValue("p_DocumentType_FileName", String.IsNullOrEmpty(FileName) ? "" : FileName);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == "true" ? "YES" : "NO");
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsLock", smodel.IsLock);
            cmd.Parameters.AddWithValue("p_CreatedBy", UName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", UName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_QUpdateProject_ApprovalDetails> Display_QUpdateProject_ApprovalDetails(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName)
        {
            connection();
            List<ClsPrp_QUpdateProject_ApprovalDetails> Projectlist = new List<ClsPrp_QUpdateProject_ApprovalDetails>();
            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ApprovalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectApproval_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectApproval_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectApproval_QuarterName", QuarterName);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_QUpdateProject_ApprovalDetails
                       {
                           QUpdateProjectApproval_IndexID = Convert.ToInt64(dr["QUpdateProjectApproval_IndexID"]),
                           QUpdateProjectApproval_ID = Convert.ToInt64(dr["QUpdateProjectApproval_ID"]),
                           Related_ProjectApproval_IndexID = Convert.ToInt64(dr["Related_ProjectApproval_IndexID"]),
                           Related_ProjectApproval_ID = Convert.ToInt64(dr["Related_ProjectApproval_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           Related_ApprovalProjectRegistration_ID = Convert.ToInt64(dr["Related_ApprovalProjectRegistration_ID"]),
                           QUpdateApproval_Year = Convert.ToString(dr["QUpdateApproval_Year"]),
                           QUpdateApproval_QuarterName = Convert.ToString(dr["QUpdateApproval_QuarterName"]),

                           DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                           DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                           DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                           DocumentType_IfOtherSpecifyName = Convert.ToString(dr["DocumentType_IfOtherSpecifyName"]),
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
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return Projectlist;
        }

        public List<ClsPrp_QUpdateProject_ApprovalDetails> Display_QUpdateProject_ApprovalDetailsById(Int64 ProjectRegistration_ID, Int32 QuarterYear, string QuarterName, Int64 RelatedProjectApprovalIndexID, Int64 RelatedProjectApprovalID, Int64 QUpdateProjectApprovalIndexID, Int64 QUpdateProjectApprovalID)
        {
            connection();
            List<ClsPrp_QUpdateProject_ApprovalDetails> Projectlist = new List<ClsPrp_QUpdateProject_ApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_ProjectQUpdate_ApprovalDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectApproval_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectApproval_Year", QuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectApproval_QuarterName", QuarterName);
            cmd.Parameters.AddWithValue("p_QUProjectApproval_ApprovalIndexID", QUpdateProjectApprovalIndexID);
            cmd.Parameters.AddWithValue("p_QUProjectApproval_ApprovalID", QUpdateProjectApprovalID);
            cmd.Parameters.AddWithValue("p_RelatedProjectApprovalIndexID", RelatedProjectApprovalIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectApprovalID", RelatedProjectApprovalID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_QUpdateProject_ApprovalDetails
                       {
                           QUpdateProjectApproval_IndexID = Convert.ToInt64(dr["QUpdateProjectApproval_IndexID"]),
                           QUpdateProjectApproval_ID = Convert.ToInt64(dr["QUpdateProjectApproval_ID"]),
                           Related_ProjectApproval_IndexID = Convert.ToInt64(dr["Related_ProjectApproval_IndexID"]),
                           Related_ProjectApproval_ID = Convert.ToInt64(dr["Related_ProjectApproval_ID"]),
                           IsQuarterlyData = Convert.ToInt32(dr["IsQuarterlyData"]),
                           IsQuarterlyDataValid = Convert.ToInt32(dr["IsQuarterlyDataValid"]),
                           Related_ApprovalProjectRegistration_ID = Convert.ToInt64(dr["Related_ApprovalProjectRegistration_ID"]),
                           QUpdateApproval_Year = Convert.ToString(dr["QUpdateApproval_Year"]),
                           QUpdateApproval_QuarterName = Convert.ToString(dr["QUpdateApproval_QuarterName"]),

                           DocumentType_CategoryName = Convert.ToString(dr["DocumentType_CategoryName"]),
                           DocumentType_Code = Convert.ToString(dr["DocumentType_Code"]),
                           DocumentType_Name = Convert.ToString(dr["DocumentType_Name"]),
                           DocumentType_IfOtherSpecifyName = Convert.ToString(dr["DocumentType_IfOtherSpecifyName"]),
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
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return Projectlist;
        }

        public bool Delete_QUpdateProject_ApprovalDetailsById(Int64 ProjectApprovalRelated_ProjectRegistration_ID, Int32 QUPQuarterYear, string QUPQuarterName, Int64 RelatedProjectApprovalIndexID, Int64 RelatedProjectApprovalID, Int64 QUpdateProjectApprovalIndexID, Int64 QUpdateProjectApprovalID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_ProjectQUpdate_ApprovalDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectApproval_ProjectRegistration_ID", ProjectApprovalRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectApproval_Year", QUPQuarterYear);
            cmd.Parameters.AddWithValue("p_ProjectApproval_QuarterName", QUPQuarterName);
            cmd.Parameters.AddWithValue("p_QUpdateProjectApprovalIndexID", QUpdateProjectApprovalIndexID);
            cmd.Parameters.AddWithValue("p_QUpdateProjectApprovalID", QUpdateProjectApprovalID);
            cmd.Parameters.AddWithValue("p_RelatedProjectApprovalIndexID", RelatedProjectApprovalIndexID);
            cmd.Parameters.AddWithValue("p_RelatedProjectApprovalID", RelatedProjectApprovalID);

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
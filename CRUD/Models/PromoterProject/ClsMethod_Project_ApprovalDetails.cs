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
    public class ClsMethod_Project_ApprovalDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public bool Add_Project_ApprovalDetails(ClsPrp_Project_ApprovalDetails smodel,Int64 Project_id, String Photo_Address, String ext)//, string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_ApprovalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            //cmd.Parameters.AddWithValue("p_p_PutProjectLand_ID", smodel.PutProjectLand_ID);
            //cmd.Parameters.AddWithValue("p_p_ProjectApproval_IndexID", smodel.ProjectApproval_IndexID);
            //cmd.Parameters.AddWithValue("p_p_ProjectApproval_ID", smodel.ProjectApproval_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalRelated_ProjectRegistration_ID", smodel.ProjectApprovalRelated_ProjectRegistration_ID);// smodel.ProjectApprovalRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_DocumentType_CategoryName", smodel.DocumentType_CategoryName);
            cmd.Parameters.AddWithValue("p_p_DocumentType_Code", smodel.DocumentType_Code);
            cmd.Parameters.AddWithValue("p_p_DocumentType_Name", smodel.DocumentType_Name);
            cmd.Parameters.AddWithValue("p_p_DocumentType_Status", smodel.DocumentType_Status);
            cmd.Parameters.AddWithValue("p_p_Date_ApplicationPlannedorExpectedReceipt", smodel.Date_ApplicationPlannedorExpectedReceipt);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FileSize", String.IsNullOrEmpty(Photo_Address) ? "FileSize" : "FileSize");// Photo_Address);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FileFormat", String.IsNullOrEmpty(Photo_Address) ? "FileFormat" : "FileFormat");// Photo_Address);// smodel.DocumentType_FileFormat);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FilePath", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);// smodel.DocumentType_FilePath);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FileName", String.IsNullOrEmpty(ext) ? "" : ext); //smodel.DocumentType_FileName);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column); 
            cmd.Parameters.AddWithValue("p_p_B_column", ""); //smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", ""); //smodel.C_column);

            // cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", "1");


            cmd.Parameters.AddWithValue("p_p_CreatedBy", "Created_By"); //smodel.Created_By);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "Modify_By");

            //MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.BigInt);
            //AppPar.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            //con.Close();
            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_Project_ApprovalDetails(ClsPrp_Project_ApprovalDetails smodel, Int64 Project_id, String Photo_Address, String ext)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_Project_ApprovalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectApproval_IndexID", smodel.ProjectApproval_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectApproval_ID", smodel.ProjectApproval_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalRelated_ProjectRegistration_ID", smodel.ProjectApprovalRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_DocumentType_CategoryName", smodel.DocumentType_CategoryName);
            cmd.Parameters.AddWithValue("p_p_DocumentType_Code", smodel.DocumentType_Code);
            cmd.Parameters.AddWithValue("p_p_DocumentType_Name", smodel.DocumentType_Name);
            cmd.Parameters.AddWithValue("p_p_DocumentType_Status", smodel.DocumentType_Status);
            cmd.Parameters.AddWithValue("p_p_Date_ApplicationPlannedorExpectedReceipt", smodel.Date_ApplicationPlannedorExpectedReceipt);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FileSize", String.IsNullOrEmpty(Photo_Address) ? "FileSize" : "FileSize");// Photo_Address);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FileFormat", String.IsNullOrEmpty(Photo_Address) ? "FileFormat" : "FileFormat");// Photo_Address);// smodel.DocumentType_FileFormat);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FilePath", String.IsNullOrEmpty(Photo_Address) ? "" : Photo_Address);// smodel.DocumentType_FilePath);
            cmd.Parameters.AddWithValue("p_p_DocumentType_FileName", String.IsNullOrEmpty(ext) ? "" : ext); //smodel.DocumentType_FileName);
            cmd.Parameters.AddWithValue("p_p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", "");
            cmd.Parameters.AddWithValue("p_p_C_column", "");
            // cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", "CreatedBy");
            //cmd.Parameters.AddWithValue("p_p_CreatedOn", "CreatedOn");
            cmd.Parameters.AddWithValue("p_p_ModifyBy", "p_ModifyBy");
            // cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);
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

        public List<ClsPrp_Project_ApprovalDetails> Display_Project_ApprovalDetails(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_ApprovalDetails> ProjectFivelist1 = new List<ClsPrp_Project_ApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ApprovalDetails", con);
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
                       new ClsPrp_Project_ApprovalDetails
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


        public List<ClsPrp_Project_ApprovalDetails> Display_Project_ApprovalDetailsById(Int64 ProjectRegistration_ID, Int64 ProjectApproval_IndexID)
        {
            connection();

            List<ClsPrp_Project_ApprovalDetails> ProjectFivelist1 = new List<ClsPrp_Project_ApprovalDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ApprovalDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectApproval_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ProjectApproval_IndexID", ProjectApproval_IndexID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ApprovalDetails
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

        //Delete_Project_ApprovalDetailsById(ProjectApprovalRelated_ProjectRegistration_ID, ProjectApproval_IndexID))
        public bool Delete_Project_ApprovalDetailsById(Int64 ProjectApprovalRelated_ProjectRegistration_ID, Int64 ProjectApproval_IndexID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_RERA_Project_ApprovalDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_p_ProjectApproval_ProjectReg_ID", ProjectApprovalRelated_ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_p_ProjectApproval_IndexID", ProjectApproval_IndexID);
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
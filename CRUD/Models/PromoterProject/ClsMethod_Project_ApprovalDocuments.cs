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
    public class ClsMethod_Project_ApprovalDocuments
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // **************** ADD Organization Experienced Promoter DETAIL *********************

        public void Add_Project_ApprovalDetails(ClsPrp_Project_ApprovalDocuments smodel, string PANaddress, string OrgCertaddress, string Image_FileName, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Master_Project_ApprovalDocuments", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDocMaster_IndexID", smodel.ProjectApprovalDocMaster_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDocMaster_InfoCode", smodel.ProjectApprovalDocMaster_InfoCode);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDocMaster_InfoName", smodel.ProjectApprovalDocMaster_InfoName);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_SetFileSize", smodel.ProjectApprovalDoc_SetFileSize);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_SetFileFormat", smodel.ProjectApprovalDoc_SetFileFormat);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_SetFilePath", smodel.ProjectApprovalDoc_SetFilePath);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_ValidCode", smodel.ProjectApprovalDoc_ValidCode);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_ValidSubCode", smodel.ProjectApprovalDoc_ValidSubCode);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_ValidTinySubCode", smodel.ProjectApprovalDoc_ValidTinySubCode);
            cmd.Parameters.AddWithValue("p_p_IsGroup", smodel.IsGroup);
            cmd.Parameters.AddWithValue("p_p_IsMandatory", smodel.IsMandatory);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);

            MySqlParameter AppPar = new MySqlParameter("p_Get_AppId", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            //Int64 AppId = Convert.ToInt64(AppPar.Value);
            //con.Close();
            //return AppId;
        }

        public bool Update_Project_ApprovalDetails(ClsPrp_Project_ApprovalDocuments smodel, string PANaddress, string OrgCertaddress, string Image_FileName, Int64 Application_id, string UID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_ProjectType_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDocMaster_IndexID", smodel.ProjectApprovalDocMaster_IndexID);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDocMaster_InfoCode", smodel.ProjectApprovalDocMaster_InfoCode);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDocMaster_InfoName", smodel.ProjectApprovalDocMaster_InfoName);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_SetFileSize", smodel.ProjectApprovalDoc_SetFileSize);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_SetFileFormat", smodel.ProjectApprovalDoc_SetFileFormat);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_SetFilePath", smodel.ProjectApprovalDoc_SetFilePath);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_ValidCode", smodel.ProjectApprovalDoc_ValidCode);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_ValidSubCode", smodel.ProjectApprovalDoc_ValidSubCode);
            cmd.Parameters.AddWithValue("p_p_ProjectApprovalDoc_ValidTinySubCode", smodel.ProjectApprovalDoc_ValidTinySubCode);
            cmd.Parameters.AddWithValue("p_p_IsGroup", smodel.IsGroup);
            cmd.Parameters.AddWithValue("p_p_IsMandatory", smodel.IsMandatory);
            cmd.Parameters.AddWithValue("p_p_A_column", smodel.A_column);
            cmd.Parameters.AddWithValue("p_p_B_column", smodel.B_column);
            cmd.Parameters.AddWithValue("p_p_C_column", smodel.C_column);
            cmd.Parameters.AddWithValue("p_p_IsActive", smodel.IsActive);
            cmd.Parameters.AddWithValue("p_p_CreatedBy", smodel.CreatedBy);
            cmd.Parameters.AddWithValue("p_p_CreatedOn", smodel.CreatedOn);
            cmd.Parameters.AddWithValue("p_p_ModifyBy", smodel.ModifyBy);
            cmd.Parameters.AddWithValue("p_p_ModifyOn", smodel.ModifyOn);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_Project_ApprovalDocuments> Display_Project_ApprovalDetails(Int64 ProjectRegistration_ID)
        {
            connection();

            List<ClsPrp_Project_ApprovalDocuments> ProjectFivelist1 = new List<ClsPrp_Project_ApprovalDocuments>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Promoter_OtherMemberDetailsByApplicationID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Project_ApprovalDocuments
                       {
                           ProjectApprovalDocMaster_IndexID = Convert.ToInt64(dr["ProjectApprovalDocMaster_IndexID"]),
                           ProjectApprovalDocMaster_InfoCode = Convert.ToInt64(dr["ProjectApprovalDocMaster_InfoCode"]),
                           ProjectApprovalDocMaster_InfoName = Convert.ToString(dr["ProjectApprovalDocMaster_InfoName"]),
                           ProjectApprovalDoc_SetFileSize = Convert.ToString(dr["ProjectApprovalDoc_SetFileSize"]),
                           ProjectApprovalDoc_SetFileFormat = Convert.ToString(dr["ProjectApprovalDoc_SetFileFormat"]),
                           ProjectApprovalDoc_SetFilePath = Convert.ToString(dr["ProjectApprovalDoc_SetFilePath"]),
                           ProjectApprovalDoc_ValidCode = Convert.ToInt32(dr["ProjectApprovalDoc_ValidCode"]),
                           ProjectApprovalDoc_ValidSubCode = Convert.ToInt32(dr["ProjectApprovalDoc_ValidSubCode"]),
                           ProjectApprovalDoc_ValidTinySubCode = Convert.ToInt32(dr["ProjectApprovalDoc_ValidTinySubCode"]),
                           IsGroup = Convert.ToInt32(dr["IsGroup"]),
                           IsMandatory = Convert.ToString(dr["IsMandatory"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                         
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           //   CreatedOn = Convert.ToString(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           // ModifyOn = Convert.ToString(dr["ModifyOn"]),

                       });
            }
            return ProjectFivelist1;
        }

    }
}
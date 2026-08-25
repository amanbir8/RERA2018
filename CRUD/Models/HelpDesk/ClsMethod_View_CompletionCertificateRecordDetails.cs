using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.HelpdeskControlPanel;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_CompletionCertificateRecordDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_ProjectCompletionCertificate> Display_Project_CompletionCertificateRecordDetails_ByID(Int64 pRelatedProjectID, Int64 pRelatedPromoterID, string pRegistrationNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectCompletionCertificate> ProjectList = new List<ClsPrp_ControlPanel_View_ProjectCompletionCertificate>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_CompletionCertificateRecords_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RelatedProjectID", pRelatedProjectID);
            cmd.Parameters.AddWithValue("p_RelatedPromoterID", pRelatedPromoterID);
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserNam", pUserNam);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_ControlPanel_View_ProjectCompletionCertificate
                       {
                           ProjectCompletion_IndexID = Convert.ToInt64(dr["ProjectCompletion_IndexID"]),
                           ProjectCompletion_ID = Convert.ToInt64(dr["ProjectCompletion_ID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                           RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                           ProjectDiaryNumber = Convert.ToString(dr["ProjectDiaryNumber"]),
                           ExtensionRegdDiaryNumber = Convert.ToString(dr["ExtensionRegdDiaryNumber"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           DName = Convert.ToString(dr["DName"]),
                           ProjectType = Convert.ToString(dr["ProjectType"]),

                           PCC_InfoDetails = Convert.ToString(dr["PCC_InfoDetails"]),
                           PCC_IssueAuthority = Convert.ToString(dr["PCC_IssueAuthority"]),
                           PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                           PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                           PCC_CertificateType = Convert.ToString(dr["PCC_CertificateType"]),
                           PCC_CertificateStatus = Convert.ToString(dr["PCC_CertificateStatus"]),
                           PCC_ReceiptDatePlanned_DateExpected = Convert.ToDateTime(dr["PCC_ReceiptDatePlanned_DateExpected"]),
                           PCC_ReciptType = Convert.ToString(dr["PCC_ReciptType"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Extra5 = Convert.ToString(dr["Extra5"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsApproval = Convert.ToInt32(dr["IsApproval"]),
                           IsConditional = Convert.ToInt32(dr["IsConditional"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                       });
            }
            return ProjectList;
        }

    }
}
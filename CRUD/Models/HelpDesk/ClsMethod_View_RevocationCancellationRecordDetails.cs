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
    public class ClsMethod_View_RevocationCancellationRecordDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_ProjectRevocationCancellation> Display_Project_RevocationCancellationRecordDetails_ByID(Int64 pRelatedProjectID, Int64 pRelatedPromoterID, string pRegistrationNumber, string pUserNam, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectRevocationCancellation> ProjectList = new List<ClsPrp_ControlPanel_View_ProjectRevocationCancellation>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RevocationCancellationRecords_ForDesk", con);
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
                       new ClsPrp_ControlPanel_View_ProjectRevocationCancellation
                       {
                           Revoke_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Revoke_RegDiaryNumber_IndexID"]),
                           Revoke_RegDiaryNumber_ID = Convert.ToInt64(dr["Revoke_RegDiaryNumber_ID"]),
                           Revoke_RegDiaryNumber_Name = Convert.ToString(dr["Revoke_RegDiaryNumber_Name"]),
                           Revoke_RegDiaryNumber_NameYear = Convert.ToString(dr["Revoke_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           ExtnRegDiaryNumber_Name = Convert.ToString(dr["ExtnRegDiaryNumber_Name"]),
                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                           IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                           RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                           DName = Convert.ToString(dr["DName"]),
                           ProjectType = Convert.ToString(dr["ProjectType"]),
                           Revoke_InfoDetails = Convert.ToString(dr["Revoke_InfoDetails"]),
                           Revoke_ReferenceName = Convert.ToString(dr["Revoke_ReferenceName"]),
                           Revoke_ReferenceDate = Convert.ToDateTime(dr["Revoke_ReferenceDate"]),
                           Revoke_Category = Convert.ToString(dr["Revoke_Category"]),
                           Revoke_ReciptType = Convert.ToString(dr["Revoke_ReciptType"]),
                           Revoke_Reasons = Convert.ToString(dr["Revoke_Reasons"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
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
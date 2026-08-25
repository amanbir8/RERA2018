using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_CompletionCertificateProjectNumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Add Completion Certificate
        public List<ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber> Display_AuthDesk_ProjectCompletionRegistrationNumber_ByIDandDNumber(Int64 ProjectId, Int64 PromoterId, string PccDiaryNumber)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber> ProjectList = new List<ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_RERAnumberCompletionPCC_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectId);
            cmd.Parameters.AddWithValue("p_Promoter_ID", PromoterId);
            cmd.Parameters.AddWithValue("p_PCC_DiaryNumber", PccDiaryNumber);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DateTime dtvalue = new DateTime(0001, 1, 1);

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                    new ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber
                    {
                        PCC_IndexID = Convert.ToInt64(dr["PCC_IndexID"]),
                        PCC_ID = Convert.ToInt64(dr["PCC_ID"]),
                        ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                        Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["Project_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),
                        RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["ProjectAddressDistrict"]),
                        DName = Convert.ToString(dr["DName"]),
                        PCC_InfoDetails = Convert.ToString(dr["PCC_InfoDetails"]),
                        PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                        PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                        PCC_CertificateStatus = Convert.ToString(dr["PCC_CertificateStatus"]),
                        PCC_ReciptType = Convert.ToString(dr["PCC_ReciptType"]),
                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        Extra1 = dr["Extra1"] == null ? dtvalue : Convert.ToDateTime(dr["Extra1"]),
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
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return ProjectList;
        }
       
        public bool Add_LDR_ProjectCompletionRegistrationNumber_DiaryNumber(ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber smodel, string User_Name, Int64 oProject_ID, Int64 oPromoter_ID, string oProjectDiaryNumber, string oPCCDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("insert_Rera_Project_PCC_AuthorityDesk_RERAnumberDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);
            
            #region Parameters
            cmd.Parameters.AddWithValue("p_PCC_IndexID", (smodel.PCC_IndexID == 0) ? 0 : smodel.PCC_IndexID);
            cmd.Parameters.AddWithValue("p_PCC_ID", (smodel.PCC_ID == 0) ? 0 : smodel.PCC_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", oProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? string.Empty : smodel.User_ID);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate == null ? dtvalue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate == null ? dtvalue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);

            cmd.Parameters.AddWithValue("p_PCC_InfoDetails", String.IsNullOrEmpty(smodel.PCC_InfoDetails) ? string.Empty : smodel.PCC_InfoDetails);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceName", String.IsNullOrEmpty(smodel.PCC_ReferenceName) ? string.Empty : smodel.PCC_ReferenceName);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceDate", smodel.PCC_ReferenceDate == null ? dtvalue : smodel.PCC_ReferenceDate);
            cmd.Parameters.AddWithValue("p_PCC_CertificateStatus", String.IsNullOrEmpty(smodel.PCC_CertificateStatus) ? string.Empty : smodel.PCC_CertificateStatus);
            cmd.Parameters.AddWithValue("p_PCC_ReciptType", String.IsNullOrEmpty(smodel.PCC_ReciptType) ? string.Empty : smodel.PCC_ReciptType);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1 == null ? dtvalue : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", oPCCDiaryNumber);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", (smodel.IsDraftEvaluation == 0) ? 0 : smodel.IsDraftEvaluation);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
      
        public bool Update_LDR_ProjectCompletionRegistrationNumber_DiaryNumber(ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber smodel, string User_Name, Int64 oProject_ID, Int64 oPromoter_ID, string oProjectDiaryNumber, string oPCCDiaryNumber)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_Rera_Project_PCC_AuthorityDesk_RERAnumberDNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_PCC_IndexID", (smodel.PCC_IndexID == 0) ? 0 : smodel.PCC_IndexID);
            cmd.Parameters.AddWithValue("p_PCC_ID", (smodel.PCC_ID == 0) ? 0 : smodel.PCC_ID);
            cmd.Parameters.AddWithValue("p_ProjectRegDiaryNumber_Name", oProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_Promoter_ID", oPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", oProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(smodel.User_ID) ? string.Empty : smodel.User_ID);
            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate == null ? dtvalue : smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate == null ? dtvalue : smodel.RERAnumberRegUptoDate);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);

            cmd.Parameters.AddWithValue("p_PCC_InfoDetails", String.IsNullOrEmpty(smodel.PCC_InfoDetails) ? string.Empty : smodel.PCC_InfoDetails);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceName", String.IsNullOrEmpty(smodel.PCC_ReferenceName) ? string.Empty : smodel.PCC_ReferenceName);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceDate", smodel.PCC_ReferenceDate == null ? dtvalue : smodel.PCC_ReferenceDate);
            cmd.Parameters.AddWithValue("p_PCC_CertificateStatus", String.IsNullOrEmpty(smodel.PCC_CertificateStatus) ? string.Empty : smodel.PCC_CertificateStatus);
            cmd.Parameters.AddWithValue("p_PCC_ReciptType", String.IsNullOrEmpty(smodel.PCC_ReciptType) ? string.Empty : smodel.PCC_ReciptType);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", smodel.Extra1 == null ? dtvalue : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", oPCCDiaryNumber);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 1);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 1);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", (smodel.IsDraftEvaluation == 0) ? 0 : smodel.IsDraftEvaluation);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", (smodel.IsDraftSecMember == 0) ? 0 : smodel.IsDraftSecMember);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
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

    }
}
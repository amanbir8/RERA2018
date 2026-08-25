using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsMethod_View_CP_ProjectCompletionCertificate
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        //Register PCC
        public List<ClsPrp_ControlPanel_View_ProjectCompletionCertificate> Display_CP_ProjectRegistrationCompletionDetails_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectCompletionCertificate> CPregistrationList = new List<ClsPrp_ControlPanel_View_ProjectCompletionCertificate>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectRegistrationCompletionDetails_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPregistrationList.Add(
                    new ClsPrp_ControlPanel_View_ProjectCompletionCertificate
                    {
                        Promoter_ID = Convert.ToInt64(dr["prmPromoter_ID"]),
                        Project_ID = Convert.ToInt64(dr["prmProject_ID"]),
                        RERAnumberRegistration = Convert.ToString(dr["prmRERAnumberRegistration"]),
                        RERAnumberIssueDate = Convert.ToDateTime(dr["prmRERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberRegUptoDate"]),

                        IsExtensionRegistration = Convert.ToInt32(dr["prmIsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["prmRERAnumberExtensionRegUptoDate"]),
                        ProjectDiaryNumber = Convert.ToString(dr["prmProjectDiaryNumber"]),
                        ExtensionRegdDiaryNumber = Convert.ToString(dr["prmExtensionRegdDiaryNumber"]),

                        ProjectName = Convert.ToString(dr["prmProjectName"]),
                        PromoterName = Convert.ToString(dr["prmPromoterName"]),
                        ProjectAddressDistrict = Convert.ToString(dr["prmProjectAddressDistrict"]),
                        DName = Convert.ToString(dr["prmDName"]),
                        ProjectType = Convert.ToString(dr["prmProjectType"]),
                    });
            }
            return CPregistrationList;
        }

        public Tuple<bool, string> Add_ProjectCompletionCertificate_DiaryNumber(ClsPrp_ControlPanel_View_ProjectCompletionCertificate smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_project_completioncertificate_regdiarynumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectCompletion_IndexID", (smodel.ProjectCompletion_IndexID == 0) ? 0 : smodel.ProjectCompletion_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_ID", (smodel.ProjectCompletion_ID == 0) ? 0 : smodel.ProjectCompletion_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", sPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", sProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);

            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", sProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtensionRegdDiaryNumber", String.IsNullOrEmpty(smodel.ExtensionRegdDiaryNumber) ? string.Empty : smodel.ExtensionRegdDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);

            cmd.Parameters.AddWithValue("p_PCC_InfoDetails", String.IsNullOrEmpty(smodel.PCC_InfoDetails) ? string.Empty : smodel.PCC_InfoDetails);
            cmd.Parameters.AddWithValue("p_PCC_IssueAuthority", String.IsNullOrEmpty(smodel.PCC_IssueAuthority) ? string.Empty : smodel.PCC_IssueAuthority);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceName", String.IsNullOrEmpty(smodel.PCC_ReferenceName) ? string.Empty : smodel.PCC_ReferenceName);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceDate", smodel.PCC_ReferenceDate);
            cmd.Parameters.AddWithValue("p_PCC_CertificateType", String.IsNullOrEmpty(smodel.PCC_CertificateType) ? string.Empty : smodel.PCC_CertificateType);
            cmd.Parameters.AddWithValue("p_PCC_CertificateStatus", String.IsNullOrEmpty(smodel.PCC_CertificateStatus) ? string.Empty : smodel.PCC_CertificateStatus);
            cmd.Parameters.AddWithValue("p_PCC_ReceiptDatePlanned_DateExpected", smodel.PCC_ReceiptDatePlanned_DateExpected.HasValue ? smodel.PCC_ReceiptDatePlanned_DateExpected : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PCC_ReciptType", String.IsNullOrEmpty(smodel.PCC_ReciptType) ? string.Empty : smodel.PCC_ReciptType);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_Extra5", String.IsNullOrEmpty(smodel.Extra5) ? string.Empty : smodel.Extra5);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", (smodel.IsApproval == 0) ? 0 : smodel.IsApproval);
            cmd.Parameters.AddWithValue("p_IsConditional", (smodel.IsConditional == 0) ? 0 : smodel.IsConditional);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();            
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);            
        }

        public Tuple<bool, string> Update_ProjectCompletionCertificate_DiaryNumber(ClsPrp_ControlPanel_View_ProjectCompletionCertificate smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_project_completioncertificatedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectCompletion_IndexID", (smodel.ProjectCompletion_IndexID == 0) ? 0 : smodel.ProjectCompletion_IndexID);
            cmd.Parameters.AddWithValue("p_ProjectCompletion_ID", (smodel.ProjectCompletion_ID == 0) ? 0 : smodel.ProjectCompletion_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", sPromoter_ID);
            cmd.Parameters.AddWithValue("p_Project_ID", sProject_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);

            cmd.Parameters.AddWithValue("p_RERAnumberRegistration", String.IsNullOrEmpty(smodel.RERAnumberRegistration) ? string.Empty : smodel.RERAnumberRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberIssueDate", smodel.RERAnumberIssueDate);
            cmd.Parameters.AddWithValue("p_RERAnumberRegUptoDate", smodel.RERAnumberRegUptoDate);

            cmd.Parameters.AddWithValue("p_IsExtensionRegistration", (smodel.IsExtensionRegistration == 0) ? 0 : smodel.IsExtensionRegistration);
            cmd.Parameters.AddWithValue("p_RERAnumberExtensionRegUptoDate", (smodel.IsExtensionRegistration == 0) ? DateTime.MinValue : smodel.RERAnumberExtensionRegUptoDate);

            cmd.Parameters.AddWithValue("p_ProjectDiaryNumber", sProjectDiaryNumber);
            cmd.Parameters.AddWithValue("p_ExtensionRegdDiaryNumber", String.IsNullOrEmpty(smodel.ExtensionRegdDiaryNumber) ? string.Empty : smodel.ExtensionRegdDiaryNumber);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? string.Empty : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? string.Empty : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_ProjectAddressDistrict", String.IsNullOrEmpty(smodel.ProjectAddressDistrict) ? string.Empty : smodel.ProjectAddressDistrict);
            cmd.Parameters.AddWithValue("p_DName", String.IsNullOrEmpty(smodel.DName) ? string.Empty : smodel.DName);
            cmd.Parameters.AddWithValue("p_ProjectType", String.IsNullOrEmpty(smodel.ProjectType) ? string.Empty : smodel.ProjectType);

            cmd.Parameters.AddWithValue("p_PCC_InfoDetails", String.IsNullOrEmpty(smodel.PCC_InfoDetails) ? string.Empty : smodel.PCC_InfoDetails);
            cmd.Parameters.AddWithValue("p_PCC_IssueAuthority", String.IsNullOrEmpty(smodel.PCC_IssueAuthority) ? string.Empty : smodel.PCC_IssueAuthority);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceName", String.IsNullOrEmpty(smodel.PCC_ReferenceName) ? string.Empty : smodel.PCC_ReferenceName);
            cmd.Parameters.AddWithValue("p_PCC_ReferenceDate", smodel.PCC_ReferenceDate);
            cmd.Parameters.AddWithValue("p_PCC_CertificateType", String.IsNullOrEmpty(smodel.PCC_CertificateType) ? string.Empty : smodel.PCC_CertificateType);
            cmd.Parameters.AddWithValue("p_PCC_CertificateStatus", String.IsNullOrEmpty(smodel.PCC_CertificateStatus) ? string.Empty : smodel.PCC_CertificateStatus);
            cmd.Parameters.AddWithValue("p_PCC_ReceiptDatePlanned_DateExpected", smodel.PCC_ReceiptDatePlanned_DateExpected.HasValue ? smodel.PCC_ReceiptDatePlanned_DateExpected : DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_PCC_ReciptType", String.IsNullOrEmpty(smodel.PCC_ReciptType) ? string.Empty : smodel.PCC_ReciptType);

            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);
            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);
            cmd.Parameters.AddWithValue("p_Extra4", String.IsNullOrEmpty(smodel.Extra4) ? string.Empty : smodel.Extra4);
            cmd.Parameters.AddWithValue("p_Extra5", String.IsNullOrEmpty(smodel.Extra5) ? string.Empty : smodel.Extra5);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", (smodel.IsApproval == 0) ? 0 : smodel.IsApproval);
            cmd.Parameters.AddWithValue("p_IsConditional", (smodel.IsConditional == 0) ? 0 : smodel.IsConditional);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", User_Name);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_Name);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.VarChar, 120);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();            
            string AppId = string.Empty;
            AppId = Convert.ToString(AppPar.Value);
            con.Close();
            cmd.Dispose();

            if (i >= 1)
                return Tuple.Create(false, AppId);
            else
                return Tuple.Create(true, AppId);
        }

        //Status of PCC
        public List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> Display_CP_ProjectCompletionStatusDetails_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails> CPstatusList = new List<ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_ProjectCompletionCertificateStatus_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegistrationNumber", pRegistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRole", pUserRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CPstatusList.Add(
                    new ClsPrp_ControlPanel_View_ProjectCompletionStatusDetails
                    {
                        ProjectCompletionEventAction_ID = Convert.ToInt64(dr["ProjectCompletionEventAction_ID"]),
                        EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                        EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                        EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                        Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                        Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                        Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                        RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                        EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                        AssignedTo = Convert.ToString(dr["AssignedTo"]),
                        Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                        Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                        IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
                        ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                        RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                        RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),
                        IsExtensionRegistration = Convert.ToInt32(dr["IsExtensionRegistration"]),
                        RERAnumberExtensionRegUptoDate = Convert.ToDateTime(dr["RERAnumberExtensionRegUptoDate"]),
                        ProjectName = Convert.ToString(dr["ProjectName"]),
                        PromoterName = Convert.ToString(dr["PromoterName"]),
                        PCC_ReferenceName = Convert.ToString(dr["PCC_ReferenceName"]),
                        PCC_ReferenceDate = Convert.ToDateTime(dr["PCC_ReferenceDate"]),
                        RERAnumberRegistration_Input = Convert.ToString(dr["RERAnumberRegistration_Input"]),
                    });
            }
            return CPstatusList;
        }
    }
}
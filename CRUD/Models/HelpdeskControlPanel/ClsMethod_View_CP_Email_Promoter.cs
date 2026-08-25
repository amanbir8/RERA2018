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
    public class ClsMethod_View_CP_Email_Promoter
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_Email_Promoter> Display_CP_ProjectRegisteredPromoterDetailsForEmailAddress_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Email_Promoter> CPregistrationList = new List<ClsPrp_ControlPanel_View_Email_Promoter>();

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
                    new ClsPrp_ControlPanel_View_Email_Promoter
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

        public List<ClsPrp_ControlPanel_View_Email_Promoter> Display_CP_EmailsAll_ForRegisteredPromoters_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Email_Promoter> CPregistrationList = new List<ClsPrp_ControlPanel_View_Email_Promoter>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_EmailsPromoterAllDetails_ByID", con);
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
                    new ClsPrp_ControlPanel_View_Email_Promoter
                    {
                        AdditionalPromoterEmail_IndexID = Convert.ToInt64(dr["AdditionalPromoterEmail_IndexID"]),
                        AdditionalPromoterEmail_ID = Convert.ToInt64(dr["AdditionalPromoterEmail_ID"]),
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
                        AE_ContactName = Convert.ToString(dr["AE_ContactName"]),
                        AE_Designation = Convert.ToString(dr["AE_Designation"]),
                        AE_ReferenceName = Convert.ToString(dr["AE_ReferenceName"]),
                        AE_ReferenceDate = Convert.ToDateTime(dr["AE_ReferenceDate"]),
                        AE_EmailType = Convert.ToString(dr["AE_EmailType"]),
                        AE_EmailAddress = Convert.ToString(dr["AE_EmailAddress"]),

                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),                        

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsApproval = Convert.ToInt32(dr["IsApproval"]),
                        IsVerified = Convert.ToInt32(dr["IsVerified"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return CPregistrationList;
        }

        public Int32 Update_LockUnlockHandler_CP_EmailsAll_ForRegisteredPromotersByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string RelatedCode, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_promoteremailaddressByIndex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_InputRequestID", RequestID);
            cmd.Parameters.AddWithValue("p_InputRefIndexID", RelatedRefIndexID);
            cmd.Parameters.AddWithValue("p_InputRefID", RelatedRefID);
            cmd.Parameters.AddWithValue("p_InputCode", RelatedCode);
            cmd.Parameters.AddWithValue("p_InputLockUnlockValue", LockUnlockCode);
            cmd.Parameters.AddWithValue("p_ByUserName", ByUserName);
            cmd.Parameters.AddWithValue("p_ByUserID", ByUserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedPVMsg", RelatedPVMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsFlagReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

        public Tuple<bool, string> Add_ProjectRegisteredPromoter_EmailAddress(ClsPrp_ControlPanel_View_Email_Promoter smodel, string User_Name, Int64 sProject_ID, Int64 sPromoter_ID, string sProjectDiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_CP_tbl_rera_project_additionalemailaddress_promoter", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionalPromoterEmail_IndexID", (smodel.AdditionalPromoterEmail_IndexID == 0) ? 0 : smodel.AdditionalPromoterEmail_IndexID);
            cmd.Parameters.AddWithValue("p_AdditionalPromoterEmail_ID", (smodel.AdditionalPromoterEmail_ID == 0) ? 0 : smodel.AdditionalPromoterEmail_ID);
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
            
            cmd.Parameters.AddWithValue("p_AE_ContactName", String.IsNullOrEmpty(smodel.AE_ContactName) ? string.Empty : smodel.AE_ContactName);
            cmd.Parameters.AddWithValue("p_AE_Designation", String.IsNullOrEmpty(smodel.AE_Designation) ? string.Empty : smodel.AE_Designation);
            cmd.Parameters.AddWithValue("p_AE_ReferenceName", String.IsNullOrEmpty(smodel.AE_ReferenceName) ? string.Empty : smodel.AE_ReferenceName);        
            cmd.Parameters.AddWithValue("p_AE_ReferenceDate", smodel.AE_ReferenceDate.HasValue ? smodel.AE_ReferenceDate.Value : dtvalue);// DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_AE_EmailType", String.IsNullOrEmpty(smodel.AE_EmailType) ? string.Empty : smodel.AE_EmailType);
            cmd.Parameters.AddWithValue("p_AE_EmailAddress", String.IsNullOrEmpty(smodel.AE_EmailAddress) ? string.Empty : smodel.AE_EmailAddress);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);

            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", 0);
            cmd.Parameters.AddWithValue("p_IsVerified",(smodel.IsVerified == 0) ? 0 : smodel.IsVerified);
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
      
    }
}
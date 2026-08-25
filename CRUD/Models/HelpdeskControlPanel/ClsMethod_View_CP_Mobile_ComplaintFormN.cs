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
    public class ClsMethod_View_CP_Mobile_ComplaintFormN
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_ControlPanel_View_Mobile_ComplaintFormN> Display_CP_FormNcomplaintDetailsForMobileNumber_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Mobile_ComplaintFormN> CPregistrationList = new List<ClsPrp_ControlPanel_View_Mobile_ComplaintFormN>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_complaint_formn_details_ByID", con);
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
                    new ClsPrp_ControlPanel_View_Mobile_ComplaintFormN
                    {
                        ComplaintFormN_ID = Convert.ToInt64(dr["ComplaintFormN_ID"]),
                        ComplaintFormN_Code = Convert.ToString(dr["ComplaintFormN_Code"]),
                        Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),
                        ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                        Complaint_DiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                        IsComplaintTransferFromTo = Convert.ToString(dr["IScompaintTransferFromTo"]),
                        Complaint_TransferDiaryNumber_Name = Convert.ToString(dr["Complaint_TransferDiaryNumber_Name"]),

                        Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                        OfficeResComplainant_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                        OfficeResComplainant_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                        OfficeResComplainant_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                        OfficeResComplainant_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                        OfficeResComplainant_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                        AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                        RelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["RelatesComplaint_ComplaintAgainstType"]),
                        RelatesComplaint_ProjectAgent_RERA_RegNumber = Convert.ToString(dr["RelatesComplaint_ProjectAgent_RERA_RegNumber"]),
                        RelatesComplaint_ProjectAgent_Name = Convert.ToString(dr["RelatesComplaint_ProjectAgent_Name"]),
                        Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
                    });
            }
            return CPregistrationList;
        }

        public List<ClsPrp_ControlPanel_View_Mobile_ComplaintFormN> Display_CP_MobileNumbersAll_ForRegisteredComplaintFormN_ByID(string pRegistrationNumber, string pUserRole)
        {
            connection();
            List<ClsPrp_ControlPanel_View_Mobile_ComplaintFormN> CPregistrationList = new List<ClsPrp_ControlPanel_View_Mobile_ComplaintFormN>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_CP_MobileComplaintNFormNumbersAllDetails_ByID", con);
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
                    new ClsPrp_ControlPanel_View_Mobile_ComplaintFormN
                    {
                        AdditionalMobileNumberFormN_IndexID = Convert.ToInt64(dr["AdditionalMobileNumberFormN_IndexID"]),
                        AdditionalMobileNumberFormN_ID = Convert.ToInt64(dr["AdditionalMobileNumberFormN_ID"]),
                        ComplaintFormN_ID = Convert.ToInt64(dr["ComplaintFormN_ID"]),
                        ComplaintFormN_Code = Convert.ToString(dr["ComplaintFormN_Code"]),
                        Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                        User_ID = Convert.ToString(dr["User_ID"]),
                        ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                        Complaint_DiaryNumber_Name = Convert.ToString(dr["Complaint_DiaryNumber_Name"]),
                        IsComplaintTransferFromTo = Convert.ToString(dr["IsComplaintTransferFromTo"]),
                        Complaint_TransferDiaryNumber_Name = Convert.ToString(dr["Complaint_TransferDiaryNumber_Name"]),

                        Complainant_Name = Convert.ToString(dr["ComplainantAppellant_Name"]),
                        OfficeResComplainant_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                        OfficeResComplainant_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                        OfficeResComplainant_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                        OfficeResComplainant_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                        OfficeResComplainant_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                        AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                        RelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["RelatesComplaint_ComplaintAgainstType"]),
                        RelatesComplaint_ProjectAgent_RERA_RegNumber = Convert.ToString(dr["RelatesComplaint_ProjectAgent_RERA_RegNumber"]),
                        RelatesComplaint_ProjectAgent_Name = Convert.ToString(dr["RelatesComplaint_ProjectAgent_Name"]),
                        Respondent_Name = Convert.ToString(dr["Respondent_Name"]),

                        AMN_ContactName = Convert.ToString(dr["AMN_ContactName"]),
                        AMN_Designation = Convert.ToString(dr["AMN_Designation"]),
                        AMN_ReferenceName = Convert.ToString(dr["AMN_ReferenceName"]),
                        AMN_ReferenceDate = Convert.ToDateTime(dr["AMN_ReferenceDate"]),
                        AMN_PhoneType = Convert.ToString(dr["AMN_PhoneType"]),
                        AMN_MobileNumber = Convert.ToString(dr["AMN_MobileNumber"]),

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

        public Int32 Update_LockUnlockHandler_CP_MobileNumbersAll_ForRegisteredComplaintNFormByIndex(string RequestID, string RelatedRefIndexID, string RelatedRefID, string RelatedCode, string LockUnlockCode, string ByUserName, string ByUserID, string RelatedRemarksIfAny, string RelatedPVMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_cp_setlockunlock_complaintnformmobilenumberByIndex", con);
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

        public Tuple<bool, string> Add_ComplaintFormN_PhoneMobileNumber(ClsPrp_ControlPanel_View_Mobile_ComplaintFormN smodel, string User_Name, Int64 sFormN_ID, string sFormN_Code, string sFormN_DiaryNumber, string sUID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_CP_tbl_rera_complaint_formn_additionalmobilenumber", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionalMobileNumberFormN_IndexID", (smodel.AdditionalMobileNumberFormN_IndexID == 0) ? 0 : smodel.AdditionalMobileNumberFormN_IndexID);
            cmd.Parameters.AddWithValue("p_AdditionalMobileNumberFormN_ID", (smodel.AdditionalMobileNumberFormN_ID == 0) ? 0 : smodel.AdditionalMobileNumberFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", sFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_Code", sFormN_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", (smodel.Profile_ID == 0) ? 0 : smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", sUID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", String.IsNullOrEmpty(smodel.ComplaintType_MN) ? string.Empty : smodel.ComplaintType_MN);

            cmd.Parameters.AddWithValue("p_Complaint_DiaryNumber_Name", String.IsNullOrEmpty(smodel.Complaint_DiaryNumber_Name) ? string.Empty : smodel.Complaint_DiaryNumber_Name);
            cmd.Parameters.AddWithValue("p_IsComplaintTransferFromTo", String.IsNullOrEmpty(smodel.IsComplaintTransferFromTo) ? string.Empty : smodel.IsComplaintTransferFromTo);
            cmd.Parameters.AddWithValue("p_Complaint_TransferDiaryNumber_Name", String.IsNullOrEmpty(smodel.Complaint_TransferDiaryNumber_Name) ? string.Empty : smodel.Complaint_TransferDiaryNumber_Name);

            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? string.Empty : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine1) ? string.Empty : smodel.OfficeResComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine2) ? string.Empty : smodel.OfficeResComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressStateCode", (smodel.OfficeResComplainant_AddressStateCode == 0) ? 0 : smodel.OfficeResComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressDistrictCode", (smodel.OfficeResComplainant_AddressDistrictCode == 0) ? 0 : smodel.OfficeResComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressPIN) ? string.Empty : smodel.OfficeResComplainant_AddressPIN);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_Name", String.IsNullOrEmpty(smodel.AuthorizedRepresentativeCounsel_Name) ? string.Empty : smodel.AuthorizedRepresentativeCounsel_Name);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ComplaintAgainstType", String.IsNullOrEmpty(smodel.RelatesComplaint_ComplaintAgainstType) ? string.Empty : smodel.RelatesComplaint_ComplaintAgainstType);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ProjectAgent_RERA_RegNumber", String.IsNullOrEmpty(smodel.RelatesComplaint_ProjectAgent_RERA_RegNumber) ? string.Empty : smodel.RelatesComplaint_ProjectAgent_RERA_RegNumber);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ProjectAgent_Name", String.IsNullOrEmpty(smodel.RelatesComplaint_ProjectAgent_Name) ? string.Empty : smodel.RelatesComplaint_ProjectAgent_Name);
            cmd.Parameters.AddWithValue("p_Respondent_Name", String.IsNullOrEmpty(smodel.Respondent_Name) ? string.Empty : smodel.Respondent_Name);

            cmd.Parameters.AddWithValue("p_AMN_ContactName", String.IsNullOrEmpty(smodel.AMN_ContactName) ? string.Empty : smodel.AMN_ContactName);
            cmd.Parameters.AddWithValue("p_AMN_Designation", String.IsNullOrEmpty(smodel.AMN_Designation) ? string.Empty : smodel.AMN_Designation);
            cmd.Parameters.AddWithValue("p_AMN_ReferenceName", String.IsNullOrEmpty(smodel.AMN_ReferenceName) ? string.Empty : smodel.AMN_ReferenceName);
            cmd.Parameters.AddWithValue("p_AMN_ReferenceDate", smodel.AMN_ReferenceDate.HasValue ? smodel.AMN_ReferenceDate.Value : dtvalue);// DateTime.MinValue);
            cmd.Parameters.AddWithValue("p_AMN_PhoneType", String.IsNullOrEmpty(smodel.AMN_PhoneType) ? string.Empty : smodel.AMN_PhoneType);
            cmd.Parameters.AddWithValue("p_AMN_MobileNumber", String.IsNullOrEmpty(smodel.AMN_MobileNumber) ? string.Empty : smodel.AMN_MobileNumber);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? string.Empty : smodel.RemarksIfAny);

            cmd.Parameters.AddWithValue("p_Extra1", String.IsNullOrEmpty(smodel.Extra1) ? string.Empty : smodel.Extra1);
            cmd.Parameters.AddWithValue("p_Extra2", String.IsNullOrEmpty(smodel.Extra2) ? string.Empty : smodel.Extra2);
            cmd.Parameters.AddWithValue("p_Extra3", String.IsNullOrEmpty(smodel.Extra3) ? string.Empty : smodel.Extra3);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsApproval", 0);
            cmd.Parameters.AddWithValue("p_IsVerified", (smodel.IsVerified == 0) ? 0 : smodel.IsVerified);
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
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.HelpDeskComplaint;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_ComplaintFormM_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_FormM_Registration> Display_ComplaintFormM_Registration_ForDesk(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormM_Registration> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormM_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Registrationdetails_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_FormM_Registration
                       {
                           ComplaintFormM_IndexID = Convert.ToInt64(dr["ComplaintFormM_IndexID"]),
                           ComplaintFormM_ID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
                           ComplaintFormM_Code = Convert.ToString(dr["ComplaintFormM_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                           IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                           IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineFaxNumber = Convert.ToInt64(dr["Complainant_LandlineFaxNumber"]),
                           Complainant_AadhaarNumber = Convert.ToInt64(dr["Complainant_AadhaarNumber"]),
                           OfficeResComplainant_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           OfficeResComplainant_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           OfficeResComplainant_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                           OfficeResComplainant_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                           OfficeResComplainant_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),
                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),
                           AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                           AuthorizedRepresentativeCounsel_EmailAddress = Convert.ToString(dr["AuthorizedRepresentativeCounsel_EmailAddress"]),
                           AuthorizedRepresentativeCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_MobileNumber"]),
                           AuthorizedRepresentativeCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_LandlineFaxNumber"]),
                           RelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["RelatesComplaint_ComplaintAgainstType"]),
                           RelatesComplaint_ProjectAgent_RERA_RegNumber = Convert.ToString(dr["RelatesComplaint_ProjectAgent_RERA_RegNumber"]),
                           RelatesComplaint_ProjectAgent_Name = Convert.ToString(dr["RelatesComplaint_ProjectAgent_Name"]),
                           Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
                           Respondent_EmailAddress = Convert.ToString(dr["Respondent_EmailAddress"]),
                           Respondent_MobileNumber = Convert.ToInt64(dr["Respondent_MobileNumber"]),
                           Respondent_LandlineFaxNumber = Convert.ToInt64(dr["Respondent_LandlineFaxNumber"]),
                           OfficeResRespondent_AddressLine1 = Convert.ToString(dr["OfficeResRespondent_AddressLine1"]),
                           OfficeResRespondent_AddressLine2 = Convert.ToString(dr["OfficeResRespondent_AddressLine2"]),
                           OfficeResRespondent_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondent_AddressStateCode"]),
                           OfficeResRespondent_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondent_AddressDistrictCode"]),
                           OfficeResRespondent_AddressPIN = Convert.ToString(dr["OfficeResRespondent_AddressPIN"]),
                           IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResRespondentAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesRespondent_AddressLine1 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine1"]),
                           ServiceNoticesRespondent_AddressLine2 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine2"]),
                           ServiceNoticesRespondent_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressStateCode"]),
                           ServiceNoticesRespondent_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressDistrictCode"]),
                           ServiceNoticesRespondent_AddressPIN = Convert.ToString(dr["ServiceNoticesRespondent_AddressPIN"]),
                           IsAgreeDeclaration_JurisdictionRERAPunjab = Convert.ToString(dr["IsAgreeDeclaration_JurisdictionRERAPunjab"]),
                           FactsCase_Statement = Convert.ToString(dr["FactsCase_Statement"]),
                           ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                           ReliefSought_TotalValueINR_FlatPlotApartment = Convert.ToDecimal(dr["ReliefSought_TotalValueINR_FlatPlotApartment"]),
                           ReliefSought_TotalAmountPaid_tilldateINR = Convert.ToDecimal(dr["ReliefSought_TotalAmountPaid_tilldateINR"]),
                           ReliefSought_PossessionDate = Convert.ToDateTime(dr["ReliefSought_PossessionDate"]),
                           ReliefSought_ActualPossessionDate_IfDelivered = Convert.ToDateTime(dr["ReliefSought_ActualPossessionDate_IfDelivered"]),
                           InterimOrderRelief_Statement = Convert.ToString(dr["InterimOrderRelief_Statement"]),
                           IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = Convert.ToString(dr["IsAgreeDeclaration_ComplaintNotPendingCourtAuthority"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToDateTime(dr["A_column"]),
                           B_column = Convert.ToDateTime(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthorityDesk_FormM_RegistrationForRegDiaryNumber> Display_ComplaintFormM_ContentDetailsByRERAregistration_ForDesk(Int64 ComplaintFormM_ID, string RERAregistrationNumber, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormM_RegistrationForRegDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormM_RegistrationForRegDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_ContentDetailsByRERAnumber_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_RERAregistrationNumberFormM", RERAregistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRoleFormM", userRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_FormM_RegistrationForRegDiaryNumber
                       {
                           ComplaintFormM_IndexID = Convert.ToInt64(dr["ComplaintFormM_IndexID"]),
                           ComplaintFormM_ID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
                           ComplaintFormM_Code = Convert.ToString(dr["ComplaintFormM_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                           IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                           IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineFaxNumber = Convert.ToInt64(dr["Complainant_LandlineFaxNumber"]),
                           Complainant_AadhaarNumber = Convert.ToInt64(dr["Complainant_AadhaarNumber"]),
                           OfficeResComplainant_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           OfficeResComplainant_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           OfficeResComplainant_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                           OfficeResComplainant_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                           OfficeResComplainant_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),
                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),
                           AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                           AuthorizedRepresentativeCounsel_EmailAddress = Convert.ToString(dr["AuthorizedRepresentativeCounsel_EmailAddress"]),
                           AuthorizedRepresentativeCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_MobileNumber"]),
                           AuthorizedRepresentativeCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_LandlineFaxNumber"]),
                           RelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["RelatesComplaint_ComplaintAgainstType"]),
                           RelatesComplaint_ProjectAgent_RERA_RegNumber = Convert.ToString(dr["RelatesComplaint_ProjectAgent_RERA_RegNumber"]),
                           RelatesComplaint_ProjectAgent_Name = Convert.ToString(dr["RelatesComplaint_ProjectAgent_Name"]),
                           Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
                           Respondent_EmailAddress = Convert.ToString(dr["Respondent_EmailAddress"]),
                           Respondent_MobileNumber = Convert.ToInt64(dr["Respondent_MobileNumber"]),
                           Respondent_LandlineFaxNumber = Convert.ToInt64(dr["Respondent_LandlineFaxNumber"]),
                           OfficeResRespondent_AddressLine1 = Convert.ToString(dr["OfficeResRespondent_AddressLine1"]),
                           OfficeResRespondent_AddressLine2 = Convert.ToString(dr["OfficeResRespondent_AddressLine2"]),
                           OfficeResRespondent_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondent_AddressStateCode"]),
                           OfficeResRespondent_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondent_AddressDistrictCode"]),
                           OfficeResRespondent_AddressPIN = Convert.ToString(dr["OfficeResRespondent_AddressPIN"]),
                           IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResRespondentAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesRespondent_AddressLine1 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine1"]),
                           ServiceNoticesRespondent_AddressLine2 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine2"]),
                           ServiceNoticesRespondent_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressStateCode"]),
                           ServiceNoticesRespondent_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressDistrictCode"]),
                           ServiceNoticesRespondent_AddressPIN = Convert.ToString(dr["ServiceNoticesRespondent_AddressPIN"]),
                           IsAgreeDeclaration_JurisdictionRERAPunjab = Convert.ToString(dr["IsAgreeDeclaration_JurisdictionRERAPunjab"]),
                           FactsCase_Statement = Convert.ToString(dr["FactsCase_Statement"]),
                           ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
                           ReliefSought_TotalValueINR_FlatPlotApartment = Convert.ToDecimal(dr["ReliefSought_TotalValueINR_FlatPlotApartment"]),
                           ReliefSought_TotalAmountPaid_tilldateINR = Convert.ToDecimal(dr["ReliefSought_TotalAmountPaid_tilldateINR"]),
                           ReliefSought_PossessionDate = Convert.ToDateTime(dr["ReliefSought_PossessionDate"]),
                           ReliefSought_ActualPossessionDate_IfDelivered = Convert.ToDateTime(dr["ReliefSought_ActualPossessionDate_IfDelivered"]),
                           InterimOrderRelief_Statement = Convert.ToString(dr["InterimOrderRelief_Statement"]),
                           IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = Convert.ToString(dr["IsAgreeDeclaration_ComplaintNotPendingCourtAuthority"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToDateTime(dr["A_column"]),
                           B_column = Convert.ToDateTime(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           yComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["yComplaintRegDiaryNumber_IndexID"]),
                           yComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["yComplaintRegDiaryNumber_ID"]),
                           yComplaintRegDiaryNumber_Name = Convert.ToString(dr["yComplaintRegDiaryNumber_Name"]),
                           yComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["yComplaintRegDiaryNumber_NameYear"]),
                           yFormM_RelatedComplaint_ID = Convert.ToInt64(dr["yFormM_RelatedComplaint_ID"]),
                           yFormM_RelatedComplaint_Code = Convert.ToString(dr["yFormM_RelatedComplaint_Code"]),
                           yProfile_ID = Convert.ToInt64(dr["yProfile_ID"]),
                           yUser_ID = Convert.ToString(dr["yUser_ID"]),
                           yComplaintType_MN = Convert.ToString(dr["yComplaintType_MN"]),
                           yIsComplaintComplete = Convert.ToInt32(dr["yIsComplaintComplete"]),
                           yIsPaymentComplete = Convert.ToInt32(dr["yIsPaymentComplete"]),
                           yPaymentTransactionID = Convert.ToString(dr["yPaymentTransactionID"]),
                           yPaymentTransactionDate = Convert.ToDateTime(dr["yPaymentTransactionDate"]),
                           yIsDocumentsComplete = Convert.ToInt32(dr["yIsDocumentsComplete"]),
                           yDocumentUploadCount = Convert.ToInt32(dr["yDocumentUploadCount"]),
                           yIsVerificationComplete = Convert.ToInt32(dr["yIsVerificationComplete"]),
                           yComplaintVerificationDate = Convert.ToDateTime(dr["yComplaintVerificationDate"]),
                           yCurrentEventcode = Convert.ToInt64(dr["yCurrentEventcode"]),
                           yEventCodeDetails_indexID = Convert.ToInt64(dr["yEventCodeDetails_indexID"]),
                           yRemarks_IfAny = Convert.ToString(dr["yRemarks_IfAny"]),
                           yA_column = Convert.ToString(dr["yA_column"]),
                           yB_column = Convert.ToString(dr["yB_column"]),
                           yC_column = Convert.ToString(dr["yC_column"]),
                           yIsActive = Convert.ToInt32(dr["yIsActive"]),
                           yIsDraft = Convert.ToInt32(dr["yIsDraft"]),
                           yIsLock = Convert.ToInt32(dr["yIsLock"]),
                           yIsPublicView = Convert.ToInt32(dr["yIsPublicView"]),
                           yIsDraftHelpDesk = Convert.ToInt32(dr["yIsDraftHelpDesk"]),
                           yIsDraftEvaluation = Convert.ToInt32(dr["yIsDraftEvaluation"]),
                           yIsDraftSecMember = Convert.ToInt32(dr["yIsDraftSecMember"]),
                           yIsDraftMember = Convert.ToInt32(dr["yIsDraftMember"]),
                           yCreatedBy = Convert.ToString(dr["yCreatedBy"]),
                           yCreatedOn = Convert.ToDateTime(dr["yCreatedOn"]),
                           yModifyBy = Convert.ToString(dr["yModifyBy"]),
                           yModifyOn = Convert.ToDateTime(dr["yModifyOn"]),

                           yComplainant_Name = Convert.ToString(dr["yComplainant_Name"]),
                           yComplainant_MobileNumber = Convert.ToInt64(dr["yComplainant_MobileNumber"]),
                           yRelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["yRelatesComplaint_ComplaintAgainstType"]),
                           yRespondent_Name = Convert.ToString(dr["yRespondent_Name"]),

                           yEventAction_Type = Convert.ToString(dr["yEventAction_Type"]),
                           yEventAction_TypeName = Convert.ToString(dr["yEventAction_TypeName"]),
                           yEventAction_IdentifiedOn = Convert.ToDateTime(dr["yEventAction_IdentifiedOn"]),
                           yEventAction_Aggregate = Convert.ToString(dr["yEventAction_Aggregate"]),
                           yTarget_ResolutionDate = Convert.ToDateTime(dr["yTarget_ResolutionDate"]),
                           yEventRemarks_IfAny = Convert.ToString(dr["yEventRemarks_IfAny"]),
                           yEventAction_Summary = Convert.ToString(dr["yEventAction_Summary"]),
                       });
            }
            return ProjectFivelist1;
        }

        public Int32 Update_LockUnLockHandler_FormMcomplaint_ContentDetails(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormMcomplaint_contentdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
            cmd.Parameters.AddWithValue("p_RelatedComplaintID", RelatedComplaintID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
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

        //PDF-Facts of the Case
        public List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Display_ComplaintFormM_FactsOfTheCase_Document_ByID(Int64 ComplaintFormM_ID, Int64 FormM_ProfileID, Int32 FactsCase_Flag, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_FactsCase_DocumentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_FormM_ProfileID", FormM_ProfileID);
            cmd.Parameters.AddWithValue("p_FactsCase_Flag", FactsCase_Flag);
            cmd.Parameters.AddWithValue("p_User_Role", userRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Complaintlist.Add(
                       new ClsPrp_AuthorityDesk_FormM_FactsCaseDocument
                       {
                           FactsCaseDocument_IndexID = Convert.ToInt64(dr["FactsCaseDocument_IndexID"]),
                           FactsCaseDocument_ID = Convert.ToInt64(dr["FactsCaseDocument_ID"]),
                           ComplainantApplicant_RelatedComplaintM_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaintM_ID"]),
                           ComplainantApplicant_RelatedComplaintM_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaintM_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           FactsCaseDoc_InfoCode = Convert.ToString(dr["FactsCaseDoc_InfoCode"]),
                           FactsCaseDoc_InfoName = Convert.ToString(dr["FactsCaseDoc_InfoName"]),
                           FactsCaseDoc_ReferenceNumber = Convert.ToString(dr["FactsCaseDoc_ReferenceNumber"]),
                           FactsCaseDoc_IssueDate = Convert.ToDateTime(dr["FactsCaseDoc_IssueDate"]),
                           FactsCaseDoc_FileSize = Convert.ToString(dr["FactsCaseDoc_FileSize"]),
                           FactsCaseDoc_FileFormat = Convert.ToString(dr["FactsCaseDoc_FileFormat"]),
                           FactsCaseDoc_FilePath = Convert.ToString(dr["FactsCaseDoc_FilePath"]),
                           FactsCaseDoc_FileName = Convert.ToString(dr["FactsCaseDoc_FileName"]),
                           FactsCaseDoc_IsGroup = Convert.ToInt32(dr["FactsCaseDoc_IsGroup"]),
                           Doc_SerialNumber = Convert.ToString(dr["Doc_SerialNumber"]),
                           Doc_NumberOfPages = Convert.ToInt32(dr["Doc_NumberOfPages"]),
                           Doc_PageStartNumber = Convert.ToInt32(dr["Doc_PageStartNumber"]),
                           Doc_PageEndNumber = Convert.ToInt32(dr["Doc_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Complaintlist;
        }

        public List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByID(Int64 FactsCaseFormM_ID, Int64 ComplaintFormM_ID, Int64 FormM_ProfileID, Int32 FactsCase_Flag, string User_Name)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_FactsCase_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_FactsCaseFormM_ID", FactsCaseFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_FormM_ProfileID", FormM_ProfileID);
            cmd.Parameters.AddWithValue("p_FactsCase_Flag", FactsCase_Flag);
            cmd.Parameters.AddWithValue("p_User_Name", User_Name);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Complaintlist.Add(
                       new ClsPrp_AuthorityDesk_FormM_FactsCaseDocument
                       {
                           FactsCaseDocument_IndexID = Convert.ToInt64(dr["FactsCaseDocument_IndexID"]),
                           FactsCaseDocument_ID = Convert.ToInt64(dr["FactsCaseDocument_ID"]),
                           ComplainantApplicant_RelatedComplaintM_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaintM_ID"]),
                           ComplainantApplicant_RelatedComplaintM_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaintM_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           FactsCaseDoc_InfoCode = Convert.ToString(dr["FactsCaseDoc_InfoCode"]),
                           FactsCaseDoc_InfoName = Convert.ToString(dr["FactsCaseDoc_InfoName"]),
                           FactsCaseDoc_ReferenceNumber = Convert.ToString(dr["FactsCaseDoc_ReferenceNumber"]),
                           FactsCaseDoc_IssueDate = Convert.ToDateTime(dr["FactsCaseDoc_IssueDate"]),
                           FactsCaseDoc_FileSize = Convert.ToString(dr["FactsCaseDoc_FileSize"]),
                           FactsCaseDoc_FileFormat = Convert.ToString(dr["FactsCaseDoc_FileFormat"]),
                           FactsCaseDoc_FilePath = Convert.ToString(dr["FactsCaseDoc_FilePath"]),
                           FactsCaseDoc_FileName = Convert.ToString(dr["FactsCaseDoc_FileName"]),
                           FactsCaseDoc_IsGroup = Convert.ToInt32(dr["FactsCaseDoc_IsGroup"]),
                           Doc_SerialNumber = Convert.ToString(dr["Doc_SerialNumber"]),
                           Doc_NumberOfPages = Convert.ToInt32(dr["Doc_NumberOfPages"]),
                           Doc_PageStartNumber = Convert.ToInt32(dr["Doc_PageStartNumber"]),
                           Doc_PageEndNumber = Convert.ToInt32(dr["Doc_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Complaintlist;
        }

        public List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Display_ComplaintFormM_FactsOfTheCase_FileHistory_ByID(Int64 ComplaintFormM_ID, Int32 FactsCase_Flag, string User_Name)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_FactsCase_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_FactsCase_Flag", FactsCase_Flag);
            cmd.Parameters.AddWithValue("p_User_Name", User_Name);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Complaintlist.Add(
                       new ClsPrp_AuthorityDesk_FormM_FactsCaseDocument
                       {
                           FactsCaseDocument_IndexID = Convert.ToInt64(dr["FactsCaseDocument_IndexID"]),
                           FactsCaseDocument_ID = Convert.ToInt64(dr["FactsCaseDocument_ID"]),
                           ComplainantApplicant_RelatedComplaintM_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaintM_ID"]),
                           ComplainantApplicant_RelatedComplaintM_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaintM_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           FactsCaseDoc_InfoCode = Convert.ToString(dr["FactsCaseDoc_InfoCode"]),
                           FactsCaseDoc_InfoName = Convert.ToString(dr["FactsCaseDoc_InfoName"]),
                           FactsCaseDoc_ReferenceNumber = Convert.ToString(dr["FactsCaseDoc_ReferenceNumber"]),
                           FactsCaseDoc_IssueDate = Convert.ToDateTime(dr["FactsCaseDoc_IssueDate"]),
                           FactsCaseDoc_FileSize = Convert.ToString(dr["FactsCaseDoc_FileSize"]),
                           FactsCaseDoc_FileFormat = Convert.ToString(dr["FactsCaseDoc_FileFormat"]),
                           FactsCaseDoc_FilePath = Convert.ToString(dr["FactsCaseDoc_FilePath"]),
                           FactsCaseDoc_FileName = Convert.ToString(dr["FactsCaseDoc_FileName"]),
                           FactsCaseDoc_IsGroup = Convert.ToInt32(dr["FactsCaseDoc_IsGroup"]),
                           Doc_SerialNumber = Convert.ToString(dr["Doc_SerialNumber"]),
                           Doc_NumberOfPages = Convert.ToInt32(dr["Doc_NumberOfPages"]),
                           Doc_PageStartNumber = Convert.ToInt32(dr["Doc_PageStartNumber"]),
                           Doc_PageEndNumber = Convert.ToInt32(dr["Doc_PageEndNumber"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Complaintlist;
        }

        public Int32 Update_LockUnLockHandler_FormMcomplaint_FactsOfTheCaseDetails(Int64 ComplaintID, Int64 ProfileID, Int64 FactsCaseID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormMcomplaint_factscasedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
            cmd.Parameters.AddWithValue("p_ProfileID", ProfileID);
            cmd.Parameters.AddWithValue("p_FactsCaseID", FactsCaseID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
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

        #region EXECUTION

        public List<ClsPrp_AuthorityDesk_Execution_Registration> Display_ComplaintFormExe_Registration_ForDesk(Int64 ComplaintForm_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_Execution_Registration> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_Execution_Registration>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormExe_Registrationdetails_ForDesk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintForm_ID", ComplaintForm_ID);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    ProjectFivelist1.Add(
                           new ClsPrp_AuthorityDesk_Execution_Registration
                           {
                               ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                               ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                               ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                               Profile_Id = Convert.ToInt64(dr["Profile_Id"]),
                               User_ID = Convert.ToString(dr["User_ID"]),

                               ComplaintType = Convert.ToString(dr["ComplaintType"]),
                               IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                               IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                               IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                               IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                               ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),

                               Complaint_Number = Convert.ToString(dr["Complaint_Number"]),

                               Complainant_FirstName = Convert.ToString(dr["Complainant_FirstName"]),
                               Complainant_MiddleName = Convert.ToString(dr["Complainant_MiddleName"]),
                               Complainant_LastName = Convert.ToString(dr["Complainant_LastName"]),
                               Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                               Complainant_MobileNumber = Convert.ToString(dr["Complainant_MobileNumber"]),
                               Complainant_LandlineFaxNumber = Convert.ToInt32(dr["Complainant_LandlineFaxNumber"]),
                               Complainant_AadhaarNumber = dr["Complainant_AadhaarNumber"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Complainant_AadhaarNumber"]),
                               OfficeResComplainant_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                               OfficeResComplainant_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                               OfficeResComplainant_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                               OfficeResComplainant_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                               OfficeResComplainant_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                               IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),

                               ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                               ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                               ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                               ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                               ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                               AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                               AuthorizedRepresentativeCounsel_EmailAddress = Convert.ToString(dr["AuthorizedRepresentativeCounsel_EmailAddress"]),
                               AuthorizedRepresentativeCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_MobileNumber"]),
                               AuthorizedRepresentativeCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_LandlineFaxNumber"]),

                               Respondent_FirstName = Convert.ToString(dr["Respondent_FirstName"]),
                               Respondent_MiddleName = Convert.ToString(dr["Respondent_MiddleName"]),
                               Respondent_LastName = Convert.ToString(dr["Respondent_LastName"]),
                               Respondent_EmailAddress = Convert.ToString(dr["Respondent_EmailAddress"]),
                               Respondent_MobileNumber = Convert.ToString(dr["Respondent_MobileNumber"]),
                               Respondent_LandlineFaxNumber = Convert.ToInt32(dr["Respondent_LandlineFaxNumber"]),
                               Respondent_AadhaarNumber = dr["Respondent_AadhaarNumber"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Respondent_AadhaarNumber"]),

                               OfficeResRespondent_AddressLine1 = Convert.ToString(dr["OfficeResRespondent_AddressLine1"]),
                               OfficeResRespondent_AddressLine2 = Convert.ToString(dr["OfficeResRespondent_AddressLine2"]),
                               OfficeResRespondent_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondent_AddressStateCode"]),
                               OfficeResRespondent_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondent_AddressDistrictCode"]),
                               OfficeResRespondent_AddressPIN = Convert.ToString(dr["OfficeResRespondent_AddressPIN"]),

                               IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResRespondentAddress_SameAsServiceNoticeAddress"]),

                               ServiceNoticesRespondent_AddressLine1 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine1"]),
                               ServiceNoticesRespondent_AddressLine2 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine2"]),
                               ServiceNoticesRespondent_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressStateCode"]),
                               ServiceNoticesRespondent_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressDistrictCode"]),
                               ServiceNoticesRespondent_AddressPIN = Convert.ToString(dr["ServiceNoticesRespondent_AddressPIN"]),

                               Date_of_Order = Convert.ToDateTime(dr["Date_of_Order"]),
                               Bench_Name = Convert.ToString(dr["Bench_Name"]),
                               Compliance_FromDate = Convert.ToDateTime(dr["Compliance_FromDate"]),
                               Compliance_ToDate = Convert.ToDateTime(dr["Compliance_ToDate"]),
                               Appeal_Information = Convert.ToString(dr["Appeal_Information"]),
                               Payment_AdjustmentDetails = Convert.ToString(dr["Payment_AdjustmentDetails"]),
                               Compliance_Status = Convert.ToString(dr["Compliance_Status"]),
                               Compliance_Document = Convert.ToString(dr["Compliance_Document"]),
                               Previous_ExecutionDetails = Convert.ToString(dr["Previous_ExecutionDetails"]),
                               Principal_Amount = Convert.ToDecimal(dr["Principal_Amount"]),
                               Interest_Amount = Convert.ToDecimal(dr["Interest_Amount"]),
                               Cost_Amount = Convert.ToDecimal(dr["Cost_Amount"]),
                               Total_Amount = Convert.ToDecimal(dr["Total_Amount"]),
                               Mode_of_AssistanceRequired = Convert.ToString(dr["Mode_of_AssistanceRequired"]),
                               Property_Details = Convert.ToString(dr["Property_Details"]),
                               Respondent_BankDetails = Convert.ToString(dr["Respondent_BankDetails"]),
                               Other_RelevantDetails = Convert.ToString(dr["Other_RelevantDetails"]),
                               Declaration_Signed = Convert.ToInt32(dr["Declaration_Signed"]) == 1,

                               Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                               CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"])
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return ProjectFivelist1;
        }

        //public List<ClsPrp_AuthorityDesk_FormExe_RegistrationForRegDiaryNumber> Display_ComplaintFormExe_ContentDetailsByRERAregistration_ForDesk(Int64 ComplaintForm_ID, string RERAregistrationNumber, string userRole)
        //{
        //    connection();
        //    List<ClsPrp_AuthorityDesk_FormExe_RegistrationForRegDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormExe_RegistrationForRegDiaryNumber>();

        //    MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormExe_ContentDetailsByRERAnumber_ForDesk", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("p_ComplaintForm_ID", ComplaintForm_ID);
        //    cmd.Parameters.AddWithValue("p_RERAregistrationNumberForm", RERAregistrationNumber);
        //    cmd.Parameters.AddWithValue("p_UserRoleForm", userRole);
        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ProjectFivelist1.Add(
        //               new ClsPrp_AuthorityDesk_FormExe_RegistrationForRegDiaryNumber
        //               {
        //                   ComplaintFormM_IndexID = Convert.ToInt64(dr["ComplaintFormM_IndexID"]),
        //                   ComplaintFormM_ID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
        //                   ComplaintFormM_Code = Convert.ToString(dr["ComplaintFormM_Code"]),
        //                   Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
        //                   User_ID = Convert.ToString(dr["User_ID"]),
        //                   ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
        //                   IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
        //                   IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
        //                   IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
        //                   IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
        //                   ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
        //                   Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
        //                   Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
        //                   Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
        //                   Complainant_LandlineFaxNumber = Convert.ToInt64(dr["Complainant_LandlineFaxNumber"]),
        //                   Complainant_AadhaarNumber = Convert.ToInt64(dr["Complainant_AadhaarNumber"]),
        //                   OfficeResComplainant_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
        //                   OfficeResComplainant_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
        //                   OfficeResComplainant_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
        //                   OfficeResComplainant_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
        //                   OfficeResComplainant_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),
        //                   IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
        //                   ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
        //                   ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
        //                   ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
        //                   ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
        //                   ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),
        //                   AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
        //                   AuthorizedRepresentativeCounsel_EmailAddress = Convert.ToString(dr["AuthorizedRepresentativeCounsel_EmailAddress"]),
        //                   AuthorizedRepresentativeCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_MobileNumber"]),
        //                   AuthorizedRepresentativeCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedRepresentativeCounsel_LandlineFaxNumber"]),
        //                   RelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["RelatesComplaint_ComplaintAgainstType"]),
        //                   RelatesComplaint_ProjectAgent_RERA_RegNumber = Convert.ToString(dr["RelatesComplaint_ProjectAgent_RERA_RegNumber"]),
        //                   RelatesComplaint_ProjectAgent_Name = Convert.ToString(dr["RelatesComplaint_ProjectAgent_Name"]),
        //                   Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
        //                   Respondent_EmailAddress = Convert.ToString(dr["Respondent_EmailAddress"]),
        //                   Respondent_MobileNumber = Convert.ToInt64(dr["Respondent_MobileNumber"]),
        //                   Respondent_LandlineFaxNumber = Convert.ToInt64(dr["Respondent_LandlineFaxNumber"]),
        //                   OfficeResRespondent_AddressLine1 = Convert.ToString(dr["OfficeResRespondent_AddressLine1"]),
        //                   OfficeResRespondent_AddressLine2 = Convert.ToString(dr["OfficeResRespondent_AddressLine2"]),
        //                   OfficeResRespondent_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondent_AddressStateCode"]),
        //                   OfficeResRespondent_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondent_AddressDistrictCode"]),
        //                   OfficeResRespondent_AddressPIN = Convert.ToString(dr["OfficeResRespondent_AddressPIN"]),
        //                   IsOfficeResRespondentAddress_SameAsServiceNoticeAddress = Convert.ToString(dr["IsOfficeResRespondentAddress_SameAsServiceNoticeAddress"]),
        //                   ServiceNoticesRespondent_AddressLine1 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine1"]),
        //                   ServiceNoticesRespondent_AddressLine2 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine2"]),
        //                   ServiceNoticesRespondent_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressStateCode"]),
        //                   ServiceNoticesRespondent_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressDistrictCode"]),
        //                   ServiceNoticesRespondent_AddressPIN = Convert.ToString(dr["ServiceNoticesRespondent_AddressPIN"]),
        //                   IsAgreeDeclaration_JurisdictionRERAPunjab = Convert.ToString(dr["IsAgreeDeclaration_JurisdictionRERAPunjab"]),
        //                   FactsCase_Statement = Convert.ToString(dr["FactsCase_Statement"]),
        //                   ReliefSought_Statement = Convert.ToString(dr["ReliefSought_Statement"]),
        //                   ReliefSought_TotalValueINR_FlatPlotApartment = Convert.ToDecimal(dr["ReliefSought_TotalValueINR_FlatPlotApartment"]),
        //                   ReliefSought_TotalAmountPaid_tilldateINR = Convert.ToDecimal(dr["ReliefSought_TotalAmountPaid_tilldateINR"]),
        //                   ReliefSought_PossessionDate = Convert.ToDateTime(dr["ReliefSought_PossessionDate"]),
        //                   ReliefSought_ActualPossessionDate_IfDelivered = Convert.ToDateTime(dr["ReliefSought_ActualPossessionDate_IfDelivered"]),
        //                   InterimOrderRelief_Statement = Convert.ToString(dr["InterimOrderRelief_Statement"]),
        //                   IsAgreeDeclaration_ComplaintNotPendingCourtAuthority = Convert.ToString(dr["IsAgreeDeclaration_ComplaintNotPendingCourtAuthority"]),
        //                   Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
        //                   A_column = Convert.ToDateTime(dr["A_column"]),
        //                   B_column = Convert.ToDateTime(dr["B_column"]),
        //                   C_column = Convert.ToString(dr["C_column"]),
        //                   D_column = Convert.ToString(dr["D_column"]),
        //                   E_column = Convert.ToString(dr["E_column"]),
        //                   IsActive = Convert.ToInt32(dr["IsActive"]),
        //                   IsDraft = Convert.ToInt32(dr["IsDraft"]),
        //                   IsLock = Convert.ToInt32(dr["IsLock"]),
        //                   IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
        //                   CreatedBy = Convert.ToString(dr["CreatedBy"]),
        //                   CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
        //                   ModifyBy = Convert.ToString(dr["ModifyBy"]),
        //                   ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

        //                   yComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["yComplaintRegDiaryNumber_IndexID"]),
        //                   yComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["yComplaintRegDiaryNumber_ID"]),
        //                   yComplaintRegDiaryNumber_Name = Convert.ToString(dr["yComplaintRegDiaryNumber_Name"]),
        //                   yComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["yComplaintRegDiaryNumber_NameYear"]),
        //                   yFormM_RelatedComplaint_ID = Convert.ToInt64(dr["yFormM_RelatedComplaint_ID"]),
        //                   yFormM_RelatedComplaint_Code = Convert.ToString(dr["yFormM_RelatedComplaint_Code"]),
        //                   yProfile_ID = Convert.ToInt64(dr["yProfile_ID"]),
        //                   yUser_ID = Convert.ToString(dr["yUser_ID"]),
        //                   yComplaintType_MN = Convert.ToString(dr["yComplaintType_MN"]),
        //                   yIsComplaintComplete = Convert.ToInt32(dr["yIsComplaintComplete"]),
        //                   yIsPaymentComplete = Convert.ToInt32(dr["yIsPaymentComplete"]),
        //                   yPaymentTransactionID = Convert.ToString(dr["yPaymentTransactionID"]),
        //                   yPaymentTransactionDate = Convert.ToDateTime(dr["yPaymentTransactionDate"]),
        //                   yIsDocumentsComplete = Convert.ToInt32(dr["yIsDocumentsComplete"]),
        //                   yDocumentUploadCount = Convert.ToInt32(dr["yDocumentUploadCount"]),
        //                   yIsVerificationComplete = Convert.ToInt32(dr["yIsVerificationComplete"]),
        //                   yComplaintVerificationDate = Convert.ToDateTime(dr["yComplaintVerificationDate"]),
        //                   yCurrentEventcode = Convert.ToInt64(dr["yCurrentEventcode"]),
        //                   yEventCodeDetails_indexID = Convert.ToInt64(dr["yEventCodeDetails_indexID"]),
        //                   yRemarks_IfAny = Convert.ToString(dr["yRemarks_IfAny"]),
        //                   yA_column = Convert.ToString(dr["yA_column"]),
        //                   yB_column = Convert.ToString(dr["yB_column"]),
        //                   yC_column = Convert.ToString(dr["yC_column"]),
        //                   yIsActive = Convert.ToInt32(dr["yIsActive"]),
        //                   yIsDraft = Convert.ToInt32(dr["yIsDraft"]),
        //                   yIsLock = Convert.ToInt32(dr["yIsLock"]),
        //                   yIsPublicView = Convert.ToInt32(dr["yIsPublicView"]),
        //                   yIsDraftHelpDesk = Convert.ToInt32(dr["yIsDraftHelpDesk"]),
        //                   yIsDraftEvaluation = Convert.ToInt32(dr["yIsDraftEvaluation"]),
        //                   yIsDraftSecMember = Convert.ToInt32(dr["yIsDraftSecMember"]),
        //                   yIsDraftMember = Convert.ToInt32(dr["yIsDraftMember"]),
        //                   yCreatedBy = Convert.ToString(dr["yCreatedBy"]),
        //                   yCreatedOn = Convert.ToDateTime(dr["yCreatedOn"]),
        //                   yModifyBy = Convert.ToString(dr["yModifyBy"]),
        //                   yModifyOn = Convert.ToDateTime(dr["yModifyOn"]),

        //                   yComplainant_Name = Convert.ToString(dr["yComplainant_Name"]),
        //                   yComplainant_MobileNumber = Convert.ToInt64(dr["yComplainant_MobileNumber"]),
        //                   yRelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["yRelatesComplaint_ComplaintAgainstType"]),
        //                   yRespondent_Name = Convert.ToString(dr["yRespondent_Name"]),

        //                   yEventAction_Type = Convert.ToString(dr["yEventAction_Type"]),
        //                   yEventAction_TypeName = Convert.ToString(dr["yEventAction_TypeName"]),
        //                   yEventAction_IdentifiedOn = Convert.ToDateTime(dr["yEventAction_IdentifiedOn"]),
        //                   yEventAction_Aggregate = Convert.ToString(dr["yEventAction_Aggregate"]),
        //                   yTarget_ResolutionDate = Convert.ToDateTime(dr["yTarget_ResolutionDate"]),
        //                   yEventRemarks_IfAny = Convert.ToString(dr["yEventRemarks_IfAny"]),
        //                   yEventAction_Summary = Convert.ToString(dr["yEventAction_Summary"]),
        //               });
        //    }
        //    return ProjectFivelist1;
        //}



        #endregion
    }
}
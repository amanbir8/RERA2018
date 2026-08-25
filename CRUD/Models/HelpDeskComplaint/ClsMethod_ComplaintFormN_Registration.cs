using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_ComplaintFormN_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public List<ClsPrp_AuthorityDesk_FormN_Registration> Display_ComplaintFormN_Registration_ForDesk(Int64 ComplaintFormN_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_Registration> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormN_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_Registrationdetails_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();



            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_FormN_Registration
                       {
                           ComplaintFormN_IndexID = Convert.ToInt64(dr["ComplaintFormN_IndexID"]),
                           ComplaintFormN_ID = Convert.ToInt64(dr["ComplaintFormN_ID"]),
                           ComplaintFormN_Code = Convert.ToString(dr["ComplaintFormN_Code"]),
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

        public List<ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber> Display_ComplaintFormN_ContentDetailsByRERAregistration_ForDesk(Int64 ComplaintFormN_ID, string RERAregistrationNumber, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_ContentDetailsByRERAnumber_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_RERAregistrationNumberFormN", RERAregistrationNumber);
            cmd.Parameters.AddWithValue("p_UserRoleFormN", userRole);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_FormN_RegistrationForRegDiaryNumber
                       {
                           ComplaintFormN_IndexID = Convert.ToInt64(dr["ComplaintFormN_IndexID"]),
                           ComplaintFormN_ID = Convert.ToInt64(dr["ComplaintFormN_ID"]),
                           ComplaintFormN_Code = Convert.ToString(dr["ComplaintFormN_Code"]),
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
                           yFormN_RelatedComplaint_ID = Convert.ToInt64(dr["yFormN_RelatedComplaint_ID"]),
                           yFormN_RelatedComplaint_Code = Convert.ToString(dr["yFormN_RelatedComplaint_Code"]),
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
        
        public Int32 Update_LockUnLockHandler_FormNcomplaint_ContentDetails(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormNcomplaint_contentdetails", con);
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
        public List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Display_ComplaintFormN_FactsOfTheCase_Document_ByID(Int64 ComplaintFormN_ID, Int64 FormN_ProfileID, Int32 FactsCase_Flag, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_FactsCase_DocumentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_FormN_ProfileID", FormN_ProfileID);
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
                       new ClsPrp_AuthorityDesk_FormN_FactsCaseDocument
                       {
                           FactsCaseDocument_IndexID = Convert.ToInt64(dr["FactsCaseDocument_IndexID"]),
                           FactsCaseDocument_ID = Convert.ToInt64(dr["FactsCaseDocument_ID"]),
                           ComplainantApplicant_RelatedComplaintN_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaintN_ID"]),
                           ComplainantApplicant_RelatedComplaintN_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaintN_Code"]),
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

        public List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByID(Int64 FactsCaseFormN_ID, Int64 ComplaintFormN_ID, Int64 FormN_ProfileID, Int32 FactsCase_Flag, string User_Name)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_FactsCase_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_FactsCaseFormN_ID", FactsCaseFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_FormN_ProfileID", FormN_ProfileID);
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
                       new ClsPrp_AuthorityDesk_FormN_FactsCaseDocument
                       {
                           FactsCaseDocument_IndexID = Convert.ToInt64(dr["FactsCaseDocument_IndexID"]),
                           FactsCaseDocument_ID = Convert.ToInt64(dr["FactsCaseDocument_ID"]),
                           ComplainantApplicant_RelatedComplaintN_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaintN_ID"]),
                           ComplainantApplicant_RelatedComplaintN_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaintN_Code"]),
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

        public List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Display_ComplaintFormN_FactsOfTheCase_FileHistory_ByID(Int64 ComplaintFormN_ID, Int32 FactsCase_Flag, string User_Name)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_FactsCase_Documents_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);            
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
                       new ClsPrp_AuthorityDesk_FormN_FactsCaseDocument
                       {
                           FactsCaseDocument_IndexID = Convert.ToInt64(dr["FactsCaseDocument_IndexID"]),
                           FactsCaseDocument_ID = Convert.ToInt64(dr["FactsCaseDocument_ID"]),
                           ComplainantApplicant_RelatedComplaintN_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaintN_ID"]),
                           ComplainantApplicant_RelatedComplaintN_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaintN_Code"]),
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

        public Int32 Update_LockUnLockHandler_FormNcomplaint_FactsOfTheCaseDetails(Int64 ComplaintID, Int64 ProfileID, Int64 FactsCaseID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormNcomplaint_factscasedetails", con);
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
    }
}
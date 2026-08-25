using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.HelpdeskComplaint;
using CRUD.Models.ComplaintExecution;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsMethod_PrintComplaintFormM_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Print_FormM_Registration> Display_ComplaintFormM_Registration_ForPrint(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_Print_FormM_Registration> ProjectFivelist1 = new List<ClsPrp_Print_FormM_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Registrationdetails_ForPrint", con);
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
                       new ClsPrp_Print_FormM_Registration
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
                           Complainant_Name = (Convert.ToString(dr["Complainant_Name"])).ToUpper(),
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
                           Respondent_Name = (Convert.ToString(dr["Respondent_Name"])).ToUpper(),
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

                           zapComplainantName = Convert.ToString(dr["zapComplainantName"]),
                           zapOtherComplainantName = Convert.ToString(dr["zapOtherComplainantName"]),
                           zapOtherBriefComplainantName = Convert.ToString(dr["zapOtherBriefComplainantName"]),
                           zapRespondantName = Convert.ToString(dr["zapRespondantName"]),
                           zapOtherRespondantName = Convert.ToString(dr["zapOtherRespondantName"]),
                           zapOtherBriefRespondantName = Convert.ToString(dr["zapOtherBriefRespondantName"]),
                           zapRelated_RegDiaryNumber = Convert.ToString(dr["zapRelated_RegDiaryNumber"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_Print_FormM_Registration> Display_ComplaintFormM_RegistrationByID_ForPrint(Int64 ComplaintFormM_ID, Int64? ProfileFormM_ID)
        {
            connection();
            List<ClsPrp_Print_FormM_Registration> ProjectFivelist1 = new List<ClsPrp_Print_FormM_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_RegistrationdetailsByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ProfileFormM_ID", ProfileFormM_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Print_FormM_Registration
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

                           Complainant_Name = (Convert.ToString(dr["Complainant_Name"])).ToUpper(),
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
                           Respondent_Name = (Convert.ToString(dr["Respondent_Name"])).ToUpper(),
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

                           zapComplainantName = Convert.ToString(dr["zapComplainantName"]),
                           zapOtherComplainantName = Convert.ToString(dr["zapOtherComplainantName"]),
                           zapOtherBriefComplainantName = Convert.ToString(dr["zapOtherBriefComplainantName"]),
                           zapRespondantName = Convert.ToString(dr["zapRespondantName"]),
                           zapOtherRespondantName = Convert.ToString(dr["zapOtherRespondantName"]),
                           zapOtherBriefRespondantName = Convert.ToString(dr["zapOtherBriefRespondantName"]),
                           zapRelated_RegDiaryNumber = Convert.ToString(dr["zapRelated_RegDiaryNumber"]),
                       });
            }
            return ProjectFivelist1;
        }

        //PDF-Facts of the Case
        public List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Display_ComplaintFormM_FactsOfTheCase_Document_ByID_ForPrint(Int64 ComplaintFormM_ID, Int64 FormM_ProfileID, Int32 FactsCase_Flag, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_FactsCase_DocumentByID_ForPrint", con);
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



        #region EXECUTION

        public List<ClsPrp_Print_ExecutionForm_Registration> Display_ExecutionForm_RegistrationByID_ForPrint(Int64 profileid, Int64 formId)
        {
            try
            {
                connection();
                List<ClsPrp_Print_ExecutionForm_Registration> result = new List<ClsPrp_Print_ExecutionForm_Registration>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Registrationdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ComplaintForm_ID", formId);
                cmd.Parameters.AddWithValue("p_ProfileForm_ID", profileid);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new ClsPrp_Print_ExecutionForm_Registration
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

                        Applicant_FirstName = Convert.ToString(dr["Applicant_FirstName"]),
                        Applicant_MiddleName = Convert.ToString(dr["Applicant_MiddleName"]),
                        Applicant_LastName = Convert.ToString(dr["Applicant_LastName"]),
                        Applicant_EmailAddress = Convert.ToString(dr["Applicant_EmailAddress"]),
                        Applicant_AddressLine1 = Convert.ToString(dr["Applicant_AddressLine1"]),
                        Applicant_AddressLine2 = Convert.ToString(dr["Applicant_AddressLine2"]),
                        Applicant_StateCode = Convert.ToString(dr["Applicant_StateCode"]),
                        Applicant_AddressDistrictCode = Convert.ToString(dr["Applicant_AddressDistrictCode"]),
                        Applicant_AddressPin = Convert.ToString(dr["Applicant_AddressPin"]),

                        Complaint_Number = Convert.ToString(dr["Complaint_Number"]),
                        Complainant_FirstName = Convert.ToString(dr["Complainant_FirstName"]),
                        Complainant_MiddleName = Convert.ToString(dr["Complainant_MiddleName"]),
                        Complainant_LastName = Convert.ToString(dr["Complainant_LastName"]),
                        Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                        //Applicant_MobileNumber = Convert.ToString(dr["Applicant_MobileNumber"]),
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

                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                        zapComplainantName = Convert.ToString(dr["zapComplainantName"]),
                        zapOtherComplainantName = Convert.ToString(dr["zapOtherComplainantName"]),
                        zapOtherBriefComplainantName = Convert.ToString(dr["zapOtherBriefComplainantName"]),
                        zapRespondantName = Convert.ToString(dr["zapRespondantName"]),
                        zapOtherRespondantName = Convert.ToString(dr["zapOtherRespondantName"]),
                        zapOtherBriefRespondantName = Convert.ToString(dr["zapOtherBriefRespondantName"]),
                        zapRelated_RegDiaryNumber = Convert.ToString(dr["zapRelated_RegDiaryNumber"]),
                    });

                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ClsPrp_Print_Formexecution_Fee> Display_ComplaintFormexecution_PaymentByID_ForPrint(Int64 profileid, Int64 formId)
        {
            connection();
            List<ClsPrp_Print_Formexecution_Fee> ComplaintFormM_List = new List<ClsPrp_Print_Formexecution_Fee>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_FeeByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintForm_ID", formId);
            cmd.Parameters.AddWithValue("p_ProfileForm_ID", profileid);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintFormM_List.Add(
                       new ClsPrp_Print_Formexecution_Fee
                       {
                           PaymentComplaint_IndexID = Convert.ToInt64(dr["PaymentComplaint_IndexID"]),
                           PaymentComplaint_ID = Convert.ToInt64(dr["PaymentComplaint_ID"]),
                           PaymentComplaint_RelatedComplainant_ID = Convert.ToInt64(dr["PaymentComplaint_RelatedComplainant_ID"]),
                           //PaymentComplaint_RelatedComplainant_Code = Convert.ToString(dr["PaymentComplaint_RelatedComplainant_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           Complaint_BriefSummary = Convert.ToString(dr["Complaint_BriefSummary"]),
                           IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                           PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                           FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                           PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                           PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                           PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                           PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                           PG_Status = Convert.ToString(dr["PG_Status"]),
                           PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                           PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                           PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                           PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                           PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                           PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                           PG_City = Convert.ToString(dr["PG_City"]),
                           PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                           PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                           PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                           PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                           PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                           PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                           PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                           PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                           PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                           PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                           PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                           PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                           PG_State = Convert.ToString(dr["PG_State"]),
                           PG_Country = Convert.ToString(dr["PG_Country"]),
                           PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                           PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                           PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                           PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                           PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                           PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                           PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                           PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                           PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                           PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                           PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                           PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                           PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                           PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                           PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                           PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                           PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                           PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                           PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                           PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                           PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                           PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
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
            return ComplaintFormM_List;
        }

        public List<Clsprp_ExecutionForm_Documents> Display_ComplaintFormExe_Documents_ByComplaintFormExeIDbyProfileID_ForPrint(Int64 profileid, Int64 formId)
        {
            try
            {
                connection();
                List<Clsprp_ExecutionForm_Documents> ExecutionForm_Documents = new List<Clsprp_ExecutionForm_Documents>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Documents_Execution_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Executioncomplaint_id", formId);
                //cmd.Parameters.AddWithValue("p_Profile_ID", profileid);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ExecutionForm_Documents.Add(
                        new Clsprp_ExecutionForm_Documents
                        {
                                ListEnclDocument_IndexID = Convert.ToInt64(dr["ListEnclDocument_IndexID"]),
                                ListEnclDocument_ID = Convert.ToInt64(dr["ListEnclDocument_ID"]),
                                ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                                ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                                Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                                User_ID = Convert.ToString(dr["User_ID"]),

                                ComplaintType = Convert.ToString(dr["ComplaintType"]),
                                ComplaintDoc_InfoCode = Convert.ToString(dr["ComplaintDoc_InfoCode"]),
                                ComplaintDoc_InfoName = Convert.ToString(dr["ComplaintDoc_InfoName"]),
                                ComplaintDoc_ReferenceNumber = Convert.ToString(dr["ComplaintDoc_ReferenceNumber"]),
                                ComplaintDoc_IssueDate = Convert.ToDateTime(dr["ComplaintDoc_IssueDate"]),

                                ComplaintDoc_FileSize = Convert.ToString(dr["ComplaintDoc_FileSize"]),
                                ComplaintDoc_FileFormat = Convert.ToString(dr["ComplaintDoc_FileFormat"]),
                                ComplaintDoc_FilePath = Convert.ToString(dr["ComplaintDoc_FilePath"]),
                                ComplaintDoc_FileName = Convert.ToString(dr["ComplaintDoc_FileName"]),
                                ComplaintDoc_IsGroup = Convert.ToInt32(dr["ComplaintDoc_IsGroup"]),

                                Doc_SerialNumber = Convert.ToString(dr["Doc_SerialNumber"]),
                                Doc_PageStartNumber = Convert.ToInt32(dr["Doc_PageStartNumber"]),
                                Doc_PageEndNumber = Convert.ToInt32(dr["Doc_PageEndNumber"]),

                                Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                                A_column = Convert.ToString(dr["A_column"]),
                                B_column = Convert.ToString(dr["B_column"]),
                                C_column = Convert.ToString(dr["C_column"]),

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
                return ExecutionForm_Documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsPrp_Print_ExecutionForm_Registration> Display_ComplaintFormExe_Registration_ForPrint(Int64 ComplaintForm_ID)
        {
            connection();
            List<ClsPrp_Print_ExecutionForm_Registration> ProjectFivelist1 = new List<ClsPrp_Print_ExecutionForm_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormExe_Registrationdetails_ForPrint", con);
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
                       new ClsPrp_Print_ExecutionForm_Registration
                       {
                           ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                           ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                           ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                           Profile_Id = Convert.ToInt64(dr["Profile_Id"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType= Convert.ToString(dr["ComplaintType"]),
                           IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                           IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                           IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),

                           Applicant_FirstName = Convert.ToString(dr["Applicant_FirstName"]),
                           Applicant_MiddleName = Convert.ToString(dr["Applicant_MiddleName"]),
                           Applicant_LastName = Convert.ToString(dr["Applicant_LastName"]),
                           Applicant_EmailAddress = Convert.ToString(dr["Applicant_EmailAddress"]),
                           Applicant_AddressLine1 = Convert.ToString(dr["Applicant_AddressLine1"]),
                           Applicant_AddressLine2 = Convert.ToString(dr["Applicant_AddressLine2"]),
                           Applicant_StateCode = Convert.ToString(dr["Applicant_StateCode"]),
                           Applicant_AddressDistrictCode = Convert.ToString(dr["Applicant_AddressDistrictCode"]),
                           Applicant_AddressPin = Convert.ToString(dr["Applicant_AddressPin"]),

                           Complaint_Number = Convert.ToString(dr["Complaint_Number"]),
                           Complainant_FirstName = Convert.ToString(dr["Complainant_FirstName"]),
                           Complainant_MiddleName = Convert.ToString(dr["Complainant_MiddleName"]),
                           Complainant_LastName = Convert.ToString(dr["Complainant_LastName"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           //Applicant_MobileNumber = Convert.ToString(dr["Applicant_MobileNumber"]),
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

                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           zapComplainantName = Convert.ToString(dr["zapComplainantName"]),
                           zapOtherComplainantName = Convert.ToString(dr["zapOtherComplainantName"]),
                           zapOtherBriefComplainantName = Convert.ToString(dr["zapOtherBriefComplainantName"]),
                           zapRespondantName = Convert.ToString(dr["zapRespondantName"]),
                           zapOtherRespondantName = Convert.ToString(dr["zapOtherRespondantName"]),
                           zapOtherBriefRespondantName = Convert.ToString(dr["zapOtherBriefRespondantName"]),
                           zapRelated_RegDiaryNumber = Convert.ToString(dr["zapRelated_RegDiaryNumber"]),
                       });
            }
            return ProjectFivelist1;
        }
        #endregion

    }
}
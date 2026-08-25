using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.HelpdeskComplaint;


namespace CRUD.Models.ComplaintPrint
{
    public class ClsMethod_PrintComplaintFormN_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public List<ClsPrp_Print_FormN_Registration> Display_ComplaintFormN_Registration_ForPrint(Int64 ComplaintFormN_ID)
        {
            connection();
            List<ClsPrp_Print_FormN_Registration> ProjectFivelist1 = new List<ClsPrp_Print_FormN_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_Registrationdetails_ForPrint", con);
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
                       new ClsPrp_Print_FormN_Registration
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

        public List<ClsPrp_Print_FormN_Registration> Display_ComplaintFormN_RegistrationByID_ForPrint(Int64 ComplaintFormN_ID, Int64? ProfileFormN_ID)
        {
            connection();
            List<ClsPrp_Print_FormN_Registration> ProjectFivelist1 = new List<ClsPrp_Print_FormN_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_RegistrationdetailsByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_ProfileFormN_ID", ProfileFormN_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_Print_FormN_Registration
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
        public List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Display_ComplaintFormN_FactsOfTheCase_Document_ByID_ForPrint(Int64 ComplaintFormN_ID, Int64 FormN_ProfileID, Int32 FactsCase_Flag, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument> Complaintlist = new List<ClsPrp_AuthorityDesk_FormN_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_FactsCase_DocumentByID_ForPrint", con);
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
    }
}
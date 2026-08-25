using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.RespondentComplaint
{
    public class ClsMethod_RespondentComplaintFormM_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public List<ClsPrp_RespondentComplaint_FormM_Registration> Display_ComplaintFormM_Registration_ForRespondentComplaint(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_RespondentComplaint_FormM_Registration> ProjectFivelist1 = new List<ClsPrp_RespondentComplaint_FormM_Registration>();

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
                       new ClsPrp_RespondentComplaint_FormM_Registration
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
    }
}
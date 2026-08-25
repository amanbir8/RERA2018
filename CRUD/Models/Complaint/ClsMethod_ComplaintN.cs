using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintFormN_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }        

        public Int64 Add_ComplaintFormN_Registration_StepI(ClsPrp_ComplaintFormN_Registration smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formn_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormN_IndexID", smodel.ComplaintFormN_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", smodel.ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_Code", smodel.ComplaintFormN_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeN");
            cmd.Parameters.AddWithValue("p_IsComplaintComplete", 1);// smodel.IsComplaintComplete);
            cmd.Parameters.AddWithValue("p_IsPaymentComplete", 0);// smodel.IsPaymentComplete);
            cmd.Parameters.AddWithValue("p_IsDocumentsComplete", 0);// smodel.IsDocumentsComplete);
            cmd.Parameters.AddWithValue("p_IsVerificationComplete", 0);// smodel.IsVerificationComplete);
            cmd.Parameters.AddWithValue("p_ComplaintVerificationDate", smodel.ComplaintVerificationDate == null ? dtvalue : smodel.ComplaintVerificationDate); // datefun(smodel.ComplaintVerificationDate.ToString()));

            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? "" : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", String.IsNullOrEmpty(smodel.Complainant_EmailAddress) ? "" : smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber == null ? 0 : smodel.Complainant_AadhaarNumber);

            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine1) ? "" : smodel.OfficeResComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine2) ? "" : smodel.OfficeResComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressStateCode", smodel.OfficeResComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressDistrictCode", smodel.OfficeResComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressPIN) ? "" : smodel.OfficeResComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResComplainantAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine1) ? "" : smodel.ServiceNoticesComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine2) ? "" : smodel.ServiceNoticesComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressStateCode", smodel.ServiceNoticesComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressDistrictCode", smodel.ServiceNoticesComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressPIN) ? "" : smodel.ServiceNoticesComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_Name", String.IsNullOrEmpty(smodel.AuthorizedRepresentativeCounsel_Name) ? "" : smodel.AuthorizedRepresentativeCounsel_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_EmailAddress", String.IsNullOrEmpty(smodel.AuthorizedRepresentativeCounsel_EmailAddress) ? "" : smodel.AuthorizedRepresentativeCounsel_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_MobileNumber", smodel.AuthorizedRepresentativeCounsel_MobileNumber == null ? 0 : smodel.AuthorizedRepresentativeCounsel_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_LandlineFaxNumber", smodel.AuthorizedRepresentativeCounsel_LandlineFaxNumber == null ? 0 : smodel.AuthorizedRepresentativeCounsel_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_RelatesComplaint_ComplaintAgainstType", smodel.RelatesComplaint_ComplaintAgainstType);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ProjectAgent_RERA_RegNumber", smodel.RelatesComplaint_ProjectAgent_RERA_RegNumber);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ProjectAgent_Name", smodel.RelatesComplaint_ProjectAgent_Name);

            cmd.Parameters.AddWithValue("p_Respondent_Name", String.IsNullOrEmpty(smodel.Respondent_Name) ? "" : smodel.Respondent_Name);
            cmd.Parameters.AddWithValue("p_Respondent_EmailAddress", String.IsNullOrEmpty(smodel.Respondent_EmailAddress) ? "" : smodel.Respondent_EmailAddress);
            cmd.Parameters.AddWithValue("p_Respondent_MobileNumber", smodel.Respondent_MobileNumber == null ? 0 : smodel.Respondent_MobileNumber);
            cmd.Parameters.AddWithValue("p_Respondent_LandlineFaxNumber", smodel.Respondent_LandlineFaxNumber == null ? 0 : smodel.Respondent_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResRespondent_AddressLine1) ? "" : smodel.OfficeResRespondent_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResRespondent_AddressLine2) ? "" : smodel.OfficeResRespondent_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressStateCode", smodel.OfficeResRespondent_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressDistrictCode", smodel.OfficeResRespondent_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResRespondent_AddressPIN) ? "" : smodel.OfficeResRespondent_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResRespondentAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesRespondent_AddressLine1) ? "" : smodel.ServiceNoticesRespondent_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesRespondent_AddressLine2) ? "" : smodel.ServiceNoticesRespondent_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressStateCode", smodel.ServiceNoticesRespondent_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressDistrictCode", smodel.ServiceNoticesRespondent_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesRespondent_AddressPIN) ? "" : smodel.ServiceNoticesRespondent_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsAgreeDeclaration_JurisdictionRERAPunjab", smodel.IsAgreeDeclaration_JurisdictionRERAPunjab == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_FactsCase_Statement", String.IsNullOrEmpty(smodel.FactsCase_Statement) ? "" : smodel.FactsCase_Statement); //"test");// 
            cmd.Parameters.AddWithValue("p_ReliefSought_Statement", String.IsNullOrEmpty(smodel.ReliefSought_Statement) ? "" : smodel.ReliefSought_Statement); //"test");//
            cmd.Parameters.AddWithValue("p_ReliefSought_TotalValueINR_FlatPlotApartment", smodel.ReliefSought_TotalValueINR_FlatPlotApartment == null ? 0 : smodel.ReliefSought_TotalValueINR_FlatPlotApartment);
            cmd.Parameters.AddWithValue("p_ReliefSought_TotalAmountPaid_tilldateINR", smodel.ReliefSought_TotalAmountPaid_tilldateINR == null ? 0 : smodel.ReliefSought_TotalAmountPaid_tilldateINR);
            cmd.Parameters.AddWithValue("p_ReliefSought_PossessionDate", smodel.ReliefSought_PossessionDate == null ? dtvalue : smodel.ReliefSought_PossessionDate); // datefun(smodel.ReliefSought_PossessionDate.ToString()));
            cmd.Parameters.AddWithValue("p_ReliefSought_ActualPossessionDate_IfDelivered", smodel.ReliefSought_ActualPossessionDate_IfDelivered == null ? dtvalue : smodel.ReliefSought_ActualPossessionDate_IfDelivered); // datefun(smodel.ReliefSought_ActualPossessionDate_IfDelivered.ToString()));

            cmd.Parameters.AddWithValue("p_InterimOrderRelief_Statement", String.IsNullOrEmpty(smodel.InterimOrderRelief_Statement) ? "" : smodel.InterimOrderRelief_Statement); //"test");//
            cmd.Parameters.AddWithValue("p_IsAgreeDeclaration_ComplaintNotPendingCourtAuthority", smodel.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority == "true" ? "1" : "0");

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == null ? dtvalue : smodel.A_column); // String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column == null ? dtvalue : smodel.B_column); // String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return AppId;
            else
                return 0;
        }

        public List<ClsPrp_ComplaintFormN_Registration> Display_ComplaintFormN_Registration_StepI(Int64 ComplaintFormN_ID)
        {
            connection();
            List<ClsPrp_ComplaintFormN_Registration> ProjectFivelist1 = new List<ClsPrp_ComplaintFormN_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_Registrationdetails", con);
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
                       new ClsPrp_ComplaintFormN_Registration
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

        public List<ClsPrp_ComplaintFormN_FlagStep> Display_ComplaintFormN_Flag_RegStep(long ComplaintFormN_ID)
        {
            connection();
            List<ClsPrp_ComplaintFormN_FlagStep> ProjectFivelist1 = new List<ClsPrp_ComplaintFormN_FlagStep>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_Flag_RegStepdetails", con);
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
                       new ClsPrp_ComplaintFormN_FlagStep
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

        public bool Update_ComplaintFormN_Registration_StepI(ClsPrp_ComplaintFormN_Registration smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formN_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);
            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormN_IndexID", smodel.ComplaintFormN_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", smodel.ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_Code", smodel.ComplaintFormN_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeN");
            cmd.Parameters.AddWithValue("p_IsComplaintComplete", smodel.IsComplaintComplete);
            cmd.Parameters.AddWithValue("p_IsPaymentComplete", smodel.IsPaymentComplete);
            cmd.Parameters.AddWithValue("p_IsDocumentsComplete", smodel.IsDocumentsComplete);
            cmd.Parameters.AddWithValue("p_IsVerificationComplete", smodel.IsVerificationComplete);
            cmd.Parameters.AddWithValue("p_ComplaintVerificationDate", smodel.ComplaintVerificationDate == null ? dtvalue : smodel.ComplaintVerificationDate); // smodel.ComplaintVerificationDate);

            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? "" : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", String.IsNullOrEmpty(smodel.Complainant_EmailAddress) ? "" : smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber == null ? 0 : smodel.Complainant_AadhaarNumber);

            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine1) ? "" : smodel.OfficeResComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine2) ? "" : smodel.OfficeResComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressStateCode", smodel.OfficeResComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressDistrictCode", smodel.OfficeResComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressPIN) ? "" : smodel.OfficeResComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResComplainantAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine1) ? "" : smodel.ServiceNoticesComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine2) ? "" : smodel.ServiceNoticesComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressStateCode", smodel.ServiceNoticesComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressDistrictCode", smodel.ServiceNoticesComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressPIN) ? "" : smodel.ServiceNoticesComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_Name", String.IsNullOrEmpty(smodel.AuthorizedRepresentativeCounsel_Name) ? "" : smodel.AuthorizedRepresentativeCounsel_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_EmailAddress", String.IsNullOrEmpty(smodel.AuthorizedRepresentativeCounsel_EmailAddress) ? "" : smodel.AuthorizedRepresentativeCounsel_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_MobileNumber", smodel.AuthorizedRepresentativeCounsel_MobileNumber == null ? 0 : smodel.AuthorizedRepresentativeCounsel_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedRepresentativeCounsel_LandlineFaxNumber", smodel.AuthorizedRepresentativeCounsel_LandlineFaxNumber == null ? 0 : smodel.AuthorizedRepresentativeCounsel_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_RelatesComplaint_ComplaintAgainstType", smodel.RelatesComplaint_ComplaintAgainstType);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ProjectAgent_RERA_RegNumber", smodel.RelatesComplaint_ProjectAgent_RERA_RegNumber);
            cmd.Parameters.AddWithValue("p_RelatesComplaint_ProjectAgent_Name", smodel.RelatesComplaint_ProjectAgent_Name);

            cmd.Parameters.AddWithValue("p_Respondent_Name", String.IsNullOrEmpty(smodel.Respondent_Name) ? "" : smodel.Respondent_Name);
            cmd.Parameters.AddWithValue("p_Respondent_EmailAddress", String.IsNullOrEmpty(smodel.Respondent_EmailAddress) ? "" : smodel.Respondent_EmailAddress);
            cmd.Parameters.AddWithValue("p_Respondent_MobileNumber", smodel.Respondent_MobileNumber == null ? 0 : smodel.Respondent_MobileNumber);
            cmd.Parameters.AddWithValue("p_Respondent_LandlineFaxNumber", smodel.Respondent_LandlineFaxNumber == null ? 0 : smodel.Respondent_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResRespondent_AddressLine1) ? "" : smodel.OfficeResRespondent_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResRespondent_AddressLine2) ? "" : smodel.OfficeResRespondent_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressStateCode", smodel.OfficeResRespondent_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressDistrictCode", smodel.OfficeResRespondent_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondent_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResRespondent_AddressPIN) ? "" : smodel.OfficeResRespondent_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResRespondentAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResRespondentAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesRespondent_AddressLine1) ? "" : smodel.ServiceNoticesRespondent_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesRespondent_AddressLine2) ? "" : smodel.ServiceNoticesRespondent_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressStateCode", smodel.ServiceNoticesRespondent_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressDistrictCode", smodel.ServiceNoticesRespondent_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesRespondent_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesRespondent_AddressPIN) ? "" : smodel.ServiceNoticesRespondent_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsAgreeDeclaration_JurisdictionRERAPunjab", smodel.IsAgreeDeclaration_JurisdictionRERAPunjab == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_FactsCase_Statement", String.IsNullOrEmpty(smodel.FactsCase_Statement) ? "" : smodel.FactsCase_Statement); //"test");// 
            cmd.Parameters.AddWithValue("p_ReliefSought_Statement", String.IsNullOrEmpty(smodel.ReliefSought_Statement) ? "" : smodel.ReliefSought_Statement); //"test");//
            cmd.Parameters.AddWithValue("p_ReliefSought_TotalValueINR_FlatPlotApartment", smodel.ReliefSought_TotalValueINR_FlatPlotApartment == null ? 0 : smodel.ReliefSought_TotalValueINR_FlatPlotApartment);
            cmd.Parameters.AddWithValue("p_ReliefSought_TotalAmountPaid_tilldateINR", smodel.ReliefSought_TotalAmountPaid_tilldateINR == null ? 0 : smodel.ReliefSought_TotalAmountPaid_tilldateINR);
            cmd.Parameters.AddWithValue("p_ReliefSought_PossessionDate", smodel.ReliefSought_PossessionDate == null ? dtvalue : smodel.ReliefSought_PossessionDate); // smodel.ReliefSought_PossessionDate);
            cmd.Parameters.AddWithValue("p_ReliefSought_ActualPossessionDate_IfDelivered", smodel.ReliefSought_ActualPossessionDate_IfDelivered == null ? dtvalue : smodel.ReliefSought_ActualPossessionDate_IfDelivered); // smodel.ReliefSought_ActualPossessionDate_IfDelivered);

            cmd.Parameters.AddWithValue("p_InterimOrderRelief_Statement", String.IsNullOrEmpty(smodel.InterimOrderRelief_Statement) ? "" : smodel.InterimOrderRelief_Statement); //"test");//
            cmd.Parameters.AddWithValue("p_IsAgreeDeclaration_ComplaintNotPendingCourtAuthority", smodel.IsAgreeDeclaration_ComplaintNotPendingCourtAuthority == "true" ? "1" : "0");

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", smodel.A_column == null ? dtvalue : smodel.A_column); // smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", smodel.B_column == null ? dtvalue : smodel.B_column); // smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 0)
                return true;
            else
                return false;
        }

        public DateTime datefun(string valuedate)
        {
            DateTime defaultdate = new DateTime(1919, 1, 1);
            if (valuedate != DBNull.Value.ToString())
            {
                IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
                String datetime = valuedate.Trim();
                DateTime dt = DateTime.Parse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                return dt;
            }
            else
                return defaultdate;
        }

        public string UpdateComplaintFormN_AgreeDetails(ClsPrp_ComplaintFormN_FlagStep smodel, Int64 ComplaintFormN_ID, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_insert_tbl_rera_complaint_formN_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_ComplaintFormN_IndexID", smodel.ComplaintFormN_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", smodel.ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_Code", smodel.ComplaintFormN_Code);

            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_IndexID", 0);
            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_ID", 0);
            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_Name", 0);
            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_NameYear", 0);
            cmd.Parameters.AddWithValue("p_FormN_RelatedComplaint_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_FormN_RelatedComplaint_Code", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", UID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeN");
            cmd.Parameters.AddWithValue("p_IsComplaintComplete", 1);
            cmd.Parameters.AddWithValue("p_IsPaymentComplete", 1);
            cmd.Parameters.AddWithValue("p_PaymentTransactionID", 0);
            cmd.Parameters.AddWithValue("p_PaymentTransactionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_IsDocumentsComplete", 1);
            cmd.Parameters.AddWithValue("p_DocumentUploadCount", 1);
            cmd.Parameters.AddWithValue("p_IsVerificationComplete", 1);
            cmd.Parameters.AddWithValue("p_ComplaintVerificationDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_CurrentEventcode", 0);
            cmd.Parameters.AddWithValue("p_EventCodeDetails_indexID", 0);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", string.Empty);
            cmd.Parameters.AddWithValue("p_A_column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_column", string.Empty);
            cmd.Parameters.AddWithValue("p_C_column", string.Empty);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 1);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_IsDraftHelpDesk", 0);
            cmd.Parameters.AddWithValue("p_IsDraftEvaluation", 0);
            cmd.Parameters.AddWithValue("p_IsDraftSecMember", 0);
            cmd.Parameters.AddWithValue("p_IsDraftMember", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_Return_ComplaintN_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = Convert.ToString(AppPar.Value);
            con.Close();

            if (i >= 0)
                return AppId;
            else
                return "0";            
        }

        public string ValidateComplaintFormN_AgreeDetails(Int64 Complaint_ID, Int64 Profile_ID, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_validate_tbl_rera_complaint_formn_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_ComplaintID_MN", Complaint_ID);
            cmd.Parameters.AddWithValue("p_User_ID", UID);
            cmd.Parameters.AddWithValue("p_UserName", userName);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeN");
            cmd.Parameters.AddWithValue("p_Profile_ID", Profile_ID);

            MySqlParameter AppPar = new MySqlParameter("p_Return_ValidateCode_RegDiaryNumber", MySqlDbType.VarChar, 50);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            string AppId = Convert.ToString(AppPar.Value);
            con.Close();

            if (i >= 0)
                return AppId;
            else
                return "0";
        }

        //Methods - Form-N - Facts of the Case
        public List<Clsprp_ComplaintFormN_FactsCaseDocument> Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI(Int64 ComplaintFormN_ID, Int64 FormN_ProfileID, string FormN_ComplaintType, string UID, string User_Name)
        {
            connection();
            List<Clsprp_ComplaintFormN_FactsCaseDocument> Complaintlist = new List<Clsprp_ComplaintFormN_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_FactsCase_Documents_ByProfileID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", ComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_FormN_ProfileID", FormN_ProfileID);
            cmd.Parameters.AddWithValue("p_FormN_ComplaintType", FormN_ComplaintType);
            cmd.Parameters.AddWithValue("p_UID", UID);
            cmd.Parameters.AddWithValue("p_User_Name", User_Name);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Complaintlist.Add(
                       new Clsprp_ComplaintFormN_FactsCaseDocument
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

        public List<Clsprp_ComplaintFormN_FactsCaseDocument> Display_ComplaintFormN_FactsOfTheCase_UploadedFileExtract_ByID(Int64 FactsCaseFormN_ID, Int64 ComplaintFormN_ID, Int64 FormN_ProfileID, Int32 FactsCase_Flag, string User_Name)
        {
            connection();
            List<Clsprp_ComplaintFormN_FactsCaseDocument> Complaintlist = new List<Clsprp_ComplaintFormN_FactsCaseDocument>();

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
                       new Clsprp_ComplaintFormN_FactsCaseDocument
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

        public bool Add_ComplaintFormN_FactsOfTheCase_Documents_ByProfileID(Clsprp_ComplaintFormN_FactsCaseDocument smodel, Int64 oComplaintFormN_ID, String oComplaintN_FactsCaseDoc_FilePath, String oComplaintN_FactsCaseDoc_FileName, String oComplaintN_FactsCaseDoc_FileSize, String oComplaintN_FactsCaseDoc_FileFormat, Int32 oComplaintN_FactsCaseDoc_IsGroup, Int64 oComplaintProfile_ID, string oUser_ID, string oUserName)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formn_FactsCase_documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_FactsCaseDocument_IndexID", 0);
            cmd.Parameters.AddWithValue("p_FactsCaseDocument_ID", (smodel.FactsCaseDocument_ID == 0) ? 0 : smodel.FactsCaseDocument_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaintN_ID", oComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaintN_Code", oComplaintFormN_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", oComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", oUser_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeN");
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoCode", String.IsNullOrEmpty(smodel.FactsCaseDoc_InfoCode) ? "0" : smodel.FactsCaseDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoName", String.IsNullOrEmpty(smodel.FactsCaseDoc_InfoName) ? "" : smodel.FactsCaseDoc_InfoName);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_ReferenceNumber", smodel.FactsCaseDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_IssueDate", smodel.FactsCaseDoc_IssueDate);

            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FileSize", oComplaintN_FactsCaseDoc_FileSize);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FileFormat", oComplaintN_FactsCaseDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FilePath", oComplaintN_FactsCaseDoc_FilePath);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FileName", oComplaintN_FactsCaseDoc_FileName);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_IsGroup", oComplaintN_FactsCaseDoc_IsGroup);

            cmd.Parameters.AddWithValue("p_Doc_SerialNumber", String.IsNullOrEmpty(smodel.Doc_SerialNumber) ? "0" : smodel.Doc_SerialNumber);
            cmd.Parameters.AddWithValue("p_Doc_NumberOfPages", smodel.Doc_NumberOfPages);
            cmd.Parameters.AddWithValue("p_Doc_PageStartNumber", smodel.Doc_PageStartNumber);
            cmd.Parameters.AddWithValue("p_Doc_PageEndNumber", smodel.Doc_PageEndNumber);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", 0);
            cmd.Parameters.AddWithValue("p_IsTempTable", 1);
            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(oUserName) ? "" : oUserName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete_FormN_FactsOfTheCase_Document_ByID(Int64 nFactscase_IndexID, Int64 nFactscase_ID, Int64 nProfile_ID, Int64 nComplaintN_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormN_FactsCaseDocumentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Factscase_IndexID", nFactscase_IndexID);
            cmd.Parameters.AddWithValue("p_Factscase_ID", nFactscase_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", nProfile_ID);
            cmd.Parameters.AddWithValue("p_ComplaintN_ID", nComplaintN_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //Methods - Form-N - Facts of the Case // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64> Display_ComplaintFormN_FactsOfTheCase_Documents_ByDocCodeInfo_ComplaintID_ProfileID(Int64 Complaint_ID, Int64 Profile_ID, Int64 FactsCaseDoc_InfoCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormN_FactsCase_Documents_ByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoCode", FactsCaseDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ComplaintFormN_ID", Complaint_ID);
            cmd.Parameters.AddWithValue("p_ProfileFormN_ID", Profile_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sumVal = Convert.ToInt64(dr["sumFileSize"]);
                cntVal = Convert.ToInt64(dr["CountFileType"]);
            }
            return new Tuple<Int64, Int64>(sumVal, cntVal);
        }

        //Methods - Form-N - Facts of the Case // Verification Method - File PDF/Text
        public bool Verify_ComplaintFormN_FactsOfTheCase_Documents_ByProfileID(string FactsCaseFlag, Int64 ComplaintN_ID, Int64 ComplaintProfile_ID, string ComplaintN_Type, Int64 FactsCaseDoc_ID, Int64 FactsCaseDoc_InfoCode, string UserName)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("usp_validate_tbl_rera_complaint_formn_FactsCase_documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_FactsCaseFlag", String.IsNullOrEmpty(FactsCaseFlag) ? "mTEXT" : FactsCaseFlag);
            cmd.Parameters.AddWithValue("p_ComplaintN_ID", ComplaintN_ID);
            cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", ComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_ComplaintN_Type", "FormTypeN");
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_ID", FactsCaseDoc_ID);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoCode", FactsCaseDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_UserName", UserName);

            MySqlParameter returnParm = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
            returnParm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnParm);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 factstatementflag = Convert.ToInt64(returnParm.Value);
            con.Close();

            if (i >= 0)
                if (factstatementflag >= 1)
                    return true; //-/55/56/
                else
                    return false;
            else
                return false;
        }

    }
}
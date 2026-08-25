using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.ComplaintExecution;
using CRUD.Models.ClassComplaintPayment;

namespace CRUD.Models.Complaint
{
    public class ClsMethod_ComplaintFormM_Registration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_ComplaintFormM_Registration_StepI(ClsPrp_ComplaintFormM_Registration smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormM_IndexID", smodel.ComplaintFormM_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", smodel.ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_Code", smodel.ComplaintFormM_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");
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
            cmd.Parameters.AddWithValue("p_F_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.F_column);

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

        public List<ClsPrp_ComplaintFormM_Registration> Display_ComplaintFormM_Registration_StepI(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_ComplaintFormM_Registration> ProjectFivelist1 = new List<ClsPrp_ComplaintFormM_Registration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Registrationdetails", con);
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
                       new ClsPrp_ComplaintFormM_Registration
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

        public List<ClsPrp_ComplaintFormM_FlagStep> Display_ComplaintFormM_Flag_RegStep(Int64 ComplaintFormM_ID)
        {
            connection();
            List<ClsPrp_ComplaintFormM_FlagStep> ProjectFivelist1 = new List<ClsPrp_ComplaintFormM_FlagStep>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_Flag_RegStepdetails", con);
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
                       new ClsPrp_ComplaintFormM_FlagStep
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

        public bool Update_ComplaintFormM_Registration_StepI(ClsPrp_ComplaintFormM_Registration smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formm_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintFormM_IndexID", smodel.ComplaintFormM_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", smodel.ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_Code", smodel.ComplaintFormM_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");
            cmd.Parameters.AddWithValue("p_IsComplaintComplete", smodel.IsComplaintComplete);
            cmd.Parameters.AddWithValue("p_IsPaymentComplete", smodel.IsPaymentComplete);
            cmd.Parameters.AddWithValue("p_IsDocumentsComplete", smodel.IsDocumentsComplete);
            cmd.Parameters.AddWithValue("p_IsVerificationComplete", smodel.IsVerificationComplete);
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

        public string UpdateComplaintFormM_AgreeDetails(ClsPrp_ComplaintFormM_FlagStep smodel, Int64 ComplaintFormM_ID, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_insert_tbl_rera_complaint_formm_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            #region PARAMETERS

            cmd.Parameters.AddWithValue("p_ComplaintFormM_IndexID", smodel.ComplaintFormM_IndexID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", smodel.ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_Code", smodel.ComplaintFormM_Code);

            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_IndexID", 0);
            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_ID", 0);
            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_Name", 0);
            cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_NameYear", 0);
            cmd.Parameters.AddWithValue("p_FormM_RelatedComplaint_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_FormM_RelatedComplaint_Code", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", UID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");
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

            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_Return_ComplaintM_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
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

        public string ValidateComplaintFormM_AgreeDetails(Int64 Complaint_ID, Int64 Profile_ID, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "usp_validate_tbl_rera_complaint_formm_RegDiaryNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_ComplaintID_MN", Complaint_ID);
            cmd.Parameters.AddWithValue("p_User_ID", UID);
            cmd.Parameters.AddWithValue("p_UserName", userName);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");
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

        //Methods - Form-M - Facts of the Case
        public List<Clsprp_ComplaintFormM_FactsCaseDocument> Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByProfileID_StepI(Int64 ComplaintFormM_ID, Int64 FormM_ProfileID, string FormM_ComplaintType, string UID, string User_Name)
        {
            connection();
            List<Clsprp_ComplaintFormM_FactsCaseDocument> Complaintlist = new List<Clsprp_ComplaintFormM_FactsCaseDocument>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_FactsCase_Documents_ByProfileID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_FormM_ProfileID", FormM_ProfileID);
            cmd.Parameters.AddWithValue("p_FormM_ComplaintType", FormM_ComplaintType);
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
                       new Clsprp_ComplaintFormM_FactsCaseDocument
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

        public List<Clsprp_ComplaintFormM_FactsCaseDocument> Display_ComplaintFormM_FactsOfTheCase_UploadedFileExtract_ByID(Int64 FactsCaseFormM_ID, Int64 ComplaintFormM_ID, Int64 FormM_ProfileID, Int32 FactsCase_Flag, string User_Name)
        {
            connection();
            List<Clsprp_ComplaintFormM_FactsCaseDocument> Complaintlist = new List<Clsprp_ComplaintFormM_FactsCaseDocument>();

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
                       new Clsprp_ComplaintFormM_FactsCaseDocument
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

        public bool Add_ComplaintFormM_FactsOfTheCase_Documents_ByProfileID(Clsprp_ComplaintFormM_FactsCaseDocument smodel, Int64 oComplaintFormM_ID, String oComplaintM_FactsCaseDoc_FilePath, String oComplaintM_FactsCaseDoc_FileName, String oComplaintM_FactsCaseDoc_FileSize, String oComplaintM_FactsCaseDoc_FileFormat, Int32 oComplaintM_FactsCaseDoc_IsGroup, Int64 oComplaintProfile_ID, string oUser_ID, string oUserName)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_FactsCase_documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region PARAMETERS

            cmd.Parameters.AddWithValue("p_FactsCaseDocument_IndexID", 0);
            cmd.Parameters.AddWithValue("p_FactsCaseDocument_ID", (smodel.FactsCaseDocument_ID == 0) ? 0 : smodel.FactsCaseDocument_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaintM_ID", oComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaintM_Code", oComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", oComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", oUser_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM"); //smodel.ComplaintType_MN);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoCode", String.IsNullOrEmpty(smodel.FactsCaseDoc_InfoCode) ? "0" : smodel.FactsCaseDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoName", String.IsNullOrEmpty(smodel.FactsCaseDoc_InfoName) ? "" : smodel.FactsCaseDoc_InfoName);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_ReferenceNumber", smodel.FactsCaseDoc_ReferenceNumber);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_IssueDate", smodel.FactsCaseDoc_IssueDate);

            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FileSize", oComplaintM_FactsCaseDoc_FileSize);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FileFormat", oComplaintM_FactsCaseDoc_FileFormat);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FilePath", oComplaintM_FactsCaseDoc_FilePath);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_FileName", oComplaintM_FactsCaseDoc_FileName);
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_IsGroup", oComplaintM_FactsCaseDoc_IsGroup);

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

            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Delete_FormM_FactsOfTheCase_Document_ByID(Int64 mFactscase_IndexID, Int64 mFactscase_ID, Int64 mProfile_ID, Int64 mComplaintM_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_FactsCaseDocumentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Factscase_IndexID", mFactscase_IndexID);
            cmd.Parameters.AddWithValue("p_Factscase_ID", mFactscase_ID);
            cmd.Parameters.AddWithValue("p_Profile_ID", mProfile_ID);
            cmd.Parameters.AddWithValue("p_ComplaintM_ID", mComplaintM_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //Methods - Form-M - Facts of the Case // Validation Method - Count and Sum Size
        public Tuple<Int64, Int64> Display_ComplaintFormM_FactsOfTheCase_Documents_ByDocCodeInfo_ComplaintID_ProfileID(Int64 Complaint_ID, Int64 Profile_ID, Int64 FactsCaseDoc_InfoCode)
        {
            connection();
            Int64 sumVal = 0;
            Int64 cntVal = 0;

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormM_FactsCase_Documents_ByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_FactsCaseDoc_InfoCode", FactsCaseDoc_InfoCode);
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", Complaint_ID);
            cmd.Parameters.AddWithValue("p_ProfileFormM_ID", Profile_ID);
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

        //Methods - Form-M - Facts of the Case // Verification Method - File PDF/Text
        public bool Verify_ComplaintFormM_FactsOfTheCase_Documents_ByProfileID(string FactsCaseFlag, Int64 ComplaintM_ID, Int64 ComplaintProfile_ID, string ComplaintM_Type, Int64 FactsCaseDoc_ID, Int64 FactsCaseDoc_InfoCode, string UserName)
        {
            connection();

            MySqlCommand cmd = new MySqlCommand("usp_validate_tbl_rera_complaint_formm_FactsCase_documents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_FactsCaseFlag", String.IsNullOrEmpty(FactsCaseFlag) ? "mTEXT" : FactsCaseFlag);
            cmd.Parameters.AddWithValue("p_ComplaintM_ID", ComplaintM_ID);
            cmd.Parameters.AddWithValue("p_ComplaintProfile_ID", ComplaintProfile_ID);
            cmd.Parameters.AddWithValue("p_ComplaintM_Type", "FormTypeM");
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



        #region EXECUTION
        //EXECUTION FORM 
        public Tuple<long, int, int> Add_ExecutionForm_Registration_StepI(ClsPrp_ExecutionApplication smodel, string UID, string userName, Int64 FormMId)
        {
            try
            {
                connection();
                //MySqlCommand cmd = new MySqlCommand("usp_insert_execution_application", con);
                MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_execution_form_details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime dtvalue = new DateTime(0001, 1, 1);

                string ComplainantMobileNumber = smodel.Complainant_MobileNumber?.Trim();

                if (!string.IsNullOrEmpty(ComplainantMobileNumber) && !ComplainantMobileNumber.StartsWith("+91"))
                {
                    ComplainantMobileNumber = "+91" + ComplainantMobileNumber;
                }
                string RespondentMobileNumber = smodel.Respondent_MobileNumber?.Trim();

                if (!string.IsNullOrEmpty(RespondentMobileNumber) && !RespondentMobileNumber.StartsWith("+91"))
                {
                    RespondentMobileNumber = "+91" + RespondentMobileNumber;
                }


                #region Parameters
                cmd.Parameters.AddWithValue("p_ExecutionForm_IndexId", smodel.ExecutionForm_IndexId);
                cmd.Parameters.AddWithValue("p_ExecutionForm_ID", smodel.ExecutionForm_ID);
                cmd.Parameters.AddWithValue("p_ExecutionForm_Code", smodel.ExecutionForm_Code);
                cmd.Parameters.AddWithValue("p_FormMId", FormMId);
                cmd.Parameters.AddWithValue("p_Related_FormExe_SequenceID", 0);
                cmd.Parameters.AddWithValue("p_Related_FormExe_Year", 0);
                cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_Id);
                cmd.Parameters.AddWithValue("p_User_ID", UID);

                cmd.Parameters.AddWithValue("p_ComplaintType", "FormTypeExecution");
                cmd.Parameters.AddWithValue("p_IsComplaintComplete", 1);// smodel.IsComplaintComplete);
                cmd.Parameters.AddWithValue("p_IsPaymentComplete", 0);// smodel.IsPaymentComplete);
                cmd.Parameters.AddWithValue("p_IsDocumentsComplete", 0);// smodel.IsDocumentsComplete);
                cmd.Parameters.AddWithValue("p_IsVerificationComplete", 0);// smodel.IsVerificationComplete);
                cmd.Parameters.AddWithValue("p_ComplaintVerificationDate", smodel.ComplaintVerificationDate == null ? dtvalue : smodel.ComplaintVerificationDate); // datefun(smodel.ComplaintVerificationDate.ToString()));


                cmd.Parameters.AddWithValue("p_Applicant_FirstName", smodel.Applicant_FirstName);
                cmd.Parameters.AddWithValue("p_Applicant_MiddleName", string.IsNullOrEmpty(smodel.Applicant_MiddleName) ? "" : smodel.Applicant_MiddleName);
                cmd.Parameters.AddWithValue("p_Applicant_LastName", smodel.Applicant_LastName);
                cmd.Parameters.AddWithValue("p_Applicant_EmailAddress", smodel.Applicant_EmailAddress);
                cmd.Parameters.AddWithValue("p_Applicant_AddressLine1", smodel.Applicant_AddressLine1);
                cmd.Parameters.AddWithValue("p_Applicant_AddressLine2", String.IsNullOrEmpty(smodel.Applicant_AddressLine2) ? "" : smodel.Applicant_AddressLine2);
                cmd.Parameters.AddWithValue("p_Applicant_StateCode", smodel.Applicant_StateCode);
                cmd.Parameters.AddWithValue("p_Applicant_AddressDistrictCode", smodel.Applicant_AddressDistrictCode);
                cmd.Parameters.AddWithValue("p_Applicant_AddressPin", smodel.Applicant_AddressPin);

                cmd.Parameters.AddWithValue("p_Complaint_Number", smodel.Complaint_Number);
                cmd.Parameters.AddWithValue("p_Complainant_FirstName", smodel.Complainant_FirstName);
                cmd.Parameters.AddWithValue("p_Complainant_MiddleName", string.IsNullOrEmpty(smodel.Complainant_MiddleName) ? "" : smodel.Complainant_MiddleName);
                cmd.Parameters.AddWithValue("p_Complainant_LastName", smodel.Complainant_LastName);
                cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", smodel.Complainant_EmailAddress);
                //cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber);
                cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", ComplainantMobileNumber);
                cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
                cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber);
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

                cmd.Parameters.AddWithValue("p_Respondent_FirstName", smodel.Respondent_FirstName);
                cmd.Parameters.AddWithValue("p_Respondent_MiddleName", String.IsNullOrEmpty(smodel.Respondent_MiddleName) ? "" : smodel.Respondent_MiddleName);
                cmd.Parameters.AddWithValue("p_Respondent_LastName", smodel.Respondent_LastName);
                cmd.Parameters.AddWithValue("p_Respondent_EmailAddress", smodel.Respondent_EmailAddress);
                //cmd.Parameters.AddWithValue("p_Respondent_MobileNumber", smodel.Respondent_MobileNumber);
                cmd.Parameters.AddWithValue("p_Respondent_MobileNumber", RespondentMobileNumber);
                cmd.Parameters.AddWithValue("p_Respondent_LandlineFaxNumber", smodel.Respondent_LandlineFaxNumber == null ? 0 : smodel.Respondent_LandlineFaxNumber);
                cmd.Parameters.AddWithValue("p_Respondent_AadhaarNumber", smodel.Respondent_AadhaarNumber);
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


                cmd.Parameters.AddWithValue("p_Date_of_Order", smodel.Date_of_Order == null ? dtvalue : smodel.Date_of_Order);
                cmd.Parameters.AddWithValue("p_Bench_Name", smodel.Bench_Name);
                cmd.Parameters.AddWithValue("p_Compliance_FromDate", smodel.Compliance_FromDate == null ? dtvalue : smodel.Compliance_FromDate);
                cmd.Parameters.AddWithValue("p_Compliance_ToDate", smodel.Compliance_ToDate == null ? dtvalue : smodel.Compliance_ToDate);
                cmd.Parameters.AddWithValue("p_Appeal_Information", smodel.Appeal_Information);
                cmd.Parameters.AddWithValue("p_Payment_AdjustmentDetails", String.IsNullOrEmpty(smodel.Payment_AdjustmentDetails) ? "" : smodel.Payment_AdjustmentDetails);
                cmd.Parameters.AddWithValue("p_Compliance_Status", String.IsNullOrEmpty(smodel.Compliance_Status) ? "" : smodel.Compliance_Status);
                cmd.Parameters.AddWithValue("p_Compliance_Document", String.IsNullOrEmpty(smodel.Compliance_Document) ? "" : smodel.Compliance_Document);
                cmd.Parameters.AddWithValue("p_Previous_ExecutionDetails", smodel.Previous_ExecutionDetails);
                cmd.Parameters.AddWithValue("p_Principal_Amount", smodel.Principal_Amount);
                cmd.Parameters.AddWithValue("p_Interest_Amount", smodel.Interest_Amount);
                cmd.Parameters.AddWithValue("p_Cost_Amount", smodel.Cost_Amount);
                cmd.Parameters.AddWithValue("p_Total_Amount", smodel.Total_Amount);
                cmd.Parameters.AddWithValue("p_Mode_of_AssistanceRequired", smodel.Mode_of_AssistanceRequired);
                cmd.Parameters.AddWithValue("p_Property_Details", smodel.Property_Details);
                cmd.Parameters.AddWithValue("p_Respondent_BankDetails", smodel.Respondent_BankDetails);
                cmd.Parameters.AddWithValue("p_Other_RelevantDetails", string.IsNullOrEmpty(smodel.Other_RelevantDetails) ? "" : smodel.Other_RelevantDetails);
                cmd.Parameters.AddWithValue("p_Declaration_Signed", smodel.Declaration_Signed == true ? 1 : 0);

                cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
                cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
                cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
                cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
                cmd.Parameters.AddWithValue("p_IsActive", 1);
                cmd.Parameters.AddWithValue("p_IsDraft", 0);
                cmd.Parameters.AddWithValue("p_IsLock", 0);
                cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
                cmd.Parameters.AddWithValue("p_IsPublicView", 0);
                cmd.Parameters.AddWithValue("p_CreatedBy", userName);
                cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("p_ModifyBy", userName);
                cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
                #endregion

                MySqlParameter AppPar = new MySqlParameter("p_valoutput", MySqlDbType.Int64);
                MySqlParameter SequencePar = new MySqlParameter("p_Related_FormExe_SequenceIDoutput", MySqlDbType.Int32);
                MySqlParameter YearPar = new MySqlParameter("p_Related_FormExe_Yearoutput", MySqlDbType.Int32);

                cmd.Parameters.Add(AppPar);
                AppPar.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(SequencePar);
                SequencePar.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(YearPar);
                YearPar.Direction = ParameterDirection.Output;

                con.Open();
                int i = cmd.ExecuteNonQuery();

                Int64 AppId = Convert.ToInt64(AppPar.Value);
                int RelatedSequenceID = Convert.ToInt32(SequencePar.Value);
                int RelatedYear = Convert.ToInt32(YearPar.Value);

                con.Close();

                if (i >= 0)
                {
                    return new Tuple<long, int, int>(AppId, RelatedSequenceID, RelatedYear);
                }

                return new Tuple<long, int, int>(0, 0, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_ExecutionForm_Registration_StepI(ClsPrp_ExecutionApplication smodel, string UID, string userName, Int64 FormM_Id)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_rera_complaint_formExe_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_ExecutionForm_IndexId", smodel.ExecutionForm_IndexId);
            cmd.Parameters.AddWithValue("p_ExecutionForm_ID", smodel.ExecutionForm_ID);
            cmd.Parameters.AddWithValue("p_ExecutionForm_Code", smodel.ExecutionForm_Code);
            cmd.Parameters.AddWithValue("p_FormMId", FormM_Id);
            cmd.Parameters.AddWithValue("p_Related_FormExe_SequenceID", smodel.Related_FormExe_SequenceID);
            cmd.Parameters.AddWithValue("p_Related_FormExe_Year", smodel.Related_FormExe_Year);
            cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_Id);
            cmd.Parameters.AddWithValue("p_User_ID", smodel.User_ID);

            cmd.Parameters.AddWithValue("p_ComplaintType", "FormTypeExecution");
            cmd.Parameters.AddWithValue("p_IsComplaintComplete", 1);// smodel.IsComplaintComplete);
            cmd.Parameters.AddWithValue("p_IsPaymentComplete", 0);// smodel.IsPaymentComplete);
            cmd.Parameters.AddWithValue("p_IsDocumentsComplete", 0);// smodel.IsDocumentsComplete);
            cmd.Parameters.AddWithValue("p_IsVerificationComplete", 0);// smodel.IsVerificationComplete);
            cmd.Parameters.AddWithValue("p_ComplaintVerificationDate", smodel.ComplaintVerificationDate == null ? dtvalue : smodel.ComplaintVerificationDate); // datefun(smodel.ComplaintVerificationDate.ToString()));
            cmd.Parameters.AddWithValue("p_Complaint_Number", smodel.Complaint_Number);


            cmd.Parameters.AddWithValue("p_Applicant_FirstName", smodel.Applicant_FirstName);
            cmd.Parameters.AddWithValue("p_Applicant_MiddleName", string.IsNullOrEmpty(smodel.Applicant_MiddleName) ? "" : smodel.Applicant_MiddleName);
            cmd.Parameters.AddWithValue("p_Applicant_LastName", smodel.Applicant_LastName);
            cmd.Parameters.AddWithValue("p_Applicant_EmailAddress", smodel.Applicant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Applicant_AddressLine1", smodel.Applicant_AddressLine1);
            cmd.Parameters.AddWithValue("p_Applicant_AddressLine2", String.IsNullOrEmpty(smodel.Applicant_AddressLine2) ? "" : smodel.Applicant_AddressLine2);
            cmd.Parameters.AddWithValue("p_Applicant_StateCode", smodel.Applicant_StateCode);
            cmd.Parameters.AddWithValue("p_Applicant_AddressDistrictCode", smodel.Applicant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Applicant_AddressPin", smodel.Applicant_AddressPin);

            cmd.Parameters.AddWithValue("p_Complainant_FirstName", smodel.Complainant_FirstName);
            cmd.Parameters.AddWithValue("p_Complainant_MiddleName", string.IsNullOrEmpty(smodel.Complainant_MiddleName) ? "" : smodel.Complainant_MiddleName);
            cmd.Parameters.AddWithValue("p_Complainant_LastName", smodel.Complainant_LastName);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber);

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

            cmd.Parameters.AddWithValue("p_Respondent_FirstName", smodel.Respondent_FirstName);
            cmd.Parameters.AddWithValue("p_Respondent_MiddleName", String.IsNullOrEmpty(smodel.Respondent_MiddleName) ? "" : smodel.Respondent_MiddleName);
            cmd.Parameters.AddWithValue("p_Respondent_LastName", smodel.Respondent_LastName);
            cmd.Parameters.AddWithValue("p_Respondent_EmailAddress", smodel.Respondent_EmailAddress);
            cmd.Parameters.AddWithValue("p_Respondent_MobileNumber", smodel.Respondent_MobileNumber);
            cmd.Parameters.AddWithValue("p_Respondent_LandlineFaxNumber", smodel.Respondent_LandlineFaxNumber == null ? 0 : smodel.Respondent_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Respondent_AadhaarNumber", smodel.Respondent_AadhaarNumber);
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


            cmd.Parameters.AddWithValue("p_Date_of_Order", smodel.Date_of_Order == null ? dtvalue : smodel.Date_of_Order);
            cmd.Parameters.AddWithValue("p_Bench_Name", smodel.Bench_Name);
            cmd.Parameters.AddWithValue("p_Compliance_FromDate", smodel.Compliance_FromDate == null ? dtvalue : smodel.Compliance_FromDate);
            cmd.Parameters.AddWithValue("p_Compliance_ToDate", smodel.Compliance_ToDate == null ? dtvalue : smodel.Compliance_ToDate);
            cmd.Parameters.AddWithValue("p_Appeal_Information", smodel.Appeal_Information);
            cmd.Parameters.AddWithValue("p_Payment_AdjustmentDetails", String.IsNullOrEmpty(smodel.Payment_AdjustmentDetails) ? "" : smodel.Payment_AdjustmentDetails);
            cmd.Parameters.AddWithValue("p_Compliance_Status", String.IsNullOrEmpty(smodel.Compliance_Status) ? "" : smodel.Compliance_Status);
            cmd.Parameters.AddWithValue("p_Compliance_Document", String.IsNullOrEmpty(smodel.Compliance_Document) ? "" : smodel.Compliance_Document);
            cmd.Parameters.AddWithValue("p_Previous_ExecutionDetails", smodel.Previous_ExecutionDetails);
            cmd.Parameters.AddWithValue("p_Principal_Amount", smodel.Principal_Amount);
            cmd.Parameters.AddWithValue("p_Interest_Amount", smodel.Interest_Amount);
            cmd.Parameters.AddWithValue("p_Cost_Amount", smodel.Cost_Amount);
            cmd.Parameters.AddWithValue("p_Total_Amount", smodel.Total_Amount);
            cmd.Parameters.AddWithValue("p_Mode_of_AssistanceRequired", smodel.Mode_of_AssistanceRequired);
            cmd.Parameters.AddWithValue("p_Property_Details", smodel.Property_Details);
            cmd.Parameters.AddWithValue("p_Respondent_BankDetails", smodel.Respondent_BankDetails);
            cmd.Parameters.AddWithValue("p_Other_RelevantDetails", string.IsNullOrEmpty(smodel.Other_RelevantDetails) ? "" : smodel.Other_RelevantDetails);
            cmd.Parameters.AddWithValue("p_Declaration_Signed", smodel.Declaration_Signed == true ? 1 : 0);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsActiveProvider", 1);
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


        public List<ClsPrp_ExecutionApplication> Display_ExecutionForm_Registration_StepI(long executioncomplaintId)
        {
            try
            {
                connection();

                List<ClsPrp_ExecutionApplication> result = new List<ClsPrp_ExecutionApplication>();

                //MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Registrationdetails", con);
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_RegistrationdetailsStep", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_executioncomplaintId", executioncomplaintId);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new ClsPrp_ExecutionApplication
                    {
                        ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                        ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                        ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                        Related_ComplaintFormMId = Convert.ToInt64(dr["Related_ComplaintFormMId"]),
                        Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                        Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
                        Profile_Id = Convert.ToInt64(dr["Profile_Id"]),
                        User_ID = Convert.ToString(dr["User_ID"]),

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
                        IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"])
                    });

                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsPrp_ExecutionForm_FlagStep> Display_ExecutionForm_Flag_RegStep(Int64 executionformId)
        {
            try
            {
                connection();
                List<ClsPrp_ExecutionForm_FlagStep> ProjectFivelist1 = new List<ClsPrp_ExecutionForm_FlagStep>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Flag_RegStepdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_executionformId", executionformId);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectFivelist1.Add(
                           new ClsPrp_ExecutionForm_FlagStep
                           {
                               ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                               ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                               ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                               Related_ComplaintFormMId = Convert.ToInt64(dr["Related_ComplaintFormMId"]),
                               Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                               Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
                               Profile_Id = Convert.ToInt64(dr["Profile_Id"]),
                               User_ID = Convert.ToString(dr["User_ID"]),
                               ComplaintType = Convert.ToString(dr["ComplaintType"]),
                               IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                               IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                               IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                               ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                               IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                               IsActive = Convert.ToInt32(dr["IsActive"]),
                               IsDraft = Convert.ToInt32(dr["IsDraft"]),
                               IsLock = Convert.ToInt32(dr["IsLock"]),
                               IsActiveProvider = Convert.ToInt32(dr["IsActiveProvider"]),
                               IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                               CreatedBy = Convert.ToString(dr["CreatedBy"]),
                               CreatedOn = Convert.ToDateTime(dr["createdOn"]),
                               ModifyOn = Convert.ToDateTime(dr["modifiedOn"]),
                               ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           });
                }
                return ProjectFivelist1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidateComplaintExecutionForm_AgreeDetails(Int64 Executioncomplaint_id, Int64 Profile_ID, string UID, string userName)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand();
                //cmd.CommandText = "usp_validate_tbl_rera_complaint_formm_RegDiaryNumber";
                cmd.CommandText = "usp_validate_tbl_rera_complaint_formExecution_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("p_ComplaintID_MN", Executioncomplaint_id);
                cmd.Parameters.AddWithValue("p_User_ID", UID);
                cmd.Parameters.AddWithValue("p_UserName", userName);
                cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeExecution");
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsPrp_Print_ExecutionForm_Registration> Display_ExecutionForm_Registration_Print(long executioncomplaintId)
        {
            try
            {
                connection();
                List<ClsPrp_Print_ExecutionForm_Registration> result = new List<ClsPrp_Print_ExecutionForm_Registration>();

                //MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Registrationdetails", con);
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_RegistrationdetailsStep", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_executioncomplaintId", executioncomplaintId);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new ClsPrp_Print_ExecutionForm_Registration
                    {
                        ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                        ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                        ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                        Related_ComplaintFormMId = Convert.ToInt64(dr["Related_ComplaintFormMId"]),
                        Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                        Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
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

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ClsPrp_ExecutionForm_FlagStep> Display_ComplaintFormExecution_Flag_RegStep(Int64 ExecutionIndexId)
        {
            try
            {
                connection();
                List<ClsPrp_ExecutionForm_FlagStep> ProjectFivelist1 = new List<ClsPrp_ExecutionForm_FlagStep>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Complaint_FormExecution_Flag_RegStepdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ExecutionIndexId", ExecutionIndexId);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectFivelist1.Add(
                           new ClsPrp_ExecutionForm_FlagStep
                           {
                               ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                               ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                               ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                               Related_ComplaintFormMId = Convert.ToInt64(dr["Related_ComplaintFormMId"]),
                               Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                               Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
                               Profile_Id = Convert.ToInt64(dr["Profile_Id"]),
                               User_ID = Convert.ToString(dr["User_ID"]),
                               ComplaintType = Convert.ToString(dr["ComplaintType"]),
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //WORKING
        public string UpdateComplaintFormExe_AgreeDetails(ClsPrp_ExecutionForm_FlagStep smodel, Int64 ComplaintFormM_ID, string UID, string userName)
        {
            try
            {
                connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "usp_insert_tbl_rera_execution_form_RegDiaryNumber";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                #region PARAMETERS

                cmd.Parameters.AddWithValue("p_ComplaintFormM_IndexID", smodel.ExecutionForm_IndexId);
                cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", smodel.ExecutionForm_ID);
                cmd.Parameters.AddWithValue("p_ComplaintFormM_Code", smodel.ExecutionForm_Code);

                cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_IndexID", 0);
                cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_ID", 0);
                cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_Name", 0);
                cmd.Parameters.AddWithValue("p_ComplaintRegDiaryNumber_NameYear", 0);
                cmd.Parameters.AddWithValue("p_FormM_RelatedComplaint_ID", ComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_FormM_RelatedComplaint_Code", ComplaintFormM_ID);
                cmd.Parameters.AddWithValue("p_Related_ComplaintFormMId", smodel.Related_ComplaintFormMId);
                cmd.Parameters.AddWithValue("p_Related_FormExe_SequenceID", smodel.Related_FormExe_SequenceID);
                cmd.Parameters.AddWithValue("p_Related_FormExe_Year", smodel.Related_FormExe_Year);
                cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_Id);
                cmd.Parameters.AddWithValue("p_User_ID", UID);
                cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeExecution");
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

                #endregion

                MySqlParameter AppPar = new MySqlParameter("p_Return_ComplaintExe_RegDiaryNumber_Name", MySqlDbType.VarChar, 50);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<ClsPrp_ExecutionApplication> Display_ExecutionForm_Registration_StepIM(long complaintMId)
        {
            try
            {
                connection();

                List<ClsPrp_ExecutionApplication> result = new List<ClsPrp_ExecutionApplication>();

                //MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_Registrationdetails", con);
                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_RegistrationdetailsM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_complaintId", complaintMId);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new ClsPrp_ExecutionApplication
                    {
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

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsPrp_ExecutionApplication> Display_ExecutionForm_Registration_SteppI(long complaintMId)
        {
            try
            {
                connection();

                List<ClsPrp_ExecutionApplication> result = new List<ClsPrp_ExecutionApplication>();

                MySqlCommand cmd = new MySqlCommand("Display_Rera_Execution_Form_RegdetailsPreFetch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_complaintId", complaintMId);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new ClsPrp_ExecutionApplication
                    {
                        ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                        ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                        ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                        Related_ComplaintFormMId = Convert.ToInt32(dr["Related_ComplaintFormMId"]),
                        Related_FormExe_SequenceID = Convert.ToInt32(dr["Related_FormExe_SequenceID"]),
                        Related_FormExe_Year = Convert.ToInt32(dr["Related_FormExe_Year"]),
                        Profile_Id = Convert.ToInt64(dr["Profile_Id"]),
                        User_ID = Convert.ToString(dr["User_ID"]),

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

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
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
    public class ClsMethod_AuthDesk_FormMN_Addmore_Complainant
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> Display_ComplainantFormM_Detail(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_AddtionalComplainants", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionM_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant
                       {
                           AdditionComplainant_IndexID = Convert.ToInt64(dr["ComplainantorApplicant_IndexID"]),
                           AdditionComplainant_ID = Convert.ToInt64(dr["ComplainantorApplicant_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantorApplicant_RelatedComplaint_ID"]),
                           ComplainantorApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantorApplicant_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           Name_of_Complainant_or_Applicant = Convert.ToString(dr["ComplainantorApplicant_Name"]),
                           EmailAddress = Convert.ToString(dr["ComplainantorApplicant_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),

                           Complainant_AadhaarNumber = Convert.ToInt64(dr["AadhaarNumber"]),

                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResComplainant_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResComplainant_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ComplaintRegistration_list;
        }

        public List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> Display_ComplainantFormN_Detail(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_AddtionalComplainants", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionN_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant
                       {
                           AdditionComplainant_IndexID = Convert.ToInt64(dr["ComplainantorApplicant_IndexID"]),
                           AdditionComplainant_ID = Convert.ToInt64(dr["ComplainantorApplicant_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantorApplicant_RelatedComplaint_ID"]),
                           ComplainantorApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantorApplicant_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           Name_of_Complainant_or_Applicant = Convert.ToString(dr["ComplainantorApplicant_Name"]),
                           EmailAddress = Convert.ToString(dr["ComplainantorApplicant_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),

                           Complainant_AadhaarNumber = Convert.ToInt64(dr["AadhaarNumber"]),

                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResComplainant_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResComplainant_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

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
            return ComplaintRegistration_list;
        }
        
        public Int32 Update_LockUnLockHandler_FormMaddmoreComplainantListDetails(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormMcomplaint_complainantslistdetails", con);
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

        public Int32 Update_LockUnLockHandler_FormNaddmoreComplainantListDetails(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormNcomplaint_complainantslistdetails", con);
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


        #region mapping

        public bool update_ComplainantFormM_Detail(Int64 ComplaintID, string UserName, Int64 complainantID, Int64 AdvID,string type)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("update_additionalFormMcomplainant_respodnantdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime modifytime = DateTime.Now;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_complainantID", complainantID);
            cmd.Parameters.AddWithValue("p_AdvID", AdvID);
            cmd.Parameters.AddWithValue("p_modifytime", modifytime);
            cmd.Parameters.AddWithValue("p_type", type);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool update_ComplainantFormN_Detail(Int64 ComplaintID, string UserName, Int64 complainantID, Int64 AdvID, string type)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("update_additionalFormNcomplainant_respodnantdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DateTime modifytime = DateTime.Now;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ComplaintID", ComplaintID);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_complainantID", complainantID);
            cmd.Parameters.AddWithValue("p_AdvID", AdvID);
            cmd.Parameters.AddWithValue("p_modifytime", modifytime);
            cmd.Parameters.AddWithValue("p_type", type);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        //public Int32 update_RespondantFormM_Detail(Int64 RespondantID, string UserName, Int64 Respondant_ID, Int64 AdvID)
        //{
        //    connection();
        //    MySqlCommand cmd = new MySqlCommand("update_additionalrespondantdetails", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DateTime modifytime = DateTime.Now;


        //    #region Parameters
        //    cmd.Parameters.AddWithValue("p_RespondantID", RespondantID);
        //    cmd.Parameters.AddWithValue("p_UserName", UserName);
        //    cmd.Parameters.AddWithValue("p_respondanantID", Respondant_ID);
        //    cmd.Parameters.AddWithValue("p_AdvID", AdvID);
        //    cmd.Parameters.AddWithValue("p_modifytime", modifytime);
        //    #endregion

        //    MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
        //    AppPar.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(AppPar);

        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();

        //    return i >= 1 ? 1 : 0;
        //}

        public List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> Display_ComplainantFormM_DetailByID(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_FormM_AddtionalComplainantsAdByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionM_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant
                       {
                           AdditionComplainant_IndexID = Convert.ToInt64(dr["ComplainantorApplicant_IndexID"]),
                           AdditionComplainant_ID = Convert.ToInt64(dr["ComplainantorApplicant_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantorApplicant_RelatedComplaint_ID"]),
                           ComplainantorApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantorApplicant_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           Name_of_Complainant_or_Applicant = Convert.ToString(dr["ComplainantorApplicant_Name"]),
                           EmailAddress = Convert.ToString(dr["ComplainantorApplicant_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),

                           Complainant_AadhaarNumber = Convert.ToInt64(dr["AadhaarNumber"]),

                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResComplainant_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResComplainant_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           CounselRepresentative = Convert.ToString(dr["CounselRepresentative"])
                       });
            }
            return ComplaintRegistration_list;
        }

        public List<ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent> Display_RespondantFormM_DetailByID(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent> ComplaintRegistration_list = new List<ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_FormM_AddtionalRespondantsAdByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionM_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent
                       {
                           AdditionRespondent_IndexID = Convert.ToInt64(dr["AdditionRespondentM_IndexID"]),
                           AdditionRespondent_ID = Convert.ToInt64(dr["AdditionRespondentM_ID"]),
                           AdditionRespondent_RelatedComplaint_ID = Convert.ToInt64(dr["AdditionRespondentM_RelatedComplaint_ID"]),
                           AdditionRespondent_RelatedComplaint_Code = Convert.ToString(dr["AdditionRespondentM_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           Name_of_Respondant_or_Applicant = Convert.ToString(dr["RespondentM_Name"]),
                           EmailAddress = Convert.ToString(dr["RespondentM_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),
                           Repondant_AadhaarNumber = 0,
                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResRespondentM_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResRespondentM_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResRespondentM_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResRespondentM_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResRespondentM_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           CounselRepresentative = Convert.ToString(dr["CounselRepresentative"])
                       });
            }
            return ComplaintRegistration_list;
        }

        public List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> Display_ComplainantFormN_DetailByID(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_FormN_AddtionalComplainantsAdByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionN_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDesk_FormMN_AddMore_Complainant
                       {
                           AdditionComplainant_IndexID = Convert.ToInt64(dr["ComplainantorApplicant_IndexID"]),
                           AdditionComplainant_ID = Convert.ToInt64(dr["ComplainantorApplicant_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantorApplicant_RelatedComplaint_ID"]),
                           ComplainantorApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantorApplicant_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           Name_of_Complainant_or_Applicant = Convert.ToString(dr["ComplainantorApplicant_Name"]),
                           EmailAddress = Convert.ToString(dr["ComplainantorApplicant_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),

                           Complainant_AadhaarNumber = Convert.ToInt64(dr["AadhaarNumber"]),

                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResComplainant_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResComplainant_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           CounselRepresentative = Convert.ToString(dr["CounselRepresentative"])
                       });
            }
            return ComplaintRegistration_list;
        }

        public List<ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent> Display_RespondantFormN_DetailByID(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent> ComplaintRegistration_list = new List<ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_FormN_AddtionalRespondantsAdByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionN_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDesk_FormMN_AddMore_Respondent
                       {
                           AdditionRespondent_IndexID = Convert.ToInt64(dr["AdditionRespondentM_IndexID"]),
                           AdditionRespondent_ID = Convert.ToInt64(dr["AdditionRespondentM_ID"]),
                           AdditionRespondent_RelatedComplaint_ID = Convert.ToInt64(dr["AdditionRespondentM_RelatedComplaint_ID"]),
                           AdditionRespondent_RelatedComplaint_Code = Convert.ToString(dr["AdditionRespondentM_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           Name_of_Respondant_or_Applicant = Convert.ToString(dr["RespondentM_Name"]),
                           EmailAddress = Convert.ToString(dr["RespondentM_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),
                           Repondant_AadhaarNumber = 0,
                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResRespondentM_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResRespondentM_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResRespondentM_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResRespondentM_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResRespondentM_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           CounselRepresentative = Convert.ToString(dr["CounselRepresentative"])
                       });
            }
            return ComplaintRegistration_list;
        }

        #endregion

        #region EXECUTION

        public List<ClsPrp_AuthorityDeskFormExe_Addmore_Complainant> Display_ComplainantFormExe_Detail(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_AuthorityDeskFormExe_Addmore_Complainant> ComplaintRegistration_list = new List<ClsPrp_AuthorityDeskFormExe_Addmore_Complainant>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormExe_AddtionalComplainants", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_AdditionExe_RelatedComplaint_ID", parmComplaint_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_AuthorityDeskFormExe_Addmore_Complainant
                       {
                           AdditionComplainant_IndexID = Convert.ToInt64(dr["ComplainantorApplicant_IndexID"]),
                           AdditionComplainant_ID = Convert.ToInt64(dr["ComplainantorApplicant_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantorApplicant_RelatedComplaint_ID"]),
                           ComplainantorApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantorApplicant_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_Exe = Convert.ToString(dr["ComplaintType_Exe"]),

                           Name_of_Complainant_or_Applicant = Convert.ToString(dr["ComplainantorApplicant_Name"]),
                           EmailAddress = Convert.ToString(dr["ComplainantorApplicant_EmailAddress"]),
                           MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                           LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),

                           Complainant_AadhaarNumber = Convert.ToInt64(dr["AadhaarNumber"]),

                           RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                           RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                           RegOffice_AddressStateCode = Convert.ToString(dr["OfficeResComplainant_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToString(dr["OfficeResComplainant_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToString(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToString(dr["ServiceNotices_AddressDistrictCode"]),
                           Service_AddressPIN = Convert.ToInt32(dr["ServiceNotices_AddressPIN"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsTempTable = Convert.ToInt32(dr["IsTempTable"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"])
                       });
            }
            return ComplaintRegistration_list;
        }

        public Int32 Update_LockUnLockHandler_FormExeaddmoreComplainantListDetails(Int64 ComplaintID, Int64 RelatedComplaintID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_FormExecomplaint_complainantslistdetails", con);
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


        #endregion
    }
}
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
    public class ClsMethod_ComplaintFormM_Addmore_Respondent
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_FormM_Respondent(ClsPrp_ComplaintFormMN_Addmore_Respondent smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_AddtionRespondent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionRespondentM_IndexID", (smodel.AdditionRespondent_IndexID == 0) ? 0 : smodel.AdditionRespondent_IndexID);
            cmd.Parameters.AddWithValue("p_AdditionRespondentM_ID", (smodel.AdditionRespondent_ID == 0) ? 0 : smodel.AdditionRespondent_ID);

            if (smodel.AdditionRespondent_RelatedComplaint_ID == null || smodel.AdditionRespondent_RelatedComplaint_ID == 0)
            { cmd.Parameters.AddWithValue("p_AdditionRespondentM_RelatedComplaint_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_AdditionRespondentM_RelatedComplaint_ID", smodel.AdditionRespondent_RelatedComplaint_ID); }

            cmd.Parameters.AddWithValue("p_AdditionRespondentM_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.AdditionRespondent_RelatedComplaint_Code) ? "" : smodel.AdditionRespondent_RelatedComplaint_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", (smodel.Profile_ID == 0) ? 0 : smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");

            cmd.Parameters.AddWithValue("p_RespondentM_Name", String.IsNullOrEmpty(smodel.Name_of_Respondant_or_Applicant) ? "" : smodel.Name_of_Respondant_or_Applicant);
            cmd.Parameters.AddWithValue("p_RespondentM_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);


            if (smodel.MobileNumber == 0 || smodel.MobileNumber == null)
            { cmd.Parameters.AddWithValue("p_MobileNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber); }

            //cmd.Parameters.AddWithValue("p_MobileNumber", (smodel.MobileNumber == 0) ? 0 : smodel.MobileNumber);
            if (smodel.LandlineNumber == 0 || smodel.LandlineNumber == null)
            { cmd.Parameters.AddWithValue("p_LandlineFaxNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_LandlineFaxNumber", smodel.LandlineNumber); }

            cmd.Parameters.AddWithValue("p_OfficeResRespondentM_AddressLine1", String.IsNullOrEmpty(smodel.RegOffice_AddressLine1) ? "" : smodel.RegOffice_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentM_AddressLine2", String.IsNullOrEmpty(smodel.RegOffice_AddressLine2) ? "" : smodel.RegOffice_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentM_AddressStateCode", (smodel.RegOffice_AddressStateCode == 0) ? 0 : smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentM_AddressDistrictCode", (smodel.RegOffice_AddressDistrictCode == 0) ? 0 : smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentM_AddressPIN", String.IsNullOrEmpty(smodel.RegOffice_AddressPIN) ? "0" : smodel.RegOffice_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResAddress_SameAsServiceNoticeAddress", String.IsNullOrEmpty(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()));

            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressLine1", String.IsNullOrEmpty(smodel.Service_AddressLine1) ? "" : smodel.Service_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressLine2", String.IsNullOrEmpty(smodel.Service_AddressLine2) ? "" : smodel.Service_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressStateCode", (smodel.Service_AddressStateCode == 0) ? 0 : smodel.Service_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressDistrictCode", (smodel.Service_AddressDistrictCode == 0) ? 0 : smodel.Service_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressPIN", (smodel.Service_AddressPIN == 0) ? "0" : smodel.Service_AddressPIN.ToString());

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? " " : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? " " : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? " " : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? " " : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsTempTable", (smodel.IsTempTable == 0) ? 0 : smodel.IsTempTable);

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_Get_Respondent_ID", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            Int64 AppId = 0;
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                AppId = Convert.ToInt64(AppPar.Value);
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                AppId = 0;
            }
            return AppId;
        }

        public List<ClsPrp_ComplaintFormMN_Addmore_Respondent> Display_Respondent_Detail(Int64 parmProfile_ID, Int64 parmComplaint_ID, string parmFormType_ID, string parmUser_ID, Int32 parmSessionTempFlag)
        {
            connection();
            List<ClsPrp_ComplaintFormMN_Addmore_Respondent> ComplaintRegistration_list = new List<ClsPrp_ComplaintFormMN_Addmore_Respondent>();

            MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormM_AddtionalRespondent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Profile_ID", parmProfile_ID);
            cmd.Parameters.AddWithValue("p_Complaint_ID", parmComplaint_ID);
            cmd.Parameters.AddWithValue("p_User_ID", parmUser_ID);
            cmd.Parameters.AddWithValue("p_ComplaintTypeFlag", parmFormType_ID);
            cmd.Parameters.AddWithValue("p_SessionTempFlag", parmSessionTempFlag); // When Flag=0, then Session: Yes, IsTempTable: No. When Flag=1, then Session: No, IsTempTable: Yes 
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_ComplaintFormMN_Addmore_Respondent
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
                           RegOffice_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondentM_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondentM_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResRespondentM_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToInt32(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToInt32(dr["ServiceNotices_AddressDistrictCode"]),
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

        public bool Delete_FormM_Respondent(Int64 AddRespondent_ID, Int64 AddRespondent_IndexID, Int64 AddProfile_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_AdditionalRespondentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AdditionRespondentM_ID", AddRespondent_ID);
            cmd.Parameters.AddWithValue("p_AdditionRespondentM_IndexID", AddRespondent_IndexID);
            cmd.Parameters.AddWithValue("p_Profile_ID", AddProfile_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        #region EXECUTION

        public Int64 Add_FormExe_Respondent(ClsPrp_ComplaintFormExe_Addmore_Respondent smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formExe_AddtionRespondent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionRespondentExe_IndexID", (smodel.AdditionRespondent_IndexID == 0) ? 0 : smodel.AdditionRespondent_IndexID);
            cmd.Parameters.AddWithValue("p_AdditionRespondentExe_ID", (smodel.AdditionRespondent_ID == 0) ? 0 : smodel.AdditionRespondent_ID);

            if (smodel.AdditionRespondent_RelatedComplaint_ID == null || smodel.AdditionRespondent_RelatedComplaint_ID == 0)
            { cmd.Parameters.AddWithValue("p_AdditionRespondentExe_RelatedComplaint_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_AdditionRespondentExe_RelatedComplaint_ID", smodel.AdditionRespondent_RelatedComplaint_ID); }

            cmd.Parameters.AddWithValue("p_AdditionRespondentExe_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.AdditionRespondent_RelatedComplaint_Code) ? "" : smodel.AdditionRespondent_RelatedComplaint_Code);
            cmd.Parameters.AddWithValue("p_Profile_ID", (smodel.Profile_ID == 0) ? 0 : smodel.Profile_ID);
            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ComplaintType_Exe", "FormTypeExe");

            cmd.Parameters.AddWithValue("p_RespondentExe_Name", String.IsNullOrEmpty(smodel.Name_of_Respondant_or_Applicant) ? "" : smodel.Name_of_Respondant_or_Applicant);
            cmd.Parameters.AddWithValue("p_RespondentExe_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);


            if (smodel.MobileNumber == 0 || smodel.MobileNumber == null)
            { cmd.Parameters.AddWithValue("p_MobileNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber); }

            //cmd.Parameters.AddWithValue("p_MobileNumber", (smodel.MobileNumber == 0) ? 0 : smodel.MobileNumber);
            if (smodel.LandlineNumber == 0 || smodel.LandlineNumber == null)
            { cmd.Parameters.AddWithValue("p_LandlineFaxNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_LandlineFaxNumber", smodel.LandlineNumber); }

            cmd.Parameters.AddWithValue("p_OfficeResRespondentExe_AddressLine1", String.IsNullOrEmpty(smodel.RegOffice_AddressLine1) ? "" : smodel.RegOffice_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentExe_AddressLine2", String.IsNullOrEmpty(smodel.RegOffice_AddressLine2) ? "" : smodel.RegOffice_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentExe_AddressStateCode", (smodel.RegOffice_AddressStateCode == 0) ? 0 : smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentExe_AddressDistrictCode", (smodel.RegOffice_AddressDistrictCode == 0) ? 0 : smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResRespondentExe_AddressPIN", String.IsNullOrEmpty(smodel.RegOffice_AddressPIN) ? "0" : smodel.RegOffice_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResAddress_SameAsServiceNoticeAddress", String.IsNullOrEmpty(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()));

            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressLine1", String.IsNullOrEmpty(smodel.Service_AddressLine1) ? "" : smodel.Service_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressLine2", String.IsNullOrEmpty(smodel.Service_AddressLine2) ? "" : smodel.Service_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressStateCode", (smodel.Service_AddressStateCode == 0) ? 0 : smodel.Service_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressDistrictCode", (smodel.Service_AddressDistrictCode == 0) ? 0 : smodel.Service_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNotices_AddressPIN", (smodel.Service_AddressPIN == 0) ? "0" : smodel.Service_AddressPIN.ToString());

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? " " : smodel.Remarks_IfAny);
            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? " " : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? " " : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? " " : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            cmd.Parameters.AddWithValue("p_IsPublicView", (smodel.IsPublicView == 0) ? 0 : smodel.IsPublicView);
            cmd.Parameters.AddWithValue("p_IsTempTable", (smodel.IsTempTable == 0) ? 0 : smodel.IsTempTable);

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_Get_Respondent_ID", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            Int64 AppId = 0;
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                AppId = Convert.ToInt64(AppPar.Value);
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                AppId = 0;
            }
            return AppId;
        }

        public List<ClsPrp_ComplaintFormExe_Addmore_Respondent> Display_Respondent_Execution_Detail(Int64 parmProfile_ID, Int64 parmComplaint_ID, string parmFormType_ID, string parmUser_ID, Int32 parmSessionTempFlag)
        {
            connection();
            List<ClsPrp_ComplaintFormExe_Addmore_Respondent> ComplaintRegistration_list = new List<ClsPrp_ComplaintFormExe_Addmore_Respondent>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormExe_AddtionalRespondent", con);
                //MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormM_AddtionalRespondent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Profile_ID", parmProfile_ID);
                cmd.Parameters.AddWithValue("p_Complaint_ID", parmComplaint_ID);
                cmd.Parameters.AddWithValue("p_User_ID", parmUser_ID);
                cmd.Parameters.AddWithValue("p_ComplaintTypeFlag", parmFormType_ID);
                cmd.Parameters.AddWithValue("p_SessionTempFlag", parmSessionTempFlag); // When Flag=0, then Session: Yes, IsTempTable: No. When Flag=1, then Session: No, IsTempTable: Yes 
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ComplaintRegistration_list.Add(
                           new ClsPrp_ComplaintFormExe_Addmore_Respondent
                           {
                               AdditionRespondent_IndexID = Convert.ToInt64(dr["AdditionRespondentExe_IndexID"]),
                               AdditionRespondent_ID = Convert.ToInt64(dr["AdditionRespondentExe_ID"]),
                               AdditionRespondent_RelatedComplaint_ID = Convert.ToInt64(dr["AdditionRespondentExe_RelatedComplaint_ID"]),
                               AdditionRespondent_RelatedComplaint_Code = Convert.ToString(dr["AdditionRespondentExe_RelatedComplaint_Code"]),
                               Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),
                               ComplaintType_Exe = Convert.ToString(dr["ComplaintType_Exe"]),

                               Name_of_Respondant_or_Applicant = Convert.ToString(dr["RespondentExe_Name"]),
                               EmailAddress = Convert.ToString(dr["RespondentExe_EmailAddress"]),
                               MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                               LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),
                               Repondant_AadhaarNumber = 0,
                               RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResRespondentExe_AddressLine1"]),
                               RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResRespondentExe_AddressLine2"]),
                               RegOffice_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondentExe_AddressStateCode"]),
                               RegOffice_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondentExe_AddressDistrictCode"]),
                               RegOffice_AddressPIN = Convert.ToString(dr["OfficeResRespondentExe_AddressPIN"]),

                               IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                               Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                               Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                               Service_AddressStateCode = Convert.ToInt32(dr["ServiceNotices_AddressStateCode"]),
                               Service_AddressDistrictCode = Convert.ToInt32(dr["ServiceNotices_AddressDistrictCode"]),
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
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return ComplaintRegistration_list;
        }

        public bool Delete_FormExe_Respondent(Int64 AddRespondent_ID, Int64 AddRespondent_IndexID, Int64 AddProfile_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormExe_AdditionalRespondentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AdditionRespondentExe_ID", AddRespondent_ID);
            cmd.Parameters.AddWithValue("p_AdditionRespondentExe_IndexID", AddRespondent_IndexID);
            cmd.Parameters.AddWithValue("p_Profile_ID", AddProfile_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion

        public List<ClsPrp_ComplaintFormMN_Addmore_Respondent> Display_Respondent_DetailM(Int64 parmProfile_ID, Int64 parmComplaint_ID, string parmFormType_ID, string parmUser_ID, Int32 parmSessionTempFlag)
        {
            connection();
            List<ClsPrp_ComplaintFormMN_Addmore_Respondent> ComplaintRegistration_list = new List<ClsPrp_ComplaintFormMN_Addmore_Respondent>();

            MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormM_AddtionalRespondentTEST", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Profile_ID", parmProfile_ID);
            cmd.Parameters.AddWithValue("p_Complaint_ID", parmComplaint_ID);
            cmd.Parameters.AddWithValue("p_User_ID", parmUser_ID);
            cmd.Parameters.AddWithValue("p_ComplaintTypeFlag", parmFormType_ID);
            cmd.Parameters.AddWithValue("p_SessionTempFlag", parmSessionTempFlag); // When Flag=0, then Session: Yes, IsTempTable: No. When Flag=1, then Session: No, IsTempTable: Yes 
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ComplaintRegistration_list.Add(
                       new ClsPrp_ComplaintFormMN_Addmore_Respondent
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
                           RegOffice_AddressStateCode = Convert.ToInt32(dr["OfficeResRespondentM_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToInt32(dr["OfficeResRespondentM_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResRespondentM_AddressPIN"]),

                           IsSameCommunicationAdd_ResOffAdd = ((dr["IsOfficeResAddress_SameAsServiceNoticeAddress"] as string == "1") ? true : false),

                           Service_AddressLine1 = Convert.ToString(dr["ServiceNotices_AddressLine1"]),
                           Service_AddressLine2 = Convert.ToString(dr["ServiceNotices_AddressLine2"]),
                           Service_AddressStateCode = Convert.ToInt32(dr["ServiceNotices_AddressStateCode"]),
                           Service_AddressDistrictCode = Convert.ToInt32(dr["ServiceNotices_AddressDistrictCode"]),
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

    }
}
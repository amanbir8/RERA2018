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
    public class ClsMethod_ComplaintFormM_Addmore_Complainant
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public Int64 Add_FormM_Complainant(ClsPrp_ComplaintFormMN_Addmore_Complainant smodel, string UID, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formm_AddtionComplainant", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionComplainant_IndexID", smodel.AdditionComplainant_IndexID);

            if (smodel.AdditionComplainant_ID == 0)
            { cmd.Parameters.AddWithValue("p_AdditionComplainant_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_AdditionComplainant_ID", smodel.AdditionComplainant_ID); }

            if (smodel.ComplainantApplicant_RelatedComplaint_ID == null || smodel.ComplainantApplicant_RelatedComplaint_ID == 0)
            { cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", smodel.ComplainantApplicant_RelatedComplaint_ID); }

            cmd.Parameters.AddWithValue("p_ComplainantorApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.ComplainantorApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantorApplicant_RelatedComplaint_Code);

            if (smodel.Profile_ID == 0)
            { cmd.Parameters.AddWithValue("p_Profile_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID); }

            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ComplaintType_MN", "FormTypeM");

            cmd.Parameters.AddWithValue("p_Name_of_Complainant_or_Applicant", String.IsNullOrEmpty(smodel.Name_of_Complainant_or_Applicant) ? "" : smodel.Name_of_Complainant_or_Applicant);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);

            if (smodel.LandlineNumber == 0 || smodel.LandlineNumber == null)
            { cmd.Parameters.AddWithValue("p_LandlineNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_LandlineNumber", smodel.LandlineNumber); }

            if (smodel.Complainant_AadhaarNumber == 0 || smodel.Complainant_AadhaarNumber == null)
            { cmd.Parameters.AddWithValue("p_AadhaarNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_AadhaarNumber", smodel.Complainant_AadhaarNumber); }

            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", String.IsNullOrEmpty(smodel.RegOffice_AddressLine1) ? "" : smodel.RegOffice_AddressLine1);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", String.IsNullOrEmpty(smodel.RegOffice_AddressLine2) ? "" : smodel.RegOffice_AddressLine2);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", smodel.RegOffice_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsSameAddressAsAbove", String.IsNullOrEmpty(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()));

            cmd.Parameters.AddWithValue("p_Service_AddressLine1", String.IsNullOrEmpty(smodel.Service_AddressLine1) ? "" : smodel.Service_AddressLine1);
            cmd.Parameters.AddWithValue("p_Service_AddressLine2", String.IsNullOrEmpty(smodel.Service_AddressLine2) ? "" : smodel.Service_AddressLine2);
            cmd.Parameters.AddWithValue("p_Service_AddressStateCode", smodel.Service_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Service_AddressDistrictCode", smodel.Service_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Service_AddressPIN", smodel.Service_AddressPIN);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? " " : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? " " : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? " " : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? " " : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            if (smodel.IsPublicView == 0)
            { cmd.Parameters.AddWithValue("p_IsPublicView", 0); }
            else
            { cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView); }

            if (smodel.IsTempTable == 0)
            { cmd.Parameters.AddWithValue("p_IsTempTable", 0); }
            else
            { cmd.Parameters.AddWithValue("p_IsTempTable", smodel.IsTempTable); }

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_Get_Complainant_ID", MySqlDbType.Int64);
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

        public List<ClsPrp_ComplaintFormMN_Addmore_Complainant> Display_Complainant_Detail(Int64 parmProfile_ID, Int64 parmComplaint_ID, string parmFormType_ID, string parmUser_ID, Int32 parmSessionTempFlag)
        {
            connection();
            List<ClsPrp_ComplaintFormMN_Addmore_Complainant> ComplaintRegistration_list = new List<ClsPrp_ComplaintFormMN_Addmore_Complainant>();

            MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormM_AddtionalComplainant", con);
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
                       new ClsPrp_ComplaintFormMN_Addmore_Complainant
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
                           RegOffice_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                           RegOffice_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                           RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

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

        public bool Delete_FormM_Complainant(Int64 AddComplaint_ID, Int64 AddComplaint_IndexID, Int64 AddProfile_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormM_AdditionalComplainantByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AdditionComplainant_ID", AddComplaint_ID);
            cmd.Parameters.AddWithValue("p_AdditionComplainant_IndexID", AddComplaint_IndexID);
            cmd.Parameters.AddWithValue("p_Profile_ID", AddProfile_ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



        #region ADDITION COMPLAINT EXECUTION

        public Int64 Add_FormExe_Complainant(ClsPrp_ComplaintFormExe_Addmore_Complainant smodel, string UID, string userName)
        {

            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_formExe_AddtionComplainant", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_AdditionComplainant_IndexID", smodel.AdditionComplainant_IndexID);

            if (smodel.AdditionComplainant_ID == 0)
            { cmd.Parameters.AddWithValue("p_AdditionComplainant_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_AdditionComplainant_ID", smodel.AdditionComplainant_ID); }

            if (smodel.ComplainantApplicant_RelatedComplaint_ID == null || smodel.ComplainantApplicant_RelatedComplaint_ID == 0)
            { cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_ComplainantApplicant_RelatedComplaint_ID", smodel.ComplainantApplicant_RelatedComplaint_ID); }

            cmd.Parameters.AddWithValue("p_ComplainantorApplicant_RelatedComplaint_Code", String.IsNullOrEmpty(smodel.ComplainantorApplicant_RelatedComplaint_Code) ? "" : smodel.ComplainantorApplicant_RelatedComplaint_Code);

            if (smodel.Profile_ID == 0)
            { cmd.Parameters.AddWithValue("p_Profile_ID", 0); }
            else
            { cmd.Parameters.AddWithValue("p_Profile_ID", smodel.Profile_ID); }

            cmd.Parameters.AddWithValue("p_User_ID", String.IsNullOrEmpty(UID) ? "" : UID);
            cmd.Parameters.AddWithValue("p_ComplaintType_Exe", "FormTypeExe");

            cmd.Parameters.AddWithValue("p_Name_of_Complainant_or_Applicant", String.IsNullOrEmpty(smodel.Name_of_Complainant_or_Applicant) ? "" : smodel.Name_of_Complainant_or_Applicant);
            cmd.Parameters.AddWithValue("p_EmailAddress", String.IsNullOrEmpty(smodel.EmailAddress) ? "" : smodel.EmailAddress);
            cmd.Parameters.AddWithValue("p_MobileNumber", smodel.MobileNumber);

            if (smodel.LandlineNumber == 0 || smodel.LandlineNumber == null)
            { cmd.Parameters.AddWithValue("p_LandlineNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_LandlineNumber", smodel.LandlineNumber); }

            if (smodel.Complainant_AadhaarNumber == 0 || smodel.Complainant_AadhaarNumber == null)
            { cmd.Parameters.AddWithValue("p_AadhaarNumber", 0); }
            else
            { cmd.Parameters.AddWithValue("p_AadhaarNumber", smodel.Complainant_AadhaarNumber); }

            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine1", String.IsNullOrEmpty(smodel.RegOffice_AddressLine1) ? "" : smodel.RegOffice_AddressLine1);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressLine2", String.IsNullOrEmpty(smodel.RegOffice_AddressLine2) ? "" : smodel.RegOffice_AddressLine2);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressStateCode", smodel.RegOffice_AddressStateCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressDistrictCode", smodel.RegOffice_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_RegOffice_AddressPIN", smodel.RegOffice_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsSameAddressAsAbove", String.IsNullOrEmpty(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()) ? (bool?)null : bool.Parse(smodel.IsSameCommunicationAdd_ResOffAdd.ToString()));

            cmd.Parameters.AddWithValue("p_Service_AddressLine1", String.IsNullOrEmpty(smodel.Service_AddressLine1) ? "" : smodel.Service_AddressLine1);
            cmd.Parameters.AddWithValue("p_Service_AddressLine2", String.IsNullOrEmpty(smodel.Service_AddressLine2) ? "" : smodel.Service_AddressLine2);
            cmd.Parameters.AddWithValue("p_Service_AddressStateCode", smodel.Service_AddressStateCode);
            cmd.Parameters.AddWithValue("p_Service_AddressDistrictCode", smodel.Service_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_Service_AddressPIN", smodel.Service_AddressPIN);

            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? " " : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? " " : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? " " : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? " " : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_IsLock", 0);
            if (smodel.IsPublicView == 0)
            { cmd.Parameters.AddWithValue("p_IsPublicView", 0); }
            else
            { cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView); }

            if (smodel.IsTempTable == 0)
            { cmd.Parameters.AddWithValue("p_IsTempTable", 0); }
            else
            { cmd.Parameters.AddWithValue("p_IsTempTable", smodel.IsTempTable); }

            cmd.Parameters.AddWithValue("p_CreatedBy", userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_Get_Complainant_ID", MySqlDbType.Int64);
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

        public List<ClsPrp_ComplaintFormExe_Addmore_Complainant> Display_ComplainantExe_Detail(Int64 parmProfile_ID, Int64 parmComplaint_ID, string parmFormType_ID, string parmUser_ID, Int32 parmSessionTempFlag)
        {
            connection();
            List<ClsPrp_ComplaintFormExe_Addmore_Complainant> ComplaintRegistration_list = new List<ClsPrp_ComplaintFormExe_Addmore_Complainant>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormExe_AddtionalComplainant", con);
                //MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormM_AddtionalComplainant", con);
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
                           new ClsPrp_ComplaintFormExe_Addmore_Complainant
                           {
                               AdditionComplainant_IndexID = Convert.ToInt64(dr["ComplainantorApplicant_IndexID"]),
                               AdditionComplainant_ID = Convert.ToInt64(dr["ComplainantorApplicant_ID"]),
                               ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantorApplicant_RelatedComplaint_ID"]),
                               ComplainantorApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantorApplicant_RelatedComplaint_Code"]),
                               Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                               User_ID = Convert.ToString(dr["User_ID"]),
                               ComplaintType_Exe = Convert.ToString(dr["ComplaintType_Exe"]),
                               //ComplaintType_Exe = Convert.ToString(dr["ComplaintType_MN"]),

                               Name_of_Complainant_or_Applicant = Convert.ToString(dr["ComplainantorApplicant_Name"]),
                               EmailAddress = Convert.ToString(dr["ComplainantorApplicant_EmailAddress"]),
                               MobileNumber = Convert.ToInt64(dr["MobileNumber"]),
                               LandlineNumber = Convert.ToInt64(dr["LandlineFaxNumber"]),

                               Complainant_AadhaarNumber = Convert.ToInt64(dr["AadhaarNumber"]),

                               RegOffice_AddressLine1 = Convert.ToString(dr["OfficeResComplainant_AddressLine1"]),
                               RegOffice_AddressLine2 = Convert.ToString(dr["OfficeResComplainant_AddressLine2"]),
                               RegOffice_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                               RegOffice_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                               RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

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

        public bool Delete_FormExe_Complainant(Int64 AddComplaint_ID, Int64 AddComplaint_IndexID, Int64 AddProfile_ID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_Complaint_FormExe_AdditionalComplainantByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_AdditionComplainant_ID", AddComplaint_ID);
            cmd.Parameters.AddWithValue("p_AdditionComplainant_IndexID", AddComplaint_IndexID);
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


        public List<ClsPrp_ComplaintFormMN_Addmore_Complainant> Display_Complainant_DetailM(Int64 parmProfile_ID, Int64 parmComplaint_ID, string parmFormType_ID, string parmUser_ID, Int32 parmSessionTempFlag)
        {
            connection();
            List<ClsPrp_ComplaintFormMN_Addmore_Complainant> ComplaintRegistration_list = new List<ClsPrp_ComplaintFormMN_Addmore_Complainant>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_rera_Complaint_FormM_AddtionalComplainantTEST", con);
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
                           new ClsPrp_ComplaintFormMN_Addmore_Complainant
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
                               RegOffice_AddressStateCode = Convert.ToInt32(dr["OfficeResComplainant_AddressStateCode"]),
                               RegOffice_AddressDistrictCode = Convert.ToInt32(dr["OfficeResComplainant_AddressDistrictCode"]),
                               RegOffice_AddressPIN = Convert.ToString(dr["OfficeResComplainant_AddressPIN"]),

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

    }
}
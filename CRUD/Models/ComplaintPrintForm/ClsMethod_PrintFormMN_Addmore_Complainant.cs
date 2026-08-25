using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsMethod_PrintFormMN_Addmore_Complainant
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_Print_FormMN_AddMore_Complainant> Print_ComplainantFormM_Detail(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_Print_FormMN_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_Print_FormMN_AddMore_Complainant>();

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
                       new ClsPrp_Print_FormMN_AddMore_Complainant
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

        public List<ClsPrp_Print_FormMN_AddMore_Complainant> Print_ComplainantFormN_Detail(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_Print_FormMN_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_Print_FormMN_AddMore_Complainant>();

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
                       new ClsPrp_Print_FormMN_AddMore_Complainant
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



        public List<ClsPrp_Print_FormExe_AddMore_Complainant> Print_ComplainantFormExe_Detail(Int64 parmComplaint_ID)
        {
            connection();
            List<ClsPrp_Print_FormExe_AddMore_Complainant> ComplaintRegistration_list = new List<ClsPrp_Print_FormExe_AddMore_Complainant>();

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
                       new ClsPrp_Print_FormExe_AddMore_Complainant
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
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return ComplaintRegistration_list;
        }

    }
}
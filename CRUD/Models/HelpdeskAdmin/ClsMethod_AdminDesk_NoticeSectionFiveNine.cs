using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.HelpdeskComplaint;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsMethod_AdminDesk_NoticeSectionFiveNine
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Extra
        public bool Add_AdminDesk_NoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNine smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_NoticesSectionFiveNineDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", smodel.NoticesSectionFiveNine_IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", smodel.NoticesSectionFiveNine_ID);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_DistrictTown_InfoName", String.IsNullOrEmpty(smodel.DistrictTown_InfoName) ? "" : smodel.DistrictTown_InfoName);
            cmd.Parameters.AddWithValue("p_DistrictTown_InfoCode", String.IsNullOrEmpty(smodel.DistrictTown_InfoCode) ? "" : smodel.DistrictTown_InfoCode);
            cmd.Parameters.AddWithValue("p_NoticeFile_NumberDetails", String.IsNullOrEmpty(smodel.NoticeFile_NumberDetails) ? "" : smodel.NoticeFile_NumberDetails);
            cmd.Parameters.AddWithValue("p_NoticeDate", smodel.NoticeDate == null ? dtvalue : smodel.NoticeDate);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterNameWithAddressDetails", String.IsNullOrEmpty(smodel.PromoterNameWithAddressDetails) ? "" : smodel.PromoterNameWithAddressDetails);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectNameWithAddressDetails", String.IsNullOrEmpty(smodel.ProjectNameWithAddressDetails) ? "" : smodel.ProjectNameWithAddressDetails); 
            cmd.Parameters.AddWithValue("p_CurrentStatusDate", smodel.CurrentStatusDate == null ? dtvalue : smodel.CurrentStatusDate);
            cmd.Parameters.AddWithValue("p_CurrentStatusWithRemarks", String.IsNullOrEmpty(smodel.CurrentStatusWithRemarks) ? "" : smodel.CurrentStatusWithRemarks);
            cmd.Parameters.AddWithValue("p_OrderDate", smodel.OrderDate == null ? dtvalue : smodel.OrderDate); 
            cmd.Parameters.AddWithValue("p_OrderDateWithRemarksIfAny", String.IsNullOrEmpty(smodel.OrderDateWithRemarksIfAny) ? "" : smodel.OrderDateWithRemarksIfAny); 
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny); 

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);
            
            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_AdminDesk_NoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNine smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_NoticesSectionFiveNineDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", smodel.NoticesSectionFiveNine_IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", smodel.NoticesSectionFiveNine_ID);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_DistrictTown_InfoName", String.IsNullOrEmpty(smodel.DistrictTown_InfoName) ? "" : smodel.DistrictTown_InfoName);
            cmd.Parameters.AddWithValue("p_DistrictTown_InfoCode", String.IsNullOrEmpty(smodel.DistrictTown_InfoCode) ? "" : smodel.DistrictTown_InfoCode);
            cmd.Parameters.AddWithValue("p_NoticeFile_NumberDetails", String.IsNullOrEmpty(smodel.NoticeFile_NumberDetails) ? "" : smodel.NoticeFile_NumberDetails);
            cmd.Parameters.AddWithValue("p_NoticeDate", smodel.NoticeDate == null ? dtvalue : smodel.NoticeDate);
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterNameWithAddressDetails", String.IsNullOrEmpty(smodel.PromoterNameWithAddressDetails) ? "" : smodel.PromoterNameWithAddressDetails);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectNameWithAddressDetails", String.IsNullOrEmpty(smodel.ProjectNameWithAddressDetails) ? "" : smodel.ProjectNameWithAddressDetails);
            cmd.Parameters.AddWithValue("p_CurrentStatusDate", smodel.CurrentStatusDate == null ? dtvalue : smodel.CurrentStatusDate);
            cmd.Parameters.AddWithValue("p_CurrentStatusWithRemarks", String.IsNullOrEmpty(smodel.CurrentStatusWithRemarks) ? "" : smodel.CurrentStatusWithRemarks);
            cmd.Parameters.AddWithValue("p_OrderDate", smodel.OrderDate == null ? dtvalue : smodel.OrderDate);
            cmd.Parameters.AddWithValue("p_OrderDateWithRemarksIfAny", String.IsNullOrEmpty(smodel.OrderDateWithRemarksIfAny) ? "" : smodel.OrderDateWithRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNine> Display_AdminDesk_NoticeSectionFiveNineDetails(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNine> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNine>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNine", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNine
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),
                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNine> Display_AdminDesk_NoticeSectionFiveNineDetailsByID(Int64 IndexID,Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNine> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNine>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSecFiveNineByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNine
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),
                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Delete_AdminDesk_NoticeSectionFiveNineDetailsByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_NoticesSecFiveNineByIndexID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // 59 by LA
        public bool Add_AdminDesk_NoticeSectionFiveNineDetailsByLA(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_NoticesSectionFiveNineDetailsByLA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", smodel.NoticesSectionFiveNine_IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", smodel.NoticesSectionFiveNine_ID);

            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IDYear", smodel.NoticesSectionFiveNine_IDYear);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IDName", String.IsNullOrEmpty(smodel.NoticesSectionFiveNine_IDName) ? "" : smodel.NoticesSectionFiveNine_IDName);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceID", smodel.Notice_RelatedReferenceID);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceDate", smodel.Notice_RelatedReferenceDate == null ? dtvalue : smodel.Notice_RelatedReferenceDate);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceName", String.IsNullOrEmpty(smodel.Notice_RelatedReferenceName) ? "" : smodel.Notice_RelatedReferenceName);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceCode", String.IsNullOrEmpty(smodel.Notice_RelatedReferenceCode) ? "" : smodel.Notice_RelatedReferenceCode);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_DistrictTown_InfoName", String.IsNullOrEmpty(smodel.DistrictTown_InfoName) ? "" : smodel.DistrictTown_InfoName);
            cmd.Parameters.AddWithValue("p_DistrictTown_InfoCode", String.IsNullOrEmpty(smodel.DistrictTown_InfoCode) ? "" : smodel.DistrictTown_InfoCode);
            cmd.Parameters.AddWithValue("p_NoticeFile_NumberDetails", String.IsNullOrEmpty(smodel.NoticeFile_NumberDetails) ? "" : smodel.NoticeFile_NumberDetails);
            cmd.Parameters.AddWithValue("p_NoticeDate", smodel.NoticeDate == null ? dtvalue : smodel.NoticeDate);
            cmd.Parameters.AddWithValue("p_Notice_ModeOfComplaint", String.IsNullOrEmpty(smodel.Notice_ModeOfComplaint) ? "" : smodel.Notice_ModeOfComplaint);
            cmd.Parameters.AddWithValue("p_Notice_ModeOfComplaintSpecifyOthers", String.IsNullOrEmpty(smodel.Notice_ModeOfComplaintSpecifyOthers) ? "" : smodel.Notice_ModeOfComplaintSpecifyOthers);
            
            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterNameWithAddressDetails", String.IsNullOrEmpty(smodel.PromoterNameWithAddressDetails) ? "" : smodel.PromoterNameWithAddressDetails);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectNameWithAddressDetails", String.IsNullOrEmpty(smodel.ProjectNameWithAddressDetails) ? "" : smodel.ProjectNameWithAddressDetails);

            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? "" : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", String.IsNullOrEmpty(smodel.Complainant_EmailAddress) ? "" : smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber == null ? 0 : smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber == null ? 0 : smodel.Complainant_AadhaarNumber);

            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine1) ? "" : smodel.OfficeResComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine2) ? "" : smodel.OfficeResComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressStateCode", smodel.OfficeResComplainant_AddressStateCode == null ? 0 : smodel.OfficeResComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressDistrictCode", smodel.OfficeResComplainant_AddressDistrictCode == null ? 0 : smodel.OfficeResComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressPIN) ? "" : smodel.OfficeResComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResComplainantAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine1) ? "" : smodel.ServiceNoticesComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine2) ? "" : smodel.ServiceNoticesComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressStateCode", smodel.ServiceNoticesComplainant_AddressStateCode == null ? 0 : smodel.ServiceNoticesComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressDistrictCode", smodel.ServiceNoticesComplainant_AddressDistrictCode == null ? 0 : smodel.ServiceNoticesComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressPIN) ? "" : smodel.ServiceNoticesComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_Name", String.IsNullOrEmpty(smodel.AuthorizedCounsel_Name) ? "" : smodel.AuthorizedCounsel_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_EmailAddress", String.IsNullOrEmpty(smodel.AuthorizedCounsel_EmailAddress) ? "" : smodel.AuthorizedCounsel_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_MobileNumber", smodel.AuthorizedCounsel_MobileNumber == null ? 0 : smodel.AuthorizedCounsel_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_LandlineFaxNumber", smodel.AuthorizedCounsel_LandlineFaxNumber == null ? 0 : smodel.AuthorizedCounsel_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_CurrentStatusDate", smodel.CurrentStatusDate == null ? dtvalue : smodel.CurrentStatusDate);            
            cmd.Parameters.AddWithValue("p_CurrentStatusTitle", String.IsNullOrEmpty(smodel.CurrentStatusTitle) ? "" : smodel.CurrentStatusTitle);            
            cmd.Parameters.AddWithValue("p_CurrentStatusWithRemarks", String.IsNullOrEmpty(smodel.CurrentStatusWithRemarks) ? "" : smodel.CurrentStatusWithRemarks);

            cmd.Parameters.AddWithValue("p_IsPersonalHearing", smodel.IsPersonalHearing);
            cmd.Parameters.AddWithValue("p_HearingBenchCode", String.IsNullOrEmpty(smodel.HearingBenchCode) ? "" : smodel.HearingBenchCode);
            cmd.Parameters.AddWithValue("p_HearingBenchName", String.IsNullOrEmpty(smodel.HearingBenchName) ? "" : smodel.HearingBenchName);
            cmd.Parameters.AddWithValue("p_FixedFor", String.IsNullOrEmpty(smodel.FixedFor) ? "" : smodel.FixedFor);
            cmd.Parameters.AddWithValue("p_OrderDate", smodel.OrderDate == null ? dtvalue : smodel.OrderDate);
            cmd.Parameters.AddWithValue("p_OrderTime", String.IsNullOrEmpty(smodel.OrderTime) ? "" : smodel.OrderTime);
            cmd.Parameters.AddWithValue("p_OrderDateStatusTitle", String.IsNullOrEmpty(smodel.OrderDateStatusTitle) ? "" : smodel.OrderDateStatusTitle);
            cmd.Parameters.AddWithValue("p_OrderDateWithRemarksIfAny", String.IsNullOrEmpty(smodel.OrderDateWithRemarksIfAny) ? "" : smodel.OrderDateWithRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedCode", smodel.CurrentEvent_IdentifiedCode);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedAggregateName", String.IsNullOrEmpty(smodel.CurrentEvent_IdentifiedAggregateName) ? "" : smodel.CurrentEvent_IdentifiedAggregateName);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedBy", String.IsNullOrEmpty(smodel.CurrentEvent_IdentifiedBy) ? "" : smodel.CurrentEvent_IdentifiedBy);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedOn", smodel.CurrentEvent_IdentifiedOn == null ? dtvalue : smodel.CurrentEvent_IdentifiedOn);

            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedCode", smodel.DeskAction_IdentifiedCode);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedAggregateName", String.IsNullOrEmpty(smodel.DeskAction_IdentifiedAggregateName) ? "" : smodel.DeskAction_IdentifiedAggregateName);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedBy", String.IsNullOrEmpty(smodel.DeskAction_IdentifiedBy) ? "" : smodel.DeskAction_IdentifiedBy);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedOn", smodel.DeskAction_IdentifiedOn == null ? dtvalue : smodel.DeskAction_IdentifiedOn);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            //return AppId;
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool Update_AdminDesk_NoticeSectionFiveNineDetailsByLA(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_update_tbl_RERA_AdminDesk_NoticesSectionFiveNineDetailsByLA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", smodel.NoticesSectionFiveNine_IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", smodel.NoticesSectionFiveNine_ID);

            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IDYear", smodel.NoticesSectionFiveNine_IDYear);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IDName", String.IsNullOrEmpty(smodel.NoticesSectionFiveNine_IDName) ? "" : smodel.NoticesSectionFiveNine_IDName);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceID", smodel.Notice_RelatedReferenceID);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceDate", smodel.Notice_RelatedReferenceDate == null ? dtvalue : smodel.Notice_RelatedReferenceDate);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceName", String.IsNullOrEmpty(smodel.Notice_RelatedReferenceName) ? "" : smodel.Notice_RelatedReferenceName);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceCode", String.IsNullOrEmpty(smodel.Notice_RelatedReferenceCode) ? "" : smodel.Notice_RelatedReferenceCode);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_DistrictTown_InfoName", String.IsNullOrEmpty(smodel.DistrictTown_InfoName) ? "" : smodel.DistrictTown_InfoName);
            cmd.Parameters.AddWithValue("p_DistrictTown_InfoCode", String.IsNullOrEmpty(smodel.DistrictTown_InfoCode) ? "" : smodel.DistrictTown_InfoCode);
            cmd.Parameters.AddWithValue("p_NoticeFile_NumberDetails", String.IsNullOrEmpty(smodel.NoticeFile_NumberDetails) ? "" : smodel.NoticeFile_NumberDetails);
            cmd.Parameters.AddWithValue("p_NoticeDate", smodel.NoticeDate == null ? dtvalue : smodel.NoticeDate);
            cmd.Parameters.AddWithValue("p_Notice_ModeOfComplaint", String.IsNullOrEmpty(smodel.Notice_ModeOfComplaint) ? "" : smodel.Notice_ModeOfComplaint);
            cmd.Parameters.AddWithValue("p_Notice_ModeOfComplaintSpecifyOthers", String.IsNullOrEmpty(smodel.Notice_ModeOfComplaintSpecifyOthers) ? "" : smodel.Notice_ModeOfComplaintSpecifyOthers);

            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterNameWithAddressDetails", String.IsNullOrEmpty(smodel.PromoterNameWithAddressDetails) ? "" : smodel.PromoterNameWithAddressDetails);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectNameWithAddressDetails", String.IsNullOrEmpty(smodel.ProjectNameWithAddressDetails) ? "" : smodel.ProjectNameWithAddressDetails);

            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? "" : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", String.IsNullOrEmpty(smodel.Complainant_EmailAddress) ? "" : smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber == null ? 0 : smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber == null ? 0 : smodel.Complainant_AadhaarNumber);

            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine1) ? "" : smodel.OfficeResComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine2) ? "" : smodel.OfficeResComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressStateCode", smodel.OfficeResComplainant_AddressStateCode == null ? 0 : smodel.OfficeResComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressDistrictCode", smodel.OfficeResComplainant_AddressDistrictCode == null ? 0 : smodel.OfficeResComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressPIN) ? "" : smodel.OfficeResComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResComplainantAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine1) ? "" : smodel.ServiceNoticesComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine2) ? "" : smodel.ServiceNoticesComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressStateCode", smodel.ServiceNoticesComplainant_AddressStateCode == null ? 0 : smodel.ServiceNoticesComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressDistrictCode", smodel.ServiceNoticesComplainant_AddressDistrictCode == null ? 0 : smodel.ServiceNoticesComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressPIN) ? "" : smodel.ServiceNoticesComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_Name", String.IsNullOrEmpty(smodel.AuthorizedCounsel_Name) ? "" : smodel.AuthorizedCounsel_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_EmailAddress", String.IsNullOrEmpty(smodel.AuthorizedCounsel_EmailAddress) ? "" : smodel.AuthorizedCounsel_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_MobileNumber", smodel.AuthorizedCounsel_MobileNumber == null ? 0 : smodel.AuthorizedCounsel_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_LandlineFaxNumber", smodel.AuthorizedCounsel_LandlineFaxNumber == null ? 0 : smodel.AuthorizedCounsel_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_CurrentStatusDate", smodel.CurrentStatusDate == null ? dtvalue : smodel.CurrentStatusDate);
            cmd.Parameters.AddWithValue("p_CurrentStatusTitle", String.IsNullOrEmpty(smodel.CurrentStatusTitle) ? "" : smodel.CurrentStatusTitle);
            cmd.Parameters.AddWithValue("p_CurrentStatusWithRemarks", String.IsNullOrEmpty(smodel.CurrentStatusWithRemarks) ? "" : smodel.CurrentStatusWithRemarks);

            cmd.Parameters.AddWithValue("p_IsPersonalHearing", smodel.IsPersonalHearing);
            cmd.Parameters.AddWithValue("p_HearingBenchCode", String.IsNullOrEmpty(smodel.HearingBenchCode) ? "" : smodel.HearingBenchCode);
            cmd.Parameters.AddWithValue("p_HearingBenchName", String.IsNullOrEmpty(smodel.HearingBenchName) ? "" : smodel.HearingBenchName);
            cmd.Parameters.AddWithValue("p_FixedFor", String.IsNullOrEmpty(smodel.FixedFor) ? "" : smodel.FixedFor);
            cmd.Parameters.AddWithValue("p_OrderDate", smodel.OrderDate == null ? dtvalue : smodel.OrderDate);
            cmd.Parameters.AddWithValue("p_OrderTime", String.IsNullOrEmpty(smodel.OrderTime) ? "" : smodel.OrderTime);
            cmd.Parameters.AddWithValue("p_OrderDateStatusTitle", String.IsNullOrEmpty(smodel.OrderDateStatusTitle) ? "" : smodel.OrderDateStatusTitle);
            cmd.Parameters.AddWithValue("p_OrderDateWithRemarksIfAny", String.IsNullOrEmpty(smodel.OrderDateWithRemarksIfAny) ? "" : smodel.OrderDateWithRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedCode", smodel.CurrentEvent_IdentifiedCode);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedAggregateName", String.IsNullOrEmpty(smodel.CurrentEvent_IdentifiedAggregateName) ? "" : smodel.CurrentEvent_IdentifiedAggregateName);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedBy", String.IsNullOrEmpty(smodel.CurrentEvent_IdentifiedBy) ? "" : smodel.CurrentEvent_IdentifiedBy);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedOn", smodel.CurrentEvent_IdentifiedOn == null ? dtvalue : smodel.CurrentEvent_IdentifiedOn);

            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedCode", smodel.DeskAction_IdentifiedCode);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedAggregateName", String.IsNullOrEmpty(smodel.DeskAction_IdentifiedAggregateName) ? "" : smodel.DeskAction_IdentifiedAggregateName);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedBy", String.IsNullOrEmpty(smodel.DeskAction_IdentifiedBy) ? "" : smodel.DeskAction_IdentifiedBy);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedOn", smodel.DeskAction_IdentifiedOn == null ? dtvalue : smodel.DeskAction_IdentifiedOn);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_NoticeSectionFiveNineDetailsByLA(Int64 Index_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNineByLA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),

                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSecFiveNineByIndexIDbyLA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", KeyID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),

                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Delete_AdminDesk_NoticeSectionFiveNineDetailsByLAandByID(Int64 IndexID, Int64 KeyID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_NoticesSecFiveNineByIndexIDbyLA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", KeyID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        
        // 59 by LA for Move
        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_InBox_NoticeSectionFiveNineDetailsByLA(string UserID, Int64 Index_ID, Int64 GetKey_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNineByLA_InBox", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_User_ID", UserID);
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            cmd.Parameters.AddWithValue("p_GetKey_ID", GetKey_ID);            
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),
                           
                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_InProcess_NoticeSectionFiveNineDetailsByLA(string UserID, Int64 Index_ID, Int64 GetKey_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNineByLA_InProcess", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_User_ID", UserID);
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            cmd.Parameters.AddWithValue("p_GetKey_ID", GetKey_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),
                           
                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_FileClosed_NoticeSectionFiveNineDetailsByLA(string UserID, Int64 Index_ID, Int64 GetKey_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNineByLA_Closed", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_User_ID", UserID);
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            cmd.Parameters.AddWithValue("p_GetKey_ID", GetKey_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),

                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_NonMaintainable_NoticeSectionFiveNineDetailsByLA(string UserID, Int64 Index_ID, Int64 GetKey_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNineByLA_NMaintainable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_User_ID", UserID);
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            cmd.Parameters.AddWithValue("p_GetKey_ID", GetKey_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),

                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_AdminDesk_HearingRecords_NoticeSectionFiveNineDetails(string UserID, Int64 Index_ID, Int64 GetKey_ID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> AdminDeskparameters = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticesSectionFiveNineByLA_HearingRecords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_User_ID", UserID);
            cmd.Parameters.AddWithValue("p_Index_ID", Index_ID);
            cmd.Parameters.AddWithValue("p_GetKey_ID", GetKey_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                AdminDeskparameters.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),

                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return AdminDeskparameters;
        }

        public bool Add_NoticeSectionFiveNineDetailsByLA_InfoDeskEvent(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_rera_complaint_sectionfivenine_eventaction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters

            cmd.Parameters.AddWithValue("p_SectionFiveNine_EventAction_ID", smodel.SectionFiveNine_EventAction_ID);
            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_NoticesSectionFiveNine_ID", smodel.Related_NoticesSectionFiveNine_ID);
            cmd.Parameters.AddWithValue("p_Related_NoticeFile_NumberDetails", String.IsNullOrEmpty(smodel.Related_NoticeFile_NumberDetails) ? "" : smodel.Related_NoticeFile_NumberDetails);

            cmd.Parameters.AddWithValue("p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_EventAction_Relationship", UserRole);
            // AssignedTo variable for UserRole who identified event action
            cmd.Parameters.AddWithValue("p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_Target_ResolutionDate", smodel.Target_ResolutionDate == null ? dtvalue : smodel.Target_ResolutionDate);
            cmd.Parameters.AddWithValue("p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_Actual_ResolutionDate", smodel.Actual_ResolutionDate == null ? dtvalue : smodel.Actual_ResolutionDate);
            cmd.Parameters.AddWithValue("p_ProgressStatus", String.IsNullOrEmpty(smodel.ProgressStatus) ? "" : smodel.ProgressStatus);
            cmd.Parameters.AddWithValue("p_Remarks_IfAny", String.IsNullOrEmpty(smodel.Remarks_IfAny) ? "" : smodel.Remarks_IfAny);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", 0);
            cmd.Parameters.AddWithValue("p_CreatedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();
            //return AppId;

            if (i >= 1)
                return true;
            else
                return false;
        }

        // 59 by LA for Log Files
        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails> Display_NoticeSectionFiveNineDetailsByLA_DeskEventLogDetails(Int64 Related_NoticesSectionFiveNine_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails> NoticesSectionFiveNinelist1 = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticeSecFiveNine_FileLogDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Related_NoticesSectionFiveNine_ID", Related_NoticesSectionFiveNine_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                NoticesSectionFiveNinelist1.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_FileLogDetails
                       {
                           SectionFiveNine_EventAction_ID = Convert.ToInt64(dr["SectionFiveNine_EventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_NoticesSectionFiveNine_ID = Convert.ToInt64(dr["Related_NoticesSectionFiveNine_ID"]),
                           Related_NoticeFile_NumberDetails = Convert.ToString(dr["Related_NoticeFile_NumberDetails"]),

                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                           ProgressStatus = Convert.ToString(dr["ProgressStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return NoticesSectionFiveNinelist1;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> Display_NoticeSectionFiveNineDetailsByLA_CurrentStatusEventLogDetails(Int64 Related_NoticesSectionFiveNine_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA> NoticesSectionFiveNinelist1 = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticeSecFiveNine_CurrentStatusFileLog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_Related_NoticesSectionFiveNine_ID", Related_NoticesSectionFiveNine_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                NoticesSectionFiveNinelist1.Add(
                       new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA
                       {
                           NoticesSectionFiveNine_IndexID = Convert.ToInt64(dr["NoticesSectionFiveNine_IndexID"]),
                           NoticesSectionFiveNine_ID = Convert.ToInt64(dr["NoticesSectionFiveNine_ID"]),

                           NoticesSectionFiveNine_IDYear = Convert.ToInt32(dr["NoticesSectionFiveNine_IDYear"]),
                           NoticesSectionFiveNine_IDName = Convert.ToString(dr["NoticesSectionFiveNine_IDName"]),
                           Notice_RelatedReferenceID = Convert.ToInt64(dr["Notice_RelatedReferenceID"]),
                           Notice_RelatedReferenceDate = Convert.ToDateTime(dr["Notice_RelatedReferenceDate"]),
                           Notice_RelatedReferenceName = Convert.ToString(dr["Notice_RelatedReferenceName"]),
                           Notice_RelatedReferenceCode = Convert.ToString(dr["Notice_RelatedReferenceCode"]),
                           SerialOrderNumber = Convert.ToInt32(dr["SerialOrderNumber"]),

                           DistrictTown_InfoName = Convert.ToString(dr["DistrictTown_InfoName"]),
                           DistrictTown_InfoCode = Convert.ToString(dr["DistrictTown_InfoCode"]),
                           NoticeFile_NumberDetails = Convert.ToString(dr["NoticeFile_NumberDetails"]),
                           NoticeDate = Convert.ToDateTime(dr["NoticeDate"]),
                           Notice_ModeOfComplaint = Convert.ToString(dr["Notice_ModeOfComplaint"]),
                           Notice_ModeOfComplaintSpecifyOthers = Convert.ToString(dr["Notice_ModeOfComplaintSpecifyOthers"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterNameWithAddressDetails = Convert.ToString(dr["PromoterNameWithAddressDetails"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectNameWithAddressDetails = Convert.ToString(dr["ProjectNameWithAddressDetails"]),

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

                           IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = String.IsNullOrEmpty(Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"])) ? "0" : Convert.ToString(dr["IsOfficeResComplainantAddress_SameAsServiceNoticeAddress"]),
                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedCounsel_Name = Convert.ToString(dr["AuthorizedCounsel_Name"]),
                           AuthorizedCounsel_EmailAddress = Convert.ToString(dr["AuthorizedCounsel_EmailAddress"]),
                           AuthorizedCounsel_MobileNumber = Convert.ToInt64(dr["AuthorizedCounsel_MobileNumber"]),
                           AuthorizedCounsel_LandlineFaxNumber = Convert.ToInt64(dr["AuthorizedCounsel_LandlineFaxNumber"]),

                           CurrentStatusDate = Convert.ToDateTime(dr["CurrentStatusDate"]),
                           CurrentStatusTitle = Convert.ToString(dr["CurrentStatusTitle"]),
                           CurrentStatusWithRemarks = Convert.ToString(dr["CurrentStatusWithRemarks"]),

                           IsPersonalHearing = Convert.ToInt32(dr["IsPersonalHearing"]),
                           HearingBenchCode = Convert.ToString(dr["HearingBenchCode"]),
                           HearingBenchName = Convert.ToString(dr["HearingBenchName"]),
                           FixedFor = Convert.ToString(dr["FixedFor"]),
                           OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                           OrderTime = Convert.ToString(dr["OrderTime"]),
                           OrderDateStatusTitle = Convert.ToString(dr["OrderDateStatusTitle"]),
                           OrderDateWithRemarksIfAny = Convert.ToString(dr["OrderDateWithRemarksIfAny"]),
                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToString(dr["D_column"]),
                           E_column = Convert.ToString(dr["E_column"]),

                           CurrentEvent_IdentifiedCode = Convert.ToInt32(dr["CurrentEvent_IdentifiedCode"]),
                           CurrentEvent_IdentifiedAggregateName = Convert.ToString(dr["CurrentEvent_IdentifiedAggregateName"]),
                           CurrentEvent_IdentifiedBy = Convert.ToString(dr["CurrentEvent_IdentifiedBy"]),
                           CurrentEvent_IdentifiedOn = Convert.ToDateTime(dr["CurrentEvent_IdentifiedOn"]),

                           DeskAction_IdentifiedCode = Convert.ToInt32(dr["DeskAction_IdentifiedCode"]),
                           DeskAction_IdentifiedAggregateName = Convert.ToString(dr["DeskAction_IdentifiedAggregateName"]),
                           DeskAction_IdentifiedBy = Convert.ToString(dr["DeskAction_IdentifiedBy"]),
                           DeskAction_IdentifiedOn = Convert.ToDateTime(dr["DeskAction_IdentifiedOn"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),

                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return NoticesSectionFiveNinelist1;
        }

        // Display only for Master Event Actions
        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails> Display_Master_AdminDesk_EventActionsByUserID(string User_ID, Int64 IndexKey)
        {
            connection();
            List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails> MasterEventActions = new List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails>();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_CurrentEventActionMaster_ByUserID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", User_ID);
            cmd.Parameters.AddWithValue("p_IndexKey", IndexKey);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterEventActions.Add(
                    new ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails
                    {
                        EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                        EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                        EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                        EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                        EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                        EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                        EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                        EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                        Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterEventActions;
        }

        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails> Display_Master_AdminDesk_DeskActionsByUserID(string User_ID, Int64 IndexKey)
        {
            connection();
            List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails> MasterEventActions = new List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails>();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_DeskActionMaster_ByUserID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", User_ID);
            cmd.Parameters.AddWithValue("p_IndexKey", IndexKey);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MasterEventActions.Add(
                    new ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails
                    {
                        DeskAction_Code = Convert.ToInt64(dr["DeskAction_Code"]),
                        DeskAction_ApplicableFor = Convert.ToString(dr["DeskAction_ApplicableFor"]),
                        DeskAction_SubApplicableFor = Convert.ToString(dr["DeskAction_SubApplicableFor"]),
                        DeskAction_Summary = Convert.ToString(dr["DeskAction_Summary"]),
                        DeskAction_Description = Convert.ToString(dr["DeskAction_Description"]),
                        DeskAction_Category = Convert.ToString(dr["DeskAction_Category"]),
                        DeskAction_Aggregate = Convert.ToString(dr["DeskAction_Aggregate"]),
                        DeskAction_Relationship = Convert.ToString(dr["DeskAction_Relationship"]),
                        Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                        Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        ModifyBy = Convert.ToString(dr["ModifyBy"]),
                        ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                    });
            }
            return MasterEventActions;
        }

        public List<ClsPrp_MasterAdminDesk_PreHearingBenchSectionFiveNine_Master> Display_Master_AdminDesk_PreHearingSectionFiveNineBenchMaster(string UserID_Role)
        {
            connection();
            List<ClsPrp_MasterAdminDesk_PreHearingBenchSectionFiveNine_Master> SectionFiveNinelist1 = new List<ClsPrp_MasterAdminDesk_PreHearingBenchSectionFiveNine_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_SectionFiveNine_PreHearingMBenchMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                SectionFiveNinelist1.Add(
                       new ClsPrp_MasterAdminDesk_PreHearingBenchSectionFiveNine_Master
                       {
                           PreHearingBench_IndexID = Convert.ToInt64(dr["PreHearingBench_IndexID"]),
                           PreHearingBench_ID = Convert.ToInt64(dr["PreHearingBench_ID"]),
                           PreHearingBenchCode = Convert.ToString(dr["PreHearingBenchCode"]), //ToInt64
                           PreHearingBenchName = Convert.ToString(dr["PreHearingBenchName"]),
                           PreHearingType = Convert.ToString(dr["PreHearingType"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return SectionFiveNinelist1;
        }

        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails> Display_AdminDesk_CurrentStatusEventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails> CurrentStatusEventlist1 = new List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_CurrentStatusEventDescriptionByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Event_ID", Event_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CurrentStatusEventlist1.Add(
                       new ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails
                       {
                           EventAction_Code = Convert.ToInt64(dr["EventAction_Code"]),
                           EventAction_ApplicableFor = Convert.ToString(dr["EventAction_ApplicableFor"]),
                           EventAction_SubApplicableFor = Convert.ToString(dr["EventAction_SubApplicableFor"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return CurrentStatusEventlist1;
        }

        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails> Display_AdminDesk_DeskEventDescription_MasterDetailsByCode(Int32 Event_ID, string Event_UserID)
        {
            connection();
            List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails> DeskEventlist1 = new List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_DeskEventDescriptionByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Event_ID", Event_ID);
            cmd.Parameters.AddWithValue("p_Event_UserID", Event_UserID);            

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                DeskEventlist1.Add(
                       new ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails
                       {
                           DeskAction_Code = Convert.ToInt64(dr["DeskAction_Code"]),
                           DeskAction_ApplicableFor = Convert.ToString(dr["DeskAction_ApplicableFor"]),
                           DeskAction_SubApplicableFor = Convert.ToString(dr["DeskAction_SubApplicableFor"]),
                           DeskAction_Summary = Convert.ToString(dr["DeskAction_Summary"]),
                           DeskAction_Description = Convert.ToString(dr["DeskAction_Description"]),
                           DeskAction_Category = Convert.ToString(dr["DeskAction_Category"]),
                           DeskAction_Aggregate = Convert.ToString(dr["DeskAction_Aggregate"]),
                           DeskAction_Relationship = Convert.ToString(dr["DeskAction_Relationship"]),
                           Target_ResolutionDuration = Convert.ToInt32(dr["Target_ResolutionDuration"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return DeskEventlist1;
        }

        // Master File
        public List<ClsPrp_AuthDesk_eCourt_UnderSection_Master> Display_Master_Complaint_UnderSectionList_ByID(Int32? Flag_ID, string UserID)
        {
            connection();
            List<ClsPrp_AuthDesk_eCourt_UnderSection_Master> ObjUnderSectionList = new List<ClsPrp_AuthDesk_eCourt_UnderSection_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Master_Complaint_UnderSectionList_ByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Flag_ID", Flag_ID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ObjUnderSectionList.Add(
                    new ClsPrp_AuthDesk_eCourt_UnderSection_Master
                    {
                        UnderSection_IndexID = Convert.ToInt32(dr["UnderSection_IndexID"]),
                        UnderSection_ID = Convert.ToInt32(dr["UnderSection_ID"]),

                        UnderSection_SerialOrder = Convert.ToInt32(dr["UnderSection_SerialOrder"]),
                        UnderSectionCode = Convert.ToString(dr["UnderSectionCode"]),
                        UnderSectionName = Convert.ToString(dr["UnderSectionName"]),
                        UnderSectionYear = Convert.ToInt32(dr["UnderSectionYear"]),
                        UnderSectionType = Convert.ToString(dr["UnderSectionType"]),
                        UnderSectionDescription = Convert.ToString(dr["UnderSectionDescription"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsFlag = Convert.ToInt32(dr["IsFlag"]),
                    });
            }
            return ObjUnderSectionList;
        }

        // Hearing Record
        public bool Add_AdminDesk_HearingDate_NoticeSectionFiveNineDetails(ClsPrp_AdminDesk_NoticeSectionFiveNineByLA smodel, string userName)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_AdminDesk_NoticeFiveNine_HearingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dtvalue = new DateTime(0001, 1, 1);

            #region Parameters
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", smodel.NoticesSectionFiveNine_IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", smodel.NoticesSectionFiveNine_ID);

            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IDYear", smodel.NoticesSectionFiveNine_IDYear);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IDName", String.IsNullOrEmpty(smodel.NoticesSectionFiveNine_IDName) ? "" : smodel.NoticesSectionFiveNine_IDName);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceID", smodel.Notice_RelatedReferenceID);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceDate", smodel.Notice_RelatedReferenceDate == null ? dtvalue : smodel.Notice_RelatedReferenceDate);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceName", String.IsNullOrEmpty(smodel.Notice_RelatedReferenceName) ? "" : smodel.Notice_RelatedReferenceName);
            cmd.Parameters.AddWithValue("p_Notice_RelatedReferenceCode", String.IsNullOrEmpty(smodel.Notice_RelatedReferenceCode) ? "" : smodel.Notice_RelatedReferenceCode);
            cmd.Parameters.AddWithValue("p_SerialOrderNumber", smodel.SerialOrderNumber);

            cmd.Parameters.AddWithValue("p_DistrictTown_InfoName", String.IsNullOrEmpty(smodel.DistrictTown_InfoName) ? "" : smodel.DistrictTown_InfoName);
            cmd.Parameters.AddWithValue("p_DistrictTown_InfoCode", String.IsNullOrEmpty(smodel.DistrictTown_InfoCode) ? "" : smodel.DistrictTown_InfoCode);
            cmd.Parameters.AddWithValue("p_NoticeFile_NumberDetails", String.IsNullOrEmpty(smodel.NoticeFile_NumberDetails) ? "" : smodel.NoticeFile_NumberDetails);
            cmd.Parameters.AddWithValue("p_NoticeDate", smodel.NoticeDate == null ? dtvalue : smodel.NoticeDate);
            cmd.Parameters.AddWithValue("p_Notice_ModeOfComplaint", String.IsNullOrEmpty(smodel.Notice_ModeOfComplaint) ? "" : smodel.Notice_ModeOfComplaint);
            cmd.Parameters.AddWithValue("p_Notice_ModeOfComplaintSpecifyOthers", String.IsNullOrEmpty(smodel.Notice_ModeOfComplaintSpecifyOthers) ? "" : smodel.Notice_ModeOfComplaintSpecifyOthers);

            cmd.Parameters.AddWithValue("p_PromoterName", String.IsNullOrEmpty(smodel.PromoterName) ? "" : smodel.PromoterName);
            cmd.Parameters.AddWithValue("p_PromoterNameWithAddressDetails", String.IsNullOrEmpty(smodel.PromoterNameWithAddressDetails) ? "" : smodel.PromoterNameWithAddressDetails);
            cmd.Parameters.AddWithValue("p_ProjectName", String.IsNullOrEmpty(smodel.ProjectName) ? "" : smodel.ProjectName);
            cmd.Parameters.AddWithValue("p_ProjectNameWithAddressDetails", String.IsNullOrEmpty(smodel.ProjectNameWithAddressDetails) ? "" : smodel.ProjectNameWithAddressDetails);

            cmd.Parameters.AddWithValue("p_Complainant_Name", String.IsNullOrEmpty(smodel.Complainant_Name) ? "" : smodel.Complainant_Name);
            cmd.Parameters.AddWithValue("p_Complainant_EmailAddress", String.IsNullOrEmpty(smodel.Complainant_EmailAddress) ? "" : smodel.Complainant_EmailAddress);
            cmd.Parameters.AddWithValue("p_Complainant_MobileNumber", smodel.Complainant_MobileNumber == null ? 0 : smodel.Complainant_MobileNumber);
            cmd.Parameters.AddWithValue("p_Complainant_LandlineFaxNumber", smodel.Complainant_LandlineFaxNumber == null ? 0 : smodel.Complainant_LandlineFaxNumber);
            cmd.Parameters.AddWithValue("p_Complainant_AadhaarNumber", smodel.Complainant_AadhaarNumber == null ? 0 : smodel.Complainant_AadhaarNumber);

            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine1", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine1) ? "" : smodel.OfficeResComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressLine2", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressLine2) ? "" : smodel.OfficeResComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressStateCode", smodel.OfficeResComplainant_AddressStateCode == null ? 0 : smodel.OfficeResComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressDistrictCode", smodel.OfficeResComplainant_AddressDistrictCode == null ? 0 : smodel.OfficeResComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_OfficeResComplainant_AddressPIN", String.IsNullOrEmpty(smodel.OfficeResComplainant_AddressPIN) ? "" : smodel.OfficeResComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_IsOfficeResComplainantAddress_SameAsServiceNoticeAddress", smodel.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress == "true" ? "1" : "0");
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine1", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine1) ? "" : smodel.ServiceNoticesComplainant_AddressLine1);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressLine2", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressLine2) ? "" : smodel.ServiceNoticesComplainant_AddressLine2);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressStateCode", smodel.ServiceNoticesComplainant_AddressStateCode == null ? 0 : smodel.ServiceNoticesComplainant_AddressStateCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressDistrictCode", smodel.ServiceNoticesComplainant_AddressDistrictCode == null ? 0 : smodel.ServiceNoticesComplainant_AddressDistrictCode);
            cmd.Parameters.AddWithValue("p_ServiceNoticesComplainant_AddressPIN", String.IsNullOrEmpty(smodel.ServiceNoticesComplainant_AddressPIN) ? "" : smodel.ServiceNoticesComplainant_AddressPIN);

            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_Name", String.IsNullOrEmpty(smodel.AuthorizedCounsel_Name) ? "" : smodel.AuthorizedCounsel_Name);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_EmailAddress", String.IsNullOrEmpty(smodel.AuthorizedCounsel_EmailAddress) ? "" : smodel.AuthorizedCounsel_EmailAddress);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_MobileNumber", smodel.AuthorizedCounsel_MobileNumber == null ? 0 : smodel.AuthorizedCounsel_MobileNumber);
            cmd.Parameters.AddWithValue("p_AuthorizedCounsel_LandlineFaxNumber", smodel.AuthorizedCounsel_LandlineFaxNumber == null ? 0 : smodel.AuthorizedCounsel_LandlineFaxNumber);

            cmd.Parameters.AddWithValue("p_CurrentStatusDate", smodel.CurrentStatusDate == null ? dtvalue : smodel.CurrentStatusDate);
            cmd.Parameters.AddWithValue("p_CurrentStatusTitle", String.IsNullOrEmpty(smodel.CurrentStatusTitle) ? "" : smodel.CurrentStatusTitle);
            cmd.Parameters.AddWithValue("p_CurrentStatusWithRemarks", String.IsNullOrEmpty(smodel.CurrentStatusWithRemarks) ? "" : smodel.CurrentStatusWithRemarks);

            cmd.Parameters.AddWithValue("p_IsPersonalHearing", smodel.IsPersonalHearing);
            cmd.Parameters.AddWithValue("p_HearingBenchCode", String.IsNullOrEmpty(smodel.HearingBenchCode) ? "" : smodel.HearingBenchCode);
            cmd.Parameters.AddWithValue("p_HearingBenchName", String.IsNullOrEmpty(smodel.HearingBenchName) ? "" : smodel.HearingBenchName);
            cmd.Parameters.AddWithValue("p_FixedFor", String.IsNullOrEmpty(smodel.FixedFor) ? "" : smodel.FixedFor);
            cmd.Parameters.AddWithValue("p_OrderDate", smodel.OrderDate == null ? dtvalue : smodel.OrderDate);
            cmd.Parameters.AddWithValue("p_OrderTime", String.IsNullOrEmpty(smodel.OrderTime) ? "" : smodel.OrderTime);
            cmd.Parameters.AddWithValue("p_OrderDateStatusTitle", String.IsNullOrEmpty(smodel.OrderDateStatusTitle) ? "" : smodel.OrderDateStatusTitle);
            cmd.Parameters.AddWithValue("p_OrderDateWithRemarksIfAny", String.IsNullOrEmpty(smodel.OrderDateWithRemarksIfAny) ? "" : smodel.OrderDateWithRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RemarksIfAny", String.IsNullOrEmpty(smodel.RemarksIfAny) ? "" : smodel.RemarksIfAny);

            cmd.Parameters.AddWithValue("p_A_column", String.IsNullOrEmpty(smodel.A_column) ? "" : smodel.A_column);
            cmd.Parameters.AddWithValue("p_B_column", String.IsNullOrEmpty(smodel.B_column) ? "" : smodel.B_column);
            cmd.Parameters.AddWithValue("p_C_column", String.IsNullOrEmpty(smodel.C_column) ? "" : smodel.C_column);
            cmd.Parameters.AddWithValue("p_D_column", String.IsNullOrEmpty(smodel.D_column) ? "" : smodel.D_column);
            cmd.Parameters.AddWithValue("p_E_column", String.IsNullOrEmpty(smodel.E_column) ? "" : smodel.E_column);

            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedCode", smodel.CurrentEvent_IdentifiedCode);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedAggregateName", String.IsNullOrEmpty(smodel.CurrentEvent_IdentifiedAggregateName) ? "" : smodel.CurrentEvent_IdentifiedAggregateName);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedBy", String.IsNullOrEmpty(smodel.CurrentEvent_IdentifiedBy) ? "" : smodel.CurrentEvent_IdentifiedBy);
            cmd.Parameters.AddWithValue("p_CurrentEvent_IdentifiedOn", smodel.CurrentEvent_IdentifiedOn == null ? dtvalue : smodel.CurrentEvent_IdentifiedOn);

            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedCode", smodel.DeskAction_IdentifiedCode);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedAggregateName", String.IsNullOrEmpty(smodel.DeskAction_IdentifiedAggregateName) ? "" : smodel.DeskAction_IdentifiedAggregateName);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedBy", String.IsNullOrEmpty(smodel.DeskAction_IdentifiedBy) ? "" : smodel.DeskAction_IdentifiedBy);
            cmd.Parameters.AddWithValue("p_DeskAction_IdentifiedOn", smodel.DeskAction_IdentifiedOn == null ? dtvalue : smodel.DeskAction_IdentifiedOn);

            cmd.Parameters.AddWithValue("p_IsActive", 1);
            cmd.Parameters.AddWithValue("p_IsDraft", smodel.IsDraft);
            cmd.Parameters.AddWithValue("p_IsDraftMember", smodel.IsDraftMember);
            cmd.Parameters.AddWithValue("p_IsPublicView", smodel.IsPublicView);

            cmd.Parameters.AddWithValue("p_CreatedBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_ModifyBy", String.IsNullOrEmpty(userName) ? "" : userName);
            cmd.Parameters.AddWithValue("p_ModifyOn", DateTime.Now);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);
            #endregion

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_HearingDetails> Display_HearingDate_NoticeSectionFiveNineDetails_ByID(Int64? FlagID, string KeyID, string UserID)
        {
            connection();
            List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_HearingDetails> ObjList = new List<ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_HearingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_NoticeFiveNine_HearingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_FlagID", FlagID);
            cmd.Parameters.AddWithValue("p_KeyID", KeyID);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ObjList.Add(
                    new ClsPrp_AdminDesk_NoticeSectionFiveNineByLA_HearingDetails
                    {
                        BenchHearingDate_IndexID = Convert.ToInt64(dr["BenchHearingDate_IndexID"]),
                        BenchHearingDate_ID = Convert.ToInt64(dr["BenchHearingDate_ID"]),
                        Related_ComplaintNoticesSectionFiveNine_ID = Convert.ToInt64(dr["Related_ComplaintNoticesSectionFiveNine_ID"]),

                        Related_ComplaintNoticesSectionFiveNine_Code = Convert.ToString(dr["Related_ComplaintNoticesSectionFiveNine_Code"]),
                        TypeOfComplaint = Convert.ToString(dr["TypeOfComplaint"]),
                        TypeOfHearing = Convert.ToString(dr["TypeOfHearing"]),
                        TypeOfComplaintHearing = Convert.ToString(dr["TypeOfComplaintHearing"]),
                        Bench_HearingDate = Convert.ToDateTime(dr["Bench_HearingDate"]),
                        Bench_HearingTime = Convert.ToString(dr["Bench_HearingTime"]),
                        HearingBench_ID = Convert.ToString(dr["HearingBench_ID"]),
                        HearingBench_Name = Convert.ToString(dr["HearingBench_Name"]),
                        HearingBench_FixedFor_ID = Convert.ToString(dr["HearingBench_FixedFor_ID"]),
                        HearingBench_FixedFor_Name = Convert.ToString(dr["HearingBench_FixedFor_Name"]),

                        HearingReplyDays = Convert.ToString(dr["HearingReplyDays"]),
                        HearingBench_BussinesOnDate_ProceedingDate = Convert.ToDateTime(dr["HearingBench_BussinesOnDate_ProceedingDate"]),
                        HearingStatus = Convert.ToString(dr["HearingStatus"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        A_column = Convert.ToString(dr["A_column"]),
                        B_column = Convert.ToString(dr["B_column"]),
                        C_column = Convert.ToString(dr["C_column"]),
                        D_column = Convert.ToDateTime(dr["D_column"]),
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
            return ObjList;
        }

        public bool Delete_AdminDesk_HearingDate_NoticeSectionFiveNineByID(Int64 IndexID, Int64 KeyID, Int64 HearingID, string HearingCode, string UserID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("Delete_Rera_AdminDesk_NoticeFiveNine_HearingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_FNIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_FNID", KeyID);
            cmd.Parameters.AddWithValue("p_FNHearingID", HearingID);
            cmd.Parameters.AddWithValue("p_FNHearingCode", HearingCode);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlParameter AppPar = new MySqlParameter("p_valreturn", MySqlDbType.Int64);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int64 AppId = Convert.ToInt64(AppPar.Value);
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
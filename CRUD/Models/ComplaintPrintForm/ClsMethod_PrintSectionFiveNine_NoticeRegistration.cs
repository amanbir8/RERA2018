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
    public class ClsMethod_PrintSectionFiveNine_NoticeRegistration
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Notice FiveNine Registration
        public List<ClsPrp_Print_NoticeSectionFiveNine> Display_Print_NoticeSectionFiveNineDetail_ByID(Int64 IndexID, Int64 FineNineID, string FineNineCode, string UserID)
        {
            connection();
            List<ClsPrp_Print_NoticeSectionFiveNine> Printparameters = new List<ClsPrp_Print_NoticeSectionFiveNine>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_Print_NoticesSectionFiveNineByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", FineNineID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_DiaryNumber", FineNineCode);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Printparameters.Add(
                       new ClsPrp_Print_NoticeSectionFiveNine
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
            return Printparameters;
        }

        // Hearing Record
        public List<ClsPrp_Print_NoticeSectionFiveNine_HearingDetails> Display_HearingDate_NoticeSectionFiveNineDetail_ByID(Int64 IndexID, Int64 FineNineID, string FineNineCode, string UserID)
        {
            connection();
            List<ClsPrp_Print_NoticeSectionFiveNine_HearingDetails> ObjList = new List<ClsPrp_Print_NoticeSectionFiveNine_HearingDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AdminDesk_Print_NoticeFiveNine_HearingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_ID", FineNineID);
            cmd.Parameters.AddWithValue("p_NoticesSectionFiveNine_DiaryNumber", FineNineCode);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ObjList.Add(
                    new ClsPrp_Print_NoticeSectionFiveNine_HearingDetails
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
    }
}
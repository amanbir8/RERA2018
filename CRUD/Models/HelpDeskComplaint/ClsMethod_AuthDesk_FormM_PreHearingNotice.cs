using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_FormM_PreHearingNotice
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
        
        public List<ClsPrp_AuthDesk_FormM_PreHearingNotice> Display_AuthDesk_ComplaintFormM_PreHearingNoticeByID(Int64 ComplaintFormM_ID, Int64 PreHearingNotice_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_PreHearingNotice> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_PreHearingNotice>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_PreHearingNoticeByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintFormM_ID", ComplaintFormM_ID);
            cmd.Parameters.AddWithValue("p_PreHearingNotice_ID", PreHearingNotice_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_PreHearingNotice
                       {
                           ComplaintFormM_IndexID = Convert.ToInt64(dr["ComplaintFormM_IndexID"]),
                           ComplaintFormM_ID = Convert.ToInt64(dr["ComplaintFormM_ID"]),
                           ComplaintFormM_Code = Convert.ToString(dr["ComplaintFormM_Code"]),

                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           ComplainantOther_Name = Convert.ToString(dr["ComplainantOther_Name"]),
                           ComplainantOtherBrief_Name = Convert.ToString(dr["ComplainantOtherBrief_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineFaxNumber = Convert.ToInt64(dr["Complainant_LandlineFaxNumber"]),

                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                           AuthorizedRepresentativeCounsel_EmailAddress = Convert.ToString(dr["AuthorizedRepresentativeCounsel_EmailAddress"]),
                           Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
                           RespondentOther_Name = Convert.ToString(dr["RespondentOther_Name"]),
                           RespondentOtherBrief_Name = Convert.ToString(dr["RespondentOtherBrief_Name"]),
                           Respondent_EmailAddress = Convert.ToString(dr["Respondent_EmailAddress"]),
                           Respondent_MobileNumber = Convert.ToInt64(dr["Respondent_MobileNumber"]),
                           Respondent_LandlineFaxNumber = Convert.ToInt64(dr["Respondent_LandlineFaxNumber"]),

                           ServiceNoticesRespondent_AddressLine1 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine1"]),
                           ServiceNoticesRespondent_AddressLine2 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine2"]),
                           ServiceNoticesRespondent_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressStateCode"]),
                           ServiceNoticesRespondent_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressDistrictCode"]),
                           ServiceNoticesRespondent_AddressPIN = Convert.ToString(dr["ServiceNoticesRespondent_AddressPIN"]),

                           PreHearingDate_IndexID = Convert.ToInt64(dr["PreHearingDate_IndexID"]),
                           PreHearingDate_ID = Convert.ToInt64(dr["PreHearingDate_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                           ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           PreHearingDate = Convert.ToDateTime(dr["PreHearingDate"]),
                           PreHearingTime = Convert.ToString(dr["PreHearingTime"]),
                           PreHearingBench = Convert.ToString(dr["PreHearingBench"]),
                           PreHearingFixedForCode = Convert.ToString(dr["PreHearingFixedForCode"]),

                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           PreHearingStatus = Convert.ToString(dr["PreHearingStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),//Convert.ToString(dr["D_column"]),
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

        #region EXECUTION

        public List<ClsPrp_AuthDesk_FormExe_PreHearingNotice> Display_AuthDesk_ComplaintFormExe_PreHearingNoticeByID(Int64 ComplaintForm_ID, Int64 PreHearingNotice_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormExe_PreHearingNotice> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormExe_PreHearingNotice>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormExe_PreHearingNoticeByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ComplaintForm_ID", ComplaintForm_ID);
            cmd.Parameters.AddWithValue("p_PreHearingNotice_ID", PreHearingNotice_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormExe_PreHearingNotice
                       {
                           ExecutionForm_IndexId = Convert.ToInt64(dr["ExecutionForm_IndexId"]),
                           ExecutionForm_ID = Convert.ToInt64(dr["ExecutionForm_ID"]),
                           ExecutionForm_Code = Convert.ToString(dr["ExecutionForm_Code"]),
                           Complaint_Number = Convert.ToString(dr["Complaint_Number"]),

                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           ComplainantOther_Name = Convert.ToString(dr["ComplainantOther_Name"]),
                           ComplainantOtherBrief_Name = Convert.ToString(dr["ComplainantOtherBrief_Name"]),
                           Complainant_EmailAddress = Convert.ToString(dr["Complainant_EmailAddress"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           Complainant_LandlineFaxNumber = Convert.ToInt64(dr["Complainant_LandlineFaxNumber"]),

                           ServiceNoticesComplainant_AddressLine1 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine1"]),
                           ServiceNoticesComplainant_AddressLine2 = Convert.ToString(dr["ServiceNoticesComplainant_AddressLine2"]),
                           ServiceNoticesComplainant_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressStateCode"]),
                           ServiceNoticesComplainant_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesComplainant_AddressDistrictCode"]),
                           ServiceNoticesComplainant_AddressPIN = Convert.ToString(dr["ServiceNoticesComplainant_AddressPIN"]),

                           AuthorizedRepresentativeCounsel_Name = Convert.ToString(dr["AuthorizedRepresentativeCounsel_Name"]),
                           AuthorizedRepresentativeCounsel_EmailAddress = Convert.ToString(dr["AuthorizedRepresentativeCounsel_EmailAddress"]),
                           Respondent_Name = Convert.ToString(dr["Respondent_Name"]),
                           RespondentOther_Name = Convert.ToString(dr["RespondentOther_Name"]),
                           RespondentOtherBrief_Name = Convert.ToString(dr["RespondentOtherBrief_Name"]),
                           Respondent_EmailAddress = Convert.ToString(dr["Respondent_EmailAddress"]),
                           Respondent_MobileNumber = Convert.ToInt64(dr["Respondent_MobileNumber"]),
                           Respondent_LandlineFaxNumber = Convert.ToInt64(dr["Respondent_LandlineFaxNumber"]),

                           ServiceNoticesRespondent_AddressLine1 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine1"]),
                           ServiceNoticesRespondent_AddressLine2 = Convert.ToString(dr["ServiceNoticesRespondent_AddressLine2"]),
                           ServiceNoticesRespondent_AddressStateCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressStateCode"]),
                           ServiceNoticesRespondent_AddressDistrictCode = Convert.ToInt32(dr["ServiceNoticesRespondent_AddressDistrictCode"]),
                           ServiceNoticesRespondent_AddressPIN = Convert.ToString(dr["ServiceNoticesRespondent_AddressPIN"]),

                           PreHearingDate_IndexID = Convert.ToInt64(dr["PreHearingDate_IndexID"]),
                           PreHearingDate_ID = Convert.ToInt64(dr["PreHearingDate_ID"]),
                           ComplainantApplicant_RelatedComplaint_ID = Convert.ToInt64(dr["ComplainantApplicant_RelatedComplaint_ID"]),
                           ComplainantApplicant_RelatedComplaint_Code = Convert.ToString(dr["ComplainantApplicant_RelatedComplaint_Code"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),

                           PreHearingDate = Convert.ToDateTime(dr["PreHearingDate"]),
                           PreHearingTime = Convert.ToString(dr["PreHearingTime"]),
                           PreHearingBench = Convert.ToString(dr["PreHearingBench"]),
                           PreHearingFixedForCode = Convert.ToString(dr["PreHearingFixedForCode"]),

                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           PreHearingStatus = Convert.ToString(dr["PreHearingStatus"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           D_column = Convert.ToDateTime(dr["D_column"]),//Convert.ToString(dr["D_column"]),
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

        #endregion
    }
}
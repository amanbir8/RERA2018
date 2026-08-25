using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.RespondentComplaint
{
    public class ClsMethod_RespondentComplaintFormN_DiaryNumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_RespondentComplaint_FormN_DiaryNumber> Display_RespondentComplaintFormN_RegDiaryNumber(string IDuserRole, string IDdiaryNumber, Int64 IDformN, string IDcode)
        {
            connection();
            List<ClsPrp_RespondentComplaint_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_RespondentComplaint_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_RespondentComplaint_FormN_RegDiaryNumberPreHear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", IDuserRole);
            cmd.Parameters.AddWithValue("p_DiaryNumber", IDdiaryNumber);
            cmd.Parameters.AddWithValue("p_FormNcomplaintID", IDformN);
            cmd.Parameters.AddWithValue("p_Code", IDcode);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_RespondentComplaint_FormN_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormN_RelatedComplaint_ID = Convert.ToInt64(dr["FormN_RelatedComplaint_ID"]),
                           FormN_RelatedComplaint_Code = Convert.ToString(dr["FormN_RelatedComplaint_Code"]),
                           Profile_ID = Convert.ToInt64(dr["Profile_ID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),
                           ComplaintType_MN = Convert.ToString(dr["ComplaintType_MN"]),
                           IsComplaintComplete = Convert.ToInt32(dr["IsComplaintComplete"]),
                           IsPaymentComplete = Convert.ToInt32(dr["IsPaymentComplete"]),
                           PaymentTransactionID = Convert.ToString(dr["PaymentTransactionID"]),
                           PaymentTransactionDate = Convert.ToDateTime(dr["PaymentTransactionDate"]),
                           IsDocumentsComplete = Convert.ToInt32(dr["IsDocumentsComplete"]),
                           DocumentUploadCount = Convert.ToInt32(dr["DocumentUploadCount"]),
                           IsVerificationComplete = Convert.ToInt32(dr["IsVerificationComplete"]),
                           ComplaintVerificationDate = Convert.ToDateTime(dr["ComplaintVerificationDate"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsLock = Convert.ToInt32(dr["IsLock"]),
                           IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           Complainant_Name = Convert.ToString(dr["Complainant_Name"]),
                           Complainant_MobileNumber = Convert.ToInt64(dr["Complainant_MobileNumber"]),
                           RelatesComplaint_ComplaintAgainstType = Convert.ToString(dr["RelatesComplaint_ComplaintAgainstType"]),
                           Respondent_Name = Convert.ToString(dr["Respondent_Name"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PreHearingDate = Convert.ToDateTime(dr["PreHearingDate"]),
                           PreHearingTime = Convert.ToString(dr["PreHearingTime"]),
                           PreHearingFixedForName = Convert.ToString(dr["PreHearingFixedForName"]),
                           HearingType_Acolumn = Convert.ToString(dr["HearingType_Acolumn"]),
                           HearingBench_Bcolumn = Convert.ToString(dr["HearingBench_Bcolumn"]),

                           complaintrelatedRERAnumber = Convert.ToString(dr["complaintrelatedRERAnumber"]),
                           complaintrelatedProjectorAgentName = Convert.ToString(dr["complaintrelatedProjectorAgentName"]),

                       });
            }
            return ProjectFivelist1;
        }        
    }
}
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsMethod_AuthDesk_FormM_DiaryNumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumber(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            cmd.Dispose();
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormM_RegDiaryNumber(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForPS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormM_RegDiaryNumberInBox(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForPSInBox", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberNewComplaint(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberNewComplaint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberReSubmitted(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberReSubmitted", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing> Display_AuthDesk_ComplaintFormM_RegDiaryNumberPreHearingDetail(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberPreHear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberOrderJudgements(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberNonMaintainableCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberNonMtlCases", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberSineDieCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberSineDieCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        // Transfer Case (Form-M to Form-N)
        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberTransferCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberTrCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            cmd.Dispose();
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberReSubmittedTransferCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberReSubTrCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing> Display_AuthDesk_ComplaintFormM_RegDiaryNumberPreHearingDetailTransferCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberPreHearTrCse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberOrderJudgementsTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForOrdTrCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormM_RegDiaryNumberInBoxTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForPSInBxTrC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormM_RegDiaryNumberTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForPSTrCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberNonMaintainableTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberNonMtlTrCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberSineDieTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberSineDiTrCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        // Bifurcate Case
        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberBifurcateCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberBfCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            cmd.Dispose();
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberReSubmittedBifurcateCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberReSubBfCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing> Display_AuthDesk_ComplaintFormM_RegDiaryNumberPreHearingBifurcateCaseDetail(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberPreHearBfCse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumberPreHearing
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberBifurcateCaseOrderJudgements(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForOrdBfCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormM_RegDiaryNumberBifurcateCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForPSBfCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormM_RegDiaryNumberInBoxBifurcateCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberForPSInBxBfC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberBifurcateCaseNonMaintainableCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberNonMtlBfCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_AuthDesk_ComplaintFormM_RegDiaryNumberBifurcateCaseSineDieCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormM_RegDiaryNumberSineDiBfCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);
            cmd.Parameters.AddWithValue("p_UserID", User_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        // CP: Bifurcation of Case
        public List<ClsPrp_AuthDesk_FormM_DiaryNumber> Display_CP_ComplaintFormM_CaseBifurcationList(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormM_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormM_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_CP_Complaint_FormM_BifurcateCase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_FormM_DiaryNumber
                       {
                           ComplaintRegDiaryNumber_IndexID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_IndexID"]),
                           ComplaintRegDiaryNumber_ID = Convert.ToInt64(dr["ComplaintRegDiaryNumber_ID"]),
                           ComplaintRegDiaryNumber_Name = Convert.ToString(dr["ComplaintRegDiaryNumber_Name"]),
                           ComplaintRegDiaryNumber_NameYear = Convert.ToInt32(dr["ComplaintRegDiaryNumber_NameYear"]),
                           FormM_RelatedComplaint_ID = Convert.ToInt64(dr["FormM_RelatedComplaint_ID"]),
                           FormM_RelatedComplaint_Code = Convert.ToString(dr["FormM_RelatedComplaint_Code"]),
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
                       });
            }
            return ProjectFivelist1;
        }

        #region EXECUTION

        public List<ClsPrp_AuthDesk_FormExe_DiaryNumber> Display_AuthDesk_ComplaintFormExe_RegDiaryNumber(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormExe_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormExe_DiaryNumber>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormExe_RegDiaryNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                cmd.Dispose();
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ProjectFivelist1.Add(
                           new ClsPrp_AuthDesk_FormExe_DiaryNumber
                           {
                               ExecutionRegDiaryNumber_IndexID = Convert.ToInt64(dr["ExecutionRegDiaryNumber_IndexID"]),
                               ExecutionRegDiaryNumber_ID = Convert.ToInt64(dr["ExecutionRegDiaryNumber_ID"]),
                               ExecutionRegDiaryNumber_Name = Convert.ToString(dr["ExecutionRegDiaryNumber_Name"]),
                               ExecutionRegDiaryNumber_NameYear = Convert.ToInt32(dr["ExecutionRegDiaryNumber_NameYear"]),
                               FormEXE_RelatedExecution_ID = Convert.ToInt64(dr["FormEXE_RelatedExecution_ID"]),
                               FormEXE_RelatedComplaint_Code = Convert.ToString(dr["FormEXE_RelatedComplaint_Code"]),
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
                               //A_column = Convert.ToString(dr["A_column"]),
                               //B_column = Convert.ToString(dr["B_column"]),
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
                               RelatesComplaint_ComplaintAgainstType = Convert.ToInt64(dr["RelatesComplaint_ComplaintAgainstType"]),
                               Respondent_Name = Convert.ToString(dr["Respondent_Name"]),

                               EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                               EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                               EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                               EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                               Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                               EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                               EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           });
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return ProjectFivelist1;
        }

        #endregion
    }
}
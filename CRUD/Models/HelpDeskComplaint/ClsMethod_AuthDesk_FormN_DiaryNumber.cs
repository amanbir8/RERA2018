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
    public class ClsMethod_AuthDesk_FormN_DiaryNumber
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumber(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumber", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormN_RegDiaryNumber(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForPS", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormN_RegDiaryNumberInBox(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForPSInBox", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberNewComplaint(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberNewComplaint", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberReSubmitted(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberReSubmitted", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing> Display_AuthDesk_ComplaintFormN_RegDiaryNumberPreHearingDetail(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberPreHear", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberOrderJudgements(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForOrder", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberNonMaintainableCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberNonMtlCases", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberSineDieCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberSineDieCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        // Transfer Case (Form-N to Form-M)
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberTransferCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberTrCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberReSubmittedTransferCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberReSubTrCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing> Display_AuthDesk_ComplaintFormN_RegDiaryNumberPreHearingDetailTransferCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberPreHearTrC", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing
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
                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberOrderJudgementsTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForOrderTrC", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormN_RegDiaryNumberInBoxTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForPSInBxTrC", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }
        
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormN_RegDiaryNumberTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForPSTrCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberNonMaintainableTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberNonMtlTrCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberSineDieTransferCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberSineDiTrCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        // Bifurcate Case
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberBifurcateCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberBfCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberReSubmittedBifurcateCase(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberReSubBfCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing> Display_AuthDesk_ComplaintFormN_RegDiaryNumberPreHearingBifurcateCaseDetail(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberPreHearBfCse", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumberPreHearing
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberBifurcateCaseOrderJudgements(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForOrderBfC", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormN_RegDiaryNumberBifurcateCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForPSBfCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthPSmembersDesk_ComplaintFormN_RegDiaryNumberInBoxBifurcateCase(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberForPSInBxBfC", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberBifurcateCaseNonMaintainableCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberNonMtlBfCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_AuthDesk_ComplaintFormN_RegDiaryNumberBifurcateCaseSineDieCases(string UserID_Role, string User_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_Complaint_FormN_RegDiaryNumberSineDiBfCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }

        // CP: Bifurcation of Case
        public List<ClsPrp_AuthDesk_FormN_DiaryNumber> Display_CP_ComplaintFormN_CaseBifurcationList(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthDesk_FormN_DiaryNumber> ProjectFivelist1 = new List<ClsPrp_AuthDesk_FormN_DiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_CP_Complaint_FormN_BifurcateCase", con);
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
                       new ClsPrp_AuthDesk_FormN_DiaryNumber
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
                       });
            }
            return ProjectFivelist1;
        }
    }
}
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_CompletionCertificateHelpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Display Project Completion
        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccNewApplication", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsNewReSubmittedApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccNewReSubmitted", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsReviewCL(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccReviewCL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsApproved(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccApproved", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsApprovedByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccApprovedByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_approvalyear", approvalyear);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsRejected(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccRejected", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsWithdrawn(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePccWithdrawn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsPublicViewIssuePCC(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePublicViewIssuePCC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsPublicViewPCC(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePublicViewPCC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ListPCC;
        }

        public List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> Display_AuthorityDesk_ProjectCompletionDetailsPublicViewPCCByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber> ListPCC = new List<ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CompletionCertificatePublicViewPCCByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_approvalyear", approvalyear);
            cmd.Parameters.AddWithValue("p_fromDate", fromDate);
            cmd.Parameters.AddWithValue("p_toDate", toDate);
            cmd.Parameters.AddWithValue("p_filterType", filterType);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListPCC.Add(
                       new ClsPrp_AuthorityDesk_CompletionCertificateDiaryNumber
                       {
                           PCC_RegDiaryNumber_IndexID = Convert.ToInt64(dr["PCC_RegDiaryNumber_IndexID"]),
                           PCC_RegDiaryNumber_ID = Convert.ToInt64(dr["PCC_RegDiaryNumber_ID"]),
                           PCC_RegDiaryNumber_Name = Convert.ToString(dr["PCC_RegDiaryNumber_Name"]),
                           PCC_RegDiaryNumber_NameYear = Convert.ToString(dr["PCC_RegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           ProjectCompletionCertificateCount = Convert.ToInt32(dr["ProjectCompletionCertificateCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
                           Extra1 = Convert.ToString(dr["Extra1"]),
                           Extra2 = Convert.ToString(dr["Extra2"]),
                           Extra3 = Convert.ToString(dr["Extra3"]),
                           Extra4 = Convert.ToString(dr["Extra4"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           IsDraftHelpDesk = Convert.ToInt32(dr["IsDraftHelpDesk"]),
                           IsDraftEvaluation = Convert.ToInt32(dr["IsDraftEvaluation"]),
                           IsDraftSecMember = Convert.ToInt32(dr["IsDraftSecMember"]),
                           IsDraftMember = Convert.ToInt32(dr["IsDraftMember"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),

                           ProjectApplicationDate = Convert.ToDateTime(dr["ProjectApplicationDate"]),
                           ProjectExtensionApplicationDate = Convert.ToDateTime(dr["ProjectExtensionApplicationDate"]),
                           ProjectCompletionApplicationDate = Convert.ToDateTime(dr["ProjectCompletionApplicationDate"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),

                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),
                           Project_RERAregistrationIssueDate = Convert.ToDateTime(dr["Project_RERAregistrationIssueDate"]),
                           Project_RERAregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAregistrationValidUptoDate"]),
                           Project_RERAextnregistrationValidUptoDate = Convert.ToDateTime(dr["Project_RERAextnregistrationValidUptoDate"]),

                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           EventRERA_RegistrationNumber = Convert.ToString(dr["EventRERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                       });
            }
            return ListPCC;
        }

        // Event Project Completion  
        public List<ClsPrp_AuthorityDesk_CompletionProjectEventLog> Display_AuthorityDesk_ProjectCompletionEventLogDetails(Int64 Project_ID, Int64 Promoter_ID, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_CompletionProjectEventLog> ProjectList = new List<ClsPrp_AuthorityDesk_CompletionProjectEventLog>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_PCCprojectEventLogDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_CompletionProjectEventLog
                       {
                           ProjectCompletionEventAction_ID = Convert.ToInt64(dr["ProjectCompletionEventAction_ID"]),
                           EventAction_Type = Convert.ToInt64(dr["EventAction_Type"]),
                           EventAction_IdentifiedBy = Convert.ToString(dr["EventAction_IdentifiedBy"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Completion_DiaryNumber = Convert.ToString(dr["Completion_DiaryNumber"]),
                           RERA_RegistrationNumber = Convert.ToString(dr["RERA_RegistrationNumber"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),
                           EventAction_Description = Convert.ToString(dr["EventAction_Description"]),
                           EventAction_Category = Convert.ToString(dr["EventAction_Category"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           EventAction_Relationship = Convert.ToString(dr["EventAction_Relationship"]),
                           AssignedTo = Convert.ToString(dr["AssignedTo"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           Target_ResolutionSummary = Convert.ToString(dr["Target_ResolutionSummary"]),
                           Actual_ResolutionDate = Convert.ToDateTime(dr["Actual_ResolutionDate"]),
                           IsBefore_TargetResolution = Convert.ToInt32(dr["IsBefore_TargetResolution"]),
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
            return ProjectList;
        }

        public List<ClsPrp_AuthorityDesk_ProjectEvent_Master> Display_AuthorityDesk_ProjectCompletionEvent_Master(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectEvent_Master> ProjectList = new List<ClsPrp_AuthorityDesk_ProjectEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_PCCprojectEvent_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectList.Add(
                       new ClsPrp_AuthorityDesk_ProjectEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
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
            return ProjectList;
        }

        public List<ClsPrp_AuthorityDesk_ProjectEvent_Master> Display_AuthorityDesk_EventDescription_MasterDetailsByCode(Int32 Event_ID)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectEvent_Master> ProjectFivelist1 = new List<ClsPrp_AuthorityDesk_ProjectEvent_Master>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthorityDesk_ProjectEventDescriptionDetailsByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Event_ID", Event_ID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthorityDesk_ProjectEvent_Master
                       {
                           EventAction_IndexID = Convert.ToInt64(dr["EventAction_IndexID"]),
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
            return ProjectFivelist1;
        }

        public bool Add_ProjectCompletionForm_InfoEvent(ClsPrp_AuthorityDesk_CompletionProjectEventLog smodel, string UserRole, string User_WhoIdentified)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_insert_tbl_RERA_Project_CompletionCertificate_EventAction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters

            cmd.Parameters.AddWithValue("p_EventAction_Type", smodel.EventAction_Type);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedBy", User_WhoIdentified);
            cmd.Parameters.AddWithValue("p_EventAction_IdentifiedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Related_Promoter_ID", smodel.Related_Promoter_ID);
            cmd.Parameters.AddWithValue("p_Related_Project_ID", smodel.Related_Project_ID);
            cmd.Parameters.AddWithValue("p_Promoter_DiaryNumber", String.IsNullOrEmpty(smodel.Promoter_DiaryNumber) ? "" : smodel.Promoter_DiaryNumber);
            cmd.Parameters.AddWithValue("p_Project_DiaryNumber", String.IsNullOrEmpty(smodel.Project_DiaryNumber) ? "" : smodel.Project_DiaryNumber);
            cmd.Parameters.AddWithValue("p_Completion_DiaryNumber", String.IsNullOrEmpty(smodel.Completion_DiaryNumber) ? "" : smodel.Completion_DiaryNumber);
            cmd.Parameters.AddWithValue("p_RERA_RegistrationNumber", String.IsNullOrEmpty(smodel.ProjectRegistrationNumberName) ? "" : smodel.ProjectRegistrationNumberName);
            cmd.Parameters.AddWithValue("p_EventAction_Summary", String.IsNullOrEmpty(smodel.EventAction_Summary) ? "" : smodel.EventAction_Summary);
            cmd.Parameters.AddWithValue("p_EventAction_Description", String.IsNullOrEmpty(smodel.EventAction_Description) ? "" : smodel.EventAction_Description);
            cmd.Parameters.AddWithValue("p_EventAction_Category", String.IsNullOrEmpty(smodel.EventAction_Category) ? "" : smodel.EventAction_Category);
            cmd.Parameters.AddWithValue("p_EventAction_Aggregate", String.IsNullOrEmpty(smodel.EventAction_Aggregate) ? "" : smodel.EventAction_Aggregate);
            cmd.Parameters.AddWithValue("p_EventAction_Relationship", UserRole);
            cmd.Parameters.AddWithValue("p_AssignedTo", String.IsNullOrEmpty(smodel.AssignedTo) ? "" : smodel.AssignedTo);
            cmd.Parameters.AddWithValue("p_Target_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_Target_ResolutionSummary", String.IsNullOrEmpty(smodel.Target_ResolutionSummary) ? "" : smodel.Target_ResolutionSummary);
            cmd.Parameters.AddWithValue("p_Actual_ResolutionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("p_IsBefore_TargetResolution", 0);
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

    }
}
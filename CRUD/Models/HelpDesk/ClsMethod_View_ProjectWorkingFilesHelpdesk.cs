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
    public class ClsMethod_View_ProjectWorkingFilesHelpdesk
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // Display Project Working-File
        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsNewApplication(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectNewApplication", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetails(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectInProcessDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsNewReSubmitted(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectNewReSubmitted", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsCheckList(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectCheckList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsApproved(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectApproved", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsApprovedByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectApprovedByDate", con);
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
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsPublicView(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectsPublicView", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsPublicViewByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectsPublicViewByDate", con);
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
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsPendingPublicView(string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectApprovedPendingPV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> Display_AuthorityDesk_ProjectWorkingFileDetailsPendingPublicViewByDate(int approvalyear, string filterType, DateTime? fromDate, DateTime? toDate, string UserID_Role)
        {
            connection();
            List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> ListWorkFile = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_WorkingFilesProjectApprovedPendingPVByDate", con);
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
                ListWorkFile.Add(
                       new ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
                       {
                           #region Parms
                           Reference_ID = Convert.ToInt64(dr["Reference_ID"]),
                           Reference_Number = Convert.ToString(dr["Reference_Number"]),

                           Project_RegDiaryNumber_IndexID = Convert.ToInt64(dr["Project_RegDiaryNumber_IndexID"]),
                           Project_RegDiaryNumber_ID = Convert.ToInt64(dr["Project_RegDiaryNumber_ID"]),
                           ProjectRegDiaryNumber_Name = Convert.ToString(dr["ProjectRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_Name = Convert.ToString(dr["PromoterRegDiaryNumber_Name"]),
                           PromoterRegDiaryNumber_NameYear = Convert.ToString(dr["PromoterRegDiaryNumber_NameYear"]),
                           UserID = Convert.ToString(dr["UserID"]),
                           Promoter_ID = Convert.ToInt64(dr["Promoter_ID"]),
                           Project_ID = Convert.ToInt64(dr["Project_ID"]),
                           LandDetailsCount = Convert.ToInt32(dr["LandDetailsCount"]),
                           KhasraAreaDetailsCount = Convert.ToInt32(dr["KhasraAreaDetailsCount"]),
                           LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                           ApprovalDetailsCount = Convert.ToInt32(dr["ApprovalDetailsCount"]),
                           PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                           SpecialBankAccountDetailsCount = Convert.ToInt32(dr["SpecialBankAccountDetailsCount"]),
                           ProjectDocumentCount = Convert.ToInt32(dr["ProjectDocumentCount"]),
                           IsRegistration = Convert.ToString(dr["IsRegistration"]),
                           CurrentEventcode = Convert.ToInt64(dr["CurrentEventcode"]),
                           EventCodeDetails_indexID = Convert.ToInt64(dr["EventCodeDetails_indexID"]),
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

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Promoter_Name = Convert.ToString(dr["Promoter_Name"]),
                           Project_AddressDistrictName = Convert.ToString(dr["Project_AddressDistrictName"]),
                           Project_RERAregistrationNumber = Convert.ToString(dr["Project_RERAregistrationNumber"]),

                           EventAction_Type = Convert.ToString(dr["EventAction_Type"]),
                           EventAction_TypeName = Convert.ToString(dr["EventAction_TypeName"]),
                           EventAction_IdentifiedOn = Convert.ToDateTime(dr["EventAction_IdentifiedOn"]),
                           EventAction_Aggregate = Convert.ToString(dr["EventAction_Aggregate"]),
                           Target_ResolutionDate = Convert.ToDateTime(dr["Target_ResolutionDate"]),
                           EventRemarks_IfAny = Convert.ToString(dr["EventRemarks_IfAny"]),
                           EventAction_Summary = Convert.ToString(dr["EventAction_Summary"]),

                           PromoterType = Convert.ToInt32(dr["PromoterType"]),
                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           PromoterWebLink = Convert.ToString(dr["PromoterWebLink"]),
                           PromoterAuthSignFormB = Convert.ToString(dr["PromoterAuthSignFormB"]),
                           ProjectAuthContactPersonName = Convert.ToString(dr["ProjectAuthContactPersonName"]),
                           AuthorizedPerson_Email = Convert.ToString(dr["AuthorizedPerson_Email"]),
                           AuthorizedPerson_Mobile = Convert.ToString(dr["AuthorizedPerson_Mobile"]),

                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           ProjectPotentialZone = Convert.ToString(dr["ProjectPotentialZone"]),
                           ProjectWebLink = Convert.ToString(dr["ProjectWebLink"]),

                           RERAnumberRegistration = Convert.ToString(dr["RERAnumberRegistration"]),
                           RERAnumberIssueDate = Convert.ToDateTime(dr["RERAnumberIssueDate"]),
                           RERAnumberRegUptoDate = Convert.ToDateTime(dr["RERAnumberRegUptoDate"]),

                           ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),

                           ProjectRERAcert_FilePath = Convert.ToString(dr["ProjectRERAcert_FilePath"]),
                           ProjectRERAcert_FileName = Convert.ToString(dr["ProjectRERAcert_FileName"]),
                           ProjectRERAcert_ReferenceNumber = Convert.ToString(dr["ProjectRERAcert_ReferenceNumber"]),
                           ProjectRERAcert_IssueDate = Convert.ToDateTime(dr["ProjectRERAcert_IssueDate"]),
                           #endregion
                       });
            }
            return ListWorkFile;
        }

    }
}
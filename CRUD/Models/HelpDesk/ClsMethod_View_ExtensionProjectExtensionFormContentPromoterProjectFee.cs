using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_ExtensionProjectExtensionFormContentPromoterProjectFee
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        // General Details
        public List<ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent> Display_Project_ExtensionFormContentPromoterProjectFeeInfo(Int64 ProjectRegistration_ID, Int64 ProjectPromoter_ID, Int64 ProjectExtension_ID, string userRole)
        {
            connection();
            List<ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent> Projectlist = new List<ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_ExtensionFormContentPrmPrjFeeForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ExtnFrm_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_ExtnFrm_ProjectPromoter_ID", ProjectPromoter_ID);
            cmd.Parameters.AddWithValue("p_ExtnFrm_ProjectExtension_ID", ProjectExtension_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_ExtensionAuthorityDesk_ProjectInfoPromoterProjectFeeContent
                       {
                           ProjectExtFormOne_ID = Convert.ToInt64(dr["ProjectExtFormOne_ID"]),
                           ProjectExtFormTwo_ID = Convert.ToString(dr["ProjectExtFormTwo_ID"]),

                           Related_ProjectExtension_ID = Convert.ToInt64(dr["Related_ProjectExtension_ID"]),
                           ProjectExtension_DiaryNumber = Convert.ToString(dr["ProjectExtension_DiaryNumber"]),
                           ProjectExtension_ApplicationDate = Convert.ToDateTime(dr["ProjectExtension_ApplicationDate"]),

                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_ApplicationDate = Convert.ToDateTime(dr["Project_ApplicationDate"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           Project_ApprovalDate = Convert.ToDateTime(dr["Project_ApprovalDate"]),
                           ProjectLastModifiedOn = Convert.ToDateTime(dr["ProjectLastModifiedOn"]),

                           Project_RegistrationNumber = Convert.ToString(dr["Project_RegistrationNumber"]),
                           Registration_IssueDate = Convert.ToDateTime(dr["Registration_IssueDate"]),
                           Registration_ValidUptoDate = Convert.ToDateTime(dr["Registration_ValidUptoDate"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }
        
        // Desk Action Details
        public List<ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails> Display_AuthDesk_PromoterProject_RegistrationActionDetails(Int64 ProjectRegistration_ID, Int64 ProjectPromoter_ID, Int64 ProjectExtension_ID, string userRole)
        {
            connection();
            List<ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails> Projectlist = new List<ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_DeskRegistrationActionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_RegPrj_ProjectRegistration_ID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_RegPrj_ProjectPromoter_ID", ProjectPromoter_ID);
            cmd.Parameters.AddWithValue("p_RegPrj_ProjectExtension_ID", ProjectExtension_ID);
            cmd.Parameters.AddWithValue("p_RegPrj_UserRole_ID", userRole);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Projectlist.Add(
                       new ClsPrp_AuthorityDesk_PromoterProject_RegistrationActionDetails
                       {
                           ProjectRegistrationActionOne_ID = Convert.ToInt64(dr["ProjectRegistrationActionOne_ID"]),
                           ProjectRegistrationActionTwo_ID = Convert.ToString(dr["ProjectRegistrationActionTwo_ID"]),
                           Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),

                           PromoterName = Convert.ToString(dr["PromoterName"]),
                           ProjectName = Convert.ToString(dr["ProjectName"]),
                           Promoter_DiaryNumber = Convert.ToString(dr["Promoter_DiaryNumber"]),
                           Project_DiaryNumber = Convert.ToString(dr["Project_DiaryNumber"]),
                           Project_ApplicationDate = Convert.ToDateTime(dr["Project_ApplicationDate"]),
                           ProjectLastModifiedOn = Convert.ToDateTime(dr["ProjectLastModifiedOn"]),

                           Project_RegistrationNumber = Convert.ToString(dr["Project_RegistrationNumber"]),
                           Registration_IssueDate = Convert.ToDateTime(dr["Registration_IssueDate"]),
                           Registration_ValidUptoDate = Convert.ToDateTime(dr["Registration_ValidUptoDate"]),

                           RegistrationActionDate = Convert.ToDateTime(dr["RegistrationActionDate"]),
                           RegistrationActionTitle = Convert.ToString(dr["RegistrationActionTitle"]),
                           IdentifiedBy = Convert.ToString(dr["IdentifiedBy"]),
                           Project_DiaryNumber_RERANumber_PUCNumber = Convert.ToString(dr["Project_DiaryNumber_RERANumber_PUCNumber"]),
                           Project_Diarydated_RERAdated_PUCdated = Convert.ToDateTime(dr["Project_Diarydated_RERAdated_PUCdated"]),
                           Project_RegistrationValidUptoDate = Convert.ToDateTime(dr["Project_RegistrationValidUptoDate"]),

                           A_Column = Convert.ToString(dr["A_Column"]),
                           B_Column = Convert.ToString(dr["B_Column"]),
                           C_Column = Convert.ToString(dr["C_Column"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                       });
            }
            return Projectlist;
        }

        // Project Details
        public List<ClsPrp_AuthDesk_View_ProjectRegistration> Display_Project_ExtensionFormProjectRegistration(Int64 zProject_ID, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectRegistration> ProjectFivelist1 = new List<ClsPrp_AuthDesk_View_ProjectRegistration>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_RegistrationForDesk", con);
            cmd.Parameters.AddWithValue("p_ProjectID", zProject_ID);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_View_ProjectRegistration
                       {
                           ProjectRegistration_IndexID = Convert.ToInt64(dr["ProjectRegistration_IndexID"]),
                           ProjectRegistration_ID = Convert.ToInt64(dr["ProjectRegistration_ID"]),

                           Project_Name = Convert.ToString(dr["Project_Name"]),
                           Project_Amenities = Convert.ToString(dr["Project_Amenities"]),
                           IsAlready_RERANumber = Convert.ToString(dr["IsAlready_RERANumber"]),
                           Existing_RERANumber = Convert.ToString(dr["Existing_RERANumber"]),
                           ProposedProjectDetail_Structure = Convert.ToString(dr["ProposedProjectDetail_Structure"]),
                           ProposedProjectDetail_Flooring = Convert.ToString(dr["ProposedProjectDetail_Flooring"]),
                           ProposedProjectDetail_WallFinishing = Convert.ToString(dr["ProposedProjectDetail_WallFinishing"]),
                           ProposedProjectDetail_SanitaryFittings = Convert.ToString(dr["ProposedProjectDetail_SanitaryFittings"]),
                           ProposedProjectDetail_ElectricalFittings = Convert.ToString(dr["ProposedProjectDetail_ElectricalFittings"]),
                           ProposedProjectDetail_Kitchen = Convert.ToString(dr["ProposedProjectDetail_Kitchen"]),
                           IsProposedProjectDetail_OthersIfAny = Convert.ToString(dr["IsProposedProjectDetail_OthersIfAny"]),
                           ProposedProjectDetail_OthersIfAnyName = Convert.ToString(dr["ProposedProjectDetail_OthersIfAnyName"]),
                           ProposedProjectDetail_OthersIfAny = Convert.ToString(dr["ProposedProjectDetail_OthersIfAny"]),
                           Project_Status = Convert.ToString(dr["Project_Status"]),
                           ProjectStart_Date = Convert.ToDateTime(dr["ProjectStart_Date"]),
                           ProjectCompletion_ProposedDate = Convert.ToDateTime(dr["ProjectCompletion_ProposedDate"]),
                           ProjectCompletion_OriginalDate = Convert.ToDateTime(dr["ProjectCompletion_OriginalDate"]),
                           ProjectRegistrationProvided_Duration = Convert.ToString(dr["ProjectRegistrationProvided_Duration"]),
                           ProjectDelayReason_IfAny = Convert.ToString(dr["ProjectDelayReason_IfAny"]),
                           Project_AddressLine1 = Convert.ToString(dr["Project_AddressLine1"]),
                           Project_AddressLine2 = Convert.ToString(dr["Project_AddressLine2"]),
                           Project_AddressStateCode = Convert.ToString(dr["Project_AddressStateCode"]),
                           Project_AddressDistrictCode = Convert.ToString(dr["Project_AddressDistrictCode"]),
                           Project_AddressSubDivisionCode = Convert.ToString(dr["Project_AddressSubDivisionCode"]),
                           Project_AddressPIN = Convert.ToString(dr["Project_AddressPIN"]),
                           Project_PotentialZoneCode = Convert.ToInt16(dr["Project_PotentialZoneCode"]),
                           ProjectWebsite_WebLink = Convert.ToString(dr["ProjectWebsite_WebLink"]),
                           AuthorizedPerson_FirstName = Convert.ToString(dr["AuthorizedPerson_FirstName"]),
                           AuthorizedPerson_MiddleName = Convert.ToString(dr["AuthorizedPerson_MiddleName"]),
                           AuthorizedPerson_LastName = Convert.ToString(dr["AuthorizedPerson_LastName"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToString(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToString(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                           IsProForma_AOS_RERAformat_AnnexureA = Convert.ToString(dr["IsProForma_AOS_RERAformat_AnnexureA"]),
                           IsProForma_AOS_RERAformat_No_IsApproved = Convert.ToString(dr["IsProForma_AOS_RERAformat_No_IsApproved"]),
                           IsProject_MegaProjectCategory = Convert.ToString(dr["IsProject_MegaProjectCategory"]),
                           IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToDecimal(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }

        public List<ClsPrp_AuthDesk_View_ProjectTypeRegistration> Display_Project_ExtensionFormProjectRegistrationTypeProject(Int64 ProjectRegistration_ID, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectTypeRegistration> ProjectFivelist1 = new List<ClsPrp_AuthDesk_View_ProjectTypeRegistration>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_RegistrationTypeProjectForDesk", con);
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectRegistration_ID);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_View_ProjectTypeRegistration
                       {
                           ProjectType_Registration_ID = Convert.ToInt64(dr["ProjectType_Registration_ID"]),
                           ProjectTypeRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectTypeRelated_ProjectRegistration_ID"]),
                           ProjectType_Code = Convert.ToString(dr["ProjectType_Code"]),
                           ProjectType_Name = Convert.ToString(dr["ProjectType_Name"]),
                           ProjectType_SubType_Code = Convert.ToString(dr["ProjectType_SubType_Code"]),
                           ProjectType_SubType_Name = Convert.ToString(dr["ProjectType_SubType_Name"]),
                           //IsDraft = Convert.ToString(dr["IsDraft"]),
                           //CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           //CreatedOn = Convert.ToString(dr["CreatedOn"]),
                           //ModifyBy = Convert.ToString(dr["ModifyBy"]),
                           //ModifyOn = Convert.ToString(dr["ModifyOn"]),
                       });
            }
            return ProjectFivelist1;
        }
        
        // Project Payment Details
        public List<ClsPrp_AuthDesk_View_ProjectPayment> Display_Project_ExtensionFormProjectPayment(Int64 ProjectRegistration_ID, string userRole)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectPayment> ProjectFivelist1 = new List<ClsPrp_AuthDesk_View_ProjectPayment>();

            MySqlCommand cmd = new MySqlCommand("Display_RERA_Project_PaymentForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectPayment_ProjectRegistration_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProjectFivelist1.Add(
                       new ClsPrp_AuthDesk_View_ProjectPayment
                       {
                           ProjectPayment_IndexID = Convert.ToInt64(dr["ProjectPayment_IndexID"]),
                           ProjectPayment_ID = Convert.ToInt64(dr["ProjectPayment_ID"]),
                           ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(dr["ProjectPaymentRelated_ProjectRegistration_ID"]),
                           ProjectPayment_TitleCode = Convert.ToInt32(dr["ProjectPayment_TitleCode"]),
                           ProjectPayment_TitleName = Convert.ToString(dr["ProjectPayment_TitleName"]),
                           Registration_Fee = Convert.ToDecimal(dr["Registration_Fee"]),
                           Other_Fee = Convert.ToDecimal(dr["Other_Fee"]),
                           Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                           Date_of_Payment_RegistrationFee = Convert.ToDateTime(dr["Date_of_Payment_RegistrationFee"]),
                           Bank_Charges = Convert.ToDecimal(dr["Bank_Charges"]),
                           Bank_Name = Convert.ToString(dr["Bank_Name"]),
                           Branch_Name = Convert.ToString(dr["Branch_Name"]),
                           DD_BankersCheque_Number = Convert.ToInt64(dr["DD_BankersCheque_Number"]),
                           DD_BankersCheque_Amount = Convert.ToDecimal(dr["DD_BankersCheque_Amount"]),
                           ImageDDorBankersCheque_FileName = Convert.ToString(dr["ImageDDorBankersCheque_FileName"]),
                           ImageDDorBankersCheque_FilePath = Convert.ToString(dr["ImageDDorBankersCheque_FilePath"]),
                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),

                           IsActive = Convert.ToInt32(dr["IsActive"]),
                           IsDraft = Convert.ToInt32(dr["IsDraft"]),
                           CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                           CreatedBy = Convert.ToString(dr["CreatedBy"]),
                           ModifyOn = Convert.ToDateTime(dr["ModifyOn"]),
                           ModifyBy = Convert.ToString(dr["ModifyBy"]),
                       });
            }
            return ProjectFivelist1;
        }
    }
}
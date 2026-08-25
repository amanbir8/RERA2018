 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models.HelpDesk
{
    public class ClsMethod_View_ProjectRegistration
    {

        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }
       
        public List<ClsPrp_AuthDesk_View_ProjectRegistration> Display_Project_RegistrationAll(Int64 zProject_ID)
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

        public List<ClsPrp_AuthDesk_View_ProjectTypeRegistration> Display_Project_RegistrationTypeProject(Int64 ProjectRegistration_ID)
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

        public List<ClsPrp_AuthDesk_View_ProjectPayment> Display_Project_Payment(Int64 ProjectRegistration_ID)
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
        
        public Int32 Update_LockUnLockHandler_Project_RegistrationApplicationFee(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_RegApplicationFeedetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_RegApplicationFeeIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

        public Int32 Update_LockUnLockHandler_Project_RegistrationDetails(Int64 ProjectID, Int64 IndexID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_project_Registrationdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_ProjectIndexID", IndexID);
            cmd.Parameters.AddWithValue("p_IsDraftValue", IsDraftValue);
            cmd.Parameters.AddWithValue("p_UserName", UserName);
            cmd.Parameters.AddWithValue("p_UserID", UserID);
            cmd.Parameters.AddWithValue("p_RelatedRemarksIfAny", RelatedRemarksIfAny);
            cmd.Parameters.AddWithValue("p_RelatedLockUnlockMsg", RelatedLockUnlockMsg);
            cmd.Parameters.AddWithValue("p_A_Column", string.Empty);
            cmd.Parameters.AddWithValue("p_B_Column", string.Empty);
            #endregion

            MySqlParameter AppPar = new MySqlParameter("p_valIsDraftReturn", MySqlDbType.Int32);
            AppPar.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(AppPar);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Int32 AppId = Convert.ToInt32(AppPar.Value);
            con.Close();

            if (i >= 1)
                return AppId;
            else
                return 999;
        }

        public List<ClsPrp_AuthDesk_View_ProjectPaymentIntegration> Display_Print_ProjectApplicationPaymentTransactions(Int64 ProjectRegistration_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectPaymentIntegration> Application_List = new List<ClsPrp_AuthDesk_View_ProjectPaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_PaymentGatewayDetails_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Project_ID", ProjectRegistration_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Application_List.Add(
                       new ClsPrp_AuthDesk_View_ProjectPaymentIntegration
                       {
                           PaymentRefNumberProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_IndexID"]),
                           PaymentRefNumberProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           ProjectPm_BriefSummary = Convert.ToString(dr["ProjectPm_BriefSummary"]),

                           IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                           PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                           FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                           PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                           PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                           PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                           PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                           PG_Status = Convert.ToString(dr["PG_Status"]),
                           PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                           PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                           PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                           PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                           PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                           PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                           PG_City = Convert.ToString(dr["PG_City"]),
                           PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                           PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                           PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                           PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                           PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                           PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                           PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                           PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                           PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                           PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                           PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                           PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                           PG_State = Convert.ToString(dr["PG_State"]),
                           PG_Country = Convert.ToString(dr["PG_Country"]),
                           PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                           PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                           PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                           PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                           PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                           PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                           PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                           PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                           PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                           PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                           PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                           PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                           PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                           PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                           PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                           PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                           PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                           PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                           PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                           PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                           PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                           PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
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
            return Application_List;
        }

        public List<ClsPrp_AuthDesk_View_ProjectPaymentIntegration> Display_ProjectApplicationPaymentTransactionsDetails(Int64 ProjectRegistration_ID, Int64 ProjectRelatedPayment_ID)
        {
            connection();
            List<ClsPrp_AuthDesk_View_ProjectPaymentIntegration> Application_List = new List<ClsPrp_AuthDesk_View_ProjectPaymentIntegration>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_Project_PaymentGatewayTransactions_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectRegistration_ID);
            cmd.Parameters.AddWithValue("p_RelatedPaymentID", ProjectRelatedPayment_ID);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Application_List.Add(
                       new ClsPrp_AuthDesk_View_ProjectPaymentIntegration
                       {
                           PaymentRefNumberProjectPm_IndexID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_IndexID"]),
                           PaymentRefNumberProjectPm_ID = Convert.ToInt64(dr["PaymentRefNumberProjectPm_ID"]),
                           RelatedProject_ID = Convert.ToInt64(dr["RelatedProject_ID"]),
                           RelatedPromoter_ID = Convert.ToInt64(dr["RelatedPromoter_ID"]),
                           RelatedProject_Code = Convert.ToString(dr["RelatedProject_Code"]),
                           RelatedPromoter_Code = Convert.ToString(dr["RelatedPromoter_Code"]),
                           RelatedPayment_ID = Convert.ToInt64(dr["RelatedPayment_ID"]),
                           RelatedPayment_IndexID = Convert.ToInt64(dr["RelatedPayment_IndexID"]),
                           User_ID = Convert.ToString(dr["User_ID"]),

                           ProjectPmZoneType = Convert.ToString(dr["ProjectPmZoneType"]),
                           PromoterType_IO = Convert.ToString(dr["PromoterType_IO"]),
                           User_Name = Convert.ToString(dr["User_Name"]),
                           ProjectPm_BriefSummary = Convert.ToString(dr["ProjectPm_BriefSummary"]),

                           IsPaymentSuccessComplete = Convert.ToInt32(dr["IsPaymentSuccessComplete"]),
                           PaymentSuccessDate = Convert.ToDateTime(dr["PaymentSuccessDate"]),
                           FailureSuccessSummary = Convert.ToString(dr["FailureSuccessSummary"]),

                           PG_Transaction_ID = Convert.ToString(dr["PG_Transaction_ID"]),
                           PG_Date = Convert.ToDateTime(dr["PG_Date"]),
                           PG_PayU_ID = Convert.ToInt64(dr["PG_PayU_ID"]),
                           PG_Amount = Convert.ToDecimal(dr["PG_Amount"]),
                           PG_Status = Convert.ToString(dr["PG_Status"]),
                           PG_Product_Info = Convert.ToString(dr["PG_Product_Info"]),

                           PG_Customer_Name = Convert.ToString(dr["PG_Customer_Name"]),
                           PG_Last_Name = Convert.ToString(dr["PG_Last_Name"]),
                           PG_Customer_Email = Convert.ToString(dr["PG_Customer_Email"]),
                           PG_Customer_Phone = Convert.ToString(dr["PG_Customer_Phone"]),
                           PG_Customer_IP_Address = Convert.ToString(dr["PG_Customer_IP_Address"]),
                           PG_City = Convert.ToString(dr["PG_City"]),
                           PG_Merchant_Name = Convert.ToString(dr["PG_Merchant_Name"]),
                           PG_Bank_Name = Convert.ToString(dr["PG_Bank_Name"]),
                           PG_Payment_Gateway = Convert.ToString(dr["PG_Payment_Gateway"]),
                           PG_Bank_Reference_No = Convert.ToString(dr["PG_Bank_Reference_No"]),
                           PG_International_Domestic = Convert.ToString(dr["PG_International_Domestic"]),
                           PG_Payment_Type = Convert.ToString(dr["PG_Payment_Type"]),
                           PG_Error_Code = Convert.ToString(dr["PG_Error_Code"]),
                           PG_Error_Message = Convert.ToString(dr["PG_Error_Message"]),
                           PG_Name_on_Card = Convert.ToString(dr["PG_Name_on_Card"]),
                           PG_Card_Number = Convert.ToString(dr["PG_Card_Number"]),

                           PG_Address_Line1 = Convert.ToString(dr["PG_Address_Line1"]),
                           PG_Address_Line2 = Convert.ToString(dr["PG_Address_Line2"]),
                           PG_State = Convert.ToString(dr["PG_State"]),
                           PG_Country = Convert.ToString(dr["PG_Country"]),
                           PG_ZipCode = Convert.ToString(dr["PG_ZipCode"]),

                           PG_Shipping_Firstname = Convert.ToString(dr["PG_Shipping_Firstname"]),
                           PG_Shipping_Lastname = Convert.ToString(dr["PG_Shipping_Lastname"]),
                           PG_Shipping_Address1 = Convert.ToString(dr["PG_Shipping_Address1"]),
                           PG_Shipping_Address2 = Convert.ToString(dr["PG_Shipping_Address2"]),
                           PG_Shipping_City = Convert.ToString(dr["PG_Shipping_City"]),
                           PG_Shipping_State = Convert.ToString(dr["PG_Shipping_State"]),
                           PG_Shipping_Country = Convert.ToString(dr["PG_Shipping_Country"]),
                           PG_Shipping_Zipcode = Convert.ToString(dr["PG_Shipping_Zipcode"]),
                           PG_Shipping_Phone = Convert.ToString(dr["PG_Shipping_Phone"]),

                           PG_Transaction_Fee = Convert.ToDecimal(dr["PG_Transaction_Fee"]),
                           PG_Discount = Convert.ToDecimal(dr["PG_Discount"]),
                           PG_Additional_Charges = Convert.ToDecimal(dr["PG_Additional_Charges"]),
                           PG_Amount_INR = Convert.ToDecimal(dr["PG_Amount_INR"]),
                           PG_UDF_1 = Convert.ToString(dr["PG_UDF_1"]),
                           PG_UDF_2 = Convert.ToString(dr["PG_UDF_2"]),
                           PG_UDF_3 = Convert.ToString(dr["PG_UDF_3"]),
                           PG_UDF_4 = Convert.ToString(dr["PG_UDF_4"]),
                           PG_UDF_5 = Convert.ToString(dr["PG_UDF_5"]),
                           PG_Device_Info = Convert.ToString(dr["PG_Device_Info"]),
                           PG_HashKey = Convert.ToString(dr["PG_HashKey"]),
                           PG_ServiceProvider = Convert.ToString(dr["PG_ServiceProvider"]),

                           Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),
                           A_column = Convert.ToString(dr["A_column"]),
                           B_column = Convert.ToString(dr["B_column"]),
                           C_column = Convert.ToString(dr["C_column"]),
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
            return Application_List;
        }

    }
}
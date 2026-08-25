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
    public class ClsMethod_View_PromoterCoPromoterDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails> Display_AuthDesk_Promoter_CoPromoterDetails_ByID(Int64 ProjectID, Int64 PromoterID, string RegistrationNumber, Int32 Flag, string UserRole, string UserID)
        {
            connection();            
            List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails> CoPromoterDetails = new List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CoPromoter_RegistrationDetails_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_RegistrationNumber", RegistrationNumber);
            cmd.Parameters.AddWithValue("p_Flag", Flag);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CoPromoterDetails.Add(
                    new Clsprp_AuthorityDesk_PromoterCoPromoterDetails
                    {
                        #region paramerters
                        CoPromoter_IndexID = Convert.ToInt64(dr["CoPromoter_IndexID"]),
                        CoPromoter_ApplicationID = Convert.ToInt64(dr["CoPromoter_ApplicationID"]),
                        CoPromoterType_Flag = Convert.ToInt32(dr["CoPromoterType_Flag"]),
                        Org_Title = Convert.ToString(dr["Org_Title"]),
                        Org_Name = Convert.ToString(dr["Org_Name"]),
                        Org_Type = Convert.ToString(dr["Org_Type"]),
                        OTI_Org_Objects = Convert.ToString(dr["OTI_Org_Objects"]),

                        Registered_Address_Org_Line1 = Convert.ToString(dr["Registered_Address_Org_Line1"]),
                        Registered_Address_Org_Line2 = Convert.ToString(dr["Registered_Address_Org_Line2"]),
                        Registered_Address_Org_State = Convert.ToInt32(dr["Registered_Address_Org_State"]),
                        Registered_Address_Org_District = Convert.ToInt32(dr["Registered_Address_Org_District"]),
                        Registered_Address_Org_Pin_Code = Convert.ToString(dr["Registered_Address_Org_Pin_Code"]),

                        First_Name = Convert.ToString(dr["First_Name"]),
                        Middle_Name = Convert.ToString(dr["Middle_Name"]),
                        Last_Name = Convert.ToString(dr["Last_Name"]),
                        Individual_Gender = Convert.ToString(dr["Individual_Gender"]),
                        Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]),
                        Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]),
                        Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]),
                        Ind_Org_Objects = Convert.ToString(dr["Ind_Org_Objects"]),

                        Permanent_Address_Prm_Line1 = Convert.ToString(dr["Permanent_Address_Prm_Line1"]),
                        Permanent_Address_Prm_Line2 = Convert.ToString(dr["Permanent_Address_Prm_Line2"]),
                        Permanent_Address_Prm_State = Convert.ToInt32(dr["Permanent_Address_Prm_State"]),
                        Permanent_Address_Prm_District = Convert.ToInt32(dr["Permanent_Address_Prm_District"]),
                        Permanent_Address_Prm_Pin_Code = Convert.ToString(dr["Permanent_Address_Prm_Pin_Code"]),

                        Communication_AddressLine1 = Convert.ToString(dr["Communication_AddressLine1"]),
                        Communication_AddressLine2 = Convert.ToString(dr["Communication_AddressLine2"]),
                        Communication_AddressStateCode = Convert.ToInt32(dr["Communication_AddressStateCode"]),
                        Communication_AddressDistrictCode = Convert.ToInt32(dr["Communication_AddressDistrictCode"]),
                        Communication_AddressPIN = Convert.ToString(dr["Communication_AddressPIN"]),

                        AuthorizedPerson_Name = Convert.ToString(dr["AuthorizedPerson_Name"]),
                        AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                        AuthorizedPerson_LandlineNumber_STD = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber_STD"]),
                        AuthorizedPerson_LandlineNumber = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber"]),
                        AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),

                        IsAuthorizedPersonAddress = Convert.ToInt32(dr["IsAuthorizedPersonAddress"]),
                        AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                        AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                        AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                        AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                        AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                        CoPromoter_Occupation = Convert.ToString(dr["CoPromoter_Occupation"]),
                        CoPromoter_WebLink = Convert.ToString(dr["CoPromoter_WebLink"]),
                        CoPromoter_PAN_Number = Convert.ToString(dr["CoPromoter_PAN_Number"]),
                        CoPromoter_Aadhaar_Number = Convert.ToInt64(dr["CoPromoter_Aadhaar_Number"]),
                        IsExperience = Convert.ToString(dr["IsExperience"]),
                        Past_Experience_InYear = Convert.ToInt32(dr["Past_Experience_InYear"]),
                        IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                        Past_Litigations_InNumber = Convert.ToInt32(dr["Past_Litigations_InNumber"]),
                        IsOrganizationMembers = Convert.ToString(dr["IsOrganizationMembers"]),
                        IsOrganizationParent_Entity = Convert.ToString(dr["IsOrganizationParent_Entity"]),

                        CoPromoterImage_FilePath = Convert.ToString(dr["CoPromoterImage_FilePath"]),
                        CoPromoterImage_FileName = Convert.ToString(dr["CoPromoterImage_FileName"]),

                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_Used_ID = Convert.ToString(dr["Related_Used_ID"]),
                        Related_Promoter_Application_ID = Convert.ToInt64(dr["Related_Promoter_Application_ID"]),
                        Link_RegDiaryNumber_ID = Convert.ToInt64(dr["Link_RegDiaryNumber_ID"]),
                        Link_RegDiaryNumber_Name = Convert.ToString(dr["Link_RegDiaryNumber_Name"]),
                        Link_RegDiaryNumber_NameYear = Convert.ToString(dr["Link_RegDiaryNumber_NameYear"]),

                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        Column_A = Convert.ToString(dr["Column_A"]),
                        Column_B = Convert.ToString(dr["Column_B"]),
                        Column_C = Convert.ToString(dr["Column_C"]),
                        Column_D = Convert.ToString(dr["Column_D"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        Created_On = Convert.ToDateTime(dr["Created_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),
                        Modified_On = Convert.ToDateTime(dr["Modified_On"]),


                        CoPromoter_RegDiaryNumber_IndexID = Convert.ToInt64(dr["CoPromoter_RegDiaryNumber_IndexID"]),
                        CoPromoter_RegDiaryNumber_ID = Convert.ToInt64(dr["CoPromoter_RegDiaryNumber_ID"]),
                        CoPromoter_RegDiaryNumber_Name = Convert.ToString(dr["CoPromoter_RegDiaryNumber_Name"]),
                        CoPromoter_RegDiaryNumber_NameYear = Convert.ToString(dr["CoPromoter_RegDiaryNumber_NameYear"]),
                        Related_CoPromoter_ApplicationID = Convert.ToInt64(dr["Related_CoPromoter_ApplicationID"]),
                        Related_CoPromoterType_Flag = Convert.ToInt32(dr["Related_CoPromoterType_Flag"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        LinkTo_Related_Promoter_ID = Convert.ToInt64(dr["LinkTo_Related_Promoter_ID"]),
                        LinkTo_Related_Project_ID = Convert.ToInt64(dr["LinkTo_Related_Project_ID"]),
                        LinkTo_Related_RegistrationNumber = Convert.ToString(dr["LinkTo_Related_RegistrationNumber"]),
                        LinkTo_RegDiaryNumber_Promoter_ID = Convert.ToInt64(dr["LinkTo_RegDiaryNumber_Promoter_ID"]),
                        LinkTo_RegDiaryNumber_ID = Convert.ToInt64(dr["LinkTo_RegDiaryNumber_ID"]),
                        LinkTo_RegDiaryNumber_Name = Convert.ToString(dr["LinkTo_RegDiaryNumber_Name"]),
                        LinkTo_RegDiaryNumber_NameYear = Convert.ToString(dr["LinkTo_RegDiaryNumber_NameYear"]),
                        OrgMemberCount = Convert.ToInt32(dr["OrgMemberCount"]),
                        ParentEntityCount = Convert.ToInt32(dr["ParentEntityCount"]),
                        LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                        DocumentsCount = Convert.ToInt32(dr["DocumentsCount"]),
                        PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                        TrackRecordDetailsCount = Convert.ToInt32(dr["TrackRecordDetailsCount"]),
                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        Link_IndexID = Convert.ToInt64(dr["Link_IndexID"]),
                        Link_ApplicationID = Convert.ToInt64(dr["Link_ApplicationID"]),
                        IsBriefSummaryDraft = Convert.ToInt32(dr["IsBriefSummaryDraft"]),
                        IsBriefSummaryLock = Convert.ToInt32(dr["IsBriefSummaryLock"]),                        
                        #endregion
                    });
            }
            return CoPromoterDetails;
        }

        public List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails> Display_AuthDesk_Promoter_CoPromoterDetails_ByAppID(Int64 ProjectID, Int64 PromoterID, Int64 ApplicationID, Int32 Flag, string UserRole, string UserID)
        {
            connection();
            List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails> CoPromoterDetails = new List<Clsprp_AuthorityDesk_PromoterCoPromoterDetails>();

            MySqlCommand cmd = new MySqlCommand("Display_Rera_AuthDesk_CoPromoter_ReferenceDetails_ForDesk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("p_Flag", Flag);
            cmd.Parameters.AddWithValue("p_UserRole", UserRole);
            cmd.Parameters.AddWithValue("p_UserID", UserID);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CoPromoterDetails.Add(
                    new Clsprp_AuthorityDesk_PromoterCoPromoterDetails
                    {
                        #region paramerters
                        CoPromoter_IndexID = Convert.ToInt64(dr["CoPromoter_IndexID"]),
                        CoPromoter_ApplicationID = Convert.ToInt64(dr["CoPromoter_ApplicationID"]),
                        CoPromoterType_Flag = Convert.ToInt32(dr["CoPromoterType_Flag"]),
                        Org_Title = Convert.ToString(dr["Org_Title"]),
                        Org_Name = Convert.ToString(dr["Org_Name"]),
                        Org_Type = Convert.ToString(dr["Org_Type"]),
                        OTI_Org_Objects = Convert.ToString(dr["OTI_Org_Objects"]),

                        Registered_Address_Org_Line1 = Convert.ToString(dr["Registered_Address_Org_Line1"]),
                        Registered_Address_Org_Line2 = Convert.ToString(dr["Registered_Address_Org_Line2"]),
                        Registered_Address_Org_State = Convert.ToInt32(dr["Registered_Address_Org_State"]),
                        Registered_Address_Org_District = Convert.ToInt32(dr["Registered_Address_Org_District"]),
                        Registered_Address_Org_Pin_Code = Convert.ToString(dr["Registered_Address_Org_Pin_Code"]),

                        First_Name = Convert.ToString(dr["First_Name"]),
                        Middle_Name = Convert.ToString(dr["Middle_Name"]),
                        Last_Name = Convert.ToString(dr["Last_Name"]),
                        Individual_Gender = Convert.ToString(dr["Individual_Gender"]),
                        Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]),
                        Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]),
                        Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]),
                        Ind_Org_Objects = Convert.ToString(dr["Ind_Org_Objects"]),

                        Permanent_Address_Prm_Line1 = Convert.ToString(dr["Permanent_Address_Prm_Line1"]),
                        Permanent_Address_Prm_Line2 = Convert.ToString(dr["Permanent_Address_Prm_Line2"]),
                        Permanent_Address_Prm_State = Convert.ToInt32(dr["Permanent_Address_Prm_State"]),
                        Permanent_Address_Prm_District = Convert.ToInt32(dr["Permanent_Address_Prm_District"]),
                        Permanent_Address_Prm_Pin_Code = Convert.ToString(dr["Permanent_Address_Prm_Pin_Code"]),

                        Communication_AddressLine1 = Convert.ToString(dr["Communication_AddressLine1"]),
                        Communication_AddressLine2 = Convert.ToString(dr["Communication_AddressLine2"]),
                        Communication_AddressStateCode = Convert.ToInt32(dr["Communication_AddressStateCode"]),
                        Communication_AddressDistrictCode = Convert.ToInt32(dr["Communication_AddressDistrictCode"]),
                        Communication_AddressPIN = Convert.ToString(dr["Communication_AddressPIN"]),

                        AuthorizedPerson_Name = Convert.ToString(dr["AuthorizedPerson_Name"]),
                        AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                        AuthorizedPerson_LandlineNumber_STD = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber_STD"]),
                        AuthorizedPerson_LandlineNumber = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber"]),
                        AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),

                        IsAuthorizedPersonAddress = Convert.ToInt32(dr["IsAuthorizedPersonAddress"]),
                        AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                        AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                        AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                        AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                        AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),

                        CoPromoter_Occupation = Convert.ToString(dr["CoPromoter_Occupation"]),
                        CoPromoter_WebLink = Convert.ToString(dr["CoPromoter_WebLink"]),
                        CoPromoter_PAN_Number = Convert.ToString(dr["CoPromoter_PAN_Number"]),
                        CoPromoter_Aadhaar_Number = Convert.ToInt64(dr["CoPromoter_Aadhaar_Number"]),
                        IsExperience = Convert.ToString(dr["IsExperience"]),
                        Past_Experience_InYear = Convert.ToInt32(dr["Past_Experience_InYear"]),
                        IsLitigation_RelatedProject = Convert.ToString(dr["IsLitigation_RelatedProject"]),
                        Past_Litigations_InNumber = Convert.ToInt32(dr["Past_Litigations_InNumber"]),
                        IsOrganizationMembers = Convert.ToString(dr["IsOrganizationMembers"]),
                        IsOrganizationParent_Entity = Convert.ToString(dr["IsOrganizationParent_Entity"]),

                        CoPromoterImage_FilePath = Convert.ToString(dr["CoPromoterImage_FilePath"]),
                        CoPromoterImage_FileName = Convert.ToString(dr["CoPromoterImage_FileName"]),

                        Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                        Related_Used_ID = Convert.ToString(dr["Related_Used_ID"]),
                        Related_Promoter_Application_ID = Convert.ToInt64(dr["Related_Promoter_Application_ID"]),
                        Link_RegDiaryNumber_ID = Convert.ToInt64(dr["Link_RegDiaryNumber_ID"]),
                        Link_RegDiaryNumber_Name = Convert.ToString(dr["Link_RegDiaryNumber_Name"]),
                        Link_RegDiaryNumber_NameYear = Convert.ToString(dr["Link_RegDiaryNumber_NameYear"]),

                        RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
                        Column_A = Convert.ToString(dr["Column_A"]),
                        Column_B = Convert.ToString(dr["Column_B"]),
                        Column_C = Convert.ToString(dr["Column_C"]),
                        Column_D = Convert.ToString(dr["Column_D"]),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        IsDraft = Convert.ToInt32(dr["IsDraft"]),
                        IsLock = Convert.ToInt32(dr["IsLock"]),
                        IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                        Created_By = Convert.ToString(dr["Created_By"]),
                        Created_On = Convert.ToDateTime(dr["Created_On"]),
                        Modify_By = Convert.ToString(dr["Modify_By"]),
                        Modified_On = Convert.ToDateTime(dr["Modified_On"]),


                        CoPromoter_RegDiaryNumber_IndexID = Convert.ToInt64(dr["CoPromoter_RegDiaryNumber_IndexID"]),
                        CoPromoter_RegDiaryNumber_ID = Convert.ToInt64(dr["CoPromoter_RegDiaryNumber_ID"]),
                        CoPromoter_RegDiaryNumber_Name = Convert.ToString(dr["CoPromoter_RegDiaryNumber_Name"]),
                        CoPromoter_RegDiaryNumber_NameYear = Convert.ToString(dr["CoPromoter_RegDiaryNumber_NameYear"]),
                        Related_CoPromoter_ApplicationID = Convert.ToInt64(dr["Related_CoPromoter_ApplicationID"]),
                        Related_CoPromoterType_Flag = Convert.ToInt32(dr["Related_CoPromoterType_Flag"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        LinkTo_Related_Promoter_ID = Convert.ToInt64(dr["LinkTo_Related_Promoter_ID"]),
                        LinkTo_Related_Project_ID = Convert.ToInt64(dr["LinkTo_Related_Project_ID"]),
                        LinkTo_Related_RegistrationNumber = Convert.ToString(dr["LinkTo_Related_RegistrationNumber"]),
                        LinkTo_RegDiaryNumber_Promoter_ID = Convert.ToInt64(dr["LinkTo_RegDiaryNumber_Promoter_ID"]),
                        LinkTo_RegDiaryNumber_ID = Convert.ToInt64(dr["LinkTo_RegDiaryNumber_ID"]),
                        LinkTo_RegDiaryNumber_Name = Convert.ToString(dr["LinkTo_RegDiaryNumber_Name"]),
                        LinkTo_RegDiaryNumber_NameYear = Convert.ToString(dr["LinkTo_RegDiaryNumber_NameYear"]),
                        OrgMemberCount = Convert.ToInt32(dr["OrgMemberCount"]),
                        ParentEntityCount = Convert.ToInt32(dr["ParentEntityCount"]),
                        LitigationsCount = Convert.ToInt32(dr["LitigationsCount"]),
                        DocumentsCount = Convert.ToInt32(dr["DocumentsCount"]),
                        PaymentDetailsCount = Convert.ToInt32(dr["PaymentDetailsCount"]),
                        TrackRecordDetailsCount = Convert.ToInt32(dr["TrackRecordDetailsCount"]),
                        Extra1 = Convert.ToString(dr["Extra1"]),
                        Extra2 = Convert.ToString(dr["Extra2"]),
                        Extra3 = Convert.ToString(dr["Extra3"]),
                        Remarks_IfAny = Convert.ToString(dr["Remarks_IfAny"]),

                        Link_IndexID = Convert.ToInt64(dr["Link_IndexID"]),
                        Link_ApplicationID = Convert.ToInt64(dr["Link_ApplicationID"]),
                        IsBriefSummaryDraft = Convert.ToInt32(dr["IsBriefSummaryDraft"]),
                        IsBriefSummaryLock = Convert.ToInt32(dr["IsBriefSummaryLock"]),
                        #endregion
                    });
            }
            return CoPromoterDetails;
        }

        public Int32 Update_LockUnLockHandler_CoPromoter_RecordsListDetails(Int64 ProjectID, Int64 PromoterID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_copromoter_recordslistdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
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

        public Int32 Update_LockUnLockHandler_CoPromoter_ProfileDetailsByIndex(Int64 ProjectID, Int64 PromoterID, Int32 IsDraftValue, string UserName, string UserID, string RelatedRemarksIfAny, string RelatedLockUnlockMsg, Int64 IndexID, Int64 AppID)
        {
            connection();
            MySqlCommand cmd = new MySqlCommand("usp_lockunlock_tbl_rera_copromoter_recordsdetailbyindex", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Parameters
            cmd.Parameters.AddWithValue("p_ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("p_PromoterID", PromoterID);
            cmd.Parameters.AddWithValue("p_IndexID", IndexID);
            cmd.Parameters.AddWithValue("p_ApplicationID", AppID);
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
    }
}
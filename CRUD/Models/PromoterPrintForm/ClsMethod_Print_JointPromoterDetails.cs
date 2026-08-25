using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterPrint
{
    public class ClsMethod_Print_JointPromoterDetails
    {
        private MySqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["reraConn"].ToString();
            con = new MySqlConnection(constring);
        }


        public List<Clsprp_JointPromoter_Print_ProfileForm> Display_JointPromoter_ProfileDetail_ByID_ForPrint(Int64 Promoter_ID, Int32 Promoter_Type, Int64 JointPromoter_ID, Int32 JointPromoter_Type, string UserID_Name, string UserID_Role)
        {
            List<Clsprp_JointPromoter_Print_ProfileForm> ProfileDetailList = new List<Clsprp_JointPromoter_Print_ProfileForm>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_Print_ProfileFormByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_Promoter_Type", Promoter_Type);
            cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_Type);
            cmd.Parameters.AddWithValue("p_UserName", UserID_Name);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                ProfileDetailList.Add(
                       new Clsprp_JointPromoter_Print_ProfileForm
                       {
                           //CoPromoter Registration Parms - START
                           CoPromoter_IndexID = Convert.ToInt64(dr["CoPromoter_IndexID"]),
                           CoPromoter_ApplicationID = Convert.ToInt64(dr["CoPromoter_ApplicationID"]),

                           CoPromoterType_Flag = Convert.ToInt32(dr["CoPromoterType_Flag"]),

                           //OTI Case
                           Org_Title = Convert.ToString(dr["Org_Title"]),
                           Org_Name = Convert.ToString(dr["Org_Name"]),
                           Org_Type = Convert.ToString(dr["Org_Type"]),
                           OTI_Org_Objects = Convert.ToString(dr["OTI_Org_Objects"]),

                           //IND Case
                           First_Name = Convert.ToString(dr["First_Name"]),
                           Middle_Name = Convert.ToString(dr["Middle_Name"]),
                           Last_Name = Convert.ToString(dr["Last_Name"]),
                           Individual_Gender = Convert.ToString(dr["Individual_Gender"]),

                           Fath_First_Name = Convert.ToString(dr["Fath_First_Name"]),
                           Fath_Middle_Name = Convert.ToString(dr["Fath_Middle_Name"]),
                           Fath_Last_Name = Convert.ToString(dr["Fath_Last_Name"]),
                           Ind_Org_Objects = Convert.ToString(dr["Ind_Org_Objects"]),

                           //Registered Address
                           Registered_Address_Org_Line1 = Convert.ToString(dr["Registered_Address_Org_Line1"]),
                           Registered_Address_Org_Line2 = Convert.ToString(dr["Registered_Address_Org_Line2"]),
                           Registered_Address_Org_State = Convert.ToInt32(dr["Registered_Address_Org_State"]),
                           Registered_Address_Org_District = Convert.ToInt32(dr["Registered_Address_Org_District"]),
                           Registered_Address_Org_Pin_Code = Convert.ToString(dr["Registered_Address_Org_Pin_Code"]),
                           Registered_Address_Org_DistrictState_Name = Convert.ToString(dr["Registered_Address_Org_DistrictState_Name"]),

                           //Permanent Address
                           Permanent_Address_Prm_Line1 = Convert.ToString(dr["Permanent_Address_Prm_Line1"]),
                           Permanent_Address_Prm_Line2 = Convert.ToString(dr["Permanent_Address_Prm_Line2"]),
                           Permanent_Address_Prm_State = Convert.ToInt32(dr["Permanent_Address_Prm_State"]),
                           Permanent_Address_Prm_District = Convert.ToInt32(dr["Permanent_Address_Prm_District"]),
                           Permanent_Address_Prm_Pin_Code = Convert.ToString(dr["Permanent_Address_Prm_Pin_Code"]),
                           Permanent_Address_Prm_DistrictState_Name = Convert.ToString(dr["Permanent_Address_Prm_DistrictState_Name"]),

                           //Communication Address
                           Communication_AddressLine1 = Convert.ToString(dr["Communication_AddressLine1"]),
                           Communication_AddressLine2 = Convert.ToString(dr["Communication_AddressLine2"]),
                           Communication_AddressStateCode = Convert.ToInt32(dr["Communication_AddressStateCode"]),
                           Communication_AddressDistrictCode = Convert.ToInt32(dr["Communication_AddressDistrictCode"]),
                           Communication_AddressPIN = Convert.ToString(dr["Communication_AddressPIN"]),
                           Communication_Address_DistrictState_Name = Convert.ToString(dr["Communication_Address_DistrictState_Name"]),

                           //Authorized Person details
                           AuthorizedPerson_Name = Convert.ToString(dr["AuthorizedPerson_Name"]),
                           AuthorizedPerson_MobileNumber = Convert.ToInt64(dr["AuthorizedPerson_MobileNumber"]),
                           AuthorizedPerson_LandlineNumber_STD = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber_STD"]),
                           AuthorizedPerson_LandlineNumber = Convert.ToInt64(dr["AuthorizedPerson_LandlineNumber"]),
                           AuthorizedPerson_EmailAddress = Convert.ToString(dr["AuthorizedPerson_EmailAddress"]),

                           //Authorized Person Address
                           IsAuthorizedPersonAddress = Convert.ToInt32(dr["IsAuthorizedPersonAddress"]),
                           AuthorizedPerson_AddressLine1 = Convert.ToString(dr["AuthorizedPerson_AddressLine1"]),
                           AuthorizedPerson_AddressLine2 = Convert.ToString(dr["AuthorizedPerson_AddressLine2"]),
                           AuthorizedPerson_AddressStateCode = Convert.ToInt32(dr["AuthorizedPerson_AddressStateCode"]),
                           AuthorizedPerson_AddressDistrictCode = Convert.ToInt32(dr["AuthorizedPerson_AddressDistrictCode"]),
                           AuthorizedPerson_AddressPIN = Convert.ToString(dr["AuthorizedPerson_AddressPIN"]),
                           AuthorizedPerson_AddressDistrictState_Name = Convert.ToString(dr["AuthorizedPerson_AddressDistrictState_Name"]),

                           //Other Parms
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

                           IsUploadPhotograph = Convert.ToInt32(dr["IsUploadPhotograph"]),
                           CoPromoterImage_FilePath = Convert.ToString(dr["CoPromoterImage_FilePath"]),
                           CoPromoterImage_FileName = Convert.ToString(dr["CoPromoterImage_FileName"]),

                           //Related Reference ID
                           //Dropdown value - Related_ProjectID - START
                           Related_Project_ID = Convert.ToInt64(dr["Related_Project_ID"]),
                           Related_Used_ID = Convert.ToString(dr["Related_Used_ID"]),
                           Related_Promoter_Application_ID = Convert.ToInt64(dr["Related_Promoter_Application_ID"]),

                           //Another Primary Promoter ID
                           Link_RegDiaryNumber_ID = Convert.ToInt64(dr["Link_RegDiaryNumber_ID"]),
                           Link_RegDiaryNumber_Name = Convert.ToString(dr["Link_RegDiaryNumber_Name"]),
                           Link_RegDiaryNumber_NameYear = Convert.ToString(dr["Link_RegDiaryNumber_NameYear"]),
                           Column_A = Convert.ToString(dr["Column_A"]),
                           Column_B = Convert.ToString(dr["Column_B"]),
                           //END

                           RemarksIfAny = Convert.ToString(dr["RemarksIfAny"]),
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
                           //CoPromoter Registration Parms

                           //CoPromoter DiaryNumber Parms - START
                           //Related ID 
                           nLinkTo_Related_Promoter_ID = Convert.ToInt64(dr["nLinkTo_Related_Promoter_ID"]),
                           nLinkTo_Related_Project_ID = Convert.ToInt64(dr["nLinkTo_Related_Project_ID"]),
                           nLinkTo_Related_RegistrationNumber = Convert.ToString(dr["nLinkTo_Related_RegistrationNumber"]),
                           nExtra1 = Convert.ToString(dr["nExtra1"]),
                           nExtra2 = Convert.ToString(dr["nExtra2"]),

                           //Another Primary Promoter ID
                           nLinkTo_RegDiaryNumber_Promoter_ID = Convert.ToInt64(dr["nLinkTo_RegDiaryNumber_Promoter_ID"]),
                           nLinkTo_RegDiaryNumber_ID = Convert.ToInt64(dr["nLinkTo_RegDiaryNumber_ID"]),
                           nLinkTo_RegDiaryNumber_Name = Convert.ToString(dr["nLinkTo_RegDiaryNumber_Name"]),
                           nLinkTo_RegDiaryNumber_NameYear = Convert.ToString(dr["nLinkTo_RegDiaryNumber_NameYear"]),
                           //CoPromoter DiaryNumber Parms

                           //Other Flag
                           IsBriefSummaryDraft = Convert.ToInt32(dr["IsBriefSummaryDraft"]),
                           IsBriefSummaryLock = Convert.ToInt32(dr["IsBriefSummaryLock"]),
                           IsDraftCoPromoters = Convert.ToInt32(dr["IsDraftCoPromoters"]),

                           JointPromoter_Name = Convert.ToString(dr["JointPromoter_Name"]),
                           JointPromoter_District = Convert.ToString(dr["JointPromoter_District"]),
                           JointPromoter_Type = Convert.ToString(dr["JointPromoter_Type"]),
                       });
            }
            return ProfileDetailList;
        }

        public List<ClsPrp_JointPromoter_Print_TrackLitigations> Display_JointPromoter_TrackRecordLitigations_ByID_ForPrint(Int64 Promoter_ID, Int32 Promoter_Type, Int64 JointPromoter_ID, Int32 JointPromoter_Type, string UserID_Name, string UserID_Role)
        {
            List<ClsPrp_JointPromoter_Print_TrackLitigations> JPromoterLitigations = new List<ClsPrp_JointPromoter_Print_TrackLitigations>();

            connection();
            MySqlCommand cmd = new MySqlCommand("Display_Rera_JointPromoter_Print_TrackLitigationsByID_ForPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_Promoter_ID", Promoter_ID);
            cmd.Parameters.AddWithValue("p_Promoter_Type", Promoter_Type);
            cmd.Parameters.AddWithValue("p_JointPromoter_ID", JointPromoter_ID);
            cmd.Parameters.AddWithValue("p_JointPromoter_Type", JointPromoter_Type);
            cmd.Parameters.AddWithValue("p_UserName", UserID_Name);
            cmd.Parameters.AddWithValue("p_UserRole", UserID_Role);

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                JPromoterLitigations.Add(
                   new ClsPrp_JointPromoter_Print_TrackLitigations
                   {
                       JointPromoter_Litigations_IndexID = Convert.ToInt64(dr["JointPromoter_Litigations_IndexID"]),
                       JointPromoter_Litigation_ID = Convert.ToInt64(dr["JointPromoter_Litigation_ID"]),

                       Related_Promoter_ID = Convert.ToInt64(dr["Related_Promoter_ID"]),
                       Related_PromoterType = Convert.ToInt32(dr["Related_PromoterType"]),

                       Related_JointPromoter_ID = Convert.ToInt64(dr["Related_JointPromoter_ID"]),
                       Related_JointPromoterType = Convert.ToInt32(dr["Related_JointPromoterType"]),
                       LitigationsRelated_JointPromoterName = Convert.ToString(dr["LitigationsRelated_JointPromoterName"]),

                       LitigationsRelated_ProjectName = Convert.ToString(dr["LitigationsRelated_ProjectName"]),
                       Project_Name = Convert.ToString(dr["Project_Name"]),
                       Project_Type = Convert.ToString(dr["Project_Type"]),
                       Project_Status = Convert.ToString(dr["Project_Status"]),
                       Project_AreaConstructed = Convert.ToDouble(dr["Project_AreaConstructed"]),

                       Case_Title = Convert.ToString(dr["Case_Title"]),
                       Case_Number = Convert.ToString(dr["Case_Number"]),
                       Authority_ForumName_CasePendingResolved = Convert.ToString(dr["Authority_ForumName_CasePendingResolved"]),

                       JointPromoter_LitigationsFlag = Convert.ToInt32(dr["JointPromoter_LitigationsFlag"]),
                       JointPromoter_LitigationsCondition = Convert.ToInt32(dr["JointPromoter_LitigationsCondition"]),

                       IsActive = Convert.ToInt32(dr["IsActive"]),
                       IsDraft = Convert.ToInt32(dr["IsDraft"]),
                       IsLock = Convert.ToInt32(dr["IsLock"]),
                       IsPublicView = Convert.ToInt32(dr["IsPublicView"]),
                       Flag = Convert.ToInt32(dr["Flag"]),
                       Created_By = Convert.ToString(dr["Created_By"]),
                       Created_On = Convert.ToDateTime(dr["Created_On"]),
                       Modify_By = Convert.ToString(dr["Modify_By"]),
                       Modified_On = Convert.ToDateTime(dr["Modified_On"]),

                       Extra1 = Convert.ToString(dr["Extra1"]),
                       Extra2 = Convert.ToString(dr["Extra2"]),
                       Extra3 = Convert.ToString(dr["Extra3"]),
                       Extra4 = Convert.ToString(dr["Extra4"]),
                   });
            }
            return JPromoterLitigations;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterPrint
{
    public class Clsprp_JointPromoter_Print_ProfileForm
    {

        [Display(Name = "Project Name")]
        public long ProjectCoPromotersRelated_ProjectID { get; set; }

        // Link and Mapping Parms - START
        public long mCoPromoter_Links_IndexID { get; set; }

        [Display(Name = "Joint-Promoter Name")]
        public long mCoPromoter_ApplicationID { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public int mCoPromoterType_Flag { get; set; }
        [Display(Name = "Joint-Promoter Diary Number")]
        public string mCoPromoter_RegDiaryNumber_Name { get; set; }
        public long mCoPromoter_Reference_ID { get; set; }


        [Display(Name = "RERA Registration Number")]
        public string mLinkTo_Project_RegistrationNumber { get; set; }

        [Display(Name = "Promoter Name")]
        public long mLinkTo_Promoter_ID { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string mLinkTo_Promoter_RegDiaryNumber_Name { get; set; }
        public long mLinkTo_Promoter_Reference_ID { get; set; }

        [Display(Name = "Project Name")]
        public long mLinkTo_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string mLinkTo_Project_RegDiaryNumber_Name { get; set; }
        public long mLinkTo_Project_Reference_ID { get; set; }

        public string mExtra1 { get; set; }
        public string mExtra2 { get; set; }
        public string mExtra3 { get; set; }
        [Display(Name = "Remarks, If Any")]
        public string mRemarks_IfAny { get; set; }

        public int mIsActive { get; set; }
        public int mIsDraft { get; set; }
        public int mIsLock { get; set; }
        [Display(Name = "Is Public View (Yes/No)?")]
        public int mIsPublicView { get; set; }
        public int mIsDraftEvaluation { get; set; }

        public string mCreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? mCreatedOn { get; set; }
        public string mModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? mModifyOn { get; set; }
        // Link and Mapping Parms


        // CoPromoter Registration Parms - START
        public long CoPromoter_IndexID { get; set; }

        [Display(Name = "Joint-Promoter Name")]
        public long CoPromoter_ApplicationID { get; set; }

        [Display(Name = "Type of Joint-Promoter")]
        public int CoPromoterType_Flag { get; set; }

        //OTI Case
        public string Org_Title { get; set; }
        [Display(Name = "Name of Organization")]
        public string Org_Name { get; set; }
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Main Objects of Organization")]
        public string OTI_Org_Objects { get; set; }

        //IND Case
        [Display(Name = "Joint-Promoter's Name")]
        public string First_Name { get; set; }
        [Display(Name = "Middle Name")]
        public string Middle_Name { get; set; }
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Gender")]
        public string Individual_Gender { get; set; }

        [Display(Name = "Father's Name")]
        public string Fath_First_Name { get; set; }
        [Display(Name = "Father's Middle Name")]
        public string Fath_Middle_Name { get; set; }
        [Display(Name = "Father's Last Name")]
        public string Fath_Last_Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Main Objects of Joint-Promoter")]
        public string Ind_Org_Objects { get; set; }

        //Registered Address
        [Display(Name = "Address Line 1")]
        public string Registered_Address_Org_Line1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Registered_Address_Org_Line2 { get; set; }
        [Display(Name = "State")]
        public int Registered_Address_Org_State { get; set; }
        [Display(Name = "District")]
        public int Registered_Address_Org_District { get; set; }
        [Display(Name = "Pin Code")]
        public string Registered_Address_Org_Pin_Code { get; set; }
        [Display(Name = "District & State")]
        public string Registered_Address_Org_DistrictState_Name { get; set; }

        //Permanent Address
        [Display(Name = "Address Line 1")]
        public string Permanent_Address_Prm_Line1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Permanent_Address_Prm_Line2 { get; set; }
        [Display(Name = "State")]
        public int Permanent_Address_Prm_State { get; set; }
        [Display(Name = "District")]
        public int Permanent_Address_Prm_District { get; set; }
        [Display(Name = "Pin Code")]
        public string Permanent_Address_Prm_Pin_Code { get; set; }
        [Display(Name = "District & State")]
        public string Permanent_Address_Prm_DistrictState_Name { get; set; }

        //Communication Address
        [Display(Name = "Address Line 1")]
        public string Communication_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Communication_AddressLine2 { get; set; }
        [Display(Name = "District & State")]
        public int Communication_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public int Communication_AddressDistrictCode { get; set; }
        [Display(Name = "Pin Code")]
        public string Communication_AddressPIN { get; set; }
        [Display(Name = "District & State")]
        public string Communication_Address_DistrictState_Name { get; set; }

        //Authorized Person details
        [Display(Name = "Name of Authorised Signatory")]
        public string AuthorizedPerson_Name { get; set; }

        [Display(Name = "Mobile No. of Authorised Signatory")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        [Display(Name = "STD Code")]
        public long AuthorizedPerson_LandlineNumber_STD { get; set; }

        [Display(Name = "Landline Number of Authorised Signatory")]
        public long AuthorizedPerson_LandlineNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Email of Authorised Signatory")]
        public string AuthorizedPerson_EmailAddress { get; set; }

        //Authorized Person Address
        [Display(Name = "Is Authorized Person Address (yes/no)?")]
        public int IsAuthorizedPersonAddress { get; set; }
        [Display(Name = "Address Line 1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public int AuthorizedPerson_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public int AuthorizedPerson_AddressDistrictCode { get; set; }
        [Display(Name = "Pin Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }
        [Display(Name = "District & State")]
        public string AuthorizedPerson_AddressDistrictState_Name { get; set; }

        //Other Parms
        [Display(Name = "Joint-Promoter Occupation")]
        public string CoPromoter_Occupation { get; set; }
        [Display(Name = "Joint-Promoter's WebLink")]
        public string CoPromoter_WebLink { get; set; }
        [Display(Name = "Joint-Promoter's PAN Number")]
        public string CoPromoter_PAN_Number { get; set; }
        [Display(Name = "Joint-Promoter's Aadhaar Number")]
        public long CoPromoter_Aadhaar_Number { get; set; }


        [Display(Name = "Experience of Joint-Promoter (Yes/No)?")]
        public string IsExperience { get; set; }
        [Display(Name = "Years of Experience of Joint-Promoter in Real Estate Development (in Years)")]
        public int Past_Experience_InYear { get; set; }
        [Display(Name = "Litigation related to Project of Joint-Promoter (Yes/No)?")]
        public string IsLitigation_RelatedProject { get; set; }
        [Display(Name = "Number of Litigation related to Project of Joint-Promoter")]
        public int Past_Litigations_InNumber { get; set; }
        [Display(Name = "Organization Members of Promoter (Yes/No)?")]
        public string IsOrganizationMembers { get; set; }
        [Display(Name = "Parent Entity of Promoter (Yes/No)?")]
        public string IsOrganizationParent_Entity { get; set; }

        [Display(Name = "Is upload photograph (yes/no)?")]
        public int IsUploadPhotograph { get; set; }
        [Display(Name = "Upload Photograph")]
        public string CoPromoterImage_FilePath { get; set; }
        [Display(Name = "Photograph")]
        public string CoPromoterImage_FileName { get; set; }

        //Related Reference ID
        //Dropdown value - Related_ProjectID - START
        public long Related_Project_ID { get; set; }
        public string Related_Used_ID { get; set; }
        public long Related_Promoter_Application_ID { get; set; }

        //Another Primary Promoter ID
        public long Link_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Reference Diary Number, If Any")]
        public string Link_RegDiaryNumber_Name { get; set; }
        public string Link_RegDiaryNumber_NameYear { get; set; }
        [Display(Name = "IND Image Yes/No")]
        public string Column_A { get; set; }
        [Display(Name = "Promoter ID (Primary Promoter-ApplicationID)")]
        public string Column_B { get; set; }
        //END

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        public string Column_C { get; set; }
        public string Column_D { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string Created_By { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_On { get; set; }
        public string Modify_By { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Modified_On { get; set; }
        // CoPromoter Registration Parms


        // CoPromoter DiaryNumber Parms - START
        public long nCoPromoter_RegDiaryNumber_IndexID { get; set; }
        public long nCoPromoter_RegDiaryNumber_ID { get; set; }

        [Display(Name = "Joint-Promoter Diary Number")]
        public string nCoPromoter_RegDiaryNumber_Name { get; set; }
        public string nCoPromoter_RegDiaryNumber_NameYear { get; set; }

        //Joint-Promoter ID
        public long nRelated_CoPromoter_ApplicationID { get; set; }
        public int nRelated_CoPromoterType_Flag { get; set; }
        public string nUserID { get; set; }

        //Related ID 
        public long nLinkTo_Related_Promoter_ID { get; set; }
        public long nLinkTo_Related_Project_ID { get; set; }
        public string nLinkTo_Related_RegistrationNumber { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string nExtra1 { get; set; }
        [Display(Name = "Project Diary Number")]
        public string nExtra2 { get; set; }

        //Another Primary Promoter ID
        public long nLinkTo_RegDiaryNumber_Promoter_ID { get; set; }
        public long nLinkTo_RegDiaryNumber_ID { get; set; }
        public string nLinkTo_RegDiaryNumber_Name { get; set; }
        public string nLinkTo_RegDiaryNumber_NameYear { get; set; }

        //extra
        public int nOrgMemberCount { get; set; }
        public int nParentEntityCount { get; set; }
        public int nLitigationsCount { get; set; }
        public int nDocumentsCount { get; set; }
        public int nPaymentDetailsCount { get; set; }
        public int nTrackRecordDetailsCount { get; set; }

        public string nExtra3 { get; set; }
        public string nRemarks_IfAny { get; set; }

        public int nIsActive { get; set; }
        public int nIsDraft { get; set; }
        public int nIsLock { get; set; }
        public int nIsDraftHelpDesk { get; set; }
        public int nIsDraftEvaluation { get; set; }
        public int nIsDraftSecMember { get; set; }
        public int nIsDraftMember { get; set; }

        public string nCreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? nCreatedOn { get; set; }
        public string nModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? nModifyOn { get; set; }
        // CoPromoter DiaryNumber Parms

        // Other Flag
        public int IsBriefSummaryDraft { get; set; }
        public int IsBriefSummaryLock { get; set; }
        public int IsDraftCoPromoters { get; set; }

        [Display(Name = "Name of Joint-Promoter")]
        public string JointPromoter_Name { get; set; }
        [Display(Name = "District of Joint-Promoter")]
        public string JointPromoter_District { get; set; }
        [Display(Name = "Type of Joint-Promoter")]
        public string JointPromoter_Type { get; set; }




        // Application ID
        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_JointPromoter_ID { get; set; }

        // Application Date
        [Display(Name = "Promoter Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Promoter_ApplicationDate { get; set; }
        [Display(Name = "Joint-Promoter Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JointPromoter_ApplicationDate { get; set; }

        // Promoter Name/Diary Number
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }

        // Joint-Promoter Name/Diary Number
        [Display(Name = "Joint-Promoter Diary Number")]
        public string zipJointPromoter_DiaryNumber { get; set; }
        [Display(Name = "Joint-Promoter Name")]
        public string zipJointPromoterName { get; set; }

        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipJointPromoterLastModifiedOn { get; set; }




        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }

        public List<ClsPrp_JointPromoter_Print_TrackLitigations> prpLitigations { get; set; }

        public List<Clsprp_JointPromoter_Print_ProfileForm> prpongoingTR { get; set; }
        public Clsprp_JointPromoter_Print_ProfileForm()
        {
            prpongoingTR = new List<Clsprp_JointPromoter_Print_ProfileForm>();
        }
    }
}
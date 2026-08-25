using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCprojectName
    {
        public long ProjectPUC_ProjectName_IndexID { get; set; }
        public long ProjectPUC_ProjectName_ID { get; set; }

        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        public long RelatedApplicationPUC_ID { get; set; }

        public string User_ID { get; set; }

        [Required]
        [Display(Name = "PUC Diary Number")]
        public string PUC_DiaryNumber { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        public string PUC_ReferencePUC_Name { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PUC_ReferencePUC_Date { get; set; }

        [Display(Name = "Change Request For")]
        public string PUC_RequestCategoryName { get; set; }

        [Display(Name = "Change Request For")]
        public long PUC_RequestCategoryID { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsExtensionRegistration { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? RERAnumberExtensionRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string ProjectDiaryNumber { get; set; }

        [Display(Name = "Extension of Registration Diary Number")]
        public string ExtensionRegdDiaryNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string PromoterName { get; set; }

        [Required]
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }
        
        [Display(Name = "Project Address District")]
        public string DName { get; set; }

        [Required]
        [Display(Name = "Type of Project")]
        public string ProjectType { get; set; }


        //Properties : Project and Promoter Name
        public long ProjectRegistrationAdditional_IndexID { get; set; }
        public long ProjectRegistrationAdditional_ID { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_FormDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ToDate { get; set; }
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ApprovedDate { get; set; }

        [Display(Name = "Is Annexure?")]
        public int IsConditionAnnexure { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }
        public int IsApproved { get; set; }
        public int IsMemberApproved { get; set; }

        //Properties : Reference Doc of Project and Promoter Name
        [Required]
        [Display(Name = "Reference Document Title")]               
        public string PUC_Doc_ReferenceTitle { get; set; }

        [Required]
        [Display(Name = "Reference Document Number")]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z ()&.,-/]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string PUC_Doc_ReferenceNumber { get; set; }

        [Required]
        [Display(Name = "Reference Details, If Any")]
        [StringLength(200, MinimumLength = 4)]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[0-9a-zA-Z ()&.,-/]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string PUC_ReferenceDetailsIfAny { get; set; }

        //Properties [Start] :Project and Promoter Name
        //Project
        public long ProjectRegistration_IndexID { get; set; }
        public long ProjectRegistration_ID { get; set; }
        public long PromoterRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Name of Project/Promoter Only")]
        public int IsOnlyProjectPromoterName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Project_Name { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Amenities")]
        [StringLength(500, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string Project_Amenities { get; set; }
        
        [Required]
        [Display(Name = "Project Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string ProjectWebsite_WebLink { get; set; }

        //Promoter
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Promoter_Name { get; set; }


        [Required]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string First_Name { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(60, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Middle_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Last_Name { get; set; }


        [Required]
        [Display(Name = "Father First Name")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_First_Name { get; set; }
        [Display(Name = "Father Middle Name")]
        [StringLength(60, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_Middle_Name { get; set; }
        [Required]
        [Display(Name = "Father Last Name")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Fath_Last_Name { get; set; }

        [Display(Name = "Occupation")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Occupation { get; set; }

        [Required]
        [Display(Name = "Is Individual or Other Than Individual?")]
        public int IsPromoterOTI { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Organization Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Org_Name { get; set; }

        [Required]
        [Display(Name = "Type of Organization")]
        public string Org_Type { get; set; }
                
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Main Objects of Organization")]
        [StringLength(400, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,400}$", ErrorMessage = "Special characters are not allowed. Maximum length is 400")]
        public string Org_Objects { get; set; }

        [Required]
        [Display(Name = "Promoter Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string WebLink_Promoter_website { get; set; }

        //Active
        public string A_ExtraClmn { get; set; }
        public string B_ExtraClmn { get; set; }
        public string C_ExtraClmn { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }
        //Properties [End] : Project Name


        public string mFlagPUC_YesNo { get; set; }
        public string mFlagPUC_OpenClosed { get; set; }
        public string mFlagPUC_ApprovedNotApproved { get; set; }

        public string mA_column { get; set; }
        public string mB_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceRegistrationProject_Input { get; set; }

        [Required]
        [Display(Name = "PUC Diary Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceRegistrationPUC_Input { get; set; }

        [Required]
        [Display(Name = "Reference PUC Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ReferenceNumber_Input { get; set; }

        [Display(Name = "Reference PUC Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReferenceNumberDate_Input { get; set; }

        [Required]
        [Display(Name = "Search By")]
        public int ReferenceNumberFlag_Input { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        public long zipRelated_PUC_ID { get; set; }
        public long zipRelated_CategoryACR_ID { get; set; }
        public string zipRelated_CategoryACR_Name { get; set; }
        [Display(Name = "Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        [Display(Name = "PUC Diary Number")]
        public string zipReference_DiaryNumber { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipProjectRegistrationNumberName { get; set; }


        public List<ClsPrp_ControlPanel_View_ProjectPUCprojectName> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCprojectName()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCprojectName>();
        }
       
        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_StateMaster> prpstateMaster { get; set; }
        public List<ClsPrp_SubdivMaster> prpsubdivMaster { get; set; }
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpchangerequestcategoryMaster { get; set; }

    }
}
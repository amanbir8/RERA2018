using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_ProjectPUCProjectLandDetails
    {
        public long ProjectPUC_ProjectLand_IndexID { get; set; }
        public long ProjectPUC_ProjectLand_ID { get; set; }

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


        //Properties : Project Land Details
        public long ProjectLandAdditional_IndexID { get; set; }
        public long ProjectLandAdditional_ID { get; set; }

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

        //Properties : Reference Doc of Project Land Details
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

        //Properties [Start] : Project Land Details
        public long ProjectLand_IndexID { get; set; }
        public long ProjectLand_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectLandRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Total Area of Land Proposed to be developed (in sqr mtrs)")]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0.0001, 999999999999.9999)]
        public double ProposedLand_TobeDeveloped_Area_Total { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under group housing development excluding common areas and ameneties")]
        public double ProposedLand_Area_ResidentialGroupHousing { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under residential plotted development excluding common areas and ameneties")]
        public double ProposedLand_Area_ResidentialPlotted { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under commercial development excluding common areas and ameneties")]
        public double ProposedLand_Area_Commercial { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under industrial development excluding common areas and ameneties")]
        public double ProposedLand_Area_Industrial { get; set; }

        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under common amenties servicing the entire project")]
        public double ProposedLand_Area_A_column { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under institution, club, school and reserved area development excluding common areas and ameneties")]
        public double ProposedLand_Area_B_column { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area under EWS development excluding common areas and ameneties")]
        public double ProposedLand_Area_C_column { get; set; }

        public double ProposedLand_Area_D_column { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name of Villages")]
        [StringLength(500, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string Name_of_Villages { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area of Land Owned by Promoter")]
        public double ProposedLand_TobeDeveloped_TotalOpenArea { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0, 999999999999.9999)]
        [Display(Name = "Area of Land Not Owned by Promoter")]
        public double ProposedLand_TobeDeveloped_TotalCoveredArea { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Longitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Longitude of Start point of proposed project land")]
        public double ProposedProjectLand_StartPoint_Longitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Latitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Latitude of Start point of proposed project land")]
        public double ProposedProjectLand_StartPoint_Latitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Longitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Longitude of End point of proposed project land")]
        public double ProposedProjectLand_EndPoint_Longitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Latitude; Maximum Six Decimal Points.")]
        [Range(0, 999999.999999)]
        [Display(Name = "Latitude of End point of proposed project land")]
        public double ProposedProjectLand_EndPoint_Latitude { get; set; }

        [Required]
        [Display(Name = "Project Land Status")]
        public string IsProjectLand_Status_OwnedByPromoter { get; set; }
        
        [Required]
        [Display(Name = "Project Land Status - Not Owned By Promoter")]
        public string IsProjectLand_Status_NotOwnedByPromoter { get; set; }

        [Required]
        [Display(Name = "Is there Any Project Land Encumbrances?")]
        public string IsLandEncumbrances_IfAny { get; set; }

        [Display(Name = "Remarks if any?")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
        //Properties [End] : Project Land Details


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
        

        public List<ClsPrp_ControlPanel_View_ProjectPUCProjectLandDetails> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_ProjectPUCProjectLandDetails()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_ProjectPUCProjectLandDetails>();
        }

        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpchangerequestcategoryMaster { get; set; }

    }
}
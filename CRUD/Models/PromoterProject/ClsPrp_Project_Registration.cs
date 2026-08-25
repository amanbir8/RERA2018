using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using CRUD.Models.Master;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_Project_Registration
    {

        //[Required(ErrorMessage = "")]
        [Display(Name = "Project Registration Index ID")]
        public long ProjectRegistration_IndexID { get; set; }

        [Display(Name = "Project Registration ID")]
        public long ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z ()&.,-/]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Project_Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Amenities")]
        [StringLength(500, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string Project_Amenities { get; set; }

        [Required(ErrorMessage = "The Select Option (Existing Punjab RERA Project/ New Project) field is required.")]
        [Display(Name = "Is Already RERA Number")]        
        public string IsAlready_RERANumber { get; set; }

        [Display(Name = "Existing Punjab RERA Number")]
        [StringLength(25, MinimumLength = 15, ErrorMessage = "Maximum length is 25")]
        public string Existing_RERANumber { get; set; }

        [Required(ErrorMessage = "The Structure field is required.")]
        [Display(Name = "1. Structure")]        
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_Structure { get; set; }

        [Required(ErrorMessage = "The Flooring field is required.")]
        [Display(Name = "2. Flooring")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_Flooring { get; set; }

        [Required(ErrorMessage = "The Wall Finishing field is required.")]
        [Display(Name = "3. Wall Finishing")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_WallFinishing { get; set; }

        [Required(ErrorMessage = "The Sanitary Fittings field is required.")]
        [Display(Name = "4. Sanitary Fittings")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_SanitaryFittings { get; set; }

        [Required(ErrorMessage = "The Electrical Fittings field is required.")]
        [Display(Name = "5. Electrical Fittings")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_ElectricalFittings { get; set; }

        [Required(ErrorMessage = "The Kitchen field is required.")]
        [Display(Name = "6. Kitchen")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_Kitchen { get; set; }

        [Required(ErrorMessage = "The Others Specification Details of Proposed Project (If Any) field is required.")]
        [Display(Name = "7. Others If Any")]
        public string IsProposedProjectDetail_OthersIfAny { get; set; }

        [Display(Name = "Others: Name")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string ProposedProjectDetail_OthersIfAnyName { get; set; }

        [Display(Name = "Others: Details")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        public string ProposedProjectDetail_OthersIfAny { get; set; }

        [Required]
        [Display(Name = "Project Status")]
        public string Project_Status { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Project Start Date")]
        public DateTime? ProjectStart_Date { get; set; }        

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Proposed/ Expected Date of Project Completion as specified in Form B")]
        public DateTime? ProjectCompletion_ProposedDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Original Date of Project Completion")]
        public DateTime? ProjectCompletion_OriginalDate { get; set; }

        [Required]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [Display(Name = "Duration for which Project Registration will be Provided")]
        public string ProjectRegistrationProvided_Duration { get; set; }

        [Display(Name = "Reason for Delay in Project if Any?")]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string ProjectDelayReason_IfAny { get; set; }

        [Required]
        [Display(Name = "Project Address Line1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]        
        public string Project_AddressLine1 { get; set; }

        [Display(Name = "Project Address Line2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Project_AddressLine2 { get; set; }

        [Required(ErrorMessage = "The Project Address State field is required.")]
        [Display(Name = "Project Address State Code")]
        public int Project_AddressStateCode { get; set; }

        [Required(ErrorMessage = "The Project Address District field is required.")]
        [Display(Name = "Project Address District Code")]
        public int Project_AddressDistrictCode { get; set; }

        [Required(ErrorMessage = "The Project Address Sub-Division field is required.")]
        [Display(Name = "Project AddressSub Division Code")]
        public int Project_AddressSubDivisionCode { get; set; }

        [Required]
        [Display(Name = "Project Address PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string Project_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Project Potential Zone")]
        public int Project_PotentialZoneCode { get; set; }

        //[Required]
        [Display(Name = "Project Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string ProjectWebsite_WebLink { get; set; }

        [Required(ErrorMessage = "The Contact Person's First Name field is required.")]
        [Display(Name = "Contact Person's First Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorizedPerson_FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorizedPerson_MiddleName { get; set; }

        [Required(ErrorMessage = "The Contact Person's Last Name field is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string AuthorizedPerson_LastName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedPerson_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedPerson_AddressLine2 { get; set; }

        [Required(ErrorMessage = "The Contact Person's Address State field is required.")]
        [Display(Name = "Select Address State")]
        public int AuthorizedPerson_AddressStateCode { get; set; }

        [Required(ErrorMessage = "The Contact Person's Address District field is required.")]
        [Display(Name = "Select Address District")]
        public int AuthorizedPerson_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Contact Person's Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AuthorizedPerson_EmailAddress { get; set; }

        [Required]
        [Display(Name = "Contact Person's Mobile Phone")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        [Required(ErrorMessage = "The proforma for Agreement of Sale (Yes/No) field is required.")]
        [Display(Name = "Is ProForma AOS RERA format AnnexureA")]
        public string IsProForma_AOS_RERAformat_AnnexureA { get; set; }

        [Display(Name = "Is ProForma AOS RERA format No IsApproved")]
        public string IsProForma_AOS_RERAformat_No_IsApproved { get; set; }

        [Required(ErrorMessage = "The Project falls under Mega Project category (Yes/No) field is required.")]
        [Display(Name = "Is Project Mega Project Category")]
        public string IsProject_MegaProjectCategory { get; set; }

        [Required(ErrorMessage = "The Any litigation(s) related to the Project (Yes/No) field is required.")]
        [Display(Name = "Is Litigation Related Project")]
        public string IsLitigation_RelatedProject { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        [Required]
        [Display(Name = "Project Cost (in rupees)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Amount; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99)]
        public decimal A_column { get; set; }

        public string B_column { get; set; }
        public string C_column { get; set; }

        [Display(Name = "IsActive")]
        public int IsActive { get; set; }
        [Display(Name = "IsDraft")]
        public int IsDraft { get; set; }
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [Display(Name = "CreatedOn")]
        public System.DateTime CreatedOn { get; set; }
        [Display(Name = "")]
        public string ModifyBy { get; set; }
        [Display(Name = "ModifyOn")]
        public System.DateTime ModifyOn { get; set; }

        [Required(ErrorMessage = "The any regularization certificate issued related to the project (Yes/No) field is required.")]
        [Display(Name = "Is Regularization Certificate Issued?")]
        public string IsYes_RegularizationCertificate { get; set; }

        [Display(Name = "Is Others (If Any)?")]
        public string IsYes_columnExtra { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Regularization certificate /document details which relates to the project")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [RegularExpression(@"^[0-9a-zA-Z''-'-.()\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string RegularizationCertificateInformation { get; set; }



        public List<ClsPrp_ProjectType_Registration> ProjectType_Registration { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_SubdivMaster> SubdivMaster { get; set; }

        public List<ClsPrp_Project_Registration> promoter { get; set; }

        public List<ClsPrp_Project_Registration> prpongoing { get; set; }
        public ClsPrp_Project_Registration()
        {
            prpongoing = new List<ClsPrp_Project_Registration>();
        }



        [Display(Name = "Commercial")]
        public string Commercial { get; set; }
        [Display(Name = "Residential")]
        public string Residential { get; set; }
        [Display(Name = "Industrial")]
        public string Industrial { get; set; }

        [Display(Name = "Building/Tower Development")]
        public bool CommercialBuildingTower { get; set; }
        [Display(Name = "Plotted Development")]
        public bool CommercialPlottedDevelopment { get; set; }
        [Display(Name = "Building/Tower Development")]
        public bool ResidentialBuildingTower { get; set; }
        [Display(Name = "Plotted Development")]
        public bool ResidentialPlottedDevelopment { get; set; }
        [Display(Name = "Building/Tower Development")]
        public bool IndustrialBuildingTower { get; set; }
        [Display(Name = "Plotted Development")]
        public bool IndustrialPlottedDevelopment { get; set; }

        public string ProjectType_Code { get; set; }
        public string ProjectType_SubType_Code { get; set; }

        public List<ClsPrp_StateMaster> stateMaster { get; internal set; }

        //public long ProjectRegistration_IndexID { get; set; }
        //public long ProjectRegistration_ID { get; set; }

        //[Required]
        //[Display(Name = "Project Name")]
        //public string Project_Name { get; set; }

        //[Required]
        //[Display(Name = "Project Amenities")]
        //public string Project_Amenities { get; set; }
        //[Required]
        //[Display(Name = "Is Already RERA Number")]
        //public string IsAlready_RERANumber { get; set; }

        //[Required]
        //[Display(Name = "Existing RERA Number")]
        //public string Existing_RERANumber { get; set; }

        //[Required]
        //[Display(Name = "Proposed Project Details such as Structure ")]
        //public string ProposedProjectDetail_Structure { get; set; }
        //[Required]
        //[Display(Name = "Flooring ")]
        //public string ProposedProjectDetail_Flooring { get; set; }
        //[Required]
        //[Display(Name = "Wall Finishing ")]
        //public string ProposedProjectDetail_WallFinishing { get; set; }
        //[Required]
        //[Display(Name = "Sanitary Fittings")]
        //public string ProposedProjectDetail_SanitaryFittings { get; set; }
        //[Required]
        //[Display(Name = "Electrical Finishing ")]
        //public string ProposedProjectDetail_ElectricalFittings { get; set; }
        //[Required]
        //[Display(Name = "Kitchen")]
        //public string ProposedProjectDetail_Kitchen { get; set; }
        //[Required]
        //[Display(Name = "Is any other Proposed Project Detail")]
        //public string IsProposedProjectDetail_OthersIfAny { get; set; }

        //[Display(Name = "Other Detail (Name)")]
        //public string ProposedProjectDetail_OthersIfAnyName { get; set; }
        //[Display(Name = "Other Detail")]
        //public string ProposedProjectDetail_OthersIfAny { get; set; }

        //[Required]
        //[Display(Name = "Project Status")]
        //public string Project_Status { get; set; }

        //[Required]
        //[Display(Name = "Project Start Date")]
        //public System.DateTime ProjectStart_Date { get; set; }

        //[Required]
        //[Display(Name = "Proposed Date of Project Completion")]
        //public System.DateTime ProjectCompletion_ProposedDate { get; set; }
        //[Required]
        //[Display(Name = "Original Date of Project Completion")]
        //public System.DateTime ProjectCompletion_OriginalDate { get; set; }
        //[Required]
        //[Display(Name = "Duration for which Project Registration will be Provided ")]
        //public string ProjectRegistrationProvided_Duration { get; set; }

        //[Display(Name = "Reason for Delay in Project if Any ? ")]
        //public string ProjectDelayReason_IfAny { get; set; }
        //[Required]
        //[Display(Name = "Project Address")]

        //public string Project_AddressLine1 { get; set; }
        //[Display(Name = " Address Line2")]
        //public string Project_AddressLine2 { get; set; }
        //[Required]
        //[Display(Name = "State")]
        //public int Project_AddressStateCode { get; set; }
        //[Required]
        //[Display(Name = "District")]
        //public int Project_AddressDistrictCode { get; set; }
        //[Required]
        //[Display(Name = "Sub-Division")]
        //public int Project_AddressSubDivisionCode { get; set; }
        //[Required]
        //[Display(Name = "Pin Code")]
        //public string Project_AddressPIN { get; set; }
        //[Required]
        //[Display(Name = "Project Potential Zone")]

        //public int Project_PotentialZoneCode { get; set; }
        //[Required]
        //[Display(Name = "Web Link to Project Website")]
        //public string ProjectWebsite_WebLink { get; set; }
        //[Required]
        //[Display(Name = "Authorized Person First Name")]
        //public string AuthorizedPerson_FirstName { get; set; }

        //[Display(Name = "Authorized Person Middle Name")]
        //public string AuthorizedPerson_MiddleName { get; set; }

        //[Display(Name = "Authorized Person Last Name")]
        //public string AuthorizedPerson_LastName { get; set; }
        //[Required]
        //[Display(Name = "Authorized Person Address")]
        //public string AuthorizedPerson_AddressLine1 { get; set; }

        //[Display(Name = "Address Line2")]
        //public string AuthorizedPerson_AddressLine2 { get; set; }
        //[Required]
        //[Display(Name = "State")]
        //public int AuthorizedPerson_AddressStateCode { get; set; }

        //[Required]
        //[Display(Name = "District")]
        //public int AuthorizedPerson_AddressDistrictCode { get; set; }
        //[Required]
        //[Display(Name = "Pin Code")]
        //public string AuthorizedPerson_AddressPIN { get; set; }
        //[Required]
        //[Display(Name = "Authorized Person Email")]
        //public string AuthorizedPerson_EmailAddress { get; set; }
        //[Required]
        //[Display(Name = "Authorized Person Mobile No.")]
        //public long AuthorizedPerson_MobileNumber { get; set; }
        //[Required]
        //[Display(Name = "Is ProForma Agreement of Sale as per RERA Act, 2016 Annexure “A”?")]

        //public string IsProForma_AOS_RERAformat_AnnexureA { get; set; }
        //[Required]
        //[Display(Name = "Is ProForma Agreement of Sale IsApproved?")]
        //public string IsProForma_AOS_RERAformat_No_IsApproved { get; set; }
        //[Required]
        //[Display(Name = "Is Project Mega Project Category?")]
        //public string IsProject_MegaProjectCategory { get; set; }

        //[Required]
        //[Display(Name = "Any Litigation Related to Project?")]

        //public string IsLitigation_RelatedProject { get; set; }
        //[Required]
        //[Display(Name = "Remarks if any?")]

        //public string Remarks_IfAny { get; set; }
        //public string A_column { get; set; }
        //public string B_column { get; set; }
        //public string C_column { get; set; }
        //public int IsActive { get; set; }
        //public int IsDraft { get; set; }
        //public string CreatedBy { get; set; }
        //public System.DateTime CreatedOn { get; set; }
        //public string ModifyBy { get; set; }
        //public System.DateTime ModifyOn { get; set; }

        //public List<ClsPrp_ProjectType_Registration> ProjectType_Registration { get; set; }
        //public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        //public List<ClsPrp_Project_Registration> promoter { get; set; }

        //public List<ClsPrp_Project_Registration> prpongoing { get; set; }
        //public ClsPrp_Project_Registration()
        //{
        //    prpongoing = new List<ClsPrp_Project_Registration>();

        //}
        //[Display(Name = "Commercial")]
        //public string Commercial { get; set; }
        //[Display(Name = "Residential")]
        //public string Residential { get; set; }
        //[Display(Name = "Industrial")]
        //public string Industrial { get; set; }

        //[Display(Name = "Building/Tower Development")]
        //public bool CommercialBuildingTower { get; set; }
        //[Display(Name = "Plotted Development")]
        //public bool CommercialPlottedDevelopment { get; set; }
        //[Display(Name = "Building/Tower Development")]
        //public bool ResidentialBuildingTower { get; set; }
        //[Display(Name = "Plotted Development")]
        //public bool ResidentialPlottedDevelopment { get; set; }
        //[Display(Name = "Building/Tower Development")]
        //public bool IndustrialBuildingTower { get; set; }
        //[Display(Name = "Plotted Development")]
        //public bool IndustrialPlottedDevelopment { get; set; }

        //public string ProjectType_Code { get; set; }
        //public string ProjectType_SubType_Code { get; set; }

        //public List<ClsPrp_StateMaster> stateMaster { get; internal set; }



    }
}
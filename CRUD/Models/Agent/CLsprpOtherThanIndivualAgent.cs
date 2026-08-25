using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Agent
{
    public class CLsprpOtherThanIndivualAgent
    {
        public long Agent_ID { get; set; }
        public int Agent_Type { get; set; }

        [Required(ErrorMessage = "Already have Punjab RERA Number (Yes/No) field is required.")]
        [Display(Name = "Do you have Punjab RERA Number?")]
        public string IsAlready_RERANumber { get; set; }

        [Display(Name = "Existing Punjab RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string Existing_RERANumber { get; set; }

        [Required]
        [Display(Name = "PAN Number of Organization")]        
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string Occupation { get; set; }
        
        [Required]
        [Display(Name = "Name of Organization")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Organization_Name { get; set; }

        [Required]
        [Display(Name = "Type of Organization")]
        public Nullable<int> Organization_TypeCode { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Main Objects of Organization")]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string Organization_MainObjects { get; set; }


        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegOffice_AddressLine1 { get; set; }


        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegOffice_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public Nullable<int> RegOffice_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public Nullable<int> RegOffice_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Nullable<int> RegOffice_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BusinessPlace_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BusinessPlace_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public int BusinessPlace_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public int BusinessPlace_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public int BusinessPlace_AddressPIN { get; set; }

        [Display(Name = "Do you have different official communication than place of Business?")]
        public bool? IsSameBussinessAdd_CommAdd { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BComm_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BComm_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public Nullable<int> BComm_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public Nullable<int> BComm_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Nullable<int> BComm_AddressPIN { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(80, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_FirstName { get; set; }

        
        [Display(Name = "Middle Name")]
        [StringLength(80, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(80, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_LastName { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        [Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }

        public Nullable<long> PhoneNumber_STD { get; set; }
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number")]
        public Nullable<long> PhoneNumber_Number { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string PAN_Number { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number")]
        [Display(Name = "Aadhaar Number")]
        public long Aadhaar_Number { get; set; }
       
        [Display(Name = "Is Other Organization Members")]
        public string IsOtherOrganizationMembers { get; set; }
       
        [Display(Name = "Is Other StateUT_RERAregistration")]
        [Required(ErrorMessage = "Any other Other State/UT RERA registration Number (Yes/No) field is required.")]
        public string IsOtherStateUT_RERAregistration { get; set; }

        [Required]
        [Display(Name = "Sub Division")]
        public string B_Column { get; set; }
        public string C_Column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<CLsprpOtherThanIndivualAgent> AgentOtherThanInd { get; set; }
        public CLsprpOtherThanIndivualAgent()
        {
            AgentOtherThanInd = new List<CLsprpOtherThanIndivualAgent>();
        }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_SubdivMaster> SubdivMaster { get; set; }
    }
}
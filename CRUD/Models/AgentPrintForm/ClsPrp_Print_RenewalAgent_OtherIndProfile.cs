using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsPrp_Print_RenewalAgent_AgentOtherIndProfile
    {
        public long RenewalAgent_IndexID { get; set; }
        public long RenewalAgent_ID { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalOrderSequence { get; set; }
        public int Related_RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public DateTime? Related_RERAnumberIssueDate { get; set; }
        public DateTime? Related_RERAnumberRegUptoDate { get; set; }
        public long Related_Agent_IndexID { get; set; }

        [Required(ErrorMessage = "Already have RERA Number (Yes/No) field is required.")]
        [Display(Name = "Do you have RERA Number?")]
        public string IsAlready_RERANumber { get; set; }

        [Display(Name = "Existing RERA Number")]
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
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_FirstName { get; set; }


        [Display(Name = "Middle Name")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(80, MinimumLength = 4)]
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

        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number")]
        [Display(Name = "Aadhaar Number")]
        public long Aadhaar_Number { get; set; }

        [Display(Name = "Is Other Organization Members")]
        public string IsOtherOrganizationMembers { get; set; }

        [Display(Name = "Is Other StateUT_RERAregistration")]
        [Required(ErrorMessage = "Any other Other State/UT RERA registration Number (Yes/No) field is required.")]
        public string IsOtherStateUT_RERAregistration { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public string P_AddressState { get; set; }
        public string P_AddressDist { get; set; }
        public string BusinessPlace_AddressState { get; set; }
        public string BusinessPlace_AddressDistrict { get; set; }
        public string BComm_AddressState { get; set; }
        public string BComm_AddressDistrict { get; set; }
        public string RegOffice_AddressState { get; set; }
        public string RegOffice_AddressDistrict { get; set; }


        public long zapRelated_Agent_ID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }
        [Display(Name = "Registration Number")]
        public string zapAgent_RegistrationNumber { get; set; }


        public List<ClsPrp_Print_RenewalAgent_AgentOtherIndProfile> AgentOtherIndProfile { get; set; }
        public ClsPrp_Print_RenewalAgent_AgentOtherIndProfile()
        {
            AgentOtherIndProfile = new List<ClsPrp_Print_RenewalAgent_AgentOtherIndProfile>();
        }

        public List<ClsPrp_Print_AgentOtherIndProfile> Agent_OtherMember { get; set; }
    }
}
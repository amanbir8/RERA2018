using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations
    {
        public long RenewalAgent_IndexID { get; set; }
        public long RenewalAgent_ID { get; set; }

        public int RenewalOrderSequence { get; set; }
        public int RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        public string Related_RERAnumberRegistration { get; set; }
        [Display(Name = "Registration Issue Date")]        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Related_RERAnumberIssueDate { get; set; }
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Related_RERAnumberRegUptoDate { get; set; }        

        public int Agent_Format_CODE { get; set; }

        //Ref Registration
        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAregistration_Number { get; set; }

        [Display(Name = "Registration Issue Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_IssueDate { get; set; }

        [Display(Name = "Registration Valid Upto Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_ExpiryDate { get; set; }

        [Display(Name = "Diary Number")]
        public string Agent_Reference_DiaryNumber { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_Reference_ApplicationDate { get; set; }

        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }

        [Display(Name = "Type of Agent")]
        public string Agent_Type { get; set; }

        //Agent Information
        [Display(Name = "Mode of Registration")]
        [StringLength(50)]
        public string Mode_RegistrationNumber { get; set; }


        //IND CASE
        [Required]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_FirstName { get; set; }


        [Display(Name = "Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_LastName { get; set; }

        [Required]
        [Display(Name = "Father's First Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Father_FirstName { get; set; }


        [Display(Name = "Father's Middle Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Father_MiddleName { get; set; }

        [Required]
        [Display(Name = "Father's Last Name")]
        [StringLength(60, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Father_LastName { get; set; }

        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string Individual_PAN_Number { get; set; }

        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number")]
        [Display(Name = "Aadhaar Number")]
        public long Individual_Aadhaar_Number { get; set; }


        //OTI CASE
        [Required]
        [Display(Name = "Name of Organization")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Organization_Name { get; set; }

        [Required]
        [Display(Name = "Type of Organization")]
        public Nullable<int> Organization_TypeCode { get; set; }

        [Required]
        [Display(Name = "PAN Number of Organization")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string Organization_PAN_Number { get; set; }



        //IND-Permanent Address OR OTI-Regd Address
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegOfficeOrPermanent_AddressLine1 { get; set; }


        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegOfficeOrPermanent_AddressLine2 { get; set; }

        [Display(Name = "State")]
        public string RegOfficeOrPermanent_AddressStateCode { get; set; }

        [Display(Name = "District")]
        public string RegOfficeOrPermanent_AddressDistrictCode { get; set; }

        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Nullable<int> RegOfficeOrPermanent_AddressPIN { get; set; }


        //Place of Bussiness Address
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BusinessPlace_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BusinessPlace_AddressLine2 { get; set; }

        [Display(Name = "State")]
        public string BusinessPlace_AddressStateCode { get; set; }

        [Display(Name = "District")]
        public string BusinessPlace_AddressDistrictCode { get; set; }

        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public int BusinessPlace_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Sub Division")]
        public int BusinessPlace_AddressSubDivisionCode { get; set; }

        [Required]
        [Display(Name = "Sub Division Name")]
        public string BusinessPlace_AddressSubDivisionName { get; set; }


        //Official Address OR Communication Address
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BComm_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BComm_AddressLine2 { get; set; }

        [Display(Name = "State")]
        public string BComm_AddressStateCode { get; set; }

        [Display(Name = "District")]
        public string BComm_AddressDistrictCode { get; set; }

        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Nullable<int> BComm_AddressPIN { get; set; }


        //OTI-Authorized Person
        [Display(Name = "First Name")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_FirstName { get; set; }


        [Display(Name = "Middle Name")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(80, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_LastName { get; set; }

        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string PAN_Number { get; set; }

        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number")]
        [Display(Name = "Aadhaar Number")]
        public long Aadhaar_Number { get; set; }



        //IND-agent-detail or OTI-Authorized Person-detail
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        [Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }

        public Nullable<long> PhoneNumber_STD { get; set; }
        
        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number")]
        public Nullable<long> PhoneNumber_Number { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string EmailAddress { get; set; }       
        

        //OTHER
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

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }

        public string BusinessPlace_AddressSubDivision { get; set; }

        public string P_AddressState { get; set; }
        public string P_AddressDist { get; set; }
        public string BusinessPlace_AddressState { get; set; }
        public string BusinessPlace_AddressDistrict { get; set; }
        public string BComm_AddressState { get; set; }
        public string BComm_AddressDistrict { get; set; }
        public string RegOffice_AddressState { get; set; }
        public string RegOffice_AddressDistrict { get; set; }
        

        public long zapRelated_Agent_ID { get; set; }
        public int zapRelated_AgentType_ID { get; set; }
        public long zapRelated_RenewalAgent_ID { get; set; }
        public int zapRelated_RenewalAgent_SequenceID { get; set; }
        public int zapRelated_RenewalAgent_YearID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapRenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Registration Number")]
        public string zapRenewalAgent_RegistrationNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapRenewalAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapRenewalAgentLastModifiedOn { get; set; }


        public List<ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations> AgentPrevRegistrations { get; set; }
        public ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations()
        {
            AgentPrevRegistrations = new List<ClsPrp_AuthDesk_View_RenewalAgent_PrevRegistrations>();
        }

        public List<ClsPrp_AuthDesk_View_RenewalAgent_OtherMembers> AgentPrevRegistrations_OtherMember { get; set; }
    }
}
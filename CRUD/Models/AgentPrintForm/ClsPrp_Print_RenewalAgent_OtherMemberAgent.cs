using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsPrp_Print_RenewalAgent_OtherMemberAgent
    {
        public long RenewalAgent_OtherMember_IndexID { get; set; }
        public long RenewalAgent_OtherMember_ID { get; set; }

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
        public long Related_Agent_OtherMember_ID { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [Display(Name = "Designation")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Name of Member is required")]
        [Display(Name = "Name of Member")]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string OtherMember_Name { get; set; }

        [Required(ErrorMessage = "PAN Number is required")]
        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string OtherMember_PAN_Number { get; set; }

        [Required(ErrorMessage = "Aadhar Number is required")]
        [Display(Name = "Aadhar Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public string OtherMember_Aadhaar_Number { get; set; }

        [Required(ErrorMessage = "Official Communication is required")]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string OfficeComm_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string OfficeComm_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public int OfficeComm_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public int OfficeComm_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code.")]
        public int OfficeComm_AddressPIN { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNumber { get; set; }

        public Nullable<long> PhoneNumber_STD { get; set; }

        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number.")]
        public Nullable<long> PhoneNumber_Number { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string Image_FileName { get; set; }

        [Display(Name = "Photo Path")]
        public string Image_FilePath { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

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

        public List<ClsPrp_Print_RenewalAgent_OtherMemberAgent> Agent_OtherMember { get; set; }
        public ClsPrp_Print_RenewalAgent_OtherMemberAgent()
        {
            Agent_OtherMember = new List<ClsPrp_Print_RenewalAgent_OtherMemberAgent>();
        }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Agent
{
    public class ClsprpRera_Agent_OtherMemberDetail
    {
        public int ID { get; set; }
        public long Agent_OtherMemberDetails_ID { get; set; }

        [Display(Name = "Agent ID")]
        public long Agent_ID { get; set; }

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
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<ClsprpRera_Agent_OtherMemberDetail> Agent_OtherMember { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintFormMN_Addmore_Respondent
    {
        public long AdditionRespondent_IndexID { get; set; }
        public long AdditionRespondent_ID { get; set; }
        public long? AdditionRespondent_RelatedComplaint_ID { get; set; }
        public string AdditionRespondent_RelatedComplaint_Code { get; set; }
        public long Profile_ID { get; set; } 
        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }

        [Required]
        [Display(Name = "Name of Respondent")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z0-9''-'-,.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Name_of_Respondant_or_Applicant { get; set; }
        
        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public long? MobileNumber { get; set; }

        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number.")]
        public long? LandlineNumber { get; set; }

        [Display(Name = "Aadhaar Number of Repondent")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public long? Repondant_AadhaarNumber { get; set; }


        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegOffice_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string RegOffice_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public int? RegOffice_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public int? RegOffice_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "PIN Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public string RegOffice_AddressPIN { get; set; }


        [Display(Name = "Do you have same Service Address with Registered office Address?")]
        public bool? IsSameCommunicationAdd_ResOffAdd { get; set; }


        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Service_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Service_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public Nullable<int> Service_AddressStateCode { get; set; }

        [Required]
        [Display(Name = "District")]
        public Nullable<int> Service_AddressDistrictCode { get; set; }

        [Required]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public Nullable<int> Service_AddressPIN { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsTempTable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<ClsPrp_ComplaintFormMN_Addmore_Respondent> FormMN_Respondent { get; set; }
        public ClsPrp_ComplaintFormMN_Addmore_Respondent()
        {
            FormMN_Respondent = new List<ClsPrp_ComplaintFormMN_Addmore_Respondent>();
        }

        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}
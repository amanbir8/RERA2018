using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_OrgMemDetail
    {
        public long Id { get; set; }


        public long Application_id { get; set; }
        public long Promoter_OtherMemberDetails_ID { get; set; }


        [Required(ErrorMessage = "Designation is required.")]
        [Display(Name = "Designation")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Name of Member is required")]
        [Display(Name = "Name of Member")]
        [StringLength(100, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string Member_Names { get; set; }

        [Required(ErrorMessage = "PAN Number is required")]
        [Display(Name = "PAN Number")]
        [RegularExpression(@"^([a-zA-Z]{5}\d{4}[a-zA-Z]{1})$", ErrorMessage = "Invalid PAN Number")]
        public string PAN_No { get; set; }

        [Required(ErrorMessage = "Aadhar Number is required")]
        [Display(Name = "Aadhar Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public long Aadhar_No { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string Address_Line2 { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "District is required")]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Pin Code is required")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code.")]
        public Nullable<long> Pin_Code { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public Nullable<long> Mobile_no { get; set; }

        /// <summary>
        /// new field
        /// </summary>
        [Display(Name = "Phone Number(STD)")]
        public Nullable<long> PhoneNumber_STD { get; set; }

        [Display(Name = "Landline Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public Nullable<long> Phone_No { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Image_FileName is required")]
        //[Display(Name = "Image_FileName")]
        /// <summary>
        /// new field
        /// </summary>
        public string Image_FileName { get; set; }

        //[Required(ErrorMessage = "Photo is required")]
        [Display(Name = "Photograph")]
        public string Photo_Address { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Modify_By { get; set; }
        public System.DateTime ModifyOn { get; set; }

        // public System.DateTime Modified_On { get; set; }

        public int Flag { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public List<ClsPrp_OrgMemDetail> prpMem { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}
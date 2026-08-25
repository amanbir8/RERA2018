using CRUD.Models.HelpDeskComplaint;
using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintAdvocateProfile
    {
            public long ComplaintProfile_IndexID { get; set; }
            public long ComplaintProfile_ID { get; set; }
            public string UserID { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [StringLength(90, MinimumLength = 2)]
            [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
            public string Applicant_FirstName { get; set; }

            [Display(Name = "Middle Name")]
            [StringLength(60, MinimumLength = 1)]
            [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
            public string Applicant_MiddleName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [StringLength(90, MinimumLength = 2)]
            [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
            public string Applicant_LastName { get; set; }

            [Required]
            [Display(Name = "Father's Name/ Husband's Name")]
            [StringLength(90, MinimumLength = 2)]
            [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
            public string Father_FirstName { get; set; }

            [Display(Name = "Father's Middle Name")]
            [StringLength(60, MinimumLength = 1)]
            [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
            public string Father_MiddleName { get; set; }

            [Display(Name = "Aadhaar Number")]
            [StringLength(60, MinimumLength = 2)]
            [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
            public string Father_LastName { get; set; }

            [Display(Name = "Occupation")]
            [StringLength(60, MinimumLength = 2)]
            [RegularExpression(@"^[/\a-zA-Z''-'-.,\s()]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
            public string Occupation { get; set; }

            [Required]
            [Display(Name = "Address Line 1")]
            [StringLength(90, ErrorMessage = "Maximum length is 90")]
            public string Residencial_Official_AddressLine1 { get; set; }

            [Display(Name = "Address Line 2")]
            [StringLength(90, ErrorMessage = "Maximum length is 90")]
            public string Residencial_Official_AddressLine2 { get; set; }

            [Required]
            [Display(Name = "State")]
            public Nullable<int> Residencial_Official_AddressStateCode { get; set; }

            [Required]
            [Display(Name = "District")]
            public Nullable<int> Residencial_Official_AddressDistrictCode { get; set; }

            [Required]
            [Display(Name = "PIN Code")]
            [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
            public string Residencial_Official_AddressPIN { get; set; }

            [Display(Name = "Do you have same Official/ Residential Address with Communication Address?")]
            public bool? IsSameCommunicationAdd_ResOffAdd { get; set; }

            [Required]
            [Display(Name = "Address Line 1")]
            [StringLength(90, ErrorMessage = "Maximum length is 90")]
            public string Comm_AddressLine1 { get; set; }

            [Display(Name = "Address Line 2")]
            [StringLength(90, ErrorMessage = "Maximum length is 90")]
            public string Comm_AddressLine2 { get; set; }

            [Required]
            [Display(Name = "State")]
            public Nullable<int> Comm_AddressStateCode { get; set; }

            [Required]
            [Display(Name = "District")]
            public Nullable<int> Comm_AddressDistrictCode { get; set; }

            [Required]
            [Display(Name = "Pin Code")]
            [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
            public Nullable<int> Comm_AddressPIN { get; set; }

            [Required]
            [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
            [Display(Name = "Mobile Number")]
            public long MobileNumber { get; set; }

            public Nullable<long> PhoneNumber_STD { get; set; }

            [Display(Name = "Landline Number or Fax Number")]
            [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
            public Nullable<long> PhoneNumber_Number { get; set; }

            [EmailAddress]
            [Required]
            [Display(Name = "Email Address")]
            [StringLength(100, ErrorMessage = "Maximum length is 100")]
            public string EmailAddress { get; set; }

            public string Remarks_IfAny { get; set; }
            public string A_column { get; set; }
            public string B_column { get; set; }
            public string C_column { get; set; }

            public int IsActive { get; set; }
            public int IsDraft { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public string ModifyBy { get; set; }
            public DateTime ModifyOn { get; set; }



            [Required]
            [Display(Name = "Party Type")]
            public string SelectedPartyType { get; set; }

            [Required]
            [Display(Name = "Selected Complainant")]
            public long? SelectedComplainantID { get; set; }

            [Required]
            [Display(Name = "Selected Respondant")]
            public long? SelectedRespondantID { get; set; }

            [Required]
            public long? SelectedAdvocateID { get; set; }
            [Required(ErrorMessage = "Please select an advocate.")]
            [Display(Name = "Selected Advocate")]
            public string SelectedAdvocateName { get; set; }

            public List<ClsPrp_Master_Advocates> MasterAdvocates { get; set; }
            public List<ClsPrp_ComplaintAdvocateProfile> ComplaintAdvocateProfile { get; set; }


            public List<ClsPrp_StateMaster> stateMaster { get; set; }
            public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
            public string CounselRepresentative { get; set; }
            public ClsPrp_ComplaintAdvocateProfile()
            {
                ComplaintAdvocateProfile = new List<ClsPrp_ComplaintAdvocateProfile>();
                MasterAdvocates = new List<ClsPrp_Master_Advocates>();
            }
    }
}
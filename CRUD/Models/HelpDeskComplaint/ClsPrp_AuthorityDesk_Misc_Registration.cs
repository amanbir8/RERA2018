using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthorityDesk_Misc_Registration
    {
        public long ComplaintMisc_IndexID { get; set; }
        public long ComplaintMisc_ID { get; set; }
        public long ComplaintMisc_Year { get; set; }
        public string ComplaintMisc_Code { get; set; }
        public string ComplaintType_MNG { get; set; }

        [Required]
        [Display(Name = "Name of Complainant")]
        [StringLength(120, ErrorMessage = "Maximum length is 120")]
        public string Complainant_Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]
        [StringLength(120, ErrorMessage = "Maximum length is 120")]
        public string Complainant_EmailAddress { get; set; }

        [Required]
        [Display(Name = "Mobile Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Complainant")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Landline Number or Fax Number.")]
        public long? Complainant_LandlineNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address for Communication")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Address_for_Communication { get; set; }

        [Required]
        [Display(Name = "Name of Project")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Project_Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Official/ Residential/ Project Address")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Project_Address { get; set; }

        [Required]
        [Display(Name = "Landmark/ Colony/ Village/ Location of Project, If any")]
        [StringLength(150, ErrorMessage = "Maximum length is 150")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Village_Sector_Tehsil_Location_of_Project { get; set; }

        [Required]
        //[AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Details of Complaint/ Information")]
        [StringLength(4500, ErrorMessage = "Maximum length is 4500")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,4500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 4500")]
        public string Complaint_Information_Details { get; set; }

        [Display(Name = "Enclosure/ Document Name")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ComplaintDocI_InfoName { get; set; }

        public DateTime ComplaintDocI_IssueDate { get; set; }
        public string ComplaintDocI_FileSize { get; set; }
        public string ComplaintDocI_FileFormat { get; set; }
        public string ComplaintDocI_FilePath { get; set; }
        public string ComplaintDocI_FileName { get; set; }
        public int? ComplaintDocI_PageStartNumber { get; set; }
        public int? ComplaintDocI_PageEndNumber { get; set; }

        [Display(Name = "Enclosure/ Document Name")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ComplaintDocII_InfoName { get; set; }

        public DateTime ComplaintDocII_IssueDate { get; set; }
        public string ComplaintDocII_FileSize { get; set; }
        public string ComplaintDocII_FileFormat { get; set; }
        public string ComplaintDocII_FilePath { get; set; }
        public string ComplaintDocII_FileName { get; set; }
        public int? ComplaintDocII_PageStartNumber { get; set; }
        public int? ComplaintDocII_PageEndNumber { get; set; }

        [Display(Name = "Enclosure/ Document Name")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        [RegularExpression(@"^[/\0-9a-zA-Z''-',.\s()]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ComplaintDocIII_InfoName { get; set; }

        public DateTime ComplaintDocIII_IssueDate { get; set; }
        public string ComplaintDocIII_FileSize { get; set; }
        public string ComplaintDocIII_FileFormat { get; set; }
        public string ComplaintDocIII_FilePath { get; set; }
        public string ComplaintDocIII_FileName { get; set; }
        public int? ComplaintDocIII_PageStartNumber { get; set; }
        public int? ComplaintDocIII_PageEndNumber { get; set; }


        public int IsVerificationComplete { get; set; }

        [Display(Name = "Complaint Verification Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ComplaintVerificationDate { get; set; }

        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public long zapRelated_Complaint_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }

        public List<ClsPrp_AuthorityDesk_Misc_Registration> ComplaintMisc { get; set; }
        public ClsPrp_AuthorityDesk_Misc_Registration()
        {
            ComplaintMisc = new List<ClsPrp_AuthorityDesk_Misc_Registration>();
        }        
    }
}
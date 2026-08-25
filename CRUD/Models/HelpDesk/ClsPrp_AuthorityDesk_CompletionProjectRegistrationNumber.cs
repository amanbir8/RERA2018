using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber
    {
        public long PCC_IndexID { get; set; }
        public long PCC_ID { get; set; }

        [Required]
        [Display(Name = "Project Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }

        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public string User_ID { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z().,&''-'-\s]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Promoter Name")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z().,&''-'-\s]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string PromoterName { get; set; }

        [Required(ErrorMessage = "The Project Address District field is required.")]
        [Display(Name = "Project Address District Code")]
        public string ProjectAddressDistrict { get; set; }

        [Display(Name = "Project Address District")]
        public string DName { get; set; }


        [Required]
        [Display(Name = "Certificate/Document Name")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string PCC_InfoDetails { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z().,&''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string PCC_ReferenceName { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PCC_ReferenceDate { get; set; }

        [Required]
        [Display(Name = "Issuing Authority of Document")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string PCC_CertificateStatus { get; set; }

        [Required]
        [Display(Name = "Mode of Recipt")]
        public string PCC_ReciptType { get; set; }

        [Display(Name = "Remarks If Any")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? Extra1 { get; set; }

        [Display(Name = "PCC Diary Number")]
        public string Extra2 { get; set; }

        [Required]
        [Display(Name = "Type of Document")]
        public string Extra3 { get; set; }

        public string Extra4 { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        
        public int IsDraftHelpDesk { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsDraftEvaluation { get; set; }

        [Display(Name = "Is Conditional PCC?")]
        public int IsDraftSecMember { get; set; }

        public int IsDraftMember { get; set; }

        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Display(Name = "Project Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectApplicationDate { get; set; }
        [Display(Name = "Form-E Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectExtensionApplicationDate { get; set; }
                
        public string ProjectRERAcert_FilePath { get; set; }
        public string ProjectRERAcert_FileName { get; set; }
        public string ProjectRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectRERAcert_IssueDate { get; set; }

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "PCC Diary Number")]
        public string zipProjectCompletion_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipProject_RERAregistrationNumber { get; set; }


        public List<ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_CompletionProjectRegistrationNumber>();
        }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}
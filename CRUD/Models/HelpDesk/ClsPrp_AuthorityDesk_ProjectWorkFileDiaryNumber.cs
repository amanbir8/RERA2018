using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber
    {
        public long Reference_ID { get; set; }
        public string Reference_Number { get; set; }

        public long Project_RegDiaryNumber_IndexID { get; set; }
        public long Project_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }
        public string PromoterRegDiaryNumber_Name { get; set; }
        public string PromoterRegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public int LandDetailsCount { get; set; }
        public int KhasraAreaDetailsCount { get; set; }
        public int LitigationsCount { get; set; }
        public int ApprovalDetailsCount { get; set; }
        public int PaymentDetailsCount { get; set; }
        public int SpecialBankAccountDetailsCount { get; set; }
        public int ProjectDocumentCount { get; set; }
        public string IsRegistration { get; set; }
        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }

        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }


        public int PromoterType { get; set; }
        public string PromoterName { get; set; }
        public string PromoterWebLink { get; set; }
        public string PromoterAuthSignFormB { get; set; }

        public string ProjectAuthContactPersonName { get; set; }

        [Required]
        [Display(Name = "Authorized Person Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AuthorizedPerson_Email { get; set; }

        [Required]
        [Display(Name = "Authorized Person Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string AuthorizedPerson_Mobile { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Potential Zone")]
        public string ProjectPotentialZone { get; set; }

        [Required]
        [Display(Name = "Project Website Web Link")]
        [StringLength(90)]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "Please check the url")]
        public string ProjectWebLink { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApplicationDate { get; set; }


        public string ProjectRERAcert_FilePath { get; set; }
        public string ProjectRERAcert_FileName { get; set; }
        public string ProjectRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectRERAcert_IssueDate { get; set; }

        public List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectWorkFileDiaryNumber>();
        }        
    }
}
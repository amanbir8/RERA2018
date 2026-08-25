using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectRERA_Certificate
    {
        public long ProjectRERAcertificate_IndexID { get; set; }
        public long ProjectRERAcertificate_ID { get; set; }
        public string ProjectRegDiaryNumber_Name { get; set; }

        public long ProjectRegDiaryNumber_tbl_IndexID { get; set; }
        public DateTime? ProjectRegDiaryNumber_CreatedDate { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public string User_ID { get; set; }

        public string ProjectRERAcert_InfoCode { get; set; }
        [Required(ErrorMessage = "Certificate/Document Title is required.")]
        [Display(Name = "Certificate/Document Title")]
        public string ProjectRERAcert_InfoName { get; set; }

        [Display(Name = "Specify Document Name, If Other")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectDoc_RelatedSectionName { get; set; }

        [Required(ErrorMessage = "Document Reference Number is required.")]
        [Display(Name = "Document Reference Number")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectRERAcert_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Document Issue Date is required.")]
        [Display(Name = "Document Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectRERAcert_IssueDate { get; set; }

        public string ProjectRERAcert_FileSize { get; set; }
        public string ProjectRERAcert_FileFormat { get; set; }
        [Display(Name = "Certificate / Document")]
        public string ProjectRERAcert_FilePath { get; set; }
        public string ProjectRERAcert_FileName { get; set; }
        public int ProjectRERAcert_IsGroup { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Specify Document Name, If Other")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string A_column { get; set; }

        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public int IsPublicView { get; set; }
        public int IsCertificateIssued { get; set; }
        public int IsExtensionIssued { get; set; }
        public int IsWithdrawn { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }

        [Display(Name = "Diary Number")]
        public string zipCompletion_DiaryNumber { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipProjectRegistrationNumberName { get; set; }

        public List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate> prpongoing { get; set; }

        public ClsPrp_AuthorityDesk_ProjectRERA_Certificate()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectRERA_Certificate>();
        }
    }
}
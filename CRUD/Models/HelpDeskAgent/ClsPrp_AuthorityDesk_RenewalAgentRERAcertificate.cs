using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate
    {
        public long RenewalAgent_RERAcertificate_IndexID { get; set; }
        public long RenewalAgent_RERAcertificate_ID { get; set; }

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

        public string Related_ReferenceDiaryNumber_Name { get; set; }
        public long Related_tbl_RegDiaryNumber_indexID { get; set; }

        public string AgentRERAcert_InfoCode { get; set; }
        [Required(ErrorMessage = "Certificate/Document Title is required.")]
        [Display(Name = "Certificate/Document Title")]
        public string AgentRERAcert_InfoName { get; set; }

        [Display(Name = "Specify Document Name, If Other")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string AgentDoc_RelatedSectionName { get; set; }

        [Required(ErrorMessage = "Document Reference Number is required.")]
        [Display(Name = "Document Reference Number")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string AgentRERAcert_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Document Issue Date is required.")]
        [Display(Name = "Document Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? AgentRERAcert_IssueDate { get; set; }

        public string AgentRERAcert_FileSize { get; set; }
        public string AgentRERAcert_FileFormat { get; set; }
        [Display(Name = "Certificate / Document")]
        public string AgentRERAcert_FilePath { get; set; }
        public string AgentRERAcert_FileName { get; set; }
        public int AgentRERAcert_IsGroup { get; set; }

        public string Agent_RERAnumberRegistration { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERAnumberIssueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERAnumberRegUptoDate { get; set; }

        public string Latest_RenewalAgent_RERAnumberRegistration { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Latest_RenewalAgent_RERAnumberIssueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Latest_RenewalAgent_RERAnumberRegUptoDate { get; set; }

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
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public int IsPublicView { get; set; }
        public int IsCertificateIssued { get; set; }
        public int IsWithdrawn { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }
        
        //Display Reference For Issue RERA Number
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

        public List<ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RenewalAgent_RERA_Certificate>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentRERA_Certificate
    {
        public long AgentRERAcertificate_IndexID { get; set; }
        public long AgentRERAcertificate_ID { get; set; }
        public string AgentRegDiaryNumber_Name { get; set; }
        public long Agent_ID { get; set; }
        public long tbl_RegDiaryNumber_indexID { get; set; }

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
        [StringLength(90, MinimumLength = 4)]
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

        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        public long zapRelated_Agent_ID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }


        //Display Reference For Revoke
        public long zipRelated_Agent_ID { get; set; }
        public long zipRelated_RenewalAgent_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zipAgent_DiaryNumber { get; set; }
        [Display(Name = "Latest Renewal Diary Number")]
        public string zipLatestRenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zipAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipAgentLastModifiedOn { get; set; }
        [Display(Name = "Revocation/Cancellation Diary Number")]
        public string zipRevocationCancellation_DiaryNumber { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipAgentRegistrationNumberName { get; set; }


        public List<ClsPrp_AuthorityDesk_AgentRERA_Certificate> prpongoing { get; set; }

        public ClsPrp_AuthorityDesk_AgentRERA_Certificate()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentRERA_Certificate>();
        }
    }
}
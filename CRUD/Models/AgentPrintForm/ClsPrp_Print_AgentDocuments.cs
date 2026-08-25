using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsPrp_Print_AgentDocuments
    {
        public long AgentDoc_IndexID { get; set; }
        public long AgentDoc_ID { get; set; }
        public long Agent_ID { get; set; }

        [Required(ErrorMessage = "Document Name is required.")]
        [Display(Name = "Document Name")]
        public int AgentDoc_InfoCode { get; set; }

        public string AgentDoc_InfoName { get; set; }

        [Required(ErrorMessage = "Reference Number is required.")]
        [Display(Name = "Document Reference Number")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string AgentDoc_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Document Issue Date is required.")]
        [Display(Name = "Document Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? AgentDoc_IssueDate { get; set; }

        public string AgentDoc_FileSize { get; set; }
        public string AgentDoc_FileFormat { get; set; }
        public string AgentDoc_FilePath { get; set; }
        public string AgentDoc_FileName { get; set; }
        public int AgentDoc_IsGroup { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
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



        public List<ClsPrp_Print_AgentDocuments> AgentDocs { get; set; }

        public ClsPrp_Print_AgentDocuments()
        {
            AgentDocs = new List<ClsPrp_Print_AgentDocuments>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentDocument
{
    public class Clsprp_Agent_Documents
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

        [Required(ErrorMessage = "Document Upload Date is required.")]
        [Display(Name = "Date of Document Upload")]
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

        public List<Clsprp_Master_Agent_Documents> MasterDocs { get; set; }
        

        public List<Clsprp_Agent_Documents> AgentDocs { get; set; }
    }
}
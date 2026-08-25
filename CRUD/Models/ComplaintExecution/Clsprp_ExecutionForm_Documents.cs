using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ComplaintExecution
{
    public class Clsprp_ExecutionForm_Documents
    {
        public long ListEnclDocument_IndexID { get; set; }
        public long ListEnclDocument_ID { get; set; }
        public long ComplainantApplicant_RelatedComplaint_ID { get; set; }
        public string ComplainantApplicant_RelatedComplaint_Code { get; set; }
        public long Related_ComplaintFormMId { get; set; } // new
        public int Related_FormExe_SequenceID { get; set; } // new
        public int Related_FormExe_Year { get; set; } // new

        public long Profile_ID { get; set; }
        public string User_ID { get; set; }

        public string ComplaintType { get; set; }

        public string ComplaintDoc_InfoCode { get; set; }

        [Required(ErrorMessage = "Enclosure/ Document Name is required.")]
        [Display(Name = "Enclosure/ Document Name")]
        public string ComplaintDoc_InfoName { get; set; }

        [Required(ErrorMessage = "Enclosure/ Document Number is required.")]
        [Display(Name = "Enclosure/ Document Number")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ComplaintDoc_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Document Upload Date is required.")]
        [Display(Name = "Date of Document Upload")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? ComplaintDoc_IssueDate { get; set; }

        public string ComplaintDoc_FileSize { get; set; }
        public string ComplaintDoc_FileFormat { get; set; }
        public string ComplaintDoc_FilePath { get; set; }
        public string ComplaintDoc_FileName { get; set; }
        public int ComplaintDoc_IsGroup { get; set; }

        [Display(Name = "Serial Number")]
        public string Doc_SerialNumber { get; set; }

        [Required(ErrorMessage = "Number of Pages related to Enclosure/ Document is required.")]
        [Display(Name = "Number of Pages (Enclosure/ Document)")]
        [Range(0, 500)]
        public int Doc_PageStartNumber { get; set; }

        public int Doc_PageEndNumber { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Remarks_IfAny { get; set; }

        //[Required(ErrorMessage = "Enclosure/ Document is required.")]
        [Display(Name = " Select Option")]
        public string A_column { get; set; }

        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        //public List<Clsprp_Master_Project_Documents> MasterDocs { get; set; }        

        //public List<Clsprp_Project_Documents> ProjectDocs { get; set; }

        public List<Clsprp_ExecutionForm_Documents> prpFormM_Docs { get; set; }
        public Clsprp_ExecutionForm_Documents()
        {
            prpFormM_Docs = new List<Clsprp_ExecutionForm_Documents>();
        }
    }
}
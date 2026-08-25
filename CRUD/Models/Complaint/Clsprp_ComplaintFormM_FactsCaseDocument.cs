using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Complaint
{
    public class Clsprp_ComplaintFormM_FactsCaseDocument
    {
        public long FactsCaseDocument_IndexID { get; set; }
        public long FactsCaseDocument_ID { get; set; }
        public long ComplainantApplicant_RelatedComplaintM_ID { get; set; }
        public string ComplainantApplicant_RelatedComplaintM_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }

        public string ComplaintType_MN { get; set; }
        
        public string FactsCaseDoc_InfoCode { get; set; }

        [Required(ErrorMessage = "File Name is required.")]
        [Display(Name = "File Name")]
        public string FactsCaseDoc_InfoName { get; set; }

        [Required(ErrorMessage = "File Number is required.")]
        [Display(Name = "Enclosure/ Document Number")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string FactsCaseDoc_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "File Upload Date is required.")]
        [Display(Name = "Date of File Upload")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? FactsCaseDoc_IssueDate { get; set; }

        [Display(Name = "File Size")]
        public string FactsCaseDoc_FileSize { get; set; }
        [Display(Name = "File Format (pdf/doc/jpeg)")]
        public string FactsCaseDoc_FileFormat { get; set; }
        [Display(Name = "View File")]
        public string FactsCaseDoc_FilePath { get; set; }
        public string FactsCaseDoc_FileName { get; set; }
        public int FactsCaseDoc_IsGroup { get; set; }
        
        [Display(Name = "Serial Number")]
        public string Doc_SerialNumber { get; set; }

        [Required(ErrorMessage = "Number of Pages is required.")]
        [Display(Name = "Number of Pages")]
        [Range(0, 500)]
        public int Doc_NumberOfPages { get; set; }

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
        public int IsTempTable { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<Clsprp_ComplaintFormM_FactsCaseDocument> prpFormM_FactsCase_Docs { get; set; }
        public Clsprp_ComplaintFormM_FactsCaseDocument()
        {
            prpFormM_FactsCase_Docs = new List<Clsprp_ComplaintFormM_FactsCaseDocument>();
        }
    }
}
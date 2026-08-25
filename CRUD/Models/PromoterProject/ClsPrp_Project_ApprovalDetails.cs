using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.PromoterProject
{
    public class ClsPrp_Project_ApprovalDetails
    {
        public long ProjectApproval_IndexID { get; set; }
        public long ProjectApproval_ID { get; set; }
       
        public long ProjectApprovalRelated_ProjectRegistration_ID { get; set; }

        [Required]
        [Display(Name = "Document Type")]
        public string DocumentType_CategoryName { get; set; }

        public string DocumentType_Code { get; set; }

        [Required]
        [Display(Name = "Document Name")]
        //[StringLength(50, MinimumLength = 4)]
        //[RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string DocumentType_Name { get; set; }

        [Required]
        [Display(Name = "Document Status")]
        public string DocumentType_Status { get; set; }

        [Required]
        [Display(Name = "Date of Issue/ Application/ Reciept")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_ApplicationPlannedorExpectedReceipt { get; set; }

        public string DocumentType_FileSize { get; set; }

        public string DocumentType_FileFormat { get; set; }
         
        [Display(Name = "Document Name")]
        public string DocumentType_FilePath { get; set; }

        public string DocumentType_FileName { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "If Other, Specify Document Name")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string A_column { get; set; }

        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public List<ClsPrp_Project_ApprovalDetails> prpongoing { get; set; }
        public ClsPrp_Project_ApprovalDetails()
        {
            prpongoing = new List<ClsPrp_Project_ApprovalDetails>();

        }
        public List<ClsPrp_Project_Master> ProjectMaster { get; set; }
    }
}
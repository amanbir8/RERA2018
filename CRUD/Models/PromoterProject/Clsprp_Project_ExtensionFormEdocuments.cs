using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.PromoterProject
{
    public class Clsprp_Project_ExtensionFormEdocuments
    {
        public long FormE_IndexID { get; set; }
        public long FormE_ID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        
        public long ProjectExtension_NameID { get; set; }
        public int ProjectExtension_NameYear { get; set; }
        public string ProjectExtension_Name { get; set; }

        //[Required(ErrorMessage = "Project Diary Number is required.")]
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumberID { get; set; }

        [Required(ErrorMessage = "RERA Registration Number is required.")]
        [Display(Name = "RERA Registration Number")]
        public string Project_RERAnumber { get; set; }

        [Required(ErrorMessage = "RERA registration issue date is required.")]
        [Display(Name = "RERA registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERANumberIssueDate { get; set; }

        [Required(ErrorMessage = "RERA registration valid upto date is required.")]
        [Display(Name = "RERA registration Valid upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERANumberValiduptoDate { get; set; }

        [Required(ErrorMessage = "Extension applied upto date is required.")]
        [Display(Name = "Extension Applied upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? FormE_DocIssueDate { get; set; }

        [Required(ErrorMessage = "Reason for which Extension Applied field is required.")]
        [Display(Name = "Reason for which Extension Applied")]        
        public string FormE_ExtensionAppliedReason { get; set; }

        [Display(Name = "Specify Other Reasons here")]
        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,2000}$", ErrorMessage = "Special characters are not allowed. Maximum length is 2000")]
        public string FormE_ExtensionAppliedReasonSpecifyOthers { get; set; }

        [Required(ErrorMessage = "Document Name is required.")]
        [Display(Name = "Document Name")]
        public int FormE_DocInfoCode { get; set; }

        public string FormE_DocInfoName { get; set; }

        [Display(Name = "Document Related To")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string FormE_DocRelatedSectionName { get; set; }

        //[Required(ErrorMessage = "Reference Number is required.")]
        [Display(Name = "Document Reference Number")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string FormE_DocReferenceNumber { get; set; }

        public string FormE_DocFileSize { get; set; }
        public string FormE_DocFileFormat { get; set; }
        public string FormE_DocFilePath { get; set; }
        public string FormE_DocFileName { get; set; }
        public int FormE_DocIsGroup { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Summary, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,2000}$", ErrorMessage = "Special characters are not allowed. Maximum length is 2000")]
        public string Summary_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsTemp { get; set; }
        public int IsDraftMember { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ModifyOn { get; set; }

        public List<Clsprp_Master_Project_ExtensionFormDocuments> MasterExtensionDocs { get; set; }       
        public List<Clsprp_Project_ExtensionFormEdocuments> ProjectExtensionDocs { get; set; }

        public List<Clsprp_Project_ExtensionFormEdocuments> prpongoing { get; set; }
        public Clsprp_Project_ExtensionFormEdocuments()
        {
            prpongoing = new List<Clsprp_Project_ExtensionFormEdocuments>();
        }
    }
}
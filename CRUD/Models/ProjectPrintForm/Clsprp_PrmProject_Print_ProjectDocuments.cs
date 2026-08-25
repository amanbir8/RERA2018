using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectPrint
{
    public class ClsPrp_PrmProject_Print_ProjectDocuments
    {

        public long ProjectDoc_IndexID { get; set; }
        public long ProjectDoc_ID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }        

        [Required(ErrorMessage = "Document Name is required.")]
        [Display(Name = "Document Name")]
        public int ProjectDoc_InfoCode { get; set; }

        public string ProjectDoc_InfoName { get; set; }

        [Display(Name = "Document Related To")]
        [StringLength(90, MinimumLength = 2)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectDoc_RelatedSectionName { get; set; }

        [Required(ErrorMessage = "Reference Number is required.")]
        [Display(Name = "Document Reference Number")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectDoc_ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Document Issue Date is required.")]
        [Display(Name = "Document Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? ProjectDoc_IssueDate { get; set; }

        public string ProjectDoc_FileSize { get; set; }
        public string ProjectDoc_FileFormat { get; set; }
        public string ProjectDoc_FilePath { get; set; }
        public string ProjectDoc_FileName { get; set; }
        public int ProjectDoc_IsGroup { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }



        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }



        //public List<Clsprp_Master_Project_Documents> MasterDocs { get; set; }        

        //public List<Clsprp_Project_Documents> ProjectDocs { get; set; }

        public List<ClsPrp_PrmProject_Print_ProjectDocuments> prpongoing { get; set; }

        public ClsPrp_PrmProject_Print_ProjectDocuments()
        {
            prpongoing = new List<ClsPrp_PrmProject_Print_ProjectDocuments>();
        }

        public List<ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails> prpProjectDiaryNumberDetails { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.ProjectExtPrint
{
    public class ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE
    {
        public long FormE_IndexID { get; set; }
        public long FormE_ID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        
        public long ProjectExtension_NameID { get; set; }
        public int ProjectExtension_NameYear { get; set; }
        public string ProjectExtension_Name { get; set; }

        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumberID { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string Project_RERAnumber { get; set; }

        [Display(Name = "RERA registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERANumberIssueDate { get; set; }

        [Display(Name = "RERA registration Valid upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_RERANumberValiduptoDate { get; set; }

        [Display(Name = "Extension Applied upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)] //Nullable<System.DateTime>
        public DateTime? FormE_DocIssueDate { get; set; }

        [Display(Name = "Reason for which Extension Applied")]        
        public string FormE_ExtensionAppliedReason { get; set; }

        [Display(Name = "Specify Other Reasons here")]
        public string FormE_ExtensionAppliedReasonSpecifyOthers { get; set; }

        [Display(Name = "Document Name")]
        public int FormE_DocInfoCode { get; set; }

        public string FormE_DocInfoName { get; set; }

        [Display(Name = "Document Related To")]
        public string FormE_DocRelatedSectionName { get; set; }

        [Display(Name = "Document Reference Number")]
        public string FormE_DocReferenceNumber { get; set; }

        public string FormE_DocFileSize { get; set; }
        public string FormE_DocFileFormat { get; set; }
        public string FormE_DocFilePath { get; set; }
        public string FormE_DocFileName { get; set; }
        public int FormE_DocIsGroup { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Summary, If Any")]
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


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Form-E Diary Number")]
        public string zipProjectExtension_DiaryNumber { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectExtensionLastModifiedOn { get; set; }
        [Display(Name = "Project District Name")]
        public string zipProjectDistrictName { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE> prpongoing { get; set; }
        public ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE()
        {
            prpongoing = new List<ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE>();
        }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails> prpProjectExtFormDiaryNumberDetails { get; set; }
    }
}
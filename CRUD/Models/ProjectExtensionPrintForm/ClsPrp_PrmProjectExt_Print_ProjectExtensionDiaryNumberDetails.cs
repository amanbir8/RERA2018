using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectExtPrint
{
    public class ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails
    {
        public long ProjectExtForm_RegDiaryNumber_IndexID { get; set; }
        public long ProjectExtForm_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string ProjectExtForm_RegDiaryNumber_Name { get; set; }
        public string ProjectExtForm_RegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public int PaymentDetailsCount { get; set; }
        public int ProjectDocumentCount { get; set; }
        public string IsRegistration { get; set; }
        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


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


        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails> prpongoing { get; set; }

        public ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails()
        {
            prpongoing = new List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails>();

        }        
    }
}
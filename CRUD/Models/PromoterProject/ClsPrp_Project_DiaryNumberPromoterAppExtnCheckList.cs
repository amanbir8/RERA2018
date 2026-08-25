using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList
    {
        public long ProjectExtensionCheckListAction_ID { get; set; }
        public string CheckList_IdentifiedBy { get; set; }
        public string UserRole { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CheckList_IdentifiedOn { get; set; }
        public long Related_Promoter_ID { get; set; }
        public long Related_Project_ID { get; set; }
        public string Promoter_DiaryNumber { get; set; }
        public string Project_DiaryNumber { get; set; }
        public string CriteriaCode { get; set; }
        [Required]
        [Display(Name = "Criteria Requirement")]
        public string CriteriaSubCode { get; set; }
        [Display(Name = "Remarks, If Any")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, MinimumLength = 1)]
        [RegularExpression(@"^[0-9a-zA-Z ,-.()/]{1,1000}$", ErrorMessage = "Special characters are not allowed. Maximum length is 1000")]
        public string Remarks_IfAny { get; set; }
        [Required]
        [Display(Name = "Is Application Criteria Acceptable? (Yes/No)")]
        public string IsChecklistValueOk { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public string CriteriaSubCodeTitle { get; set; }
        public int VarCriteriaCode { get; set; }
        public int VarCriteriaSubCode { get; set; }
        public int VarChecklistOrderNumber { get; set; }
        public int VarChecklistGroupID { get; set; }

        public long zipExtensionFormRelated_Promoter_ID { get; set; }
        public long zipExtensionFormRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipExtensionFormProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipExtensionFormProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipExtensionFormProjectLastModifiedOn { get; set; }


        public List<ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList> prpongoing { get; set; }
        public ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList()
        {
            prpongoing = new List<ClsPrp_Project_DiaryNumberPromoterAppExtnCheckList>();
        }        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails
    {
        public long QUpdateProject_RegDiaryNumber_IndexID { get; set; }
        public long QUpdateProject_RegDiaryNumber_ID { get; set; }
        [Display(Name = "QUP Diary Number")]
        public string QUpdateProject_RegDiaryNumber_Name { get; set; }
        public string QUpdateProject_RegDiaryNumber_NameYear { get; set; }
        [Display(Name = "Quarterly Year")]
        public int QUpdateProject_Year { get; set; }
        [Display(Name = "Quarterly Name")]
        public string QUpdateProject_QuarterName { get; set; }
        public string UserID { get; set; }
        public long PromoterID { get; set; }
        public long ProjectID { get; set; }
        public int InventoryCount { get; set; }
        public int ParkingDetailsCount { get; set; }
        public int GeoTaggingPhotographCount { get; set; }
        public int InternalFacilitiesCount { get; set; }
        public int ExternalFacilitiesCount { get; set; }
        public int ApprovalsCount { get; set; }
        [Display(Name = "RERA Number")]
        public string RERAnumber { get; set; }
        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Display(Name = "Valid upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberValidUptoDate { get; set; }
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
        public int IsActiveProvider { get; set; }
        public int IsLock { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        [Display(Name = "Project District Name")]
        public string zipProjectDistrictName { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }

        public List<ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails> prpongoing { get; set; }

        public ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails()
        {
            prpongoing = new List<ClsPrp_PrintPDF_QUpdatesProjectDiaryNumberDetails>();
        }
    }
}
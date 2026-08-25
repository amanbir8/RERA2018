using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords
    {
        public long QUpdateProject_RegDiaryNumber_IndexID { get; set; }
        public long QUpdateProject_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string QUpdateProject_RegDiaryNumber_Name { get; set; }
        public string QUpdateProject_RegDiaryNumber_NameYear { get; set; }
        public int QUpdateProject_Year { get; set; }
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
        [Display(Name = "RERA Registration Number")]
        public string RERAnumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberVlaidUptoDate { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        [Display(Name = "Remarks, If Any")]
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


        [Display(Name = "Quarter Year")]
        public string setQuarterValue_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string setQuarterValue_Name { get; set; }
        [Display(Name = "Submitted Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? QuarterlySubmittedDate { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }

        public List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProjectStatusRecords>();

        }
    }
}
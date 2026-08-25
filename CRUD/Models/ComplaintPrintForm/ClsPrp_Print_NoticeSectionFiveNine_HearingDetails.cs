using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsPrp_Print_NoticeSectionFiveNine_HearingDetails
    {
        public long BenchHearingDate_IndexID { get; set; }
        public long BenchHearingDate_ID { get; set; }
        public long Related_ComplaintNoticesSectionFiveNine_ID { get; set; }
  
        [Display(Name = "Notice/File Number")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string Related_ComplaintNoticesSectionFiveNine_Code { get; set; }
        
        [Display(Name = "Type Of Complaint")]
        public string TypeOfComplaint { get; set; }
        [Display(Name = "Under Section ID")]
        public string TypeOfHearing { get; set; }
        [Display(Name = "Under Section")]
        public string TypeOfComplaintHearing { get; set; }

        [Display(Name = "Next Hearing Date Fixed")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Bench_HearingDate { get; set; }
        [Display(Name = "Next Hearing Time Fixed")]
        public string Bench_HearingTime { get; set; }

        [Display(Name = "Complaint Hearing Bench ID")]
        public string HearingBench_ID { get; set; }
        [Display(Name = "Complaint Hearing Bench")]
        public string HearingBench_Name { get; set; }

        [Display(Name = "Fixed For/ Status ID")]
        public string HearingBench_FixedFor_ID { get; set; }
        [Display(Name = "Fixed For/ Status")]
        public string HearingBench_FixedFor_Name { get; set; }

        [Display(Name = "Hearing Reply (in days)")]
        public string HearingReplyDays { get; set; }
        [Display(Name = "Business On Date/ Date Fixed for Proceeding")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HearingBench_BussinesOnDate_ProceedingDate { get; set; }

        [Display(Name = "Hearing Status")]
        public string HearingStatus { get; set; }

        [Display(Name = "Remarks, If Any")]
        [StringLength(1500)]
        public string Remarks_IfAny { get; set; }
        
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }
        public string E_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_Print_NoticeSectionFiveNine_HearingDetails> prpNoticeFiveNineHearingDetail { get; set; }
        public ClsPrp_Print_NoticeSectionFiveNine_HearingDetails()
        {
            prpNoticeFiveNineHearingDetail = new List<ClsPrp_Print_NoticeSectionFiveNine_HearingDetails>();
        }
    }
}
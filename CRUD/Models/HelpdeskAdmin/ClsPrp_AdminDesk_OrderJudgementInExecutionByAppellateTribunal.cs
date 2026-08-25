using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal
    {
        //Order & Judgement In Execution
        public long AppellateTribunalOrderExecution_IndexID { get; set; }
        public long AppellateTribunalOrderExecution_ID { get; set; }
        public long Related_ComplaintID { get; set; }

        public string Related_DiaryNumber { get; set; }
        public string Related_ComplaintType_MN { get; set; }
        [Required]
        [Display(Name ="Appeal Reference Number")]
        public string Related_Appeal_RefNumber { get; set; }
        public DateTime? Related_Appeal_OrderDate { get; set; }
        public int SerialOrderNumber { get; set; }

        [Display(Name = "Complaint Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ComplaintNumber { get; set; }

        [Required]
        [Display(Name = "Complainant Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string ComplainantName { get; set; }

        [Required]
        [Display(Name = "Respondent Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string RespondentName { get; set; }

        [Required]
        [Display(Name = "Date of Decision")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Decision { get; set; }

        [Required]
        [Display(Name = "Execution Appeal Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Execution_RefNumber { get; set; }

        [Required]
        [Display(Name = "Execution Date of Filing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Execution_FilingDate { get; set; }

        [Display(Name = "Execution Date of Instituion Filing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Execution_InstitutionDate { get; set; }

        public long Related_PreHearingDate_IndexID { get; set; }

        public long Related_PreHearingDate_ID { get; set; }

        public DateTime? Related_PreHearingDate { get; set; }

        public string Related_PreHearingTime { get; set; }

        public string User_ID { get; set; }


        [Display(Name = "Hearing Bench Code")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string HearingBenchCode { get; set; }

        [Display(Name = "Hearing Bench Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string HearingBenchName { get; set; }

        public string HearingBenchType { get; set; }

        [Required]
        [Display(Name = "Execution Type of Order")]
        public int ExecutionOrderDoc_InfoCode { get; set; }

        [Display(Name = "Execution Type of OrderName")]
        public string ExecutionOrderDoc_InfoName { get; set; }

        public string ExecutionOrderDoc_ReferenceNumber { get; set; }

        public DateTime? ExecutionOrderDoc_IssueDate { get; set; }

        public string ExecutionOrderDoc_FileSize { get; set; }

        public string ExecutionOrderDoc_FileFormat { get; set; }

        public string ExecutionOrderDoc_FilePath { get; set; }

        public string ExecutionOrderDoc_FileName { get; set; }

        public int ExecutionOrderDoc_IsGroup { get; set; }

        public string Upload_SerialNumber { get; set; }

        public int Upload_PageStartNumber { get; set; }

        public int Upload_PageEndNumber { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }


        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftMember { get; set; }
        public int IsLock { get; set; }

        public string ViewJugdement_BaseUrl { get; set; }

        //public long Related_OrderJudgement_ComplaintID { get; set; }
        //public string Related_OrderJudgement_ComplaintType { get; set; }
        //public string Related_OrderJudgement_DiaryNumber { get; set; }
        //public string Related_OrderJudgement_OrderRefNumber { get; set; }


        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }
        public int IsFlag { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        [Display(Name = "Type of Order")]
        public string Related_TypeofOrder { get; set; }

        public List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> prpongoing { get; set; }
        public ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal()
        {
            prpongoing = new List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal>();
        }

        //public List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> prpOrderCourtREAT { get; set; }
        //public List<ClsPrp_AdminDesk_OrderJudgementInExecutionByAppellateTribunal> prpOrderCourtExREAT { get; set; }
    }
}
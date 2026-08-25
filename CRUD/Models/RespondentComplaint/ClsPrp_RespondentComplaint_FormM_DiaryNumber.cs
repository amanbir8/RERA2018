using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.RespondentComplaint
{
    public class ClsPrp_RespondentComplaint_FormM_DiaryNumber
    {
        public long ComplaintRegDiaryNumber_IndexID { get; set; }
        public long ComplaintRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string ComplaintRegDiaryNumber_Name { get; set; }
        public int ComplaintRegDiaryNumber_NameYear { get; set; }
        public long FormM_RelatedComplaint_ID { get; set; }
        public string FormM_RelatedComplaint_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }
        public int IsComplaintComplete { get; set; }
        public int IsPaymentComplete { get; set; }
        public string PaymentTransactionID { get; set; }
        public DateTime? PaymentTransactionDate { get; set; }
        public int IsDocumentsComplete { get; set; }
        public int DocumentUploadCount { get; set; }
        public int IsVerificationComplete { get; set; }
        public DateTime? ComplaintVerificationDate { get; set; }
        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Name of Complainant")]
        public string Complainant_Name { get; set; }
        [Display(Name = "Mobile Number of Complainant")]
        public long Complainant_MobileNumber { get; set; }
        [Display(Name = "Complaint Against")]
        public string RelatesComplaint_ComplaintAgainstType { get; set; }
        [Display(Name = "Name of Respondent")]
        public string Respondent_Name { get; set; }

        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }

        [Display(Name = "Hearing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PreHearingDate { get; set; }
        [Display(Name = "Hearing Time")]
        public string PreHearingTime { get; set; }
        [Display(Name = "Fixed For")]
        public string PreHearingFixedForName { get; set; }
        [Display(Name = "Hearing Type")]
        public string HearingType_Acolumn { get; set; }
        [Display(Name = "Hearing Bench")]
        public string HearingBench_Bcolumn { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string complaintrelatedRERAnumber { get; set; }
        [Display(Name = "Project/Agent Name")]
        public string complaintrelatedProjectorAgentName { get; set; }

        public List<ClsPrp_RespondentComplaint_FormM_DiaryNumber> prpongoing { get; set; }
        public ClsPrp_RespondentComplaint_FormM_DiaryNumber()
        {
            prpongoing = new List<ClsPrp_RespondentComplaint_FormM_DiaryNumber>();
        }
        public List<Clsprp_RespondentComplaint_FormM_Documents> prpFormM_Docs { get; set; }
    }
}
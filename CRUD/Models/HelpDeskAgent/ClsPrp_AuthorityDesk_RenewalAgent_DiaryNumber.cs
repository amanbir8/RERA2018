using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber
    {
        public long RenewalAgentDiaryNumber_IndexID { get; set; }
        public long RenewalAgentDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RenewalAgentDiaryNumber_Name { get; set; }
        public string RenewalAgentDiaryNumber_NameYear { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalAgent_Year { get; set; }
        public int Related_RenewalAgent_SequenceID { get; set; }
        public string Related_UserID { get; set; }
        public long Related_Agent_ID { get; set; }
        public int Related_AgentType_ID { get; set; }

        [Display(Name = "Reference Diary Number")]
        public string Related_Agent_DiaryNumber { get; set; }
        [Display(Name = "Registration Number")]
        public string Related_RERAnumberRegistration { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Related_LastRegistrationIssueDate { get; set; }
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Related_LastRegistrationRegUptoDate { get; set; }

        public int othermemdetailCount { get; set; }
        public int documentuploadCount { get; set; }
        public int UTOtherStateRERACount { get; set; }
        public int PaymentCount { get; set; }
        public int AgentDocumentCount { get; set; }       

        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }       
        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }

        [Display(Name = "Real Estate Agent Name")]
        public string RenewalAgent_Name { get; set; }        
        [Display(Name = "District Name")]
        public string RenewalAgent_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string RenewalAgent_RERAregistrationNumber { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }

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

        [Display(Name = "RERA Registration Number")]
        public string RERA_Registration_Number { get; set; } //RERAnumberRegistration
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_IssueDate { get; set; } //RERAnumberIssueDate
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_RegistrationUptoDate { get; set; } //RERAnumberRegUptoDate


        public List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RenewalAgent_DiaryNumber>();
        }        
    }
}
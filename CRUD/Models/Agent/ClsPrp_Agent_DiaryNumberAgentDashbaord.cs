using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Agent
{
    public class ClsPrp_Agent_DiaryNumberAgentDashbaord
    {
        public long AgentRegDiaryNumber_IndexID { get; set; }
        public long AgentRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string AgentRegDiaryNumber_Name { get; set; }
        public string AgentRegDiaryNumber_NameYear { get; set; }       

        public long Agent_ID { get; set; }
        public string UserID { get; set; }     
        public int othermemdetailCount { get; set; }
        public int documentuploadCount { get; set; }
        public int UTOtherStateRERACount { get; set; }
        public int PaymentCount { get; set; }
        public int AgentDocumentCount { get; set; }
        public string Remarks_IfAny { get; set; }

        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }

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

        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }        
        [Display(Name = "RERA Number")]
        public string Agent_RERAregistrationNumber { get; set; }

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

        public long RenewalAgentRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RenewalAgentRegDiaryNumber_Name { get; set; }
        public string RenewalAgentRegDiaryNumber_NameYear { get; set; }

        public long Registration_Number_Code { get; set; }
        public long Registration_Number_EventTypeID { get; set; }
        public string Registration_Number_SeqOrder { get; set; }

        public long Registration_Number_ReferenceID { get; set; }
        public string Registration_Number_ReferenceNumber { get; set; }
        public DateTime? Registration_Number_ReferenceDate { get; set; }
        public Int32 Registration_Number_IsLatestRenewal_Flag { get; set; }

        [Display(Name = "Registration Number")]
        public string RERA_Registration_Number { get; set; }
        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Registration_IssueDate { get; set; }
        [Display(Name = "Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Registration_ValidUptoDate { get; set; }
        [Display(Name = "Renewal Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastRenewal_Registration_IssueDate { get; set; }
        [Display(Name = "Renewal Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastRenewal_Registration_ValidUptoDate { get; set; }
        [Display(Name = "Status Flag")]
        public Int32 Registration_Number_Flag { get; set; }
        [Display(Name = "Status, If Any")]
        public string Registration_Number_Status { get; set; }

        public List<ClsPrp_Agent_DiaryNumberAgentDashbaord> prpongoing { get; set; }
        public ClsPrp_Agent_DiaryNumberAgentDashbaord()
        {
            prpongoing = new List<ClsPrp_Agent_DiaryNumberAgentDashbaord>();
        }

        public List<Models.HelpDeskAgent.ClsPrp_AuthorityDesk_AgentSubCheckListLog> AppAgentCheckListContent { get; set; }
    }
}
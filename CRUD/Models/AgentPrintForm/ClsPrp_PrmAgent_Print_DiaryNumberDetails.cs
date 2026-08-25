using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.AgentPrintForm
{
    public class ClsPrp_PrmAgent_Print_DiaryNumberDetails
    {

        public long AgentRegDiaryNumber_IndexID { get; set; }
        public long AgentRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string AgentRegDiaryNumber_Name { get; set; }
        public string AgentRegDiaryNumber_NameYear { get; set; }

        public string UserID { get; set; }
        public long Agent_ID { get; set; }

        public int othermemdetailCount { get; set; }
        public int documentuploadCount { get; set; }
        public int UTOtherStateRERACount { get; set; }
        public int PaymentCount { get; set; }
        public int AgentDocumentCount { get; set; }

        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        public long zapRelated_Agent_ID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }

        [Display(Name = "Registration Number")]
        public string zapAgent_RegistrationNumber { get; set; }

        public List<ClsPrp_PrmAgent_Print_DiaryNumberDetails> prpongoing { get; set; }

        public ClsPrp_PrmAgent_Print_DiaryNumberDetails()
        {
            prpongoing = new List<ClsPrp_PrmAgent_Print_DiaryNumberDetails>();

        }        
    }
}
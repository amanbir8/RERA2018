using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentDiaryNumber
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

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }

        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }        
        [Display(Name = "District Name")]
        public string Agent_AddressDistrictName { get; set; }
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


        public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentDiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();

        }

        public class PagedResult<ClsPrp_AuthorityDesk_AgentDiaryNumber>
        {
            public List<ClsPrp_AuthorityDesk_AgentDiaryNumber> Items { get; set; } = new List<ClsPrp_AuthorityDesk_AgentDiaryNumber>();
            public int TotalCount { get; set; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails
    {
        public long EventAction_IndexID { get; set; }

        [Display(Name = "Current Status Code")]
        public long EventAction_Code { get; set; }
        public string EventAction_ApplicableFor { get; set; }
        public string EventAction_SubApplicableFor { get; set; }
        public string EventAction_Summary { get; set; }
        [Display(Name = "Current Status Description")]
        public string EventAction_Description { get; set; }
        public string EventAction_Category { get; set; }
        [Display(Name = "Current Status Name")]
        public string EventAction_Aggregate { get; set; }
        public string EventAction_Relationship { get; set; }
        public int Target_ResolutionDuration { get; set; }
        public string Target_ResolutionSummary { get; set; }

        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [Display(Name = "Modify Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails> prpMasterEventAction { get; set; }
        public ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails()
        {
            prpMasterEventAction = new List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_EventActionDetails>();
        } 
         
    }
}
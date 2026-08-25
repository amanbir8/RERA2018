using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectEvent_Master
    {

        public long EventAction_IndexID { get; set; }
        public long EventAction_Code { get; set; }
        public string EventAction_ApplicableFor { get; set; }
        public string EventAction_SubApplicableFor { get; set; }
        public string EventAction_Summary { get; set; }
        public string EventAction_Description { get; set; }
        public string EventAction_Category { get; set; }
        [Display(Name = "Application Action Name")]
        public string EventAction_Aggregate { get; set; }
        public string EventAction_Relationship { get; set; }
        public int Target_ResolutionDuration { get; set; }
        public string Target_ResolutionSummary { get; set; }

        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

    }
}
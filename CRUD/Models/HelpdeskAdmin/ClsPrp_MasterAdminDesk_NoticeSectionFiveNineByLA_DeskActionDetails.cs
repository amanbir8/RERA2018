using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails
    {
        public long DeskAction_IndexID { get; set; }

        [Display(Name = "File Action Code")]
        public long DeskAction_Code { get; set; }
        public string DeskAction_ApplicableFor { get; set; }
        public string DeskAction_SubApplicableFor { get; set; }
        public string DeskAction_Summary { get; set; }
        [Display(Name = "File Action Description")]
        public string DeskAction_Description { get; set; }
        public string DeskAction_Category { get; set; }
        [Display(Name = "File Action Name")]
        public string DeskAction_Aggregate { get; set; }
        public string DeskAction_Relationship { get; set; }
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

        public List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails> prpMasterDeskAction { get; set; }
        public ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails()
        {
            prpMasterDeskAction = new List<ClsPrp_MasterAdminDesk_NoticeSectionFiveNineByLA_DeskActionDetails>();
        } 
         
    }
}
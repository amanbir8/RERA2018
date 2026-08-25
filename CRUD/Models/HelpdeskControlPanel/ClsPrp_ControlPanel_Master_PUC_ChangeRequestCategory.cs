using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory
    {
        public long ChangeRequest_IndexID { get; set; }

        [Display(Name = "Change Request ID")]
        public long ChangeRequest_Code { get; set; }

        public string ChangeRequest_ApplicableFor { get; set; }
        public string ChangeRequest_SubApplicableFor { get; set; }

        [Display(Name = "Change Request Category Name")]
        public string ChangeRequest_Aggregate { get; set; }

        public string ChangeRequest_Description { get; set; }
        public int Target_ResolutionDuration { get; set; }
        public string Target_ResolutionSummary { get; set; }
        public int ChangeRequest_ValidCode { get; set; }
        public int ChangeRequest_IsGroup { get; set; }
        public int ChangeRequest_IsMandatory { get; set; }
        public string A_column { get; set; }

        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory> prpongoing { get; set; }
        public ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory()
        {
            prpongoing = new List<ClsPrp_ControlPanel_Master_PUC_ChangeRequestCategory>();
        }
    }
}
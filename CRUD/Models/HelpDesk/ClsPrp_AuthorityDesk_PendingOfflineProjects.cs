using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_PendingOfflineProjects
    {
        public long OfflineProjects_IndexID { get; set; }
        public long OfflineProjects_ID { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineProjects_IssueDate { get; set; }
        [Display(Name = "Reference Number")]
        public string OfflineProjects_ReferenceNumber { get; set; }
        [Display(Name = "Project District")]
        public string OfflineProjects_DistrictName { get; set; }
        [Display(Name = "Promoter Name")]
        public string OfflineProjects_PromoterName { get; set; }
        [Display(Name = "Project Name")]
        public string OfflineProjects_ProjectName { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string OfflineProjects_RERAregistrationNumber { get; set; }
        [Display(Name = "Type of Project")]
        public string OfflineProjects_TypeofProject { get; set; }
        [Display(Name = "Project Location")]
        public string OfflineProjects_ProjectLocation { get; set; }
        [Display(Name = "Promoter Address")]
        public string OfflineProjects_PromoterAddress { get; set; }
        [Display(Name = "Promoter's Contact Details")]
        public string OfflineProjects_PromoterContactDetails { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "CreatedOn Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineProject_RERAregistrationIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineProject_RERAregistrationValidUptoDate { get; set; }

        public List<ClsPrp_AuthorityDesk_PendingOfflineProjects> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_PendingOfflineProjects()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_PendingOfflineProjects>();

        }        
    }
}
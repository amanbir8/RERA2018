using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormMisc_DiaryNumber
    {
        public long ComplaintMisc_IndexID { get; set; }
        public long ComplaintMisc_ID { get; set; }
        public long ComplaintMisc_Year { get; set; }
        [Display(Name = "Diary Number")]
        public string ComplaintMisc_Code { get; set; }
        public string ComplaintType_MNG { get; set; }
        [Display(Name = "Name of Complainant")]
        public string Complainant_Name { get; set; }
        public string Complainant_EmailAddress { get; set; }
        [Display(Name = "Mobile Number of Complainant")]
        public long Complainant_MobileNumber { get; set; }
        public long Complainant_LandlineNumber { get; set; }
        public string Address_for_Communication { get; set; }
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Project Address")]
        public string Project_Address { get; set; }
        public string Village_Sector_Tehsil_Location_of_Project { get; set; }
        public string Complaint_Information_Details { get; set; }

        public int IsVerificationComplete { get; set; }
        public DateTime? ComplaintVerificationDate { get; set; }
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

        public List<ClsPrp_AuthDesk_FormMisc_DiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthDesk_FormMisc_DiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormMisc_DiaryNumber>();

        }        
    }
}
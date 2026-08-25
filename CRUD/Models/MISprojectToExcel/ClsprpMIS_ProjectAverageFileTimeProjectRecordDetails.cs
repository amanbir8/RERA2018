using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails
    {
        public long IndexCode { get; set; }

        public long Related_Project_ID { get; set; }
        public long Related_Promoter_ID { get; set; }

        [Display(Name = "Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApplicationDate_IdentifiedOn { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Activity Code")]
        public long LastActivity_EventAction_Type { get; set; }
        [Display(Name = "Application Status (Last Action by RERA)")]
        public string LastActivity_EventAction_Aggregate { get; set; }       
        [Display(Name = "Date of Last Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastActivity_EventAction_IdentifiedOn { get; set; }

        [Display(Name = "Date of Application Approved for Registration")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApplicationApprovalDate { get; set; }

        [Display(Name = "No of Days (Application Approved for Registration)")]
        public string RegistrationApproval_Days { get; set; }

        [Display(Name = "No of Days (Last Action by RERA)")]
        public string LastActionbyRERA_Days { get; set; }

        [Display(Name = "No of Days (Application Received)")]
        public string ApplicationRecipt_Days { get; set; }

        [Display(Name = "No of Days (No reply by Promoter)")]
        public string A_column { get; set; }

        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }

        [Required]
        [Display(Name = "Date")]
        public int IsApplicationDateFlag { get; set; }
        [Required]
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }        
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }        
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Required]
        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }
        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails>();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails
    {
        public long IndexCode { get; set; }

        public long Related_Project_ID { get; set; }
        public long Related_Promoter_ID { get; set; }

        [Display(Name = "Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApplicationSubmitted_Date { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }


        [Display(Name = "Activity Code")]
        public long EventAction_Type { get; set; }
        [Display(Name = "Activity's Name")]
        public string EventAction_Aggregate { get; set; }       
        [Display(Name = "Date of Action by RERA")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Number of Days")]
        public string DaysInNumber { get; set; }
        [Display(Name = "Days Range Title")]
        public string DaysRangeLevel_Title { get; set; }        


        public string A_column { get; set; }
        public long B_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? C_column { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_column { get; set; }


        [Required]
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }
        [Required]
        [Display(Name = "Application Action Type")]
        public long ApplicationEventTypeCode { get; set; }
        [Required]
        [Display(Name = "Select Days Range")]
        public int RangeNumberValue { get; set; }
        [Required]
        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }        
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

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

        public List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails>();
        }
        public List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage> FileTime_RangeValue { get; set; }
        public List<Clsprp_Master_ProjectExtensionCompletion_AverageFileIndexEvent> FileIndexEventMaster { get; set; }
        
    }
}
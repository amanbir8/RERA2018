using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectInCompleteRemindersSchedulerEmails
    {

        public long ProjectReminder_IndexID { get; set; }
        public long ProjectReminder_ID { get; set; }
        public long Project_ID { get; set; }
        public long Promoter_ID { get; set; }

        [Display(Name = "Project's Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter's Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_Diary_ApplicationDate { get; set; }

        public long Event_Type { get; set; }
        [Display(Name = "Date of Action")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Event_IdentifiedOnDate { get; set; }

        [Display(Name = "Reminder-I Status")]
        public int ROneFlag { get; set; }
        [Display(Name = "Date of Reminder-I")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateROne { get; set; }

        [Display(Name = "Reminder-II Status")]
        public int RTwoFlag { get; set; }
        [Display(Name = "Date of Reminder-II")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateRTwo { get; set; }

        [Display(Name = "Reminder-III Status")]
        public int RThreeFlag { get; set; }
        [Display(Name = "Date of Reminder-III")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateRThree { get; set; }

        [Display(Name = "Reminder-IV Status")]
        public int RFourFlag { get; set; }
        [Display(Name = "Date of Reminder-IV")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateRFour { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        [Display(Name = "Number of times Application Returns to Promoter as an In-Complete File :")]
        public int C_Column { get; set; }
        [Display(Name = "Date of Application ReSubmitted")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? D_Column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }        


        public List<ClsprpMIS_ProjectInCompleteRemindersSchedulerEmails> prpongoing { get; set; }
        public ClsprpMIS_ProjectInCompleteRemindersSchedulerEmails()
        {
            prpongoing = new List<ClsprpMIS_ProjectInCompleteRemindersSchedulerEmails>();
        }
        
        public List<ClsprpMIS_ProjectInCompleteRemindersSchedulerSMSgateway> prpSchedulerSMSgateway { get; set; }
    }
}
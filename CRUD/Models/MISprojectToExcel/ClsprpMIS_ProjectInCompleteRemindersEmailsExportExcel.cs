using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel
    {
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_Diary_ApplicationDate { get; set; }

        [Display(Name = "Project's Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter's Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Date of Action")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Event_IdentifiedOnDate { get; set; }
        [Display(Name = "Action Title")]
        public string Event_AggregateName { get; set; }

        [Display(Name = "Reminder Type")]
        public string ReminderType { get; set; }

        [Display(Name = "To Emails Address Details")]
        public string EmailsAddressDetails { get; set; }
        [Display(Name = "To Emails Count")]
        public int EmailsAddressCount { get; set; }
        [Display(Name = "Email Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Email_SentDate { get; set; }
        [Display(Name = "Subject")]
        public string Email_TitleSubject { get; set; }

        [Display(Name = "Remarks, if Any")]
        public string Remarks_IfAny { get; set; }     

        public List<ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel> prpongoing { get; set; }
        public ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel()
        {
            prpongoing = new List<ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel>();
        }
    }
}
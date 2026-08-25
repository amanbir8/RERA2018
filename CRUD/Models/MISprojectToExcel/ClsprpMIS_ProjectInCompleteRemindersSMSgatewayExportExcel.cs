using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel
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

        [Display(Name = "To Mobile Number")]
        public string SMSsMainAddress { get; set; }
        [Display(Name = "To Phone Address Details")]
        public string SMSsAddressDetails { get; set; }
        [Display(Name = "To Phones Count")]
        public int SMSsAddressCount { get; set; }
        [Display(Name = "SMS Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SMS_SentDate { get; set; }
        [Display(Name = "Subject")]
        public string SMS_TitleSubject { get; set; }

        [Display(Name = "Remarks, if Any")]
        public string Remarks_IfAny { get; set; }     

        public List<ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel> prpongoing { get; set; }
        public ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel()
        {
            prpongoing = new List<ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel>();
        }
    }
}
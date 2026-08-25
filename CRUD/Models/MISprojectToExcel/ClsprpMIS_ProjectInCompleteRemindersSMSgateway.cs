using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectInCompleteRemindersSMSgateway
    {

        public long ProjectReminderLogSMS_IndexID { get; set; }
        public long ProjectReminderLogSMS_ID { get; set; }
        public long Related_ProjectReminderSMS_IndexID { get; set; }
        public long Related_ProjectReminderSMS_ID { get; set; }
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
        [Display(Name = "Action Title")]
        public string Event_AggregateName { get; set; }

        [Display(Name = "Reminder Type")]
        public string ReminderType { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReminderTargetDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReminderResolutionDate { get; set; }
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
        [AllowHtml]
        [Display(Name = "Message Content")]
        public string SMS_ContentBody { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public int C_Column { get; set; }
        public DateTime? D_Column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }

        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }


        public int ROneFlag { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateROne { get; set; }

        public int RTwoFlag { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateRTwo { get; set; }

        public int RThreeFlag { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateRThree { get; set; }

        public int RFourFlag { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateRFour { get; set; }


        public List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway> prpongoing { get; set; }
        public ClsprpMIS_ProjectInCompleteRemindersSMSgateway()
        {
            prpongoing = new List<ClsprpMIS_ProjectInCompleteRemindersSMSgateway>();
        }
    }
}
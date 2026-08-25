using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MIScomplaintToExcel
{
    public class ClsprpMIS_FormMInCompleteRemindersSchedulerEmails
    {
        public long FormM_Reminder_IndexID { get; set; }
        public long FormM_Reminder_ID { get; set; }
        public long RelatedComplaintFormM_ID { get; set; }        

        [Display(Name = "Complainant's Name")]
        public string Complainant_Name { get; set; }
        [Display(Name = "Respondent's Name")]
        public string Respondent_Name { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public Int64 Complainant_Mobile_Number { get; set; }

        [Display(Name = "Email ID")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Complainant_Email_ID { get; set; }

        [Display(Name = "Diary Number")]
        public string RelatedComplaintFormM_DiaryNumber { get; set; }
        [Display(Name = "Date of Filing")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApplicationDateFormM { get; set; }        


        public long RelatedComplaint_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RelatedComplaint_DiaryNumber { get; set; }


        [Display(Name = "Type of Complaint Form")]
        public string ComplaintType_MN { get; set; }

        [Display(Name = "Is Transfer Case (Yes/No)?")]        
        public Int32 IsTransferCase { get; set; }
        [Display(Name = "Case Transfer Type")]
        public string TransferTypeOption { get; set; }
        [Display(Name = "Case Transfer Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TransferDate { get; set; }

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
        
        public List<ClsprpMIS_FormMInCompleteRemindersSchedulerEmails> prpongoing { get; set; }
        public ClsprpMIS_FormMInCompleteRemindersSchedulerEmails()
        {
            prpongoing = new List<ClsprpMIS_FormMInCompleteRemindersSchedulerEmails>();
        }
        
        public List<ClsprpMIS_FormMInCompleteRemindersSchedulerSMSgateway> prpSchedulerSMSgateway { get; set; }
    }
}
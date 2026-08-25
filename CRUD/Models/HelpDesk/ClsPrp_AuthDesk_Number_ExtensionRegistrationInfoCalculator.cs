using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_Number_ExtensionRegistrationInfoCalculator
    {
        public long ProjectInfoCalculator_IndexID { get; set; }
        public long ProjectInfoCalculator_ID { get; set; }

        public long Related_Project_ID { get; set; }
        public long Related_Promoter_ID { get; set; }

        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Display(Name = "Form-5 Diary Number")]
        public string ExtensionForm_DiaryNumber { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RegistrationNumber_Output { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationIssueDate_Output { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationValidUptoDate_Output { get; set; }

        [Display(Name = "Already generated Registration Number Case")]
        public int IsGeneratedRegistrationNumber { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ExtensionRegistrationNumber_Calc { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtensionRegistrationIssueDate_Calc { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtensionRegistrationValidUptoDate_Calc { get; set; }
       
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }

        public string setNumberAlreadyExisted_Flag { get; set; }

        [Display(Name = "Diary Number")]
        public string lastdisplayProjectDiaryNumber { get; set; }
        [Display(Name = "Form-5 Diary Number")]
        public string lastdisplayFormFiveProjectDiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string lastdisplayProjectName { get; set; }

        [Display(Name = "Registration Number")]
        public string lastdisplayRegistrationNumber { get; set; }
        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? lastdisplayRegistrationIssueDate { get; set; }
        [Display(Name = "Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? lastdisplayRegistrationValidUptoDate { get; set; }

        [Display(Name = "Extension of Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? lastdisplayExtensionRegistrationValidUptoDate { get; set; }

        
        public List<ClsPrp_AuthDesk_Number_ExtensionRegistrationInfoCalculator> prpongoing { get; set; }
        public ClsPrp_AuthDesk_Number_ExtensionRegistrationInfoCalculator()
        {
            prpongoing = new List<ClsPrp_AuthDesk_Number_ExtensionRegistrationInfoCalculator>();
        } 
               
    }
}
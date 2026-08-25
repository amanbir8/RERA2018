using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator
    {
        public long AgentInfoCalculator_IndexID { get; set; }
        public long AgentInfoCalculator_ID { get; set; }

        public long Related_Agent_ID { get; set; }        

        [Display(Name = "Diary Number")]
        public string Agent_DiaryNumber { get; set; }

        [Display(Name = "Real-Estate Agent Name")]
        public string RealEstateAgent_Name { get; set; }

        [Required]
        [Display(Name = "Number Options")]
        public int RegistrationNumberOptions_Input { get; set; }

        [Required]
        [Display(Name = "Type of Real-Estate Agent")]
        public string AgentStateType_Input { get; set; }

        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationIssueDate_Input { get; set; }

        [Required]
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationValidUptoDate_Input { get; set; }

        [Display(Name = "Already generated Registration Number Case")]
        public int IsGeneratedRegistrationNumber { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string prmRegistrationNumber { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? prmRegistrationIssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? prmRegistrationValidUptoDate { get; set; }
       
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }


        public string setPrepared_SequenceNumber { get; set; }
        public string setPrepared_AgentStateType { get; set; }
        public string setPrepared_NumberTypeFlag { get; set; }
        public string setNumberAlreadyExisted_Flag { get; set; }


        [Display(Name = "Diary Number")]
        public string lastdisplayAgentDiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string lastdisplayAgentName { get; set; }

        [Display(Name = "Registration Number")]
        public string lastdisplayAgentRegistrationNumber { get; set; }
        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? lastdisplayAgentRegistrationIssueDate { get; set; }
        [Display(Name = "Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? lastdisplayAgentRegistrationValidUptoDate { get; set; }


        public List<ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator> prpongoing { get; set; }
        public ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator()
        {
            prpongoing = new List<ClsPrp_AuthDesk_Number_AgentRegistrationInfoCalculator>();
        } 
               
    }
}
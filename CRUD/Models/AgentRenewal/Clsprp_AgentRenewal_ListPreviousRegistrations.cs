using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models.Master;
using System.ComponentModel.DataAnnotations;
using CRUD.Models.Promoter;

namespace CRUD.Models.AgentRenewal
{
    public class Clsprp_AgentRenewal_ListPreviousRegistrations
    {
        public long AgentRenewal_ListPreviousRegistration_IndexID { get; set; }
        public long AgentRenewal_ListPreviousRegistration_ID { get; set; }

        // Registration Number
        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        // Agent ID
        public long Agent_ID { get; set; }
        public int AgentType_ID { get; set; }
        public string UserID { get; set; }
        // Agent Renewal ID
        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalAgent_Year { get; set; }
        public int Renewal_OrderSequence { get; set; }
        [Display(Name = "Renewal of Registration (Sequence Number)")]
        public string Renewal_OrderSequence_Name { get; set; }

        // Agent Description
        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }
        [Display(Name = "District Name")]
        public string Agent_AddressDistrictName { get; set; }
        [Display(Name = "Type of Agent")]
        public string Agent_Type { get; set; }

        [Display(Name = "Diary Number")]
        public string RegDiaryNumber_Name { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegDiaryNumber_Application_Date { get; set; }

        // Agent Flag
        public int Is_YesNo_OfflineAgentRegistered_Flag { get; set; }
        public int Is_YesNo_AgentRegistered_Flag { get; set; }
        public int Is_YesNo_RenewalAgentID_Flag { get; set; }
        public int Is_YesNo_RenewalAgentRegistered_Flag { get; set; }
        public int Is_YesNo_ValidforAgentRenewal_Flag { get; set; }
   
        public string A_column { get; set; }
        public string B_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public List<Clsprp_AgentRenewal_ListPreviousRegistrations> AgentRenewalList { get; set; }
        public Clsprp_AgentRenewal_ListPreviousRegistrations()
        {
            AgentRenewalList = new List<Clsprp_AgentRenewal_ListPreviousRegistrations>();
        }
    }
}
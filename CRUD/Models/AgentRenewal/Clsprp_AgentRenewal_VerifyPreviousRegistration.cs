using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models.Master;
using System.ComponentModel.DataAnnotations;
using CRUD.Models.Promoter;

namespace CRUD.Models.AgentRenewal
{
    public class Clsprp_AgentRenewal_VerifyPreviousRegistration
    {
        public long AgentRenewal_VerifyPreviousRegistration_IndexID { get; set; }
        public long AgentRenewal_VerifyPreviousRegistration_ID { get; set; }

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
        [Required]
        public long Agent_ID { get; set; }
        [Required]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }

        [Display(Name = "Diary Number")]
        public string Agent_RegDiaryNumber_Name { get; set; }
        public long Agent_RegDiaryNumber_Year { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RegDiaryNumber_Application_Date { get; set; }

        public long Agent_LDR_RERAnumber_DiaryNumber_ID { get; set; }
        [Required]
        public int Is_YesNo_AgentRegistered_Flag { get; set; }

        // Agent Description
        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }
        [Display(Name = "District Name")]
        public string Agent_AddressDistrictName { get; set; }
        [Display(Name = "Type of Agent")]
        public string Agent_Type { get; set; }

        [Display(Name = "Address Line 1")]
        public string Agent_PlaceOfBussiness_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Agent_PlaceOfBussiness_AddressLine2 { get; set; }
        [Display(Name = "District")]
        public string Agent_PlaceOfBussiness_District { get; set; }
        [Display(Name = "State")]
        public string Agent_PlaceOfBussiness_State { get; set; }
        [Display(Name = "PIN Number")]
        public string Agent_PlaceOfBussiness_PIN { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Agent_Email_Address { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public long Agent_Mobile_PhoneNumber { get; set; }

        [Required]
        public int Is_YesNo_AgentDescription_Flag { get; set; }

        // Agent Renewal ID
        [Required]
        public long Related_RenewalAgent_ID { get; set; }
        [Required]
        public int Related_RenewalAgent_Year { get; set; }
        [Required]
        public int Renewal_OrderSequence { get; set; }
        [Display(Name = "Renewal of Registration (Sequence Number)")]
        public string Renewal_OrderSequence_Name { get; set; }
        [Display(Name = "Diary Number")]
        public string Related_RenewalAgentRegDiaryNumber_Name { get; set; }
        public int Related_RenewalAgentRegDiaryNumber_Year { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Related_RenewalAgentRegDiaryNumber_Application_Date { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RenewalAgentRegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalAgentRegistrationIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalAgentRegistrationRegUptoDate { get; set; }

        public long Agent_LDR_RenewalRERAnumber_DiaryNumber_ID { get; set; }
        [Required]
        public int Is_YesNo_ActiveProvider_Flag { get; set; }
        [Required]
        public int Is_YesNo_RenewalAgentRegistered_Flag { get; set; }

        // Offline Agent Registered Number
        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string OfflineAgentRegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgentRegistrationIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgentRegistrationRegUptoDate { get; set; }

        public long ProfileNewCreated_Agent_ID { get; set; }

        public int Is_YesNo_ProfileNewCreated_Flag { get; set; }
        [Required]
        public int Is_YesNo_OfflineAgentRegistered_Flag { get; set; }


        // Agent Renewal Permission Flag
        [Required]
        [Display(Name = "I Agree")]
        public int Is_YesNo_AgentRenewalPermission_Flag { get; set; }
        [Required]
        public int Is_YesNo_ValidforAgentRenewal_Flag { get; set; }
   
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }

        public List<Clsprp_AgentRenewal_VerifyPreviousRegistration> AgentRenewal { get; set; }
        public Clsprp_AgentRenewal_VerifyPreviousRegistration()
        {
            AgentRenewal = new List<Clsprp_AgentRenewal_VerifyPreviousRegistration>();
        }
    }
}
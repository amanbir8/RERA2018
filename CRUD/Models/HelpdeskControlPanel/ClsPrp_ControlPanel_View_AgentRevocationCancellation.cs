using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpdeskControlPanel
{
    public class ClsPrp_ControlPanel_View_AgentRevocationCancellation
    {
        public long RevokeAgent_RegDiaryNumber_IndexID { get; set; }
        public long RevokeAgent_RegDiaryNumber_ID { get; set; }

        [Display(Name = "Revocation/Cancellation Diary Number")]
        public string RevokeAgent_RegDiaryNumber_Name { get; set; }

        public int RevokeAgent_RegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Agent_ID { get; set; }

        [Required]
        [Display(Name = "Type of Agent")]
        public int Agent_Type { get; set; }

        [Required]
        [Display(Name = "Diary Number")]
        public string AgentRegDiaryNumber_Name { get; set; }

        [Display(Name = "Diary Number (Renewal of Registration)")]
        public string LatestAgentRenewalRegDiaryNumber_Name { get; set; }

        [Required]
        [Display(Name = "Registration Number/ RERA Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Required]
        [Display(Name = "Is Renewal of Registration?")]
        public int IsRenewalRegistration { get; set; }

        public long RenewalAgent_ID { get; set; }
        public int RenewalAgent_Year { get; set; }

        [Display(Name = "Registration Number (Renewal)")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string LatestRenewalRegistrationNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date (Renewal)")]
        public DateTime? LatestRenewalRegistrationIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Upto Date (Renewal)")]
        public DateTime? LatestRenewalRegistrationUptoDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Real Estate Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string AgentName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Real Estate Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string OrganizationName { get; set; }

        [Required]        
        [Display(Name = "Authorized Person Name")]
        [StringLength(250, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string AuthorizedPersonName { get; set; }

        [Required]
        [Display(Name = "Registered Address District")]
        public string AgentRegisteredDistrict { get; set; }

        [Required]
        [Display(Name = "Place of Bussiness Address District")]
        public string AgentBussinessPlaceDistrict { get; set; }

        [Required]
        [Display(Name = "Revocation/Cancellation Details")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Revoke_InfoDetails { get; set; }

        [Required]
        [Display(Name = "Reference Number")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Revoke_ReferenceName { get; set; }

        [Required]
        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Revoke_ReferenceDate { get; set; }

        [Required]
        [Display(Name = "Revocation/Cancellation Category")]
        public string Revoke_Category { get; set; }

        [Required]
        [Display(Name = "Mode of Recipt")]
        public string Revoke_ReciptType { get; set; }

        [Required]
        [Display(Name = "Revocation/Cancellation Reasons")]
        [StringLength(400, MinimumLength = 4)]
        [RegularExpression(@"^[().,& 0-9a-zA-Z''-'-\s]{1,400}$", ErrorMessage = "Special characters are not allowed. Maximum length is 400")]
        [DataType(DataType.MultilineText)]
        public string Revoke_Reasons { get; set; }

        [Display(Name = "Remarks If Any")]
        [DataType(DataType.MultilineText)]
        public string Remarks_IfAny { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsDraftHelpDesk { get; set; }

        [Display(Name = "Is conditional Revocation/Cancellation? (Yes/No)")]
        public int IsDraftEvaluation { get; set; }

        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }        
        
                      
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string RoleAccessFlag { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration_Input { get; set; }


        public long zipRelated_Agent_ID { get; set; }
        public long zipRelated_RenewalAgent_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string zipAgent_DiaryNumber { get; set; }
        [Display(Name = "Latest Renewal Diary Number")]
        public string zipLatestRenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zipAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipAgentLastModifiedOn { get; set; }
        [Display(Name = "Revocation/Cancellation Diary Number")]
        public string zipRevocationCancellation_DiaryNumber { get; set; }
        [Display(Name = "RERA Registration Number")]
        public string zipAgentRegistrationNumberName { get; set; }


        public List<ClsPrp_ControlPanel_View_AgentRevocationCancellation> prpongoing { get; set; }
        public ClsPrp_ControlPanel_View_AgentRevocationCancellation()
        {
            prpongoing = new List<ClsPrp_ControlPanel_View_AgentRevocationCancellation>();
        }

        public List<ClsPrp_DistrictMaster> prpdistrictMaster { get; set; }
    }
}
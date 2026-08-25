using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber
    {
        public long RenewalAgent_RERAnumber_DiaryNumber_IndexID { get; set; }
        public long RenewalAgent_RERAnumber_DiaryNumber_ID { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalOrderSequence { get; set; }
        public int Related_RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public DateTime? Related_RERAnumberIssueDate { get; set; }
        public DateTime? Related_RERAnumberRegUptoDate { get; set; }

        public long RelatedAgentDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RelatedAgentDiaryNumber_Name { get; set; }
        public string RelatedAgentDiaryNumber_NameYear { get; set; }

        public long RelatedRenewalAgentRegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string RelatedRenewalAgentRegDiaryNumber_Name { get; set; }
        public string RelatedRenewalAgentRegDiaryNumber_NameYear { get; set; }

        public string UserID { get; set; }             

        public int OtherMemDetailsCount { get; set; }
        public int DocumentuploadsCount { get; set; }
        public int UTotherStateRERACount { get; set; }
        public int PaymentsCount { get; set; }
        public int AgentDocumentCount { get; set; }

        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public long tbl_RegDiaryNumber_indexID { get; set; }

        public long ReferenceProject_ID { get; set; }
        public string ReferenceProject_Name { get; set; }
        public long ReferencePromoter_ID { get; set; }
        public string ReferencePromoter_Name { get; set; }
        
        public string IsAlreadyRegistration { get; set; }
        [Display(Name = "Existing RERA Registration Number (If Yes)")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ExistingRegistration { get; set; }

        public string Agent_Type { get; set; }   //int(11)


        [Display(Name = "Agent First Name")]
        [StringLength(60, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_FirstName { get; set; }

        [Display(Name = "Agent Last Name")]
        [StringLength(60, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_LastName { get; set; }

        [Display(Name = "Organization Name")]
        public string Organization_Name { get; set; }
        

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BComm_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string BComm_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public int BComm_AddressStateCode { get; set; }
        [Required]
        [Display(Name = "District")]
        public int BComm_AddressDistrictCode { get; set; }
        [Required]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public int BComm_AddressPIN { get; set; }

        public string BComm_AddressStateName { get; set; }        
        public string BComm_AddressDistrictName { get; set; }

        [EmailAddress]        
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string EmailAddress { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }



        [Required]
        [Display(Name = "Authorized Person First Name")]
        [StringLength(80, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_FirstName { get; set; }

        [Required]
        [Display(Name = "Authorized Person Last Name")]
        [StringLength(80, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,80}$", ErrorMessage = "Special characters are not allowed. Maximum length is 80")]
        public string AuthorizedSignatory_LastName { get; set; }


        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedSignatory_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        [StringLength(90, ErrorMessage = "Maximum length is 90")]
        public string AuthorizedSignatory_AddressLine2 { get; set; }

        [Required]
        [Display(Name = "State")]
        public int AuthorizedSignatory_AddressStateCode { get; set; }
        [Required]
        [Display(Name = "District")]
        public int AuthorizedSignatory_AddressDistrictCode { get; set; }
        [Required]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code")]
        public int AuthorizedSignatory_AddressPIN { get; set; }

        public string AuthorizedSignatory_AddressStateName { get; set; }
        public string AuthorizedSignatory_AddressDistrictName { get; set; }


        [EmailAddress]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string AuthorizedSignatory_EmailAddress { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public long AuthorizedSignatory_MobileNumber { get; set; }


        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string Agent_RERAnumberRegistration { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERAnumberIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERAnumberRegUptoDate { get; set; }


        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string LatestRenewalAgent_RERAnumberRegistration { get; set; }
        [Required]
        [Display(Name = "Renewal of Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LatestRenewalAgent_RERAnumberIssueDate { get; set; }
        [Required]
        [Display(Name = "Renewal of Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LatestRenewalAgent_RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string Remarks_IfAny { get; set; }

        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }


        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }        
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        [Required]
        public int IsPublicView { get; set; }
        [Required]
        public int IsCertificateIssued { get; set; }
        public int IsWithdrawn { get; set; }


        public string CreatedBy { get; set; }      
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        [Display(Name = "Real Estate Agent Name")]
        public string Agent_Name { get; set; }        
        [Display(Name = "District Name")]
        public string Agent_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string Agent_RERAregistrationNumber { get; set; }


        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }

        //Display Reference For Issue RERA Number
        public long zapRelated_Agent_ID { get; set; }
        public int zapRelated_AgentType_ID { get; set; }
        public long zapRelated_RenewalAgent_ID { get; set; }
        public int zapRelated_RenewalAgent_SequenceID { get; set; }
        public int zapRelated_RenewalAgent_YearID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapRenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Registration Number")]
        public string zapRenewalAgent_RegistrationNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapRenewalAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapRenewalAgentLastModifiedOn { get; set; }

        public List<ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RenewalAgent_RERAnumber_DiaryNumber>();

        }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
    }
}
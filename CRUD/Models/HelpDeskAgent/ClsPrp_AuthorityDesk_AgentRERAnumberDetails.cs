using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentRERAnumberDetails
    {
        public long Agent_RERAnumber_DiaryNumber_IndexID { get; set; }
        public long Agent_RERAnumber_DiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string AgentRegDiaryNumber_Name { get; set; }
        public string AgentRegDiaryNumber_NameYear { get; set; }

        public long Agent_ID { get; set; }
        public string UserID { get; set; }             

        public int OtherMemDetailsCount { get; set; }
        public int DocumentuploadsCount { get; set; }
        public int UTotherStateRERACount { get; set; }
        public int PaymentsCount { get; set; }
        public int AgentDocumentCount { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string Remarks_IfAny { get; set; }
        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public long tbl_RegDiaryNumber_indexID { get; set; }

        public long Project_ID { get; set; }
        public string Project_Name { get; set; }
        public long Promoter_ID { get; set; }
        public string Promoter_Name { get; set; }
        public string IsAlreadyRegistration { get; set; }
        [Display(Name = "Existing RERA Registration Number (If Yes)")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string ExistingRegistration { get; set; }
        public string Agent_Type { get; set; }   //int(11)
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(60, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z''-'-.\s]{1,60}$", ErrorMessage = "Special characters are not allowed. Maximum length is 60")]
        public string Agent_LastName { get; set; }
        [Display(Name = "Organization Name")]
        public string Organization_Name { get; set; }
        public string BComm_AddressStateCode { get; set; } //int(11)
        public string BComm_AddressDistrictCode { get; set; } //int(11)
        [EmailAddress]        
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string EmailAddress { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAnumberRegistration { get; set; }
        [Required]
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }
        [Required]
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }
                
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        [Required]
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }

        [Required]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
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
          

        public string AgentRERAcert_FilePath { get; set; }
        public string AgentRERAcert_FileName { get; set; }        
        public string AgentRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AgentRERAcert_IssueDate { get; set; }


        //Search Params
        [Required]
        [Display(Name = "Date")]
        public int IsApplicationDateFlag { get; set; }
        [Required]
        [Display(Name = "Mode")]
        public int IsApplicationModeFlag { get; set; }
        [Required]
        [Display(Name = "Type of Agent")]
        public int InputEntry_AgentType { get; set; }
        [Required]
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Required]
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Required]
        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }
        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public string RoleAccessFlag { get; set; }


        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentRERAnumberDetails()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDetails>();
        }
    }
}
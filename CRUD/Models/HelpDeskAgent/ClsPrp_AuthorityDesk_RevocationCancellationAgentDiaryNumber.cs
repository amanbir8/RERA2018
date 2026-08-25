using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber
    {
        public long RevokeAgent_RegDiaryNumber_IndexID { get; set; }
        public long RevokeAgent_RegDiaryNumber_ID { get; set; }

        [Display(Name = "Revocation/Cancellation Diary Number")]
        public string RevokeAgent_RegDiaryNumber_Name { get; set; }

        public int RevokeAgent_RegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Agent_ID { get; set; }

        [Display(Name = "Type of Agent")]
        public int Agent_Type { get; set; }

        [Display(Name = "Diary Number")]
        public string AgentRegDiaryNumber_Name { get; set; }

        [Display(Name = "Diary Number (Renewal of Registration)")]
        public string LatestAgentRenewalRegDiaryNumber_Name { get; set; }

        [Display(Name = "Registration Number/ RERA Number")]
        public string RERAnumberRegistration { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Renewal of Registration?")]
        public int IsRenewalRegistration { get; set; }

        public long RenewalAgent_ID { get; set; }
        public int RenewalAgent_Year { get; set; }

        [Display(Name = "Registration Number (Renewal)")]
        public string LatestRenewalRegistrationNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date (Renewal)")]
        public DateTime? LatestRenewalRegistrationIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Upto Date (Renewal)")]
        public DateTime? LatestRenewalRegistrationUptoDate { get; set; }

        [Display(Name = "Real Estate Name")]
        public string AgentName { get; set; }

        [Display(Name = "Real Estate Name")]
        public string OrganizationName { get; set; }

        [Display(Name = "Authorized Person Name")]
        public string AuthorizedPersonName { get; set; }

        [Display(Name = "Registered Address District")]
        public string AgentRegisteredDistrict { get; set; }

        [Display(Name = "Place of Bussiness Address District")]
        public string AgentBussinessPlaceDistrict { get; set; }

        [Display(Name = "Revocation/Cancellation Details")]
        public string Revoke_InfoDetails { get; set; }

        [Display(Name = "Reference Number")]
        public string Revoke_ReferenceName { get; set; }

        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Revoke_ReferenceDate { get; set; }

        [Display(Name = "Revocation/Cancellation Category")]
        public string Revoke_Category { get; set; }

        [Display(Name = "Mode of Recipt")]
        public string Revoke_ReciptType { get; set; }

        [Display(Name = "Revocation/Cancellation Reasons")]
        public string Revoke_Reasons { get; set; }

        [Display(Name = "Remarks If Any")]
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
        

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AgentApplicationDate { get; set; }

        [Display(Name = "Revoke Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AgentRevokeApplicationDate { get; set; }

        [Display(Name = "Agent Name")]
        public string getAgentName { get; set; }
        [Display(Name = "Agent Name")]
        public string Agent_Name { get; set; }
        [Display(Name = "District Name")]
        public string Agent_BussinessPlaceAddressDistrictName { get; set; }


        [Display(Name = "RERA Number")]
        public string Agent_RERAregistrationNumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERAregistrationIssueDate { get; set; }
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERAregistrationValidUptoDate { get; set; }

        [Display(Name = "Renewal of Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERArenewalregistrationIssueDate { get; set; }
        [Display(Name = "Renewal of Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Agent_RERArenewalregistrationValidUptoDate { get; set; }


        public long EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public string Agent_DiaryNumber { get; set; }
        public string LatestRenewalAgent_DiaryNumber { get; set; }
        public string Revoke_DiaryNumber { get; set; }
        public string EventRERA_RegistrationNumber { get; set; }
        public string EventAction_Summary { get; set; }
        public string EventAction_Description { get; set; }
        public string EventAction_Category { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public string EventAction_Relationship { get; set; }
        public string AssignedTo { get; set; }
        public string EventRemarks_IfAny { get; set; }


        public string AgentRERAcert_FilePath { get; set; }
        public string AgentRERAcert_FileName { get; set; }
        public string AgentRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AgentRERAcert_IssueDate { get; set; }

        public List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RevocationCancellationAgentDiaryNumber>();
        }        
    }
}
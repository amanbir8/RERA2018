using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber
    {
        public long AgentRegRenewal_DiaryNumber_IndexID { get; set; }
        public long AgentRegRenewal_DiaryNumber_ID { get; set; }
        public long RelatedAgent_ID { get; set; }
        public long RelatedRenewalAgent_ID { get; set; }
        public int RelatedRenewalAgent_Year { get; set; }
        public int RenewalOrderSequence { get; set; }
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
        public string ExistingRegistration { get; set; }

        [Display(Name = "Type of Agent")]
        public int Agent_Type { get; set; }

        [Display(Name = "Agent Name")]
        public string Agent_FirstName { get; set; }
        public string Agent_LastName { get; set; }
        [Display(Name = "Organization Name")]
        public string Organization_Name { get; set; }

        [Display(Name = "Address Line1")]
        public string BComm_AddressLine1 { get; set; }
        [Display(Name = "Address Line2")]
        public string BComm_AddressLine2 { get; set; }
        [Display(Name = "State Name")]
        public string BComm_AddressStateCode { get; set; }
        [Display(Name = "District Name")]
        public string BComm_AddressDistrictCode { get; set; }
        [Display(Name = "Pin Code")]
        public string BComm_Address_PIN { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }

        [Display(Name = "Authorized Person Name")]
        public string AuthorizedPerson_FirstName { get; set; }
        public string AuthorizedPerson_LastName { get; set; }

        [Display(Name = "Address Line1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [Display(Name = "Address Line2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }
        [Display(Name = "District Name")]
        public string AuthorizedPerson_District { get; set; }
        [Display(Name = "State Name")]
        public string AuthorizedPerson_State { get; set; }
        [Display(Name = "Pin Code")]
        public string AuthorizedPerson_PIN { get; set; }

        [Display(Name = "Email Address")]
        public string AuthorizedPerson_Email { get; set; }
        [Display(Name = "Mobile Number")]
        public string AuthorizedPerson_Mobile { get; set; }

        [Display(Name = "Registration Number")]
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Renewal of Registration Number")]
        public string RenewalAgentRegistrationNumber { get; set; }

        [Display(Name = "Issue Date (Renewal of Registration)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalAgentRegistrationIssueDate { get; set; }

        [Display(Name = "Valid Upto Date (Renewal of Registration)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalAgentRegistrationRegUptoDate { get; set; }

        [Display(Name = "Remarks, If Any")]
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
        public int IsPublicView { get; set; }
        public int IsConditionAnnexureIssued { get; set; }
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
        
        //Display Reference For Revoke
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


        public List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber> prpongoing { get; set; }
        public ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber()
        {
            prpongoing = new List<ClsPrp_RenewalAuthorityDesk_AgentRenewalRERAnumberDiaryNumber>();
        }        
    }
}
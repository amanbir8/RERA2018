using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails
    {
        public long OfflineAgents_IndexID { get; set; }
        public long OfflineAgents_ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_IssueDate { get; set; }
        public string OfflineAgents_ReferenceNumber { get; set; }

        [Display(Name = "Agent Name/ Organization Name")]
        public string OfflineAgents_AgentName_OrganizationName { get; set; }
        public string OfflineAgents_AgentType { get; set; }
        [Display(Name = "Father's Name and Permanent Address/ Registered Address")]
        public string OfflineAgents_FatherNameWithPermanentAddress_RegisteredAddress { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string OfflineAgents_RERAregistrationNumber { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_RERAregistrationIssueDate { get; set; }
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OfflineAgents_RERAregistrationValidUptoDate { get; set; }

        [Display(Name = "Place of Business Address")]
        public string OfflineAgents_PlaceOfBussinessAddress { get; set; }
        [Display(Name = "District of Business Place")]
        public string OfflineAgents_BusinessPlaceDistrict { get; set; }
        [Display(Name = "Contact Details (Email Address and Mobile Number)")]
        public string OfflineAgents_ContactDetails { get; set; }
        [Display(Name = "Remarks, If Any")]
        public string OfflineAgents_RemarksIfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsPublicView { get; set; }
        public int IsCertificate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentRERAnumberOfflineRegisteredDetails>();
        }
    }
}
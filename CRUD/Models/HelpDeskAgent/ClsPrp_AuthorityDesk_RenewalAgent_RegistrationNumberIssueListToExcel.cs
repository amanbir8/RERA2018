using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel
    {
        [Display(Name = "Diary Number")]
        public string RenewalAgentDiaryNumber_Name { get; set; }
        
        [Display(Name = "Reference Diary Number")]
        public string Related_Agent_DiaryNumber { get; set; }
        [Display(Name = "Registration Number")]
        public string Related_RERAnumberRegistration { get; set; }
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Related_LastRegistrationIssueDate { get; set; }
        [Display(Name = "Registration Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Related_LastRegistrationRegUptoDate { get; set; }

        [Display(Name = "Real Estate Name")]
        public string Agent_Name { get; set; }

        [Display(Name = "Registered Address District")]
        public string Agent_Registered_District { get; set; }

        [Display(Name = "Place of Bussiness Address District")]
        public string Agent_BussinessPlace_District { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }
        
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }

        [Display(Name = "Real Estate Agent Name")]
        public string RenewalAgent_Name { get; set; }
        [Display(Name = "District Name")]
        public string RenewalAgent_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string RenewalAgent_RERAregistrationNumber { get; set; }
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; }


        public long EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public string EventAction_Summary { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public string EventAction_Relationship { get; set; }
        public string AssignedTo { get; set; }
        public string EventRemarks_IfAny { get; set; }

        [Display(Name = "RERA Registration Number")]
        public string RERA_Registration_Number { get; set; } //RERAnumberRegistration
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_IssueDate { get; set; } //RERAnumberIssueDate
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_RegistrationUptoDate { get; set; } //RERAnumberRegUptoDate
        
        public string AgentRERAcert_FilePath { get; set; }
        public string AgentRERAcert_FileName { get; set; }
        public string AgentRERAcert_ReferenceNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AgentRERAcert_IssueDate { get; set; }


        public List<ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RenewalAgent_RegistrationNumberIssueListToExcel>();
        }        
    }
}
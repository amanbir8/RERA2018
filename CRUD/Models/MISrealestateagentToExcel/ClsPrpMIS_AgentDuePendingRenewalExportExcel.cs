using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class ClsPrp_MIS_AgentDuePendingRenewalExportExcel
    {
        [Display(Name = "Agent Diary Number")]
        public string Agent_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Agent_Diary_ApplicationDate { get; set; }

        [Display(Name = "Agent Type")]
        public string Agent_TypeSTR { get; set; }

        [Display(Name = "Realestate Agent Name")]
        public string Agent_Organization_Name { get; set; }

        [Display(Name = "Agent RERA Number")]
        public String Agent_RERA_No { get; set; }
        [Display(Name = "RERA Issue Date")]
        public DateTime Agent_RERA_IssueDate { get; set; }
        [Display(Name = "RERA Valid upto")]
        public DateTime Agent_RERA_ValidDate { get; set; }
        
        [Display(Name = "Address Line-1")]
        public string BusinessPlace_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string BusinessPlace_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public string BusinessPlace_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public string BusinessPlace_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string BusinessPlace_AddressPIN { get; set; }

        [Display(Name = "Address Line-1")]
        public string BComm_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string BComm_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public string BComm_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public string BComm_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string BComm_AddressPIN { get; set; }

        [Display(Name = "Authorized Signatory Name")]
        public string AuthorizedSignatory_Name { get; set; }
        [Display(Name = "Authorized Signatory Middle Name")]
        public string AuthorizedSignatory_MiddleName { get; set; }
        [Display(Name = "Authorized Signatory Last Name")]
        public string AuthorizedSignatory_LastName { get; set; }

        [Display(Name = "Authorized Signatory Mobile Number")]
        public long MobileNumber { get; set; }
        [Display(Name = "Authorized Signatory Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Is Offline")]
        public Int32 Merge_Mode { get; set; }


        public List<ClsPrp_MIS_AgentDuePendingRenewalExportExcel> prpongoing { get; set; }
        public ClsPrp_MIS_AgentDuePendingRenewalExportExcel()
        {
            prpongoing = new List<ClsPrp_MIS_AgentDuePendingRenewalExportExcel>();
        }

    }
}
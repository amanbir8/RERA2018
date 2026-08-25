using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_AgentAddressDirectoryDetails
    {
        [Display(Name = "Agent Diary Number")]
        public string Agent_DiaryNumber { get; set; }
        [Display(Name = "Renewal Agent Diary Number")]
        public string RenewalAgent_DiaryNumber { get; set; }

        [Display(Name = "Application Date")]
        public DateTime? Agent_Diary_ApplicationDate { get; set; }
        [Display(Name = "Application Date")]
        public DateTime? RenewalAgent_Diary_ApplicationDate { get; set; }

        public long Agent_ID { get; set; }
        public long RenewalAgent_ID { get; set; }
        public int Agent_Type { get; set; }
        [Display(Name = "Agent Type")]
        public string Agent_TypeSTR { get; set; }
        
        [Display(Name = "Realestate Agent Name")]
        public string Agent_Organization_Name { get; set; }

        [Display(Name = "Address Line-1")]
        public string P_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string P_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public string P_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public string P_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string P_AddressPIN { get; set; }

        [Display(Name = "Address Line-1")]
        public string RegOffice_AddressLine1 { get; set; }
        [Display(Name = "Address Line-2")]
        public string RegOffice_AddressLine2 { get; set; }
        [Display(Name = "State")]
        public string RegOffice_AddressStateCode { get; set; }
        [Display(Name = "District")]
        public string RegOffice_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string RegOffice_AddressPIN { get; set; }


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
        
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        [Display(Name = "Registration Type Option")]
        public string Agent_RegTypeFlag { get; set; }
        [Display(Name = "RERA Number")]
        public string reranumber { get; set; }

        public List<Clsprp_MIS_AgentAddressDirectoryDetails> prpongoing { get; set; }
        public Clsprp_MIS_AgentAddressDirectoryDetails()
        {
            prpongoing = new List<Clsprp_MIS_AgentAddressDirectoryDetails>();
        }

    }
}
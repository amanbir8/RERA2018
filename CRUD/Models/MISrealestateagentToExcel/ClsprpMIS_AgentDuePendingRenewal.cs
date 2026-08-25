using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_AgentDuePendingRenewal
    {
        [Display(Name = "Agent Diary Number")]
        public string Agent_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Agent_Diary_ApplicationDate { get; set; }

        public long Agent_ID { get; set; }
        public int Agent_Type { get; set; }
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

        [Display(Name = "Is Offline")]
        public Int32 Merge_Mode { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        //start - search parmaters
        public String ApplicationDate { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_ToDate { get; set; }

        [Display(Name = "Select Month")]
        public int EventMonth { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        [Display(Name = "Search Option")]
        public string Application_SearchOptionFlag { get; set; }
        [Display(Name = "Range Option")]
        public string Application_SearchRangeFlag { get; set; }

        [Display(Name = "Type Option")]
        public string Application_SearchTypeFlag { get; set; }
        //end - search parmaters

        public List<Clsprp_MIS_AgentDuePendingRenewal> prpongoing { get; set; }
        public Clsprp_MIS_AgentDuePendingRenewal()
        {
            prpongoing = new List<Clsprp_MIS_AgentDuePendingRenewal>();
        }

    }
}
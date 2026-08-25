using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class ClsprpPanel_RegisteredAgentExportExcel
    {

        [Display(Name = "Agent Diary Number")]
        public string AgentRegDiaryNumber_Name { get; set; }
        [Display(Name = "Renewal Agent Diary Number")]
        public DateTime? AgentDiaryNumberApplication_Date { get; set; }
        [Display(Name = "Application Date")]
        public DateTime? Application_Date { get; set; }
        [Display(Name = "Renewal Application Date")]
        public string AgentName { get; set; }

        [Display(Name = "Realestate Agent Name")]
        public string Agent_AddressDistrictName { get; set; }

        [Display(Name = "Agent Type")]
        public int Agent_Type { get; set; }

        [Display(Name = "Permanent Address Line 1")]
        public string Project_Name { get; set; }
        [Display(Name = "Permanent Address Line 2")]
        public string Agent_FirstName { get; set; }
        [Display(Name = "District")]
        public string Agent_MiddleName { get; set; }
        [Display(Name = "State")]
        public string Agent_LastName { get; set; }        
        [Display(Name = "PIN Code")]
        public string Organization_Name { get; set; }

        [Display(Name = "Registered Office Address Line 2")]
        public string AgentTypeName { get; set; }        
        [Display(Name = "District")]
        public string EmailAddress { get; set; }
        [Display(Name = "State")]
        public long MobileNumber { get; set; }


        [Display(Name = "Place of Bussiness Address Line 1")]
        public string BComm_AddressStateCode { get; set; }
        [Display(Name = "Place of Bussiness Address Line 2")]
        public string BComm_AddressDistrictCode { get; set; }        
        [Display(Name = "District")]
        public string BusinessPlace_District { get; set; }
        [Display(Name = "State")]
        public string ProjectRERAcert_ReferenceNumber { get; set; }
        [Display(Name = "PIN Code")]
        public string BusinessPlace_PIN { get; set; }

        [Display(Name = "Communication Address Line 1")]
        public string BussinessCommunication_AddressLine1 { get; set; }
        [Display(Name = "Communication Address Line 2")]
        public string BussinessCommunication_AddressLine2 { get; set; }        
        [Display(Name = "District")]
        public string BussinessCommunication_District { get; set; }
        [Display(Name = "State")]
        public string BussinessCommunication_State { get; set; }
        [Display(Name = "PIN Code")]
        public string ProjectRERAcert_IssueDate { get; set; }


        [Display(Name = "RERA Number")]
        public string RERAnumberRegistration { get; set; }
        public DateTime? RERAnumberIssueDate { get; set; }
        public DateTime? RERAnumberRegUptoDate { get; set; }

        public List<ClsprpPanel_RegisteredAgentExportExcel> prpongoing { get; set; }
        public ClsprpPanel_RegisteredAgentExportExcel()
        {
            prpongoing = new List<ClsprpPanel_RegisteredAgentExportExcel>();
        }

    }
}
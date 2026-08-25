using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISrealestateagentToExcel
{
    public class Clsprp_MIS_RenewalAgentAddressDirectoryExportExcel
    {
        [Display(Name = "RenewalAgent Diary Number")]
        public string RenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Application Date")]
        public DateTime Application_Date { get; set; }

        [Display(Name = "Realestate Agent Name")]
        public string RealEstateAgent_Name { get; set; }

        [Display(Name = "Agent Type")]
        public string Agent_Type { get; set; }

        [Display(Name = "Permanent Address Line 1")]
        public string Permanent_AddressLine1 { get; set; }
        [Display(Name = "Permanent Address Line 2")]
        public string Permanent_AddressLine2 { get; set; }
        [Display(Name = "District")]
        public string Permanent_District { get; set; }
        [Display(Name = "State")]
        public string Permanent_State { get; set; }        
        [Display(Name = "PIN Code")]
        public string Permanent_PIN { get; set; }

        [Display(Name = "Registered Office Address Line 1")]
        public string RegOffice_AddressLine1 { get; set; }
        [Display(Name = "Registered Office Address Line 2")]
        public string RegOffice_AddressLine2 { get; set; }        
        [Display(Name = "District")]
        public string RegOffice_District { get; set; }
        [Display(Name = "State")]
        public string RegOffice_State { get; set; }
        [Display(Name = "PIN Code")]
        public string RegOffice_PIN { get; set; }


        [Display(Name = "Place of Bussiness Address Line 1")]
        public string BusinessPlace_AddressLine1 { get; set; }
        [Display(Name = "Place of Bussiness Address Line 2")]
        public string BusinessPlace_AddressLine2 { get; set; }        
        [Display(Name = "District")]
        public string BusinessPlace_District { get; set; }
        [Display(Name = "State")]
        public string BusinessPlace_State { get; set; }
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
        public string BussinessCommunication_PIN { get; set; }

        [Display(Name = "Authorized Signatory Name")]
        public string AuthorizedSignatory_Name { get; set; }
        [Display(Name = "Authorized Signatory Middle Name")]
        public string AuthorizedSignatory_MiddleName { get; set; }
        [Display(Name = "Authorized Signatory Last Name")]
        public string AuthorizedSignatory_LastName { get; set; }

        [Display(Name = "Authorized Signatory Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Authorized Signatory Mobile Number")]
        public long MobileNumber { get; set; }

        public List<Clsprp_MIS_RenewalAgentAddressDirectoryExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_RenewalAgentAddressDirectoryExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_RenewalAgentAddressDirectoryExportExcel>();
        }

    }
}
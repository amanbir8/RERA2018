using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAddressDirectoryExportExcel
    {

        // Project Details
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }


        [Display(Name = "Project Address Line1")]
        public string Project_AddressLine1 { get; set; }
        [Display(Name = "Project Address Line2")]
        public string Project_AddressLine2 { get; set; }
        [Display(Name = "Project Address Sub-Division")]
        public string Project_AddressSubDivision { get; set; }
        [Display(Name = "Project Address District")]
        public string Project_AddressDistrict { get; set; }
        [Display(Name = "Project Address State")]
        public string Project_AddressState { get; set; }       
        [Display(Name = "Project Address PIN")]
        public string Project_AddressPIN { get; set; }

        [Display(Name = "Project Potential")]
        public string Project_AddressPotentialZone { get; set; }


        [Display(Name = "Authorized Person First Name")]
        public string AuthorizedPerson_FirstName { get; set; }
        [Display(Name = "Authorized Person Middle Name")]
        public string AuthorizedPerson_MiddleName { get; set; }
        [Display(Name = "Authorized Person Last Name")]
        public string AuthorizedPerson_LastName { get; set; }

        [Display(Name = "Authorized Person Email")]
        [EmailAddress]
        public string AuthorizedPerson_EmailAddress { get; set; }
        [Display(Name = "Authorized Person Mobile Phone")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        [Display(Name = "Authorized Person Address Line 1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [Display(Name = "Authorized Person Address Line 2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }
        [Display(Name = "Authorized Person Address District")]
        public string AuthorizedPerson_AddressDistrict { get; set; }
        [Display(Name = "Authorized Person Address State")]
        public string AuthorizedPerson_AddressState { get; set; }
        [Display(Name = "PIN Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }       

       // Promoter Details
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }

        [Display(Name = "Authorised Signatory Name")]
        public string Promoter_AuthorisedSignatory_Name { get; set; }
        [Display(Name = "Authorised SignatoryMobile Number")]
        public Int64 Promoter_AuthorisedSignatory_MobileNumber { get; set; }
        [Display(Name = "Authorised Signatory Email Id")]
        [EmailAddress]
        public string Promoter_AuthorisedSignatory_Email { get; set; }

        [Display(Name = "Regd Address Line 1")]
        public string Promoter_RegdAddress_Line1 { get; set; }
        [Display(Name = "Regd Address Line 2")]
        public string Promoter_RegdAddress_Line2 { get; set; }
        [Display(Name = "District")]
        public string Promoter_RegdDistrict { get; set; }
        [Display(Name = "State")]
        public string Promoter_RegdState { get; set; }        
        [Display(Name = "Pin Code")]
        public string Promoter_Regd_PIN { get; set; }


        [Display(Name = "Regd Address Line 1")]
        public string Promoter_CommAddress_Line1 { get; set; }
        [Display(Name = "Regd Address Line 2")]
        public string Promoter_CommAddress_Line2 { get; set; }        
        [Display(Name = "District")]
        public string Promoter_CommDistrict { get; set; }
        [Display(Name = "State")]
        public string Promoter_CommState { get; set; }
        [Display(Name = "Pin Code")]
        public string Promoter_Comm_PIN { get; set; }        
        
        public List<Clsprp_MIS_ProjectAddressDirectoryExportExcel> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAddressDirectoryExportExcel()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAddressDirectoryExportExcel>();
        }

    }
}
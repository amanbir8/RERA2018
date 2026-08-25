using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.MISprojectToExcel
{
    public class Clsprp_MIS_ProjectAddressDirectoryDetails
    {

        // Project Details
        [Display(Name = "Project Diary Number")]
        public string ProjectDiaryNumber { get; set; }

        [Display(Name = "Project Registration Index ID")]
        public long ProjectRegistration_IndexID { get; set; }
        [Display(Name = "Project Registration ID")]
        public long ProjectRegistration_ID { get; set; }


        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }


        [Display(Name = "Project Address Line1")]
        public string Project_AddressLine1 { get; set; }
        [Display(Name = "Project Address Line2")]
        public string Project_AddressLine2 { get; set; }
        [Display(Name = "Project Address State")]
        public string Project_AddressStateCode { get; set; }
        [Display(Name = "Project Address District")]
        public string Project_AddressDistrictCode { get; set; }
        [Display(Name = "Project Address Sub-Division")]
        public string Project_AddressSubDivisionCode { get; set; }
        [Display(Name = "Project Address PIN")]
        public string Project_AddressPIN { get; set; }


        [Display(Name = "Project Potential Zone")]
        public string Project_PotentialZoneCode { get; set; }

        
        [Display(Name = "Authorized Person First Name")]
        public string AuthorizedPerson_FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string AuthorizedPerson_MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string AuthorizedPerson_LastName { get; set; }


        [Display(Name = "Address Line 1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }
        [Display(Name = "Select Address State")]
        public string AuthorizedPerson_AddressStateCode { get; set; }
        [Display(Name = "Select Address District")]
        public string AuthorizedPerson_AddressDistrictCode { get; set; }
        [Display(Name = "PIN Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }

        [Display(Name = "Authorized Person Email")]        
        public string AuthorizedPerson_EmailAddress { get; set; }
        [Display(Name = "Authorized Person Mobile Phone")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        [Display(Name = "IsActive")]
        public int IsActive { get; set; }
        [Display(Name = "IsDraft")]
        public int IsDraft { get; set; }
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [Display(Name = "CreatedOn")]
        public System.DateTime CreatedOn { get; set; }
        [Display(Name = "")]
        public string ModifyBy { get; set; }
        [Display(Name = "ModifyOn")]
        public System.DateTime ModifyOn { get; set; }

        //public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        //public List<ClsPrp_SubdivMaster> SubdivMaster { get; set; }      
        //public List<ClsPrp_StateMaster> stateMaster { get; internal set; }

        // Promoter Details

        public Int64 Application_Id { get; set; }

        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }

        
        [Display(Name = "Regd Address Line 1")]        
        public string Promoter_RegdAddress_Line1 { get; set; }
        [Display(Name = "Regd Address Line 2")]        
        public string Promoter_RegdAddress_Line2 { get; set; }        
        [Display(Name = "State")]
        public string Promoter_RegdState { get; set; }        
        [Display(Name = "District")]
        public string Promoter_RegdDistrict { get; set; }        
        [Display(Name = "Pin Code")]        
        public string Promoter_Regd_PIN { get; set; }


        [Display(Name = "Regd Address Line 1")]        
        public string Promoter_CommAddress_Line1 { get; set; }
        [Display(Name = "Regd Address Line 2")]
        public string Promoter_CommAddress_Line2 { get; set; }
        [Display(Name = "State")]
        public string Promoter_CommState { get; set; }
        [Display(Name = "District")]
        public string Promoter_CommDistrict { get; set; }
        [Display(Name = "Pin Code")]        
        public string Promoter_Comm_PIN { get; set; }


        [Display(Name = "Authorised Signatory Name")]
        public string Promoter_AuthorisedSignatory_Name { get; set; }
        [Display(Name = "Authorised Signatory Mobile")]        
        public Int64 Promoter_AuthorisedSignatory_MobileNumber { get; set; }
        [Display(Name = "Authorised Signatory Email Address")]
        public string Promoter_AuthorisedSignatory_Email { get; set; }


        public int Flag { get; set; }
        public string Extra4 { get; set; }

        public List<Clsprp_MIS_ProjectAddressDirectoryDetails> prpongoing { get; set; }
        public Clsprp_MIS_ProjectAddressDirectoryDetails()
        {
            prpongoing = new List<Clsprp_MIS_ProjectAddressDirectoryDetails>();
        }

    }
}
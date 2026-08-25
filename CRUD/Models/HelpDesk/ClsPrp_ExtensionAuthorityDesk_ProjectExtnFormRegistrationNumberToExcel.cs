using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumberToExcel
    {
        [Display(Name = "Diary Number")]
        public string RelatedProjectRegDiaryNumber_Name { get; set; }        
        public DateTime? RelatedProjectRegDiaryNumber_CreatedDate { get; set; }        
        [Display(Name = "Diary Number")]
        public string RelatedExtnRegDiaryNumber_Name { get; set; }        
        public DateTime? RelatedExtnRegDiaryNumber_CreatedDate { get; set; }

        public string IsAlreadyRegistration { get; set; }
        [Display(Name = "Existing RERA Registration Number (If Yes)")]        
        public string ExistingRegistration { get; set; }

        public int PromoterType { get; set; }
        public string PromoterName { get; set; }
        public string PromoterWebLink { get; set; }
        public string PromoterAuthSignFormB { get; set; }

        
        [Display(Name = "Project Name")]       
        public string ProjectName { get; set; }
                        
        [Display(Name = "Project Address Line1")]        
        public string ProjectAddressLine1 { get; set; }
        [Display(Name = "Project Address Line2")]        
        public string ProjectAddressLine2 { get; set; }        
        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }        
        [Display(Name = "Project Address State")]
        public string ProjectAddressState { get; set; }        
        [Display(Name = "Project Address Sub-Division")]
        public string ProjectAddressSubDivision { get; set; }        
        [Display(Name = "Project Address PIN")]        
        public string ProjectAddressPIN { get; set; }
        
        [Display(Name = "Project Potential Zone")]
        public string ProjectPotentialZone { get; set; }
       
        [Display(Name = "Project Website Web Link")]        
        public string ProjectWebLink { get; set; }
        
        [Display(Name = "Authorized Person First Name")]        
        public string AuthorizedPerson_FirstName { get; set; }        
        [Display(Name = "Last Name")]        
        public string AuthorizedPerson_LastName { get; set; }
       
        [Display(Name = "Address Line 1")]        
        public string AuthorizedPerson_AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]        
        public string AuthorizedPerson_AddressLine2 { get; set; }        
        [Display(Name = "Address District")]
        public string AuthorizedPerson_District { get; set; }        
        [Display(Name = "Address State")]
        public string AuthorizedPerson_State { get; set; }        
        [Display(Name = "PIN Code")]        
        public string AuthorizedPerson_PIN { get; set; }        
        [Display(Name = "Authorized Person Email")]
        [EmailAddress]        
        public string AuthorizedPerson_Email { get; set; }        
        [Display(Name = "Authorized Person Mobile Number")]        
        public string AuthorizedPerson_Mobile { get; set; }

                
        [Display(Name = "RERA Registration Number")]        
        public string RERAnumberRegistration { get; set; }        
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }        
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }
                
        [Display(Name = "RERA Registration Number")]        
        public string ExtnRegistrationNumber { get; set; }        
        [Display(Name = "Extension of Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtnRegistrationIssueDate { get; set; }        
        [Display(Name = "Extension of Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtnRegistrationRegUptoDate { get; set; }

        [Display(Name = "Remarks, If Any")]        
        public string RemarksIfAny { get; set; }
        
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }        

        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }
        

        [Display(Name = "Project Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectApplicationDate { get; set; }
        [Display(Name = "Form-E Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectExtensionApplicationDate { get; set; }
                
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }        
        public string EventRemarks_IfAny { get; set; }        

        public List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumberToExcel> prpongoing { get; set; }
        public ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumberToExcel()
        {
            prpongoing = new List<ClsPrp_ExtensionAuthorityDesk_ProjectExtnFormRegistrationNumberToExcel>();
        }        
    }
}
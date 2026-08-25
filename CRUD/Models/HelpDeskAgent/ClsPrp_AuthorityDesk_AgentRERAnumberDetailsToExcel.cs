using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel
    {
        [Display(Name = "Realestate Agent's Diary Number")]
        public string RealestateAgent_DiaryNumber { get; set; } //AgentRegDiaryNumber_Name

        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; } //CreatedOn

        [Display(Name = "Real Estate Agent Name")]
        public string AgentName_OrganizationName { get; set; } //Agent_Name
        [Display(Name = "District Name")]
        public string PlaceOfBussinessAddress_District { get; set; } //Agent_AddressDistrictName
        [Display(Name = "Mobile Number")]
        public long Mobile_Number { get; set; } //MobileNumber
        [Display(Name = "Email Address")]
        public string Email_Address { get; set; } //EmailAddress


        [Display(Name = "RERA Registration Number")]
        public string RERA_Registration_Number { get; set; } //RERAnumberRegistration
        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_IssueDate { get; set; } //RERAnumberIssueDate
        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERA_Number_RegistrationUptoDate { get; set; } //RERAnumberRegUptoDate

        [Display(Name = "Status")]
        public string Status { get; set; } //EventAction_Aggregate
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Status_Date { get; set; } //EventAction_IdentifiedOn

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentRERAnumberDetailsToExcel>();
        }
    }
}
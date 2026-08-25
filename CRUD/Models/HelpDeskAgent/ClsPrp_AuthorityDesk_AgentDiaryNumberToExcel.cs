using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel
    {
        [Display(Name = "Real Estate Agent Diary Number")]
        public string RealEstateAgent_DiaryNumber { get; set; } //AgentRegDiaryNumber_Name
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; } //CreatedOn

        [Display(Name = "Real Estate Agent Name")]
        public string AgentName_OrganizationName { get; set; } //Agent_Name
        [Display(Name = "District Name")]
        public string PlaceOfBussinessAddress_District { get; set; } //Agent_AddressDistrictName

        [Display(Name = "Status")]
        public string Status { get; set; } //EventAction_Aggregate
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Status_Date { get; set; } //EventAction_IdentifiedOn

        public List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentDiaryNumberToExcel>();
        }        
    }
}
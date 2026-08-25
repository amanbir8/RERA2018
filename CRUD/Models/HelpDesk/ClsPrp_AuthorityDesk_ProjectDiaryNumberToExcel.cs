using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel
    {
        [Display(Name = "Project Diary Number")]
        public string Project_DiaryNumber { get; set; } //PromoterRegDiaryNumber_Name
        [Display(Name = "Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Application_Date { get; set; } //CreatedOn

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "District Name")]
        public string ProjectAddress_District { get; set; } //Project_AddressDistrictName
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }

        public long ProjectCost{ get; set; }
        
        [Display(Name = "Status")]
        public string Status { get; set; } //EventAction_Aggregate
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Status_Date { get; set; } //EventAction_IdentifiedOn

        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel>();

        }        
    }
}
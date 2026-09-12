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



        #region  NEW FIELDS ADDITION

        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }  //ok

        [Display(Name = "Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }   //ok

        [Display(Name = "Valid Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ValidUpToDate { get; set; }   //ok

        [Display(Name = "Project Completion Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Project_CompletionDate { get; set; }   //ok

        [Display(Name = "Promoter Address Line-1")]
        public string Promoter_Address_Line1 { get; set; }    //ok

        [Display(Name = "Promoter Address Line-2")]
        public string Promoter_Address_Line2 { get; set; }    //ok

        [Display(Name = "Promoter Address District")]
        public string Promoter_Address_District { get; set; }    //ok

        [Display(Name = "Promoter Address State")]
        public string Promoter_Address_State { get; set; }    //ok

        [Display(Name = "Promoter Address Pin")]
        public string Promoter_Address_Pin { get; set; }    //ok

        [Display(Name = "Type Of Organization")]
        public string Type_of_Organization { get; set; }    //ok

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }    //ok

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNumber { get; set; }    //ok

        [Display(Name = "Project Address Line-1")]
        public string Project_Address_Line1 { get; set; }    //ok

        [Display(Name = "Project Address Line-2")]
        public string Project_Address_Line2 { get; set; }    //ok

        [Display(Name = "Project Address State")]
        public string Project_Address_State { get; set; }    //ok

        [Display(Name = "Project Address Pin")]
        public string Project_Address_Pin { get; set; }    //ok

        [Display(Name = "Project Address Sub-Division")]
        public string Project_Address_SubDivision { get; set; }    //ok

        [Display(Name = "Type of Project")]
        public string Type_of_Project { get; set; }    //ok

        [Display(Name = "Type(Display)")]
        public string Type_Display { get; set; }    //ok

        [Display(Name = "Total Area(sqr mtr)")]
        public long Total_Area { get; set; }    //ok

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }    //ok

        [Display(Name = "Special Bank Account Number")]
        public string Special_Bank_Account_Number { get; set; }    //ok

        [Display(Name = "Contruction Type")]
        public string Contruction_Type { get; set; }    //ok

        [Display(Name = "Inventory Type")]
        public string Inventory_Type { get; set; }    //ok

        public string Column_A { get; set; }
        public string Column_B { get; set; }
        public string Column_C { get; set; }
        public string Column_D { get; set; }
        public string Column_E { get; set; }

        #endregion


        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumberToExcel>();

        }        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectDiaryNumber
    {
        public long Project_RegDiaryNumber_IndexID { get; set; }
        public long Project_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }    //ok
        public string PromoterRegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public int LandDetailsCount { get; set; }
        public long ProjectCost { get; set; }    //ok
        public int KhasraAreaDetailsCount { get; set; }
        public int LitigationsCount { get; set; }
        public int ApprovalDetailsCount { get; set; }
        public int PaymentDetailsCount { get; set; }
        public int SpecialBankAccountDetailsCount { get; set; }
        public int ProjectDocumentCount { get; set; }
        public string IsRegistration { get; set; }
        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Remarks_IfAny { get; set; }    //ok
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }   //ok
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }  //ok
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }    //ok
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }  //ok
        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }  //ok

        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }    //ok
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }    //ok
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }

        //Check-list Flag-Code
        public string CLflag1 { get; set; }
        public string CLflag2 { get; set; }
        public string CLflag3 { get; set; }
        public string CLflag4 { get; set; }
        public string CLflag5 { get; set; }
        public string CLflag6 { get; set; }


        #region  NEW FIELDS ADDITION

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
        public string Email{ get; set; }    //ok

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
        public string Project_Address_SubDivision{ get; set; }    //ok

        [Display(Name = "Type of Project")]
        public string Type_of_Project { get; set; }    //ok

        [Display(Name = "Type(Display)")]
        public string Type_Display{ get; set; }    //ok

        [Display(Name = "Total Area(sqr mtr)")]
        public long Total_Area{ get; set; }    //ok

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }    //ok

        [Display(Name = "Special Bank Account Number")]
        public string Special_Bank_Account_Number { get; set; }    //ok

        [Display(Name = "Contruction Type")]
        public string Contruction_Type{ get; set; }    //ok

        [Display(Name = "Inventory Type")]
        public string Inventory_Type{ get; set; }    //ok


        public string Column_A { get; set; }
        public string Column_B { get; set; }
        public string Column_C { get; set; }
        public string Column_D { get; set; }
        public string Column_E { get; set; }

        #endregion


        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectDiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

        }        
    }
}
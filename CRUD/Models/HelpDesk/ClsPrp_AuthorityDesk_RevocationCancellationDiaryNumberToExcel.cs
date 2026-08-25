using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_RevocationCancellationDiaryNumberToExcel
    {
        [Display(Name = "Revocation/Cancellation Diary Number")]
        public string Revoke_RegDiaryNumber_Name { get; set; }

        [Display(Name = "Project Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }

        [Display(Name = "Extension of Registration Diary Number")]
        public string ExtnRegDiaryNumber_Name { get; set; }

        [Display(Name = "Registration Number/ RERA Number")]
        public string RERAnumberRegistration { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Issue Date")]
        public DateTime? RERAnumberIssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Valid Upto Date")]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Is Extension of Registration of Project?")]
        public int IsExtensionRegistration { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extension of Registration Upto Date")]
        public DateTime? RERAnumberExtensionRegUptoDate { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Promoter Name")]
        public string PromoterName { get; set; }

        [Display(Name = "Project Address District")]
        public string ProjectAddressDistrict { get; set; }

        [Display(Name = "Project Address District")]
        public string DName { get; set; }

        [Display(Name = "Type of Project")]
        public string ProjectType { get; set; }

        [Display(Name = "Revocation/Cancellation Details")]
        public string Revoke_InfoDetails { get; set; }

        [Display(Name = "Reference Number")]
        public string Revoke_ReferenceName { get; set; }

        [Display(Name = "Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Revoke_ReferenceDate { get; set; }

        [Display(Name = "Revocation/Cancellation Category")]
        public string Revoke_Category { get; set; }

        [Display(Name = "Mode of Recipt")]
        public string Revoke_ReciptType { get; set; }

        [Display(Name = "Revocation/Cancellation Reasons")]
        public string Revoke_Reasons { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }
        
        [Display(Name = "Is conditional Revocation/Cancellation? (Yes/No)")]
        public int IsDraftEvaluation { get; set; }

        [Display(Name = "Project Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectApplicationDate { get; set; }

        [Display(Name = "Revoke Application Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectRevokeApplicationDate { get; set; }


        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }

        public long EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        public string EventAction_IdentifiedBy { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        public string Promoter_DiaryNumber { get; set; }
        public string Project_DiaryNumber { get; set; }
        public string Revoke_DiaryNumber { get; set; }
        public string RERA_RegistrationNumber { get; set; }
        public string EventAction_Summary { get; set; }
        public string EventAction_Description { get; set; }
        public string EventAction_Category { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public string EventAction_Relationship { get; set; }
        public string AssignedTo { get; set; }
        public string EventRemarks_IfAny { get; set; } 
                      

        public List<ClsPrp_AuthorityDesk_RevocationCancellationDiaryNumberToExcel> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_RevocationCancellationDiaryNumberToExcel()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_RevocationCancellationDiaryNumberToExcel>();
        }        
    }
}
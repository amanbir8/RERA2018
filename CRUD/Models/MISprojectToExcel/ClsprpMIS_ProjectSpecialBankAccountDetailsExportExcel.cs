using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using CRUD.Models.Master;

namespace CRUD.Models.MISprojectToExcel
{
    public class ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel
    {
        [Display(Name = "RERA Registration Number")]
        public string RERAnumberRegistration { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberIssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAnumberRegUptoDate { get; set; }

        [Display(Name = "Project's Diary Number")]
        public string ProjectRegDiaryNumber_Name { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }

        [Display(Name = "Branch Name")]
        public string Branch_Name { get; set; }

        [Display(Name = "Bank Account Number")]
        public string Bank_AccountNumber { get; set; }

        [Display(Name = "Bank IFSC Code")]
        public string Bank_IFSC_Code { get; set; }

        [Display(Name = "Address Line 1")]
        public string Bank_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Bank_AddressLine2 { get; set; }

        [Display(Name = "State")]
        public string Bank_AddressStateCode { get; set; }

        [Display(Name = "District")]
        public string Bank_AddressDistrictCode { get; set; }

        [Display(Name = "PIN Code")]
        public string Bank_AddressPIN { get; set; }

        public string ImageCancelledCheque_FileName { get; set; }
        [Display(Name = "Cancelled Cheque")]
        public string ImageCancelledCheque_FilePath { get; set; }

        [Display(Name = "Remarks, If Any")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Acount Holder Name")]
        public string AcountHolder_Name { get; set; }

        //Additional : Special Bank Account
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
       
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_FormDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Account_ToDate { get; set; }

        [Display(Name = "Is Annexure?")]
        public int IsConditionAnnexure { get; set; }
        [Display(Name = "Is Public View?")]
        public int IsPublicView { get; set; }

        [Display(Name = "Is Registration/History?")]
        public string IsRegistrationHistory { get; set; }
        //Properties : Special Bank Account

        public List<ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel> prpongoing { get; set; }
        public ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel()
        {
            prpongoing = new List<ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel>();
        }
    }
}
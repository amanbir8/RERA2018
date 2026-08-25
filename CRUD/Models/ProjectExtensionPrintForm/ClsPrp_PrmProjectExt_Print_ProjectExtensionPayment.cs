using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectExtPrint
{
    public class ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment
    {
        public long ProjectPayment_IndexID { get; set; }
        public long ProjectPayment_ID { get; set; }

        [Display(Name = "Project Name")]
        public long ProjectPaymentRelated_ProjectRegistration_ID { get; set; }

        [Display(Name = "Payment Type")]
        public int ProjectPayment_TitleCode { get; set; }
        [Display(Name = "Payment Type Title")]
        public string ProjectPayment_TitleName { get; set; }

        [Display(Name = "Fee Amount (in rupees)")]
        public decimal Registration_Fee { get; set; }
        [Display(Name = "Annual web-portal Convenience Fee (in rupees)")]
        public decimal Other_Fee { get; set; }

        [Display(Name = "Payment Mode")]
        public string Payment_Mode { get; set; }

        [Display(Name = "Date of Payment for Extension Fees")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Payment_RegistrationFee { get; set; }

        [Display(Name = "Bank Charges (in rupees)")]
        public decimal Bank_Charges { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }
        [Display(Name = "Branch Name")]
        public string Branch_Name { get; set; }

        [Display(Name = "DD/Bankers Cheque Number")]
        public long DD_BankersCheque_Number { get; set; }
        [Display(Name = "DD/Bankers Cheque Amount (in rupees)")]
        public decimal DD_BankersCheque_Amount { get; set; }

        public string ImageDDorBankersCheque_FileName { get; set; }
        [Display(Name = "DD/Bankers Cheque")]
        public string ImageDDorBankersCheque_FilePath { get; set; }

        [Display(Name = "Remarks (if Any)")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Branch Address")]
        public string A_column { get; set; }
        public string B_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Form-E Diary Number")]
        public string zipProjectExtension_DiaryNumber { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectExtensionLastModifiedOn { get; set; }
        [Display(Name = "Project District Name")]
        public string zipProjectDistrictName { get; set; }
        [Display(Name = "Promoter Name")]
        public string zipPromoterName { get; set; }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment> prpongoing { get; set; }
        public ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment()
        {
            prpongoing = new List<ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment>();
        }

        public List<ClsPrp_PrmProjectExt_Print_ProjectExtensionDiaryNumberDetails> prpProjectExtFormDiaryNumberDetails { get; set; }
    }
}
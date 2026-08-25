using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_CauseListForWeeklyCalender
    {

        public long CauseListWeeklyCalender_IndexID { get; set; }
        public long CauseListWeeklyCalender_ID { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int CasueListOneFlag { get; set; }
        [Required]
        [Display(Name = "(1) Date of Cause List")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CauseListOneDate { get; set; }
        [Required]
        [Display(Name = "Day of Cause List")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string CauseListOneDay { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int CasueListTwoFlag { get; set; }
        [Required]
        [Display(Name = "(2) Date of Cause List")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CauseListTwoDate { get; set; }
        [Required]
        [Display(Name = "Day of Cause List")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string CauseListTwoDay { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int CasueListThreeFlag { get; set; }
        [Required]
        [Display(Name = "(3) Date of Cause List")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CauseListThreeDate { get; set; }
        [Required]
        [Display(Name = "Day of Cause List")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string CauseListThreeDay { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int CasueListFourFlag { get; set; }
        [Required]
        [Display(Name = "(4) Date of Cause List")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CauseListFourDate { get; set; }
        [Required]
        [Display(Name = "Day of Cause List")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string CauseListFourDay { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int CasueListFiveFlag { get; set; }
        [Required]
        [Display(Name = "(5) Date of Cause List")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CauseListFiveDate { get; set; }
        [Required]
        [Display(Name = "Day of Cause List")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        public string CauseListFiveDay { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Remarks, If Any")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string RemarksIfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftMember { get; set; }
        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        public List<ClsPrp_AdminDesk_CauseListForWeeklyCalender> prpCauseListForWeeklyCalender { get; set; }
        public ClsPrp_AdminDesk_CauseListForWeeklyCalender()
        {
            prpCauseListForWeeklyCalender = new List<ClsPrp_AdminDesk_CauseListForWeeklyCalender>();
        } 
         
    }
}
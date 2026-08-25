using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_CauseListForThreeOne
    {
        public long CauseListFormMN_IndexID { get; set; }
        public long CauseListFormMN_ID { get; set; }

        [Required]
        [Display(Name = "Date of Cause List")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CauseListDate { get; set; }

        [Required]
        [Display(Name = "Day of Cause List")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]        
        public string CauseListDay { get; set; }

        public string ViewCauseListFormMN_BaseUrl { get; set; }
        public string ViewCauseListFormMN_FilePath { get; set; }
        [Display(Name = "Cause List Document")]
        public string ViewCauseListFormMN_FileName { get; set; }
        public string ViewCauseListFormMN_FileType { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Remarks, If Any")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
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


        public List<ClsPrp_AdminDesk_CauseListForThreeOne> prpCauseListForThreeOne { get; set; }
        public ClsPrp_AdminDesk_CauseListForThreeOne()
        {
            prpCauseListForThreeOne = new List<ClsPrp_AdminDesk_CauseListForThreeOne>();
        } 
         
    }
}
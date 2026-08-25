using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_OrderJudgementByAuthority
    {

        public long OrderJudgementByAuthority_IndexID { get; set; }
        public long OrderJudgementByAuthority_ID { get; set; }

        public int SerialOrderNumber { get; set; }

        [Required]
        [Display(Name = "Complaint Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string ComplaintNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Complainant Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ComplainantName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Respondent Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string RespondentName { get; set; }

        [Required]
        [Display(Name = "Date of Decision")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Decision { get; set; }

        public string ViewJugdement_BaseUrl { get; set; }
        public string ViewJugdement_FilePath { get; set; }

        [Display(Name = "Order/ Jugdement Document")]
        public string ViewJugdement_FileName { get; set; }
        public string ViewJugdement_FileType { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }

        [Required]
        [Display(Name = "Offline/ Web-portal registered (Yes/No)")]
        public int IsDraftMember { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


        public List<ClsPrp_AdminDesk_OrderJudgementByAuthority> prpOrderJudgementByAuthority { get; set; }
        public ClsPrp_AdminDesk_OrderJudgementByAuthority()
        {
            prpOrderJudgementByAuthority = new List<ClsPrp_AdminDesk_OrderJudgementByAuthority>();
        } 
         
    }
}
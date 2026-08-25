using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_SpotLight
    {

        public long SpotLight_IndexID { get; set; }
        public long SpotLight_ID { get; set; }
        public string SpotLight_LanguageFlag { get; set; }

        [Required]
        [Display(Name = "Is higher priority spot-light news? (Yes/No)")]
        public int SpotLight_PriorityFlag { get; set; }

        [Required]
        [Display(Name = "Date of Issue")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SpotLight_IssueDate { get; set; }

        [Required]
        [Display(Name = "Reference Number (If Any)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string SpotLight_ReferenceNumber { get; set; }

        [Required]
        [Display(Name = "Category")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string SpotLight_Category { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Title")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string SpotLight_Title { get; set; }

        [Required]
        [Display(Name = "Category (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string CulturePunjabi_SpotLight_Category { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Title (in Punjabi)")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string CulturePunjabi_SpotLight_Title { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }

        public int IsActive { get; set; }
        [Required]
        [Display(Name = "Public View (Yes/No)")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        public List<ClsPrp_AdminDesk_SpotLight> prpSpotLight { get; set; }
        public ClsPrp_AdminDesk_SpotLight()
        {
            prpSpotLight = new List<ClsPrp_AdminDesk_SpotLight>();
        } 
         
    }
}
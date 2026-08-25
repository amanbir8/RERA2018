using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_LatestNews
    {
        public long LatestNews_IndexID { get; set; }
        public long LatestNews_ID { get; set; }
        public string LatestNews_LanguageFlag { get; set; }

        [Required]
        [Display(Name = "Is higher priority news? (Yes/No)")]
        public int LatestNews_PriorityFlag { get; set; }

        [Required]
        [Display(Name = "Date of Issue")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LatestNews_IssueDate { get; set; }

        [Required]
        [Display(Name = "Reference Number (If Any)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string LatestNews_ReferenceNumber { get; set; }


        [Required]
        [Display(Name = "Category")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string LatestNews_Category { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Title")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string LatestNews_Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string LatestNews_Description { get; set; }
        public string LatestNews_RelatedTo_IfAny { get; set; }


        [Required]
        [Display(Name = "Category (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string CulturePunjabi_LatestNews_Category { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Title (in Punjabi)")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string CulturePunjabi_LatestNews_Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description (in Punjabi)")]
        [StringLength(500, ErrorMessage = "Maximum length is 500")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string CulturePunjabi_LatestNews_Description { get; set; }
        public string CulturePunjabi_LatestNews_RelatedTo_IfAny { get; set; }

        [Required]
        [Display(Name = "Is hyperlink or PDF file? (Yes/No)")]
        public int IsHyperlinkorFileDirectoryPath { get; set; }
        
        public string LatestNews_BaseUrl { get; set; }
        [Display(Name = "Document/File Path")]
        public string LatestNews_Url { get; set; }
        [Display(Name = "Document/File Name")]
        public string LatestNews_ExtraUrl { get; set; }


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
        
        public List<ClsPrp_AdminDesk_LatestNews> prpLatestNews { get; set; }
        public ClsPrp_AdminDesk_LatestNews()
        {
            prpLatestNews = new List<ClsPrp_AdminDesk_LatestNews>();
        } 
         
    }
}
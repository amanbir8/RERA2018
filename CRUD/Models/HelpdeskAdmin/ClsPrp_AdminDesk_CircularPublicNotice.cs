using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_CircularPublicNotice
    {

        public long CircularPublicNotice_IndexID { get; set; }
        public long CircularPublicNotice_ID { get; set; }        
        public string CircularPublicNotice_LanguageFlag { get; set; }

        [Required]
        [Display(Name = "Circular/Notice Number")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Circular_Number { get; set; }

        [Required]
        [Display(Name = "Date of Issue")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Circular_IssueDate { get; set; }

        [Required]
        [Display(Name = "Circular/Notice Category")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Circular_Category { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Circular/Notice Title")]
        [StringLength(300, ErrorMessage = "Maximum length is 300")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Circular_Title { get; set; }

        [Display(Name = "Circular/Notice Category (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string CulturePunjabi_Circular_Category { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Circular/Notice Title (in Punjabi)")]
        [StringLength(300, ErrorMessage = "Maximum length is 300")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string CulturePunjabi_Circular_Title { get; set; }

        public string Circular_BaseUrl { get; set; }
        public string Circular_FilePath { get; set; }
        [Display(Name = "Circular/Public Notice Document")]
        public string Circular_FileName { get; set; }
        public string Circular_FileType { get; set; }

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


        public List<ClsPrp_AdminDesk_CircularPublicNotice> prpCircularPublicNotice { get; set; }
        public ClsPrp_AdminDesk_CircularPublicNotice()
        {
            prpCircularPublicNotice = new List<ClsPrp_AdminDesk_CircularPublicNotice>();
        } 
         
    }
}
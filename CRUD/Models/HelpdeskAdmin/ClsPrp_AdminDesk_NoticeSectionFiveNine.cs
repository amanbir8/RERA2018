using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_NoticeSectionFiveNine
    {

        public long NoticesSectionFiveNine_IndexID { get; set; }
        public long NoticesSectionFiveNine_ID { get; set; }
        public int SerialOrderNumber { get; set; }

        [Required]
        [Display(Name = "District/Town Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string DistrictTown_InfoName { get; set; }

        [Display(Name = "District/Town Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string DistrictTown_InfoCode { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Notice/File Number")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string NoticeFile_NumberDetails { get; set; }

        [Required]
        [Display(Name = "Notice Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NoticeDate { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string PromoterName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Promoter Name with Address Details")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string PromoterNameWithAddressDetails { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name")]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Name with Address Details")]
        [StringLength(350, ErrorMessage = "Maximum length is 350")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string ProjectNameWithAddressDetails { get; set; }

        [Display(Name = "Current Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CurrentStatusDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Current Status Remarks, If Any")]
        [StringLength(400, ErrorMessage = "Maximum length is 400")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string CurrentStatusWithRemarks { get; set; }

        [Display(Name = "Order Date/ Hearing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Order/ Hearing Remarks, If Any")]
        [StringLength(400, ErrorMessage = "Maximum length is 400")]
        ////[RegularExpression(@"^[a-zA-Z''-'-.\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string OrderDateWithRemarksIfAny { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
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


        public List<ClsPrp_AdminDesk_NoticeSectionFiveNine> prpNoticeSectionFiveNine { get; set; }
        public ClsPrp_AdminDesk_NoticeSectionFiveNine()
        {
            prpNoticeSectionFiveNine = new List<ClsPrp_AdminDesk_NoticeSectionFiveNine>();
        } 
         
    }
}
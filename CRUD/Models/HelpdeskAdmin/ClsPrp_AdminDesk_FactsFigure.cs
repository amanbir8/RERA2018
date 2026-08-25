using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Models.HelpdeskAdmin
{
    public class ClsPrp_AdminDesk_FactsFigure
    {
        public long FactsFigure_IndexID { get; set; }
        public long FactsFigure_ID { get; set; }
        public string FactsFigure_LanguageFlag { get; set; }

        [Required(ErrorMessage = "Number of Registered Projects is required.")]
        [Display(Name = "Number of Registered Projects")]
        [Range(0, 50000)]
        public int Number_RegisteredProjects { get; set; }

        [Required(ErrorMessage = "Number of Registered Real-Estate Agents is required.")]
        [Display(Name = "Number of Registered Real-Estate Agents")]
        [Range(0, 50000)]
        public int Number_RegisteredAgents { get; set; }

        [Required(ErrorMessage = "Number of Disposed Complaints is required.")]
        [Display(Name = "Number of Disposed Complaints")]
        [Range(0, 50000)]
        public int Number_DisposedComplaints { get; set; }

        [Required(ErrorMessage = "Number of Pending Projects is required.")]
        [Display(Name = "Number of Pending Projects")]
        [Range(0, 50000)]
        public int Number_PendingProjects { get; set; }


        [Display(Name = "Registered Projects Title")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Title_RegisteredProjects { get; set; }

        [Display(Name = "Registered Real-Estate Agents Title")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Title_RegisteredAgents { get; set; }

        [Display(Name = "Disposed Complaints Title")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Title_DisposedComplaints { get; set; }

        [Display(Name = "Pending Projects Title")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Title_PendingProjects { get; set; }


        [Display(Name = "Registered Projects Title (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string CulturePunjabi_Title_RegisteredProjects { get; set; }

        [Display(Name = "Registered Real-Estate Agents Title (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string CulturePunjabi_Title_RegisteredAgents { get; set; }

        [Display(Name = "Disposed Complaints Title (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string CulturePunjabi_Title_DisposedComplaints { get; set; }

        [Display(Name = "Pending Projects Title (in Punjabi)")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string CulturePunjabi_Title_PendingProjects { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }

        public int IsActive { get; set; }

        [Required]
        [Display(Name = "Public View (Yes/No)")]
        //[RegularExpression(@"^([0-9]{2})$", ErrorMessage = "Invalid public view field.")]
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        [Display(Name = "Date of Issue")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }


        public List<ClsPrp_AdminDesk_FactsFigure> prpFactsFigure { get; set; }
        public ClsPrp_AdminDesk_FactsFigure()
        {
            prpFactsFigure = new List<ClsPrp_AdminDesk_FactsFigure>();
        } 
         
    }
}
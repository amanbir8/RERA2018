using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Promoter
{
    public class ClsPrp_OngoingProjectLFiveYears
    {
        public int Id { get; set; }
        public Int64 Application_id { get; set; }

        public Int64 Promoter_Experience_ID { get; set; }
        
        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Project Name is required.")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string Projectname { get; set; }

        [Display(Name = "Project Type")]
        [Required(ErrorMessage = "Project Type is required.")]
        public string ProjectType { get; set; }

        
        [Display(Name = "Project Status")]
        [Required(ErrorMessage = "Project Status is required.")]
        public string ProjectStatus { get; set; }

        
        [Display(Name = "Area Constructed under the Project (Sqr mtr)")]
        [Required(ErrorMessage = "Area Constructed under the Project (Sqr mtr) is required.")]
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Invalid Area; Maximum Four Decimal Points.")]
        [Range(0.0001, 999999999999.9999)]
        public double AreaConUProject { get; set; }

        [Display(Name = "Project Start Date")]
        [Required(ErrorMessage = "Project Start Date is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]         
        public DateTime? ProjectStartDate { get; set; }
      
         
        [Display(Name = "Proposed Date of Completion")]
        [Required(ErrorMessage = "Original Proposed Date of Completion is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OCDateProject { get; set; }

        [Display(Name = "Actual Date of Completion")]
        [Required(ErrorMessage = "Actual Completion Date is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ACDProject { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Reason and Extent of Delays in Completion of Project")]
        [Required(ErrorMessage = "Reason and Extent of Delays in Completion of Project is required.")]
        [StringLength(200)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,200}$", ErrorMessage = "Special characters are not allowed. Maximum length is 200")]
        public string RExtentofDelayProject { get; set; }

        
        [Display(Name = "Type of Land of the Project")]
        [Required(ErrorMessage = "Type of Land of the Project is required.")]
        public string TypeLandofProject { get; set; }

        
        [Display(Name = "Any Litigation Related to Project?")]
        [Required(ErrorMessage = "Litigation Related to Project is required.")]
        public string LitgToProject { get; set; }

       
        [Display(Name = "Case Title")]        
        public string CaseTitle { get; set; }

        [Display(Name = "Case Number")]        
        public string CaseNumber { get; set; }

        
        [Display(Name = "Name of Authority/Forum where Case is Pending/ resolved")]
        public string NameofAuthorityForumwhereCasisPendingresolved { get; set; }

        [Display(Name = "Any Payment Pending Related to Land?")]
        [Required(ErrorMessage = "Payment Pending Related to Land is required.")]
        public string IsPaymentDetailsPending_RelatedLand { get; set; }

        [Display(Name = "Details of Payment Pending Related to Land")]
        //[Required(ErrorMessage = "Details of Payment Pending Related to Land is required.")]
        [StringLength(100)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,100}$", ErrorMessage = "Special characters are not allowed. Maximum length is 100")]
        public string DetailPaymentPendingProject { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string Created_By { get; set; }
        public System.DateTime Created_On { get; set; }
        public string Modify_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }

        public int Flag { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }

        public List<ClsPrp_OngoingProjectLFiveYears> prpongoing { get; set; }
       
    }
}
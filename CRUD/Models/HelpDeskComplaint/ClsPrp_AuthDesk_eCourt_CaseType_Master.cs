using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_eCourt_CaseType_Master
    {
        public long CaseType_IndexID { get; set; }
        public long CaseType_ID { get; set; }
        public int CaseType_SerialOrder { get; set; }

        public string CaseTypeCode { get; set; }

        [Required(ErrorMessage = "Case Type Name is required")]
        [Display(Name = "Case Type Name")]
        [StringLength(150)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string CaseTypeName { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Description If Any is required")]
        [Display(Name = "Description, If Any")]
        [StringLength(250)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string CaseTypeDescription { get; set; }

        [Required(ErrorMessage = "Remarks If Any is required")]
        [Display(Name = "Remarks, If Any")]
        [StringLength(250)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsFlag { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_AuthDesk_eCourt_CaseType_Master> prpongoing { get; set; }
        public ClsPrp_AuthDesk_eCourt_CaseType_Master()
        {
            prpongoing = new List<ClsPrp_AuthDesk_eCourt_CaseType_Master>();
        }        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails
    {
        public string Prepared_SequenceNumber { get; set; }
        public string Prepared_AgentStateType { get; set; }
        public string Prepared_NumberTypeFlag { get; set; }

        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string Prepared_RegistrationNumber { get; set; }

        [Display(Name = "Registration Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Prepared_IssueDate { get; set; }

        [Display(Name = "Registration Upto Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Prepared_ValidUptoDate { get; set; }

        [Display(Name = "Amount (INR)")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Value; Maximum Two Decimal Points.")]
        [Range(0.00, 999999999.99)]
        public decimal Amount_PriceValue { get; set; }

        public string NumberAlreadyExisted_Flag { get; set; }

        [Display(Name = "Real-Estate Agent Name")]
        [StringLength(90, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,90}$", ErrorMessage = "Special characters are not allowed. Maximum length is 90")]
        public string RealEstateAgentName { get; set; }

        [Display(Name = "Diary Number")]
        public string RealEstateAgentRegDiaryNumber_Name { get; set; }
                     
        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        public string RemarksIfAny { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }        

        public int IsActive { get; set; }
        public int IsDraft { get; set; }        

        public string CreatedBy { get; set; }        
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }       

        public List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentRERAnumberSummaryDetails>();
        }
    }
}
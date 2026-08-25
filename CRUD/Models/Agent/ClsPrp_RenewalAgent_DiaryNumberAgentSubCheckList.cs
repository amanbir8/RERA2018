using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.Agent
{
    public class ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList
    {

        public long RenewalAgentCheckListAction_ID { get; set; }
        public string CheckList_IdentifiedBy { get; set; }
        public string UserRole { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CheckList_IdentifiedOn { get; set; }

        public long Related_Agent_ID { get; set; }
        public int Related_AgentType_ID { get; set; }
        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalAgent_Year { get; set; }
        public int Related_RenewalAgent_SequenceID { get; set; }
        public string RelatedAgent_DiaryNumber { get; set; }
        public string RelatedAgent_RenewalDiaryNumber { get; set; }
        public string RERAnumberRegistration { get; set; }

        public string CriteriaCode { get; set; }
        [Required]
        [Display(Name = "Criteria Requirement")]
        public string CriteriaSubCode { get; set; }
        [Display(Name = "Remarks, If Any")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 1)]
        [RegularExpression(@"^[0-9a-zA-Z''-',.\s]{1,500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 500")]
        public string Remarks_IfAny { get; set; }
        [Required]
        [Display(Name = "Is Application Criteria Acceptable? (Yes/No)")]
        public string IsChecklistValueOk { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsLock { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyOn { get; set; }

        public string CriteriaSubCodeTitle { get; set; }
        public int VarCriteriaCode { get; set; }
        public int VarCriteriaSubCode { get; set; }
        public int VarChecklistOrderNumber { get; set; }
        public int VarChecklistGroupID { get; set; }

        public long zapRelated_Agent_ID { get; set; }
        public int zapRelated_AgentType_ID { get; set; }
        public long zapRelated_RenewalAgent_ID { get; set; }
        public int zapRelated_RenewalAgent_SequenceID { get; set; }
        public int zapRelated_RenewalAgent_YearID { get; set; }
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapRenewalAgent_DiaryNumber { get; set; }
        [Display(Name = "Registration Number")]
        public string zapRenewalAgent_RegistrationNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapRenewalAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapRenewalAgentLastModifiedOn { get; set; }


        public List<ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList> prpAgentSubCheckList { get; set; }
        public ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList()
        {
            prpAgentSubCheckList = new List<ClsPrp_RenewalAgent_DiaryNumberAgentSubCheckList>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskAgent
{
    public class ClsPrp_AuthorityDesk_AgentSubCheckListLog
    {

        public long AgentCheckListAction_ID { get; set; }
        public string CheckList_IdentifiedBy { get; set; }
        public string UserRole { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CheckList_IdentifiedOn { get; set; }
        public long Related_Agent_ID { get; set; }       
        public string Agent_DiaryNumber { get; set; }        
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
        [Display(Name = "Real Estate Agent Diary Number")]
        public string zapAgent_DiaryNumber { get; set; }
        [Display(Name = "Real Estate Agent Name")]
        public string zapAgentName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapAgentLastModifiedOn { get; set; }





        public List<ClsPrp_AuthorityDesk_AgentSubCheckListLog> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_AgentSubCheckListLog()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_AgentSubCheckListLog>();

        }

        public List<ClsPrp_AuthorityDesk_AgentSubCheckList_Master> SubCheckListMaster { get; set; }
    }
}
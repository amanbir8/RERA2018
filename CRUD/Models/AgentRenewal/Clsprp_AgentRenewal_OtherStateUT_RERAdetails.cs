using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.AgentRenewal
{
    public class Clsprp_AgentRenewal_OtherStateUT_RERAdetails
    {
        public long AgentRenewal_OtherStateUT_regRERA_IndexID { get; set; }
        public long AgentRenewal_OtherStateUT_regRERA_ID { get; set; }

        public long RenewalAgent_ID { get; set; }
        public int RenewalOrderSequence { get; set; }
        public int RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public long Related_Agent_OtherStateUT_regRERA_ID { get; set; }

        [Display(Name = "State Name")]
        public int StateCode { get; set; }
        public string State_Name { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAregistration_Number { get; set; }

        [Required]
        [Display(Name = "RERA Registration Issue Date")]               
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_IssueDate { get; set; }

        [Required]
        [Display(Name = "RERA Registration Expiry Date")]        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_ExpiryDate { get; set; }
        
        public string ImageRERAcert_FileName { get; set; }
        public string ImageRERAcert_FilePath { get; set; }
        public string ImageRERAcert_FileSize { get; set; }
        public string ImageRERAcert_FileType { get; set; }

        [Display(Name = "Remarks, If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Maximum length is 250")]
        [RegularExpression(@"^[0-9a-zA-Z''-'-,.\s]{1,250}$", ErrorMessage = "Special characters are not allowed. Maximum length is 250")]
        public string Remarks_IfAny { get; set; }

        public string A_Column { get; set; }
        public string B_Column { get; set; }
        public string C_Column { get; set; }

        public int IsActive { get; set; }
        public int IsActiveProvider { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }
        public int IsConditional { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }

        public List<Clsprp_AgentRenewal_OtherStateUT_RERAdetails> AgentRenewal_OtherStateUT { get; set; }
        public Clsprp_AgentRenewal_OtherStateUT_RERAdetails()
        {
            AgentRenewal_OtherStateUT = new List<Clsprp_AgentRenewal_OtherStateUT_RERAdetails>();
        }        
    }
}
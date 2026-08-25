using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Agent
{
    public class ClsprpRERA_Agent_OtherStateUT_regRERAdetails
    {
        public long Agent_OtherStateUT_regRERA_IndexID { get; set; }
        public long Agent_OtherStateUT_regRERA_ID { get; set; }
        public long Agent_ID { get; set; }

        //[Required]
        [Display(Name = "State Name")]
        public int StateCode { get; set; }

        [Required]
        [Display(Name = "RERA Registration Number")]
        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"^[0-9a-zA-Z''-'-\s]{1,50}$", ErrorMessage = "Special characters are not allowed. Maximum length is 50")]
        public string RERAregistration_Number { get; set; }

        [Display(Name = "RERA Registration IssueDate")]
        [Required]        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_IssueDate { get; set; }

        [Display(Name = "RERA Registration ExpiryDate")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RERAregistration_ExpiryDate { get; set; }

        public string ImageRERAcert_FileName { get; set; }
        public string ImageRERAcert_FilePath { get; set; }

        public string Remarks_IfAny { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }

        public string StateName_OtherUT { get; set; }

        public List<Promoter.ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails> Agent_OtherStateUTMember { get; set; }
        public ClsprpRERA_Agent_OtherStateUT_regRERAdetails()
        {
            Agent_OtherStateUTMember = new List<ClsprpRERA_Agent_OtherStateUT_regRERAdetails>();
        }
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
    }
}
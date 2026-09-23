using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpdeskComplaint
{
    public class ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom
    {
        public long CourtRoom_IndexID { get; set; }
        public long CourtRoom_ID { get; set; }

        public long Related_ComplaintID { get; set; }
        public string Related_ComplaintCode { get; set; }
        public long Related_PrehearingDate_IndexID { get; set; }
        public long Related_PrehearingDate_ID { get; set; }

        public string ComplaintType_MN { get; set; }
        public string ComplaintType_TransferYN { get; set; }
        public string ComplaintType_BifurcationYN { get; set; }

        [Display(Name = "eRoom Applied Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime eRoom_AppliedDate { get; set; }

        [Required]
        public string CRAS_Name { get; set; }
        public string CRAS_Category { get; set; }
        public string CRAS_Attendance_YN { get; set; }
        public int CRAS_SeqOrder { get; set; }
        public int CRAS_Ref_Applied_SeqOrder { get; set; }
        [Required]
        public string CRAS_ProxyCouncilRepresentative { get; set; }
        public int CRAS_Advocate_Flag { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        public string CRAS_AdvocateName { get; set; }
        public int CRAS_Advocate_MTO { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }             


        public long zapRelated_Complaint_ID { get; set; }
        public string zapRelated_RegDiaryNumber { get; set; }
        [Display(Name = "RERA Number")]
        public string zapComplainantRERAnumber { get; set; }
        [Display(Name = "Complainant Name")]
        public string zapComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }

        public int IsMain { get; set; }
        public bool IsUpdate { get; set; }





        public List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom> prpongoing { get; set; }
        public List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom> Complainants { get; set; }
        public List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom> Respondents { get; set; }
        public ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom()
        {
            prpongoing = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();
            Complainants = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();
            Respondents = new List<ClsPrp_AuthDesk_FormM_PreHearing_CourtRoom>();
        }
        // public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> PreHearingFixedForMaster { get; set; }
        // public List<ClsPrp_AuthDesk_PreHearingBench_Master> PreHearingBenchMaster { get; set; }
       
    }
}
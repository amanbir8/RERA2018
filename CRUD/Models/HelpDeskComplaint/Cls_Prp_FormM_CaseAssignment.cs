using CRUD.Models.HelpdeskComplaint;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDeskComplaint
{
    public class Cls_Prp_FormM_CaseAssignment
    {
        public long InstitutionFormM_IndexID { get; set; }
        public long InstitutionFormM_ID { get; set; }
        public string InstitutionFormM_Code { get; set; }
        public long Profile_ID { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }
        public int IsSameDiaryNumberWithInstitutionNumber { get; set; }
        public long Institution_Ref_ID { get; set; }
        public int Institution_Ref_Year { get; set; }
        [Required]
        [Display(Name ="Institution Reference Number")]
        public string Institution_Ref_Number { get; set; }
        [Required]
        [Display(Name = "Institution Reference Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Institution_Ref_Date { get; set; }


        public int IsManualAssignBench { get; set; }


        [Required]
        [Display(Name = "Complaint Bench Name")]
        public long AssignementBench_ID { get; set; }
        public string AssignementBench_Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Nature Of Complaint Statement")]
        public string NatureOfComplaint_Statement { get; set; }
        public string NatureOfComplaint_Key1 { get; set; }
        public string NatureOfComplaint_Key2 { get; set; }
        public string NatureOfComplaint_Key3 { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name ="ReliefSought Statement")]
        public string ReliefSought_Statement { get; set; }
        [Display(Name = "Dak Number")]
        public string Dak_Number { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Dak Date")]
        public DateTime? Dak_Date { get; set; }
        [Display(Name = "Is Complaint Hardcopy Set Yes/No")]
        public int IsComplaintHardcopySetYesNo { get; set; }
        [Display(Name = "Number of Hardcopy Set(s)")]
        public int HardcopySetNumber { get; set; }
        [Display(Name = "Number Of Complainant")]
        public int NumberOfComplainant { get; set; }
        [Display(Name = "Number Of Respondent")]
        public int NumberOfRespondent { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1500)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-.,\s()]{1,1500}$", ErrorMessage = "Special characters are not allowed. Maximum length is 1500")]
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public string D_column { get; set; }
        public string E_column { get; set; }
        public DateTime? F_column { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsLockRefNumber { get; set; }
        public int IsPublicView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }


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


        public List<Cls_Prp_FormM_CaseAssignment> prpongoing { get; set; }
        public Cls_Prp_FormM_CaseAssignment()
        {
            prpongoing = new List<Cls_Prp_FormM_CaseAssignment>();

        }
        //public List<ClsPrp_AuthDesk_PreHearingFixedFor_Master> PreHearingFixedForMaster { get; set; }
        public List<ClsPrp_AuthDesk_PreHearingBench_Master> PreHearingBenchMaster { get; set; }

        public List<BenchMaster> OnlineBenchMaster { get; set; }
        public long onlineBench_ID { get; set; }
        public string onlineBenchName { get; set; }
    }

    public class BenchMaster
    {
        public long onlineBench_ID { get; set; }
        public string onlineBenchName { get; set; }
    }

}
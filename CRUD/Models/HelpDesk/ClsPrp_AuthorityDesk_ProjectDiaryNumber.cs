using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_ProjectDiaryNumber
    {
        public long Project_RegDiaryNumber_IndexID { get; set; }
        public long Project_RegDiaryNumber_ID { get; set; }
        [Display(Name = "Diary Number")]
        public string PromoterRegDiaryNumber_Name { get; set; }
        public string PromoterRegDiaryNumber_NameYear { get; set; }
        public string UserID { get; set; }
        public long Promoter_ID { get; set; }
        public long Project_ID { get; set; }
        public int LandDetailsCount { get; set; }
        public long ProjectCost { get; set; }
        public int KhasraAreaDetailsCount { get; set; }
        public int LitigationsCount { get; set; }
        public int ApprovalDetailsCount { get; set; }
        public int PaymentDetailsCount { get; set; }
        public int SpecialBankAccountDetailsCount { get; set; }
        public int ProjectDocumentCount { get; set; }
        public string IsRegistration { get; set; }
        public long CurrentEventcode { get; set; }
        public long EventCodeDetails_indexID { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Remarks_IfAny { get; set; }
        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsDraftHelpDesk { get; set; }
        public int IsDraftEvaluation { get; set; }
        public int IsDraftSecMember { get; set; }
        public int IsDraftMember { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Application Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "District Name")]
        public string Project_AddressDistrictName { get; set; }
        [Display(Name = "RERA Number")]
        public string Project_RERAregistrationNumber { get; set; }

        public string EventAction_Type { get; set; }
        public string EventAction_TypeName { get; set; }
        [Display(Name = "Status Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventAction_IdentifiedOn { get; set; }
        [Display(Name = "Status")]
        public string EventAction_Aggregate { get; set; }
        public DateTime? Target_ResolutionDate { get; set; }
        public string EventRemarks_IfAny { get; set; }
        public string EventAction_Summary { get; set; }

        //Check-list Flag-Code
        public string CLflag1 { get; set; }
        public string CLflag2 { get; set; }
        public string CLflag3 { get; set; }
        public string CLflag4 { get; set; }
        public string CLflag5 { get; set; }
        public string CLflag6 { get; set; }


        public List<ClsPrp_AuthorityDesk_ProjectDiaryNumber> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_ProjectDiaryNumber()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_ProjectDiaryNumber>();

        }        
    }
}
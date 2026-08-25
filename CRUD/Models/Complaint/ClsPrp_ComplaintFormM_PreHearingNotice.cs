using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintFormM_PreHearingNotice
    {
        public long ComplaintFormM_IndexID { get; set; }
        public long ComplaintFormM_ID { get; set; }
        public string ComplaintFormM_Code { get; set; }        

        [Display(Name = "Name of Complainant")]
        public string Complainant_Name { get; set; }

        [Display(Name = "Name of Other Complainants")]
        public string ComplainantOther_Name { get; set; }

        [Display(Name = "Name of Other Complainants")]
        public string ComplainantOtherBrief_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]
        public string Complainant_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Complainant")]
        public long Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Complainant")]
        public long? Complainant_LandlineFaxNumber { get; set; }

        [Display(Name = "Address Line 1")]
        public string ServiceNoticesComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]        
        public string ServiceNoticesComplainant_AddressLine2 { get; set; }
        
        [Display(Name = "Address State")]
        public Nullable<int> ServiceNoticesComplainant_AddressStateCode { get; set; }
        
        [Display(Name = "Address District")]
        public Nullable<int> ServiceNoticesComplainant_AddressDistrictCode { get; set; }
        
        [Display(Name = "Address PIN Code")]        
        public string ServiceNoticesComplainant_AddressPIN { get; set; }

        [Display(Name = "Name of Authorized Representative/ Counsel")]
        public string AuthorizedRepresentativeCounsel_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Authorized Representative/ Counsel")]        
        public string AuthorizedRepresentativeCounsel_EmailAddress { get; set; }
                
        [Display(Name = "Name of Respondent")]        
        public string Respondent_Name { get; set; }

        [Display(Name = "Name of Other Respondents")]
        public string RespondentOther_Name { get; set; }

        [Display(Name = "Name of Other Respondents")]
        public string RespondentOtherBrief_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Respondent")]        
        public string Respondent_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Respondent")]        
        public long? Respondent_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Respondent")]        
        public long? Respondent_LandlineFaxNumber { get; set; }

        [Display(Name = "Address Line 1")]        
        public string ServiceNoticesRespondent_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]        
        public string ServiceNoticesRespondent_AddressLine2 { get; set; }

        [Display(Name = "Address State")]
        public Nullable<int> ServiceNoticesRespondent_AddressStateCode { get; set; }

        [Display(Name = "Address District")]
        public Nullable<int> ServiceNoticesRespondent_AddressDistrictCode { get; set; }

        [Display(Name = "PIN Code")]        
        public string ServiceNoticesRespondent_AddressPIN { get; set; }
        
        public string ServiceNoticesComplainant_AddressStateCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressDistrictCodeName { get; set; }
        public string ServiceNoticesRespondent_AddressStateCodeName { get; set; }
        public string ServiceNoticesRespondent_AddressDistrictCodeName { get; set; }
        

        public long PreHearingDate_IndexID { get; set; }
        public long PreHearingDate_ID { get; set; }
        public long ComplainantApplicant_RelatedComplaint_ID { get; set; }
        public string ComplainantApplicant_RelatedComplaint_Code { get; set; }
        public string ComplaintType_MN { get; set; }

        [Display(Name = "Hearing Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PreHearingDate { get; set; }

        [Display(Name = "Hearing Time")]             
        public string PreHearingTime { get; set; }

        [Display(Name = "Complaint Hearing Bench")]        
        public string PreHearingBench { get; set; }

        [Display(Name = "Fixed For")]        
        public string PreHearingFixedForCode { get; set; }

        [Display(Name = "Fixed For")]        
        public string PreHearingFixedForName { get; set; }

        [Display(Name = "Status")]        
        public string PreHearingStatus { get; set; }

        [Display(Name = "Remarks, If Any")]        
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Hearing Type")]        
        public string A_column { get; set; }

        [Display(Name = "Hearing Bench")]        
        public string B_column { get; set; }

        public string C_column { get; set; }
        public string D_column { get; set; }
        public string E_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
        public int IsPublicView { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public List<ClsPrp_ComplaintFormM_PreHearingNotice> prpongoingNotice { get; set; }
        public ClsPrp_ComplaintFormM_PreHearingNotice()
        {
            prpongoingNotice = new List<ClsPrp_ComplaintFormM_PreHearingNotice>();

        }        
        public List<ClsPrp_StateMaster> stateMaster { get; set; }
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;
using System.Web.Mvc;
using CRUD.Models.HelpdeskComplaint;

namespace CRUD.Models.ComplaintPrint
{
    public class ClsPrp_Print_FormM_Registration
    {
        public long ComplaintFormM_IndexID { get; set; }
        public long ComplaintFormM_ID { get; set; }
        public string ComplaintFormM_Code { get; set; }

        public long Profile_ID { get; set; }
        public string User_ID { get; set; }
        public string ComplaintType_MN { get; set; }

        public int IsComplaintComplete { get; set; }
        public int IsPaymentComplete { get; set; }
        public int IsDocumentsComplete { get; set; }

        public int IsVerificationComplete { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ComplaintVerificationDate { get; set; }

        [Display(Name = "Name of Complainant")]        
        public string Complainant_Name { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email ID of Complainant")]        
        public string Complainant_EmailAddress { get; set; }
        
        [Display(Name = "Mobile Number of Complainant")]        
        public long Complainant_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Complainant")]        
        public long? Complainant_LandlineFaxNumber { get; set; }

        [Display(Name = "Aadhaar Number of Complainant")]  
        public long? Complainant_AadhaarNumber { get; set; }
        

        
        [Display(Name = "Address Line 1")]        
        public string OfficeResComplainant_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]        
        public string OfficeResComplainant_AddressLine2 { get; set; }

        [Display(Name = "Address State")]
        public Nullable<int> OfficeResComplainant_AddressStateCode { get; set; }

        [Display(Name = "Address District")]
        public Nullable<int> OfficeResComplainant_AddressDistrictCode { get; set; }

        [Display(Name = "Address PIN Code")]        
        public string OfficeResComplainant_AddressPIN { get; set; }
        

        public string IsOfficeResComplainantAddress_SameAsServiceNoticeAddress { get; set; }        
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

        [Display(Name = "Mobile Number of Authorized Representative/ Counsel")]        
        public long? AuthorizedRepresentativeCounsel_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Authorized Representative/ Counsel")]        
        public long? AuthorizedRepresentativeCounsel_LandlineFaxNumber { get; set; }


        [Display(Name = "Complaint Against")]
        public string RelatesComplaint_ComplaintAgainstType { get; set; }

        [Display(Name = "RERA Registration Number of Project/ Agent to which the Complaint relates")]        
        public string RelatesComplaint_ProjectAgent_RERA_RegNumber { get; set; }

        [Display(Name = "Name of the Real Estate Project/ Agent to which the Complaint relates")]        
        public string RelatesComplaint_ProjectAgent_Name { get; set; }

        
        [Display(Name = "Name of Respondent")]        
        public string Respondent_Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email ID of Respondent")]        
        public string Respondent_EmailAddress { get; set; }

        [Display(Name = "Mobile Number of Respondent")]        
        public long? Respondent_MobileNumber { get; set; }

        [Display(Name = "Landline Number or Fax Number of Respondent")]        
        public long? Respondent_LandlineFaxNumber { get; set; }


        [Display(Name = "Address Line 1")]        
        public string OfficeResRespondent_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]        
        public string OfficeResRespondent_AddressLine2 { get; set; }

        [Display(Name = "Address State")]
        public Nullable<int> OfficeResRespondent_AddressStateCode { get; set; }

        [Display(Name = "Address District")]
        public Nullable<int> OfficeResRespondent_AddressDistrictCode { get; set; }

        [Display(Name = "Address PIN Code")]        
        public string OfficeResRespondent_AddressPIN { get; set; }


        public string IsOfficeResRespondentAddress_SameAsServiceNoticeAddress { get; set; }
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
        

        [Display(Name = "Jurisdiction of the Real Estate Regulatory Authority, Punjab (Declaration)")]
        public string IsAgreeDeclaration_JurisdictionRERAPunjab { get; set; }


        [AllowHtml]
        [Display(Name = "Facts of Complaint [Mention a concise statement of facts and grounds for complaint.]")]
        public string FactsCase_Statement { get; set; }


        [AllowHtml]
        [Display(Name = "Relief(s) Sought")]        
        public string ReliefSought_Statement { get; set; }


        [Display(Name = "Total value of Flat/Plot/Apartment (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal? ReliefSought_TotalValueINR_FlatPlotApartment { get; set; }

        [Display(Name = "Total Amount paid till date (INR)")]        
        [Range(0, 9999999999999999.99)]
        public decimal? ReliefSought_TotalAmountPaid_tilldateINR { get; set; }

        [Display(Name = "Date of possession as per agrreement for sale/allotment letter etc.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReliefSought_PossessionDate { get; set; }

        [Display(Name = "Actual date of possession, If delivered")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReliefSought_ActualPossessionDate_IfDelivered { get; set; }

                       
        [AllowHtml]
        [Display(Name = "Pending final decision of the complaint the complainant seeks issue of the following interim order [Give here the nature of the interim order prayed for with reasons.]")]
        public string InterimOrderRelief_Statement { get; set; }

        [Display(Name = "Complaint not pending with any other Court, etc. or has not been decided by any other Court/ Authority, etc. (Declaration)")]
        public string IsAgreeDeclaration_ComplaintNotPendingCourtAuthority { get; set; }

        public string Remarks_IfAny { get; set; }

        [Display(Name = "Date of Allotment Letter")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? A_column { get; set; }

        [Display(Name = "Date of Agreement to Sale, If any")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? B_column { get; set; }

        [Display(Name = "Flat/ Apartment/ Plot Number (Booked with complete Address of associated property)")]
        public string C_column { get; set; }

        public string D_column { get; set; }
        public string E_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public int IsLock { get; set; }
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
        [Display(Name = "Other Complainant Name")]
        public string zapOtherComplainantName { get; set; }
        [Display(Name = "Other Complainant Name")]
        public string zapOtherBriefComplainantName { get; set; }
        [Display(Name = "Respondant Name")]
        public string zapRespondantName { get; set; }
        [Display(Name = "Other Respondant Name")]
        public string zapOtherRespondantName { get; set; }
        [Display(Name = "Other Respondant Name")]
        public string zapOtherBriefRespondantName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zapComplaintFormLastModifiedOn { get; set; }


        public string OfficeResComplainant_AddressStateCodeName { get; set; }
        public string OfficeResComplainant_AddressDistrictCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressStateCodeName { get; set; }
        public string ServiceNoticesComplainant_AddressDistrictCodeName { get; set; }
        public string OfficeResRespondent_AddressStateCodeName { get; set; }
        public string OfficeResRespondent_AddressDistrictCodeName { get; set; }
        public string ServiceNoticesRespondent_AddressStateCodeName { get; set; }
        public string ServiceNoticesRespondent_AddressDistrictCodeName { get; set; }


        public List<ClsPrp_Print_FormM_Registration> prpComplaintFormM { get; set; }
        public ClsPrp_Print_FormM_Registration()
        {
            prpComplaintFormM = new List<ClsPrp_Print_FormM_Registration>();
        }

        public List<ClsPrp_StateMaster> stateMaster { get; set; }        
        public List<ClsPrp_DistrictMaster> districtMaster { get; set; }

        public List<ClsPrp_Print_FormM_Fee> prpComplaintFormM_FeeDetail { get; set; }
        public List<Clsprp_Print_FormM_Documents> prpComplaintFormM_Docs { get; set; }

        public List<ClsPrp_Print_FormMN_AddMore_Complainant> prpComplaintFormM_AddMoreComplainant { get; set; }
        public List<ClsPrp_Print_FormMN_AddMore_Respondent> prpComplaintFormM_AddMoreRespondent { get; set; }

        public List<ClsPrp_AuthorityDesk_FormM_FactsCaseDocument> FactsCase_Documents { get; set; }
    }
}
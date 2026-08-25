using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.classAgentRenewalPayment
{
    public class ClsPrp_AgentRenewalApplication_Ind_OTInd
    {
        public long RenewalAgent_IndexID { get; set; }
        public long RenewalAgent_ID { get; set; }

        public long Related_RenewalAgent_ID { get; set; }
        public int Related_RenewalOrderSequence { get; set; }
        public int Related_RelatedRenewalAgent_Year { get; set; }
        public long Related_Agent_ID { get; set; }
        public string Related_AgentDiaryNumber_Name { get; set; }
        public int Related_Agent_Type { get; set; }
        public string Related_UserID { get; set; }
        public string Related_RERAnumberRegistration { get; set; }
        public DateTime? Related_RERAnumberIssueDate { get; set; }
        public DateTime? Related_RERAnumberRegUptoDate { get; set; }
        public long Related_Agent_IndexID { get; set; }

        public string IsAlready_RERANumber { get; set; }
        public string Existing_RERANumber { get; set; }
        public string Agent_FirstName { get; set; }
        public string Agent_MiddleName { get; set; }
        public string Agent_LastName { get; set; }
        public string Father_FirstName { get; set; }
        public string Father_MiddleName { get; set; }
        public string Father_LastName { get; set; }
        public string Occupation { get; set; }
        public string Image_FileName { get; set; }
        public string Image_FilePath { get; set; }
        public string P_AddressLine1 { get; set; }
        public string P_AddressLine2 { get; set; }
        public string P_AddressStateCode { get; set; }
        public string P_AddressDistrictCode { get; set; }
        public string P_AddressPIN { get; set; }
        public string Organization_Name { get; set; }
        public int Organization_TypeCode { get; set; }
        public string Organization_MainObjects { get; set; }
        public string RegOffice_AddressLine1 { get; set; }
        public string RegOffice_AddressLine2 { get; set; }
        public string RegOffice_AddressStateCode { get; set; }
        public string RegOffice_AddressDistrictCode { get; set; }
        public int RegOffice_AddressPIN { get; set; }
        public string BusinessPlace_AddressLine1 { get; set; }
        public string BusinessPlace_AddressLine2 { get; set; }
        public string BusinessPlace_AddressStateCode { get; set; }
        public string BusinessPlace_AddressDistrictCode { get; set; }
        public int BusinessPlace_AddressPIN { get; set; }
        public string IsSameBussinessAdd_CommAdd { get; set; }
        public string BComm_AddressLine1 { get; set; }
        public string BComm_AddressLine2 { get; set; }
        public string BComm_AddressStateCode { get; set; }
        public string BComm_AddressDistrictCode { get; set; }
        public int BComm_AddressPIN { get; set; }
        public string AuthorizedSignatory_FirstName { get; set; }
        public string AuthorizedSignatory_MiddleName { get; set; }
        public string AuthorizedSignatory_LastName { get; set; }
        public long MobileNumber { get; set; }
        public long PhoneNumber_STD { get; set; }
        public long PhoneNumber_Number { get; set; }
        public string EmailAddress { get; set; }
        public string PAN_Number { get; set; }
        public long Aadhaar_Number { get; set; }
        public string IsOtherOrganizationMembers { get; set; }
        public string IsOtherStateUT_RERAregistration { get; set; }
        public string Remarks_IfAny { get; set; }
        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

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

        public List<ClsPrp_AgentRenewalApplication_Ind_OTInd> AgentRenewalApplication { get; set; }
        public ClsPrp_AgentRenewalApplication_Ind_OTInd()
        {
            AgentRenewalApplication = new List<ClsPrp_AgentRenewalApplication_Ind_OTInd>();
        }

    }
}
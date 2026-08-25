using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.classProjectPmPayment
{
    public class ClsPrp_ProjectPmApplication_Registration
    {
        [Display(Name = "Project Registration Index ID")]
        public long ProjectRegistration_IndexID { get; set; }

        [Display(Name = "Project Registration ID")]
        public long ProjectRegistration_ID { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Project Amenities")]
        public string Project_Amenities { get; set; }

        [Display(Name = "Is Already RERA Number")]
        public string IsAlready_RERANumber { get; set; }

        [Display(Name = "Existing Punjab RERA Number")]
        public string Existing_RERANumber { get; set; }

        [Display(Name = "1. Structure")]
        public string ProposedProjectDetail_Structure { get; set; }

        [Display(Name = "2. Flooring")]
        public string ProposedProjectDetail_Flooring { get; set; }

        [Display(Name = "3. Wall Finishing")]
        public string ProposedProjectDetail_WallFinishing { get; set; }

        [Display(Name = "4. Sanitary Fittings")]
        public string ProposedProjectDetail_SanitaryFittings { get; set; }

        [Display(Name = "5. Electrical Fittings")]
        public string ProposedProjectDetail_ElectricalFittings { get; set; }

        [Display(Name = "6. Kitchen")]
        public string ProposedProjectDetail_Kitchen { get; set; }

        [Display(Name = "7. Others If Any")]
        public string IsProposedProjectDetail_OthersIfAny { get; set; }

        [Display(Name = "Others: Name")]
        public string ProposedProjectDetail_OthersIfAnyName { get; set; }

        [Display(Name = "Others: Details")]
        public string ProposedProjectDetail_OthersIfAny { get; set; }

        [Display(Name = "Project Status")]
        public string Project_Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Project Start Date")]
        public DateTime? ProjectStart_Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Proposed/ Expected Date of Project Completion as specified in Form B")]
        public DateTime? ProjectCompletion_ProposedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Original Date of Project Completion")]
        public DateTime? ProjectCompletion_OriginalDate { get; set; }

        [Display(Name = "Duration for which Project Registration will be Provided")]
        public string ProjectRegistrationProvided_Duration { get; set; }

        [Display(Name = "Reason for Delay in Project if Any?")]
        public string ProjectDelayReason_IfAny { get; set; }

        [Display(Name = "Project Address Line1")]
        public string Project_AddressLine1 { get; set; }

        [Display(Name = "Project Address Line2")]
        public string Project_AddressLine2 { get; set; }

        [Display(Name = "Project Address State Code")]
        public int Project_AddressStateCode { get; set; }

        [Display(Name = "Project Address District Code")]
        public int Project_AddressDistrictCode { get; set; }

        [Display(Name = "Project AddressSub Division Code")]
        public int Project_AddressSubDivisionCode { get; set; }

        [Display(Name = "Project Address PIN")]
        public string Project_AddressPIN { get; set; }

        [Display(Name = "Project Potential Zone")]
        public int Project_PotentialZoneCode { get; set; }

        [Display(Name = "Project Website Web Link")]
        public string ProjectWebsite_WebLink { get; set; }

        [Display(Name = "Authorized Person First Name")]
        public string AuthorizedPerson_FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string AuthorizedPerson_MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string AuthorizedPerson_LastName { get; set; }

        [Display(Name = "Address Line 1")]
        public string AuthorizedPerson_AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AuthorizedPerson_AddressLine2 { get; set; }

        [Display(Name = "Select Address State")]
        public int AuthorizedPerson_AddressStateCode { get; set; }

        [Display(Name = "Select Address District")]
        public int AuthorizedPerson_AddressDistrictCode { get; set; }

        [Display(Name = "PIN Code")]
        public string AuthorizedPerson_AddressPIN { get; set; }

        [Display(Name = "Authorized Person Email")]
        public string AuthorizedPerson_EmailAddress { get; set; }

        [Display(Name = "Authorized Person Mobile Phone")]
        public long AuthorizedPerson_MobileNumber { get; set; }

        [Display(Name = "Is ProForma AOS RERA format AnnexureA")]
        public string IsProForma_AOS_RERAformat_AnnexureA { get; set; }

        [Display(Name = "Is ProForma AOS RERA format No IsApproved")]
        public string IsProForma_AOS_RERAformat_No_IsApproved { get; set; }

        [Display(Name = "Is Project Mega Project Category")]
        public string IsProject_MegaProjectCategory { get; set; }

        [Display(Name = "Is Litigation Related Project")]
        public string IsLitigation_RelatedProject { get; set; }

        [Display(Name = "Remarks If Any")]
        public string Remarks_IfAny { get; set; }

        [Display(Name = "Project Cost (in rupees)")]
        public decimal A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }

        [Display(Name = "IsActive")]
        public int IsActive { get; set; }
        [Display(Name = "IsDraft")]
        public int IsDraft { get; set; }
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [Display(Name = "CreatedOn")]
        public System.DateTime CreatedOn { get; set; }
        [Display(Name = "")]
        public string ModifyBy { get; set; }
        [Display(Name = "ModifyOn")]
        public System.DateTime ModifyOn { get; set; }

        public long Promoter_ID { get; set; }
        public string Used_ID { get; set; }

        [Display(Name = "Is Regularization Certificate Issued?")]
        public string IsYes_RegularizationCertificate { get; set; }

        [Display(Name = "Is Others (If Any)?")]
        public string IsYes_columnExtra { get; set; }

        [Display(Name = "Regularization certificate /document details which relates to the project")]
        public string RegularizationCertificateInformation { get; set; }

        public string Project_AddressStateCodeName { get; set; }
        public string Project_AddressDistrictCodeName { get; set; }
        public string Project_AddressSubDivisionCodeName { get; set; }
        public string Project_PotentialZoneCodeName { get; set; }
        public string AuthorizedPerson_AddressStateCodeName { get; set; }
        public string AuthorizedPerson_AddressDistrictCodeName { get; set; }

        public List<ClsPrp_ProjectPmApplication_Registration> ProjectPmApplication { get; set; }
        public ClsPrp_ProjectPmApplication_Registration()
        {
            ProjectPmApplication = new List<ClsPrp_ProjectPmApplication_Registration>();
        }

        //public List<ClsPrp_ProjectType_Registration> ProjectType_Registration { get; set; }  
    }
}
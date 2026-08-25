using CRUD.Models.HelpDesk;
using CRUD.Models.ProjectPrint;
using CRUD.Models.PromoterPrint;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectPrintForm
{
    public class ClsPrp_PrmProject_Print_ConsolidatedReport
    {
        // 1. General & Registration
        public ClsPrp_PrmProject_Print_ProjectRegistration Registration { get; set; } = new ClsPrp_PrmProject_Print_ProjectRegistration();
        public ClsPrp_PrmProject_Print_ProjectPayment Payments { get; set; } = new ClsPrp_PrmProject_Print_ProjectPayment();
        public ClsPrp_PrmProject_Print_ProjectApprovalDetails Approvals { get; set; } = new ClsPrp_PrmProject_Print_ProjectApprovalDetails();

        // 2. Land, Bank & Khasra
        public ClsPrp_PrmProject_Print_ProjectLandDetails Land { get; set; } = new ClsPrp_PrmProject_Print_ProjectLandDetails();
        public ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails Khasra { get; set; } = new ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails();
        public ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails Bank { get; set; } = new ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails();

        // 3. Litigations & Documents
        public ClsPrp_PrmProject_Print_ProjectLitigations Litigations { get; set; } = new ClsPrp_PrmProject_Print_ProjectLitigations();
        public ClsPrp_PrmProject_Print_ProjectDocuments Documents { get; set; } = new ClsPrp_PrmProject_Print_ProjectDocuments();
        public ClsPrp_Project_ApprovalDetails ApprovalDocuments { get; set; } = new ClsPrp_Project_ApprovalDetails();
        public Clsprp_AuthDesk_View_ProjectDocuments TrashDocuments { get; set; } = new Clsprp_AuthDesk_View_ProjectDocuments();


        // 4. Quarterly Updates
        public ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction Construction { get; set; } = new ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction();
        public ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory Inventory { get; set; } = new ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory();
        public ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities ExternalFacilities { get; set; } = new ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities();
        public ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities InternalFacilities { get; set; } = new ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities();
        public ClsPrp_PrmProject_Print_ProjectParkingDetails Parking { get; set; } = new ClsPrp_PrmProject_Print_ProjectParkingDetails();
        public ClsPrp_PrmProject_Print_ProjectConstructionStatusPhotographs Photographs { get; set; } = new ClsPrp_PrmProject_Print_ProjectConstructionStatusPhotographs();
        public ClsPrp_PrmProject_Print_ProjectProfessionalDetails Professionals { get; set; } = new ClsPrp_PrmProject_Print_ProjectProfessionalDetails();

        //5. Promoter
        public Clsprp_PrmPromoter_Print_PromoterDocuments PromoterDocuments { get; set; } = new Clsprp_PrmPromoter_Print_PromoterDocuments();
        public Clsprp_PrmPromoter_Print_PromoterPrintForm PromoterProfile { get; set; } = new Clsprp_PrmPromoter_Print_PromoterPrintForm();
        public ClsPrp_PrmPromoter_Print_DiaryNumberDetails PromoterDiaryNumberDetails { get; set; } = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();
        public Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm PromoterOtherMemberDetails { get; set; } = new Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm();
    }
}
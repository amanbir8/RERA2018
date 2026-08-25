using CRUD.Models.HelpDesk;
using CRUD.Models.ProjectPrint;
using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ProjectPrintForm
{
    public class ClsPrp_PrmProject_Print_Consolidated
    {
        // ------------------------------------------------------------------
        // Shared context (fetched once instead of once per section)
        // ------------------------------------------------------------------
        public Int64 ProjectID { get; set; }
        public Int64 PromoterID { get; set; }
        public string UserRole { get; set; }

        // Shared diary-number header used by every "Project Details" section
        public List<ClsPrp_PrmProject_Print_ProjectDiaryNumberDetails> prpProjectDiaryNumberDetails { get; set; }

        // Shared diary-number header used by every "QUpdates (QUP)" section
        public List<ClsPrp_PrmProject_Print_QUpdatesProjectDiaryNumberDetails> prpQUProjectDiaryNumberDetails { get; set; } 

        // Shared zip* linkage block (Project↔Promoter cross-reference) used by
        // all three Promoter Profile sections — lifted out instead of repeated.
        public string ZipProjectDiaryNumber { get; set; }
        public string ZipProjectName { get; set; }
        public Int64? ZipRelated_Promoter_ID { get; set; }
        public Int64? ZipRelated_Project_ID { get; set; }
        public DateTime? ZipProjectLastModifiedOn { get; set; }

        // QUP selection context
        public Int32 QUP_Year { get; set; }
        public string QUP_QuarterName { get; set; }

        // ------------------------------------------------------------------
        // Group 1 — Project Details (keyed by Session["Project_id"])
        // ------------------------------------------------------------------
        public ClsPrp_PrmProject_Print_ProjectDocuments ProjectDocuments { get; set; }
        public ClsPrp_PrmProject_Print_ProjectPayment ProjectPayment { get; set; }
        public ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails ProjectSpecialBankAccount { get; set; }
        public ClsPrp_PrmProject_Print_ProjectApprovalDetails ProjectApprovals { get; set; }
        public ClsPrp_PrmProject_Print_ProjectLandDetails ProjectLand { get; set; }
        public ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails ProjectKhasraArea { get; set; }
        public ClsPrp_PrmProject_Print_ProjectRegistration ProjectRegistration { get; set; }
        public ClsPrp_PrmProject_Print_ProjectLitigations ProjectLitigations { get; set; }
        public ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction ProjectConstruction { get; set; }
        public ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory ProjectInventory { get; set; }
        public ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities ProjectExternalFacilities { get; set; }
        public ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities ProjectInternalFacilities { get; set; }
        public ClsPrp_PrmProject_Print_ProjectParkingDetails ProjectParking { get; set; }
        public ClsPrp_PrmProject_Print_ProjectConstructionStatusPhotographs ProjectPhotographs { get; set; }
        public ClsPrp_PrmProject_Print_ProjectProfessionalDetails ProjectProfessionals { get; set; }

        // ------------------------------------------------------------------
        // Group 2 — Promoter Profile (keyed by Session["zipPromoterID"])
        // Individual vs Organization are mutually exclusive in the original
        // code (Flag==2 redirects Ind -> OthInd), so only ONE of the next two
        // will be populated per promoter — check IsIndividualPromoter in the view.
        // ------------------------------------------------------------------
        public bool IsIndividualPromoter { get; set; }
        public ClsPromoterPrintForm PromoterIndividual { get; set; }
        public ClsPromoterOrgExpPrintForm PromoterOrganization { get; set; } // covers both OthInd + TrackLitigations data (prpMem/Prpparententity included)
        public Clsprp_AuthorityDesk_PromoterDocuments PromoterDocuments { get; set; }

        // ------------------------------------------------------------------
        // Group 3 — Project Quarterly Updates / QUP (keyed by Project_id + Year + Quarter)
        // ------------------------------------------------------------------
        public ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory QUP_InventoryConstruction { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails QUP_Parking { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs QUP_Photographs { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities QUP_InternalFacilities { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities QUP_ExternalFacilities { get; set; }
        public ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails QUP_Approvals { get; set; }
    }
}
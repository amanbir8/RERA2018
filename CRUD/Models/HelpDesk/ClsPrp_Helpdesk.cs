using CRUD.Models.Document;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_Helpdesk
    {
        public long Application_id { get; set; }
        public Int64 ID { get; set; }

        [Display(Name = "Project ID")]
        public Int32 ProjectRegistration_ID { get; set; }
        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }
        [Display(Name = "Status")]
        public string Project_Status { get; set; }

        [Display(Name = "Promoter ID")]
        public Int32 Promoter_ID { get; set; }
        [Display(Name = "Promoter Name")]
        public string Promoter_Name { get; set; }
        [Display(Name = "Name of Organization")]
        public string Org_Name { get; set; }

        public List<ClsPrp_Helpdesk> project_ongoing { get; set; }


        #region//Promoter Details
            public ClsPrp_OrgExp Prp_OrgExp { get; set; }
            public Clsprp_Promoter Prp_Promoter { get; set; }
            public List<ClsPrp_OrgMemDetail> List_OrgMemDetail { get; set; }
            public List<ClsPrp_ParentEntityDetail> List_ParentEntityDetail { get; set; }
            public List<Clsprp_Promoter_Documents> List_Promoter_Documents { get; set; }
            public List<ClsPrp_OngoingProjectLFiveYears> List_Promoter_FiveYr { get; set; }
        #endregion

        #region//Project Details
            public List<ClsPrp_Project_Registration> List_Project { get; set; }
            public List<ClsPrp_Project_Litigations> List_Project_Litigations { get; set; }
            public List<ClsPrp_Project_Payment> List_Project_Payment { get; set; }
        #endregion

        #region// Project Land Details
            public List<ClsPrp_Project_LandDetails> List_Project_LandDetails { get; set; }
            public List<ClsPrp_Project_KhasraAreaDetails> List_Project_KhasraAreaDetails { get; set; }
        #endregion

        #region// Project Approval Details
        public List<ClsPrp_Project_ApprovalDetails> List_Project_ApprovalDetails { get; set; }
        //public List<ClsPrp_Project_KhasraAreaDetails> List_Project_KhasraAreaDetails { get; set; }
        #endregion

        #region// Project Approval Details
        public List<ClsPrp_Project_SpecialBankAccountDetails> List_Project_SpecialBankAccountDetails { get; set; }
        #endregion
        
    }
}
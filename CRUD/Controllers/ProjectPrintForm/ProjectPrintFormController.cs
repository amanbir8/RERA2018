using CRUD.Models.Document;
using CRUD.Models.HelpDesk;
using CRUD.Models.ProjectPrint;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RazorPDF;
using System.Web.Configuration;
using CRUD.Models.ProjectPrintForm;
using CRUD.Common;
using CRUD.Models.PromoterPrint;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace CRUD.Controllers.ProjectPrint
{
    [Authorize]
    [Authorize(Roles = "Promoter,SecretaryRERA")]
    public class ProjectPrintFormController : Controller
    {
        private static readonly ConcurrentDictionary<string, ZipDownloadProgress> _zipProgress = new ConcurrentDictionary<string, ZipDownloadProgress>();
        public class ZipDownloadProgress
        {
            public int TotalFiles { get; set; }
            public int CompletedFiles { get; set; }
            public int Percent { get; set; }
            public string Status { get; set; }
            public string FilePath { get; set; }
            public string FileName { get; set; }
            public bool Completed { get; set; }
            public string Error { get; set; }
            public List<string> ActiveFiles { get; set; } = new List<string>();

        }
        //Project Details
        #region Print Project Documents

        [HttpGet]
        public ActionResult Print_ProjectDocumentDetails()
        {
            ClsMethod_Print_ProjectDocuments sdb = new ClsMethod_Print_ProjectDocuments();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectDocuments aa = new ClsPrp_PrmProject_Print_ProjectDocuments();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_Documents_ByProjectId(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Payment Details

        [HttpGet]
        public ActionResult Print_ProjectPaymentDetails()
        {
            ClsMethod_Print_ProjectRegistration sdb = new ClsMethod_Print_ProjectRegistration();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectPayment aa = new ClsPrp_PrmProject_Print_ProjectPayment();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_Payment(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);
            aa.prpProjectPaymentIntegrationDetails = sdb.Display_Print_ProjectApplicationPaymentTransactions(ProjectID);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Special Bank Account Details

        [HttpGet]
        public ActionResult Print_ProjectSpecialBankAccountDetails()
        {
            ClsMethod_Print_ProjectSpecialBankAccountDetails sdb = new ClsMethod_Print_ProjectSpecialBankAccountDetails();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails aa = new ClsPrp_PrmProject_Print_ProjectSpecialBankAccountDetails();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_SpecialBankAccountDetails(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Approvals Details

        [HttpGet]
        public ActionResult Print_ProjectApprovalDetails()
        {
            ClsMethod_Print_ProjectApprovalDetails sdb = new ClsMethod_Print_ProjectApprovalDetails();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectApprovalDetails aa = new ClsPrp_PrmProject_Print_ProjectApprovalDetails();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_ApprovalDetails(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Land Details

        [HttpGet]
        public ActionResult Print_ProjectLandDetails()
        {
            ClsMethod_Print_ProjectLandDetails sdb = new ClsMethod_Print_ProjectLandDetails();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectLandDetails aa = new ClsPrp_PrmProject_Print_ProjectLandDetails();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_Landdetails(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Khasra Area Details

        [HttpGet]
        public ActionResult Print_ProjectKhasraAreaDetails()
        {
            ClsMethod_Print_ProjectKhasraAreaDetails sdb = new ClsMethod_Print_ProjectKhasraAreaDetails();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails aa = new ClsPrp_PrmProject_Print_ProjectKhasraAreaDetails();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_KhasraAreaDetails(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Details

        [HttpGet]
        public ActionResult Print_ProjectRegistrationDetails()
        {
            ClsMethod_Print_ProjectRegistration sdb = new ClsMethod_Print_ProjectRegistration();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectRegistration aa = new ClsPrp_PrmProject_Print_ProjectRegistration();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_RegistrationAll(ProjectID);
            aa.ProjectType_Registration = sdb.Display_Project_RegistrationTypeProject(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Litigations

        [HttpGet]
        public ActionResult Print_ProjectLitigations()
        {
            ClsMethod_Print_ProjectLitigations sdb = new ClsMethod_Print_ProjectLitigations();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectLitigations aa = new ClsPrp_PrmProject_Print_ProjectLitigations();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_Project_Litigations(ProjectID);

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        //Promoter Profile
        #region Promoter Profile
        public ActionResult Display_PromoterIndPrintForm()
        {
            Int64 Application_id = 0;
            int? statecode;
            int? DistrictCode;

            if (Session["zipProjectDiaryNumber"] != null)
            {
                Int64? Promoter_ID = Convert.ToInt64(Session["zipPromoterID"]);
                Application_id = (Promoter_ID != null) ? Convert.ToInt64(Promoter_ID) : 0;
            }

            ClsPromoterPrintForm objprp = new ClsPromoterPrintForm();
            ClsPromoterPrintForm objDB = new ClsPromoterPrintForm(); //calling class DBdata
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            objprp = objDB.DisplayIndPro(Convert.ToInt64(Application_id));

            if (objprp.Flag == 2)
            {
                return RedirectToAction("Display_PromoterOthIndPrintForm");
            }

            statecode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(DistrictCode);


            if (Session["zipProjectDiaryNumber"] != null)
            {
                string ProjectDiaryNumber = Session["zipProjectDiaryNumber"].ToString();
                string ProjectName = Session["zipProjectName"].ToString();
                Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zipLastModifiedOn"]);
                Int64? PromoterID = Convert.ToInt64(Session["zipPromoterID"]);

                objprp.zipRelated_Promoter_ID = (PromoterID != null) ? Convert.ToInt64(PromoterID) : 0;
                objprp.zipRelated_Project_ID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
                objprp.zipProject_DiaryNumber = (String.IsNullOrEmpty(ProjectDiaryNumber) ? "" : ProjectDiaryNumber);
                objprp.zipProjectName = (String.IsNullOrEmpty(ProjectName) ? "" : ProjectName);
                objprp.zipProjectLastModifiedOn = LastModifiedOn;
            }

            return View("Display_PromoterIndPrintForm", objprp);
        }
        public ActionResult Display_PromoterOthIndPrintForm()
        {
            Int64 Application_id = 0;
            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;

            if (Session["zipProjectDiaryNumber"] != null)
            {
                Int64? Promoter_ID = Convert.ToInt64(Session["zipPromoterID"]);
                Application_id = (Promoter_ID != null) ? Convert.ToInt64(Promoter_ID) : 0;
            }

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPromoterOrgExpPrintForm objprp = new ClsPromoterOrgExpPrintForm();
            ClsPromoterOrgExpPrintForm objDB = new ClsPromoterOrgExpPrintForm(); //calling class DBdata



            objprp = objDB.DisplayOrgExp(Convert.ToInt64(Application_id));

            statecode = Convert.ToInt32(objprp.Org_State);
            objprp.Org_State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.Org_District);
            objprp.Org_District = objdis.District_Name(DistrictCode);

            BusinessPlace_AddressStateCode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(BusinessPlace_AddressStateCode);

            BusinessPlace_AddressDistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(BusinessPlace_AddressDistrictCode);

            objprp.Prpparententity = objDB.DisplayDetailByApplicationID(Application_id);

            objprp.prpMem = objDB.Display_MemProject(Application_id);


            if (Session["zipProjectDiaryNumber"] != null)
            {
                string ProjectDiaryNumber = Session["zipProjectDiaryNumber"].ToString();
                string ProjectName = Session["zipProjectName"].ToString();
                Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zipLastModifiedOn"]);
                Int64? PromoterID = Convert.ToInt64(Session["zipPromoterID"]);

                objprp.zipRelated_Promoter_ID = (PromoterID != null) ? Convert.ToInt64(PromoterID) : 0;
                objprp.zipRelated_Project_ID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
                objprp.zipProject_DiaryNumber = (String.IsNullOrEmpty(ProjectDiaryNumber) ? "" : ProjectDiaryNumber);
                objprp.zipProjectName = (String.IsNullOrEmpty(ProjectName) ? "" : ProjectName);
                objprp.zipProjectLastModifiedOn = LastModifiedOn;
            }

            objprp.prpLitigations = objDB.DisplayLitigationn(Application_id);

            if (objprp.prpLitigations != null)
            {
                foreach (var item in objprp.prpLitigations)
                {
                    //aa.Promoter_ID = item.Promoter_ID;                   
                }
            }
            objprp.prpongoing = objDB.DisplaybyID_ongoingProject(Application_id);
            if (objprp.prpongoing != null)
            {
                foreach (var item in objprp.prpongoing)
                {
                    //objDB.Promoter_Experience_ID = item.Promoter_Experience_ID;                  
                }
            }
            return View("Display_PromoterOthIndPrintForm", objprp);
        }
        public ActionResult Display_PromoterTrackLitigationsDetails()
        {
            Int64 Application_id = 0;
            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;

            if (Session["zipProjectDiaryNumber"] != null)
            {
                Int64? Promoter_ID = Convert.ToInt64(Session["zipPromoterID"]);
                Application_id = (Promoter_ID != null) ? Convert.ToInt64(Promoter_ID) : 0;
            }

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPromoterOrgExpPrintForm objprp = new ClsPromoterOrgExpPrintForm();
            ClsPromoterOrgExpPrintForm objDB = new ClsPromoterOrgExpPrintForm(); //calling class DBdata


            objprp = objDB.DisplayOrgExp(Convert.ToInt64(Application_id));

            statecode = Convert.ToInt32(objprp.Org_State);
            objprp.Org_State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.Org_District);
            objprp.Org_District = objdis.District_Name(DistrictCode);

            BusinessPlace_AddressStateCode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(BusinessPlace_AddressStateCode);

            BusinessPlace_AddressDistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(BusinessPlace_AddressDistrictCode);

            if (Session["zipProjectDiaryNumber"] != null)
            {
                string ProjectDiaryNumber = Session["zipProjectDiaryNumber"].ToString();
                string ProjectName = Session["zipProjectName"].ToString();
                Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zipLastModifiedOn"]);
                Int64? PromoterID = Convert.ToInt64(Session["zipPromoterID"]);

                objprp.zipRelated_Promoter_ID = (PromoterID != null) ? Convert.ToInt64(PromoterID) : 0;
                objprp.zipRelated_Project_ID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
                objprp.zipProject_DiaryNumber = (String.IsNullOrEmpty(ProjectDiaryNumber) ? "" : ProjectDiaryNumber);
                objprp.zipProjectName = (String.IsNullOrEmpty(ProjectName) ? "" : ProjectName);
                objprp.zipProjectLastModifiedOn = LastModifiedOn;
            }

            objprp.prpLitigations = objDB.DisplayLitigationn(Application_id);

            if (objprp.prpLitigations != null)
            {
                foreach (var item in objprp.prpLitigations)
                {
                    //aa.Promoter_ID = item.Promoter_ID;                    
                }
            }
            objprp.prpongoing = objDB.DisplaybyID_ongoingProject(Application_id);

            if (objprp.prpongoing != null)
            {
                foreach (var item in objprp.prpongoing)
                {
                    //objDB.Promoter_Experience_ID = item.Promoter_Experience_ID;   
                }
            }
            return View("Display_PromoterTrackLitigationsDetails", objprp);
        }
        #endregion

        #region Promoter Profile Documents

        [HttpGet]
        public ActionResult Display_PromoterDoc()
        {
            ClsMethod_View_PromoterDocuments sdb = new ClsMethod_View_PromoterDocuments();
            Clsprp_AuthorityDesk_PromoterDocuments aa = new Clsprp_AuthorityDesk_PromoterDocuments();
            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();
            if (Session["zipProjectDiaryNumber"] != null)
            {
                Int64? Promoter_ID = Convert.ToInt64(Session["zipPromoterID"]);
                aPromoterID = (Promoter_ID != null) ? Convert.ToInt64(Promoter_ID) : 0;
            }

            aa.prpongoing = sdb.Display_AuthDesk_Promoter_Documents_PromoterId(aPromoterID);


            if (Session["zipProjectDiaryNumber"] != null)
            {
                string ProjectDiaryNumber = Session["zipProjectDiaryNumber"].ToString();
                string ProjectName = Session["zipProjectName"].ToString();
                Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
                DateTime? LastModifiedOn = Convert.ToDateTime(Session["zipLastModifiedOn"]);
                Int64? PromoterID = Convert.ToInt64(Session["zipPromoterID"]);

                aa.zipRelated_Promoter_ID = (PromoterID != null) ? Convert.ToInt64(PromoterID) : 0;
                aa.zipRelated_Project_ID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
                aa.zipProject_DiaryNumber = (String.IsNullOrEmpty(ProjectDiaryNumber) ? "" : ProjectDiaryNumber);
                aa.zipProjectName = (String.IsNullOrEmpty(ProjectName) ? "" : ProjectName);
                aa.zipProjectLastModifiedOn = LastModifiedOn;
            }


            return View("Display_PromoterDoc", aa);
        }

        #endregion

        //Project Quarterly Details
        #region Print Project Updates - (Construction Details)

        [HttpGet]
        public ActionResult Print_ProjectConstructionDetails()
        {
            ClsMethod_Print_Project_Updates_CIIEFP sdb = new ClsMethod_Print_Project_Updates_CIIEFP();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction aa = new ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Construction();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_ProjectBuildingTowerBlock_Construction(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Updates - (Inventory Details)

        [HttpGet]
        public ActionResult Print_ProjectInventoryDetails()
        {
            ClsMethod_Print_Project_Updates_CIIEFP sdb = new ClsMethod_Print_Project_Updates_CIIEFP();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory aa = new ClsPrp_PrmProject_Print_ProjectBuildingTowerBlock_Inventory();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Updates - (External Facilities Details)

        [HttpGet]
        public ActionResult Print_ProjectExternalFacilitiesDetails()
        {
            ClsMethod_Print_Project_Updates_CIIEFP sdb = new ClsMethod_Print_Project_Updates_CIIEFP();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities aa = new ClsPrp_PrmProject_Print_ProjectExternalInfrastructure_Facilities();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_ProjectExternalInfrastructure_Facilities(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Updates - (Internal Facilities Details)

        [HttpGet]
        public ActionResult Print_ProjectInternalFacilitiesDetails()
        {
            ClsMethod_Print_Project_Updates_CIIEFP sdb = new ClsMethod_Print_Project_Updates_CIIEFP();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities aa = new ClsPrp_PrmProject_Print_ProjectInternalInfrastructure_Facilities();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_ProjectInternalInfrastructure_Facilities(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Updates - (Parking Details)

        [HttpGet]
        public ActionResult Print_ProjectParkingDetails()
        {
            ClsMethod_Print_Project_Updates_CIIEFP sdb = new ClsMethod_Print_Project_Updates_CIIEFP();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectParkingDetails aa = new ClsPrp_PrmProject_Print_ProjectParkingDetails();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_ProjectParkingDetails(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Updates - (Photographs)

        [HttpGet]
        public ActionResult Print_ProjectPhotographDetails()
        {
            ClsMethod_Print_Project_ConstructionStatusPhotographs sdb = new ClsMethod_Print_Project_ConstructionStatusPhotographs();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectConstructionStatusPhotographs aa = new ClsPrp_PrmProject_Print_ProjectConstructionStatusPhotographs();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_Project_ConstructionStatusPhotographs(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Updates - (Professional Details)

        [HttpGet]
        public ActionResult Print_ProjectProfessionalsDetails()
        {
            ClsMethod_Print_Project_ProfessionalDetails sdb = new ClsMethod_Print_Project_ProfessionalDetails();
            ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_ProjectProfessionalDetails aa = new ClsPrp_PrmProject_Print_ProjectProfessionalDetails();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            //Int64 PromoterApplicationId = 0;
            //if (Session["ApplicationId"] != null)
            //{
            //    if (Session["ApplicationId"].ToString() != "0")
            //    {
            //        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //    }
            //} 
            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_AuthDesk_ProjectProfessionalDetails(ProjectID, 0, "");

            aa.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);

            //return View("Print_ProjectLandDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion


        //QUpdates QUP (Project Quarterly) Details
        #region Print QUpdates QUP - (Inventory and Construction Details)

        [HttpGet]
        public ActionResult Print_QUpdateProjectInventoryConstruction()
        {
            ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA sdb = new ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA();
            ClsMethod_Print_QUpdatesProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_QUpdatesProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory aa = new ClsPrp_PrmProject_Print_QUpdatesProjectBuildingTowerBlock_Inventory();

            Int64 QUP_ProjectID = 0;
            Int32 QUP_Year = 0;
            String QUP_QuarterName = string.Empty;
            if (Session["Project_id"] != null)
            {
                Int64? QUPProjectID = Convert.ToInt64(Session["Project_id"]);
                QUP_ProjectID = (QUPProjectID != null) ? Convert.ToInt64(QUPProjectID) : 0;
            }
            if (Session["DropDownlistyear"] != null)
            {
                Int32? QUPYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUP_Year = (QUPYear != null) ? Convert.ToInt32(QUPYear) : 0;
            }
            if (Session["DropDownlistQUATER"] != null)
            {
                String QUPQuarterName = Convert.ToString(Session["DropDownlistQUATER"]);
                QUP_QuarterName = (QUPQuarterName != null) ? Convert.ToString(QUPQuarterName) : string.Empty;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_QUpdatesProject_ConstructionInventoryDetails(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);
            aa.prpQUProjectDiaryNumberDetails = sdbDN.Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);

            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print QUpdates QUP - (Parking Details)

        [HttpGet]
        public ActionResult Print_QUpdateProjectParkingDetails()
        {
            ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA sdb = new ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA();
            ClsMethod_Print_QUpdatesProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_QUpdatesProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails aa = new ClsPrp_PrmProject_Print_QUpdatesProjectParkingDetails();

            Int64 QUP_ProjectID = 0;
            Int32 QUP_Year = 0;
            String QUP_QuarterName = string.Empty;
            if (Session["Project_id"] != null)
            {
                Int64? QUPProjectID = Convert.ToInt64(Session["Project_id"]);
                QUP_ProjectID = (QUPProjectID != null) ? Convert.ToInt64(QUPProjectID) : 0;
            }
            if (Session["DropDownlistyear"] != null)
            {
                Int32? QUPYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUP_Year = (QUPYear != null) ? Convert.ToInt32(QUPYear) : 0;
            }
            if (Session["DropDownlistQUATER"] != null)
            {
                String QUPQuarterName = Convert.ToString(Session["DropDownlistQUATER"]);
                QUP_QuarterName = (QUPQuarterName != null) ? Convert.ToString(QUPQuarterName) : string.Empty;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_QUpdatesProject_ParkingDetails(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);
            aa.prpQUProjectDiaryNumberDetails = sdbDN.Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);

            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print QUpdates QUP - (Status Construction Photographs)

        [HttpGet]
        public ActionResult Print_QUpdateProjectStatusConstructionPhotographs()
        {
            ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA sdb = new ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA();
            ClsMethod_Print_QUpdatesProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_QUpdatesProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs aa = new ClsPrp_PrmProject_Print_QUpdatesProjectStatusConstructionPhotographs();

            Int64 QUP_ProjectID = 0;
            Int32 QUP_Year = 0;
            String QUP_QuarterName = string.Empty;
            if (Session["Project_id"] != null)
            {
                Int64? QUPProjectID = Convert.ToInt64(Session["Project_id"]);
                QUP_ProjectID = (QUPProjectID != null) ? Convert.ToInt64(QUPProjectID) : 0;
            }
            if (Session["DropDownlistyear"] != null)
            {
                Int32? QUPYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUP_Year = (QUPYear != null) ? Convert.ToInt32(QUPYear) : 0;
            }
            if (Session["DropDownlistQUATER"] != null)
            {
                String QUPQuarterName = Convert.ToString(Session["DropDownlistQUATER"]);
                QUP_QuarterName = (QUPQuarterName != null) ? Convert.ToString(QUPQuarterName) : string.Empty;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_QUpdatesProject_StatusConstructionPhotographs(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);
            aa.prpQUProjectDiaryNumberDetails = sdbDN.Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);

            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print QUpdates QUP - (Internal Infrastructure Facilities)

        [HttpGet]
        public ActionResult Print_QUpdateProjectInternalInfrastructureFacilities()
        {
            ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA sdb = new ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA();
            ClsMethod_Print_QUpdatesProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_QUpdatesProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities aa = new ClsPrp_PrmProject_Print_QUpdatesProjectInternalInfrastructure_Facilities();

            Int64 QUP_ProjectID = 0;
            Int32 QUP_Year = 0;
            String QUP_QuarterName = string.Empty;
            if (Session["Project_id"] != null)
            {
                Int64? QUPProjectID = Convert.ToInt64(Session["Project_id"]);
                QUP_ProjectID = (QUPProjectID != null) ? Convert.ToInt64(QUPProjectID) : 0;
            }
            if (Session["DropDownlistyear"] != null)
            {
                Int32? QUPYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUP_Year = (QUPYear != null) ? Convert.ToInt32(QUPYear) : 0;
            }
            if (Session["DropDownlistQUATER"] != null)
            {
                String QUPQuarterName = Convert.ToString(Session["DropDownlistQUATER"]);
                QUP_QuarterName = (QUPQuarterName != null) ? Convert.ToString(QUPQuarterName) : string.Empty;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_QUpdatesProject_InternalInfrastructureFacilities(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);
            aa.prpQUProjectDiaryNumberDetails = sdbDN.Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);

            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print QUpdates QUP - (External Infrastructure Facilities)

        [HttpGet]
        public ActionResult Print_QUpdateProjectExternalInfrastructureFacilities()
        {
            ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA sdb = new ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA();
            ClsMethod_Print_QUpdatesProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_QUpdatesProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities aa = new ClsPrp_PrmProject_Print_QUpdatesProjectExternalInfrastructure_Facilities();

            Int64 QUP_ProjectID = 0;
            Int32 QUP_Year = 0;
            String QUP_QuarterName = string.Empty;
            if (Session["Project_id"] != null)
            {
                Int64? QUPProjectID = Convert.ToInt64(Session["Project_id"]);
                QUP_ProjectID = (QUPProjectID != null) ? Convert.ToInt64(QUPProjectID) : 0;
            }
            if (Session["DropDownlistyear"] != null)
            {
                Int32? QUPYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUP_Year = (QUPYear != null) ? Convert.ToInt32(QUPYear) : 0;
            }
            if (Session["DropDownlistQUATER"] != null)
            {
                String QUPQuarterName = Convert.ToString(Session["DropDownlistQUATER"]);
                QUP_QuarterName = (QUPQuarterName != null) ? Convert.ToString(QUPQuarterName) : string.Empty;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_QUpdatesProject_ExternalInfrastructureFacilities(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);
            aa.prpQUProjectDiaryNumberDetails = sdbDN.Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);

            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print QUpdates QUP - (Approvals Details)

        [HttpGet]
        public ActionResult Print_QUpdateProjectApprovals()
        {
            ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA sdb = new ClsMethod_Print_QUpdatesProject_UpdatesCIIEFPA();
            ClsMethod_Print_QUpdatesProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_QUpdatesProjectDiaryNumberDetails();
            ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails aa = new ClsPrp_PrmProject_Print_QUpdatesProjectApprovalDetails();

            Int64 QUP_ProjectID = 0;
            Int32 QUP_Year = 0;
            String QUP_QuarterName = string.Empty;
            if (Session["Project_id"] != null)
            {
                Int64? QUPProjectID = Convert.ToInt64(Session["Project_id"]);
                QUP_ProjectID = (QUPProjectID != null) ? Convert.ToInt64(QUPProjectID) : 0;
            }
            if (Session["DropDownlistyear"] != null)
            {
                Int32? QUPYear = Convert.ToInt32(Session["DropDownlistyear"].ToString());
                QUP_Year = (QUPYear != null) ? Convert.ToInt32(QUPYear) : 0;
            }
            if (Session["DropDownlistQUATER"] != null)
            {
                String QUPQuarterName = Convert.ToString(Session["DropDownlistQUATER"]);
                QUP_QuarterName = (QUPQuarterName != null) ? Convert.ToString(QUPQuarterName) : string.Empty;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_QUpdatesProject_ProjectApprovals(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);
            aa.prpQUProjectDiaryNumberDetails = sdbDN.Display_QUpdatesProject_RegDiaryNumberByID_ForPrint(QUP_ProjectID, QUP_Year, QUP_QuarterName, userRole);

            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion


        // User Role Function
        private string getUserRole()
        {
            string varRet = string.Empty;
            if (User.IsInRole("Promoter"))
                varRet = "19845cf7-c32d-4d4d-8f71-b19078b5bf6c";
            if (User.IsInRole("RealEstateAgent"))
                varRet = "5cab7404-0136-4e22-87ef-9cdaca6016e5";
            if (User.IsInRole("Complainant"))
                varRet = "53c2bc00-c000-4666-a30d-61b4151b5133";
            if (User.IsInRole("HelpDesk"))
                varRet = "7b9d725a-b33c-4aba-934a-bee1ec13f684";
            if (User.IsInRole("SecretaryRERA"))
                varRet = "15ac7786-a35e-46a3-ae19-8befd003dcfd";
            if (User.IsInRole("ManagerDesk"))
                varRet = "e583ee7f-aaa3-49bd-afc8-79c877afe591";
            if (User.IsInRole("Administrator"))
                varRet = "66d13a1a-ef3a-4eb3-b88c-95b06f451c74";
            if (User.IsInRole("LegalAdvisorDesk"))
                varRet = "7330c9a0-4296-4ddf-a421-0d0c491adf2d";
            if (User.IsInRole("PStoMembers"))
                varRet = "97eba4f1-7be4-4ba2-848d-8ad65a317455";
            if (User.IsInRole("Programmer"))
                varRet = "319a2b07-788f-4f90-9cda-3bca6ed81d3c";
            if (User.IsInRole("Authority"))
                varRet = "21f8f78b-5d55-4138-a503-57fcace0800e";
            return varRet;
        }
        

        #region Print Consolidated Project Report (Form A)

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Print_ProjectConsolidatedReport(string reportType)
        {
            Int64 ProjectID = 0;
            Int64 PromoterID = 0;
            string Diarynumber = string.Empty;

            string userRole = getUserRole();


            //string userRole = string.Empty;
            //Int64 ProjectID = 0;
            userRole = getUserRole();
            if (Session["zipProjectDiaryNumber"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;

                string Diary_Number = Convert.ToString(Session["zipProjectDiaryNumber"]);
                Diarynumber = (!string.IsNullOrEmpty(Diary_Number)) ? Diary_Number : "";
            }
            if (Session["zipPromoterID"] != null)
            {
                PromoterID = Convert.ToInt64(Session["zipPromoterID"]);
            }
            Session["ApplicationId"] = PromoterID;

            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();
            ClsPrp_PromoterType PrmType = new ClsPrp_PromoterType();
            PrmType = objDB.Display_PromoterType(PromoterID);

            Session["User_Type"] = PrmType.Flag.ToString();



            // 1. Instantiate the Master Model we just created
            ClsPrp_PrmProject_Print_ConsolidatedReport masterModel = new ClsPrp_PrmProject_Print_ConsolidatedReport();



            //ClsMethod_Print_ProjectDiaryNumberDetails diaryDb = new ClsMethod_Print_ProjectDiaryNumberDetails();
            //ClsMethod_Print_PromoterDocuments sdbPromDoc = new ClsMethod_Print_PromoterDocuments();

            //masterModel.Registration.prpProjectDiaryNumberDetails = diaryDb.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);
            //masterModel.PromoterDocuments.prpongoing = sdbPromDoc.Display_PrmPromoter_Promoter_Documents_PromoterId(PromoterID);

            if (reportType == "Project")
            {
                //aa.prpongoing = sdb.Display_Project_RegistrationAll(ProjectID);
                //aa.ProjectType_Registration = sdb.Display_Project_RegistrationTypeProject(ProjectID);
                //aa.prpongoing = sdb.Display_Project_Landdetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_KhasraAreaDetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_ApprovalDetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_SpecialBankAccountDetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_Documents_ByProjectId(ProjectID);
                //aa.prpongoing = sdb.Display_Project_Payment(ProjectID);
                //aa.prpProjectPaymentIntegrationDetails = sdb.Display_Print_ProjectApplicationPaymentTransactions(ProjectID);
                // 2. PROJECT REGISTRATION DETAILS & PAYMENTS
                ClsMethod_Print_ProjectRegistration sdbReg = new ClsMethod_Print_ProjectRegistration();
                ClsMethod_Print_ProjectLandDetails sdbLand = new ClsMethod_Print_ProjectLandDetails();
                ClsMethod_Print_ProjectKhasraAreaDetails sdbKhasra = new ClsMethod_Print_ProjectKhasraAreaDetails();
                ClsMethod_Print_ProjectApprovalDetails sdbApp = new ClsMethod_Print_ProjectApprovalDetails();
                ClsMethod_Print_ProjectSpecialBankAccountDetails sdbBank = new ClsMethod_Print_ProjectSpecialBankAccountDetails();
                ClsMethod_Print_ProjectDocuments sdbDoc = new ClsMethod_Print_ProjectDocuments();

                masterModel.Registration.prpongoing = sdbReg.Display_Project_RegistrationAll(ProjectID);
                masterModel.Registration.ProjectType_Registration = sdbReg.Display_Project_RegistrationTypeProject(ProjectID);
                masterModel.Land.prpongoing = sdbLand.Display_Project_Landdetails(ProjectID);
                masterModel.Khasra.prpongoing = sdbKhasra.Display_Project_KhasraAreaDetails(ProjectID);
                masterModel.Approvals.prpongoing = sdbApp.Display_Project_ApprovalDetails(ProjectID);
                masterModel.Bank.prpongoing = sdbBank.Display_Project_SpecialBankAccountDetails(ProjectID);
                masterModel.Documents.prpongoing = sdbDoc.Display_Project_Documents_ByProjectId(ProjectID);
                masterModel.Payments.prpongoing = sdbReg.Display_Project_Payment(ProjectID);
                masterModel.Payments.prpProjectPaymentIntegrationDetails = sdbReg.Display_Print_ProjectApplicationPaymentTransactions(ProjectID);


                // 8. LITIGATIONS
                ClsMethod_Print_ProjectLitigations sdbLit = new ClsMethod_Print_ProjectLitigations();
                masterModel.Litigations.prpongoing = sdbLit.Display_Project_Litigations(ProjectID);

                // 11. DIARY NUMBER (Common) PROMOTER & PROJECT
                ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
                masterModel.Registration.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);
                ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
                masterModel.PromoterDiaryNumberDetails.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(PromoterID, userRole);

                ViewBag.ReportType = "Project";
            }
            else if (reportType == "Promoter")
            {
                // 10. PROMOTER
                //ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();
                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
                ClsMethod_Print_PromoterDocuments sdb = new ClsMethod_Print_PromoterDocuments();
                if (PrmType.Flag == 1)
                {
                    masterModel.PromoterProfile = objDB.Display_PromoterIndividualsProfile_ByApplicationID(PromoterID); //////////////////////////////////////
                    int? statecode = Convert.ToInt32(masterModel.PromoterProfile.State);
                    int? DistrictCode = Convert.ToInt32(masterModel.PromoterProfile.District);
                    masterModel.PromoterProfile.State = objdis.State_Name(statecode);
                    masterModel.PromoterProfile.District = objdis.District_Name(DistrictCode);
                }
                else
                {
                    masterModel.PromoterOtherMemberDetails = objDB.Display_PromoterOtherThenIndProfile_ByApplicationID(PromoterID);////////////////////////
                    int? statecode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.State);
                    int? DistrictCode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.District);
                    masterModel.PromoterOtherMemberDetails.Org_State = objdis.State_Name(statecode);
                    masterModel.PromoterOtherMemberDetails.Org_District = objdis.District_Name(DistrictCode);

                    int? BusinessPlace_AddressStateCode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.State);
                    int? BusinessPlace_AddressDistrictCode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.District);
                    masterModel.PromoterOtherMemberDetails.State = objdis.State_Name(BusinessPlace_AddressStateCode);
                    masterModel.PromoterOtherMemberDetails.District = objdis.District_Name(BusinessPlace_AddressDistrictCode);

                }

                masterModel.PromoterOtherMemberDetails.prpMem = objDB.Display_PromoterOrganizationMembers_ByApplicationID(PromoterID);/////////////////////////////////
                masterModel.PromoterOtherMemberDetails.Prpparententity = objDB.Display_ParentEntityDetail_ByApplicationID(PromoterID);/////////////////////////////////
                masterModel.PromoterOtherMemberDetails.prpTrackRecord = objDB.DisplaybyID_PromoterOngoingComplete_ByApplicationID(PromoterID);/////////////////////////
                masterModel.PromoterOtherMemberDetails.prpLitigations = objDB.Display_PromoterLitigations_ByApplicationID(PromoterID);/////////////////////////////////
                masterModel.PromoterDocuments.prpongoing = sdb.Display_PrmPromoter_Promoter_Documents_PromoterId(PromoterID);//////////////////////////////////////////


                // 11. DIARY NUMBER (Common) PROMOTER & PROJECT
                ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
                masterModel.Registration.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);
                ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
                masterModel.PromoterDiaryNumberDetails.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(PromoterID, userRole);

                ViewBag.ReportType = "Promoter";
                ViewBag.PromoterType = PrmType.Flag;
            }
            else if (reportType == "Quaterly")
            {
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectBuildingTowerBlock_Construction(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectInternalInfrastructure_Facilities(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectParkingDetails(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectProfessionalDetails(ProjectID, 0, "");
                //Print_ProjectPhotographDetailsaa.prpongoing = sdb.Display_AuthDesk_ProjectExternalInfrastructure_Facilities(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_Project_ConstructionStatusPhotographs(ProjectID, 0, "");
                // 9. Quaterly UPDATES (Construction, Inventory, Facilities, Parking)
                ClsMethod_Print_Project_Updates_CIIEFP sdbUpdates = new ClsMethod_Print_Project_Updates_CIIEFP();
                ClsMethod_Print_Project_ProfessionalDetails sdbProf = new ClsMethod_Print_Project_ProfessionalDetails();
                ClsMethod_Print_Project_ConstructionStatusPhotographs sdbPhoto = new ClsMethod_Print_Project_ConstructionStatusPhotographs();
                masterModel.Construction.prpongoing = sdbUpdates.Display_AuthDesk_ProjectBuildingTowerBlock_Construction(ProjectID, 0, "");
                masterModel.Inventory.prpongoing = sdbUpdates.Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(ProjectID, 0, "");
                masterModel.InternalFacilities.prpongoing = sdbUpdates.Display_AuthDesk_ProjectInternalInfrastructure_Facilities(ProjectID, 0, "");
                masterModel.Parking.prpongoing = sdbUpdates.Display_AuthDesk_ProjectParkingDetails(ProjectID, 0, "");
                masterModel.Professionals.prpongoing = sdbProf.Display_AuthDesk_ProjectProfessionalDetails(ProjectID, 0, "");
                masterModel.ExternalFacilities.prpongoing = sdbUpdates.Display_AuthDesk_ProjectExternalInfrastructure_Facilities(ProjectID, 0, "");
                masterModel.Photographs.prpongoing = sdbPhoto.Display_AuthDesk_Project_ConstructionStatusPhotographs(ProjectID, 0, "");

                ViewBag.ReportType = "Quaterly";

            }
            else
            {
                //aa.prpongoing = sdb.Display_Project_RegistrationAll(ProjectID);
                //aa.ProjectType_Registration = sdb.Display_Project_RegistrationTypeProject(ProjectID);
                //aa.prpongoing = sdb.Display_Project_Landdetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_KhasraAreaDetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_ApprovalDetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_SpecialBankAccountDetails(ProjectID);
                //aa.prpongoing = sdb.Display_Project_Documents_ByProjectId(ProjectID);
                //aa.prpongoing = sdb.Display_Project_Payment(ProjectID);
                //aa.prpProjectPaymentIntegrationDetails = sdb.Display_Print_ProjectApplicationPaymentTransactions(ProjectID);
                // 2. PROJECT REGISTRATION DETAILS & PAYMENTS
                ClsMethod_Print_ProjectRegistration sdbReg = new ClsMethod_Print_ProjectRegistration();
                ClsMethod_Print_ProjectLandDetails sdbLand = new ClsMethod_Print_ProjectLandDetails();
                ClsMethod_Print_ProjectKhasraAreaDetails sdbKhasra = new ClsMethod_Print_ProjectKhasraAreaDetails();
                ClsMethod_Print_ProjectApprovalDetails sdbApp = new ClsMethod_Print_ProjectApprovalDetails();
                ClsMethod_Print_ProjectSpecialBankAccountDetails sdbBank = new ClsMethod_Print_ProjectSpecialBankAccountDetails();
                ClsMethod_Print_ProjectDocuments sdbDoc = new ClsMethod_Print_ProjectDocuments();

                masterModel.Registration.prpongoing = sdbReg.Display_Project_RegistrationAll(ProjectID);
                masterModel.Registration.ProjectType_Registration = sdbReg.Display_Project_RegistrationTypeProject(ProjectID);
                masterModel.Land.prpongoing = sdbLand.Display_Project_Landdetails(ProjectID);
                masterModel.Khasra.prpongoing = sdbKhasra.Display_Project_KhasraAreaDetails(ProjectID);
                masterModel.Approvals.prpongoing = sdbApp.Display_Project_ApprovalDetails(ProjectID);
                masterModel.Bank.prpongoing = sdbBank.Display_Project_SpecialBankAccountDetails(ProjectID);
                masterModel.Documents.prpongoing = sdbDoc.Display_Project_Documents_ByProjectId(ProjectID);
                masterModel.Payments.prpongoing = sdbReg.Display_Project_Payment(ProjectID);
                masterModel.Payments.prpProjectPaymentIntegrationDetails = sdbReg.Display_Print_ProjectApplicationPaymentTransactions(ProjectID);


                // 8. LITIGATIONS
                ClsMethod_Print_ProjectLitigations sdbLit = new ClsMethod_Print_ProjectLitigations();
                masterModel.Litigations.prpongoing = sdbLit.Display_Project_Litigations(ProjectID);


                //aa.prpongoing = sdb.Display_AuthDesk_ProjectBuildingTowerBlock_Construction(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectInternalInfrastructure_Facilities(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectParkingDetails(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_ProjectProfessionalDetails(ProjectID, 0, "");
                //Print_ProjectPhotographDetailsaa.prpongoing = sdb.Display_AuthDesk_ProjectExternalInfrastructure_Facilities(ProjectID, 0, "");
                //aa.prpongoing = sdb.Display_AuthDesk_Project_ConstructionStatusPhotographs(ProjectID, 0, "");
                // 9. Quaterly UPDATES (Construction, Inventory, Facilities, Parking)
                ClsMethod_Print_Project_Updates_CIIEFP sdbUpdates = new ClsMethod_Print_Project_Updates_CIIEFP();
                ClsMethod_Print_Project_ProfessionalDetails sdbProf = new ClsMethod_Print_Project_ProfessionalDetails();
                ClsMethod_Print_Project_ConstructionStatusPhotographs sdbPhoto = new ClsMethod_Print_Project_ConstructionStatusPhotographs();
                masterModel.Construction.prpongoing = sdbUpdates.Display_AuthDesk_ProjectBuildingTowerBlock_Construction(ProjectID, 0, "");
                masterModel.Inventory.prpongoing = sdbUpdates.Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(ProjectID, 0, "");
                masterModel.InternalFacilities.prpongoing = sdbUpdates.Display_AuthDesk_ProjectInternalInfrastructure_Facilities(ProjectID, 0, "");
                masterModel.Parking.prpongoing = sdbUpdates.Display_AuthDesk_ProjectParkingDetails(ProjectID, 0, "");
                masterModel.Professionals.prpongoing = sdbProf.Display_AuthDesk_ProjectProfessionalDetails(ProjectID, 0, "");
                masterModel.ExternalFacilities.prpongoing = sdbUpdates.Display_AuthDesk_ProjectExternalInfrastructure_Facilities(ProjectID, 0, "");
                masterModel.Photographs.prpongoing = sdbPhoto.Display_AuthDesk_Project_ConstructionStatusPhotographs(ProjectID, 0, "");



                // 10. PROMOTER
                //ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();
                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
                ClsMethod_Print_PromoterDocuments sdb = new ClsMethod_Print_PromoterDocuments();

                if (PrmType.Flag == 1)
                {
                    masterModel.PromoterProfile = objDB.Display_PromoterIndividualsProfile_ByApplicationID(PromoterID); //////////////////////////////////////
                    int? statecode = Convert.ToInt32(masterModel.PromoterProfile.State);
                    int? DistrictCode = Convert.ToInt32(masterModel.PromoterProfile.District);
                    masterModel.PromoterProfile.State = objdis.State_Name(statecode);
                    masterModel.PromoterProfile.District = objdis.District_Name(DistrictCode);
                }
                else
                {
                    masterModel.PromoterOtherMemberDetails = objDB.Display_PromoterOtherThenIndProfile_ByApplicationID(PromoterID);////////////////////////
                    int? statecode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.State);
                    int? DistrictCode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.District);
                    masterModel.PromoterOtherMemberDetails.Org_State = objdis.State_Name(statecode);
                    masterModel.PromoterOtherMemberDetails.Org_District = objdis.District_Name(DistrictCode);

                    int? BusinessPlace_AddressStateCode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.State);
                    int? BusinessPlace_AddressDistrictCode = Convert.ToInt32(masterModel.PromoterOtherMemberDetails.District);
                    masterModel.PromoterOtherMemberDetails.State = objdis.State_Name(BusinessPlace_AddressStateCode);
                    masterModel.PromoterOtherMemberDetails.District = objdis.District_Name(BusinessPlace_AddressDistrictCode);

                }

                masterModel.PromoterOtherMemberDetails.prpMem = objDB.Display_PromoterOrganizationMembers_ByApplicationID(PromoterID);/////////////////////////////////
                masterModel.PromoterOtherMemberDetails.Prpparententity = objDB.Display_ParentEntityDetail_ByApplicationID(PromoterID);/////////////////////////////////
                masterModel.PromoterOtherMemberDetails.prpTrackRecord = objDB.DisplaybyID_PromoterOngoingComplete_ByApplicationID(PromoterID);/////////////////////////
                masterModel.PromoterOtherMemberDetails.prpLitigations = objDB.Display_PromoterLitigations_ByApplicationID(PromoterID);/////////////////////////////////
                masterModel.PromoterDocuments.prpongoing = sdb.Display_PrmPromoter_Promoter_Documents_PromoterId(PromoterID);//////////////////////////////////////////


                // 11. DIARY NUMBER (Common) PROMOTER & PROJECT
                ClsMethod_Print_ProjectDiaryNumberDetails sdbDN = new ClsMethod_Print_ProjectDiaryNumberDetails();
                masterModel.Registration.prpProjectDiaryNumberDetails = sdbDN.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);
                ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
                masterModel.PromoterDiaryNumberDetails.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(PromoterID, userRole);

                ViewBag.ReportType = "All";
                ViewBag.PromoterType = PrmType.Flag;
            }


            // Return the massive model to RazorPDF
            //return new RazorPDF.PdfActionResult(masterModel);
            return new RazorPDF.PdfActionResult(masterModel, (writer, document) =>
            {
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                writer.PageEvent = new PageNumberPdfPageEventHelper(true);
                document.AddTitle("Project Consolidated Report");
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetProjectDocumentSelection()
        {
            Int64 ProjectID = 0;
            Int64 PromoterID = 0;
            Int32 vDocumentFlag = 0;

            if (Session["zipProjectDiaryNumber"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }
            Session["Project_id"] = ProjectID;

            if (Session["zipPromoterID"] != null)
            {
                PromoterID = Convert.ToInt64(Session["zipPromoterID"]);
            }
            Session["ApplicationId"] = PromoterID;

            string userRole = string.Empty;
            userRole = getUserRole();
            vDocumentFlag = 1;
            var masterModel = new ClsPrp_PrmProject_Print_ConsolidatedReport();

            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();
            ClsPrp_PromoterType PrmType = new ClsPrp_PromoterType();
            PrmType = objDB.Display_PromoterType(PromoterID);

            Session["User_Type"] = PrmType.Flag.ToString();

            ClsMethod_Print_ProjectDocuments sdbDoc = new ClsMethod_Print_ProjectDocuments();
            ClsMethod_Print_ProjectDiaryNumberDetails diaryDb = new ClsMethod_Print_ProjectDiaryNumberDetails();
            ClsMethod_Print_PromoterDocuments sdbPromDoc = new ClsMethod_Print_PromoterDocuments();
            ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
            ClsMethod_View_ProjectDocuments sdbtr = new ClsMethod_View_ProjectDocuments();

            masterModel.Registration.prpProjectDiaryNumberDetails = diaryDb.Display_Project_RegDiaryNumberByPromoterID_ForPrint(ProjectID, userRole);
            masterModel.Documents.prpongoing = sdbDoc.Display_Project_Documents_ByProjectId(ProjectID);
            masterModel.ApprovalDocuments.prpongoing = sdb.Display_Project_ApprovalDetails(ProjectID);
            masterModel.PromoterDocuments.prpongoing = sdbPromDoc.Display_PrmPromoter_Promoter_Documents_PromoterId(PromoterID);
            masterModel.TrashDocuments.prpongoing = sdbtr.Display_Project_TrashDocuments_ByIdFlag(ProjectID, userRole, PromoterID, vDocumentFlag);

            //ClsMethod_Print_Project_Updates_CIIEFP sdbUpdates = new ClsMethod_Print_Project_Updates_CIIEFP();
            //masterModel.Construction.prpongoing = sdbUpdates.Display_AuthDesk_ProjectBuildingTowerBlock_Construction(ProjectID, 0, "");
            //masterModel.Inventory.prpongoing = sdbUpdates.Display_AuthDesk_ProjectBuildingTowerBlock_Inventory(ProjectID, 0, "");
            //masterModel.ExternalFacilities.prpongoing = sdbUpdates.Display_AuthDesk_ProjectExternalInfrastructure_Facilities(ProjectID, 0, "");
            //masterModel.InternalFacilities.prpongoing = sdbUpdates.Display_AuthDesk_ProjectInternalInfrastructure_Facilities(ProjectID, 0, "");
            //masterModel.Parking.prpongoing = sdbUpdates.Display_AuthDesk_ProjectParkingDetails(ProjectID, 0, "");
            //// 10. PHOTOGRAPHS
            //ClsMethod_Print_Project_ConstructionStatusPhotographs sdbPhoto = new ClsMethod_Print_Project_ConstructionStatusPhotographs();
            //masterModel.Photographs.prpongoing = sdbPhoto.Display_AuthDesk_Project_ConstructionStatusPhotographs(ProjectID, 0, "");

            //// 11. PROFESSIONALS
            //ClsMethod_Print_Project_ProfessionalDetails sdbProf = new ClsMethod_Print_Project_ProfessionalDetails();
            //masterModel.Professionals.prpongoing = sdbProf.Display_AuthDesk_ProjectProfessionalDetails(ProjectID, 0, "");

            return PartialView("PrintProjectPromoDocument", masterModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult DownloadZipByType(string docType, List<string> files)
        {
            if (files == null || files.Count == 0)
            {
                return new HttpStatusCodeResult(400, "No files selected.");
            }

            string zipFileName = docType + "_Documents_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".zip";

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    //AddRemoteFilesToZip(archive, files, docType);
                    if (docType == "Approval")
                    {
                        AddRemoteFilesToZipWithNames(archive, files, docType);
                    }
                    else
                    {
                        AddRemoteFilesToZip(archive, files, docType);
                    }

                }
                memoryStream.Position = 0;
                return File(memoryStream.ToArray(), "application/zip", zipFileName);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult DownloadCompletedZip(string jobId)
        {
            ZipDownloadProgress progress;

            if (!_zipProgress.TryGetValue(jobId, out progress))
            {
                return HttpNotFound("Download job not found.");
            }

            if (!progress.Completed)
            {
                return new HttpStatusCodeResult(
                    409,
                    "ZIP is still being created.");
            }

            if (!string.IsNullOrEmpty(progress.Error))
            {
                return new HttpStatusCodeResult(
                    500,
                    "ZIP creation failed.");
            }

            if (!System.IO.File.Exists(progress.FilePath))
            {
                return HttpNotFound("ZIP file not found.");
            }

            byte[] bytes = System.IO.File.ReadAllBytes(progress.FilePath);

            string fileName = progress.FileName;

            // Delete after reading
            try
            {
                System.IO.File.Delete(progress.FilePath);

                ZipDownloadProgress removed;

                _zipProgress.TryRemove(jobId, out removed);
            }
            catch
            {
                // Ignore cleanup error
            }

            return File(bytes, "application/zip", fileName);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetZipDownloadProgress(string jobId)
        {
            ZipDownloadProgress progress;

            if (!_zipProgress.TryGetValue(jobId, out progress))
            {
                return Json(new
                {
                    success = false,
                    message = "Download job not found."
                },
                JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = true,
                percent = progress.Percent,
                completedFiles = progress.CompletedFiles,
                totalFiles = progress.TotalFiles,
                status = progress.Status,
                completed = progress.Completed,
                error = progress.Error
            },
            JsonRequestBehavior.AllowGet);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public JsonResult StartZipDownload(string docType, List<string> files)
        //{
        //    if (files == null || files.Count == 0)
        //    {
        //        Response.StatusCode = 400;

        //        return Json(new
        //        {
        //            success = false,
        //            message = "No files selected."
        //        });
        //    }

        //    string jobId = Guid.NewGuid().ToString("N");

        //    string zipFileName = docType + "_Documents_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".zip";

        //    string zipFolder = Server.MapPath("~/App_Data/ZipDownloads");

        //    if (!Directory.Exists(zipFolder))
        //    {
        //        Directory.CreateDirectory(zipFolder);
        //    }

        //    string zipPath = Path.Combine(zipFolder, jobId + ".zip");

        //    var progress = new ZipDownloadProgress
        //    {
        //        TotalFiles = files.Count,
        //        CompletedFiles = 0,
        //        Percent = 0,
        //        Status = "Preparing ZIP...",
        //        FilePath = zipPath,
        //        FileName = zipFileName,
        //        Completed = false
        //    };

        //    _zipProgress[jobId] = progress;

        //    // Start ZIP creation in background
        //    Task.Run(() =>
        //    {
        //        try
        //        {
        //            CreateZipInBackground(
        //                jobId,
        //                docType,
        //                files,
        //                zipPath
        //            );
        //        }
        //        catch (Exception ex)
        //        {
        //            ZipDownloadProgress p;

        //            if (_zipProgress.TryGetValue(jobId, out p))
        //            {
        //                p.Error = ex.ToString();
        //                p.Status = "Failed";
        //                p.Completed = true;
        //            }
        //        }
        //    });

        //    return Json(new
        //    {
        //        success = true,
        //        jobId = jobId
        //    });
        //}
        //private void CreateZipInBackground(string jobId, string docType, List<string> files, string zipPath)
        //{
        //    ZipDownloadProgress progress = _zipProgress[jobId];

        //    try
        //    {
        //        progress.Status = "Creating ZIP...";

        //        using (var fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
        //        using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
        //        {
        //            if (docType == "Approval")
        //            {
        //                AddRemoteFilesToZipWithNamesProgress(archive, files, docType, progress);
        //            }
        //            else
        //            {
        //                AddRemoteFilesToZipProgress(archive, files, docType, progress);
        //            }
        //        }

        //        progress.CompletedFiles =
        //            progress.TotalFiles;

        //        progress.Percent = 100;
        //        progress.Status = "ZIP ready";
        //        progress.Completed = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        progress.Error = ex.ToString();
        //        progress.Status = "Failed";
        //        progress.Completed = true;
        //    }
        //}
        [AllowAnonymous]
        [HttpPost]
        public JsonResult StartZipDownload(string docType, List<string> files)
        {
            if (files == null || files.Count == 0)
            {
                Response.StatusCode = 400;
                return Json(new { success = false, message = "No files selected." });
            }

            string jobId = Guid.NewGuid().ToString("N");
            string zipFileName = docType + "_Documents_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".zip";
            string zipFolder = Server.MapPath("~/App_Data/ZipDownloads");

            if (!Directory.Exists(zipFolder))
            {
                Directory.CreateDirectory(zipFolder);
            }

            string zipPath = Path.Combine(zipFolder, jobId + ".zip");

            var progress = new ZipDownloadProgress
            {
                TotalFiles = files.Count,
                CompletedFiles = 0,
                Percent = 0,
                Status = "Preparing ZIP...",
                FilePath = zipPath,
                FileName = zipFileName,
                Completed = false
            };

            _zipProgress[jobId] = progress;

            // Start ZIP creation in background (async)
            Task.Run(async () =>
            {
                try
                {
                    await CreateZipInBackgroundAsync(jobId, docType, files, zipPath);
                }
                catch (Exception ex)
                {
                    ZipDownloadProgress p;
                    if (_zipProgress.TryGetValue(jobId, out p))
                    {
                        p.Error = ex.ToString();
                        p.Status = "Failed";
                        p.Completed = true;
                    }
                }
            });

            return Json(new { success = true, jobId = jobId });
        }

        private async Task CreateZipInBackgroundAsync(string jobId, string docType, List<string> files, string zipPath)
        {
            ZipDownloadProgress progress = _zipProgress[jobId];

            try
            {
                progress.Status = "Creating ZIP...";

                using (var fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    if (docType == "Approval")
                    {
                        await AddRemoteFilesToZipWithNamesProgressAsync(archive, files, docType, progress);
                    }
                    else
                    {
                        await AddRemoteFilesToZipProgressAsync(archive, files, docType, progress);
                    }
                }

                progress.CompletedFiles = progress.TotalFiles;
                progress.Percent = 100;
                progress.Status = "ZIP ready";
                progress.Completed = true;
            }
            catch (Exception ex)
            {
                progress.Error = ex.ToString();
                progress.Status = "Failed";
                progress.Completed = true;
            }
        }
        //private void AddRemoteFilesToZipProgress(ZipArchive archive, List<string> fileUrls, string folderName, ZipDownloadProgress progress)
        //{
        //    if (fileUrls == null)
        //        return;

        //    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

        //    using (var client = new System.Net.WebClient())
        //    {
        //        foreach (var url in fileUrls)
        //        {
        //            try
        //            {
        //                progress.Status = "Downloading document " + (progress.CompletedFiles + 1) + " of " + progress.TotalFiles + "...";

        //                byte[] fileBytes = client.DownloadData(url);

        //                string fileName = Path.GetFileName(new Uri(url).LocalPath);

        //                string entryName = folderName + "/" + fileName;

        //                var entry = archive.CreateEntry(entryName, CompressionLevel.Fastest);

        //                using (var entryStream = entry.Open())
        //                {
        //                    entryStream.Write(fileBytes, 0, fileBytes.Length);
        //                }

        //                progress.CompletedFiles++;

        //                progress.Percent = (int)Math.Round(((double)progress.CompletedFiles / progress.TotalFiles) * 100);

        //                progress.Status = "Downloaded " + progress.CompletedFiles + " of " + progress.TotalFiles;
        //            }
        //            catch (Exception ex)
        //            {
        //                string strex = ex.ToString();

        //                // Still count this file so progress doesn't get stuck
        //                progress.CompletedFiles++;
        //                progress.Percent = (int)Math.Round(((double)progress.CompletedFiles / progress.TotalFiles) * 100);
        //            }
        //        }
        //    }
        //}
        //private void AddRemoteFilesToZipWithNamesProgress(ZipArchive archive, List<string> nameUrlPairs, string folderName, ZipDownloadProgress progress)
        //{
        //    if (nameUrlPairs == null)
        //        return;

        //    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

        //    using (var client = new System.Net.WebClient())
        //    {
        //        int counter = 1;

        //        foreach (var pair in nameUrlPairs)
        //        {
        //            try
        //            {
        //                progress.Status = "Downloading document " + (progress.CompletedFiles + 1) + " of " + progress.TotalFiles + "...";

        //                var parts = pair.Split(new string[] { "||" }, StringSplitOptions.None);

        //                if (parts.Length != 2)
        //                {
        //                    progress.CompletedFiles++;
        //                    continue;
        //                }

        //                string docName = parts[0];
        //                string url = parts[1];

        //                byte[] fileBytes = client.DownloadData(url);

        //                string extension = Path.GetExtension(new Uri(url).LocalPath);

        //                string safeName = string.Join("_", docName.Split(Path.GetInvalidFileNameChars()));

        //                string entryName = folderName + "/" + counter + "_" + safeName + extension;
        //                counter++;

        //                var entry = archive.CreateEntry(entryName, CompressionLevel.Fastest);

        //                using (var entryStream = entry.Open())
        //                {
        //                    entryStream.Write(fileBytes, 0, fileBytes.Length);
        //                }

        //                progress.CompletedFiles++;
        //                progress.Percent = (int)Math.Round(((double)progress.CompletedFiles / progress.TotalFiles) * 100);

        //                progress.Status = "Downloaded " + progress.CompletedFiles + " of " + progress.TotalFiles;
        //            }
        //            catch (Exception ex)
        //            {
        //                string strex = ex.ToString();
        //                progress.CompletedFiles++;

        //                progress.Percent = (int)Math.Round(((double)progress.CompletedFiles / progress.TotalFiles) * 100);
        //            }
        //        }
        //    }
        //}
        private static readonly HttpClient _httpClient = new HttpClient();

        private async Task AddRemoteFilesToZipProgressAsync(ZipArchive archive, List<string> fileUrls, string folderName, ZipDownloadProgress progress)
        {
            if (fileUrls == null) return;

            var semaphore = new SemaphoreSlim(5);
            var zipLock = new object();
            var progressLock = new object();

            var tasks = fileUrls.Select(async url =>
            {
                await semaphore.WaitAsync();
                try
                {
                    byte[] fileBytes = await _httpClient.GetByteArrayAsync(url);
                    string fileName = Path.GetFileName(new Uri(url).LocalPath);
                    string entryName = folderName + "/" + fileName;

                    lock (zipLock)
                    {
                        var entry = archive.CreateEntry(entryName, CompressionLevel.Fastest);
                        using (var entryStream = entry.Open())
                        {
                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("FAILED: " + url + " | " + ex.Message);
                }
                finally
                {
                    lock (progressLock)
                    {
                        progress.CompletedFiles++;
                        progress.Percent = (int)Math.Round(((double)progress.CompletedFiles / progress.TotalFiles) * 100);
                        progress.Status = "Downloaded " + progress.CompletedFiles + " of " + progress.TotalFiles;
                    }
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
        }

        private async Task AddRemoteFilesToZipWithNamesProgressAsync(ZipArchive archive, List<string> nameUrlPairs, string folderName, ZipDownloadProgress progress)
        {
            if (nameUrlPairs == null) return;

            var semaphore = new SemaphoreSlim(5);
            var zipLock = new object();
            var progressLock = new object();
            var counterLock = new object();
            int counter = 1;

            var tasks = nameUrlPairs.Select(async pair =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var parts = pair.Split(new string[] { "||" }, StringSplitOptions.None);
                    if (parts.Length != 2) return;

                    string docName = parts[0];
                    string url = parts[1];

                    byte[] fileBytes = await _httpClient.GetByteArrayAsync(url);
                    string extension = Path.GetExtension(new Uri(url).LocalPath);
                    string safeName = string.Join("_", docName.Split(Path.GetInvalidFileNameChars()));

                    lock (zipLock)
                    {
                        int myNumber;
                        lock (counterLock)
                        {
                            myNumber = counter++;
                        }

                        string entryName = folderName + "/" + myNumber + "_" + safeName + extension;
                        var entry = archive.CreateEntry(entryName, CompressionLevel.Fastest);
                        using (var entryStream = entry.Open())
                        {
                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("FAILED: " + pair + " | " + ex.Message);
                }
                finally
                {
                    lock (progressLock)
                    {
                        progress.CompletedFiles++;
                        progress.Percent = (int)Math.Round(((double)progress.CompletedFiles / progress.TotalFiles) * 100);
                        progress.Status = "Downloaded " + progress.CompletedFiles + " of " + progress.TotalFiles;
                    }
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
        }










        private void AddRemoteFilesToZip(ZipArchive archive, List<string> fileUrls, string folderName)
        {
            if (fileUrls == null) return;

            using (var client = new System.Net.WebClient())
            {
                foreach (var url in fileUrls)
                {
                    try
                    {
                        byte[] fileBytes = client.DownloadData(url);
                        string fileName = Path.GetFileName(new Uri(url).LocalPath);
                        string entryName = folderName + "/" + fileName;

                        var entry = archive.CreateEntry(entryName);
                        using (var entryStream = entry.Open())
                        {
                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        string strex = ex.ToString();
                    }
                }
            }
        }

        private void AddRemoteFilesToZipWithNames(ZipArchive archive, List<string> nameUrlPairs, string folderName)
        {
            if (nameUrlPairs == null) return;

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (var client = new System.Net.WebClient())
            {
                int counter = 1;
                foreach (var pair in nameUrlPairs)
                {
                    try
                    {
                        var parts = pair.Split(new string[] { "||" }, StringSplitOptions.None);
                        if (parts.Length != 2) continue;

                        string docName = parts[0];
                        string url = parts[1];

                        byte[] fileBytes = client.DownloadData(url);
                        string extension = Path.GetExtension(new Uri(url).LocalPath);

                        // sanitize the document name for use as a filename
                        string safeName = string.Join("_", docName.Split(Path.GetInvalidFileNameChars()));

                        string entryName = folderName + "/" + counter + "_" + safeName + extension;
                        counter++;

                        var entry = archive.CreateEntry(entryName);
                        using (var entryStream = entry.Open())
                        {
                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        string strex = ex.ToString();
                    }
                }
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult DownloadSingleFile(string fileUrl, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
            {
                return new HttpStatusCodeResult(400, "File URL is required.");
            }

            try
            {
                using (var client = new System.Net.WebClient())
                {
                    byte[] fileBytes = client.DownloadData(fileUrl);
                    string downloadName = !string.IsNullOrWhiteSpace(fileName) ? fileName : Path.GetFileName(new Uri(fileUrl).LocalPath);
                    return File(fileBytes, "application/octet-stream", downloadName);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(404, "File could not be downloaded.");
            }
        }
        #endregion
    }

    public class ClsPrp_PromoterType
    {
        public int Id { get; set; }
        public long Application_id { get; set; }
        public string Org_Name { get; set; }
        public int Flag { get; set; }
    }

}
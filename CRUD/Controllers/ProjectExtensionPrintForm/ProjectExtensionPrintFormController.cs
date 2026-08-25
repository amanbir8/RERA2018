using CRUD.Models.Document;
using CRUD.Models.HelpDesk;
using CRUD.Models.ProjectExtPrint;
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


namespace CRUD.Controllers.ProjectExtPrint
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class ProjectExtensionPrintFormController : Controller
    {
        //Project Details
        #region Print Project Documents

        [HttpGet]
        public ActionResult Print_ProjectExtensionFormDetails()
        {
            ClsMethod_Print_ProjectExtensionFormDiaryNumberDetails sdb = new ClsMethod_Print_ProjectExtensionFormDiaryNumberDetails();
            ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE aa = new ClsPrp_PrmProjectExt_Print_ProjectExtensionRegistrationFormE();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_ProjectExtensionForm_FormEandDocuments(ProjectID);
            aa.prpProjectExtFormDiaryNumberDetails = sdb.Display_ProjectExtensionForm_RegDiaryNumberByProjectID_ForPrint(ProjectID, userRole);
            foreach (var item in aa.prpongoing)
            {
                aa.FormE_IndexID = item.FormE_IndexID;
                aa.FormE_ID = item.FormE_ID;
                aa.Promoter_ID = item.Promoter_ID;
                aa.Project_ID = item.Project_ID;
                aa.ProjectExtension_NameID = item.ProjectExtension_NameID;
                aa.ProjectExtension_NameYear = item.ProjectExtension_NameYear;
                aa.ProjectExtension_Name = item.ProjectExtension_Name;

                aa.Project_DiaryNumberID = item.Project_DiaryNumberID;
                aa.Project_RERAnumber = item.Project_RERAnumber;
                aa.Project_RERANumberIssueDate = item.Project_RERANumberIssueDate;
                aa.Project_RERANumberValiduptoDate = item.Project_RERANumberValiduptoDate;
                aa.FormE_DocIssueDate = item.FormE_DocIssueDate;
                aa.FormE_ExtensionAppliedReason = item.FormE_ExtensionAppliedReason;
                aa.FormE_ExtensionAppliedReasonSpecifyOthers = item.FormE_ExtensionAppliedReasonSpecifyOthers;
            }
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        #region Print Project Payment Details

        [HttpGet]
        public ActionResult Print_ProjectExtensionPaymentDetails()
        {
            ClsMethod_Print_ProjectExtensionFormDiaryNumberDetails sdb = new ClsMethod_Print_ProjectExtensionFormDiaryNumberDetails();
            ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment aa = new ClsPrp_PrmProjectExt_Print_ProjectExtensionPayment();

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                Int64? Project_ID = Convert.ToInt64(Session["Project_id"]);
                ProjectID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            }

            string userRole = string.Empty;
            userRole = getUserRole();

            aa.prpongoing = sdb.Display_ProjectExtensionForm_Payment(ProjectID);
            aa.prpProjectExtFormDiaryNumberDetails = sdb.Display_ProjectExtensionForm_RegDiaryNumberByProjectID_ForPrint(ProjectID, userRole);
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
    }
}
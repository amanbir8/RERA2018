using CRUD.Models.Document;
using CRUD.Models.HelpDesk;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using CRUD.Models.PromoterPrint;

namespace CRUD.Controllers.PromoterPrint
{
    [Authorize]
    [Authorize(Roles = "Promoter,SecretaryRERA")]    
    public class PromoterPrintFormController : Controller
    {

        //Promoter Profile
        #region Print Promoter Profile
        public ActionResult Print_PromoterIndDetail()
        {
            //Int64 Application_id = 0;
            int? statecode;
            int? DistrictCode;

            string userRole = string.Empty;
            int usertype = 0;
            Int64 aPromoterID = 0;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }
            usertype = Convert.ToInt32(Session["User_Type"]);
            string strRetvalue = string.Empty;
            if (Session["User_Type"] != null)
            {
                if (Session["User_Type"].ToString() != "0")
                {
                    //if (Session["User_Type"].ToString() == "1")
                    //{
                    //    //if Individual Case
                    //    strRetvalue = "Print_PromoterIndDetail";
                    //}
                    //else 
                    if (Session["User_Type"].ToString() == "2")
                    {
                        //if Other than Individual Case
                        //strRetvalue = "Print_PromoterOtherThanIndDetail";                       
                        return RedirectToAction("Print_PromoterOtherThanIndDetail");
                    }
                    //return RedirectToAction(strRetvalue);
                }
            }

            Clsprp_PrmPromoter_Print_PromoterPrintForm objprp = new Clsprp_PrmPromoter_Print_PromoterPrintForm();
            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();

            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();                    

            objprp = objDB.Display_PromoterIndividualsProfile_ByApplicationID(aPromoterID);
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);


            statecode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(DistrictCode);


            foreach (var item in aaZapDN.prpongoing)
            {
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                objprp.zipPromoterLastModifiedOn = item.CreatedOn;
            }

            //return View("Display_PromoterIndPrintForm", objprp);
            return new RazorPDF.PdfActionResult(objprp);
        }


        public ActionResult Print_PromoterOtherThanIndDetail()
        {
            //Int64 Application_id = 0;
            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;

            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }

            Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm objprp = new Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm();
            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();

            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp = objDB.Display_PromoterOtherThenIndProfile_ByApplicationID(aPromoterID);
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);


            statecode = Convert.ToInt32(objprp.Org_State);
            objprp.Org_State = objdis.State_Name(statecode);

            DistrictCode = Convert.ToInt32(objprp.Org_District);
            objprp.Org_District = objdis.District_Name(DistrictCode);

            BusinessPlace_AddressStateCode = Convert.ToInt32(objprp.State);
            objprp.State = objdis.State_Name(BusinessPlace_AddressStateCode);

            BusinessPlace_AddressDistrictCode = Convert.ToInt32(objprp.District);
            objprp.District = objdis.District_Name(BusinessPlace_AddressDistrictCode);


            foreach (var item in aaZapDN.prpongoing)
            {
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                objprp.zipPromoterLastModifiedOn = item.CreatedOn;
            }

            //return View("Display_PromoterOthIndPrintForm", objprp);
            return new RazorPDF.PdfActionResult(objprp);
        }

        #endregion

        #region Print Parent Entity

        public ActionResult Print_PromoterParentEntity()
        {
            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }


            Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm objprp = new Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm();
            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();

            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();


            objprp.Prpparententity = objDB.Display_ParentEntityDetail_ByApplicationID(aPromoterID);
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);

            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            //int? statecode;
            //int? DistrictCode;

            //foreach (var item in objprp.Prpparententity)
            //{
            //    statecode = Convert.ToInt32(item.State);
            //    objprp.State = objdis.State_Name(statecode);
            //    DistrictCode = Convert.ToInt32(item.District);
            //    objprp.Org_District = objdis.District_Name(DistrictCode);
            //}


            foreach (var item in aaZapDN.prpongoing)
            {
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                objprp.zipPromoterLastModifiedOn = item.CreatedOn;
            }

            //return View("Print_PromoterParentEntity", objprp);
            return new RazorPDF.PdfActionResult(objprp);
        }

        #endregion

        #region Print Promoter Organization Members

        public ActionResult Print_PromoterOrganizationMember()
        {
            //int? BusinessPlace_AddressStateCode;
            //int? BusinessPlace_AddressDistrictCode;

            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }

            Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm objprp = new Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm();
            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();

            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();

            


            objprp.prpMem = objDB.Display_PromoterOrganizationMembers_ByApplicationID(aPromoterID);
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);
            
            
            foreach (var item in aaZapDN.prpongoing)
            {
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                objprp.zipPromoterLastModifiedOn = item.CreatedOn;
            }

            //return View("Print_PromoterOrganizationMember", objprp);           
            return new RazorPDF.PdfActionResult(objprp);
        }

        #endregion

        #region Print Promoter Profile NOT USE
        public ActionResult Display_PromoterTrackLitigationsDetails()
        {
            //Int64 Application_id = 0;
            ////int? statecode;
            ////int? DistrictCode;
            ////int? BusinessPlace_AddressStateCode;
            ////int? BusinessPlace_AddressDistrictCode;

            //if (Session["zipProjectDiaryNumber"] != null)
            //{
            //    Int64? Promoter_ID = Convert.ToInt64(Session["zipPromoterID"]);
            //    Application_id = (Promoter_ID != null) ? Convert.ToInt64(Promoter_ID) : 0;
            //}

            //ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //ClsPromoterOrgExpPrintForm objprp = new ClsPromoterOrgExpPrintForm();
            //ClsPromoterOrgExpPrintForm objDB = new ClsPromoterOrgExpPrintForm(); //calling class DBdata


            //if (Session["zipProjectDiaryNumber"] != null)
            //{
            //    string ProjectDiaryNumber = Session["zipProjectDiaryNumber"].ToString();
            //    string ProjectName = Session["zipProjectName"].ToString();
            //    Int64? Project_ID = Convert.ToInt64(Session["zipProjectID"]);
            //    DateTime? LastModifiedOn = Convert.ToDateTime(Session["zipLastModifiedOn"]);
            //    Int64? PromoterID = Convert.ToInt64(Session["zipPromoterID"]);

            //    objprp.zipRelated_Promoter_ID = (PromoterID != null) ? Convert.ToInt64(PromoterID) : 0;
            //    objprp.zipRelated_Project_ID = (Project_ID != null) ? Convert.ToInt64(Project_ID) : 0;
            //    objprp.zipProject_DiaryNumber = (String.IsNullOrEmpty(ProjectDiaryNumber) ? "" : ProjectDiaryNumber);
            //    objprp.zipProjectName = (String.IsNullOrEmpty(ProjectName) ? "" : ProjectName);
            //    objprp.zipProjectLastModifiedOn = LastModifiedOn;
            //}

            //objprp.prpLitigations = objDB.DisplayLitigationn(Application_id);

            //if (objprp.prpLitigations != null)
            //{
            //    foreach (var item in objprp.prpLitigations)
            //    {
            //        //aa.Promoter_ID = item.Promoter_ID;                    
            //    }
            //}
            //objprp.prpongoing = objDB.DisplaybyID_ongoingProject(Application_id);

            //if (objprp.prpongoing != null)
            //{
            //    foreach (var item in objprp.prpongoing)
            //    {
            //        //objDB.Promoter_Experience_ID = item.Promoter_Experience_ID;   
            //    }
            //}
            return View("Display_PromoterTrackLitigationsDetails");//, objprp);
        }
        #endregion

        #region Print Promoter Litigations

        public ActionResult Print_PromoterLitigationsDetails()
        {
            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }

            Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm objprp = new Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm();
            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();

            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();

            objprp.prpLitigations = objDB.Display_PromoterLitigations_ByApplicationID(aPromoterID);
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);
            
            foreach (var item in aaZapDN.prpongoing)
            {
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                objprp.zipPromoterLastModifiedOn = item.CreatedOn;
            }

            //return View("Print_PromoterLitigationsDetails", objprp);
            return new RazorPDF.PdfActionResult(objprp);
        }
        #endregion

        #region Print Promoter Past Experience/Track Record Profile

        public ActionResult Print_PromoterTrackRecordDetails()
        {
            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }

            Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm objprp = new Clsprp_PrmPromoter_Print_PromoterOtherThanIndPrintForm();
            ClsMethod_Print_PromoterProfileDetails objDB = new ClsMethod_Print_PromoterProfileDetails();

            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();


            objprp.prpTrackRecord = objDB.DisplaybyID_PromoterOngoingComplete_ByApplicationID(aPromoterID);
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);

            foreach (var item in aaZapDN.prpongoing)
            {
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                objprp.zipPromoterLastModifiedOn = item.CreatedOn;
            }

            //return View("Print_PromoterTrackRecordDetails", objprp);
            return new RazorPDF.PdfActionResult(objprp);
        }
        #endregion

        #region Print Promoter Documents

        [HttpGet]
        public ActionResult Print_PromoterDocumentDetails()
        {

            ClsMethod_Print_PromoterDocuments sdb = new ClsMethod_Print_PromoterDocuments();
            Clsprp_PrmPromoter_Print_PromoterDocuments aa = new Clsprp_PrmPromoter_Print_PromoterDocuments();


            ClsMethod_Print_PromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_PromoterDiaryNumberDetails();
            ClsPrp_PrmPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmPromoter_Print_DiaryNumberDetails();

            string userRole = string.Empty;
            Int64 aPromoterID = 0;
            userRole = getUserRole();            

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
            }

            aa.prpongoing = sdb.Display_PrmPromoter_Promoter_Documents_PromoterId(aPromoterID);            
            aaZapDN.prpongoing = sdbZapDN.Print_Promoter_RegDiaryNumberByPromoterID_ForPrint(aPromoterID, userRole);

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                aa.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                aa.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                aa.zipPromoterLastModifiedOn = item.CreatedOn;
            }
            
            //return View("Print_PromoterDocuments", aa);
            return new RazorPDF.PdfActionResult(aa);

        }

        #endregion


        //Joint-Promoter Profile
        #region Print Joint-Promoter Profile
        //Print IND-Profile
        public ActionResult Print_JointPromoterIndDetail()
        {
            string userID = string.Empty;
            string userName = string.Empty;
            string userRole = string.Empty;
            string userError = string.Empty;
            string strRetvalue = string.Empty;
            Int64 aPromoterID = 0;
            Int32 aPromoterType = 0;
            Int64 aJointPromoterID = 0;
            Int32 aJointPromoterType = 0;

            int? statecode;
            int? DistrictCode;

            int? comm_statecode;
            int? comm_DistrictCode;

            #region Set All-Parms

            userID = User.Identity.GetUserId();
            userName = User.Identity.Name;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                //PrmID
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    Int64? azPromoterType = Convert.ToInt64(Session["User_Type"]);
                    aPromoterType = (azPromoterType != null) ? Convert.ToInt32(azPromoterType) : 0;
                }
                //JointPrmID
                if (aPromoterID != 0 && aPromoterType != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            Int64? azJointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                            aJointPromoterID = (azJointPromoterID != null) ? Convert.ToInt64(azJointPromoterID) : 0;
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            Int64? azJointPromoterType = Convert.ToInt64(Session["jointpromoter_Type"]);
                            aJointPromoterType = (azJointPromoterType != null) ? Convert.ToInt32(azJointPromoterType) : 0;
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    // NA Case :- Error (Mapping error between jointpromoter_ID)
                    userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                //NA Case :- Error (Session Expires/Empty)
                userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
            }
            #endregion
            #region Set Joint-Promoter Case (IND or OTI)
            if (Session["User_Type"] != null)
            {
                if (Session["User_Type"].ToString() != "0")
                {
                    if (Session["User_Type"].ToString() == "2")
                    {
                        //if Other than Individual Case                     
                        return RedirectToAction("Print_JointPromoterOtherThanIndDetail");
                    }
                }
            }
            #endregion

            ClsMethod_Print_JointPromoterDetails objDB = new ClsMethod_Print_JointPromoterDetails();
            Clsprp_JointPromoter_Print_ProfileForm objprp = new Clsprp_JointPromoter_Print_ProfileForm();

            ClsMethod_Print_JointPromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_JointPromoterDiaryNumberDetails();
            ClsPrp_JointPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_JointPromoter_Print_DiaryNumberDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.prpongoingTR = objDB.Display_JointPromoter_ProfileDetail_ByID_ForPrint(aPromoterID, aPromoterType, aJointPromoterID, aJointPromoterType, userName, userRole);
            aaZapDN.prpongoing = sdbZapDN.Print_JointPromoter_RegDiaryNumberByID_ForPrint(aPromoterID, aJointPromoterID, aJointPromoterType, userName, userRole);

            statecode = Convert.ToInt32(objprp.Permanent_Address_Prm_State);
            DistrictCode = Convert.ToInt32(objprp.Permanent_Address_Prm_District);
            objprp.Permanent_Address_Prm_DistrictState_Name = Convert.ToString(objdis.District_Name(DistrictCode) + ", " + objdis.State_Name(statecode));

            comm_statecode = Convert.ToInt32(objprp.Communication_AddressStateCode);
            comm_DistrictCode = Convert.ToInt32(objprp.Communication_AddressDistrictCode);
            objprp.Communication_Address_DistrictState_Name = Convert.ToString(objdis.District_Name(comm_DistrictCode) + ", " + objdis.State_Name(comm_statecode));

            foreach (var item in aaZapDN.prpongoing)
            {
                // ID
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipRelated_JointPromoter_ID = item.zipRelated_JointPromoter_ID;
                // Application Date
                objprp.Promoter_ApplicationDate = item.Promoter_ApplicationDate;
                objprp.JointPromoter_ApplicationDate = item.JointPromoter_ApplicationDate;
                // Promoter Name/Diary Number
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                // Joint-Promoter Name/Diary Number
                objprp.zipJointPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipJointPromoter_DiaryNumber) ? "" : item.zipJointPromoter_DiaryNumber);
                objprp.zipJointPromoterName = (String.IsNullOrEmpty(item.zipJointPromoterName) ? "" : item.zipJointPromoterName);

                objprp.zipJointPromoterLastModifiedOn = item.zipJointPromoterLastModifiedOn;
            }

            return new RazorPDF.PdfActionResult(objprp);
        }
        //Print OTI-Profile
        public ActionResult Print_JointPromoterOtherThanIndDetail()
        {
            string userID = string.Empty;
            string userName = string.Empty;
            string userRole = string.Empty;
            string userError = string.Empty;
            string strRetvalue = string.Empty;
            Int64 aPromoterID = 0;
            Int32 aPromoterType = 0;
            Int64 aJointPromoterID = 0;
            Int32 aJointPromoterType = 0;

            int? statecode;
            int? DistrictCode;
            int? comm_statecode;
            int? comm_DistrictCode;

            #region Set All-Parms

            userID = User.Identity.GetUserId();
            userName = User.Identity.Name;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                //PrmID
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    Int64? azPromoterType = Convert.ToInt64(Session["User_Type"]);
                    aPromoterType = (azPromoterType != null) ? Convert.ToInt32(azPromoterType) : 0;
                }
                //JointPrmID
                if (aPromoterID != 0 && aPromoterType != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            Int64? azJointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                            aJointPromoterID = (azJointPromoterID != null) ? Convert.ToInt64(azJointPromoterID) : 0;
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            Int64? azJointPromoterType = Convert.ToInt64(Session["jointpromoter_Type"]);
                            aJointPromoterType = (azJointPromoterType != null) ? Convert.ToInt32(azJointPromoterType) : 0;
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    // NA Case :- Error (Mapping error between jointpromoter_ID)
                    userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                //NA Case :- Error (Session Expires/Empty)
                userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
            }
            #endregion

            ClsMethod_Print_JointPromoterDetails objDB = new ClsMethod_Print_JointPromoterDetails();
            Clsprp_JointPromoter_Print_ProfileForm objprp = new Clsprp_JointPromoter_Print_ProfileForm();

            ClsMethod_Print_JointPromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_JointPromoterDiaryNumberDetails();
            ClsPrp_JointPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_JointPromoter_Print_DiaryNumberDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            objprp.prpongoingTR = objDB.Display_JointPromoter_ProfileDetail_ByID_ForPrint(aPromoterID, aPromoterType, aJointPromoterID, aJointPromoterType, userName, userRole);
            aaZapDN.prpongoing = sdbZapDN.Print_JointPromoter_RegDiaryNumberByID_ForPrint(aPromoterID, aJointPromoterID, aJointPromoterType, userName, userRole);

            statecode = Convert.ToInt32(objprp.Registered_Address_Org_State);
            DistrictCode = Convert.ToInt32(objprp.Registered_Address_Org_District);
            objprp.Registered_Address_Org_DistrictState_Name = Convert.ToString(objdis.District_Name(DistrictCode) + ", " + objdis.State_Name(statecode));

            comm_statecode = Convert.ToInt32(objprp.Communication_AddressStateCode);
            comm_DistrictCode = Convert.ToInt32(objprp.Communication_AddressDistrictCode);
            objprp.Communication_Address_DistrictState_Name = Convert.ToString(objdis.District_Name(comm_DistrictCode) + ", " + objdis.State_Name(comm_statecode));

            foreach (var item in aaZapDN.prpongoing)
            {
                // ID
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipRelated_JointPromoter_ID = item.zipRelated_JointPromoter_ID;
                // Application Date
                objprp.Promoter_ApplicationDate = item.Promoter_ApplicationDate;
                objprp.JointPromoter_ApplicationDate = item.JointPromoter_ApplicationDate;
                // Promoter Name/Diary Number
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                // Joint-Promoter Name/Diary Number
                objprp.zipJointPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipJointPromoter_DiaryNumber) ? "" : item.zipJointPromoter_DiaryNumber);
                objprp.zipJointPromoterName = (String.IsNullOrEmpty(item.zipJointPromoterName) ? "" : item.zipJointPromoterName);

                objprp.zipJointPromoterLastModifiedOn = item.zipJointPromoterLastModifiedOn;
            }

            return new RazorPDF.PdfActionResult(objprp);
        }
        #endregion

        #region Print Joint-Promoter Litigations
        //Print Litigations and Track-Records
        public ActionResult Print_JointPromoterLitigationsDetails()
        {
            string userID = string.Empty;
            string userName = string.Empty;
            string userRole = string.Empty;
            string userError = string.Empty;
            Int64 aPromoterID = 0;
            Int32 aPromoterType = 0;
            Int64 aJointPromoterID = 0;
            Int32 aJointPromoterType = 0;

            #region Set All-Parms

            userID = User.Identity.GetUserId();
            userName = User.Identity.Name;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                //PrmID
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? azPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    aPromoterID = (azPromoterID != null) ? Convert.ToInt64(azPromoterID) : 0;
                }
                if (Session["User_Type"].ToString() != "0")
                {
                    Int64? azPromoterType = Convert.ToInt64(Session["User_Type"]);
                    aPromoterType = (azPromoterType != null) ? Convert.ToInt32(azPromoterType) : 0;
                }
                //JointPrmID
                if (aPromoterID != 0 && aPromoterType != 0)
                {
                    if (Session["jointpromoter_Id"] != null && Session["jointpromoter_Type"] != null)
                    {
                        if (Session["jointpromoter_Id"].ToString() != "0")
                        {
                            Int64? azJointPromoterID = Convert.ToInt64(Session["jointpromoter_Id"]);
                            aJointPromoterID = (azJointPromoterID != null) ? Convert.ToInt64(azJointPromoterID) : 0;
                        }
                        if (Session["jointpromoter_Type"].ToString() != "0")
                        {
                            Int64? azJointPromoterType = Convert.ToInt64(Session["jointpromoter_Type"]);
                            aJointPromoterType = (azJointPromoterType != null) ? Convert.ToInt32(azJointPromoterType) : 0;
                        }
                    }
                    else
                    {
                        //NA Case :- Error (Session Expires/Empty)
                        userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                    }
                }
                else
                {
                    // NA Case :- Error (Mapping error between jointpromoter_ID)
                    userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
                }
            }
            else
            {
                //NA Case :- Error (Session Expires/Empty)
                userError = "Error! Something Went Wrong. Please sign-in with registered real-estate project.";
            }
            #endregion

            ClsMethod_Print_JointPromoterDetails objDB = new ClsMethod_Print_JointPromoterDetails();
            ClsPrp_JointPromoter_Print_TrackLitigations objprp = new ClsPrp_JointPromoter_Print_TrackLitigations();

            ClsMethod_Print_JointPromoterDiaryNumberDetails sdbZapDN = new ClsMethod_Print_JointPromoterDiaryNumberDetails();
            ClsPrp_JointPromoter_Print_DiaryNumberDetails aaZapDN = new ClsPrp_JointPromoter_Print_DiaryNumberDetails();

            objprp.prpongoingTL = objDB.Display_JointPromoter_TrackRecordLitigations_ByID_ForPrint(aPromoterID, aPromoterType, aJointPromoterID, aJointPromoterType, userName, userRole);
            aaZapDN.prpongoing = sdbZapDN.Print_JointPromoter_RegDiaryNumberByID_ForPrint(aPromoterID, aJointPromoterID, aJointPromoterType, userName, userRole);

            foreach (var item in aaZapDN.prpongoing)
            {
                // ID
                objprp.zipRelated_Promoter_ID = item.zipRelated_Promoter_ID;
                objprp.zipRelated_JointPromoter_ID = item.zipRelated_JointPromoter_ID;
                // Application Date
                objprp.Promoter_ApplicationDate = item.Promoter_ApplicationDate;
                objprp.JointPromoter_ApplicationDate = item.JointPromoter_ApplicationDate;
                // Promoter Name/Diary Number
                objprp.zipPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipPromoter_DiaryNumber) ? "" : item.zipPromoter_DiaryNumber);
                objprp.zipPromoterName = (String.IsNullOrEmpty(item.zipPromoterName) ? "" : item.zipPromoterName);
                // Joint-Promoter Name/Diary Number
                objprp.zipJointPromoter_DiaryNumber = (String.IsNullOrEmpty(item.zipJointPromoter_DiaryNumber) ? "" : item.zipJointPromoter_DiaryNumber);
                objprp.zipJointPromoterName = (String.IsNullOrEmpty(item.zipJointPromoterName) ? "" : item.zipJointPromoterName);

                objprp.zipJointPromoterLastModifiedOn = item.zipJointPromoterLastModifiedOn;
            }

            return new RazorPDF.PdfActionResult(objprp);
        }
        #endregion

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
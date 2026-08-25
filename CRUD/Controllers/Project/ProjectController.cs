using CRUD.Models;
using CRUD.Models.Promoter;
using CRUD.Models.PromoterProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CRUD.Models.Master;
using CRUD.Models.ProjectFeeCalculator;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CRUD.Controllers.Project
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class ProjectController : Controller
    {
        string Photo_Address = string.Empty;
        //Table 08 approval documents

        /// Table 02 - Table 03, 
        /// Controller Project Registration
        #region 
        // Get:
        [HttpGet]
        public ActionResult Insert_project_Detail()
        {
            Int64 inPromoterID = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    inPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("OptionView", "Promoter");
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsMethod_Project_Registration sdb = new ClsMethod_Project_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_Project_Registration aa = new ClsPrp_Project_Registration();

            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;
            ViewBag.statePunjab = aa.stateMaster.Where(item =>item.StateName=="Punjab" ) ;

            aa.districtMaster = objdis.dropdownlist_display1();
            aa.prpongoing = sdb.Display_Project_RegistrationAll(inPromoterID);

            //if (aa.prpongoing.Count >= 1)
            //{
            //    foreach (var item in aa.prpongoing)
            //    {
            //        Tuple<string, string, string> extractCode = fnExtractSubStringRegularizationColonyProject(item.B_column);
            //        aa.IsYes_RegularizationCertificate = extractCode.Item1;
            //        aa.IsYes_columnExtra = extractCode.Item2;
            //        aa.RegularizationCertificateInformation = extractCode.Item3;
            //    }
            //}

            TempData["submitvalue"] = "Submit";TempData.Keep();
            return View("Insert_project_Detail", aa);
        }

        // POST: 
        [HttpPost]
        public ActionResult Insert_project_Detail(ClsPrp_Project_Registration smodel)
        {
            ClsMethod_Project_Registration sdb = new ClsMethod_Project_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_Project_Registration aa = new ClsPrp_Project_Registration();

            try
            {
                aa.districtMaster = objdis.dropdownlist_display1();
                aa.stateMaster = objdis.State_list();
                ViewBag.state = aa.stateMaster;
                ViewBag.statePunjab = aa.stateMaster.Where(item => item.StateName == "Punjab");

                Int64 inPromoterID = 0;
                if (Session["ApplicationId"] != null)
                {
                    inPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
                
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;

                #region Type of Project Validator
                Int32 varChkBuildingType = 0;
                if (smodel.CommercialBuildingTower)
                    varChkBuildingType = 1;
                if (smodel.CommercialPlottedDevelopment)
                    varChkBuildingType = 1;
                if (smodel.ResidentialBuildingTower)
                    varChkBuildingType = 1;
                if (smodel.ResidentialPlottedDevelopment)
                    varChkBuildingType = 1;
                if (smodel.IndustrialBuildingTower)
                    varChkBuildingType = 1;
                if (smodel.IndustrialPlottedDevelopment)
                    varChkBuildingType = 1;

                if (varChkBuildingType != 1)
                {
                    ModelState.AddModelError("CommercialBuildingTower", "The Type of Project (Commercial /Residential/ Industrial) field is required.");
                }
                #endregion

                if (ModelState.IsValid)
                {
                    string retSubStringValue = fnSaveSubStringRegularizationColonyProject(smodel);
                    smodel.B_column = retSubStringValue;
                    Int64 Appid = sdb.Add_Project_Registration(smodel, inPromoterID, UID, UserNam);

                    if (Appid > 0)
                    {
                        ClsPrp_ProjectType_Registration sdb1 = new ClsPrp_ProjectType_Registration();
                        ClsMethod_ProjectType_Registration objdis1 = new ClsMethod_ProjectType_Registration();

                        bool CommercialPlottedDevelopment = smodel.CommercialPlottedDevelopment;
                        if (CommercialPlottedDevelopment)
                        {
                            objdis1.Add_Project_Type_Registration(Appid, "01", "Commercial", "01", "Plotted Development");
                        }

                        bool CommercialBuildingTower = smodel.CommercialBuildingTower;
                        if (CommercialBuildingTower)
                        {
                            objdis1.Add_Project_Type_Registration(Appid, "01", "Commercial", "02", "Building/Tower Development");
                        }

                        bool IndustrialBuildingTower = smodel.IndustrialBuildingTower;
                        if (IndustrialBuildingTower)
                        {
                            objdis1.Add_Project_Type_Registration(Appid, "02", "Industrial", "02", "Building/Tower Development");
                        }

                        bool IndustrialPlottedDevelopment = smodel.IndustrialPlottedDevelopment;
                        if (IndustrialPlottedDevelopment)
                        {
                            objdis1.Add_Project_Type_Registration(Appid, "02", "Industrial", "01", "Plotted Development");
                        }

                        bool ResidentialBuildingTower = smodel.ResidentialBuildingTower;
                        if (ResidentialBuildingTower)
                        {
                            objdis1.Add_Project_Type_Registration(Appid, "03", "Residential", "02", "Building/Tower Development");
                        }

                        bool ResidentialPlottedDevelopment = smodel.ResidentialPlottedDevelopment;
                        if (ResidentialPlottedDevelopment)
                        {
                            objdis1.Add_Project_Type_Registration(Appid, "03", "Residential", "01", "Plotted Development");
                        }

                        //TempData["resultmessageshown"] = "Record Inserted Successfully!";
                        //@ViewData["resultMessageShown"] = "1";
                        ModelState.Clear();                        
                    }
                }
                else
                {
                    return View("Insert_project_Detail", aa);
                }
                return RedirectToAction("Insert_project_Detail");
            }
            catch (Exception ex)
            {
                ex.ToString();
                //@ViewData["resultMessageShown"] = "0";
                //TempData["resultmessageshown"] = "Bad Request, Try Again!";                
                return View();
            }
        }

        // Get:
        [HttpGet]
        public ActionResult Edit_project_Detail(Int64 ProjectRegistration_ID, int Id)
        {
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            ClsMethod_Project_Registration sdb = new ClsMethod_Project_Registration();
            ClsPrp_Project_Registration aa = new ClsPrp_Project_Registration();
            ClsMethod_ProjectType_Registration prt = new ClsMethod_ProjectType_Registration();
            //aa.prpongoing = prt.Display_Project_Registration();
            aa.prpongoing = sdb.Display_Project_Registration(ProjectRegistration_ID, Id);

            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;

            ViewBag.statePunjab = aa.stateMaster.Where(item => item.StateName == "Punjab");

            ClsPrp_ProjectType_Registration sdb1 = new ClsPrp_ProjectType_Registration();
            ClsMethod_ProjectType_Registration objdis1 = new ClsMethod_ProjectType_Registration();

            ClsMethodDistrictMaster objdisDM = new ClsMethodDistrictMaster();
            aa.districtMaster = objdisDM.dropdownlist_display1();
            aa.SubdivMaster = objdisDM.dropdownlist_diplaySubdiv();

            for (int i = 0; i < aa.prpongoing.Count(); i++)
            {
                string ProjectType_SubType_Code_string = aa.prpongoing[i].ProjectType_SubType_Code.ToString();
                string ProjectType_Code_string = aa.prpongoing[i].ProjectType_Code.ToString();


                if (ProjectType_Code_string == "01" && ProjectType_SubType_Code_string == "01")
                {
                    aa.CommercialPlottedDevelopment = true;
                }
                if (ProjectType_Code_string == "01" && ProjectType_SubType_Code_string == "02")
                {
                    aa.CommercialBuildingTower = true;
                }
                if (ProjectType_Code_string == "02" && ProjectType_SubType_Code_string == "01")
                {
                    aa.IndustrialPlottedDevelopment = true;
                }
                if (ProjectType_Code_string == "02" && ProjectType_SubType_Code_string == "02")
                {
                    aa.IndustrialBuildingTower = true;
                }
                if (ProjectType_Code_string == "03" && ProjectType_SubType_Code_string == "01")
                {
                    aa.ResidentialPlottedDevelopment = true;
                }
                if (ProjectType_Code_string == "03" && ProjectType_SubType_Code_string == "02")
                {
                    aa.ResidentialBuildingTower = true;
                }
            }
            foreach (var item in aa.prpongoing)
            {
                aa.ProjectRegistration_IndexID = item.ProjectRegistration_IndexID;
                aa.ProjectRegistration_ID = item.ProjectRegistration_ID;
                aa.Project_Name = item.Project_Name;
                aa.Project_Amenities = item.Project_Amenities;
                aa.IsAlready_RERANumber = item.IsAlready_RERANumber;
                aa.Existing_RERANumber = item.Existing_RERANumber;
                aa.ProposedProjectDetail_Structure = item.ProposedProjectDetail_Structure;
                aa.ProposedProjectDetail_Flooring = item.ProposedProjectDetail_Flooring;
                aa.ProposedProjectDetail_WallFinishing = item.ProposedProjectDetail_WallFinishing;
                aa.ProposedProjectDetail_SanitaryFittings = item.ProposedProjectDetail_SanitaryFittings;
                aa.ProposedProjectDetail_ElectricalFittings = item.ProposedProjectDetail_ElectricalFittings;
                aa.ProposedProjectDetail_Kitchen = item.ProposedProjectDetail_Kitchen;
                aa.IsProposedProjectDetail_OthersIfAny = item.IsProposedProjectDetail_OthersIfAny;
                aa.ProposedProjectDetail_OthersIfAnyName = item.ProposedProjectDetail_OthersIfAnyName;
                aa.ProposedProjectDetail_OthersIfAny = item.ProposedProjectDetail_OthersIfAny;
                aa.Project_Status = item.Project_Status;
                aa.ProjectStart_Date = item.ProjectStart_Date;
                aa.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                aa.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                aa.ProjectRegistrationProvided_Duration = item.ProjectRegistrationProvided_Duration;
                aa.ProjectDelayReason_IfAny = item.ProjectDelayReason_IfAny;
                aa.Project_AddressLine1 = item.Project_AddressLine1;
                aa.Project_AddressLine2 = item.Project_AddressLine2;
                aa.Project_AddressStateCode = item.Project_AddressStateCode;
                aa.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                aa.Project_AddressSubDivisionCode = item.Project_AddressSubDivisionCode;
                aa.Project_AddressPIN = item.Project_AddressPIN;
                aa.Project_PotentialZoneCode = item.Project_PotentialZoneCode;
                aa.ProjectWebsite_WebLink = item.ProjectWebsite_WebLink;
                aa.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                aa.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                aa.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;
                aa.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                aa.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                aa.AuthorizedPerson_AddressStateCode = item.AuthorizedPerson_AddressStateCode;
                aa.AuthorizedPerson_AddressDistrictCode = item.AuthorizedPerson_AddressDistrictCode;
                aa.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;
                aa.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                aa.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;
                aa.IsProForma_AOS_RERAformat_AnnexureA = item.IsProForma_AOS_RERAformat_AnnexureA;
                aa.IsProForma_AOS_RERAformat_No_IsApproved = item.IsProForma_AOS_RERAformat_No_IsApproved;
                aa.IsProject_MegaProjectCategory = item.IsProject_MegaProjectCategory;
                aa.IsLitigation_RelatedProject = item.IsLitigation_RelatedProject;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

                Tuple<string, string, string> extractCode = fnExtractSubStringRegularizationColonyProject(item.B_column);
                aa.IsYes_RegularizationCertificate = extractCode.Item1;
                aa.IsYes_columnExtra = extractCode.Item2;
                aa.RegularizationCertificateInformation = extractCode.Item3;
            }

            ViewBag.HideGrid = "gridHide";
            TempData["Submitvalue"] = "Update";
            TempData.Keep();
            return View("Insert_project_Detail", aa);
        }

        // POST: 
        [HttpPost]
        public ActionResult Edit_project_Detail(ClsPrp_Project_Registration smodel)
        {
            ClsMethod_Project_Registration sdb = new ClsMethod_Project_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_Project_Registration aa = new ClsPrp_Project_Registration();

            try
            {
                aa.districtMaster = objdis.dropdownlist_display1();
                aa.stateMaster = objdis.State_list();
                ViewBag.state = aa.stateMaster;
                ViewBag.statePunjab = aa.stateMaster.Where(item => item.StateName == "Punjab");

                Int64 inPromoterID = 0;
                if (Session["ApplicationId"] != null)
                {
                    inPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                }
                else
                {
                    return RedirectToAction("SessionExpire", "Account");
                }
                
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;

                #region Type of Project Validator
                Int32 varChkBuildingType = 0;
                if (smodel.CommercialBuildingTower)
                    varChkBuildingType = 1;
                if (smodel.CommercialPlottedDevelopment)
                    varChkBuildingType = 1;
                if (smodel.ResidentialBuildingTower)
                    varChkBuildingType = 1;
                if (smodel.ResidentialPlottedDevelopment)
                    varChkBuildingType = 1;
                if (smodel.IndustrialBuildingTower)
                    varChkBuildingType = 1;
                if (smodel.IndustrialPlottedDevelopment)
                    varChkBuildingType = 1;

                if (varChkBuildingType != 1)
                {
                    ModelState.AddModelError("CommercialBuildingTower", "The Type of Project (Commercial /Residential/ Industrial) field is required.");
                }
                #endregion



                if (ModelState.IsValid)
                {
                    string retSubStringValue = fnSaveSubStringRegularizationColonyProject(smodel);
                    smodel.B_column = retSubStringValue;
                    Int64 Appid = sdb.Update_Project_Registration(smodel, inPromoterID, UID, UserNam);
                    if (Appid > 0)
                    {
                        ClsPrp_ProjectType_Registration sdb1 = new ClsPrp_ProjectType_Registration();
                        ClsMethod_ProjectType_Registration objdis1 = new ClsMethod_ProjectType_Registration();

                        bool CommercialPlottedDevelopment = smodel.CommercialPlottedDevelopment;
                        if (CommercialPlottedDevelopment)
                        {
                            objdis1.Update_Project_Type_Registration(Appid, "01", "Commercial", "01", "Plotted Development");
                        }
                        bool CommercialBuildingTower = smodel.CommercialBuildingTower;
                        if (CommercialBuildingTower)
                        {
                            objdis1.Update_Project_Type_Registration(Appid, "01", "Commercial", "02", "Building/Tower Development");
                        }
                        bool IndustrialBuildingTower = smodel.IndustrialBuildingTower;
                        if (IndustrialBuildingTower)
                        {
                            objdis1.Update_Project_Type_Registration(Appid, "02", "Industrial", "02", "Building/Tower Development");
                        }
                        bool IndustrialPlottedDevelopment = smodel.IndustrialPlottedDevelopment;
                        if (IndustrialPlottedDevelopment)
                        {
                            objdis1.Update_Project_Type_Registration(Appid, "02", "Industrial", "01", "Plotted Development");
                        }
                        bool ResidentialBuildingTower = smodel.ResidentialBuildingTower;
                        if (ResidentialBuildingTower)
                        {
                            objdis1.Update_Project_Type_Registration(Appid, "03", "Residential", "02", "Building/Tower Development");
                        }
                        bool ResidentialPlottedDevelopment = smodel.ResidentialPlottedDevelopment;
                        if (ResidentialPlottedDevelopment)
                        {
                            objdis1.Update_Project_Type_Registration(Appid, "03", "Residential", "01", "Plotted Development");
                        }

                        //ViewBag.resultmessageshown = "Record Updated Successfully!";
                        //TempData["resultmessageshown"] = "Record Updated Successfully!"; //new MessageVM() { CssClassName = "alert-sucess", Title = "Success!", Message = "Operation Done." };
                        //@ViewData["resultMessageShown"] = "1";
                        ModelState.Clear();
                    }                    
                }
                else
                {
                    return View("Insert_project_Detail", aa);
                }
                return RedirectToAction("Insert_project_Detail");
            }
            catch (Exception ex)
            {
                ex.ToString();
                //TempData["resultmessageshown"] = "Bad Request, Try Again!";
                return View();
            }
        }
        
        private Tuple<string, string, string> fnExtractSubStringRegularizationColonyProject(string varFormStr)
        {
            string retflagREGC = string.Empty;
            string retflagExtra = string.Empty;
            string retflagREGCertInfo = string.Empty;

            try
            {
                if (varFormStr == "NIL")
                {
                    retflagREGC = "NREGC";
                    retflagExtra = "NEXTRA";
                    retflagREGCertInfo = string.Empty;                    
                }
                else
                {
                    string input = varFormStr;
                    //string input = "//YREGC////NEXTRA////remarks if any//";                   
                    string[] getstrings = Regex.Matches(input, @"\//(.+?)\//")
                                                .Cast<Match>()
                                                .Select(s => s.Groups[1].Value).ToArray();

                    if (getstrings.Length > 0)
                    {
                        if (getstrings.Length <= 2)
                        {
                            retflagREGC = getstrings[0];
                            retflagExtra = getstrings[1];
                            retflagREGCertInfo = string.Empty;
                        }
                        else
                        {
                            retflagREGC = getstrings[0];
                            retflagExtra = getstrings[1];
                            retflagREGCertInfo = getstrings[2];                            
                        }
                    }
                    else
                    {
                        retflagREGC = "NREGC";
                        retflagExtra = "NEXTRA";
                        retflagREGCertInfo = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                retflagREGC = "NREGC";
                retflagExtra = "NEXTRA";
                retflagREGCertInfo = string.Empty;
            }
            return new Tuple<string, string, string>(retflagREGC, retflagExtra, retflagREGCertInfo);
        }

        private string fnSaveSubStringRegularizationColonyProject(ClsPrp_Project_Registration smodel)
        {
            string retflagREGC = string.Empty;
            string retflagExtra = string.Empty;
            string retflagREGCertInfo = string.Empty;
            string input = string.Empty;

            if (smodel != null)
            {
                retflagREGC = String.IsNullOrEmpty(smodel.IsYes_RegularizationCertificate) ? "NREGC" : smodel.IsYes_RegularizationCertificate;
                retflagExtra = String.IsNullOrEmpty(smodel.IsYes_columnExtra) ? "NEXTRA" : smodel.IsYes_columnExtra;
                retflagREGCertInfo = String.IsNullOrEmpty(smodel.RegularizationCertificateInformation) ? string.Empty : smodel.RegularizationCertificateInformation;
            }
            else
            {
                retflagREGC = "NREGC";
                retflagExtra = "NEXTRA";
                retflagREGCertInfo = string.Empty;
            }

            input = "//" + retflagREGC + "////" + retflagExtra + "////" + retflagREGCertInfo + "//";
            return input;
        }
        #endregion

        /// Table 04  Detail of Project Litigations(If Any)
        #region
        /// <summary>
        ///  Detail of Project Litigations(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistLitigations(FormCollection frm, ClsPrp_Project_Litigations smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.LitigationsRelated_ProjectRegistration_ID;
 
            TempData["SelectedItem"] = frm["LitigationsRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_Litigations()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            }
            //////else
            //////{
            //////    return RedirectToAction("SessionExpire", "Account");
            //////}
            //TempData["list"] = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //TempData.Keep();

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_litigations(PromoterApplicationId, Project_id);
            TempData.Keep();


            ClsMethod_Project_Litigations sdb = new ClsMethod_Project_Litigations();
            ClsPrp_Project_Litigations aa = new ClsPrp_Project_Litigations();
            aa.prpongoing = sdb.Display_Project_Litigations(Project_id);
            aa.LitigationsRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_Litigations clsfive = new ClsMethod_Project_Litigations();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "Litigations"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            //////// Fill project list from project Registration Table
            ///TEST 20180215
            //////Int64 PromoterApplicationId = 0;
            //////if (Session["ApplicationId"] != null)
            //////{
            //////    if (Session["ApplicationId"].ToString() != "0")
            //////    {
            //////        PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
            //////    }
            //////}

            //////aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            //////ViewBag.list = aa.ProjectMaster;
            ///TEST 20180215
            //TempData["submitvalue"] = "Submit";

            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            TempData["submitvalue"] = "Submit";TempData.Keep();
            return View("Create_Litigations", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_Litigations(ClsPrp_Project_Litigations smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.LitigationsRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_Litigations sdb = new ClsMethod_Project_Litigations();
                    if (sdb.Add_Project_Type_Litigations(smodel))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_Litigations");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }


        // GET: Single Display Display_Project_Litigations(Int64 ProjectRegistration_ID)
        //LitigationsRelated_ProjectRegistration_ID=@ProjectRegistration_ID,ProjectLitigations_IndexID = @ProjectLitigations_IndexID
        //Display_Project_LitigationsID(Int64 ProjectLitigations_IndexID, Int64 ProjectRegistration_ID)
        [HttpGet]
        public ActionResult Edit_Litigations(Int64 ProjectLitigations_IndexID, Int64 ProjectRegistration_ID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_Litigations sdb = new ClsMethod_Project_Litigations();
            ClsPrp_Project_Litigations aa = new ClsPrp_Project_Litigations();
            aa.prpongoing = sdb.Display_Project_LitigationsID(ProjectLitigations_IndexID, ProjectRegistration_ID);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectLitigations_IndexID = item.ProjectLitigations_IndexID;
                aa.ProjectLitigations_ID = item.ProjectLitigations_ID;
                aa.LitigationsRelated_ProjectRegistration_ID = item.LitigationsRelated_ProjectRegistration_ID;
                aa.Case_Title = item.Case_Title;
                aa.Case_Number = item.Case_Number;
                aa.AuthorityForumName_CasePendingResolved = item.AuthorityForumName_CasePendingResolved;
                //aa.Constructed_FloorsNumber = item.Constructed_FloorsNumber;
                //aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_Litigations", aa);

        }

        // POST: Update
        [HttpPost]
        public ActionResult Edit_Litigations(ClsPrp_Project_Litigations smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_Litigations sdb = new ClsMethod_Project_Litigations();
                    sdb.Update_Project_Type_Litigations(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("Create_Litigations");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        //GET: Delete
        public ActionResult Delete_Litigations(Int64 ProjectLitigations_IndexID, Int64 ProjectRegistration_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_Litigations sdb = new ClsMethod_Project_Litigations();
                if (sdb.Delete_Project_Litigations(ProjectLitigations_IndexID, ProjectRegistration_ID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_Litigations");
            }
            catch
            {
                return View();
            }
        }

        #endregion Litigations

        /// Table 05 Detail of Project LandDetails(If Any)
        #region
        /// <summary>
        ///  Detail of Project LandDetails(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistLand(FormCollection frm, ClsPrp_Project_LandDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectLandRelated_ProjectRegistration_ID;
            //ViewBag.SelectedItem = frm["ProjectLandRelated_ProjectRegistration_ID"];
            TempData["SelectedItem"] = frm["ProjectLandRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_LandDetails()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;

            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";


            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "LandDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());


            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();


            ClsMethod_Project_LandDetails sdb = new ClsMethod_Project_LandDetails();
            ClsPrp_Project_LandDetails aa = new ClsPrp_Project_LandDetails();
            aa.prpongoing = sdb.Display_Project_Landdetails(Project_id);
            aa.ProjectLandRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_LandDetails clsfive = new ClsMethod_Project_LandDetails();

            //////// Fill project list from project Registration Table
            if (aa.prpongoing.Count >= 1)
            {
                TempData["submitvalue"] = "Update"; TempData.Keep();                
            }
            else
            {
                TempData["submitvalue"] = "Submit"; TempData.Keep();                
            }
            foreach (var item in aa.prpongoing)
            {
                aa.ProjectLand_ID = item.ProjectLand_ID;
                aa.ProjectLand_IndexID = item.ProjectLand_IndexID;
                aa.ProjectLandRelated_ProjectRegistration_ID = item.ProjectLandRelated_ProjectRegistration_ID;

                if (item.IsDraft>=1)
                {
                    aa.ProposedLand_TobeDeveloped_Area_Total = item.ProposedLand_TobeDeveloped_Area_Total;
                    aa.ProposedLand_Area_ResidentialGroupHousing = item.ProposedLand_Area_ResidentialGroupHousing;
                    aa.ProposedLand_Area_ResidentialPlotted = item.ProposedLand_Area_ResidentialPlotted;
                    aa.ProposedLand_Area_Commercial = item.ProposedLand_Area_Commercial;
                    aa.ProposedLand_Area_Industrial = item.ProposedLand_Area_Industrial;
                    aa.ProposedLand_Area_A_column = item.ProposedLand_Area_A_column;
                    aa.ProposedLand_Area_B_column = item.ProposedLand_Area_B_column;
                    aa.ProposedLand_Area_C_column = item.ProposedLand_Area_C_column;
                    aa.ProposedLand_Area_D_column = item.ProposedLand_Area_D_column;
                    aa.Name_of_Villages = item.Name_of_Villages;
                    aa.ProposedLand_TobeDeveloped_TotalOpenArea = item.ProposedLand_TobeDeveloped_TotalOpenArea;
                    aa.ProposedLand_TobeDeveloped_TotalCoveredArea = item.ProposedLand_TobeDeveloped_TotalCoveredArea;
                    aa.ProposedProjectLand_StartPoint_Longitude = item.ProposedProjectLand_StartPoint_Longitude;
                    aa.ProposedProjectLand_StartPoint_Latitude = item.ProposedProjectLand_StartPoint_Latitude;
                    aa.ProposedProjectLand_EndPoint_Longitude = item.ProposedProjectLand_EndPoint_Longitude;
                    aa.ProposedProjectLand_EndPoint_Latitude = item.ProposedProjectLand_EndPoint_Latitude;
                    aa.IsProjectLand_Status_OwnedByPromoter = item.IsProjectLand_Status_OwnedByPromoter;
                    aa.IsProjectLand_Status_NotOwnedByPromoter = item.IsProjectLand_Status_NotOwnedByPromoter;
                    aa.IsLandEncumbrances_IfAny = item.IsLandEncumbrances_IfAny;
                    //aa.Remarks_IfAny = item.Remarks_IfAny;
                    //aa.A_column = item.A_column;
                    //aa.B_column = item.B_column;
                    //aa.C_column = item.C_column;
                }
                ////aa.ProposedLand_TobeDeveloped_Area_Total = item.ProposedLand_TobeDeveloped_Area_Total;
                ////aa.ProposedLand_Area_ResidentialGroupHousing = item.ProposedLand_Area_ResidentialGroupHousing;
                ////aa.ProposedLand_Area_ResidentialPlotted = item.ProposedLand_Area_ResidentialPlotted;
                ////aa.ProposedLand_Area_Commercial = item.ProposedLand_Area_Commercial;
                ////aa.ProposedLand_Area_Industrial = item.ProposedLand_Area_Industrial;
                ////aa.ProposedLand_Area_A_column = item.ProposedLand_Area_A_column;
                ////aa.ProposedLand_Area_B_column = item.ProposedLand_Area_B_column;
                ////aa.ProposedLand_Area_C_column = item.ProposedLand_Area_C_column;
                ////aa.ProposedLand_Area_D_column = item.ProposedLand_Area_D_column;
                ////aa.Name_of_Villages = item.Name_of_Villages;
                ////aa.ProposedLand_TobeDeveloped_TotalOpenArea = item.ProposedLand_TobeDeveloped_TotalOpenArea;
                ////aa.ProposedLand_TobeDeveloped_TotalCoveredArea = item.ProposedLand_TobeDeveloped_TotalCoveredArea;
                ////aa.ProposedProjectLand_StartPoint_Longitude = item.ProposedProjectLand_StartPoint_Longitude;
                ////aa.ProposedProjectLand_StartPoint_Latitude = item.ProposedProjectLand_StartPoint_Latitude;
                ////aa.ProposedProjectLand_EndPoint_Longitude = item.ProposedProjectLand_EndPoint_Longitude;
                ////aa.ProposedProjectLand_EndPoint_Latitude = item.ProposedProjectLand_EndPoint_Latitude;
                ////aa.IsProjectLand_Status_OwnedByPromoter = item.IsProjectLand_Status_OwnedByPromoter;
                ////aa.IsProjectLand_Status_NotOwnedByPromoter = item.IsProjectLand_Status_NotOwnedByPromoter;
                ////aa.IsLandEncumbrances_IfAny = item.IsLandEncumbrances_IfAny;
                //////aa.Remarks_IfAny = item.Remarks_IfAny;
                //////aa.A_column = item.A_column;
                //////aa.B_column = item.B_column;
                //////aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }



            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;
            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion

            return View("Create_LandDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_LandDetails(ClsPrp_Project_LandDetails smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectLandRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_LandDetails sdb = new ClsMethod_Project_LandDetails();

                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        if (sdb.Update_Project_Landdetails(smodel))
                        {
                            TempData["message"] = "Record Updated Successfully!";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        if (sdb.Add_Project_Landdetails(smodel))
                        {
                            TempData["message"] = "Record Inserted Successfully!";                            
                            ModelState.Clear();
                        }
                    }                    
                }
                // return View("Create");
                return RedirectToAction("Create_LandDetails");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        //// GET: Single Display
        [HttpGet]//@ProjectLand_IndexID bigint,        @ProjectConstructionRelated_ProjectRegistration_ID
        public ActionResult Edit_LandDetails(Int64? ProjectLand_IndexID, Int64? ProjectConstructionRelated_ProjectRegistration_ID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_LandDetails sdb = new ClsMethod_Project_LandDetails();
            ClsPrp_Project_LandDetails aa = new ClsPrp_Project_LandDetails();
            aa.prpongoing = sdb.Display_Project_LanddetailsIndexID(ProjectLand_IndexID, ProjectConstructionRelated_ProjectRegistration_ID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectLand_ID = item.ProjectLand_ID;
                aa.ProjectLand_IndexID = item.ProjectLand_IndexID;
                aa.ProjectLandRelated_ProjectRegistration_ID = item.ProjectLandRelated_ProjectRegistration_ID;
                aa.ProposedLand_TobeDeveloped_Area_Total = item.ProposedLand_TobeDeveloped_Area_Total;
                aa.ProposedLand_Area_ResidentialGroupHousing = item.ProposedLand_Area_ResidentialGroupHousing;
                aa.ProposedLand_Area_ResidentialPlotted = item.ProposedLand_Area_ResidentialPlotted;
                aa.ProposedLand_Area_Commercial = item.ProposedLand_Area_Commercial;
                aa.ProposedLand_Area_Industrial = item.ProposedLand_Area_Industrial;
                aa.ProposedLand_Area_A_column = item.ProposedLand_Area_A_column;
                aa.ProposedLand_Area_B_column = item.ProposedLand_Area_B_column;
                aa.ProposedLand_Area_C_column = item.ProposedLand_Area_C_column;
                aa.ProposedLand_Area_D_column = item.ProposedLand_Area_D_column;
                aa.Name_of_Villages = item.Name_of_Villages;
                aa.ProposedLand_TobeDeveloped_TotalOpenArea = item.ProposedLand_TobeDeveloped_TotalOpenArea;
                aa.ProposedLand_TobeDeveloped_TotalCoveredArea = item.ProposedLand_TobeDeveloped_TotalCoveredArea;
                aa.ProposedProjectLand_StartPoint_Longitude = item.ProposedProjectLand_StartPoint_Longitude;
                aa.ProposedProjectLand_StartPoint_Latitude = item.ProposedProjectLand_StartPoint_Latitude;
                aa.ProposedProjectLand_EndPoint_Longitude = item.ProposedProjectLand_EndPoint_Longitude;
                aa.ProposedProjectLand_EndPoint_Latitude = item.ProposedProjectLand_EndPoint_Latitude;
                aa.IsProjectLand_Status_OwnedByPromoter = item.IsProjectLand_Status_OwnedByPromoter;
                aa.IsProjectLand_Status_NotOwnedByPromoter = item.IsProjectLand_Status_NotOwnedByPromoter;
                aa.IsLandEncumbrances_IfAny = item.IsLandEncumbrances_IfAny;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                //aa.A_column = item.A_column;
                //aa.B_column = item.B_column;
                //aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_LandDetails", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_LandDetails(ClsPrp_Project_LandDetails smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_LandDetails sdb = new ClsMethod_Project_LandDetails();

                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        if (sdb.Update_Project_Landdetails(smodel))
                        {
                            TempData["message"] = "Record Updated Successfully!";
                            ModelState.Clear();
                        }
                    }              
                }

                return RedirectToAction("Create_LandDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //GET: Delete
        public ActionResult Delete_LandDetails(Int64? ProjectLand_IndexID, Int64? ProjectConstructionRelated_ProjectRegistration_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_LandDetails sdb = new ClsMethod_Project_LandDetails();
                if (sdb.Delete_Project_LandDetails(ProjectLand_IndexID, ProjectConstructionRelated_ProjectRegistration_ID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_LandDetails");
            }
            catch
            {
                return View();
            }
        }


        #endregion

        /// Table 06  Detail of Project Khasra(If Any)
        #region
        /// <summary>
        ///  Detail of Project Khasra(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Dropdownlist(FormCollection frm, ClsPrp_Project_KhasraAreaDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            //ViewBag.SelectedItem = frm["ProjectKhasraAreaRelated_ProjectRegistration_ID"];
            TempData["SelectedItem"] = frm["ProjectKhasraAreaRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_Khasra()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;

            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }


            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "Khasra"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            //TempData["list"] = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //TempData.Keep();


            ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
            ClsPrp_Project_KhasraAreaDetails aa = new ClsPrp_Project_KhasraAreaDetails();
            aa.prpongoing = sdb.Display_Project_KhasraAreaDetails(Project_id);
            aa.ProjectKhasraAreaRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ViewBag.project = aa.prpongoing;

            ClsMethod_Project_KhasraAreaDetails clsfive = new ClsMethod_Project_KhasraAreaDetails();


            //////// Fill project list from project Registration Table
            //ClsMethodProject objdis = new ClsMethodProject();

            aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            ViewBag.list = aa.ProjectMaster;

             TempData["submitvalue"] = "Submit";TempData.Keep();
            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            return View("Create_Khasra", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_Khasra(ClsPrp_Project_KhasraAreaDetails smodel)
        {
            //Int64 Project_id = 110028;
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }


            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
                    if (sdb.Add_Project_KhasraAreaDetails(smodel))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_Khasra");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        // GET: Single Display ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID,
        [HttpGet]
        public ActionResult Edit_Khasra(Int64 ProjectKhasra_IndexID, int ProjectKhasraRelated_ProjectRegistration_ID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
            ClsPrp_Project_KhasraAreaDetails aa = new ClsPrp_Project_KhasraAreaDetails();
            aa.prpongoing = sdb.Display_Project_KhasraAreaDetailsById(ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectKhasraArea_IndexID = item.ProjectKhasraArea_IndexID;
                aa.ProjectKhasraArea_ID = item.ProjectKhasraArea_ID;
                aa.ProjectKhasraAreaRelated_ProjectRegistration_ID = item.ProjectKhasraAreaRelated_ProjectRegistration_ID;
                aa.KhasraNumber_ProposedLand_TobeDeveloped = item.KhasraNumber_ProposedLand_TobeDeveloped;
                aa.Area_ProposedLand_EachKhasraNumber = item.Area_ProposedLand_EachKhasraNumber;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_Khasra", aa);

        }

        // POST: Update
        [HttpPost]
        public ActionResult Edit_Khasra(ClsPrp_Project_KhasraAreaDetails smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
                    sdb.Update_Project_KhasraAreaDetails(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("Create_Khasra");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        // GET: Delete 
        public ActionResult Delete_Khasra(Int64 ProjectKhasra_IndexID, Int64 ProjectKhasraRelated_ProjectRegistration_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
                if (sdb.Delete_Project_KhasraAreaDetailsById(ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_Khasra");
            }
            catch
            {
                return View();
            }
        }

        #endregion Khasra

        /// Table 07  Detail of Project ApprovalDetails(If Any)
        #region
        /// <summary>
        ///  Detail of Project ApprovalDetails(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectApproval(FormCollection frm, ClsPrp_Project_ApprovalDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["ProjectApprovalRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectApprovalRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        // GET: Empty Create + Display
        public ActionResult Create_ApprovalDetails()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ApprovalDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());


            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();
            ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
            ClsPrp_Project_ApprovalDetails aa = new ClsPrp_Project_ApprovalDetails();
            aa.prpongoing = sdb.Display_Project_ApprovalDetails(Project_id);
            aa.ProjectApprovalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_ApprovalDetails clsfive = new ClsMethod_Project_ApprovalDetails();

            //////// Fill project list from project Registration Table
            //ClsMethodProject objdis = new ClsMethodProject();
            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            TempData["submitvalue"] = "Submit";
            TempData.Keep();
            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            return View("Create_ApprovalDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_ApprovalDetails(ClsPrp_Project_ApprovalDetails smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectApprovalRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            //Save & Update
            #region

            String ext = String.Empty;
            string FilePathExt = string.Empty;
            string error = string.Empty;
            int errorstate = 0;

            if (TempData["submitvalue"].ToString() == "Update")
            {
                #region PhotoCertificate Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataProject";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.DocumentType_FileName))
                            {
                                pathindb = smodel.DocumentType_FileName.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.DocumentType_FilePath))
                            {
                                fileName = smodel.DocumentType_FilePath.ToString();
                            }
                            else
                            {
                                fileName = "ApprovalDocument_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }

                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 1MB";
                            error = "Photo Size Should be less than 1MB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg or .pdf";
                        error = "Photo format should be .jpg or .pdf";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Photograph";
                    error = "Kindly Upload Photograph";
                    errorstate = 1;

                    //update with same photograph
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.DocumentType_FilePath;
                            ext = smodel.DocumentType_FileName;
                            FilePathExt = smodel.DocumentType_FileName;
                        }
                        try
                        {
                            ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
                            sdb.Update_Project_ApprovalDetails(smodel, Project_id, Photo_Address, FilePathExt);//, smodel.Application_id, smodel.Id, smodel.Promoter_OtherMemberDetails_ID);
                            TempData["message"] = "Details updated Successfully";

                            return RedirectToAction("Create_ApprovalDetails");
                        }
                        catch (Exception ex)
                        {
                            return View();
                        }
                    }
                    return RedirectToAction("Create_ApprovalDetails");
                }
                else
                {
                    return RedirectToAction("Create_ApprovalDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataProject";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "ApprovalDocument_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 1MB";
                            error = "Photo Size Should be less than 1MB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg or .pdf";
                        error = "Photo format should be .jpg or .pdf";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Photograph";
                    error = "Kindly Upload Photograph";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (Photo_Address == "")
                            {
                                Photo_Address = smodel.DocumentType_FilePath;
                                ext = smodel.DocumentType_FileName;
                                FilePathExt = smodel.DocumentType_FileName;
                            }
                            ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
                            if (sdb.Add_Project_ApprovalDetails(smodel, Project_id, Photo_Address, FilePathExt))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }                        
                        return RedirectToAction("Create_ApprovalDetails");
                    }
                    else
                    {                        
                        return RedirectToAction("Create_ApprovalDetails");
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return View();
                }
            }
            #endregion
        }

        //// GET: Single Display
        [HttpGet]
        public ActionResult Edit_ApprovalDetails(Int64 ProjectApprovalRelated_ProjectRegistration_ID, int ProjectApproval_IndexID)
        {
            ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
            ClsPrp_Project_ApprovalDetails aa = new ClsPrp_Project_ApprovalDetails();
            aa.prpongoing = sdb.Display_Project_ApprovalDetailsById(ProjectApprovalRelated_ProjectRegistration_ID, ProjectApproval_IndexID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectApproval_IndexID = item.ProjectApproval_IndexID;
                aa.ProjectApproval_ID = item.ProjectApproval_ID;
                aa.ProjectApprovalRelated_ProjectRegistration_ID = item.ProjectApprovalRelated_ProjectRegistration_ID;
                aa.DocumentType_CategoryName = item.DocumentType_CategoryName;
                aa.DocumentType_Code = item.DocumentType_Code;
                aa.DocumentType_Name = item.DocumentType_Name;
                aa.DocumentType_Status = item.DocumentType_Status;
                aa.Date_ApplicationPlannedorExpectedReceipt = item.Date_ApplicationPlannedorExpectedReceipt;
                aa.DocumentType_FileSize = item.DocumentType_FileSize;
                aa.DocumentType_FileFormat = item.DocumentType_FileFormat;
                aa.DocumentType_FilePath = item.DocumentType_FilePath;
                aa.DocumentType_FileName = item.DocumentType_FileName;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_ApprovalDetails", aa);
        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_ApprovalDetails(ClsPrp_Project_ApprovalDetails smodel)
        {
            try
            {
                ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
               // sdb.Update_Project_ApprovalDetails(smodel);//, Project_id, Id, Project_Experience_ID);
                TempData["message"] = " Details updated Successfully";

                return RedirectToAction("Create_ApprovalDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_ApprovalDetails(Int64 ProjectApprovalRelated_ProjectRegistration_ID, Int64 ProjectApproval_IndexID)
        {
            try
            {
                ClsMethod_Project_ApprovalDetails sdb = new ClsMethod_Project_ApprovalDetails();
                if (sdb.Delete_Project_ApprovalDetailsById(ProjectApprovalRelated_ProjectRegistration_ID, ProjectApproval_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";
                }
                return RedirectToAction("Create_ApprovalDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        /// Done Table 09 Detail of Project Construction(If Any)
        #region
        /// <summary>
        ///  Detail of Project Construction(If Any)
        /// <summary>
        ///  Detail of Project Construction(If Any)
        /// </summary>
        /// <returns></returns>
        #region Project_Dropdown
        // Get Project detail on basis of App ID
        [HttpPost]
        public ActionResult DropdownlistProject_Construction(FormCollection frm, ClsPrp_Project_BuildingTowerBlock_Construction smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectConstructionRelated_ProjectRegistration_ID;
             TempData["SelectedItem"] = frm["ProjectConstructionRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        public ActionResult GetProject()
        {
            //Int64 Application_ID = 10001;

            ClsMethodProject objdis = new ClsMethodProject();
            //aa.stateMaster = objdis.State_list();

            // Class2 aa = new Class2();
            ClsPrp_Project_BuildingTowerBlock_Construction aa = new ClsPrp_Project_BuildingTowerBlock_Construction();

            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            ViewBag.list = aa.ProjectMaster;            


            //return Json(aa, JsonRequestBehavior.AllowGet);

            return View();



        }
        #endregion Project_Dropdown
        // GET: Empty Create + Display
        public ActionResult Create_Construction()
        {
            Int64 Project_id = 0;

            //Int64 Application_ID = 10001;
            ViewBag.SelectedItem = "";
            ClsMethodProject objdis = new ClsMethodProject();
            //aa.stateMaster = objdis.State_list();

            // Class2 aa = new Class2();
            ClsPrp_Project_BuildingTowerBlock_Construction ss = new ClsPrp_Project_BuildingTowerBlock_Construction();

            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //ss.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = ss.ProjectMaster;
            // Int64 Project_id = 0;
            Session["url"] = Request.UrlReferrer;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "Construction"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }


            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
            ClsPrp_Project_BuildingTowerBlock_Construction aa = new ClsPrp_Project_BuildingTowerBlock_Construction();
            aa.prpongoing = sdb.Display_BuildingTowerBlock_Construction(Project_id);
            aa.ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_BuildingTowerBlock_Construction clsfive = new ClsMethod_Project_BuildingTowerBlock_Construction();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            TempData["CurrentYears"] = null;ViewBag.Years = GetYears();

            TempData["submitvalue"] = "Submit";TempData.Keep();
            //Check Isdraft value From Diary Number table
           
            return View("Create_Construction", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_Construction(ClsPrp_Project_BuildingTowerBlock_Construction smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectConstructionRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["CurrentYears"] = smodel.B_column;
            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
                     
                 Int32 check_IsdraftValue=   Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {
                        if (sdb.Add_Project_BuildingTowerBlock_Construction(smodel))//, Project_id))
                        {
                            TempData["message"] = "Details Added Successfully";

                            // ViewBag.Message = " Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    { 
                    TempData["message"] = "Record Cannot be added";
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_Construction");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: Single Display
        [HttpGet]
        public ActionResult Edit_Construction(Int64 Application_id, Int64 Id)
        {
            //  Project_id = "110029";
            ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
            ClsPrp_Project_BuildingTowerBlock_Construction aa = new ClsPrp_Project_BuildingTowerBlock_Construction();
            aa.prpongoing = sdb.Display_BuildingTowerBlock_ConstructionBYID(Application_id, Id);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectConstruction_ID = item.ProjectConstruction_ID;
                aa.ProjectConstruction_IndexID = item.ProjectConstruction_IndexID;
                aa.ProjectConstructionRelated_ProjectRegistration_ID = item.ProjectConstructionRelated_ProjectRegistration_ID;
                aa.BuildingTowerBlock_Name = item.BuildingTowerBlock_Name;
                aa.Proposed_FloorPlotsNumber = item.Proposed_FloorPlotsNumber;
                aa.CurrentlySanctioned_FloorPlotsNumber = item.CurrentlySanctioned_FloorPlotsNumber;
                aa.Constructed_FloorsNumber = item.Constructed_FloorsNumber;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            ViewBag.Years = GetYears();

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_Construction", aa);

        }

        // POST: Update
        [HttpPost]
        public ActionResult Edit_Construction( ClsPrp_Project_BuildingTowerBlock_Construction smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
                    sdb.Update_Project_BuildingTowerBlock_Construction(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = " Details updated Successfully";
                }

                return RedirectToAction("Create_Construction");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Delete 
        public ActionResult Delete_Construction(Int64 id, Int64 Application_id)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
                if (sdb.Delete_BuildingTowerBlock_Construction(Application_id, id))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_Construction");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        /// Table 10 Detail of Project Inventory(If Any)
        #region
        /// <summary>
        ///  Detail of Project Inventory(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectInventory(FormCollection frm, ClsPrp_Project_BuildingTowerBlock_Inventory smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
 
            TempData["SelectedItem"] = frm["ProjectInventoryRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectInventoryRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_Inventory()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "Inventory"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());


            ClsMethod_Project_BuildingTowerBlock_Inventory sdb = new ClsMethod_Project_BuildingTowerBlock_Inventory();
            ClsPrp_Project_BuildingTowerBlock_Inventory aa = new ClsPrp_Project_BuildingTowerBlock_Inventory();
            aa.prpongoing = sdb.Display_Project_BuildingTowerBlock_Inventory(Project_id);
            aa.ProjectInventoryRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_BuildingTowerBlock_Inventory clsfive = new ClsMethod_Project_BuildingTowerBlock_Inventory();

            ClsMethod_master_BuildingTowerName BTMaster = new ClsMethod_master_BuildingTowerName();
            aa.MasterBuilding = BTMaster.Display_BuildingTowerBlock_Construction(Project_id);

            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;
            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            TempData["CurrentYears"] = null;ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit";TempData.Keep();
            return View("Create_Inventory", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_Inventory(ClsPrp_Project_BuildingTowerBlock_Inventory smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectInventoryRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["CurrentYears"] = smodel.B_column;

            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_BuildingTowerBlock_Inventory sdb = new ClsMethod_Project_BuildingTowerBlock_Inventory();
                    Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {
                        if (sdb.Add_Project_BuildingTowerBlock_Inventory(smodel, Project_id))
                        {
                            TempData["message"] = " Details Added Successfully";
                            // ViewBag.Message = " Details Added Successfully";
                            ModelState.Clear();
                        }

                    }
                    else
                    {
                        TempData["message"] = "Record Cannot be added";
                    }
                    // return View("Create");
                }
                return RedirectToAction("Create_Inventory");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        //// GET: Single Display Display_Project_BuildingTowerBlock_InventoryById(Int64 ProjectRegistration_ID,Int64 @ProjectInventory_IndexID)
        [HttpGet]
        public ActionResult Edit_Inventory(Int64 ProjectRegistration_ID, Int64 ProjectInventory_IndexID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_BuildingTowerBlock_Inventory sdb = new ClsMethod_Project_BuildingTowerBlock_Inventory();
            ClsPrp_Project_BuildingTowerBlock_Inventory aa = new ClsPrp_Project_BuildingTowerBlock_Inventory();
            aa.prpongoing = sdb.Display_Project_BuildingTowerBlock_InventoryById(ProjectRegistration_ID, ProjectInventory_IndexID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);
            ClsMethod_master_BuildingTowerName BTMaster = new ClsMethod_master_BuildingTowerName();
            aa.MasterBuilding = BTMaster.Display_BuildingTowerBlock_Construction(ProjectRegistration_ID);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectInventory_ID = item.ProjectInventory_ID;
                aa.ProjectInventory_IndexID = item.ProjectInventory_IndexID;
                aa.ProjectInventoryRelated_ProjectRegistration_ID = item.ProjectInventoryRelated_ProjectRegistration_ID;
                aa.BuildingTowerBlock_Name = item.BuildingTowerBlock_Name;
                aa.ApartmentShopPlot_Type = item.ApartmentShopPlot_Type;
                aa.ApartmentShopPlot_CarpetArea = item.ApartmentShopPlot_CarpetArea;
                aa.ApartmentShopPlot_ExclusiveOpenTerraceArea = item.ApartmentShopPlot_ExclusiveOpenTerraceArea;
                aa.ApartmentShopPlot_ExclusiveBalconyVerandahArea = item.ApartmentShopPlot_ExclusiveBalconyVerandahArea;
                aa.ApartmentShopPlot_AvailableforSaleNumber = item.ApartmentShopPlot_AvailableforSaleNumber;
                aa.ApartmentShopPlot_AlreadySoldNumber = item.ApartmentShopPlot_AlreadySoldNumber;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
            ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_Inventory", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_Inventory(ClsPrp_Project_BuildingTowerBlock_Inventory smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_BuildingTowerBlock_Inventory sdb = new ClsMethod_Project_BuildingTowerBlock_Inventory();
                    sdb.Update_Project_BuildingTowerBlock_Inventory(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = " Details updated Successfully";
                }

                return RedirectToAction("Create_Inventory");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_Inventory(Int64 ProjectRegistration_ID, Int64 ProjectInventory_IndexID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_BuildingTowerBlock_Inventory sdb = new ClsMethod_Project_BuildingTowerBlock_Inventory();
                if (sdb.Delete_BuildingTowerBlock_Inventory(ProjectRegistration_ID, ProjectInventory_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_Inventory");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        /// Table 11 Detail of Project Facilities(If Any)
        #region
        /// <summary>
        ///  Detail of Project Facilities(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectFacilities(FormCollection frm, ClsPrp_Project_InternalInfrastructure_Facilities smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
            TempData["SelectedItem"] = frm["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_Facilities()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();
            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "Facilities"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            ClsMethod_Project_InternalInfrastructure_Facilities sdb = new ClsMethod_Project_InternalInfrastructure_Facilities();
            ClsPrp_Project_InternalInfrastructure_Facilities aa = new ClsPrp_Project_InternalInfrastructure_Facilities();
            aa.prpongoing = sdb.Display_Project_InternalInfrastructure_Facilities(Project_id);
            aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_InternalInfrastructure_Facilities clsfive = new ClsMethod_Project_InternalInfrastructure_Facilities();


            //////// Fill project list from project Registration Table
            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;
            TempData["CurrentYears"] = null;ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit";TempData.Keep();
            return View("Create_Facilities", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_Facilities(ClsPrp_Project_InternalInfrastructure_Facilities smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["CurrentYears"] = smodel.B_column;

            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_InternalInfrastructure_Facilities sdb = new ClsMethod_Project_InternalInfrastructure_Facilities();
                    Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {
                        if (sdb.Add_Project_InternalInfrastructure_Facilities(smodel, Project_id))
                        {
                            TempData["message"] = " Details Added Successfully";
                            // ViewBag.Message = " Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        TempData["message"] = "Record Cannot be added";
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_Facilities");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Single Display
        [HttpGet]
        public ActionResult Edit_Facilities(Int64 Application_id, int Id)
        {
            //  Project_id = "110029";
            ClsMethod_Project_InternalInfrastructure_Facilities sdb = new ClsMethod_Project_InternalInfrastructure_Facilities();
            ClsPrp_Project_InternalInfrastructure_Facilities aa = new ClsPrp_Project_InternalInfrastructure_Facilities();
            aa.prpongoing = sdb.Display_Project_InternalInfrastructure_Facilities(Application_id, Id);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectInfrastructureFacilities_IndexID = item.ProjectInfrastructureFacilities_IndexID;
                aa.ProjectInfrastructureFacilities_ID = item.ProjectInfrastructureFacilities_ID;
                aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = item.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
                aa.InternalInfrastructureFacilities_Name = item.InternalInfrastructureFacilities_Name;
                aa.InternalInfrastructureFacilities_Type = item.InternalInfrastructureFacilities_Type;
                aa.ExternalAgency_LocalAuthority_Name = item.ExternalAgency_LocalAuthority_Name;
                aa.Is_InternalInfrastructureFacilitiesApplicable = item.Is_InternalInfrastructureFacilitiesApplicable;
                aa.WorkProgress_Percentage = item.WorkProgress_Percentage;
                aa.InternalInfrastructureFacilities_Details = item.InternalInfrastructureFacilities_Details;
                
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                //aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
            ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_Facilities", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_Facilities(ClsPrp_Project_InternalInfrastructure_Facilities smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_InternalInfrastructure_Facilities sdb = new ClsMethod_Project_InternalInfrastructure_Facilities();
                    sdb.Update_Project_InternalInfrastructure_Facilities(smodel);
                    TempData["message"] = "Details updated Successfully";
                }
                return RedirectToAction("Create_Facilities");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_InternalFacilities(Int64 ProjectInfrastructure_ProjectRegistration_ID, Int64 ProjectInfrastructureFacilities_IndexID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_InternalInfrastructure_Facilities sdb = new ClsMethod_Project_InternalInfrastructure_Facilities();
                if (sdb.Delete_InternalInFacilities(ProjectInfrastructure_ProjectRegistration_ID, ProjectInfrastructureFacilities_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_Facilities");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        /// Table 12  Detail of Project ParkingDetails(If Any)
        #region
        /// <summary>
        ///  Detail of Project ParkingDetails(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectParkingDetails(FormCollection frm, ClsPrp_Project_ParkingDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectParkingRelated_ProjectRegistration_ID;
            

            TempData["SelectedItem"] = frm["ProjectParkingRelated_ProjectRegistration_ID"];
            TempData.Keep();

            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }

        // GET: Empty Create + Display
        public ActionResult Create_ParkingDetails()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";
            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();
            
            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ParkingDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            ClsMethod_Project_ParkingDetails sdb = new ClsMethod_Project_ParkingDetails();
            ClsPrp_Project_ParkingDetails aa = new ClsPrp_Project_ParkingDetails();
            aa.prpongoing = sdb.Display_Project_ParkingDetails(Project_id);
            aa.ProjectParkingRelated_ProjectRegistration_ID =   Convert.ToInt64(TempData["SelectedItem"]);
            ClsMethod_Project_ParkingDetails clsfive = new ClsMethod_Project_ParkingDetails();


            //////// Fill project list from project Registration Table
            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;
            TempData["CurrentYears"] = null;ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit";TempData.Keep();
            return View("Create_ParkingDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_ParkingDetails(ClsPrp_Project_ParkingDetails smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectParkingRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["CurrentYears"] = smodel.B_column;

            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ParkingDetails sdb = new ClsMethod_Project_ParkingDetails();
                    Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {

                        if (sdb.Add_Project_ParkingDetails(smodel, Project_id))
                        {
                            TempData["message"] = " Details Added Successfully";
                            // ViewBag.Message = " Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        TempData["message"] = "Record Cannot be added";
                    }
                }
                return RedirectToAction("Create_ParkingDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        //// GET: Single Display Display_Project_ParkingDetailsById(Int64 ProjectRegistration_ID,Int64 ProjectParking_IndexID)
        [HttpGet]
        public ActionResult Edit_ParkingDetails(Int64 ProjectRegistration_ID, Int64 ProjectParking_IndexID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_ParkingDetails sdb = new ClsMethod_Project_ParkingDetails();
            ClsPrp_Project_ParkingDetails aa = new ClsPrp_Project_ParkingDetails();
            aa.prpongoing = sdb.Display_Project_ParkingDetailsById(ProjectRegistration_ID, ProjectParking_IndexID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);


            foreach (var item in aa.prpongoing)
            {
                aa.ProjectParking_IndexID = item.ProjectParking_IndexID;
                aa.ProjectParking_ID = item.ProjectParking_ID;
                aa.ProjectParkingRelated_ProjectRegistration_ID = item.ProjectParkingRelated_ProjectRegistration_ID;
                aa.ParkingType = item.ParkingType;
                aa.ParkingSpace_AvailableforSale_Number = item.ParkingSpace_AvailableforSale_Number;
                aa.ParkingSpace_Area_Total = item.ParkingSpace_Area_Total;
                aa.ParkingSpace_BookedSold_Number = item.ParkingSpace_BookedSold_Number;                
                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                //aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
            ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_ParkingDetails", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_ParkingDetails(ClsPrp_Project_ParkingDetails smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ParkingDetails sdb = new ClsMethod_Project_ParkingDetails();
                    sdb.Update_Project_ParkingDetails(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = " Details updated Successfully";
                }

                return RedirectToAction("Create_ParkingDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_ParkingDetails(Int64 ProjectParking_IndexID, Int64 ProjectRegistration_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_ParkingDetails sdb = new ClsMethod_Project_ParkingDetails();
                if (sdb.Delete_Project_ParkingDetails(ProjectParking_IndexID, ProjectRegistration_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_ParkingDetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        /// Table 13  Detail of Project ProfessionalDetails(If Any)
        #region
        /// <summary>
        ///  Detail of Project ProfessionalDetails(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectProfessionalDetails(FormCollection frm, ClsPrp_Project_ProfessionalDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            

            TempData["SelectedItem"] = frm["ProjectProfessionalRelated_ProjectRegistration_ID"];TempData.Keep();

            Session["Project_id"] = smodel.ProjectProfessionalRelated_ProjectRegistration_ID;

            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }

        // GET: Empty Create + Display
        public ActionResult Create_ProfessionalDetails()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
          // ViewBag.SelectedItem = "";
            ClsMethodProject objdis1 = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProfessionalDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

           

            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ProfessionalDetails(Project_id);

            ClsMethod_Project_ProfessionalDetails clsfive = new ClsMethod_Project_ProfessionalDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;




            aa.ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            aa.districtMaster = objdis.dropdownlist_display1();
            TempData["CurrentYears"] = null;ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit";TempData.Keep();
            return View("Create_ProfessionalDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_ProfessionalDetails(ClsPrp_Project_ProfessionalDetails smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectProfessionalRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["CurrentYears"] = smodel.B_column;

            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
                    Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {

                        if (sdb.Add_Project_ProfessionalDetails(smodel, Project_id))
                        {
                            TempData["message"] = " Details Added Successfully";
                            // ViewBag.Message = " Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        TempData["message"] = "Record Cannot be added";
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_ProfessionalDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Single DisplayDisplay_Project_ApprovalDetailsById(Int64 ProjectRegistration_ID,Int64 ProjectProfessional_IndexID)
        [HttpGet]
        public ActionResult Edit_ProfessionalDetails(Int64 ProjectRegistration_ID, Int64 ProjectProfessional_IndexID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ApprovalDetailsById(ProjectRegistration_ID, ProjectProfessional_IndexID);

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

                       
            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();

            ViewBag.state = aa.stateMaster;

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectProfessional_IndexID = item.ProjectProfessional_IndexID;
                aa.ProjectProfessional_ID = item.ProjectProfessional_ID;
                aa.ProjectProfessionalRelated_ProjectRegistration_ID = item.ProjectProfessionalRelated_ProjectRegistration_ID;
                aa.Associated_Consultant_Type = item.Associated_Consultant_Type;
                aa.Name_of_Professional = item.Name_of_Professional;
                aa.RERA_ID_IfAgent = item.RERA_ID_IfAgent;
                aa.Name_and_Year_of_Establishment_of_Promoter = item.Name_and_Year_of_Establishment_of_Promoter;
                aa.Name_and_Profile_of_Key_ProjectsCompleted = item.Name_and_Profile_of_Key_ProjectsCompleted;
                aa.OfficialComm_AddressLine1 = item.OfficialComm_AddressLine1;
                aa.OfficialComm_AddressLine2 = item.OfficialComm_AddressLine2;
                aa.OfficialComm_AddressStateCode = item.OfficialComm_AddressStateCode;
                aa.OfficialComm_AddressDistrictCode = item.OfficialComm_AddressDistrictCode;
                aa.OfficialComm_AddressPIN = item.OfficialComm_AddressPIN;
                aa.MobileNumber = item.MobileNumber;
                aa.Phone_STD = item.Phone_STD;
                aa.Phone_Number = item.Phone_Number;
                aa.Email_ID = item.Email_ID;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_ProfessionalDetails", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_ProfessionalDetails(ClsPrp_Project_ProfessionalDetails smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
                    sdb.Update_Project_ApprovalDetails(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = " Details updated Successfully";
                }
                return RedirectToAction("Create_ProfessionalDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_ProfessionalDetails(Int64 ProjectProfessionalDetailsRelated_ProjectRegistration_ID, Int64 ProjectProfessionalDetails_IndexID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
                if (sdb.Delete_ProfessionalDetails(ProjectProfessionalDetailsRelated_ProjectRegistration_ID, ProjectProfessionalDetails_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_ProfessionalDetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        /// Table 14  Detail of Project PaymentDetails(If Any)
        #region
        /// <summary>
        ///  Detail of Project PaymentDetails(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectPaymentDetails(FormCollection frm, ClsPrp_Project_Payment smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            
            TempData["SelectedItem"] = frm["ProjectPaymentRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectPaymentRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_PaymentDetails()
        {
            
            ClsMethodProject objdis = new ClsMethodProject();
            ViewBag.SelectedItem = "";



            Int64 Project_id = 0;
            //Int64 Application_ID = 0;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "PaymentDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();
            ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();
            ClsPrp_Project_Payment aa = new ClsPrp_Project_Payment();
            aa.prpongoing = sdb.Display_Project_Payment(Project_id);
            aa.ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_Payment clsfive = new ClsMethod_Project_Payment();
            ClsMethod_Project_FeeCalculator sdbcalc = new ClsMethod_Project_FeeCalculator();

            //////// Fill project list from project Registration Table

            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            if (TempData["SelectedItem"] != null)
            {
                if (Convert.ToInt64(TempData["SelectedItem"]) != 0)
                {
                    Tuple<decimal, decimal, decimal, string> getEvaluateFee = sdbcalc.Display_ProjectPaymentRegistrationFeeCalculatorByProjectID(Convert.ToInt64(TempData["SelectedItem"]), PromoterApplicationId, 1);
                    aa.Registration_Fee = getEvaluateFee.Item1;
                    aa.Other_Fee = getEvaluateFee.Item2;
                    aa.Bank_Charges = getEvaluateFee.Item3;
                    aa.DD_BankersCheque_Amount = getEvaluateFee.Item1 + getEvaluateFee.Item2 + getEvaluateFee.Item3;
                }
            }
            TempData["ProjectPayment_TicketName"] = string.Empty;
            TempData["submitvalue"] = "Submit";
            TempData.Keep();
            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            return View("Create_PaymentDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_PaymentDetails(ClsPrp_Project_Payment smodel)
        {
            Int64 Project_id = 0;
            ClsPrp_Project_Payment aa = new ClsPrp_Project_Payment();

            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            ClsMethod_Project_FeeCalculator sdbcalc = new ClsMethod_Project_FeeCalculator();
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectPaymentRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            bool IsValidModel = false;
            Int64 RelatedProjectID = 0;
            Int64 RelatedPromoterID = 0;
            Int64 PaymentType = 0;

            TempData["ProjectPayment_TicketName"] = string.Empty;

            decimal calcRegistrationFee = 0;
            decimal calcWebPortalFee = 0;
            decimal calcOthersFee = 0;
            decimal calcChequeAmount = 0;

            decimal entryRegistrationFee = 0;
            decimal entryWebPortalFee = 0;
            decimal entryOthersFee = 0;
            decimal entryChequeAmount = 0;

            PaymentType = smodel.ProjectPayment_TitleCode;
            RelatedProjectID = smodel.ProjectPaymentRelated_ProjectRegistration_ID;
            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            RelatedPromoterID = PromoterApplicationId;

            #region Project Fee Calculator Validation Function
            if (PaymentType == 1)
            {
                if (Convert.ToInt64(RelatedPromoterID) != 0)
                {
                    if (Convert.ToInt64(RelatedProjectID) != 0)
                    {
                        Tuple<decimal, decimal, decimal, string> getCalcFee = sdbcalc.Display_ProjectPaymentRegistrationFeeCalculatorByProjectID(Project_id, PromoterApplicationId, 1);

                        // LOGIC to check Validate Fee Structure                        

                        calcRegistrationFee = getCalcFee.Item1;
                        calcWebPortalFee = getCalcFee.Item2;
                        calcOthersFee = getCalcFee.Item3;
                        calcChequeAmount = getCalcFee.Item1 + getCalcFee.Item2 + getCalcFee.Item3;                        

                        entryRegistrationFee = smodel.Registration_Fee;
                        entryWebPortalFee = smodel.Other_Fee;
                        entryOthersFee = smodel.Bank_Charges;
                        entryChequeAmount = smodel.DD_BankersCheque_Amount;

                        Math.Round(calcRegistrationFee, 2);
                        Math.Round(calcWebPortalFee, 2);
                        Math.Round(calcOthersFee, 2);
                        Math.Round(calcChequeAmount, 2);

                        Math.Round(entryRegistrationFee, 2);
                        Math.Round(entryWebPortalFee, 2);
                        Math.Round(entryOthersFee, 2);
                        Math.Round(entryChequeAmount, 2);

                        bool flagFee1 = false;
                        bool flagFee2 = false;
                        if (entryRegistrationFee >= calcRegistrationFee)
                        {
                            flagFee1 = true;
                        }
                        if (entryChequeAmount >= calcChequeAmount)
                        {
                            flagFee2 = true;
                        }

                        if (flagFee1 == true && flagFee2 == true)
                        {
                            IsValidModel = true;
                        }
                    }
                }
            }
            else
            {
                IsValidModel = true;
            }
            #endregion

            if (IsValidModel != false)
            {
                //Case 1: When Validate Fee by Calculator
                if (smodel.Payment_Mode != "Online Payment")
                {
                    //Save & Update
                    #region Offline Payment Mode

                    String ext = String.Empty;
                    string FilePathExt = string.Empty;
                    string error = string.Empty;
                    int errorstate = 0;

                    if (TempData["submitvalue"].ToString() == "Update")
                    {
                        #region PhotoCertificate Update with Path
                        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                        {
                            var files = Request.Files[0];
                            var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                            ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                int size = files.ContentLength;
                                if (size <= 512000)
                                {

                                    #region Declare Variables
                                    var pathpromoterdata = "";
                                    var pathindb = "";
                                    string masterPromoterDoc_SetFilePath = "readwritedataProject";
                                    #endregion

                                    #region UpdateFile Path Creation 
                                    if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FileName))
                                    {
                                        pathindb = smodel.ImageDDorBankersCheque_FileName.ToString();
                                    }
                                    else
                                    {
                                        pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                                    }
                                    pathpromoterdata = Server.MapPath("~/" + pathindb);

                                    if (!Directory.Exists(pathpromoterdata))
                                    {
                                        Directory.CreateDirectory(pathpromoterdata);
                                    }
                                    #endregion

                                    var fileName = string.Empty;
                                    if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FilePath))
                                    {
                                        fileName = smodel.ImageDDorBankersCheque_FilePath.ToString();
                                    }
                                    else
                                    {
                                        fileName = "DDBCheque_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                    }

                                    var path = Path.Combine(pathpromoterdata, fileName);
                                    files.SaveAs(path);
                                    Photo_Address = fileName;
                                    FilePathExt = pathindb;

                                }
                                else
                                {
                                    TempData["notice"] = "Photo Size Should be less than 512KB";
                                    error = "Photo Size Should be less than 512KB";
                                    errorstate = 1;
                                }
                            }
                            else
                            {
                                TempData["notice"] = "Photo format should be .jpg";
                                error = "Photo format should be .jpg";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Kindly Upload Photograph";
                            error = "Kindly Upload Photograph";
                            errorstate = 1;

                            //update with same photograph
                            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                            {
                                errorstate = 0;
                            }

                        }
                        #endregion
                        if (errorstate == 0)
                        {
                            if (ModelState.IsValid)
                            {
                                if (Photo_Address == "")
                                {
                                    Photo_Address = smodel.ImageDDorBankersCheque_FilePath;
                                    ext = smodel.ImageDDorBankersCheque_FileName;
                                    FilePathExt = smodel.ImageDDorBankersCheque_FileName;
                                }

                                try
                                {
                                    ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();
                                    sdb.Update_Project_Payment(smodel, UserNam, UID);//, smodel.Application_id, smodel.Id, smodel.Promoter_OtherMemberDetails_ID);
                                    TempData["message"] = "Details updated Successfully";

                                    return RedirectToAction("Create_PaymentDetails");
                                }
                                catch (Exception ex)
                                {
                                    return View();
                                }
                            }
                            return RedirectToAction("Create_PaymentDetails");
                        }
                        else
                        {
                            return RedirectToAction("Create_PaymentDetails");
                        }
                    }
                    else
                    {
                        #region PhotoCertificate Save with Path
                        if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                        {
                            var files = Request.Files[0];
                            var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                            ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                int size = files.ContentLength;
                                if (size <= 512000)
                                {

                                    #region Declare Variables
                                    var pathpromoterdata = "";
                                    var pathindb = "";
                                    string masterPromoterDoc_SetFilePath = "readwritedataProject";
                                    #endregion

                                    #region SaveFile Path Creation
                                    pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                                    pathpromoterdata = Server.MapPath("~/" + pathindb);

                                    if (!Directory.Exists(pathpromoterdata))
                                    {
                                        Directory.CreateDirectory(pathpromoterdata);
                                    }
                                    #endregion

                                    var fileName = string.Empty;
                                    fileName = "DDBCheque_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                                    var path = Path.Combine(pathpromoterdata, fileName);
                                    files.SaveAs(path);
                                    Photo_Address = fileName;
                                    FilePathExt = pathindb;

                                }
                                else
                                {
                                    TempData["notice"] = "Photo Size Should be less than 512KB";
                                    error = "Photo Size Should be less than 512KB";
                                    errorstate = 1;
                                }
                            }
                            else
                            {
                                TempData["notice"] = "Photo format should be .jpg";
                                error = "Photo format should be .jpg";
                                errorstate = 1;
                            }
                        }
                        else
                        {
                            TempData["notice"] = "Kindly Upload Photograph";
                            error = "Kindly Upload Photograph";
                            errorstate = 1;
                        }
                        #endregion

                        try
                        {
                            if (errorstate == 0)
                            {
                                if (ModelState.IsValid)
                                {
                                    if (Photo_Address == "")
                                    {
                                        Photo_Address = smodel.ImageDDorBankersCheque_FilePath;
                                        ext = smodel.ImageDDorBankersCheque_FileName;
                                        FilePathExt = smodel.ImageDDorBankersCheque_FileName;
                                    }

                                    ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();

                                    //to bind bank master
                                    ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
                                    aa.BankMaster = Bmaster.Display_Master_BankDetails();

                                    //to bind Payment master
                                    ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
                                    aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

                                    if (sdb.Add_Project_Payment(smodel, Project_id, Photo_Address, FilePathExt, UserNam, UID))
                                    {
                                        TempData["message"] = " Details Added Successfully";

                                        ModelState.Clear();
                                    }
                                }
                                return RedirectToAction("Create_PaymentDetails");
                            }
                            else
                            {
                                return RedirectToAction("Create_PaymentDetails");
                            }
                        }
                        catch (Exception ex)
                        {
                            return View();
                        }
                    }
                    #endregion
                }
                else if (smodel.Payment_Mode == "Online Payment")
                {
                    //Save & Update 
                    #region Online Payment Mode
                    //(Before Payment Processed with Flag=5) 
                    //(With processed with Flag=1)
                    string FileName = string.Empty;
                    string ext = string.Empty;
                    string FilePath = string.Empty;

                    //smodel.Bank_Charges = Convert.ToDecimal(0.00);
                    smodel.Date_of_Payment_RegistrationFee = new DateTime(0001, 1, 1);
                    smodel.Bank_Name = string.Empty;
                    smodel.Branch_Name = string.Empty;
                    smodel.A_column = string.Empty; //Branch Address
                    smodel.DD_BankersCheque_Number = 0;
                    //smodel.DD_BankersCheque_Amount = Convert.ToDecimal(smodel.Registration_Fee + smodel.Other_Fee);
                    smodel.ImageDDorBankersCheque_FileName = string.Empty;
                    smodel.ImageDDorBankersCheque_FilePath = string.Empty;

                    ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();

                    ModelState.Remove("Date_of_Payment_RegistrationFee");
                    ModelState.Remove("Bank_Name");
                    ModelState.Remove("Branch_Name");
                    ModelState.Remove("DD_BankersCheque_Number");
                    ModelState.Remove("A_column");

                    try
                    {
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            if (ModelState.IsValid)
                            {
                                sdb.Update_Project_Payment(smodel, UserNam, UID);
                                TempData["message"] = "Details updated Successfully";
                                ModelState.Clear();
                            }
                            return RedirectToAction("Create_PaymentDetails");
                        }
                        else
                        {
                            if (ModelState.IsValid)
                            {
                                if (sdb.Add_Project_Payment(smodel, Project_id, Photo_Address, FileName, UserNam, UID))
                                {
                                    ViewBag.Message = "Your Data is Successfully Submitted";
                                    ModelState.Clear();
                                }
                            }
                            return RedirectToAction("Create_PaymentDetails");
                        }
                    }
                    catch (Exception ex)
                    {
                        string strretval = ex.ToString();
                        return RedirectToAction("Create_PaymentDetails");
                    }
                    #endregion
                }
                return RedirectToAction("Create_PaymentDetails");
            }
            else
            {
                //Case 2: When Not Validate Fee by Calculator
                #region
                //to bind bank master
                ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
                aa.BankMaster = Bmaster.Display_Master_BankDetails();

                //to bind Payment master
                ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
                aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

                TempData["ProjectPayment_TicketName"] = "Invalid True";
                TempData["message"] = " Oops! Invalid details of Fee Amount. Registration Fee should not be less than " + Math.Round(calcChequeAmount, 2) + " (INR).";
                //TempData.Keep();
                //ModelState.Clear();
                return View("Create_PaymentDetails", aa);
                #endregion
            }
        }

        //// GET: Single DisplayDisplay_Project_PaymentById(Int64 ProjectRegistration_ID,Int64 ProjectPayment_IndexID)
        [HttpGet]
        public ActionResult Edit_PaymentDetails(Int64 ProjectRegistration_ID, Int64 ProjectPayment_IndexID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();
            ClsPrp_Project_Payment aa = new ClsPrp_Project_Payment();
            aa.prpongoing = sdb.Display_Project_PaymentById(ProjectRegistration_ID, ProjectPayment_IndexID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectPayment_IndexID = item.ProjectPayment_IndexID;
                aa.ProjectPayment_ID = item.ProjectPayment_ID;
                aa.ProjectPaymentRelated_ProjectRegistration_ID = item.ProjectPaymentRelated_ProjectRegistration_ID;
                aa.ProjectPayment_TitleCode = item.ProjectPayment_TitleCode;
                aa.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                aa.Registration_Fee = item.Registration_Fee;
                aa.Other_Fee = item.Other_Fee;
                aa.Payment_Mode = item.Payment_Mode;
                aa.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aa.Bank_Charges = item.Bank_Charges;
                aa.Bank_Name = item.Bank_Name;
                aa.Branch_Name = item.Branch_Name;
                aa.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aa.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                aa.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                aa.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                //aa.B_column = item.B_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            TempData["ProjectPayment_TicketName"] = string.Empty;
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_PaymentDetails", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_PaymentDetails(ClsPrp_Project_Payment smodel)
        {
            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();

                sdb.Update_Project_Payment(smodel, UserNam, UID);//, Project_id, Id, Project_Experience_ID);
                TempData["message"] = " Details updated Successfully";
                TempData["ProjectPayment_TicketName"] = string.Empty;

                return RedirectToAction("Create_PaymentDetails");
            }
            catch (Exception ex)
            {
                TempData["ProjectPayment_TicketName"] = string.Empty;
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_PaymentDetails(Int64 ProjectPaymentRelated_ProjectRegistration_ID, Int64 ProjectPayment_IndexID)
        {
            TempData["ProjectPayment_TicketName"] = string.Empty;
            try
            {
                ClsMethod_Project_Payment sdb = new ClsMethod_Project_Payment();
                if (sdb.Delete_Project_Payment(ProjectPaymentRelated_ProjectRegistration_ID, ProjectPayment_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_PaymentDetails");
            }
            catch
            {
                return View();
            }
        }

        // Fee Calculator - Project Registration
        [HttpGet]
        public ActionResult ProjectRegistrationStaticFeeCalculator(Int64 projectId, Int64 promoterId, Int64 projectzoneId)
        {
            Int64 PromoterApplicationId = 0;
            Int64 Project_id = 0;

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["Project_id"].ToString() != "0")
                {
                    Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                }
            }

            ClsPrp_Project_PaymentFeeCalculator aa = new ClsPrp_Project_PaymentFeeCalculator();
            ClsMethod_Project_FeeCalculator sdbcalc = new ClsMethod_Project_FeeCalculator();

            //parmPlotArea, parmGHArea, parmComArea, parmIndArea, parmCommonArea, parmOtherCommonArea, parmEWSArea
            Tuple<int, string, decimal, Tuple<decimal, decimal, decimal, decimal, decimal, decimal, decimal>> getCalcFee = sdbcalc.Display_LandAreaDetailsPaymentFeeCalculatorByProjectID(Project_id, PromoterApplicationId, 1);
            
            aa.RelatedProject_ID = Project_id;
            aa.RelatedPromoter_ID = PromoterApplicationId;
            aa.calcFeeCalculator_ZoneType = Convert.ToInt32(getCalcFee.Item1);
            aa.calcProjectPayment_TitleCode = 1;
            aa.calcProposedLand_TobeDeveloped_Area_Total = Convert.ToDouble(getCalcFee.Item3);
            aa.calcProposedLand_Area_ResidentialGroupHousing = Convert.ToDouble(getCalcFee.Item4.Item2);
            aa.calcProposedLand_Area_ResidentialPlotted = Convert.ToDouble(getCalcFee.Item4.Item1);
            aa.calcProposedLand_Area_Commercial = Convert.ToDouble(getCalcFee.Item4.Item3);
            aa.calcProposedLand_Area_Industrial = Convert.ToDouble(getCalcFee.Item4.Item4);
            aa.calcProposedLand_Area_CommonAmenties = Convert.ToDouble(getCalcFee.Item4.Item5);
            aa.calcProposedLand_Area_OtherCommonAmenties = Convert.ToDouble(getCalcFee.Item4.Item6);
            aa.calcProposedLand_Area_EWSdevelopment = Convert.ToDouble(getCalcFee.Item4.Item7);
            aa.setRegistration_Fee = 0;
            aa.setOther_Fee = 0;
            aa.setBank_Charges = 0;
            aa.setDD_BankersCheque_Amount = 0;
            
            //to bind Payment master
            ClsMethod_AllMaster Paymentmaster = new ClsMethod_AllMaster();
            aa.PayFeeMaster = Paymentmaster.Display_Master_PaymentType();

            return View("ProjectRegistrationStaticFeeCalculator", aa);
        }

        [HttpPost]
        public ActionResult SearchApplicationFeeCalculatorDetail(ClsPrp_Project_PaymentFeeCalculator[] order)
        {
            bool status = false;
            Int64? chkappid = null;

            decimal retApplicationFee = 0;
            decimal retWebPortalConvenienceFee = 0;
            decimal retOtherFee = 0;
            decimal retFeeAmount = 0;
            Int32 parmFeeType = 0;

            //if (ModelState.IsValid)
            //{
            if (order != null)
            {
                foreach (var item in order)
                {
                    ClsMethod_Project_FeeCalculator sdbcalc = new ClsMethod_Project_FeeCalculator();

                    //Fee Calculator Values Used for Formula
                    Int32 parmZone = 0;
                    decimal parmTArea = 0;
                    decimal parmPlotArea = 0;
                    decimal parmGHArea = 0;
                    decimal parmComArea = 0;
                    decimal parmIndArea = 0;
                    decimal parmCommonArea = 0;
                    decimal parmOtherCommonArea = 0;
                    decimal parmEWSArea = 0;

                    parmZone = Convert.ToInt32(item.calcFeeCalculator_ZoneType);
                    parmTArea = Convert.ToDecimal(item.calcProposedLand_TobeDeveloped_Area_Total);
                    parmPlotArea = Convert.ToDecimal(item.calcProposedLand_Area_ResidentialPlotted);
                    parmGHArea = Convert.ToDecimal(item.calcProposedLand_Area_ResidentialGroupHousing);
                    parmComArea = Convert.ToDecimal(item.calcProposedLand_Area_Commercial);
                    parmIndArea = Convert.ToDecimal(item.calcProposedLand_Area_Industrial);
                    parmCommonArea = Convert.ToDecimal(item.calcProposedLand_Area_CommonAmenties);
                    parmOtherCommonArea = Convert.ToDecimal(item.calcProposedLand_Area_OtherCommonAmenties);
                    parmEWSArea = Convert.ToDecimal(item.calcProposedLand_Area_EWSdevelopment);
                    parmFeeType = Convert.ToInt32(item.calcProjectPayment_TitleCode);

                    //Fee Calculator Formula
                    if (parmFeeType == 1)
                    {
                        //Registration Fee
                        Tuple<decimal, string> ProjectRegistrationFeePayment = sdbcalc.Get_ProjectRegistrationFeePayment(parmZone, parmTArea, parmPlotArea, parmGHArea, parmComArea, parmIndArea, parmCommonArea, parmOtherCommonArea, parmEWSArea);

                        retApplicationFee = ProjectRegistrationFeePayment.Item1;
                        retWebPortalConvenienceFee = 5000m;
                        retOtherFee = 0;
                        retFeeAmount = retApplicationFee + retWebPortalConvenienceFee + retOtherFee;
                    }
                    else
                    {
                        //Late Fee or Any Other Fee
                        retApplicationFee = 0;
                        retWebPortalConvenienceFee = 0;
                        retOtherFee = 0;
                        retFeeAmount = retApplicationFee + retWebPortalConvenienceFee + retOtherFee;
                    }
                    chkappid = 1;
                }
            }

            if (chkappid == null)
                status = false;
            else
                status = true;

            //}

            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    statusPaymentFee = retApplicationFee,
                    statusConvenienceFee = retWebPortalConvenienceFee,
                    statusOtherFee = retOtherFee,
                    statusFeeAmount = retFeeAmount,
                    remarks = "Success"
                }
            };
        }

        [HttpPost]
        public ActionResult GetApplicationFeeCalculatorDetail(Int64 projectpaymentId)
        {
            bool status = false;
            Int64? chkappid = null;

            Int64 RelatedProjectID = 0;
            Int64 RelatedPromoterID = 0;
            Int64 PaymentType = 0;

            if (Session["Project_id"] != null)
            {
                RelatedProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                if (Session["ApplicationId"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        RelatedPromoterID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            ClsMethod_Project_FeeCalculator sdbcalc = new ClsMethod_Project_FeeCalculator();

            decimal calcRegistrationFee = 0;
            decimal calcWebPortalFee = 0;
            decimal calcOthersFee = 0;
            decimal calcChequeAmount = 0;

            PaymentType = projectpaymentId;

            if (PaymentType == 1)
            {
                if (Convert.ToInt64(RelatedPromoterID) != 0)
                {
                    if (Convert.ToInt64(RelatedProjectID) != 0)
                    {
                        Tuple<decimal, decimal, decimal, string> getCalcFee = sdbcalc.Display_ProjectPaymentRegistrationFeeCalculatorByProjectID(RelatedProjectID, RelatedPromoterID, 1);

                        // LOGIC to check Validate Fee Structure                       
                        calcRegistrationFee = getCalcFee.Item1;
                        calcWebPortalFee = getCalcFee.Item2;
                        calcOthersFee = getCalcFee.Item3;
                        calcChequeAmount = getCalcFee.Item1 + getCalcFee.Item2 + getCalcFee.Item3;
                        chkappid = 1;
                    }
                }
            }
            else
            {
                calcRegistrationFee = 0.00m;
                calcWebPortalFee = 0.00m;
                calcOthersFee = 0.00m;
                calcChequeAmount = calcRegistrationFee + calcWebPortalFee + calcOthersFee;
                chkappid = 1;
            }

            if (chkappid == null)
                status = false;
            else
                status = true;


            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    statusPaymentFee = calcRegistrationFee,
                    statusConvenienceFee = calcWebPortalFee,
                    statusOtherFee = calcOthersFee,
                    statusFeeAmount = calcChequeAmount,
                    remarks = "Success"
                }
            };
        }
        #endregion

        /// Table 15  Detail of Project SpecialBankAccountDetailsDetails(If Any)
        #region
        /// <summary>
        ///  Detail of Project SpecialBankAccountDetailsDetails(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectSpecialBankAccountDetailsDetails(FormCollection frm, ClsPrp_Project_SpecialBankAccountDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            //ViewBag.SelectedItem = frm["SpecialBankAccountRelated_ProjectRegistration_ID"];
            TempData["SelectedItem"] = frm["SpecialBankAccountRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.SpecialBankAccountRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_SpecialBankAccountDetails()
        {
              
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ViewBag.SelectedItem = "";

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "SpecialBankAccountDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            ClsMethodProject objdis1 = new ClsMethodProject();
            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_SpecialBankAccountDetails sdb = new ClsMethod_Project_SpecialBankAccountDetails();
            ClsPrp_Project_SpecialBankAccountDetails aa = new ClsPrp_Project_SpecialBankAccountDetails();
            // Project_id = Convert.ToInt32(TempData["ProjectRegistration_ID"]);
            aa.prpongoing = sdb.Display_Project_SpecialBankAccountDetails(Project_id);
            aa.SpecialBankAccountRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();
            ClsMethodDistrictMaster objdisDM = new ClsMethodDistrictMaster();
            aa.districtMaster = objdisDM.dropdownlist_display1();


            foreach (var item in aa.prpongoing)
            {
                aa.SpecialBankAccount_IndexID = item.SpecialBankAccount_IndexID;
                aa.SpecialBankAccount_ID = item.SpecialBankAccount_ID;
                aa.SpecialBankAccountRelated_ProjectRegistration_ID = item.SpecialBankAccountRelated_ProjectRegistration_ID;

                if (item.IsDraft >= 1)
                {
                    aa.Bank_Name = item.Bank_Name;
                    aa.Branch_Name = item.Branch_Name;
                    aa.Bank_AccountNumber = item.Bank_AccountNumber;
                    aa.Bank_IFSC_Code = item.Bank_IFSC_Code;
                    aa.Bank_AddressLine1 = item.Bank_AddressLine1;
                    aa.Bank_AddressLine2 = item.Bank_AddressLine2;
                    aa.Bank_AddressStateCode = item.Bank_AddressStateCode;
                    aa.Bank_AddressDistrictCode = item.Bank_AddressDistrictCode;
                    aa.Bank_AddressPIN = item.Bank_AddressPIN;
                    aa.ImageCancelledCheque_FileName = item.ImageCancelledCheque_FileName;
                    aa.ImageCancelledCheque_FilePath = item.ImageCancelledCheque_FilePath;
                    //aa.Remarks_IfAny = item.Remarks_IfAny;
                    //aa.A_column = item.A_column;
                    //aa.B_column = item.B_column;
                }

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            ClsMethod_Project_SpecialBankAccountDetails clsfive = new ClsMethod_Project_SpecialBankAccountDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.list1 = aa.stateMaster;

            //////// Fill project list from project Registration Table

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            //TempData["submitvalue"] = "Submit";TempData.Keep();

            if (aa.prpongoing.Count >= 1)
            {
                TempData["submitvalue"] = "Update"; TempData.Keep();
            }
            else
            {
                TempData["submitvalue"] = "Submit"; TempData.Keep();
            }

            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            return View("Create_SpecialBankAccountDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_SpecialBankAccountDetails(ClsPrp_Project_SpecialBankAccountDetails smodel)
        {

            Int64 Project_id = 0;
            ClsPrp_Project_SpecialBankAccountDetails aa = new ClsPrp_Project_SpecialBankAccountDetails();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.SpecialBankAccountRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            //Save & Update
            #region

            String ext = String.Empty;
            string FilePathExt = string.Empty;
            string error = string.Empty;
            int errorstate = 0;

            ClsMethodProject objdis1 = new ClsMethodProject();


            if (TempData["submitvalue"].ToString() == "Update")
            {
                #region PhotoCertificate Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 512000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataProject";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ImageCancelledCheque_FileName))
                            {
                                pathindb = smodel.ImageCancelledCheque_FileName.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ImageCancelledCheque_FilePath))
                            {
                                fileName = smodel.ImageCancelledCheque_FilePath.ToString();
                            }
                            else
                            {
                                fileName = "SplBCCheque_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }

                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 512KB";
                            error = "Photo Size Should be less than 512KB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg";
                        error = "Photo format should be .jpg";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Photograph";
                    error = "Kindly Upload Photograph";
                    errorstate = 1;

                    //update with same photograph
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {

                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.ImageCancelledCheque_FilePath;
                            ext = smodel.ImageCancelledCheque_FileName;
                            FilePathExt = smodel.ImageCancelledCheque_FileName;
                        }

                        try
                        {
                            ClsMethod_Project_SpecialBankAccountDetails sdb = new ClsMethod_Project_SpecialBankAccountDetails();
                            sdb.Update_Project_SpecialBankAccountDetails(smodel, Photo_Address, FilePathExt);//, smodel.Application_id, smodel.Id, smodel.Promoter_OtherMemberDetails_ID);
                            TempData["message"] = "Details updated Successfully";

                            return RedirectToAction("Create_SpecialBankAccountDetails");
                        }
                        catch (Exception ex)
                        {
                            return View();
                        }
                    }
                    return RedirectToAction("Create_SpecialBankAccountDetails");
                }
                else
                {
                    return RedirectToAction("Create_SpecialBankAccountDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 512000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataProject";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "SplBCCheque_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;
                        }
                        else
                        {
                            TempData["notice"] = "Photo Size Should be less than 512KB";
                            error = "Photo Size Should be less than 512KB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Photo format should be .jpg";
                        error = "Photo format should be .jpg";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Kindly Upload Photograph";
                    error = "Kindly Upload Photograph";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {

                            if (Photo_Address == "")
                            {
                                Photo_Address = smodel.ImageCancelledCheque_FilePath;
                                ext = smodel.ImageCancelledCheque_FileName;
                                FilePathExt = smodel.ImageCancelledCheque_FileName;
                            }

                            ClsMethod_Project_SpecialBankAccountDetails sdb = new ClsMethod_Project_SpecialBankAccountDetails();

                            aa.stateMaster = objdis.State_list();
                            ViewBag.list1 = aa.stateMaster;

                            //to bind bank master
                            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
                            aa.BankMaster = Bmaster.Display_Master_BankDetails();

                            if (sdb.Add_Project_SpecialBankAccountDetails(smodel, Project_id, Photo_Address, FilePathExt))
                            {
                                TempData["message"] = " Details Added Successfully";
                                
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("Create_SpecialBankAccountDetails");
                    }
                    else
                    {
                        return RedirectToAction("Create_SpecialBankAccountDetails");
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            #endregion
        }

        // GET: Single Display
        [HttpGet]
        public ActionResult Edit_SpecialBankAccountDetails(Int64 Application_id, int Id)
        {
            //  Project_id = "110029";
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            ClsMethod_Project_SpecialBankAccountDetails sdb = new ClsMethod_Project_SpecialBankAccountDetails();
            ClsPrp_Project_SpecialBankAccountDetails aa = new ClsPrp_Project_SpecialBankAccountDetails();
            aa.prpongoing = sdb.Display_Project_SpecialBankAccountDetails(Application_id, Id);
            aa.stateMaster = objdis.State_list();

             
            ViewBag.list1 = aa.stateMaster;

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);
            //aa.districtMaster = objdis.dropdownlist_display1();

            //to bind bank master
            ClsMethod_AllMaster Bmaster = new ClsMethod_AllMaster();
            aa.BankMaster = Bmaster.Display_Master_BankDetails();

            aa.districtMaster = objdis.dropdownlist_display1();

            foreach (var item in aa.prpongoing)
            {
                aa.SpecialBankAccount_IndexID = item.SpecialBankAccount_IndexID;
                aa.SpecialBankAccount_ID = item.SpecialBankAccount_ID;
                aa.SpecialBankAccountRelated_ProjectRegistration_ID = item.SpecialBankAccountRelated_ProjectRegistration_ID;
                aa.Bank_Name = item.Bank_Name;
                aa.Branch_Name = item.Branch_Name;
                aa.Bank_AccountNumber = item.Bank_AccountNumber;
                aa.Bank_IFSC_Code = item.Bank_IFSC_Code;
                aa.Bank_AddressLine1 = item.Bank_AddressLine1;
                aa.Bank_AddressLine2 = item.Bank_AddressLine2;
                aa.Bank_AddressStateCode = item.Bank_AddressStateCode;
                aa.Bank_AddressDistrictCode = item.Bank_AddressDistrictCode;

                aa.Bank_AddressPIN = item.Bank_AddressPIN;
                aa.ImageCancelledCheque_FileName = item.ImageCancelledCheque_FileName;
                aa.ImageCancelledCheque_FilePath = item.ImageCancelledCheque_FilePath;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
           
        

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_SpecialBankAccountDetails", aa);

        }

        // POST: Update
        [HttpPost]
        public ActionResult Edit_SpecialBankAccountDetails(ClsPrp_Project_SpecialBankAccountDetails smodel)
        {
            //string Project_id = "110030";
            try
            {
                ClsMethod_Project_SpecialBankAccountDetails sdb = new ClsMethod_Project_SpecialBankAccountDetails();
                sdb.Update_Project_SpecialBankAccountDetails(smodel,"","");//, Project_id, Id, Project_Experience_ID); noT WORKING
                TempData["message"] = " Details updated Successfully";

                return RedirectToAction("Create_SpecialBankAccountDetails");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_SpecialBankAccountDetails(Int64 ProjectSpecialBankAccountDetailsDetailsRelated_ProjectRegistration_ID, Int64 ProjectSpecialBankAccountDetailsDetails_IndexID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_SpecialBankAccountDetails sdb = new ClsMethod_Project_SpecialBankAccountDetails();
                if (sdb.Delete_SpecialBankAccountDetails(ProjectSpecialBankAccountDetailsDetailsRelated_ProjectRegistration_ID, ProjectSpecialBankAccountDetailsDetails_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_SpecialBankAccountDetails");
            }
            catch
            {
                return View();
            }
        }

        //Check Single Entry Bank A/C number
        public JsonResult CheckBankAccountNumber(string AccountNumber)
        {
            ClsMethod_Project_SpecialBankAccountDetails CheckAccNo = new ClsMethod_Project_SpecialBankAccountDetails();
            bool BAccNo = CheckAccNo.Check_SpecialBankAccountNumber(AccountNumber);

            return Json(BAccNo);
        }

        #endregion

        public JsonResult GetDistrictByStateId(string stateid)
        {
            int Id = 0;
            if (stateid != "")
                Id = Convert.ToInt32(stateid);


            UserDetails aa = new UserDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            var states = objdis.dropdownlist_display1(Id);

            return Json(states);
        }

        public JsonResult GetSubdivisionByDistId(string Distid)
        {
            int Id = 0;
            if (Distid != "")
                Id = Convert.ToInt32(Distid);


            UserDetails aa = new UserDetails();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            var Subdiv = objdis.dropdownlist_diplaySubdiv(Id);

            return Json(Subdiv);
        }

        /// Table 16 Detail of Project External Facilities(If Any)
        #region
        /// <summary>
        ///  Detail of Project Facilities(If Any)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectEXFacilities(FormCollection frm, ClsPrp_Project_ExternalInfrastructure_Facilities smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
            TempData["SelectedItem"] = frm["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_EXFacilities()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();
            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "EXFacilities"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            ClsMethod_Project_ExternalInfrastructure_Facilities sdb = new ClsMethod_Project_ExternalInfrastructure_Facilities();
            ClsPrp_Project_ExternalInfrastructure_Facilities aa = new ClsPrp_Project_ExternalInfrastructure_Facilities();
            aa.prpongoing = sdb.Display_Project_ExternalInfrastructure_Facilities(Project_id);
            aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_ExternalInfrastructure_Facilities clsfive = new ClsMethod_Project_ExternalInfrastructure_Facilities();

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }
            //////// Fill project list from project Registration Table

            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;
            TempData["CurrentYears"] = null;ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_EXFacilities", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_EXFacilities(ClsPrp_Project_ExternalInfrastructure_Facilities smodel)
        {
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            TempData["CurrentYears"] = smodel.B_column;

            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ExternalInfrastructure_Facilities sdb = new ClsMethod_Project_ExternalInfrastructure_Facilities();
                    Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {
                        if (sdb.Add_Project_ExternalInfrastructure_Facilities(smodel, Project_id))
                        {
                            TempData["message"] = " Details Added Successfully";
                            // ViewBag.Message = " Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        TempData["message"] = "Record Cannot be added";
                    }
                }
                return RedirectToAction("Create_EXFacilities");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Single Display
        [HttpGet]
        public ActionResult Edit_EXFacilities(Int64 Application_id, int Id)
        {
            //  Project_id = "110029";
            ClsMethod_Project_ExternalInfrastructure_Facilities sdb = new ClsMethod_Project_ExternalInfrastructure_Facilities();
            ClsPrp_Project_ExternalInfrastructure_Facilities aa = new ClsPrp_Project_ExternalInfrastructure_Facilities();
            aa.prpongoing = sdb.Display_Project_ExternalInfrastructure_Facilities(Application_id, Id);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectInfrastructureFacilities_IndexID = item.ProjectInfrastructureFacilities_IndexID;
                aa.ProjectInfrastructureFacilities_ID = item.ProjectInfrastructureFacilities_ID;
                aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = item.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
                aa.InternalInfrastructureFacilities_Name = item.InternalInfrastructureFacilities_Name;
                aa.InternalInfrastructureFacilities_Type = item.InternalInfrastructureFacilities_Type;
                aa.ExternalAgency_LocalAuthority_Name = item.ExternalAgency_LocalAuthority_Name;
                aa.Is_InternalInfrastructureFacilitiesApplicable = item.Is_InternalInfrastructureFacilitiesApplicable;
                aa.WorkProgress_Percentage = item.WorkProgress_Percentage;
                aa.InternalInfrastructureFacilities_Details = item.InternalInfrastructureFacilities_Details;

                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                //aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }
            ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_EXFacilities", aa);

        }

        //// POST: Update
        [HttpPost]
        public ActionResult Edit_EXFacilities(ClsPrp_Project_ExternalInfrastructure_Facilities smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ExternalInfrastructure_Facilities sdb = new ClsMethod_Project_ExternalInfrastructure_Facilities();
                    sdb.Update_Project_ExternalInfrastructure_Facilities(smodel);
                    TempData["message"] = "Details updated Successfully";
                }
                return RedirectToAction("Create_EXFacilities");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete 
        public ActionResult Delete_EXFacilities(Int64 ProjectInfrastructure_ProjectRegistration_ID, Int64 ProjectInfrastructureFacilities_IndexID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_ExternalInfrastructure_Facilities sdb = new ClsMethod_Project_ExternalInfrastructure_Facilities();
                if (sdb.Delete_ExternalInfrastructure_Facilities(ProjectInfrastructure_ProjectRegistration_ID, ProjectInfrastructureFacilities_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";
                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_EXFacilities");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        public JsonResult GetReraExistingNumber(string stateid)
        {
            //int Id = 0;
            //if (stateid != "")
            //    Id = Convert.ToInt32(stateid);




            ClsMethod_Project_ExistingRera objdis = new ClsMethod_Project_ExistingRera();


            var states = objdis.Fill_Existing_detail(stateid);

            return Json(states);
        }

        public JsonResult GetBuildingTowerBlockByProjectId(string projectid)
        {
            Int64 Id = 0;
            if (projectid != "")
                Id = Convert.ToInt64(projectid);
            
            ClsMethod_master_BuildingTowerName BTMaster = new ClsMethod_master_BuildingTowerName();         
            var buildingblocktowerlist = BTMaster.Display_BuildingTowerBlock_Construction(Id);

            return Json(buildingblocktowerlist);
        }

        /// Table 17 Project Photographs Details
        #region
        /// <summary>
        ///  Project Photographs Details
        /// <summary>
        ///  Project Photographs Details
        /// </summary>
        /// <returns></returns>
        #region Project_Dropdown
        // Get Project detail on basis of App ID
        [HttpPost]
        public ActionResult DropdownlistProject_ProjectPhotographsDetails(FormCollection frm, ClsPrp_Project_ConstructionStatusPhotographs smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectPhotographsRelated_Project_ID;
            TempData["SelectedItem"] = frm["ProjectPhotographsRelated_Project_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }

        //public ActionResult GetProjectPhotographsDetails()
        //{
        //    Int64 ProjectReg_ID = 10001;

        //    ClsMethodProject objdis = new ClsMethodProject();
        //    //aa.stateMaster = objdis.State_list();

        //    // Class2 aa = new Class2();
        //    ClsPrp_Project_ConstructionStatusPhotographs aa = new ClsPrp_Project_ConstructionStatusPhotographs();

        //    // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
        //    Int64 PromoterApplicationId = 0;
        //    if (Session["ApplicationId"] != null)
        //    {
        //        if (Session["ApplicationId"].ToString() != "0")
        //        {
        //            PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
        //        }
        //    }

        //    Int64 Project_id = 0;
        //    if (Session["Project_id"] != null)
        //    {
        //        Project_id = Convert.ToInt64(Session["Project_id"].ToString());
        //        aa.ProjectPhotographsRelated_Project_ID = Project_id;
        //    }
        //    //else
        //    //{
        //    //    return RedirectToAction("SessionExpire", "Account");
        //    //}



        //    aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
        //    //TempData["list"] = aa.ProjectMaster;
        //    //TempData.Keep();

        //    var fullUrl = this.Request.UrlReferrer.ToString();
        //    string url = fullUrl;
        //    var request = new HttpRequest(null, url, null);
        //    var response = new HttpResponse(new StringWriter());
        //    var httpContext = new HttpContext(request, response);
        //    var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
        //    var values = routeData.Values;
        //    string controllerName = values["controller"].ToString();
        //    string viewname = values["action"].ToString();
        //    string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
        //    if ((part != "PhotographDetails"))
        //        Session.Remove("Project_id");
        //    else
        //        ProjectReg_ID = Convert.ToInt64(Session["Project_id"].ToString());


        //    ClsMethod_master_BuildingTowerName BTMaster = new ClsMethod_master_BuildingTowerName();
        //    aa.MasterBuilding = BTMaster.Display_BuildingTowerBlock_Construction(ProjectReg_ID);

        //    ViewBag.list = aa.ProjectMaster;

        //    ViewBag.Years = GetYears();

        //    //return Json(aa, JsonRequestBehavior.AllowGet);

        //    //return View();
        //    return View("Create_PhotographDetails", aa);
        //}
        
        #endregion Project_Dropdown
        // GET: Empty Create + Display
        public ActionResult Create_PhotographDetails()
        {
            Int64 Project_id = 0;

            //Int64 Application_ID = 10001;
            ViewBag.SelectedItem = "";
            ClsMethodProject objdis = new ClsMethodProject();
            //aa.stateMaster = objdis.State_list();

            // Class2 aa = new Class2();
            ClsPrp_Project_ConstructionStatusPhotographs ss = new ClsPrp_Project_ConstructionStatusPhotographs();

            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //ss.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = ss.ProjectMaster;
            // Int64 Project_id = 0;
            Session["url"] = Request.UrlReferrer;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "PhotographDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_ConstructionStatusPhotographs sdb = new ClsMethod_Project_ConstructionStatusPhotographs();
            ClsPrp_Project_ConstructionStatusPhotographs aa = new ClsPrp_Project_ConstructionStatusPhotographs();
            aa.prpongoing = sdb.Display_Project_ConstructionStatusPhotographs(Project_id);
            aa.ProjectPhotographsRelated_Project_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_ConstructionStatusPhotographs clsfive = new ClsMethod_Project_ConstructionStatusPhotographs();

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            //ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_PhotographDetails", aa);
        }        

        // GET: Delete 
        public ActionResult Delete_PhotographDetails(Int64? inProjectPhotographs_IndexID, Int64? inProjectPhotographs_ID, Int64? inProject_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_ConstructionStatusPhotographs sdb = new ClsMethod_Project_ConstructionStatusPhotographs();
                if (sdb.Delete_Project_ConstructionStatusPhotographs(inProject_ID, inProjectPhotographs_IndexID, inProjectPhotographs_ID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_PhotographDetails");
            }
            catch
            {
                return RedirectToAction("Create_PhotographDetails");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FormPhotographUpload(HttpPostedFileBase uploadedFile, ClsPrp_Project_ConstructionStatusPhotographs smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    //Clsprp_Master_Promoter_Documents clsprp = new Clsprp_Master_Promoter_Documents();
                    //ClsMethod_Master_Promoter_Documents objdoc = new ClsMethod_Master_Promoter_Documents();
                    ClsPrp_Project_ConstructionStatusPhotographs clsprpPrmDoc = new ClsPrp_Project_ConstructionStatusPhotographs();
                    ClsMethod_Project_ConstructionStatusPhotographs objProjectPhoto = new ClsMethod_Project_ConstructionStatusPhotographs();

                    //Int32 IndexId = smodel.PromoterDoc_InfoCode;
                    Int64 PromoterId = 0;
                    Int64 Application_id = 0;
                    Int64 ProjectRegID = 0;
                    Int32 ProjectQYear = 0;
                    string ProjectQname = string.Empty;
                    Int32 ConstructionCode = 0;
                    Int64 BlockCode = 0;

                    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                    {
                        if (Session["ApplicationId"].ToString() != "0")
                        {
                            Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        }
                    }
                    PromoterId = Application_id;
                    ProjectRegID = smodel.ProjectPhotographsRelated_Project_ID;
                    ProjectQYear = Convert.ToInt32(smodel.B_column);
                    ProjectQname = Convert.ToString(smodel.A_column);
                    ConstructionCode = Convert.ToInt32(smodel.TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code);
                    BlockCode = Convert.ToInt64(smodel.BuildingTowerBlock_InfoCode);

                    Tuple<Int64, Int64> tupleSumCntFile = objProjectPhoto.Display_Project_ConstructionStatusPhotographs_ByDocCodeInfoPromoterID(PromoterId, ProjectRegID, ProjectQYear, ProjectQname, ConstructionCode, BlockCode);

                    #region Declare Variables
                    var path = "";
                    var pathindb = "";
                    var savefileName = "";
                    string extensionPhotoIdentityDocument = string.Empty;
                    int byteCountPhotoIdentityDocument = 0;
                    Int32 masterGetPhotoIdentityDocument = 0;
                    Int32 extensionPutPhotoIdentityDocument = 0;
                    //Int32 masterPutPhotoIdentityDocument = 0;
                    string masterProjectPhoto_SetFilePath = "readwriteProjectPhoto";
                    Int32 masterSetUploadFileLimitCount = 0;
                    Int64 masterSetUploadFileLimitSize = 0;
                    Int64 masterSetMaxUploadFileLimitSize = 0;
                    string masterSetFileName = string.Empty;
                    bool IsValidFileType = false;
                    #endregion

                    //Bad Request - No Doc
                    if (Request.Files.Count > 0)
                    {
                        TempData["CurrentYears"] = smodel.B_column;
                        Session["CurrentYears"] = smodel.B_column;
                        Session["PresentQuater"] = smodel.A_column;

                        Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                        if (check_IsdraftValue == 0)
                        {
                            #region
                            var PhotoIdentityDocument = Request.Files[0];

                            //Bad Request - No Doc OR No Size
                            if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                            {
                                #region SaveFile Path Creation

                                pathindb = masterProjectPhoto_SetFilePath + "\\" + Convert.ToString(ProjectRegID) + "\\";
                                path = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                #endregion

                                #region Master File Type Check
                                //Upload File Type
                                extensionPhotoIdentityDocument = Path.GetExtension(PhotoIdentityDocument.FileName);
                                switch (extensionPhotoIdentityDocument)
                                {
                                    case ".JPEG":
                                    case ".jpeg":
                                    case ".JPG":
                                    case ".jpg":
                                    case ".PNG":
                                    case ".png":
                                        {
                                            //Image Type
                                            extensionPutPhotoIdentityDocument = 102;
                                            break;
                                        }
                                    case ".PDF":
                                    case ".pdf":
                                        {
                                            //PDF Type
                                            extensionPutPhotoIdentityDocument = 103;
                                            break;
                                        }
                                }


                                //Check File Type and Set Master File Limit
                                masterGetPhotoIdentityDocument = smodel.TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code;
                                if (masterGetPhotoIdentityDocument == 1)
                                {
                                    masterSetUploadFileLimitCount = 2;
                                    masterSetUploadFileLimitSize = 10000000;
                                    masterSetMaxUploadFileLimitSize = 100000000;
                                    masterSetFileName = "AdvProspectus";
                                    if (extensionPutPhotoIdentityDocument == 102 || extensionPutPhotoIdentityDocument == 103)
                                    {
                                        IsValidFileType = true;
                                    }
                                }
                                else if (masterGetPhotoIdentityDocument == 2)
                                {
                                    masterSetUploadFileLimitCount = 10;
                                    masterSetUploadFileLimitSize = 10000000;
                                    masterSetMaxUploadFileLimitSize = 100000000;
                                    masterSetFileName = "Construction";
                                    if (extensionPutPhotoIdentityDocument == 102)
                                    {
                                        IsValidFileType = true;
                                    }
                                }
                                else if (masterGetPhotoIdentityDocument == 3)
                                {
                                    masterSetUploadFileLimitCount = 5;
                                    masterSetUploadFileLimitSize = 10000000;
                                    masterSetMaxUploadFileLimitSize = 100000000;
                                    masterSetFileName = "CommonArea";
                                    if (extensionPutPhotoIdentityDocument == 102)
                                    {
                                        IsValidFileType = true;
                                    }
                                }

                                #endregion

                                //Check Number of Files Uploaded
                                if (tupleSumCntFile.Item2 < masterSetUploadFileLimitCount)
                                {
                                    if (IsValidFileType)
                                    {
                                        if (tupleSumCntFile.Item1 <= masterSetMaxUploadFileLimitSize)
                                        {
                                            byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                            if (byteCountPhotoIdentityDocument <= masterSetUploadFileLimitSize)
                                            {
                                                savefileName = RegexRemove(SaveFileDatePrefix() + masterSetFileName + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                                var pathsavefile = Path.Combine(path, savefileName);
                                                PhotoIdentityDocument.SaveAs(pathsavefile);

                                                var pathsavedb = Path.Combine(pathindb, savefileName);

                                                Int64 inPromoter_ID = PromoterId;
                                                string inPromoterDoc_FilePath = pathsavedb;
                                                string inPromoterDoc_FileName = savefileName;
                                                string inPromoterDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                                string inPromoterDoc_FileFormat = extensionPhotoIdentityDocument;
                                                Int32 inPromoterDoc_IsGroup = Convert.ToInt32(1);

                                                bool varRet = SaveProjectPhotographs(smodel, inPromoter_ID, inPromoterDoc_FilePath, inPromoterDoc_FileName, inPromoterDoc_FileSize, inPromoterDoc_FileFormat, inPromoterDoc_IsGroup);

                                                if (varRet != false)
                                                {
                                                    return Json(new
                                                    {
                                                        //Data = "Complete",
                                                        statusCode = 101,
                                                        status = "Complete",
                                                        remarks = "Successfully uplaoded"
                                                    }, JsonRequestBehavior.AllowGet);
                                                }
                                                else
                                                {
                                                    return Json(new
                                                    {
                                                        //Data = "Bad Request! Upload Failed",
                                                        statusCode = 105,
                                                        status = "Bad Request! Upload Failed",
                                                        remarks = "Not Saved! Upload Failed "
                                                    }, JsonRequestBehavior.AllowGet);
                                                }
                                            }
                                            else
                                            {
                                                decimal varSetFileSize = 0;
                                                string varOutSetFileSize = string.Empty;
                                                varSetFileSize = Convert.ToInt32(masterSetUploadFileLimitSize);

                                                if (varSetFileSize > 1048576)
                                                {
                                                    varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1048576) / 100 + " MB";
                                                }
                                                else if (varSetFileSize > 1024)
                                                {
                                                    varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1024) / 100 + " KB";
                                                }
                                                else
                                                {
                                                    varOutSetFileSize = varSetFileSize + " Bytes";
                                                }

                                                return Json(new
                                                {
                                                    //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                    statusCode = 103,
                                                    status = "File size should be less than " + varOutSetFileSize,
                                                    remarks = uploadedFile.FileName
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                        }
                                        else
                                        {
                                            decimal varSetGroupFileSize = 0;
                                            string varOutSetGroupFileSize = string.Empty;

                                            varSetGroupFileSize = Convert.ToInt64(tupleSumCntFile.Item1);

                                            if (varSetGroupFileSize > 1048576)
                                            {
                                                varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1048576) / 100 + " MB";
                                            }
                                            else if (varSetGroupFileSize > 1024)
                                            {
                                                varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1024) / 100 + " KB";
                                            }
                                            else
                                            {
                                                varOutSetGroupFileSize = varSetGroupFileSize + " Bytes";
                                            }


                                            return Json(new
                                            {
                                                //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                statusCode = 107,
                                                status = "Maximum number of uploaded files size limit reached. (Max Size " + Convert.ToString(varOutSetGroupFileSize) + ".)",
                                                remarks = uploadedFile.FileName
                                            }, JsonRequestBehavior.AllowGet);
                                        }
                                    }
                                    else
                                    {
                                        return Json(new
                                        {
                                            //Data = "Format not match, File Name: " + uploadedFile.FileName,
                                            statusCode = 104,
                                            status = "File format not matched.",
                                            remarks = uploadedFile.FileName
                                        }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                else
                                {
                                    return Json(new
                                    {
                                        //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
                                        statusCode = 106,
                                        status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(masterSetUploadFileLimitCount) + " files.)",
                                        remarks = uploadedFile.FileName
                                    }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(new
                                {
                                    //Data = "Bad Request! Upload Failed",
                                    statusCode = 102,
                                    status = "Bad Request! Upload Failed",
                                    remarks = string.Empty
                                }, JsonRequestBehavior.AllowGet);
                            }
                            #endregion
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Bad Request! Upload Failed",
                                statusCode = 102,
                                status = "Invalid uploads! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            //Data = "Bad Request! Upload Failed",
                            statusCode = 102,
                            status = "Bad Request! Upload Failed",
                            remarks = string.Empty
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        //Data = "Bad Request! Upload Failed",
                        statusCode = 102,
                        status = "Mandatory field(s) required! Upload Failed",
                        remarks = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    //Data = "Bad Request! Upload Failed",
                    statusCode = 102,
                    status = "Bad Request! Upload Failed",
                    remarks = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
        }
        
        private bool SaveProjectPhotographs(ClsPrp_Project_ConstructionStatusPhotographs smodel, Int64 z_Promoter_ID, String z_PromoterDoc_FilePath, String z_PromoterDoc_FileName, String z_PromoterDoc_FileSize, String z_PromoterDoc_FileFormat, Int32 z_PromoterDoc_IsGroup)
        {
            Int64 Promoter_ID = 0;
            Promoter_ID = z_Promoter_ID;
            string PromoterDoc_FilePath = String.IsNullOrEmpty(z_PromoterDoc_FilePath) ? string.Empty : z_PromoterDoc_FilePath;
            string PromoterDoc_FileName = String.IsNullOrEmpty(z_PromoterDoc_FileName) ? string.Empty : z_PromoterDoc_FileName;
            string PromoterDoc_FileSize = String.IsNullOrEmpty(z_PromoterDoc_FileSize) ? string.Empty : z_PromoterDoc_FileSize;
            string PromoterDoc_FileFormat = String.IsNullOrEmpty(z_PromoterDoc_FileFormat) ? string.Empty : z_PromoterDoc_FileFormat;
            Int32 PromoterDoc_IsGroup = z_PromoterDoc_IsGroup;
            bool varRET = false;

            ////if (Session["Project_id"] != null)
            ////{
            ////    Promoter_ID = Convert.ToInt64(Session["Project_id"].ToString());
            ////    smodel.Promoter_ID = Promoter_ID;
            ////}
            ////else
            ////{
            ////    RedirectToAction("IndexPromoter", "Home");
            ////}

            TempData["CurrentYears"] = smodel.B_column;
            Session["CurrentYears"] = smodel.B_column;
            Session["PresentQuater"] = smodel.A_column;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ConstructionStatusPhotographs savedb = new ClsMethod_Project_ConstructionStatusPhotographs();
                    Int32 check_IsdraftValue = Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    if (check_IsdraftValue == 0)
                    {
                        if (savedb.Add_Project_ConstructionStatusPhotographs(smodel, Promoter_ID, PromoterDoc_FilePath, PromoterDoc_FileName, PromoterDoc_FileSize, PromoterDoc_FileFormat, PromoterDoc_IsGroup))
                        {
                            varRET = true;
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        TempData["message"] = "Record Cannot be added";
                    }
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }

        private string RegexRemove(string varSTR)
        {
            string oSTR = string.Empty;
            string pattern = "\\s+";
            string replacement = "_";
            Regex rgx = new Regex(pattern);
            oSTR = rgx.Replace(varSTR, replacement);
            return oSTR;
        }

        private string SaveFileDatePrefix()
        {
            string varSetDate = string.Empty;
            var fileyear = DateTime.Now.Year;
            var filemonth = string.Empty;
            var fileday = string.Empty;
            if (DateTime.Now.Month < 10)
                filemonth = "0" + Convert.ToString(DateTime.Now.Month);
            else
                filemonth = Convert.ToString(DateTime.Now.Month);
            if (DateTime.Now.Day < 10)
                fileday = "0" + Convert.ToString(DateTime.Now.Day);
            else
                fileday = Convert.ToString(DateTime.Now.Day);
            varSetDate = fileyear.ToString() + filemonth + fileday;
            return varSetDate;
        }

        #endregion

        /// Table 18  Detail of Project Documents
        #region
        /// <summary>
        ///  Detail of Project Documents
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropdownlistProjectDocument(FormCollection frm, Clsprp_Project_Documents smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.Project_ID;

            TempData["SelectedItem"] = frm["Project_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_ProjectDocument()
        {
            Int64 Project_id = 0;
            Int64 Application_ID = 0;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            }
            //else
            //{
            //    return RedirectToAction("SessionExpire", "Account");
            //}

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Master_Project_Documents objdoc = new ClsMethod_Master_Project_Documents();
            Clsprp_Master_Project_Documents clsprp = new Clsprp_Master_Project_Documents();
            ClsMethod_Project_Documents sdb = new ClsMethod_Project_Documents();
            Clsprp_Project_Documents aa = new Clsprp_Project_Documents();
            //////List<Clsprp_Project_Documents> clsprpPrmProjectDocList = new List<Clsprp_Project_Documents>();
            aa.ProjectDoc_IssueDate = DateTime.Now;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProjectDocument"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            //////// Fill project list from project Registration Table

            aa.prpongoing = sdb.Display_Project_Documents_ByProjectId(Project_id);
            aa.Project_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();            

            aa.ProjectDocs = aa.prpongoing;
            
            aa.MasterDocs = objdoc.Display_Master_Project_DocumentsByProjectIDandPromoterID(Application_ID, Project_id);

            foreach (var item in aa.MasterDocs)
            {
                clsprp.ProjectDocMaster_IndexID = item.ProjectDocMaster_IndexID;
                clsprp.ProjectDocMaster_InfoCode = item.ProjectDocMaster_InfoCode;
                clsprp.ProjectDocMaster_InfoName = item.ProjectDocMaster_InfoName;
                clsprp.ProjectDocMaster_RelatedSectionName = item.ProjectDocMaster_RelatedSectionName;
                clsprp.ProjectDoc_SetFileSize = item.ProjectDoc_SetFileSize;
                clsprp.ProjectDoc_SetFileFormat = item.ProjectDoc_SetFileFormat;
                clsprp.ProjectDoc_SetFilePath = item.ProjectDoc_SetFilePath;
                clsprp.ProjectDoc_ValidCode = item.ProjectDoc_ValidCode;
                clsprp.ProjectDoc_ValidSubCode = item.ProjectDoc_ValidSubCode;
                clsprp.ProjectDoc_ValidTinySubCode = item.ProjectDoc_ValidTinySubCode;
                clsprp.IsGroup = item.IsGroup;
                clsprp.IsMandatory = item.IsMandatory;
                clsprp.A_column = item.A_column;
                clsprp.B_column = item.B_column;
                clsprp.C_column = item.C_column;
                clsprp.IsActive = item.IsActive;
                clsprp.CreatedBy = item.CreatedBy;
                clsprp.CreatedOn = item.CreatedOn;
                clsprp.ModifyBy = item.ModifyBy;
                clsprp.ModifyOn = item.ModifyOn;
            }


            //aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Project_id);
            //ViewBag.list = aa.ProjectMaster;

            //TempData["submitvalue"] = "Submit";
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            return View("Create_ProjectDocument", aa);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ProjectDocumentFormUpload(HttpPostedFileBase uploadedFile, Clsprp_Project_Documents smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Project_Documents clsprp = new Clsprp_Master_Project_Documents();
                    ClsMethod_Master_Project_Documents objdoc = new ClsMethod_Master_Project_Documents();
                    Clsprp_Project_Documents clsprpPrmDoc = new Clsprp_Project_Documents();
                    ClsMethod_Project_Documents objPromoterDoc = new ClsMethod_Project_Documents();

                    Int32 IndexId = smodel.ProjectDoc_InfoCode;
                    Int64 PromoterId = 0;
                    Int64 Application_id = 0;
                    Int64 ProjectId = 0;
                    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                    {
                        if (Session["ApplicationId"].ToString() != "0")
                        {
                            Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        }
                    }
                    PromoterId = Application_id;
                    ProjectId = Convert.ToInt64(Session["Project_id"].ToString());

                    #region Read Master Data By Document Type
                    clsprpPrmDoc.MasterDocs = objdoc.Display_Master_Project_DocumentsByProjectIDandPromoterID(PromoterId, ProjectId);

                    Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_Promoter_Documents_ByDocCodeInfoPromoterID(PromoterId, IndexId));

                    foreach (var item in clsprpPrmDoc.MasterDocs)
                    {
                        if (item.ProjectDocMaster_InfoCode == IndexId)
                        {
                            clsprp.ProjectDocMaster_IndexID = item.ProjectDocMaster_IndexID;
                            clsprp.ProjectDocMaster_InfoCode = item.ProjectDocMaster_InfoCode;
                            clsprp.ProjectDocMaster_InfoName = item.ProjectDocMaster_InfoName;
                            clsprp.ProjectDoc_SetFileSize = item.ProjectDoc_SetFileSize;
                            clsprp.ProjectDoc_SetFileFormat = item.ProjectDoc_SetFileFormat;
                            clsprp.ProjectDoc_SetFilePath = item.ProjectDoc_SetFilePath;
                            clsprp.ProjectDoc_ValidCode = item.ProjectDoc_ValidCode;
                            clsprp.ProjectDoc_ValidSubCode = item.ProjectDoc_ValidSubCode;
                            clsprp.ProjectDoc_ValidTinySubCode = item.ProjectDoc_ValidTinySubCode;
                            clsprp.IsGroup = item.IsGroup;
                            clsprp.IsMandatory = item.IsMandatory;
                            clsprp.A_column = item.A_column;
                            clsprp.B_column = item.B_column;
                            clsprp.C_column = item.C_column;
                            clsprp.IsActive = item.IsActive;
                            clsprp.CreatedBy = item.CreatedBy;
                            clsprp.CreatedOn = item.CreatedOn;
                            clsprp.ModifyBy = item.ModifyBy;
                            clsprp.ModifyOn = item.ModifyOn;
                        }
                    }
                    #endregion

                    #region Declare Variables
                    var path = "";
                    var pathindb = "";
                    var savefileName = "";
                    string extensionPhotoIdentityDocument = string.Empty;
                    int byteCountPhotoIdentityDocument = 0;
                    string masterGetPhotoIdentityDocument = string.Empty;
                    Int32 extensionPutPhotoIdentityDocument = 0;
                    Int32 masterPutPhotoIdentityDocument = 0;
                    string masterPromoterDoc_SetFilePath = "readwriteProjectDoc";
                    bool IsValidFileType = false;
                    #endregion

                    //Bad Request - No Doc
                    if (Request.Files.Count > 0)
                    {
                        var PhotoIdentityDocument = Request.Files[0];

                        //Bad Request - No Doc OR No Size
                        if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                        {
                            #region SaveFile Path Creation
                            if (clsprp.ProjectDoc_SetFilePath.ToString() != string.Empty || clsprp.ProjectDoc_SetFilePath.ToString() != null)
                            {
                                masterPromoterDoc_SetFilePath = clsprp.ProjectDoc_SetFilePath.ToString();
                            }
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(ProjectId) + "\\";
                            path = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            #endregion

                            #region Master File Type Check
                            //Upload File Type
                            extensionPhotoIdentityDocument = Path.GetExtension(PhotoIdentityDocument.FileName);
                            switch (extensionPhotoIdentityDocument)
                            {
                                case ".JPEG":
                                case ".jpeg":
                                case ".JPG":
                                case ".jpg":
                                case ".PNG":
                                case ".png":
                                    {
                                        //Image Type
                                        extensionPutPhotoIdentityDocument = 102;
                                        break;
                                    }
                                case ".PDF":
                                case ".pdf":
                                    {
                                        //PDF Type
                                        extensionPutPhotoIdentityDocument = 103;
                                        break;
                                    }
                            }

                            //Master File Type
                            masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ProjectDoc_SetFileFormat);
                            switch (masterGetPhotoIdentityDocument)
                            {
                                case "JPEG/JPG/PDF":
                                    {
                                        //Both Image and PDF Type
                                        masterPutPhotoIdentityDocument = 101;
                                        break;
                                    }
                                case "JPEG/JPG":
                                case "JPEG":
                                case "JPG":
                                    {
                                        //Image Type
                                        masterPutPhotoIdentityDocument = 102;
                                        break;
                                    }
                                case "PDF":
                                    {
                                        //PDF Type
                                        masterPutPhotoIdentityDocument = 103;
                                        break;
                                    }
                            }
                            if (masterPutPhotoIdentityDocument == 101)
                            {
                                if (extensionPutPhotoIdentityDocument == 102 || extensionPutPhotoIdentityDocument == 103)
                                {
                                    IsValidFileType = true;
                                }
                            }
                            else
                            {
                                if (extensionPutPhotoIdentityDocument == masterPutPhotoIdentityDocument)
                                {
                                    IsValidFileType = true;
                                }
                            }
                            #endregion

                            //Check Number of Files Uploaded
                            if (tupleSumCntFile.Item2 < Convert.ToInt32(clsprp.IsGroup))
                            {
                                if (IsValidFileType)
                                {
                                    if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ProjectDoc_SetFileSize))
                                    {
                                        byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                        if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ProjectDoc_SetFileSize))
                                        {
                                            byte[] fileBytes;
                                            using (var memoryStream = new MemoryStream())
                                            {
                                                PhotoIdentityDocument.InputStream.Position = 0;
                                                PhotoIdentityDocument.InputStream.CopyTo(memoryStream);
                                                fileBytes = memoryStream.ToArray();
                                            }

                                            if (extensionPutPhotoIdentityDocument == 103)
                                            {
                                               // string expectedType = BuildExpectedTypeForAi(clsprp);
                                                //var aiResult = await CallProjectDocumentAiClassifier(fileBytes, PhotoIdentityDocument.FileName, expectedType);

                                                //if (aiResult == null || string.IsNullOrWhiteSpace(aiResult.documentType))
                                                //{
                                                //    return Json(new
                                                //    {
                                                //        statusCode = 108,
                                                //        status = "AI validation failed. Please try again.",
                                                //        remarks = uploadedFile.FileName
                                                //    }, JsonRequestBehavior.AllowGet);
                                                //}

                                                //string detectedType = NormalizeDocTypeForAi(aiResult.documentType);
                                                //string detectedStatus = (aiResult.status ?? string.Empty).Trim().ToUpperInvariant();

                                                //if (detectedStatus != "ACCEPTED" || detectedType != expectedType)
                                                //{
                                                //    return Json(new
                                                //    {
                                                //        statusCode = 109,
                                                //        status = "Wrong or low-confidence document detected by AI.",
                                                //        remarks = "Expected: " + expectedType + ", Detected: " + detectedType + ", Status: " + (string.IsNullOrWhiteSpace(aiResult.status) ? "UNKNOWN" : aiResult.status)
                                                //    }, JsonRequestBehavior.AllowGet);
                                                //}
                                            }

                                            savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ProjectDocMaster_InfoName) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                            var pathsavefile = Path.Combine(path, savefileName);
                                            PhotoIdentityDocument.SaveAs(pathsavefile);

                                            var pathsavedb = Path.Combine(pathindb, savefileName);

                                            Int64 inPromoter_ID = PromoterId;
                                            string inProjectDoc_FilePath = pathsavedb;
                                            string inProjectDoc_FileName = savefileName;
                                            string inProjectDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inProjectDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inProjectDoc_IsGroup = Convert.ToInt32(clsprp.IsMandatory);

                                            bool varRet = SaveProjectLandApprovalDocuments(smodel, inPromoter_ID, inProjectDoc_FilePath, inProjectDoc_FileName, inProjectDoc_FileSize, inProjectDoc_FileFormat, inProjectDoc_IsGroup, ProjectId);

                                            if (varRet != false)
                                            {
                                                return Json(new
                                                {
                                                    //Data = "Complete",
                                                    statusCode = 101,
                                                    status = "Complete",
                                                    remarks = "Successfully uplaoded"
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                            else
                                            {
                                                return Json(new
                                                {
                                                    //Data = "Bad Request! Upload Failed",
                                                    statusCode = 105,
                                                    status = "Bad Request! Upload Failed",
                                                    remarks = "Not Saved! Upload Failed "
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                        }
                                        else
                                        {
                                            decimal varSetFileSize = 0;
                                            string varOutSetFileSize = string.Empty;
                                            varSetFileSize = Convert.ToInt32(clsprp.ProjectDoc_SetFileSize);

                                            if (varSetFileSize > 1048576)
                                            {
                                                varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1048576) / 100 + " MB";
                                            }
                                            else if (varSetFileSize > 1024)
                                            {
                                                varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1024) / 100 + " KB";
                                            }
                                            else
                                            {
                                                varOutSetFileSize = varSetFileSize + " Bytes";
                                            }

                                            return Json(new
                                            {
                                                //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                statusCode = 103,
                                                status = "File size should be less than " + varOutSetFileSize,
                                                remarks = uploadedFile.FileName
                                            }, JsonRequestBehavior.AllowGet);
                                        }
                                    }
                                    else
                                    {
                                        decimal varSetGroupFileSize = 0;
                                        string varOutSetGroupFileSize = string.Empty;

                                        varSetGroupFileSize = Convert.ToInt64(tupleSumCntFile.Item1);

                                        if (varSetGroupFileSize > 1048576)
                                        {
                                            varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1048576) / 100 + " MB";
                                        }
                                        else if (varSetGroupFileSize > 1024)
                                        {
                                            varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1024) / 100 + " KB";
                                        }
                                        else
                                        {
                                            varOutSetGroupFileSize = varSetGroupFileSize + " Bytes";
                                        }


                                        return Json(new
                                        {
                                            //Data = "Size less, File Name: " + uploadedFile.FileName,
                                            statusCode = 107,
                                            status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
                                            remarks = uploadedFile.FileName
                                        }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                else
                                {
                                    return Json(new
                                    {
                                        //Data = "Format not match, File Name: " + uploadedFile.FileName,
                                        statusCode = 104,
                                        status = "File format not matched.",
                                        remarks = uploadedFile.FileName
                                    }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(new
                                {
                                    //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
                                    statusCode = 106,
                                    status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(clsprp.IsGroup) + " files.)",
                                    remarks = uploadedFile.FileName
                                }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Bad Request! Upload Failed",
                                statusCode = 102,
                                status = "Bad Request! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            //Data = "Bad Request! Upload Failed",
                            statusCode = 102,
                            status = "Bad Request! Upload Failed",
                            remarks = string.Empty
                        }, JsonRequestBehavior.AllowGet);
                    }                    
                }
                else
                {
                    return Json(new
                    {
                        //Data = "Bad Request! Upload Failed",
                        statusCode = 102,
                        status = "Mandatory field(s) required! Upload Failed",
                        remarks = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    //Data = "Bad Request! Upload Failed",
                    statusCode = 102,
                    status = "Bad Request! Upload Failed",
                    remarks = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
        }

        private async Task<AiClassifyResponse> CallProjectDocumentAiClassifier(byte[] fileBytes, string fileName, string expectedType)
        {
            var aiUrl = WebConfigurationManager.AppSettings["ProjectDocumentAiClassifierUrl"];
            if (string.IsNullOrWhiteSpace(aiUrl))
            {
                aiUrl = "http://127.0.0.1:8001/classify";
            }

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                using (var form = new MultipartFormDataContent())
                {
                    form.Add(new ByteArrayContent(fileBytes), "file", fileName);
                    form.Add(new StringContent(expectedType ?? string.Empty), "expectedType");

                    var response = await client.PostAsync(aiUrl, form);
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AiClassifyResponse>(json);
                }
            }
        }

        private string NormalizeDocTypeForAi(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "unknown";
            }

            var normalized = value.Trim().ToLowerInvariant().Replace(" ", "_");
            normalized = Regex.Replace(normalized, "[^a-z0-9_]+", "_");
            normalized = Regex.Replace(normalized, "_{2,}", "_").Trim('_');
            return string.IsNullOrWhiteSpace(normalized) ? "unknown" : normalized;
        }

        //private string BuildExpectedTypeForAi(Clsprp_Master_Project_Documents projectDocMaster)
        //{
        //    string[] candidates =
        //    {
        //        projectDocMaster.ProjectDoc_ValidTinySubCode,
        //        projectDocMaster.ProjectDoc_ValidSubCode,
        //        projectDocMaster.ProjectDoc_ValidCode,
        //        projectDocMaster.ProjectDocMaster_InfoName
        //    };

        //    foreach (var candidate in candidates)
        //    {
        //        var normalized = NormalizeDocTypeForAi(candidate);
        //        if (normalized != "unknown")
        //        {
        //            return normalized;
        //        }
        //    }

        //    return "unknown";
        //}

        private class AiClassifyResponse
        {
            public string documentType { get; set; }
            public string status { get; set; }
        }

        private bool SaveProjectLandApprovalDocuments(Clsprp_Project_Documents smodel, Int64 z_Promoter_ID, String z_PromoterDoc_FilePath, String z_PromoterDoc_FileName, String z_PromoterDoc_FileSize, String z_PromoterDoc_FileFormat, Int32 z_PromoterDoc_IsGroup, Int64 z_ProjectId)
        {
            Int64 Promoter_ID = 0;
            Promoter_ID = z_Promoter_ID;
            string PromoterDoc_FilePath = String.IsNullOrEmpty(z_PromoterDoc_FilePath) ? string.Empty : z_PromoterDoc_FilePath;
            string PromoterDoc_FileName = String.IsNullOrEmpty(z_PromoterDoc_FileName) ? string.Empty : z_PromoterDoc_FileName;
            string PromoterDoc_FileSize = String.IsNullOrEmpty(z_PromoterDoc_FileSize) ? string.Empty : z_PromoterDoc_FileSize;
            string PromoterDoc_FileFormat = String.IsNullOrEmpty(z_PromoterDoc_FileFormat) ? string.Empty : z_PromoterDoc_FileFormat;
            Int32 PromoterDoc_IsGroup = z_PromoterDoc_IsGroup;
            Int64 PromoterDoc_ProjectID = z_ProjectId;
            bool varRET = false;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_Documents savedb = new ClsMethod_Project_Documents();
                    string UID = User.Identity.GetUserId();
                    string UserNam = User.Identity.Name;
                    smodel.CreatedBy = UserNam;
                    smodel.ModifyBy = UserNam;
                    if (savedb.Add_Project_Documents(smodel, Promoter_ID, PromoterDoc_FilePath, PromoterDoc_FileName, PromoterDoc_FileSize, PromoterDoc_FileFormat, PromoterDoc_IsGroup, PromoterDoc_ProjectID))
                    {
                        varRET = true;
                        ModelState.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }

        //Get Document Information As Json
        public JsonResult GetProjectDocumentMasterByDocId(string DocId)
        {
            int Id = 0;
            if (DocId != "")
                Id = Convert.ToInt32(DocId);

            ClsMethod_Master_Project_Documents objDoc = new ClsMethod_Master_Project_Documents();
            var Subdiv = objDoc.Display_Master_Project_DocumentsByProjectDocInfoID(Id);

            return Json(Subdiv);
        }        

        //Get Document Uploaded List As Json
        public string GetProjectDocumentUploadedList_ByProjectId(string parmProjectId)
        {
            long Id = 0;
                if (parmProjectId != "")
                    Id = Convert.ToInt64(parmProjectId);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id") });

            try
            {
                ClsMethod_Project_Documents objDoc = new ClsMethod_Project_Documents();
                List<Clsprp_Project_DocumentsUploadedList> objgetprp = new List<Clsprp_Project_DocumentsUploadedList>();
                objgetprp = objDoc.Display_Project_DocumentsUploadedList_ByProjectId(Id);

                if (objgetprp.Count > 0)
                {
                    foreach (Clsprp_Project_DocumentsUploadedList a in objgetprp)
                    {
                        dt.Rows.Add(a.ProjectDoc_InfoCode);
                    }
                }
                else
                {                    
                    dt.Rows.Add(0);
                }
            }
            catch (Exception ex)
            {
                string varEx = ex.ToString();                
                dt.Rows.Add(0);
            }

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return serializer.Serialize(rows);
        }


        //GET: Delete
        public ActionResult Delete_ProjectDocument(Int64 inProjectDoc_IndexID, Int64 inProjectDoc_ID, Int64 inProject_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_Documents sdb = new ClsMethod_Project_Documents();
                if (sdb.Delete_Project_Document(inProjectDoc_IndexID, inProjectDoc_ID, inProject_ID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_ProjectDocument");
            }
            catch
            {
                return RedirectToAction("Create_ProjectDocument");
            }
        }

        #endregion Project_ProjectDocument

        private static List<SelectListItem> GetYears()
        {
            List<SelectListItem> Years = new List<SelectListItem>();

            for (Int32 i = (DateTime.Now.Year); i <= (2050); i++)
            //for (Int32 i = (DateTime.Now.Year); i <= (DateTime.Now.Year + 25) ; i++)
            //for (Int32 i = (DateTime.Now.Year); i <= (DateTime.Now.Year); i++)
            {
                Years.Add(new SelectListItem
                {
                    Text = Convert.ToString(i),
                    Value = Convert.ToString(i)
                });
            }

            return Years.ToList();
        }

        private static List<SelectListItem> GetQuarterlyUpdateYears()
        {
            List<SelectListItem> Years = new List<SelectListItem>();

            for (Int32 i = 2018; i <= (DateTime.Now.Year); i++)
            {
                Years.Add(new SelectListItem
                {
                    Text = Convert.ToString(i),
                    Value = Convert.ToString(i)
                });
            }
            return Years.ToList();
        }

        /// Table 19 Check Lists
        #region
        /// Project Individual Promoter Check Lists
        // Get:
        [HttpGet]
        //[Authorize(Roles = "Promoter, HelpDesk")]
        public ActionResult Create_ProjectICheckList()
        {
            return View();
        }

        /// Project Other Than Individual Promoter Check Lists
        // Get:
        [HttpGet]
        //[Authorize(Roles = "Promoter, HelpDesk")]
        public ActionResult Create_ProjectOCheckList()
        {
            return View();
        }
        #endregion
        #region
        /// Registration Check Lists - Individual Promoter
        // Get:
        [HttpGet]
        //[Authorize(Roles = "Promoter, HelpDesk")]
        public ActionResult Create_ProjectIRegistrationCheckList()
        {
            return View();
        }

        /// Registration Check Lists - Other Than Individual Promoter
        // Get:
        [HttpGet]
        //[Authorize(Roles = "Promoter, HelpDesk")]
        public ActionResult Create_ProjectORegistrationCheckList()
        {
            return View();
        }
        #endregion
        #region
        /// <summary>
        /// To check the isdraft value to disable the save /submit button
        /// </summary>
        public void Get_Isdraftvalue_FromDiaryNumber(Int64 Project_id)
        {
            //Int64 Project_id = 0;
            //Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            ClsMethodProjectConfirm model = new ClsMethodProjectConfirm();

           

            Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Project_id);
            TempData["ProjectIsdraftValue"] = IsdraftValue;

            //return View("AgentView");
            //return RedirectToAction("AgentView");



        }
        #endregion
        public Int32 Get_Project_quater_Isdraftvalue_FromDiaryNumber()
        {
            Int64 Project_id = 0;
            string Quater = string.Empty;
            string Year = string.Empty;
            ClsMethodProjectQuater model = new ClsMethodProjectQuater();

            #region
            /// <summary>
            ///  Confirmation of  Agent Profile
            /// </summary>
            /// <returns></returns>
            //Get Project_id, year and quater after postback

            if ((Session["Project_id"] == null) || (Session["CurrentYears"] == null) || (Session["PresentQuater"] == null))
            {
                //TempData["status"] = "Pending";
                //TempData.Keep();
                //TempData["submitvalue"] = "Select Project";
                //TempData.Keep();
                return 1;
            }

            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                Year = Session["CurrentYears"].ToString();
                Quater = Session["PresentQuater"].ToString();

                Int32 returnIsdraftValue = 0;
                Int32 IsdraftValue = model.Isdraftvalue_FromDiaryNumber(Project_id, Quater, Year);
                //TempData["IsdraftValue"] = IsdraftValue;
                if (IsdraftValue == 1 || IsdraftValue == 5 || IsdraftValue == 6)
                {
                    returnIsdraftValue = 1;
                }
                else
                {
                    returnIsdraftValue = 0;
                }
                return returnIsdraftValue; // IsdraftValue;
            }
            //return View("AgentView");
            //return RedirectToAction("ProjectConfirmQuater");




            #endregion

        }

        public void Get_ProjectExtensionFormE_Isdraftvalue_FromDiaryNumber(Int64 Project_id)
        {
            ClsMethodProjectExtensionFormConfirm modelobj = new ClsMethodProjectExtensionFormConfirm();
            Int32 IsdraftValue = modelobj.Isdraftvalue_ProjectExtensionForm_FromDiaryNumber(Project_id);
            TempData["ProjectExtensionFormIsdraftValue"] = IsdraftValue;
        }

        

        // Project Due for Extension Details
        #region

        #region Form-E Documents Details
        [HttpPost]
        public ActionResult DropdownlistProjectExtensionDocument(FormCollection frm, Clsprp_Project_ExtensionFormEdocuments smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.Project_ID;
            TempData["SelectedItem"] = frm["Project_ID"]; TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        // GET: Empty Create + Display
        public ActionResult Create_ProjectExtensionFormEDocument()
        {
            Int64 Project_id = 0;
            Int64 Application_ID = 0;

            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
            }

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId_ExtensionForm(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProjectExtensionFormEDocument"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            
            //Fill project extension details with document list from project extension document Table
                      
            ClsMethod_Master_Project_ExtensionFormDocuments objdoc = new ClsMethod_Master_Project_ExtensionFormDocuments();
            Clsprp_Master_Project_ExtensionFormDocuments clsprp = new Clsprp_Master_Project_ExtensionFormDocuments();
            ClsMethod_Project_ExtensionFormDocuments sdb = new ClsMethod_Project_ExtensionFormDocuments();
            Clsprp_Project_ExtensionFormEdocuments aa = new Clsprp_Project_ExtensionFormEdocuments();
            Clsprp_Project_ExtensionFormEdocuments reraObj = new Clsprp_Project_ExtensionFormEdocuments();

            aa.prpongoing = sdb.Display_Project_ExtensionFormDocuments_ByProjectId(Project_id);
            aa.Project_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();

            aa.ProjectExtensionDocs = aa.prpongoing;
            aa.MasterExtensionDocs = objdoc.Display_Master_Project_ExtensionFormDocumentsByProjectIDandPromoterID(Application_ID, Project_id);

            reraObj.prpongoing = sdb.Display_Project_ExtensionFormRERAnumberdetails_ByProjectId(Project_id);
            if (aa.prpongoing.Count <= 0)
            {
                foreach (var itemB in reraObj.prpongoing)
                {
                    aa.Project_RERAnumber = itemB.Project_RERAnumber;
                    aa.Project_RERANumberIssueDate = itemB.Project_RERANumberIssueDate;
                    aa.Project_RERANumberValiduptoDate = itemB.Project_RERANumberValiduptoDate;
                }
            }

            foreach (var item in aa.MasterExtensionDocs)
            {
                clsprp.ProjectDocMaster_IndexID = item.ProjectDocMaster_IndexID;
                clsprp.ProjectDocMaster_InfoCode = item.ProjectDocMaster_InfoCode;
                clsprp.ProjectDocMaster_InfoName = item.ProjectDocMaster_InfoName;
                clsprp.ProjectDocMaster_RelatedSectionName = item.ProjectDocMaster_RelatedSectionName;
                clsprp.ProjectDoc_SetFileSize = item.ProjectDoc_SetFileSize;
                clsprp.ProjectDoc_SetFileFormat = item.ProjectDoc_SetFileFormat;
                clsprp.ProjectDoc_SetFilePath = item.ProjectDoc_SetFilePath;
                clsprp.ProjectDoc_ValidCode = item.ProjectDoc_ValidCode;
                clsprp.ProjectDoc_ValidSubCode = item.ProjectDoc_ValidSubCode;
                clsprp.ProjectDoc_ValidTinySubCode = item.ProjectDoc_ValidTinySubCode;
                clsprp.IsGroup = item.IsGroup;
                clsprp.IsMandatory = item.IsMandatory;
                clsprp.A_column = item.A_column;
                clsprp.B_column = item.B_column;
                clsprp.C_column = item.C_column;
                clsprp.IsActive = item.IsActive;
                clsprp.CreatedBy = item.CreatedBy;
                clsprp.CreatedOn = item.CreatedOn;
                clsprp.ModifyBy = item.ModifyBy;
                clsprp.ModifyOn = item.ModifyOn;
            }

            foreach (var itemA in aa.prpongoing)
            {
                //aa.FormE_IndexID = itemA.FormE_IndexID;
                //aa.FormE_ID = itemA.FormE_ID;
                //aa.Promoter_ID = itemA.Promoter_ID;
                //aa.Project_ID = itemA.Project_ID;

                //aa.ProjectExtension_NameID = itemA.ProjectExtension_NameID;
                //aa.ProjectExtension_NameYear = itemA.ProjectExtension_NameYear;
                //aa.ProjectExtension_Name = itemA.ProjectExtension_Name;
                //aa.Project_DiaryNumberID = itemA.Project_DiaryNumberID;

                aa.Project_RERAnumber = itemA.Project_RERAnumber;
                aa.Project_RERANumberIssueDate = itemA.Project_RERANumberIssueDate;
                aa.Project_RERANumberValiduptoDate = itemA.Project_RERANumberValiduptoDate;
                aa.FormE_DocIssueDate = itemA.FormE_DocIssueDate;
                aa.FormE_ExtensionAppliedReason = itemA.FormE_ExtensionAppliedReason;
                aa.FormE_ExtensionAppliedReasonSpecifyOthers = itemA.FormE_ExtensionAppliedReasonSpecifyOthers;

                //aa.FormE_DocInfoCode = itemA.FormE_DocInfoCode;
                //aa.FormE_DocInfoName = itemA.FormE_DocInfoName;
                //aa.FormE_DocRelatedSectionName = itemA.FormE_DocRelatedSectionName;
                //aa.FormE_DocReferenceNumber = itemA.FormE_DocReferenceNumber;

                //aa.FormE_DocFileSize = itemA.FormE_DocFileSize;
                //aa.FormE_DocFileFormat = itemA.FormE_DocFileFormat;
                //aa.FormE_DocFilePath = itemA.FormE_DocFilePath;
                //aa.FormE_DocFileName = itemA.FormE_DocFileName;
                //aa.FormE_DocIsGroup = itemA.FormE_DocIsGroup;

                //aa.Remarks_IfAny = itemA.Remarks_IfAny;
                //aa.Summary_IfAny = itemA.Summary_IfAny;
                //aa.A_column = itemA.A_column;
                //aa.B_column = itemA.B_column;
                //aa.C_column = itemA.C_column;
                //aa.D_column = itemA.D_column;

                //aa.IsActive = itemA.IsActive;
                //aa.IsDraft = itemA.IsDraft;
                //aa.IsTemp = itemA.IsTemp;
                //aa.IsDraftMember = itemA.IsDraftMember;
                //aa.IsPublicView = itemA.IsPublicView;
                //aa.CreatedBy = itemA.CreatedBy;
                //aa.CreatedOn = itemA.CreatedOn;
                //aa.ModifyBy = itemA.ModifyBy;
                //aa.ModifyOn = itemA.ModifyOn;
            }

            TempData["submitvalueProjectFormExt"] = "Submit"; TempData.Keep();
            Get_ProjectExtensionFormE_Isdraftvalue_FromDiaryNumber(Project_id);
            
            return View("Create_ProjectExtensionFormEDocument", aa);
        }

        //Get Document Information As Json
        public JsonResult GetProjectExtensionFormDocumentMasterByDocId(string DocId)
        {
            int Id = 0;
            if (DocId != "")
                Id = Convert.ToInt32(DocId);

            ClsMethod_Master_Project_ExtensionFormDocuments objDoc = new ClsMethod_Master_Project_ExtensionFormDocuments();
            var Subdiv = objDoc.Display_Master_Project_ExtensionFormDocumentsByProjectDocInfoID(Id);

            return Json(Subdiv);
        }

        //Get Document Uploaded List As Json
        public string GetProjectExtensionFormDocumentUploadedList_ByProjectId(string parmProjectId)
        {
            long Id = 0;
            if (parmProjectId != "")
                Id = Convert.ToInt64(parmProjectId);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id") });

            try
            {
                ClsMethod_Project_ExtensionFormDocuments objDoc = new ClsMethod_Project_ExtensionFormDocuments();
                List<Clsprp_Project_ExtensionFormEdocumentsUploadedList> objgetprp = new List<Clsprp_Project_ExtensionFormEdocumentsUploadedList>();
                objgetprp = objDoc.Display_Project_ExtensionFormDocumentsUploadedList_ByProjectId(Id);

                if (objgetprp.Count > 0)
                {
                    foreach (Clsprp_Project_ExtensionFormEdocumentsUploadedList a in objgetprp)
                    {
                        dt.Rows.Add(a.ProjectDoc_InfoCode);
                    }
                }
                else
                {
                    dt.Rows.Add(0);
                }
            }
            catch (Exception ex)
            {
                string varEx = ex.ToString();
                dt.Rows.Add(0);
            }

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return serializer.Serialize(rows);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ProjectExtensionFormDocumentFormUpload(HttpPostedFileBase uploadedFile, Clsprp_Project_ExtensionFormEdocuments smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Project_ExtensionFormDocuments clsprp = new Clsprp_Master_Project_ExtensionFormDocuments();
                    ClsMethod_Master_Project_ExtensionFormDocuments objdoc = new ClsMethod_Master_Project_ExtensionFormDocuments();
                    Clsprp_Project_ExtensionFormEdocuments clsprpPrmDoc = new Clsprp_Project_ExtensionFormEdocuments();
                    ClsMethod_Project_ExtensionFormDocuments objPromoterDoc = new ClsMethod_Project_ExtensionFormDocuments();

                    Int32 IndexId = smodel.FormE_DocInfoCode;
                    Int64 PromoterId = 0;
                    Int64 Application_id = 0;
                    Int64 ProjectId = 0;
                    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                    {
                        if (Session["ApplicationId"].ToString() != "0")
                        {
                            Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        }
                    }
                    PromoterId = Application_id;
                    ProjectId = Convert.ToInt64(Session["Project_id"].ToString());

                    #region Read Master Data By Document Type
                    clsprpPrmDoc.MasterExtensionDocs = objdoc.Display_Master_Project_ExtensionFormDocumentsByProjectIDandPromoterID(PromoterId, ProjectId);

                    Tuple<Int64, Int64> tupleSumCntFile = (objPromoterDoc.Display_Project_ExtensionFormDocuments_ByDocCodeInfoProjectID(ProjectId, IndexId));

                    foreach (var item in clsprpPrmDoc.MasterExtensionDocs)
                    {
                        if (item.ProjectDocMaster_InfoCode == IndexId)
                        {
                            clsprp.ProjectDocMaster_IndexID = item.ProjectDocMaster_IndexID;
                            clsprp.ProjectDocMaster_InfoCode = item.ProjectDocMaster_InfoCode;
                            clsprp.ProjectDocMaster_InfoName = item.ProjectDocMaster_InfoName;
                            clsprp.ProjectDoc_SetFileSize = item.ProjectDoc_SetFileSize;
                            clsprp.ProjectDoc_SetFileFormat = item.ProjectDoc_SetFileFormat;
                            clsprp.ProjectDoc_SetFilePath = item.ProjectDoc_SetFilePath;
                            clsprp.ProjectDoc_ValidCode = item.ProjectDoc_ValidCode;
                            clsprp.ProjectDoc_ValidSubCode = item.ProjectDoc_ValidSubCode;
                            clsprp.ProjectDoc_ValidTinySubCode = item.ProjectDoc_ValidTinySubCode;
                            clsprp.IsGroup = item.IsGroup;
                            clsprp.IsMandatory = item.IsMandatory;
                            clsprp.A_column = item.A_column;
                            clsprp.B_column = item.B_column;
                            clsprp.C_column = item.C_column;
                            clsprp.IsActive = item.IsActive;
                            clsprp.CreatedBy = item.CreatedBy;
                            clsprp.CreatedOn = item.CreatedOn;
                            clsprp.ModifyBy = item.ModifyBy;
                            clsprp.ModifyOn = item.ModifyOn;
                        }
                    }
                    #endregion

                    #region Declare Variables
                    var path = "";
                    var pathindb = "";
                    var savefileName = "";
                    string extensionPhotoIdentityDocument = string.Empty;
                    int byteCountPhotoIdentityDocument = 0;
                    string masterGetPhotoIdentityDocument = string.Empty;
                    Int32 extensionPutPhotoIdentityDocument = 0;
                    Int32 masterPutPhotoIdentityDocument = 0;
                    string masterPromoterDoc_SetFilePath = "readwriteExtFormDoc";
                    bool IsValidFileType = false;
                    #endregion

                    //Bad Request - No Doc
                    if (Request.Files.Count > 0)
                    {
                        var PhotoIdentityDocument = Request.Files[0];

                        //Bad Request - No Doc OR No Size
                        if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                        {
                            #region SaveFile Path Creation
                            if (clsprp.ProjectDoc_SetFilePath.ToString() != string.Empty || clsprp.ProjectDoc_SetFilePath.ToString() != null)
                            {
                                masterPromoterDoc_SetFilePath = clsprp.ProjectDoc_SetFilePath.ToString();
                            }
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(ProjectId) + "\\";
                            path = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            #endregion

                            #region Master File Type Check
                            //Upload File Type
                            extensionPhotoIdentityDocument = Path.GetExtension(PhotoIdentityDocument.FileName);
                            switch (extensionPhotoIdentityDocument)
                            {
                                case ".JPEG":
                                case ".jpeg":
                                case ".JPG":
                                case ".jpg":
                                case ".PNG":
                                case ".png":
                                    {
                                        //Image Type
                                        extensionPutPhotoIdentityDocument = 102;
                                        break;
                                    }
                                case ".PDF":
                                case ".pdf":
                                    {
                                        //PDF Type
                                        extensionPutPhotoIdentityDocument = 103;
                                        break;
                                    }
                            }

                            //Master File Type
                            masterGetPhotoIdentityDocument = Convert.ToString(clsprp.ProjectDoc_SetFileFormat);
                            switch (masterGetPhotoIdentityDocument)
                            {
                                case "JPEG/JPG/PDF":
                                    {
                                        //Both Image and PDF Type
                                        masterPutPhotoIdentityDocument = 101;
                                        break;
                                    }
                                case "JPEG/JPG":
                                case "JPEG":
                                case "JPG":
                                    {
                                        //Image Type
                                        masterPutPhotoIdentityDocument = 102;
                                        break;
                                    }
                                case "PDF":
                                    {
                                        //PDF Type
                                        masterPutPhotoIdentityDocument = 103;
                                        break;
                                    }
                            }
                            if (masterPutPhotoIdentityDocument == 101)
                            {
                                if (extensionPutPhotoIdentityDocument == 102 || extensionPutPhotoIdentityDocument == 103)
                                {
                                    IsValidFileType = true;
                                }
                            }
                            else
                            {
                                if (extensionPutPhotoIdentityDocument == masterPutPhotoIdentityDocument)
                                {
                                    IsValidFileType = true;
                                }
                            }
                            #endregion

                            //Check Number of Files Uploaded
                            if (tupleSumCntFile.Item2 < Convert.ToInt32(clsprp.IsGroup))
                            {
                                if (IsValidFileType)
                                {
                                    if (tupleSumCntFile.Item1 <= Convert.ToInt32(clsprp.ProjectDoc_SetFileSize))
                                    {
                                        byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                        if (byteCountPhotoIdentityDocument <= Convert.ToInt32(clsprp.ProjectDoc_SetFileSize))
                                        {
                                            savefileName = RegexRemove(SaveFileDatePrefix() + Convert.ToString(clsprp.ProjectDocMaster_InfoCode) + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                            var pathsavefile = Path.Combine(path, savefileName);
                                            PhotoIdentityDocument.SaveAs(pathsavefile);

                                            var pathsavedb = Path.Combine(pathindb, savefileName);

                                            Int64 inPromoter_ID = PromoterId;
                                            string inProjectDoc_FilePath = pathindb;// pathsavedb;
                                            string inProjectDoc_FileName = savefileName;
                                            string inProjectDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                            string inProjectDoc_FileFormat = extensionPhotoIdentityDocument;
                                            Int32 inProjectDoc_IsGroup = Convert.ToInt32(clsprp.IsMandatory);

                                            bool varRet = SaveProjectExtensionFormErelatedDocuments(smodel, inPromoter_ID, inProjectDoc_FilePath, inProjectDoc_FileName, inProjectDoc_FileSize, inProjectDoc_FileFormat, inProjectDoc_IsGroup, ProjectId);

                                            if (varRet != false)
                                            {
                                                return Json(new
                                                {
                                                    //Data = "Complete",
                                                    statusCode = 101,
                                                    status = "Complete",
                                                    remarks = "Successfully uplaoded"
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                            else
                                            {
                                                return Json(new
                                                {
                                                    //Data = "Bad Request! Upload Failed",
                                                    statusCode = 105,
                                                    status = "Bad Request! Upload Failed",
                                                    remarks = "Not Saved! Upload Failed "
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                        }
                                        else
                                        {
                                            decimal varSetFileSize = 0;
                                            string varOutSetFileSize = string.Empty;
                                            varSetFileSize = Convert.ToInt32(clsprp.ProjectDoc_SetFileSize);

                                            if (varSetFileSize > 1048576)
                                            {
                                                varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1048576) / 100 + " MB";
                                            }
                                            else if (varSetFileSize > 1024)
                                            {
                                                varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1024) / 100 + " KB";
                                            }
                                            else
                                            {
                                                varOutSetFileSize = varSetFileSize + " Bytes";
                                            }

                                            return Json(new
                                            {
                                                //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                statusCode = 103,
                                                status = "File size should be less than " + varOutSetFileSize,
                                                remarks = uploadedFile.FileName
                                            }, JsonRequestBehavior.AllowGet);
                                        }
                                    }
                                    else
                                    {
                                        decimal varSetGroupFileSize = 0;
                                        string varOutSetGroupFileSize = string.Empty;

                                        varSetGroupFileSize = Convert.ToInt64(tupleSumCntFile.Item1);

                                        if (varSetGroupFileSize > 1048576)
                                        {
                                            varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1048576) / 100 + " MB";
                                        }
                                        else if (varSetGroupFileSize > 1024)
                                        {
                                            varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1024) / 100 + " KB";
                                        }
                                        else
                                        {
                                            varOutSetGroupFileSize = varSetGroupFileSize + " Bytes";
                                        }


                                        return Json(new
                                        {
                                            //Data = "Size less, File Name: " + uploadedFile.FileName,
                                            statusCode = 107,
                                            status = "Maximum number of uploaded files size limit reached.(Max:" + varOutSetGroupFileSize + ")",
                                            remarks = uploadedFile.FileName
                                        }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                else
                                {
                                    return Json(new
                                    {
                                        //Data = "Format not match, File Name: " + uploadedFile.FileName,
                                        statusCode = 104,
                                        status = "File format not matched.",
                                        remarks = uploadedFile.FileName
                                    }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(new
                                {
                                    //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
                                    statusCode = 106,
                                    status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(clsprp.IsGroup) + " files.)",
                                    remarks = uploadedFile.FileName
                                }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Bad Request! Upload Failed",
                                statusCode = 102,
                                status = "Bad Request! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            //Data = "Bad Request! Upload Failed",
                            statusCode = 102,
                            status = "Bad Request! Upload Failed",
                            remarks = string.Empty
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        //Data = "Bad Request! Upload Failed",
                        statusCode = 102,
                        status = "Mandatory field(s) required! Upload Failed",
                        remarks = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    //Data = "Bad Request! Upload Failed",
                    statusCode = 102,
                    status = "Bad Request! Upload Failed",
                    remarks = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
        }

        private bool SaveProjectExtensionFormErelatedDocuments(Clsprp_Project_ExtensionFormEdocuments smodel, Int64 z_Promoter_ID, String z_PromoterDoc_FilePath, String z_PromoterDoc_FileName, String z_PromoterDoc_FileSize, String z_PromoterDoc_FileFormat, Int32 z_PromoterDoc_IsGroup, Int64 z_ProjectId)
        {
            Int64 Promoter_ID = 0;
            Promoter_ID = z_Promoter_ID;
            string PromoterDoc_FilePath = String.IsNullOrEmpty(z_PromoterDoc_FilePath) ? string.Empty : z_PromoterDoc_FilePath;
            string PromoterDoc_FileName = String.IsNullOrEmpty(z_PromoterDoc_FileName) ? string.Empty : z_PromoterDoc_FileName;
            string PromoterDoc_FileSize = String.IsNullOrEmpty(z_PromoterDoc_FileSize) ? string.Empty : z_PromoterDoc_FileSize;
            string PromoterDoc_FileFormat = String.IsNullOrEmpty(z_PromoterDoc_FileFormat) ? string.Empty : z_PromoterDoc_FileFormat;
            Int32 PromoterDoc_IsGroup = z_PromoterDoc_IsGroup;
            Int64 PromoterDoc_ProjectID = z_ProjectId;
            bool varRET = false;

            string prmProject_DiaryNumberID = string.Empty;
            string prmProject_RERAnumber = string.Empty;
            string prmUserName = string.Empty;

            string UID = User.Identity.GetUserId();
            prmUserName = User.Identity.Name;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_ExtensionFormDocuments savedb = new ClsMethod_Project_ExtensionFormDocuments();
                    if (savedb.Add_Project_ExtensionFormEdocuments(smodel, Promoter_ID, PromoterDoc_FilePath, PromoterDoc_FileName, PromoterDoc_FileSize, PromoterDoc_FileFormat, PromoterDoc_IsGroup, PromoterDoc_ProjectID, prmProject_DiaryNumberID, prmProject_RERAnumber, prmUserName))
                    {
                        varRET = true;
                        ModelState.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }

        //GET: Delete
        public ActionResult Delete_ProjectExtensionFormEDocument(Int64 inProjectDoc_IndexID, Int64 inProjectDoc_ID, Int64 inProject_ID)
        {
            try
            {
                ClsMethod_Project_ExtensionFormDocuments sdb = new ClsMethod_Project_ExtensionFormDocuments();
                if (sdb.Delete_Project_ExtensionFormDocument(inProjectDoc_IndexID, inProjectDoc_ID, inProject_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                }
                return RedirectToAction("Create_ProjectExtensionFormEDocument");
            }
            catch
            {
                return RedirectToAction("Create_ProjectExtensionFormEDocument");
            }
        }

        #endregion
        
        #region Form-E Payment
        [HttpPost]
        public ActionResult DropdownlistProjectExtensionPaymentDetails(FormCollection frm, ClsPrp_Project_ExtensionFormEPayment smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["ProjectPaymentRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectPaymentRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        // GET: Empty Create + Display
        public ActionResult Create_ProjectExtentionPaymentDetails()
        {
            ClsMethodProject objdis = new ClsMethodProject();
            ViewBag.SelectedItem = "";
            Int64 Project_id = 0;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProjectExtentionPaymentDetails"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId_ExtensionForm(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_ExtensionFormEPayment sdb = new ClsMethod_Project_ExtensionFormEPayment();
            ClsPrp_Project_ExtensionFormEPayment aa = new ClsPrp_Project_ExtensionFormEPayment();

            aa.prpongoing = sdb.Display_Project_ExtensionFormPayment(Project_id);
            aa.ProjectPaymentRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
                        
            ClsMethod_AllMaster objmaster = new ClsMethod_AllMaster();
            //to bind bank master
            aa.BankMaster = objmaster.Display_Master_BankDetails();
            //to bind Payment master
            Int32 PaymentForCode = 1;
            Int32 PaymentGroupCode = 11;
            aa.PayFeeMaster = objmaster.Display_Master_PaymentTypeByCode(PaymentForCode, PaymentGroupCode);
            aa.ImageDDorBankersCheque_FileName = "";

            TempData["submitvalueFormEpayment"] = "Submit";  TempData.Keep();
            Get_ProjectExtensionFormE_Isdraftvalue_FromDiaryNumber(Project_id);

            return View("Create_ProjectExtentionPaymentDetails", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_ProjectExtentionPaymentDetails(ClsPrp_Project_ExtensionFormEPayment smodel)
        {
            Int64 Project_id = 0;
            ClsPrp_Project_ExtensionFormEPayment aa = new ClsPrp_Project_ExtensionFormEPayment();

            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectPaymentRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            //Save & Update
            #region

            String ext = String.Empty;
            string FilePathExt = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string prmUserName = User.Identity.Name;
            string UID = User.Identity.GetUserId();

            if (TempData["submitvalueFormEpayment"].ToString() == "Update")
            {
                #region PhotoCertificate Update with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".pdf", ".PDF" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 512000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwriteExtFormDoc";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FilePath))
                            {
                                pathindb = smodel.ImageDDorBankersCheque_FilePath.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ImageDDorBankersCheque_FileName))
                            {
                                fileName = smodel.ImageDDorBankersCheque_FileName.ToString();
                            }
                            else
                            {
                                fileName = "FeeFormE_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }

                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;
                        }
                        else
                        {
                            TempData["notice"] = "Scan copy/document Size Should be less than 512KB";
                            error = "Scan copy/document Size Should be less than 512KB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Scan copy/document format should be .jpg/.pdf";
                        error = "Scan copy/document format should be .jpg/.pdf";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Invalid Scan copy/document! Try Again";
                    error = "Invalid Scan copy/document! Try Again";
                    errorstate = 1;

                    //update with same photograph
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }
                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.ImageDDorBankersCheque_FileName;
                            ext = smodel.ImageDDorBankersCheque_FilePath;
                            FilePathExt = smodel.ImageDDorBankersCheque_FilePath;
                        }

                        try
                        {
                            ClsMethod_Project_ExtensionFormEPayment sdb = new ClsMethod_Project_ExtensionFormEPayment();
                            sdb.Update_Project_ExtensionFormPayment(smodel, prmUserName);
                            TempData["message"] = "Details updated Successfully";
                            return RedirectToAction("Create_ProjectExtentionPaymentDetails");
                        }
                        catch (Exception ex)
                        {
                            string exvar = ex.ToString();
                            return View();
                        }
                    }
                    return RedirectToAction("Create_ProjectExtentionPaymentDetails");
                }
                else
                {
                    return RedirectToAction("Create_ProjectExtentionPaymentDetails");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".pdf", ".PDF" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 512000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwriteExtFormDoc";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "FeeFormE_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;
                        }
                        else
                        {
                            TempData["notice"] = "Scan copy/document Size Should be less than 512KB";
                            error = "Scan copy/document Size Should be less than 512KB";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Scan copy/document format should be .jpg/.pdf";
                        error = "Scan copy/document format should be .jpg/.pdf";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Invalid Scan copy/document! Try Again";
                    error = "Invalid Scan copy/document! Try Again";
                    errorstate = 1;
                }
                #endregion

                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (Photo_Address == "")
                            {
                                Photo_Address = smodel.ImageDDorBankersCheque_FileName;
                                ext = smodel.ImageDDorBankersCheque_FilePath;
                                FilePathExt = smodel.ImageDDorBankersCheque_FilePath;
                            }

                            ClsMethod_Project_ExtensionFormEPayment sdb = new ClsMethod_Project_ExtensionFormEPayment();

                            ClsMethod_AllMaster objmaster = new ClsMethod_AllMaster();
                            //to bind bank master
                            aa.BankMaster = objmaster.Display_Master_BankDetails();
                            //to bind Payment master
                            Int32 PaymentForCode = 1;
                            Int32 PaymentGroupCode = 11;
                            aa.PayFeeMaster = objmaster.Display_Master_PaymentTypeByCode(PaymentForCode, PaymentGroupCode);

                            if (sdb.Add_Project_ExtensionFormPayment(smodel, Project_id, Photo_Address, FilePathExt, prmUserName))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("Create_ProjectExtentionPaymentDetails");
                    }
                    else
                    {
                        return RedirectToAction("Create_ProjectExtentionPaymentDetails");
                    }
                }
                catch (Exception ex)
                {
                    string exvar = ex.ToString();
                    return View();
                }
            }
            #endregion
        }

        //// GET: Single Display
        [HttpGet]
        public ActionResult Edit_ProjectExtentionPaymentDetails(Int64 ProjectRegistration_ID, Int64 ProjectPayment_IndexID, Int64 ProjectPayment_ID)
        {
            ClsMethod_Project_ExtensionFormEPayment sdb = new ClsMethod_Project_ExtensionFormEPayment();
            ClsPrp_Project_ExtensionFormEPayment aa = new ClsPrp_Project_ExtensionFormEPayment();

            aa.prpongoing = sdb.Display_Project_ExtensionFormPaymentById(ProjectRegistration_ID, ProjectPayment_IndexID, ProjectPayment_ID);

            ClsMethod_AllMaster objmaster = new ClsMethod_AllMaster();
            //to bind bank master
            aa.BankMaster = objmaster.Display_Master_BankDetails();
            //to bind Payment master
            Int32 PaymentForCode = 1;
            Int32 PaymentGroupCode = 11;
            aa.PayFeeMaster = objmaster.Display_Master_PaymentTypeByCode(PaymentForCode, PaymentGroupCode);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectPayment_IndexID = item.ProjectPayment_IndexID;
                aa.ProjectPayment_ID = item.ProjectPayment_ID;
                aa.ProjectPaymentRelated_ProjectRegistration_ID = item.ProjectPaymentRelated_ProjectRegistration_ID;
                aa.ProjectPayment_TitleCode = item.ProjectPayment_TitleCode;
                aa.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                aa.Registration_Fee = item.Registration_Fee;
                aa.Other_Fee = item.Other_Fee;
                aa.Payment_Mode = item.Payment_Mode;
                aa.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aa.Bank_Charges = item.Bank_Charges;
                aa.Bank_Name = item.Bank_Name;
                aa.Branch_Name = item.Branch_Name;
                aa.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aa.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                aa.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                aa.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalueFormEpayment"] = "Update"; TempData.Keep();
            return View("Create_ProjectExtentionPaymentDetails", aa);
        }

        //// GET: Delete 
        public ActionResult Delete_ProjectExtentionPaymentDetails(Int64 ProjectRegistration_ID, Int64 ProjectPayment_IndexID, Int64 ProjectPayment_ID)
        {
            try
            {
                ClsMethod_Project_ExtensionFormEPayment sdb = new ClsMethod_Project_ExtensionFormEPayment();
                if (sdb.Delete_Project_ExtensionFormPayment(ProjectRegistration_ID, ProjectPayment_IndexID, ProjectPayment_ID))
                {
                    TempData["message"] = " Details deleted Successfully";
                }
                return RedirectToAction("Create_ProjectExtentionPaymentDetails");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #endregion

        // Audited Annual Report on Statement of Accounts (Form-5) Application
        #region

        #region Audited Annual Report on Statement of Accounts (Form-5) Application

        [HttpPost]
        public ActionResult DropdownlistProjectStatementofAccountsApplication(FormCollection frm, ClsPrp_Project_StatementofAccountsApplicationFormFive smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            Session["Project_id"] = smodel.ProjectStatementofAccountsRelated_ProjectID;            
            TempData["SelectedItem"] = frm["ProjectStatementofAccountsRelated_ProjectID"];
            TempData.Keep();
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }
        // GET: Empty Create + Display
        public ActionResult Create_ProjectStatementofAccountsApplicationFormFive()
        {
            Int64 Project_id = 0;            

            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProjectStatementofAccountsApplicationFormFive"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());


            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_FormFive(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();
            ClsPrp_Project_StatementofAccountsApplicationFormFive aa = new ClsPrp_Project_StatementofAccountsApplicationFormFive();
            
            aa.prpongoing = sdb.Display_Project_StatementofAccountsApplicationFormFivedetails(Project_id);
            aa.ProjectStatementofAccountsRelated_ProjectID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();

            //if (aa.prpongoing.Count >= 1)
            //{
            //    TempData["submitvalueFormFive"] = "Update"; TempData.Keep();
            //}
            
            TempData["submitvalueFormFive"] = "Submit"; TempData.Keep();
            aa.ImageFormFive_FileName = "";
            
            //foreach (var item in aa.prpongoing)
            //{
            //    aa.ProjectStatementofAccounts_IndexID = item.ProjectStatementofAccounts_IndexID;
            //    aa.ProjectStatementofAccounts_ID = item.ProjectStatementofAccounts_ID;
            //    aa.ProjectStatementofAccounts_DiaryNumber = item.ProjectStatementofAccounts_DiaryNumber;
            //    aa.ProjectStatementofAccounts_DiaryID = item.ProjectStatementofAccounts_DiaryID;
            //    aa.ProjectStatementofAccounts_DiaryYear = item.ProjectStatementofAccounts_DiaryYear;
            //    aa.ProjectStatementofAccountsRelated_ProjectID = item.ProjectStatementofAccountsRelated_ProjectID;
            //    aa.ProjectStatementofAccountsRelated_ProjectName = item.ProjectStatementofAccountsRelated_ProjectName;
            //    aa.ProjectStatementofAccountsRelated_ProjectDiaryNumber = item.ProjectStatementofAccountsRelated_ProjectDiaryNumber;
            //    aa.ProjectStatementofAccountsRelated_PromoterID = item.ProjectStatementofAccountsRelated_PromoterID;
            //    aa.ProjectStatementofAccountsRelated_UserID = item.ProjectStatementofAccountsRelated_UserID;

            //    aa.FinancialYear_EndingOnDate = item.FinancialYear_EndingOnDate;
            //    aa.FormB_CompletionDate = item.FormB_CompletionDate;
            //    aa.Percentage_of_Completion = item.Percentage_of_Completion;
            //    aa.ExplanatoryNote = item.ExplanatoryNote;
            //    aa.CollectedDuring_FinancialYear_Amount_INR = item.CollectedDuring_FinancialYear_Amount_INR;
            //    aa.CollectedTillDate_Amount_INR = item.CollectedTillDate_Amount_INR;
            //    aa.WithdrawDuring_FinancialYear_Amount_INR = item.WithdrawDuring_FinancialYear_Amount_INR;
            //    aa.WithdrawnTillDate_Amount_INR = item.WithdrawnTillDate_Amount_INR;
            //    aa.Amount_A_column = item.Amount_A_column;
            //    aa.Amount_B_column = item.Amount_B_column;

            //    aa.ImageFormFive_FileName = item.ImageFormFive_FileName;
            //    aa.ImageFormFive_FilePath = item.ImageFormFive_FilePath;
            //    aa.ImageFormFive_FileSize = item.ImageFormFive_FileSize;
            //    aa.ImageFormFive_FileFormat = item.ImageFormFive_FileFormat;
            //    aa.A_column = item.A_column;
            //    aa.B_column = item.B_column;
            //    aa.C_column = item.C_column;
            //    aa.Remarks_IfAny = item.Remarks_IfAny;

            //    aa.IsActive = item.IsActive;
            //    aa.IsDraft = item.IsDraft;
            //    aa.IsEvaluationDraft = item.IsEvaluationDraft;
            //    aa.IsMemberDraft = item.IsMemberDraft;
            //    aa.IsSecretaryDraft = item.IsSecretaryDraft;
            //    aa.IsAuthorityDraft = item.IsAuthorityDraft;
            //    aa.IsPublicView = item.IsPublicView;
            //    aa.CreatedBy = item.CreatedBy;
            //    aa.CreatedOn = item.CreatedOn;
            //    aa.ModifyBy = item.ModifyBy;
            //    aa.ModifyOn = item.ModifyOn;
            //}
            //Get_Isdraftvalue_FromDiaryNumber(Project_id);
            //TempData["ProjectFormFiveIsdraftValue"] = aa.IsDraft;
            TempData["FormFiveSubmitMessage"] = "";
            TempData["FormFivePreviewMessage"] = "";
            return View("Create_ProjectStatementofAccountsApplicationFormFive", aa);
        }
        // GET: Edit Update + Single Display
        [HttpGet]
        public ActionResult Edit_ProjectStatementofAccountsApplicationFormFive(Int64? ProjectRegistration_ID, Int64? ProjectStatementofAccounts_IndexID)
        {
            ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();
            ClsPrp_Project_StatementofAccountsApplicationFormFive aa = new ClsPrp_Project_StatementofAccountsApplicationFormFive();
            aa.prpongoing = sdb.Display_Project_StatementofAccountsApplicationFormFivedetails_ByID(ProjectRegistration_ID, ProjectStatementofAccounts_IndexID);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectStatementofAccounts_IndexID = item.ProjectStatementofAccounts_IndexID;
                aa.ProjectStatementofAccounts_ID = item.ProjectStatementofAccounts_ID;
                aa.ProjectStatementofAccounts_DiaryNumber = item.ProjectStatementofAccounts_DiaryNumber;
                aa.ProjectStatementofAccounts_DiaryID = item.ProjectStatementofAccounts_DiaryID;
                aa.ProjectStatementofAccounts_DiaryYear = item.ProjectStatementofAccounts_DiaryYear;
                aa.ProjectStatementofAccountsRelated_ProjectID = item.ProjectStatementofAccountsRelated_ProjectID;
                aa.ProjectStatementofAccountsRelated_ProjectName = item.ProjectStatementofAccountsRelated_ProjectName;
                aa.ProjectStatementofAccountsRelated_ProjectDiaryNumber = item.ProjectStatementofAccountsRelated_ProjectDiaryNumber;
                aa.ProjectStatementofAccountsRelated_PromoterID = item.ProjectStatementofAccountsRelated_PromoterID;
                aa.ProjectStatementofAccountsRelated_UserID = item.ProjectStatementofAccountsRelated_UserID;

                aa.FinancialYear_EndingOnDate = item.FinancialYear_EndingOnDate;
                aa.FormB_CompletionDate = item.FormB_CompletionDate;
                aa.Percentage_of_Completion = item.Percentage_of_Completion;
                aa.ExplanatoryNote = item.ExplanatoryNote;
                aa.CollectedDuring_FinancialYear_Amount_INR = item.CollectedDuring_FinancialYear_Amount_INR;
                aa.CollectedTillDate_Amount_INR = item.CollectedTillDate_Amount_INR;
                aa.WithdrawDuring_FinancialYear_Amount_INR = item.WithdrawDuring_FinancialYear_Amount_INR;
                aa.WithdrawnTillDate_Amount_INR = item.WithdrawnTillDate_Amount_INR;
                aa.Amount_A_column = item.Amount_A_column;
                aa.Amount_B_column = item.Amount_B_column;

                aa.ImageFormFive_FileName = item.ImageFormFive_FileName;
                aa.ImageFormFive_FilePath = item.ImageFormFive_FilePath;
                aa.ImageFormFive_FileSize = item.ImageFormFive_FileSize;
                aa.ImageFormFive_FileFormat = item.ImageFormFive_FileFormat;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsEvaluationDraft = item.IsEvaluationDraft;
                aa.IsMemberDraft = item.IsMemberDraft;
                aa.IsSecretaryDraft = item.IsSecretaryDraft;
                aa.IsAuthorityDraft = item.IsAuthorityDraft;
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            //Get_Isdraftvalue_FromDiaryNumber(Project_id);
            //TempData["ProjectFormFiveIsdraftValue"] = aa.IsDraft;

            TempData["submitvalueFormFive"] = "Update";
            TempData.Keep();
            TempData["FormFiveSubmitMessage"] = "";
            TempData["FormFivePreviewMessage"] = "";
            return View("Create_ProjectStatementofAccountsApplicationFormFive", aa);
        }
        // GET: Edit Update + Single Display
        [HttpGet]
        public ActionResult Confirm_ProjectStatementofAccountsApplicationFormFive(Int64? ProjectRegistration_ID, Int64? ProjectStatementofAccounts_IndexID)
        {
            ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();
            ClsPrp_Project_StatementofAccountsApplicationFormFive aa = new ClsPrp_Project_StatementofAccountsApplicationFormFive();
            aa.prpongoing = sdb.Display_Project_StatementofAccountsApplicationFormFivedetails_ByID(ProjectRegistration_ID, ProjectStatementofAccounts_IndexID);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectStatementofAccounts_IndexID = item.ProjectStatementofAccounts_IndexID;
                aa.ProjectStatementofAccounts_ID = item.ProjectStatementofAccounts_ID;
                aa.ProjectStatementofAccounts_DiaryNumber = item.ProjectStatementofAccounts_DiaryNumber;
                aa.ProjectStatementofAccounts_DiaryID = item.ProjectStatementofAccounts_DiaryID;
                aa.ProjectStatementofAccounts_DiaryYear = item.ProjectStatementofAccounts_DiaryYear;
                aa.ProjectStatementofAccountsRelated_ProjectID = item.ProjectStatementofAccountsRelated_ProjectID;
                aa.ProjectStatementofAccountsRelated_ProjectName = item.ProjectStatementofAccountsRelated_ProjectName;
                aa.ProjectStatementofAccountsRelated_ProjectDiaryNumber = item.ProjectStatementofAccountsRelated_ProjectDiaryNumber;
                aa.ProjectStatementofAccountsRelated_PromoterID = item.ProjectStatementofAccountsRelated_PromoterID;
                aa.ProjectStatementofAccountsRelated_UserID = item.ProjectStatementofAccountsRelated_UserID;

                aa.FinancialYear_EndingOnDate = item.FinancialYear_EndingOnDate;
                aa.FormB_CompletionDate = item.FormB_CompletionDate;
                aa.Percentage_of_Completion = item.Percentage_of_Completion;
                aa.ExplanatoryNote = item.ExplanatoryNote;
                aa.CollectedDuring_FinancialYear_Amount_INR = item.CollectedDuring_FinancialYear_Amount_INR;
                aa.CollectedTillDate_Amount_INR = item.CollectedTillDate_Amount_INR;
                aa.WithdrawDuring_FinancialYear_Amount_INR = item.WithdrawDuring_FinancialYear_Amount_INR;
                aa.WithdrawnTillDate_Amount_INR = item.WithdrawnTillDate_Amount_INR;
                aa.Amount_A_column = item.Amount_A_column;
                aa.Amount_B_column = item.Amount_B_column;

                aa.ImageFormFive_FileName = item.ImageFormFive_FileName;
                aa.ImageFormFive_FilePath = item.ImageFormFive_FilePath;
                aa.ImageFormFive_FileSize = item.ImageFormFive_FileSize;
                aa.ImageFormFive_FileFormat = item.ImageFormFive_FileFormat;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.Remarks_IfAny = item.Remarks_IfAny;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.IsEvaluationDraft = item.IsEvaluationDraft;
                aa.IsMemberDraft = item.IsMemberDraft;
                aa.IsSecretaryDraft = item.IsSecretaryDraft;
                aa.IsAuthorityDraft = item.IsAuthorityDraft;
                aa.IsPublicView = item.IsPublicView;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            //Get_Isdraftvalue_FromDiaryNumber(Project_id);
            //TempData["ProjectFormFiveIsdraftValue"] = aa.IsDraft;

            TempData["submitvalueFormFive"] = "Confirm";
            TempData.Keep();
            TempData["FormFivePreviewMessage"] = "[ PREVIEW & CONFIRM ]";
            TempData.Keep();
            TempData["FormFiveSubmitMessage"] = "";
                        
            return View("Create_ProjectStatementofAccountsApplicationFormFive", aa);
        }
        // POST: Insert
        [HttpPost]
        public ActionResult Create_ProjectStatementofAccountsApplicationFormFive(ClsPrp_Project_StatementofAccountsApplicationFormFive smodel)
        {
            TempData["FormFiveSubmitMessage"] = "";
            TempData["FormFivePreviewMessage"] = "";
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectStatementofAccountsRelated_ProjectID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            //Save & Update
            #region

            String ext = String.Empty;
            string FilePathExt = string.Empty;
            string error = string.Empty;
            int errorstate = 0;
            string UID = User.Identity.GetUserId();
            string UserNam = User.Identity.Name;

            if (TempData["submitvalueFormFive"].ToString() == "Update")
            {
                #region PhotoCertificate Update with Path
                if (Request.Files[0].FileName != null && Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (files.FileName != null && allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataFormFive";
                            #endregion

                            #region UpdateFile Path Creation 
                            if (!String.IsNullOrEmpty(smodel.ImageFormFive_FileName))
                            {
                                pathindb = smodel.ImageFormFive_FileName.ToString();
                            }
                            else
                            {
                                pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            }
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            if (!String.IsNullOrEmpty(smodel.ImageFormFive_FilePath))
                            {
                                fileName = smodel.ImageFormFive_FilePath.ToString();
                            }
                            else
                            {
                                fileName = "FormFiveAAR_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            }

                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Document Size Should be less than 1MB (One MB).";
                            error = "Document Size Should be less than 1MB (One MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .jpg or .pdf)";
                        error = "Bad request! Invalid document format (should be .jpg or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;

                    //update with same Document
                    if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                    {
                        errorstate = 0;
                    }

                }
                #endregion
                if (errorstate == 0)
                {
                    if (ModelState.IsValid)
                    {
                        if (Photo_Address == "")
                        {
                            Photo_Address = smodel.ImageFormFive_FileName;
                            ext = smodel.ImageFormFive_FileFormat;
                            FilePathExt = smodel.ImageFormFive_FilePath;
                        }
                        try
                        {
                            ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();

                            smodel.ProjectStatementofAccountsRelated_UserID = UID;
                            sdb.Update_Project_StatementofAccountsApplicationFormFivedetails(smodel, Project_id, Photo_Address, FilePathExt, ext, UserNam);
                            TempData["message"] = "Details updated Successfully";

                            return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                        }
                        catch (Exception ex)
                        {
                            string varEX = ex.ToString();
                            return View();
                        }
                    }
                    return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                }
                else
                {
                    return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                }
            }
            else if(TempData["submitvalueFormFive"].ToString() == "Confirm")
            {
                try
                {
                    ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();

                    smodel.ProjectStatementofAccountsRelated_UserID = UID;
                    smodel.ModifyBy = UserNam;
                    if (sdb.Confirm_Project_StatementofAccountsApplicationFormFivedetails(smodel))
                    {
                        TempData["message"] = " Details confirmed Successfully";
                        TempData["FormFiveSubmitMessage"] = "Application (Form-5 dated " + smodel.FinancialYear_EndingOnDate.Value.ToString("MMMM yyyy") + ") successfully confirmed.";
                        TempData.Keep();

                        Int64 PromoterApplicationId = 0;
                        if (Session["ApplicationId"] != null)
                        {
                            if (Session["ApplicationId"].ToString() != "0")
                            {
                                PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                            }
                        }
                        ClsMethodProject objdis = new ClsMethodProject();
                        TempData["list"] = objdis.FillDropdown_Project_ByAppId_FormFive(PromoterApplicationId, 0);
                        TempData.Keep();
                    }
                    ClsPrp_Project_StatementofAccountsApplicationFormFive aa = new ClsPrp_Project_StatementofAccountsApplicationFormFive();
                    aa.ProjectStatementofAccountsRelated_ProjectID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();

                    aa.prpongoing = sdb.Display_Project_StatementofAccountsApplicationFormFivedetails(Project_id);
                    if (aa.prpongoing.Count < 1)
                    {
                        aa.ImageFormFive_FileName = "";
                    }
                    else
                    {
                        aa.ImageFormFive_FileName = "";
                    }
                    TempData["submitvalueFormFive"] = "Submit"; TempData.Keep();
                    return View("Create_ProjectStatementofAccountsApplicationFormFive", aa);
                    //return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                }
                catch
                {
                    return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                }
            }
            else
            {
                #region PhotoCertificate Save with Path
                if (Request.Files[0].FileName != null && Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                {
                    var files = Request.Files[0];
                    var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                    ext = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                    if (files.FileName != null && allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        int size = files.ContentLength;
                        if (size <= 1024000)
                        {

                            #region Declare Variables
                            var pathpromoterdata = "";
                            var pathindb = "";
                            string masterPromoterDoc_SetFilePath = "readwritedataFormFive";
                            #endregion

                            #region SaveFile Path Creation
                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(Project_id) + "\\";
                            pathpromoterdata = Server.MapPath("~/" + pathindb);

                            if (!Directory.Exists(pathpromoterdata))
                            {
                                Directory.CreateDirectory(pathpromoterdata);
                            }
                            #endregion

                            var fileName = string.Empty;
                            fileName = "FormFiveAAR_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + ext;
                            var path = Path.Combine(pathpromoterdata, fileName);
                            files.SaveAs(path);
                            Photo_Address = fileName;
                            FilePathExt = pathindb;

                        }
                        else
                        {
                            TempData["notice"] = "Document Size Should be less than 1MB (One MB).";
                            error = "Document Size Should be less than 1MB (One MB).";
                            errorstate = 1;
                        }
                    }
                    else
                    {
                        TempData["notice"] = "Bad request! Invalid document format (should be .jpg or .pdf)";
                        error = "Bad request! Invalid document format (should be .jpg or .pdf)";
                        errorstate = 1;
                    }
                }
                else
                {
                    TempData["notice"] = "Bad request! Invalid upload document.";
                    error = "Bad request! Invalid upload document.";
                    errorstate = 1;
                }
                #endregion
                try
                {
                    if (errorstate == 0)
                    {
                        if (ModelState.IsValid)
                        {
                            if (Photo_Address == "")
                            {
                                Photo_Address = smodel.ImageFormFive_FileName;
                                ext = smodel.ImageFormFive_FileFormat;
                                FilePathExt = smodel.ImageFormFive_FilePath;
                            }
                            ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();

                            smodel.ProjectStatementofAccountsRelated_UserID = UID;
                            if (sdb.Add_Project_StatementofAccountsApplicationFormFivedetails(smodel, Project_id, Photo_Address, FilePathExt, ext, UserNam))
                            {
                                TempData["message"] = " Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                        return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                    }
                    else
                    {
                        return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return View();
                }
            }
            #endregion
        }
        //// GET: Delete 
        public ActionResult Delete_ProjectStatementofAccountsApplicationFormFive(Int64 ProjectRegistration_ID, Int64 ProjectStatementofAccounts_IndexID)
        {
            //if (TempData["FormFiveSubmitMessage"] == null)
            //{
            //    TempData["FormFiveSubmitMessage"] = "";
            //}
            try
            {
                ClsMethod_Project_StatementofAccountsApplicationFormFive sdb = new ClsMethod_Project_StatementofAccountsApplicationFormFive();
                if (sdb.Delete_Project_StatementofAccountsApplicationFormFivedetails(ProjectRegistration_ID, ProjectStatementofAccounts_IndexID))
                {
                    TempData["message"] = " Details deleted Successfully";                    
                }
                return RedirectToAction("Create_ProjectStatementofAccountsApplicationFormFive");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #endregion



        // Project Quaterly Updates (Quaterly Updates of Registered Projects)
        #region
        //QU-01 Detail of QUpdate Project Inventory
        #region
        [HttpPost]
        public ActionResult DropdownlistProjectQUpdate_QUInventoryDetails(FormCollection frm, ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["Related_ProjectRegistration_ID"]; TempData.Keep();
            TempData["SelectedItemQUpdatesYear"] = frm["QUpdateInventory_Year"]; TempData.Keep();
            TempData["SelectedItemQUpdatesQuater"] = frm["QUpdateInventory_QuarterName"]; TempData.Keep();
            Session["Project_id"] = smodel.Related_ProjectRegistration_ID;
            Session["QUpdatesSelectedYears"] = smodel.QUpdateInventory_Year;
            Session["QUpdatesSelectedQuater"] = smodel.QUpdateInventory_QuarterName;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        [HttpGet]
        public ActionResult QUpdate_QUInventoryDetials()
        {
            Int64 Project_id = 0;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_QuaterlyUpdates(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "QUInventoryDetials"))
            {
                Session.Remove("Project_id");
                Session.Remove("QUpdatesSelectedYears");
                Session.Remove("QUpdatesSelectedQuater");
            }
            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory sdb = new ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory();
            ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory aa = new ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory();

            aa.prpongoing = sdb.Display_QUpdateProject_BuildingTowerBlock_Inventory(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.Related_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            aa.QUpdateInventory_Year = Convert.ToString(TempData["SelectedItemQUpdatesYear"]); TempData.Keep();
            aa.QUpdateInventory_QuarterName = Convert.ToString(TempData["SelectedItemQUpdatesQuater"]); TempData.Keep();

            //ClsMethod_master_BuildingTowerName BTMaster = new ClsMethod_master_BuildingTowerName();
            //aa.MasterBuilding = BTMaster.Display_BuildingTowerBlock_Construction(Project_id);

            aa.MasterProjectInventoryList = sdb.Display_Master_QUpdateProject_InventoryList();

            if (Session["QUpdatesSelectedYears"] != null)
            {
                aa.QUpdateInventory_Year = Session["QUpdatesSelectedYears"].ToString();
                aa.QUpdateInventory_QuarterName = Session["QUpdatesSelectedQuater"].ToString();
            }

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            //foreach (var item in aa.prpongoing)
            //{
            //    item.IsRegisteredDiaryNumberLock = retDNoValue;
            //    aa.IsRegisteredDiaryNumberLock = item.IsRegisteredDiaryNumberLock;
            //}

            aa.prpongoing.ToList().ForEach(s => s.IsRegisteredDiaryNumberLock = retDNoValue);

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            TempData["QUpdatesSelectedYears"] = null; ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            TempData["selectCntlInventory"] = "CntlUnlock"; TempData.Keep();
            return View("QUpdate_QUInventoryDetials", aa);
        }

        [HttpGet]
        public ActionResult QUpdateEdit_QUInventoryDetials(Int64 PRID, Int64 quPIIndexID, Int64 quPIID, Int64 rPIIndexID, Int64 rPIID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectInventory_IndexID = 0;
            Int64 QUpdateProjectInventory_ID = 0;
            Int64 Related_ProjectInventoryIndexID = 0;
            Int64 Related_ProjectInventory_ID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectInventory_IndexID = quPIIndexID;
            QUpdateProjectInventory_ID = quPIID;
            Related_ProjectInventoryIndexID = rPIIndexID;
            Related_ProjectInventory_ID = rPIID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }
            
            ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory sdb = new ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory();
            ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory aa = new ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory();

            aa.prpongoing = sdb.Display_QUpdateProject_BuildingTowerBlock_InventoryByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectInventory_IndexID, QUpdateProjectInventory_ID, Related_ProjectInventoryIndexID, Related_ProjectInventory_ID);
            aa.MasterProjectInventoryList = sdb.Display_Master_QUpdateProject_InventoryList();
            
            //ClsMethod_master_BuildingTowerName BTMaster = new ClsMethod_master_BuildingTowerName();
            //aa.MasterBuilding = BTMaster.Display_BuildingTowerBlock_Construction(ProjectRegistration_ID);

            if (aa.prpongoing.Count > 0)
            {
                foreach (var item in aa.prpongoing)
                {
                    aa.QUpdateProjectInventory_IndexID = item.QUpdateProjectInventory_IndexID;
                    aa.QUpdateProjectInventory_ID = item.QUpdateProjectInventory_ID;
                    aa.Related_ProjectInventoryIndexID = item.Related_ProjectInventoryIndexID;
                    aa.Related_ProjectInventory_ID = item.Related_ProjectInventory_ID;
                    aa.IsQuarterlyData = item.IsQuarterlyData;
                    aa.Related_ProjectRegistration_ID = item.Related_ProjectRegistration_ID;
                    aa.QUpdateInventory_Year = item.QUpdateInventory_Year;
                    aa.QUpdateInventory_QuarterName = item.QUpdateInventory_QuarterName;

                    aa.BuildingTowerBlock_Name = item.BuildingTowerBlock_Name;
                    aa.ApartmentShopPlot_Type = item.ApartmentShopPlot_Type;
                    aa.ApartmentShopPlot_InventoryType = item.ApartmentShopPlot_InventoryType;
                    aa.ApartmentShopPlot_CarpetArea = item.ApartmentShopPlot_CarpetArea;
                    aa.ApartmentShopPlot_ExclusiveOpenTerraceArea = item.ApartmentShopPlot_ExclusiveOpenTerraceArea;
                    aa.ApartmentShopPlot_ExclusiveBalconyVerandahArea = item.ApartmentShopPlot_ExclusiveBalconyVerandahArea;

                    aa.ApartmentShopPlot_NumberAvailableforSale = item.ApartmentShopPlot_NumberAvailableforSale;
                    aa.ApartmentShopPlot_NumberSoldUptoRegistration = item.ApartmentShopPlot_NumberSoldUptoRegistration;
                    aa.ApartmentShopPlot_NumberFloorsConstructedInQuarter = item.ApartmentShopPlot_NumberFloorsConstructedInQuarter;

                    aa.ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter = item.ApartmentShopPlot_NumberFoundationsBasementsConstructedInQuarter;
                    aa.ApartmentShopPlot_NumberBookedInQuarter = item.ApartmentShopPlot_NumberBookedInQuarter;
                    aa.ApartmentShopPlot_NumberCanceledBookedInQuarter = item.ApartmentShopPlot_NumberCanceledBookedInQuarter;
                    aa.ApartmentShopPlot_NumberSoldInQuarter = item.ApartmentShopPlot_NumberSoldInQuarter;
                    aa.ApartmentShopPlot_TotalNumberFloorsConstructed = item.ApartmentShopPlot_TotalNumberFloorsConstructed;
                    aa.ApartmentShopPlot_TotalNumberBooked = item.ApartmentShopPlot_TotalNumberBooked;
                    aa.ApartmentShopPlot_TotalNumberSold = item.ApartmentShopPlot_TotalNumberSold;

                    aa.Remarks_IfAny = item.Remarks_IfAny;
                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsRegisteredDiaryNumberLock = item.IsRegisteredDiaryNumberLock;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            else
            {
                aa.QUpdateProjectInventory_IndexID = QUpdateProjectInventory_IndexID;
                aa.QUpdateProjectInventory_ID = QUpdateProjectInventory_ID;
                aa.Related_ProjectInventoryIndexID = Related_ProjectInventoryIndexID;
                aa.Related_ProjectInventory_ID = Related_ProjectInventory_ID;
                aa.IsQuarterlyData = 5; // Table-2(DB Value)
                aa.Related_ProjectRegistration_ID = ProjectRegistration_ID;
                aa.QUpdateInventory_Year = Convert.ToString(ProjectQuarterYear);
                aa.QUpdateInventory_QuarterName = Convert.ToString(ProjectQuarterName);
            }
            //set default quarter year and name
            aa.QUpdateInventory_Year = Convert.ToString(ProjectQuarterYear);
            aa.QUpdateInventory_QuarterName = Convert.ToString(ProjectQuarterName);

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            string strSetSubmitValue = string.Empty;
            if(aa.QUpdateProjectInventory_IndexID == 0)
            {                               
                strSetSubmitValue = "Save";
            }
            else
            {
                strSetSubmitValue = "Update";
            }

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["QUpdatesSelectedYears"] = null;            
            TempData["submitvalue"] = strSetSubmitValue; TempData.Keep();
            TempData["selectCntlInventory"] = "CntlLock"; TempData.Keep();
            return View("QUpdate_QUInventoryDetials", aa);
        }

        [HttpPost]
        public ActionResult QUpdateEdit_QUInventoryDetials(ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory smodel)
        {
            ViewBag.Years = GetQuarterlyUpdateYears();
            //TempData["CurrentYears"] = smodel.B_column;
            //Session["CurrentYears"] = smodel.B_column;
            //Session["PresentQuater"] = smodel.A_column;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                ProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.Related_ProjectRegistration_ID = ProjectID;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            //Save & Update
            #region
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory sdb = new ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory();

                    // IsRegisteredDiaryNumberLock
                    Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                    check_IsdraftValue = 2;
                    check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectID, ProjectQuarterYear, ProjectQuarterName);
                    if (check_IsdraftValue == 0 || check_IsdraftValue == 2) 
                    {
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            if (sdb.Update_QUpdateProject_BuildingTowerBlock_InventoryDetails(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details updated Successfully";
                                ModelState.Clear();
                            }
                        }
                        else
                        {
                            if (sdb.Add_QUpdateProject_BuildingTowerBlock_InventoryDetails(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        TempData["message"] = "Error! Invalid details";
                    }
                }
                return RedirectToAction("QUpdate_QUInventoryDetials");
            }
            catch (Exception ex)
            {
                string retSTR = ex.ToString();
                return View();
            }
            #endregion
        }

        // Delete 
        public ActionResult QUpdateDelete_QUInventoryDetials(Int64 PRID, Int64 quPIIndexID, Int64 quPIID, Int64 rPIIndexID, Int64 rPIID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectInventory_IndexID = 0;
            Int64 QUpdateProjectInventory_ID = 0;
            Int64 Related_ProjectInventoryIndexID = 0;
            Int64 Related_ProjectInventory_ID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectInventory_IndexID = quPIIndexID;
            QUpdateProjectInventory_ID = quPIID;
            Related_ProjectInventoryIndexID = rPIIndexID;
            Related_ProjectInventory_ID = rPIID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory sdb = new ClsMethod_QUpdateProject_BuildingTowerBlock_Inventory();
            ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory aa = new ClsPrp_QUpdateProject_BuildingTowerBlock_Inventory();

            try
            {
                // IsRegisteredDiaryNumberLock
                Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                check_IsdraftValue = 2;
                check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                {
                    if (sdb.Delete_QUpdateProject_BuildingTowerBlock_InventoryByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectInventory_IndexID, QUpdateProjectInventory_ID, Related_ProjectInventoryIndexID, Related_ProjectInventory_ID))
                    {
                        TempData["message"] = " Details deleted Successfully";
                    }
                }
                else
                {
                    TempData["message"] = "Error! Invalid details";
                }
                return RedirectToAction("QUpdate_QUInventoryDetials");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //QU-02 Detail of QUpdate Project Parking
        #region
        [HttpPost]
        public ActionResult DropdownlistProjectQUpdate_QUParkingDetails(FormCollection frm, ClsPrp_QUpdateProject_ParkingDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["Related_ParkingProjectRegistration_ID"]; TempData.Keep();
            TempData["SelectedItemQUpdatesYear"] = frm["QUpdateParking_Year"]; TempData.Keep();
            TempData["SelectedItemQUpdatesQuater"] = frm["QUpdateParking_QuarterName"]; TempData.Keep();
            Session["Project_id"] = smodel.Related_ParkingProjectRegistration_ID;
            Session["QUpdatesSelectedYears"] = smodel.QUpdateParking_Year;
            Session["QUpdatesSelectedQuater"] = smodel.QUpdateParking_QuarterName;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        [HttpGet]
        public ActionResult QUpdate_QUParkingDetails()
        {
            Int64 Project_id = 0;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_QuaterlyUpdates(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "QUParkingDetails"))
            {
                Session.Remove("Project_id");
                Session.Remove("QUpdatesSelectedYears");
                Session.Remove("QUpdatesSelectedQuater");
            }
            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ParkingDetails sdb = new ClsMethod_QUpdateProject_ParkingDetails();
            ClsPrp_QUpdateProject_ParkingDetails aa = new ClsPrp_QUpdateProject_ParkingDetails();

            aa.prpongoing = sdb.Display_QUpdateProject_ParkingDetails(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.Related_ParkingProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]);
            aa.QUpdateParking_Year = Convert.ToString(TempData["SelectedItemQUpdatesYear"]); TempData.Keep();
            aa.QUpdateParking_QuarterName = Convert.ToString(TempData["SelectedItemQUpdatesQuater"]); TempData.Keep();

            if (Session["QUpdatesSelectedYears"] != null)
            {
                aa.QUpdateParking_Year = Session["QUpdatesSelectedYears"].ToString();
                aa.QUpdateParking_QuarterName = Session["QUpdatesSelectedQuater"].ToString();
            }

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            aa.prpongoing.ToList().ForEach(s => s.IsRegisteredDiaryNumberLock = retDNoValue);

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            TempData["QUpdatesSelectedYears"] = null; ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            TempData["selectCntlParking"] = "CntlUnlock"; TempData.Keep();
            return View("QUpdate_QUParkingDetails", aa);
        }

        [HttpGet]
        public ActionResult QUpdateEdit_QUParkingDetails(Int64 PRID, Int64 quPPIndexID, Int64 quPPID, Int64 rPPIndexID, Int64 rPPID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectParking_IndexID = 0;
            Int64 QUpdateProjectParking_ID = 0;
            Int64 Related_ProjectParkingIndexID = 0;
            Int64 Related_ProjectParking_ID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectParking_IndexID = quPPIndexID;
            QUpdateProjectParking_ID = quPPID;
            Related_ProjectParkingIndexID = rPPIndexID;
            Related_ProjectParking_ID = rPPID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ParkingDetails sdb = new ClsMethod_QUpdateProject_ParkingDetails();
            ClsPrp_QUpdateProject_ParkingDetails aa = new ClsPrp_QUpdateProject_ParkingDetails();

            aa.prpongoing = sdb.Display_QUpdateProject_ParkingDetailsByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectParking_IndexID, QUpdateProjectParking_ID, Related_ProjectParkingIndexID, Related_ProjectParking_ID);
            if (aa.prpongoing.Count > 0)
            {
                foreach (var item in aa.prpongoing)
                {
                    aa.QUpdateProjectParking_IndexID = item.QUpdateProjectParking_IndexID;
                    aa.QUpdateProjectParking_ID = item.QUpdateProjectParking_ID;
                    aa.Related_ProjectParking_IndexID = item.Related_ProjectParking_IndexID;
                    aa.Related_ProjectParking_ID = item.Related_ProjectParking_ID;
                    aa.IsQuarterlyData = item.IsQuarterlyData;
                    aa.Related_ParkingProjectRegistration_ID = item.Related_ParkingProjectRegistration_ID;
                    aa.QUpdateParking_Year = item.QUpdateParking_Year;
                    aa.QUpdateParking_QuarterName = item.QUpdateParking_QuarterName;

                    aa.ParkingType = item.ParkingType;
                    aa.ParkingSpaceUnits_TotalArea = item.ParkingSpaceUnits_TotalArea;
                    aa.ParkingSpaceUnits_NumberAvailableforSale = item.ParkingSpaceUnits_NumberAvailableforSale;
                    aa.ParkingSpaceUnits_NumberBookedSoldUptoRegistration = item.ParkingSpaceUnits_NumberBookedSoldUptoRegistration;
                    aa.ParkingSpaceUnits_NumberBookedInQuarter = item.ParkingSpaceUnits_NumberBookedInQuarter;
                    aa.ParkingSpaceUnits_NumberCanceledBookedInQuarter = item.ParkingSpaceUnits_NumberCanceledBookedInQuarter;
                    aa.ParkingSpaceUnits_NumberSoldInQuarter = item.ParkingSpaceUnits_NumberSoldInQuarter;
                    aa.ParkingSpaceUnits_TotalNumberBooked = item.ParkingSpaceUnits_TotalNumberBooked;
                    aa.ParkingSpaceUnits_TotalNumberSold = item.ParkingSpaceUnits_TotalNumberSold;
                    aa.Remarks_IfAny = item.Remarks_IfAny;

                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsRegisteredDiaryNumberLock = item.IsRegisteredDiaryNumberLock;
                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            else
            {
                aa.QUpdateProjectParking_IndexID = QUpdateProjectParking_IndexID;
                aa.QUpdateProjectParking_ID = QUpdateProjectParking_ID;
                aa.Related_ProjectParking_IndexID = Related_ProjectParkingIndexID;
                aa.Related_ProjectParking_ID = Related_ProjectParking_ID;
                aa.IsQuarterlyData = 5; // Table-2(DB Value)
                aa.Related_ParkingProjectRegistration_ID = ProjectRegistration_ID;
                aa.QUpdateParking_Year = Convert.ToString(ProjectQuarterYear);
                aa.QUpdateParking_QuarterName = Convert.ToString(ProjectQuarterName);
            }
            //set default quarter year and name
            aa.QUpdateParking_Year = Convert.ToString(ProjectQuarterYear);
            aa.QUpdateParking_QuarterName = Convert.ToString(ProjectQuarterName);


            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            string strSetSubmitValue = string.Empty;
            if (aa.QUpdateProjectParking_IndexID == 0)
            {
                strSetSubmitValue = "Save";
            }
            else
            {
                strSetSubmitValue = "Update";
            }

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["QUpdatesSelectedYears"] = null;
            TempData["submitvalue"] = strSetSubmitValue; TempData.Keep();
            TempData["selectCntlParking"] = "CntlLock"; TempData.Keep();
            return View("QUpdate_QUParkingDetails", aa);
        }

        [HttpPost]
        public ActionResult QUpdateEdit_QUParkingDetails(ClsPrp_QUpdateProject_ParkingDetails smodel)
        {
            ViewBag.Years = GetQuarterlyUpdateYears();
            //TempData["CurrentYears"] = smodel.B_column;
            //Session["CurrentYears"] = smodel.B_column;
            //Session["PresentQuater"] = smodel.A_column;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                ProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.Related_ParkingProjectRegistration_ID = ProjectID;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            //Save & Update
            #region
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_QUpdateProject_ParkingDetails sdb = new ClsMethod_QUpdateProject_ParkingDetails();

                    // IsRegisteredDiaryNumberLock
                    Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                    check_IsdraftValue = 2;
                    check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectID, ProjectQuarterYear, ProjectQuarterName);
                    if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                    {
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            if (sdb.Update_QUpdateProject_ParkingDetails(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details updated Successfully";
                                ModelState.Clear();
                            }
                        }
                        else
                        {
                            if (sdb.Add_QUpdateProject_ParkingDetails(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        TempData["message"] = "Error! Invalid details";
                    }
                }
                return RedirectToAction("QUpdate_QUParkingDetails");
            }
            catch (Exception ex)
            {
                string retSTR = ex.ToString();
                return View();
            }
            #endregion
        }

        // Delete 
        public ActionResult QUpdateDelete_QUParkingDetails(Int64 PRID, Int64 quPPIndexID, Int64 quPPID, Int64 rPPIndexID, Int64 rPPID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectParking_IndexID = 0;
            Int64 QUpdateProjectParking_ID = 0;
            Int64 Related_ProjectParkingIndexID = 0;
            Int64 Related_ProjectParking_ID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectParking_IndexID = quPPIndexID;
            QUpdateProjectParking_ID = quPPID;
            Related_ProjectParkingIndexID = rPPIndexID;
            Related_ProjectParking_ID = rPPID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ParkingDetails sdb = new ClsMethod_QUpdateProject_ParkingDetails();
            ClsPrp_QUpdateProject_ParkingDetails aa = new ClsPrp_QUpdateProject_ParkingDetails();

            try
            {
                // IsRegisteredDiaryNumberLock
                Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                check_IsdraftValue = 2;
                check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                {
                    if (sdb.Delete_QUpdateProject_ParkingDetailsByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectParking_IndexID, QUpdateProjectParking_ID, Related_ProjectParkingIndexID, Related_ProjectParking_ID))
                    {
                        TempData["message"] = " Details deleted Successfully";
                    }
                }
                else
                {
                    TempData["message"] = "Error! Invalid details";
                }
                return RedirectToAction("QUpdate_QUParkingDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //QU-03 Detail of QUpdate Project Approvals
        #region
        [HttpPost]
        public ActionResult DropdownlistProjectQUpdate_QUApprovalDetails(FormCollection frm, ClsPrp_QUpdateProject_ApprovalDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["Related_ApprovalProjectRegistration_ID"]; TempData.Keep();
            TempData["SelectedItemQUpdatesYear"] = frm["QUpdateApproval_Year"]; TempData.Keep();
            TempData["SelectedItemQUpdatesQuater"] = frm["QUpdateApproval_QuarterName"]; TempData.Keep();
            Session["Project_id"] = smodel.Related_ApprovalProjectRegistration_ID;
            Session["QUpdatesSelectedYears"] = smodel.QUpdateApproval_Year;
            Session["QUpdatesSelectedQuater"] = smodel.QUpdateApproval_QuarterName;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        [HttpGet]
        public ActionResult QUpdate_QUApprovalDetails()
        {
            Int64 Project_id = 0;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_QuaterlyUpdates(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "QUApprovalDetails"))
            {
                Session.Remove("Project_id");
                Session.Remove("QUpdatesSelectedYears");
                Session.Remove("QUpdatesSelectedQuater");
            }
            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ApprovalDetails sdb = new ClsMethod_QUpdateProject_ApprovalDetails();
            ClsPrp_QUpdateProject_ApprovalDetails aa = new ClsPrp_QUpdateProject_ApprovalDetails();

            aa.prpongoing = sdb.Display_QUpdateProject_ApprovalDetails(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.Related_ApprovalProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            aa.QUpdateApproval_Year = Convert.ToString(TempData["SelectedItemQUpdatesYear"]); TempData.Keep();
            aa.QUpdateApproval_QuarterName = Convert.ToString(TempData["SelectedItemQUpdatesQuater"]); TempData.Keep();

            if (Session["QUpdatesSelectedYears"] != null)
            {
                aa.QUpdateApproval_Year = Session["QUpdatesSelectedYears"].ToString();
                aa.QUpdateApproval_QuarterName = Session["QUpdatesSelectedQuater"].ToString();
            }

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            aa.prpongoing.ToList().ForEach(s => s.IsRegisteredDiaryNumberLock = retDNoValue);

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            TempData["QUpdatesSelectedYears"] = null; ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["submitvalue"] = "Save"; TempData.Keep();
            TempData["selectCntlApprovals"] = "CntlUnlock"; TempData.Keep();

            return View("QUpdate_QUApprovalDetails", aa);
        }

        [HttpPost]
        public ActionResult QUpdate_QUApprovalDetails(ClsPrp_QUpdateProject_ApprovalDetails smodel)
        {
            ViewBag.Years = GetQuarterlyUpdateYears();
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                ProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.Related_ApprovalProjectRegistration_ID = ProjectID;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            //Save & Update
            #region            
            string FileAddress = string.Empty;
            string FileExtn = string.Empty;
            string FilePath = string.Empty;
            string FileName = string.Empty;
            string error = string.Empty;
            int errorstate = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    #region
                    // IsRegisteredDiaryNumberLock
                    Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                    check_IsdraftValue = 2;
                    check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectID, ProjectQuarterYear, ProjectQuarterName);
                    if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                    {
                        //Case-A: UPDATE
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            #region DocumentCertificate Update with Path
                            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                            {
                                var files = Request.Files[0];
                                var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                                FileExtn = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(FileExtn)) //check what type of extension  
                                {
                                    int size = files.ContentLength;
                                    if (size <= 1024000)
                                    {

                                        #region Declare Variables
                                        var pathpromoterdata = "";
                                        var pathindb = "";
                                        string masterPromoterDoc_SetFilePath = "rwdataQUProject";
                                        #endregion

                                        #region UpdateFile Path Creation 
                                        if (!String.IsNullOrEmpty(smodel.DocumentType_FileName))
                                        {
                                            pathindb = smodel.DocumentType_FileName.ToString();
                                        }
                                        else
                                        {
                                            pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(ProjectID) + "\\";
                                        }
                                        pathpromoterdata = Server.MapPath("~/" + pathindb);

                                        if (!Directory.Exists(pathpromoterdata))
                                        {
                                            Directory.CreateDirectory(pathpromoterdata);
                                        }
                                        #endregion

                                        var fileName = string.Empty;
                                        if (!String.IsNullOrEmpty(smodel.DocumentType_FileName))
                                        {
                                            fileName = smodel.DocumentType_FileName.ToString();
                                        }
                                        else
                                        {
                                            fileName = "ApprovalQUpdates_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + FileExtn;
                                        }

                                        var path = Path.Combine(pathpromoterdata, fileName);
                                        files.SaveAs(path);
                                        FileAddress = fileName;
                                        FilePath = pathindb;
                                        FileName = fileName;
                                    }
                                    else
                                    {
                                        TempData["notice"] = "Document (File) Size should be less than 1MB";
                                        error = "Document (File) Size should be less than 1MB";
                                        errorstate = 1;
                                    }
                                }
                                else
                                {
                                    TempData["notice"] = "Document (File) format should be .jpg or .pdf";
                                    error = "Document (File) format should be .jpg or .pdf";
                                    errorstate = 1;
                                }
                            }
                            else
                            {
                                TempData["notice"] = "Kindly Upload Document (File)";
                                error = "Kindly Upload Document (File)";
                                errorstate = 1;

                                //update with same Document (File)
                                if (Request.Files.Count > 0 && (Request.Files[0].ContentLength == 0))
                                {
                                    errorstate = 0;
                                }

                            }
                            #endregion
                            if (errorstate == 0)
                            {
                                if (ModelState.IsValid)
                                {
                                    if (FileAddress == "")
                                    {
                                        FileAddress = smodel.DocumentType_FilePath;
                                        FileExtn = smodel.DocumentType_FileFormat;
                                        FilePath = smodel.DocumentType_FilePath;
                                        FileName = smodel.DocumentType_FileName;
                                    }
                                    try
                                    {
                                        ClsMethod_QUpdateProject_ApprovalDetails sdb = new ClsMethod_QUpdateProject_ApprovalDetails();
                                        sdb.Update_QUpdateProject_ApprovalDetails(smodel, FileName, FilePath, FileExtn, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName);
                                        TempData["message"] = "Details updated Successfully";

                                        return RedirectToAction("QUpdate_QUApprovalDetails");
                                    }
                                    catch (Exception ex)
                                    {
                                        string msg = ex.ToString();
                                        return View();
                                    }
                                }
                                return RedirectToAction("QUpdate_QUApprovalDetails");
                            }
                            else
                            {
                                return RedirectToAction("QUpdate_QUApprovalDetails");
                            }
                        }
                        //Case-B: INSERT
                        else
                        {
                            #region DocumentCertificate Save with Path
                            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
                            {
                                var files = Request.Files[0];
                                var allowedExtensions = new[] { ".Jpg", ".jpg", ".JPG", ".jpeg", ".JPEG", ".Jpeg", ".PDF", ".pdf", ".Pdf" };
                                FileExtn = Path.GetExtension(files.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(FileExtn)) //check what type of extension  
                                {
                                    int size = files.ContentLength;
                                    if (size <= 1024000)
                                    {

                                        #region Declare Variables
                                        var pathpromoterdata = "";
                                        var pathindb = "";
                                        string masterPromoterDoc_SetFilePath = "rwdataQUProject";
                                        #endregion

                                        #region SaveFile Path Creation
                                        pathindb = masterPromoterDoc_SetFilePath + "\\" + Convert.ToString(ProjectID) + "\\";
                                        pathpromoterdata = Server.MapPath("~/" + pathindb);

                                        if (!Directory.Exists(pathpromoterdata))
                                        {
                                            Directory.CreateDirectory(pathpromoterdata);
                                        }
                                        #endregion

                                        var fileName = string.Empty;
                                        fileName = "ApprovalQUpdates_" + SaveFileDatePrefix() + Guid.NewGuid().ToString() + FileExtn;
                                        var path = Path.Combine(pathpromoterdata, fileName);
                                        files.SaveAs(path);
                                        FileAddress = fileName;
                                        FilePath = pathindb;
                                        FileName = fileName;
                                    }
                                    else
                                    {
                                        TempData["notice"] = "Document (File) Size should be less than 1MB";
                                        error = "Document (File) Size should be less than 1MB";
                                        errorstate = 1;
                                    }
                                }
                                else
                                {
                                    TempData["notice"] = "Document (File) format should be .jpg or .pdf";
                                    error = "Document (File) format should be .jpg or .pdf";
                                    errorstate = 1;
                                }
                            }
                            else
                            {
                                TempData["notice"] = "Kindly Upload Document (File)";
                                error = "Kindly Upload Document (File)";
                                errorstate = 1;
                            }
                            #endregion
                            try
                            {
                                if (errorstate == 0)
                                {
                                    if (ModelState.IsValid)
                                    {
                                        if (FileAddress == "")
                                        {
                                            FileAddress = smodel.DocumentType_FilePath;
                                            FileExtn = smodel.DocumentType_FileFormat;
                                            FilePath = smodel.DocumentType_FilePath;
                                            FileName = smodel.DocumentType_FileName;
                                        }
                                        ClsMethod_QUpdateProject_ApprovalDetails sdb = new ClsMethod_QUpdateProject_ApprovalDetails();
                                        if (sdb.Add_QUpdateProject_ApprovalDetails(smodel, FileName, FilePath, FileExtn, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                                        {
                                            TempData["message"] = " Details Added Successfully";
                                            ModelState.Clear();
                                        }
                                    }
                                    return RedirectToAction("QUpdate_QUApprovalDetails");
                                }
                                else
                                {
                                    return RedirectToAction("QUpdate_QUApprovalDetails");
                                }
                            }
                            catch (Exception ex)
                            {
                                ex.ToString();
                                return View();
                            }
                        }
                    }
                    else
                    {
                        TempData["message"] = "Error! Invalid details";
                    }
                    #endregion

                }
                return RedirectToAction("QUpdate_QUApprovalDetails");
            }
            catch (Exception ex)
            {
                string retSTR = ex.ToString();
                return View();
            }
            #endregion
        }

        [HttpGet]
        public ActionResult QUpdateEdit_QUApprovalDetails(Int64 PRID, Int64 quPAIndexID, Int64 quPAID, Int64 rPAIndexID, Int64 rPAID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectApprovals_IndexID = 0;
            Int64 QUpdateProjectApprovals_ID = 0;
            Int64 Related_ProjectApprovalsIndexID = 0;
            Int64 Related_ProjectApprovalsID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectApprovals_IndexID = quPAIndexID;
            QUpdateProjectApprovals_ID = quPAID;
            Related_ProjectApprovalsIndexID = rPAIndexID;
            Related_ProjectApprovalsID = rPAID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ApprovalDetails sdb = new ClsMethod_QUpdateProject_ApprovalDetails();
            ClsPrp_QUpdateProject_ApprovalDetails aa = new ClsPrp_QUpdateProject_ApprovalDetails();            
            aa.prpongoing = sdb.Display_QUpdateProject_ApprovalDetailsById(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, Related_ProjectApprovalsIndexID, Related_ProjectApprovalsID, QUpdateProjectApprovals_IndexID, QUpdateProjectApprovals_ID);

            if (aa.prpongoing.Count > 0)
            {
                foreach (var item in aa.prpongoing)
                {
                    aa.QUpdateProjectApproval_IndexID = item.QUpdateProjectApproval_IndexID;
                    aa.QUpdateProjectApproval_ID = item.QUpdateProjectApproval_ID;
                    aa.Related_ProjectApproval_IndexID = item.Related_ProjectApproval_IndexID;
                    aa.Related_ProjectApproval_ID = item.Related_ProjectApproval_ID;
                    aa.IsQuarterlyData = item.IsQuarterlyData;
                    aa.IsQuarterlyDataValid = item.IsQuarterlyDataValid;
                    aa.Related_ApprovalProjectRegistration_ID = item.Related_ApprovalProjectRegistration_ID;
                    aa.QUpdateApproval_Year = item.QUpdateApproval_Year;
                    aa.QUpdateApproval_QuarterName = item.QUpdateApproval_QuarterName;

                    aa.DocumentType_CategoryName = item.DocumentType_CategoryName;
                    aa.DocumentType_Code = item.DocumentType_Code;
                    aa.DocumentType_Name = item.DocumentType_Name;
                    aa.DocumentType_IfOtherSpecifyName = item.DocumentType_IfOtherSpecifyName;
                    aa.DocumentType_Status = item.DocumentType_Status;
                    aa.Date_ApplicationPlannedorExpectedReceipt = item.Date_ApplicationPlannedorExpectedReceipt;
                    aa.DocumentType_FileSize = item.DocumentType_FileSize;
                    aa.DocumentType_FileFormat = item.DocumentType_FileFormat;
                    aa.DocumentType_FilePath = item.DocumentType_FilePath;
                    aa.DocumentType_FileName = item.DocumentType_FileName;

                    aa.Remarks_IfAny = item.Remarks_IfAny;
                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;
                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsRegisteredDiaryNumberLock = item.IsRegisteredDiaryNumberLock;
                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            else
            {
                aa.QUpdateProjectApproval_IndexID = QUpdateProjectApprovals_IndexID;
                aa.QUpdateProjectApproval_ID = QUpdateProjectApprovals_ID;
                aa.Related_ProjectApproval_IndexID = Related_ProjectApprovalsIndexID;
                aa.Related_ProjectApproval_ID = Related_ProjectApprovalsID;
                aa.IsQuarterlyData = 5; // Table-2(DB Value)
                aa.Related_ApprovalProjectRegistration_ID = ProjectRegistration_ID;
                aa.QUpdateApproval_Year = Convert.ToString(ProjectQuarterYear);
                aa.QUpdateApproval_QuarterName = Convert.ToString(ProjectQuarterName);
            }
            //set default quarter year and name
            aa.QUpdateApproval_Year = Convert.ToString(ProjectQuarterYear);
            aa.QUpdateApproval_QuarterName = Convert.ToString(ProjectQuarterName);

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            string strSetSubmitValue = string.Empty;
            if (aa.QUpdateProjectApproval_IndexID == 0)
            {
                strSetSubmitValue = "Save";
            }
            else
            {
                strSetSubmitValue = "Update";
            }

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["QUpdatesSelectedYears"] = null;
            TempData["submitvalue"] = strSetSubmitValue; TempData.Keep();
            TempData["selectCntlApprovals"] = "CntlLock"; TempData.Keep();
            return View("QUpdate_QUApprovalDetails", aa);
        }

        // Delete 
        public ActionResult QUpdateDelete_QUApprovalDetails(Int64 PRID, Int64 quPAIndexID, Int64 quPAID, Int64 rPAIndexID, Int64 rPAID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectApprovals_IndexID = 0;
            Int64 QUpdateProjectApprovals_ID = 0;
            Int64 Related_ProjectApprovalsIndexID = 0;
            Int64 Related_ProjectApprovalsID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectApprovals_IndexID = quPAIndexID;
            QUpdateProjectApprovals_ID = quPAID;
            Related_ProjectApprovalsIndexID = rPAIndexID;
            Related_ProjectApprovalsID = rPAID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ApprovalDetails sdb = new ClsMethod_QUpdateProject_ApprovalDetails();
            ClsPrp_QUpdateProject_ApprovalDetails aa = new ClsPrp_QUpdateProject_ApprovalDetails();

            try
            {
                // IsRegisteredDiaryNumberLock
                Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                check_IsdraftValue = 2;
                check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                {
                    if (sdb.Delete_QUpdateProject_ApprovalDetailsById(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, Related_ProjectApprovalsIndexID, Related_ProjectApprovalsID, QUpdateProjectApprovals_IndexID, QUpdateProjectApprovals_ID))
                    {
                        TempData["message"] = " Details deleted Successfully";
                    }
                }
                else
                {
                    TempData["message"] = "Error! Invalid details";
                }
                return RedirectToAction("QUpdate_QUApprovalDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //QU-04 Detail of QUpdate Quarterly Status of Construction Photographs
        #region
        [HttpPost]
        public ActionResult DropdownlistProjectQUpdate_QUPhotographsDetails(FormCollection frm, ClsPrp_QUpdateProject_ConstructionStatusPhotographs smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();            
            TempData["SelectedItem"] = frm["ProjectPhotographsRelated_Project_ID"]; TempData.Keep();
            TempData["SelectedItemQUpdatesYear"] = frm["QUpdatePhotographs_Year"]; TempData.Keep();
            TempData["SelectedItemQUpdatesQuater"] = frm["QUpdatePhotographs_QuarterName"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectPhotographsRelated_Project_ID;
            Session["QUpdatesSelectedYears"] = smodel.QUpdatePhotographs_Year;
            Session["QUpdatesSelectedQuater"] = smodel.QUpdatePhotographs_QuarterName;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        [HttpGet]
        public ActionResult QUpdate_QUPhotographDetails()
        {
            Int64 Project_id = 0;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            ViewBag.SelectedItem = "";
            ClsMethodProject objdis = new ClsMethodProject();            
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            TempData["list"] = objdis.FillDropdown_Project_ByAppId_QuaterlyUpdates(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "QUPhotographDetails"))
            {
                Session.Remove("Project_id");
                Session.Remove("QUpdatesSelectedYears");
                Session.Remove("QUpdatesSelectedQuater");
            }
            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }            

            ClsMethod_QUpdateProject_ConstructionStatusPhotographs sdb = new ClsMethod_QUpdateProject_ConstructionStatusPhotographs();
            ClsPrp_QUpdateProject_ConstructionStatusPhotographs aa = new ClsPrp_QUpdateProject_ConstructionStatusPhotographs();

            aa.prpongoing = sdb.Display_QUpdateProject_ConstructionStatusPhotographs(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.ProjectPhotographsRelated_Project_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            aa.QUpdatePhotographs_Year = Convert.ToString(TempData["SelectedItemQUpdatesYear"]); TempData.Keep();
            aa.QUpdatePhotographs_QuarterName = Convert.ToString(TempData["SelectedItemQUpdatesQuater"]); TempData.Keep();

            aa.MasterProjectInventoryList = sdb.Display_Master_QUpdateProject_InventoryList();
            aa.MasterProjectInventoryICommonList = sdb.Display_Master_QUpdateProject_InventoryInfraCommonList();
            aa.MasterProjectPhotographStatusList = sdb.Display_Master_QUpdateProject_PhotographStatusTitleList();

            if (Session["QUpdatesSelectedYears"] != null)
            {
                aa.QUpdatePhotographs_Year = Session["QUpdatesSelectedYears"].ToString();
                aa.QUpdatePhotographs_QuarterName = Session["QUpdatesSelectedQuater"].ToString();
            }

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;
            TempData["QUpdatesIsRegisteredDiaryNumberLock"] = retDNoValue; TempData.Keep();

            aa.prpongoing.ToList().ForEach(s => s.IsRegisteredDiaryNumberLock = retDNoValue);
                        

            TempData["QUpdatesSelectedYears"] = null; ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            TempData["selectCntlPhotography"] = "CntlUnlock"; TempData.Keep();
            return View("QUpdate_QUPhotographDetails", aa);
        }

        // GET: Delete 
        public ActionResult Delete_QUPhotographDetails(Int64? inPQUPhotographsIndexID, Int64? inPQUPhotographsID, Int64? inProjectID)
        {
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            Int64 ProjectRegistration_ID = 0;
            ProjectRegistration_ID = Convert.ToInt64(inProjectID);

            try
            {
                if (Session["QUpdatesSelectedYears"] != null)
                {
                    ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                    ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
                }

                // IsRegisteredDiaryNumberLock
                Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                check_IsdraftValue = 2;
                check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                {
                    ClsMethod_QUpdateProject_ConstructionStatusPhotographs sdb = new ClsMethod_QUpdateProject_ConstructionStatusPhotographs();

                    if (sdb.Delete_ProjectQUpdate_ConstructionStatusPhotographs(inProjectID, inPQUPhotographsIndexID, inPQUPhotographsID))
                    {
                        TempData["message"] = " Details deleted Successfully";
                    }
                }
                else
                {
                    TempData["message"] = "Error! Invalid details";
                }
                return RedirectToAction("QUpdate_QUPhotographDetails");
            }
            catch(Exception ex)
            {
                string ExRet = ex.ToString();
                return RedirectToAction("QUpdate_QUPhotographDetails");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FormQUpdatePhotographUpload(HttpPostedFileBase uploadedFile, ClsPrp_QUpdateProject_ConstructionStatusPhotographs smodel)
        {
            if (Request.Files.Count > 0 && (Request.Files[0].ContentLength != 0))
            {
                if (ModelState.IsValid)
                {
                    Clsprp_Master_Project_PhotographFileSizeCount clsprp = new Clsprp_Master_Project_PhotographFileSizeCount();
                    Clsprp_Master_Project_PhotographFileSizeCount clsprpGetMaster = new Clsprp_Master_Project_PhotographFileSizeCount();
                    ClsPrp_QUpdateProject_ConstructionStatusPhotographs clsprpPrmDoc = new ClsPrp_QUpdateProject_ConstructionStatusPhotographs();
                    ClsMethod_QUpdateProject_ConstructionStatusPhotographs objProjectPhoto = new ClsMethod_QUpdateProject_ConstructionStatusPhotographs();

                    #region Declare and Set By SearchFilterCodeID
                    Int64 PromoterId = 0;
                    Int64 Application_id = 0;
                    Int64 ProjectRegID = 0;
                    Int32 ProjectQYear = 0;
                    string ProjectQname = string.Empty;
                    Int32 ConstructionCode = 0;
                    Int64 BlockCode = 0;
                    Int32 StatusConstructionCode = 0;

                    if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                    {
                        if (Session["ApplicationId"].ToString() != "0")
                        {
                            Application_id = Convert.ToInt64(Session["ApplicationId"]);
                        }
                    }
                    PromoterId = Application_id;
                    ProjectRegID = smodel.ProjectPhotographsRelated_Project_ID;
                    ProjectQYear = Convert.ToInt32(smodel.QUpdatePhotographs_Year);
                    ProjectQname = Convert.ToString(smodel.QUpdatePhotographs_QuarterName);
                    ConstructionCode = Convert.ToInt32(smodel.BuildingTowerBlock_ComArea_ConStatusCode);
                    BlockCode = Convert.ToInt64(smodel.BuildingTowerBlock_InfoCode);
                    StatusConstructionCode = Convert.ToInt32(smodel.Photographs_Title);
                    #endregion

                    #region Read Master Data By Document Type
                    Tuple<Int64, Int64, Int64, Int64> tupleSumCntFile = objProjectPhoto.Display_ProjectQUpdate_ConstructionStatusPhotographs_ByDocCodeByID(PromoterId, ProjectRegID, ProjectQYear, ProjectQname, ConstructionCode, 0, StatusConstructionCode);
                    clsprp.MasterPhotographFileSizeCount = objProjectPhoto.Display_Master_ProjectQUpdate_ConstructionStatusPhotographsByID(PromoterId, ProjectRegID, ConstructionCode, StatusConstructionCode);
                    
                    foreach (var item in clsprp.MasterPhotographFileSizeCount)
                    {
                        if (item.StatusTitleList_ID == StatusConstructionCode)
                        {
                            clsprpGetMaster.StatusTitleList_IndexID = item.StatusTitleList_IndexID;
                            clsprpGetMaster.StatusTitleList_ID = item.StatusTitleList_ID;
                            clsprpGetMaster.StatusTitleListName = item.StatusTitleListName;
                            clsprpGetMaster.StatusTitleListDescription = item.StatusTitleListDescription;
                            clsprpGetMaster.StatusImg_RelatedSectionName = item.StatusImg_RelatedSectionName;
                            clsprpGetMaster.StatusImg_SetFileSize = item.StatusImg_SetFileSize;
                            clsprpGetMaster.StatusImg_SetFileFormat = item.StatusImg_SetFileFormat;
                            clsprpGetMaster.StatusImg_SetFilePath = item.StatusImg_SetFilePath;
                            clsprpGetMaster.StatusTitleFlag = item.StatusTitleFlag;
                            clsprpGetMaster.StatusImg_ValidCode = item.StatusImg_ValidCode;
                            clsprpGetMaster.StatusImg_ValidSubCode = item.StatusImg_ValidSubCode;
                            clsprpGetMaster.IsGroup = item.IsGroup;
                            clsprpGetMaster.IsMandatory = item.IsMandatory;
                            clsprpGetMaster.A_column = item.A_column;
                            clsprpGetMaster.B_column = item.B_column;
                            clsprpGetMaster.IsActive = item.IsActive;
                            clsprpGetMaster.CreatedBy = item.CreatedBy;
                            clsprpGetMaster.CreatedOn = item.CreatedOn;
                            clsprpGetMaster.ModifyBy = item.ModifyBy;
                            clsprpGetMaster.ModifyOn = item.ModifyOn;
                        }
                    }
                    #endregion

                    #region Declare Variables
                    var path = "";
                    var pathindb = "";
                    var savefileName = "";
                    string extensionPhotoIdentityDocument = string.Empty;
                    int byteCountPhotoIdentityDocument = 0;
                    Int32 masterGetPhotoIdentityDocument = 0;
                    Int32 extensionPutPhotoIdentityDocument = 0;
                    string masterGetExnPhotoIdentityDocument = string.Empty;
                    Int32 masterPutPhotoIdentityDocument = 0;
                    string masterProjectPhoto_SetFilePath = "rwQUPrjGeoImg";
                    Int32 masterSetUploadFileLimitCount = 0;
                    Int64 masterSetUploadFileLimitSize = 0;
                    Int32 masterSetMaxUploadFileLimitCount = 0;
                    Int64 masterSetMaxUploadFileLimitSize = 0;
                    string masterSetFileName = string.Empty;
                    bool IsValidFileType = false;
                    #endregion

                    //Bad Request - No Doc
                    if (Request.Files.Count > 0)
                    {
                        #region Step-I
                        TempData["QUpdatesSelectedYears"] = Convert.ToInt32(smodel.QUpdatePhotographs_Year);
                        Session["QUpdatesSelectedYears"] = Convert.ToInt32(smodel.QUpdatePhotographs_Year);
                        Session["QUpdatesSelectedQuater"] = Convert.ToString(smodel.QUpdatePhotographs_QuarterName);

                        //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
                        Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
                        retDNoValue = 2;
                        retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegID, ProjectQYear, ProjectQname);
                        clsprpPrmDoc.IsRegisteredDiaryNumberLock = retDNoValue;
                        if (retDNoValue == 0 || retDNoValue == 2)
                        {
                            #region Step-II
                            var PhotoIdentityDocument = Request.Files[0];

                            //Bad Request - No Doc OR No Size
                            if (PhotoIdentityDocument != null && PhotoIdentityDocument.ContentLength > 0)
                            {
                                #region Step-III
                                #region SaveFile Path Creation
                                if (clsprpGetMaster.StatusImg_SetFilePath.ToString() != string.Empty || clsprpGetMaster.StatusImg_SetFilePath.ToString() != null)
                                {
                                    masterProjectPhoto_SetFilePath = clsprpGetMaster.StatusImg_SetFilePath.ToString();
                                }
                                pathindb = masterProjectPhoto_SetFilePath + "\\" + Convert.ToString(DateTime.Now.Year) + "\\" + Convert.ToString(ProjectRegID) + "\\";
                                path = Server.MapPath("~/" + pathindb);

                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                #endregion                                
                                #region Master File Type Check
                                //Upload File Type
                                extensionPhotoIdentityDocument = Path.GetExtension(PhotoIdentityDocument.FileName);
                                switch (extensionPhotoIdentityDocument)
                                {
                                    case ".JPEG":
                                    case ".jpeg":
                                    case ".JPG":
                                    case ".jpg":
                                    case ".PNG":
                                    case ".png":
                                        {
                                            //Image Type
                                            extensionPutPhotoIdentityDocument = 102;
                                            break;
                                        }
                                    case ".PDF":
                                    case ".pdf":
                                        {
                                            //PDF Type
                                            extensionPutPhotoIdentityDocument = 103;
                                            break;
                                        }
                                }

                                //Master File Type
                                masterGetExnPhotoIdentityDocument = Convert.ToString(clsprpGetMaster.StatusImg_SetFileFormat);
                                switch (masterGetExnPhotoIdentityDocument)
                                {
                                    case "JPEG/JPG/PDF":
                                        {
                                            //Both Image and PDF Type
                                            masterPutPhotoIdentityDocument = 101;
                                            break;
                                        }
                                    case "JPEG/JPG":
                                    case "JPEG":
                                    case "JPG":
                                        {
                                            //Image Type
                                            masterPutPhotoIdentityDocument = 102;
                                            break;
                                        }
                                    case "PDF":
                                        {
                                            //PDF Type
                                            masterPutPhotoIdentityDocument = 103;
                                            break;
                                        }
                                }

                                //Master File Type: To check valid document/image extension
                                if (masterPutPhotoIdentityDocument == 101)
                                {
                                    //File with all extension allowed
                                    if (extensionPutPhotoIdentityDocument == 102 || extensionPutPhotoIdentityDocument == 103)
                                    {
                                        IsValidFileType = true;
                                    }
                                }
                                else
                                {
                                    if (extensionPutPhotoIdentityDocument == masterPutPhotoIdentityDocument)
                                    {
                                        IsValidFileType = true;
                                    }
                                }
                                #endregion

                                #region Master Set FileName
                                //Check File Type and Set Master File Limit

                                masterSetUploadFileLimitCount = Convert.ToInt32(clsprpGetMaster.IsGroup);
                                masterSetUploadFileLimitSize = Convert.ToInt64(clsprpGetMaster.StatusImg_SetFileSize);
                                masterSetMaxUploadFileLimitCount = Convert.ToInt32(clsprpGetMaster.A_column);
                                masterSetMaxUploadFileLimitSize = Convert.ToInt64(clsprpGetMaster.B_column);

                                masterGetPhotoIdentityDocument = smodel.BuildingTowerBlock_ComArea_ConStatusCode;
                                if (masterGetPhotoIdentityDocument == 1)
                                {                                    
                                    masterSetFileName = "QUPrjAdvImg";                                    
                                }
                                else if (masterGetPhotoIdentityDocument == 2)
                                {                                   
                                    masterSetFileName = "QUPrjContImg";                                    
                                }
                                else if (masterGetPhotoIdentityDocument == 3)
                                {                                    
                                    masterSetFileName = "QUPrjInfCAImg";                                    
                                }
                                #endregion

                                //Check Number of Files Uploaded
                                if(tupleSumCntFile.Item4 < masterSetMaxUploadFileLimitCount)
                                {
                                    #region Step-IV
                                    if (tupleSumCntFile.Item2 < masterSetUploadFileLimitCount)
                                    {
                                        #region Step-V                                
                                        if (IsValidFileType)
                                        {
                                            #region Step-VI
                                            if (tupleSumCntFile.Item3 <= masterSetMaxUploadFileLimitSize)
                                            {
                                                byteCountPhotoIdentityDocument = PhotoIdentityDocument.ContentLength;

                                                if (byteCountPhotoIdentityDocument <= masterSetUploadFileLimitSize)
                                                {
                                                    savefileName = RegexRemove(SaveFileDatePrefix() + masterSetFileName + Guid.NewGuid().ToString() + extensionPhotoIdentityDocument);
                                                    var pathsavefile = Path.Combine(path, savefileName);
                                                    PhotoIdentityDocument.SaveAs(pathsavefile);

                                                    var pathsavedb = Path.Combine(pathindb, savefileName);

                                                    Int64 QUfilePromoterID = PromoterId;
                                                    string QUfileDoc_FilePath = pathsavedb;
                                                    string QUfileDoc_FileName = savefileName;
                                                    string QUfileDoc_FileSize = Convert.ToString(byteCountPhotoIdentityDocument);
                                                    string QUfileDoc_FileFormat = extensionPhotoIdentityDocument;
                                                    Int32 QUfileDoc_IsGroup = Convert.ToInt32(1);

                                                    bool varRet = SaveQUpdateProjectPhotographs(smodel, QUfilePromoterID, QUfileDoc_FilePath, QUfileDoc_FileName, QUfileDoc_FileSize, QUfileDoc_FileFormat, QUfileDoc_IsGroup);

                                                    if (varRet != false)
                                                    {
                                                        return Json(new
                                                        {
                                                            //Data = "Complete",
                                                            statusCode = 101,
                                                            status = "Complete",
                                                            remarks = "Successfully uplaoded"
                                                        }, JsonRequestBehavior.AllowGet);
                                                    }
                                                    else
                                                    {
                                                        return Json(new
                                                        {
                                                            //Data = "Bad Request! Upload Failed",
                                                            statusCode = 105,
                                                            status = "Bad Request! Upload Failed",
                                                            remarks = "Not Saved! Upload Failed "
                                                        }, JsonRequestBehavior.AllowGet);
                                                    }
                                                }
                                                else
                                                {
                                                    decimal varSetFileSize = 0;
                                                    string varOutSetFileSize = string.Empty;
                                                    varSetFileSize = Convert.ToInt32(masterSetUploadFileLimitSize);

                                                    if (varSetFileSize > 1048576)
                                                    {
                                                        varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1048576) / 100 + " MB";
                                                    }
                                                    else if (varSetFileSize > 1024)
                                                    {
                                                        varOutSetFileSize = Math.Round(varSetFileSize * 100 / 1024) / 100 + " KB";
                                                    }
                                                    else
                                                    {
                                                        varOutSetFileSize = varSetFileSize + " Bytes";
                                                    }

                                                    return Json(new
                                                    {
                                                        //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                        statusCode = 103,
                                                        status = "File size should be less than " + varOutSetFileSize,
                                                        remarks = uploadedFile.FileName
                                                    }, JsonRequestBehavior.AllowGet);
                                                }
                                            }
                                            else
                                            {
                                                decimal varSetGroupFileSize = 0;
                                                string varOutSetGroupFileSize = string.Empty;

                                                varSetGroupFileSize = Convert.ToInt64(tupleSumCntFile.Item1);

                                                if (varSetGroupFileSize > 1048576)
                                                {
                                                    varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1048576) / 100 + " MB";
                                                }
                                                else if (varSetGroupFileSize > 1024)
                                                {
                                                    varOutSetGroupFileSize = Math.Round(varSetGroupFileSize * 100 / 1024) / 100 + " KB";
                                                }
                                                else
                                                {
                                                    varOutSetGroupFileSize = varSetGroupFileSize + " Bytes";
                                                }


                                                return Json(new
                                                {
                                                    //Data = "Size less, File Name: " + uploadedFile.FileName,
                                                    statusCode = 107,
                                                    status = "Maximum number of uploaded files size limit reached. (Max Size " + Convert.ToString(varOutSetGroupFileSize) + ".)",
                                                    remarks = uploadedFile.FileName
                                                }, JsonRequestBehavior.AllowGet);
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            return Json(new
                                            {
                                                //Data = "Format not match, File Name: " + uploadedFile.FileName,
                                                statusCode = 104,
                                                status = "File format not matched.",
                                                remarks = uploadedFile.FileName
                                            }, JsonRequestBehavior.AllowGet);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        return Json(new
                                        {
                                            //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
                                            statusCode = 106,
                                            status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(masterSetUploadFileLimitCount) + " files.)",
                                            remarks = uploadedFile.FileName
                                        }, JsonRequestBehavior.AllowGet);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    return Json(new
                                    {
                                        //Data = "Invalid Maximum number of uploaed files limit, File Name: " + uploadedFile.FileName,
                                        statusCode = 106,
                                        status = "Maximum number of uploaded files limit reached. (Maximum " + Convert.ToString(masterSetMaxUploadFileLimitCount) + " files.)",
                                        remarks = uploadedFile.FileName
                                    }, JsonRequestBehavior.AllowGet);
                                }                               
                                #endregion
                            }
                            else
                            {
                                return Json(new
                                {
                                    //Data = "Bad Request! Upload Failed",
                                    statusCode = 102,
                                    status = "Bad Request! Upload Failed",
                                    remarks = string.Empty
                                }, JsonRequestBehavior.AllowGet);
                            }
                            #endregion
                        }
                        else
                        {
                            return Json(new
                            {
                                //Data = "Bad Request! Upload Failed",
                                statusCode = 102,
                                status = "Invalid uploads! Upload Failed",
                                remarks = string.Empty
                            }, JsonRequestBehavior.AllowGet);
                        }
                        #endregion
                    }
                    else
                    {
                        return Json(new
                        {
                            //Data = "Bad Request! Upload Failed",
                            statusCode = 102,
                            status = "Bad Request! Upload Failed",
                            remarks = string.Empty
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        //Data = "Bad Request! Upload Failed",
                        statusCode = 102,
                        status = "Mandatory field(s) required! Upload Failed",
                        remarks = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    //Data = "Bad Request! Upload Failed",
                    statusCode = 102,
                    status = "Bad Request! Upload Failed",
                    remarks = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
        }

        private bool SaveQUpdateProjectPhotographs(ClsPrp_QUpdateProject_ConstructionStatusPhotographs smodel, Int64 QUpdatePromoterID, String QUpdateDocFilePath, String QUpdateDocFileName, String QUpdateDocFileSize, String QUpdateDocFileFormat, Int32 QUpdateDocIsGroup)
        {
            Int64 QUPrjPromoterID = 0;
            QUPrjPromoterID = QUpdatePromoterID;
            string QUPrjDocFilePath = String.IsNullOrEmpty(QUpdateDocFilePath) ? string.Empty : QUpdateDocFilePath;
            string QUPrjDocFileName = String.IsNullOrEmpty(QUpdateDocFileName) ? string.Empty : QUpdateDocFileName;
            string QUPrjDocFileSize = String.IsNullOrEmpty(QUpdateDocFileSize) ? string.Empty : QUpdateDocFileSize;
            string QUPrjDocFileFormat = String.IsNullOrEmpty(QUpdateDocFileFormat) ? string.Empty : QUpdateDocFileFormat;
            Int32 QUPrjDocIsGroup = QUpdateDocIsGroup;
            bool varRET = false;

            TempData["QUpdatesSelectedYears"] = Convert.ToInt32(smodel.QUpdatePhotographs_Year);
            Session["QUpdatesSelectedYears"] = Convert.ToInt32(smodel.QUpdatePhotographs_Year);
            Session["QUpdatesSelectedQuater"] = Convert.ToString(smodel.QUpdatePhotographs_QuarterName);

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_QUpdateProject_ConstructionStatusPhotographs savedb = new ClsMethod_QUpdateProject_ConstructionStatusPhotographs();

                    //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
                    // IsRegisteredDiaryNumberLock
                    Int32 check_IsdraftValue = 0; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                    check_IsdraftValue = 2;
                    //check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                    if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                    {
                        if (savedb.Add_ProjectQUpdate_ConstructionStatusPhotographs(smodel, QUPrjPromoterID, QUPrjDocFilePath, QUPrjDocFileName, QUPrjDocFileSize, QUPrjDocFileFormat, QUPrjDocIsGroup, userName))
                        {
                            varRET = true;
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        TempData["message"] = "Error! Record Cannot be added";
                    }
                }
            }
            catch (Exception ex)
            {
                string varExMsg = ex.Message;
                varRET = false;
            }
            return varRET;
        }
        #endregion

        // Detail of Project Internal Facilities(If Any)
        #region
        [HttpPost]
        public ActionResult DropdownlistProjectQUpdate_QUInternalFacilities(FormCollection frm, ClsPrp_QUpdateProject_InternalInfrastructure_Facilities smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]; TempData.Keep();
            TempData["SelectedItemQUpdatesYear"] = frm["QUpdateInfraFacilities_Year"]; TempData.Keep();
            TempData["SelectedItemQUpdatesQuater"] = frm["QUpdateInfraFacilities_QuarterName"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
            Session["QUpdatesSelectedYears"] = smodel.QUpdateInfraFacilities_Year;
            Session["QUpdatesSelectedQuater"] = smodel.QUpdateInfraFacilities_QuarterName;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        [HttpGet]
        public ActionResult QUpdate_QUInternalFacilities()
        {
            Int64 Project_id = 0;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_QuaterlyUpdates(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "QUInternalFacilities"))
            {
                Session.Remove("Project_id");
                Session.Remove("QUpdatesSelectedYears");
                Session.Remove("QUpdatesSelectedQuater");
            }
            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_InternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_InternalInfrastructure_Facilities();
            ClsPrp_QUpdateProject_InternalInfrastructure_Facilities aa = new ClsPrp_QUpdateProject_InternalInfrastructure_Facilities();

            aa.prpongoing = sdb.Display_QUpdateProject_InternalInfrastructure_Facilities(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            aa.QUpdateInfraFacilities_Year = Convert.ToString(TempData["SelectedItemQUpdatesYear"]); TempData.Keep();
            aa.QUpdateInfraFacilities_QuarterName = Convert.ToString(TempData["SelectedItemQUpdatesQuater"]); TempData.Keep();

            if (Session["QUpdatesSelectedYears"] != null)
            {
                aa.QUpdateInfraFacilities_Year = Session["QUpdatesSelectedYears"].ToString();
                aa.QUpdateInfraFacilities_QuarterName = Session["QUpdatesSelectedQuater"].ToString();
            }

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            aa.prpongoing.ToList().ForEach(s => s.IsRegisteredDiaryNumberLock = retDNoValue);

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            TempData["QUpdatesSelectedYears"] = null; ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            TempData["selectCntlInternalFacilities"] = "CntlUnlock"; TempData.Keep();
            return View("QUpdate_QUInternalFacilities", aa);
        }

        [HttpGet]
        public ActionResult QUpdateEdit_QUInternalFacilities(Int64 PRID, Int64 quPIFIndexID, Int64 quPIFID, Int64 rPIFIndexID, Int64 rPFIID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectInfraFacilities_IndexID = 0;
            Int64 QUpdateProjectInfraFacilities_ID = 0;
            Int64 Related_ProjectInfrastructureFacilitiesIndexID = 0;
            Int64 Related_ProjectInfrastructureFacilitiesID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectInfraFacilities_IndexID = quPIFIndexID;
            QUpdateProjectInfraFacilities_ID = quPIFID;
            Related_ProjectInfrastructureFacilitiesIndexID = rPIFIndexID;
            Related_ProjectInfrastructureFacilitiesID = rPFIID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_InternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_InternalInfrastructure_Facilities();
            ClsPrp_QUpdateProject_InternalInfrastructure_Facilities aa = new ClsPrp_QUpdateProject_InternalInfrastructure_Facilities();

            aa.prpongoing = sdb.Display_QUpdateProject_InternalInfrastructure_FacilitiesByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectInfraFacilities_IndexID, QUpdateProjectInfraFacilities_ID, Related_ProjectInfrastructureFacilitiesIndexID, Related_ProjectInfrastructureFacilitiesID);
            
            if (aa.prpongoing.Count > 0)
            {
                foreach (var item in aa.prpongoing)
                {
                    aa.QUpdateProjectInfraFacilities_IndexID = item.QUpdateProjectInfraFacilities_IndexID;
                    aa.QUpdateProjectInfraFacilities_ID = item.QUpdateProjectInfraFacilities_ID;
                    aa.Related_ProjectInfrastructureFacilitiesIndexID = item.Related_ProjectInfrastructureFacilitiesIndexID;
                    aa.Related_ProjectInfrastructureFacilitiesID = item.Related_ProjectInfrastructureFacilitiesID;
                    aa.IsQuarterlyData = item.IsQuarterlyData;
                    aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = item.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
                    aa.QUpdateInfraFacilities_Year = item.QUpdateInfraFacilities_Year;
                    aa.QUpdateInfraFacilities_QuarterName = item.QUpdateInfraFacilities_QuarterName;

                    aa.InternalInfrastructureFacilities_Name = item.InternalInfrastructureFacilities_Name;
                    aa.InternalInfrastructureFacilities_Type = item.InternalInfrastructureFacilities_Type;
                    aa.ExternalAgency_LocalAuthority_Name = item.ExternalAgency_LocalAuthority_Name;
                    aa.Is_InternalInfrastructureFacilitiesApplicable = item.Is_InternalInfrastructureFacilitiesApplicable;

                    aa.WorkProgress_PercentageUptoRegistration = item.WorkProgress_PercentageUptoRegistration;
                    aa.InternalInfrastructureFacilitiesUptoRegistration_Details = item.InternalInfrastructureFacilitiesUptoRegistration_Details;
                    aa.WorkProgress_PercentageInQuarter = item.WorkProgress_PercentageInQuarter;
                    aa.InternalInfrastructureFacilitiesInQuarter_Details = item.InternalInfrastructureFacilitiesInQuarter_Details;
                    aa.WorkProgress_PercentageTotal = item.WorkProgress_PercentageTotal;

                    aa.Remarks_IfAny = item.Remarks_IfAny;
                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsRegisteredDiaryNumberLock = item.IsRegisteredDiaryNumberLock;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            else
            {
                aa.QUpdateProjectInfraFacilities_IndexID = QUpdateProjectInfraFacilities_IndexID;
                aa.QUpdateProjectInfraFacilities_ID = QUpdateProjectInfraFacilities_ID;
                aa.Related_ProjectInfrastructureFacilitiesIndexID = Related_ProjectInfrastructureFacilitiesIndexID;
                aa.Related_ProjectInfrastructureFacilitiesID = Related_ProjectInfrastructureFacilitiesID;
                aa.IsQuarterlyData = 5; // Table-2(DB Value)
                aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = ProjectRegistration_ID;
                aa.QUpdateInfraFacilities_Year = Convert.ToString(ProjectQuarterYear);
                aa.QUpdateInfraFacilities_QuarterName = Convert.ToString(ProjectQuarterName);
            }
            //set default quarter year and name
            aa.QUpdateInfraFacilities_Year = Convert.ToString(ProjectQuarterYear);
            aa.QUpdateInfraFacilities_QuarterName = Convert.ToString(ProjectQuarterName);

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            string strSetSubmitValue = string.Empty;
            if (aa.QUpdateProjectInfraFacilities_IndexID == 0)
            {
                strSetSubmitValue = "Save";
            }
            else
            {
                strSetSubmitValue = "Update";
            }

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["QUpdatesSelectedYears"] = null;
            TempData["submitvalue"] = strSetSubmitValue; TempData.Keep();
            TempData["selectCntlInternalFacilities"] = "CntlLock"; TempData.Keep();
            return View("QUpdate_QUInternalFacilities", aa);
        }

        [HttpPost]
        public ActionResult QUpdateEdit_QUInternalFacilities(ClsPrp_QUpdateProject_InternalInfrastructure_Facilities smodel)
        {
            ViewBag.Years = GetQuarterlyUpdateYears();
            //TempData["CurrentYears"] = smodel.B_column;
            //Session["CurrentYears"] = smodel.B_column;
            //Session["PresentQuater"] = smodel.A_column;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                ProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = ProjectID;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            //Save & Update
            #region
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_QUpdateProject_InternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_InternalInfrastructure_Facilities();

                    // IsRegisteredDiaryNumberLock
                    Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                    check_IsdraftValue = 2;
                    check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectID, ProjectQuarterYear, ProjectQuarterName);
                    if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                    {
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            if (sdb.Update_QUpdateProject_InternalInfrastructure_Facilities(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details updated Successfully";
                                ModelState.Clear();
                            }
                        }
                        else
                        {
                            if (sdb.Add_QUpdateProject_InternalInfrastructure_Facilities(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        TempData["message"] = "Error! Invalid details";
                    }
                }
                return RedirectToAction("QUpdate_QUInternalFacilities");
            }
            catch (Exception ex)
            {
                string retSTR = ex.ToString();
                return View();
            }
            #endregion
        }
        
        // Delete 
        public ActionResult QUpdateDelete_QUInternalFacilities(Int64 PRID, Int64 quPIFIndexID, Int64 quPIFID, Int64 rPIFIndexID, Int64 rPFIID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectInfraFacilities_IndexID = 0;
            Int64 QUpdateProjectInfraFacilities_ID = 0;
            Int64 Related_ProjectInfrastructureFacilitiesIndexID = 0;
            Int64 Related_ProjectInfrastructureFacilitiesID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectInfraFacilities_IndexID = quPIFIndexID;
            QUpdateProjectInfraFacilities_ID = quPIFID;
            Related_ProjectInfrastructureFacilitiesIndexID = rPIFIndexID;
            Related_ProjectInfrastructureFacilitiesID = rPFIID;            

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_InternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_InternalInfrastructure_Facilities();
            ClsPrp_QUpdateProject_InternalInfrastructure_Facilities aa = new ClsPrp_QUpdateProject_InternalInfrastructure_Facilities();

            try
            {
                // IsRegisteredDiaryNumberLock
                Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                check_IsdraftValue = 2;
                check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                {
                    if (sdb.Delete_QUpdateProject_InternalInfrastructure_FacilitiesByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectInfraFacilities_IndexID, QUpdateProjectInfraFacilities_ID, Related_ProjectInfrastructureFacilitiesIndexID, Related_ProjectInfrastructureFacilitiesID))
                    {
                        TempData["message"] = " Details deleted Successfully";
                    }
                }
                else
                {
                    TempData["message"] = "Error! Invalid details";
                }
                return RedirectToAction("QUpdate_QUInternalFacilities");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        // Detail of Project External Facilities(If Any)
        #region
        [HttpPost]
        public ActionResult DropdownlistProjectQUpdate_QUExternalFacilities(FormCollection frm, ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID"]; TempData.Keep();
            TempData["SelectedItemQUpdatesYear"] = frm["QUpdateInfraExFacilities_Year"]; TempData.Keep();
            TempData["SelectedItemQUpdatesQuater"] = frm["QUpdateInfraExFacilities_QuarterName"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
            Session["QUpdatesSelectedYears"] = smodel.QUpdateInfraExFacilities_Year;
            Session["QUpdatesSelectedQuater"] = smodel.QUpdateInfraExFacilities_QuarterName;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());
        }

        [HttpGet]
        public ActionResult QUpdate_QUExternalFacilities()
        {
            Int64 Project_id = 0;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis.FillDropdown_Project_ByAppId_QuaterlyUpdates(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "QUExternalFacilities"))
            {
                Session.Remove("Project_id");
                Session.Remove("QUpdatesSelectedYears");
                Session.Remove("QUpdatesSelectedQuater");
            }
            else
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities();
            ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities aa = new ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities();

            aa.prpongoing = sdb.Display_QUpdateProject_ExternalInfrastructure_Facilities(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            aa.QUpdateInfraExFacilities_Year = Convert.ToString(TempData["SelectedItemQUpdatesYear"]); TempData.Keep();
            aa.QUpdateInfraExFacilities_QuarterName = Convert.ToString(TempData["SelectedItemQUpdatesQuater"]); TempData.Keep();

            if (Session["QUpdatesSelectedYears"] != null)
            {
                aa.QUpdateInfraExFacilities_Year = Session["QUpdatesSelectedYears"].ToString();
                aa.QUpdateInfraExFacilities_QuarterName = Session["QUpdatesSelectedQuater"].ToString();
            }

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber, 9-Closed QUP system
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(Project_id, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            aa.prpongoing.ToList().ForEach(s => s.IsRegisteredDiaryNumberLock = retDNoValue);

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            TempData["QUpdatesSelectedYears"] = null; ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            TempData["selectCntlExternalFacilities"] = "CntlUnlock"; TempData.Keep();
            return View("QUpdate_QUExternalFacilities", aa);
        }

        [HttpGet]
        public ActionResult QUpdateEdit_QUExternalFacilities(Int64 PRID, Int64 quPXIFIndexID, Int64 quPXIFID, Int64 rPXIFIndexID, Int64 rPXFIID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectInfraExFacilities_IndexID = 0;
            Int64 QUpdateProjectInfraExFacilities_ID = 0;
            Int64 Related_ProjectInfrastructureExFacilitiesIndexID = 0;
            Int64 Related_ProjectInfrastructureExFacilitiesID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectInfraExFacilities_IndexID = quPXIFIndexID;
            QUpdateProjectInfraExFacilities_ID = quPXIFID;
            Related_ProjectInfrastructureExFacilitiesIndexID = rPXIFIndexID;
            Related_ProjectInfrastructureExFacilitiesID = rPXFIID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities();
            ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities aa = new ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities();

            aa.prpongoing = sdb.Display_QUpdateProject_ExternalInfrastructure_FacilitiesByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectInfraExFacilities_IndexID, QUpdateProjectInfraExFacilities_ID, Related_ProjectInfrastructureExFacilitiesIndexID, Related_ProjectInfrastructureExFacilitiesID);

            if (aa.prpongoing.Count > 0)
            {
                foreach (var item in aa.prpongoing)
                {
                    aa.QUpdateProjectInfraExFacilities_IndexID = item.QUpdateProjectInfraExFacilities_IndexID;
                    aa.QUpdateProjectInfraExFacilities_ID = item.QUpdateProjectInfraExFacilities_ID;
                    aa.Related_ProjectInfrastructureExFacilitiesIndexID = item.Related_ProjectInfrastructureExFacilitiesIndexID;
                    aa.Related_ProjectInfrastructureExFacilitiesID = item.Related_ProjectInfrastructureExFacilitiesID;
                    aa.IsQuarterlyData = item.IsQuarterlyData;
                    aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = item.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID;
                    aa.QUpdateInfraExFacilities_Year = item.QUpdateInfraExFacilities_Year;
                    aa.QUpdateInfraExFacilities_QuarterName = item.QUpdateInfraExFacilities_QuarterName;

                    aa.ExternalInfrastructureFacilities_Name = item.ExternalInfrastructureFacilities_Name;
                    aa.ExternalInfrastructureFacilities_Type = item.ExternalInfrastructureFacilities_Type;
                    aa.ExternalAgency_LocalAuthority_Name = item.ExternalAgency_LocalAuthority_Name;
                    aa.Is_InternalInfrastructureFacilitiesApplicable = item.Is_InternalInfrastructureFacilitiesApplicable;

                    aa.WorkProgress_PercentageUptoRegistration = item.WorkProgress_PercentageUptoRegistration;
                    aa.ExternalInfrastructureFacilitiesUptoRegistration_Details = item.ExternalInfrastructureFacilitiesUptoRegistration_Details;
                    aa.WorkProgress_PercentageInQuarter = item.WorkProgress_PercentageInQuarter;
                    aa.ExternalInfrastructureFacilitiesInQuarter_Details = item.ExternalInfrastructureFacilitiesInQuarter_Details;
                    aa.WorkProgress_PercentageTotal = item.WorkProgress_PercentageTotal;

                    aa.Remarks_IfAny = item.Remarks_IfAny;
                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsRegisteredDiaryNumberLock = item.IsRegisteredDiaryNumberLock;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            else
            {
                aa.QUpdateProjectInfraExFacilities_IndexID = QUpdateProjectInfraExFacilities_IndexID;
                aa.QUpdateProjectInfraExFacilities_ID = QUpdateProjectInfraExFacilities_ID;
                aa.Related_ProjectInfrastructureExFacilitiesIndexID = Related_ProjectInfrastructureExFacilitiesIndexID;
                aa.Related_ProjectInfrastructureExFacilitiesID = Related_ProjectInfrastructureExFacilitiesID;
                aa.IsQuarterlyData = 5; // Table-2(DB Value)
                aa.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = ProjectRegistration_ID;
                aa.QUpdateInfraExFacilities_Year = Convert.ToString(ProjectQuarterYear);
                aa.QUpdateInfraExFacilities_QuarterName = Convert.ToString(ProjectQuarterName);
            }
            //set default quarter year and name
            aa.QUpdateInfraExFacilities_Year = Convert.ToString(ProjectQuarterYear);
            aa.QUpdateInfraExFacilities_QuarterName = Convert.ToString(ProjectQuarterName);

            //1-Registered DiaryNumber, 2-Open DiaryNumber Or NotConfirmed DiaryNumber
            Int32 retDNoValue = 0;//Get Value From DiaryNumber Table
            retDNoValue = 2;
            retDNoValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
            aa.IsRegisteredDiaryNumberLock = retDNoValue;

            string strSetSubmitValue = string.Empty;
            if (aa.QUpdateProjectInfraExFacilities_IndexID == 0)
            {
                strSetSubmitValue = "Save";
            }
            else
            {
                strSetSubmitValue = "Update";
            }

            ViewBag.EmployeeDetailsGrid = aa.prpongoing;
            ViewBag.Years = GetQuarterlyUpdateYears();
            TempData["QUpdatesSelectedYears"] = null;
            TempData["submitvalue"] = strSetSubmitValue; TempData.Keep();
            TempData["selectCntlExternalFacilities"] = "CntlLock"; TempData.Keep();
            return View("QUpdate_QUExternalFacilities", aa);
        }

        [HttpPost]
        public ActionResult QUpdateEdit_QUExternalFacilities(ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities smodel)
        {
            ViewBag.Years = GetQuarterlyUpdateYears();
            //TempData["CurrentYears"] = smodel.B_column;
            //Session["CurrentYears"] = smodel.B_column;
            //Session["PresentQuater"] = smodel.A_column;
            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            Int64 ProjectID = 0;
            if (Session["Project_id"] != null)
            {
                ProjectID = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectInfrastructureFacilitiesRelated_ProjectRegistration_ID = ProjectID;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            //Save & Update
            #region
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities();

                    // IsRegisteredDiaryNumberLock
                    Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                    check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectID, ProjectQuarterYear, ProjectQuarterName);
                    //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                    if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                    {
                        if (TempData["submitvalue"].ToString() == "Update")
                        {
                            if (sdb.Update_QUpdateProject_ExternalInfrastructure_Facilities(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details updated Successfully";
                                ModelState.Clear();
                            }
                        }
                        else
                        {
                            if (sdb.Add_QUpdateProject_ExternalInfrastructure_Facilities(smodel, ProjectID, ProjectQuarterYear, ProjectQuarterName, userName))
                            {
                                TempData["message"] = "Details Added Successfully";
                                ModelState.Clear();
                            }
                        }
                    }
                    else
                    {
                        TempData["message"] = "Error! Invalid details";
                    }
                }
                return RedirectToAction("QUpdate_QUExternalFacilities");
            }
            catch (Exception ex)
            {
                string retSTR = ex.ToString();
                return View();
            }
            #endregion
        }

        // Delete 
        public ActionResult QUpdateDelete_QUExternalFacilities(Int64 PRID, Int64 quPXIFIndexID, Int64 quPXIFID, Int64 rPXIFIndexID, Int64 rPXFIID)
        {
            Int64 ProjectRegistration_ID = 0;
            Int64 QUpdateProjectInfraExFacilities_IndexID = 0;
            Int64 QUpdateProjectInfraExFacilities_ID = 0;
            Int64 Related_ProjectInfrastructureExFacilitiesIndexID = 0;
            Int64 Related_ProjectInfrastructureExFacilitiesID = 0;

            ProjectRegistration_ID = PRID;
            QUpdateProjectInfraExFacilities_IndexID = quPXIFIndexID;
            QUpdateProjectInfraExFacilities_ID = quPXIFID;
            Related_ProjectInfrastructureExFacilitiesIndexID = rPXIFIndexID;
            Related_ProjectInfrastructureExFacilitiesID = rPXFIID;

            Int32 ProjectQuarterYear = 0;
            string ProjectQuarterName = string.Empty;
            if (Session["QUpdatesSelectedYears"] != null)
            {
                ProjectQuarterYear = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                ProjectQuarterName = Convert.ToString(Session["QUpdatesSelectedQuater"].ToString());
            }

            ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities sdb = new ClsMethod_QUpdateProject_ExternalInfrastructure_Facilities();
            ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities aa = new ClsPrp_QUpdateProject_ExternalInfrastructure_Facilities();

            try
            {
                // IsRegisteredDiaryNumberLock
                Int32 check_IsdraftValue = 2; // Get_Project_quater_Isdraftvalue_FromDiaryNumber();
                //IF RegdDNo=1 --> Lock, IF RegdDNo=2 --> Unlock, IF RegdDNo=9 --> Lock as DueDate expires
                check_IsdraftValue = 2;
                check_IsdraftValue = Get_QUpdateProject_getQUValue_FromDiaryNumber(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName);
                if (check_IsdraftValue == 0 || check_IsdraftValue == 2)
                {
                    if (sdb.Delete_QUpdateProject_ExternalInfrastructure_FacilitiesByID(ProjectRegistration_ID, ProjectQuarterYear, ProjectQuarterName, QUpdateProjectInfraExFacilities_IndexID, QUpdateProjectInfraExFacilities_ID, Related_ProjectInfrastructureExFacilitiesIndexID, Related_ProjectInfrastructureExFacilitiesID))
                    {
                        TempData["message"] = " Details deleted Successfully";
                    }
                }
                else
                {
                    TempData["message"] = "Error! Invalid details";
                }
                return RedirectToAction("QUpdate_QUExternalFacilities");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        // Get Value From DiaryNumber Table (1-Registered, 2-Open Or NotConfirmed, 9-Lock as DueDate expires) 
        #region        
        public Int32 Get_QUpdateProject_getQUValue_FromDiaryNumber(Int64 qProjectID, Int32 qYear, string qQuaterName)
        {
            Int32 returnQUpdateDNoValue = 0;
            Int64 pQUpdateProjectID = 0;
            Int32 pQUpdateProjectYear = 0;
            string pQUpdateProjectQuaterName = string.Empty;
            
            pQUpdateProjectID = qProjectID;
            pQUpdateProjectYear = qYear;
            pQUpdateProjectQuaterName = qQuaterName;

            if ((Session["Project_id"] == null) || (Session["QUpdatesSelectedYears"] == null) || (Session["QUpdatesSelectedQuater"] == null))
            {
                returnQUpdateDNoValue = 1;
            }
            else
            {
                Int64 Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                Int32 Year = Convert.ToInt32(Session["QUpdatesSelectedYears"].ToString());
                string Quater = Session["QUpdatesSelectedQuater"].ToString();

                ClsMethodProjectQuater_QUpdateProject ObjCls = new ClsMethodProjectQuater_QUpdateProject();
                Int32 IsdraftValue = ObjCls.GetQUValue_FromDiaryNumber(pQUpdateProjectID, pQUpdateProjectYear, pQUpdateProjectQuaterName);
                if (IsdraftValue == 1 || IsdraftValue == 5 || IsdraftValue == 6)
                {
                    returnQUpdateDNoValue = 1;
                }
                else if(IsdraftValue == 9)
                {
                    returnQUpdateDNoValue = 9;
                }
                else
                {
                    returnQUpdateDNoValue = 2;
                }
            }
            return returnQUpdateDNoValue;
        }
        #endregion
        #endregion


        // Joint-Promoter (Project-CoPromoters)
        #region Joint-Promoter
        [HttpPost]
        public ActionResult DropdownlistProjectCoPromoters(FormCollection frm, ClsPrp_Project_KhasraAreaDetails smodel)
        {
            ClsMethodProject objdis = new ClsMethodProject();
            TempData["SelectedItem"] = frm["ProjectKhasraAreaRelated_ProjectRegistration_ID"]; TempData.Keep();
            Session["Project_id"] = smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID;
            Session["url"] = Request.UrlReferrer;
            return Redirect(Session["url"].ToString());


        }
        // GET: Empty Create + Display
        public ActionResult Create_ProjectCoPromoters()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;

            ClsMethodProject objdis = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;
            ViewBag.SelectedItem = "";

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }


            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "Khasra"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            //TempData["list"] = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //TempData.Keep();


            ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
            ClsPrp_Project_KhasraAreaDetails aa = new ClsPrp_Project_KhasraAreaDetails();
            aa.prpongoing = sdb.Display_Project_KhasraAreaDetails(Project_id);
            aa.ProjectKhasraAreaRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ViewBag.project = aa.prpongoing;

            ClsMethod_Project_KhasraAreaDetails clsfive = new ClsMethod_Project_KhasraAreaDetails();


            //////// Fill project list from project Registration Table
            //ClsMethodProject objdis = new ClsMethodProject();

            aa.ProjectMaster = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            ViewBag.list = aa.ProjectMaster;

            TempData["submitvalue"] = "Submit"; TempData.Keep();
            #region
            Get_Isdraftvalue_FromDiaryNumber(Project_id);
            #endregion
            return View("Create_ProjectCoPromoters", aa);
        }

        // POST: Insert
        [HttpPost]
        public ActionResult Create_ProjectCoPromoters(ClsPrp_Project_KhasraAreaDetails smodel)
        {
            //Int64 Project_id = 110028;
            Int64 Project_id = 0;
            if (Session["Project_id"] != null)
            {
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());
                smodel.ProjectKhasraAreaRelated_ProjectRegistration_ID = Project_id;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }


            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
                    if (sdb.Add_Project_KhasraAreaDetails(smodel))
                    {
                        TempData["message"] = "Record Inserted Successfully!";
                        ModelState.Clear();
                    }
                }
                // return View("Create");
                return RedirectToAction("Create_ProjectCoPromoters");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        // GET: Single Display ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID,
        [HttpGet]
        public ActionResult Edit_ProjectCoPromoters(Int64 ProjectKhasra_IndexID, int ProjectKhasraRelated_ProjectRegistration_ID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
            ClsPrp_Project_KhasraAreaDetails aa = new ClsPrp_Project_KhasraAreaDetails();
            aa.prpongoing = sdb.Display_Project_KhasraAreaDetailsById(ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectKhasraArea_IndexID = item.ProjectKhasraArea_IndexID;
                aa.ProjectKhasraArea_ID = item.ProjectKhasraArea_ID;
                aa.ProjectKhasraAreaRelated_ProjectRegistration_ID = item.ProjectKhasraAreaRelated_ProjectRegistration_ID;
                aa.KhasraNumber_ProposedLand_TobeDeveloped = item.KhasraNumber_ProposedLand_TobeDeveloped;
                aa.Area_ProposedLand_EachKhasraNumber = item.Area_ProposedLand_EachKhasraNumber;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;
                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_ProjectCoPromoters", aa);
        }

        // POST: Update
        [HttpPost]
        public ActionResult Edit_ProjectCoPromoters(ClsPrp_Project_KhasraAreaDetails smodel)
        {
            //string Project_id = "110030";
            try
            {
                if (ModelState.IsValid)
                {
                    ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
                    sdb.Update_Project_KhasraAreaDetails(smodel);//, Project_id, Id, Project_Experience_ID);
                    TempData["message"] = "Record Updated Successfully!";
                }
                return RedirectToAction("Create_ProjectCoPromoters");
            }
            catch (Exception ex)
            {
                ex.ToString();
                TempData["message"] = "Bad Request, Try Again!";
                return View();
            }
        }

        // GET: Delete 
        public ActionResult Delete_ProjectCoPromoters(Int64 ProjectKhasra_IndexID, Int64 ProjectKhasraRelated_ProjectRegistration_ID)
        {
            // Project_id = "110027";
            try
            {
                ClsMethod_Project_KhasraAreaDetails sdb = new ClsMethod_Project_KhasraAreaDetails();
                if (sdb.Delete_Project_KhasraAreaDetailsById(ProjectKhasra_IndexID, ProjectKhasraRelated_ProjectRegistration_ID))
                {
                    TempData["message"] = " Details deleted Successfully";

                    //ViewBag.AlertMsg = " Details Deleted Successfully";
                }
                return RedirectToAction("Create_ProjectCoPromoters");
            }
            catch
            {
                return View();
            }
        }
        #endregion Project-CoPromoters(If Any)


        // Detail of Project Construction(If Any)
        #region
        public ActionResult Create_ConstructionQ()
        {
            Int64 Project_id = 0;

            //Int64 Application_ID = 10001;
            ViewBag.SelectedItem = "";
            ClsMethodProject objdis = new ClsMethodProject();
            //aa.stateMaster = objdis.State_list();

            // Class2 aa = new Class2();
            ClsPrp_Project_BuildingTowerBlock_Construction ss = new ClsPrp_Project_BuildingTowerBlock_Construction();

            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //ss.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = ss.ProjectMaster;
            // Int64 Project_id = 0;
            Session["url"] = Request.UrlReferrer;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ConstructionQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }


            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
            ClsPrp_Project_BuildingTowerBlock_Construction aa = new ClsPrp_Project_BuildingTowerBlock_Construction();
            aa.prpongoing = sdb.Display_BuildingTowerBlock_Construction(Project_id);
            aa.ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_BuildingTowerBlock_Construction clsfive = new ClsMethod_Project_BuildingTowerBlock_Construction();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();

            TempData["submitvalue"] = "Submit"; TempData.Keep();
            //Check Isdraft value From Diary Number table

            return View("Create_ConstructionQ", aa);
        }
        
        [HttpGet]
        public ActionResult Edit_ConstructionQ(Int64 Application_id, Int64 Id)
        {
            //  Project_id = "110029";
            ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
            ClsPrp_Project_BuildingTowerBlock_Construction aa = new ClsPrp_Project_BuildingTowerBlock_Construction();
            aa.prpongoing = sdb.Display_BuildingTowerBlock_ConstructionBYID(Application_id, Id);

            //ClsMethod_OngoingProjectLFiveYears clsfive = new ClsMethod_OngoingProjectLFiveYears();
            //aa.Prp_Project_Name = clsfive.ListofProjects(smodel.Project_id);

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectConstruction_ID = item.ProjectConstruction_ID;
                aa.ProjectConstruction_IndexID = item.ProjectConstruction_IndexID;
                aa.ProjectConstructionRelated_ProjectRegistration_ID = item.ProjectConstructionRelated_ProjectRegistration_ID;
                aa.BuildingTowerBlock_Name = item.BuildingTowerBlock_Name;
                aa.Proposed_FloorPlotsNumber = item.Proposed_FloorPlotsNumber;
                aa.CurrentlySanctioned_FloorPlotsNumber = item.CurrentlySanctioned_FloorPlotsNumber;
                aa.Constructed_FloorsNumber = item.Constructed_FloorsNumber;
                aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;
                aa.C_column = item.C_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;

            }

            ViewBag.Years = GetYears();

            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_ConstructionQ", aa);
        }

        [HttpGet]
        public ActionResult QUpdate_ConstructionQ()
        {
            Int64 Project_id = 0;

            //Int64 Application_ID = 10001;
            ViewBag.SelectedItem = "";
            ClsMethodProject objdis = new ClsMethodProject();
            //aa.stateMaster = objdis.State_list();

            // Class2 aa = new Class2();
            ClsPrp_Project_BuildingTowerBlock_Construction ss = new ClsPrp_Project_BuildingTowerBlock_Construction();

            // ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            //ss.ProjectMaster = objdis.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = ss.ProjectMaster;
            // Int64 Project_id = 0;
            Session["url"] = Request.UrlReferrer;

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ConstructionQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }


            TempData["list"] = objdis.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            ClsMethod_Project_BuildingTowerBlock_Construction sdb = new ClsMethod_Project_BuildingTowerBlock_Construction();
            ClsPrp_Project_BuildingTowerBlock_Construction aa = new ClsPrp_Project_BuildingTowerBlock_Construction();
            aa.prpongoing = sdb.Display_BuildingTowerBlock_Construction(Project_id);
            aa.ProjectConstructionRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            ClsMethod_Project_BuildingTowerBlock_Construction clsfive = new ClsMethod_Project_BuildingTowerBlock_Construction();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();

            TempData["submitvalue"] = "Submit"; TempData.Keep();
            //Check Isdraft value From Diary Number table

            return View("Create_ConstructionQ", aa);
        }
        #endregion        

        // Detail of Project ProfessionalDetails(If Any)
        #region        
        public ActionResult Create_ProfessionalDetailsQ()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            // ViewBag.SelectedItem = "";
            ClsMethodProject objdis1 = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProfessionalDetailsQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ProfessionalDetails(Project_id);

            ClsMethod_Project_ProfessionalDetails clsfive = new ClsMethod_Project_ProfessionalDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;




            aa.ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            aa.districtMaster = objdis.dropdownlist_display1();
            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_ProfessionalDetailsQ", aa);
        }

        [HttpGet]
        public ActionResult Edit_ProfessionalDetailsQ(Int64 ProjectRegistration_ID, Int64 ProjectProfessional_IndexID)
        {
            //  Project_id = "110029";
            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ApprovalDetailsById(ProjectRegistration_ID, ProjectProfessional_IndexID);

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();


            aa.stateMaster = objdis.State_list();
            aa.districtMaster = objdis.dropdownlist_display1();

            ViewBag.state = aa.stateMaster;

            foreach (var item in aa.prpongoing)
            {
                aa.ProjectProfessional_IndexID = item.ProjectProfessional_IndexID;
                aa.ProjectProfessional_ID = item.ProjectProfessional_ID;
                aa.ProjectProfessionalRelated_ProjectRegistration_ID = item.ProjectProfessionalRelated_ProjectRegistration_ID;
                aa.Associated_Consultant_Type = item.Associated_Consultant_Type;
                aa.Name_of_Professional = item.Name_of_Professional;
                aa.RERA_ID_IfAgent = item.RERA_ID_IfAgent;
                aa.Name_and_Year_of_Establishment_of_Promoter = item.Name_and_Year_of_Establishment_of_Promoter;
                aa.Name_and_Profile_of_Key_ProjectsCompleted = item.Name_and_Profile_of_Key_ProjectsCompleted;
                aa.OfficialComm_AddressLine1 = item.OfficialComm_AddressLine1;
                aa.OfficialComm_AddressLine2 = item.OfficialComm_AddressLine2;
                aa.OfficialComm_AddressStateCode = item.OfficialComm_AddressStateCode;
                aa.OfficialComm_AddressDistrictCode = item.OfficialComm_AddressDistrictCode;
                aa.OfficialComm_AddressPIN = item.OfficialComm_AddressPIN;
                aa.MobileNumber = item.MobileNumber;
                aa.Phone_STD = item.Phone_STD;
                aa.Phone_Number = item.Phone_Number;
                aa.Email_ID = item.Email_ID;
                //aa.Remarks_IfAny = item.Remarks_IfAny;
                aa.A_column = item.A_column;
                aa.B_column = item.B_column;

                aa.IsActive = item.IsActive;
                aa.IsDraft = item.IsDraft;
                aa.CreatedBy = item.CreatedBy;
                aa.CreatedOn = item.CreatedOn;
                aa.ModifyBy = item.ModifyBy;
                aa.ModifyOn = item.ModifyOn;
            }
            ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Update";
            TempData.Keep();
            return View("Create_ProfessionalDetailsQ", aa);
        }

        public ActionResult QUpdate_ProfessionalDetailsQ()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            // ViewBag.SelectedItem = "";
            ClsMethodProject objdis1 = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ProfessionalDetailsQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ProfessionalDetails(Project_id);

            ClsMethod_Project_ProfessionalDetails clsfive = new ClsMethod_Project_ProfessionalDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;

            aa.ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            aa.districtMaster = objdis.dropdownlist_display1();
            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_ProfessionalDetailsQ", aa);
        }
        #endregion        


        // Detail of Project ePayment WebPortal Maintanince Fee(If Any)
        public ActionResult Create_WebPortalePaymentDetailsQ()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            // ViewBag.SelectedItem = "";
            ClsMethodProject objdis1 = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "WebPortalePaymentDetailsQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ProfessionalDetails(Project_id);

            ClsMethod_Project_ProfessionalDetails clsfive = new ClsMethod_Project_ProfessionalDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;

            aa.ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            aa.districtMaster = objdis.dropdownlist_display1();
            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_WebPortalePaymentDetailsQ", aa);
        }

        // Detail of Architecture Certificate(Table-A and Table-B)
        public ActionResult Create_ArchitectureTableADetailsQ()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            // ViewBag.SelectedItem = "";
            ClsMethodProject objdis1 = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ArchitectureTableADetailsQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ProfessionalDetails(Project_id);

            ClsMethod_Project_ProfessionalDetails clsfive = new ClsMethod_Project_ProfessionalDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;

            aa.ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            aa.districtMaster = objdis.dropdownlist_display1();
            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_ArchitectureTableADetailsQ", aa);
        }

        public ActionResult Create_ArchitectureTableBDetailsQ()
        {
            Int64 Project_id = 0;
            //Int64 Application_ID = 0;
            // ViewBag.SelectedItem = "";
            ClsMethodProject objdis1 = new ClsMethodProject();
            Session["url"] = Request.UrlReferrer;

            Int64 PromoterApplicationId = 0;
            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    PromoterApplicationId = Convert.ToInt64(Session["ApplicationId"]);
                }
            }

            TempData["list"] = objdis1.FillDropdown_Project_ByAppId(PromoterApplicationId, 0);
            TempData.Keep();

            var fullUrl = this.Request.UrlReferrer.ToString();
            string url = fullUrl;
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var values = routeData.Values;
            string controllerName = values["controller"].ToString();
            string viewname = values["action"].ToString();
            string part = viewname.Substring(viewname.LastIndexOf('_') + 1);
            if ((part != "ArchitectureTableBDetailsQ"))
                Session.Remove("Project_id");
            else
                Project_id = Convert.ToInt64(Session["Project_id"].ToString());



            ClsMethod_Project_ProfessionalDetails sdb = new ClsMethod_Project_ProfessionalDetails();
            ClsPrp_Project_ProfessionalDetails aa = new ClsPrp_Project_ProfessionalDetails();
            aa.prpongoing = sdb.Display_Project_ProfessionalDetails(Project_id);

            ClsMethod_Project_ProfessionalDetails clsfive = new ClsMethod_Project_ProfessionalDetails();

            //  aa.Prp_Project_Name = clsfive.ListofProjects(Project_id);
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            aa.stateMaster = objdis.State_list();
            ViewBag.state = aa.stateMaster;

            aa.ProjectProfessionalRelated_ProjectRegistration_ID = Convert.ToInt64(TempData["SelectedItem"]); TempData.Keep();
            //////// Fill project list from project Registration Table

            if (Session["CurrentYears"] != null)
            {
                aa.B_column = Session["CurrentYears"].ToString();
                aa.A_column = Session["PresentQuater"].ToString();
            }

            //aa.ProjectMaster = objdis1.FillDropdown_Project_ByAppId(Application_ID);
            //ViewBag.list = aa.ProjectMaster;

            aa.districtMaster = objdis.dropdownlist_display1();
            TempData["CurrentYears"] = null; ViewBag.Years = GetYears();
            TempData["submitvalue"] = "Submit"; TempData.Keep();
            return View("Create_ArchitectureTableBDetailsQ", aa);
        }
        
    }
}
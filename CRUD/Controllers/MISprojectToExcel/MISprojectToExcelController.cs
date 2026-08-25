using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CRUD.Models.MISprojectToExcel;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style.XmlAccess;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using CRUD.Models.Promoter;
using CRUD.Models.Master;
// using Microsoft.Interop.Excel;

namespace CRUD.Controllers.MISprojectToExcel
{
    [Authorize]
    [Authorize(Roles = "Authority, HelpDesk, SecretaryRERA, ManagerDesk, LegalAdvisorDesk, PStoMembers")]
    public class MISprojectToExcelController : Controller
    {

        #region Projects Address Directory (MIS Reports)
        [HttpGet]
        public ActionResult Display_ProjectAddressDirectoryDetailsForInProcessMIS()
        {
            ClsMethod_MIS_ProjectAddressDirectoryDetails sdb = new ClsMethod_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryDetails getObj = new Clsprp_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXls = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForInProcessApplication(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

                aaXlsInner.Project_DiaryNumber = item.ProjectDiaryNumber;
                aaXlsInner.Project_Name = item.Project_Name;

                aaXlsInner.Project_AddressLine1 = item.Project_AddressLine1;
                aaXlsInner.Project_AddressLine2 = item.Project_AddressLine2;
                aaXlsInner.Project_AddressState = item.Project_AddressStateCode;
                aaXlsInner.Project_AddressDistrict = item.Project_AddressDistrictCode;
                aaXlsInner.Project_AddressSubDivision = item.Project_AddressSubDivisionCode;
                aaXlsInner.Project_AddressPIN = item.Project_AddressPIN;

                aaXlsInner.Project_AddressPotentialZone = item.Project_PotentialZoneCode;

                aaXlsInner.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                aaXlsInner.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                aaXlsInner.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;

                aaXlsInner.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                aaXlsInner.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                aaXlsInner.AuthorizedPerson_AddressState = item.AuthorizedPerson_AddressStateCode;
                aaXlsInner.AuthorizedPerson_AddressDistrict = item.AuthorizedPerson_AddressDistrictCode;
                aaXlsInner.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;

                aaXlsInner.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                aaXlsInner.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;
                
                // Promoter Details
                aaXlsInner.Promoter_Name = item.Promoter_Name;

                aaXlsInner.Promoter_RegdAddress_Line1 = item.Promoter_RegdAddress_Line1;
                aaXlsInner.Promoter_RegdAddress_Line2 = item.Promoter_RegdAddress_Line2;
                aaXlsInner.Promoter_RegdState = item.Promoter_RegdState;
                aaXlsInner.Promoter_RegdDistrict = item.Promoter_RegdDistrict;
                aaXlsInner.Promoter_Regd_PIN = item.Promoter_Regd_PIN;

                aaXlsInner.Promoter_CommAddress_Line1 = item.Promoter_CommAddress_Line1;
                aaXlsInner.Promoter_CommAddress_Line2 = item.Promoter_CommAddress_Line2;
                aaXlsInner.Promoter_CommState = item.Promoter_CommState;
                aaXlsInner.Promoter_CommDistrict = item.Promoter_CommDistrict;
                aaXlsInner.Promoter_Comm_PIN = item.Promoter_Comm_PIN;

                aaXlsInner.Promoter_AuthorisedSignatory_Name = item.Promoter_AuthorisedSignatory_Name;
                aaXlsInner.Promoter_AuthorisedSignatory_MobileNumber = item.Promoter_AuthorisedSignatory_MobileNumber;
                aaXlsInner.Promoter_AuthorisedSignatory_Email = item.Promoter_AuthorisedSignatory_Email;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectAddressDirectoryMIS"] = aaXls.prpongoing;

            return View("Display_ProjectAddressDirectoryDetailsForInProcessMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectAddressDirectoryDetailsForInProcessMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_ProjectAddressDirectoryDetails sdb = new ClsMethod_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryDetails getObj = new Clsprp_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXls = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForInProcessApplication_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

                    aaXlsInner.Project_DiaryNumber = item.ProjectDiaryNumber;
                    aaXlsInner.Project_Name = item.Project_Name;

                    aaXlsInner.Project_AddressLine1 = item.Project_AddressLine1;
                    aaXlsInner.Project_AddressLine2 = item.Project_AddressLine2;
                    aaXlsInner.Project_AddressState = item.Project_AddressStateCode;
                    aaXlsInner.Project_AddressDistrict = item.Project_AddressDistrictCode;
                    aaXlsInner.Project_AddressSubDivision = item.Project_AddressSubDivisionCode;
                    aaXlsInner.Project_AddressPIN = item.Project_AddressPIN;

                    aaXlsInner.Project_AddressPotentialZone = item.Project_PotentialZoneCode;

                    aaXlsInner.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                    aaXlsInner.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                    aaXlsInner.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;

                    aaXlsInner.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                    aaXlsInner.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                    aaXlsInner.AuthorizedPerson_AddressState = item.AuthorizedPerson_AddressStateCode;
                    aaXlsInner.AuthorizedPerson_AddressDistrict = item.AuthorizedPerson_AddressDistrictCode;
                    aaXlsInner.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;

                    aaXlsInner.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                    aaXlsInner.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;

                    // Promoter Details
                    aaXlsInner.Promoter_Name = item.Promoter_Name;

                    aaXlsInner.Promoter_RegdAddress_Line1 = item.Promoter_RegdAddress_Line1;
                    aaXlsInner.Promoter_RegdAddress_Line2 = item.Promoter_RegdAddress_Line2;
                    aaXlsInner.Promoter_RegdState = item.Promoter_RegdState;
                    aaXlsInner.Promoter_RegdDistrict = item.Promoter_RegdDistrict;
                    aaXlsInner.Promoter_Regd_PIN = item.Promoter_Regd_PIN;

                    aaXlsInner.Promoter_CommAddress_Line1 = item.Promoter_CommAddress_Line1;
                    aaXlsInner.Promoter_CommAddress_Line2 = item.Promoter_CommAddress_Line2;
                    aaXlsInner.Promoter_CommState = item.Promoter_CommState;
                    aaXlsInner.Promoter_CommDistrict = item.Promoter_CommDistrict;
                    aaXlsInner.Promoter_Comm_PIN = item.Promoter_Comm_PIN;

                    aaXlsInner.Promoter_AuthorisedSignatory_Name = item.Promoter_AuthorisedSignatory_Name;
                    aaXlsInner.Promoter_AuthorisedSignatory_MobileNumber = item.Promoter_AuthorisedSignatory_MobileNumber;
                    aaXlsInner.Promoter_AuthorisedSignatory_Email = item.Promoter_AuthorisedSignatory_Email;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectAddressDirectoryMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectAddressDirectoryDetailsForInProcessMIS", getObj);
        }
        
        [HttpGet]
        public ActionResult Display_ProjectAddressDirectoryDetailsForRegisteredProjectsMIS()
        {
            ClsMethod_MIS_ProjectAddressDirectoryDetails sdb = new ClsMethod_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryDetails getObj = new Clsprp_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXls = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForRegisteredProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

                aaXlsInner.Project_DiaryNumber = item.ProjectDiaryNumber;
                aaXlsInner.Project_Name = item.Project_Name;

                aaXlsInner.Project_AddressLine1 = item.Project_AddressLine1;
                aaXlsInner.Project_AddressLine2 = item.Project_AddressLine2;
                aaXlsInner.Project_AddressState = item.Project_AddressStateCode;
                aaXlsInner.Project_AddressDistrict = item.Project_AddressDistrictCode;
                aaXlsInner.Project_AddressSubDivision = item.Project_AddressSubDivisionCode;
                aaXlsInner.Project_AddressPIN = item.Project_AddressPIN;

                aaXlsInner.Project_AddressPotentialZone = item.Project_PotentialZoneCode;

                aaXlsInner.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                aaXlsInner.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                aaXlsInner.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;

                aaXlsInner.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                aaXlsInner.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                aaXlsInner.AuthorizedPerson_AddressState = item.AuthorizedPerson_AddressStateCode;
                aaXlsInner.AuthorizedPerson_AddressDistrict = item.AuthorizedPerson_AddressDistrictCode;
                aaXlsInner.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;

                aaXlsInner.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                aaXlsInner.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;

                // Promoter Details
                aaXlsInner.Promoter_Name = item.Promoter_Name;

                aaXlsInner.Promoter_RegdAddress_Line1 = item.Promoter_RegdAddress_Line1;
                aaXlsInner.Promoter_RegdAddress_Line2 = item.Promoter_RegdAddress_Line2;
                aaXlsInner.Promoter_RegdState = item.Promoter_RegdState;
                aaXlsInner.Promoter_RegdDistrict = item.Promoter_RegdDistrict;
                aaXlsInner.Promoter_Regd_PIN = item.Promoter_Regd_PIN;

                aaXlsInner.Promoter_CommAddress_Line1 = item.Promoter_CommAddress_Line1;
                aaXlsInner.Promoter_CommAddress_Line2 = item.Promoter_CommAddress_Line2;
                aaXlsInner.Promoter_CommState = item.Promoter_CommState;
                aaXlsInner.Promoter_CommDistrict = item.Promoter_CommDistrict;
                aaXlsInner.Promoter_Comm_PIN = item.Promoter_Comm_PIN;

                aaXlsInner.Promoter_AuthorisedSignatory_Name = item.Promoter_AuthorisedSignatory_Name;
                aaXlsInner.Promoter_AuthorisedSignatory_MobileNumber = item.Promoter_AuthorisedSignatory_MobileNumber;
                aaXlsInner.Promoter_AuthorisedSignatory_Email = item.Promoter_AuthorisedSignatory_Email;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectAddressDirectoryMIS"] = aaXls.prpongoing;

            return View("Display_ProjectAddressDirectoryDetailsForRegisteredProjectsMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectAddressDirectoryDetailsForRegisteredProjectsMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_ProjectAddressDirectoryDetails sdb = new ClsMethod_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryDetails getObj = new Clsprp_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXls = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForRegisteredProjects_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectAddressDirectoryExportExcel aaXlsInner = new Clsprp_MIS_ProjectAddressDirectoryExportExcel();

                    aaXlsInner.Project_DiaryNumber = item.ProjectDiaryNumber;
                    aaXlsInner.Project_Name = item.Project_Name;

                    aaXlsInner.Project_AddressLine1 = item.Project_AddressLine1;
                    aaXlsInner.Project_AddressLine2 = item.Project_AddressLine2;
                    aaXlsInner.Project_AddressState = item.Project_AddressStateCode;
                    aaXlsInner.Project_AddressDistrict = item.Project_AddressDistrictCode;
                    aaXlsInner.Project_AddressSubDivision = item.Project_AddressSubDivisionCode;
                    aaXlsInner.Project_AddressPIN = item.Project_AddressPIN;

                    aaXlsInner.Project_AddressPotentialZone = item.Project_PotentialZoneCode;

                    aaXlsInner.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                    aaXlsInner.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                    aaXlsInner.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;

                    aaXlsInner.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                    aaXlsInner.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                    aaXlsInner.AuthorizedPerson_AddressState = item.AuthorizedPerson_AddressStateCode;
                    aaXlsInner.AuthorizedPerson_AddressDistrict = item.AuthorizedPerson_AddressDistrictCode;
                    aaXlsInner.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;

                    aaXlsInner.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                    aaXlsInner.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;

                    // Promoter Details
                    aaXlsInner.Promoter_Name = item.Promoter_Name;

                    aaXlsInner.Promoter_RegdAddress_Line1 = item.Promoter_RegdAddress_Line1;
                    aaXlsInner.Promoter_RegdAddress_Line2 = item.Promoter_RegdAddress_Line2;
                    aaXlsInner.Promoter_RegdState = item.Promoter_RegdState;
                    aaXlsInner.Promoter_RegdDistrict = item.Promoter_RegdDistrict;
                    aaXlsInner.Promoter_Regd_PIN = item.Promoter_Regd_PIN;

                    aaXlsInner.Promoter_CommAddress_Line1 = item.Promoter_CommAddress_Line1;
                    aaXlsInner.Promoter_CommAddress_Line2 = item.Promoter_CommAddress_Line2;
                    aaXlsInner.Promoter_CommState = item.Promoter_CommState;
                    aaXlsInner.Promoter_CommDistrict = item.Promoter_CommDistrict;
                    aaXlsInner.Promoter_Comm_PIN = item.Promoter_Comm_PIN;

                    aaXlsInner.Promoter_AuthorisedSignatory_Name = item.Promoter_AuthorisedSignatory_Name;
                    aaXlsInner.Promoter_AuthorisedSignatory_MobileNumber = item.Promoter_AuthorisedSignatory_MobileNumber;
                    aaXlsInner.Promoter_AuthorisedSignatory_Email = item.Promoter_AuthorisedSignatory_Email;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectAddressDirectoryMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectAddressDirectoryDetailsForRegisteredProjectsMIS", getObj);
        }

        public void ExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectAddressDirectoryMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=ListofProjectAddressDirectorys_" + strDateFormat + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        [HttpGet]
        public ActionResult ProjectAddressDirectoryDetailsForMIS(Int64 projectId)
        {
            ClsMethod_MIS_ProjectAddressDirectoryDetails sdb = new ClsMethod_MIS_ProjectAddressDirectoryDetails();
            Clsprp_MIS_ProjectAddressDirectoryDetails getObj = new Clsprp_MIS_ProjectAddressDirectoryDetails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAddressDirectoryDetails_ForMIS(projectId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.ProjectDiaryNumber = item.ProjectDiaryNumber;
                getObj.ProjectRegistration_IndexID = item.ProjectRegistration_IndexID;
                getObj.ProjectRegistration_ID = item.ProjectRegistration_ID;
                getObj.Project_Name = item.Project_Name;
                getObj.Project_AddressLine1 = item.Project_AddressLine1;
                getObj.Project_AddressLine2 = item.Project_AddressLine2;
                getObj.Project_AddressStateCode = item.Project_AddressStateCode;
                getObj.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                getObj.Project_AddressSubDivisionCode = item.Project_AddressSubDivisionCode;
                getObj.Project_AddressPIN = item.Project_AddressPIN;

                getObj.Project_PotentialZoneCode = item.Project_PotentialZoneCode;
                getObj.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                getObj.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                getObj.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;

                getObj.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                getObj.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                getObj.AuthorizedPerson_AddressStateCode = item.AuthorizedPerson_AddressStateCode;
                getObj.AuthorizedPerson_AddressDistrictCode = item.AuthorizedPerson_AddressDistrictCode;
                getObj.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;

                getObj.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                getObj.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;

                // Promoter Details
                getObj.Application_Id = item.Application_Id;
                getObj.Promoter_Name = item.Promoter_Name;

                getObj.Promoter_RegdAddress_Line1 = item.Promoter_RegdAddress_Line1;
                getObj.Promoter_RegdAddress_Line2 = item.Promoter_RegdAddress_Line2;
                getObj.Promoter_RegdState = item.Promoter_RegdState;
                getObj.Promoter_RegdDistrict = item.Promoter_RegdDistrict;
                getObj.Promoter_Regd_PIN = item.Promoter_Regd_PIN;

                getObj.Promoter_CommAddress_Line1 = item.Promoter_CommAddress_Line1;
                getObj.Promoter_CommAddress_Line2 = item.Promoter_CommAddress_Line2;
                getObj.Promoter_CommState = item.Promoter_CommState;
                getObj.Promoter_CommDistrict = item.Promoter_CommDistrict;
                getObj.Promoter_Comm_PIN = item.Promoter_Comm_PIN;

                getObj.Promoter_AuthorisedSignatory_Name = item.Promoter_AuthorisedSignatory_Name;
                getObj.Promoter_AuthorisedSignatory_MobileNumber = item.Promoter_AuthorisedSignatory_MobileNumber;
                getObj.Promoter_AuthorisedSignatory_Email = item.Promoter_AuthorisedSignatory_Email;

                getObj.Flag = item.Flag;
                getObj.Extra4 = item.Extra4;
            }
            return View("ProjectAddressDirectoryDetailsForMIS", getObj);
        }
        #endregion

        #region Project Certificate - QR Code Generation (MIS Reports)

        #region QR Code For Registered Projects
        [HttpGet]
        public ActionResult Display_ProjectQRcodeCertificateDetailsForRegisteredProjectsMIS()
        {
            ClsMethod_MIS_ProjectQRcodeCertificateDetails sdb = new ClsMethod_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeCertificateDetails getObj = new Clsprp_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeCertificateExportExcel aaXls = new Clsprp_MIS_ProjectQRcodeCertificateExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForRERAnumberRegisteredProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_ProjectQRcodeCertificateExportExcel aaXlsInner = new Clsprp_MIS_ProjectQRcodeCertificateExportExcel();

                aaXlsInner.Project_DiaryNumber = item.Project_DiaryNumber;
                aaXlsInner.Application_Date = item.Project_Diary_ApplicationDate;
                aaXlsInner.Project_Name = item.Project_Name;
                aaXlsInner.Project_Type = item.Project_TypeSTR;
                aaXlsInner.Project_TotalArea = item.Project_TotalArea + " " + item.Project_TotalAreaSTR;

                aaXlsInner.Project_AddressLine1 = item.Project_AddressLine1;
                aaXlsInner.Project_AddressLine2 = item.Project_AddressLine2;
                aaXlsInner.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                aaXlsInner.Project_AddressStateCode = item.Project_AddressStateCode;
                aaXlsInner.Project_AddressPIN = item.Project_AddressPIN;

                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.Promoter_Type = item.Promoter_TypeSTR;

                aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                aaXlsInner.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aaXlsInner.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aaXlsInner.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                aaXlsInner.RERA_RegistrationNumber = item.RERAnumberRegistration;
                aaXlsInner.RERA_RegistrationNumber_IssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERA_RegistrationNumber_ValidUptoDate = item.RERAnumberRegUptoDate;

                aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                aaXlsInner.RemarksIfAny = item.RemarksIfAny;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectQRcodeCertificateMIS"] = aaXls.prpongoing;

            return View("Display_ProjectQRcodeCertificateDetailsForRegisteredProjectsMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectQRcodeCertificateDetailsForRegisteredProjectsMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_ProjectQRcodeCertificateDetails sdb = new ClsMethod_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeCertificateDetails getObj = new Clsprp_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeCertificateExportExcel aaXls = new Clsprp_MIS_ProjectQRcodeCertificateExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForRERAnumberRegisteredProjects_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectQRcodeCertificateExportExcel aaXlsInner = new Clsprp_MIS_ProjectQRcodeCertificateExportExcel();

                    aaXlsInner.Project_DiaryNumber = item.Project_DiaryNumber;
                    aaXlsInner.Application_Date = item.Project_Diary_ApplicationDate;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Project_Type = item.Project_TypeSTR;
                    aaXlsInner.Project_TotalArea = item.Project_TotalArea + " " + item.Project_TotalAreaSTR;

                    aaXlsInner.Project_AddressLine1 = item.Project_AddressLine1;
                    aaXlsInner.Project_AddressLine2 = item.Project_AddressLine2;
                    aaXlsInner.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                    aaXlsInner.Project_AddressStateCode = item.Project_AddressStateCode;
                    aaXlsInner.Project_AddressPIN = item.Project_AddressPIN;

                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.Promoter_Type = item.Promoter_TypeSTR;

                    aaXlsInner.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    aaXlsInner.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    aaXlsInner.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    aaXlsInner.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    aaXlsInner.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                    aaXlsInner.RERA_RegistrationNumber = item.RERAnumberRegistration;
                    aaXlsInner.RERA_RegistrationNumber_IssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERA_RegistrationNumber_ValidUptoDate = item.RERAnumberRegUptoDate;

                    aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                    aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                    aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                    aaXlsInner.RemarksIfAny = item.RemarksIfAny;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectQRcodeCertificateMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectQRcodeCertificateDetailsForRegisteredProjectsMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectQRcodeCertificateDetailsForRegisteredProjectsMIS(Int64 ProjectId, Int64 PromoterId)
        {
            ClsMethod_MIS_ProjectQRcodeCertificateDetails sdb = new ClsMethod_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeCertificateDetails getObj = new Clsprp_MIS_ProjectQRcodeCertificateDetails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForRERAnumberRegisteredProjects_ForMIS(ProjectId, PromoterId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.Project_DiaryNumber = item.Project_DiaryNumber;
                getObj.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;

                getObj.Project_ID = item.Project_ID;
                getObj.Promoter_ID = item.Promoter_ID;
                getObj.Project_Name = item.Project_Name;
                getObj.Project_Type = item.Project_Type;
                getObj.Project_TypeSTR = item.Project_TypeSTR;

                getObj.Project_TotalArea = item.Project_TotalArea;
                getObj.Project_TotalAreaSTR = item.Project_TotalAreaSTR;

                getObj.Project_AddressLine1 = item.Project_AddressLine1;
                getObj.Project_AddressLine2 = item.Project_AddressLine2;
                getObj.Project_AddressStateCode = item.Project_AddressStateCode;
                getObj.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                getObj.Project_AddressPIN = item.Project_AddressPIN;

                getObj.Promoter_Name = item.Promoter_Name;
                getObj.Promoter_Type = item.Promoter_Type;
                getObj.Promoter_TypeSTR = item.Promoter_TypeSTR;

                getObj.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                getObj.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                getObj.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                getObj.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                getObj.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;

                getObj.RERAnumberRegistration = item.RERAnumberRegistration;
                getObj.RERAnumberIssueDate = item.RERAnumberIssueDate;
                getObj.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;

                getObj.QRcodeImage_A = item.QRcodeImage_A;
                getObj.QRcodeImage_B = item.QRcodeImage_B;
                getObj.QRcodeImage_C = item.QRcodeImage_C;
                getObj.RemarksIfAny = item.RemarksIfAny;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("ProjectQRcodeCertificateDetailsForRegisteredProjectsMIS", getObj);
        }

        public void ExportwithQRcodeToExcel()
        {
            var objXlslist = Session["modelProjectQRcodeCertificateMIS"] as List<Clsprp_MIS_ProjectQRcodeCertificateExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Project Name";
            workSheet.Cells[1, 5].Value = "Project Type";
            workSheet.Cells[1, 6].Value = "Project Total Area (In sqrmtrs)";

            workSheet.Cells[1, 7].Value = "Project - Address Line 1";
            workSheet.Cells[1, 8].Value = "Project - Address Line 2";
            workSheet.Cells[1, 9].Value = "Project - District";
            workSheet.Cells[1, 10].Value = "Project - State";
            workSheet.Cells[1, 11].Value = "Project - PIN";

            workSheet.Cells[1, 12].Value = "Promoter Name";
            workSheet.Cells[1, 13].Value = "Promoter - Address Line 1";
            workSheet.Cells[1, 14].Value = "Promoter - Address Line 2";
            workSheet.Cells[1, 15].Value = "Promoter - District";
            workSheet.Cells[1, 16].Value = "Promoter - State";
            workSheet.Cells[1, 17].Value = "Promoter - PIN";

            workSheet.Cells[1, 18].Value = "RERA Number";
            workSheet.Cells[1, 19].Value = "Issue Date";
            workSheet.Cells[1, 20].Value = "Valid upto Date";
            workSheet.Cells[1, 21].Value = "QR Code Image";
            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Project_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Application_Date.ToString("dd-MMM-yyyy");
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Project_Name;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.Project_Type;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Project_TotalArea;

                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Project_AddressLine1;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.Project_AddressLine2;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.Project_AddressDistrictCode;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.Project_AddressStateCode;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.Project_AddressPIN;

                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.Promoter_Name;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.BusinessPlace_AddressLine1;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.BusinessPlace_AddressLine2;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.BusinessPlace_AddressDistrictCode;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.BusinessPlace_AddressStateCode;
                workSheet.Cells[recordIndex, 17].Value = QRcodeItem.BusinessPlace_AddressPIN;

                workSheet.Cells[recordIndex, 18].Value = QRcodeItem.RERA_RegistrationNumber;
                workSheet.Cells[recordIndex, 19].Value = QRcodeItem.RERA_RegistrationNumber_IssueDate.HasValue ? QRcodeItem.RERA_RegistrationNumber_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 20].Value = QRcodeItem.RERA_RegistrationNumber_ValidUptoDate.HasValue ? QRcodeItem.RERA_RegistrationNumber_ValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;

                Stream streamQR = new MemoryStream(GenerateQrCodeByBytesForProjects(QRcodeItem.RERA_RegistrationNumber, QRcodeItem.RERA_RegistrationNumber_ValidUptoDate, QRcodeItem.Project_Name, QRcodeItem.Project_Type, QRcodeItem.Promoter_Name, QRcodeItem.Project_AddressLine1, QRcodeItem.Project_AddressLine2, QRcodeItem.Project_AddressDistrictCode, QRcodeItem.Project_AddressStateCode));
                var cfPhoto = System.Drawing.Image.FromStream(streamQR);
                var cfBm = new Bitmap(cfPhoto, new Size(215, 170));
                ExcelPicture imgQR = workSheet.Drawings.AddPicture(QRcodeItem.Project_DiaryNumber, cfBm);
                imgQR.SetPosition(recordIndex - 1, 5, 20, 5);
                imgQR.SetSize(90, 90);
                workSheet.Row(recordIndex).Height = 100;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();

            workSheet.Cells["A1:U1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:U1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 21])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectQRcodeCertificates_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region QR Code For Offline Projects
        [HttpGet]
        public ActionResult Display_ProjectQRcodeCertificateDetailsForOfflineProjectsMIS()
        {
            ClsMethod_MIS_ProjectQRcodeCertificateDetails sdb = new ClsMethod_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails getObj = new Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails();
            Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel aaXls = new Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForOfflineProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel aaXlsInner = new Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel();
                
                aaXlsInner.OfflineProject_ReferenceNumber = item.OfflineProject_ReferenceNumber;
                aaXlsInner.OfflineProject_IssueDate = item.OfflineProject_IssueDate;
                aaXlsInner.OfflineProject_Name = item.OfflineProject_Name;
                aaXlsInner.OfflineProject_Type = item.OfflineProject_Type;

                aaXlsInner.OfflineProject_TotalArea = string.Concat(string.Concat(item.OfflineProject_TotalArea, " "), "sqrmtrs");

                aaXlsInner.OfflineProject_Address = item.OfflineProject_Address;
                aaXlsInner.OfflineProject_BusinessPlaceDistrict = item.OfflineProject_BusinessPlaceDistrict;

                aaXlsInner.OfflinePromoter_Name = item.OfflinePromoter_Name;
                aaXlsInner.OfflinePromoter_BusinessPlace_Address = item.OfflinePromoter_BusinessPlace_Address;

                aaXlsInner.OfflineProject_RERAregistrationNumber = item.OfflineProject_RERAregistrationNumber;
                aaXlsInner.OfflineProject_RERAregistrationIssueDate = item.OfflineProject_RERAregistrationIssueDate;
                aaXlsInner.OfflineProject_RERAregistrationValidUptoDate = item.OfflineProject_RERAregistrationValidUptoDate;

                aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                aaXlsInner.OfflineProject_RemarksIfAny = item.OfflineProject_RemarksIfAny;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectQRcodeOfflineCertificateMIS"] = aaXls.prpongoing;

            return View("Display_ProjectQRcodeCertificateDetailsForOfflineProjectsMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectQRcodeCertificateDetailsForOfflineProjectsMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethod_MIS_ProjectQRcodeCertificateDetails sdb = new ClsMethod_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails getObj = new Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails();
            Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel aaXls = new Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForOfflineProjects_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel aaXlsInner = new Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel();

                    aaXlsInner.OfflineProject_ReferenceNumber = item.OfflineProject_ReferenceNumber;
                    aaXlsInner.OfflineProject_IssueDate = item.OfflineProject_IssueDate;
                    aaXlsInner.OfflineProject_Name = item.OfflineProject_Name;
                    aaXlsInner.OfflineProject_Type = item.OfflineProject_Type;

                    aaXlsInner.OfflineProject_TotalArea = string.Concat(string.Concat(item.OfflineProject_TotalArea, " "), "sqrmtrs");

                    aaXlsInner.OfflineProject_Address = item.OfflineProject_Address;
                    aaXlsInner.OfflineProject_BusinessPlaceDistrict = item.OfflineProject_BusinessPlaceDistrict;

                    aaXlsInner.OfflinePromoter_Name = item.OfflinePromoter_Name;
                    aaXlsInner.OfflinePromoter_BusinessPlace_Address = item.OfflinePromoter_BusinessPlace_Address;

                    aaXlsInner.OfflineProject_RERAregistrationNumber = item.OfflineProject_RERAregistrationNumber;
                    aaXlsInner.OfflineProject_RERAregistrationIssueDate = item.OfflineProject_RERAregistrationIssueDate;
                    aaXlsInner.OfflineProject_RERAregistrationValidUptoDate = item.OfflineProject_RERAregistrationValidUptoDate;

                    aaXlsInner.QRcodeImage_A = item.QRcodeImage_A;
                    aaXlsInner.QRcodeImage_B = item.QRcodeImage_B;
                    aaXlsInner.QRcodeImage_C = item.QRcodeImage_C;
                    aaXlsInner.OfflineProject_RemarksIfAny = item.OfflineProject_RemarksIfAny;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectQRcodeOfflineCertificateMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectQRcodeCertificateDetailsForOfflineProjectsMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectQRcodeCertificateDetailsForOfflineProjectsMIS(Int64 OfflineProjectId)
        {
            ClsMethod_MIS_ProjectQRcodeCertificateDetails sdb = new ClsMethod_MIS_ProjectQRcodeCertificateDetails();
            Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails getObj = new Clsprp_MIS_ProjectQRcodeOfflineCertificateDetails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQRcodeCertificateDetails_ForOfflineProjects_ForMIS(OfflineProjectId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.OfflineProject_IndexID = item.OfflineProject_IndexID;
                getObj.OfflineProject_ID = item.OfflineProject_ID;
                getObj.OfflineProject_IssueDate = item.OfflineProject_IssueDate;
                getObj.OfflineProject_ReferenceNumber = item.OfflineProject_ReferenceNumber;

                getObj.OfflineProject_Name = item.OfflineProject_Name;
                getObj.OfflineProject_Type = item.OfflineProject_Type;
                getObj.OfflineProject_TotalArea = item.OfflineProject_TotalArea;
                getObj.OfflineProject_Address = item.OfflineProject_Address;
                getObj.OfflineProject_BusinessPlaceDistrict = item.OfflineProject_BusinessPlaceDistrict;

                getObj.OfflinePromoter_Name = item.OfflinePromoter_Name;
                getObj.OfflinePromoter_Type = item.OfflinePromoter_Type;
                getObj.OfflinePromoter_BusinessPlace_Address = item.OfflinePromoter_BusinessPlace_Address;

                getObj.OfflineProject_RERAregistrationNumber = item.OfflineProject_RERAregistrationNumber;
                getObj.OfflineProject_RERAregistrationIssueDate = item.OfflineProject_RERAregistrationIssueDate;
                getObj.OfflineProject_RERAregistrationValidUptoDate = item.OfflineProject_RERAregistrationValidUptoDate;

                getObj.OfflineProject_ContactDetails = item.OfflineProject_ContactDetails;
                getObj.OfflineProject_RemarksIfAny = item.OfflineProject_RemarksIfAny;

                getObj.A_column = item.A_column;
                getObj.B_column = item.B_column;
                getObj.C_column = item.C_column;

                getObj.QRcodeImage_A = item.QRcodeImage_A;
                getObj.QRcodeImage_B = item.QRcodeImage_B;
                getObj.QRcodeImage_C = item.QRcodeImage_C;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsPublicView = item.IsPublicView;
                getObj.IsCertificate = item.IsCertificate;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("ProjectQRcodeCertificateDetailsForOfflineProjectsMIS", getObj);
        }

        public void ExportOfflinewithQRcodeToExcel()
        {
            var objXlslist = Session["modelProjectQRcodeOfflineCertificateMIS"] as List<Clsprp_MIS_ProjectQRcodeOfflineCertificateExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Reference Number";
            workSheet.Cells[1, 3].Value = "Reference Date";
            workSheet.Cells[1, 4].Value = "Project Name";
            workSheet.Cells[1, 5].Value = "Project Type";
            workSheet.Cells[1, 6].Value = "Project Total Area (In sqrmtrs)";
            workSheet.Cells[1, 7].Value = "Project Address";
            workSheet.Cells[1, 8].Value = "District of Business Place";
            workSheet.Cells[1, 9].Value = "Promoter Name";
            workSheet.Cells[1, 10].Value = "Place of Business Address";
            workSheet.Cells[1, 11].Value = "RERA Number";
            workSheet.Cells[1, 12].Value = "Issue Date";
            workSheet.Cells[1, 13].Value = "Valid upto Date";
            workSheet.Cells[1, 14].Value = "QR Code Image";
            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.OfflineProject_ReferenceNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.OfflineProject_IssueDate.HasValue ? QRcodeItem.OfflineProject_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.OfflineProject_Name;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.OfflineProject_Type;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.OfflineProject_TotalArea;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.OfflineProject_Address;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.OfflineProject_BusinessPlaceDistrict;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.OfflinePromoter_Name;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.OfflinePromoter_BusinessPlace_Address;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.OfflineProject_RERAregistrationNumber;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.OfflineProject_RERAregistrationIssueDate.HasValue ? (QRcodeItem.OfflineProject_RERAregistrationIssueDate.Value.ToString("MM/dd/yyyy") == "01/01/0001" ? string.Empty : QRcodeItem.OfflineProject_RERAregistrationIssueDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.OfflineProject_RERAregistrationValidUptoDate.HasValue ? (QRcodeItem.OfflineProject_RERAregistrationValidUptoDate.Value.ToString("MM/dd/yyyy") == "01/01/0001" ? string.Empty : QRcodeItem.OfflineProject_RERAregistrationValidUptoDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;

                Stream streamQR = new MemoryStream(GenerateQrCodeByBytesForOfflineProjects(QRcodeItem.OfflineProject_RERAregistrationNumber, QRcodeItem.OfflineProject_RERAregistrationValidUptoDate, QRcodeItem.OfflineProject_Name, QRcodeItem.OfflineProject_Type, QRcodeItem.OfflinePromoter_Name, QRcodeItem.OfflineProject_Address));
                var cfPhoto = System.Drawing.Image.FromStream(streamQR);
                var cfBm = new Bitmap(cfPhoto, new Size(215, 170));
                ExcelPicture imgQR = workSheet.Drawings.AddPicture(QRcodeItem.OfflineProject_RERAregistrationNumber.ToString(), cfBm);
                imgQR.SetPosition(recordIndex - 1, 5, 13, 5);
                imgQR.SetSize(90, 90);
                workSheet.Row(recordIndex).Height = 100;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();

            workSheet.Cells["A1:N1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:N1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 14])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectQRcodeOfflineCertificates_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        public byte[] GenerateQrCodeByBytesForProjects(string qrRERAnumber, DateTime? qrValidUptoDate, string qrProjectName, string qrProjectType, string qrPromoterName, string qrProjectAddressLine1, string qrProjectAddressLine2, string qrProjectDistrictName, string qrProjectStateName)
        {
            string qrcodestring = string.Empty;            
            string qrValidUptoDatestring = string.Empty;
            
            qrValidUptoDatestring = qrValidUptoDate.HasValue ? qrValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDatestring + ") " + qrProjectName + " (" + qrProjectType + "), " + qrPromoterName + ", " + qrProjectAddressLine1 + ", " + qrProjectAddressLine2 + ", " + qrProjectDistrictName + ", " + qrProjectStateName;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return byteArray;
        }
        public ActionResult GenerateQrCodeByRegisteredProjectID(string qrRERAnumber, DateTime qrValidUptoDate, string qrProjectName, string qrProjectType, string qrPromoterName, string qrProjectAddressLine1, string qrProjectAddressLine2, string qrProjectDistrictName, string qrProjectStateName)
        {
            string qrcodestring = string.Empty;            
            
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDate.ToString("dd'/'MM'/'yyyy") + ") " + qrProjectName + " (" + qrProjectType + "), " + qrPromoterName + ", " + qrProjectAddressLine1 + ", " + qrProjectAddressLine2 + ", " + qrProjectDistrictName + ", " + qrProjectStateName;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return File(byteArray, "image/jpeg");
        }

        public byte[] GenerateQrCodeByBytesForOfflineProjects(string qrRERAnumber, DateTime? qrValidUptoDate, string qrProjectName, string qrProjectType, string qrPromoterName, string qrProjectAddressPlaceOfBussiness)
        {
            string qrcodestring = string.Empty;
            string qrValidUptoDatestring = string.Empty;

            qrValidUptoDatestring = qrValidUptoDate.HasValue ? (qrValidUptoDate.Value.ToString("MM/dd/yyyy") == "01/01/0001" ? string.Empty : qrValidUptoDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDatestring + ") " + qrProjectName + " (" + qrProjectType + "), " + qrPromoterName + ", " + qrProjectAddressPlaceOfBussiness;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return byteArray;
        }
        public ActionResult GenerateQrCodeByOfflineProjectID(string qrRERAnumber, DateTime? qrValidUptoDate, string qrProjectName, string qrProjectType, string qrPromoterName, string qrProjectAddressPlaceOfBussiness)
        {
            string qrcodestring = string.Empty;
            string qrValidUptoDatestring = string.Empty;

            qrValidUptoDatestring = qrValidUptoDate.HasValue ? (qrValidUptoDate.Value.ToString("MM/dd/yyyy") == "01/01/0001" ? string.Empty : qrValidUptoDate.Value.ToString("dd-MMM-yyyy")) : string.Empty;
            qrcodestring = qrRERAnumber + " (Valid upto " + qrValidUptoDatestring + ") " + qrProjectName + " (" + qrProjectType + "), " + qrPromoterName + ", " + qrProjectAddressPlaceOfBussiness;
            Bitmap qrCodeImage = RenderQrCode(qrcodestring);
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return File(byteArray, "image/jpeg");
        }

        public static byte[] ConvertToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private Bitmap RenderQrCode(string qrcodestring)
        {
            string level = "L"; //comboBoxECC.SelectedItem.ToString();

            int iconSize = 0;
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                //using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBoxQRCode.Text, eccLevel))
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcodestring, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap img = qrCode.GetGraphic(20, Color.Black, Color.White, GetIconBitmap(), iconSize);
                        return img;
                    }
                }
            }
        }
        private Bitmap GetIconBitmap()
        {
            Bitmap img = null;
            string iconPath = " ";
            if (iconPath.Length > 0)
            {
                try
                {
                    img = new Bitmap(iconPath);
                }
                catch (Exception)
                {
                }
            }
            return img;
        }
        #endregion

        #region Project Annual Statements of Account (Form-5)
        [HttpGet]
        public ActionResult Display_ProjectFormFiveDetailsForRegisteredProjectsMIS()
        {
            ClsMethodMIS_ProjectStatementofAccountsFormFive sdb = new ClsMethodMIS_ProjectStatementofAccountsFormFive();
            ClsprpMIS_ProjectStatementofAccountsFormFive getObj = new ClsprpMIS_ProjectStatementofAccountsFormFive();
            ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel aaXls = new ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectFormFiveDetails_ForRegisteredProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel aaXlsInner = new ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel();

                aaXlsInner.Project_DiaryNumber = item.ProjectStatementofAccountsRelated_ProjectDiaryNumber;
                aaXlsInner.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                aaXlsInner.Project_Name = item.Project_Name;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.ProjectStatementofAccounts_DiaryNumber = item.ProjectStatementofAccounts_DiaryNumber;
                aaXlsInner.CreatedOn = item.ModifyOn;
                aaXlsInner.FinancialYear_EndingOnDate = item.FinancialYear_EndingOnDate;
                aaXlsInner.FormB_CompletionDate = item.FormB_CompletionDate;

                aaXlsInner.Percentage_of_Completion = item.Percentage_of_Completion;
                aaXlsInner.CollectedDuring_FinancialYear_Amount_INR = item.CollectedDuring_FinancialYear_Amount_INR;
                aaXlsInner.CollectedTillDate_Amount_INR = item.CollectedTillDate_Amount_INR;
                aaXlsInner.WithdrawDuring_FinancialYear_Amount_INR = item.WithdrawDuring_FinancialYear_Amount_INR;
                aaXlsInner.WithdrawnTillDate_Amount_INR = item.WithdrawnTillDate_Amount_INR;
                aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectFormFiveMIS"] = aaXls.prpongoing;

            return View("Display_ProjectFormFiveDetailsForRegisteredProjectsMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectFormFiveDetailsForRegisteredProjectsMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethodMIS_ProjectStatementofAccountsFormFive sdb = new ClsMethodMIS_ProjectStatementofAccountsFormFive();
            ClsprpMIS_ProjectStatementofAccountsFormFive getObj = new ClsprpMIS_ProjectStatementofAccountsFormFive();
            ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel aaXls = new ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectFormFiveDetails_ForRegisteredProjects_ByParmDate(UserID_Role, FromDateM, ToDateM).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel aaXlsInner = new ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel();

                    aaXlsInner.Project_DiaryNumber = item.ProjectStatementofAccountsRelated_ProjectDiaryNumber;
                    aaXlsInner.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                    aaXlsInner.ProjectStatementofAccounts_DiaryNumber = item.ProjectStatementofAccounts_DiaryNumber;
                    aaXlsInner.CreatedOn = item.ModifyOn;
                    aaXlsInner.FinancialYear_EndingOnDate = item.FinancialYear_EndingOnDate;
                    aaXlsInner.FormB_CompletionDate = item.FormB_CompletionDate;

                    aaXlsInner.Percentage_of_Completion = item.Percentage_of_Completion;
                    aaXlsInner.CollectedDuring_FinancialYear_Amount_INR = item.CollectedDuring_FinancialYear_Amount_INR;
                    aaXlsInner.CollectedTillDate_Amount_INR = item.CollectedTillDate_Amount_INR;
                    aaXlsInner.WithdrawDuring_FinancialYear_Amount_INR = item.WithdrawDuring_FinancialYear_Amount_INR;
                    aaXlsInner.WithdrawnTillDate_Amount_INR = item.WithdrawnTillDate_Amount_INR;
                    aaXlsInner.Remarks_IfAny = item.Remarks_IfAny;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectFormFiveMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectFormFiveDetailsForRegisteredProjectsMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectFormFiveDetailsForRegisteredProjectsMIS(Int64 ProjectId, Int64 PromoterId, Int64 FrmfiveId, string FrmfiveDNId)
        {
            ClsMethodMIS_ProjectStatementofAccountsFormFive sdb = new ClsMethodMIS_ProjectStatementofAccountsFormFive();
            ClsprpMIS_ProjectStatementofAccountsFormFive getObj = new ClsprpMIS_ProjectStatementofAccountsFormFive();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectFormFiveDetails_ForRegisteredProjects_ForMIS(ProjectId, PromoterId, FrmfiveId, FrmfiveDNId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.ProjectStatementofAccounts_IndexID = item.ProjectStatementofAccounts_IndexID;
                getObj.ProjectStatementofAccounts_ID = item.ProjectStatementofAccounts_ID;
                getObj.ProjectStatementofAccounts_DiaryNumber = item.ProjectStatementofAccounts_DiaryNumber;
                getObj.ProjectStatementofAccounts_DiaryID = item.ProjectStatementofAccounts_DiaryID;
                getObj.ProjectStatementofAccounts_DiaryYear = item.ProjectStatementofAccounts_DiaryYear;

                getObj.ProjectStatementofAccountsRelated_ProjectID = item.ProjectStatementofAccountsRelated_ProjectID;
                getObj.ProjectStatementofAccountsRelated_ProjectName = item.ProjectStatementofAccountsRelated_ProjectName;
                getObj.ProjectStatementofAccountsRelated_ProjectDiaryNumber = item.ProjectStatementofAccountsRelated_ProjectDiaryNumber;

                getObj.ProjectStatementofAccountsRelated_PromoterID = item.ProjectStatementofAccountsRelated_PromoterID;
                getObj.ProjectStatementofAccountsRelated_UserID = item.ProjectStatementofAccountsRelated_UserID;
                getObj.FinancialYear_EndingOnDate = item.FinancialYear_EndingOnDate;
                getObj.FormB_CompletionDate = item.FormB_CompletionDate;
                getObj.Percentage_of_Completion = item.Percentage_of_Completion;
                getObj.ExplanatoryNote = item.ExplanatoryNote;

                getObj.CollectedDuring_FinancialYear_Amount_INR = item.CollectedDuring_FinancialYear_Amount_INR;
                getObj.CollectedTillDate_Amount_INR = item.CollectedTillDate_Amount_INR;
                getObj.WithdrawDuring_FinancialYear_Amount_INR = item.WithdrawDuring_FinancialYear_Amount_INR;
                getObj.WithdrawnTillDate_Amount_INR = item.WithdrawnTillDate_Amount_INR;
                getObj.Amount_A_column = item.Amount_A_column;
                getObj.Amount_B_column = item.Amount_B_column;

                getObj.ImageFormFive_FileName = item.ImageFormFive_FileName;
                getObj.ImageFormFive_FilePath = item.ImageFormFive_FilePath;
                getObj.ImageFormFive_FileSize = item.ImageFormFive_FileSize;
                getObj.ImageFormFive_FileFormat = item.ImageFormFive_FileFormat;

                getObj.A_column = item.A_column;
                getObj.B_column = item.B_column;
                getObj.C_column = item.C_column;
                getObj.Remarks_IfAny = item.Remarks_IfAny;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsEvaluationDraft = item.IsEvaluationDraft;
                getObj.IsMemberDraft = item.IsMemberDraft;
                getObj.IsSecretaryDraft = item.IsSecretaryDraft;
                getObj.IsAuthorityDraft = item.IsAuthorityDraft;
                getObj.IsPublicView = item.IsPublicView;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;

                getObj.Project_DiaryNumber = item.Project_DiaryNumber;
                getObj.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                getObj.Project_Name = item.Project_Name;
                getObj.Promoter_Name = item.Promoter_Name;
                getObj.RERAnumberRegistration = item.RERAnumberRegistration;
                getObj.RERAnumberIssueDate = item.RERAnumberIssueDate;
                getObj.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
            }
            return View("ProjectFormFiveDetailsForRegisteredProjectsMIS", getObj);
        }

        public void ExportwithFormFiveToExcel()
        {
            var objXlslist = Session["modelProjectFormFiveMIS"] as List<ClsprpMIS_ProjectStatementofAccountsFormFiveExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Statement of Accounts Reference Date";
            workSheet.Cells[1, 5].Value = "Project Name";
            workSheet.Cells[1, 6].Value = "Promoter Name";

            workSheet.Cells[1, 7].Value = "Registration Number";
            workSheet.Cells[1, 8].Value = "Registration Issue Date";
            workSheet.Cells[1, 9].Value = "Registration Valid Upto Date";
            workSheet.Cells[1, 10].Value = "Financial Year ending on (31st March)";
            workSheet.Cells[1, 11].Value = "Percentage of Completion";

            workSheet.Cells[1, 12].Value = "Amount collected during the financial year (INR)";
            workSheet.Cells[1, 13].Value = "Amount collected till date (INR)";
            workSheet.Cells[1, 14].Value = "Amount withdraw during the financial year (INR)";
            workSheet.Cells[1, 15].Value = "Amount withdrawn till date (INR)";
            workSheet.Cells[1, 16].Value = "Remarks, if Any";
           
            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Project_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Project_Diary_ApplicationDate.ToString("dd-MMM-yyyy");
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.CreatedOn.ToString("dd-MMM-yyyy");
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.Project_Name;
                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Promoter_Name;

                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.RERAnumberRegistration;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.RERAnumberIssueDate.HasValue ? QRcodeItem.RERAnumberIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.RERAnumberRegUptoDate.HasValue ? QRcodeItem.RERAnumberRegUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.FinancialYear_EndingOnDate;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.Percentage_of_Completion;

                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.CollectedDuring_FinancialYear_Amount_INR;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.CollectedTillDate_Amount_INR;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.WithdrawDuring_FinancialYear_Amount_INR;
                workSheet.Cells[recordIndex, 15].Value = QRcodeItem.WithdrawnTillDate_Amount_INR;
                workSheet.Cells[recordIndex, 16].Value = QRcodeItem.Remarks_IfAny;                

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();

            workSheet.Cells["A1:P1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:P1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 16])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectFormFive_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ExportToExcelFF()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectFormFiveMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=ListofProjectFormFive_" + strDateFormat + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Project InComplete Reminder Emails (Notice)
        [HttpGet]
        public ActionResult Display_ProjectReminderEmailsDetailsForMIS()
        {
            ClsMethodMIS_ProjectReminderEmailsDetails sdb = new ClsMethodMIS_ProjectReminderEmailsDetails();
            ClsprpMIS_ProjectInCompleteRemindersEmails getObj = new ClsprpMIS_ProjectInCompleteRemindersEmails();
            ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel aaXls = new ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectReminderEmailsDetails_ForRegisteredProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel aaXlsInner = new ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel();

                aaXlsInner.Project_DiaryNumber = item.Project_DiaryNumber;
                aaXlsInner.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                aaXlsInner.Project_Name = item.Project_Name;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                aaXlsInner.Event_AggregateName = item.Event_AggregateName;
                aaXlsInner.ReminderType = item.ReminderType;
                aaXlsInner.EmailsAddressDetails = item.EmailsAddressDetails;
                aaXlsInner.EmailsAddressCount = item.EmailsAddressCount;
                aaXlsInner.Email_SentDate = item.Email_SentDate;
                aaXlsInner.Email_TitleSubject = item.Email_TitleSubject;
                aaXlsInner.Remarks_IfAny = item.A_Column;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectReminderEmailsMIS"] = aaXls.prpongoing;

            return View("Display_ProjectReminderEmailsDetailsForMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectReminderEmailsDetailsForMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethodMIS_ProjectReminderEmailsDetails sdb = new ClsMethodMIS_ProjectReminderEmailsDetails();
            ClsprpMIS_ProjectInCompleteRemindersEmails getObj = new ClsprpMIS_ProjectInCompleteRemindersEmails();
            ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel aaXls = new ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;
                Int32 ReminderNumberType = 0;
                string ReminderCasesType = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectReminderEmailsDetails_ForRegisteredProjects_ByParmDate(UserID_Role, FromDateM, ToDateM, ReminderNumberType, ReminderCasesType).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel aaXlsInner = new ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel();

                    aaXlsInner.Project_DiaryNumber = item.Project_DiaryNumber;
                    aaXlsInner.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                    aaXlsInner.Event_AggregateName = item.Event_AggregateName;
                    aaXlsInner.ReminderType = item.ReminderType;
                    aaXlsInner.EmailsAddressDetails = item.EmailsAddressDetails;
                    aaXlsInner.EmailsAddressCount = item.EmailsAddressCount;
                    aaXlsInner.Email_SentDate = item.Email_SentDate;
                    aaXlsInner.Email_TitleSubject = item.Email_TitleSubject;
                    aaXlsInner.Remarks_IfAny = item.A_Column;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectReminderEmailsMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectReminderEmailsDetailsForMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectReminderEmailsShowContentDetailsForMIS(Int64 ProjectId, Int64 PromoterId, Int64 ReminderLogId)
        {
            ClsMethodMIS_ProjectReminderEmailsDetails sdb = new ClsMethodMIS_ProjectReminderEmailsDetails();
            ClsprpMIS_ProjectInCompleteRemindersEmails getObj = new ClsprpMIS_ProjectInCompleteRemindersEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectReminderEmailsDetails_ForRegisteredProjects_ShowContent(ProjectId, PromoterId, userRole, ReminderLogId);

            foreach (var item in getObj.prpongoing)
            {
                getObj.ProjectReminderLog_IndexID = item.ProjectReminderLog_IndexID;
                getObj.ProjectReminderLog_ID = item.ProjectReminderLog_ID;
                getObj.Related_ProjectReminder_IndexID = item.Related_ProjectReminder_IndexID;
                getObj.Related_ProjectReminder_ID = item.Related_ProjectReminder_ID;
                getObj.Project_ID = item.Project_ID;
                getObj.Promoter_ID = item.Promoter_ID;

                getObj.Project_Name = item.Project_Name;
                getObj.Promoter_Name = item.Promoter_Name;
                getObj.Project_DiaryNumber = item.Project_DiaryNumber;
                getObj.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.Event_AggregateName = item.Event_AggregateName;

                getObj.ReminderType = item.ReminderType;
                getObj.ReminderTargetDate = item.ReminderTargetDate;
                getObj.ReminderResolutionDate = item.ReminderResolutionDate;
                getObj.EmailsAddressDetails = item.EmailsAddressDetails;
                getObj.EmailsAddressCount = item.EmailsAddressCount;
                getObj.Email_SentDate = item.Email_SentDate;
                getObj.Email_TitleSubject = item.Email_TitleSubject;
                getObj.Email_ContentBody = item.Email_ContentBody;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;

                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;
                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;

                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;
                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;
            }
            return View("ProjectReminderEmailsShowContentDetailsForMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectReminderEmailSchedulerContentDetailsForMIS(Int64 ProjectId, Int64 PromoterId)
        {
            ClsMethodMIS_ProjectReminderEmailsDetails sdb = new ClsMethodMIS_ProjectReminderEmailsDetails();
            ClsMethodMIS_ProjectReminderSMSgatewayDetails sdbSMSgateway = new ClsMethodMIS_ProjectReminderSMSgatewayDetails();
            ClsprpMIS_ProjectInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_ProjectInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectSchedulerReminderEmailsDetails_ForProjects(ProjectId, PromoterId, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_ProjectSchedulerReminderSMSsDetails_ForProjects(ProjectId, PromoterId, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.ProjectReminder_IndexID = item.ProjectReminder_IndexID;
                getObj.ProjectReminder_ID = item.ProjectReminder_ID;
                getObj.Project_ID = item.Project_ID;
                getObj.Promoter_ID = item.Promoter_ID;

                getObj.Project_Name = item.Project_Name;
                getObj.Promoter_Name = item.Promoter_Name;
                getObj.Project_DiaryNumber = item.Project_DiaryNumber;
                getObj.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;

                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;
                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;

                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;                
            }
            return View("ProjectReminderEmailSchedulerContentDetailsForMIS", getObj);
        }

        public void ExportwithReminderEmailsToExcel()
        {
            var objXlslist = Session["modelProjectReminderEmailsMIS"] as List<ClsprpMIS_ProjectInCompleteRemindersEmailsExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Project Name";
            workSheet.Cells[1, 5].Value = "Promoter Name";

            workSheet.Cells[1, 6].Value = "Action Title";
            workSheet.Cells[1, 7].Value = "Date of Action";
            workSheet.Cells[1, 8].Value = "Reminder Type";

            workSheet.Cells[1, 9].Value = "To Emails Address Details";
            workSheet.Cells[1, 10].Value = "To Emails Count";
            workSheet.Cells[1, 11].Value = "Email Date";
            workSheet.Cells[1, 12].Value = "Subject";
            workSheet.Cells[1, 13].Value = "Remarks, if Any";

            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Project_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Project_Diary_ApplicationDate.HasValue ? QRcodeItem.Project_Diary_ApplicationDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Project_Name;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.Promoter_Name;

                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Event_AggregateName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Event_IdentifiedOnDate.HasValue ? QRcodeItem.Event_IdentifiedOnDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.ReminderType;

                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.EmailsAddressDetails;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.EmailsAddressCount;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.Email_SentDate.HasValue ? QRcodeItem.Email_SentDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.Email_TitleSubject;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.Remarks_IfAny;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 13])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectReminderEmails_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ExportToExcelReminderEmails()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectReminderEmailsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=ListofProjectReminderEmails_" + strDateFormat + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Project InComplete Reminder SMSs (Notice)
        [HttpGet]
        public ActionResult Display_ProjectReminderSMSsDetailsForMIS()
        {
            ClsMethodMIS_ProjectReminderSMSgatewayDetails sdb = new ClsMethodMIS_ProjectReminderSMSgatewayDetails();
            ClsprpMIS_ProjectInCompleteRemindersSMSgateway getObj = new ClsprpMIS_ProjectInCompleteRemindersSMSgateway();
            ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel aaXls = new ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectReminderSMSgatewayDetails_ForRegisteredProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel aaXlsInner = new ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel();

                aaXlsInner.Project_DiaryNumber = item.Project_DiaryNumber;
                aaXlsInner.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                aaXlsInner.Project_Name = item.Project_Name;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                aaXlsInner.Event_AggregateName = item.Event_AggregateName;
                aaXlsInner.ReminderType = item.ReminderType;
                aaXlsInner.SMSsMainAddress = item.SMSsMainAddress;
                aaXlsInner.SMSsAddressDetails = item.SMSsAddressDetails;
                aaXlsInner.SMSsAddressCount = item.SMSsAddressCount;
                aaXlsInner.SMS_SentDate = item.SMS_SentDate;
                aaXlsInner.SMS_TitleSubject = item.SMS_TitleSubject;
                aaXlsInner.Remarks_IfAny = item.A_Column;

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelProjectReminderSMSsMIS"] = aaXls.prpongoing;

            return View("Display_ProjectReminderSMSsDetailsForMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectReminderSMSsDetailsForMIS(DateTime? FromDate, DateTime? ToDate)
        {
            ClsMethodMIS_ProjectReminderSMSgatewayDetails sdb = new ClsMethodMIS_ProjectReminderSMSgatewayDetails();
            ClsprpMIS_ProjectInCompleteRemindersSMSgateway getObj = new ClsprpMIS_ProjectInCompleteRemindersSMSgateway();
            ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel aaXls = new ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;
                Int32 ReminderNumberType = 0;
                string ReminderCasesType = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = FromDate.HasValue ? FromDate.Value : dtvalue;
                DateTime ToDateM = ToDate.HasValue ? ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectReminderSMSgatewayDetails_ForRegisteredProjects_ByParmDate(UserID_Role, FromDateM, ToDateM, ReminderNumberType, ReminderCasesType).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel aaXlsInner = new ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel();

                    aaXlsInner.Project_DiaryNumber = item.Project_DiaryNumber;
                    aaXlsInner.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                    aaXlsInner.Event_AggregateName = item.Event_AggregateName;
                    aaXlsInner.ReminderType = item.ReminderType;
                    aaXlsInner.SMSsMainAddress = item.SMSsMainAddress;
                    aaXlsInner.SMSsAddressDetails = item.SMSsAddressDetails;
                    aaXlsInner.SMSsAddressCount = item.SMSsAddressCount;
                    aaXlsInner.SMS_SentDate = item.SMS_SentDate;
                    aaXlsInner.SMS_TitleSubject = item.SMS_TitleSubject;
                    aaXlsInner.Remarks_IfAny = item.A_Column;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelProjectReminderSMSsMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectReminderSMSsDetailsForMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectReminderSMSsShowContentDetailsForMIS(Int64 ProjectId, Int64 PromoterId, Int64 ReminderLogId)
        {
            ClsMethodMIS_ProjectReminderSMSgatewayDetails sdb = new ClsMethodMIS_ProjectReminderSMSgatewayDetails();
            ClsprpMIS_ProjectInCompleteRemindersSMSgateway getObj = new ClsprpMIS_ProjectInCompleteRemindersSMSgateway();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectReminderSMSgatewayDetails_ForRegisteredProjects_ShowContent(ProjectId, PromoterId, userRole, ReminderLogId);

            foreach (var item in getObj.prpongoing)
            {
                getObj.ProjectReminderLogSMS_IndexID = item.ProjectReminderLogSMS_IndexID;
                getObj.ProjectReminderLogSMS_ID = item.ProjectReminderLogSMS_ID;
                getObj.Related_ProjectReminderSMS_IndexID = item.Related_ProjectReminderSMS_IndexID;
                getObj.Related_ProjectReminderSMS_ID = item.Related_ProjectReminderSMS_ID;
                getObj.Project_ID = item.Project_ID;
                getObj.Promoter_ID = item.Promoter_ID;

                getObj.Project_Name = item.Project_Name;
                getObj.Promoter_Name = item.Promoter_Name;
                getObj.Project_DiaryNumber = item.Project_DiaryNumber;
                getObj.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.Event_AggregateName = item.Event_AggregateName;

                getObj.ReminderType = item.ReminderType;
                getObj.ReminderTargetDate = item.ReminderTargetDate;
                getObj.ReminderResolutionDate = item.ReminderResolutionDate;
                getObj.SMSsMainAddress = item.SMSsMainAddress;
                getObj.SMSsAddressDetails = item.SMSsAddressDetails;
                getObj.SMSsAddressCount = item.SMSsAddressCount;
                getObj.SMS_SentDate = item.SMS_SentDate;
                getObj.SMS_TitleSubject = item.SMS_TitleSubject;
                getObj.SMS_ContentBody = item.SMS_ContentBody;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;
                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;

                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;
                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;

                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;
                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;
            }
            return View("ProjectReminderSMSsShowContentDetailsForMIS", getObj);
        }

        public void ExportwithReminderSMSsToExcel()
        {
            var objXlslist = Session["modelProjectReminderSMSsMIS"] as List<ClsprpMIS_ProjectInCompleteRemindersSMSgatewayExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Project Name";
            workSheet.Cells[1, 5].Value = "Promoter Name";

            workSheet.Cells[1, 6].Value = "Action Title";
            workSheet.Cells[1, 7].Value = "Date of Action";
            workSheet.Cells[1, 8].Value = "Reminder Type";

            workSheet.Cells[1, 9].Value = "To Mobile Number";
            workSheet.Cells[1, 10].Value = "To Phone Address Details";
            workSheet.Cells[1, 11].Value = "To Phones Count";
            workSheet.Cells[1, 12].Value = "SMS Date";
            workSheet.Cells[1, 13].Value = "Subject";
            workSheet.Cells[1, 14].Value = "Remarks, if Any";

            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var QRcodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = QRcodeItem.Project_DiaryNumber;
                workSheet.Cells[recordIndex, 3].Value = QRcodeItem.Project_Diary_ApplicationDate.HasValue ? QRcodeItem.Project_Diary_ApplicationDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = QRcodeItem.Project_Name;
                workSheet.Cells[recordIndex, 5].Value = QRcodeItem.Promoter_Name;

                workSheet.Cells[recordIndex, 6].Value = QRcodeItem.Event_AggregateName;
                workSheet.Cells[recordIndex, 7].Value = QRcodeItem.Event_IdentifiedOnDate.HasValue ? QRcodeItem.Event_IdentifiedOnDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = QRcodeItem.ReminderType;

                workSheet.Cells[recordIndex, 9].Value = QRcodeItem.SMSsMainAddress;
                workSheet.Cells[recordIndex, 10].Value = QRcodeItem.SMSsAddressDetails;
                workSheet.Cells[recordIndex, 11].Value = QRcodeItem.SMSsAddressCount;
                workSheet.Cells[recordIndex, 12].Value = QRcodeItem.SMS_SentDate.HasValue ? QRcodeItem.SMS_SentDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = QRcodeItem.SMS_TitleSubject;
                workSheet.Cells[recordIndex, 14].Value = QRcodeItem.Remarks_IfAny;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();

            workSheet.Cells["A1:N1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:N1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeQR = workSheet.Cells[1, 1, recordIndex - 1, 14])
            {
                RangeQR.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Top.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Left.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Right.Color.SetColor(Color.Black);
                RangeQR.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeQR.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeQR.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeQR.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectReminderSMSs_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ExportToExcelReminderSMSs()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectReminderSMSsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=ListofProjectReminderSMSs_" + strDateFormat + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Extension-Form Project InComplete Reminder Emails (Notice)
        [HttpGet]
        public ActionResult ProjectExtnFormReminderEmailSchedulerContentDetailsForMIS(Int64 ProjectId, Int64 PromoterId, string ExtnFormDNumber)
        {
            ClsMethodMIS_ExtnFormProjectReminderEmailsDetails sdb = new ClsMethodMIS_ExtnFormProjectReminderEmailsDetails();
            ClsMethodMIS_ExtnFormProjectReminderSMSgatewayDetails sdbSMSgateway = new ClsMethodMIS_ExtnFormProjectReminderSMSgatewayDetails();
            ClsprpMIS_ExtnFormProjectInCompleteRemindersSchedulerEmails getObj = new ClsprpMIS_ExtnFormProjectInCompleteRemindersSchedulerEmails();
            string userRole = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ExtnFormProjectSchedulerReminderEmailsDetails_ForProjects(ProjectId, PromoterId, ExtnFormDNumber, userRole);
            getObj.prpSchedulerSMSgateway = sdbSMSgateway.Display_AuthDesk_MIS_ExtnFormProjectSchedulerReminderSMSsDetails_ForProjects(ProjectId, PromoterId, ExtnFormDNumber, userRole);

            foreach (var item in getObj.prpongoing)
            {
                getObj.ExtnProjectReminder_IndexID = item.ExtnProjectReminder_IndexID;
                getObj.ExtnProjectReminder_ID = item.ExtnProjectReminder_ID;
                getObj.Project_ID = item.Project_ID;
                getObj.Promoter_ID = item.Promoter_ID;
                getObj.ExtnProject_ID = item.ExtnProject_ID;

                getObj.Project_Name = item.Project_Name;
                getObj.Promoter_Name = item.Promoter_Name;
                getObj.Project_DiaryNumber = item.Project_DiaryNumber;
                getObj.ExtnProject_DiaryNumber = item.ExtnProject_DiaryNumber;
                getObj.Project_Diary_ApplicationDate = item.Project_Diary_ApplicationDate;

                getObj.RERA_Registration_Number = item.RERA_Registration_Number;
                getObj.RERA_Registration_ValiduptoDate = item.RERA_Registration_ValiduptoDate;

                getObj.Event_Type = item.Event_Type;
                getObj.Event_IdentifiedOnDate = item.Event_IdentifiedOnDate;
                getObj.ROneFlag = item.ROneFlag;
                getObj.DateROne = item.DateROne;

                getObj.RTwoFlag = item.RTwoFlag;
                getObj.DateRTwo = item.DateRTwo;
                getObj.RThreeFlag = item.RThreeFlag;
                getObj.DateRThree = item.DateRThree;

                getObj.RFourFlag = item.RFourFlag;
                getObj.DateRFour = item.DateRFour;

                getObj.A_Column = item.A_Column;
                getObj.B_Column = item.B_Column;
                getObj.C_Column = item.C_Column;
                getObj.D_Column = item.D_Column;

                getObj.IsActive = item.IsActive;
                getObj.IsDraft = item.IsDraft;
                getObj.IsLock = item.IsLock;

                getObj.CreatedBy = item.CreatedBy;
                getObj.CreatedOn = item.CreatedOn;
                getObj.ModifyBy = item.ModifyBy;
                getObj.ModifyOn = item.ModifyOn;
            }
            return View("ProjectExtnFormReminderEmailSchedulerContentDetailsForMIS", getObj);
        }
        #endregion

        #region Project FileTime Index Reports
        #region Project Elementry Records FileTime (MIS Reports)
        [HttpGet]
        public ActionResult Display_ProjectFileTimeDetailsForMIS()
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeDetails getObj = new Clsprp_MIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeExportExcel aaXls = new Clsprp_MIS_ProjectAverageFileTimeExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectElementaryFileTimeDetails_ForProjects(UserID_Role).ToList();

            foreach (var item in getObj.prpongoing)
            {
                Clsprp_MIS_ProjectAverageFileTimeExportExcel aaXlsInner = new Clsprp_MIS_ProjectAverageFileTimeExportExcel();

                aaXlsInner.Activity_Name = item.EventAction_Aggregate;
                aaXlsInner.NumberOfApplications = item.NumberOfApplications;                

                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelXlsProjectElementaryIndexMIS"] = aaXls.prpongoing;

            return View("Display_ProjectFileTimeDetailsForMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectFileTimeDetailsForMIS(Clsprp_MIS_ProjectAverageFileTimeDetails smodel)
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeDetails getObj = new Clsprp_MIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeExportExcel aaXls = new Clsprp_MIS_ProjectAverageFileTimeExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;
                Int32 flagApplicationMode = 0;
                Int32 flagApplicationDate = 0;

                flagApplicationMode = smodel.IsApplicationModeFlag;
                flagApplicationDate = smodel.IsApplicationDateFlag;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectElementaryFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM).ToList();
                ViewBag.data = "true";

                Session["modelProjectFileElementaryIndexMIS"] = getObj.prpongoing;

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectAverageFileTimeExportExcel aaXlsInner = new Clsprp_MIS_ProjectAverageFileTimeExportExcel();

                    aaXlsInner.Activity_Name = item.EventAction_Aggregate;
                    aaXlsInner.NumberOfApplications = item.NumberOfApplications;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectElementaryIndexMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectFileTimeDetailsForMIS", getObj);
        }

        public JsonResult GetSpiderChartProjectActivityIndexLiveReportsData(string IndexId, Int32 ApplicationModeCode)
        {
            Int32 valApplicationMode = 0;
            if (ApplicationModeCode == 0)
            {
                valApplicationMode = 51;
            }
            else
            {
                valApplicationMode = ApplicationModeCode;
            }
            var objXlslist = Session["modelProjectFileElementaryIndexMIS"] as List<Clsprp_MIS_ProjectAverageFileTimeDetails>;

            var spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int>();
            var spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int>();
            var spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int>();

            var spiderwebChartModel = new ClsPrp_ProjectIndexActivity_SpiderWebChartsLiveReportProjectRecords<int>
            {
                LiveReportProjectIndexSpiderChartsTitleData = new List<ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int>>(),
                LiveReportProjectIndexSpiderChartsCollectionData = new List<ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int>>(),
                LiveReportProjectIndexSpiderChartsProcessedData = new List<ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int>>()
            };

            if (objXlslist != null)
            {
                int varCollection = 0;
                int varProcessed1 = 0;
                int varProcessed2 = 0;
                int varProcessed3 = 0;
                int varProcessed4 = 0;
                int varProcessed5 = 0;
                int varProcessed6 = 0;
                string varTitle = string.Empty;

                if (valApplicationMode == 51)
                {
                    foreach (var item in objXlslist)
                    {
                        if (item.EventAction_Type == 110001)
                        {
                            varCollection = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 110019)
                        {
                            varProcessed2 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 110006)
                        {
                            varProcessed3 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 110007 || item.EventAction_Type == 110010 || item.EventAction_Type == 110011 || item.EventAction_Type == 110012)
                        {
                            varProcessed4 = varProcessed4 + Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 110017)
                        {
                            varProcessed5 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 110020 || item.EventAction_Type == 110023)
                        {
                            varProcessed6 = varProcessed6 + Convert.ToInt32(item.NumberOfApplications);
                        }
                    }
                }
                else if(valApplicationMode == 52)
                {
                    foreach (var item in objXlslist)
                    {
                        if (item.EventAction_Type == 150001)
                        {
                            varCollection = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 150010)
                        {
                            varProcessed2 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 150006)
                        {
                            varProcessed3 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 150007)
                        {
                            varProcessed4 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 150017)
                        {
                            varProcessed5 = Convert.ToInt32(item.NumberOfApplications);
                        }
                        if (item.EventAction_Type == 150020) // Pending
                        {
                            varProcessed6 = Convert.ToInt32(item.NumberOfApplications);
                        }
                    }
                }
                else if (valApplicationMode == 53)
                {       
                    // Pending           
                    varCollection = Convert.ToInt32(0);
                }

                varProcessed1 = varCollection;
                for (int i = 1; i < 7; i++)
                {
                    if (i == 1)
                    {
                        spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int> { collectionvalue = varCollection };
                        spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int> { processedvalue = varProcessed1 };
                        spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int> { name = "Application Submitted" };
                    }
                    if (i == 2)
                    {
                        spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int> { collectionvalue = varCollection };
                        spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int> { processedvalue = varProcessed2 };
                        spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int> { name = "Evaluation of Application (General and Finance)" };
                    }
                    if (i == 3)
                    {
                        spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int> { collectionvalue = varCollection };
                        spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int> { processedvalue = varProcessed3 };
                        spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int> { name = "Application CheckList Prepared" };
                    }
                    if (i == 4)
                    {
                        spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int> { collectionvalue = varCollection };
                        spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int> { processedvalue = varProcessed4 };
                        spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int> { name = "In-Complete Application (Additional Information Sought by the Authority)" };
                    }
                    if (i == 5)
                    {
                        spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int> { collectionvalue = varCollection };
                        spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int> { processedvalue = varProcessed5 };
                        spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int> { name = "Application Approved for Registration" };
                    }
                    if (i == 6)
                    {
                        spiderwebChartCollectionValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsCollectionSeries<int> { collectionvalue = varCollection };
                        spiderwebChartProcessedValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsProcessedSeries<int> { processedvalue = varProcessed6 };
                        spiderwebChartTitleValue = new ClsPrp_ProjectIndexActivity_LiveReportSpiderWebChartsTitleSeries<int> { name = "Application moved for Public View" };
                    }


                    spiderwebChartModel.LiveReportProjectIndexSpiderChartsTitleData.Add(spiderwebChartTitleValue);
                    spiderwebChartModel.LiveReportProjectIndexSpiderChartsCollectionData.Add(spiderwebChartCollectionValue);
                    spiderwebChartModel.LiveReportProjectIndexSpiderChartsProcessedData.Add(spiderwebChartProcessedValue);
                }
            }

            return Json(spiderwebChartModel, JsonRequestBehavior.AllowGet);
        }

        public void ExportwithElementaryFileTimeToExcel()
        {
            var objXlslist = Session["modelXlsProjectElementaryIndexMIS"] as List<Clsprp_MIS_ProjectAverageFileTimeExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;
            
            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Activity's Name";
            workSheet.Cells[1, 3].Value = "Number of Applications";
            
            //Body of table
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.Activity_Name;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.NumberOfApplications;
                
                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();            

            workSheet.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 3])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectElementaryActivityIndex_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region Project Detailed Recrods FileTime (MIS Reports)
        [HttpGet]
        public ActionResult Display_ProjectFileTimeRecordsDetailsForMIS()
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails getObj = new Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails();
            Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel aaXls = new Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel();

            try
            {
                var now = DateTime.Now;
                string UserID_Role = string.Empty;
                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectRecordsFileTimeDetails_ForProjects(UserID_Role).ToList();

                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel aaXlsInner = new Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel();

                    aaXlsInner.Diary_Number = item.Project_DiaryNumber;
                    aaXlsInner.Application_Date = item.ApplicationDate_IdentifiedOn;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.LastActivity_Name = item.LastActivity_EventAction_Aggregate;
                    aaXlsInner.LastActivity_Date = item.LastActivity_EventAction_IdentifiedOn;
                    aaXlsInner.ApplicationApproved_Date = item.ApplicationApprovalDate;
                    aaXlsInner.RegistrationApproved_Days = item.RegistrationApproval_Days;
                    aaXlsInner.LastActionbyRERA_Days = item.LastActionbyRERA_Days;
                    aaXlsInner.ApplicationReceived_Days = item.ApplicationRecipt_Days;
                    aaXlsInner.NoReplyByPromoter_Days = item.A_column;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectDetailRecordsMIS"] = aaXls.prpongoing;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectFileTimeRecordsDetailsForMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_ProjectFileTimeRecordsDetailsForMIS(Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails smodel)
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails getObj = new Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails();
            Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel aaXls = new Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel();

            try
            {
                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationMode = 0;
                    Int32 flagApplicationDate = 0;
                    Int32 varprmRange = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;

                    flagApplicationMode = smodel.IsApplicationModeFlag; //radioSearchFor
                    flagApplicationDate = smodel.IsApplicationDateFlag; //radioRangeDifferentMode

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }               
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                            //Task has been started
                            Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationMode, flagApplicationDate, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);
                        });
                    }
                    await Task.WhenAll(taskA);

                    ViewBag.data = "true";
                    Session["modelProjectFileActivityIndexMIS"] = getObj.prpongoing;

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel aaXlsInner = new Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel();

                        aaXlsInner.Diary_Number = item.Project_DiaryNumber;
                        aaXlsInner.Application_Date = item.ApplicationDate_IdentifiedOn;
                        aaXlsInner.Project_Name = item.Project_Name;
                        aaXlsInner.LastActivity_Name = item.LastActivity_EventAction_Aggregate;
                        aaXlsInner.LastActivity_Date = item.LastActivity_EventAction_IdentifiedOn;
                        aaXlsInner.ApplicationApproved_Date = item.ApplicationApprovalDate;
                        aaXlsInner.RegistrationApproved_Days = item.RegistrationApproval_Days;
                        aaXlsInner.LastActionbyRERA_Days = item.LastActionbyRERA_Days;
                        aaXlsInner.ApplicationReceived_Days = item.ApplicationRecipt_Days;
                        aaXlsInner.NoReplyByPromoter_Days = item.A_column;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelXlsProjectDetailRecordsMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();                
            }            
            return View("Display_ProjectFileTimeRecordsDetailsForMIS", getObj);
        }

        [HttpGet]
        public ActionResult ProjectFileTimeRecordsShowNoReplybyPromotersForMIS(Int64 ProjectId, Int64 PromoterId, Int32 ApplicationFlagId)
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters getObj = new Clsprp_MIS_ProjectAverageFileTimeNoReplyByPromoters();

            try
            {
                string userRole = string.Empty;
                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectRecordsFileTimeNoReplyFromPromotersByID(userRole, ApplicationFlagId, ProjectId, PromoterId);

                foreach (var item in getObj.prpongoing)
                {
                    getObj.IndexCode = item.IndexCode;
                    getObj.Related_Project_ID = item.Related_Project_ID;
                    getObj.Related_Promoter_ID = item.Related_Promoter_ID;
                    getObj.Project_DiaryNumber = item.Project_DiaryNumber;

                    getObj.FromDate_EventAction_IdentifiedOn = item.FromDate_EventAction_IdentifiedOn;
                    getObj.ToDate_EventAction_IdentifiedOn = item.ToDate_EventAction_IdentifiedOn;
                    getObj.NoReplybyPromoters_Days = item.NoReplybyPromoters_Days;

                    getObj.A_column = item.A_column;
                    getObj.B_column = item.B_column;
                    getObj.C_column = item.C_column;
                    getObj.D_column = item.D_column;
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("ProjectFileTimeRecordsShowNoReplybyPromotersForMIS", getObj);
        }      

        public JsonResult GetRotatelevelsChartProjectActivityIndexLiveReportsData(string IndexId)
        {
            var objXlslist = Session["modelProjectFileActivityIndexMIS"] as List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordDetails>;


            var rotatelevelsChartValue = new ClsPrp_ProjectIndexActivity_LiveReportProjectRecordsRotatelevelsChartsSeries<int>();
            var rotatelevelsChartModel = new ClsPrp_ProjectIndexActivity_RotatelevelsChartsLiveReportProjectRecords<int>
            {
                LiveReportProjectIndexRecordsRotatelevelsChartsData = new List<ClsPrp_ProjectIndexActivity_LiveReportProjectRecordsRotatelevelsChartsSeries<int>>()
            };

            if (objXlslist != null)
            {
                int varDays = 0;
                foreach (var item in objXlslist)
                {
                    if (item.ApplicationRecipt_Days != "NA")
                    {
                        varDays = Convert.ToInt32(item.ApplicationRecipt_Days);
                    }
                    else
                    {
                        varDays = Convert.ToInt32(item.LastActionbyRERA_Days);
                    }

                    rotatelevelsChartValue = new ClsPrp_ProjectIndexActivity_LiveReportProjectRecordsRotatelevelsChartsSeries<int> { name = item.Project_DiaryNumber.ToString(), y = varDays };
                    rotatelevelsChartModel.LiveReportProjectIndexRecordsRotatelevelsChartsData.Add(rotatelevelsChartValue);
                }
            }

            return Json(rotatelevelsChartModel, JsonRequestBehavior.AllowGet);
        }

        public void ExportwithDetailRecordsFileTimeToExcel()
        {
            var objXlslist = Session["modelXlsProjectDetailRecordsMIS"] as List<Clsprp_MIS_ProjectAverageFileTimeProjectRecordExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Project Name";

            workSheet.Cells[1, 5].Value = "Date of Application Approved for Registration";

            workSheet.Cells[1, 6].Value = "No. of Days (Application Approved for Registration)";
            workSheet.Cells[1, 7].Value = "No. of Days (Last Action by RERA)";
            workSheet.Cells[1, 8].Value = "No. of Days (Application Received)";
            workSheet.Cells[1, 9].Value = "No. of Days (No Reply by Promoter)";

            workSheet.Cells[1, 10].Value = "Date of Last Action by RERA";
            workSheet.Cells[1, 11].Value = "Application Status (Last Action by RERA)";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.Diary_Number;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Application_Date.HasValue ? (XlscodeItem.Application_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.Project_Name;

                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.ApplicationApproved_Date.HasValue ? (XlscodeItem.ApplicationApproved_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.ApplicationApproved_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.RegistrationApproved_Days;
                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.LastActionbyRERA_Days;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.ApplicationReceived_Days;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.NoReplyByPromoter_Days;

                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.LastActivity_Date.HasValue ? (XlscodeItem.LastActivity_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.LastActivity_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.LastActivity_Name;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();

            workSheet.Cells["A1:K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:K1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 11])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectActivitiesDetailedRecords_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion
        
        #region Project Average Recrods FileTime (MIS Reports)
        [HttpGet]
        public ActionResult Display_ProjectFileTimeAverageRecordsDetailsForMIS()
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails getObj = new Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails();
            Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel aaXls = new Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel();

            var now = DateTime.Now;
            string UserID_Role = string.Empty;
            Int32 varApplicationTypeFlag = 51;
            string varForEventAction = "Project";

            getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAverageRecordsFileTimeDetails_ForProjects(UserID_Role).ToList();
            getObj.FileIndexEventMaster = sdb.Display_Master_MIS_ProjectExtensionCompletionDetailsByID_ForProjects(UserID_Role, varApplicationTypeFlag, varForEventAction).ToList();

            foreach (var item in getObj.prpongoing) 
            {
                Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel aaXlsInner = new Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel();

                aaXlsInner.DaysRangeLevel_Title = item.Project_DiaryNumber;
                aaXlsInner.DaysInNumber = Convert.ToInt32(item.DaysInNumber);
                aaXlsInner.PercentagePerDays = 0;
                
                aaXls.prpongoing.Add(aaXlsInner);
            }
            Session["modelXlsProjectAverageIndexMIS"] = aaXls.prpongoing;

            return View("Display_ProjectFileTimeAverageRecordsDetailsForMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectFileTimeAverageRecordsDetailsForMIS(Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails smodel)
        {
            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails getObj = new Clsprp_MIS_ProjectAverageFileTimeRangeRecordDetails();
            List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage> putObj = new List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage>();
            Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel aaXls = new Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel();

            if (ModelState.IsValid)
            {
                string UserID_Role = string.Empty;
                Int32 flagApplicationMode = 0;
                Int64 flagApplicationEventCode = 0;
                Int32 RangeNumberValue = 0;
                Int32 varprmRange = 0;
                Int32 varprmMonth = 0;
                Int32 varprmYear = 0;
                string varForEventAction = "Project";

                flagApplicationMode = smodel.IsApplicationModeFlag;
                flagApplicationEventCode = smodel.ApplicationEventTypeCode;

                DateTime dtvalue = new DateTime(0001, 1, 1);
                DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                RangeNumberValue = smodel.RangeNumberValue; //drpRangeValue
                varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                varprmMonth = smodel.EventMonth;
                varprmYear = smodel.EventYear;

                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectAverageRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationMode, flagApplicationEventCode, RangeNumberValue, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList();
                getObj.FileIndexEventMaster = sdb.Display_Master_MIS_ProjectExtensionCompletionDetailsByID_ForProjects(UserID_Role, flagApplicationMode, varForEventAction).ToList();

                ViewBag.data = "true";                

                
                Int32 varRangeLimit = 0;
                Int32 varTotalValueSets = 0;
                varRangeLimit = RangeNumberValue;
                varTotalValueSets = getObj.prpongoing.Count;

                for (int i = 1; i <= 10; i++)
                {
                    Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage putInner = new Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage();

                    putInner.IndexCode = RangeNumberValue * i;
                    if (i == 1 || i == 10)
                    {
                        if (i == 1)
                        {
                            putInner.DaysRangeLevel_Title = "1 to " + Convert.ToString(varRangeLimit);
                        }
                        else
                        {
                            putInner.DaysRangeLevel_Title = Convert.ToString((varRangeLimit * i) + 1) + " and Above";
                        }
                    }
                    else
                    {
                        putInner.DaysRangeLevel_Title = Convert.ToString((varRangeLimit * (i - 1)) + 1) + " to " + Convert.ToString((varRangeLimit * (i - 1)) + varRangeLimit);
                    }
                    putInner.DaysInNumber = 0;
                    putInner.PercentagePerDays = 0;
                    putInner.A_column = string.Empty;
                    putInner.B_column = 0;
                    putInner.C_column = DateTime.Now;

                    putObj.Add(putInner);
                }

                if (varTotalValueSets > 0)
                {
                    // Set Value
                    foreach (var item in getObj.prpongoing)
                    {
                        foreach (var itemInner in putObj)
                        {
                            if (itemInner.DaysRangeLevel_Title == item.DaysRangeLevel_Title)
                            {
                                itemInner.DaysInNumber = itemInner.DaysInNumber + 1;
                            }
                        }
                    }

                    // Set Percentage
                    foreach (var itemPercentage in putObj)
                    {
                        if (itemPercentage.DaysInNumber > 0)
                        {
                            itemPercentage.PercentagePerDays = ((Convert.ToDecimal(itemPercentage.DaysInNumber) / Convert.ToDecimal(varTotalValueSets)) * 100);
                        }
                    }
                }
                Session["modelProjectAverageActivityIndexMIS"] = putObj;
                
                getObj.FileTime_RangeValue = putObj;

                foreach (var item in putObj)
                {
                    Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel aaXlsInner = new Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel();

                    aaXlsInner.DaysRangeLevel_Title = item.DaysRangeLevel_Title;
                    aaXlsInner.DaysInNumber = item.DaysInNumber;
                    aaXlsInner.PercentagePerDays = item.PercentagePerDays;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectAverageIndexMIS"] = aaXls.prpongoing;

                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectFileTimeAverageRecordsDetailsForMIS", getObj); 
        }

        public JsonResult GetPieChartProjectActivityIndexLiveReportsData(string IndexId)
        {
            var objXlslist = Session["modelProjectAverageActivityIndexMIS"] as List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentage>;
                        

            var pieChartValue = new ClsPrp_ProjectAverageActivity_LiveReportProjectAverageRecordsPieChartsSeries<int>();
            var pieChartModel = new ClsPrp_ProjectAverageActivity_PieChartsLiveReportProjectAverageRecords<int>
            {
                LiveReportProjectAverageRecordsPieChartsData = new List<ClsPrp_ProjectAverageActivity_LiveReportProjectAverageRecordsPieChartsSeries<int>>()
            };

            if (objXlslist != null)
            {
                foreach (var item in objXlslist)
                {
                    pieChartValue = new ClsPrp_ProjectAverageActivity_LiveReportProjectAverageRecordsPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + item.DaysRangeLevel_Title.ToString() + "</span>", y = item.PercentagePerDays, projectaverageactivitynumber = item.DaysInNumber };
                    pieChartModel.LiveReportProjectAverageRecordsPieChartsData.Add(pieChartValue);
                }
            }

            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjectExtnCompletionEventByID(string projectmodeId)
        {
            string UserID_Role = string.Empty;
            string EventAction_Type = "Project";
            int Id = 0;
            if (projectmodeId != "")
                Id = Convert.ToInt32(projectmodeId);


            ClsMethodMIS_ProjectAverageFileTimeDetails sdb = new ClsMethodMIS_ProjectAverageFileTimeDetails();
            var subeventtype = sdb.Display_Master_MIS_ProjectExtensionCompletionDetailsByID_ForProjects(UserID_Role, Id, EventAction_Type);

            return Json(subeventtype);
        }       
        
        public void ExportwithAverageRecordsFileTimeToExcel()
        {
            var objXlslist = Session["modelXlsProjectAverageIndexMIS"] as List<Clsprp_MIS_ProjectAverageFileTimeRangeNumberPercentageExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;

            //Header of table 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Range (in days)";
            workSheet.Cells[1, 3].Value = "Number of Applications";
            workSheet.Cells[1, 4].Value = "Percentage (%)";

            //Body of table   
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.DaysRangeLevel_Title;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.DaysInNumber;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.PercentagePerDays;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();

            workSheet.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 4])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectAverageActivity_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion
        #endregion

        #region Project CheckList InComplete Statistics Reports
        #region Project Statistics Index
        [HttpGet]
        public ActionResult Display_ProjectCheckListFileTimeRecordsDetailsForMIS()
        {
            ClsMethodMIS_ProjectCheckListRecordDetails sdb = new ClsMethodMIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordDetails getObj = new Clsprp_MIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXls = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

            try
            {
                var now = DateTime.Now;
                string UserID_Role = string.Empty;
                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectChecklistRecordsFileTimeDetails_ForProjects(UserID_Role).ToList();

                string flagApplicationCategoryName = string.Empty;
                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXlsInner = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

                    aaXlsInner.PromoterRegDiaryNumber_Name = item.PromoterRegDiaryNumber_Name;
                    aaXlsInner.SearchFor_Name = flagApplicationCategoryName;
                    aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                    aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                    aaXlsInner.EventAction_NoReplybyPromoter_Days = item.EventAction_NoReplybyPromoter_Days;
                    aaXlsInner.Application_Date = item.Application_Date;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Project_Status = item.Project_Status;
                    aaXlsInner.ProjectStart_Date = item.ProjectStart_Date;
                    aaXlsInner.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                    aaXlsInner.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                    aaXlsInner.VariableValue = fnGetStatisticsRemarksTitle(item.VariableValue);

                    aaXlsInner.RERAregistrationnumber = item.RERAregistrationnumber;
                    aaXlsInner.Registration_IssueDate = item.Registration_IssueDate;
                    aaXlsInner.Registration_UptoDate = item.Registration_UptoDate;

                    aaXlsInner.A_column = item.A_column;
                    aaXlsInner.B_column = item.B_column;
                    aaXlsInner.C_column = item.C_column;
                    aaXlsInner.D_column = item.D_column;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectCheckListFileActivityIndexRecordsMIS"] = aaXls.prpongoing;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectCheckListFileTimeRecordsDetailsForMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_ProjectCheckListFileTimeRecordsDetailsForMIS(Clsprp_MIS_ProjectCheckListRecordDetails smodel)
        {
            ClsMethodMIS_ProjectCheckListRecordDetails sdb = new ClsMethodMIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordDetails getObj = new Clsprp_MIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXls = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

            try
            {
                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationMode = 0;
                    Int32 flagApplicationCategory = 0;
                    Int32 varprmRange = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;
                    string flagApplicationCategoryName = string.Empty;

                    flagApplicationMode = smodel.IsApplicationTypeFlag; //radioSearchFor
                    flagApplicationCategory = smodel.IsApplicationStatisticsCategory; //radioStatisticsCategory
                    flagApplicationCategoryName = fnGetStatisticsCategoryOptionTitle(flagApplicationCategory);                    

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectChecklistRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationCategory, flagApplicationMode, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                            //Task has been started
                            Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectChecklistRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationCategory, flagApplicationMode, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);
                        });
                    }
                    await Task.WhenAll(taskA);

                    ViewBag.data = "true";
                    Session["modelProjectCheckListFileActivityIndexGraph"] = getObj.prpongoing;

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXlsInner = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

                        aaXlsInner.PromoterRegDiaryNumber_Name = item.PromoterRegDiaryNumber_Name;
                        aaXlsInner.SearchFor_Name = flagApplicationCategoryName;
                        aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                        aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                        aaXlsInner.EventAction_NoReplybyPromoter_Days = item.EventAction_NoReplybyPromoter_Days;
                        aaXlsInner.Application_Date = item.Application_Date;
                        aaXlsInner.Promoter_Name = item.Promoter_Name;
                        aaXlsInner.Project_Name = item.Project_Name;
                        aaXlsInner.Project_Status = item.Project_Status;
                        aaXlsInner.ProjectStart_Date = item.ProjectStart_Date;
                        aaXlsInner.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                        aaXlsInner.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                        aaXlsInner.VariableValue = fnGetStatisticsRemarksTitle(item.VariableValue);

                        aaXlsInner.RERAregistrationnumber = item.RERAregistrationnumber;
                        aaXlsInner.Registration_IssueDate = item.Registration_IssueDate;
                        aaXlsInner.Registration_UptoDate = item.Registration_UptoDate;

                        aaXlsInner.A_column = item.A_column;
                        aaXlsInner.B_column = item.B_column;
                        aaXlsInner.C_column = item.C_column;
                        aaXlsInner.D_column = item.D_column;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelXlsProjectCheckListFileActivityIndexRecordsMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectCheckListFileTimeRecordsDetailsForMIS", getObj);
        }

        public JsonResult GetPieChartProjectActivityIndexLiveReportsActionTypeData(string IndexId)
        {
            var objXlslist = Session["modelProjectCheckListFileActivityIndexGraph"] as List<Clsprp_MIS_ProjectCheckListRecordDetails>;


            var pieChartValue = new ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<int>();
            var pieChartModel = new ClsPrp_ProjectActivityIndex_PieChartsLiveReportProjectInCompleteActionRecords<int>
            {
                LiveReportProjectRecordsPieChartsData = new List<ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<int>>()
            };

            if (objXlslist != null)
            {
                string vlabelGraph = string.Empty;
                decimal vPercentageGraph = 0;
                Int64 vApplicationsGraph = 0;
                Int64 vTotalApplicationsGraph = Convert.ToInt64(objXlslist.Count);

                foreach (var line in objXlslist.GroupBy(info => info.VariableValue)
                        .Select(group => new
                        {
                            VariableValue = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.VariableValue))
                {                    
                    vApplicationsGraph = line.Count;
                    vPercentageGraph = (Convert.ToDecimal(vApplicationsGraph) / Convert.ToDecimal(vTotalApplicationsGraph)) * 100.00m;
                    vlabelGraph = fnGetStatisticsRemarksTitle(line.VariableValue);
                                        
                    pieChartValue = new ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + vlabelGraph.ToString() + "</span>", y = vPercentageGraph, projectaverageactivitynumber = vApplicationsGraph };
                    pieChartModel.LiveReportProjectRecordsPieChartsData.Add(pieChartValue);

                }
            }
            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
        }

        public void ExportProjectCheckListRecordsFileTimeToExcel()
        {
            var objXlslist = Session["modelXlsProjectCheckListFileActivityIndexRecordsMIS"] as List<Clsprp_MIS_ProjectCheckListRecordsExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Project Name";
            workSheet.Cells[1, 5].Value = "Promoter's Name";
            workSheet.Cells[1, 6].Value = "Project Status";

            workSheet.Cells[1, 7].Value = "Project Start Date";
            workSheet.Cells[1, 8].Value = "Proposed/ Expected Date of Project Completion as specified in Form B";
            workSheet.Cells[1, 9].Value = "Date of Last Action by RERA";
            workSheet.Cells[1, 10].Value = "Application Status (Last Action by RERA)";
            workSheet.Cells[1, 11].Value = "No Reply by Promoter (in Days)";
            workSheet.Cells[1, 12].Value = "Search For";
            workSheet.Cells[1, 13].Value = "Remarks, If Any";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.PromoterRegDiaryNumber_Name;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Application_Date.HasValue ? (XlscodeItem.Application_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.Project_Name;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.Promoter_Name;
                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.Project_Status;

                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.ProjectStart_Date.HasValue ? (XlscodeItem.ProjectStart_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.ProjectStart_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.ProjectCompletion_ProposedDate.HasValue ? (XlscodeItem.ProjectCompletion_ProposedDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.ProjectCompletion_ProposedDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.EventAction_IdentifiedOn.HasValue ? (XlscodeItem.EventAction_IdentifiedOn != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.EventAction_IdentifiedOn.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.EventAction_Aggregate;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.EventAction_NoReplybyPromoter_Days;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.SearchFor_Name;
                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.VariableValue;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 13])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectActionActivitiesDetailedRecords_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        private string fnGetStatisticsRemarksTitle(string varInput)
        {
            string retStr = string.Empty;
            switch (varInput)
            {
                case "Y":
                    retStr = "Provided";
                    break;
                case "N":
                    retStr = "Not provided";
                    break;
                case "X":
                    retStr = "Not applicable";
                    break;
                case "O":
                    retStr = "Exempted Case";
                    break;
                case "Unknown Value":
                    retStr = "Checklist Not Prepared";
                    break;
                default:
                    retStr = "Others";
                    break;
            }
            return retStr;
        }

        private string fnGetStatisticsCategoryOptionTitle(Int32 varInput)
        {
            string retStr = string.Empty;
            switch (varInput)
            {
                case 21:
                    retStr = "Land Title Search Report";
                    break;
                case 22:
                    retStr = "Latest Copy of Jamabandi Certificate";
                    break;
                case 23:
                    retStr = "Details of Land Encumbrances OR NE Certificate";
                    break;
                case 24:
                    retStr = "CLU Certificate";
                    break;
                case 25:
                    retStr = "License to develop society/colony from competent authority";
                    break;
                case 26:
                    retStr = "Copy of Registration as Promoter";
                    break;
                case 27:
                    retStr = "Demand Draft OR Finance Checklist";
                    break;
                default:
                    retStr = "Others";
                    break;
            }
            return retStr;
        }
        #endregion

        #region Project Extension Statistics Index
        [HttpGet]
        public ActionResult Display_ProjectCheckListExtnFileTimeRecordsDetailsForMIS()
        {
            ClsMethodMIS_ProjectCheckListRecordDetails sdb = new ClsMethodMIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordDetails getObj = new Clsprp_MIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXls = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

            try
            {
                var now = DateTime.Now;
                string UserID_Role = string.Empty;
                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectExtensionChecklistRecordsFileTimeDetails_ForProjects(UserID_Role).ToList();

                string flagApplicationCategoryName = string.Empty;
                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXlsInner = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

                    aaXlsInner.PromoterRegDiaryNumber_Name = item.PromoterRegDiaryNumber_Name;
                    aaXlsInner.SearchFor_Name = flagApplicationCategoryName;
                    aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                    aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                    aaXlsInner.EventAction_NoReplybyPromoter_Days = item.EventAction_NoReplybyPromoter_Days;
                    aaXlsInner.Application_Date = item.Application_Date;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Project_Status = item.Project_Status;
                    aaXlsInner.ProjectStart_Date = item.ProjectStart_Date;
                    aaXlsInner.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                    aaXlsInner.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                    aaXlsInner.VariableValue = fnGetStatisticsRemarksTitle(item.VariableValue);

                    aaXlsInner.RERAregistrationnumber = item.RERAregistrationnumber;
                    aaXlsInner.Registration_IssueDate = item.Registration_IssueDate;
                    aaXlsInner.Registration_UptoDate = item.Registration_UptoDate;

                    aaXlsInner.A_column = item.A_column;
                    aaXlsInner.B_column = item.B_column;
                    aaXlsInner.C_column = item.C_column;
                    aaXlsInner.D_column = item.D_column;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectCheckListExtnFileRecordsMIS"] = aaXls.prpongoing;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectCheckListExtnFileTimeRecordsDetailsForMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_ProjectCheckListExtnFileTimeRecordsDetailsForMIS(Clsprp_MIS_ProjectCheckListRecordDetails smodel)
        {
            ClsMethodMIS_ProjectCheckListRecordDetails sdb = new ClsMethodMIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordDetails getObj = new Clsprp_MIS_ProjectCheckListRecordDetails();
            Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXls = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

            try
            {
                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationMode = 0;
                    Int32 flagApplicationCategory = 0;
                    Int32 varprmRange = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;
                    string flagApplicationCategoryName = string.Empty;

                    flagApplicationMode = smodel.IsApplicationTypeFlag; //radioSearchFor
                    flagApplicationCategory = smodel.IsApplicationStatisticsCategory; //radioStatisticsCategory
                    flagApplicationCategoryName = fnGetExtnStatisticsCategoryOptionTitle(flagApplicationCategory);

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectExtensionChecklistRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationCategory, flagApplicationMode, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                            //Task has been started
                            Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectExtensionChecklistRecordsFileTimeDetailsByID_ForProjects(UserID_Role, flagApplicationCategory, flagApplicationMode, FromDateM, ToDateM, varprmRange, varprmMonth, varprmYear).ToList(), token);
                        });
                    }
                    await Task.WhenAll(taskA);

                    ViewBag.data = "true";
                    Session["modelProjectExtnCheckListFileActivityIndexGraph"] = getObj.prpongoing;

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_ProjectCheckListRecordsExportExcel aaXlsInner = new Clsprp_MIS_ProjectCheckListRecordsExportExcel();

                        aaXlsInner.PromoterRegDiaryNumber_Name = item.PromoterRegDiaryNumber_Name;
                        aaXlsInner.SearchFor_Name = flagApplicationCategoryName;
                        aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                        aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                        aaXlsInner.EventAction_NoReplybyPromoter_Days = item.EventAction_NoReplybyPromoter_Days;
                        aaXlsInner.Application_Date = item.Application_Date;
                        aaXlsInner.Promoter_Name = item.Promoter_Name;
                        aaXlsInner.Project_Name = item.Project_Name;
                        aaXlsInner.Project_Status = item.Project_Status;
                        aaXlsInner.ProjectStart_Date = item.ProjectStart_Date;
                        aaXlsInner.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                        aaXlsInner.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                        aaXlsInner.VariableValue = fnGetStatisticsRemarksTitle(item.VariableValue);

                        aaXlsInner.RERAregistrationnumber = item.RERAregistrationnumber;
                        aaXlsInner.Registration_IssueDate = item.Registration_IssueDate;
                        aaXlsInner.Registration_UptoDate = item.Registration_UptoDate;

                        aaXlsInner.A_column = item.A_column;
                        aaXlsInner.B_column = item.B_column;
                        aaXlsInner.C_column = item.C_column;
                        aaXlsInner.D_column = item.D_column;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelXlsProjectCheckListExtnFileRecordsMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectCheckListExtnFileTimeRecordsDetailsForMIS", getObj);
        }

        public JsonResult GetPieChartProjectExtnActivityIndexLiveReportsActionTypeData(string IndexId)
        {
            var objXlslist = Session["modelProjectExtnCheckListFileActivityIndexGraph"] as List<Clsprp_MIS_ProjectCheckListRecordDetails>;

            var pieChartValue = new ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<int>();
            var pieChartModel = new ClsPrp_ProjectActivityIndex_PieChartsLiveReportProjectInCompleteActionRecords<int>
            {
                LiveReportProjectRecordsPieChartsData = new List<ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<int>>()
            };

            if (objXlslist != null)
            {
                string vlabelGraph = string.Empty;
                decimal vPercentageGraph = 0;
                Int64 vApplicationsGraph = 0;
                Int64 vTotalApplicationsGraph = Convert.ToInt64(objXlslist.Count);

                foreach (var line in objXlslist.GroupBy(info => info.VariableValue)
                        .Select(group => new
                        {
                            VariableValue = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.VariableValue))
                {
                    vApplicationsGraph = line.Count;
                    vPercentageGraph = (Convert.ToDecimal(vApplicationsGraph) / Convert.ToDecimal(vTotalApplicationsGraph)) * 100.00m;
                    vlabelGraph = fnGetStatisticsRemarksTitle(line.VariableValue);

                    pieChartValue = new ClsPrp_ProjectActivityIndex_LiveReportProjectInCompleteActionRecordsPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + vlabelGraph.ToString() + "</span>", y = vPercentageGraph, projectaverageactivitynumber = vApplicationsGraph };
                    pieChartModel.LiveReportProjectRecordsPieChartsData.Add(pieChartValue);

                }
            }
            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
        }

        public void ExportProjectCheckListExtnRecordsFileTimeToExcel()
        {
            var objXlslist = Session["modelXlsProjectCheckListExtnFileRecordsMIS"] as List<Clsprp_MIS_ProjectCheckListRecordsExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "RERA Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Upto Date";

            workSheet.Cells[1, 5].Value = "Diary Number";
            workSheet.Cells[1, 6].Value = "Application Date";
            workSheet.Cells[1, 7].Value = "Project Name";
            workSheet.Cells[1, 8].Value = "Promoter's Name";
            workSheet.Cells[1, 9].Value = "Project Status";
            workSheet.Cells[1, 10].Value = "Project Start Date";
            workSheet.Cells[1, 11].Value = "Proposed/ Expected Date of Project Completion as specified in Form B";

            workSheet.Cells[1, 12].Value = "Date of Last Action by RERA";
            workSheet.Cells[1, 13].Value = "Application Status (Last Action by RERA)";
            workSheet.Cells[1, 14].Value = "No Reply by Promoter (in Days)";
            workSheet.Cells[1, 15].Value = "Search For";
            workSheet.Cells[1, 16].Value = "Remarks, If Any";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.RERAregistrationnumber;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Registration_IssueDate.HasValue ? (XlscodeItem.Registration_IssueDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Registration_IssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.Registration_UptoDate.HasValue ? (XlscodeItem.Registration_UptoDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Registration_UptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.PromoterRegDiaryNumber_Name;
                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.Application_Date.HasValue ? (XlscodeItem.Application_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.Project_Name;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.Promoter_Name;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.Project_Status;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.ProjectCompletion_ProposedDate.HasValue ? (XlscodeItem.ProjectCompletion_ProposedDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.ProjectCompletion_ProposedDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.ProjectCompletion_OriginalDate.HasValue ? (XlscodeItem.ProjectCompletion_OriginalDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.ProjectCompletion_OriginalDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.EventAction_IdentifiedOn.HasValue ? (XlscodeItem.EventAction_IdentifiedOn != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.EventAction_IdentifiedOn.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.EventAction_Aggregate;
                workSheet.Cells[recordIndex, 14].Value = XlscodeItem.EventAction_NoReplybyPromoter_Days;
                workSheet.Cells[recordIndex, 15].Value = XlscodeItem.SearchFor_Name;
                workSheet.Cells[recordIndex, 16].Value = XlscodeItem.VariableValue;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();
            workSheet.Column(16).AutoFit();

            workSheet.Cells["A1:P1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:P1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 16])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectActionActivitiesExtensionDetailedRecords_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        private string fnGetExtnStatisticsCategoryOptionTitle(Int32 varInput)
        {
            string retStr = string.Empty;
            switch (varInput)
            {
                case 21:
                    retStr = "Copy of Approved Layout Plan";
                    break;
                case 22:
                    retStr = "Architect Certificate (Table A and Table B)";
                    break;
                case 23:
                    retStr = "Explanatory Note/Details";
                    break;
                case 24:
                    retStr = "License to develop society/colony from competent authority";
                    break;
                case 25:
                    retStr = "Demand Draft OR Finance Checklist";
                    break;                
                default:
                    retStr = "Others";
                    break;
            }
            return retStr;
        }
        #endregion
        #endregion
        
        #region Quarterly Updates of Registered Project Reports
        [HttpGet]
        public ActionResult Display_ProjectQuarterlyUpdateRecordsDetailsForMIS()
        {
            ClsMethodMIS_ProjectQuarterlyUpdatesRecordDetails sdb = new ClsMethodMIS_ProjectQuarterlyUpdatesRecordDetails();
            Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails getObj = new Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails();
            Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel aaXls = new Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            try
            {
                var now = DateTime.Now;
                string UserID_Role = string.Empty;
                int statecode = 28;
                getObj.districtMaster = objdis.dropdownlist_display1(statecode);
                
                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQuarterlyUpdateRecordsDetails_ForProjects(UserID_Role).ToList();

                string flagApplicationCategoryName = string.Empty;
                foreach (var item in getObj.prpongoing)
                {
                    Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel aaXlsInner = new Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel();

                    aaXlsInner.QUpdateProject_RegDiaryNumber_Name = item.QUpdateProject_RegDiaryNumber_Name;
                    aaXlsInner.Application_Date = item.Application_Date;
                    aaXlsInner.QUpdateProject_Year = item.QUpdateProject_Year;
                    aaXlsInner.QUpdateProject_QuarterName = item.QUpdateProject_QuarterName;
                    aaXlsInner.RERAregistrationnumber = item.RERAregistrationnumber;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberValidUptoDate = item.RERAnumberValidUptoDate;

                    aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                    aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                    aaXlsInner.QUP_SubmittedOnTimebyPromoter_Name = item.QUP_SubmittedOnTimebyPromoter_Name;
                    aaXlsInner.QUP_SubmittedOnTimebyPromoter_Days = item.QUP_SubmittedOnTimebyPromoter_Days;

                    aaXlsInner.Project_AddressStateCode = item.Project_AddressStateCode;
                    aaXlsInner.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                    aaXlsInner.Project_AddressSubDivisionCode = item.Project_AddressSubDivisionCode;

                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.QuarterValue_Year = item.QuarterValue_Year;
                    aaXlsInner.QuarterValue_Name = item.QuarterValue_Name;

                    aaXlsInner.VariableValue = item.VariableValue;
                    aaXlsInner.PercentageValue = item.PercentageValue;

                    aaXlsInner.A_column = item.A_column;
                    aaXlsInner.B_column = item.B_column;
                    aaXlsInner.C_column = item.C_column;
                    aaXlsInner.D_column = item.D_column;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectQuarterlyUpdateRecordsMIS"] = aaXls.prpongoing;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectQuarterlyUpdateRecordsDetailsForMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_ProjectQuarterlyUpdateRecordsDetailsForMIS(Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails smodel)
        {
            ClsMethodMIS_ProjectQuarterlyUpdatesRecordDetails sdb = new ClsMethodMIS_ProjectQuarterlyUpdatesRecordDetails();
            Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails getObj = new Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails();
            Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel aaXls = new Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            try
            {
                ModelState.Remove("IsApplicationStatisticsCategory");
                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    Int32 flagApplicationDistrict = 0;
                    Int32 flagDistrictCode = 0;
                    Int32 varprmRange = 0;
                    String varprmMonth = string.Empty;
                    Int32 varprmYear = 0;
                    string flagApplicationCategoryName = string.Empty;

                    flagApplicationDistrict = smodel.IsApplicationTypeFlag; //radioSearchFor
                    flagDistrictCode = smodel.IsApplicationStatisticsCategory; //radioStatisticsCategory
                    //flagApplicationCategoryName = fnGetStatisticsCategoryOptionTitle(flagApplicationCategory);

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmRange = smodel.IsRangeValueDateInputFlag; //radioRangeFlag
                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;                    

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                    
                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQuarterlyUpdateRecordsDetailsByID_ForProjects(UserID_Role, flagApplicationDistrict, flagDistrictCode, varprmRange, FromDateM, ToDateM, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                            //Task has been started
                            Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectQuarterlyUpdateRecordsDetailsByID_ForProjects(UserID_Role, flagApplicationDistrict, flagDistrictCode, varprmRange, FromDateM, ToDateM, varprmMonth, varprmYear).ToList(), token);
                        });
                    }
                    await Task.WhenAll(taskA);

                    ViewBag.data = "true";
                    Session["modelProjectQuarterlyUpdateRecordsGraph"] = getObj.prpongoing;

                    foreach (var item in getObj.prpongoing)
                    {
                        Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel aaXlsInner = new Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel();

                        aaXlsInner.QUpdateProject_RegDiaryNumber_Name = item.QUpdateProject_RegDiaryNumber_Name;
                        aaXlsInner.Application_Date = item.Application_Date;
                        aaXlsInner.QUpdateProject_Year = item.QUpdateProject_Year;
                        aaXlsInner.QUpdateProject_QuarterName = item.QUpdateProject_QuarterName;
                        aaXlsInner.RERAregistrationnumber = item.RERAregistrationnumber;
                        aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                        aaXlsInner.RERAnumberValidUptoDate = item.RERAnumberValidUptoDate;

                        aaXlsInner.EventAction_IdentifiedOn = item.EventAction_IdentifiedOn;
                        aaXlsInner.EventAction_Aggregate = item.EventAction_Aggregate;
                        aaXlsInner.QUP_SubmittedOnTimebyPromoter_Name = item.QUP_SubmittedOnTimebyPromoter_Name;
                        aaXlsInner.QUP_SubmittedOnTimebyPromoter_Days = item.QUP_SubmittedOnTimebyPromoter_Days;                        

                        aaXlsInner.Project_AddressStateCode = item.Project_AddressStateCode;
                        aaXlsInner.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                        aaXlsInner.Project_AddressSubDivisionCode = item.Project_AddressSubDivisionCode;

                        aaXlsInner.Project_Name = item.Project_Name;
                        aaXlsInner.Promoter_Name = item.Promoter_Name;
                        aaXlsInner.QuarterValue_Year = item.QuarterValue_Year;
                        aaXlsInner.QuarterValue_Name = item.QuarterValue_Name;

                        aaXlsInner.VariableValue = item.VariableValue;
                        aaXlsInner.PercentageValue = item.PercentageValue;

                        aaXlsInner.A_column = item.A_column;
                        aaXlsInner.B_column = item.B_column;
                        aaXlsInner.C_column = item.C_column;
                        aaXlsInner.D_column = item.D_column;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelXlsProjectQuarterlyUpdateRecordsMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }

                int statecode = 28;
                getObj.districtMaster = objdis.dropdownlist_display1(statecode);
                getObj.IsApplicationStatisticsCategory = smodel.IsApplicationStatisticsCategory;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectQuarterlyUpdateRecordsDetailsForMIS", getObj);
        }

        public JsonResult GetPieChartProjectQuarterlyUpdatesLiveReportsData(string IndexId)
        {
            var objXlslist = Session["modelProjectQuarterlyUpdateRecordsGraph"] as List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordDetails>;


            var pieChartValue = new ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecordsPieChartsSeries<int>();
            var pieChartModel = new ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecords<int>
            {
                LiveReportQUpdateProjectRecordsPieChartsData = new List<ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecordsPieChartsSeries<int>>()
            };

            if (objXlslist != null)
            {
                string vlabelGraph = string.Empty;
                decimal vPercentageGraph = 0;
                Int64 vApplicationsGraph = 0;
                Int64 vTotalApplicationsGraph = Convert.ToInt64(objXlslist.Count);

                foreach (var line in objXlslist.GroupBy(info => info.QUP_SubmittedOnTimebyPromoter_Name)
                        .Select(group => new
                        {
                            QUP_SubmittedOnTimebyPromoter_Name = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.QUP_SubmittedOnTimebyPromoter_Name))
                {
                    vApplicationsGraph = line.Count;
                    vPercentageGraph = (Convert.ToDecimal(vApplicationsGraph) / Convert.ToDecimal(vTotalApplicationsGraph)) * 100.00m;
                    vlabelGraph = fnGetQUpdatesStatisticsRemarksTitle(line.QUP_SubmittedOnTimebyPromoter_Name);

                    pieChartValue = new ClsPrp_QuarterlyUpdatesActivityIndex_LiveReportProjectRecordsPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + vlabelGraph.ToString() + "</span>", y = vPercentageGraph, projectaverageactivitynumber = vApplicationsGraph };
                    pieChartModel.LiveReportQUpdateProjectRecordsPieChartsData.Add(pieChartValue);

                }
            }
            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
        }

        public void ExportProjectQuarterlyUpdateRecordsToExcel()
        {
            var objXlslist = Session["modelXlsProjectQuarterlyUpdateRecordsMIS"] as List<Clsprp_MIS_ProjectQuarterlyUpdatesRecordExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Diary Number";
            workSheet.Cells[1, 3].Value = "Application Date";
            workSheet.Cells[1, 4].Value = "Quarter Name";
            workSheet.Cells[1, 5].Value = "Quarter Year";

            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Promoter's Name";

            workSheet.Cells[1, 8].Value = "RERA Registration Number";
            workSheet.Cells[1, 9].Value = "Issue Date";
            workSheet.Cells[1, 10].Value = "Valid Upto Date";
            workSheet.Cells[1, 11].Value = "Quarterly Update Status";
            workSheet.Cells[1, 12].Value = "Date of Last Action";
            workSheet.Cells[1, 13].Value = "Remarks, If Any";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.QUpdateProject_RegDiaryNumber_Name;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Application_Date.HasValue ? (XlscodeItem.Application_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Application_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.QuarterValue_Name;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.QuarterValue_Year;

                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.Project_Name;
                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.Promoter_Name;

                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.RERAregistrationnumber;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.RERAnumberIssueDate.HasValue ? (XlscodeItem.RERAnumberIssueDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.RERAnumberIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.RERAnumberValidUptoDate.HasValue ? (XlscodeItem.RERAnumberValidUptoDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.RERAnumberValidUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.EventAction_Aggregate;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.EventAction_IdentifiedOn.HasValue ? (XlscodeItem.EventAction_IdentifiedOn != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.EventAction_IdentifiedOn.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.QUP_SubmittedOnTimebyPromoter_Name;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 13])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofProjectQuarterlyUpdateRecords_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        private string fnGetQUpdatesStatisticsRemarksTitle(string varInput)
        {
            string retStr = string.Empty;
            switch (varInput)
            {
                case "Provided On-Time":
                    retStr = "Provided On-Time Case(s)";
                    break;
                case "NA":
                    retStr = "Not provided On-Time Case(s)";
                    break;
                default:
                    retStr = "Others Case(s)";
                    break;
            }
            return retStr;
        }
        #endregion

        #region Project Special Bank Account Number (Report MIS)
        [HttpGet]
        public ActionResult Display_ProjectSpecialBankAccountNumberMIS()
        {
            ClsMethodMIS_ProjectSpecialBankAccountNumberDetails sdb = new ClsMethodMIS_ProjectSpecialBankAccountNumberDetails();
            ClsprpMIS_ProjectSpecialBankAccountDetails getObj = new ClsprpMIS_ProjectSpecialBankAccountDetails();
            ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel aaXls = new ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AllMaster objMaster = new ClsMethod_AllMaster();

            try
            {
                string UserID_Role = string.Empty;                
                getObj.BankMaster = objMaster.Display_Master_BankDetails();
                getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectSpecialBankAccountRecords_ForProjects(UserID_Role).ToList();

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel aaXlsInner = new ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel();

                    aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                    aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                    aaXlsInner.Bank_Name = item.Bank_Name;
                    aaXlsInner.Branch_Name = item.Branch_Name;
                    aaXlsInner.Bank_IFSC_Code = item.Bank_IFSC_Code;

                    aaXlsInner.Bank_AccountNumber = item.Bank_AccountNumber;
                    aaXlsInner.AcountHolder_Name = item.A_column;

                    aaXlsInner.Bank_AddressLine1 = item.Bank_AddressLine1;
                    aaXlsInner.Bank_AddressLine2 = item.Bank_AddressLine2;
                    aaXlsInner.Bank_AddressStateCode = Convert.ToString(item.Bank_AddressStateCode);
                    aaXlsInner.Bank_AddressDistrictCode = Convert.ToString(item.Bank_AddressDistrictCode);
                    aaXlsInner.Bank_AddressPIN = item.Bank_AddressPIN;

                    aaXlsInner.ImageCancelledCheque_FileName = item.ImageCancelledCheque_FileName;
                    aaXlsInner.ImageCancelledCheque_FilePath = item.ImageCancelledCheque_FilePath;

                    aaXlsInner.Project_Name = item.Project_Name;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                    aaXlsInner.Account_FormDate = item.Account_FormDate;
                    aaXlsInner.Account_ToDate = item.Account_ToDate;
                    aaXlsInner.IsRegistrationHistory = item.IsRegistrationHistory;

                    aaXls.prpongoing.Add(aaXlsInner);
                }
                Session["modelXlsProjectSBANRecordsMIS"] = aaXls.prpongoing;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectSpecialBankAccountNumberMIS", getObj);
        }

        [HttpPost]
        public async Task<ActionResult> Display_ProjectSpecialBankAccountNumberMIS(ClsprpMIS_ProjectSpecialBankAccountDetails smodel)
        {
            ClsMethodMIS_ProjectSpecialBankAccountNumberDetails sdb = new ClsMethodMIS_ProjectSpecialBankAccountNumberDetails();
            ClsprpMIS_ProjectSpecialBankAccountDetails getObj = new ClsprpMIS_ProjectSpecialBankAccountDetails();
            ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel aaXls = new ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_AllMaster objMaster = new ClsMethod_AllMaster();

            try
            {                
                if (ModelState.IsValid)
                {
                    string UserID_Role = string.Empty;
                    string ApplicationBankflag = "0";
                    Int32 BankCodeflag = 0;
                    Int32 ApplicationOptionDateFlag = 0;                    
                    Int32 ApplicationRangeflag = 0;
                    Int32 varprmMonth = 0;
                    Int32 varprmYear = 0;

                    ApplicationBankflag = smodel.Application_SearchOptionFlag; //radioSearchFor
                    BankCodeflag = Convert.ToInt32(smodel.BankName_Input); //radioBankCode
                    ApplicationOptionDateFlag = Convert.ToInt32(smodel.Application_SearchOptionDateFlag);  //radioSearchDate
                    ApplicationRangeflag = Convert.ToInt32(smodel.Application_SearchRangeFlag);  //radioRangeFlag

                    DateTime dtvalue = new DateTime(0001, 1, 1);
                    DateTime FromDateM = smodel.InputEntry_FromDate.HasValue ? smodel.InputEntry_FromDate.Value : dtvalue;
                    DateTime ToDateM = smodel.InputEntry_ToDate.HasValue ? smodel.InputEntry_ToDate.Value : dtvalue;

                    varprmMonth = smodel.EventMonth;
                    varprmYear = smodel.EventYear;

                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;

                    Task taskA = Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectSpecialBankAccountRecordsByID_ForProjects(UserID_Role, ApplicationBankflag, BankCodeflag, ApplicationOptionDateFlag, ApplicationRangeflag, FromDateM, ToDateM, varprmMonth, varprmYear).ToList(), token);

                    await taskA;
                    if ((taskA != null) && (taskA.IsCompleted == false || taskA.Status == TaskStatus.Running || taskA.Status == TaskStatus.WaitingToRun || taskA.Status == TaskStatus.WaitingForActivation))
                    {
                        //Task is already running
                        source.Cancel();
                    }
                    else
                    {
                        taskA = Task.Factory.StartNew(() =>
                        {
                            //Task has been started
                            Task.Run(() => getObj.prpongoing = sdb.Display_AuthDesk_MIS_ProjectSpecialBankAccountRecordsByID_ForProjects(UserID_Role, ApplicationBankflag, BankCodeflag, ApplicationOptionDateFlag, ApplicationRangeflag, FromDateM, ToDateM, varprmMonth, varprmYear).ToList(), token);
                        });
                    }
                    await Task.WhenAll(taskA);

                    ViewBag.data = "true";
                    Session["modelProjectSBANRecordsGraph"] = getObj.prpongoing;

                    foreach (var item in getObj.prpongoing)
                    {
                        ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel aaXlsInner = new ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel();

                        aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                        aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                        aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                        aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                        aaXlsInner.Bank_Name = item.Bank_Name;
                        aaXlsInner.Branch_Name = item.Branch_Name;
                        aaXlsInner.Bank_IFSC_Code = item.Bank_IFSC_Code;

                        aaXlsInner.Bank_AccountNumber = item.Bank_AccountNumber;
                        aaXlsInner.AcountHolder_Name = item.A_column;

                        aaXlsInner.Bank_AddressLine1 = item.Bank_AddressLine1;
                        aaXlsInner.Bank_AddressLine2 = item.Bank_AddressLine2;
                        aaXlsInner.Bank_AddressStateCode = Convert.ToString(item.Bank_AddressStateCode);
                        aaXlsInner.Bank_AddressDistrictCode = Convert.ToString(item.Bank_AddressDistrictCode);
                        aaXlsInner.Bank_AddressPIN = item.Bank_AddressPIN;

                        aaXlsInner.ImageCancelledCheque_FileName = item.ImageCancelledCheque_FileName;
                        aaXlsInner.ImageCancelledCheque_FilePath = item.ImageCancelledCheque_FilePath;

                        aaXlsInner.Project_Name = item.Project_Name;
                        aaXlsInner.Promoter_Name = item.Promoter_Name;
                        aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                        aaXlsInner.Account_FormDate = item.Account_FormDate;
                        aaXlsInner.Account_ToDate = item.Account_ToDate;
                        aaXlsInner.IsRegistrationHistory = item.IsRegistrationHistory;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }
                    Session["modelXlsProjectSBANRecordsMIS"] = aaXls.prpongoing;

                    if (getObj.prpongoing.Count > 0)
                    {
                        //  ExportToExcel();
                    }
                    else
                    {
                        ViewData["data"] = "No data found";
                    }
                }
                getObj.BankMaster = objMaster.Display_Master_BankDetails();
                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
            }
            catch (Exception ex)
            {
                string exstr = ex.ToString();
            }
            return View("Display_ProjectSpecialBankAccountNumberMIS", getObj);
        }

        public JsonResult GetPieChartProjectSpecialBankAccountLiveReportsData(string IndexId)
        {
            var objXlslist = Session["modelProjectSBANRecordsGraph"] as List<ClsprpMIS_ProjectSpecialBankAccountDetails>;
            
            var pieChartValue = new ClsPrp_SpecialBankAccountActivityIndex_LiveReportProjectRecordsPieChartsSeries<int>();
            var pieChartModel = new ClsPrp_SpecialBankAccountActivityIndex_LiveReportProjectRecords<int>
            {
                LiveReportSpecialBankAccountRecordsPieChartsData = new List<ClsPrp_SpecialBankAccountActivityIndex_LiveReportProjectRecordsPieChartsSeries<int>>()
            };

            if (objXlslist != null)
            {
                string vlabelGraph = string.Empty;
                decimal vPercentageGraph = 0;
                Int64 vApplicationsGraph = 0;
                Int64 vTotalApplicationsGraph = Convert.ToInt64(objXlslist.Count);

                foreach (var line in objXlslist.GroupBy(info => info.Bank_Name)
                        .Select(group => new
                        {
                            Bank_Name = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Bank_Name))
                {
                    vApplicationsGraph = line.Count;
                    vPercentageGraph = (Convert.ToDecimal(vApplicationsGraph) / Convert.ToDecimal(vTotalApplicationsGraph)) * 100.00m;
                    vlabelGraph = line.Bank_Name;

                    pieChartValue = new ClsPrp_SpecialBankAccountActivityIndex_LiveReportProjectRecordsPieChartsSeries<int> { name = "<span style=\"color:#3c763d;\">" + vlabelGraph.ToString() + "</span>", y = vPercentageGraph, projectaverageactivitynumber = vApplicationsGraph };
                    pieChartModel.LiveReportSpecialBankAccountRecordsPieChartsData.Add(pieChartValue);
                }
            }
            return Json(pieChartModel, JsonRequestBehavior.AllowGet);
        }

        public void ExportProjectSBANlistToExcel()
        {
            var objXlslist = Session["modelXlsProjectSBANRecordsMIS"] as List<ClsprpMIS_ProjectSpecialBankAccountDetailsExportExcel>;

            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("RERA Punjab - Sheet1");
            workSheet.TabColor = System.Drawing.Color.Green;
            workSheet.DefaultRowHeight = 12;

            //Header of table
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            workSheet.Cells[1, 1].Value = "S.No";
            workSheet.Cells[1, 2].Value = "Registration Number";
            workSheet.Cells[1, 3].Value = "Registration Issue Date";
            workSheet.Cells[1, 4].Value = "Registration Valid Upto Date";
            workSheet.Cells[1, 5].Value = "Project's Dairy Number";

            workSheet.Cells[1, 6].Value = "Project Name";
            workSheet.Cells[1, 7].Value = "Promoter's Name";

            workSheet.Cells[1, 8].Value = "Bank Name";
            workSheet.Cells[1, 9].Value = "Branch Name";
            workSheet.Cells[1, 10].Value = "Bank IFSC Code";            
            workSheet.Cells[1, 11].Value = "Bank Account Number";
            workSheet.Cells[1, 12].Value = "Account Holder Name";
            workSheet.Cells[1, 13].Value = "Remarks, If Any";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.RERAnumberRegistration;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.RERAnumberIssueDate.HasValue ? (XlscodeItem.RERAnumberIssueDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.RERAnumberIssueDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.RERAnumberRegUptoDate.HasValue ? (XlscodeItem.RERAnumberRegUptoDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.RERAnumberRegUptoDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.ProjectRegDiaryNumber_Name;

                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.Project_Name;
                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.Promoter_Name;

                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.Bank_Name;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.Branch_Name;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.Bank_IFSC_Code;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.Bank_AccountNumber;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.AcountHolder_Name;
                workSheet.Cells[recordIndex, 13].Value = "Registered Project";// XlscodeItem.IsRegistrationHistory;

                workSheet.Row(recordIndex).Height = 15;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();

            workSheet.Cells["A1:M1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:M1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 13])
            {
                RangeXls.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Top.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Left.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Right.Color.SetColor(Color.Black);
                RangeXls.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                RangeXls.Style.Border.Bottom.Color.SetColor(Color.Black);
                RangeXls.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                RangeXls.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                Response.AddHeader("content-disposition", "attachment; filename=ListofSpecialBankAccountRecords_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion




    }
}

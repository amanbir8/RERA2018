using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CRUD.Models.PaymentToExcel_MIS;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style.XmlAccess;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using CRUD.Models.MIS;

namespace CRUD.Controllers.PaymentToExcel_MIS
{
    [Authorize]
    [Authorize(Roles = "Authority, ManagerDesk, HelpDesk, SecretaryRERA, LegalAdvisorDesk")]
    public class ExportToExcelController : Controller
    {
        #region Complaint (Form-M/N) Payments List 
        [HttpGet]
        public ActionResult Display_ComplaintPaymentMIS_FormM()
        {
            ClsMethodMIS_ComplaintFormM RegBussinessLayer = new ClsMethodMIS_ComplaintFormM();
            ClsprpMIS_ComplaintFormM getObj = new ClsprpMIS_ComplaintFormM();

            getObj.prpongoing = RegBussinessLayer.ComplaintMGet().ToList();
            return View("Display_ComplaintPaymentMIS_FormM", getObj);
        }

        [HttpPost]
        public ActionResult Display_ComplaintPaymentMIS_FormM(ClsprpMIS_ComplaintFormM smodel)
        {
            ClsMethodMIS_ComplaintFormM RegBussinessLayer = new ClsMethodMIS_ComplaintFormM();
            ClsprpMIS_ComplaintFormM getObj = new ClsprpMIS_ComplaintFormM();
            ClsprpMIS_ComplaintFormM_ExportToExcel aaXls = new ClsprpMIS_ComplaintFormM_ExportToExcel();

            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registered Complaints Payments (2)Pending Diary Number Complaints Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ComplaintMformPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ComplaintFormM_ExportToExcel aaXlsInner = new ClsprpMIS_ComplaintFormM_ExportToExcel();

                    aaXlsInner.Complaint_Diary_Number = item.Complaint_Diary_Number;
                    aaXlsInner.Complainant_Name = item.Complainant_Name;
                    aaXlsInner.Respondant_Name = item.Respondant_Name;
                    aaXlsInner.PG_Complainant_Email = item.PG_Complainant_Email;
                    aaXlsInner.PG_Complainant_Phone = item.PG_Complainant_Phone;
                    aaXlsInner.Payment_Success_Date = item.Payment_Success_Date;
                    aaXlsInner.Status = item.Status;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    //Fee Table Terms
                    aaXlsInner.PG_Payment_Description = item.PG_Payment_Description;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.Amount = item.Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    //Payment Gateway
                    aaXlsInner.PG_PaymentRef_Number = item.PG_PaymentRef_Number;
                    aaXlsInner.PG_Merchant_Name = item.PG_Merchant_Name;
                    aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                    aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                Session["modelComplaintPaymentMIS_FormM"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ComplaintPaymentMIS_FormM", getObj);
        }


        #region EPAY FORM M
        [HttpGet]
        public ActionResult Display_ComplaintPaymentMIS_EpayFormM()
        {
            ClsMethodMIS_ComplaintFormM RegBussinessLayer = new ClsMethodMIS_ComplaintFormM();
            ClsprpMIS_CourtEpayPayment getObj = new ClsprpMIS_CourtEpayPayment();

            getObj.prpongoing = RegBussinessLayer.ComplaintEpayFormMGet().ToList();
            return View("Display_ComplaintPaymentMIS_EpayFormM", getObj);
        }

        [HttpPost]
        public ActionResult Display_ComplaintPaymentMIS_EpayFormM(ClsprpMIS_ComplaintFormM smodel)
        {
            ClsMethodMIS_ComplaintFormM RegBussinessLayer = new ClsMethodMIS_ComplaintFormM();
            ClsprpMIS_CourtEpayPayment getObj = new ClsprpMIS_CourtEpayPayment();
            ClsprpMIS_EpayComplaintFormM_ExportToExcel aaXls = new ClsprpMIS_EpayComplaintFormM_ExportToExcel();

            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                //String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registered Complaints Payments (2)Pending Diary Number Complaints Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_EpayComplaintMformPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_EpayComplaintFormM_ExportToExcel aaXlsInner = new ClsprpMIS_EpayComplaintFormM_ExportToExcel();

                    aaXlsInner.Complaint_Number = item.Complaint_Number;
                    aaXlsInner.Complainant_Name = item.Complainant_Name;
                    aaXlsInner.ComplaintAgainst_Name = item.ComplaintAgainst_Name;
                    aaXlsInner.Payment_EmailAddress = item.Payment_EmailAddress;
                    aaXlsInner.Payment_MobileNumber = item.Payment_MobileNumber;
                    aaXlsInner.PaymentSuccessDate = item.Payment_Success_Date;
                    aaXlsInner.PG_Status = item.PG_Status;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    //Fee Table Terms
                    aaXlsInner.PG_Payment_Description = item.PG_Product_Info;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.Amount = item.Payment_Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    //Payment Gateway
                    aaXlsInner.PG_PaymentRef_Number = item.PG_PaymentRef_Number;
                    aaXlsInner.PG_Merchant_Name = item.PG_Merchant_Name;
                    aaXlsInner.PG_Bank_Name = item.Bank_Name;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount;
                    aaXlsInner.PaymentReferenceName = item.PaymentReferenceName;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                Session["modelComplaintPaymentMIS_EpayFormM"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ComplaintPaymentMIS_EpayFormM", getObj);
        }

        public void EpayComplaintMformExportToExcel()
        {
            var objXlslist = Session["modelComplaintPaymentMIS_EpayFormM"] as List<ClsprpMIS_EpayComplaintFormM_ExportToExcel>;

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
            workSheet.Cells[1, 3].Value = "Complainant's Name";
            workSheet.Cells[1, 4].Value = "Respondant's Name";
            workSheet.Cells[1, 5].Value = "Email Address";
            workSheet.Cells[1, 6].Value = "Mobile or Phone Number";

            workSheet.Cells[1, 7].Value = "Transaction Date";
            workSheet.Cells[1, 8].Value = "Transaction Status";
            workSheet.Cells[1, 9].Value = "Payment Gateway ID";
            workSheet.Cells[1, 10].Value = "Payment Description";
            workSheet.Cells[1, 11].Value = "Transaction ID";
            workSheet.Cells[1, 12].Value = "Transaction Date";

            workSheet.Cells[1, 13].Value = "Amount (INR)";
            workSheet.Cells[1, 14].Value = "Payment Ref Number (PRN)";
            workSheet.Cells[1, 15].Value = "Merchant Name";
            workSheet.Cells[1, 16].Value = "Bank Name";
            workSheet.Cells[1, 17].Value = "Payment Gateway";
            workSheet.Cells[1, 18].Value = "Bank Reference Number";
            workSheet.Cells[1, 19].Value = "Payment Type";

            workSheet.Cells[1, 20].Value = "Transaction Fee (INR)";
            workSheet.Cells[1, 21].Value = "Additional Charges (INR)";
            workSheet.Cells[1, 22].Value = "Amount (INR)";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.Complaint_Number;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.ComplaintAgainst_Name;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.Payment_EmailAddress;
                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.Payment_MobileNumber;

                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.PaymentSuccessDate.HasValue ? (XlscodeItem.PaymentSuccessDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.PaymentSuccessDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.PG_Status;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.PG_PayU_ID;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.PaymentReferenceName;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.PG_Transaction_ID;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.PG_Date.HasValue ? (XlscodeItem.PG_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.PG_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.Amount;
                workSheet.Cells[recordIndex, 14].Value = XlscodeItem.PG_PaymentRef_Number;
                workSheet.Cells[recordIndex, 15].Value = XlscodeItem.PG_Merchant_Name;
                workSheet.Cells[recordIndex, 16].Value = XlscodeItem.PG_Bank_Name;
                workSheet.Cells[recordIndex, 17].Value = XlscodeItem.PG_Payment_Gateway;
                workSheet.Cells[recordIndex, 18].Value = XlscodeItem.PG_Bank_Reference_No;
                workSheet.Cells[recordIndex, 19].Value = XlscodeItem.PG_Payment_Type;

                workSheet.Cells[recordIndex, 20].Value = XlscodeItem.PG_Transaction_Fee;
                workSheet.Cells[recordIndex, 21].Value = XlscodeItem.PG_Additional_Charges;
                workSheet.Cells[recordIndex, 22].Value = XlscodeItem.PG_Amount_INR;

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
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();

            workSheet.Cells["A1:V1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:V1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 22])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofFeePaymentsFormM_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region EPAY FORM N
        [HttpGet]
        public ActionResult Display_ComplaintPaymentMIS_EpayFormN()
        {
            ClsMethodMIS_ComplaintFormM RegBussinessLayer = new ClsMethodMIS_ComplaintFormM();
            ClsprpMIS_CourtEpayPayment getObj = new ClsprpMIS_CourtEpayPayment();

            getObj.prpongoing = RegBussinessLayer.ComplaintEpayFormNGet().ToList();
            return View("Display_ComplaintPaymentMIS_EpayFormN", getObj);
        }

        [HttpPost]
        public ActionResult Display_ComplaintPaymentMIS_EpayFormN(ClsprpMIS_ComplaintFormM smodel)
        {
            ClsMethodMIS_ComplaintFormM RegBussinessLayer = new ClsMethodMIS_ComplaintFormM();
            ClsprpMIS_CourtEpayPayment getObj = new ClsprpMIS_CourtEpayPayment();
            ClsprpMIS_EpayComplaintFormM_ExportToExcel aaXls = new ClsprpMIS_EpayComplaintFormM_ExportToExcel();

            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_EpayComplaintNformPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_EpayComplaintFormM_ExportToExcel aaXlsInner = new ClsprpMIS_EpayComplaintFormM_ExportToExcel();

                    aaXlsInner.Complaint_Number = item.Complaint_Number;
                    aaXlsInner.Complainant_Name = item.Complainant_Name;
                    aaXlsInner.ComplaintAgainst_Name = item.ComplaintAgainst_Name;
                    aaXlsInner.Payment_EmailAddress = item.Payment_EmailAddress;
                    aaXlsInner.Payment_MobileNumber = item.Payment_MobileNumber;
                    aaXlsInner.PaymentSuccessDate = item.Payment_Success_Date;
                    aaXlsInner.PG_Status = item.PG_Status;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    //Fee Table Terms
                    aaXlsInner.PG_Payment_Description = item.PG_Product_Info;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.Amount = item.Payment_Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    //Payment Gateway
                    aaXlsInner.PG_PaymentRef_Number = item.PG_PaymentRef_Number;
                    aaXlsInner.PG_Merchant_Name = item.PG_Merchant_Name;
                    aaXlsInner.PG_Bank_Name = item.Bank_Name;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount;
                    aaXlsInner.PaymentReferenceName = item.PaymentReferenceName;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                Session["modelComplaintPaymentMIS_EpayFormN"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ComplaintPaymentMIS_EpayFormN", getObj);
        }

        public void EpayComplaintNformExportToExcel()
        {
            var objXlslist = Session["modelComplaintPaymentMIS_EpayFormN"] as List<ClsprpMIS_EpayComplaintFormM_ExportToExcel>;

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
            workSheet.Cells[1, 3].Value = "Complainant's Name";
            workSheet.Cells[1, 4].Value = "Respondant's Name";
            workSheet.Cells[1, 5].Value = "Email Address";
            workSheet.Cells[1, 6].Value = "Mobile or Phone Number";

            workSheet.Cells[1, 7].Value = "Transaction Date";
            workSheet.Cells[1, 8].Value = "Transaction Status";
            workSheet.Cells[1, 9].Value = "Payment Gateway ID";
            workSheet.Cells[1, 10].Value = "Payment Description";
            workSheet.Cells[1, 11].Value = "Transaction ID";
            workSheet.Cells[1, 12].Value = "Transaction Date";

            workSheet.Cells[1, 13].Value = "Amount (INR)";
            workSheet.Cells[1, 14].Value = "Payment Ref Number (PRN)";
            workSheet.Cells[1, 15].Value = "Merchant Name";
            workSheet.Cells[1, 16].Value = "Bank Name";
            workSheet.Cells[1, 17].Value = "Payment Gateway";
            workSheet.Cells[1, 18].Value = "Bank Reference Number";
            workSheet.Cells[1, 19].Value = "Payment Type";

            workSheet.Cells[1, 20].Value = "Transaction Fee (INR)";
            workSheet.Cells[1, 21].Value = "Additional Charges (INR)";
            workSheet.Cells[1, 22].Value = "Amount (INR)";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.Complaint_Number;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.ComplaintAgainst_Name;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.Payment_EmailAddress;
                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.Payment_MobileNumber;

                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.PaymentSuccessDate.HasValue ? (XlscodeItem.PaymentSuccessDate != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.PaymentSuccessDate.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.PG_Status;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.PG_PayU_ID;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.PaymentReferenceName;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.PG_Transaction_ID;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.PG_Date.HasValue ? (XlscodeItem.PG_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.PG_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.Amount;
                workSheet.Cells[recordIndex, 14].Value = XlscodeItem.PG_PaymentRef_Number;
                workSheet.Cells[recordIndex, 15].Value = XlscodeItem.PG_Merchant_Name;
                workSheet.Cells[recordIndex, 16].Value = XlscodeItem.PG_Bank_Name;
                workSheet.Cells[recordIndex, 17].Value = XlscodeItem.PG_Payment_Gateway;
                workSheet.Cells[recordIndex, 18].Value = XlscodeItem.PG_Bank_Reference_No;
                workSheet.Cells[recordIndex, 19].Value = XlscodeItem.PG_Payment_Type;

                workSheet.Cells[recordIndex, 20].Value = XlscodeItem.PG_Transaction_Fee;
                workSheet.Cells[recordIndex, 21].Value = XlscodeItem.PG_Additional_Charges;
                workSheet.Cells[recordIndex, 22].Value = XlscodeItem.PG_Amount_INR;

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
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();

            workSheet.Cells["A1:V1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:V1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 22])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofFeePaymentsFormM_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion




        [HttpGet]
        public ActionResult Display_ComplaintPaymentMIS_FormN()
        {
            ClsMethodMIS_ComplaintFormN RegistrationBussinessLayer = new ClsMethodMIS_ComplaintFormN();
            ClsprpMIS_ComplaintFormN getObj = new ClsprpMIS_ComplaintFormN();

            getObj.prpongoing = RegistrationBussinessLayer.ComplaintNGet().ToList();
            return View("Display_ComplaintPaymentMIS_FormN", getObj);
        }

        [HttpPost]
        public ActionResult Display_ComplaintPaymentMIS_FormN(ClsprpMIS_ComplaintFormN smodel)
        {
            ClsMethodMIS_ComplaintFormN RegBussinessLayer = new ClsMethodMIS_ComplaintFormN();
            ClsprpMIS_ComplaintFormN getObj = new ClsprpMIS_ComplaintFormN();
            ClsprpMIS_ComplaintFormN_ExportToExcel aaXls = new ClsprpMIS_ComplaintFormN_ExportToExcel();

            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registered Complaints Payments (2)Pending Diary Number Complaints Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ComplaintNformPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ComplaintFormN_ExportToExcel aaXlsInner = new ClsprpMIS_ComplaintFormN_ExportToExcel();

                    aaXlsInner.Application_Diary_Number = item.Application_Diary_Number;
                    aaXlsInner.Applicant_Name = item.Applicant_Name;
                    aaXlsInner.Respondant_Name = item.Respondant_Name;
                    aaXlsInner.PG_Complainant_Email = item.PG_Complainant_Email;
                    aaXlsInner.PG_Complainant_Phone = item.PG_Complainant_Phone;
                    aaXlsInner.Payment_Success_Date = item.Payment_Success_Date;
                    aaXlsInner.Status = item.Status;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    //Fee Table Terms
                    aaXlsInner.PG_Payment_Description = item.PG_Payment_Description;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.Amount = item.Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    //Payment Gateway
                    aaXlsInner.PG_PaymentRef_Number = item.PG_PaymentRef_Number;
                    aaXlsInner.PG_Merchant_Name = item.PG_Merchant_Name;
                    aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                    aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                Session["modelComplaintPaymentMIS_FormN"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ComplaintPaymentMIS_FormN", getObj);
        }

        public void ExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["model"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=UserDetails_" + strDateFormat + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public void ComplaintMformExportToExcel()
        {
            var objXlslist = Session["modelComplaintPaymentMIS_FormM"] as List<ClsprpMIS_ComplaintFormM_ExportToExcel>;

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
            workSheet.Cells[1, 3].Value = "Complainant's Name";
            workSheet.Cells[1, 4].Value = "Respondant's Name";
            workSheet.Cells[1, 5].Value = "Email Address";
            workSheet.Cells[1, 6].Value = "Mobile or Phone Number";

            workSheet.Cells[1, 7].Value = "Transaction Date";
            workSheet.Cells[1, 8].Value = "Transaction Status";
            workSheet.Cells[1, 9].Value = "Payment Gateway ID";
            workSheet.Cells[1, 10].Value = "Payment Description";
            workSheet.Cells[1, 11].Value = "Transaction ID";
            workSheet.Cells[1, 12].Value = "Transaction Date";

            workSheet.Cells[1, 13].Value = "Amount (INR)";
            workSheet.Cells[1, 14].Value = "Payment Ref Number (PRN)";
            workSheet.Cells[1, 15].Value = "Merchant Name";
            workSheet.Cells[1, 16].Value = "Bank Name";
            workSheet.Cells[1, 17].Value = "Payment Gateway";
            workSheet.Cells[1, 18].Value = "Bank Reference Number";
            workSheet.Cells[1, 19].Value = "Payment Type";

            workSheet.Cells[1, 20].Value = "Transaction Fee (INR)";
            workSheet.Cells[1, 21].Value = "Additional Charges (INR)";
            workSheet.Cells[1, 22].Value = "Amount (INR)";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.Complaint_Diary_Number;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Complainant_Name;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.Respondant_Name;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.PG_Complainant_Email;
                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.PG_Complainant_Phone;

                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.Payment_Success_Date.HasValue ? (XlscodeItem.Payment_Success_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Payment_Success_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.Status;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.PG_PayU_ID;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.PG_Payment_Description;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.PG_Transaction_ID;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.PG_Date.HasValue ? (XlscodeItem.PG_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.PG_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.Amount;
                workSheet.Cells[recordIndex, 14].Value = XlscodeItem.PG_PaymentRef_Number;
                workSheet.Cells[recordIndex, 15].Value = XlscodeItem.PG_Merchant_Name;
                workSheet.Cells[recordIndex, 16].Value = XlscodeItem.PG_Bank_Name;
                workSheet.Cells[recordIndex, 17].Value = XlscodeItem.PG_Payment_Gateway;
                workSheet.Cells[recordIndex, 18].Value = XlscodeItem.PG_Bank_Reference_No;
                workSheet.Cells[recordIndex, 19].Value = XlscodeItem.PG_Payment_Type;

                workSheet.Cells[recordIndex, 20].Value = XlscodeItem.PG_Transaction_Fee;
                workSheet.Cells[recordIndex, 21].Value = XlscodeItem.PG_Additional_Charges;
                workSheet.Cells[recordIndex, 22].Value = XlscodeItem.PG_Amount_INR;

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
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();

            workSheet.Cells["A1:V1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:V1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 22])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofFeePaymentsFormM_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public void ComplaintNformExportToExcel()
        {
            var objXlslist = Session["modelComplaintPaymentMIS_FormN"] as List<ClsprpMIS_ComplaintFormN_ExportToExcel>;

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
            workSheet.Cells[1, 3].Value = "Complainant's Name";
            workSheet.Cells[1, 4].Value = "Respondant's Name";
            workSheet.Cells[1, 5].Value = "Email Address";
            workSheet.Cells[1, 6].Value = "Mobile or Phone Number";

            workSheet.Cells[1, 7].Value = "Transaction Date";
            workSheet.Cells[1, 8].Value = "Transaction Status";
            workSheet.Cells[1, 9].Value = "Payment Gateway ID";
            workSheet.Cells[1, 10].Value = "Payment Description";
            workSheet.Cells[1, 11].Value = "Transaction ID";
            workSheet.Cells[1, 12].Value = "Transaction Date";

            workSheet.Cells[1, 13].Value = "Amount (INR)";
            workSheet.Cells[1, 14].Value = "Payment Ref Number (PRN)";
            workSheet.Cells[1, 15].Value = "Merchant Name";
            workSheet.Cells[1, 16].Value = "Bank Name";
            workSheet.Cells[1, 17].Value = "Payment Gateway";
            workSheet.Cells[1, 18].Value = "Bank Reference Number";
            workSheet.Cells[1, 19].Value = "Payment Type";

            workSheet.Cells[1, 20].Value = "Transaction Fee (INR)";
            workSheet.Cells[1, 21].Value = "Additional Charges (INR)";
            workSheet.Cells[1, 22].Value = "Amount (INR)";

            //Body of table 
            int recordIndex = 2;
            foreach (var XlscodeItem in objXlslist)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = XlscodeItem.Application_Diary_Number;
                workSheet.Cells[recordIndex, 3].Value = XlscodeItem.Applicant_Name;
                workSheet.Cells[recordIndex, 4].Value = XlscodeItem.Respondant_Name;
                workSheet.Cells[recordIndex, 5].Value = XlscodeItem.PG_Complainant_Email;
                workSheet.Cells[recordIndex, 6].Value = XlscodeItem.PG_Complainant_Phone;

                workSheet.Cells[recordIndex, 7].Value = XlscodeItem.Payment_Success_Date.HasValue ? (XlscodeItem.Payment_Success_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.Payment_Success_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;
                workSheet.Cells[recordIndex, 8].Value = XlscodeItem.Status;
                workSheet.Cells[recordIndex, 9].Value = XlscodeItem.PG_PayU_ID;
                workSheet.Cells[recordIndex, 10].Value = XlscodeItem.PG_Payment_Description;
                workSheet.Cells[recordIndex, 11].Value = XlscodeItem.PG_Transaction_ID;
                workSheet.Cells[recordIndex, 12].Value = XlscodeItem.PG_Date.HasValue ? (XlscodeItem.PG_Date != Convert.ToDateTime("0001-01-01 00:00:00") ? XlscodeItem.PG_Date.Value.ToString("dd-MMM-yyyy") : string.Empty) : string.Empty;

                workSheet.Cells[recordIndex, 13].Value = XlscodeItem.Amount;
                workSheet.Cells[recordIndex, 14].Value = XlscodeItem.PG_PaymentRef_Number;
                workSheet.Cells[recordIndex, 15].Value = XlscodeItem.PG_Merchant_Name;
                workSheet.Cells[recordIndex, 16].Value = XlscodeItem.PG_Bank_Name;
                workSheet.Cells[recordIndex, 17].Value = XlscodeItem.PG_Payment_Gateway;
                workSheet.Cells[recordIndex, 18].Value = XlscodeItem.PG_Bank_Reference_No;
                workSheet.Cells[recordIndex, 19].Value = XlscodeItem.PG_Payment_Type;

                workSheet.Cells[recordIndex, 20].Value = XlscodeItem.PG_Transaction_Fee;
                workSheet.Cells[recordIndex, 21].Value = XlscodeItem.PG_Additional_Charges;
                workSheet.Cells[recordIndex, 22].Value = XlscodeItem.PG_Amount_INR;

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
            workSheet.Column(17).AutoFit();
            workSheet.Column(18).AutoFit();
            workSheet.Column(19).AutoFit();
            workSheet.Column(20).AutoFit();
            workSheet.Column(21).AutoFit();
            workSheet.Column(22).AutoFit();

            workSheet.Cells["A1:V1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["A1:V1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            using (ExcelRange RangeXls = workSheet.Cells[1, 1, recordIndex - 1, 22])
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
                Response.AddHeader("content-disposition", "attachment; filename=ListofFeePaymentsFormN_" + strDateFormat + ".xls");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        #endregion

        #region Project Payments List

        #region Registration Fee
        [HttpGet]
        public ActionResult Display_ProjectPaymentMIS()
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsRegistration getObj = new ClsprpMIS_ProjectPaymentsRegistration();
            ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

            string userRole = string.Empty;

            DateTime prmFromDate = DateTime.Now.AddMonths(-1);
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "1";    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
            String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year  
            Int32 application_Month = 0;        //Month
            Int32 application_EventYear = 0;    //Year

            getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

                aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.ProjectName = item.ProjectName;
                aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.PromoterType = item.PromoterType;
                //Fee Table Terms
                aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                aaXlsInner.Registration_Fee = item.Registration_Fee;
                aaXlsInner.Other_Fee = item.Other_Fee;
                aaXlsInner.Payment_Mode = item.Payment_Mode;
                aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aaXlsInner.Bank_Name = item.Bank_Name;
                aaXlsInner.Branch_Name = item.Branch_Name;
                aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                // Project PaymentGateway
                aaXlsInner.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                aaXlsInner.PG_Date = item.PG_Date;
                aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                aaXlsInner.PG_Amount = item.PG_Amount;
                aaXlsInner.PG_Status = item.PG_Status;
                aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                aaXlsInner.PG_Discount = item.PG_Discount;
                aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                aaXls.prpongoing.Add(aaXlsInner);
            }

            getObj.Application_SearchOptionFlag = application_SearchTypeFlag;
            getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
            getObj.Application_FromDate = prmFromDate;
            getObj.Application_ToDate = prmToDate;
            getObj.EventMonth = application_Month;
            getObj.EventYear = application_EventYear;

            Session["modelProjectRegistrationPaymentsMIS"] = aaXls.prpongoing;
            return View("Display_ProjectPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectPaymentMIS(ClsprpMIS_ProjectPaymentsRegistration smodel)
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsRegistration getObj = new ClsprpMIS_ProjectPaymentsRegistration();
            ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

            ModelState.Remove("PG_Amount");
            ModelState.Remove("PG_Product_Info");
            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                //if (application_SearchTypeFlag == "2")
                //{
                //    prmFromDate = DateTime.Now;
                //    prmToDate = prmFromDate.AddMonths(3);
                //    application_SearchRangeFlag = "1";
                //}

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

                    aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                    aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                    aaXlsInner.ProjectName = item.ProjectName;
                    aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.PromoterType = item.PromoterType;
                    //Fee Table Terms
                    aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                    aaXlsInner.Registration_Fee = item.Registration_Fee;
                    aaXlsInner.Other_Fee = item.Other_Fee;
                    aaXlsInner.Payment_Mode = item.Payment_Mode;
                    aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    aaXlsInner.Bank_Name = item.Bank_Name;
                    aaXlsInner.Branch_Name = item.Branch_Name;
                    aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    // Project PaymentGateway
                    aaXlsInner.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    aaXlsInner.PG_Amount = item.PG_Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                    aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                    aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Discount = item.PG_Discount;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                //if (application_SearchTypeFlag == "2")
                //{
                //    getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
                //    getObj.Application_FromDate = prmFromDate;
                //    getObj.Application_ToDate = prmToDate;
                //}

                Session["modelProjectRegistrationPaymentsMIS"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectPaymentMIS", getObj);
        }

        public void ProjectRegistrationFeeExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectRegistrationPaymentsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=PaymentsDetails_" + strDateFormat + ".xls");
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
        #region Extension of Registration Fee
        [HttpGet]
        public ActionResult Display_ProjectExtensionPaymentMIS()
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsRegistration getObj = new ClsprpMIS_ProjectPaymentsRegistration();
            ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

            string userRole = string.Empty;

            DateTime prmFromDate = DateTime.Now.AddMonths(-1);
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "1";    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
            String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year  
            Int32 application_Month = 0;        //Month
            Int32 application_EventYear = 0;    //Year

            getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectExtensionOfRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

                aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.ProjectName = item.ProjectName;
                aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.PromoterType = item.PromoterType;
                //Fee Table Terms
                aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                aaXlsInner.Registration_Fee = item.Registration_Fee;
                aaXlsInner.Other_Fee = item.Other_Fee;
                aaXlsInner.Payment_Mode = item.Payment_Mode;
                aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aaXlsInner.Bank_Name = item.Bank_Name;
                aaXlsInner.Branch_Name = item.Branch_Name;
                aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                // Project PaymentGateway
                aaXlsInner.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                aaXlsInner.PG_Date = item.PG_Date;
                aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                aaXlsInner.PG_Amount = item.PG_Amount;
                aaXlsInner.PG_Status = item.PG_Status;
                aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                aaXlsInner.PG_Discount = item.PG_Discount;
                aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                aaXls.prpongoing.Add(aaXlsInner);
            }

            getObj.Application_SearchOptionFlag = application_SearchTypeFlag;
            getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
            getObj.Application_FromDate = prmFromDate;
            getObj.Application_ToDate = prmToDate;
            getObj.EventMonth = application_Month;
            getObj.EventYear = application_EventYear;

            Session["modelProjectExtensionPaymentsMIS"] = aaXls.prpongoing;
            return View("Display_ProjectExtensionPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectExtensionPaymentMIS(ClsprpMIS_ProjectPaymentsRegistration smodel)
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsRegistration getObj = new ClsprpMIS_ProjectPaymentsRegistration();
            ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

            ModelState.Remove("PG_Amount");
            ModelState.Remove("PG_Product_Info");
            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                //if (application_SearchTypeFlag == "2")
                //{
                //    prmFromDate = DateTime.Now;
                //    prmToDate = prmFromDate.AddMonths(3);
                //    application_SearchRangeFlag = "1";
                //}

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectExtensionOfRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

                    aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                    aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                    aaXlsInner.ProjectName = item.ProjectName;
                    aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.PromoterType = item.PromoterType;
                    //Fee Table Terms
                    aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                    aaXlsInner.Registration_Fee = item.Registration_Fee;
                    aaXlsInner.Other_Fee = item.Other_Fee;
                    aaXlsInner.Payment_Mode = item.Payment_Mode;
                    aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    aaXlsInner.Bank_Name = item.Bank_Name;
                    aaXlsInner.Branch_Name = item.Branch_Name;
                    aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    // Project PaymentGateway
                    aaXlsInner.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    aaXlsInner.PG_Amount = item.PG_Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                    aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                    aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Discount = item.PG_Discount;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                //if (application_SearchTypeFlag == "2")
                //{
                //    getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
                //    getObj.Application_FromDate = prmFromDate;
                //    getObj.Application_ToDate = prmToDate;
                //}

                Session["modelProjectExtensionPaymentsMIS"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectExtensionPaymentMIS", getObj);
        }

        public void ProjectExtensionFeeExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectExtensionPaymentsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=PaymentsDetails_" + strDateFormat + ".xls");
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
        #region Additional Fee
        [HttpGet]
        public ActionResult Display_ProjectAdditionalPaymentMIS()
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsMiscAdditional getObj = new ClsprpMIS_ProjectPaymentsMiscAdditional();
            ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

            string userRole = string.Empty;

            DateTime prmFromDate = DateTime.Now.AddMonths(-1);
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "1";    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
            String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year  
            Int32 application_Month = 0;        //Month
            Int32 application_EventYear = 0;    //Year

            getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectAdditionalPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

                aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.ProjectName = item.ProjectName;
                aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.PromoterType = item.PromoterType;
                //Fee Table Terms
                aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                aaXlsInner.RelatedAnnualYear = item.RelatedAnnualYear;
                aaXlsInner.RelatedSessionYear_Name = item.RelatedSessionYear_Name;
                aaXlsInner.Registration_Fee = item.Registration_Fee;
                aaXlsInner.Other_Fee = item.Other_Fee;
                aaXlsInner.Payment_Mode = item.Payment_Mode;
                aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aaXlsInner.Bank_Name = item.Bank_Name;
                aaXlsInner.Branch_Name = item.Branch_Name;
                aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                // Project PaymentGateway
                aaXlsInner.PaymentRefNumberMiscProjectPm_ID = item.PaymentRefNumberMiscProjectPm_ID;
                aaXlsInner.MiscFeeProject_Flag = item.MiscFeeProject_Flag;
                aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                aaXlsInner.PG_Date = item.PG_Date;
                aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                aaXlsInner.PG_Amount = item.PG_Amount;
                aaXlsInner.PG_Status = item.PG_Status;
                aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                aaXlsInner.PG_Discount = item.PG_Discount;
                aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                aaXls.prpongoing.Add(aaXlsInner);
            }

            getObj.Application_SearchOptionFlag = application_SearchTypeFlag;
            getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
            getObj.Application_FromDate = prmFromDate;
            getObj.Application_ToDate = prmToDate;
            getObj.EventMonth = application_Month;
            getObj.EventYear = application_EventYear;

            Session["modelProjectAdditionalPaymentsMIS"] = aaXls.prpongoing;
            return View("Display_ProjectAdditionalPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectAdditionalPaymentMIS(ClsprpMIS_ProjectPaymentsMiscAdditional smodel)
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsMiscAdditional getObj = new ClsprpMIS_ProjectPaymentsMiscAdditional();
            ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

            ModelState.Remove("PG_Amount");
            ModelState.Remove("PG_Product_Info");
            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectAdditionalPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

                    aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                    aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                    aaXlsInner.ProjectName = item.ProjectName;
                    aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.PromoterType = item.PromoterType;
                    //Fee Table Terms
                    aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                    aaXlsInner.RelatedAnnualYear = item.RelatedAnnualYear;
                    aaXlsInner.RelatedSessionYear_Name = item.RelatedSessionYear_Name;
                    aaXlsInner.Registration_Fee = item.Registration_Fee;
                    aaXlsInner.Other_Fee = item.Other_Fee;
                    aaXlsInner.Payment_Mode = item.Payment_Mode;
                    aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    aaXlsInner.Bank_Name = item.Bank_Name;
                    aaXlsInner.Branch_Name = item.Branch_Name;
                    aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    // Project PaymentGateway
                    aaXlsInner.PaymentRefNumberMiscProjectPm_ID = item.PaymentRefNumberMiscProjectPm_ID;
                    aaXlsInner.MiscFeeProject_Flag = item.MiscFeeProject_Flag;
                    aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    aaXlsInner.PG_Amount = item.PG_Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                    aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                    aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Discount = item.PG_Discount;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                Session["modelProjectAdditionalPaymentsMIS"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectAdditionalPaymentMIS", getObj);
        }

        public void ProjectAdditionalFeeExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectAdditionalPaymentsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=PaymentsDetails_" + strDateFormat + ".xls");
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
        #region Misc and AWM Fee
        [HttpGet]
        public ActionResult Display_ProjectMiscPaymentMIS()
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsMiscAdditional getObj = new ClsprpMIS_ProjectPaymentsMiscAdditional();
            ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

            string userRole = string.Empty;

            DateTime prmFromDate = DateTime.Now.AddMonths(-1);
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "1";    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
            String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year  
            Int32 application_Month = 0;        //Month
            Int32 application_EventYear = 0;    //Year

            getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectMiscPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

                aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.ProjectName = item.ProjectName;
                aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.PromoterType = item.PromoterType;
                //Fee Table Terms
                aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                aaXlsInner.RelatedAnnualYear = item.RelatedAnnualYear;
                aaXlsInner.RelatedSessionYear_Name = item.RelatedSessionYear_Name;
                aaXlsInner.Registration_Fee = item.Registration_Fee;
                aaXlsInner.Other_Fee = item.Other_Fee;
                aaXlsInner.Payment_Mode = item.Payment_Mode;
                aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                aaXlsInner.Bank_Name = item.Bank_Name;
                aaXlsInner.Branch_Name = item.Branch_Name;
                aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                // Project PaymentGateway
                aaXlsInner.PaymentRefNumberMiscProjectPm_ID = item.PaymentRefNumberMiscProjectPm_ID;
                aaXlsInner.MiscFeeProject_Flag = item.MiscFeeProject_Flag;
                aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                aaXlsInner.PG_Date = item.PG_Date;
                aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                aaXlsInner.PG_Amount = item.PG_Amount;
                aaXlsInner.PG_Status = item.PG_Status;
                aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                aaXlsInner.PG_Discount = item.PG_Discount;
                aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                aaXls.prpongoing.Add(aaXlsInner);
            }

            getObj.Application_SearchOptionFlag = application_SearchTypeFlag;
            getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
            getObj.Application_FromDate = prmFromDate;
            getObj.Application_ToDate = prmToDate;
            getObj.EventMonth = application_Month;
            getObj.EventYear = application_EventYear;

            Session["modelProjectMiscFeePaymentsMIS"] = aaXls.prpongoing;
            return View("Display_ProjectMiscPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ProjectMiscPaymentMIS(ClsprpMIS_ProjectPaymentsMiscAdditional smodel)
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_ProjectPaymentsMiscAdditional getObj = new ClsprpMIS_ProjectPaymentsMiscAdditional();
            ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

            ModelState.Remove("PG_Amount");
            ModelState.Remove("PG_Product_Info");
            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
                String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                Int32 application_Month = smodel.EventMonth;    //Month
                Int32 application_EventYear = smodel.EventYear; //Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectMiscPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                ViewBag.data = "true";

                foreach (var item in getObj.prpongoing)
                {
                    ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsMiscAdditionalExportToExcel();

                    aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
                    aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                    aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                    aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                    aaXlsInner.ProjectName = item.ProjectName;
                    aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
                    aaXlsInner.Promoter_Name = item.Promoter_Name;
                    aaXlsInner.PromoterType = item.PromoterType;
                    //Fee Table Terms
                    aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
                    aaXlsInner.RelatedAnnualYear = item.RelatedAnnualYear;
                    aaXlsInner.RelatedSessionYear_Name = item.RelatedSessionYear_Name;
                    aaXlsInner.Registration_Fee = item.Registration_Fee;
                    aaXlsInner.Other_Fee = item.Other_Fee;
                    aaXlsInner.Payment_Mode = item.Payment_Mode;
                    aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                    aaXlsInner.Bank_Name = item.Bank_Name;
                    aaXlsInner.Branch_Name = item.Branch_Name;
                    aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                    aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                    // Project PaymentGateway
                    aaXlsInner.PaymentRefNumberMiscProjectPm_ID = item.PaymentRefNumberMiscProjectPm_ID;
                    aaXlsInner.MiscFeeProject_Flag = item.MiscFeeProject_Flag;
                    aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
                    aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
                    aaXlsInner.PG_Date = item.PG_Date;
                    aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                    aaXlsInner.PG_Amount = item.PG_Amount;
                    aaXlsInner.PG_Status = item.PG_Status;
                    aaXlsInner.PG_Product_Info = item.PG_Product_Info;
                    aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
                    aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
                    aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aaXlsInner.PG_Discount = item.PG_Discount;
                    aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
                    aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

                    aaXls.prpongoing.Add(aaXlsInner);
                }

                getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                getObj.Application_FromDate = smodel.Application_FromDate;
                getObj.Application_ToDate = smodel.Application_ToDate;
                getObj.EventMonth = smodel.EventMonth;
                getObj.EventYear = smodel.EventYear;

                Session["modelProjectMiscFeePaymentsMIS"] = aaXls.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_ProjectMiscPaymentMIS", getObj);
        }

        public void ProjectMiscFeeExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelProjectMiscFeePaymentsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=PaymentsDetails_" + strDateFormat + ".xls");
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

        #region ePay Fee
        [HttpGet]
        public ActionResult Display_ePayProjectPaymentMIS()
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_EpayProjectRegistration getObj = new ClsprpMIS_EpayProjectRegistration();
            ClsprpMIS_EpayProjectRegistrationExportToExcel aaXls = new ClsprpMIS_EpayProjectRegistrationExportToExcel();

            string userRole = string.Empty;
            string userID = string.Empty;
            //if(Session["User_Id"] !=null )
            if(!string.IsNullOrWhiteSpace(Session["User_Id"] as string))
            {
                userID =Convert.ToString(Session["User_Id"]);
            }

            DateTime prmFromDate = DateTime.Now.AddMonths(-1);
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "503";    //(503)Penalty Fee (504)Services Fee (505)Others Fee
            String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year  
            Int32 application_Month = 0;        //Month
            Int32 application_EventYear = 0;    //Year

            getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ePayProjectRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();

            foreach (var item in getObj.prpongoing)
            {
                ClsprpMIS_EpayProjectRegistrationExportToExcel aaXlsInner = new ClsprpMIS_EpayProjectRegistrationExportToExcel();

                aaXlsInner.ReferenceChoiceValue = item.ReferenceChoiceValue;
                aaXlsInner.ReferenceChoiceName = item.ReferenceChoiceName;
                aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                aaXlsInner.Project_ID = item.Project_ID;
                aaXlsInner.ExtensionProject_ID = item.ExtensionProject_ID ?? 0;
                aaXlsInner.Project_Name = item.Project_Name;
                aaXlsInner.Promoter_ID = item.Promoter_ID;
                aaXlsInner.ProjectAddress_DistrictName = item.ProjectAddress_DistrictName;
                aaXlsInner.Promoter_Name = item.Promoter_Name;
                aaXlsInner.PaymentReferenceName = item.PaymentReferenceName;
                aaXlsInner.Payment_Amount = item.Payment_Amount;
                aaXlsInner.Bank_Name = item.Bank_Name;
                aaXlsInner.Payment_GroupName = item.Payment_GroupName;
                aaXlsInner.PaymentForName = item.PaymentForName;
                aaXlsInner.PartyName = item.PartyName;
                aaXlsInner.BenchName = item.BenchName;
                aaXlsInner.BenchOrderNumber = item.BenchOrderNumber;
                aaXlsInner.Payment_EmailAddress = item.Payment_EmailAddress;
                aaXlsInner.Payment_MobileNumber = item.Payment_MobileNumber;
                aaXlsInner.PG_Date = item.PG_Date;
                aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                aaXlsInner.PG_Amount = item.PG_Amount;
                aaXlsInner.PG_Status = item.PG_Status;
                aaXls.prpongoing.Add(aaXlsInner);
            }

            getObj.Application_SearchOptionFlag = application_SearchTypeFlag;
            getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
            getObj.Application_FromDate = prmFromDate;
            getObj.Application_ToDate = prmToDate;
            getObj.EventMonth = application_Month;
            getObj.EventYear = application_EventYear;

            Session["modelEpayProjectRegistrationPaymentsMIS"] = aaXls.prpongoing;
            ActivityLogger.LogEventActivity(userID, "PaymentReports", "Display_ePayProjectPaymentMIS");
            return View("Display_ePayProjectPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_ePayProjectPaymentMIS(ClsprpMIS_EpayProjectRegistration smodel)
        {
            ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
            ClsprpMIS_EpayProjectRegistration getObj = new ClsprpMIS_EpayProjectRegistration();
            ClsprpMIS_EpayProjectRegistrationExportToExcel aaXls = new ClsprpMIS_EpayProjectRegistrationExportToExcel();

            //ModelState.Remove("PG_Amount");
            //ModelState.Remove("PG_Product_Info");
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    string userRole = string.Empty;

                    DateTime dtvalue = new DateTime(0001, 1, 1);

                    DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                    DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                    String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
                    String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                    Int32 application_Month = smodel.EventMonth;    //Month
                    Int32 application_EventYear = smodel.EventYear; //Year

                    getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ePayProjectRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
                    ViewBag.data = "true";

                    foreach (var item in getObj.prpongoing)
                    {
                        ClsprpMIS_EpayProjectRegistrationExportToExcel aaXlsInner = new ClsprpMIS_EpayProjectRegistrationExportToExcel();

                        aaXlsInner.ReferenceChoiceValue = item.ReferenceChoiceValue;
                        aaXlsInner.ReferenceChoiceName = item.ReferenceChoiceName;
                        aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
                        aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
                        aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
                        aaXlsInner.Project_ID = item.Project_ID;
                        aaXlsInner.ExtensionProject_ID = item.ExtensionProject_ID ?? 0;
                        aaXlsInner.Project_Name = item.Project_Name;
                        aaXlsInner.Promoter_ID = item.Promoter_ID;
                        aaXlsInner.ProjectAddress_DistrictName = item.ProjectAddress_DistrictName;
                        aaXlsInner.Promoter_Name = item.Promoter_Name;
                        aaXlsInner.PaymentReferenceName = item.PaymentReferenceName;
                        aaXlsInner.Payment_Amount = item.Payment_Amount;
                        aaXlsInner.Bank_Name = item.Bank_Name;
                        aaXlsInner.Payment_GroupName = item.Payment_GroupName;
                        aaXlsInner.PaymentForName = item.PaymentForName;
                        aaXlsInner.PartyName = item.PartyName;
                        aaXlsInner.BenchName = item.BenchName;
                        aaXlsInner.BenchOrderNumber = item.BenchOrderNumber;
                        aaXlsInner.Payment_EmailAddress = item.Payment_EmailAddress;
                        aaXlsInner.Payment_MobileNumber = item.Payment_MobileNumber;
                        aaXlsInner.PG_Date = item.PG_Date;
                        aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
                        aaXlsInner.PG_Amount = item.PG_Amount;
                        aaXlsInner.PG_Status = item.PG_Status;

                        aaXls.prpongoing.Add(aaXlsInner);
                    }

                    getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
                    getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
                    getObj.Application_FromDate = smodel.Application_FromDate;
                    getObj.Application_ToDate = smodel.Application_ToDate;
                    getObj.EventMonth = smodel.EventMonth;
                    getObj.EventYear = smodel.EventYear;

                    Session["modelEpayProjectRegistrationPaymentsMIS"] = aaXls.prpongoing;
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

                throw ex;
            }
            return View("Display_ePayProjectPaymentMIS", getObj);
        }

        public void epayFeeExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelEpayProjectRegistrationPaymentsMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=PaymentsDetails_" + strDateFormat + ".xls");
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

        #endregion


        #region Agent and Complaint Payment List
        [HttpGet]
        public ActionResult Display_AgentPaymentMIS()
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentPayment getObj = new ClsprpMIS_AgentPayment();

            var now = DateTime.Now;
            getObj.prpongoing = RegBussinessLayer.AgentPaymentGet().ToList();
            return View("Display_AgentPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_AgentPaymentMIS(DateTime FromDate, DateTime ToDate)
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentPayment getObj = new ClsprpMIS_AgentPayment();

            if (ModelState.IsValid)
            {
                getObj.prpongoing = RegBussinessLayer.AgentPaymentPost(FromDate, ToDate).ToList();
                ViewBag.data = "true";
                Session["modelAgentPaymentMIS"] = getObj.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_AgentPaymentMIS", getObj);
        }

        public void AgentRegistrationExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelAgentPaymentMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=RealestateAgentPaymentDetails_" + strDateFormat + ".xls");
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
        public ActionResult Display_AgentRenewalPaymentMIS()
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentPayment getObj = new ClsprpMIS_AgentPayment();

            var now = DateTime.Now;
            getObj.prpongoing = RegBussinessLayer.AgentRenewalPaymentGet().ToList();
            return View("Display_AgentRenewalPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_AgentRenewalPaymentMIS(DateTime FromDate, DateTime ToDate)
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentPayment getObj = new ClsprpMIS_AgentPayment();

            if (ModelState.IsValid)
            {
                getObj.prpongoing = RegBussinessLayer.AgentRenewalPaymentPost(FromDate, ToDate).ToList();
                ViewBag.data = "true";
                Session["modelAgentPaymentMIS"] = getObj.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_AgentRenewalPaymentMIS", getObj);
        }

        [HttpGet]
        public ActionResult Display_AgentMiscellaneousPaymentMIS()
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentPayment getObj = new ClsprpMIS_AgentPayment();

            var now = DateTime.Now;
            getObj.prpongoing = RegBussinessLayer.AgentPaymentGet().ToList();
            return View("Display_AgentMiscellaneousPaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_AgentMiscellaneousPaymentMIS(DateTime FromDate, DateTime ToDate)
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentPayment getObj = new ClsprpMIS_AgentPayment();

            if (ModelState.IsValid)
            {
                getObj.prpongoing = RegBussinessLayer.AgentRenewalPaymentPost(FromDate, ToDate).ToList();
                ViewBag.data = "true";
                Session["modelAgentPaymentMIS"] = getObj.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_AgentMiscellaneousPaymentMIS", getObj);
        }


        #region EPAY AGENT
        [HttpGet]
        public ActionResult Display_Agent_ePaymentMIS()
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentEpayPayment getObj = new ClsprpMIS_AgentEpayPayment();
            string userRole = string.Empty;

            DateTime prmFromDate = DateTime.Now;
            DateTime prmToDate = DateTime.Now;
            String application_SearchTypeFlag = "605";    //(601) Fee (604)Other Fee (605)Service Fee
            //String application_SearchRangeFlag = "1";   //(1)From-Date/To-Date  (2)Month/Year

            getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ePayAgentRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag).ToList();
            //getObj.prpongoing = RegBussinessLayer.AgentEpayPaymentGet().ToList();


            getObj.Application_SearchOptionFlag = application_SearchTypeFlag;
            //getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
            getObj.Application_FromDate = prmFromDate;
            getObj.Application_ToDate = prmToDate;
            //getObj.EventMonth = application_Month;
            //getObj.EventYear = application_EventYear;
            Session["modelAgentEpayPaymentMIS"] = getObj.prpongoing;

            return View("Display_Agent_ePaymentMIS", getObj);
        }

        [HttpPost]
        public ActionResult Display_Agent_ePaymentMIS(ClsprpMIS_AgentEpayPayment smodel)
        {
            ClsMethodMIS_AgentPayment RegBussinessLayer = new ClsMethodMIS_AgentPayment();
            ClsprpMIS_AgentEpayPayment getObj = new ClsprpMIS_AgentEpayPayment();

            if (ModelState.IsValid)
            {
                string userRole = string.Empty;

                DateTime dtvalue = new DateTime(0001, 1, 1);

                DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
                DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

                String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
                //String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

                getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ePayAgentRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag).ToList();
                //getObj.prpongoing = RegBussinessLayer.AgentEpayPaymentPost(FromDate, ToDate).ToList();
                ViewBag.data = "true";
                Session["modelAgentEpayPaymentMIS"] = getObj.prpongoing;
                if (getObj.prpongoing.Count > 0)
                {
                    //  ExportToExcel();
                }
                else
                {
                    ViewData["data"] = "No data found";
                }
            }
            return View("Display_Agent_ePaymentMIS", getObj);
        }

        public void AgentRegistrationEpayExportToExcel()
        {
            GridView gv = new GridView();
            gv.DataSource = Session["modelAgentEpayPaymentMIS"];
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string strDateFormat = string.Empty;
            strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
            Response.AddHeader("content-disposition", "attachment; filename=RealestateAgentPaymentDetails_" + strDateFormat + ".xls");
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

        #endregion


        #region Consolidated payments
        [HttpGet]
        public ActionResult Display_ConsolidatedEpayPaymentMIS()
        {
            return View("Display_ConsolidatedEpayPaymentMIS");
        }
        [HttpGet]
        public ActionResult Display_ConsolidatedPaymentMIS()
        {
            return View("Display_ConsolidatedPaymentMIS");
        }

        //[HttpPost]
        //public ActionResult Display_ConsolidatedEpayPaymentMIS(ClsprpMIS_ProjectPaymentsRegistration smodel)
        //{
        //    ClsMethodMIS_ProjectPaymentDetails RegBussinessLayer = new ClsMethodMIS_ProjectPaymentDetails();
        //    ClsprpMIS_ProjectPaymentsRegistration getObj = new ClsprpMIS_ProjectPaymentsRegistration();
        //    ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXls = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

        //    ModelState.Remove("PG_Amount");
        //    ModelState.Remove("PG_Product_Info");
        //    if (ModelState.IsValid)
        //    {
        //        string userRole = string.Empty;

        //        DateTime dtvalue = new DateTime(0001, 1, 1);

        //        DateTime prmFromDate = smodel.Application_FromDate.HasValue ? smodel.Application_FromDate.Value : dtvalue;
        //        DateTime prmToDate = smodel.Application_ToDate.HasValue ? smodel.Application_ToDate.Value : dtvalue;

        //        String application_SearchTypeFlag = smodel.Application_SearchOptionFlag;    //(1)Registration Payments (2)Late Fee Payments (3)Other Payments
        //        String application_SearchRangeFlag = smodel.Application_SearchRangeFlag;    //(1)From-Date/To-Date  (2)Month/Year

        //        Int32 application_Month = smodel.EventMonth;    //Month
        //        Int32 application_EventYear = smodel.EventYear; //Year

        //        //if (application_SearchTypeFlag == "2")
        //        //{
        //        //    prmFromDate = DateTime.Now;
        //        //    prmToDate = prmFromDate.AddMonths(3);
        //        //    application_SearchRangeFlag = "1";
        //        //}

        //        getObj.prpongoing = RegBussinessLayer.Display_AuthDesk_ProjectRegistrationPaymentsDetail_ByUserID(userRole, prmFromDate, prmToDate, application_SearchTypeFlag, application_SearchRangeFlag, application_Month, application_EventYear).ToList();
        //        ViewBag.data = "true";

        //        foreach (var item in getObj.prpongoing)
        //        {
        //            ClsprpMIS_ProjectPaymentsRegistrationExportToExcel aaXlsInner = new ClsprpMIS_ProjectPaymentsRegistrationExportToExcel();

        //            aaXlsInner.ProjectRegDiaryNumber_Name = item.ProjectRegDiaryNumber_Name;
        //            aaXlsInner.RERAnumberRegistration = item.RERAnumberRegistration;
        //            aaXlsInner.RERAnumberIssueDate = item.RERAnumberIssueDate;
        //            aaXlsInner.RERAnumberRegUptoDate = item.RERAnumberRegUptoDate;
        //            aaXlsInner.ProjectName = item.ProjectName;
        //            aaXlsInner.Project_AddressDistrictName = item.Project_AddressDistrictName;
        //            aaXlsInner.Promoter_Name = item.Promoter_Name;
        //            aaXlsInner.PromoterType = item.PromoterType;
        //            //Fee Table Terms
        //            aaXlsInner.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
        //            aaXlsInner.Registration_Fee = item.Registration_Fee;
        //            aaXlsInner.Other_Fee = item.Other_Fee;
        //            aaXlsInner.Payment_Mode = item.Payment_Mode;
        //            aaXlsInner.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
        //            aaXlsInner.Bank_Name = item.Bank_Name;
        //            aaXlsInner.Branch_Name = item.Branch_Name;
        //            aaXlsInner.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
        //            aaXlsInner.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
        //            // Project PaymentGateway
        //            aaXlsInner.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
        //            aaXlsInner.ProjectPmZoneType = item.ProjectPmZoneType;
        //            aaXlsInner.PG_Transaction_ID = item.PG_Transaction_ID;
        //            aaXlsInner.PG_Date = item.PG_Date;
        //            aaXlsInner.PG_PayU_ID = item.PG_PayU_ID;
        //            aaXlsInner.PG_Amount = item.PG_Amount;
        //            aaXlsInner.PG_Status = item.PG_Status;
        //            aaXlsInner.PG_Product_Info = item.PG_Product_Info;
        //            aaXlsInner.PG_Bank_Name = item.PG_Bank_Name;
        //            aaXlsInner.PG_Payment_Gateway = item.PG_Payment_Gateway;
        //            aaXlsInner.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
        //            aaXlsInner.PG_Payment_Type = item.PG_Payment_Type;
        //            aaXlsInner.PG_Transaction_Fee = item.PG_Transaction_Fee;
        //            aaXlsInner.PG_Discount = item.PG_Discount;
        //            aaXlsInner.PG_Additional_Charges = item.PG_Additional_Charges;
        //            aaXlsInner.PG_Amount_INR = item.PG_Amount_INR;

        //            aaXls.prpongoing.Add(aaXlsInner);
        //        }

        //        getObj.Application_SearchOptionFlag = smodel.Application_SearchOptionFlag;
        //        getObj.Application_SearchRangeFlag = smodel.Application_SearchRangeFlag;
        //        getObj.Application_FromDate = smodel.Application_FromDate;
        //        getObj.Application_ToDate = smodel.Application_ToDate;
        //        getObj.EventMonth = smodel.EventMonth;
        //        getObj.EventYear = smodel.EventYear;

        //        //if (application_SearchTypeFlag == "2")
        //        //{
        //        //    getObj.Application_SearchRangeFlag = application_SearchRangeFlag;
        //        //    getObj.Application_FromDate = prmFromDate;
        //        //    getObj.Application_ToDate = prmToDate;
        //        //}

        //        Session["modelProjectRegistrationPaymentsMIS"] = aaXls.prpongoing;
        //        if (getObj.prpongoing.Count > 0)
        //        {
        //            //  ExportToExcel();
        //        }
        //        else
        //        {
        //            ViewData["data"] = "No data found";
        //        }
        //    }
        //    return View("Display_ProjectPaymentMIS", getObj);
        //}

        //public void ProjectRegistrationFeeExportToExcel()
        //{
        //    GridView gv = new GridView();
        //    gv.DataSource = Session["modelProjectRegistrationPaymentsMIS"];
        //    gv.DataBind();
        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    string strDateFormat = string.Empty;
        //    strDateFormat = string.Format("{0:yyyy-MMM-dd-hh-mm-ss}", DateTime.Now);
        //    Response.AddHeader("content-disposition", "attachment; filename=PaymentsDetails_" + strDateFormat + ".xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    gv.RenderControl(htw);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
        #endregion


    }
}

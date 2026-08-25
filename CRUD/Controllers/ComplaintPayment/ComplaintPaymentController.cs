using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using CRUD.Models.ClassComplaintPayment;
using CRUD.Models.Complaint;
using CRUD.Models.Master;
using CRUD.Models.PromoterProject;
using CRUD.Models.Promoter;
using CRUD.Models.ComplaintExecution;
using System.Net.Cache;
using static CRUD.Controllers.classAgentPayment.AgentPaymentController;
using CRUD.Models.ComplaintPayment;

namespace CRUD.Controllers.ComplaintPayment
{
    [Authorize]
    [Authorize(Roles = "Complainant")]
    public class ComplaintPaymentController : Controller
    {
        private void WritePaymentLog(string formType, string orderId, string amount, string status, string firstName, string email, string bankRefNum, string payUId, bool isValidPaymentResponse)
        {
            try
            {
                string logPath = Server.MapPath("~/logs");
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                string filePath = Path.Combine(logPath, "payment.txt");
                string logData = $"FormType={formType ?? "NA"} | " +
                                 $"TxnID={orderId ?? "NA"} | " +
                                 $"Amount={amount ?? "NA"} | " +
                                 $"Status={status ?? "NA"} | " +
                                 $"Name={firstName ?? "NA"} | " +
                                 $"Email={email ?? "NA"} | " +
                                 $"BankRef={bankRefNum ?? "NA"} | " +
                                 $"PayUId={payUId ?? "NA"} | " +
                                 $"IsValidResponse={(isValidPaymentResponse ? "1" : "0")}";

                System.IO.File.AppendAllText(filePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {logData}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                var strex = ex.ToString();
            }
        }

        [HttpGet]
        public ActionResult RequestPaymentFormM()
        {

            ClsPrp_ComplaintFormM_PaymentIntegration objFormMpayment = new ClsPrp_ComplaintFormM_PaymentIntegration();
            ClsMethod_ComplaintFormM_PaymentIntegration objPayment = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsPrp_ComplaintFormM_Registration objFormM = new ClsPrp_ComplaintFormM_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();


            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            objFormM.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
            if (objFormM.Complainant_UserProfile.Count >= 1)
            {
                foreach (var item in objFormM.Complainant_UserProfile)
                {
                    objFormM.Profile_ID = item.ComplaintProfile_ID;
                    objFormM.User_ID = item.UserID;

                    objFormM.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                    objFormM.Complainant_EmailAddress = item.EmailAddress;
                    objFormM.Complainant_MobileNumber = item.MobileNumber;
                    objFormM.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                    objFormM.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                    objFormM.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                    objFormM.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                    objFormM.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                    objFormM.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                    objFormM.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                    objFormM.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                    objFormM.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                    objFormM.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                    objFormM.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                    objFormM.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                }
            }

            Int64 ComplainantExecutionForm_id = 0;
            if (Session["execution_IndexId"] != null)
            {
                if (Session["execution_IndexId"].ToString() != "0")
                {
                    ComplainantExecutionForm_id = Convert.ToInt64(Session["execution_IndexId"]);
                }
            }

            objFormM.ComplaintFormMstepI = objFormAppM.Display_ComplaintFormM_Registration_StepI(ComplainantExecutionForm_id);
            if (objFormM.ComplaintFormMstepI.Count >= 1)
            {
                foreach (var item in objFormM.ComplaintFormMstepI)
                {
                    objFormM.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                    objFormM.ComplaintFormM_ID = item.ComplaintFormM_ID;
                    objFormM.ComplaintFormM_Code = item.ComplaintFormM_Code;

                    objFormM.Profile_ID = item.Profile_ID;
                    objFormM.User_ID = item.User_ID;
                    objFormM.ComplaintType_MN = item.ComplaintType_MN;

                    objFormM.IsComplaintComplete = item.IsComplaintComplete;
                    objFormM.IsPaymentComplete = item.IsPaymentComplete;
                    objFormM.IsDocumentsComplete = item.IsDocumentsComplete;

                    objFormM.IsVerificationComplete = item.IsVerificationComplete;
                    objFormM.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objFormM.Complainant_Name = item.Complainant_Name;
                    objFormM.Complainant_EmailAddress = item.Complainant_EmailAddress;
                    objFormM.Complainant_MobileNumber = item.Complainant_MobileNumber;
                    objFormM.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                    objFormM.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                    objFormM.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                    objFormM.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                    objFormM.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                    objFormM.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                    objFormM.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                    objFormM.IsActive = item.IsActive;
                    objFormM.IsDraft = item.IsDraft;
                    objFormM.IsLock = item.IsLock;
                    objFormM.IsPublicView = item.IsPublicView;
                    objFormM.CreatedBy = item.CreatedBy;
                    objFormM.CreatedOn = item.CreatedOn;
                    objFormM.ModifyBy = item.ModifyBy;
                    objFormM.ModifyOn = item.ModifyOn;
                }
            }

            objFormMpayment.ComplaintFormMstepII = objPayment.Display_ComplaintFormM_Payment(ComplainantExecutionForm_id);
            if (objFormMpayment.ComplaintFormMstepII.Count >= 1)
            {
                foreach (var item in objFormMpayment.ComplaintFormMstepII)
                {
                    objFormMpayment.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    objFormMpayment.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    objFormMpayment.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    objFormMpayment.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    objFormMpayment.Profile_ID = item.Profile_ID;
                    objFormMpayment.User_ID = item.User_ID;

                    objFormMpayment.ComplaintType_MN = item.ComplaintType_MN;
                    objFormMpayment.User_Name = item.User_Name;
                    objFormMpayment.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    objFormMpayment.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    objFormMpayment.PaymentSuccessDate = item.PaymentSuccessDate;
                    objFormMpayment.FailureSuccessSummary = item.FailureSuccessSummary;

                    objFormMpayment.PG_Transaction_ID = item.PG_Transaction_ID;
                    objFormMpayment.PG_Date = item.PG_Date;
                    objFormMpayment.PG_PayU_ID = item.PG_PayU_ID;
                    objFormMpayment.PG_Amount = item.PG_Amount; //Amount INR
                    objFormMpayment.PG_Status = item.PG_Status;
                    objFormMpayment.PG_Product_Info = item.PG_Product_Info; //Product Info
                    objFormMpayment.PG_Customer_Name = item.PG_Customer_Name; //Name
                    objFormMpayment.PG_Last_Name = item.PG_Last_Name;
                    objFormMpayment.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    objFormMpayment.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    objFormMpayment.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    objFormMpayment.PG_City = item.PG_City;
                    objFormMpayment.PG_Merchant_Name = item.PG_Merchant_Name;
                    objFormMpayment.PG_Bank_Name = item.PG_Bank_Name;
                    objFormMpayment.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    objFormMpayment.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    objFormMpayment.PG_International_Domestic = item.PG_International_Domestic;
                    objFormMpayment.PG_Payment_Type = item.PG_Payment_Type;
                    objFormMpayment.PG_Error_Code = item.PG_Error_Code;
                    objFormMpayment.PG_Error_Message = item.PG_Error_Message;
                    objFormMpayment.PG_Name_on_Card = item.PG_Name_on_Card;
                    objFormMpayment.PG_Card_Number = item.PG_Card_Number;
                    objFormMpayment.PG_Address_Line1 = item.PG_Address_Line1;
                    objFormMpayment.PG_Address_Line2 = item.PG_Address_Line2;
                    objFormMpayment.PG_State = item.PG_State;
                    objFormMpayment.PG_Country = item.PG_Country;
                    objFormMpayment.PG_ZipCode = item.PG_ZipCode;
                    objFormMpayment.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    objFormMpayment.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    objFormMpayment.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    objFormMpayment.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    objFormMpayment.PG_Shipping_City = item.PG_Shipping_City;
                    objFormMpayment.PG_Shipping_State = item.PG_Shipping_State;
                    objFormMpayment.PG_Shipping_Country = item.PG_Shipping_Country;
                    objFormMpayment.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    objFormMpayment.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    objFormMpayment.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    objFormMpayment.PG_Discount = item.PG_Discount;
                    objFormMpayment.PG_Additional_Charges = item.PG_Additional_Charges;
                    objFormMpayment.PG_Amount_INR = item.PG_Amount_INR;
                    objFormMpayment.PG_UDF_1 = item.PG_UDF_1;
                    objFormMpayment.PG_UDF_2 = item.PG_UDF_2;
                    objFormMpayment.PG_UDF_3 = item.PG_UDF_3;
                    objFormMpayment.PG_UDF_4 = item.PG_UDF_4;
                    objFormMpayment.PG_UDF_5 = item.PG_UDF_5;

                    objFormMpayment.PG_Device_Info = item.PG_Device_Info;
                    objFormMpayment.PG_HashKey = item.PG_HashKey;
                    objFormMpayment.PG_ServiceProvider = item.PG_ServiceProvider;
                    objFormMpayment.Remarks_IfAny = item.Remarks_IfAny;

                    objFormMpayment.A_column = item.A_column;
                    objFormMpayment.B_column = item.B_column;
                    objFormMpayment.C_column = item.C_column;

                    objFormMpayment.IsActive = item.IsActive;
                    objFormMpayment.IsDraft = item.IsDraft;
                    objFormMpayment.IsLock = item.IsLock;
                    objFormMpayment.IsPublicView = item.IsPublicView;

                    objFormMpayment.CreatedBy = item.CreatedBy;
                    objFormMpayment.CreatedOn = item.CreatedOn;
                    objFormMpayment.ModifyBy = item.ModifyBy;
                    objFormMpayment.ModifyOn = item.ModifyOn;
                }

                if (objFormMpayment.IsPaymentSuccessComplete == 0 || objFormMpayment.IsPaymentSuccessComplete == 2)
                {
                    // Payment - Pending OR Failure
                    TempData["submitvalueFormMStep2"] = "Make Payment"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueFormMStep2"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                //No records found - table Payment Form M 
                objFormMpayment.PaymentComplaint_IndexID = 0;
                objFormMpayment.PaymentComplaint_ID = 0;
                objFormMpayment.PaymentComplaint_RelatedComplainant_ID = objFormM.ComplaintFormM_ID;
                objFormMpayment.PaymentComplaint_RelatedComplainant_Code = objFormM.ComplaintFormM_Code;
                objFormMpayment.Profile_ID = objFormM.Profile_ID;
                objFormMpayment.ComplaintType_MN = objFormM.ComplaintType_MN; // "FormTypeM";

                //objFormMpayment.User_ID = objFormM.User_ID;
                //objFormMpayment.User_Name = item.User_Name;

                objFormMpayment.PG_Product_Info = "Complaint Fee (Form-M)";
                objFormMpayment.PG_Transaction_Fee = 0;
                objFormMpayment.PG_Discount = 0;
                objFormMpayment.PG_Additional_Charges = 0;
                objFormMpayment.PG_Amount_INR = 1000;
                objFormMpayment.PG_Amount = 1000;
                objFormMpayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                objFormMpayment.PG_Shipping_Firstname = objFormM.Complainant_Name;
                objFormMpayment.PG_Shipping_Lastname = string.Empty;
                objFormMpayment.PG_Shipping_Address1 = objFormM.ServiceNoticesComplainant_AddressLine1;
                objFormMpayment.PG_Shipping_Address2 = objFormM.ServiceNoticesComplainant_AddressLine2;
                objFormMpayment.PG_Shipping_City = objdis.District_Name(objFormM.ServiceNoticesComplainant_AddressDistrictCode);
                objFormMpayment.PG_Shipping_State = objdis.State_Name(objFormM.ServiceNoticesComplainant_AddressStateCode);
                objFormMpayment.PG_Shipping_Country = "India";
                objFormMpayment.PG_Shipping_Zipcode = objFormM.ServiceNoticesComplainant_AddressPIN;
                objFormMpayment.PG_Shipping_Phone = Convert.ToString(objFormM.Complainant_MobileNumber);

                objFormMpayment.PG_Customer_Name = objFormM.Complainant_Name; //Name
                objFormMpayment.PG_Last_Name = string.Empty;
                objFormMpayment.PG_Customer_Email = objFormM.Complainant_EmailAddress; //Email ID
                objFormMpayment.PG_Customer_Phone = Convert.ToString(objFormM.Complainant_MobileNumber); //Phone/Mobile 

                objFormMpayment.PG_Address_Line1 = objFormM.ServiceNoticesComplainant_AddressLine1;
                objFormMpayment.PG_Address_Line2 = objFormM.ServiceNoticesComplainant_AddressLine2;
                objFormMpayment.PG_City = objdis.District_Name(objFormM.ServiceNoticesComplainant_AddressDistrictCode);
                objFormMpayment.PG_State = objdis.State_Name(objFormM.ServiceNoticesComplainant_AddressStateCode);
                objFormMpayment.PG_Country = "India";
                objFormMpayment.PG_ZipCode = objFormM.ServiceNoticesComplainant_AddressPIN;

                TempData["submitvalueFormMStep2"] = "Make Payment"; TempData.Keep();
            }


            return View(objFormMpayment);
        }

        #region Remote Post and Txn Generation
        public class RemotePost
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();

            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";

            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }

            public void Post()
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Write("<html><head>");
                System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                }
                System.Web.HttpContext.Current.Response.Write("</form>");
                System.Web.HttpContext.Current.Response.Write("</body></html>");
                System.Web.HttpContext.Current.Response.End();
            }
        }

        //Hash generation Algorithm
        public string Generatehash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }


        //////////json product info description
        ////////public string GetJson(string DiaryNo, DateTime DiaryDate, string PayPurpose, string Depositor, string PayFor)
        ////////{

        ////////    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        ////////    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        ////////    Dictionary<string, object> row = null;

        ////////    DataTable dtEmployee = new DataTable();

        ////////    dtEmployee.Columns.Add("field", typeof(string));            
        ////////    dtEmployee.Columns.Add("value", typeof(string));
        ////////    //dtEmployee.Columns.Add("description", typeof(string));
        ////////    //dtEmployee.Columns.Add("commission", typeof(string));

        ////////    dtEmployee.Rows.Add("Diary Number", DiaryNo);
        ////////    dtEmployee.Rows.Add("Diary Date", DiaryDate);
        ////////    dtEmployee.Rows.Add("Payment Purpose", PayPurpose);
        ////////    dtEmployee.Rows.Add("Depositor", Depositor);
        ////////    dtEmployee.Rows.Add("Payment For", PayFor);

        ////////    foreach (DataRow dr in dtEmployee.Rows)
        ////////    {
        ////////        row = new Dictionary<string, object>();
        ////////        foreach (DataColumn col in dtEmployee.Columns)
        ////////        {
        ////////            row.Add(col.ColumnName, dr[col]);
        ////////        }
        ////////        rows.Add(row);
        ////////    }
        ////////    return serializer.Serialize(rows);
        ////////}


        //random transition id generation
        public string Generatetxnid()
        {
            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }
        #endregion

        #region ePaymeny Input Form-M
        [HttpPost]
        public void RequestPaymentFormM(ClsPrp_ComplaintFormM_PaymentIntegration dm)
        {
            string firstName = dm.PG_Customer_Name;
            string lastname = dm.PG_Last_Name;
            string amount = Convert.ToString(dm.PG_Amount);
            string productInfo = dm.PG_Product_Info;
            string email = dm.PG_Customer_Email;
            string phone = dm.PG_Customer_Phone;
            string surl = string.Empty;
            string furl = string.Empty;
            string status = string.Empty;

            string city = dm.PG_City;
            string address1 = dm.PG_Address_Line1;
            string address2 = dm.PG_Address_Line2;
            string state = dm.PG_State;
            string country = dm.PG_Country;
            string zipcode = dm.PG_ZipCode;

            string shipping_firstname = dm.PG_Shipping_Firstname;
            string shipping_lastname = dm.PG_Shipping_Lastname;
            string shipping_address1 = dm.PG_Shipping_Address1;
            string shipping_address2 = dm.PG_Shipping_Address2;
            string shipping_city = dm.PG_Shipping_City;
            string shipping_state = dm.PG_Shipping_State;
            string shipping_country = dm.PG_Shipping_Country;
            string shipping_zipcode = dm.PG_Shipping_Zipcode;
            string shipping_phone = dm.PG_Shipping_Phone;

            string txnid = Generatetxnid();

            string udf2 = dm.PG_Product_Info;
            string udf3 = Convert.ToString(dm.PaymentComplaint_RelatedComplainant_ID);
            string udf4 = string.Empty;
            string udf5 = string.Empty;

            #region Save & Update - Table Payment
            ClsMethod_ComplaintFormM_PaymentIntegration objFormAppM = new ClsMethod_ComplaintFormM_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            Int64 p_PaymentRefNumber = 0;

            if (TempData["submitvalueFormMStep2"].ToString() == "Make Payment")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        p_PaymentRefNumber = objFormAppM.Add_ComplaintFormM_Payment(dm, UID, userName, txnid, "0");
                        if (p_PaymentRefNumber > 0)
                        {
                            dm.PG_UDF_1 = Convert.ToString(p_PaymentRefNumber);
                            ModelState.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                }
            }
            else
            {
                try
                {
                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentFormM";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationM";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                    }

                    RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    RedirectToAction("RegComplaintFormM", "Complaint");
                }
            }
            #endregion


            string udf1 = Convert.ToString(p_PaymentRefNumber);



            /**************************************************************/
            RemotePost myremotepost = new RemotePost();

            //////////////string key = "t5aUkm"; //98d8Yh
            //////////////string salt = "ZVhH63Gg"; //6thltjA2
            //////////////"https://test.payu.in/_payment";

            string key = ConfigurationManager.AppSettings["payuMerchantKey"];
            string salt = ConfigurationManager.AppSettings["payuSalt"];
            string baseURL = ConfigurationManager.AppSettings["payuBaseURL"];
            string DomainNameURL = ConfigurationManager.AppSettings["payuDomainNameURL"];

            //posting all the parameters required for integration.
            myremotepost.Url = baseURL;
            myremotepost.Add("key", key);
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);
            myremotepost.Add("productinfo", productInfo);
            //  HttpUtility.HtmlEncode("{\"paymentIdentifiers\":" + GetJson(mDiaryNo, mDiaryDate, mPayPurpose, mDepositor, mPayFor).ToString() + "}"));//"123");// 
            myremotepost.Add("firstname", firstName);
            myremotepost.Add("lastname", lastname);
            myremotepost.Add("phone", phone);
            myremotepost.Add("email", email);
            myremotepost.Add("status", status);

            myremotepost.Add("udf1", udf1);
            myremotepost.Add("udf2", udf2);
            myremotepost.Add("udf3", udf3);
            myremotepost.Add("udf4", udf4);
            myremotepost.Add("udf5", udf5);

            myremotepost.Add("city", city);
            myremotepost.Add("address1", address1);
            myremotepost.Add("address2", address2);
            myremotepost.Add("state", state);
            myremotepost.Add("country", country);
            myremotepost.Add("zipcode", zipcode);

            myremotepost.Add("shipping_firstname", shipping_firstname);
            myremotepost.Add("shipping_lastname", shipping_lastname);
            myremotepost.Add("shipping_address1", shipping_address1);
            myremotepost.Add("shipping_address2", shipping_address2);
            myremotepost.Add("shipping_city", shipping_city);
            myremotepost.Add("shipping_state", shipping_state);
            myremotepost.Add("shipping_country", shipping_country);
            myremotepost.Add("shipping_zipcode", shipping_zipcode);
            myremotepost.Add("shipping_phone", shipping_phone);

            myremotepost.Add("surl", DomainNameURL + "/complaintpayment/successpaymentm");
            myremotepost.Add("furl", DomainNameURL + "/complaintpayment/failurepaymentm/" + p_PaymentRefNumber);
            myremotepost.Add("service_provider", "payu"); //payu_paisa

            string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "||||||" + salt;
            //string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "|" + udf6 + "|" + udf7 + "|" + udf8 + "|" + udf9 + "|" + udf10 + "|" + salt;
            //string hashString = "3Q5c3q|2590640|3053.00|OnlineBooking|vimallad|ladvimal@gmail.com|||||||||||mE2RxRwx";
            string hash = Generatehash512(hashString);

            myremotepost.Add("hash", hash);

            if (p_PaymentRefNumber > 0)
            {
                myremotepost.Post();
            }
        }

        public string Get_ComplaintFormM_FlagStep()
        {
            string retSTR = string.Empty;
            Int64 ComplainantFormM_id = 0;
            if (Session["ComplaintFormM_ID"] != null)
            {
                if (Session["ComplaintFormM_ID"].ToString() != "0")
                {
                    ComplainantFormM_id = Convert.ToInt64(Session["ComplaintFormM_ID"]);
                }
            }

            ClsPrp_ComplaintFormM_FlagStep objflagstep = new ClsPrp_ComplaintFormM_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormM_Flag_RegStep(ComplainantFormM_id);
            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ComplaintFormM_IndexID = item.ComplaintFormM_IndexID;
                    objflagstep.ComplaintFormM_ID = item.ComplaintFormM_ID;
                    objflagstep.ComplaintFormM_Code = item.ComplaintFormM_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }
        #endregion

        #region ePayment Output Form-M

        [AllowAnonymous]
        public ActionResult successpaymentm(FormCollection form = null)
        {
            string salt = ConfigurationManager.AppSettings["payuSalt"];
            bool isValidPaymentResponse = false;
            int existingPaymentStatus = -1;

            string order_id = string.Empty;
            string v_firstName = string.Empty;
            string v_amount = string.Empty;
            string v_productInfo = string.Empty;
            string v_email = string.Empty;
            string v_status = string.Empty;

            string v_udf1 = string.Empty;
            string v_udf2 = string.Empty;
            string v_udf3 = string.Empty;
            string v_udf4 = string.Empty;
            string v_udf5 = string.Empty;

            string v_bank_ref_num = string.Empty;
            string v_PG_TYPE = string.Empty;
            string v_mihpayid = string.Empty;
            string v_mode = string.Empty;
            string v_bankcode = string.Empty;

            try
            {
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;

                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
                if (form != null && !String.IsNullOrEmpty(form["status"]) && form["status"].ToString().Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = salt + "|" + form["status"].ToString();
                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");
                    }
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != Request.Form["hash"])
                    {
                        //Value didn't match that means some paramter value change between transaction
                        ViewData["PaymentMessage"] = "Payment Fails! Some paramter value change between transaction, Try Again.";
                    }
                    else
                    {
                        //if hash value match for before transaction data and after transaction data
                        //that means success full transaction  , see more in response
                        order_id = Request.Form["txnid"];
                        v_firstName = Request.Form["firstName"];
                        v_amount = Request.Form["amount"];
                        v_productInfo = Request.Form["productInfo"];
                        v_email = Request.Form["email"];
                        v_status = Request.Form["status"];

                        v_udf1 = Request.Form["udf1"];
                        v_udf2 = Request.Form["udf2"];
                        v_udf3 = Request.Form["udf3"];
                        v_udf4 = Request.Form["udf4"];
                        v_udf5 = Request.Form["udf5"];

                        v_bank_ref_num = Request.Form["bank_ref_num"];
                        v_PG_TYPE = Request.Form["PG_TYPE"];
                        v_mihpayid = Request.Form["mihpayid"];
                        v_mode = Request.Form["mode"];
                        v_bankcode = Request.Form["bankcode"];
                        isValidPaymentResponse = true;
                    }
                }
                else
                {
                    ViewData["PaymentMessage"] = "Payment Fails! Try Again.";
                }
            }
            catch (Exception ex)
            {
                var strex = ex.ToString();
                ViewData["PaymentMessage"] = "Payment Fails! Try Again.";
            }

            ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormM_PaymentIntegration aa = new ClsPrp_ComplaintFormM_PaymentIntegration();

            Int64 PRN_udf1 = String.IsNullOrEmpty(v_udf1) ? 0 : Convert.ToInt64(v_udf1);
            aa.ComplaintFormMstepII = sdb.Display_ComplaintFormM_PaymentByPRNumber(PRN_udf1);

            if (aa.ComplaintFormMstepII.Count >= 1)
            {
                foreach (var item in aa.ComplaintFormMstepII)
                {
                    aa.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    aa.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    aa.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    aa.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;

                    aa.ComplaintType_MN = item.ComplaintType_MN;
                    aa.User_Name = item.User_Name;
                    aa.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    aa.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    aa.PaymentSuccessDate = item.PaymentSuccessDate;
                    aa.FailureSuccessSummary = item.FailureSuccessSummary;

                    aa.PG_Transaction_ID = item.PG_Transaction_ID;
                    aa.PG_Date = item.PG_Date;
                    aa.PG_PayU_ID = item.PG_PayU_ID;
                    aa.PG_Amount = item.PG_Amount; //Amount INR
                    aa.PG_Status = item.PG_Status;
                    aa.PG_Product_Info = item.PG_Product_Info; //Product Info
                    aa.PG_Customer_Name = item.PG_Customer_Name; //Name
                    aa.PG_Last_Name = item.PG_Last_Name;
                    aa.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    aa.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    aa.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    aa.PG_City = item.PG_City;
                    aa.PG_Merchant_Name = item.PG_Merchant_Name;
                    aa.PG_Bank_Name = item.PG_Bank_Name;
                    aa.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aa.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aa.PG_International_Domestic = item.PG_International_Domestic;
                    aa.PG_Payment_Type = item.PG_Payment_Type;
                    aa.PG_Error_Code = item.PG_Error_Code;
                    aa.PG_Error_Message = item.PG_Error_Message;
                    aa.PG_Name_on_Card = item.PG_Name_on_Card;
                    aa.PG_Card_Number = item.PG_Card_Number;
                    aa.PG_Address_Line1 = item.PG_Address_Line1;
                    aa.PG_Address_Line2 = item.PG_Address_Line2;
                    aa.PG_State = item.PG_State;
                    aa.PG_Country = item.PG_Country;
                    aa.PG_ZipCode = item.PG_ZipCode;
                    aa.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    aa.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    aa.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    aa.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    aa.PG_Shipping_City = item.PG_Shipping_City;
                    aa.PG_Shipping_State = item.PG_Shipping_State;
                    aa.PG_Shipping_Country = item.PG_Shipping_Country;
                    aa.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    aa.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    aa.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aa.PG_Discount = item.PG_Discount;
                    aa.PG_Additional_Charges = item.PG_Additional_Charges;
                    aa.PG_Amount_INR = item.PG_Amount_INR;
                    aa.PG_UDF_1 = item.PG_UDF_1;
                    aa.PG_UDF_2 = item.PG_UDF_2;
                    aa.PG_UDF_3 = item.PG_UDF_3;
                    aa.PG_UDF_4 = item.PG_UDF_4;
                    aa.PG_UDF_5 = item.PG_UDF_5;

                    aa.PG_Device_Info = item.PG_Device_Info;
                    aa.PG_HashKey = item.PG_HashKey;
                    aa.PG_ServiceProvider = item.PG_ServiceProvider;
                    aa.Remarks_IfAny = item.Remarks_IfAny;

                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }

                if (aa.IsPaymentSuccessComplete == 0 || aa.IsPaymentSuccessComplete == 2)
                {
                    // Payment Details Save (Case when Flag as Pending OR Failure)
                    TempData["submitvalueFormMStep2surl"] = "Proceed"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueFormMStep2surl"] = "Next"; TempData.Keep();
                }
                existingPaymentStatus = aa.IsPaymentSuccessComplete;
            }
            try
            {
                if (isValidPaymentResponse)
                {
                    aa.PG_Transaction_ID = order_id;
                    aa.PG_Date = DateTime.Now;
                    aa.PG_PayU_ID = Convert.ToInt64(v_mihpayid);
                    aa.PG_Amount = Convert.ToDecimal(v_amount);
                    aa.PG_Status = v_status;
                    aa.Complaint_BriefSummary = v_status;
                    aa.PG_Product_Info = v_productInfo;
                    aa.PG_Customer_Name = v_firstName;
                    aa.PG_Customer_Email = v_email;

                    aa.PG_UDF_1 = v_udf1;
                    aa.PG_UDF_2 = v_udf2;
                    aa.PG_UDF_3 = v_udf3;
                    aa.PG_UDF_4 = v_udf4;
                    aa.PG_UDF_5 = v_udf5;

                    aa.PG_Bank_Reference_No = v_bank_ref_num;
                    aa.PG_Payment_Type = v_PG_TYPE;
                    aa.PG_Bank_Name = v_bankcode;
                    aa.PG_Payment_Gateway = v_mode;

                    aa.IsPaymentSuccessComplete = 1;
                    aa.PaymentSuccessDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                return RedirectToAction("RegComplaintFormM", "Complaint");
            }

            if (isValidPaymentResponse && existingPaymentStatus != 1)
            {
                try
                {
                    string updateUID = String.IsNullOrEmpty(aa.User_ID) ? User.Identity.GetUserId() : aa.User_ID;
                    string updateUserName = String.IsNullOrEmpty(aa.User_Name) ? User.Identity.Name : aa.User_Name;
                    sdb.Update_ComplaintFormM_Payment(aa, updateUID, updateUserName, 1);
                    TempData["submitvalueFormMStep2surl"] = "Next"; TempData.Keep();
                }
                catch
                {
                    //ViewData["PaymentMessage"] = "Payment received but details update failed. Please contact support.";
                    ViewData["PaymentMessage"] = "Payment received.";
                }
            }

            WritePaymentLog("FormM", order_id, v_amount, v_status, v_firstName, v_email, v_bank_ref_num, v_mihpayid, isValidPaymentResponse);
            return View(aa);
        }

        [HttpPost]
        public ActionResult successpaymentmform(ClsPrp_ComplaintFormM_PaymentIntegration dm)
        {

            ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormM_PaymentIntegration aa = new ClsPrp_ComplaintFormM_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueFormMStep2surl"].ToString() == "Proceed")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)

                    if (ModelState.IsValid)
                    {
                        bool allowUpdateForDuplicateCheck = true;
                        long prnNumber = 0;
                        if (!String.IsNullOrEmpty(dm.PG_UDF_1))
                        {
                            try
                            {
                                prnNumber = Convert.ToInt64(dm.PG_UDF_1);
                            }
                            catch
                            {
                                prnNumber = 0;
                            }
                        }
                        else
                        {
                            prnNumber = dm.PaymentComplaint_ID;
                        }

                        if (prnNumber > 0)
                        {
                            var existingPaymentRecords = sdb.Display_ComplaintFormM_PaymentByPRNumber(prnNumber);
                            if (existingPaymentRecords != null && existingPaymentRecords.Count > 0)
                            {
                                var latestPaymentRecord = existingPaymentRecords[0];
                                if (latestPaymentRecord.IsPaymentSuccessComplete == 1)
                                {
                                    // Duplicate callback/request: already marked successful, skip update.
                                    allowUpdateForDuplicateCheck = false;
                                    TempData["message"] = "Payment already marked successful.";
                                    errorstate = "START";
                                }
                            }
                        }

                        if (allowUpdateForDuplicateCheck && sdb.Update_ComplaintFormM_Payment(dm, UID, userName, IsPaymentSuccessCompleteFlag))
                        {
                            TempData["message"] = "Details Updated Successfully";
                            errorstate = "START";
                        }
                        ModelState.Clear();
                    }
                    if (errorstate == "START")
                    {
                        string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                        string varFlagStep_ControllerLinkName = string.Empty;
                        string varFlagStep_ActionLinkName = string.Empty;

                        switch (varFlagStep_LinkName)
                        {
                            case "Step1M":
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintFormM";
                                break;
                            case "Step2M":
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintEncldocM";
                                break;
                            case "Step3M":
                                varFlagStep_ControllerLinkName = "ComplaintPayment";
                                varFlagStep_ActionLinkName = "RequestPaymentFormM";
                                break;
                            case "Step4M":
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintVerificationM";
                                break;
                            default:
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintFormM";
                                break;
                        }
                        return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                    }
                    else
                    {
                        return RedirectToAction("RegComplaintFormM", "Complaint");
                    }
                }
                else
                {
                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentFormM";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationM";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormM";
                            break;
                    }
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
            }

            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                //dm.PG_Last_Name = strex;
                return View("successpaymentm", dm);
            }
            #endregion
        }

        [AllowAnonymous]
        public ActionResult failurepaymentm(int? id)
        {
            ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormM_PaymentIntegration aa = new ClsPrp_ComplaintFormM_PaymentIntegration();

            Int64 PRN_udf1 = id == null ? 0 : Convert.ToInt64(id);
            aa.ComplaintFormMstepII = sdb.Display_ComplaintFormM_PaymentByPRNumber(PRN_udf1);

            if (aa.ComplaintFormMstepII.Count >= 1)
            {
                foreach (var item in aa.ComplaintFormMstepII)
                {
                    aa.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    aa.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    aa.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    aa.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;

                    aa.ComplaintType_MN = item.ComplaintType_MN;
                    aa.User_Name = item.User_Name;
                    aa.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    aa.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    aa.PaymentSuccessDate = item.PaymentSuccessDate;
                    aa.FailureSuccessSummary = item.FailureSuccessSummary;

                    aa.PG_Transaction_ID = item.PG_Transaction_ID;
                    aa.PG_Date = item.PG_Date;
                    aa.PG_PayU_ID = item.PG_PayU_ID;
                    aa.PG_Amount = item.PG_Amount; //Amount INR
                    aa.PG_Status = item.PG_Status;
                    aa.PG_Product_Info = item.PG_Product_Info; //Product Info
                    aa.PG_Customer_Name = item.PG_Customer_Name; //Name
                    aa.PG_Last_Name = item.PG_Last_Name;
                    aa.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    aa.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    aa.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    aa.PG_City = item.PG_City;
                    aa.PG_Merchant_Name = item.PG_Merchant_Name;
                    aa.PG_Bank_Name = item.PG_Bank_Name;
                    aa.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aa.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aa.PG_International_Domestic = item.PG_International_Domestic;
                    aa.PG_Payment_Type = item.PG_Payment_Type;
                    aa.PG_Error_Code = item.PG_Error_Code;
                    aa.PG_Error_Message = item.PG_Error_Message;
                    aa.PG_Name_on_Card = item.PG_Name_on_Card;
                    aa.PG_Card_Number = item.PG_Card_Number;
                    aa.PG_Address_Line1 = item.PG_Address_Line1;
                    aa.PG_Address_Line2 = item.PG_Address_Line2;
                    aa.PG_State = item.PG_State;
                    aa.PG_Country = item.PG_Country;
                    aa.PG_ZipCode = item.PG_ZipCode;
                    aa.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    aa.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    aa.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    aa.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    aa.PG_Shipping_City = item.PG_Shipping_City;
                    aa.PG_Shipping_State = item.PG_Shipping_State;
                    aa.PG_Shipping_Country = item.PG_Shipping_Country;
                    aa.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    aa.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    aa.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aa.PG_Discount = item.PG_Discount;
                    aa.PG_Additional_Charges = item.PG_Additional_Charges;
                    aa.PG_Amount_INR = item.PG_Amount_INR;
                    aa.PG_UDF_1 = item.PG_UDF_1;
                    aa.PG_UDF_2 = item.PG_UDF_2;
                    aa.PG_UDF_3 = item.PG_UDF_3;
                    aa.PG_UDF_4 = item.PG_UDF_4;
                    aa.PG_UDF_5 = item.PG_UDF_5;

                    aa.PG_Device_Info = item.PG_Device_Info;
                    aa.PG_HashKey = item.PG_HashKey;
                    aa.PG_ServiceProvider = item.PG_ServiceProvider;
                    aa.Remarks_IfAny = item.Remarks_IfAny;

                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            return View(aa);
        }

        #endregion












        #region FORM N      


        [HttpGet]
        public ActionResult RequestPaymentN()
        {

            ClsPrp_ComplaintFormN_PaymentIntegration objFormMpayment = new ClsPrp_ComplaintFormN_PaymentIntegration();
            ClsMethod_ComplaintFormN_PaymentIntegration objPayment = new ClsMethod_ComplaintFormN_PaymentIntegration();
            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsPrp_ComplaintFormN_Registration objFormM = new ClsPrp_ComplaintFormN_Registration();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();
            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();


            Int64 ComplainantProfile_id = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplainantProfile_id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            objFormM.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplainantProfile_id);
            if (objFormM.Complainant_UserProfile.Count >= 1)
            {
                foreach (var item in objFormM.Complainant_UserProfile)
                {
                    objFormM.Profile_ID = item.ComplaintProfile_ID;
                    objFormM.User_ID = item.UserID;

                    objFormM.Complainant_Name = item.Applicant_FirstName + " " + item.Applicant_LastName;
                    objFormM.Complainant_EmailAddress = item.EmailAddress;
                    objFormM.Complainant_MobileNumber = item.MobileNumber;
                    objFormM.Complainant_LandlineFaxNumber = item.PhoneNumber_Number;

                    objFormM.OfficeResComplainant_AddressLine1 = item.Residencial_Official_AddressLine1;
                    objFormM.OfficeResComplainant_AddressLine2 = item.Residencial_Official_AddressLine2;
                    objFormM.OfficeResComplainant_AddressStateCode = item.Residencial_Official_AddressStateCode;
                    objFormM.OfficeResComplainant_AddressDistrictCode = item.Residencial_Official_AddressDistrictCode;
                    objFormM.OfficeResComplainant_AddressPIN = item.Residencial_Official_AddressPIN;

                    objFormM.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                    objFormM.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                    objFormM.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                    objFormM.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                    objFormM.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                    objFormM.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                }
            }

            Int64 ComplainantFormN_id = 0;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            objFormM.ComplaintFormNstepI = objFormAppM.Display_ComplaintFormN_Registration_StepI(ComplainantFormN_id);
            if (objFormM.ComplaintFormNstepI.Count >= 1)
            {
                foreach (var item in objFormM.ComplaintFormNstepI)
                {
                    objFormM.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                    objFormM.ComplaintFormN_ID = item.ComplaintFormN_ID;
                    objFormM.ComplaintFormN_Code = item.ComplaintFormN_Code;

                    objFormM.Profile_ID = item.Profile_ID;
                    objFormM.User_ID = item.User_ID;
                    objFormM.ComplaintType_MN = item.ComplaintType_MN;

                    objFormM.IsComplaintComplete = item.IsComplaintComplete;
                    objFormM.IsPaymentComplete = item.IsPaymentComplete;
                    objFormM.IsDocumentsComplete = item.IsDocumentsComplete;

                    objFormM.IsVerificationComplete = item.IsVerificationComplete;
                    objFormM.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objFormM.Complainant_Name = item.Complainant_Name;
                    objFormM.Complainant_EmailAddress = item.Complainant_EmailAddress;
                    objFormM.Complainant_MobileNumber = item.Complainant_MobileNumber;
                    objFormM.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                    objFormM.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                    objFormM.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                    objFormM.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                    objFormM.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                    objFormM.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                    objFormM.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                    objFormM.IsActive = item.IsActive;
                    objFormM.IsDraft = item.IsDraft;
                    objFormM.IsLock = item.IsLock;
                    objFormM.IsPublicView = item.IsPublicView;
                    objFormM.CreatedBy = item.CreatedBy;
                    objFormM.CreatedOn = item.CreatedOn;
                    objFormM.ModifyBy = item.ModifyBy;
                    objFormM.ModifyOn = item.ModifyOn;
                }
            }

            objFormMpayment.ComplaintFormNstepII = objPayment.Display_ComplaintFormN_Payment(ComplainantFormN_id);
            if (objFormMpayment.ComplaintFormNstepII.Count >= 1)
            {
                foreach (var item in objFormMpayment.ComplaintFormNstepII)
                {
                    objFormMpayment.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    objFormMpayment.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    objFormMpayment.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    objFormMpayment.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    objFormMpayment.Profile_ID = item.Profile_ID;
                    objFormMpayment.User_ID = item.User_ID;

                    objFormMpayment.ComplaintType_MN = item.ComplaintType_MN;
                    objFormMpayment.User_Name = item.User_Name;
                    objFormMpayment.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    objFormMpayment.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    objFormMpayment.PaymentSuccessDate = item.PaymentSuccessDate;
                    objFormMpayment.FailureSuccessSummary = item.FailureSuccessSummary;

                    objFormMpayment.PG_Transaction_ID = item.PG_Transaction_ID;
                    objFormMpayment.PG_Date = item.PG_Date;
                    objFormMpayment.PG_PayU_ID = item.PG_PayU_ID;
                    objFormMpayment.PG_Amount = item.PG_Amount; //Amount INR
                    objFormMpayment.PG_Status = item.PG_Status;
                    objFormMpayment.PG_Product_Info = item.PG_Product_Info; //Product Info
                    objFormMpayment.PG_Customer_Name = item.PG_Customer_Name; //Name
                    objFormMpayment.PG_Last_Name = item.PG_Last_Name;
                    objFormMpayment.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    objFormMpayment.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    objFormMpayment.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    objFormMpayment.PG_City = item.PG_City;
                    objFormMpayment.PG_Merchant_Name = item.PG_Merchant_Name;
                    objFormMpayment.PG_Bank_Name = item.PG_Bank_Name;
                    objFormMpayment.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    objFormMpayment.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    objFormMpayment.PG_International_Domestic = item.PG_International_Domestic;
                    objFormMpayment.PG_Payment_Type = item.PG_Payment_Type;
                    objFormMpayment.PG_Error_Code = item.PG_Error_Code;
                    objFormMpayment.PG_Error_Message = item.PG_Error_Message;
                    objFormMpayment.PG_Name_on_Card = item.PG_Name_on_Card;
                    objFormMpayment.PG_Card_Number = item.PG_Card_Number;
                    objFormMpayment.PG_Address_Line1 = item.PG_Address_Line1;
                    objFormMpayment.PG_Address_Line2 = item.PG_Address_Line2;
                    objFormMpayment.PG_State = item.PG_State;
                    objFormMpayment.PG_Country = item.PG_Country;
                    objFormMpayment.PG_ZipCode = item.PG_ZipCode;
                    objFormMpayment.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    objFormMpayment.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    objFormMpayment.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    objFormMpayment.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    objFormMpayment.PG_Shipping_City = item.PG_Shipping_City;
                    objFormMpayment.PG_Shipping_State = item.PG_Shipping_State;
                    objFormMpayment.PG_Shipping_Country = item.PG_Shipping_Country;
                    objFormMpayment.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    objFormMpayment.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    objFormMpayment.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    objFormMpayment.PG_Discount = item.PG_Discount;
                    objFormMpayment.PG_Additional_Charges = item.PG_Additional_Charges;
                    objFormMpayment.PG_Amount_INR = item.PG_Amount_INR;
                    objFormMpayment.PG_UDF_1 = item.PG_UDF_1;
                    objFormMpayment.PG_UDF_2 = item.PG_UDF_2;
                    objFormMpayment.PG_UDF_3 = item.PG_UDF_3;
                    objFormMpayment.PG_UDF_4 = item.PG_UDF_4;
                    objFormMpayment.PG_UDF_5 = item.PG_UDF_5;

                    objFormMpayment.PG_Device_Info = item.PG_Device_Info;
                    objFormMpayment.PG_HashKey = item.PG_HashKey;
                    objFormMpayment.PG_ServiceProvider = item.PG_ServiceProvider;
                    objFormMpayment.Remarks_IfAny = item.Remarks_IfAny;

                    objFormMpayment.A_column = item.A_column;
                    objFormMpayment.B_column = item.B_column;
                    objFormMpayment.C_column = item.C_column;

                    objFormMpayment.IsActive = item.IsActive;
                    objFormMpayment.IsDraft = item.IsDraft;
                    objFormMpayment.IsLock = item.IsLock;
                    objFormMpayment.IsPublicView = item.IsPublicView;

                    objFormMpayment.CreatedBy = item.CreatedBy;
                    objFormMpayment.CreatedOn = item.CreatedOn;
                    objFormMpayment.ModifyBy = item.ModifyBy;
                    objFormMpayment.ModifyOn = item.ModifyOn;
                }

                if (objFormMpayment.IsPaymentSuccessComplete == 0 || objFormMpayment.IsPaymentSuccessComplete == 2)
                {
                    // Payment - Pending OR Failure
                    TempData["submitvalueFormNStep2"] = "Make Payment"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueFormNStep2"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                //No records found - table Payment Form M 
                objFormMpayment.PaymentComplaint_IndexID = 0;
                objFormMpayment.PaymentComplaint_ID = 0;
                objFormMpayment.PaymentComplaint_RelatedComplainant_ID = objFormM.ComplaintFormN_ID;
                objFormMpayment.PaymentComplaint_RelatedComplainant_Code = objFormM.ComplaintFormN_Code;
                objFormMpayment.Profile_ID = objFormM.Profile_ID;
                objFormMpayment.ComplaintType_MN = objFormM.ComplaintType_MN; // "FormTypeM";

                //objFormMpayment.User_ID = objFormM.User_ID;
                //objFormMpayment.User_Name = item.User_Name;

                objFormMpayment.PG_Product_Info = "Complaint Fee (Form-N)";
                objFormMpayment.PG_Transaction_Fee = 0;
                objFormMpayment.PG_Discount = 0;
                objFormMpayment.PG_Additional_Charges = 0;
                objFormMpayment.PG_Amount_INR = 1000;
                objFormMpayment.PG_Amount = 1000;
                objFormMpayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                objFormMpayment.PG_Shipping_Firstname = objFormM.Complainant_Name;
                objFormMpayment.PG_Shipping_Lastname = string.Empty;
                objFormMpayment.PG_Shipping_Address1 = objFormM.ServiceNoticesComplainant_AddressLine1;
                objFormMpayment.PG_Shipping_Address2 = objFormM.ServiceNoticesComplainant_AddressLine2;
                objFormMpayment.PG_Shipping_City = objdis.District_Name(objFormM.ServiceNoticesComplainant_AddressDistrictCode);
                objFormMpayment.PG_Shipping_State = objdis.State_Name(objFormM.ServiceNoticesComplainant_AddressStateCode);
                objFormMpayment.PG_Shipping_Country = "India";
                objFormMpayment.PG_Shipping_Zipcode = objFormM.ServiceNoticesComplainant_AddressPIN;
                objFormMpayment.PG_Shipping_Phone = Convert.ToString(objFormM.Complainant_MobileNumber);

                objFormMpayment.PG_Customer_Name = objFormM.Complainant_Name; //Name
                objFormMpayment.PG_Last_Name = string.Empty;
                objFormMpayment.PG_Customer_Email = objFormM.Complainant_EmailAddress; //Email ID
                objFormMpayment.PG_Customer_Phone = Convert.ToString(objFormM.Complainant_MobileNumber); //Phone/Mobile 

                objFormMpayment.PG_Address_Line1 = objFormM.ServiceNoticesComplainant_AddressLine1;
                objFormMpayment.PG_Address_Line2 = objFormM.ServiceNoticesComplainant_AddressLine2;
                objFormMpayment.PG_City = objdis.District_Name(objFormM.ServiceNoticesComplainant_AddressDistrictCode);
                objFormMpayment.PG_State = objdis.State_Name(objFormM.ServiceNoticesComplainant_AddressStateCode);
                objFormMpayment.PG_Country = "India";
                objFormMpayment.PG_ZipCode = objFormM.ServiceNoticesComplainant_AddressPIN;

                TempData["submitvalueFormNStep2"] = "Make Payment"; TempData.Keep();
            }


            return View(objFormMpayment);
        }

        #region ePaymeny Input Form-N
        [HttpPost]
        public void RequestPaymentN(ClsPrp_ComplaintFormN_PaymentIntegration dm)
        {
            string firstName = dm.PG_Customer_Name;
            string lastname = dm.PG_Last_Name;
            string amount = Convert.ToString(dm.PG_Amount);
            string productInfo = dm.PG_Product_Info;
            string email = dm.PG_Customer_Email;
            string phone = dm.PG_Customer_Phone;
            string surl = string.Empty;
            string furl = string.Empty;
            string status = string.Empty;

            string city = dm.PG_City;
            string address1 = dm.PG_Address_Line1;
            string address2 = dm.PG_Address_Line2;
            string state = dm.PG_State;
            string country = dm.PG_Country;
            string zipcode = dm.PG_ZipCode;

            string shipping_firstname = dm.PG_Shipping_Firstname;
            string shipping_lastname = dm.PG_Shipping_Lastname;
            string shipping_address1 = dm.PG_Shipping_Address1;
            string shipping_address2 = dm.PG_Shipping_Address2;
            string shipping_city = dm.PG_Shipping_City;
            string shipping_state = dm.PG_Shipping_State;
            string shipping_country = dm.PG_Shipping_Country;
            string shipping_zipcode = dm.PG_Shipping_Zipcode;
            string shipping_phone = dm.PG_Shipping_Phone;

            string txnid = Generatetxnid();

            string udf2 = dm.PG_Product_Info;
            string udf3 = Convert.ToString(dm.PaymentComplaint_RelatedComplainant_ID);
            string udf4 = string.Empty;
            string udf5 = string.Empty;

            #region Save & Update - Table Payment
            ClsMethod_ComplaintFormN_PaymentIntegration objFormAppM = new ClsMethod_ComplaintFormN_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            Int64 p_PaymentRefNumber = 0;

            if (TempData["submitvalueFormNStep2"].ToString() == "Make Payment")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        p_PaymentRefNumber = objFormAppM.Add_ComplaintFormN_Payment(dm, UID, userName, txnid, "0");
                        if (p_PaymentRefNumber > 0)
                        {
                            dm.PG_UDF_1 = Convert.ToString(p_PaymentRefNumber);
                            ModelState.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                }
            }
            else
            {
                try
                {
                    string varFlagStep_LinkName = Get_ComplaintFormN_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocN";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentN";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationN";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                    }

                    RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    RedirectToAction("RegComplaintFormN", "Complaint");
                }
            }
            #endregion


            string udf1 = Convert.ToString(p_PaymentRefNumber);



            /**************************************************************/
            RemotePost myremotepost = new RemotePost();

            //////////////string key = "t5aUkm"; //98d8Yh
            //////////////string salt = "ZVhH63Gg"; //6thltjA2
            //////////////"https://test.payu.in/_payment";

            string key = ConfigurationManager.AppSettings["payuMerchantKey"];
            string salt = ConfigurationManager.AppSettings["payuSalt"];
            string baseURL = ConfigurationManager.AppSettings["payuBaseURL"];
            string DomainNameURL = ConfigurationManager.AppSettings["payuDomainNameURL"];

            //posting all the parameters required for integration.
            myremotepost.Url = baseURL;
            myremotepost.Add("key", key);
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);
            myremotepost.Add("productinfo", productInfo);
            //  HttpUtility.HtmlEncode("{\"paymentIdentifiers\":" + GetJson(mDiaryNo, mDiaryDate, mPayPurpose, mDepositor, mPayFor).ToString() + "}"));//"123");// 
            myremotepost.Add("firstname", firstName);
            myremotepost.Add("lastname", lastname);
            myremotepost.Add("phone", phone);
            myremotepost.Add("email", email);
            myremotepost.Add("status", status);

            myremotepost.Add("udf1", udf1);
            myremotepost.Add("udf2", udf2);
            myremotepost.Add("udf3", udf3);
            myremotepost.Add("udf4", udf4);
            myremotepost.Add("udf5", udf5);

            myremotepost.Add("city", city);
            myremotepost.Add("address1", address1);
            myremotepost.Add("address2", address2);
            myremotepost.Add("state", state);
            myremotepost.Add("country", country);
            myremotepost.Add("zipcode", zipcode);

            myremotepost.Add("shipping_firstname", shipping_firstname);
            myremotepost.Add("shipping_lastname", shipping_lastname);
            myremotepost.Add("shipping_address1", shipping_address1);
            myremotepost.Add("shipping_address2", shipping_address2);
            myremotepost.Add("shipping_city", shipping_city);
            myremotepost.Add("shipping_state", shipping_state);
            myremotepost.Add("shipping_country", shipping_country);
            myremotepost.Add("shipping_zipcode", shipping_zipcode);
            myremotepost.Add("shipping_phone", shipping_phone);

            myremotepost.Add("surl", DomainNameURL + "/complaintpayment/successpaymentn");
            myremotepost.Add("furl", DomainNameURL + "/complaintpayment/failurepaymentn/" + p_PaymentRefNumber);
            myremotepost.Add("service_provider", "payu"); //payu_paisa

            string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "||||||" + salt;
            //string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "|" + udf6 + "|" + udf7 + "|" + udf8 + "|" + udf9 + "|" + udf10 + "|" + salt;
            //string hashString = "3Q5c3q|2590640|3053.00|OnlineBooking|vimallad|ladvimal@gmail.com|||||||||||mE2RxRwx";
            string hash = Generatehash512(hashString);

            myremotepost.Add("hash", hash);

            if (p_PaymentRefNumber > 0)
            {
                myremotepost.Post();
            }
        }

        public string Get_ComplaintFormN_FlagStep()
        {
            string retSTR = string.Empty;
            Int64 ComplainantFormN_id = 0;
            if (Session["ComplaintFormN_ID"] != null)
            {
                if (Session["ComplaintFormN_ID"].ToString() != "0")
                {
                    ComplainantFormN_id = Convert.ToInt64(Session["ComplaintFormN_ID"]);
                }
            }

            ClsPrp_ComplaintFormN_FlagStep objflagstep = new ClsPrp_ComplaintFormN_FlagStep();
            ClsMethod_ComplaintFormN_Registration objFormAppM = new ClsMethod_ComplaintFormN_Registration();

            objflagstep.ComplaintFormNstepFlag = objFormAppM.Display_ComplaintFormN_Flag_RegStep(ComplainantFormN_id);
            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormNstepFlag)
                {
                    objflagstep.ComplaintFormN_IndexID = item.ComplaintFormN_IndexID;
                    objflagstep.ComplaintFormN_ID = item.ComplaintFormN_ID;
                    objflagstep.ComplaintFormN_Code = item.ComplaintFormN_Code;
                    objflagstep.Profile_ID = item.Profile_ID;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType_MN = item.ComplaintType_MN;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormNstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; //
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }
        #endregion

        #region ePayment Output Form-N

        [AllowAnonymous]
        public ActionResult successpaymentn(FormCollection form = null)
        {
            string salt = ConfigurationManager.AppSettings["payuSalt"];
            bool isValidPaymentResponse = false;
            int existingPaymentStatus = -1;

            string order_id = string.Empty;
            string v_firstName = string.Empty;
            string v_amount = string.Empty;
            string v_productInfo = string.Empty;
            string v_email = string.Empty;
            string v_status = string.Empty;

            string v_udf1 = string.Empty;
            string v_udf2 = string.Empty;
            string v_udf3 = string.Empty;
            string v_udf4 = string.Empty;
            string v_udf5 = string.Empty;

            string v_bank_ref_num = string.Empty;
            string v_PG_TYPE = string.Empty;
            string v_mihpayid = string.Empty;
            string v_mode = string.Empty;
            string v_bankcode = string.Empty;

            try
            {
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;

                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
                if (form != null && !String.IsNullOrEmpty(form["status"]) && form["status"].ToString().Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = salt + "|" + form["status"].ToString();
                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");
                    }
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != Request.Form["hash"])
                    {
                        //Value didn't match that means some paramter value change between transaction
                        ViewData["PaymentMessage"] = "Payment Fails! Some paramter value change between transaction, Try Again.";
                    }
                    else
                    {
                        //if hash value match for before transaction data and after transaction data
                        //that means success full transaction  , see more in response
                        order_id = Request.Form["txnid"];
                        v_firstName = Request.Form["firstName"];
                        v_amount = Request.Form["amount"];
                        v_productInfo = Request.Form["productInfo"];
                        v_email = Request.Form["email"];
                        v_status = Request.Form["status"];

                        v_udf1 = Request.Form["udf1"];
                        v_udf2 = Request.Form["udf2"];
                        v_udf3 = Request.Form["udf3"];
                        v_udf4 = Request.Form["udf4"];
                        v_udf5 = Request.Form["udf5"];

                        v_bank_ref_num = Request.Form["bank_ref_num"];
                        v_PG_TYPE = Request.Form["PG_TYPE"];
                        v_mihpayid = Request.Form["mihpayid"];
                        v_mode = Request.Form["mode"];
                        v_bankcode = Request.Form["bankcode"];
                        isValidPaymentResponse = true;
                    }
                }
                else
                {
                    ViewData["PaymentMessage"] = "Payment Fails! Try Again.";
                }
            }
            catch (Exception ex)
            {
                var strex = ex.ToString();
                ViewData["PaymentMessage"] = "Payment Fails! Try Again.";
            }

            ClsMethod_ComplaintFormN_PaymentIntegration sdb = new ClsMethod_ComplaintFormN_PaymentIntegration();
            ClsPrp_ComplaintFormN_PaymentIntegration aa = new ClsPrp_ComplaintFormN_PaymentIntegration();

            Int64 PRN_udf1 = String.IsNullOrEmpty(v_udf1) ? 0 : Convert.ToInt64(v_udf1);
            aa.ComplaintFormNstepII = sdb.Display_ComplaintFormN_PaymentByPRNumber(PRN_udf1);

            if (aa.ComplaintFormNstepII.Count >= 1)
            {
                foreach (var item in aa.ComplaintFormNstepII)
                {
                    aa.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    aa.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    aa.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    aa.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;

                    aa.ComplaintType_MN = item.ComplaintType_MN;
                    aa.User_Name = item.User_Name;
                    aa.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    aa.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    aa.PaymentSuccessDate = item.PaymentSuccessDate;
                    aa.FailureSuccessSummary = item.FailureSuccessSummary;

                    aa.PG_Transaction_ID = item.PG_Transaction_ID;
                    aa.PG_Date = item.PG_Date;
                    aa.PG_PayU_ID = item.PG_PayU_ID;
                    aa.PG_Amount = item.PG_Amount; //Amount INR
                    aa.PG_Status = item.PG_Status;
                    aa.PG_Product_Info = item.PG_Product_Info; //Product Info
                    aa.PG_Customer_Name = item.PG_Customer_Name; //Name
                    aa.PG_Last_Name = item.PG_Last_Name;
                    aa.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    aa.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    aa.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    aa.PG_City = item.PG_City;
                    aa.PG_Merchant_Name = item.PG_Merchant_Name;
                    aa.PG_Bank_Name = item.PG_Bank_Name;
                    aa.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aa.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aa.PG_International_Domestic = item.PG_International_Domestic;
                    aa.PG_Payment_Type = item.PG_Payment_Type;
                    aa.PG_Error_Code = item.PG_Error_Code;
                    aa.PG_Error_Message = item.PG_Error_Message;
                    aa.PG_Name_on_Card = item.PG_Name_on_Card;
                    aa.PG_Card_Number = item.PG_Card_Number;
                    aa.PG_Address_Line1 = item.PG_Address_Line1;
                    aa.PG_Address_Line2 = item.PG_Address_Line2;
                    aa.PG_State = item.PG_State;
                    aa.PG_Country = item.PG_Country;
                    aa.PG_ZipCode = item.PG_ZipCode;
                    aa.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    aa.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    aa.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    aa.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    aa.PG_Shipping_City = item.PG_Shipping_City;
                    aa.PG_Shipping_State = item.PG_Shipping_State;
                    aa.PG_Shipping_Country = item.PG_Shipping_Country;
                    aa.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    aa.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    aa.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aa.PG_Discount = item.PG_Discount;
                    aa.PG_Additional_Charges = item.PG_Additional_Charges;
                    aa.PG_Amount_INR = item.PG_Amount_INR;
                    aa.PG_UDF_1 = item.PG_UDF_1;
                    aa.PG_UDF_2 = item.PG_UDF_2;
                    aa.PG_UDF_3 = item.PG_UDF_3;
                    aa.PG_UDF_4 = item.PG_UDF_4;
                    aa.PG_UDF_5 = item.PG_UDF_5;

                    aa.PG_Device_Info = item.PG_Device_Info;
                    aa.PG_HashKey = item.PG_HashKey;
                    aa.PG_ServiceProvider = item.PG_ServiceProvider;
                    aa.Remarks_IfAny = item.Remarks_IfAny;

                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }

                if (aa.IsPaymentSuccessComplete == 0 || aa.IsPaymentSuccessComplete == 2)
                {
                    // Payment Details Save (Case when Flag as Pending OR Failure)
                    TempData["submitvalueFormNStep2surl"] = "Proceed"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueFormNStep2surl"] = "Next"; TempData.Keep();
                }
                existingPaymentStatus = aa.IsPaymentSuccessComplete;
            }
            try
            {
                if (isValidPaymentResponse)
                {
                    aa.PG_Transaction_ID = order_id;
                    aa.PG_Date = DateTime.Now;
                    aa.PG_PayU_ID = Convert.ToInt64(v_mihpayid);
                    aa.PG_Amount = Convert.ToDecimal(v_amount);
                    aa.PG_Status = v_status;
                    aa.Complaint_BriefSummary = v_status;
                    aa.PG_Product_Info = v_productInfo;
                    aa.PG_Customer_Name = v_firstName;
                    aa.PG_Customer_Email = v_email;

                    aa.PG_UDF_1 = v_udf1;
                    aa.PG_UDF_2 = v_udf2;
                    aa.PG_UDF_3 = v_udf3;
                    aa.PG_UDF_4 = v_udf4;
                    aa.PG_UDF_5 = v_udf5;

                    aa.PG_Bank_Reference_No = v_bank_ref_num;
                    aa.PG_Payment_Type = v_PG_TYPE;
                    aa.PG_Bank_Name = v_bankcode;
                    aa.PG_Payment_Gateway = v_mode;

                    aa.IsPaymentSuccessComplete = 1;
                    aa.PaymentSuccessDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                return RedirectToAction("RegComplaintFormN", "Complaint");
            }

            if (isValidPaymentResponse && existingPaymentStatus != 1)
            {
                try
                {
                    string updateUID = String.IsNullOrEmpty(aa.User_ID) ? User.Identity.GetUserId() : aa.User_ID;
                    string updateUserName = String.IsNullOrEmpty(aa.User_Name) ? User.Identity.Name : aa.User_Name;
                    sdb.Update_ComplaintFormN_Payment(aa, updateUID, updateUserName, 1);
                    TempData["submitvalueFormNStep2surl"] = "Next"; TempData.Keep();
                }
                catch
                {
                    ViewData["PaymentMessage"] = "Payment received but details update failed. Please contact support.";
                }
            }
            WritePaymentLog("FormN", order_id, v_amount, v_status, v_firstName, v_email, v_bank_ref_num, v_mihpayid, isValidPaymentResponse);
            return View(aa);
        }

        [HttpPost]
        public ActionResult successpaymentnform(ClsPrp_ComplaintFormN_PaymentIntegration dm)
        {

            ClsMethod_ComplaintFormN_PaymentIntegration sdb = new ClsMethod_ComplaintFormN_PaymentIntegration();
            ClsPrp_ComplaintFormN_PaymentIntegration aa = new ClsPrp_ComplaintFormN_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueFormNStep2surl"].ToString() == "Proceed")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)

                    if (ModelState.IsValid)
                    {
                        bool allowUpdateForDuplicateCheck = true;
                        long prnNumber = 0;
                        if (!String.IsNullOrEmpty(dm.PG_UDF_1))
                        {
                            try
                            {
                                prnNumber = Convert.ToInt64(dm.PG_UDF_1);
                            }
                            catch
                            {
                                prnNumber = 0;
                            }
                        }
                        else
                        {
                            prnNumber = dm.PaymentComplaint_ID;
                        }

                        if (prnNumber > 0)
                        {
                            var existingPaymentRecords = sdb.Display_ComplaintFormN_PaymentByPRNumber(prnNumber);
                            if (existingPaymentRecords != null && existingPaymentRecords.Count > 0)
                            {
                                var latestPaymentRecord = existingPaymentRecords[0];
                                if (latestPaymentRecord.IsPaymentSuccessComplete == 1)
                                {
                                    // Duplicate callback/request: already marked successful, skip update.
                                    allowUpdateForDuplicateCheck = false;
                                    TempData["message"] = "Payment already marked successful.";
                                    errorstate = "START";
                                }
                            }
                        }

                        if (allowUpdateForDuplicateCheck && sdb.Update_ComplaintFormN_Payment(dm, UID, userName, IsPaymentSuccessCompleteFlag))
                        {
                            TempData["message"] = "Details Updated Successfully";
                            errorstate = "START";
                        }
                        ModelState.Clear();
                    }
                    if (errorstate == "START")
                    {
                        string varFlagStep_LinkName = Get_ComplaintFormN_FlagStep();

                        string varFlagStep_ControllerLinkName = string.Empty;
                        string varFlagStep_ActionLinkName = string.Empty;

                        switch (varFlagStep_LinkName)
                        {
                            case "Step1M":
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintFormN";
                                break;
                            case "Step2M":
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintEncldocN";
                                break;
                            case "Step3M":
                                varFlagStep_ControllerLinkName = "ComplaintPayment";
                                varFlagStep_ActionLinkName = "RequestPaymentN";
                                break;
                            case "Step4M":
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintVerificationN";
                                break;
                            default:
                                varFlagStep_ControllerLinkName = "Complaint";
                                varFlagStep_ActionLinkName = "RegComplaintFormN";
                                break;
                        }
                        return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                    }
                    else
                    {
                        return RedirectToAction("RegComplaintFormN", "Complaint");
                    }
                }
                else
                {
                    string varFlagStep_LinkName = Get_ComplaintFormN_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintEncldocN";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentN";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintVerificationN";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "Complaint";
                            varFlagStep_ActionLinkName = "RegComplaintFormN";
                            break;
                    }
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
            }

            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                //dm.PG_Last_Name = strex;
                return View("successpaymentn", dm);
            }
            #endregion
        }

        [AllowAnonymous]
        public ActionResult failurepaymentn(int? id)
        {
            ClsMethod_ComplaintFormN_PaymentIntegration sdb = new ClsMethod_ComplaintFormN_PaymentIntegration();
            ClsPrp_ComplaintFormN_PaymentIntegration aa = new ClsPrp_ComplaintFormN_PaymentIntegration();

            Int64 PRN_udf1 = id == null ? 0 : Convert.ToInt64(id);
            aa.ComplaintFormNstepII = sdb.Display_ComplaintFormN_PaymentByPRNumber(PRN_udf1);

            if (aa.ComplaintFormNstepII.Count >= 1)
            {
                foreach (var item in aa.ComplaintFormNstepII)
                {
                    aa.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    aa.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    aa.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    aa.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;

                    aa.ComplaintType_MN = item.ComplaintType_MN;
                    aa.User_Name = item.User_Name;
                    aa.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    aa.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    aa.PaymentSuccessDate = item.PaymentSuccessDate;
                    aa.FailureSuccessSummary = item.FailureSuccessSummary;

                    aa.PG_Transaction_ID = item.PG_Transaction_ID;
                    aa.PG_Date = item.PG_Date;
                    aa.PG_PayU_ID = item.PG_PayU_ID;
                    aa.PG_Amount = item.PG_Amount; //Amount INR
                    aa.PG_Status = item.PG_Status;
                    aa.PG_Product_Info = item.PG_Product_Info; //Product Info
                    aa.PG_Customer_Name = item.PG_Customer_Name; //Name
                    aa.PG_Last_Name = item.PG_Last_Name;
                    aa.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    aa.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    aa.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    aa.PG_City = item.PG_City;
                    aa.PG_Merchant_Name = item.PG_Merchant_Name;
                    aa.PG_Bank_Name = item.PG_Bank_Name;
                    aa.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aa.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aa.PG_International_Domestic = item.PG_International_Domestic;
                    aa.PG_Payment_Type = item.PG_Payment_Type;
                    aa.PG_Error_Code = item.PG_Error_Code;
                    aa.PG_Error_Message = item.PG_Error_Message;
                    aa.PG_Name_on_Card = item.PG_Name_on_Card;
                    aa.PG_Card_Number = item.PG_Card_Number;
                    aa.PG_Address_Line1 = item.PG_Address_Line1;
                    aa.PG_Address_Line2 = item.PG_Address_Line2;
                    aa.PG_State = item.PG_State;
                    aa.PG_Country = item.PG_Country;
                    aa.PG_ZipCode = item.PG_ZipCode;
                    aa.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    aa.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    aa.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    aa.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    aa.PG_Shipping_City = item.PG_Shipping_City;
                    aa.PG_Shipping_State = item.PG_Shipping_State;
                    aa.PG_Shipping_Country = item.PG_Shipping_Country;
                    aa.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    aa.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    aa.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aa.PG_Discount = item.PG_Discount;
                    aa.PG_Additional_Charges = item.PG_Additional_Charges;
                    aa.PG_Amount_INR = item.PG_Amount_INR;
                    aa.PG_UDF_1 = item.PG_UDF_1;
                    aa.PG_UDF_2 = item.PG_UDF_2;
                    aa.PG_UDF_3 = item.PG_UDF_3;
                    aa.PG_UDF_4 = item.PG_UDF_4;
                    aa.PG_UDF_5 = item.PG_UDF_5;

                    aa.PG_Device_Info = item.PG_Device_Info;
                    aa.PG_HashKey = item.PG_HashKey;
                    aa.PG_ServiceProvider = item.PG_ServiceProvider;
                    aa.Remarks_IfAny = item.Remarks_IfAny;

                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }
            }
            return View(aa);
        }
        #endregion

        #endregion


        #region EXECUTION

        [HttpGet]
        public ActionResult RequestPaymentExecutionForm()
        {

            ClsPrp_ComplaintExecutionForm_PaymentIntegration objFormMpayment = new ClsPrp_ComplaintExecutionForm_PaymentIntegration();
            ClsMethod_ComplaintFormM_PaymentIntegration objPayment = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsPrp_ExecutionApplication objFormM = new ClsPrp_ExecutionApplication();
            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsMethod_ComplaintProfile objProfile = new ClsMethod_ComplaintProfile();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();


            Int64 ComplaintExeProfile_Id = 0;
            Int64 zComplaintFormM_ID = 0;
            if (Session["ApplicationId"] != null && Session["User_Type"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    ComplaintExeProfile_Id = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }
            zComplaintFormM_ID = Convert.ToInt64(Session["ComplaintFormM_ID"]);

            objFormM.Complainant_UserProfile = objProfile.DisplayComplaintProfileDetail(ComplaintExeProfile_Id);
            if (objFormM.Complainant_UserProfile.Count >= 1)
            {
                foreach (var item in objFormM.Complainant_UserProfile)
                {
                    objFormM.ExecutionForm_ID = item.ComplaintProfile_ID;
                    objFormM.User_ID = item.UserID;

                    objFormM.Applicant_FirstName = item.Applicant_FirstName + " " + item.Applicant_LastName;
                    objFormM.Applicant_EmailAddress = item.EmailAddress;
                    objFormM.Applicant_MobileNumber = Convert.ToString(item.MobileNumber);
                    //objFormM.dh_phone_landline = Convert.ToInt32(item.PhoneNumber_Number);

                    objFormM.Applicant_AddressLine1 = item.Residencial_Official_AddressLine1;
                    objFormM.Applicant_AddressLine2 = item.Residencial_Official_AddressLine2;
                    objFormM.Applicant_StateCode = objdis.State_Name(Convert.ToInt32(item.Residencial_Official_AddressStateCode));
                    objFormM.Applicant_AddressDistrictCode = objdis.District_Name(Convert.ToInt32(item.Residencial_Official_AddressDistrictCode));
                    objFormM.Applicant_AddressPin = item.Residencial_Official_AddressPIN;

                    //objFormM.IsOfficeResComplainantAddress_SameAsServiceNoticeAddress = item.IsSameCommunicationAdd_ResOffAdd.HasValue ? "1" : "0";
                    //objFormM.ServiceNoticesComplainant_AddressLine1 = item.Comm_AddressLine1;
                    //objFormM.ServiceNoticesComplainant_AddressLine2 = item.Comm_AddressLine2;
                    //objFormM.ServiceNoticesComplainant_AddressStateCode = item.Comm_AddressStateCode;
                    //objFormM.ServiceNoticesComplainant_AddressDistrictCode = item.Comm_AddressDistrictCode;
                    //objFormM.ServiceNoticesComplainant_AddressPIN = item.Comm_AddressPIN.ToString();
                }
            }

            Int64 Executioncomplaint_id = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }

            objFormM.ExecutionFormstepI = objFormAppM.Display_ExecutionForm_Registration_StepI(Executioncomplaint_id);
            if (objFormM.ExecutionFormstepI.Count >= 1)
            {
                foreach (var item in objFormM.ExecutionFormstepI)
                {
                    objFormM.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                    objFormM.ExecutionForm_ID = item.ExecutionForm_ID;
                    objFormM.ExecutionForm_Code = item.ExecutionForm_Code;
                    objFormM.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objFormM.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objFormM.Related_FormExe_Year = item.Related_FormExe_Year;
                    objFormM.Profile_Id = item.Profile_Id;
                    objFormM.User_ID = item.User_ID;
                    objFormM.ComplaintType = item.ComplaintType;

                    objFormM.IsComplaintComplete = item.IsComplaintComplete;
                    objFormM.IsPaymentComplete = item.IsPaymentComplete;
                    objFormM.IsDocumentsComplete = item.IsDocumentsComplete;

                    objFormM.IsVerificationComplete = item.IsVerificationComplete;
                    objFormM.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objFormM.Complainant_FirstName = item.Complainant_FirstName;
                    objFormM.Complainant_EmailAddress = item.Complainant_EmailAddress;
                    objFormM.Complainant_MobileNumber = item.Complainant_MobileNumber;
                    objFormM.Complainant_LandlineFaxNumber = item.Complainant_LandlineFaxNumber;
                    objFormM.Complainant_AadhaarNumber = item.Complainant_AadhaarNumber;

                    objFormM.ServiceNoticesComplainant_AddressLine1 = item.ServiceNoticesComplainant_AddressLine1;
                    objFormM.ServiceNoticesComplainant_AddressLine2 = item.ServiceNoticesComplainant_AddressLine2;
                    objFormM.ServiceNoticesComplainant_AddressStateCode = item.ServiceNoticesComplainant_AddressStateCode;
                    objFormM.ServiceNoticesComplainant_AddressDistrictCode = item.ServiceNoticesComplainant_AddressDistrictCode;
                    objFormM.ServiceNoticesComplainant_AddressPIN = item.ServiceNoticesComplainant_AddressPIN;

                    objFormM.IsActive = item.IsActive;
                    objFormM.IsDraft = item.IsDraft;
                    objFormM.IsLock = item.IsLock;
                    objFormM.IsPublicView = item.IsPublicView;
                    objFormM.CreatedBy = item.CreatedBy;
                    objFormM.CreatedOn = item.CreatedOn;
                    objFormM.ModifyBy = item.ModifyBy;
                    objFormM.ModifiedOn = item.ModifiedOn;
                }
            }

            objFormMpayment.ComplaintExecutionFormstepII = objPayment.Display_ComplaintFormExecution_Payment(Executioncomplaint_id);
            if (objFormMpayment.ComplaintExecutionFormstepII.Count >= 1)
            {
                foreach (var item in objFormMpayment.ComplaintExecutionFormstepII)
                {
                    objFormMpayment.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    objFormMpayment.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    objFormMpayment.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    objFormMpayment.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    objFormMpayment.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objFormMpayment.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objFormMpayment.Related_FormExe_Year = item.Related_FormExe_Year;
                    objFormMpayment.Profile_ID = item.Profile_ID;
                    objFormMpayment.User_ID = item.User_ID;

                    objFormMpayment.ComplaintType_MN = item.ComplaintType_MN;
                    objFormMpayment.User_Name = item.User_Name;
                    objFormMpayment.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    objFormMpayment.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    objFormMpayment.PaymentSuccessDate = item.PaymentSuccessDate;
                    objFormMpayment.FailureSuccessSummary = item.FailureSuccessSummary;

                    objFormMpayment.PG_Transaction_ID = item.PG_Transaction_ID;
                    objFormMpayment.PG_Date = item.PG_Date;
                    objFormMpayment.PG_PayU_ID = item.PG_PayU_ID;
                    objFormMpayment.PG_Amount = item.PG_Amount; //Amount INR
                    objFormMpayment.PG_Status = item.PG_Status;
                    objFormMpayment.PG_Product_Info = item.PG_Product_Info; //Product Info
                    objFormMpayment.PG_Customer_Name = item.PG_Customer_Name; //Name
                    objFormMpayment.PG_Last_Name = item.PG_Last_Name;
                    objFormMpayment.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    objFormMpayment.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    objFormMpayment.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    objFormMpayment.PG_City = item.PG_City;
                    objFormMpayment.PG_Merchant_Name = item.PG_Merchant_Name;
                    objFormMpayment.PG_Bank_Name = item.PG_Bank_Name;
                    objFormMpayment.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    objFormMpayment.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    objFormMpayment.PG_International_Domestic = item.PG_International_Domestic;
                    objFormMpayment.PG_Payment_Type = item.PG_Payment_Type;
                    objFormMpayment.PG_Error_Code = item.PG_Error_Code;
                    objFormMpayment.PG_Error_Message = item.PG_Error_Message;
                    objFormMpayment.PG_Name_on_Card = item.PG_Name_on_Card;
                    objFormMpayment.PG_Card_Number = item.PG_Card_Number;
                    objFormMpayment.PG_Address_Line1 = item.PG_Address_Line1;
                    objFormMpayment.PG_Address_Line2 = item.PG_Address_Line2;
                    objFormMpayment.PG_State = item.PG_State;
                    objFormMpayment.PG_Country = item.PG_Country;
                    objFormMpayment.PG_ZipCode = item.PG_ZipCode;
                    objFormMpayment.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    objFormMpayment.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    objFormMpayment.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    objFormMpayment.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    objFormMpayment.PG_Shipping_City = item.PG_Shipping_City;
                    objFormMpayment.PG_Shipping_State = item.PG_Shipping_State;
                    objFormMpayment.PG_Shipping_Country = item.PG_Shipping_Country;
                    objFormMpayment.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    objFormMpayment.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    objFormMpayment.PG_Shipping_Aemail = item.PG_Shipping_Aemail;
                    objFormMpayment.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    objFormMpayment.PG_Discount = item.PG_Discount;
                    objFormMpayment.PG_Additional_Charges = item.PG_Additional_Charges;
                    objFormMpayment.PG_Amount_INR = item.PG_Amount_INR;
                    objFormMpayment.PG_UDF_1 = item.PG_UDF_1;
                    objFormMpayment.PG_UDF_2 = item.PG_UDF_2;
                    objFormMpayment.PG_UDF_3 = item.PG_UDF_3;
                    objFormMpayment.PG_UDF_4 = item.PG_UDF_4;
                    objFormMpayment.PG_UDF_5 = item.PG_UDF_5;

                    objFormMpayment.PG_Device_Info = item.PG_Device_Info;
                    objFormMpayment.PG_HashKey = item.PG_HashKey;
                    objFormMpayment.PG_ServiceProvider = item.PG_ServiceProvider;
                    objFormMpayment.Remarks_IfAny = item.Remarks_IfAny;

                    objFormMpayment.A_column = item.A_column;
                    objFormMpayment.B_column = item.B_column;
                    objFormMpayment.C_column = item.C_column;

                    objFormMpayment.IsActive = item.IsActive;
                    objFormMpayment.IsDraft = item.IsDraft;
                    objFormMpayment.IsLock = item.IsLock;
                    objFormMpayment.IsPublicView = item.IsPublicView;

                    objFormMpayment.CreatedBy = item.CreatedBy;
                    objFormMpayment.CreatedOn = item.CreatedOn;
                    objFormMpayment.ModifyBy = item.ModifyBy;
                    objFormMpayment.ModifyOn = item.ModifyOn;
                }

                if (objFormMpayment.IsPaymentSuccessComplete == 0 || objFormMpayment.IsPaymentSuccessComplete == 2)
                {
                    // Payment - Pending OR Failure
                    TempData["submitvalueFormMStep2"] = "Make Payment"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueFormMStep2"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                // No records found - table Payment Form M
                objFormMpayment.PaymentComplaint_IndexID = 0;
                objFormMpayment.PaymentComplaint_ID = 0;
                objFormMpayment.PaymentComplaint_RelatedComplainant_ID = objFormM.ExecutionForm_ID;
                objFormMpayment.PaymentComplaint_RelatedComplainant_Code = objFormM.ExecutionForm_Code;
                objFormMpayment.Related_ComplaintFormMId = objFormM.Related_ComplaintFormMId;
                objFormMpayment.Related_FormExe_SequenceID = objFormM.Related_FormExe_SequenceID;
                objFormMpayment.Related_FormExe_Year = objFormM.Related_FormExe_Year;
                objFormMpayment.Profile_ID = objFormM.Profile_Id;
                objFormMpayment.ComplaintType_MN = "EXECUTION FORM"; // "FormTypeM";

                objFormMpayment.User_ID = objFormM.User_ID;
                objFormMpayment.User_Name = objFormM.CreatedBy;

                objFormMpayment.PG_Product_Info = "EXECUTION FORM";
                objFormMpayment.PG_Transaction_Fee = 0;
                objFormMpayment.PG_Discount = 0;
                objFormMpayment.PG_Additional_Charges = 0;
                objFormMpayment.PG_Amount_INR = 1000;
                objFormMpayment.PG_Amount = 1000;
                objFormMpayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";


                objFormMpayment.PG_Shipping_Firstname = objFormM.Applicant_FirstName;
                objFormMpayment.PG_Shipping_Lastname = objFormM.Applicant_LastName;
                objFormMpayment.PG_Shipping_Address1 = objFormM.ServiceNoticesComplainant_AddressLine1;
                objFormMpayment.PG_Shipping_Address2 = objFormM.ServiceNoticesComplainant_AddressLine2;
                objFormMpayment.PG_Shipping_City = objdis.District_Name(objFormM.ServiceNoticesComplainant_AddressDistrictCode);
                objFormMpayment.PG_Shipping_State = objdis.State_Name(objFormM.ServiceNoticesComplainant_AddressStateCode);
                objFormMpayment.PG_Shipping_Country = "India";
                objFormMpayment.PG_Shipping_Zipcode = objFormM.ServiceNoticesComplainant_AddressPIN;
                objFormMpayment.PG_Shipping_Phone = Convert.ToString(objFormM.Applicant_MobileNumber);
                objFormMpayment.PG_Shipping_Aemail = objFormM.Applicant_EmailAddress; //Email ID



                objFormMpayment.PG_Customer_Name = objFormM.Complainant_FirstName; //Name
                objFormMpayment.PG_Last_Name = objFormM.Complainant_LastName ?? string.Empty;
                objFormMpayment.PG_Customer_Email = objFormM.Complainant_EmailAddress; //Email ID
                objFormMpayment.PG_Customer_Phone = Convert.ToString(objFormM.Complainant_MobileNumber); //Phone/Mobile 

                objFormMpayment.PG_Address_Line1 = objFormM.ServiceNoticesComplainant_AddressLine1;
                objFormMpayment.PG_Address_Line2 = objFormM.ServiceNoticesComplainant_AddressLine2;
                objFormMpayment.PG_City = objdis.District_Name(objFormM.ServiceNoticesComplainant_AddressDistrictCode);
                objFormMpayment.PG_State = objdis.State_Name(objFormM.ServiceNoticesComplainant_AddressStateCode);
                objFormMpayment.PG_Country = "India";
                objFormMpayment.PG_ZipCode = objFormM.ServiceNoticesComplainant_AddressPIN;



                TempData["submitvalueFormMStep2"] = "Make Payment"; TempData.Keep();
            }
            return View(objFormMpayment);
        }

        #region Paymeny Input Form-EXECUTION

        public string Get_ComplaintFormExecution_FlagStep()
        {
            string retSTR = string.Empty;
            Int64 Executioncomplaint_id = 0;
            if (Session["ExecutionForm_ID"] != null)
            {
                if (Session["ExecutionForm_ID"].ToString() != "0")
                {
                    Executioncomplaint_id = Convert.ToInt64(Session["ExecutionForm_ID"]);
                }
            }

            ClsPrp_ExecutionForm_FlagStep objflagstep = new ClsPrp_ExecutionForm_FlagStep();
            ClsMethod_ComplaintFormM_Registration objFormAppM = new ClsMethod_ComplaintFormM_Registration();

            objflagstep.ComplaintFormMstepFlag = objFormAppM.Display_ComplaintFormExecution_Flag_RegStep(Executioncomplaint_id);
            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                foreach (var item in objflagstep.ComplaintFormMstepFlag)
                {
                    objflagstep.ExecutionForm_IndexId = item.ExecutionForm_IndexId;
                    objflagstep.ExecutionForm_ID = item.ExecutionForm_ID;
                    objflagstep.ExecutionForm_Code = item.ExecutionForm_Code;
                    objflagstep.Related_ComplaintFormMId = item.Related_ComplaintFormMId;
                    objflagstep.Related_FormExe_SequenceID = item.Related_FormExe_SequenceID;
                    objflagstep.Related_FormExe_Year = item.Related_FormExe_Year;
                    objflagstep.Profile_Id = item.Profile_Id;
                    objflagstep.User_ID = item.User_ID;
                    objflagstep.ComplaintType = item.ComplaintType;

                    objflagstep.IsComplaintComplete = item.IsComplaintComplete;
                    objflagstep.IsPaymentComplete = item.IsPaymentComplete;
                    objflagstep.IsDocumentsComplete = item.IsDocumentsComplete;
                    objflagstep.IsVerificationComplete = item.IsVerificationComplete;
                    objflagstep.ComplaintVerificationDate = item.ComplaintVerificationDate;

                    objflagstep.IsActive = item.IsActive;
                    objflagstep.IsDraft = item.IsDraft;
                    objflagstep.IsLock = item.IsLock;
                    objflagstep.IsPublicView = item.IsPublicView;
                    objflagstep.CreatedBy = item.CreatedBy;
                    objflagstep.CreatedOn = item.CreatedOn;
                    objflagstep.ModifyBy = item.ModifyBy;
                    objflagstep.ModifyOn = item.ModifyOn;
                }
            }

            if (objflagstep.ComplaintFormMstepFlag.Count >= 1)
            {
                if (objflagstep.IsDraft == 0)
                {
                    if (objflagstep.IsActive == 1)
                    {
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 1)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 1 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 1 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step3M"; // "RequestPaymentFormM"; // 
                        }
                        if (objflagstep.IsComplaintComplete == 1 && objflagstep.IsDocumentsComplete == 0 && objflagstep.IsPaymentComplete == 0 && objflagstep.IsVerificationComplete == 0)
                        {
                            retSTR = "Step2M"; // "RegComplaintEncldocM"; //
                        }
                    }
                }
                else
                {
                    retSTR = "Step4M"; // "RegComplaintVerificationM"; // 
                }
            }
            else
            {
                retSTR = "Step1M"; // "RegComplaintFormM"; // 
            }
            return retSTR;
        }

        [HttpPost]
        public void RequestPaymentExecutionForm(ClsPrp_ComplaintExecutionForm_PaymentIntegration dm)
        {
            string firstName = dm.PG_Customer_Name;
            string lastname = dm.PG_Last_Name;
            string amount = Convert.ToString(dm.PG_Amount);
            string productInfo = dm.PG_Product_Info;
            string email = dm.PG_Customer_Email;
            string phone = dm.PG_Customer_Phone;
            string surl = string.Empty;
            string furl = string.Empty;
            string status = string.Empty;

            string city = dm.PG_City;
            string address1 = dm.PG_Address_Line1;
            string address2 = dm.PG_Address_Line2;
            string state = dm.PG_State;
            string country = dm.PG_Country;
            string zipcode = dm.PG_ZipCode;

            string shipping_firstname = dm.PG_Shipping_Firstname;
            string shipping_lastname = dm.PG_Shipping_Lastname;
            string shipping_address1 = dm.PG_Shipping_Address1;
            string shipping_address2 = dm.PG_Shipping_Address2;
            string shipping_city = dm.PG_Shipping_City;
            string shipping_state = dm.PG_Shipping_State;
            string shipping_country = dm.PG_Shipping_Country;
            string shipping_zipcode = dm.PG_Shipping_Zipcode;
            string shipping_phone = dm.PG_Shipping_Phone;

            string txnid = Generatetxnid();

            string udf2 = dm.PG_Product_Info;
            string udf3 = Convert.ToString(dm.PaymentComplaint_RelatedComplainant_ID);
            string udf4 = string.Empty;
            string udf5 = string.Empty;

            #region Save & Update - Table Payment
            ClsMethod_ComplaintFormM_PaymentIntegration objFormAppM = new ClsMethod_ComplaintFormM_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            Int64 p_PaymentRefNumber = 0;

            if (TempData["submitvalueFormMStep2"].ToString() == "Make Payment")
            {
                try
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                    if (ModelState.IsValid)
                    {
                        p_PaymentRefNumber = objFormAppM.Add_ComplaintFormExecution_Payment(dm, UID, userName, txnid, "0");
                        if (p_PaymentRefNumber > 0)
                        {
                            dm.PG_UDF_1 = Convert.ToString(p_PaymentRefNumber);
                            ModelState.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                }
            }
            else
            {
                try
                {
                    string varFlagStep_LinkName = Get_ComplaintFormExecution_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                    }

                    RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
                catch (Exception ex)
                {
                    string strex = ex.ToString();
                    TempData["message"] = "Bad Request, Try Again!";
                    RedirectToAction("RegExecutionForm", "ComplaintExecution");
                }
            }
            #endregion


            string udf1 = Convert.ToString(p_PaymentRefNumber);



            /**************************************************************/
            RemotePost myremotepost = new RemotePost();

            //////////////string key = "t5aUkm"; //98d8Yh
            //////////////string salt = "ZVhH63Gg"; //6thltjA2
            //////////////"https://test.payu.in/_payment";

            string key = ConfigurationManager.AppSettings["payuMerchantKey"];
            string salt = ConfigurationManager.AppSettings["payuSalt"];
            string baseURL = ConfigurationManager.AppSettings["payuBaseURL"];
            string DomainNameURL = ConfigurationManager.AppSettings["payuDomainNameURL"];

            //posting all the parameters required for integration.
            myremotepost.Url = baseURL;
            myremotepost.Add("key", key);
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);
            myremotepost.Add("productinfo", productInfo);
            //  HttpUtility.HtmlEncode("{\"paymentIdentifiers\":" + GetJson(mDiaryNo, mDiaryDate, mPayPurpose, mDepositor, mPayFor).ToString() + "}"));//"123");// 
            myremotepost.Add("firstname", firstName);
            myremotepost.Add("lastname", lastname);
            myremotepost.Add("phone", phone);
            myremotepost.Add("email", email);
            myremotepost.Add("status", status);

            myremotepost.Add("udf1", udf1);
            myremotepost.Add("udf2", udf2);
            myremotepost.Add("udf3", udf3);
            myremotepost.Add("udf4", udf4);
            myremotepost.Add("udf5", udf5);

            myremotepost.Add("city", city);
            myremotepost.Add("address1", address1);
            myremotepost.Add("address2", address2);
            myremotepost.Add("state", state);
            myremotepost.Add("country", country);
            myremotepost.Add("zipcode", zipcode);

            myremotepost.Add("shipping_firstname", shipping_firstname);
            myremotepost.Add("shipping_lastname", shipping_lastname);
            myremotepost.Add("shipping_address1", shipping_address1);
            myremotepost.Add("shipping_address2", shipping_address2);
            myremotepost.Add("shipping_city", shipping_city);
            myremotepost.Add("shipping_state", shipping_state);
            myremotepost.Add("shipping_country", shipping_country);
            myremotepost.Add("shipping_zipcode", shipping_zipcode);
            myremotepost.Add("shipping_phone", shipping_phone);

            myremotepost.Add("surl", DomainNameURL + "/complaintpayment/successpaymentm");
            myremotepost.Add("furl", DomainNameURL + "/complaintpayment/failurepaymentm/" + p_PaymentRefNumber);
            myremotepost.Add("service_provider", "payu"); //payu_paisa

            string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "||||||" + salt;
            //string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "|" + udf6 + "|" + udf7 + "|" + udf8 + "|" + udf9 + "|" + udf10 + "|" + salt;
            //string hashString = "3Q5c3q|2590640|3053.00|OnlineBooking|vimallad|ladvimal@gmail.com|||||||||||mE2RxRwx";
            string hash = Generatehash512(hashString);

            myremotepost.Add("hash", hash);

            if (p_PaymentRefNumber > 0)
            {
                myremotepost.Post();
            }
        }

        #endregion

        #region Payment Output Form-EXECUTION

        [AllowAnonymous]
        public ActionResult successpaymentExe(FormCollection form = null)
        {
            string salt = ConfigurationManager.AppSettings["payuSalt"];
            bool isValidPaymentResponse = false;
            int existingPaymentStatus = -1;

            string order_id = string.Empty;
            string v_firstName = string.Empty;
            string v_amount = string.Empty;
            string v_productInfo = string.Empty;
            string v_email = string.Empty;
            string v_status = string.Empty;

            string v_udf1 = string.Empty;
            string v_udf2 = string.Empty;
            string v_udf3 = string.Empty;
            string v_udf4 = string.Empty;
            string v_udf5 = string.Empty;

            string v_bank_ref_num = string.Empty;
            string v_PG_TYPE = string.Empty;
            string v_mihpayid = string.Empty;
            string v_mode = string.Empty;
            string v_bankcode = string.Empty;

            try
            {
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;

                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
                if (form != null && !String.IsNullOrEmpty(form["status"]) && form["status"].ToString().Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = salt + "|" + form["status"].ToString();
                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");
                    }
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != Request.Form["hash"])
                    {
                        //Value didn't match that means some paramter value change between transaction
                        ViewData["PaymentMessage"] = "Payment Fails! Some paramter value change between transaction, Try Again.";
                    }
                    else
                    {
                        //if hash value match for before transaction data and after transaction data
                        //that means success full transaction  , see more in response
                        order_id = Request.Form["txnid"];
                        v_firstName = Request.Form["firstName"];
                        v_amount = Request.Form["amount"];
                        v_productInfo = Request.Form["productInfo"];
                        v_email = Request.Form["email"];
                        v_status = Request.Form["status"];

                        v_udf1 = Request.Form["udf1"];
                        v_udf2 = Request.Form["udf2"];
                        v_udf3 = Request.Form["udf3"];
                        v_udf4 = Request.Form["udf4"];
                        v_udf5 = Request.Form["udf5"];

                        v_bank_ref_num = Request.Form["bank_ref_num"];
                        v_PG_TYPE = Request.Form["PG_TYPE"];
                        v_mihpayid = Request.Form["mihpayid"];
                        v_mode = Request.Form["mode"];
                        v_bankcode = Request.Form["bankcode"];
                        isValidPaymentResponse = true;
                    }
                }
                else
                {
                    ViewData["PaymentMessage"] = "Payment Fails! Try Again.";
                }
            }
            catch (Exception ex)
            {
                var strex = ex.ToString();
                ViewData["PaymentMessage"] = "Payment Fails! Try Again.";
            }

            ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintExecutionForm_PaymentIntegration aa = new ClsPrp_ComplaintExecutionForm_PaymentIntegration();

            Int64 PRN_udf1 = String.IsNullOrEmpty(v_udf1) ? 0 : Convert.ToInt64(v_udf1);
            aa.ComplaintExecutionFormstepII = sdb.Display_ComplaintFormExe_PaymentByPRNumber(PRN_udf1);

            if (aa.ComplaintExecutionFormstepII.Count >= 1)
            {
                foreach (var item in aa.ComplaintExecutionFormstepII)
                {
                    aa.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
                    aa.PaymentComplaint_ID = item.PaymentComplaint_ID;
                    aa.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
                    aa.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
                    aa.Profile_ID = item.Profile_ID;
                    aa.User_ID = item.User_ID;

                    aa.ComplaintType_MN = item.ComplaintType_MN;
                    aa.User_Name = item.User_Name;
                    aa.Complaint_BriefSummary = item.Complaint_BriefSummary;
                    aa.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    aa.PaymentSuccessDate = item.PaymentSuccessDate;
                    aa.FailureSuccessSummary = item.FailureSuccessSummary;

                    aa.PG_Transaction_ID = item.PG_Transaction_ID;
                    aa.PG_Date = item.PG_Date;
                    aa.PG_PayU_ID = item.PG_PayU_ID;
                    aa.PG_Amount = item.PG_Amount; //Amount INR
                    aa.PG_Status = item.PG_Status;
                    aa.PG_Product_Info = item.PG_Product_Info; //Product Info
                    aa.PG_Customer_Name = item.PG_Customer_Name; //Name
                    aa.PG_Last_Name = item.PG_Last_Name;
                    aa.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    aa.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    aa.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    aa.PG_City = item.PG_City;
                    aa.PG_Merchant_Name = item.PG_Merchant_Name;
                    aa.PG_Bank_Name = item.PG_Bank_Name;
                    aa.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    aa.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    aa.PG_International_Domestic = item.PG_International_Domestic;
                    aa.PG_Payment_Type = item.PG_Payment_Type;
                    aa.PG_Error_Code = item.PG_Error_Code;
                    aa.PG_Error_Message = item.PG_Error_Message;
                    aa.PG_Name_on_Card = item.PG_Name_on_Card;
                    aa.PG_Card_Number = item.PG_Card_Number;
                    aa.PG_Address_Line1 = item.PG_Address_Line1;
                    aa.PG_Address_Line2 = item.PG_Address_Line2;
                    aa.PG_State = item.PG_State;
                    aa.PG_Country = item.PG_Country;
                    aa.PG_ZipCode = item.PG_ZipCode;
                    aa.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    aa.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    aa.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    aa.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    aa.PG_Shipping_City = item.PG_Shipping_City;
                    aa.PG_Shipping_State = item.PG_Shipping_State;
                    aa.PG_Shipping_Country = item.PG_Shipping_Country;
                    aa.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    aa.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    aa.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    aa.PG_Discount = item.PG_Discount;
                    aa.PG_Additional_Charges = item.PG_Additional_Charges;
                    aa.PG_Amount_INR = item.PG_Amount_INR;
                    aa.PG_UDF_1 = item.PG_UDF_1;
                    aa.PG_UDF_2 = item.PG_UDF_2;
                    aa.PG_UDF_3 = item.PG_UDF_3;
                    aa.PG_UDF_4 = item.PG_UDF_4;
                    aa.PG_UDF_5 = item.PG_UDF_5;

                    aa.PG_Device_Info = item.PG_Device_Info;
                    aa.PG_HashKey = item.PG_HashKey;
                    aa.PG_ServiceProvider = item.PG_ServiceProvider;
                    aa.Remarks_IfAny = item.Remarks_IfAny;

                    aa.A_column = item.A_column;
                    aa.B_column = item.B_column;
                    aa.C_column = item.C_column;

                    aa.IsActive = item.IsActive;
                    aa.IsDraft = item.IsDraft;
                    aa.IsLock = item.IsLock;
                    aa.IsPublicView = item.IsPublicView;

                    aa.CreatedBy = item.CreatedBy;
                    aa.CreatedOn = item.CreatedOn;
                    aa.ModifyBy = item.ModifyBy;
                    aa.ModifyOn = item.ModifyOn;
                }

                if (aa.IsPaymentSuccessComplete == 0 || aa.IsPaymentSuccessComplete == 2)
                {
                    // Payment Details Save (Case when Flag as Pending OR Failure)
                    TempData["submitvalueFormMStep2surl"] = "Proceed"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueFormMStep2surl"] = "Next"; TempData.Keep();
                }
                existingPaymentStatus = aa.IsPaymentSuccessComplete;
            }
            try
            {
                if (isValidPaymentResponse)
                {
                    aa.PG_Transaction_ID = order_id;
                    aa.PG_Date = DateTime.Now;
                    aa.PG_PayU_ID = Convert.ToInt64(v_mihpayid);
                    aa.PG_Amount = Convert.ToDecimal(v_amount);
                    aa.PG_Status = v_status;
                    aa.Complaint_BriefSummary = v_status;
                    aa.PG_Product_Info = v_productInfo;
                    aa.PG_Customer_Name = v_firstName;
                    aa.PG_Customer_Email = v_email;

                    aa.PG_UDF_1 = v_udf1;
                    aa.PG_UDF_2 = v_udf2;
                    aa.PG_UDF_3 = v_udf3;
                    aa.PG_UDF_4 = v_udf4;
                    aa.PG_UDF_5 = v_udf5;

                    aa.PG_Bank_Reference_No = v_bank_ref_num;
                    aa.PG_Payment_Type = v_PG_TYPE;
                    aa.PG_Bank_Name = v_bankcode;
                    aa.PG_Payment_Gateway = v_mode;

                    aa.IsPaymentSuccessComplete = 1;
                    aa.PaymentSuccessDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                return RedirectToAction("RegExecutionForm", "ComplaintExecution");
            }

            if (isValidPaymentResponse && existingPaymentStatus != 1)
            {
                try
                {
                    string updateUID = String.IsNullOrEmpty(aa.User_ID) ? User.Identity.GetUserId() : aa.User_ID;
                    string updateUserName = String.IsNullOrEmpty(aa.User_Name) ? User.Identity.Name : aa.User_Name;
                    sdb.Update_ComplaintFormExe_Payment(aa, updateUID, updateUserName, 1);
                    TempData["submitvalueFormMStep2surl"] = "Next"; TempData.Keep();
                }
                catch
                {
                    //ViewData["PaymentMessage"] = "Payment received but details update failed. Please contact support.";
                    ViewData["PaymentMessage"] = "Payment received.";
                }
            }

            WritePaymentLog("FormExecution", order_id, v_amount, v_status, v_firstName, v_email, v_bank_ref_num, v_mihpayid, isValidPaymentResponse);
            return View(aa);
        }

        [HttpPost]
        public ActionResult successpaymentExeform(ClsPrp_ComplaintFormM_PaymentIntegration dm)
        {

            ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormM_PaymentIntegration aa = new ClsPrp_ComplaintFormM_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueFormMStep2surl"].ToString() == "Proceed")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)

                    if (ModelState.IsValid)
                    {
                        bool allowUpdateForDuplicateCheck = true;
                        long prnNumber = 0;
                        if (!String.IsNullOrEmpty(dm.PG_UDF_1))
                        {
                            try
                            {
                                prnNumber = Convert.ToInt64(dm.PG_UDF_1);
                            }
                            catch
                            {
                                prnNumber = 0;
                            }
                        }
                        else
                        {
                            prnNumber = dm.PaymentComplaint_ID;
                        }

                        if (prnNumber > 0)
                        {
                            var existingPaymentRecords = sdb.Display_ComplaintFormM_PaymentByPRNumber(prnNumber);
                            if (existingPaymentRecords != null && existingPaymentRecords.Count > 0)
                            {
                                var latestPaymentRecord = existingPaymentRecords[0];
                                if (latestPaymentRecord.IsPaymentSuccessComplete == 1)
                                {
                                    // Duplicate callback/request: already marked successful, skip update.
                                    allowUpdateForDuplicateCheck = false;
                                    TempData["message"] = "Payment already marked successful.";
                                    errorstate = "START";
                                }
                            }
                        }

                        if (allowUpdateForDuplicateCheck && sdb.Update_ComplaintFormM_Payment(dm, UID, userName, IsPaymentSuccessCompleteFlag))
                        {
                            TempData["message"] = "Details Updated Successfully";
                            errorstate = "START";
                        }
                        ModelState.Clear();
                    }
                    if (errorstate == "START")
                    {
                        string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                        string varFlagStep_ControllerLinkName = string.Empty;
                        string varFlagStep_ActionLinkName = string.Empty;

                        switch (varFlagStep_LinkName)
                        {
                            case "Step1M":
                                varFlagStep_ControllerLinkName = "ComplaintExecution";
                                varFlagStep_ActionLinkName = "RegExecutionForm";
                                break;
                            case "Step2M":
                                varFlagStep_ControllerLinkName = "ComplaintExecution";
                                varFlagStep_ActionLinkName = "RegExecutionEncldocM";
                                break;
                            case "Step3M":
                                varFlagStep_ControllerLinkName = "ComplaintPayment";
                                varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
                                break;
                            case "Step4M":
                                varFlagStep_ControllerLinkName = "ComplaintExecution";
                                varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
                                break;
                            default:
                                varFlagStep_ControllerLinkName = "ComplaintExecution";
                                varFlagStep_ActionLinkName = "RegExecutionForm";
                                break;
                        }
                        return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                    }
                    else
                    {
                        return RedirectToAction("RegExecutionForm", "ComplaintExecution");
                    }
                }
                else
                {
                    string varFlagStep_LinkName = Get_ComplaintFormM_FlagStep();

                    string varFlagStep_ControllerLinkName = string.Empty;
                    string varFlagStep_ActionLinkName = string.Empty;

                    switch (varFlagStep_LinkName)
                    {
                        case "Step1M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                        case "Step2M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionEncldocM";
                            break;
                        case "Step3M":
                            varFlagStep_ControllerLinkName = "ComplaintPayment";
                            varFlagStep_ActionLinkName = "RequestPaymentExecutionForm";
                            break;
                        case "Step4M":
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegComplaintExecutionVerification";
                            break;
                        default:
                            varFlagStep_ControllerLinkName = "ComplaintExecution";
                            varFlagStep_ActionLinkName = "RegExecutionForm";
                            break;
                    }
                    return RedirectToAction(varFlagStep_ActionLinkName, varFlagStep_ControllerLinkName);
                }
            }

            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                //dm.PG_Last_Name = strex;
                return View("successpaymentExe", dm);
            }
            #endregion
        }

        //[AllowAnonymous]
        //public ActionResult failurepaymentm(int? id)
        //{
        //    ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();
        //    ClsPrp_ComplaintFormM_PaymentIntegration aa = new ClsPrp_ComplaintFormM_PaymentIntegration();

        //    Int64 PRN_udf1 = id == null ? 0 : Convert.ToInt64(id);
        //    aa.ComplaintFormMstepII = sdb.Display_ComplaintFormM_PaymentByPRNumber(PRN_udf1);

        //    if (aa.ComplaintFormMstepII.Count >= 1)
        //    {
        //        foreach (var item in aa.ComplaintFormMstepII)
        //        {
        //            aa.PaymentComplaint_IndexID = item.PaymentComplaint_IndexID;
        //            aa.PaymentComplaint_ID = item.PaymentComplaint_ID;
        //            aa.PaymentComplaint_RelatedComplainant_ID = item.PaymentComplaint_RelatedComplainant_ID;
        //            aa.PaymentComplaint_RelatedComplainant_Code = item.PaymentComplaint_RelatedComplainant_Code;
        //            aa.Profile_ID = item.Profile_ID;
        //            aa.User_ID = item.User_ID;

        //            aa.ComplaintType_MN = item.ComplaintType_MN;
        //            aa.User_Name = item.User_Name;
        //            aa.Complaint_BriefSummary = item.Complaint_BriefSummary;
        //            aa.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
        //            aa.PaymentSuccessDate = item.PaymentSuccessDate;
        //            aa.FailureSuccessSummary = item.FailureSuccessSummary;

        //            aa.PG_Transaction_ID = item.PG_Transaction_ID;
        //            aa.PG_Date = item.PG_Date;
        //            aa.PG_PayU_ID = item.PG_PayU_ID;
        //            aa.PG_Amount = item.PG_Amount; //Amount INR
        //            aa.PG_Status = item.PG_Status;
        //            aa.PG_Product_Info = item.PG_Product_Info; //Product Info
        //            aa.PG_Customer_Name = item.PG_Customer_Name; //Name
        //            aa.PG_Last_Name = item.PG_Last_Name;
        //            aa.PG_Customer_Email = item.PG_Customer_Email; //Email ID
        //            aa.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
        //            aa.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
        //            aa.PG_City = item.PG_City;
        //            aa.PG_Merchant_Name = item.PG_Merchant_Name;
        //            aa.PG_Bank_Name = item.PG_Bank_Name;
        //            aa.PG_Payment_Gateway = item.PG_Payment_Gateway;
        //            aa.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
        //            aa.PG_International_Domestic = item.PG_International_Domestic;
        //            aa.PG_Payment_Type = item.PG_Payment_Type;
        //            aa.PG_Error_Code = item.PG_Error_Code;
        //            aa.PG_Error_Message = item.PG_Error_Message;
        //            aa.PG_Name_on_Card = item.PG_Name_on_Card;
        //            aa.PG_Card_Number = item.PG_Card_Number;
        //            aa.PG_Address_Line1 = item.PG_Address_Line1;
        //            aa.PG_Address_Line2 = item.PG_Address_Line2;
        //            aa.PG_State = item.PG_State;
        //            aa.PG_Country = item.PG_Country;
        //            aa.PG_ZipCode = item.PG_ZipCode;
        //            aa.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
        //            aa.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
        //            aa.PG_Shipping_Address1 = item.PG_Shipping_Address1;
        //            aa.PG_Shipping_Address2 = item.PG_Shipping_Address2;
        //            aa.PG_Shipping_City = item.PG_Shipping_City;
        //            aa.PG_Shipping_State = item.PG_Shipping_State;
        //            aa.PG_Shipping_Country = item.PG_Shipping_Country;
        //            aa.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
        //            aa.PG_Shipping_Phone = item.PG_Shipping_Phone;
        //            aa.PG_Transaction_Fee = item.PG_Transaction_Fee;
        //            aa.PG_Discount = item.PG_Discount;
        //            aa.PG_Additional_Charges = item.PG_Additional_Charges;
        //            aa.PG_Amount_INR = item.PG_Amount_INR;
        //            aa.PG_UDF_1 = item.PG_UDF_1;
        //            aa.PG_UDF_2 = item.PG_UDF_2;
        //            aa.PG_UDF_3 = item.PG_UDF_3;
        //            aa.PG_UDF_4 = item.PG_UDF_4;
        //            aa.PG_UDF_5 = item.PG_UDF_5;

        //            aa.PG_Device_Info = item.PG_Device_Info;
        //            aa.PG_HashKey = item.PG_HashKey;
        //            aa.PG_ServiceProvider = item.PG_ServiceProvider;
        //            aa.Remarks_IfAny = item.Remarks_IfAny;

        //            aa.A_column = item.A_column;
        //            aa.B_column = item.B_column;
        //            aa.C_column = item.C_column;

        //            aa.IsActive = item.IsActive;
        //            aa.IsDraft = item.IsDraft;
        //            aa.IsLock = item.IsLock;
        //            aa.IsPublicView = item.IsPublicView;

        //            aa.CreatedBy = item.CreatedBy;
        //            aa.CreatedOn = item.CreatedOn;
        //            aa.ModifyBy = item.ModifyBy;
        //            aa.ModifyOn = item.ModifyOn;
        //        }
        //    }
        //    return View(aa);
        //}

        #endregion

        #endregion



        #region SINGLE PAGE REVERIFY



        public class ReverifyResult
        {
            public int RetFlag { get; set; }
            public string Message { get; set; }
            public string MsgType { get; set; }
            public int Status { get; set; }
            // --- Diagnostics for detailed logging ---
            public string GatewayTxnId { get; set; }
            public string GatewayTxnStatus { get; set; }
            public string Mihpayid { get; set; }
            public decimal GatewayAmount { get; set; }
            public string GatewayPaymentDate { get; set; }   // "addedon" from PayU response
            public string GatewayUnmappedStatus { get; set; }
            public string SpMethodCalled { get; set; }
            public int DbStatusCode { get; set; }

            public DateTime GatewayCallStartedAt { get; set; }
            public DateTime GatewayCallCompletedAt { get; set; }
            public DateTime SpCallStartedAt { get; set; }
            public DateTime SpCallCompletedAt { get; set; }

            public TimeSpan GatewayCallDuration => GatewayCallCompletedAt - GatewayCallStartedAt;
            public TimeSpan SpCallDuration => SpCallCompletedAt - SpCallStartedAt;

        }

        public static class PaymentReverifyService
        {
            public static ReverifyResult ReverifyTransaction(string gatewayTxnID)
            {
                var result = new ReverifyResult { MsgType = "info" };
                var sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();

                try
                {
                    string command = "verify_payment";
                    string key = ConfigurationManager.AppSettings["payuMerchantKey"];
                    string salt = ConfigurationManager.AppSettings["payuSalt"];
                    string URI = ConfigurationManager.AppSettings["payuApiBaseURL"];

                    var myremoteapipost = new RemotePostAPI();
                    myremoteapipost.Add("key", key);
                    myremoteapipost.Add("salt", salt);
                    myremoteapipost.Add("var1", gatewayTxnID);
                    myremoteapipost.Add("command", command);
                    myremoteapipost.Add("service_provider", "payu");
                    myremoteapipost.Add("hash", Generatehash512($"{key}|{command}|{gatewayTxnID}|{salt}"));
                    string myParameters = myremoteapipost.PostParameters();

                    var myWebRequest = (HttpWebRequest)WebRequest.Create(URI);
                    myWebRequest.KeepAlive = false;
                    myWebRequest.ProtocolVersion = HttpVersion.Version10;
                    myWebRequest.ConnectionGroupName = Guid.NewGuid().ToString();
                    myWebRequest.Timeout = -1;
                    myWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    myWebRequest.Method = "POST";
                    myWebRequest.ContentType = "application/x-www-form-urlencoded";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.Expect100Continue = false;
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    using (var w = new StreamWriter(myWebRequest.GetRequestStream()))
                        w.Write(myParameters);

                    string response;
                    using (var resp = (HttpWebResponse)myWebRequest.GetResponse())
                    using (var stream = resp.GetResponseStream())
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                        response = reader.ReadToEnd();

                    result.GatewayCallStartedAt = DateTime.Now;
                    dynamic array = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    result.GatewayCallCompletedAt = DateTime.Now;

                    string status = array["status"];
                    var txn = array["transaction_details"][gatewayTxnID];
                    string unmappedStatus = txn["unmappedstatus"];
                    result.GatewayUnmappedStatus = unmappedStatus;


                    if (status != "1")
                    {
                        result.Message = "No record found in payment gateway verification.";
                        result.MsgType = "error";
                        return result;
                    }
                    try
                    {
                        result.GatewayPaymentDate = (string)txn["addedon"];
                    }
                    catch
                    {
                        result.GatewayPaymentDate = "exception while fetching success date from payu";
                    }

                    if (unmappedStatus != "captured")
                    {
                        result.Message = unmappedStatus;
                        result.MsgType = (unmappedStatus == "in progress" || unmappedStatus == "pending") ? "warning" : "error";
                        return result;
                    }

                    string mihpayid = txn["mihpayid"], bank_ref_num = txn["bank_ref_num"], pstatus = txn["status"];
                    string bankcode = txn["bankcode"], payment_type = txn["mode"], payment_gateway = txn["PG_TYPE"];
                    string udf1 = txn["udf1"], udf2 = txn["udf2"], udf3 = txn["udf3"], udf4 = txn["udf4"], udf5 = txn["udf5"];
                    decimal amount = txn["amt"], additionalcharges = txn["additional_charges"];

                    result.GatewayTxnId = gatewayTxnID;
                    result.Mihpayid = mihpayid;
                    result.GatewayAmount = amount;

                    if (pstatus != "success")
                    {
                        result.Message = $"Captured but status is '{pstatus}', not success.";
                        result.MsgType = "warning";
                        return result;
                    }

                    //result.SpCallStartedAt = DateTime.Now;
                    //int dbStatus = udf2 == "Complaint Fee (Form-M)"
                    //    ? sdb.Update_ComplaintFormMPaymentGatewayByAPI(gatewayTxnID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5)
                    //    : udf2 == "Complaint Fee (Form-N)"
                    //        ? sdb.Update_ComplaintFormNPaymentGatewayByAPI(gatewayTxnID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5)
                    //        : -1;

                    //result.SpCallCompletedAt = DateTime.Now;
                    //result.DbStatusCode = dbStatus;
                    int dbStatus;
                    switch (udf2)
                    {
                        case "Complaint Fee (Form-M)":
                            result.SpMethodCalled = "Update_ComplaintFormMPaymentGatewayByAPI";
                            result.SpCallStartedAt = DateTime.Now;
                            dbStatus = sdb.Update_ComplaintFormMPaymentGatewayByAPI(gatewayTxnID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5);
                            result.SpCallCompletedAt = DateTime.Now;
                            break;
                        case "Complaint Fee (Form-N)":
                            result.SpMethodCalled = "Update_ComplaintFormNPaymentGatewayByAPI";
                            result.SpCallStartedAt = DateTime.Now;
                            dbStatus = sdb.Update_ComplaintFormNPaymentGatewayByAPI(gatewayTxnID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5);
                            result.SpCallCompletedAt = DateTime.Now;
                            break;
                        default:
                            result.Message = "Invalid payment type.";
                            result.MsgType = "error";
                            return result;
                    }

                    result.RetFlag = dbStatus == 1 ? 1 : 0;
                    result.MsgType = dbStatus == 1 ? "success" : dbStatus == 2 || dbStatus == 0 ? "warning" : "error";
                    result.Message = dbStatus == 1 ? "Payment verified and updated successfully."
                        : dbStatus == 2 ? "Payment was already updated earlier."
                        : dbStatus == 0 ? "Transaction found, but no matching record was available to update."
                        : dbStatus == -1 ? "Invalid payment type."
                        : "An error occurred while updating payment.";
                }
                catch (Exception ex)
                {
                    result.GatewayUnmappedStatus = result.GatewayUnmappedStatus ?? "exception";
                    result.Message = ex.Message;
                    result.MsgType = "error";
                }

                return result;
            }

            private static string Generatehash512(string text)
            {
                byte[] message = Encoding.UTF8.GetBytes(text);

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] hashValue;
                SHA512Managed hashString = new SHA512Managed();
                string hex = "";
                hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                return hex;
            }
        }



        [AllowAnonymous]
        public ActionResult AllComplaintFormMreverify()
        {
            ClsMethod_ComplaintFormM_PaymentIntegration objPayment = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormM_PaymentIntegration prp = new ClsPrp_ComplaintFormM_PaymentIntegration();

            DateTime To_date = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime From_date = DateTime.Now.AddDays(-28).Date;

            prp.ComplaintFormMstepII = objPayment.Display_ComplaintFormM_PaymentReVerify(To_date, From_date);
            return View(prp);
        }

        [AllowAnonymous]
        public ActionResult AllComplaintFormNreverify()
        {
            ClsMethod_ComplaintFormM_PaymentIntegration objPayment = new ClsMethod_ComplaintFormM_PaymentIntegration();
            ClsPrp_ComplaintFormN_PaymentIntegration prp = new ClsPrp_ComplaintFormN_PaymentIntegration();

            DateTime To_date = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime From_date = DateTime.Now.AddDays(-28).Date;

            prp.ComplaintFormNstepII = objPayment.Display_ComplaintFormN_PaymentReVerify(To_date, From_date);
            return View(prp);
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public JsonResult reverifyTxnAPI(string gatewayTxnID)
        //{
        //    int retFlag = 0;
        //    long retValuePaymentRegistration_ID = 0;
        //    long retValuePRN_ID = 0;
        //    long retValuePaymentChallan_ID = 0;
        //    long retValueGateway_ID = 0;

        //    string message = "";
        //    string msgType = "info";

        //    ClsMethod_ComplaintFormM_PaymentIntegration sdb = new ClsMethod_ComplaintFormM_PaymentIntegration();

        //    try
        //    {
        //        string var1 = Convert.ToString(gatewayTxnID);
        //        string command = "verify_payment";

        //        RemotePostAPI myremoteapipost = new RemotePostAPI();

        //        string key = ConfigurationManager.AppSettings["payuMerchantKey"];
        //        string salt = ConfigurationManager.AppSettings["payuSalt"];
        //        string URI = ConfigurationManager.AppSettings["payuApiBaseURL"];
        //        string myParameters = string.Empty;

        //        myremoteapipost.Add("key", key);
        //        myremoteapipost.Add("salt", salt);
        //        myremoteapipost.Add("var1", var1);
        //        myremoteapipost.Add("command", command);
        //        myremoteapipost.Add("service_provider", "payu");

        //        string hashString = key + "|" + command + "|" + var1 + "|" + salt;
        //        string hash = Generatehash512(hashString);
        //        myremoteapipost.Add("hash", hash);
        //        myParameters = myremoteapipost.PostParameters();

        //        HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(URI);
        //        myWebRequest.KeepAlive = false;
        //        myWebRequest.ProtocolVersion = HttpVersion.Version10;
        //        myWebRequest.ConnectionGroupName = Guid.NewGuid().ToString();
        //        myWebRequest.Timeout = -1;
        //        myWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
        //        myWebRequest.Method = "POST";
        //        myWebRequest.ContentType = "application/x-www-form-urlencoded";

        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //        ServicePointManager.Expect100Continue = false;
        //        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        //        using (StreamWriter requestWriter = new StreamWriter(myWebRequest.GetRequestStream()))
        //        {
        //            requestWriter.Write(myParameters);
        //        }

        //        string response;
        //        using (HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse())
        //        using (Stream receiveStream = myWebResponse.GetResponseStream())
        //        using (StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding("utf-8")))
        //        {
        //            response = readStream.ReadToEnd();
        //        }

        //        dynamic array = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

        //        string status = array["status"];
        //        string array3 = array["transaction_details"][gatewayTxnID]["unmappedstatus"];

        //        string array4 = array["transaction_details"][gatewayTxnID]["udf3"];
        //        string array5 = array["transaction_details"][gatewayTxnID]["udf1"];
        //        string array6 = array["transaction_details"][gatewayTxnID]["udf4"];
        //        string array7 = array["transaction_details"][gatewayTxnID]["udf5"];

        //        string mihpayid = array["transaction_details"][gatewayTxnID]["mihpayid"];
        //        string bank_ref_num = array["transaction_details"][gatewayTxnID]["bank_ref_num"];
        //        decimal amount = array["transaction_details"][gatewayTxnID]["amt"];
        //        string pstatus = array["transaction_details"][gatewayTxnID]["status"];
        //        decimal additionalcharges = array["transaction_details"][gatewayTxnID]["additional_charges"];
        //        string bankcode = array["transaction_details"][gatewayTxnID]["bankcode"];
        //        string payment_type = array["transaction_details"][gatewayTxnID]["mode"];
        //        string payment_gateway = array["transaction_details"][gatewayTxnID]["PG_TYPE"];
        //        string udf1 = array["transaction_details"][gatewayTxnID]["udf1"];
        //        string udf2 = array["transaction_details"][gatewayTxnID]["udf2"];
        //        string udf3 = array["transaction_details"][gatewayTxnID]["udf3"];
        //        string udf4 = array["transaction_details"][gatewayTxnID]["udf4"];
        //        string udf5 = array["transaction_details"][gatewayTxnID]["udf5"];

        //        switch (udf2)
        //        {
        //            case "Complaint Fee (Form-M)":
        //                if (status == "1")
        //                {
        //                    if (array3 == "captured")
        //                    {
        //                        retFlag = 1;

        //                        retValuePaymentRegistration_ID = Convert.ToInt64(string.IsNullOrEmpty(array4) ? "0" : array4);
        //                        retValuePRN_ID = Convert.ToInt64(string.IsNullOrEmpty(array5) ? "0" : array5);
        //                        retValuePaymentChallan_ID = Convert.ToInt64(string.IsNullOrEmpty(array6) ? "0" : array6);
        //                        retValueGateway_ID = Convert.ToInt64(string.IsNullOrEmpty(array7) ? "0" : array7);

        //                        int dbStatus = sdb.Update_ComplaintFormMPaymentGatewayByAPI(gatewayTxnID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5);

        //                        if (dbStatus == 1)
        //                        {
        //                            message = "Payment verified and updated successfully.";
        //                            msgType = "success";
        //                        }
        //                        else if (dbStatus == 2)
        //                        {
        //                            message = "Payment was already updated earlier.";
        //                            msgType = "warning";
        //                        }
        //                        else if (dbStatus == 0)
        //                        {
        //                            message = "Transaction found, but no matching record was available to update.";
        //                            msgType = "warning";
        //                        }
        //                        else
        //                        {
        //                            message = "An error occurred while updating payment.";
        //                            msgType = "error";
        //                        }
        //                    }
        //                    else if (array3 == "userCancelled" || array3 == "bounced" || array3 == "dropped" || array3 == "failed")
        //                    {
        //                        //retFlag = 0;
        //                        //sdb.Update_statusComplaintFormMPaymentGatewayByAPI(gatewayTxnID);
        //                        message = array3;
        //                        msgType = "error";

        //                    }
        //                    else if (array3 == "in progress" || array3 == "pending")
        //                    {
        //                        //retFlag = 0;
        //                        message = array3;
        //                        msgType = "warning";
        //                    }
        //                    else
        //                    {
        //                        //retFlag = 0;
        //                        message = array3;
        //                        msgType = "warning";
        //                    }
        //                }
        //                else
        //                {
        //                    retFlag = 0;
        //                    message = "No record found in payment gateway verification.";
        //                    msgType = "error";
        //                }
        //                break;

        //            case "Complaint Fee (Form-N)":
        //                if (status == "1")
        //                {
        //                    if (array3 == "captured")
        //                    {
        //                        retFlag = 1;

        //                        retValuePaymentRegistration_ID = Convert.ToInt64(string.IsNullOrEmpty(array4) ? "0" : array4);
        //                        retValuePRN_ID = Convert.ToInt64(string.IsNullOrEmpty(array5) ? "0" : array5);
        //                        retValuePaymentChallan_ID = Convert.ToInt64(string.IsNullOrEmpty(array6) ? "0" : array6);
        //                        retValueGateway_ID = Convert.ToInt64(string.IsNullOrEmpty(array7) ? "0" : array7);

        //                        int dbStatus = sdb.Update_ComplaintFormNPaymentGatewayByAPI(gatewayTxnID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges, bankcode, payment_type, payment_gateway, udf1, udf2, udf3, udf4, udf5);

        //                        if (dbStatus == 1)
        //                        {
        //                            message = "Payment verified and updated successfully.";
        //                            msgType = "success";
        //                        }
        //                        else if (dbStatus == 2)
        //                        {
        //                            message = "Payment was already updated earlier.";
        //                            msgType = "warning";
        //                        }
        //                        else if (dbStatus == 0)
        //                        {
        //                            message = "Transaction found, but no matching record was available to update.";
        //                            msgType = "warning";
        //                        }
        //                        else
        //                        {
        //                            message = "An error occurred while updating payment.";
        //                            msgType = "error";
        //                        }
        //                    }
        //                    else if (array3 == "userCancelled" || array3 == "bounced" || array3 == "dropped" || array3 == "failed")
        //                    {
        //                        //retFlag = 0;
        //                        //sdb.Update_statusComplaintFormNPaymentGatewayByAPI(gatewayTxnID);
        //                        message = array3;
        //                        msgType = "error";

        //                    }
        //                    else if (array3 == "in progress" || array3 == "pending")
        //                    {
        //                        //retFlag = 0;
        //                        message = array3;
        //                        msgType = "warning";
        //                    }
        //                    else
        //                    {
        //                        //retFlag = 0;
        //                        message = array3;
        //                        msgType = "warning";
        //                    }
        //                }
        //                else
        //                {
        //                    retFlag = 0;
        //                    message = "No record found in payment gateway verification.";
        //                    msgType = "error";
        //                }
        //                break;

        //            default:
        //                retFlag = 0;
        //                message = "Invalid payment type.";
        //                msgType = "error";
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //        msgType = "error";
        //    }

        //    return Json(new
        //    {
        //        message = message,
        //        type = msgType
        //    }, JsonRequestBehavior.AllowGet);
        //}
        [AllowAnonymous]
        [HttpGet]
        public JsonResult reverifyTxnAPI(string gatewayTxnID)
        {
            var result = PaymentReverifyService.ReverifyTransaction(gatewayTxnID);
            return Json(new { message = result.Message, type = result.MsgType }, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}
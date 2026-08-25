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
using CRUD.Models.classAgentPayment;
using CRUD.Models.Complaint;
//using CRUD.Models.Master;
//using CRUD.Models.PromoterProject;
using CRUD.Models.Promoter;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Net.Security;
using System.Net.Cache;
using CRUD.Models.AgentPayment;

namespace CRUD.Controllers.classAgentPayment
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentPaymentController : Controller
    {
        public string HtmlResult { get; private set; }
        #region Remote Post and Txn Generation

        //Remote Post
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

        ////Hash generation Algorithm
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

        //random transition id generation
        public string Generatetxnid()
        {
            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }

        //Remote API Post Parms
        public class RemotePostAPI
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();

            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }

            public string PostParameters()
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    if (i < Inputs.Keys.Count - 1)
                    {
                        builder.Append(string.Format(Inputs.Keys[i] + "=" + Inputs[Inputs.Keys[i]] + "&"));
                    }
                    else
                    {
                        builder.Append(string.Format(Inputs.Keys[i] + "=" + Inputs[Inputs.Keys[i]]));
                    }
                }
                string innerString = builder.ToString();
                return innerString;
            }
        }

        #endregion

        #region ePaymeny Input AgentApplication

        [HttpGet]
        public ActionResult RequestAgentApplicationPayment()
        {
            ClsPrp_AgentApplication_PaymentIntegration objAppPayment = new ClsPrp_AgentApplication_PaymentIntegration();
            ClsMethod_AgentApplication_PaymentIntegration objPayment = new ClsMethod_AgentApplication_PaymentIntegration();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_AgentApplication_Ind_OTInd objAgentApp = new ClsPrp_AgentApplication_Ind_OTInd();
            ClsPrp_AgentPayment objgetPayment = new ClsPrp_AgentPayment();

            Int64 AgentApplicationID = 0;
            Int64 AgentApplicationPaymentID = 0;
            Int64 AgentApplicationPaymentIndexID = 0;
            Int64 PaymentID = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    AgentApplicationID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            if (Session["RequestAgentPaymentID"] != null)
            {
                if (Session["RequestAgentPaymentID"].ToString() != "0")
                {
                    PaymentID = Convert.ToInt64(Session["RequestAgentPaymentID"]);
                }
            }

            objAgentApp.AgentApplication = objPayment.Display_AgentApplication_ProfileByID(AgentApplicationID);
            if (objAgentApp.AgentApplication.Count >= 1)
            {
                foreach (var item in objAgentApp.AgentApplication)
                {
                    #region parameters
                    objAgentApp.ID = item.ID;
                    objAgentApp.Agent_ID = item.Agent_ID;
                    objAgentApp.Agent_Type = item.Agent_Type;
                    objAgentApp.IsAlready_RERANumber = item.IsAlready_RERANumber;
                    objAgentApp.Existing_RERANumber = item.Existing_RERANumber;
                    objAgentApp.Agent_FirstName = item.Agent_FirstName;
                    objAgentApp.Agent_MiddleName = item.Agent_MiddleName;
                    objAgentApp.Agent_LastName = item.Agent_LastName;
                    objAgentApp.Father_FirstName = item.Father_FirstName;
                    objAgentApp.Father_MiddleName = item.Father_MiddleName;
                    objAgentApp.Father_LastName = item.Father_LastName;
                    objAgentApp.Occupation = item.Occupation;
                    objAgentApp.Image_FileName = item.Image_FileName;
                    objAgentApp.Image_FilePath = item.Image_FilePath;
                    objAgentApp.P_AddressLine1 = item.P_AddressLine1;
                    objAgentApp.P_AddressLine2 = item.P_AddressLine2;
                    objAgentApp.P_AddressStateCode = item.P_AddressStateCode;
                    objAgentApp.P_AddressDistrictCode = item.P_AddressDistrictCode;
                    objAgentApp.P_AddressPIN = item.P_AddressPIN;
                    objAgentApp.Organization_Name = item.Organization_Name;
                    objAgentApp.Organization_TypeCode = item.Organization_TypeCode;
                    objAgentApp.Organization_MainObjects = item.Organization_MainObjects;
                    objAgentApp.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    objAgentApp.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    objAgentApp.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                    objAgentApp.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                    objAgentApp.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                    objAgentApp.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    objAgentApp.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    objAgentApp.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    objAgentApp.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    objAgentApp.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                    objAgentApp.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                    objAgentApp.BComm_AddressLine1 = item.BComm_AddressLine1;
                    objAgentApp.BComm_AddressLine2 = item.BComm_AddressLine2;
                    objAgentApp.BComm_AddressStateCode = item.BComm_AddressStateCode;
                    objAgentApp.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    objAgentApp.BComm_AddressPIN = item.BComm_AddressPIN;
                    objAgentApp.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                    objAgentApp.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    objAgentApp.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                    objAgentApp.MobileNumber = item.MobileNumber;
                    objAgentApp.PhoneNumber_STD = item.PhoneNumber_STD;
                    objAgentApp.PhoneNumber_Number = item.PhoneNumber_Number;
                    objAgentApp.EmailAddress = item.EmailAddress;
                    objAgentApp.PAN_Number = item.PAN_Number;
                    objAgentApp.Aadhaar_Number = item.Aadhaar_Number;
                    objAgentApp.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                    objAgentApp.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;
                    objAgentApp.Remarks_IfAny = item.Remarks_IfAny;
                    objAgentApp.A_column = item.A_column;
                    objAgentApp.B_column = item.B_column;
                    objAgentApp.C_column = item.C_column;
                    objAgentApp.IsActive = item.IsActive;
                    objAgentApp.IsDraft = item.IsDraft;
                    objAgentApp.CreatedBy = item.CreatedBy;
                    objAgentApp.CreatedOn = item.CreatedOn;
                    objAgentApp.ModifyBy = item.ModifyBy;
                    objAgentApp.ModifyOn = item.ModifyOn;
                    #endregion
                }
            }

            // check from mySQLdb and payudb server for getdetailpayment
            // if yes then getdetail cshtml page table data show 
            // (firstly check sqldb and secondly check payu API service)

            objAppPayment.AgentPayment = objPayment.Display_AgentApplication_PaymentById(AgentApplicationID, AgentApplicationPaymentIndexID, AgentApplicationPaymentID, PaymentID);
            if (objAppPayment.AgentPayment.Count >= 1)
            {
                foreach (var item in objAppPayment.AgentPayment)
                {
                    #region parameters
                    objAppPayment.PaymentRefNumberAgent_IndexID = item.PaymentRefNumberAgent_IndexID;
                    objAppPayment.PaymentRefNumberAgent_ID = item.PaymentRefNumberAgent_ID;
                    objAppPayment.RelatedAgent_ID = item.RelatedAgent_ID;
                    objAppPayment.RelatedAgent_Code = item.RelatedAgent_Code;
                    objAppPayment.RelatedPayment_ID = item.RelatedPayment_ID;
                    objAppPayment.User_ID = item.User_ID;

                    objAppPayment.AgentType_IO = item.AgentType_IO;
                    objAppPayment.User_Name = item.User_Name;
                    objAppPayment.Agent_BriefSummary = item.Agent_BriefSummary;
                    objAppPayment.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    objAppPayment.PaymentSuccessDate = item.PaymentSuccessDate;
                    objAppPayment.FailureSuccessSummary = item.FailureSuccessSummary;

                    objAppPayment.PG_Transaction_ID = item.PG_Transaction_ID;
                    objAppPayment.PG_Date = item.PG_Date;
                    objAppPayment.PG_PayU_ID = item.PG_PayU_ID;
                    objAppPayment.PG_Amount = item.PG_Amount; //Amount INR
                    objAppPayment.PG_Status = item.PG_Status;
                    objAppPayment.PG_Product_Info = item.PG_Product_Info; //Product Info
                    objAppPayment.PG_Customer_Name = item.PG_Customer_Name; //Name
                    objAppPayment.PG_Last_Name = item.PG_Last_Name;
                    objAppPayment.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    objAppPayment.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    objAppPayment.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    objAppPayment.PG_City = item.PG_City;
                    objAppPayment.PG_Merchant_Name = item.PG_Merchant_Name;
                    objAppPayment.PG_Bank_Name = item.PG_Bank_Name;
                    objAppPayment.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    objAppPayment.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    objAppPayment.PG_International_Domestic = item.PG_International_Domestic;
                    objAppPayment.PG_Payment_Type = item.PG_Payment_Type;
                    objAppPayment.PG_Error_Code = item.PG_Error_Code;
                    objAppPayment.PG_Error_Message = item.PG_Error_Message;
                    objAppPayment.PG_Name_on_Card = item.PG_Name_on_Card;
                    objAppPayment.PG_Card_Number = item.PG_Card_Number;
                    objAppPayment.PG_Address_Line1 = item.PG_Address_Line1;
                    objAppPayment.PG_Address_Line2 = item.PG_Address_Line2;
                    objAppPayment.PG_State = item.PG_State;
                    objAppPayment.PG_Country = item.PG_Country;
                    objAppPayment.PG_ZipCode = item.PG_ZipCode;
                    objAppPayment.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    objAppPayment.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    objAppPayment.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    objAppPayment.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    objAppPayment.PG_Shipping_City = item.PG_Shipping_City;
                    objAppPayment.PG_Shipping_State = item.PG_Shipping_State;
                    objAppPayment.PG_Shipping_Country = item.PG_Shipping_Country;
                    objAppPayment.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    objAppPayment.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    objAppPayment.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    objAppPayment.PG_Discount = item.PG_Discount;
                    objAppPayment.PG_Additional_Charges = item.PG_Additional_Charges;
                    objAppPayment.PG_Amount_INR = item.PG_Amount_INR;
                    objAppPayment.PG_UDF_1 = item.PG_UDF_1;
                    objAppPayment.PG_UDF_2 = item.PG_UDF_2;
                    objAppPayment.PG_UDF_3 = item.PG_UDF_3;
                    objAppPayment.PG_UDF_4 = item.PG_UDF_4;
                    objAppPayment.PG_UDF_5 = item.PG_UDF_5;

                    objAppPayment.PG_Device_Info = item.PG_Device_Info;
                    objAppPayment.PG_HashKey = item.PG_HashKey;
                    objAppPayment.PG_ServiceProvider = item.PG_ServiceProvider;
                    objAppPayment.Remarks_IfAny = item.Remarks_IfAny;

                    objAppPayment.A_column = item.A_column;
                    objAppPayment.B_column = item.B_column;
                    objAppPayment.C_column = item.C_column;

                    objAppPayment.IsActive = item.IsActive;
                    objAppPayment.IsDraft = item.IsDraft;
                    objAppPayment.IsLock = item.IsLock;
                    objAppPayment.IsPublicView = item.IsPublicView;

                    objAppPayment.CreatedBy = item.CreatedBy;
                    objAppPayment.CreatedOn = item.CreatedOn;
                    objAppPayment.ModifyBy = item.ModifyBy;
                    objAppPayment.ModifyOn = item.ModifyOn;
                    #endregion
                }

                if (objAppPayment.IsPaymentSuccessComplete == 0 || objAppPayment.IsPaymentSuccessComplete == 2)
                {
                    // PayU API Check - Payment Status By TxnID 
                    Tuple<int, long, long, long> tptemp = getPaymentDetailsByTxnAPI(objAppPayment.PG_Transaction_ID);
                    if (tptemp.Item1 == 1)
                    {
                        // Payment - Done But Confirmation Pending
                        TempData["submitvalueAgentAppPayment"] = "Proceed"; TempData.Keep();
                        return RedirectToAction("getagentapplicationpayment", "AgentPayment");
                    }
                    else
                    {
                        // Payment - Pending OR Failure
                        TempData["submitvalueAgentAppPayment"] = "Make Payment"; TempData.Keep();
                    }
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueAgentAppPayment"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                objgetPayment.AgentPayment = objPayment.Display_AgentPaymentDetailsByID(AgentApplicationID, PaymentID);
                if (objgetPayment.AgentPayment.Count >= 1)
                {
                    foreach (var item in objgetPayment.AgentPayment)
                    {
                        #region parameters
                        objgetPayment.AgentPayment_IndexID = item.AgentPayment_IndexID;
                        objgetPayment.AgentPayment_ID = item.AgentPayment_ID;
                        objgetPayment.Agent_ID = item.Agent_ID;
                        objgetPayment.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                        objgetPayment.AgentPayment_TitleName = item.AgentPayment_TitleName;
                        objgetPayment.Registration_Fee = item.Registration_Fee;
                        objgetPayment.Other_Fee = item.Other_Fee;
                        objgetPayment.Payment_Mode = item.Payment_Mode;
                        objgetPayment.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                        objgetPayment.Bank_Charges = item.Bank_Charges;
                        objgetPayment.Bank_Name = item.Bank_Name;
                        objgetPayment.Branch_Name = item.Branch_Name;
                        objgetPayment.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                        objgetPayment.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                        objgetPayment.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                        objgetPayment.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;
                        objgetPayment.Remarks_IfAny = item.Remarks_IfAny;

                        objgetPayment.A_column = item.A_column;
                        objgetPayment.B_column = item.B_column;
                        objgetPayment.C_column = item.C_column;

                        objgetPayment.IsActive = item.IsActive;
                        objgetPayment.IsDraft = item.IsDraft;
                        objgetPayment.CreatedBy = item.CreatedBy;
                        objgetPayment.CreatedOn = item.CreatedOn;
                        objgetPayment.ModifyBy = item.ModifyBy;
                        objgetPayment.ModifyOn = item.ModifyOn;
                        #endregion
                    }
                    #region parameters
                    //No records found - table Payment Form M 
                    objAppPayment.PaymentRefNumberAgent_IndexID = 0;
                    objAppPayment.PaymentRefNumberAgent_ID = 0;
                    objAppPayment.RelatedAgent_ID = objAgentApp.Agent_ID;
                    objAppPayment.RelatedAgent_Code = Convert.ToString(objAgentApp.Agent_ID);
                    objAppPayment.RelatedPayment_ID = PaymentID; // session or query string
                    objAppPayment.AgentType_IO = Convert.ToString(objAgentApp.Agent_Type); // "Ind or OtherThanInd";

                    objAppPayment.User_ID = UID;
                    objAppPayment.User_Name = userName;

                    objAppPayment.PG_Shipping_Address1 = objAgentApp.BComm_AddressLine1;
                    objAppPayment.PG_Shipping_Address2 = objAgentApp.BComm_AddressLine2;
                    objAppPayment.PG_Shipping_City = objdis.District_Name(Convert.ToInt32(objAgentApp.BComm_AddressDistrictCode));
                    objAppPayment.PG_Shipping_State = objdis.State_Name(Convert.ToInt32(objAgentApp.BComm_AddressStateCode));
                    objAppPayment.PG_Shipping_Country = "India";
                    objAppPayment.PG_Shipping_Zipcode = Convert.ToString(objAgentApp.BComm_AddressPIN);
                    objAppPayment.PG_Shipping_Phone = Convert.ToString(objAgentApp.MobileNumber);

                    objAppPayment.PG_Customer_Email = objAgentApp.EmailAddress; //Email ID
                    objAppPayment.PG_Customer_Phone = Convert.ToString(objAgentApp.MobileNumber); //Phone/Mobile 

                    objAppPayment.PG_Address_Line1 = objAgentApp.BComm_AddressLine1;
                    objAppPayment.PG_Address_Line2 = objAgentApp.BComm_AddressLine2;
                    objAppPayment.PG_City = objdis.District_Name(Convert.ToInt32(objAgentApp.BComm_AddressDistrictCode));
                    objAppPayment.PG_State = objdis.State_Name(Convert.ToInt32(objAgentApp.BComm_AddressStateCode));
                    objAppPayment.PG_Country = "India";
                    objAppPayment.PG_ZipCode = Convert.ToString(objAgentApp.BComm_AddressPIN);

                    if (objAgentApp.Agent_Type == 1)
                    {
                        string PaymentTypeUDF2 = string.Empty;
                        if (objgetPayment.AgentPayment_TitleCode == 1)
                        {
                            PaymentTypeUDF2 = "Application Fee (Agent Individual Registration)";
                        }
                        objAppPayment.PG_Product_Info = PaymentTypeUDF2;
                        objAppPayment.PG_Transaction_Fee = 0;
                        objAppPayment.PG_Discount = 0;
                        objAppPayment.PG_Additional_Charges = 0;
                        objAppPayment.PG_Amount_INR = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Amount = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                        objAppPayment.PG_Shipping_Firstname = objAgentApp.Agent_FirstName + " " + objAgentApp.Agent_MiddleName;
                        objAppPayment.PG_Shipping_Lastname = objAgentApp.Agent_LastName;
                        objAppPayment.PG_Customer_Name = objAgentApp.Agent_FirstName + " " + objAgentApp.Agent_MiddleName; //Name
                        objAppPayment.PG_Last_Name = objAgentApp.Agent_LastName;
                    }
                    else if (objAgentApp.Agent_Type == 2)
                    {
                        string PaymentTypeUDF2 = string.Empty;
                        if (objgetPayment.AgentPayment_TitleCode == 1)
                        {
                            PaymentTypeUDF2 = "Application Fee (Agent Other Than Individual Registration)";
                        }
                        objAppPayment.PG_Product_Info = PaymentTypeUDF2;
                        objAppPayment.PG_Transaction_Fee = 0;
                        objAppPayment.PG_Discount = 0;
                        objAppPayment.PG_Additional_Charges = 0;
                        objAppPayment.PG_Amount_INR = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Amount = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                        objAppPayment.PG_Shipping_Firstname = objAgentApp.AuthorizedSignatory_FirstName;
                        objAppPayment.PG_Shipping_Lastname = objAgentApp.AuthorizedSignatory_LastName;
                        objAppPayment.PG_Customer_Name = objAgentApp.AuthorizedSignatory_FirstName; //Name
                        objAppPayment.PG_Last_Name = objAgentApp.AuthorizedSignatory_LastName;
                    }
                    #endregion
                }
                TempData["submitvalueAgentAppPayment"] = "Make Payment"; TempData.Keep();
            }
            return View("RequestAgentApplicationPayment", objAppPayment);
        }

        [HttpGet]
        public ActionResult Detail_RequestAgentApplicationPayment(Int64? RelatedPaymentCode)
        {
            ClsPrp_AgentApplication_PaymentIntegration objAppPayment = new ClsPrp_AgentApplication_PaymentIntegration();
            ClsMethod_AgentApplication_PaymentIntegration objPayment = new ClsMethod_AgentApplication_PaymentIntegration();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_AgentApplication_Ind_OTInd objAgentApp = new ClsPrp_AgentApplication_Ind_OTInd();
            ClsPrp_AgentPayment objgetPayment = new ClsPrp_AgentPayment();

            Int64 AgentApplicationID = 0;
            Int64 AgentApplicationPaymentID = 0;
            Int64 AgentApplicationPaymentIndexID = 0;
            Int64 PaymentID = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (RelatedPaymentCode != null)
            {
                if (RelatedPaymentCode.ToString() != "0")
                {
                    PaymentID = Convert.ToInt64(RelatedPaymentCode);
                    Session["RequestAgentPaymentID"] = PaymentID;
                }
            }

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    AgentApplicationID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            objAgentApp.AgentApplication = objPayment.Display_AgentApplication_ProfileByID(AgentApplicationID);
            if (objAgentApp.AgentApplication.Count >= 1)
            {
                foreach (var item in objAgentApp.AgentApplication)
                {
                    #region paramerters
                    objAgentApp.ID = item.ID;
                    objAgentApp.Agent_ID = item.Agent_ID;
                    objAgentApp.Agent_Type = item.Agent_Type;
                    objAgentApp.IsAlready_RERANumber = item.IsAlready_RERANumber;
                    objAgentApp.Existing_RERANumber = item.Existing_RERANumber;
                    objAgentApp.Agent_FirstName = item.Agent_FirstName;
                    objAgentApp.Agent_MiddleName = item.Agent_MiddleName;
                    objAgentApp.Agent_LastName = item.Agent_LastName;
                    objAgentApp.Father_FirstName = item.Father_FirstName;
                    objAgentApp.Father_MiddleName = item.Father_MiddleName;
                    objAgentApp.Father_LastName = item.Father_LastName;
                    objAgentApp.Occupation = item.Occupation;
                    objAgentApp.Image_FileName = item.Image_FileName;
                    objAgentApp.Image_FilePath = item.Image_FilePath;
                    objAgentApp.P_AddressLine1 = item.P_AddressLine1;
                    objAgentApp.P_AddressLine2 = item.P_AddressLine2;
                    objAgentApp.P_AddressStateCode = item.P_AddressStateCode;
                    objAgentApp.P_AddressDistrictCode = item.P_AddressDistrictCode;
                    objAgentApp.P_AddressPIN = item.P_AddressPIN;
                    objAgentApp.Organization_Name = item.Organization_Name;
                    objAgentApp.Organization_TypeCode = item.Organization_TypeCode;
                    objAgentApp.Organization_MainObjects = item.Organization_MainObjects;
                    objAgentApp.RegOffice_AddressLine1 = item.RegOffice_AddressLine1;
                    objAgentApp.RegOffice_AddressLine2 = item.RegOffice_AddressLine2;
                    objAgentApp.RegOffice_AddressStateCode = item.RegOffice_AddressStateCode;
                    objAgentApp.RegOffice_AddressDistrictCode = item.RegOffice_AddressDistrictCode;
                    objAgentApp.RegOffice_AddressPIN = item.RegOffice_AddressPIN;
                    objAgentApp.BusinessPlace_AddressLine1 = item.BusinessPlace_AddressLine1;
                    objAgentApp.BusinessPlace_AddressLine2 = item.BusinessPlace_AddressLine2;
                    objAgentApp.BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    objAgentApp.BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    objAgentApp.BusinessPlace_AddressPIN = item.BusinessPlace_AddressPIN;
                    objAgentApp.IsSameBussinessAdd_CommAdd = item.IsSameBussinessAdd_CommAdd;
                    objAgentApp.BComm_AddressLine1 = item.BComm_AddressLine1;
                    objAgentApp.BComm_AddressLine2 = item.BComm_AddressLine2;
                    objAgentApp.BComm_AddressStateCode = item.BComm_AddressStateCode;
                    objAgentApp.BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    objAgentApp.BComm_AddressPIN = item.BComm_AddressPIN;
                    objAgentApp.AuthorizedSignatory_FirstName = item.AuthorizedSignatory_FirstName;
                    objAgentApp.AuthorizedSignatory_MiddleName = item.AuthorizedSignatory_MiddleName;
                    objAgentApp.AuthorizedSignatory_LastName = item.AuthorizedSignatory_LastName;
                    objAgentApp.MobileNumber = item.MobileNumber;
                    objAgentApp.PhoneNumber_STD = item.PhoneNumber_STD;
                    objAgentApp.PhoneNumber_Number = item.PhoneNumber_Number;
                    objAgentApp.EmailAddress = item.EmailAddress;
                    objAgentApp.PAN_Number = item.PAN_Number;
                    objAgentApp.Aadhaar_Number = item.Aadhaar_Number;
                    objAgentApp.IsOtherOrganizationMembers = item.IsOtherOrganizationMembers;
                    objAgentApp.IsOtherStateUT_RERAregistration = item.IsOtherStateUT_RERAregistration;
                    objAgentApp.Remarks_IfAny = item.Remarks_IfAny;
                    objAgentApp.A_column = item.A_column;
                    objAgentApp.B_column = item.B_column;
                    objAgentApp.C_column = item.C_column;
                    objAgentApp.IsActive = item.IsActive;
                    objAgentApp.IsDraft = item.IsDraft;
                    objAgentApp.CreatedBy = item.CreatedBy;
                    objAgentApp.CreatedOn = item.CreatedOn;
                    objAgentApp.ModifyBy = item.ModifyBy;
                    objAgentApp.ModifyOn = item.ModifyOn;
                    #endregion
                }
            }

            // check from mySQLdb and payudb server for getdetailpayment
            // if yes then getdetail cshtml page table data show 
            // (firstly check sqldb and secondly check payu API service)

            objAppPayment.AgentPayment = objPayment.Display_AgentApplication_PaymentById(AgentApplicationID, AgentApplicationPaymentIndexID, AgentApplicationPaymentID, PaymentID);
            // PRN Exist - Case
            if (objAppPayment.AgentPayment.Count >= 1)
            {
                foreach (var item in objAppPayment.AgentPayment)
                {
                    #region paramerters
                    objAppPayment.PaymentRefNumberAgent_IndexID = item.PaymentRefNumberAgent_IndexID;
                    objAppPayment.PaymentRefNumberAgent_ID = item.PaymentRefNumberAgent_ID;
                    objAppPayment.RelatedAgent_ID = item.RelatedAgent_ID;
                    objAppPayment.RelatedAgent_Code = item.RelatedAgent_Code;
                    objAppPayment.RelatedPayment_ID = item.RelatedPayment_ID;
                    objAppPayment.User_ID = item.User_ID;

                    objAppPayment.AgentType_IO = item.AgentType_IO;
                    objAppPayment.User_Name = item.User_Name;
                    objAppPayment.Agent_BriefSummary = item.Agent_BriefSummary;
                    objAppPayment.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    objAppPayment.PaymentSuccessDate = item.PaymentSuccessDate;
                    objAppPayment.FailureSuccessSummary = item.FailureSuccessSummary;

                    objAppPayment.PG_Transaction_ID = item.PG_Transaction_ID;
                    objAppPayment.PG_Date = item.PG_Date;
                    objAppPayment.PG_PayU_ID = item.PG_PayU_ID;
                    objAppPayment.PG_Amount = item.PG_Amount; //Amount INR
                    objAppPayment.PG_Status = item.PG_Status;
                    objAppPayment.PG_Product_Info = item.PG_Product_Info; //Product Info
                    objAppPayment.PG_Customer_Name = item.PG_Customer_Name; //Name
                    objAppPayment.PG_Last_Name = item.PG_Last_Name;
                    objAppPayment.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    objAppPayment.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    objAppPayment.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    objAppPayment.PG_City = item.PG_City;
                    objAppPayment.PG_Merchant_Name = item.PG_Merchant_Name;
                    objAppPayment.PG_Bank_Name = item.PG_Bank_Name;
                    objAppPayment.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    objAppPayment.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    objAppPayment.PG_International_Domestic = item.PG_International_Domestic;
                    objAppPayment.PG_Payment_Type = item.PG_Payment_Type;
                    objAppPayment.PG_Error_Code = item.PG_Error_Code;
                    objAppPayment.PG_Error_Message = item.PG_Error_Message;
                    objAppPayment.PG_Name_on_Card = item.PG_Name_on_Card;
                    objAppPayment.PG_Card_Number = item.PG_Card_Number;
                    objAppPayment.PG_Address_Line1 = item.PG_Address_Line1;
                    objAppPayment.PG_Address_Line2 = item.PG_Address_Line2;
                    objAppPayment.PG_State = item.PG_State;
                    objAppPayment.PG_Country = item.PG_Country;
                    objAppPayment.PG_ZipCode = item.PG_ZipCode;
                    objAppPayment.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    objAppPayment.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    objAppPayment.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    objAppPayment.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    objAppPayment.PG_Shipping_City = item.PG_Shipping_City;
                    objAppPayment.PG_Shipping_State = item.PG_Shipping_State;
                    objAppPayment.PG_Shipping_Country = item.PG_Shipping_Country;
                    objAppPayment.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    objAppPayment.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    objAppPayment.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    objAppPayment.PG_Discount = item.PG_Discount;
                    objAppPayment.PG_Additional_Charges = item.PG_Additional_Charges;
                    objAppPayment.PG_Amount_INR = item.PG_Amount_INR;
                    objAppPayment.PG_UDF_1 = item.PG_UDF_1;
                    objAppPayment.PG_UDF_2 = item.PG_UDF_2;
                    objAppPayment.PG_UDF_3 = item.PG_UDF_3;
                    objAppPayment.PG_UDF_4 = item.PG_UDF_4;
                    objAppPayment.PG_UDF_5 = item.PG_UDF_5;

                    objAppPayment.PG_Device_Info = item.PG_Device_Info;
                    objAppPayment.PG_HashKey = item.PG_HashKey;
                    objAppPayment.PG_ServiceProvider = item.PG_ServiceProvider;
                    objAppPayment.Remarks_IfAny = item.Remarks_IfAny;

                    objAppPayment.A_column = item.A_column;
                    objAppPayment.B_column = item.B_column;
                    objAppPayment.C_column = item.C_column;

                    objAppPayment.IsActive = item.IsActive;
                    objAppPayment.IsDraft = item.IsDraft;
                    objAppPayment.IsLock = item.IsLock;
                    objAppPayment.IsPublicView = item.IsPublicView;

                    objAppPayment.CreatedBy = item.CreatedBy;
                    objAppPayment.CreatedOn = item.CreatedOn;
                    objAppPayment.ModifyBy = item.ModifyBy;
                    objAppPayment.ModifyOn = item.ModifyOn;
                    #endregion
                }
                // PRN - Check Case
                if (objAppPayment.IsPaymentSuccessComplete == 0 || objAppPayment.IsPaymentSuccessComplete == 2)
                {
                    // PayU API Check - Payment Status By TxnID 
                    Tuple<int, long, long, long> tptemp = getPaymentDetailsByTxnAPI(objAppPayment.PG_Transaction_ID);

                    if (tptemp.Item1 == 1)
                    {
                        // Payment - Done But Confirmation Pending
                        TempData["submitvalueAgentAppPayment"] = "Proceed"; TempData.Keep();
                        // Payment - Confirm Action
                        return RedirectToAction("getagentapplicationpayment", "AgentPayment");
                    }
                    else
                    {
                        // Payment - Pending OR Failure
                        TempData["submitvalueAgentAppPayment"] = "Make Payment"; TempData.Keep();
                    }
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueAgentAppPayment"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                //New Payment Case (AgentPayment Details + Payment Setting Details) 
                objgetPayment.AgentPayment = objPayment.Display_AgentPaymentDetailsByID(AgentApplicationID, PaymentID);
                if (objgetPayment.AgentPayment.Count >= 1)
                {
                    foreach (var item in objgetPayment.AgentPayment)
                    {
                        #region paramerters
                        objgetPayment.AgentPayment_IndexID = item.AgentPayment_IndexID;
                        objgetPayment.AgentPayment_ID = item.AgentPayment_ID;
                        objgetPayment.Agent_ID = item.Agent_ID;
                        objgetPayment.AgentPayment_TitleCode = item.AgentPayment_TitleCode;
                        objgetPayment.AgentPayment_TitleName = item.AgentPayment_TitleName;
                        objgetPayment.Registration_Fee = item.Registration_Fee;
                        objgetPayment.Other_Fee = item.Other_Fee;
                        objgetPayment.Payment_Mode = item.Payment_Mode;
                        objgetPayment.Date_of_Payment_RegistrationFee = item.Date_of_Payment_RegistrationFee;
                        objgetPayment.Bank_Charges = item.Bank_Charges;
                        objgetPayment.Bank_Name = item.Bank_Name;
                        objgetPayment.Branch_Name = item.Branch_Name;
                        objgetPayment.DD_BankersCheque_Number = item.DD_BankersCheque_Number;
                        objgetPayment.DD_BankersCheque_Amount = item.DD_BankersCheque_Amount;
                        objgetPayment.ImageDDorBankersCheque_FileName = item.ImageDDorBankersCheque_FileName;
                        objgetPayment.ImageDDorBankersCheque_FilePath = item.ImageDDorBankersCheque_FilePath;
                        objgetPayment.Remarks_IfAny = item.Remarks_IfAny;

                        objgetPayment.A_column = item.A_column;
                        objgetPayment.B_column = item.B_column;
                        objgetPayment.C_column = item.C_column;

                        objgetPayment.IsActive = item.IsActive;
                        objgetPayment.IsDraft = item.IsDraft;
                        objgetPayment.CreatedBy = item.CreatedBy;
                        objgetPayment.CreatedOn = item.CreatedOn;
                        objgetPayment.ModifyBy = item.ModifyBy;
                        objgetPayment.ModifyOn = item.ModifyOn;
                        #endregion
                    }
                    #region paramerters
                    //No records found - table Payment Form M 
                    objAppPayment.PaymentRefNumberAgent_IndexID = 0;
                    objAppPayment.PaymentRefNumberAgent_ID = 0;
                    objAppPayment.RelatedAgent_ID = objAgentApp.Agent_ID;
                    objAppPayment.RelatedAgent_Code = Convert.ToString(objAgentApp.Agent_ID);
                    objAppPayment.RelatedPayment_ID = PaymentID; // session or query string
                    objAppPayment.AgentType_IO = Convert.ToString(objAgentApp.Agent_Type); // "Ind or OtherThanInd";

                    objAppPayment.User_ID = UID;
                    objAppPayment.User_Name = userName;

                    objAppPayment.PG_Shipping_Address1 = objAgentApp.BComm_AddressLine1;
                    objAppPayment.PG_Shipping_Address2 = objAgentApp.BComm_AddressLine2;
                    objAppPayment.PG_Shipping_City = objdis.District_Name(Convert.ToInt32(objAgentApp.BComm_AddressDistrictCode));
                    objAppPayment.PG_Shipping_State = objdis.State_Name(Convert.ToInt32(objAgentApp.BComm_AddressStateCode));
                    objAppPayment.PG_Shipping_Country = "India";
                    objAppPayment.PG_Shipping_Zipcode = Convert.ToString(objAgentApp.BComm_AddressPIN);
                    objAppPayment.PG_Shipping_Phone = Convert.ToString(objAgentApp.MobileNumber);

                    objAppPayment.PG_Customer_Email = objAgentApp.EmailAddress; //Email ID
                    objAppPayment.PG_Customer_Phone = Convert.ToString(objAgentApp.MobileNumber); //Phone/Mobile 

                    objAppPayment.PG_Address_Line1 = objAgentApp.BComm_AddressLine1;
                    objAppPayment.PG_Address_Line2 = objAgentApp.BComm_AddressLine2;
                    objAppPayment.PG_City = objdis.District_Name(Convert.ToInt32(objAgentApp.BComm_AddressDistrictCode));
                    objAppPayment.PG_State = objdis.State_Name(Convert.ToInt32(objAgentApp.BComm_AddressStateCode));
                    objAppPayment.PG_Country = "India";
                    objAppPayment.PG_ZipCode = Convert.ToString(objAgentApp.BComm_AddressPIN);

                    if (objAgentApp.Agent_Type == 1)
                    {
                        string PaymentTypeUDF2 = string.Empty;
                        if (objgetPayment.AgentPayment_TitleCode == 1)
                        {
                            PaymentTypeUDF2 = "Application Fee (Agent Individual Registration)";
                        }
                        objAppPayment.PG_Product_Info = PaymentTypeUDF2;
                        objAppPayment.PG_Transaction_Fee = 0;
                        objAppPayment.PG_Discount = 0;
                        objAppPayment.PG_Additional_Charges = 0;
                        objAppPayment.PG_Amount_INR = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Amount = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                        objAppPayment.PG_Shipping_Firstname = objAgentApp.Agent_FirstName + " " + objAgentApp.Agent_MiddleName;
                        objAppPayment.PG_Shipping_Lastname = objAgentApp.Agent_LastName;
                        objAppPayment.PG_Customer_Name = objAgentApp.Agent_FirstName + " " + objAgentApp.Agent_MiddleName; //Name
                        objAppPayment.PG_Last_Name = objAgentApp.Agent_LastName;
                    }
                    else if (objAgentApp.Agent_Type == 2)
                    {
                        string PaymentTypeUDF2 = string.Empty;
                        if (objgetPayment.AgentPayment_TitleCode == 1)
                        {
                            PaymentTypeUDF2 = "Application Fee (Agent Other Than Individual Registration)";
                        }
                        objAppPayment.PG_Product_Info = PaymentTypeUDF2;
                        objAppPayment.PG_Transaction_Fee = 0;
                        objAppPayment.PG_Discount = 0;
                        objAppPayment.PG_Additional_Charges = 0;
                        objAppPayment.PG_Amount_INR = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Amount = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                        objAppPayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                        objAppPayment.PG_Shipping_Firstname = objAgentApp.AuthorizedSignatory_FirstName;
                        objAppPayment.PG_Shipping_Lastname = objAgentApp.AuthorizedSignatory_LastName;
                        objAppPayment.PG_Customer_Name = objAgentApp.AuthorizedSignatory_FirstName; //Name
                        objAppPayment.PG_Last_Name = objAgentApp.AuthorizedSignatory_LastName;
                    }
                    #endregion
                }
                TempData["submitvalueAgentAppPayment"] = "Make Payment"; TempData.Keep();
            }
            return View("RequestAgentApplicationPayment", objAppPayment);
        }

        [HttpPost]
        public void RequestAgentApplicationPayment(ClsPrp_AgentApplication_PaymentIntegration dm)
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
            string udf3 = Convert.ToString(dm.RelatedAgent_ID);
            string udf4 = Convert.ToString(dm.RelatedPayment_ID);
            string udf5 = string.Empty;

            #region Save & Update - Table Payment
            ClsMethod_AgentApplication_PaymentIntegration objFormAppM = new ClsMethod_AgentApplication_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            Int64 p_PaymentRefNumber = 0;

            if (TempData["submitvalueAgentAppPayment"].ToString() == "Make Payment")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        dm.PG_UDF_2 = dm.PG_Product_Info;
                        dm.PG_UDF_3 = Convert.ToString(dm.RelatedAgent_ID);
                        dm.PG_UDF_4 = Convert.ToString(dm.RelatedPayment_ID);

                        p_PaymentRefNumber = objFormAppM.Add_AgentApplication_Payment(dm, UID, userName, txnid, "0");
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
                RedirectToAction("getdetailpaymentagentapplication", "AgentPayment");
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

            myremotepost.Add("surl", DomainNameURL + "/AgentPayment/successpaymentagentapp");
            myremotepost.Add("furl", DomainNameURL + "/AgentPayment/failurepaymentagentapp/" + p_PaymentRefNumber);
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

        #region ePayment Output Agent Application

        [AllowAnonymous]
        public ActionResult successpaymentagentapp(FormCollection form = null)
        {
            string salt = ConfigurationManager.AppSettings["payuSalt"];

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
                if (form["status"].ToString() == "success")
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

            ClsMethod_AgentApplication_PaymentIntegration sdb = new ClsMethod_AgentApplication_PaymentIntegration();
            ClsPrp_AgentApplication_PaymentIntegration aa = new ClsPrp_AgentApplication_PaymentIntegration();

            Int64 PRN_udf1 = String.IsNullOrEmpty(v_udf1) ? 0 : Convert.ToInt64(v_udf1);
            aa.AgentPayment = sdb.Display_AgentApplication_PaymentByPRNumber(PRN_udf1);
            int existingPaymentStatus = aa.IsPaymentSuccessComplete;

            if (aa.AgentPayment.Count >= 1)
            {
                foreach (var item in aa.AgentPayment)
                {
                    aa.PaymentRefNumberAgent_IndexID = item.PaymentRefNumberAgent_IndexID;
                    aa.PaymentRefNumberAgent_ID = item.PaymentRefNumberAgent_ID;
                    aa.RelatedAgent_ID = item.RelatedAgent_ID;
                    aa.RelatedAgent_Code = item.RelatedAgent_Code;
                    aa.RelatedPayment_ID = item.RelatedPayment_ID;
                    aa.User_ID = item.User_ID;

                    aa.AgentType_IO = item.AgentType_IO;
                    aa.User_Name = item.User_Name;
                    aa.Agent_BriefSummary = item.Agent_BriefSummary;
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
                    TempData["submitvalueAgentAppPaymentsurl"] = "Proceed"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueAgentAppPaymentsurl"] = "Next"; TempData.Keep();
                }
            }
            try
            {
                aa.PG_Transaction_ID = order_id;
                aa.PG_Date = DateTime.Now;
                aa.PG_PayU_ID = Convert.ToInt64(v_mihpayid);
                aa.PG_Amount = Convert.ToDecimal(v_amount);
                aa.PG_Status = v_status;
                aa.Agent_BriefSummary = v_status;
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

                //aa.IsPaymentSuccessComplete = 1;
                //aa.PaymentSuccessDate = DateTime.Now;


                string UID = aa.User_ID;
                string userName = aa.User_Name;
                Int32 flag = 1;

                string logPath = Server.MapPath("~/logs");

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                string filePath = Path.Combine(logPath, "payment.txt");
                string logData = $"TxnID={order_id ?? "NA"} | " +
                                 $"Amount={v_amount ?? "NA"} | " +
                                 $"Status={v_status ?? "NA"} | " +
                                 $"Name={v_firstName ?? "NA"} | " +
                                 $"Email={v_email ?? "NA"} | " +
                                 $"BankRef={v_bank_ref_num ?? "NA"} | " +
                                 $"PayUId={v_mihpayid ?? "NA"}";

                System.IO.File.AppendAllText(filePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {logData}{Environment.NewLine}");
                // System.IO.File.AppendAllText(filePath, DateTime.Now + " | " + EncryptedParam + Environment.NewLine);

                if (existingPaymentStatus == 0 || existingPaymentStatus == 2)
                {
                    aa.IsPaymentSuccessComplete = 1;
                    aa.PaymentSuccessDate = DateTime.Now;
                    bool result = sdb.Update_AgentApplication_Payment(aa, UID, userName, flag);

                    if (result)
                    {
                        TempData["message"] = "Payment Saved Successfully";
                    }
                    else
                    {
                        TempData["message"] = "Payment Save Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                return RedirectToAction("getdetailpaymentagentapplication", "AgentPayment");
            }
            return View(aa);
        }

        [HttpPost]
        public ActionResult successpaymentagentapplication(ClsPrp_AgentApplication_PaymentIntegration dm)
        {

            ClsMethod_AgentApplication_PaymentIntegration sdb = new ClsMethod_AgentApplication_PaymentIntegration();
            ClsPrp_AgentApplication_PaymentIntegration aa = new ClsPrp_AgentApplication_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueAgentAppPaymentsurl"].ToString() == "Proceed")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)
                    if (ModelState.IsValid)
                    {
                        if (sdb.Update_AgentApplication_Payment(dm, UID, userName, IsPaymentSuccessCompleteFlag))
                        {
                            TempData["message"] = "Details Updated Successfully";
                        }
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("RegAgent", "Agent");
            }

            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                //dm.PG_Last_Name = strex;
                return RedirectToAction("getdetailpaymentagentapplication", "AgentPayment");
            }
            #endregion
        }

        [AllowAnonymous]
        public ActionResult failurepaymentagentapp(int? id)
        {
            ClsMethod_AgentApplication_PaymentIntegration sdb = new ClsMethod_AgentApplication_PaymentIntegration();
            ClsPrp_AgentApplication_PaymentIntegration aa = new ClsPrp_AgentApplication_PaymentIntegration();

            Int64 PRN_udf1 = id == null ? 0 : Convert.ToInt64(id);
            aa.AgentPayment = sdb.Display_AgentApplication_PaymentByPRNumber(PRN_udf1);

            if (aa.AgentPayment.Count >= 1)
            {
                foreach (var item in aa.AgentPayment)
                {
                    aa.PaymentRefNumberAgent_IndexID = item.PaymentRefNumberAgent_IndexID;
                    aa.PaymentRefNumberAgent_ID = item.PaymentRefNumberAgent_ID;
                    aa.RelatedAgent_ID = item.RelatedAgent_ID;
                    aa.RelatedAgent_Code = item.RelatedAgent_Code;
                    aa.RelatedPayment_ID = item.RelatedPayment_ID;
                    aa.User_ID = item.User_ID;

                    aa.AgentType_IO = item.AgentType_IO;
                    aa.User_Name = item.User_Name;
                    aa.Agent_BriefSummary = item.Agent_BriefSummary;
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

        [HttpGet]
        public ActionResult getdetailpaymentagentapplication()
        {
            return View();
        }

        #endregion

        #region ePayment GET TXN Details By Agent Payment TxnID

        [HttpGet]
        public ActionResult getagentapplicationpayment()
        {
            Int64 AgentApplicationID = 0;
            Int64 PaymentID = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    AgentApplicationID = Convert.ToInt64(Session["ApplicationId"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            if (Session["RequestAgentPaymentID"] != null)
            {
                if (Session["RequestAgentPaymentID"].ToString() != "0")
                {
                    PaymentID = Convert.ToInt64(Session["RequestAgentPaymentID"]);
                }
            }

            ClsPrp_AgentApplication_PaymentIntegration objAppPayment = new ClsPrp_AgentApplication_PaymentIntegration();
            ClsMethod_AgentApplication_PaymentIntegration objPayment = new ClsMethod_AgentApplication_PaymentIntegration();

            objAppPayment.AgentPayment = objPayment.Display_AgentApplication_PaymentById(AgentApplicationID, 0, 0, PaymentID);
            // PRN Exist - Case
            if (objAppPayment.AgentPayment.Count >= 1)
            {
                foreach (var item in objAppPayment.AgentPayment)
                {
                    // Payment Parameters
                    #region parameters
                    objAppPayment.PaymentRefNumberAgent_IndexID = item.PaymentRefNumberAgent_IndexID;
                    objAppPayment.PaymentRefNumberAgent_ID = item.PaymentRefNumberAgent_ID;
                    objAppPayment.RelatedAgent_ID = item.RelatedAgent_ID;
                    objAppPayment.RelatedAgent_Code = item.RelatedAgent_Code;
                    objAppPayment.RelatedPayment_ID = item.RelatedPayment_ID;
                    objAppPayment.User_ID = item.User_ID;

                    objAppPayment.AgentType_IO = item.AgentType_IO;
                    objAppPayment.User_Name = item.User_Name;
                    objAppPayment.Agent_BriefSummary = item.Agent_BriefSummary;
                    objAppPayment.IsPaymentSuccessComplete = item.IsPaymentSuccessComplete;
                    objAppPayment.PaymentSuccessDate = item.PaymentSuccessDate;
                    objAppPayment.FailureSuccessSummary = item.FailureSuccessSummary;

                    objAppPayment.PG_Transaction_ID = item.PG_Transaction_ID;
                    objAppPayment.PG_Date = item.PG_Date;
                    objAppPayment.PG_PayU_ID = item.PG_PayU_ID;
                    objAppPayment.PG_Amount = item.PG_Amount; //Amount INR
                    objAppPayment.PG_Status = item.PG_Status;
                    objAppPayment.PG_Product_Info = item.PG_Product_Info; //Product Info
                    objAppPayment.PG_Customer_Name = item.PG_Customer_Name; //Name
                    objAppPayment.PG_Last_Name = item.PG_Last_Name;
                    objAppPayment.PG_Customer_Email = item.PG_Customer_Email; //Email ID
                    objAppPayment.PG_Customer_Phone = item.PG_Customer_Phone; //Phone/Mobile
                    objAppPayment.PG_Customer_IP_Address = item.PG_Customer_IP_Address;
                    objAppPayment.PG_City = item.PG_City;
                    objAppPayment.PG_Merchant_Name = item.PG_Merchant_Name;
                    objAppPayment.PG_Bank_Name = item.PG_Bank_Name;
                    objAppPayment.PG_Payment_Gateway = item.PG_Payment_Gateway;
                    objAppPayment.PG_Bank_Reference_No = item.PG_Bank_Reference_No;
                    objAppPayment.PG_International_Domestic = item.PG_International_Domestic;
                    objAppPayment.PG_Payment_Type = item.PG_Payment_Type;
                    objAppPayment.PG_Error_Code = item.PG_Error_Code;
                    objAppPayment.PG_Error_Message = item.PG_Error_Message;
                    objAppPayment.PG_Name_on_Card = item.PG_Name_on_Card;
                    objAppPayment.PG_Card_Number = item.PG_Card_Number;
                    objAppPayment.PG_Address_Line1 = item.PG_Address_Line1;
                    objAppPayment.PG_Address_Line2 = item.PG_Address_Line2;
                    objAppPayment.PG_State = item.PG_State;
                    objAppPayment.PG_Country = item.PG_Country;
                    objAppPayment.PG_ZipCode = item.PG_ZipCode;
                    objAppPayment.PG_Shipping_Firstname = item.PG_Shipping_Firstname;
                    objAppPayment.PG_Shipping_Lastname = item.PG_Shipping_Lastname;
                    objAppPayment.PG_Shipping_Address1 = item.PG_Shipping_Address1;
                    objAppPayment.PG_Shipping_Address2 = item.PG_Shipping_Address2;
                    objAppPayment.PG_Shipping_City = item.PG_Shipping_City;
                    objAppPayment.PG_Shipping_State = item.PG_Shipping_State;
                    objAppPayment.PG_Shipping_Country = item.PG_Shipping_Country;
                    objAppPayment.PG_Shipping_Zipcode = item.PG_Shipping_Zipcode;
                    objAppPayment.PG_Shipping_Phone = item.PG_Shipping_Phone;
                    objAppPayment.PG_Transaction_Fee = item.PG_Transaction_Fee;
                    objAppPayment.PG_Discount = item.PG_Discount;
                    objAppPayment.PG_Additional_Charges = item.PG_Additional_Charges;
                    objAppPayment.PG_Amount_INR = item.PG_Amount_INR;
                    objAppPayment.PG_UDF_1 = item.PG_UDF_1;
                    objAppPayment.PG_UDF_2 = item.PG_UDF_2;
                    objAppPayment.PG_UDF_3 = item.PG_UDF_3;
                    objAppPayment.PG_UDF_4 = item.PG_UDF_4;
                    objAppPayment.PG_UDF_5 = item.PG_UDF_5;

                    objAppPayment.PG_Device_Info = item.PG_Device_Info;
                    objAppPayment.PG_HashKey = item.PG_HashKey;
                    objAppPayment.PG_ServiceProvider = item.PG_ServiceProvider;
                    objAppPayment.Remarks_IfAny = item.Remarks_IfAny;

                    objAppPayment.A_column = item.A_column;
                    objAppPayment.B_column = item.B_column;
                    objAppPayment.C_column = item.C_column;

                    objAppPayment.IsActive = item.IsActive;
                    objAppPayment.IsDraft = item.IsDraft;
                    objAppPayment.IsLock = item.IsLock;
                    objAppPayment.IsPublicView = item.IsPublicView;

                    objAppPayment.CreatedBy = item.CreatedBy;
                    objAppPayment.CreatedOn = item.CreatedOn;
                    objAppPayment.ModifyBy = item.ModifyBy;
                    objAppPayment.ModifyOn = item.ModifyOn;
                    #endregion
                }
                // PRN - Check Case
                if (objAppPayment.IsPaymentSuccessComplete == 0 || objAppPayment.IsPaymentSuccessComplete == 2)
                {
                    TempData["APIerrorstatus"] = "To confirm that the registration payment successfully paid, please click the link below 'Confirm Payment'";
                    try
                    {
                        // PayU API Check - Payment Status with Details By TxnID 
                        Tuple<int, dynamic> tparrtemp = getPaymentDetailsByTransactionsAPI(objAppPayment.PG_Transaction_ID);

                        if (tparrtemp.Item1 == 1)
                        {
                            // Payment Parameters
                            #region parameters
                            dynamic arrayapi = tparrtemp.Item2;
                            string TxnapiID = objAppPayment.PG_Transaction_ID;

                            // get payment details
                            string arrapiStatus = (string)arrayapi["status"];
                            string arrapiMsg = (string)arrayapi["msg"];
                            string arrapiActionStatus = (string)arrayapi["transaction_details"][TxnapiID]["unmappedstatus"];

                            string arrapi_mihpayid = (string)arrayapi["transaction_details"][TxnapiID]["mihpayid"];
                            string arrapi_request_id = (string)arrayapi["transaction_details"][TxnapiID]["request_id"];
                            string arrapi_bank_ref_num = (string)arrayapi["transaction_details"][TxnapiID]["bank_ref_num"];
                            string arrapi_amt = (string)arrayapi["transaction_details"][TxnapiID]["amt"];
                            string arrapi_transaction_amount = (string)arrayapi["transaction_details"][TxnapiID]["transaction_amount"];

                            string arrapi_txnid = (string)arrayapi["transaction_details"][TxnapiID]["txnid"];
                            string arrapi_additional_charges = (string)arrayapi["transaction_details"][TxnapiID]["additional_charges"];
                            string arrapi_productinfo = (string)arrayapi["transaction_details"][TxnapiID]["productinfo"];
                            string arrapi_firstname = (string)arrayapi["transaction_details"][TxnapiID]["firstname"];
                            string arrapi_bankcode = (string)arrayapi["transaction_details"][TxnapiID]["bankcode"];

                            string arrapi_AgentID = (string)arrayapi["transaction_details"][TxnapiID]["udf3"];
                            string arrapi_PaymentGatewayID = (string)arrayapi["transaction_details"][TxnapiID]["udf1"];
                            string arrapi_AgentPaymentID = (string)arrayapi["transaction_details"][TxnapiID]["udf4"];
                            string arrapi_udf5 = (string)arrayapi["transaction_details"][TxnapiID]["udf5"];
                            string arrapi_field2 = (string)arrayapi["transaction_details"][TxnapiID]["field2"];

                            string arrapi_field9 = (string)arrayapi["transaction_details"][TxnapiID]["field9"];
                            string arrapi_error_code = (string)arrayapi["transaction_details"][TxnapiID]["error_code"];
                            string arrapi_payment_source = (string)arrayapi["transaction_details"][TxnapiID]["payment_source"];
                            string arrapi_card_type = (string)arrayapi["transaction_details"][TxnapiID]["card_type"];
                            string arrapi_error_Message = (string)arrayapi["transaction_details"][TxnapiID]["error_Message"];

                            string arrapi_net_amount_debit = (string)arrayapi["transaction_details"][TxnapiID]["net_amount_debit"];
                            string arrapi_disc = (string)arrayapi["transaction_details"][TxnapiID]["disc"];
                            string arrapi_mode = (string)arrayapi["transaction_details"][TxnapiID]["mode"];
                            string arrapi_PG_TYPE = (string)arrayapi["transaction_details"][TxnapiID]["PG_TYPE"];
                            string arrapi_card_no = (string)arrayapi["transaction_details"][TxnapiID]["card_no"];

                            string arrapi_name_on_card = (string)arrayapi["transaction_details"][TxnapiID]["name_on_card"];
                            string arrapi_udf2 = (string)arrayapi["transaction_details"][TxnapiID]["udf2"];
                            string arrapi_status = (string)arrayapi["transaction_details"][TxnapiID]["status"];
                            string arrapi_unmappedstatus = (string)arrayapi["transaction_details"][TxnapiID]["unmappedstatus"];
                            string arrapi_Merchant_UTR = (string)arrayapi["transaction_details"][TxnapiID]["Merchant_UTR"];

                            string arrapi_addedon = (string)arrayapi["transaction_details"][TxnapiID]["addedon"];
                            string arrapi_Settled_At = (string)arrayapi["transaction_details"][TxnapiID]["Settled_At"];

                            // set payment details
                            objAppPayment.Agent_BriefSummary = Convert.ToString(string.IsNullOrEmpty(arrapi_field9) ? "NA" : arrapi_field9);
                            objAppPayment.IsPaymentSuccessComplete = 1;
                            //objAppPayment.PaymentSuccessDate = arrapi_addedon;
                            objAppPayment.FailureSuccessSummary = Convert.ToString(string.IsNullOrEmpty(arrapi_field9) ? "NA" : arrapi_field9);
                            objAppPayment.PG_Transaction_ID = Convert.ToString(string.IsNullOrEmpty(arrapi_txnid) ? TxnapiID : arrapi_txnid);

                            //objAppPayment.PG_Date = arrapi_addedon;
                            objAppPayment.PG_PayU_ID = Convert.ToInt64(string.IsNullOrEmpty(arrapi_mihpayid) ? "0" : arrapi_mihpayid);
                            //objAppPayment.PG_Amount = arrapi_amt; //Amount INR
                            objAppPayment.PG_Status = Convert.ToString(string.IsNullOrEmpty(arrapi_field9) ? "NA" : arrapi_field9); //Status
                            objAppPayment.PG_Product_Info = Convert.ToString(string.IsNullOrEmpty(arrapi_udf2) ? "NA" : arrapi_udf2); //Product Info
                            objAppPayment.PG_Customer_Name = Convert.ToString(string.IsNullOrEmpty(arrapi_firstname) ? "NA" : arrapi_firstname); //Name                           

                            objAppPayment.PG_Bank_Name = Convert.ToString(string.IsNullOrEmpty(arrapi_bankcode) ? "NA" : arrapi_bankcode);
                            objAppPayment.PG_Payment_Gateway = Convert.ToString(string.IsNullOrEmpty(arrapi_PG_TYPE) ? "NA" : arrapi_PG_TYPE);
                            objAppPayment.PG_Bank_Reference_No = Convert.ToString(string.IsNullOrEmpty(arrapi_bank_ref_num) ? "NA" : arrapi_bank_ref_num);
                            objAppPayment.PG_International_Domestic = string.Empty;
                            objAppPayment.PG_Payment_Type = Convert.ToString(string.IsNullOrEmpty(arrapi_mode) ? "NA" : arrapi_mode);

                            objAppPayment.PG_Error_Code = Convert.ToString(string.IsNullOrEmpty(arrapi_error_code) ? "NA" : arrapi_error_code);
                            objAppPayment.PG_Error_Message = Convert.ToString(string.IsNullOrEmpty(arrapi_error_Message) ? "NA" : arrapi_error_Message);
                            objAppPayment.PG_Name_on_Card = Convert.ToString(string.IsNullOrEmpty(arrapi_name_on_card) ? "NA" : arrapi_name_on_card);
                            objAppPayment.PG_Card_Number = Convert.ToString(string.IsNullOrEmpty(arrapi_card_no) ? "NA" : arrapi_card_no);

                            objAppPayment.PG_Transaction_Fee = Convert.ToDecimal(string.IsNullOrEmpty(arrapi_net_amount_debit) ? "0" : arrapi_net_amount_debit);
                            objAppPayment.PG_Discount = Convert.ToDecimal(string.IsNullOrEmpty(arrapi_disc) ? "0" : arrapi_disc);
                            objAppPayment.PG_Additional_Charges = Convert.ToDecimal(string.IsNullOrEmpty(arrapi_additional_charges) ? "0" : arrapi_additional_charges);
                            //objAppPayment.PG_Amount_INR = item.PG_Amount_INR;

                            objAppPayment.PG_UDF_1 = Convert.ToString(string.IsNullOrEmpty(arrapi_PaymentGatewayID) ? "0" : arrapi_PaymentGatewayID);
                            objAppPayment.PG_UDF_2 = Convert.ToString(string.IsNullOrEmpty(arrapi_udf2) ? string.Empty : arrapi_udf2);
                            objAppPayment.PG_UDF_3 = Convert.ToString(string.IsNullOrEmpty(arrapi_AgentID) ? "0" : arrapi_AgentID);
                            objAppPayment.PG_UDF_4 = Convert.ToString(string.IsNullOrEmpty(arrapi_AgentPaymentID) ? "0" : arrapi_AgentPaymentID);
                            objAppPayment.PG_UDF_5 = Convert.ToString(string.IsNullOrEmpty(arrapi_udf5) ? string.Empty : arrapi_udf5);

                            objAppPayment.PG_Device_Info = Convert.ToString(string.IsNullOrEmpty(arrapi_unmappedstatus) ? string.Empty : arrapi_unmappedstatus);
                            objAppPayment.PG_HashKey = Convert.ToString(string.IsNullOrEmpty(arrapi_field2) ? string.Empty : arrapi_field2);
                            objAppPayment.PG_ServiceProvider = Convert.ToString(string.IsNullOrEmpty(arrapi_payment_source) ? string.Empty : arrapi_payment_source);
                            #endregion
                            // Payment - Done But Confirmation Pending
                            TempData["submitvalueGetAgentPaymentGateway"] = "Confirm Payment"; TempData.Keep();
                        }
                        else
                        {
                            // Payment - Pending OR Failure (Bounced /Failed /UserCancelled /Droped)
                            //return RedirectToAction("RegAgent", "Agent");
                            return View("getagentapplicationpayment", objAppPayment);
                        }
                    }
                    catch (Exception ex)
                    {
                        string retstr = ex.ToString();
                        TempData["APIerrorstatus"] = retstr;
                        return View("getagentapplicationpayment", objAppPayment);
                        //return RedirectToAction("RegAgent", "Agent");
                    }
                }
                else
                {
                    // Payment - Done
                    TempData["APIerrorstatus"] = "Paid";
                    TempData["submitvalueGetAgentPaymentGateway"] = "Back"; TempData.Keep();
                }
            }
            return View("getagentapplicationpayment", objAppPayment);
        }

        [HttpPost]
        public ActionResult getagentapplicationpaymenttxn(ClsPrp_AgentApplication_PaymentIntegration setmodel)
        {
            ClsMethod_AgentApplication_PaymentIntegration sdb = new ClsMethod_AgentApplication_PaymentIntegration();
            ClsPrp_AgentApplication_PaymentIntegration aa = new ClsPrp_AgentApplication_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueGetAgentPaymentGateway"].ToString() == "Confirm Payment")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)
                    if (ModelState.IsValid)
                    {
                        if (sdb.Update_AgentApplication_PaymentByAPI(setmodel, UID, userName, IsPaymentSuccessCompleteFlag))
                        {
                            TempData["message"] = "Details Updated Successfully";
                        }
                        ModelState.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
            }
            #endregion
            return RedirectToAction("RegAgent", "Agent");
        }

        public Tuple<Int32, Int64, Int64, Int64> getPaymentDetailsByTxnAPI(string TxnID)
        {
            Int32 RetFlag = 0;
            Int64 RetValueAgentID = 0;
            Int64 RetValuePaymentGatewayID = 0;
            Int64 RetValueAgentPaymentID = 0;
            try
            {
                string var1 = Convert.ToString(TxnID);
                string command = Convert.ToString("verify_payment");

                RemotePostAPI myremoteapipost = new RemotePostAPI();

                string key = ConfigurationManager.AppSettings["payuMerchantKeyTEST"]; //"98d8Yh"; //98d8Yh 
                string salt = ConfigurationManager.AppSettings["payuSaltTEST"]; //"6thltjA2"; //6thltjA2 
                string URI = ConfigurationManager.AppSettings["payuApiBaseURL"];
                //string URI = ConfigurationManager.AppSettings["payuBaseURL"];
                string myParameters = string.Empty;

                //posting all the parameters required for integration.           
                myremoteapipost.Add("key", key);
                myremoteapipost.Add("salt", salt);
                myremoteapipost.Add("var1", var1);
                myremoteapipost.Add("command", command);
                myremoteapipost.Add("service_provider", "payu"); //payu_paisa

                string hashString = key + "|" + command + "|" + var1 + "|" + salt;
                string hash = Generatehash512(hashString);
                myremoteapipost.Add("hash", hash);
                myParameters = myremoteapipost.PostParameters();

                #region WebClient Method
                //string HtmlResult = string.Empty;
                //using (WebClient wc = new WebClient())
                //{
                //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                //    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                //    HtmlResult = wc.UploadString(URI, myParameters);
                //}

                //dynamic array = Newtonsoft.Json.JsonConvert.DeserializeObject(HtmlResult);

                //string array1 = (string)array["status"];
                //string array2 = (string)array["msg"];
                //string array3 = (string)array["transaction_details"][TxnID]["unmappedstatus"];

                //string array4 = (string)array["transaction_details"][TxnID]["udf3"];
                //string array5 = (string)array["transaction_details"][TxnID]["udf1"];
                //string array6 = (string)array["transaction_details"][TxnID]["udf4"];

                //JObject jObject = JObject.Parse(HtmlResult);
                //string status = (string)jObject.SelectToken("status");
                //string msg = (string)jObject.SelectToken("msg");
                #endregion

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(URI);
                myWebRequest.KeepAlive = false;
                myWebRequest.ProtocolVersion = HttpVersion.Version10;
                myWebRequest.ConnectionGroupName = Guid.NewGuid().ToString();
                myWebRequest.Timeout = -1;
                myWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                myWebRequest.Method = "POST";
                myWebRequest.ContentType = "application/x-www-form-urlencoded";

                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)768;

                //StreamWriter requestWriter = new StreamWriter(myWebRequest.GetRequestStream());
                //requestWriter.Write(myParameters);
                //requestWriter.Close();

                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)768;

                //StreamReader responseReader = new StreamReader(myWebRequest.GetResponse().GetResponseStream());
                //HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                //Stream ReceiveStream = myWebResponse.GetResponseStream();
                //Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                //StreamReader readStream = new StreamReader(ReceiveStream, encode);

                //string response = readStream.ReadToEnd();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                using (StreamWriter requestWriter = new StreamWriter(myWebRequest.GetRequestStream()))
                {
                    requestWriter.Write(myParameters);
                }

                string response;
                using (HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse())
                using (Stream receiveStream = myWebResponse.GetResponseStream())
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding("utf-8")))
                {
                    response = readStream.ReadToEnd();
                }

                dynamic array = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

                string array1 = (string)array["status"];
                string array2 = (string)array["msg"];
                string array3 = (string)array["transaction_details"][TxnID]["unmappedstatus"];

                string array4 = (string)array["transaction_details"][TxnID]["udf3"];
                string array5 = (string)array["transaction_details"][TxnID]["udf1"];
                string array6 = (string)array["transaction_details"][TxnID]["udf4"];

                string mihpayid = (string)array["transaction_details"][TxnID]["mihpayid"];
                string bank_ref_num = (string)array["transaction_details"][TxnID]["bank_ref_num"];
                string amount = (string)array["transaction_details"][TxnID]["amt"];
                string pstatus = (string)array["transaction_details"][TxnID]["status"];
                string additionalcharges = (string)array["transaction_details"][TxnID]["additional_charges"];
                string udf1 = (string)array["transaction_details"][TxnID]["udf1"];
                string udf2 = (string)array["transaction_details"][TxnID]["udf2"];
                string udf3 = (string)array["transaction_details"][TxnID]["udf3"];
                string udf4 = (string)array["transaction_details"][TxnID]["udf4"];
                string udf5 = (string)array["transaction_details"][TxnID]["udf5"];
                string unmappedstatus = (string)array["transaction_details"][TxnID]["unmappedstatus"];

                JObject account = JObject.Parse(response);
                string status = (string)account.SelectToken("status");
                string msg = (string)account.SelectToken("msg");
                string statusAmount = (string)account.SelectToken("transaction_details." + var1 + ".status");

                if (status == "1")
                {
                    if (array3 == "captured")
                    {
                        RetFlag = 1; // Yes Txn Completed
                        RetValueAgentID = Convert.ToInt64(string.IsNullOrEmpty(array4) ? "0" : array4); //AGENT ID
                        RetValuePaymentGatewayID = Convert.ToInt64(string.IsNullOrEmpty(array5) ? "0" : array5); //Payment Gatway ID
                        RetValueAgentPaymentID = Convert.ToInt64(string.IsNullOrEmpty(array6) ? "0" : array6); //Agent Payment ID
                    }
                    else
                    {
                        RetFlag = 0; // No Txn Bounced /Failed /UserCancelled /Droped
                    }
                }
                else
                {
                    RetFlag = 0; // No record found
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                TempData["APIerrorstatus"] = str;
            }
            var tuple = new Tuple<int, long, long, long>(RetFlag, RetValueAgentID, RetValuePaymentGatewayID, RetValueAgentPaymentID);
            return tuple;
        }

        //public Tuple<int, long, long, long> getPaymentDetailsByTxnAPI(string TxnID)
        //{
        //    int RetFlag = 0;
        //    long RetValueAgentID = 0;
        //    long RetValuePaymentGatewayID = 0;
        //    long RetValueAgentPaymentID = 0;

        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(TxnID))
        //        {
        //            TempData["APIerrorstatus"] = "TxnID is null or empty.";
        //            return Tuple.Create(RetFlag, RetValueAgentID, RetValuePaymentGatewayID, RetValueAgentPaymentID);
        //        }

        //        string key = ConfigurationManager.AppSettings["payuMerchantKeyTEST"]?.Trim();
        //        string salt = ConfigurationManager.AppSettings["payuSaltTEST"]?.Trim();
        //        string var1 = TxnID?.Trim();
        //        string command = "verify_payment"; ;
        //        string baseUrl = ConfigurationManager.AppSettings["payuApiBaseURL"]?.Trim();

        //        string hashString = key + "|" + command + "|" + var1 + "|" + salt;
        //        string hash = Generatehash512(hashString).ToLowerInvariant();

        //        TempData["APIerrorstatus"] = "HASHSTRING=[" + hashString + "] HASH=[" + hash + "]";

        //        string url = baseUrl.Contains("?") ? baseUrl + "&form=2" : baseUrl + "?form=2";

        //        //// PayU hash: sha512(key|command|var1|salt)
        //        //string hashString = key + "|" + command + "|" + var1 + "|" + salt;
        //        //string hash = Generatehash512(hashString).ToLowerInvariant();

        //        string postData =
        //            "key=" + Uri.EscapeDataString(key) +
        //            "&command=" + Uri.EscapeDataString(command) +
        //            "&var1=" + Uri.EscapeDataString(var1) +
        //            "&hash=" + Uri.EscapeDataString(hash);

        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Method = "POST";
        //        request.ContentType = "application/x-www-form-urlencoded";
        //        request.KeepAlive = false;
        //        request.Timeout = 100000;
        //        request.ReadWriteTimeout = 100000;
        //        request.ProtocolVersion = HttpVersion.Version10;
        //        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

        //        byte[] bytes = Encoding.UTF8.GetBytes(postData);
        //        request.ContentLength = bytes.Length;

        //        using (Stream requestStream = request.GetRequestStream())
        //        {
        //            requestStream.Write(bytes, 0, bytes.Length);
        //        }

        //        string responseText;
        //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //        using (Stream responseStream = response.GetResponseStream())
        //        using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
        //        {
        //            responseText = reader.ReadToEnd();
        //        }

        //        JObject obj = JObject.Parse(responseText);

        //        string status = obj["status"]?.ToString();
        //        string msg = obj["msg"]?.ToString();

        //        if (status == "1")
        //        {
        //            JToken txnToken = obj["transaction_details"]?[var1];

        //            if (txnToken == null)
        //            {
        //                TempData["APIerrorstatus"] = "transaction_details missing for TxnID: " + var1 + " | " + responseText;
        //                return Tuple.Create(RetFlag, RetValueAgentID, RetValuePaymentGatewayID, RetValueAgentPaymentID);
        //            }

        //            string unmappedstatus = txnToken["unmappedstatus"]?.ToString();

        //            if (unmappedstatus == "captured")
        //            {
        //                RetFlag = 1;
        //                RetValueAgentID = SafeToLong(txnToken["udf3"]?.ToString());
        //                RetValuePaymentGatewayID = SafeToLong(txnToken["udf1"]?.ToString());
        //                RetValueAgentPaymentID = SafeToLong(txnToken["udf4"]?.ToString());
        //            }
        //            else
        //            {
        //                TempData["APIerrorstatus"] = "Txn found but not captured. unmappedstatus=" + unmappedstatus;
        //            }
        //        }
        //        else
        //        {
        //            TempData["APIerrorstatus"] = msg + " | " + responseText;
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        string details = ex.Message;

        //        if (ex.Response != null)
        //        {
        //            using (var sr = new StreamReader(ex.Response.GetResponseStream()))
        //            {
        //                details += " | " + sr.ReadToEnd();
        //            }
        //        }

        //        TempData["APIerrorstatus"] = details;
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["APIerrorstatus"] = ex.ToString();
        //    }

        //    return Tuple.Create(RetFlag, RetValueAgentID, RetValuePaymentGatewayID, RetValueAgentPaymentID);
        //}

        //private static long SafeToLong(string value)
        //{
        //    long result;
        //    return long.TryParse(value, out result) ? result : 0L;
        //}

        //public static string Generatehash512(string text)
        //{
        //    byte[] message = Encoding.UTF8.GetBytes(text);

        //    using (SHA512Managed hashString = new SHA512Managed())
        //    {
        //        byte[] hashValue = hashString.ComputeHash(message);

        //        StringBuilder hex = new StringBuilder(hashValue.Length * 2);

        //        foreach (byte b in hashValue)
        //        {
        //            hex.AppendFormat("{0:x2}", b);
        //        }

        //        return hex.ToString();
        //    }
        //}












        public Tuple<Int32, dynamic> getPaymentDetailsByTransactionsAPI_0111(string TxnID)
        {
            Int32 RetFlag = 0;
            dynamic array = null;

            try
            {
                string var1 = Convert.ToString(TxnID);
                string command = Convert.ToString("verify_payment");

                RemotePostAPI myremoteapipost = new RemotePostAPI();

                string key = ConfigurationManager.AppSettings["payuMerchantKey"]; // "98d8Yh"; //98d8Yh 
                string salt = ConfigurationManager.AppSettings["payuSalt"]; // "6thltjA2"; //6thltjA2 
                string URI = ConfigurationManager.AppSettings["payuApiBaseURL"];
                //string URI = ConfigurationManager.AppSettings["payuBaseURL"];

                string myParameters = string.Empty;

                //posting all the parameters required for integration.           
                myremoteapipost.Add("key", key);
                myremoteapipost.Add("salt", salt);
                myremoteapipost.Add("var1", var1);
                myremoteapipost.Add("command", command);
                myremoteapipost.Add("service_provider", "payu"); //payu_paisa

                string hashString = key + "|" + command + "|" + var1 + "|" + salt;
                string hash = Generatehash512(hashString);
                myremoteapipost.Add("hash", hash);
                myParameters = myremoteapipost.PostParameters();

                string HtmlResult = string.Empty;
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                    HtmlResult = wc.UploadString(URI, myParameters);
                }

                array = Newtonsoft.Json.JsonConvert.DeserializeObject(HtmlResult);

                string array1 = (string)array["status"];
                string array2 = (string)array["msg"];
                string array3 = (string)array["transaction_details"][TxnID]["unmappedstatus"];

                string array4 = (string)array["transaction_details"][TxnID]["udf3"];
                string array5 = (string)array["transaction_details"][TxnID]["udf1"];
                string array6 = (string)array["transaction_details"][TxnID]["udf4"];

                JObject jObject = JObject.Parse(HtmlResult);
                string status = (string)jObject.SelectToken("status");
                string msg = (string)jObject.SelectToken("msg");

                if (status == "1")
                {
                    if (array3 == "captured")
                    {
                        RetFlag = 1; // Yes Txn Completed
                    }
                    else
                    {
                        RetFlag = 0; // No Txn Bounced /Failed /UserCancelled /Droped
                    }
                }
                else
                {
                    RetFlag = 0; // No record found
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                TempData["APIerrorstatus"] = str;
            }
            var tuple = new Tuple<int, dynamic>(RetFlag, array);
            return tuple;
        }

        public Tuple<Int32, dynamic> getPaymentDetailsByTransactionsAPI(string TxnID)
        {
            Int32 RetFlag = 0;
            dynamic array = null;

            try
            {
                string var1 = Convert.ToString(TxnID);
                string command = Convert.ToString("verify_payment");

                RemotePostAPI myremoteapipost = new RemotePostAPI();

                string key = ConfigurationManager.AppSettings["payuMerchantKey"]; // "98d8Yh"; //98d8Yh 
                string salt = ConfigurationManager.AppSettings["payuSalt"]; // "6thltjA2"; //6thltjA2 
                string URI = ConfigurationManager.AppSettings["payuApiBaseURL"]; //string Url = "https://info.payu.in/merchant/postservice.php?form=2";
                //string URI = ConfigurationManager.AppSettings["payuBaseURL"];

                string myParameters = string.Empty;

                //posting all the parameters required for integration.           
                myremoteapipost.Add("key", key);
                myremoteapipost.Add("salt", salt);
                myremoteapipost.Add("var1", var1);
                myremoteapipost.Add("command", command);
                myremoteapipost.Add("service_provider", "payu"); //payu_paisa

                string hashString = key + "|" + command + "|" + var1 + "|" + salt;
                string hash = Generatehash512(hashString);
                myremoteapipost.Add("hash", hash);
                myParameters = myremoteapipost.PostParameters();

                //TcpClient client = new TcpClient("info.payu.in/merchant/postservice.php?form=2", 443);
                //Stream netStream = client.GetStream();
                //SslStream sslStream = new SslStream(netStream);
                //sslStream.AuthenticateAsClient("info.payu.in/merchant/postservice.php?form=2");

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(URI);
                myWebRequest.KeepAlive = false;
                myWebRequest.ProtocolVersion = HttpVersion.Version10;
                myWebRequest.ConnectionGroupName = Guid.NewGuid().ToString();
                myWebRequest.Timeout = -1;
                myWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                myWebRequest.Method = "POST";
                myWebRequest.ContentType = "application/x-www-form-urlencoded";

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768;

                StreamWriter requestWriter = new StreamWriter(myWebRequest.GetRequestStream());
                requestWriter.Write(myParameters);
                requestWriter.Close();

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768;

                StreamReader responseReader = new StreamReader(myWebRequest.GetResponse().GetResponseStream());
                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream ReceiveStream = myWebResponse.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(ReceiveStream, encode);

                string response = readStream.ReadToEnd();

                //sslStream.Close();
                //client.Close();

                array = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

                string array1 = (string)array["status"];
                string array2 = (string)array["msg"];
                string array3 = (string)array["transaction_details"][TxnID]["unmappedstatus"];

                string array4 = (string)array["transaction_details"][TxnID]["udf3"];
                string array5 = (string)array["transaction_details"][TxnID]["udf1"];
                string array6 = (string)array["transaction_details"][TxnID]["udf4"];

                JObject account = JObject.Parse(response);
                string status = (string)account.SelectToken("status");
                string msg = (string)account.SelectToken("msg");
                string statusAmount = (string)account.SelectToken("transaction_details." + var1 + ".status");

                if (status == "1")
                {
                    if (array3 == "captured")
                    {
                        RetFlag = 1; // Yes Txn Completed
                    }
                    else
                    {
                        RetFlag = 0; // No Txn Bounced /Failed /UserCancelled /Droped
                    }
                }
                else
                {
                    RetFlag = 0; // No record found
                }
            }
            catch (Exception ex)
            {
                //WebException

                //using (WebResponse response = ex.Response)
                //{
                //    HttpWebResponse httpResponse = (HttpWebResponse)response;
                //    // Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                //    using (Stream data = response.GetResponseStream())
                //    using (var reader = new StreamReader(data))
                //    {
                //        string text = reader.ReadToEnd();
                //        TempData["APIerrorstatus"] = "Error code:" + httpResponse.StatusCode + "<br/>" + text;
                //    }
                //}

                string str = ex.ToString();
                TempData["APIerrorstatus"] = str;
            }
            var tuple = new Tuple<int, dynamic>(RetFlag, array);
            return tuple;
        }
        #endregion




        [AllowAnonymous]
        public ActionResult AllAgentreverify()
        {
            ClsMethod_AgentApplication_PaymentIntegration objPayment = new ClsMethod_AgentApplication_PaymentIntegration();
            ClsPrp_AgentApplication_PaymentIntegration prp = new ClsPrp_AgentApplication_PaymentIntegration();

            DateTime To_date = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime From_date = DateTime.Now.AddDays(-21).Date;

            prp.AgentPayment = objPayment.Display_AgentApplication_PaymentReverify(To_date, From_date);
            return View(prp);
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public JsonResult reverifyTxnAPI(string zPG_Transaction_ID)
        //{
        //    int retFlag = 0;
        //    string message = "";
        //    string msgType = "info";

        //    ClsMethod_AgentApplication_PaymentIntegration sdb = new ClsMethod_AgentApplication_PaymentIntegration();

        //    try
        //    {
        //        string var1 = Convert.ToString(zPG_Transaction_ID);
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
        //        string array3 = array["transaction_details"][zPG_Transaction_ID]["unmappedstatus"];

        //        string array4 = array["transaction_details"][zPG_Transaction_ID]["udf3"];
        //        string array5 = array["transaction_details"][zPG_Transaction_ID]["udf1"];
        //        string array6 = array["transaction_details"][zPG_Transaction_ID]["udf4"];
        //        string array7 = array["transaction_details"][zPG_Transaction_ID]["udf5"];

        //        string mihpayid = array["transaction_details"][zPG_Transaction_ID]["mihpayid"];
        //        string bank_ref_num = array["transaction_details"][zPG_Transaction_ID]["bank_ref_num"];
        //        decimal amount = array["transaction_details"][zPG_Transaction_ID]["amt"];
        //        string pstatus = array["transaction_details"][zPG_Transaction_ID]["status"];
        //        decimal additionalcharges = array["transaction_details"][zPG_Transaction_ID]["additional_charges"];

        //        string bankcode = array["transaction_details"][zPG_Transaction_ID]["bankcode"];
        //        string payment_type = array["transaction_details"][zPG_Transaction_ID]["mode"];
        //        string payment_gateway = array["transaction_details"][zPG_Transaction_ID]["PG_TYPE"];

        //        string udf1 = array["transaction_details"][zPG_Transaction_ID]["udf1"];
        //        string udf2 = array["transaction_details"][zPG_Transaction_ID]["udf2"];
        //        string udf3 = array["transaction_details"][zPG_Transaction_ID]["udf3"];
        //        string udf4 = array["transaction_details"][zPG_Transaction_ID]["udf4"];
        //        string udf5 = array["transaction_details"][zPG_Transaction_ID]["udf5"];

        //        if (status == "1")
        //        {
        //            if (array3 == "captured")
        //            {
        //                retFlag = 1;


        //                int dbStatus = sdb.Update_AgentPaymentGatewayByAPI(zPG_Transaction_ID, mihpayid, amount, bank_ref_num, pstatus, additionalcharges,bankcode,payment_type,payment_gateway, udf1, udf2, udf3, udf4, udf5);

        //                if (dbStatus == 1)
        //                {
        //                    message = "Payment verified and updated successfully.";
        //                    msgType = "success";
        //                }
        //                else if (dbStatus == 2)
        //                {
        //                    message = "Payment was already updated earlier.";
        //                    msgType = "warning";
        //                }
        //                else if (dbStatus == 0)
        //                {
        //                    message = "Transaction found, but no matching record was available to update.";
        //                    msgType = "warning";
        //                }
        //                else
        //                {
        //                    message = "An error occurred while updating payment.";
        //                    msgType = "error";
        //                }
        //            }
        //            else if (array3 == "userCancelled" || array3 == "bounced" || array3 == "dropped" || array3 == "failed")
        //            {
        //                //retFlag = 0;
        //                //sdb.Update_statusAgentPaymentGatewayByAPI(zPG_Transaction_ID);
        //                message = array3;
        //                msgType = "error";

        //            }
        //            else if (array3 == "in progress" || array3 == "pending")
        //            {
        //                //retFlag = 0;
        //                message = array3;
        //                msgType = "warning";
        //            }
        //            else
        //            {
        //                //retFlag = 0;
        //                message = array3;
        //                msgType = "warning";
        //            }

        //        }
        //        else
        //        {
        //            retFlag = 0;
        //            message = "No record found in payment gateway verification.";
        //            msgType = "error";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //        msgType = "error";
        //    }

        //    return Json(new
        //    {
        //        status = retFlag,
        //        message = message,
        //        type = msgType
        //    }, JsonRequestBehavior.AllowGet);
        //}

        [AllowAnonymous]
        public ActionResult DeleteAgentreverify(string zPG_Transaction_ID)
        {
            ClsMethod_AgentApplication_PaymentIntegration objPayment = new ClsMethod_AgentApplication_PaymentIntegration();
            ClsPrp_AgentApplication_PaymentIntegration prp = new ClsPrp_AgentApplication_PaymentIntegration();

            DateTime To_date = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            DateTime From_date = DateTime.Now.AddDays(-21).Date;

            prp.AgentPayment = objPayment.Display_AgentApplication_PaymentReverify(To_date, From_date);
            return View(prp);
        }



        [AllowAnonymous]
        [HttpGet]
        public JsonResult reverifyTxnAPI(string zPG_Transaction_ID)
        {
            var result = AgentPaymentReverifyService.ReverifyTransaction(zPG_Transaction_ID);
            return Json(new { status = result.Status, message = result.Message, type = result.MessageType }, JsonRequestBehavior.AllowGet);
        }
    }
}
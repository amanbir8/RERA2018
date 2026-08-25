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
using CRUD.Models.classProjectExtensionPayment;
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

namespace CRUD.Controllers.classProjectExtensionPayment
{
    [Authorize]
    [Authorize(Roles = "Promoter")]
    public class ProjectExtensionPaymentController : Controller
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

        #region ePaymeny Input Project-Extension-Registration-Application

        [HttpGet]
        public ActionResult RequestProjectExtensionApplicationPayment()
        {
            ClsPrp_ProjectExtensionApplication_PaymentIntegration objAppPayment = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();
            ClsMethod_ProjectExtensionApplication_PaymentIntegration objPayment = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_ProjectExtensionApplication_Registration objRegistrationApp = new ClsPrp_ProjectExtensionApplication_Registration();
            ClsPrp_ProjectExtensionPayment objgetPayment = new ClsPrp_ProjectExtensionPayment();

            Int64 Project_ID = 0;
            Int64 Promoter_ID = 0;
            Int64 ProjectPmApplicationPaymentID = 0;
            Int64 ProjectPmApplicationPaymentIndexID = 0;
            Int64 PaymentPRN = 0;

            Int64 ProjectExtension_ID = 0;
            Int32 ProjectExtension_SequenceID = 0;
            Int32 ProjectExtension_Year = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Promoter_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["Project_id"].ToString() != "0")
                {
                    Project_ID = Convert.ToInt64(Session["Project_id"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            if (Session["RequestProjectPmPaymentID"] != null)
            {
                if (Session["RequestProjectPmPaymentID"].ToString() != "0")
                {
                    ProjectPmApplicationPaymentID = Convert.ToInt64(Session["RequestProjectPmPaymentID"]);
                }
            }
            if (Session["RequestProjectPmPaymentIndexID"] != null)
            {
                if (Session["RequestProjectPmPaymentIndexID"].ToString() != "0")
                {
                    ProjectPmApplicationPaymentIndexID = Convert.ToInt64(Session["RequestProjectPmPaymentIndexID"]);
                }
            }

            objRegistrationApp.ProjectExtensionApplication = objPayment.Display_ProjectExtensionApplication_RegistrationByID(Project_ID, Promoter_ID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year);
            if (objRegistrationApp.ProjectExtensionApplication.Count >= 1)
            {
                foreach (var item in objRegistrationApp.ProjectExtensionApplication)
                {
                    #region parameters
                    objRegistrationApp.ProjectRegistration_IndexID = item.ProjectRegistration_IndexID;
                    objRegistrationApp.ProjectRegistration_ID = item.ProjectRegistration_ID;

                    objRegistrationApp.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    objRegistrationApp.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    objRegistrationApp.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    objRegistrationApp.Project_Name = item.Project_Name;
                    //objRegistrationApp.Project_Amenities = item.Project_Amenities;
                    //objRegistrationApp.IsAlready_RERANumber = item.IsAlready_RERANumber;
                    //objRegistrationApp.Existing_RERANumber = item.Existing_RERANumber;
                    //objRegistrationApp.ProposedProjectDetail_Structure = item.ProposedProjectDetail_Structure;
                    //objRegistrationApp.ProposedProjectDetail_Flooring = item.ProposedProjectDetail_Flooring;
                    //objRegistrationApp.ProposedProjectDetail_WallFinishing = item.ProposedProjectDetail_WallFinishing;
                    //objRegistrationApp.ProposedProjectDetail_SanitaryFittings = item.ProposedProjectDetail_SanitaryFittings;
                    //objRegistrationApp.ProposedProjectDetail_ElectricalFittings = item.ProposedProjectDetail_ElectricalFittings;
                    //objRegistrationApp.ProposedProjectDetail_Kitchen = item.ProposedProjectDetail_Kitchen;
                    //objRegistrationApp.IsProposedProjectDetail_OthersIfAny = item.IsProposedProjectDetail_OthersIfAny;
                    //objRegistrationApp.ProposedProjectDetail_OthersIfAnyName = item.ProposedProjectDetail_OthersIfAnyName;
                    //objRegistrationApp.ProposedProjectDetail_OthersIfAny = item.ProposedProjectDetail_OthersIfAny;
                    objRegistrationApp.Project_Status = item.Project_Status;
                    objRegistrationApp.ProjectStart_Date = item.ProjectStart_Date;
                    objRegistrationApp.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                    objRegistrationApp.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                    objRegistrationApp.ProjectRegistrationProvided_Duration = item.ProjectRegistrationProvided_Duration;
                    objRegistrationApp.ProjectDelayReason_IfAny = item.ProjectDelayReason_IfAny;
                    objRegistrationApp.Project_AddressLine1 = item.Project_AddressLine1;
                    objRegistrationApp.Project_AddressLine2 = item.Project_AddressLine2;
                    objRegistrationApp.Project_AddressStateCode = item.Project_AddressStateCode;
                    objRegistrationApp.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                    objRegistrationApp.Project_AddressSubDivisionCode = item.Project_AddressSubDivisionCode;
                    objRegistrationApp.Project_AddressPIN = item.Project_AddressPIN;
                    objRegistrationApp.Project_PotentialZoneCode = item.Project_PotentialZoneCode;
                    objRegistrationApp.ProjectWebsite_WebLink = item.ProjectWebsite_WebLink;
                    objRegistrationApp.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                    objRegistrationApp.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                    objRegistrationApp.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;
                    objRegistrationApp.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                    objRegistrationApp.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                    objRegistrationApp.AuthorizedPerson_AddressStateCode = item.AuthorizedPerson_AddressStateCode;
                    objRegistrationApp.AuthorizedPerson_AddressDistrictCode = item.AuthorizedPerson_AddressDistrictCode;
                    objRegistrationApp.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;
                    objRegistrationApp.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                    objRegistrationApp.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;
                    objRegistrationApp.IsProForma_AOS_RERAformat_AnnexureA = item.IsProForma_AOS_RERAformat_AnnexureA;
                    objRegistrationApp.IsProForma_AOS_RERAformat_No_IsApproved = item.IsProForma_AOS_RERAformat_No_IsApproved;
                    objRegistrationApp.IsProject_MegaProjectCategory = item.IsProject_MegaProjectCategory;
                    objRegistrationApp.IsLitigation_RelatedProject = item.IsLitigation_RelatedProject;

                    objRegistrationApp.Remarks_IfAny = item.Remarks_IfAny;
                    objRegistrationApp.A_column = item.A_column;
                    objRegistrationApp.B_column = item.B_column;
                    objRegistrationApp.C_column = item.C_column;
                    objRegistrationApp.IsActive = item.IsActive;
                    objRegistrationApp.IsDraft = item.IsDraft;
                    objRegistrationApp.CreatedBy = item.CreatedBy;
                    objRegistrationApp.CreatedOn = item.CreatedOn;
                    objRegistrationApp.ModifyBy = item.ModifyBy;
                    objRegistrationApp.ModifyOn = item.ModifyOn;

                    objRegistrationApp.Promoter_ID = item.Promoter_ID;
                    objRegistrationApp.Used_ID = item.Used_ID;

                    objRegistrationApp.Project_AddressStateCodeName = item.Project_AddressStateCodeName;
                    objRegistrationApp.Project_AddressDistrictCodeName = item.Project_AddressDistrictCodeName;
                    objRegistrationApp.Project_AddressSubDivisionCodeName = item.Project_AddressSubDivisionCodeName;
                    objRegistrationApp.Project_PotentialZoneCodeName = item.Project_PotentialZoneCodeName;
                    objRegistrationApp.AuthorizedPerson_AddressStateCodeName = item.AuthorizedPerson_AddressStateCodeName;
                    objRegistrationApp.AuthorizedPerson_AddressDistrictCodeName = item.AuthorizedPerson_AddressDistrictCodeName;
                    #endregion
                }
            }

            // check from mySQLdb and payudb server for getdetailpayment
            // if yes then getdetail cshtml page table data show 
            // (firstly check sqldb and secondly check payu API service)

            objAppPayment.ProjectExtensionPayment = objPayment.Display_ProjectExtensionApplication_PaymentById(Project_ID, Promoter_ID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year, ProjectPmApplicationPaymentIndexID, ProjectPmApplicationPaymentID, PaymentPRN);
            if (objAppPayment.ProjectExtensionPayment.Count >= 1)
            {
                foreach (var item in objAppPayment.ProjectExtensionPayment)
                {
                    #region parameters
                    objAppPayment.PaymentRefNumberProjectPm_IndexID = item.PaymentRefNumberProjectPm_IndexID;
                    objAppPayment.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    objAppPayment.RelatedProject_ID = item.RelatedProject_ID;
                    objAppPayment.RelatedPromoter_ID = item.RelatedPromoter_ID;
                    objAppPayment.RelatedProject_Code = item.RelatedProject_Code;
                    objAppPayment.RelatedPromoter_Code = item.RelatedPromoter_Code;
                    objAppPayment.RelatedPayment_ID = item.RelatedPayment_ID;
                    objAppPayment.RelatedPayment_IndexID = item.RelatedPayment_IndexID;
                    objAppPayment.User_ID = item.User_ID;

                    objAppPayment.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    objAppPayment.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    objAppPayment.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    objAppPayment.ProjectPmZoneType = item.ProjectPmZoneType;
                    objAppPayment.PromoterType_IO = item.PromoterType_IO;
                    objAppPayment.User_Name = item.User_Name;

                    objAppPayment.ProjectPm_BriefSummary = item.ProjectPm_BriefSummary;
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
                    Tuple<int, long, long, long, long> tptemp = getProjectPmPaymentDetailsByTxnAPI(objAppPayment.PG_Transaction_ID);
                    if (tptemp.Item1 == 1)
                    {
                        // Payment - Done But Confirmation Pending
                        TempData["submitvalueProjectExtensionAppPayment"] = "Proceed"; TempData.Keep();
                        return RedirectToAction("getprojectpmapplicationpayment", "ProjectPmPayment");
                    }
                    else
                    {
                        // Payment - Pending OR Failure
                        TempData["submitvalueProjectExtensionAppPayment"] = "Make Payment"; TempData.Keep();
                    }
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueProjectExtensionAppPayment"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                objgetPayment.ProjectExtensionPayment = objPayment.Display_ProjectExtensionPaymentDetailsByID(Project_ID, Promoter_ID, ProjectPmApplicationPaymentID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year);
                if (objgetPayment.ProjectExtensionPayment.Count >= 1)
                {
                    foreach (var item in objgetPayment.ProjectExtensionPayment)
                    {
                        #region parameters
                        objgetPayment.ProjectPayment_IndexID = item.ProjectPayment_IndexID;
                        objgetPayment.ProjectPayment_ID = item.ProjectPayment_ID;
                        objgetPayment.ProjectPaymentRelated_ProjectRegistration_ID = item.ProjectPaymentRelated_ProjectRegistration_ID;
                        objgetPayment.ProjectPaymentRelated_Promoter_ID = item.ProjectPaymentRelated_Promoter_ID;

                        objgetPayment.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                        objgetPayment.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                        objgetPayment.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                        objgetPayment.ProjectPayment_TitleCode = item.ProjectPayment_TitleCode;
                        objgetPayment.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
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
                    //No records found - table Payment 
                    //reference with Project Registration and Online Payment Info                     
                    objAppPayment.PaymentRefNumberProjectPm_IndexID = 0;
                    objAppPayment.PaymentRefNumberProjectPm_ID = 0;
                    objAppPayment.RelatedProject_ID = objRegistrationApp.ProjectRegistration_ID;
                    objAppPayment.RelatedPromoter_ID = objRegistrationApp.Promoter_ID;
                    objAppPayment.RelatedProject_Code = Convert.ToString(objRegistrationApp.ProjectRegistration_ID);
                    objAppPayment.RelatedPromoter_Code = Convert.ToString(objRegistrationApp.Promoter_ID);
                    objAppPayment.RelatedPayment_ID = ProjectPmApplicationPaymentID; // session or query string
                    objAppPayment.RelatedPayment_IndexID = ProjectPmApplicationPaymentIndexID; // session or query string
                    objAppPayment.User_ID = UID;

                    objAppPayment.Related_ProjectExtension_ID = objRegistrationApp.Related_ProjectExtension_ID;
                    objAppPayment.Related_ProjectExtension_SequenceID = objRegistrationApp.Related_ProjectExtension_SequenceID;
                    objAppPayment.Related_ProjectExtension_Year = objRegistrationApp.Related_ProjectExtension_Year;

                    objAppPayment.ProjectPmZoneType = Convert.ToString(objRegistrationApp.Project_PotentialZoneCode); // "Zone Type";
                    objAppPayment.PromoterType_IO = Convert.ToString(objRegistrationApp.Project_PotentialZoneCode); // "Ind or OtherThanInd";
                    objAppPayment.User_Name = userName;

                    objAppPayment.PG_Shipping_Address1 = objRegistrationApp.AuthorizedPerson_AddressLine1;
                    objAppPayment.PG_Shipping_Address2 = objRegistrationApp.AuthorizedPerson_AddressLine2;
                    objAppPayment.PG_Shipping_City = objdis.District_Name(Convert.ToInt32(objRegistrationApp.AuthorizedPerson_AddressDistrictCode));
                    objAppPayment.PG_Shipping_State = objdis.State_Name(Convert.ToInt32(objRegistrationApp.AuthorizedPerson_AddressStateCode));
                    objAppPayment.PG_Shipping_Country = "India";
                    objAppPayment.PG_Shipping_Zipcode = Convert.ToString(objRegistrationApp.AuthorizedPerson_AddressPIN);
                    objAppPayment.PG_Shipping_Phone = Convert.ToString(objRegistrationApp.AuthorizedPerson_MobileNumber);

                    objAppPayment.PG_Customer_Email = objRegistrationApp.AuthorizedPerson_EmailAddress; //Email ID
                    objAppPayment.PG_Customer_Phone = Convert.ToString(objRegistrationApp.AuthorizedPerson_MobileNumber); //Phone/Mobile 

                    objAppPayment.PG_Address_Line1 = objRegistrationApp.Project_AddressLine1;
                    objAppPayment.PG_Address_Line2 = objRegistrationApp.Project_AddressLine2;
                    objAppPayment.PG_City = objdis.District_Name(Convert.ToInt32(objRegistrationApp.Project_AddressDistrictCode));
                    objAppPayment.PG_State = objdis.State_Name(Convert.ToInt32(objRegistrationApp.Project_AddressStateCode));
                    objAppPayment.PG_Country = "India";
                    objAppPayment.PG_ZipCode = Convert.ToString(objRegistrationApp.Project_AddressPIN);

                    //Profile Related Info
                    objAppPayment.PG_Product_Info = "Project Application Fee (Registration)";
                    objAppPayment.PG_Transaction_Fee = 0;
                    objAppPayment.PG_Discount = 0;
                    objAppPayment.PG_Additional_Charges = 0;
                    objAppPayment.PG_Amount_INR = objgetPayment.DD_BankersCheque_Amount;
                    objAppPayment.PG_Amount = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                    objAppPayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                    objAppPayment.PG_Shipping_Firstname = objRegistrationApp.AuthorizedPerson_FirstName + " " + objRegistrationApp.AuthorizedPerson_MiddleName;
                    objAppPayment.PG_Shipping_Lastname = objRegistrationApp.AuthorizedPerson_LastName;
                    objAppPayment.PG_Customer_Name = objRegistrationApp.AuthorizedPerson_FirstName + " " + objRegistrationApp.AuthorizedPerson_MiddleName; //Name
                    objAppPayment.PG_Last_Name = objRegistrationApp.AuthorizedPerson_LastName;
                    #endregion
                }
                TempData["submitvalueProjectExtensionAppPayment"] = "Make Payment"; TempData.Keep();
            }
            return View("RequestProjectExtensionApplicationPayment", objAppPayment);
        }

        [HttpGet]
        public ActionResult Detail_RequestProjectExtensionApplicationPayment(Int64? RelatedPaymentCode, Int64? RelatedPaymentICode)
        {
            ClsPrp_ProjectExtensionApplication_PaymentIntegration objAppPayment = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();
            ClsMethod_ProjectExtensionApplication_PaymentIntegration objPayment = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();
            ClsPrp_ProjectExtensionApplication_Registration objRegistrationApp = new ClsPrp_ProjectExtensionApplication_Registration();
            ClsPrp_ProjectExtensionPayment objgetPayment = new ClsPrp_ProjectExtensionPayment();

            Int64 Project_ID = 0;
            Int64 Promoter_ID = 0;
            Int64 ProjectPmApplicationPaymentID = 0;
            Int64 ProjectPmApplicationPaymentIndexID = 0;
            Int64 PaymentPRN = 0;

            Int64 ProjectExtension_ID = 0;
            Int32 ProjectExtension_SequenceID = 0;
            Int32 ProjectExtension_Year = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (RelatedPaymentCode != null)
            {
                if (RelatedPaymentCode.ToString() != "0")
                {
                    ProjectPmApplicationPaymentID = Convert.ToInt64(RelatedPaymentCode);
                    Session["RequestProjectPmPaymentID"] = ProjectPmApplicationPaymentID;
                }
            }
            if (RelatedPaymentICode != null)
            {
                if (RelatedPaymentICode.ToString() != "0")
                {
                    ProjectPmApplicationPaymentIndexID = Convert.ToInt64(RelatedPaymentICode);
                    Session["RequestProjectPmPaymentIndexID"] = ProjectPmApplicationPaymentIndexID;
                }
            }

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Promoter_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["Project_id"].ToString() != "0")
                {
                    Project_ID = Convert.ToInt64(Session["Project_id"]);
                }
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            objRegistrationApp.ProjectExtensionApplication = objPayment.Display_ProjectExtensionApplication_RegistrationByID(Project_ID, Promoter_ID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year);
            if (objRegistrationApp.ProjectExtensionApplication.Count >= 1)
            {
                foreach (var item in objRegistrationApp.ProjectExtensionApplication)
                {
                    #region paramerters
                    objRegistrationApp.ProjectRegistration_IndexID = item.ProjectRegistration_IndexID;
                    objRegistrationApp.ProjectRegistration_ID = item.ProjectRegistration_ID;

                    objRegistrationApp.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    objRegistrationApp.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    objRegistrationApp.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    objRegistrationApp.Project_Name = item.Project_Name;
                    //objRegistrationApp.Project_Amenities = item.Project_Amenities;
                    //objRegistrationApp.IsAlready_RERANumber = item.IsAlready_RERANumber;
                    //objRegistrationApp.Existing_RERANumber = item.Existing_RERANumber;
                    //objRegistrationApp.ProposedProjectDetail_Structure = item.ProposedProjectDetail_Structure;
                    //objRegistrationApp.ProposedProjectDetail_Flooring = item.ProposedProjectDetail_Flooring;
                    //objRegistrationApp.ProposedProjectDetail_WallFinishing = item.ProposedProjectDetail_WallFinishing;
                    //objRegistrationApp.ProposedProjectDetail_SanitaryFittings = item.ProposedProjectDetail_SanitaryFittings;
                    //objRegistrationApp.ProposedProjectDetail_ElectricalFittings = item.ProposedProjectDetail_ElectricalFittings;
                    //objRegistrationApp.ProposedProjectDetail_Kitchen = item.ProposedProjectDetail_Kitchen;
                    //objRegistrationApp.IsProposedProjectDetail_OthersIfAny = item.IsProposedProjectDetail_OthersIfAny;
                    //objRegistrationApp.ProposedProjectDetail_OthersIfAnyName = item.ProposedProjectDetail_OthersIfAnyName;
                    //objRegistrationApp.ProposedProjectDetail_OthersIfAny = item.ProposedProjectDetail_OthersIfAny;
                    objRegistrationApp.Project_Status = item.Project_Status;
                    objRegistrationApp.ProjectStart_Date = item.ProjectStart_Date;
                    objRegistrationApp.ProjectCompletion_ProposedDate = item.ProjectCompletion_ProposedDate;
                    objRegistrationApp.ProjectCompletion_OriginalDate = item.ProjectCompletion_OriginalDate;
                    objRegistrationApp.ProjectRegistrationProvided_Duration = item.ProjectRegistrationProvided_Duration;
                    objRegistrationApp.ProjectDelayReason_IfAny = item.ProjectDelayReason_IfAny;
                    objRegistrationApp.Project_AddressLine1 = item.Project_AddressLine1;
                    objRegistrationApp.Project_AddressLine2 = item.Project_AddressLine2;
                    objRegistrationApp.Project_AddressStateCode = item.Project_AddressStateCode;
                    objRegistrationApp.Project_AddressDistrictCode = item.Project_AddressDistrictCode;
                    objRegistrationApp.Project_AddressSubDivisionCode = item.Project_AddressSubDivisionCode;
                    objRegistrationApp.Project_AddressPIN = item.Project_AddressPIN;
                    objRegistrationApp.Project_PotentialZoneCode = item.Project_PotentialZoneCode;
                    objRegistrationApp.ProjectWebsite_WebLink = item.ProjectWebsite_WebLink;
                    objRegistrationApp.AuthorizedPerson_FirstName = item.AuthorizedPerson_FirstName;
                    objRegistrationApp.AuthorizedPerson_MiddleName = item.AuthorizedPerson_MiddleName;
                    objRegistrationApp.AuthorizedPerson_LastName = item.AuthorizedPerson_LastName;
                    objRegistrationApp.AuthorizedPerson_AddressLine1 = item.AuthorizedPerson_AddressLine1;
                    objRegistrationApp.AuthorizedPerson_AddressLine2 = item.AuthorizedPerson_AddressLine2;
                    objRegistrationApp.AuthorizedPerson_AddressStateCode = item.AuthorizedPerson_AddressStateCode;
                    objRegistrationApp.AuthorizedPerson_AddressDistrictCode = item.AuthorizedPerson_AddressDistrictCode;
                    objRegistrationApp.AuthorizedPerson_AddressPIN = item.AuthorizedPerson_AddressPIN;
                    objRegistrationApp.AuthorizedPerson_EmailAddress = item.AuthorizedPerson_EmailAddress;
                    objRegistrationApp.AuthorizedPerson_MobileNumber = item.AuthorizedPerson_MobileNumber;
                    objRegistrationApp.IsProForma_AOS_RERAformat_AnnexureA = item.IsProForma_AOS_RERAformat_AnnexureA;
                    objRegistrationApp.IsProForma_AOS_RERAformat_No_IsApproved = item.IsProForma_AOS_RERAformat_No_IsApproved;
                    objRegistrationApp.IsProject_MegaProjectCategory = item.IsProject_MegaProjectCategory;
                    objRegistrationApp.IsLitigation_RelatedProject = item.IsLitigation_RelatedProject;

                    objRegistrationApp.Remarks_IfAny = item.Remarks_IfAny;
                    objRegistrationApp.A_column = item.A_column;
                    objRegistrationApp.B_column = item.B_column;
                    objRegistrationApp.C_column = item.C_column;
                    objRegistrationApp.IsActive = item.IsActive;
                    objRegistrationApp.IsDraft = item.IsDraft;
                    objRegistrationApp.CreatedBy = item.CreatedBy;
                    objRegistrationApp.CreatedOn = item.CreatedOn;
                    objRegistrationApp.ModifyBy = item.ModifyBy;
                    objRegistrationApp.ModifyOn = item.ModifyOn;

                    objRegistrationApp.Promoter_ID = item.Promoter_ID;
                    objRegistrationApp.Used_ID = item.Used_ID;

                    objRegistrationApp.Project_AddressStateCodeName = item.Project_AddressStateCodeName;
                    objRegistrationApp.Project_AddressDistrictCodeName = item.Project_AddressDistrictCodeName;
                    objRegistrationApp.Project_AddressSubDivisionCodeName = item.Project_AddressSubDivisionCodeName;
                    objRegistrationApp.Project_PotentialZoneCodeName = item.Project_PotentialZoneCodeName;
                    objRegistrationApp.AuthorizedPerson_AddressStateCodeName = item.AuthorizedPerson_AddressStateCodeName;
                    objRegistrationApp.AuthorizedPerson_AddressDistrictCodeName = item.AuthorizedPerson_AddressDistrictCodeName;
                    #endregion
                }
            }

            // check from mySQLdb and payudb server for getdetailpayment
            // if yes then getdetail cshtml page table data show 
            // (firstly check sqldb and secondly check payu API service)

            objAppPayment.ProjectExtensionPayment = objPayment.Display_ProjectExtensionApplication_PaymentById(Project_ID, Promoter_ID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year, ProjectPmApplicationPaymentIndexID, ProjectPmApplicationPaymentID, PaymentPRN);
            // PRN Exist - Case
            if (objAppPayment.ProjectExtensionPayment.Count >= 1)
            {
                foreach (var item in objAppPayment.ProjectExtensionPayment)
                {
                    #region paramerters
                    objAppPayment.PaymentRefNumberProjectPm_IndexID = item.PaymentRefNumberProjectPm_IndexID;
                    objAppPayment.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    objAppPayment.RelatedProject_ID = item.RelatedProject_ID;
                    objAppPayment.RelatedPromoter_ID = item.RelatedPromoter_ID;
                    objAppPayment.RelatedProject_Code = item.RelatedProject_Code;
                    objAppPayment.RelatedPromoter_Code = item.RelatedPromoter_Code;
                    objAppPayment.RelatedPayment_ID = item.RelatedPayment_ID;
                    objAppPayment.RelatedPayment_IndexID = item.RelatedPayment_IndexID;
                    objAppPayment.User_ID = item.User_ID;

                    objAppPayment.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    objAppPayment.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    objAppPayment.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    objAppPayment.ProjectPmZoneType = item.ProjectPmZoneType;
                    objAppPayment.PromoterType_IO = item.PromoterType_IO;
                    objAppPayment.User_Name = item.User_Name;

                    objAppPayment.ProjectPm_BriefSummary = item.ProjectPm_BriefSummary;
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
                    Tuple<int, long, long, long, long> tptemp = getProjectPmPaymentDetailsByTxnAPI(objAppPayment.PG_Transaction_ID);

                    if(tptemp.Item1 == 1)
                    {
                        // Payment - Done But Confirmation Pending
                        TempData["submitvalueProjectExtensionAppPayment"] = "Proceed"; TempData.Keep();
                        // Payment - Confirm Action
                        return RedirectToAction("getprojectextensionapplicationpayment", "ProjectExtensionPayment");
                    }
                    else
                    {
                        // Payment - Pending OR Failure
                        TempData["submitvalueProjectExtensionAppPayment"] = "Make Payment"; TempData.Keep();
                    }                    
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueProjectExtensionAppPayment"] = "Proceed"; TempData.Keep();
                }
            }
            else
            {
                //New Payment Case (ProjectRegistrationPayment Details + Payment Setting Details) 
                objgetPayment.ProjectExtensionPayment = objPayment.Display_ProjectExtensionPaymentDetailsByID(Project_ID, Promoter_ID, ProjectPmApplicationPaymentID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year);
                if (objgetPayment.ProjectExtensionPayment.Count >= 1)
                {
                    foreach (var item in objgetPayment.ProjectExtensionPayment)
                    {
                        #region paramerters
                        objgetPayment.ProjectPayment_IndexID = item.ProjectPayment_IndexID;
                        objgetPayment.ProjectPayment_ID = item.ProjectPayment_ID;
                        objgetPayment.ProjectPaymentRelated_ProjectRegistration_ID = item.ProjectPaymentRelated_ProjectRegistration_ID;
                        objgetPayment.ProjectPaymentRelated_Promoter_ID = item.ProjectPaymentRelated_Promoter_ID;

                        objgetPayment.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                        objgetPayment.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                        objgetPayment.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                        objgetPayment.ProjectPayment_TitleCode = item.ProjectPayment_TitleCode;
                        objgetPayment.ProjectPayment_TitleName = item.ProjectPayment_TitleName;
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
                    //No records found - table Payment 
                    //reference with Project Registration and Online Payment Info                     
                    objAppPayment.PaymentRefNumberProjectPm_IndexID = 0;
                    objAppPayment.PaymentRefNumberProjectPm_ID = 0;
                    objAppPayment.RelatedProject_ID = objRegistrationApp.ProjectRegistration_ID;
                    objAppPayment.RelatedPromoter_ID = objRegistrationApp.Promoter_ID;
                    objAppPayment.RelatedProject_Code = Convert.ToString(objRegistrationApp.ProjectRegistration_ID);
                    objAppPayment.RelatedPromoter_Code = Convert.ToString(objRegistrationApp.Promoter_ID);
                    objAppPayment.RelatedPayment_ID = ProjectPmApplicationPaymentID; // session or query string
                    objAppPayment.RelatedPayment_IndexID = ProjectPmApplicationPaymentIndexID; // session or query string
                    objAppPayment.User_ID = UID;

                    objAppPayment.Related_ProjectExtension_ID = objRegistrationApp.Related_ProjectExtension_ID;
                    objAppPayment.Related_ProjectExtension_SequenceID = objRegistrationApp.Related_ProjectExtension_SequenceID;
                    objAppPayment.Related_ProjectExtension_Year = objRegistrationApp.Related_ProjectExtension_Year;

                    objAppPayment.ProjectPmZoneType = Convert.ToString(objRegistrationApp.Project_PotentialZoneCode); // "Zone Type";
                    objAppPayment.PromoterType_IO = Convert.ToString(objRegistrationApp.Project_PotentialZoneCode); // "Ind or OtherThanInd";
                    objAppPayment.User_Name = userName;

                    objAppPayment.PG_Shipping_Address1 = objRegistrationApp.AuthorizedPerson_AddressLine1;
                    objAppPayment.PG_Shipping_Address2 = objRegistrationApp.AuthorizedPerson_AddressLine2;
                    objAppPayment.PG_Shipping_City = objdis.District_Name(Convert.ToInt32(objRegistrationApp.AuthorizedPerson_AddressDistrictCode));
                    objAppPayment.PG_Shipping_State = objdis.State_Name(Convert.ToInt32(objRegistrationApp.AuthorizedPerson_AddressStateCode));
                    objAppPayment.PG_Shipping_Country = "India";
                    objAppPayment.PG_Shipping_Zipcode = Convert.ToString(objRegistrationApp.AuthorizedPerson_AddressPIN);
                    objAppPayment.PG_Shipping_Phone = Convert.ToString(objRegistrationApp.AuthorizedPerson_MobileNumber);

                    objAppPayment.PG_Customer_Email = objRegistrationApp.AuthorizedPerson_EmailAddress; //Email ID
                    objAppPayment.PG_Customer_Phone = Convert.ToString(objRegistrationApp.AuthorizedPerson_MobileNumber); //Phone/Mobile 

                    objAppPayment.PG_Address_Line1 = objRegistrationApp.Project_AddressLine1;
                    objAppPayment.PG_Address_Line2 = objRegistrationApp.Project_AddressLine2;
                    objAppPayment.PG_City = objdis.District_Name(Convert.ToInt32(objRegistrationApp.Project_AddressDistrictCode));
                    objAppPayment.PG_State = objdis.State_Name(Convert.ToInt32(objRegistrationApp.Project_AddressStateCode));
                    objAppPayment.PG_Country = "India";
                    objAppPayment.PG_ZipCode = Convert.ToString(objRegistrationApp.Project_AddressPIN);

                    //Profile Related Info
                    objAppPayment.PG_Product_Info = "Project Application Fee (Registration)";
                    objAppPayment.PG_Transaction_Fee = 0;
                    objAppPayment.PG_Discount = 0;
                    objAppPayment.PG_Additional_Charges = 0;
                    objAppPayment.PG_Amount_INR = objgetPayment.DD_BankersCheque_Amount;
                    objAppPayment.PG_Amount = objgetPayment.Registration_Fee + objgetPayment.Other_Fee;
                    objAppPayment.PG_Merchant_Name = "rera.punjab.gov.in (payubiz)";

                    objAppPayment.PG_Shipping_Firstname = objRegistrationApp.AuthorizedPerson_FirstName + " " + objRegistrationApp.AuthorizedPerson_MiddleName;
                    objAppPayment.PG_Shipping_Lastname = objRegistrationApp.AuthorizedPerson_LastName;
                    objAppPayment.PG_Customer_Name = objRegistrationApp.AuthorizedPerson_FirstName + " " + objRegistrationApp.AuthorizedPerson_MiddleName; //Name
                    objAppPayment.PG_Last_Name = objRegistrationApp.AuthorizedPerson_LastName;
                    #endregion
                }
                TempData["submitvalueProjectExtensionAppPayment"] = "Make Payment"; TempData.Keep();
            }
            return View("RequestProjectExtensionApplicationPayment", objAppPayment);
        }

        [HttpPost]
        public void RequestProjectExtensionApplicationPayment(ClsPrp_ProjectExtensionApplication_PaymentIntegration dm)
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
            string udf3 = Convert.ToString(dm.RelatedPayment_ID);
            string udf4 = Convert.ToString(dm.RelatedProject_ID);
            string udf5 = Convert.ToString(dm.RelatedPayment_IndexID);

            #region Save & Update - Table Payment
            ClsMethod_ProjectExtensionApplication_PaymentIntegration objFormAppM = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            Int64 p_PaymentRefNumber = 0;

            if (TempData["submitvalueProjectExtensionAppPayment"].ToString() == "Make Payment")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        dm.PG_UDF_2 = dm.PG_Product_Info;
                        dm.PG_UDF_3 = Convert.ToString(dm.RelatedPayment_ID);
                        dm.PG_UDF_4 = Convert.ToString(dm.RelatedProject_ID);
                        dm.PG_UDF_5 = Convert.ToString(dm.RelatedPayment_IndexID);

                        p_PaymentRefNumber = objFormAppM.Add_ProjectExtensionApplication_Payment(dm, UID, userName, txnid, "0");
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
                RedirectToAction("getdetailpaymentprojectextensionapplication", "ProjectExtensionPayment");
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

            myremotepost.Add("surl", DomainNameURL + "/ProjectExtensionPayment/successpaymentprojectextensionapp");
            myremotepost.Add("furl", DomainNameURL + "/ProjectExtensionPayment/failurepaymentprojectextensionapp/" + p_PaymentRefNumber);        
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

        #region ePayment Output Project-Extension-Registration-Application

        [AllowAnonymous]        
        public ActionResult successpaymentprojectextensionapp(FormCollection form = null)
        {
            string salt = ConfigurationManager.AppSettings["payuSalt"];

            Int64 ProjectExtension_ID = 0;
            Int32 ProjectExtension_SequenceID = 0;
            Int32 ProjectExtension_Year = 0;

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

            ClsMethod_ProjectExtensionApplication_PaymentIntegration sdb = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();
            ClsPrp_ProjectExtensionApplication_PaymentIntegration aa = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();

            Int64 PRN_udf1 = String.IsNullOrEmpty(v_udf1) ? 0 : Convert.ToInt64(v_udf1);
            aa.ProjectExtensionPayment = sdb.Display_ProjectExtensionApplication_PaymentByPRN(PRN_udf1, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year);

            if (aa.ProjectExtensionPayment.Count >= 1)
            {
                foreach (var item in aa.ProjectExtensionPayment)
                {
                    aa.PaymentRefNumberProjectPm_IndexID = item.PaymentRefNumberProjectPm_IndexID;
                    aa.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    aa.RelatedProject_ID = item.RelatedProject_ID;
                    aa.RelatedPromoter_ID = item.RelatedPromoter_ID;
                    aa.RelatedProject_Code = item.RelatedProject_Code;
                    aa.RelatedPromoter_Code = item.RelatedPromoter_Code;
                    aa.RelatedPayment_ID = item.RelatedPayment_ID;
                    aa.RelatedPayment_IndexID = item.RelatedPayment_IndexID;
                    aa.User_ID = item.User_ID;

                    aa.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    aa.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    aa.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    aa.ProjectPmZoneType = item.ProjectPmZoneType;
                    aa.PromoterType_IO = item.PromoterType_IO;
                    aa.User_Name = item.User_Name;

                    aa.ProjectPm_BriefSummary = item.ProjectPm_BriefSummary;
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
                    TempData["submitvalueProjectExtensionAppPaymentsurl"] = "Proceed"; TempData.Keep();
                }
                else
                {
                    // Payment - DONE
                    TempData["submitvalueProjectExtensionAppPaymentsurl"] = "Next"; TempData.Keep();
                }
            }
            try
            {
                aa.PG_Transaction_ID = order_id;
                aa.PG_Date = DateTime.Now;
                aa.PG_PayU_ID = Convert.ToInt64(v_mihpayid);
                aa.PG_Amount = Convert.ToDecimal(v_amount);
                aa.PG_Transaction_Fee = Convert.ToDecimal(v_amount);
                aa.PG_Additional_Charges = 0;
                aa.PG_Status = v_status;
                aa.ProjectPm_BriefSummary = v_status;
                aa.FailureSuccessSummary = v_status;
                aa.PG_Product_Info = v_productInfo;
                aa.PG_Customer_Name = v_firstName;
                aa.PG_Customer_Email = v_email;

                aa.PG_UDF_1 = v_udf1;
                aa.PG_UDF_2 = v_udf2;
                aa.PG_UDF_3 = v_udf3;
                aa.PG_UDF_4 = v_udf4;
                aa.PG_UDF_5 = v_udf5;

                aa.PG_Bank_Reference_No = v_bank_ref_num;
                aa.PG_Payment_Type = v_mode; 
                aa.PG_Bank_Name = v_bankcode;
                aa.PG_Payment_Gateway = v_PG_TYPE;

                aa.IsPaymentSuccessComplete = 1;
                aa.PaymentSuccessDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                return RedirectToAction("getdetailpaymentprojectextensionapplication", "ProjectExtensionPayment");
            }
            return View(aa);
        }

        [HttpPost]
        public ActionResult successpaymentprojectextensionapplication(ClsPrp_ProjectExtensionApplication_PaymentIntegration dm)
        {

            ClsMethod_ProjectExtensionApplication_PaymentIntegration sdb = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();
            ClsPrp_ProjectExtensionApplication_PaymentIntegration aa = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueProjectExtensionAppPaymentsurl"].ToString() == "Proceed")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)
                    if (ModelState.IsValid)
                    {
                        if (sdb.Update_ProjectExtensionApplication_Payment(dm, UID, userName, IsPaymentSuccessCompleteFlag))
                        {
                            TempData["message"] = "Details Updated Successfully";                            
                        }
                        ModelState.Clear();
                    }                                       
                }
                return RedirectToAction("Create_ProjectExtensionPaymentDetails", "Project");                
            }

            catch (Exception ex)
            {
                string strex = ex.ToString();                
                TempData["PaymentMessage"] = "Bad Request, Try Again!";
                //dm.PG_Last_Name = strex;
                return RedirectToAction("getdetailpaymentprojectextensionapplication", "ProjectExtensionPayment");
            }
            #endregion
        }

        [AllowAnonymous]
        public ActionResult failurepaymentprojectextensionapp(int? id)
        {
            Int64 ProjectExtension_ID = 0;
            Int32 ProjectExtension_SequenceID = 0;
            Int32 ProjectExtension_Year = 0;

            ClsMethod_ProjectExtensionApplication_PaymentIntegration sdb = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();
            ClsPrp_ProjectExtensionApplication_PaymentIntegration aa = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();

            Int64 PRN_udf1 = id == null ? 0 : Convert.ToInt64(id);
            aa.ProjectExtensionPayment = sdb.Display_ProjectExtensionApplication_PaymentByPRN(PRN_udf1, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year);

            if (aa.ProjectExtensionPayment.Count >= 1)
            {
                foreach (var item in aa.ProjectExtensionPayment)
                {
                    aa.PaymentRefNumberProjectPm_IndexID = item.PaymentRefNumberProjectPm_IndexID;
                    aa.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    aa.RelatedProject_ID = item.RelatedProject_ID;
                    aa.RelatedPromoter_ID = item.RelatedPromoter_ID;
                    aa.RelatedProject_Code = item.RelatedProject_Code;
                    aa.RelatedPromoter_Code = item.RelatedPromoter_Code;
                    aa.RelatedPayment_ID = item.RelatedPayment_ID;
                    aa.RelatedPayment_IndexID = item.RelatedPayment_IndexID;
                    aa.User_ID = item.User_ID;

                    aa.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    aa.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    aa.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    aa.ProjectPmZoneType = item.ProjectPmZoneType;
                    aa.PromoterType_IO = item.PromoterType_IO;
                    aa.User_Name = item.User_Name;

                    aa.ProjectPm_BriefSummary = item.ProjectPm_BriefSummary;
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
        public ActionResult getdetailpaymentprojectextensionapplication()
        {
            return View();
        }

        #endregion

        #region ePayment GET TXN Details By Project Extension Payment TxnID

        [HttpGet]
        public ActionResult getprojectextensionapplicationpayment()
        {
            Int64 Project_ID = 0;
            Int64 Promoter_ID = 0;
            Int64 ProjectExtension_ID = 0;
            Int32 ProjectExtension_SequenceID = 0;
            Int32 ProjectExtension_Year = 0;
            Int64 ProjectPmApplicationPaymentID = 0;
            Int64 ProjectPmApplicationPaymentIndexID = 0;
            Int64 PaymentPRN = 0;

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Promoter_ID = Convert.ToInt64(Session["ApplicationId"]);
                }
                if (Session["Project_id"].ToString() != "0")
                {
                    Project_ID = Convert.ToInt64(Session["Project_id"]);
                }
                //Assign-Values Logic
                ProjectExtension_ID = 0;
                ProjectExtension_SequenceID = 0;
                ProjectExtension_Year = 0;
            }
            else
            {
                return RedirectToAction("SessionExpire", "Account");
            }

            if (Session["RequestProjectPmPaymentID"] != null)
            {
                if (Session["RequestProjectPmPaymentID"].ToString() != "0")
                {
                    ProjectPmApplicationPaymentID = Convert.ToInt64(Session["RequestProjectPmPaymentID"]);
                }
            }
            if (Session["RequestProjectPmPaymentIndexID"] != null)
            {
                if (Session["RequestProjectPmPaymentIndexID"].ToString() != "0")
                {
                    ProjectPmApplicationPaymentIndexID = Convert.ToInt64(Session["RequestProjectPmPaymentIndexID"]);
                }
            }

            ClsPrp_ProjectExtensionApplication_PaymentIntegration objAppPayment = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();
            ClsMethod_ProjectExtensionApplication_PaymentIntegration objPayment = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();

            objAppPayment.ProjectExtensionPayment = objPayment.Display_ProjectExtensionApplication_PaymentById(Project_ID, Promoter_ID, ProjectExtension_ID, ProjectExtension_SequenceID, ProjectExtension_Year, ProjectPmApplicationPaymentIndexID, ProjectPmApplicationPaymentID, PaymentPRN);
            // PRN Exist - Case
            if (objAppPayment.ProjectExtensionPayment.Count >= 1)
            {
                foreach (var item in objAppPayment.ProjectExtensionPayment)
                {
                    // Payment Parameters
                    #region parameters
                    objAppPayment.PaymentRefNumberProjectPm_IndexID = item.PaymentRefNumberProjectPm_IndexID;
                    objAppPayment.PaymentRefNumberProjectPm_ID = item.PaymentRefNumberProjectPm_ID;
                    objAppPayment.RelatedProject_ID = item.RelatedProject_ID;
                    objAppPayment.RelatedPromoter_ID = item.RelatedPromoter_ID;
                    objAppPayment.RelatedProject_Code = item.RelatedProject_Code;
                    objAppPayment.RelatedPromoter_Code = item.RelatedPromoter_Code;
                    objAppPayment.RelatedPayment_ID = item.RelatedPayment_ID;
                    objAppPayment.RelatedPayment_IndexID = item.RelatedPayment_IndexID;
                    objAppPayment.User_ID = item.User_ID;

                    objAppPayment.Related_ProjectExtension_ID = item.Related_ProjectExtension_ID;
                    objAppPayment.Related_ProjectExtension_SequenceID = item.Related_ProjectExtension_SequenceID;
                    objAppPayment.Related_ProjectExtension_Year = item.Related_ProjectExtension_Year;

                    objAppPayment.ProjectPmZoneType = item.ProjectPmZoneType;
                    objAppPayment.PromoterType_IO = item.PromoterType_IO;
                    objAppPayment.User_Name = item.User_Name;

                    objAppPayment.ProjectPm_BriefSummary = item.ProjectPm_BriefSummary;
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
                        Tuple<int, dynamic> tparrtemp = getProjectPmPaymentDetailsByTransactionsAPI(objAppPayment.PG_Transaction_ID);

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

                            string arrapi_RelatedPaymentID = (string)arrayapi["transaction_details"][TxnapiID]["udf3"];
                            string arrapi_PaymentGatewayID = (string)arrayapi["transaction_details"][TxnapiID]["udf1"];
                            string arrapi_ProjectID = (string)arrayapi["transaction_details"][TxnapiID]["udf4"];
                            string arrapi_RelatedPaymentIndexID = (string)arrayapi["transaction_details"][TxnapiID]["udf5"];
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
                            objAppPayment.ProjectPm_BriefSummary = Convert.ToString(string.IsNullOrEmpty(arrapi_field9) ? "NA" : arrapi_field9);
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
                            objAppPayment.PG_Payment_Gateway = Convert.ToString(string.IsNullOrEmpty(arrapi_PG_TYPE) ? "NA" : arrapi_mode);
                            objAppPayment.PG_Bank_Reference_No = Convert.ToString(string.IsNullOrEmpty(arrapi_bank_ref_num) ? "NA" : arrapi_bank_ref_num);
                            objAppPayment.PG_International_Domestic = string.Empty;
                            objAppPayment.PG_Payment_Type = Convert.ToString(string.IsNullOrEmpty(arrapi_mode) ? "NA" : arrapi_PG_TYPE);

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
                            objAppPayment.PG_UDF_3 = Convert.ToString(string.IsNullOrEmpty(arrapi_RelatedPaymentID) ? "0" : arrapi_RelatedPaymentID);
                            objAppPayment.PG_UDF_4 = Convert.ToString(string.IsNullOrEmpty(arrapi_ProjectID) ? "0" : arrapi_ProjectID);
                            objAppPayment.PG_UDF_5 = Convert.ToString(string.IsNullOrEmpty(arrapi_RelatedPaymentIndexID) ? string.Empty : arrapi_RelatedPaymentIndexID);

                            objAppPayment.PG_Device_Info = Convert.ToString(string.IsNullOrEmpty(arrapi_unmappedstatus) ? string.Empty : arrapi_unmappedstatus);
                            objAppPayment.PG_HashKey = Convert.ToString(string.IsNullOrEmpty(arrapi_field2) ? string.Empty : arrapi_field2);
                            objAppPayment.PG_ServiceProvider = Convert.ToString(string.IsNullOrEmpty(arrapi_payment_source) ? string.Empty : arrapi_payment_source);
                            #endregion
                            // Payment - Done But Confirmation Pending
                            TempData["submitvalueGetProjectPmPaymentGateway"] = "Confirm Payment"; TempData.Keep();                            
                        }
                        else
                        {
                            // Payment - Pending OR Failure (Bounced /Failed /UserCancelled /Droped)
                            //return RedirectToAction("RegAgent", "Agent");
                            return View("getprojectpmapplicationpayment", objAppPayment);
                        }
                    }
                    catch(Exception ex)
                    {
                        string retstr = ex.ToString();
                        TempData["APIerrorstatus"] = retstr;
                        return View("getprojectpmapplicationpayment", objAppPayment);
                        //return RedirectToAction("RegAgent", "Agent");
                    }
                }
                else
                {
                    // Payment - Done
                    TempData["APIerrorstatus"] = "Paid";
                    TempData["submitvalueGetProjectPmPaymentGateway"] = "Back"; TempData.Keep();
                }
            }
            return View("getprojectextensionapplicationpayment", objAppPayment);
        }           

        [HttpPost]        
        public ActionResult getprojectextensionapplicationpaymenttxn(ClsPrp_ProjectExtensionApplication_PaymentIntegration setmodel)
        {
            ClsMethod_ProjectExtensionApplication_PaymentIntegration sdb = new ClsMethod_ProjectExtensionApplication_PaymentIntegration();
            ClsPrp_ProjectExtensionApplication_PaymentIntegration aa = new ClsPrp_ProjectExtensionApplication_PaymentIntegration();

            string UID = User.Identity.GetUserId();
            string userName = User.Identity.Name;
            string errorstate = string.Empty;
            Int32 IsPaymentSuccessCompleteFlag = 1; //Success 1/ Failure 2/ Pending 0

            #region Save & Update 
            try
            {
                if (TempData["submitvalueGetProjectPmPaymentGateway"].ToString() == "Confirm Payment")
                {
                    // to update existing record - payment complete
                    // Payment Details Save (Case when Flag as Pending : 0 OR Failure : 2)
                    if (ModelState.IsValid)
                    {
                        if (sdb.Update_ProjectExtensionApplication_PaymentByAPI(setmodel, UID, userName, IsPaymentSuccessCompleteFlag))
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
            return RedirectToAction("Create_ProjectExtensionPaymentDetails", "Project");
        }

        public Tuple<Int32, Int64, Int64, Int64, Int64> getProjectPmPaymentDetailsByTxnAPI(string TxnID)
        {
            Int32 RetFlag = 0;
            Int64 RetValueRelatedPaymentID = 0;
            Int64 RetValuePaymentGatewayID = 0;
            Int64 RetValueProjectID = 0;
            Int64 RetValueRelatedPaymentIndexID = 0;
            try
            {
                string var1 = Convert.ToString(TxnID);
                string command = Convert.ToString("verify_payment");

                RemotePostAPI myremoteapipost = new RemotePostAPI();

                string key = ConfigurationManager.AppSettings["payuMerchantKey"]; //"98d8Yh"; //98d8Yh 
                string salt = ConfigurationManager.AppSettings["payuSalt"]; //"6thltjA2"; //6thltjA2 
                string URI = ConfigurationManager.AppSettings["payuApiBaseURL"]; 
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

                dynamic array = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

                string array1 = (string)array["status"];
                string array2 = (string)array["msg"];
                string array3 = (string)array["transaction_details"][TxnID]["unmappedstatus"];

                string array4 = (string)array["transaction_details"][TxnID]["udf3"];
                string array5 = (string)array["transaction_details"][TxnID]["udf1"];
                string array6 = (string)array["transaction_details"][TxnID]["udf4"];
                string array7 = (string)array["transaction_details"][TxnID]["udf5"];

                JObject account = JObject.Parse(response);
                string status = (string)account.SelectToken("status");
                string msg = (string)account.SelectToken("msg");
                string statusAmount = (string)account.SelectToken("transaction_details." + var1 + ".status");

                if (status == "1")
                {                    
                    if (array3 == "captured")
                    {
                        RetFlag = 1; // Yes Txn Completed
                        RetValueRelatedPaymentID = Convert.ToInt64(string.IsNullOrEmpty(array4) ? "0" : array4); //Related Payment ID
                        RetValuePaymentGatewayID = Convert.ToInt64(string.IsNullOrEmpty(array5) ? "0" : array5); //Payment Gatway ID
                        RetValueProjectID = Convert.ToInt64(string.IsNullOrEmpty(array6) ? "0" : array6); //Project ID
                        RetValueRelatedPaymentIndexID = Convert.ToInt64(string.IsNullOrEmpty(array6) ? "0" : array7); //Related Payment IndexID
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
            var tuple = new Tuple<int, long, long, long, long>(RetFlag, RetValueProjectID, RetValuePaymentGatewayID, RetValueRelatedPaymentID, RetValueRelatedPaymentIndexID);
            return tuple;
        }

        public Tuple<Int32, dynamic> getProjectPmPaymentDetailsByTransactionsAPI_0111(string TxnID)
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
                string array7 = (string)array["transaction_details"][TxnID]["udf5"];

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

        public Tuple<Int32, dynamic> getProjectPmPaymentDetailsByTransactionsAPI(string TxnID)
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
                string array7 = (string)array["transaction_details"][TxnID]["udf5"];

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
    }
}
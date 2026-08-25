using CRUD.Models.Agent;
using CRUD.Models.AgentPrintForm;
using CRUD.Models.Promoter;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    [Authorize]
    [Authorize(Roles = "RealEstateAgent")]
    public class AgentPrintFormController : Controller
    {
        //Print: Real-estate Agent
        /// <summary>
        /// Registration of Real-estate Agent
        /// </summary>
        /// <returns></returns>

        #region Print Ind Agent Print Profile
        [HttpGet]
        public ActionResult Print_IndAgentDetail()
        {

            string userRole = string.Empty;
            Int64 AgentID = 0;
            // Int64 AgentID = 5002;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? AgentID_ID = Convert.ToInt64(Session["ApplicationId"]);
                    AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                }
            }

            Clsprp_IndAgent aa = new Clsprp_IndAgent();         
            CLSMethod_Print_IndAgent sdb = new CLSMethod_Print_IndAgent();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            aa.Agent = sdb.Display_Print_AgentIndProfileDetail(AgentID);
            aaZapDN.prpongoing = sdbZapDN.Display_Agent_RegDiaryNumberByAgentID_ForPrint(AgentID, userRole);

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            foreach (var item in aa.Agent)
            {
                if (item.Agent_Type == 2)
                {
                    return RedirectToAction("Print_AgentOtherIndProfile");
                }

                statecode = item.P_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.P_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

            }

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
            }

            // return View("Print_IndAgentDetail", aa);


            // return View("RegIndAgent", aa);
            return new RazorPDF.PdfActionResult(aa);

        }
        #endregion

        #region Print Agent Other Than Ind Profile
        [HttpGet]
        public ActionResult Print_AgentOtherIndProfile()
        {
            ClsMethod_Print_AgentInd_OtherInd_Profile sdb = new ClsMethod_Print_AgentInd_OtherInd_Profile();
            ClsPrp_Print_AgentOtherIndProfile aa = new ClsPrp_Print_AgentOtherIndProfile();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            string userRole = string.Empty;
            Int64 AgentID = 0;
            //Int64 AgentID =5002;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? AgentID_ID = Convert.ToInt64(Session["ApplicationId"]);
                    AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                }
            }

            int? statecode;
            int? DistrictCode;
            int? BusinessPlace_AddressStateCode;
            int? BusinessPlace_AddressDistrictCode;
            int? BComm_AddressStateCode;
            int? BComm_AddressDistrictCode;

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.AgentOtherIndProfile = sdb.Display_Print_AgentOtherThanIndDetail(AgentID);
            aaZapDN.prpongoing = sdbZapDN.Display_Agent_RegDiaryNumberByAgentID_ForPrint(AgentID, userRole);

            foreach (var item in aa.AgentOtherIndProfile)
            {

                statecode = item.RegOffice_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.RegOffice_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                BComm_AddressStateCode = item.BComm_AddressStateCode;
                aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);

            }            

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
            }

            // return View("Print_AgentOtherIndProfile", aa);
            return new RazorPDF.PdfActionResult(aa);
        }
        
        [HttpGet]
        public ActionResult Print_AgentOtherMemberDetail()
        {
            ClsMethodprpOtherMemberAgent sdb = new ClsMethodprpOtherMemberAgent();
            ClsprpOtherMemberAgent aa = new ClsprpOtherMemberAgent();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            string userRole = string.Empty;
            Int64 AgentID = 0;
            //Int64 AgentID = 5002;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? AgentID_ID = Convert.ToInt64(Session["ApplicationId"]);
                    AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                }
            }

            int? statecode;
            int? DistrictCode;           

            ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

            aa.Agent_OtherMember = sdb.Display_Print_AgentOtherMemberDetail(AgentID);
            aaZapDN.prpongoing = sdbZapDN.Display_Agent_RegDiaryNumberByAgentID_ForPrint(AgentID, userRole);

            foreach (var item in aa.Agent_OtherMember)
            {
                statecode = item.OfficeComm_AddressStateCode;
                aa.P_AddressState = objdis.State_Name(statecode);
                DistrictCode = item.OfficeComm_AddressDistrictCode;
                aa.P_AddressDist = objdis.District_Name(DistrictCode);

                //BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                //aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                //BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                //aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);


                //BComm_AddressStateCode = item.BComm_AddressStateCode;
                //aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                //BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                //aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);
            }           

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
            }

            return new RazorPDF.PdfActionResult(aa);
        }
        #endregion

        #region Print Agent Other State UT RERA Details

        [HttpGet]
        public ActionResult Print_AgentOtherStateUT_RERA()
        {
            ClsMethod_Print_AgentOtherStateUT_RERA sdb = new ClsMethod_Print_AgentOtherStateUT_RERA();
            ClsPrp_Print_AgentOtherStateUT_RERA aa = new ClsPrp_Print_AgentOtherStateUT_RERA();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            string userRole = string.Empty;
            Int64 AgentID = 0;
            //Int64 AgentID = 5002;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? AgentID_ID = Convert.ToInt64(Session["ApplicationId"]);
                    AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                }
            }

            aa.Agent_OtherStateUTMember= sdb.Display_AgentOtherStateUT_RERADetail(AgentID);
            aaZapDN.prpongoing = sdbZapDN.Display_Agent_RegDiaryNumberByAgentID_ForPrint(AgentID, userRole);

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
            }

            return new RazorPDF.PdfActionResult(aa);
            //return View("Display_AgentOtherStateUT_RERA", aa);
        }

        #endregion

        #region Print Agent Payment Details

        [HttpGet]
        public ActionResult Print_AgentPaymentDetails()
        {
            ClsMethod_Print_AgentPayment sdb = new ClsMethod_Print_AgentPayment();
            ClsPrp_Print_AgentPayment aa = new ClsPrp_Print_AgentPayment();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            string userRole = string.Empty;
            Int64 AgentID = 0;
            //Int64 AgentID = 5002;
            userRole = getUserRole();            

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? AgentID_ID = Convert.ToInt64(Session["ApplicationId"]);
                    AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                }                
            }         

            aa.AgentPayment = sdb.Display_Print_AgentPaymentDetail(AgentID);
            aaZapDN.prpongoing = sdbZapDN.Display_Agent_RegDiaryNumberByAgentID_ForPrint(AgentID, userRole);
            aa.AgentPaymentWithTranasactions = sdb.Display_Print_AgentApplicationPaymentTransactions(AgentID);

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;              
            }
            
            return new RazorPDF.PdfActionResult(aa);
            // return View("Print_AgentPaymentDetails", aa);
        }

        #endregion

        #region Print Agent Document Details

        [HttpGet]
        public ActionResult Print_AgentDocumentDetails()
        {
            ClsMethod_Print_AgentDocuments sdb = new ClsMethod_Print_AgentDocuments();
            ClsPrp_Print_AgentDocuments aa = new ClsPrp_Print_AgentDocuments();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            string userRole = string.Empty;
            Int64 AgentID = 0;
            //Int64 AgentID = 5002;
            userRole = getUserRole();

            if (Session["ApplicationId"] != null)
            {
                if (Session["ApplicationId"].ToString() != "0")
                {
                    Int64? AgentID_ID = Convert.ToInt64(Session["ApplicationId"]);
                    AgentID = (AgentID_ID != null) ? Convert.ToInt64(AgentID_ID) : 0;
                }
            }

            aa.AgentDocs = sdb.Display_Print_AgentDocuments_ByAgentId(AgentID);
            aaZapDN.prpongoing = sdbZapDN.Display_Agent_RegDiaryNumberByAgentID_ForPrint(AgentID, userRole);

            foreach (var item in aaZapDN.prpongoing)
            {
                aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
            }

            //return View("Print_AgentDocumentDetails", aa);
            return new RazorPDF.PdfActionResult(aa);
        }

        #endregion

        //Print: Form-J
        /// <summary>
        /// Renewal of Registration (Form-J) of Real-estate Agent
        /// </summary>
        /// <returns></returns>

        #region AR Ind Agent Print Profile
        [HttpGet]
        public ActionResult Print_AgentRenewal_IndAgentDetail()
        {
            ClsPrp_Print_RenewalAgent_IndividualProfile aa = new ClsPrp_Print_RenewalAgent_IndividualProfile();
            CLSMethod_Print_IndAgent sdb = new CLSMethod_Print_IndAgent();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                string userRole = getUserRole();

                Int64 rna_AgentID = 0;
                Int32 rna_TypeOfAgent = 0;
                Int64 rna_RenewalAgentID = 0;
                Int32 rna_RenewalSequenceID = 0;
                Int32 rna_RenewalAgentYear = 0;
                string rna_Error = string.Empty;

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
                #endregion

                aa.AgentIndividual = sdb.Display_Print_RenewalAgent_IndividualProfileDetail(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aaZapDN.prpongoing = sdbZapDN.Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);

                int? statecode;
                int? DistrictCode;
                int? BusinessPlace_AddressStateCode;
                int? BusinessPlace_AddressDistrictCode;
                int? BComm_AddressStateCode;
                int? BComm_AddressDistrictCode;

                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

                foreach (var item in aa.AgentIndividual)
                {
                    if (item.Related_Agent_Type == 2)
                    {
                        return RedirectToAction("Print_AgentRenewal_OtherIndAgentProfile");
                    }
                    statecode = item.P_AddressStateCode;
                    aa.P_AddressState = objdis.State_Name(statecode);
                    DistrictCode = item.P_AddressDistrictCode;
                    aa.P_AddressDist = objdis.District_Name(DistrictCode);

                    BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                    BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);

                    BComm_AddressStateCode = item.BComm_AddressStateCode;
                    aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                    BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);
                }

                foreach (var item in aaZapDN.prpongoing)
                {
                    aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                    aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                    aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                    aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
                    aa.zapAgent_RegistrationNumber = item.zapAgent_RegistrationNumber;
                }
            }
            catch(Exception ex)
            {
                string strex = ex.ToString();
            }
            return new RazorPDF.PdfActionResult(aa);
        }
        #endregion

        #region AR Agent Other Than Ind Print Profile
        [HttpGet]
        public ActionResult Print_AgentRenewal_OtherIndAgentProfile()
        {
            ClsMethod_Print_AgentInd_OtherInd_Profile sdb = new ClsMethod_Print_AgentInd_OtherInd_Profile();
            ClsPrp_Print_RenewalAgent_AgentOtherIndProfile aa = new ClsPrp_Print_RenewalAgent_AgentOtherIndProfile();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();
            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                string userRole = getUserRole();

                Int64 rna_AgentID = 0;
                Int32 rna_TypeOfAgent = 0;
                Int64 rna_RenewalAgentID = 0;
                Int32 rna_RenewalSequenceID = 0;
                Int32 rna_RenewalAgentYear = 0;
                string rna_Error = string.Empty;

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
                #endregion

                int? statecode;
                int? DistrictCode;
                int? BusinessPlace_AddressStateCode;
                int? BusinessPlace_AddressDistrictCode;
                int? BComm_AddressStateCode;
                int? BComm_AddressDistrictCode;

                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

                aa.AgentOtherIndProfile = sdb.Display_Print_RenewalAgent_OtherThanIndDetail(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aaZapDN.prpongoing = sdbZapDN.Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);

                foreach (var item in aa.AgentOtherIndProfile)
                {
                    statecode = item.RegOffice_AddressStateCode;
                    aa.P_AddressState = objdis.State_Name(statecode);
                    DistrictCode = item.RegOffice_AddressDistrictCode;
                    aa.P_AddressDist = objdis.District_Name(DistrictCode);

                    BusinessPlace_AddressStateCode = item.BusinessPlace_AddressStateCode;
                    aa.BusinessPlace_AddressState = objdis.State_Name(BusinessPlace_AddressStateCode);

                    BusinessPlace_AddressDistrictCode = item.BusinessPlace_AddressDistrictCode;
                    aa.BusinessPlace_AddressDistrict = objdis.District_Name(BusinessPlace_AddressDistrictCode);

                    BComm_AddressStateCode = item.BComm_AddressStateCode;
                    aa.BComm_AddressState = objdis.State_Name(BComm_AddressStateCode);

                    BComm_AddressDistrictCode = item.BComm_AddressDistrictCode;
                    aa.BComm_AddressDistrict = objdis.District_Name(BComm_AddressDistrictCode);
                }

                foreach (var item in aaZapDN.prpongoing)
                {
                    aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                    aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                    aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                    aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
                    aa.zapAgent_RegistrationNumber = item.zapAgent_RegistrationNumber;
                }
            }
            catch(Exception ex)
            {
                string extsr = ex.ToString();
            }
            return new RazorPDF.PdfActionResult(aa);
        }


        [HttpGet]
        public ActionResult Print_AgentRenewal_OtherMemberDetail()
        {
            ClsMethodprpOtherMemberAgent sdb = new ClsMethodprpOtherMemberAgent();
            ClsPrp_Print_RenewalAgent_OtherMemberAgent aa = new ClsPrp_Print_RenewalAgent_OtherMemberAgent();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();
            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                string userRole = getUserRole();

                Int64 rna_AgentID = 0;
                Int32 rna_TypeOfAgent = 0;
                Int64 rna_RenewalAgentID = 0;
                Int32 rna_RenewalSequenceID = 0;
                Int32 rna_RenewalAgentYear = 0;
                string rna_Error = string.Empty;

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
                #endregion

                int? statecode;
                int? DistrictCode;

                ClsMethodDistrictMaster objdis = new ClsMethodDistrictMaster();

                aa.Agent_OtherMember = sdb.Display_Print_RenewalAgent_OtherMemberDetail(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aaZapDN.prpongoing = sdbZapDN.Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);

                foreach (var item in aa.Agent_OtherMember)
                {
                    statecode = item.OfficeComm_AddressStateCode;
                    aa.P_AddressState = objdis.State_Name(statecode);
                    DistrictCode = item.OfficeComm_AddressDistrictCode;
                    aa.P_AddressDist = objdis.District_Name(DistrictCode);
                }

                foreach (var item in aaZapDN.prpongoing)
                {
                    aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                    aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                    aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                    aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
                    aa.zapAgent_RegistrationNumber = item.zapAgent_RegistrationNumber;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return new RazorPDF.PdfActionResult(aa);
        }
        #endregion

        #region AR Other State-RERA Print Detail
        [HttpGet]
        public ActionResult Print_AgentRenewal_OtherStateUT_RERA()
        {
            ClsMethod_Print_AgentOtherStateUT_RERA sdb = new ClsMethod_Print_AgentOtherStateUT_RERA();
            ClsPrp_Print_RenewalAgent_OtherStateUT_RERA aa = new ClsPrp_Print_RenewalAgent_OtherStateUT_RERA();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                string userRole = getUserRole();

                Int64 rna_AgentID = 0;
                Int32 rna_TypeOfAgent = 0;
                Int64 rna_RenewalAgentID = 0;
                Int32 rna_RenewalSequenceID = 0;
                Int32 rna_RenewalAgentYear = 0;
                string rna_Error = string.Empty;

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
                #endregion

                aa.Agent_OtherStateUTMember = sdb.Display_RenewalAgent_OtherStateUT_RERADetail(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aaZapDN.prpongoing = sdbZapDN.Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);

                foreach (var item in aaZapDN.prpongoing)
                {
                    aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                    aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                    aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                    aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
                    aa.zapAgent_RegistrationNumber = item.zapAgent_RegistrationNumber;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return new RazorPDF.PdfActionResult(aa);
        }
        #endregion

        #region AR Fee Payment Print Detail
        [HttpGet]
        public ActionResult Print_AgentRenewal_FeePaymentDetail()
        {
            ClsMethod_Print_AgentPayment sdb = new ClsMethod_Print_AgentPayment();
            ClsPrp_Print_RenewalAgent_Payment aa = new ClsPrp_Print_RenewalAgent_Payment();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();
            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                string userRole = getUserRole();

                Int64 rna_AgentID = 0;
                Int32 rna_TypeOfAgent = 0;
                Int64 rna_RenewalAgentID = 0;
                Int32 rna_RenewalSequenceID = 0;
                Int32 rna_RenewalAgentYear = 0;
                string rna_Error = string.Empty;

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
                #endregion

                aa.AgentRenewalPayment = sdb.Display_Print_RenewalAgent_PaymentDetail(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aaZapDN.prpongoing = sdbZapDN.Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aa.AgentRenewalPaymentWithTranasactions = sdb.Display_Print_RenewalAgent_AgentApplicationPaymentTransactions(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);

                foreach (var item in aaZapDN.prpongoing)
                {
                    aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                    aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                    aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                    aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
                    aa.zapAgent_RegistrationNumber = item.zapAgent_RegistrationNumber;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return new RazorPDF.PdfActionResult(aa);
        }
        #endregion

        #region AR Document Print Detail
        [HttpGet]
        public ActionResult Print_AgentRenewal_DocumentDetail()
        {
            ClsMethod_Print_AgentDocuments sdb = new ClsMethod_Print_AgentDocuments();
            ClsPrp_Print_RenewalAgent_Documents aa = new ClsPrp_Print_RenewalAgent_Documents();

            ClsMethod_Print_AgentDiaryNumberDetails sdbZapDN = new ClsMethod_Print_AgentDiaryNumberDetails();
            ClsPrp_PrmAgent_Print_DiaryNumberDetails aaZapDN = new ClsPrp_PrmAgent_Print_DiaryNumberDetails();

            try
            {
                string UID = User.Identity.GetUserId();
                string UserNam = User.Identity.Name;
                string userRole = getUserRole();

                Int64 rna_AgentID = 0;
                Int32 rna_TypeOfAgent = 0;
                Int64 rna_RenewalAgentID = 0;
                Int32 rna_RenewalSequenceID = 0;
                Int32 rna_RenewalAgentYear = 0;
                string rna_Error = string.Empty;

                #region Set All-Parms
                if (Session["ApplicationId"] != null && Session["User_Type"] != null)
                {
                    if (Session["ApplicationId"].ToString() != "0")
                    {
                        rna_AgentID = Convert.ToInt64(Session["ApplicationId"]);
                    }
                    if (Session["User_Type"].ToString() != "0")
                    {
                        rna_TypeOfAgent = Convert.ToInt32(Session["User_Type"]);
                    }
                    if (rna_AgentID != 0 && rna_TypeOfAgent != 0)
                    {
                        if (Session["RenewalAgentId"] != null && Session["RenewalSequenceId"] != null && Session["RenewalAgentYear"] != null)
                        {
                            if (Session["RenewalAgentId"].ToString() != "0")
                            {
                                rna_RenewalAgentID = Convert.ToInt64(Session["RenewalAgentId"]);
                            }
                            if (Session["RenewalSequenceId"].ToString() != "0")
                            {
                                rna_RenewalSequenceID = Convert.ToInt32(Session["RenewalSequenceId"]);
                            }
                            if (Session["RenewalAgentYear"].ToString() != "0")
                            {
                                rna_RenewalAgentYear = Convert.ToInt32(Session["RenewalAgentYear"]);
                            }
                        }
                    }
                }
                else
                {
                    //NA Case :- Error (Session Expires/Empty)
                    rna_Error = "Error! Something Went Wrong. Please sign-in with registered real-estate agent.";
                }
                #endregion

                aa.AgentDocs = sdb.Display_Print_RenewalAgent_Documents_ById(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);
                aaZapDN.prpongoing = sdbZapDN.Display_RenewalAgent_RegDiaryNumberByAgentID_ForPrint(rna_AgentID, rna_TypeOfAgent, rna_RenewalAgentID, rna_RenewalSequenceID, rna_RenewalAgentYear, userRole);

                foreach (var item in aaZapDN.prpongoing)
                {
                    aa.zapRelated_Agent_ID = item.zapRelated_Agent_ID;
                    aa.zapAgent_DiaryNumber = (String.IsNullOrEmpty(item.zapAgent_DiaryNumber) ? "" : item.zapAgent_DiaryNumber);
                    aa.zapAgentName = (String.IsNullOrEmpty(item.zapAgentName) ? "" : item.zapAgentName);
                    aa.zapAgentLastModifiedOn = item.zapAgentLastModifiedOn;
                    aa.zapAgent_RegistrationNumber = item.zapAgent_RegistrationNumber;
                }
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
            }
            return new RazorPDF.PdfActionResult(aa);
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
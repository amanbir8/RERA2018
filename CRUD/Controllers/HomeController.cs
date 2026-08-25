using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult IndexDefault()
        {
            string varRETurl = string.Empty;
            if (User.IsInRole("Promoter"))
            {
                varRETurl = "IndexPromoter";
            }
            if (User.IsInRole("RealEstateAgent"))
            {
                varRETurl = "IndexAgent";
            }
            if (User.IsInRole("Complainant"))
            {
                varRETurl = "IndexComplainant";
            }
            if (User.IsInRole("HelpDesk"))
            {
                return View();
            }
            if (User.IsInRole("SecretaryRERA"))
            {
                return View();
            }
            if (User.IsInRole("ManagerDesk"))
            {
                return View();
            }
            if (User.IsInRole("Administrator"))
            {
                return View();
            }
            if (User.IsInRole("LegalAdvisorDesk"))
            {
                return View();
            }
            if (User.IsInRole("PStoMembers"))
            {
                return View();
            }
            if (User.IsInRole("Programmer"))
            {
                return View();
            }
            if (User.IsInRole("Authority"))
            {
                return View();
            }
            return RedirectToAction(varRETurl);            
        }

        [Authorize(Roles = "RealEstateAgent")]
        public ActionResult IndexAgent()
        {
            ViewBag.Message = "Your application description page.";

            return View();            
        }

        [Authorize(Roles = "SecretaryRERA")]
        public ActionResult IndexAdmin()
        {
            ViewBag.Message = "Your contact page.";

            return View();            
        }

        [Authorize(Roles = "HelpDesk, SecretaryRERA, ManagerDesk, LegalAdvisorDesk, PStoMembers, Programmer, Authority")]
        public ActionResult IndexHelpDesk()
        {
            ViewBag.Message = "Your contact page.";

            return View();            
        }

        [Authorize(Roles = "Promoter")]
        public ActionResult IndexPromoter()
        {
            ViewBag.Message = "Your contact page.";

            return View();            
        }

        [Authorize(Roles = "Complainant")]
        public ActionResult IndexComplainant()
        {
            ViewBag.Message = "Your contact page.";

            return View();            
        }

        //TEST PAGE
        public ActionResult IndexAdminHelpDesk()
        {
            return View();            
        }

        public ActionResult IndexHelpDeskProjects()
        {
            return View();            
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
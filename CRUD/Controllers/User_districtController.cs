using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace CRUD.Controllers
{
    [Authorize]
    public class User_districtController : Controller
    {
        // GET: User_district
        public ActionResult VM_User_district()
        {
            VM_User_Dist VM_OBJ = new VM_User_Dist();
            VM_user_district_DBhandler clsobj = new VM_user_district_DBhandler();
            VM_OBJ = clsobj.GetBlogComment();

            return View(VM_OBJ);
             
        }
    }
}
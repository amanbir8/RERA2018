   
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
 
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace CRUD.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult dropdownlist()
        {
            UserDBHandler objuser=new UserDBHandler();
            UserDetails clsobj = new UserDetails();
            clsobj = objuser.dropdownlist_display();

            return View(clsobj);

            //UserDBHandler dd = new UserDBHandler();
            //objuser.usersinfo= dd.dropdownlist_display();


            //StudentDBHandle dbhandle = new StudentDBHandle();
            //ModelState.Clear();
            //return View(dbhandle.GetStudent());
        }
    }

    internal class mySqlDataAdapter
    {
    }

    internal class mySqlCommand
    {
    }

    internal class mySqlConnection
    {
    }
}
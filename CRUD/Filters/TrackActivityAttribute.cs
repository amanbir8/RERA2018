using CRUD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Filters
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TrackActivityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null || filterContext.IsChildAction)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            try
            {
                var httpContext = filterContext.HttpContext;
                var userId = Convert.ToString(httpContext.Session["User_Id"]);

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var actionName = Convert.ToString(filterContext.ActionDescriptor.ActionName);
                    var controllerName = Convert.ToString(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);

                    ActivityLogger.LogEventActivity(userId, actionName, controllerName);
                }
            }
            catch
            {
                // Activity logging should never break the request pipeline.
            }

            base.OnActionExecuting(filterContext);
        }
    }


    //public class TrackActivityAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        string action =filterContext.ActionDescriptor.ActionName;

    //        string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

    //        //System.Diagnostics.Debug.WriteLine(controller + " - " + action);

    //        base.OnActionExecuting(filterContext);
    //    }
    //}
}
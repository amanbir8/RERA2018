using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CRUD
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly HttpClient OpenAiHttp = new HttpClient
        {
            BaseAddress = new Uri("https://api.openai.com/")
        };

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 60;
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                //log the error
            }
            Server.ClearError();

            Response.Redirect("/Account/Error404");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPIandAngularJSSample.Models;

namespace WebAPIandAngularJSSample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<WebAPIandAngularJSSampleContext>(new WebAPIandAngularJSSampleContextInitializer());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
        
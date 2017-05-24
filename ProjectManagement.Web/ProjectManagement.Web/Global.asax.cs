using ProjectManagement.Common.Settings;
using ProjectManagement.Data;
using ProjectManagement.Data.Logging;
using ProjectManagement.Web.App_Start;
using ProjectManagement.Web.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectManagement.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create database.
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.Initialize(true);

            // Init logging.
            LoggingConfig.RegisterLoggingSources(new List<EventSource> { WebEventSource.Log, DataEventSource.Log },
                (ICommonSettings)NinjectWebCommon.Kernel.GetService(typeof(ICommonSettings)));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}
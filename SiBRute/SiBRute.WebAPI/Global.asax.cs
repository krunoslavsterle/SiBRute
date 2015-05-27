using SiBRute.WebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using SiBRute.DAL;

namespace SiBRute.WebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Without this there is an error ("Context has changed since the database was created") when trying to get data form the database            
            Database.SetInitializer<RoutesDbContext>(null);
        }
    }
}

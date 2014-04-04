using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using p2groep04.Infrastructure;
using p2groep04.Models.DAL;
using p2groep04.Models.Domain;
using WebMatrix.WebData;

namespace p2groep04
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer(new CreateAndMigrateDatabaseInitializer<ProjectContext, p2groep04.Migrations.Configuration>());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<ProjectContext>(new ProjectInitializer());
            new ProjectContext().Database.Initialize(true);
            
            ModelBinders.Binders.Add(typeof(User), new UserModelBinder());
        }
    }
}
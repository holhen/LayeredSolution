using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using LayeredSolution.BusinessLayer;
using LayeredSolution.Controllers;
using LayeredSolution.DataLayer;

namespace LayeredSolution
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class AutofacConfig
    {
        public static IContainer Container;
        public static void Config()
        {

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(
                typeof (IProductService).Assembly);
            builder.RegisterControllers(typeof (HomeController).Assembly);
            Container = builder.Build();
            DependencyResolver.SetResolver(
                new AutofacDependencyResolver(Container));
        }
    }
}

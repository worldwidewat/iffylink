using System.Web.Mvc;
using System.Web.Routing;

namespace WorldWideWat.IffyLink.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Redirect", "{alias}",
                            new {controller = "Home", action = "Index", alias = UrlParameter.Optional}
                );

            routes.MapRoute("Default", "{action}/{alias}",
                            new { controller = "Home", action = "Index", alias = UrlParameter.Optional }
                );
        }
    }
}
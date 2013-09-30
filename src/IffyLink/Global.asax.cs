using System.Web.Mvc;
using System.Web.Routing;
using WorldWideWat.IffyLink.App_Start;

namespace WorldWideWat.IffyLink
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DapperConfig.Configure();
        }
    }
}
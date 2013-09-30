using System.Web.Optimization;

namespace WorldWideWat.IffyLink.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            const string jqueryCdnPath = "http://code.jquery.com/jquery-2.0.3.min.js";

            bundles.Add(new ScriptBundle("~/bundles/js", jqueryCdnPath).Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/bootstrap/bootstrap-theme.css",
                "~/Content/datetimepicker.css",
                "~/Content/site.css"));
        }
    }
}
using System.Web.Optimization;

namespace WorldWideWat.IffyLink.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/site.js")
                );

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/bootstrap/bootstrap-theme.css",
                "~/Content/datetimepicker.css",
                "~/Content/site.css"));
        }
    }
}
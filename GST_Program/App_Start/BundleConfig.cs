using System.Web.Optimization;

namespace GST_Program
{
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
                "~/Content/Vendor/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/css/bootstrap").Include(
                "~/Content/Vendor/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/css/fontawesome").Include(
                "~/Content/Vendor/font-awesome/font-awesome.min.css"));
        }
    }
}

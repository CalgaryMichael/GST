﻿using System.Web.Optimization;

namespace GST_Program
{
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                "~/Content/Vendor/jquery/jquery-2.2.4.min.js"));

            // jQuery Validate (Remove?)
            bundles.Add(new ScriptBundle("~/bundles/js/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
                "~/Content/Vendor/bootstrap/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css/bootstrap").Include(
                "~/Content/Vendor/bootstrap/css/bootstrap.min.css"));

            // DataTables
            bundles.Add(new ScriptBundle("~/bundles/js/datatables").Include(
                "~/Content/Vendor/datatables/js/datatables.min.js"));

            bundles.Add(new StyleBundle("~/bundles/css/datatables").Include(
                "~/Content/Vendor/datatables/css/datatables.min.css"));

            // Font Awesome
            bundles.Add(new StyleBundle("~/bundles/css/fontawesome").Include(
                "~/Content/Vendor/font-awesome/css/font-awesome.min.css"));
        }
    }
}

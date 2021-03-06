﻿using System.Web;
using System.Web.Optimization;

namespace AceAmazingRace
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(  
                      "~/Scripts/jquery-ui-{version}.js",
                      "~/Scripts/jquery.timepicker.js"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/initialization").Include(
                      "~/Scripts/initialization.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-spacelab.css",
                      "~/Content/leaflet.css",
                      "~/Content/Site.css",
                      "~/Content/zerogrid.css",
                      "~/Content/style.css",
                      "~/Content/menu.css",
                      "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(  
                   "~/Content/themes/base/jquery-ui.css",
                   "~/Content/jquery.timepicker.css"));  

            bundles.Add(new ScriptBundle("~/bundles/leaflet").Include(
                    "~/Scripts/leaflet.js"));

        }
    }
}

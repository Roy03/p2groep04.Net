﻿using System.Web;
using System.Web.Optimization;
using Microsoft.Ajax.Utilities;

namespace p2groep04
{
    public class BundleConfig
    {
        /// --- IMPORTANT NOTICE ---
        /// Based on the debug setting, (mostly web.config)
        /// debug="true" - the non minified version will be used.
        /// debug="false" - *.min.css will be searched, and if not found, the current will be minified

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;   //enable CDN support
            var jqueryCdnPath = "http://code.jquery.com/jquery-1.11.0.js";

            //main style
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/Style.css"));

            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include(
                "~/Scripts/jquery-{version}.js"
            ));

            //plugins
            bundles.Add(new StyleBundle("~/Content/plugins/css").Include(
                "~/Content/plugins/animate/css/animate.css",
                "~/Content/plugins/bootstrap-modified/css/bootstrap.css",
                "~/Content/plugins/bootstrap-modified/css/bootstrap-theme.css",
                "~/Content/plugins/mono-social-icons/css/MonoSocialIconsFont.css"
            ));


            bundles.Add(new ScriptBundle("~/Content/plugins/js").Include(
                "~/Content/plugins/bootstrap-modified/js/bootstrap.js"
            ));

        }
    }
}
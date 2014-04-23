using System.Web;
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
            var jqueryCdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js";
            var fueluxCDNPath = "http://www.fuelcdn.com/fuelux/2.6.0/loader.min.js";

            //main style
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/Style.css",
                "~/Content/css/pluginOverride.css"
            ));

            //jquery
            //zie template voor definitie

            //plugins
            bundles.Add(new StyleBundle("~/Content/plugins/css").Include(
                "~/Content/plugins/animate/css/animate.css",
                "~/Content/plugins/bootstrap-modified/css/bootstrap.css",
                "~/Content/plugins/bootstrap-modified/css/bootstrap-theme.css",
                "~/Content/plugins/mono-social-icons/css/MonoSocialIconsFont.css",
                "~/Content/plugins/select2/select2.css",
                "~/Content/plugins/tag-input/jquery.tagsinput.css"
            ));


            bundles.Add(new ScriptBundle("~/Content/plugins/js").Include(
                "~/Content/plugins/bootstrap/js/bootstrap.js",
                "~/Content/plugins/select2/select2.js",
                "~/Content/plugins/tag-input/jquery.tagsinput.js"
            ));

        }
    }
}
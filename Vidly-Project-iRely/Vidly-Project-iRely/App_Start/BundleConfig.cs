using System.Web;
using System.Web.Optimization;

namespace Vidly_Project_iRely
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
             //"~/Scripts/jquery-{version}.js",
             "~/Scripts/jquery-3.6.3.js",
             "~/Scripts/jquery-3.6.3.min.js"
             //"~/Scripts/jquery.validate.js"
             ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //"~/Scripts/jquery.validate.js",
            //"~/Scripts/jquery.validate.min.js",
            "~/Scripts/jquery.validate-1.19.3.js",
            "~/Scripts/jquery.validate.unobtrusive.js",
            "~/Scripts/jquery.validate.unobtrusive.min.js"
            ));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap-pulse.css.css",
                      //"~/Content/myStyle.css"));
                      "~/Content/site.css"));
        }
    }
}

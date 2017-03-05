using System.Web;
using System.Web.Optimization;

namespace MaiNguyen.GUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            //Bootstrap CSS
            bundles.Add(new StyleBundle("~/UI/bootstrap/css/styles").Include(
                "~/UI/bootstrap/css/bootstrap.min.css",
               "~/UI/nprogress/nprogress.css",
               "~/UI/iCheck/skins/flat/green.css",
               "~/UI/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css",
               "~/UI/jqvmap/jqvmap.min.css",
               "~/UI/bootstrap-daterangepicker/daterangepicker.css",
               "~/UI/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css",
               "~/UI/build/css/custom.min.css"
              ));

            //Bootstrap JS
            bundles.Add(new ScriptBundle("~/UI/bootstrap/js/javascripts").Include(
                //Bootstrap
                "~/UI/bootstrap/js/bootstrap.min.js",
                //FastClick
                "~/UI/fastclick/fastclick.js",
                //NProgress
                "~/UI/nprogress/nprogress.js",
               //Chart.js
               "~/UI/Chart.js/Chart.min.js",
               //gauge.js
               "~/UI/gauge.js/gauge.min.js",
               //bootstrap-progressbar
               "~/UI/bootstrap-progressbar/bootstrap-progressbar.min.js",
                //iCheck
                "~/UI/iCheck/icheck.min.js",
               //Skycons
               "~/UI/skycons/skycons.js",
               //Flot
               //"~/UI/Flot/jquery.flot.js",
               //"~/UI/Flot/jquery.flot.pie.js",
               // "~/UI/Flot/jquery.flot.time.js",
               //"~/UI/Flot/jquery.flot.stack.js",
               //"~/UI/Flot/jquery.flot.resize.js",
               //Flot plugins
               //"~/UI/flot.orderbars/js/jquery.flot.orderBars.js",
               //"~/UI/flot-spline/js/jquery.flot.spline.min.js",
               //"~/UI/flot.curvedlines/curvedLines.js",
               //DateJS
               "~/UI/DateJS/date.js",
                //JQVMap
                "~/UI/jqvmap/jquery.vmap.js",
                "~/UI/jqvmap/maps/jquery.vmap.world.js",
               "~/UI/jqvmap/jquery.vmap.sampledata.js",
               //bootstrap-daterangepicker
               "~/UI/moment/moment.min.js",
                "~/UI/bootstrap-daterangepicker/daterangepicker.js",
                //Custom Theme Scripts
                "~/UI/build/js/custom.min.js"));
        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace Cryptinsure
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/style.css",
                      "~/Content/font-awesome.css"));
        }
    }
}

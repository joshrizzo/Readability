using System.Web;
using System.Web.Optimization;

namespace Readability
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").IncludeDirectory("~/Scripts/", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/css").IncludeDirectory("~/Styles/", "*.css", false));

            BundleTable.EnableOptimizations = true;
        }
    }
}

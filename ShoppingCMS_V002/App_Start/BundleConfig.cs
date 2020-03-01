using System.Web;
using System.Web.Optimization;

namespace ShoppingCMS_V002
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/assets/plugins/global/plugins.bundle.js",
                "~/assets/js/scripts.bundle.js",
                "~/assets/plugins/custom/fullcalendar/fullcalendar.bundle.js",
                "~/assets/js/pages/dashboard.js",
                "~/CustomScript/MasterClicks.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/AddProduct").Include(
                 "~/assets/js/pages/custom/wizard/wizard-3.js",
                "~/assets/js/pages/crud/file-upload/dropzonejs.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                "~/assets/css/pages/wizard/wizard-3.rtl.css",
                "~/assets/plugins/custom/fullcalendar/fullcalendar.bundle.rtl.css",
                "~/assets/plugins/global/plugins.bundle.rtl.css",
                "~/assets/css/style.bundle.rtl.css",
                "~/assets/css/skins/header/base/light.rtl.css",
                "~/assets/css/skins/header/menu/light.rtl.css",
                "~/assets/css/skins/brand/dark.rtl.css",
                "~/assets/css/skins/aside/dark.rtl.css",
                "~/assets/css/Custome.css"
            ));

        }
    }
}

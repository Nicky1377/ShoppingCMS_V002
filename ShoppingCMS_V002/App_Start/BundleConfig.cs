using System.Web;
using System.Web.Optimization;

namespace ShoppingCMS_V002
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryCore.js").Include(
                "~/assets/plugins/global/plugins.bundle.js",
                "~/assets/js/scripts.bundle.js",
                "~/assets/plugins/custom/fullcalendar/fullcalendar.bundle.js",
                "~/assets/js/pages/dashboard.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/Ckeditor.js").Include(
                "~/assets/js/pages/custom/Plugins/ckeditor/ckeditor.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/Select2").Include(
                "~/assets/js/pages/crud/forms/widgets/select2.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/AddProduct.js").Include(
                 "~/assets/js/pages/custom/wizard/wizard-3.js",
                "~/assets/js/pages/crud/file-upload/dropzonejs.js",
                "~/assets/js/pages/crud/forms/widgets/select2.js"));

            bundles.Add(new StyleBundle("~/assets/CoreAdmin.css").Include(

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
            bundles.Add(new StyleBundle("~/assets/Uploader.css").Include(
                "~/assets/plugins/custom/Uploader/UploaderCustome.css"
            ));

            bundles.Add(new StyleBundle("~/assets/Auth.css").Include(
                "~/assets/Auth/fontawesome-free/css/all.min.css",
                "~/assets/Auth/css/MainLoginCss.css",
                "~/assets/Auth/css/panda.css",
                "~/assets/Auth/css/LoginAuthCustomCss.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/Auth/mainlogin.js").Include(
                "~/assets/Auth/js/mainlogin.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/Auth/panda.js").Include(
                "~/assets/Auth/js/panda.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/AddProScript.js").Include(
              "~/CustomScript/AddProScript.js"
          ));

        }
    }
}

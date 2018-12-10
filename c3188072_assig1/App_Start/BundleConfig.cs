using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace c3188072_assig1
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/assets/bundles/WebFormsJs").Include(
                            "~/assets/Scripts/WebForms/WebForms.js",
                            "~/assets/Scripts/WebForms/WebUIValidation.js",
                            "~/assets/Scripts/WebForms/MenuStandards.js",
                            "~/assets/Scripts/WebForms/Focus.js",
                            "~/assets/Scripts/WebForms/GridView.js",
                            "~/assets/Scripts/WebForms/DetailsView.js",
                            "~/assets/Scripts/WebForms/TreeView.js",
                            "~/assets/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/assets/bundles/MsAjaxJs").Include(
                    "~/assets/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/assets/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/assets/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/assets/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/assets/bundles/modernizr").Include(
                            "~/assets/Scripts/modernizr-*"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/assets/Scripts/respond.min.js",
                    DebugPath = "~/assets/Scripts/respond.js",
                });
        }
    }
}
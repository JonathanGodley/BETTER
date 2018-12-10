using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace c3188072_assig1
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            // map routes to make our user layer appear in the base directory
            routes.MapPageRoute("",
            "",
            "~/User_Layer/Default.aspx");

            routes.MapPageRoute("",
            "{FOLDER}/{URL}",
            "~/User_Layer/{FOLDER}/{URL}.aspx",
            false,
            new RouteValueDictionary { { "URL", "Default" } } // if no file specified, we're after the default.aspx file in the directory
            );

            routes.MapPageRoute("",
            "{FOLDER}/{URL}/{VAR}",
            "~/User_Layer/{FOLDER}/{URL}.aspx",
            false,
            new RouteValueDictionary { { "URL", "Default" } } // if no file specified, we're after the default.aspx file in the directory
            );
        }
    }
}

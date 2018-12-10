// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace c3188072_assig1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        void Session_Start(object sender, EventArgs e)
        {
            // start logged in - for marking / testing purposes
            Session.Add("loggedin", true);
            Session.Add("currentUser", 100002); // jonathan test user
            Session.Add("expires", System.DateTime.Now.AddMinutes(30.0));
            // Session Expiry = 30 minutes
        }
    }
}
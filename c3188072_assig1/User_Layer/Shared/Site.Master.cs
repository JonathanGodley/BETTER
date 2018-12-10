//Jonathan Godley - c3188072
//Last Modified: 03/11/2017 
//Inft3050 Assignment 2
using System;
using System.Web.UI;

namespace c3188072_assig1
{
    public partial class SiteMaster : MasterPage
    {
        public String userName;

        protected void Page_Load(object sender, EventArgs e)
        {
            // check if loggedin Session Var exists
            if (Session["loggedin"] != null)
            {
                // Check if true
                if ((bool)Session["loggedin"] == true)
                {

                    int UserID = (int)Session["CurrentUser"];
                    userName = c3188072_assig1.Models.Utilities.FindPlayer(UserID).Name;

                }

                if (Session["expires"] != null)
                {
                    if ((DateTime)Session["expires"] <= System.DateTime.Now)
                    {
                        // expired, so logout
                        Response.BufferOutput = true;
                        Response.Redirect("~/Account/Logout/");
                    }
                }

            }
        }
    }

}
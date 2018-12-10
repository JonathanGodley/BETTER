// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;

namespace c3188072_assig1.User_Layer.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // remove all session objects, including our loggedin token
            Session.RemoveAll();
        }
    }
}
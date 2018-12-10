// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web;
using System.Web.UI;
using c3188072_assig1.Models;

namespace c3188072_assig1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // setup Nav URLs
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            RegisterHyperLink.NavigateUrl = "Register";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                string attempt = Password.Text;

                // find account
                try
                {
                    UserAccount loginAccount = Utilities.FindPlayer(Email.Text.ToLower());

                    var result = (attempt == loginAccount.Password);

                    switch (result)
                    {
                        case true:
                            // link us to our session idt
                            Session.Add("loggedin", true);
                            Session.Add("currentUser", loginAccount.UserID);
                            Session.Add("expires", System.DateTime.Now.AddMinutes(30.0));

                            Response.BufferOutput = true;
                            Response.Redirect("~/Overview");
                            break;
                        case false:
                        default:
                            FailureText.Text = "Invalid login attempt, Check your Username and Password";
                            ErrorMessage.Visible = true;
                            break;
                    }
                }
                catch
                {
                    FailureText.Text = "Invalid login attempt, Check your Username and Password";
                    ErrorMessage.Visible = true;
                }


            }
        }
    }
}
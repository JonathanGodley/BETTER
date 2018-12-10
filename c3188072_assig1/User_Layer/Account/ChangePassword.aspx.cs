// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private UserAccount ua;

        protected void Page_Load(object sender, EventArgs e)
        {
            //check if logged in
            if (Session["loggedin"] != null)
            {
                // get our user
                try
                {
                    ua = Utilities.FindPlayer((int)Session["currentUser"]);

                }
                catch
                {
                    // if failure
                    Response.BufferOutput = true;
                    Response.Redirect("~/Shared/ErrorPage");
                }
            }
            else
            {
                // redirect to login page
                Response.BufferOutput = true;
                Response.Redirect("~/Account/Login");
            }
        }

        protected void UpdateDetails(object sender, EventArgs e)
        {

            if (IsValid)
            {
                // Validate the user password
                string attempt = OldPassword.Text;

                var result = (attempt == ua.Password);

                switch (result)
                {
                    case true:

                        if (NewPassword.Text.Length >= 48)
                        {
                            FailureText.Text = "Your password is too long!";
                            ErrorMessage.Visible = true;
                            break;
                        }


                        // change our password
                        string query = "UPDATE tblUser SET passcode = '" + NewPassword.Text + "' WHERE userId = " + ua.UserID;
                        Utilities.Insert(query);

                        // return to overview
                        Response.BufferOutput = true;
                        Response.Redirect("~/Overview");
                        break;
                    case false:
                    default:
                        FailureText.Text = "Invalid attempt, Check Old Password";
                        ErrorMessage.Visible = true;
                        break;
                }
            }

        }
    }
}
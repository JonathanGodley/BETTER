// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web.UI;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Account
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        public UserAccount ua;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //check if logged in
                if (Session["loggedin"] != null)
                {
                    // get our user
                    ua = Utilities.FindPlayer((int)Session["currentUser"]);


                    if (!Page.IsPostBack) // only run first page_load, use values provided by View State for button presses
                    {

                        Email.Text = ua.Email;
                        ParentEmail.Text = ua.ParentEmail;
                        Name.Text = ua.Name;

                    }

                    // Populate Page with User Data

                }
                else
                {
                    // redirect to login page
                    Response.BufferOutput = true;
                    Response.Redirect("~/Account/Login");
                }
            }
            catch
            {
                // if failure
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }
        }

        protected void UpdateDetails(object sender, EventArgs e)
        {

            if (IsValid)
            {
                // Validate the user password
                string attempt = Password.Text;
                var result = (attempt == ua.Password);

                switch (result)
                {
                    case true:
                        // change our details

                        if (Email.Text.Length >= 48)
                        {
                            FailureText.Text = "Your email is too long!";
                            ErrorMessage.Visible = true;
                            break;
                        }

                        if (ParentEmail.Text.Length >= 48)
                        {
                            FailureText.Text = "Your parent's is too long!";
                            ErrorMessage.Visible = true;
                            break;
                        }

                        if (Name.Text.Length >= 48)
                        {
                            FailureText.Text = "Your name is too long!";
                            ErrorMessage.Visible = true;
                            break;
                        }

                        string query = "UPDATE tblUser SET email = '" + Email.Text + "' WHERE userId = " + ua.UserID;
                        Utilities.Insert(query);

                        query = "UPDATE tblUser SET parentEmail = '" + ParentEmail.Text + "' WHERE userId = " + ua.UserID;
                        Utilities.Insert(query);

                        query = "UPDATE tblUser SET name = '" + Name.Text + "' WHERE userId = " + ua.UserID;
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
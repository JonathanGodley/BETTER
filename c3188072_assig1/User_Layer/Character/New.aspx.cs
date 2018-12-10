// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Character
{
    public partial class New : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["loggedin"] == null)
                {
                    // redirect to login page
                    Response.BufferOutput = true;
                    Response.Redirect("~/Account/Login");
                }

                // find Active User ID
                int UserID = (int)Session["CurrentUser"];

                // pull user details
                UserAccount tmpUser = Utilities.FindPlayer(UserID);

                // count user characters
                if (tmpUser.GetUserCharacters().Count >= 4)
                {
                    // too many characters, not allowed to make a new one
                    Response.BufferOutput = true;
                    Response.Redirect("~/Shared/ErrorPage");
                }

            }
            catch
            {
                // if failure
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }
        }

        protected void Create(object sender, EventArgs e)
        {

            if (IsValid)
            {
                // find Active User ID
                int UserID = (int)Session["CurrentUser"];

                if (NameTextBox.Text.Length >= 28)
                {
                    FailureText.Text = "Your character name is too long!";
                    ErrorMessage.Visible = true;
                }
                else
                {

                    // create our new character
                    String query = "INSERT INTO tblTitan (titanName, userId, elementId) VALUES ('" + NameTextBox.Text + "', " + UserID + ", " + ElementRadioButtonList.SelectedValue + ");";
                    Utilities.Insert(query);

                    // Back to Previous Menu
                    Response.BufferOutput = true;
                    Response.Redirect("~/Overview");
                }
            }


        }
    }
}
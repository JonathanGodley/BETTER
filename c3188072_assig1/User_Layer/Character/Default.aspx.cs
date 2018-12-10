// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Collections.Generic;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Character
{
    public partial class Default : System.Web.UI.Page
    {
        // variable to share to the aspx file
        public List<UserCharacter> playChars;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedin"] != null)
            {
                try
                {
                    // get our current user
                    int UserID = (int)Session["CurrentUser"];
                    UserAccount curPlayer = Utilities.FindPlayer(UserID);

                    // return their players
                    playChars = curPlayer.GetUserCharacters();
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

        protected void New(object sender, EventArgs e)
        {

            UserAccount tmpUser;

            // find Active User ID
            int UserID = (int)Session["CurrentUser"];

            // pull user details
            tmpUser = Utilities.FindPlayer(UserID);


            // count user characters
            if (tmpUser.GetUserCharacters().Count >= 4)
            {
                // too many characters, not allowed to make a new one
                // display error message
                FailureText.Text = "Character Limit Reached!";
                ErrorMessage.Visible = true;
            }
            else
            {
                Response.BufferOutput = true;
                Response.Redirect("~/Character/New");
            }
        }

    }
}

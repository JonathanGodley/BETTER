// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Character
{
    public partial class Show : System.Web.UI.Page
    {
        public UserCharacter Character;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // pull out the friendlyURL variable telling us who we're looking for
                int index = int.Parse(Page.RouteData.Values["var"].ToString());

                // find character matching ID
                Character = Utilities.FindCharacter(index);

                if (!Page.IsPostBack) // only run first page_load, use values provided by View State for button presses
                {
                    if (Character.AnonymousOwner == true)
                    { AnonymousOwner.Checked = true; }
                    else { AnonymousOwner.Checked = false; }
                }

                // make sure we cant select other people's characters
                if ((int)Session["CurrentUser"] != Character.Owner)
                {
                    Select.Visible = false;
                    IntroText.Text = "View Another Player's Character";
                }

                if (Character == null || Character.Deleted == true)
                {
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

        protected void SelectCharacter(object sender, EventArgs e)
        {

            int UserID = (int)Session["CurrentUser"];
            UserAccount curPlayer = Utilities.FindPlayer(UserID);
            // mark our character as active
            Session.Add("activeCharacter", Character.Id);

            // redirect
            Response.BufferOutput = true;
            Response.Redirect("~/Character/");



        }

        protected void DeleteCharacter(object sender, EventArgs e)
        {
            // first check if we're deleting our active character
            if ((Session["activeCharacter"] != null) && (int)Session["activeCharacter"] == Character.Id)
            {
                Session.Remove("activeCharacter");
            }

            // set it locally
            Character.Deleted = true;

            // set it on database
            string query = "UPDATE tblTitan SET suspended = 1 WHERE titanId = " + Character.Id + ";";
            Utilities.Insert(query);

            // redirect
            Response.BufferOutput = true;
            Response.Redirect("~/Character/");


        }

        protected void AnonymousOwner_CheckedChanged(object sender, EventArgs e)
        {

            if (AnonymousOwner.Checked == true)
            {
                Character.AnonymousOwner = true;
                Utilities.Insert("UPDATE tblTitan SET anonymousOwner = 1 WHERE titanId = " + Character.Id + ";");
            }
            else
            {
                Character.AnonymousOwner = false;
                Utilities.Insert("UPDATE tblTitan SET anonymousOwner = 0 WHERE titanId = " + Character.Id + ";");
            }

        }
    }
}
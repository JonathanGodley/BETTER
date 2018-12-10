// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web.UI;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Combat
{
    public partial class Outcome : System.Web.UI.Page
    {
        public UserCharacter Character;
        public UserCharacter Opponent;
        public FightRecord fRecord;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // Block Page if we haven't selected a Character
                if (Session["activeCharacter"] != null)
                {
                    // pull out the friendlyURL variable telling us who what battle we're looking at
                    fRecord = Utilities.FindFight(int.Parse(Page.RouteData.Values["var"].ToString()));

                    // so we have a character selected, now we make sure it's involved in the fight
                    if (fRecord.IsInvolved((int)Session["activeCharacter"]))
                    {
                        // find our character
                        Character = Utilities.FindCharacter(fRecord.GetOwnedBy((int)Session["currentUser"]));

                        // find opponent
                        Opponent = Utilities.FindCharacter(fRecord.GetNOT(Character.Id));
                    }
                    else
                    {
                        // redirect to BattleSummary page
                        Response.BufferOutput = true;
                        Response.Redirect("~/BattleSummary/");
                    }

                }
                else if (Session["loggedin"] != null)
                {
                    // redirect to character select page
                    Response.BufferOutput = true;
                    Response.Redirect("~/Character/");
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
                // if we're missing our variable we've hit an error
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }
        }
    }
}
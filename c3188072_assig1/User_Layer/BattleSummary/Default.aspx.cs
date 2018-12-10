// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Collections.Generic;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.BattleSummary
{
    public partial class Default : System.Web.UI.Page
    {
        public List<FightRecord> fRecs = new List<FightRecord>();
        public UserCharacter Character;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Block Page if we haven't selected a Character
            if (Session["activeCharacter"] != null)
            {

                // find active character
                int activeCharacter = (int)Session["activeCharacter"];

                // pull their info + their fights
                Character = Utilities.FindCharacter(activeCharacter);
                fRecs = (Utilities.FindFights(activeCharacter));
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
    }
}
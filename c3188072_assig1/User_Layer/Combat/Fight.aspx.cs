// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web.UI;
using c3188072_assig1.Models;
using System.Collections.Generic;

namespace c3188072_assig1.User_Layer.Combat
{
    public partial class Fight : System.Web.UI.Page
    {
        public UserCharacter Character;
        public UserCharacter Opponent;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Block Page if we haven't selected a Character
                if (Session["activeCharacter"] != null)
                {

                    int activeCharacter = (int)Session["activeCharacter"];

                    // pull their info + their fights
                    Character = Utilities.FindCharacter(activeCharacter);
                    Opponent = Utilities.FindCharacter(int.Parse(Page.RouteData.Values["var"].ToString()));
                    OpponentLabel.Text = Opponent.Name;

                    if (Character.Owner == Opponent.Owner || Opponent.Retired == true || Opponent.Deleted == true)
                    {
                        Response.BufferOutput = true;
                        Response.Redirect("~/Shared/ErrorPage");
                    }

                    if (Character.Retired == true)
                    {
                        Session.Remove("activeCharacter");
                        Response.BufferOutput = true;
                        Response.Redirect("~/Shared/ErrorPage");
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
                // if failure
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }
        }

        protected void StartFight(object sender, EventArgs e)
        {

            int victor;
            string query;
            // ints to hold battle xp used to determine victor, will be rounded into ints later
            double characterBattleXP = Character.Xp;
            double opponentBattleXP = Opponent.Xp;
            int earnedXP = 0;

            // A challenger receives a +25% experience points bonus per fight due to being the challenger. 
            // Challanger is always active player's character
            characterBattleXP = characterBattleXP * 1.25;

            // check for elemental bonus points (15%)
            if (Character.Element == "Water" && Opponent.Element == "Fire") { characterBattleXP = characterBattleXP * 1.15; }
            else if (Character.Element == "Fire" && Opponent.Element == "Air") { characterBattleXP = characterBattleXP * 1.15; }
            else if (Character.Element == "Air" && Opponent.Element == "Earth") { characterBattleXP = characterBattleXP * 1.15; }
            else if (Character.Element == "Earth" && Opponent.Element == "Water") { characterBattleXP = characterBattleXP * 1.15; }
            else if (Opponent.Element == "Water" && Character.Element == "Fire") { opponentBattleXP = opponentBattleXP * 1.15; }
            else if (Opponent.Element == "Fire" && Character.Element == "Air") { opponentBattleXP = opponentBattleXP * 1.15; }
            else if (Opponent.Element == "Air" && Character.Element == "Earth") { opponentBattleXP = opponentBattleXP * 1.15; }
            else if (Opponent.Element == "Earth" && Character.Element == "Water") { opponentBattleXP = opponentBattleXP * 1.15; }

            // random battle bonus
            // A simple binary random generator that will either grant a 25% experience points bonus to The Challenger or the Defender. 
            // create random generator
            Random rand = new Random(Int32.Parse(DateTime.Now.Millisecond.ToString()));
            // call for a binary result
            if (rand.Next(0, 1) == 0) { characterBattleXP = characterBattleXP * 1.25; } // challenger gets 25% bonus
            else { opponentBattleXP = opponentBattleXP * 1.25; } // defender gets 25% bonus

            // round both doubles up
            characterBattleXP = Math.Round(characterBattleXP);
            opponentBattleXP = Math.Round(opponentBattleXP);

            // determine our victor
            if (characterBattleXP > opponentBattleXP)
            {
                // player/challenger wins
                victor = Character.Id;
                earnedXP = (int)Math.Round((characterBattleXP * 0.25));
                Character.Xp += earnedXP;
                if (Character.Xp > 11501)
                {
                    Character.Xp = 11501;
                }
                query = "UPDATE tblTitan SET experience = " + Character.Xp + " WHERE titanId = " + Character.Id;
                Utilities.Insert(query);
                Character.UpdateStats();
                Character.LvlCheck();
            }
            else if (characterBattleXP < opponentBattleXP)
            {
                // opponent / defender wins
                victor = Opponent.Id;
                earnedXP = (int)Math.Round((opponentBattleXP * 0.25));
                Opponent.Xp += earnedXP;
                if (Opponent.Xp > 11501)
                {
                    Opponent.Xp = 11501;
                }
                query = "UPDATE tblTitan SET experience = " + Opponent.Xp + " WHERE titanId = " + Opponent.Id;
                Utilities.Insert(query);
                Opponent.UpdateStats();
                Opponent.LvlCheck();
            }
            else
            {
                // draw
                victor = -1;
            }

            // save our battle outcome
            query = "INSERT INTO tblBattle (battler1, battler2, battleWinner) " +
                        "VALUES(" + Character.Id + ", " + Opponent.Id + ", " + victor + ");";
            Utilities.Insert(query);

            // notify opponent a battle occured
            query = "UPDATE tblUser SET battleOccured = 1 WHERE userId = " + Opponent.Owner;
            Utilities.Insert(query);


            // find the id of the fight we just generated
            query = "SELECT TOP 1 battleId FROM tblBattle WHERE battler1 = " + Character.Id + " ORDER BY battleTime DESC;";
            List<Object> results = Utilities.SelectQuery(query);

            foreach (List<Object> result in results)
            {
                // go to outcome page of battle
                Response.BufferOutput = true;
                Response.Redirect("~/Combat/Outcome/" + result[0]);
            }


        }
    }
}
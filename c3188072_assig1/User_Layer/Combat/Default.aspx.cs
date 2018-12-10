// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Collections.Generic;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Combat
{
    public partial class Default : System.Web.UI.Page
    {
        public List<UserCharacter> uChars = new List<UserCharacter>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Block Page if we haven't selected a Character
            if (Session["activeCharacter"] != null)
            {
                try
                {
                    // search through all characters and grab everyone not owned by the player
                    string query = "SELECT * FROM tblTitan WHERE (userId != " + (int)Session["currentUser"] + " AND hallOfFame = 0 AND suspended = 0);";
                    // returning our results as a list
                    List<Object> results = Utilities.SelectQuery(query);
                    UserCharacter currentCharacter = Utilities.FindCharacter((int)Session["activeCharacter"]);

                    foreach (List<Object> result in results)
                    {
                        UserCharacter uc = new UserCharacter((string)result[1], (int)result[0], (int)result[4], (int)result[3], (int)result[2], result[8].ToString(), (bool)result[7], (bool)result[9], (bool)result[6]);

                        // need to check that A Monster can only challenge another Monster within 2 steps
                        // up of its own Level/Step and 1 step down of its own Level/Step. 
                        // [Some examples: a L2S4 (Level 2 Step 4) can challenge any other Monster in the range:
                        // L2S3 through to L3S2. A L1S3 can challenge any other Monster in the range: L1S2 through to L2S1]. 

                        // first we check if they're the same step / level
                        if (uc.Level == currentCharacter.Level && uc.Step == currentCharacter.Step)
                        { uChars.Add(uc); }

                        // now we'll check for the step behind, need to check for current level, 1 step behind, 
                        // and previous level, step 4 - IF current step is 1.

                        // current level, 1 step behind
                        else if (uc.Level == currentCharacter.Level && uc.Step == currentCharacter.Step - 1)
                        { uChars.Add(uc); }
                        // previous level, step 4
                        else if (uc.Level == currentCharacter.Level - 1 && uc.Step == 4 && currentCharacter.Step == 1)
                        { uChars.Add(uc); }

                        // now we need to check the 2 steps in front
                        // we need to check same level, 1 step ahead, 2 steps ahead
                        else if (uc.Level == currentCharacter.Level && uc.Step == currentCharacter.Step + 1)
                        { uChars.Add(uc); }
                        else if (uc.Level == currentCharacter.Level && uc.Step == currentCharacter.Step + 2)
                        { uChars.Add(uc); }

                        // need to check step 1 on next level if on step 3
                        else if (uc.Level == currentCharacter.Level + 1 && uc.Step == 1 && currentCharacter.Step == 3)
                        { uChars.Add(uc); }

                        // need to check step 1 and 2 on next level if on step 4
                        else if (uc.Level == currentCharacter.Level + 1 && uc.Step == 1 && currentCharacter.Step == 4)
                        { uChars.Add(uc); }
                        else if (uc.Level == currentCharacter.Level + 1 && uc.Step == 2 && currentCharacter.Step == 4)
                        { uChars.Add(uc); }

                    }
                }
                catch
                {
                    // if failure
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
    }
}
// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Exercise
{
    public partial class Allocate : System.Web.UI.Page
    {
        public List<UserCharacter> cpChars;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedin"] == null)
            {
                // redirect to login page
                Response.BufferOutput = true;
                Response.Redirect("~/Account/Login");
            }

            try
            {

                // find our useraccount
                int UserID = (int)Session["CurrentUser"];
                UserAccount curPlayer = Utilities.FindPlayer(UserID);

                // check and set number of available XP points
                int avlXPpoints = curPlayer.ExercisePoints;
                avlXP.Text = avlXPpoints.ToString();

                // load our data items
                cpChars = curPlayer.GetUserCharacters();

            }
            catch
            {
                // if failure
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }

        }

        protected void SpendPoints(object sender, EventArgs e)
        {
            try
            {
                pointWarning.Visible = false; // just hide the warning on button press, incase they've failed once already.
                                              // find our useraccount
                int UserID = (int)Session["CurrentUser"];
                UserAccount curPlayer = Utilities.FindPlayer(UserID);

                // check we have enough points to spend
                // loop through all text boxes
                String textboxString = "";
                foreach (TextBox textBox in dataPanel.Controls.OfType<TextBox>())
                {
                    textboxString = textBox.Text;
                }

                // split our string on the commas
                String[] valString;
                valString = textboxString.Split(',');
                int spentPoints = 0;

                foreach (string str in valString)
                {
                    string tmpStr = str; // avoid crashing from empty textboxes
                    if (tmpStr == "") { tmpStr = "0"; }
                    spentPoints += int.Parse(tmpStr.Replace(",", string.Empty));
                }

                if (spentPoints <= curPlayer.ExercisePoints && spentPoints >= 0)
                {
                    // update points
                    avlXP.Text = (Convert.ToInt32(avlXP.Text) - spentPoints).ToString();
                    curPlayer.ExercisePoints = Convert.ToInt32(avlXP.Text);
                    // update Exercise Points in user profile
                    string query = "UPDATE tblUser SET exercisePoints = " + curPlayer.ExercisePoints + " WHERE userId = " + curPlayer.UserID;
                    Utilities.Insert(query);

                    // spend points
                    int i = 0;
                    foreach (UserCharacter cpChar in cpChars)
                    {
                        string tmpStr = valString[i]; // avoid crashing from empty textboxes
                        if (tmpStr == "") { tmpStr = "0"; }
                        cpChar.Xp += int.Parse(tmpStr);
                        if (cpChar.Xp > 11501)
                        {
                            cpChar.Xp = 11501;
                        }
                        query = "UPDATE tblTitan SET experience = " + cpChar.Xp + " WHERE titanId = " + cpChar.Id;
                        Utilities.Insert(query);
                        i++;
                    }

                    // check for levelup & retirement
                    foreach (UserCharacter cpChar in cpChars)
                    {
                        cpChar.LvlCheck();
                    }
                }
                else // not enough points
                {
                    pointWarning.Visible = true;
                }

                // on-reload, prevent textboxes from being blank
                foreach (TextBox textBox in dataPanel.Controls.OfType<TextBox>())
                {
                    textBox.Text = "0";
                }
            }
            catch
            {
                // if failure
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }
        }
    }
}
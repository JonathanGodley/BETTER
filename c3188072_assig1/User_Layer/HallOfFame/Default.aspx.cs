// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Collections.Generic;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.HallOfFame
{
    public partial class Default : System.Web.UI.Page
    {
        public List<UserCharacter> hofChars = new List<UserCharacter>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // search through all characters and grab everyone not owned by the player
                string query = "SELECT * FROM tblTitan WHERE (hallOfFame = 1)";
                // returning our results as a list
                List<Object> results = Utilities.SelectQuery(query);

                foreach (List<Object> result in results)
                {
                    UserCharacter uc = new UserCharacter((string)result[1], (int)result[0], (int)result[4], (int)result[3], (int)result[2], result[8].ToString(), (bool)result[7], (bool)result[9], (bool)result[6]);
                    hofChars.Add(uc);
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
// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using c3188072_assig1.Models;
using System.Collections.Generic;

namespace c3188072_assig1.User_Layer.Overview
{
    public partial class Default : System.Web.UI.Page
    {
        public UserAccount uAc;
        public Boolean battleFought = false;
        public Boolean pointsLeft = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedin"] != null)
            {
                try
                {
                    uAc = Utilities.FindPlayer((int)Session["currentUser"]);

                    // check for points unspent
                    if (uAc.ExercisePoints > 0)
                    { pointsLeft = true; }

                    // check for battles fought
                    // first we query the database
                    string query = "SELECT battleOccured FROM tblUser WHERE (userId = '" + uAc.UserID + "')";
                    // returning our results as a list
                    List<Object> results = Utilities.SelectQuery(query);

                    // then get the result
                    foreach (List<Object> result in results)
                    {

                        battleFought = (bool)result[0];

                    }

                    // switch battles fought to negative
                    query = "UPDATE tblUser SET battleOccured = 0 WHERE userId = " + uAc.UserID;
                    c3188072_assig1.Models.Utilities.Insert(query);
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
    }
}
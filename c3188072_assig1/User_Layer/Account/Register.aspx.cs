// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web.UI;
using c3188072_assig1.Models;
using System.Collections.Generic;

namespace c3188072_assig1.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                bool result = true;
                // check for duplicate emails


                // first we query the database
                string query = "SELECT COUNT(*) FROM tblUser WHERE(email = '" + Email.Text.ToLower() + "');";
                // returning our results as a list
                List<Object> results = Utilities.SelectQuery(query);

                foreach (List<Object> item in results)
                {

                    if ((int)item[0] != 0)
                    {
                        result = false;
                    }
                }


                if (result)
                {
                    // make our user account and create a session
                    // generate a pin
                    int PPin = new Random().Next(1000, 9999); // random number for PIN, need to add Email Capabilities

                    if (Email.Text.Length >= 48)
                    {
                        FailureText.Text = "Your email is too long!";
                        ErrorMessage.Visible = true;

                    }
                    else if (ParentEmail.Text.Length >= 48)
                    {
                        FailureText.Text = "Your parent's is too long!";
                        ErrorMessage.Visible = true;

                    }
                    else if (Name.Text.Length >= 48)
                    {
                        FailureText.Text = "Your name is too long!";
                        ErrorMessage.Visible = true;

                    }
                    else
                    {


                        query = "INSERT INTO tblUser (name, email, passcode, parentEmail, pin, active) " +
                            "VALUES('" + Name.Text + "', '" + Email.Text.ToLower() + "', '" + ConfirmPassword.Text + "', '" + ParentEmail.Text.ToLower() + "', " + PPin + ", 1);";

                        // send the command to create the account
                        Utilities.Insert(query);

                        // send email containg ppin to parent
                        // SEE FUNCTION DEFINITION FOR WHY IT'S COMMENTED
                        // Utilities.Email(ParentEmail.Text.ToLower(), "Account Created", "A new account has been created, your pin to confirm your child's exercise is: " + PPin);

                        // Create Session
                        Session.Add("loggedin", true);

                        // find the userID we just created
                        Session.Add("currentUser", Utilities.FindPlayer(Email.Text.ToLower()).UserID);

                        // redirect
                        Response.BufferOutput = true;
                        Response.Redirect("~/Overview");
                    }
                }
                else
                {
                    FailureText.Text = "Registration Failed";
                }


            }
        }

    }
}
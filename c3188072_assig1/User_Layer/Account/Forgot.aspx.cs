// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Web.UI;
using c3188072_assig1.Models;
using System.Collections.Generic;

namespace c3188072_assig1.Account
{
    public partial class ForgotPassword : Page
    {

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // see if an account matching Email.Text exists
                bool found = false;

                // first we query the database
                try
                {
                    string query = "SELECT COUNT(*) FROM tblUser WHERE(email = '" + Email.Text.ToLower() + "');";
                    // returning our results as a list
                    List<Object> results = Utilities.SelectQuery(query);
                    foreach (List<Object> result in results)
                    {
                        if ((int)result[0] == 1)
                        {
                            found = true;
                        }
                    }

                    if (found)
                    {
                        // psuedo code for  further expansion
                        //Email(email.text, "reset link ="+Utilities.GenerateResetLink(email.text).ToString()) 
                    }

                    FailureText.Text = "If an account matches the provided information, an email has been sent";
                    ErrorMessage.Visible = true;

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
}
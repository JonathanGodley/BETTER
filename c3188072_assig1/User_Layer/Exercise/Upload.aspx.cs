// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
using System;
using System.Xml.Linq;
using c3188072_assig1.Models;
using System.Collections.Generic;
using System.IO;

namespace c3188072_assig1.User_Layer.Exercise
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedin"] == null)
            {
                // redirect to login page
                Response.BufferOutput = true;
                Response.Redirect("~/Account/Login");
            }
        }

        protected void UploadXML(object sender, EventArgs e)
        {


            if (IsValid)
            {
                // Validate the user pin
                // find our user
                int UserID = (int)Session["CurrentUser"];
                UserAccount User = Utilities.FindPlayer(UserID);

                // FOR TESTING PURPOSES, THIS FORM WILL ALWAYS ACCEPT 1234 
                var result = (int.Parse(ParentPin.Text) == 1234 || int.Parse(ParentPin.Text) == User.PPin);

                switch (result)
                {
                    case true: // if pin correct

                        // check if we're allowed to upload again
                        string query = "SELECT TOP 1 creationDate FROM tblExerciseRecord WHERE userID = " + UserID + " ORDER BY creationDate DESC;";
                        List<Object> results = Utilities.SelectQuery(query);

                        // work out the last time this user uploaded and cast it into a datetime
                        DateTime last = DateTime.Now.AddHours(-48);
                        foreach (List<Object> qResult in results)
                        {
                            last = (DateTime)qResult[0];
                        }

                        // check if the datetime is < 24h ago
                        if (last.AddHours(24).CompareTo(DateTime.Now) >= 0)
                        {
                            // uploading blocked
                            // display error message
                            FailureText.Text = "Last Upload was too recent";
                            ErrorMessage.Visible = true;
                            break;
                        }
                        else
                        {
                            // uploading allowed

                            // read file
                            int earnedPoints = 0;
                            // locate and check XML doc
                            if (XMLfile.PostedFile.ContentLength > 0) // if file not blank
                            {
                                string fn = System.IO.Path.GetFileName(XMLfile.PostedFile.FileName);
                                string SaveLocation = Server.MapPath(Path.Combine("~/uploads/xml/", UserID + ".xml"));

                                // save XML document
                                XMLfile.PostedFile.SaveAs(SaveLocation);

                                // read XML document
                                XDocument doc = XDocument.Load(Server.MapPath(Path.Combine("~/uploads/xml/", UserID + ".xml")));
                                XElement root = doc.Root;
                                foreach (XElement elem in root.Elements("points"))
                                // parse to double then to int to eliminate decimal places
                                { earnedPoints += (int)double.Parse(elem.Value.ToString()); }

                                // max 500 points earnable
                                if (earnedPoints > 500)
                                { earnedPoints = 500; }

                                // email link to parent
                                //Utilities.Email(User.ParentEmail, "Please Confirm your Child's Exercise", "Please Visit http://better.com/Exercise/ParentValidation/" + User.UserID + "to confirm your child earned "+ earnedPoints + "Points");

                                // add Exercise Points to user profile
                                query = "UPDATE tblUser SET exercisePoints = exercisePoints + " + earnedPoints + " WHERE userId = " + User.UserID;
                                Utilities.Insert(query);

                                // add to our exercise records
                                query = "INSERT INTO tblExerciseRecord (userId, exercisePoints) VALUES (" + UserID + ", " + earnedPoints + ");";
                                Utilities.Insert(query);


                                // redirect to overview page
                                Response.BufferOutput = true;
                                Response.Redirect("Default");
                            }
                        }
                        break;
                    case false: // pin invalid
                    default:
                        FailureText.Text = "Invalid Pin";
                        ErrorMessage.Visible = true;
                        break;
                }
            }


        }
    }
}
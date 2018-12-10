// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
// Utility Functions for Class
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace c3188072_assig1.Models
{
    public class Utilities
    {
        // run a select query on our database and return the results as a list
        public static List<Object> SelectQuery(String query)
        {
            // Prepare connection and command
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=udbBetter;Integrated Security=true;");
            SqlCommand command = new SqlCommand(query, connection);

            // Open Connection and Execute our Command
            connection.Open();
            SqlDataReader result = command.ExecuteReader();

            // Store the results of our query in a list
            List<Object> results = new List<Object>();

            // add our query results to our list
            while (result.Read()) // loop until all results read
            {
                // we're going to store all the data for each row of results in another list for ease of manipulation,
                //      rather than trying to struggle with a list or arrays
                List<Object> row = new List<Object>();

                // add each field to our 'row'
                for (int i = 0; i < result.FieldCount; i++)
                    row.Add(result[i]);

                // add our 'row' to our results list
                results.Add(row);
            }

            //Close the connection
            connection.Close();

            return results;
        }

        // run a command to create a new data row
        public static void Insert(String query)
        {
            // Prepare connection and command
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=udbBetter;Integrated Security=true;");
            SqlCommand command = new SqlCommand(query, connection);

            // Open Connection
            connection.Open();

            // Run Command and close connection
            command.ExecuteNonQuery();
            connection.Close();
        }

        // return the player whose userID is provided
        public static UserAccount FindPlayer(int findThis)
        {
            UserAccount tempUA = null;

            // first we query the database
            string query = "SELECT * FROM tblUser WHERE (userId = '" + findThis + "')";
            // returning our results as a list
            List<Object> results = SelectQuery(query);

            // then pull the result into a userAccount object
            foreach (List<Object> result in results)
            {
                tempUA = new UserAccount(Convert.ToInt32(result[0]), (string)result[1], (string)result[2], (string)result[4], (string)result[3], Convert.ToInt32(result[5]), Convert.ToInt32(result[6]));
            }
            return tempUA;
        }

        // return the player whose email is provided
        public static UserAccount FindPlayer(string email)
        {
            UserAccount tempUA = null;

            // first we query the database
            string query = "SELECT * FROM tblUser WHERE (email = '" + email.ToLower() + "')";
            // returning our results as a list
            List<Object> results = SelectQuery(query);

            // then pull the result into a userAccount object
            foreach (List<Object> result in results)
            {
                tempUA = new UserAccount(Convert.ToInt32(result[0]), (string)result[1], (string)result[2], (string)result[4], (string)result[3], Convert.ToInt32(result[5]), Convert.ToInt32(result[6]));
            }
            return tempUA;
        }

        // return the character whose ID is provided
        public static UserCharacter FindCharacter(int ID)
        {
            UserCharacter tempUC = null;

            // first we query the database
            string query = "SELECT * FROM tblTitan WHERE (titanId = '" + ID + "')";
            // returning our results as a list
            List<Object> results = SelectQuery(query);

            // then pull the result into a userCharacter object
            foreach (List<Object> result in results)
            {
                tempUC = new UserCharacter((string)result[1], (int)result[0], (int)result[4], (int)result[3], (int)result[2], result[8].ToString(), (bool)result[7], (bool)result[9], (bool)result[6]);
            }
            return tempUC;
        }

        // return all fights involving the character specified
        public static List<FightRecord> FindFights(int ID)
        {
            List<FightRecord> found = new List<FightRecord>();

            // first we query the database
            string query = "SELECT * FROM tblBattle WHERE (battler1 = " + ID + " OR battler2 = " + ID + ")";
            // returning our results as a list
            List<Object> results = SelectQuery(query);

            // process our list into a list of fight records
            foreach (List<Object> result in results)
            {


                FightRecord tmpFR = new FightRecord((int)result[0], (int)result[1], (int)result[2], (int)result[4], result[3].ToString());
                found.Add(tmpFR);

            }


            return found;
        }

        // find a fight by it's ID
        public static FightRecord FindFight(int ID)
        {
            FightRecord tempFR = null;

            // first we query the database
            string query = "SELECT * FROM tblBattle WHERE (battleId = " + ID + ")";
            // returning our results as a list
            List<Object> results = SelectQuery(query);

            // then pull the result into a fightRecord object
            foreach (List<Object> result in results)
            {
                tempFR = new FightRecord((int)result[0], (int)result[1], (int)result[2], (int)result[4], result[3].ToString());
            }
            return tempFR;
        }


        // send an email

        // okay, this is essentially a proof of concept, I've tried gmail and my ISP internode as providers and I haven't been
        // able to get anywhere, and I've tried two seperate methods to go about it and I give up.

        // I'm pretty sure my code works and i'm just having problems with the providers, 
        // the following results in an "go away you're a spammer" message from Gmail, which is better than the 
        // time-outs i've been getting with Internode,
        // I've followed https://support.google.com/a/answer/176600?hl=en and tried the middle column to varying success, so i don't know.

        // I've commented out everywhere I would've sent an email had it worked

        // for testing you can just load Exercise/ParentValidation/<UserID> and that would've been the link emailed.

        // I would've tried hosting my own SMTP server and testing it that way, but I've ran out of time I'm afraid.

        public static void Email(String recepient, String Subject, String Message)
        {
            SmtpClient smtpClient = new SmtpClient("aspmx.l.google.com", 25);

            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.Credentials = new System.Net.NetworkCredential("UserName", "MyPassWord");

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From & To
            mail.From = new MailAddress("c3188072@uon.edu.au", "B.E.T.T.E.R.");
            mail.To.Add(new MailAddress(recepient));

            //Set Contents
            mail.Subject = Subject;
            mail.Body = Message;

            smtpClient.Send(mail);
        }




    }
}
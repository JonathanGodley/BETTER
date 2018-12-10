// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
// User Account Class
using System;
using System.Collections.Generic;

namespace c3188072_assig1.Models
{
    public class UserAccount
    {
        // class variables
        private int uaUserID;
        private String uaName;
        private String uaEmail;
        private String uaParentEmail;
        private String uaPassword;
        private int uaPPin;
        private int uaExercisePoints;

        // Constructor
        public UserAccount(int UserID, String UserName, String UserEmail, String ParentEmail, String UserPassword, int ParentPin, int ExercisePoints)
        {
            uaUserID = UserID;
            uaName = UserName;
            uaEmail = UserEmail.ToLower();
            uaParentEmail = ParentEmail.ToLower();
            uaPassword = UserPassword;
            uaPPin = ParentPin;
            uaExercisePoints = ExercisePoints;
        }

        // Constructor
        public UserAccount(int UserID, String UserName, String UserEmail, String ParentEmail, String UserPassword)
        {
            uaUserID = UserID;
            uaName = UserName;
            uaEmail = UserEmail.ToLower();
            uaParentEmail = ParentEmail.ToLower();
            uaPassword = UserPassword;
            uaPPin = new Random().Next(1000, 9999); // random number for PIN, need to add Email Capabilities
            //Email(ParentEmail, "Account Created, "Excercise Pin: "+uaPPin.ToString()) 
            uaExercisePoints = 0;
        }

        // Gets and Sets
        public int UserID
        {
            get
            {
                return uaUserID;
            }
        }

        public String Name
        {
            get
            {
                return uaName;
            }
            set
            {
                uaName = value;
            }
        }

        public String Email
        {
            get
            {
                return uaEmail;
            }
            set
            {
                uaEmail = value;
            }
        }

        public String ParentEmail
        {
            get
            {
                return uaParentEmail;
            }
            set
            {
                uaParentEmail = value;
            }
        }

        public String Password
        {
            get
            {
                return uaPassword;
            }
            set
            {
                uaPassword = value;
            }
        }

        public int PPin
        {
            get
            {
                return uaPPin;
            }
            set
            {
                uaPPin = value;
            }
        }

        public int ExercisePoints
        {
            get
            {
                return uaExercisePoints;
            }
            set
            {
                uaExercisePoints = value;
            }
        }

        // get characters owned by this player
        public List<UserCharacter> GetUserCharacters()
        {

            List<UserCharacter> playerChars = new List<UserCharacter>();

            //loop through the global list and copy the ones belonging to us that aren't retired

            // first we query the database
            string query = "SELECT * FROM tblTitan WHERE (userId = " + UserID + " AND hallOfFame = 0 AND suspended = 0);";

            // returning our results as a list
            List<Object> results = Utilities.SelectQuery(query);

            // process our list into a list of user characters
            foreach (List<Object> result in results)
            {
                UserCharacter tempUC = new UserCharacter((string)result[1], (int)result[0], (int)result[4], (int)result[3], (int)result[2], result[8].ToString(), (bool)result[7], (bool)result[9], (bool)result[6]);
                playerChars.Add(tempUC);
            }

            return playerChars;
        }

        // get exercise done by this player
        public List<ExerciseRecord> GetUserExercise()
        {
            List<ExerciseRecord> playerExercise = new List<ExerciseRecord>();

            //loop through the global list and copy the ones belonging to us
            // first we query the database
            string query = "SELECT * FROM tblExerciseRecord WHERE (userId = " + UserID + " );";

            // returning our results as a list
            List<Object> results = Utilities.SelectQuery(query);

            // process our list into a list of exercise records
            foreach (List<Object> result in results)
            {
                ExerciseRecord tempER = new ExerciseRecord((int)result[2], (int)result[1], result[3].ToString());
                playerExercise.Add(tempER);
            }

            return playerExercise;
        }

    }
}
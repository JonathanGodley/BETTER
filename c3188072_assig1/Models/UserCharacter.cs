// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
// Game Character Class
using System;
using System.Collections.Generic;

namespace c3188072_assig1.Models
{
    public class UserCharacter
    {
        // class variables
        private int cID;
        private int cXp;
        private string cElement;
        private int cOwner;
        private int cLevel;
        private int cStep;
        private int cWins;
        private int cLosses;
        private int cDraws;
        private string cName;
        private string cCreated;
        private bool cRetired;
        private bool cAnonymousOwner;
        private bool cDeleted;

        // constructor
        public UserCharacter(string inpName, int inpElement, int inpID, int inpOwner, string inpCreated)
        {
            cName = inpName;
            cID = inpID;
            cXp = 0;

            // find element name from element ID provided
            List<Object> results = Utilities.SelectQuery("SELECT elementName FROM tblElement WHERE elementID = " + inpElement + ";");
            foreach (List<Object> result in results)
            {
                cElement = (string)result[0];
            }

            cOwner = inpOwner;
            cCreated = inpCreated;
            cRetired = false;
            LvlCheck();
            UpdateStats();
            cAnonymousOwner = false;
            cDeleted = false;
        }

        // 2nd Constructor
        public UserCharacter(string inpName, int inpID, int inpXP, int inpElement, int inpOwner, string inpCreated, bool inpRetired, bool inpAnonymous, bool inpDeleted)
        {
            cName = inpName;
            cID = inpID;
            cXp = inpXP;

            // find element name from element ID provided
            List<Object> results = Utilities.SelectQuery("SELECT elementName FROM tblElement WHERE elementID = " + inpElement + ";");
            foreach (List<Object> result in results)
            {
                cElement = (string)result[0];
            }

            cOwner = inpOwner;
            cCreated = inpCreated;
            cRetired = inpRetired;
            LvlCheck();
            UpdateStats();
            cAnonymousOwner = inpAnonymous;
            cDeleted = inpDeleted;
        }

        // Gets & Sets
        public int Id
        {
            get
            {
                return cID;
            }
        }

        public int Xp
        {
            get
            {
                return cXp;
            }
            set
            {
                cXp = value;
            }
        }

        public int Owner
        {
            get
            {
                return cOwner;
            }
            set
            {
                cOwner = value;
            }
        }

        public string Element
        {
            get
            {
                return cElement;
            }
        }

        public String Name
        {
            get
            {
                return cName;
            }
            set
            {
                cName = value;
            }
        }

        public String Created
        {
            get
            {
                return cCreated;
            }
            set
            {
                cCreated = value;
            }
        }

        public bool Retired
        {
            get
            {
                return cRetired;
            }
            set
            {
                cRetired = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return cDeleted;
            }
            set
            {
                cDeleted = value;
            }
        }

        public int Level
        {
            get
            {
                return cLevel;
            }
        }

        public int Step
        {
            get
            {
                return cStep;
            }
        }

        public int Wins
        {
            get
            {
                return cWins;
            }
        }

        public int Losses
        {
            get
            {
                return cLosses;
            }
        }

        public int Draws
        {
            get
            {
                return cDraws;
            }
        }

        public bool AnonymousOwner
        {
            get
            {
                return cAnonymousOwner;
            }
            set
            {
                cAnonymousOwner = value;
            }
        }

        public void LvlCheck()
        {
            // make sure xp isn't over limit
            if (Xp > 11501)
            {
                // fix it
                Xp = 11501;
                string query = "UPDATE tblTitan SET experience = " + Xp + " WHERE titanId = " + Id;
                Utilities.Insert(query);
            }

            if (Xp == 11501) // make sure we're retired
            {
                Retired = true;
                // query to make self HOF
                string query = "UPDATE tblTitan SET hallOfFame = 1 WHERE titanId = " + Id;
                Utilities.Insert(query);

            }

            // return the level and step appropriate for current xp
            string query2 = "SELECT TOP 1 lvl,step FROM tblExperience WHERE " + Xp + " <= expMax;";
            List<Object> results = Utilities.SelectQuery(query2);


            foreach (List<Object> result in results)
            {
                cLevel = Convert.ToInt32(result[0]);
                cStep = Convert.ToInt32(result[1]);
            }


        }

        public void UpdateStats()
        {
            // find number of wins
            string query = "SELECT COUNT(*) FROM tblBattle WHERE ((battler1 = " + Id + " OR battler2 = " + Id + ") AND battleWinner = " + Id + ");";
            List<Object> results = Utilities.SelectQuery(query);
            foreach (List<Object> result in results)
            {
                cWins = Convert.ToInt32(result[0]);
            }

            // find losses
            query = "SELECT COUNT(*) FROM tblBattle WHERE ((battler1 = " + Id + " OR battler2 = " + Id + ") AND (battleWinner != " + Id + " AND battleWinner != -1));";
            results = Utilities.SelectQuery(query);
            foreach (List<Object> result in results)
            {
                cLosses = Convert.ToInt32(result[0]);
            }

            // find draws

            query = "SELECT COUNT(*) FROM tblBattle WHERE ((battler1 = " + Id + " OR battler2 = " + Id + ") AND battleWinner = -1);";
            results = Utilities.SelectQuery(query);
            foreach (List<Object> result in results)
            {
                cDraws = Convert.ToInt32(result[0]);
            }
        }
    }
}
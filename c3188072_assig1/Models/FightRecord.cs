// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
// Contains Information About Fights

namespace c3188072_assig1.Models
{
    public class FightRecord
    {
        // class variables
        private int frID;
        private int[] frCombatants = new int[2];
        private int frVictor;
        private string battletime;

        // Constructor
        public FightRecord(int ID, int Combatant1, int Combatant2, int Victor, string dt)
        {
            frID = ID;
            frCombatants[0] = Combatant1;
            frCombatants[1] = Combatant2;
            frVictor = Victor;
            battletime = dt;
        }

        // return the character in the corresponding position
        public int GetCombatant(int i)
        {
            return frCombatants[i];
        }

        // return the character whose ID is NOT i
        public int GetNOT(int i)
        {
            if (i == frCombatants[0])
            {
                return frCombatants[1];
            }
            else
            {
                return frCombatants[0];
            }
        }

        // return the character owned by i
        public int GetOwnedBy(int i)
        {
            if (i == Utilities.FindCharacter(frCombatants[0]).Owner)
            {
                return frCombatants[0];
            }
            else
            {
                return frCombatants[1];
            }
        }
        // get Victor
        public int Victor
        {
            get
            {
                return frVictor;
            }
        }

        // get fightID
        public int ID
        {
            get
            {
                return frID;
            }
        }

        // is the character i involved in the fight
        public bool IsInvolved(int i)
        {
            bool val = false;

            if (i == frCombatants[0])
            {
                val = true;
            }
            else if (i == frCombatants[1])
            {
                val = true;
            }

            return val;
        }
    }
}
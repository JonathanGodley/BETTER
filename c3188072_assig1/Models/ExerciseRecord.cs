// Jonathan Godley - c3188072
// Last Modified: 03/11/2017
// Inft3050 Assignment 2
// Contains information about an exercise upload
using System;

namespace c3188072_assig1.Models
{
    public class ExerciseRecord
    {
        // class variables
        private int erPointsEarned;
        private int erOwner;
        private string erDate;


        // constructor
        public ExerciseRecord(int inpPoints, int inpOwner, string inpDate)
        {
            erPointsEarned = inpPoints;
            erOwner = inpOwner;
            erDate = inpDate;
        }



        // Gets & Sets
        public int PointsEarned
        {
            get
            {
                return erPointsEarned;
            }
            set
            {
                erPointsEarned = value;
            }
        }

        public int Owner
        {
            get
            {
                return erOwner;
            }
            set
            {
                erOwner = value;
            }
        }

        public String Date
        {
            get
            {
                return erDate;
            }
            set
            {
                erDate = value;
            }
        }
    }
}
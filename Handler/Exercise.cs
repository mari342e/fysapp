using System;
using System.Collections.Generic;

namespace Handler
{
    public class Exercise
    {       
        public int UserGroupID { get; set; }
        public int ExerciseID { get; set; }
        public string ExerciseTitle { get; set; }
        public List<string> ImageLinks { get; set; }
        public List<string> Description { get; set; }
        public string Repetition { get; set; }
        public string Breaks { get; set; }
        public string Focus { get; set; }

        public Exercise(int userGroupID, int exerciseID, string exerciseTitle, List<string> imageLinks, List<string> description, string repetition, string breaks, string focus)
        {
            UserGroupID = userGroupID;
            ExerciseID = exerciseID;
            ExerciseTitle = exerciseTitle;
            ImageLinks = imageLinks;
            Description = description;
            Repetition = repetition;
            Breaks = breaks;
            Focus = focus;
        }

    }
}

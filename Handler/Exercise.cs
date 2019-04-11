﻿using System;
using System.Collections.Generic;

namespace Handler
{
    public class Exercise
    {       
        public int UserGroupID { get; set; }
        public int ExerciseID { get; set; }
        public string Title { get; set; }
        public List<string> ImageLinks { get; set; }
        public List<string> Description { get; set; }
        public string Repetition { get; set; }
        public string Breaks { get; set; }
        public string Focus { get; set; }

        public Exercise(int userGroupID, int exerciseID, string title, List<string> imageLinks, List<string> description, string repetition, string breaks, string focus)
        {
            UserGroupID = userGroupID;
            ExerciseID = exerciseID;
            Title = title;
            ImageLinks = imageLinks;
            Description = description;
            Repetition = repetition;
            Breaks = breaks;
            Focus = focus;
        }

    }
}

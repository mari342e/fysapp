﻿using System;
using System.Collections.Generic;

namespace Handler.Models
{
    public class Exercise
    {       
        public int UserGroupID { get; set; }
        public int ExerciseID { get; set; }
        public string ApiExerciseID { get; set; }
        public string Title { get; set; }
        public string ImageLinks { get; set; }
        public string Description { get; set; }
        public string Repetition { get; set; }
        public string Breaks { get; set; }
        public string Focus { get; set; }

        public Exercise(int userGroupID, int exerciseID, string apiExerciseID, string title, string imageLinks, string description, string repetition, string breaks, string focus)
        {
            UserGroupID = userGroupID;
            ExerciseID = exerciseID;
            ApiExerciseID = apiExerciseID;
            Title = title;
            ImageLinks = imageLinks;
            Description = description;
            Repetition = repetition;
            Breaks = breaks;
            Focus = focus;
        }

        public Exercise()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Models
{
    public class TrainingExercise
    {
        public class Training
        {
            public string ExerciseID { get; set; }
            public DateTime time { get; set; }
            public int set1Repetiotions { get; set; }
            public int set2Repetiotions { get; set; }
            public int set3Repetiotions { get; set; }
            public double set1Weights { get; set; }
            public double set2Weights { get; set; }
            public double set3Weights { get; set; }
        }
    }
}

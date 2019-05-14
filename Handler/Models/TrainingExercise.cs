using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Models
{
    public class TrainingExercise
    {
        public TrainingExercise(string exerciseID, DateTime time, int set1Repetitions, int set2Repetitions, int set3Repetitions, double set1Weights, double set2Weights, double set3Weights)
        {
            ExerciseID = exerciseID;
            this.time = time;
            this.set1Repetitions = set1Repetitions;
            this.set2Repetitions = set2Repetitions;
            this.set3Repetitions = set3Repetitions;
            this.set1Weights = set1Weights;
            this.set2Weights = set2Weights;
            this.set3Weights = set3Weights;
        }
        public TrainingExercise() { }

        public string ExerciseID { get; set; }
        public DateTime time { get; set; }
        public int set1Repetitions { get; set; }
        public int set2Repetitions { get; set; }
        public int set3Repetitions { get; set; }
        public double set1Weights { get; set; }
        public double set2Weights { get; set; }
        public double set3Weights { get; set; }

    }
}

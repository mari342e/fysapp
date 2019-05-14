using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Models
{
    
    public class Training
    {
        public string _id { get; set; }
        public string UserID { get; set; }
        public string SessionID { get; set; }
        public bool TrainingFysioToday { get; set; }
        public double PainsBefore { get; set; }
        public bool TakenPainkillerBefore { get; set; }
        public string TypePainkillerBefore { get; set; }
        public string AmountPainkillerBefore { get; set; }
        public bool SideEffectsBefore { get; set; }
        public string SideEffectsDescriptionBefore { get; set; }
        public int PainsAfter { get; set; }
        public bool TakenPainkillerAfter { get; set; }
        public string TypePainkillerAfter { get; set; }
        public string AmountPainkillerAfter { get; set; }
        public bool ExhaustedAfter { get; set; }
        public bool Completed { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public List<TrainingExercise> TrainingExercises { get; set; }

        public Training()
        {
        }
        public Training(Training training) {
            _id = training._id;
            UserID = training.UserID;
            SessionID = training.SessionID;
            TrainingFysioToday = training.TrainingFysioToday;
            PainsBefore = training.PainsBefore;
            TakenPainkillerBefore = training.TakenPainkillerBefore;
            TypePainkillerBefore = training.TypePainkillerBefore;
            AmountPainkillerBefore = training.AmountPainkillerBefore;
            SideEffectsBefore = training.SideEffectsBefore;
            SideEffectsDescriptionBefore = training.SideEffectsDescriptionBefore;
            PainsAfter = training.PainsAfter;
            TakenPainkillerAfter = training.TakenPainkillerAfter;
            TypePainkillerAfter = training.TypePainkillerAfter;
            AmountPainkillerAfter = training.AmountPainkillerAfter;
            ExhaustedAfter = training.ExhaustedAfter;
            Completed = training.Completed;
            Comments = training.Comments;
            Date = training.Date;
            TrainingExercises = training.TrainingExercises;
        }
        public Training(string userID, string sessionID, bool trainingFysioToday, double painsBefore, bool takenPainKillerBefore, string typePainkillerBefore, string amountPainkillerBefore, bool sideEffectsBefore, string sideEffectsDescriptionBefore, int painsAfter, bool takenPainkillerAfter, string typePainkillerAfter, string amountPainkillerAfter, bool exhaustedAfter, string comments, bool completed, DateTime date, List<TrainingExercise> trainingExercises, string _ided)
        {
            UserID = userID;
            SessionID = sessionID;
            TrainingFysioToday = trainingFysioToday;
            PainsBefore = painsBefore;
            TakenPainkillerBefore = takenPainKillerBefore;
            TypePainkillerBefore = typePainkillerBefore;
            AmountPainkillerBefore = amountPainkillerBefore;
            SideEffectsBefore = sideEffectsBefore;
            SideEffectsDescriptionBefore = sideEffectsDescriptionBefore;
            PainsAfter = painsAfter;
            TakenPainkillerAfter = takenPainkillerAfter;
            TypePainkillerAfter = typePainkillerAfter;
            AmountPainkillerAfter = amountPainkillerAfter;
            ExhaustedAfter = exhaustedAfter;
            Completed = completed;
            Comments = comments;
            Date = date;
            TrainingExercises = trainingExercises;
            _id = _ided;
        }
    }
}

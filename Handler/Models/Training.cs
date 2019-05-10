using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Models
{
    
    public class Training
    {        
        public string UserID { get; set; }
        public string SessionID { get; set; }
        public bool trainingFysioToday { get; set; }
        public double PainsBefore { get; set; }
        public bool TakenPainKillerBefore { get; set; }
        public string TypePainkillerBefore { get; set; }
        public string AmountPainkillerBefore { get; set; }
        public bool SideEffectsBefore { get; set; }
        public string SideEffectsDescriptionBefore { get; set; }
        public int PainsAfter { get; set; }
        public bool TakenPainkillerAfter { get; set; }
        public string TypePainkillerAfter { get; set; }
        public string AmountPainkillerAfter { get; set; }
        public bool ExhaustedAfter { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public List<TrainingExercise> TrainingExercises { get; set; }

        public Training()
        {
        }
        public Training(string userID, string sessionID, bool trainingFysioToday, double painsBefore, bool takenPainKillerBefore, string typePainkillerBefore, string amountPainkillerBefore, bool sideEffectsBefore, string sideEffectsDescriptionBefore, int painsAfter, bool takenPainkillerAfter, string typePainkillerAfter, string amountPainkillerAfter, bool exhaustedAfter, string comments, DateTime date, List<TrainingExercise> trainingExercises)
        {
            UserID = userID;
            SessionID = sessionID;
            this.trainingFysioToday = trainingFysioToday;
            PainsBefore = painsBefore;
            TakenPainKillerBefore = takenPainKillerBefore;
            TypePainkillerBefore = typePainkillerBefore;
            AmountPainkillerBefore = amountPainkillerBefore;
            SideEffectsBefore = sideEffectsBefore;
            SideEffectsDescriptionBefore = sideEffectsDescriptionBefore;
            PainsAfter = painsAfter;
            TakenPainkillerAfter = takenPainkillerAfter;
            TypePainkillerAfter = typePainkillerAfter;
            AmountPainkillerAfter = amountPainkillerAfter;
            ExhaustedAfter = exhaustedAfter;
            Comments = comments;
            Date = date;
            TrainingExercises = trainingExercises;
        }
    }
}

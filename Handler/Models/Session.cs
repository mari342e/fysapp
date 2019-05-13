using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Models
{
    public class Session
    {
        public string _id { get; set; }
        public int GroupID { get; set; }
        public int OrderNo { get; set; }
        public int DurationWeeks { get; set; }
        public DateTime UserStartDate { get; set; }
        public DateTime UserEndDate { get; set; }
        public List<int> UserWeekNo { get; set; }
        public int UserSelectedWeekNo { get; set; }
        public DateTime CreateDate { get; set; }
        public List<string> ExerciseIDs { get; set; }
        public List<Exercise> ExerciseList { get; set; }

        public Session(string id, int groupID, int orderNo, int durationWeeks, DateTime createDate, List<string> exerciseIDs, List<Exercise> exerciseList)
        {
            _id = id;
            GroupID = groupID;
            OrderNo = orderNo;
            DurationWeeks = durationWeeks;
            CreateDate = createDate;
            ExerciseIDs = exerciseIDs;
            ExerciseList = exerciseList;
        }
        public Session() { }
    }
    
}

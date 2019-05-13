using Handler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Handlers
{
    public class SessionHandler
    {
        private readonly string uri = "sessions";

        private async Task<List<Session>> addExercises(List<Session> list) {
            ExerciseHandler exerciseHandler = new ExerciseHandler();

            List<Exercise> exercises;

            //Tjekker om der er nogle exercises ellers venter den til de er hentet
          
            exercises = LoginInfo.AllExercises;
            
            foreach (var item in list)
            {
                item.ExerciseList = new List<Exercise>();
                foreach (var exerciseID in item.ExerciseIDs)
                {
                    var exercise = exercises.Find(e => e.ApiExerciseID == exerciseID);
                    if (exercise != null)
                    {
                        item.ExerciseList.Add(exercise);
                    }
                }
            }
            
            var trainings = LoginInfo.AllTrainings;
            var orderedList = list.OrderBy(i => i.OrderNo).ToList();

            if (trainings.Count < 1)
            {
                DateTime today = DateTime.Today;
                var dayOfWeek = (int)today.DayOfWeek;
                if (dayOfWeek == 0) {
                    dayOfWeek = 7;
                }
                var weekNo = 0;
                var startDate = today.AddDays(-dayOfWeek);
                foreach (var item in list)
                {
                    var sessionStartDate = startDate.AddDays(1);
                    item.UserStartDate = sessionStartDate;
                    var sessionEndDate = sessionStartDate.AddDays((item.DurationWeeks * 7) - 1);
                    item.UserEndDate = sessionEndDate;
                    item.UserWeekNo = new List<int>();
                    for (int i = weekNo+1; i <= weekNo + item.DurationWeeks; i++)
                    {
                        item.UserWeekNo.Add(i);
                    }
                    weekNo = item.UserWeekNo.Last();    
                    startDate = sessionEndDate;
                }
            }
            else {
                var firstTraining = trainings.First();
                DateTime firstTrainingDate = firstTraining.Date;

                var dayOfWeek = (int)firstTrainingDate.DayOfWeek;
                if (dayOfWeek == 0)
                {
                    dayOfWeek = 7;
                }
                var weekNo = 0;
                var startDate = firstTrainingDate.AddDays(-dayOfWeek);
                foreach (var item in list)
                {
                    var sessionStartDate = startDate.AddDays(1);
                    item.UserStartDate = sessionStartDate;
                    var sessionEndDate = sessionStartDate.AddDays((item.DurationWeeks * 7) - 1);
                    item.UserEndDate = sessionEndDate;
                    item.UserWeekNo = new List<int>();
                    for (int i = weekNo + 1; i <= weekNo + item.DurationWeeks; i++)
                    {
                        item.UserWeekNo.Add(i);
                    }
                    weekNo = item.UserWeekNo.Last();
                    startDate = sessionEndDate;
                }
            }

          

            return orderedList;
        }
        public async Task<List<Session>> GetAllSessions()
        {
            var json = await LoginInfo.client.GetStringAsync(uri);
            List<Session> list = JsonConvert.DeserializeObject<List<Session>>(json);
            var listNew = await addExercises(list);
            return listNew;
        }
        public async Task<List<Session>> GetGroupSessions(int groupID)
        {
            var json = await LoginInfo.client.GetStringAsync(uri + "/group/" + groupID.ToString());
            List<Session> list = JsonConvert.DeserializeObject<List<Session>>(json);          

            var listNew = await addExercises(list);
            return listNew;
        }
    }
}

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
                foreach (var exerciseID in item.ExerciseIDs)
                {
                    var exercise = exercises.Find(e => e.ApiExerciseID == exerciseID);
                    if (exercise != null)
                    {
                        item.ExerciseList.Add(exercise);
                    }
                }
            }

            var orderedList = list.OrderBy(i => i.OrderNo).ToList();

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

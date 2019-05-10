using Handler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Handlers
{
    public class SessionHandler
    {
        private readonly string uri = "sessions";

        private List<Session> addExercises(List<Session> list) {
            ExerciseHandler exerciseHandler = new ExerciseHandler();
            var exercises = exerciseHandler.GetExercises();
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
            return list;
        }
        public async Task<List<Session>> GetAllSessions()
        {
            var json = await ClientHttp.client.GetStringAsync(uri);
            List<Session> list = JsonConvert.DeserializeObject<List<Session>>(json);
            var listNew = addExercises(list);
            return listNew;
        }
        public async Task<List<Session>> GetGroupSessions(string groupID)
        {
            var json = await ClientHttp.client.GetStringAsync(uri + "/group/" + groupID);
            List<Session> list = JsonConvert.DeserializeObject<List<Session>>(json);

            var listNew = addExercises(list);
            return listNew;
        }
    }
}

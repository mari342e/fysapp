using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Handler.Models;
using System.Net.Http;

namespace Handler.Handlers
{
    public class ExerciseHandler
    {
        public async Task<List<Exercise>> GetExercisesByGroupID(int groupID)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync("https://fysapp-umbraco.azurewebsites.net/umbraco/api/Api/GetAllExercises");
            List<Exercise> exerciseList = JsonConvert.DeserializeObject<List<Exercise>>(json);
          
            var orderedList = exerciseList.FindAll(i => i.UserGroupID == groupID);

            return orderedList;
        }

    }
}

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
            //var list = new List<Exercise>();
            //string jsonName = "Exercises.json";
            //var assembly = typeof(ExerciseHandler).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonName}");

            //using (var reader = new StreamReader(stream))
            //{
            //    var jsonString = reader.ReadToEnd();

            //    list = JsonConvert.DeserializeObject<List<Exercise>>(jsonString);
            //}
            //var orderedList = list.FindAll(i => i.UserGroupID == groupID);


            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync("https://fysapp-umbraco.azurewebsites.net/umbraco/api/Api/GetAllExercises");
            List<Exercise> exerciseList = JsonConvert.DeserializeObject<List<Exercise>>(json);

            var orderedList = exerciseList.FindAll(i => i.UserGroupID == groupID);

            return orderedList;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

using System.IO;
using System.Reflection;

namespace Handler.Handlers
{
    public class ExerciseHandler
    {
        public List<Exercise> GetExercises()
        {
            var list = new List<Exercise>();
            string jsonName = "Exercises.json";
            var assembly = typeof(ExerciseHandler).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonName}");

            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Exercise>>(jsonString);
            }
            return list;
        }

    }
}

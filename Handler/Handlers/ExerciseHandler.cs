﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Handler.Models;

namespace Handler.Handlers
{
    public class ExerciseHandler
    {
        public async Task<List<Exercise>> GetExercisesByGroupID(int groupID)
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
            var orderedList = list.FindAll(i => i.UserGroupID == groupID);

            return list;
        }

    }
}

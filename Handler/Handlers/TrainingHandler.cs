using Handler.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Handlers
{
    public class TrainingHandler
    {
        private readonly string uri = "trainings";

        public async Task<List<Training>> GetTrainingsByUserID(string userID)
        {
            var json = await LoginInfo.client.GetStringAsync(uri + "/user/" + userID);
            List<Training> training = JsonConvert.DeserializeObject<List<Training>>(json);

            return training;
        }
        public async Task<Training> GetTrainingByID(string ID)
        {
            var json = await LoginInfo.client.GetStringAsync(uri + "/" + ID);
            Training training = JsonConvert.DeserializeObject<Training>(json);

            return training;
        }
        public async Task<List<Training>> GetTrainingsByUserAndSessionID(string userID, string sessionID)
        {
            var json = await LoginInfo.client.GetStringAsync(uri + "/usersession/" + userID +"/" + sessionID);
            List<Training> training = JsonConvert.DeserializeObject<List<Training>>(json);

            return training;
        }

        public async Task<Training> CreateTraining(Training newTraining)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var postJson = JsonConvert.SerializeObject(newTraining, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            StringContent queryString = new StringContent(postJson, Encoding.UTF8, "application/json");
            var response = await LoginInfo.client.PostAsync(uri, queryString);
            response.EnsureSuccessStatusCode();
            Training training = JsonConvert.DeserializeObject<Training>(await response.Content.ReadAsStringAsync());

            return training;
        }

        public async Task<Training> UpdateTraining(Training newTraining)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var postJson = JsonConvert.SerializeObject(newTraining, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            StringContent queryString = new StringContent(postJson, Encoding.UTF8, "application/json");
            
            var response = await LoginInfo.client.PutAsync(uri +"/" + newTraining._id, queryString);
            response.EnsureSuccessStatusCode();
            Training training = JsonConvert.DeserializeObject<Training>(await response.Content.ReadAsStringAsync());

            return training;
        }
        public async Task<TrainingExercise> AddTrainingExercise(TrainingExercise newTrainingExercise, string trainingID)
        {
            //Denne virker ikke :(
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var postJson = JsonConvert.SerializeObject(newTrainingExercise, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            StringContent queryString = new StringContent(postJson, Encoding.UTF8, "application/json");
            var response = await LoginInfo.client.PutAsync(uri + "/addexercise/" + trainingID, queryString);
            response.EnsureSuccessStatusCode();
            TrainingExercise trainingExercise = JsonConvert.DeserializeObject<TrainingExercise>(await response.Content.ReadAsStringAsync());

            return trainingExercise;
        }
    }
}

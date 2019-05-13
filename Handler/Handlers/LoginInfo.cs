using Handler.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Handlers
{
    public static class LoginInfo
    {
        public static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://fysappapi.herokuapp.com/")
        };
        public static User LoggedInUser = new User();
        public static List<Session> UserSessions = new List<Session>();
        public static List<Training> AllTrainings = new List<Training>();
        public static List<Exercise> AllExercises = new List<Exercise>();

        public static async Task<string> SetLoginInfo(string userID) {
            UserHandler userHandler = new UserHandler();
            var user = await userHandler.GetUserByID(userID);
           
            LoggedInUser = user;
            
               
            await SetExercises();
           await SetTrainings();
            await SetUserSessions();
            return "completed";
        }
       

        private static async Task<string> SetUserSessions()
        {
            SessionHandler sessionHandler = new SessionHandler();
            UserSessions = await sessionHandler.GetGroupSessions(LoggedInUser.GroupID);

            
            return "completed";
        }
        private static async Task<string> SetTrainings()
        {
            TrainingHandler trainingHandler = new TrainingHandler();
            AllTrainings = await trainingHandler.GetTrainingsByUserID(LoggedInUser._id);

            return "completed";
        }
        private static async Task<string> SetExercises()
        {
            ExerciseHandler trainingHandler = new ExerciseHandler();
            AllExercises = await trainingHandler.GetExercisesByGroupID(LoggedInUser.GroupID);
            
            return "completed";
        }


    }
}

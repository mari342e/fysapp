﻿using Handler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Handlers
{
    public class UserHandler
    {
        private readonly string uri = "users";
        public async Task<User> GetUserByAssignedID(string assignedID)
        {
            var response = await LoginInfo.client.GetAsync(uri + "/assignedid/" + assignedID);
            User user = null;
            if (response.IsSuccessStatusCode)
            {
                user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
           
            return user;
        }
        public async Task<User> GetUserByID(string ID)
        {
            var response = await LoginInfo.client.GetAsync(uri + "/" + ID);
            User user = null;
            if (response.IsSuccessStatusCode)
            {
                user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                LoginInfo.LoggedInUser = user;
            }
            return user;
        }
    }
}

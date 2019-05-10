using Handler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Handlers
{
    class UserHandler
    {
        private readonly string uri = "users";
        public async Task<User> GetUserByAssignedID(string assignedID)
        {
            var json = await ClientHttp.client.GetStringAsync(uri + "/assignedid/" + assignedID);
            User user = JsonConvert.DeserializeObject<User>(json);

            return user;
        }
        public async Task<User> GetUserByID(string ID)
        {
            var json = await ClientHttp.client.GetStringAsync(uri + "/" + ID);
            User user = JsonConvert.DeserializeObject<User>(json);

            return user;
        }
    }
}

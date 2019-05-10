using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Models
{
    public class User
    {        
        public string _id { get; set; }
        public int GroupID { get; set; }
        public int AssignedID { get; set; }

        public User(string id, int groupID, int assignedID)
        {
            _id = id;
            GroupID = groupID;
            AssignedID = assignedID;
        }

        public User()
        {

        }
    }
}

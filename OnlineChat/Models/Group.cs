using System.ComponentModel.DataAnnotations;

namespace OnlineChat.Models
{
    public class Group
    { 
        public int Id { get; set; }
        
        public string GroupName { get; set; }

        public List<User>? UsersInGroup { get; set; }
        public List<Message>? MessagesInGroup { get; set; }
    }
}

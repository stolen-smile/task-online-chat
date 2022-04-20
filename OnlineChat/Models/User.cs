using System.ComponentModel.DataAnnotations;

namespace OnlineChat.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string NickName { get; set; }

        public List<Message>? Messages { get; set; }

        public List<Group>? Groups { get; set; }
    }
}

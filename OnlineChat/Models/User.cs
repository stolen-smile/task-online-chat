using System.ComponentModel.DataAnnotations;

namespace OnlineChat.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your nickname")]
        public string NickName { get; set; }

        public List<Message>? Messages { get; set; }

        public List<Group>? Groups { get; set; }
    }
}

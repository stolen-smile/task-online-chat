using System.ComponentModel.DataAnnotations;

namespace OnlineChat.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your nickname please")]
        public string NickName { get; set; }
    }
}

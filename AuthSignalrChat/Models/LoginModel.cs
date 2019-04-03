using System.ComponentModel.DataAnnotations;

namespace AuthSignalrChat.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}

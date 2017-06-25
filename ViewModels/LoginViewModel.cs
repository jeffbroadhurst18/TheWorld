using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Error box")]
        [MinLength(5)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Error box")]
        [MinLength(5)]
        public string Password { get; set; }
    }
}

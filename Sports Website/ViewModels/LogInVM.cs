using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LogInVM
    {

        [Required(ErrorMessage = "User is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "password min length is 8")]
        public string Password { get; set; }
        public string returnUrl { get; set; }
    }
}

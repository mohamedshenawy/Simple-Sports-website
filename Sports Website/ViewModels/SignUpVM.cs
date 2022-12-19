using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class SignUpVM
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Emial not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8 , ErrorMessage ="password min length is 8")]
        public string Password { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ViewModels
{
    public class UpdateUserVM
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Emial not valid")]
        public string Email { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class RoleVM
    {
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }

    }
}

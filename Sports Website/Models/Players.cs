using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Players : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public virtual Teams Team { get; set; }
    }
}

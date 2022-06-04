using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Tours : BaseClass
    {
        [Required]
        public string Name { get; set; }

        //relations

        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public virtual Teams Team { get; set; }
       
        public virtual List<Matches> matches { get; set; }

        
    }
}

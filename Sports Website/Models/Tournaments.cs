using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Tournaments :BaseClass 
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public string vedioUrl { get; set; }
        
        //relations
        public virtual List<Teams> teams { get; set; }



    }
}

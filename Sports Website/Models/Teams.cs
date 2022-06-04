using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Teams : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoUrl { get; set; }
        public DateTime FoundationDate { get; set; }

        //relations

        [ForeignKey("Tournament")]
        public int? TournamentID { get; set; }
        public virtual Tournaments Tournament{ get; set; }



        public virtual List<Players> players { get; set; }

        public virtual List<Tours> tours { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Matches : BaseClass
    {
        [ForeignKey("Tour")]
        public int TourID { get; set; }
        public virtual Tours Tour { get; set; }
    }
}

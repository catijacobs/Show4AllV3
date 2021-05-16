using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3.Models
{
    public class StarRating
    {
       [Key]
       public int RateId { get; set; }
       public int Rate { get; set; }
       public string Location { get; set; }
       public int ShowsId { get; set; }
        [ForeignKey("ShowsId")]
       public virtual Shows Shows { get; set; }
    }
}

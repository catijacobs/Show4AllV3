using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3.Models
{
    public class Shows
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Primary Actor")]
        [Required]
        public int ActorListId { get; set; }
        [ForeignKey("ActorListId")]
        public virtual ActorList ActorList { get; set; }
        [Display(Name = "Season")]
        [Required]
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public virtual Season Season { get; set; }

        [Display(Name = "Episode")]
        [Required]
        public int EpisodeId { get; set; }
        [ForeignKey("EpisodeId")]
        public virtual Episode Episode { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        
        [StringLength(5)]
        public string Rating { get; set; }


        public int RateCount
        {
           get { return Ratings.Count; }
        }

       public int RateTotal
       {
            get
           {
               return (Ratings.Sum(m => m.Rate));
            }
       }

       public virtual ICollection<StarRating> Ratings { get; set; }

        public Shows()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vi.Models
{
    public class movie
    {
        public int  id { get; set;}
        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string name{ set; get; }
        
        public Genre genreType { get; set; }
        [Required]
        [Display(Name ="Genre Type")]
        public byte genreTypeId { get; set; }
        public DateTime dateAdded { get; set; }
        [Display(Name ="Release Date")]
        public DateTime dateReleased { get; set; }
        [Display(Name = "Number of Stock")]
        [Range(1,20)]
        [Required]
        public int stockAvailable { get; set; }
            

    }
}
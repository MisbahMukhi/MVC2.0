using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class Song
    {
        public Int32 SongID { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Album { get; set; }
        //public bool ShowDiscount {get; set} double check if this is string or decimal
       // public decimal DiscountPrice {get; set;}
        //public bool IsFeatured { get; set; } 
    
    

        //navigational properties 
        public virtual List<Artist> Artists { get; set; }
        public virtual List<Album> Albums { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual List<SongRating> SongRatings { get; set; }


    }
}
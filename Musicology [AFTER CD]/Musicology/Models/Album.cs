using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class Album
    { 
        public Int32 AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public decimal AlbumPrice { get; set; }
       
       
        //public bool ShowDiscount {get; set} double check if this is string or decimal
        //public decimal AlbumDiscountPrice { get; set; }
        //public bool IsFeatured { get; set; }

        //navigational properties
        public virtual List<Song> Songs { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual List<AlbumRating> AlbumRatings { get; set; }
        public virtual List<Artist> Artists { get; set; }

    }
}
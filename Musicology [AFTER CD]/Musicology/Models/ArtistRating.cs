using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class ArtistRating
    {
        public Int32 ArtistRatingID { get; set; }
        public Int32 ArtistRatingNum { get; set; }
        public string ArtistReview { get; set; }

        //navigational properties
        public virtual Artist Artists { get; set; }
        public virtual AppUser AppUsers { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class SongRating
    {
        public Int32 SongRatingID { get; set; }
        public Int32 SongRatingNum { get; set; }
        public string SongReview { get; set; }

        //navigational properties
        public virtual Song Songs { get; set; }
        public virtual AppUser AppUsers { get; set; }

    }
}
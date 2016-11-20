using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class AlbumRating
    {
        public Int32 AlbumRatingID { get; set; }
        public Int32 AlbumRatingNum { get; set; }
        public string AlbumReview { get; set; }

        //navigational properties
        public virtual Album Albums { get; set; }
        public virtual AppUser AppUsers { get; set; }

    }
}
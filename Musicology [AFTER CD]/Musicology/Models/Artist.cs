using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class Artist
    {
        public Int32 ArtistID { get; set; }
        public string ArtistName { get; set; }
       public string Genre { get; set; }
       // public bool IsFeatured { get; set; }
       
        //navigational properties 
        public virtual List<ArtistRating> ArtistRatings { get; set; }
        public virtual List<Song> Songs { get; set; }
        public virtual List<Album> Albums { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class OrderItem
    {
        public Int32 OrderItemID { get; set; }
        public Decimal Price { get; set; }
        public Decimal SongPrice { get; set; }
        public Decimal AlbumPrice { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual Song Songs { get; set; }
        public virtual Album Albums { get; set; }



    }
}
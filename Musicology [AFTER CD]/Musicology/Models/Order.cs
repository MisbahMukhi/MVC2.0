using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class Order
    {
        public Int32 OrderID { get; set; }
        public Decimal Subtotal { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Total { get; set; }


        //navigational properties
        public virtual AppUser AppUsers { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual CreditCard CreditCards { get; set; }
    }
}
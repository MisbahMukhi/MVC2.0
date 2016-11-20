using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicology.Models
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }
        public Int64 CreditCardNumber { get; set; }
        public string CreditCardType { get; set; }

        public Int32 ExpMonth { get; set; }
        public Int32 ExpYear { get; set; }
        public Int32 SecurityCode { get; set; }

        //navigational properties
        public virtual AppUser AppUsers { get; set; }

    }   
}
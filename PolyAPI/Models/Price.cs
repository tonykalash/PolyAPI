using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Price
    {
        public Price()
        {
            Bookings = new HashSet<Booking>();
        }

        public int PriceId { get; set; }
        public string? PriceName { get; set; }
        public string? PriceDescription { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

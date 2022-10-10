using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class PromoCode
    {
        public PromoCode()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int PromoId { get; set; }
        public string? PromoCodename { get; set; }
        public int? Discount { get; set; }

        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}

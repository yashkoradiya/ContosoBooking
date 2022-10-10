using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class Category
    {
        public int CatId { get; set; }
        public string? ClassType { get; set; }
        public int? SeatsAvailable { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceAlgorithm { get; set; }
    }
}

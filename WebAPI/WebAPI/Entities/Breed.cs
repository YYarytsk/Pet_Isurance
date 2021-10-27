using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Breed
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public decimal Price { get; set; }
        public decimal AvgLifeSpan { get; set; }
    }
}

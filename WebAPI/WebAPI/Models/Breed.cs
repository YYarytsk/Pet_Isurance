using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public decimal Price { get; set; }
        public decimal AvgLifeSpan { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Pet
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public decimal Age { get; set; }
        public string Location { get; set; }
        public string InsurancePlan { get; set; }
        public string InsuranceMonthly { get; set; }
        public int UserId { get; set; }
        public bool IsInsured { get; set; }

        public virtual User User { get; set; }
    }
}

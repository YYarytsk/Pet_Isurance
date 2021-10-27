using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class InsurancePlan
    {

            public InsurancePlan()
            {

            }
            public InsurancePlan(int petId, decimal goldCost, decimal silverCost)
            {
                PetId = petId;
                GoldCost = goldCost;
                SilverCost = silverCost;
            }
            public int PetId { get; set; }
            public decimal GoldCost { get; set; }
            public decimal SilverCost { get; set; }
        




    }
}

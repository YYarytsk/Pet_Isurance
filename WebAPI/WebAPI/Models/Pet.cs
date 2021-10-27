using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Pet
    {
        public Pet(int id, string breed, decimal age, string location, string insurancePlan, string insuranceMonthly, int userId, bool isInsured)
        {
            Id = id;
            Breed = breed;
            Age = age;
            Location = location;
            InsurancePlan = insurancePlan;
            InsuranceMonthly = insuranceMonthly;
            UserId = userId;
            IsInsured = isInsured;
        }
        public Pet(string breed, decimal age, string location, string insurancePlan, string insuranceMonthly, int userId, bool isInsured)
        {
            Breed = breed;
            Age = age;
            Location = location;
            InsurancePlan = insurancePlan;
            InsuranceMonthly = insuranceMonthly;
            UserId = userId;
            IsInsured = isInsured;
        }
        public Pet()
        {

        }
        public int Id { get; set; }
        public string Breed { get; set; }
        public decimal Age { get; set; }
        public string Location { get; set; }
        public string InsurancePlan { get; set; }
        public string InsuranceMonthly { get; set; }
        public int UserId { get; set; }
        public bool IsInsured { get; set; }
    }
}

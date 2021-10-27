using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class PetRepository : IPet
    {
        private readonly Entities.petinsuranceContext _context;

        public PetRepository(Entities.petinsuranceContext context)
        {
            _context = context;
        }
        public async Task<Pet> AddPet(Pet pet)
        {
            await _context.Pets.AddAsync(
                new Entities.Pet
                {
                    Breed = pet.Breed,
                    Age = pet.Age,
                    Location = pet.Location,
                    InsurancePlan = pet.InsurancePlan,
                    InsuranceMonthly = pet.InsuranceMonthly,
                    UserId = pet.UserId,
                });
            await _context.SaveChangesAsync();
            return pet;
        }



        public async Task<bool> DeletePetAsync(Pet pet)
        {                
            var attempt = _context.Remove(_context.Pets.FirstOrDefaultAsync(s => s.Id == pet.Id));
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }



        public async Task<Pet> GetPetById(int id)
        {
            var get = await _context.Pets.FirstOrDefaultAsync(s => s.Id == id);
            
            if(get != null)
            {
                Pet pet = new Pet(get.Id, get.Breed, get.Age, get.Location, get.InsurancePlan, get.InsuranceMonthly, get.UserId, get.IsInsured);
                return pet;
            }

            return null;
        }

        public Task<List<Pet>> GetPetsByUserId(int id)
        {
            Task<List<Pet>> list = _context.Pets.Where(p => p.UserId == id).Select(x => new Pet(x.Id, x.Breed, x.Age, x.Location, x.InsurancePlan, x.InsuranceMonthly, x.UserId, x.IsInsured)).ToListAsync();
            return list;
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            var original = await _context.Pets.FirstOrDefaultAsync(p => p.Id == pet.Id);
            original.Breed = pet.Breed;
            original.Age = pet.Age;
            original.Location = pet.Location;
            original.InsurancePlan = pet.InsurancePlan;
            original.InsuranceMonthly = pet.InsuranceMonthly;
            original.UserId = pet.UserId;
            original.IsInsured = pet.IsInsured;
            await _context.SaveChangesAsync();
            return pet;
        }
        /// <summary>
        /// CalculateInsurance gets called on a list of pets to do the calculations for cost
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public async Task<bool> CheckQualification(Pet pet)
        {
            if(pet.UserId != 0)
            {
                var findPet = await _context.Pets.FirstOrDefaultAsync(s => s.Id == pet.Id);
                var findBreed = await _context.Breeds.FirstOrDefaultAsync(b => b.Species == pet.Breed);
                var findState = await _context.States.FirstOrDefaultAsync(l => l.StateName == pet.Location);
                if (findState.QualifiedLizards.Split(", ").Contains(findBreed.Id.ToString()))
                {
                    return true;
                }
                else return false;
                
                
                
            }
            else
            {
                var findState = await _context.States.FirstOrDefaultAsync(l => l.StateName == pet.Location);
                if (findState.QualifiedLizards.Split(", ").Contains(pet.Breed))
                {
                    return true;
                }
                else return false;
            }
        }

        public async Task DeletePet(Pet pet)
        {
            var found = await _context.Pets.FirstOrDefaultAsync(p => p.Id == pet.Id);
            _context.Pets.Remove(found);
            await _context.SaveChangesAsync();
        }
        public async Task<InsurancePlan> GetQuote(Pet pet)
        {
            var foundBreed = await _context.Breeds.FirstOrDefaultAsync(s => s.Species == pet.Breed);
            InsurancePlan plan = new InsurancePlan();
            plan.PetId = pet.Id;

            var baseCost = pet.Age / foundBreed.AvgLifeSpan;
            var cost = foundBreed.Price * baseCost;

            decimal low = new decimal (.34);
            decimal high = new decimal (.66);
            if (baseCost < low)
            {
                plan.SilverCost = Math.Round(new decimal(.013) * foundBreed.Price, 2);
                plan.GoldCost = Math.Round(new decimal(.024) * foundBreed.Price, 2);
            }
            else if(baseCost > high)
            {
                plan.SilverCost = Math.Round(new decimal(.039) * foundBreed.Price, 2);
                plan.GoldCost = Math.Round(new decimal(.058) * foundBreed.Price, 2);
            }
            else
            {
                plan.SilverCost = Math.Round(new decimal(.023) * foundBreed.Price, 2);
                plan.GoldCost = Math.Round(new decimal(.035) * foundBreed.Price, 2);
            }
            return plan;
        }

        public async Task PayPets(List<Pet> pets)
        {
            foreach(Pet pet in pets)
            {
                Entities.Pet original = await _context.Pets.Where(p => p.Id == pet.Id).FirstOrDefaultAsync();
                if(original != null)
                {
                    original.Breed = pet.Breed;
                    original.Age = pet.Age;
                    original.Location = pet.Location;
                    original.InsurancePlan = pet.InsurancePlan;
                    original.InsuranceMonthly = pet.InsuranceMonthly;
                    original.UserId = pet.UserId;
                    original.IsInsured = true;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}

using Xunit;
using WebAPI.Repositories;
using Moq;
using WebAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITesting.RepositoriesTests
{
    public class PetRepoTests
    {
        private readonly Mock<WebAPI.Entities.petinsuranceContext> _context;

        public PetRepoTests()
        {
            _context = new Mock<WebAPI.Entities.petinsuranceContext>();
        }

        Pet testPet = new()
        {
            Breed = "Crested Gecko",
            Age = 5,
            Location = "Hawaii",
            InsurancePlan = "Gold",
            InsuranceMonthly = "Gold",
            UserId = 5,
        };

        /// <summary>
        /// Tests AddPet to check if result is type Task
        /// </summary>

        [Fact]
        public void AddPet_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.AddPet(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests DeletePetAsync to check if result is type Task
        /// </summary>

        [Fact]
        public void DeletePetAsync_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.DeletePetAsync(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests GetPetById to check if result is type Task
        /// </summary>

        [Fact]
        public void GetPetById_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.GetPetById(testPet.Id);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests UpdatePet to check if result is type Task
        /// </summary>

        [Fact]
        public void UpdatePet_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.UpdatePet(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests CheckQualification to check if result is type Task
        /// </summary>

        [Fact]
        public void CheckQualifications_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.CheckQualification(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests DeletePet to check if result is type Task
        /// </summary>

        [Fact]
        public void DeletePet_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.DeletePet(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests GetQuote to check if result is type Task
        /// </summary>

        [Fact]
        public void GetQuote_TestIfType_Task()
        {

            var _petRepo = new PetRepository(_context.Object);
            var result = _petRepo.GetQuote(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

    }
}

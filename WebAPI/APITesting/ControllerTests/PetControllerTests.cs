using Xunit;
using WebAPI.Repositories;
using Moq;
using WebAPI.Models;
using System.Threading.Tasks;
using WebAPI.Repositories.Interfaces;
using WebAPI.Controllers;
using System.Collections.Generic;

namespace APITesting.RepositoriesTests
{
    public class PetControllerTests
    {
        private readonly Mock<IPet> _repo;
        private readonly PetsController _controller;
        public PetControllerTests()
        {
            _repo = new Mock<IPet>();
            _controller = new PetsController(_repo.Object);
        }

        Pet testPet = new()
        {
            Breed = "Crested Gecko",
            Age = 5,
            Location = "Hawaii",
            InsurancePlan = "Gold",
            InsuranceMonthly = "Gold",
            UserId = 1,
        };

        User testUser = new()
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "McTest",
            UserName = "BobTheTester",
            Password = "CanWeTestIt",
            DoB = "1999/12/07",
            Location = "Hawaii",
            PhoneNumber = "2101024321",
            Email = "BobTheTester@aol.com",
        };

        /// <summary>
        /// Tests GetPets to check if result is type Task
        /// </summary>

        [Fact]
        public void GetPets_TestIfType_Task()
        {

            var _petsController = new PetsController(_repo.Object);
            var result = _petsController.GetPets(testUser.Id);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests PutPet to check if result is type Task
        /// </summary>

        [Fact]
        public void PutPets_TestIfType_Task()
        {

            var _petsController = new PetsController(_repo.Object);
            var result = _petsController.PutPet(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests PostPet to check if result is type Task
        /// </summary>

        [Fact]
        public void PostPet_TestIfType_Task()
        {

            var _petsController = new PetsController(_repo.Object);
            var result = _petsController.PostPet(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests QuotePets to check if result is type Task
        /// </summary>

        [Fact]
        public void QuotePets_TestIfType_Task()
        {
            List<Pet> petList = new List<Pet>()
            {

                new Pet(){ Id=1, Age=5, Breed="Bearded Dragon", InsuranceMonthly="Gold", InsurancePlan="Gold", Location="Hawaii", UserId=1},
                new Pet(){ Id=2, Age=9, Breed="Mountain Horned Dragon", InsuranceMonthly="Gold", InsurancePlan="Gold", Location="Hawaii", UserId=1},
                new Pet(){ Id=2, Age=10, Breed="Green Basilisk", InsuranceMonthly="Gold", InsurancePlan="Gold", Location="Hawaii", UserId=1}
            };
            var _petsController = new PetsController(_repo.Object);
            var result = _petsController.QuotePets(petList);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests DeletePet to check if result is type Task
        /// </summary>

        [Fact]
        public void DeletePet_TestIfType_Task()
        {

            var _petsController = new PetsController(_repo.Object);
            var result = _petsController.DeletePet(testPet);

            Assert.IsAssignableFrom<Task>(result);
        }

    }
}

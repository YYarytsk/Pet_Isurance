using Xunit;
using WebAPI.Controllers;
using Moq;
using System.Threading.Tasks;
using WebAPI.Repositories.Interfaces;
using System;
using WebAPI.Models;

namespace APITesting.ControllerTests
{
    public class UserControllerTests
    {
        private readonly Mock<IUser> _repo;
        private readonly UsersController _controller;
        private readonly Mock<LoginRequest> _loginRequest;

        public UserControllerTests()
        {
            _repo = new Mock<IUser>();
            _loginRequest = new Mock<LoginRequest>();
            _controller = new UsersController(_repo.Object);
        }

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
        /// Tests GetUser to check if result is type Task
        /// </summary>

        [Fact]
        public void GetUser_TestIfType_Task()
        {
            var result = _controller.GetUser(1);

            Assert.IsAssignableFrom<Task>(result);

        }

        /// <summary>
        /// Tests PostUser to check if result is type Task
        /// </summary>

        [Fact]
        public void PostUser_TestIfType_Task()
        {
            var result = _controller.PostUser(testUser);

            Assert.IsAssignableFrom<Task>(result);

        }

        /// <summary>
        /// Tests Login to check if result is type Task
        /// </summary>

        [Fact]
        public void LoginUser_TestIfType_Task()
        {
            var result = _controller.Login(_loginRequest.Object);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests Create to check if result is type Task
        /// </summary>

        [Fact]
        public void CreateUser_TestIfType_Task()
        {
            var result = _controller.Create(testUser);

            Assert.IsAssignableFrom<Task>(result);
        }

    }
}
using Xunit;
using WebAPI.Repositories;
using Moq;
using WebAPI.Models;
using System.Threading.Tasks;

namespace APITesting.RepositoriesTests
{
    public class UserRepoTests
    {
        private readonly Mock<WebAPI.Entities.petinsuranceContext> _context;
        private readonly Mock<LoginRequest> _loginRequest;

        public UserRepoTests()
        {
            _loginRequest = new Mock<LoginRequest>();
            _context = new Mock<WebAPI.Entities.petinsuranceContext>();
        }


        User testUser = new()
        {
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
        /// Tests AddUser to check if result is type Task
        /// </summary>

        [Fact]
        public void AddUser_TestIfType_Task()
        {

            var _userRepo = new UserRepository(_context.Object);
            var result = _userRepo.AddUser(testUser as User);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests CheckUserCreds to check if result is type Task
        /// </summary>

        [Fact]
        public void CheckUserCreds_TestIfType_Task()
        {

            var _userRepo = new UserRepository(_context.Object);
            var result = _userRepo.CheckUserCreds(_loginRequest.Object);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests GetUserByUsername to check if result is type Task
        /// </summary>

        [Fact]
        public void GetUserByUsername_TestIfType_Task()
        {

            var _userRepo = new UserRepository(_context.Object);
            var result = _userRepo.GetUserByUsername(testUser.UserName);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests DeleteUser to check if result is type Task
        /// </summary>

        [Fact]
        public void DeleteUser_TestIfType_Task()
        {

            var _userRepo = new UserRepository(_context.Object);
            var result = _userRepo.DeleteUser(testUser);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests GetUserByEmail to check if result is type Task
        /// </summary>

        [Fact]
        public void GetUserByEmail_TestIfType_Task()
        {

            var _userRepo = new UserRepository(_context.Object);
            var result = _userRepo.GetUserByEmail(testUser.Email);

            Assert.IsAssignableFrom<Task>(result);
        }

        /// <summary>
        /// Tests GetUserByUsername to check if result is type Task
        /// </summary>

        [Fact]
        public void GetUserById_TestIfType_Task()
        {

            var _userRepo = new UserRepository(_context.Object);
            var result = _userRepo.GetUserById(testUser.Id);

            Assert.IsAssignableFrom<Task>(result);
        }

    }
}
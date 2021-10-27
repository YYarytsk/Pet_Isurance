using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserRepository : IUser
    {
        private readonly Entities.petinsuranceContext _context;
        public UserRepository(Entities.petinsuranceContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            if (await GetUserByEmail(user.Email) == null && await GetUserByUsername(user.UserName) == null)
            {
                await _context.Users.AddAsync(
                new Entities.User
                {

                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = user.Password,
                    DoB = user.DoB,
                    Location = user.Location,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                });
                await _context.SaveChangesAsync();
                User newUser = await GetUserByEmail(user.Email);
                return newUser;
            }
            else return null;
        }

        /// <summary>
        /// Could use some refactoring, Right now it checks both username and password, not realistic for a login
        /// </summary>
        /// <param name="attempt"></param>
        /// <returns></returns>
        public async Task<User> CheckUserCreds(LoginRequest attempt)
        {
            if(!attempt.Email.Contains('@'))
            {
                attempt.UserName = attempt.Email;
            }
            try
            {
                if(attempt.Email.Contains('@'))
                {
                    User user = await GetUserByEmail(attempt.Email);
                    if (user != null)
                    {
                        if (user.Email == attempt.Email && user.Password == attempt.Password)
                        {
                            User foundUser = new User(user.Id, user.FirstName, user.LastName, user.UserName, user.Password, user.DoB, user.Location, user.PhoneNumber, user.Email);
                            return foundUser;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                User user = await GetUserByUsername(attempt.Email);
                if (user != null)
                {
                    if (user.UserName == attempt.UserName && user.Password == attempt.Password)
                    {
                        User foundUser = new User(user.Id, user.FirstName, user.LastName, user.UserName, user.Password, user.DoB, user.Location, user.PhoneNumber, user.Email);
                        return foundUser;
                    }

                }
            }
            catch
            {

            }
            return null;
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            var search = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (search != null)
            {
                User newUser = new User(search.Id, search.FirstName, search.LastName, search.UserName, search.Password, search.DoB, search.Location, search.PhoneNumber, search.Email);
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> DeleteUser(User user)
        {

            var search = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Id == user.Id);
            if(search == null)
            {
                return "User not found";
            }
            _context.Remove(search);
            await _context.SaveChangesAsync();
            return "User has been deleted";

        }
        public async Task<User> GetUserByEmail(string email)
        {
            var search = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (search != null)
            {
                User newUser = new User(search.Id, search.FirstName, search.LastName, search.UserName, search.Password, search.DoB, search.Location, search.PhoneNumber, search.Email);
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            var found = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            User user = new User(found.Id, found.FirstName, found.LastName, found.UserName, found.Password, found.DoB, found.Location, found.PhoneNumber, found.Email);
            return user;
        }
    }
}

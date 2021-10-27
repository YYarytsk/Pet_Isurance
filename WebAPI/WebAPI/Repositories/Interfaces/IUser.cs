using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUser
    {
        Task<User> AddUser(User user);
        Task<string> DeleteUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByUsername(string userName);

        //User UpdateUser(User user);     might not need.



        // this has to do with logging in
        Task<User> CheckUserCreds(LoginRequest attempt);




    }
}

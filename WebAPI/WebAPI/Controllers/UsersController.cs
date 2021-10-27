using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _repo;

        public UsersController(IUser repo)
        {
            _repo = repo;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with id of {id} not found");
            }

            return Ok(user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _repo.AddUser(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(LoginRequest user)
        {
            User findUser = await _repo.CheckUserCreds(user);
            if(findUser != null)
            {
                return Ok(findUser);
            }
            return BadRequest("User not found");
        }
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Create(User user)
        {
            User newUser = await _repo.AddUser(user);
            if(newUser != null)
            {
                return Ok(newUser);
            }
            return BadRequest("Something went wrong");
        }

    }
}

using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController
    {
        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            return await GetUsers();
        }

        [HttpGet("{id}", Name = "GetByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            return await GetById(id);
        }

        private static async Task<User> GetById(int id)
        {
            List<User> users = await GetUsers();
            return users.Find(x => x.ID == id);
        }

        private static Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User() { ID = 1, Name = "Sam", Age = 19, Location = "Seatte" });
            users.Add(new User() { ID = 2, Name = "Tom", Age = 19, Location = "Seatte" });
            users.Add(new User() { ID = 3, Name = "Bob", Age = 19, Location = "Seatte" });
            users.Add(new User() { ID = 4, Name = "Rack", Age = 19, Location = "Seatte" });
            users.Add(new User() { ID = 5, Name = "Rock", Age = 19, Location = "Seatte" });
            users.Add(new User() { ID = 6, Name = "Jacob", Age = 19, Location = "Seatte" });
            return Task.FromResult(users);
        }
    }
}

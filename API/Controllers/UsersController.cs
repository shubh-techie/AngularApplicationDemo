using DatingApp.Api.Entities;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController
    {
        private readonly IDataBaseService _dataBaseService;
        public UsersController(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAsync()
        {
            return await this._dataBaseService.GetAllAsync();
        }

        [HttpGet("{id}", Name = "GetByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppUser>> GetAsync(int id)
        {
            return await this._dataBaseService.GetByIdAsync(id);
        }

        //private static async Task<AppUser> GetById(int id)
        //{
        //    List<AppUser> users = await GetUsers();
        //    return users.Find(x => x.Id == id);
        //}

        //private static Task<List<AppUser>> GetUsers()
        //{
        //    var users = new List<AppUser>
        //    {
        //        new AppUser() { Id = 1, FirstName = "Sam", LastName="smith",  UserName="SamHello" },
        //        new AppUser() { Id = 2, FirstName = "Tom", LastName="smith", UserName="SamHello" },
        //        new AppUser() { Id = 3, FirstName = "Bob", LastName="smith", UserName="SamHello" },
        //        new AppUser() { Id = 4, FirstName = "Rack",LastName="smith",  UserName="SamHello" },
        //        new AppUser() { Id = 5, FirstName = "Rock", LastName="smith", UserName="SamHello" },
        //        new AppUser() { Id = 6, FirstName = "Jacob", LastName="smith", UserName="SamHello" }
        //    };
        //    return Task.FromResult(users);
        //}
    }
}

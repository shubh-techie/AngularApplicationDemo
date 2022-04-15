using DatingApp.Api.Contracts;
using DatingApp.Api.Entities;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UsersController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetUsersAsync()
        {
            return await this._userAccountService.GetAllAsync();
        }

        [HttpGet("all", Name = "GetUsersDetails")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersDetailsAsync()
        {
            return await this._userAccountService.GetUserDetails();
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserInfoDto>> GetUserAsync(int id)
        {
            return await this._userAccountService.GetByIdAsync(id);
        }

    }
}

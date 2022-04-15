using DatingApp.Api.Contracts;
using DatingApp.Api.Entities;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatingApp.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserAccountService _dataBaseContext;

        public AccountController(IUserAccountService dataBaseService)
        {
            _dataBaseContext = dataBaseService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            return await this._dataBaseContext.Register(registerDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            return await this._dataBaseContext.Login(loginDto);
        }
    }
}

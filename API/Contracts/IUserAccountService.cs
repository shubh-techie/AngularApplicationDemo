using DatingApp.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Contracts
{
    public interface IUserAccountService
    {
        Task<ActionResult<IEnumerable<UserInfoDto>>> GetAllAsync();
        Task<ActionResult<IEnumerable<AppUser>>> GetUserDetails();
        Task<ActionResult<UserInfoDto>> GetByIdAsync(int id);
        Task<ActionResult<UserDto>> Register(RegisterDto registerDto);
        Task<ActionResult<UserDto>> Login(LoginDto loginDto);
    }
}

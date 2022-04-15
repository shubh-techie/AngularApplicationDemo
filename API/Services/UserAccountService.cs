using AutoMapper;
using DatingApp.Api.Contracts;
using DatingApp.Api.Entities;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace DatingApp.Api.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public ITokenService TokenService { get; }

        public UserAccountService(DataContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            this._mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetAllAsync()
        {
            var allusers = await this._context.Users.ToListAsync();
            return _mapper.Map<List<UserInfoDto>>(allusers);
        }

        public async Task<ActionResult<IEnumerable<AppUser>>> GetUserDetails()
        {
            return await this._context.Users.ToListAsync();
        }

        public async Task<ActionResult<UserInfoDto>> GetByIdAsync(int id)
        {
            var user = await this._context.Users.FindAsync(id);
            return this._mapper.Map<UserInfoDto>(user);
        }

        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await this._context.Users
                .SingleOrDefaultAsync(x => x.UserName.ToLower() == loginDto.UserName.ToLower());
            if (user == null)
                return new UnauthorizedObjectResult("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return new UnauthorizedObjectResult("Invalid password");
            }

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();
            if (await UserExists(registerDto.UserName))
                return new BadRequestObjectResult("username is taken");

            var user = new AppUser()
            {
                UserName = registerDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            this._context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string userName)
        {
            return await this._context.Users.AnyAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
        }

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

        public async Task<ActionResult<AppUser>> Register(string userName, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser()
            {
                UserName = userName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key

            };

            this._context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}

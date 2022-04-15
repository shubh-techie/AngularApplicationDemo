using DatingApp.Api.Contracts;
using DatingApp.Api.Model;
using DatingApp.Api.Options.JwtTokenKey;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingApp.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IOptionsMonitor<JwtTokenKeyOptions> tokenKey;

        public TokenService(IConfiguration configuration, IOptionsMonitor<JwtTokenKeyOptions> tokenKey)
        {
            this.tokenKey = tokenKey;
            if (tokenKey == null)
                throw new Exception("configuration error.");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.tokenKey.CurrentValue.TokenKey));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

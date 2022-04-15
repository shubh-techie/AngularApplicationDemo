using DatingApp.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Contracts
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

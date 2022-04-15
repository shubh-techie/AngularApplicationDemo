using DatingApp.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Entities
{
    public interface IDataBaseService
    {
        Task<ActionResult<IEnumerable<AppUser>>> GetAllAsync();
        Task<ActionResult<AppUser>> GetByIdAsync(int id);
    }
}

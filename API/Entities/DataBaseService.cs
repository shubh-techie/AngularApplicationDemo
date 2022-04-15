using DatingApp.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Api.Entities
{
    public class DataBaseService : IDataBaseService
    {
        private readonly DataContext context;

        public DataBaseService(DataContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllAsync()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task<ActionResult<AppUser>> GetByIdAsync(int id)
        {
            return await this.context.Users.FindAsync(id);
        }
    }
}

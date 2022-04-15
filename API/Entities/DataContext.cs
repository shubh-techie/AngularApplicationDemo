using DatingApp.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}

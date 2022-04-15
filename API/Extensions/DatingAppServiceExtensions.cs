using DatingApp.Api.Contracts;
using DatingApp.Api.Entities;
using DatingApp.Api.Options.JwtTokenKey;
using DatingApp.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Extensions
{
    public static class DatingAppServiceExtensions
    {
        public static IServiceCollection AddDatingAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            services.Configure<JwtTokenKeyOptions>(configuration.GetSection("JwtTokenKey"));

            services.AddScoped<ITokenService, TokenService>(); // Till http request server
            services.AddScoped<IUserAccountService, UserAccountService>(); // Till application closed
            return services;
        }
    }
}

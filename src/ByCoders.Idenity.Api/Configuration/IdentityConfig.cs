using ByCoders.Core.Identity;
using ByCoders.Idenity.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByCoders.Idenity.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ByCodersDBIdentityContext>(optionsAction: options
                  => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ByCodersDBIdentityContext>()
                .AddDefaultTokenProviders();
            services.AddJWTConfiguration(configuration);
            return services;
        }
    }
}

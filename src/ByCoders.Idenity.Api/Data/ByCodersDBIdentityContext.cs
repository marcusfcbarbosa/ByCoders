using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ByCoders.Idenity.Api.Data
{
    public class ByCodersDBIdentityContext : IdentityDbContext
    {
        public ByCodersDBIdentityContext(DbContextOptions<ByCodersDBIdentityContext> options) : base(options) { }
    }
}
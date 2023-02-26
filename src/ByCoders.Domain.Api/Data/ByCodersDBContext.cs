using ByCoders.Core.Data;
using ByCoders.Core.DomainObjects;
using ByCoders.Domain.Api.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;
using System.Threading.Tasks;

namespace ByCoders.Domain.Api.Data
{
    public class ByCodersDBContext : DbContext, IUnitOfWork
    {
        public ByCodersDBContext(DbContextOptions<ByCodersDBContext> options)
          : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<Titulo> Titulos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<DateAndTime>();
            modelBuilder.Ignore<Cpf>();
            modelBuilder.Ignore<CartaoCredito>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(50)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;//desabilitando delete em cascata

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ByCodersDBContext).Assembly);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}

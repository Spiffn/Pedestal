using Microsoft.EntityFrameworkCore;
using Pedestal.Catalog.Infrastructure.EntityConfigurations;
using Pedestal.Catalog.Models;

namespace Pedestal.Catalog.Infrastructure
{
    public class CatalogContext : DbContext {
        public DbSet<Modeldydoo> Modeldydoos { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModeldydooEntityTypeConfiguration());
        }
    }
}
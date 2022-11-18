using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LexiconMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
                
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<PersonDB> Persons { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Citys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Citys)
                .WithOne(p => p.Country);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Persons)
                .WithOne(p => p.City);
        }
    }
}

using LexiconMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;

namespace LexiconMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<PersonDB> People { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(p => p.Country);

            modelBuilder.Entity<City>()
                .HasMany(c => c.People)
                .WithOne(p => p.City);

            modelBuilder.Entity<PersonDB>()
                .HasMany(p => p.Languages)
                .WithMany(c => c.People);
        }
    }
}

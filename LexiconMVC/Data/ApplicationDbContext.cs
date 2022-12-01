using LexiconMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;

namespace LexiconMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

            //string adminroleid = Guid.NewGuid().ToString();
            //string userroleid = Guid.NewGuid().ToString();
            //string userid = Guid.NewGuid().ToString();

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = adminroleid,
            //    Name = "Admin",
            //    NormalizedName="ADMIN"
            //});
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = userroleid,
            //    Name = "User",
            //    NormalizedName = "User"
            //});

            //PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            //modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            //{
            //    Id = userid,
            //    Email = "goran.holmqvist@gmail.com",
            //    NormalizedEmail = "GORAN.HOLMQVIST@GMAIL.COM",
            //    UserName = "goran.holmqvist@gamil.com",
            //    NormalizedUserName = "GORAN.HOLMQVIST@GMAIL.COM",
            //    FirstName = "Göran",
            //    LastName = "Holmquist",
            //    BirthDate = DateTime.Now,
            //    PasswordHash = hasher.HashPassword(null, "N8nvYdL3BsNiYPL?")
            //});
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId=adminroleid,
            //    UserId=userid
            //});
        }
    }
}

using Microsoft.EntityFrameworkCore;

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

        public DbSet<Person> Persons { get; set; }
    }
}

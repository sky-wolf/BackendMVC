namespace LexiconMVC.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder
                .ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            if(!context.Persons.Any())
            {
                context.AddRange
                    (
                        new Person { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = "Salt lake", PhoneNumber = "+1 498 12 34 56" },
                        new Person { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = "London", PhoneNumber = "+44 159 12 34 56" },
                        new Person { Id = Guid.NewGuid().ToString(), Name = "Peter Hollans", City = "New York", PhoneNumber = "+1 987 12 34 56" },
                        new Person { Id = Guid.NewGuid().ToString(), Name = "Tim Corey", City = "Los Agels", PhoneNumber = "+1 753 12 34 56" }
                    );
            }

            context.SaveChanges();
        }
    }
}

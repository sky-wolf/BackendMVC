namespace LexiconMVC.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder
                .ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();
            if(!context.Countries.Any())
            {
                context.Countries.AddRange(Countries.Select(c => c.Value));
            }
            if(!context.Citys.Any())
            {
                
                context.Citys.AddRange(Citys.Select(c => c.Value));
            }
            if (!context.Persons.Any())
            {
                context.AddRange
                    (
                        new PersonDB { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = Citys["Salt lake"], PhoneNumber = "+1 498 12 34 56" },
                        new PersonDB { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = Citys["London"], PhoneNumber = "+44 159 12 34 56" },
                        new PersonDB { Id = Guid.NewGuid().ToString(), Name = "Peter Hollans", City = Citys["New York"], PhoneNumber = "+1 987 12 34 56" },
                        new PersonDB { Id = Guid.NewGuid().ToString(), Name = "Tim Corey", City = Citys["Los Agels"], PhoneNumber = "+1 753 12 34 56" }
                     );
            }

            if (!context.Languages.Any())
            {
                context.AddRange
                    (
                        new Language {  Name = "English" },
                        new Language {  Name = "Svenska" }
                     );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Country>? countries;
        public static Dictionary<string, Country> Countries
        {
            get {
                if(countries == null)
                {
                    var countList = new Country[]
                    {
                        new Country { Name = "Usa" },
                        new Country { Name = "England" },
                        new Country { Name = "Sweden" }
                    };
                    countries = new Dictionary<string, Country>();
                    foreach(var country in countList)
                    {
                        countries.Add(country.Name, country);
                    }
                }
                return countries;
            }
        }

        private static Dictionary<string, City>? citys;
        public static Dictionary<string, City> Citys
        {
            get
            {
                if (citys == null)
                {
                    var countList = new City[]
                    {
                        new City { Name = "Salt lake", Country = Countries["Usa"] },
                        new City { Name = "Los Angeles", Country = Countries["Usa"] },
                        new City { Name = "New York", Country = Countries["Usa"] },
                        new City { Name = "London", Country = Countries["England"] },
                        new City { Name = "Göteborg", Country = Countries["Sweden"] },
                        new City { Name = "Stockholm", Country = Countries["Sweden"] }
                    };
                    citys = new Dictionary<string, City>();
                    foreach (var city in countList)
                    {
                        citys.Add(city.Name, city);
                    }
                }
                return citys;
            }
        }

        
    }
}

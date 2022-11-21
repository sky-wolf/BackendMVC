namespace LexiconMVC.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public List<PersonDB> People { get; set; } =  new List<PersonDB>();
        public List<Language> Languages { get; set; } = new List<Language>();


    }
}

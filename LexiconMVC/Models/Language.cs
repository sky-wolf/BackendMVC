namespace LexiconMVC.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonDB> Person { get; set; }
    }
}

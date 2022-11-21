using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class PersonDB
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public City City { get; set; }
        public List<Language> Languages { get; set; }
    }
}

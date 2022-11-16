using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string City { get; set; }

    }
}

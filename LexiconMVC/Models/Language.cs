using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonDB> People { get; set; }
    }
}

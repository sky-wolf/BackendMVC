using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}

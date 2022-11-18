using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class CityViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}

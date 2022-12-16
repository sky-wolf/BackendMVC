using LexiconMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class ReactCreateCityViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int Country { get; set; }
    }
}

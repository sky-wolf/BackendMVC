using LexiconMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class CreatePresonViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}

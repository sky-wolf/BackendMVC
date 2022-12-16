using LexiconMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class ReactCreateCountryyViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class ReactPersonListViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;


    }
}

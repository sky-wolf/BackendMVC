using LexiconMVC.Models;

namespace LexiconMVC.ViewModels
{
    public class PeopleViewModel
    {
        public static List<Person> listOfPeople = new List<Person>();
        public List<Person> tempListe = new List<Person>();
        public static void SkapaLista()
        {
            listOfPeople.Clear();

            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = "Salt lake" });
            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = "London" });
            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Peter Hollans", City = "New York" });
            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Tim Corey", City = "Los Agels" });

        }

        public CreatePresonViewModel CreatePresonViewModel { get; set; }


    }
}

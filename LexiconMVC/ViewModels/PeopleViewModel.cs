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

            listOfPeople.Add(new Person { Id = "1"/*Guid.NewGuid().ToString()*/, Name = "Rykel Bennet", City = "Salt lake", PhoneNumber = "+1 498 12 34 56" });
            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Rykel Bennet", City = "London", PhoneNumber = "+44 159 12 34 56" });
            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Peter Hollans", City = "New York", PhoneNumber = "+1 987 12 34 56" });
            listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "Tim Corey", City = "Los Agels", PhoneNumber = "+1 753 12 34 56" });

        }

        public CreatePresonViewModel CreatePresonViewModel { get; set; }


    }
}

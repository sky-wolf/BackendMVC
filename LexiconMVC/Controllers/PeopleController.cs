using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {
       public PeopleController()
        {
            if(PeopleViewModel.listOfPeople.Count == 0)
            {
                PeopleViewModel.SkapaLista();
            }
        }

        public IActionResult Index(string searchString)
        {

            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.tempListe = PeopleViewModel.listOfPeople;

            var list = PeopleViewModel.listOfPeople;


            if (!String.IsNullOrEmpty(searchString))
            {
                var resultat = list.Where(p => p.Name.Contains(searchString)).ToList();
                if(resultat.Count == 0)
                {
                    resultat = list.Where(p => p.City.Contains(searchString)).ToList();
                }
                
                peopleViewModel.tempListe = resultat;

            }
            else
            {
                peopleViewModel.tempListe = PeopleViewModel.listOfPeople;
            }
            return View(peopleViewModel);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePresonViewModel createPresonViewModel)
        {

            if (ModelState.IsValid)
            {
                var id = PeopleViewModel.listOfPeople.Count;
                PeopleViewModel.listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = createPresonViewModel.City });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var resultat = PeopleViewModel.listOfPeople.FirstOrDefault(p => p.Id == id);
            if (resultat != null)
            {
                PeopleViewModel.listOfPeople.Remove(resultat);
            }
            
            return RedirectToAction("Index");
        }
    }
}

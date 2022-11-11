using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            return View();
            //PeopleViewModel peopleViewModel = new PeopleViewModel();
            //peopleViewModel.tempListe = PeopleViewModel.listOfPeople;

            //var list = PeopleViewModel.listOfPeople;


            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    var resultat = list.Where(p => p.Name.Contains(searchString)).ToList();
            //    if (resultat.Count == 0)
            //    {
            //        resultat = list.Where(p => p.City.Contains(searchString)).ToList();
            //    }

            //    peopleViewModel.tempListe = resultat;

            //}
            //else
            //{
            //    peopleViewModel.tempListe = PeopleViewModel.listOfPeople;
            //}
            //return View(peopleViewModel);
        }


        [HttpPost]
        public IActionResult Create(CreatePresonViewModel createPresonViewModel)
        {

            if (ModelState.IsValid)
            {
                PeopleViewModel.listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = createPresonViewModel.City, PhoneNumber = createPresonViewModel.PhoneNumber });
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var resultat = PeopleViewModel.listOfPeople.FirstOrDefault(p => p.Id == id);
            if (resultat != null)
            {
                PeopleViewModel.listOfPeople.Remove(resultat);
            }
            
            return StatusCode(StatusCodes.Status204NoContent);
        }

        public IActionResult GetPeople()
        {
           
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.tempListe = PeopleViewModel.listOfPeople;
           
            
            return PartialView("_peoplePartial", peopleViewModel.tempListe);
        }

        public IActionResult GetDetails(string id)
        {
            Person person = PeopleViewModel.listOfPeople.FirstOrDefault(p => p.Id == id);
            return PartialView("_personPartial",person);
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            
            PeopleViewModel peopleViewModel = new PeopleViewModel();
          

            var list = PeopleViewModel.listOfPeople;


            if (!String.IsNullOrEmpty(searchString))
            {
                var resultat = list.Where(p => p.Name.Contains(searchString)).ToList();
                if (resultat.Count == 0)
                {
                    resultat = list.Where(p => p.City.Contains(searchString)).ToList();
                }

                peopleViewModel.tempListe = resultat;

            }
            else
            {
                peopleViewModel.tempListe = PeopleViewModel.listOfPeople;
            }
            //return View(peopleViewModel);
            return PartialView("_peoplePartial", peopleViewModel.tempListe);
        }
    }
}

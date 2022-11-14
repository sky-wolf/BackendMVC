using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace LexiconMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PeopleController(ApplicationDbContext applicationDbContext)
        {
            //if (PeopleViewModel.listOfPeople.Count == 0)
            //{
            //    PeopleViewModel.SkapaLista();
            //}
            _applicationDbContext = applicationDbContext;
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
                //PeopleViewModel.listOfPeople.Add(new Person { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = createPresonViewModel.City, PhoneNumber = createPresonViewModel.PhoneNumber });
                _applicationDbContext.Add(new Person { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = createPresonViewModel.City, PhoneNumber = createPresonViewModel.PhoneNumber });
                _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            Person person = _applicationDbContext.Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                //PeopleViewModel.listOfPeople.Remove(person);
                _applicationDbContext.Persons.Remove(person);
                _applicationDbContext.SaveChanges();
            }
            person = _applicationDbContext.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }
            
        }

        public IActionResult GetPeople()
        {
           
            //PeopleViewModel peopleViewModel = new PeopleViewModel();
            //peopleViewModel.tempListe = PeopleViewModel.listOfPeople;
            List<Person> person = _applicationDbContext.Persons.ToList();
            //_applicationDbContext
            
            return PartialView("_peoplePartial", person);
        }

        public IActionResult GetDetails(string id)
        {
            Person person = _applicationDbContext.Persons.FirstOrDefault(p => p.Id == id); /*PeopleViewModel.listOfPeople.FirstOrDefault(p => p.Id == id);*/
            return PartialView("_personPartial",person);
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {

            //PeopleViewModel peopleViewModel = new PeopleViewModel();


            //var list = PeopleViewModel.listOfPeople;

            List<Person> person;
            if (!String.IsNullOrEmpty(searchString))
            {
                person = (from p in _applicationDbContext.Persons.Where(p => p.Name.Contains(searchString)) select p).ToList();

                //person = _applicationDbContext.Persons.Where(p => p.Name.Contains(searchString)).ToList();
                if (person.Count == 0)
                {
                    //person = _applicationDbContext.Persons.Where(p => p.City.Contains(searchString)).ToList();
                    person = (from p in _applicationDbContext.Persons.Where(p => p.City.Contains(searchString)) select p).ToList();
                }

                //peopleViewModel.tempListe = resultat;

            }
            else
            {
                person = _applicationDbContext.Persons.ToList();
            }
            //return View(peopleViewModel);
            return PartialView("_peoplePartial", person);
        }
    }
}

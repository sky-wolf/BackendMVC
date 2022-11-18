using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Controllers
{
    public class PeopleDBController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PeopleDBController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Test = _applicationDbContext.Citys.ToList();
            ViewBag.City = new SelectList(_applicationDbContext.Citys, "Id", "Name");
            return View();

        }


        [HttpPost]
        public IActionResult Create(CreatePresonDBViewModel createPresonViewModel)
        {
            //ModelState.Remove("City");
            if (ModelState.IsValid)
            {
                var city = _applicationDbContext.Citys.FirstOrDefault(c => c.Id == createPresonViewModel.City);

                city.Persons.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = city, PhoneNumber = createPresonViewModel.PhoneNumber });
               //_applicationDbContext.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = createPresonViewModel.City, PhoneNumber = createPresonViewModel.PhoneNumber });
               _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        //[HttpPost]
        //public ActionResult Delete(string id)
        //{
        //    PersonDB person = _applicationDbContext.Persons.FirstOrDefault(p => p.Id == id);
        //    if (person != null)
        //    {
        //        _applicationDbContext.Persons.Remove(person);
        //        _applicationDbContext.SaveChanges();
        //    }
        //    person = _applicationDbContext.Persons.FirstOrDefault(p => p.Id == id);
        //    if (person == null)
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status422UnprocessableEntity);
        //    }

        //}

        public IActionResult GetPeople()
        {
        
            List<PersonDB> person = _applicationDbContext.Persons.ToList();

            return PartialView("_peopleDBPartial", person);
        }

        //public IActionResult GetDetails(string id)
        //{
        //    PersonDB person = _applicationDbContext.Persons.FirstOrDefault(p => p.Id == id);
        //    return PartialView("_personDBPartial", person);
        //}

        //[HttpPost]
        //public IActionResult Search(string searchString)
        //{

        //    List<PersonDB> person;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        person = (from p in _applicationDbContext.Persons.Where(p => p.Name.Contains(searchString)) select p).ToList();

                
        //        if (person.Count == 0)
        //        {
                    
        //            person = (from p in _applicationDbContext.Persons.Where(p => p.City.Contains(searchString)) select p).ToList();
        //        }


        //    }
        //    else
        //    {
        //        person = _applicationDbContext.Persons.ToList();
        //    }

        //    return PartialView("_peopleDBPartial", person);
        //}
    }
}

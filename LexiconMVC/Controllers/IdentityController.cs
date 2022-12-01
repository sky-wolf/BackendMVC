using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Controllers
{
    [Authorize]
    public class IdentityController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IdentityController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Test = _applicationDbContext.Cities.ToList();
            ViewBag.City = new SelectList(_applicationDbContext.Cities, "Id", "Name");
            return View();

        }

        [HttpPost]
        public IActionResult Create(CreatePresonDBViewModel createPresonViewModel, int id)
        {
            ModelState.Remove("City");
            if (ModelState.IsValid)
            {
                var city = _applicationDbContext.Cities.FirstOrDefault(c => c.Id == id);

                //city.People.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = city, PhoneNumber = createPresonViewModel.PhoneNumber });
                _applicationDbContext.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = city, PhoneNumber = createPresonViewModel.PhoneNumber });
                _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public ActionResult Delete(string id)
        {
            PersonDB person = _applicationDbContext.People.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _applicationDbContext.People.Remove(person);
                _applicationDbContext.SaveChanges();
            }
            person = _applicationDbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

        }

        public IActionResult GetPeople()
        {

            List<PersonDB> person = _applicationDbContext.People.Include(x => x.City).ToList();

            return PartialView("_peopleDBPartial", person);
        }

        public IActionResult GetDetails(string id)
        {
            PersonDB person = _applicationDbContext.People.Include(x => x.City).FirstOrDefault(p => p.Id == id);
            return PartialView("_personDBPartial", person);
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {

            List<PersonDB> person;
            if (!String.IsNullOrEmpty(searchString))
            {
                person = (from p in _applicationDbContext.People.Include(x => x.City).Where(p => p.Name.Contains(searchString)) select p).ToList();


                if (person.Count == 0)
                {

                    person = (from p in _applicationDbContext.People.Include(x => x.City).Where(p => p.City.Name.Contains(searchString)) select p).ToList();
                }


            }
            else
            {
                person = _applicationDbContext.People.ToList();
            }

            return PartialView("_peopleDBPartial", person);
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Test = _applicationDbContext.Cities.ToList();
            PersonDB person = _applicationDbContext.People.Include(x => x.City).FirstOrDefault(p => p.Id == id);
            ViewBag.City = new SelectList(_applicationDbContext.Cities, "Id", "Name");
            return PartialView("_personEditPartial", person);
        }

        [HttpPost]
        public IActionResult Update(EditPresonDBViewModel editPresonViewModel)
        {
            if (ModelState.IsValid)
            {
                var city = _applicationDbContext.Cities.FirstOrDefault(c => c.Id == editPresonViewModel.City);
                PersonDB person = new PersonDB
                {
                    Id = editPresonViewModel.Id,
                    Name = editPresonViewModel.Name,
                    PhoneNumber = editPresonViewModel.PhoneNumber,
                    City = city,
                };
                //city.People.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = city, PhoneNumber = createPresonViewModel.PhoneNumber });
                //_applicationDbContext.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = city, PhoneNumber = createPresonViewModel.PhoneNumber });
                _applicationDbContext.Update(person);
                _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}

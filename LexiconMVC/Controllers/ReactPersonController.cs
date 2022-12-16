using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactPersonController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReactPersonController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public List<ReactPersonListViewModel> GetPersonList()
        {
            List<ReactPersonListViewModel> people = new List<ReactPersonListViewModel>();
            List<PersonDB> temp = _applicationDbContext.People.Include(x => x.City).ToList();

            foreach (PersonDB person in temp)
            {
                people.Add(new ReactPersonListViewModel { Id = person.Id, Name = person.Name, City = person.City.Name, PhoneNumber = person.PhoneNumber });
            }

            return people;
        }

        [HttpGet("{id}")]
        public List<ReactPersonListViewModel> GetPersonList(string id)
        {
            List<ReactPersonListViewModel> people = new List<ReactPersonListViewModel>();
            List<PersonDB> temp = _applicationDbContext.People.Include(x => x.City).ToList();

            foreach (PersonDB person in temp)
            {
                people.Add(new ReactPersonListViewModel { Id = person.Id, Name = person.Name, City = person.City.Name, PhoneNumber = person.PhoneNumber });
            }

            return people;
        }

        [HttpPost]
        public IActionResult Create(ReactCreatePresonViewModel createPresonViewModel)
        {
            if (ModelState.IsValid)
            {
                var city = _applicationDbContext.Cities.FirstOrDefault(c => c.Id == createPresonViewModel.City);

                _applicationDbContext.Add(new PersonDB { Id = Guid.NewGuid().ToString(), Name = createPresonViewModel.Name, City = city, PhoneNumber = createPresonViewModel.PhoneNumber });
                _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Search(string searchString)
        {
            List<ReactPersonListViewModel> people = new List<ReactPersonListViewModel>();
            

            if (!String.IsNullOrEmpty(searchString))
            {
                List<PersonDB> temp = _applicationDbContext.People.Include(x => x.City).Where(c => c.Name.Contains(searchString)).ToList();
                foreach (PersonDB person in temp)
                {
                    people.Add(new ReactPersonListViewModel { Id = person.Id, Name = person.Name, City = person.City.Name, PhoneNumber = person.PhoneNumber });
                }

                return Ok(people);

            }
            

            return Forbid();
        }

        [HttpDelete]
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

        [Route("[action]")]
        [HttpGet]
        public IActionResult Detaile(string id)
        {
            ReactPersonListViewModel person;
            var temp = _applicationDbContext.People.Include(x => x.City).FirstOrDefault(c => c.Id == id);

            person = new ReactPersonListViewModel { Id = temp.Id, Name = temp.Name, City = temp.City.Name, PhoneNumber = temp.PhoneNumber };
            return Ok(person);

        }
    }
}

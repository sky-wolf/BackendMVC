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
    public class ReactCityController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReactCityController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("{id}")]
        public List<City> GetList(int id)
        {
            List<City> cities = new List<City>();
            //var temp = _applicationDbContext.Cities.ToList();
            var temp = _applicationDbContext.Cities.Include(x => x.Country).Where(c => c.Country.Id == id).ToList();
            //temp = _applicationDbContext.People.Include(x => x.City).
            //    Cities.Include(x => x.Country)Where(p => p.Id == toBeRemoveCountry.Id).ToList();
            foreach (var item in temp)
            {
                cities.Add(new City { Id = item.Id, Name = item.Name });
            }
            
            
            
            return cities;

        }

        [HttpGet]
        public List<City> GetList()
        {
            List<City> city = _applicationDbContext.Cities.ToList();

            return city;
        }

        [HttpPost]
        public IActionResult Create(ReactCreateCityViewModel reactCreateCity)
        {
            if (ModelState.IsValid)
            {
                var country = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == reactCreateCity.Country);

                _applicationDbContext.Add(new City { Name = reactCreateCity.Name, Country = country  });
                _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Search(string searchString)
        {
            List<City> cities = new List<City>();


            if (!String.IsNullOrEmpty(searchString))
            {
                List<City> temp = _applicationDbContext.Cities.Include(x => x.Country).Where(c => c.Name.Contains(searchString)).ToList();
                foreach (var item in temp)
                {
                    cities.Add(new City { Id = item.Id, Name = item.Name });
                }

                return Ok(cities);

            }


            return Forbid();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Detaile(int id)
        {
            ReactCityListViewModel city;
            var temp = _applicationDbContext.Cities.Include(x => x.Country).FirstOrDefault(c => c.Id == id);

            city = new ReactCityListViewModel { Id = temp.Id, Name = temp.Name, Country = temp.Country.Name };
            return Ok(city);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            City city = _applicationDbContext.Cities.FirstOrDefault(c => c.Id == id);

            if (city != null)
            {
                _applicationDbContext.Cities.Remove(city);
                _applicationDbContext.SaveChanges();
            }
            city = _applicationDbContext.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

        }
    }
}
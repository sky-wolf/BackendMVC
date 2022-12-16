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
    public class ReactCountryController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReactCountryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public List<Country> GetList()
        {
            var temp = _applicationDbContext.Countries.ToList();

            return temp;
        }

        [HttpPost]
        public IActionResult Create(ReactCreateCountryyViewModel reactCreateCountryyViewModel)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(new Country { Name = reactCreateCountryyViewModel.Name });
                _applicationDbContext.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Search(string searchString)
        {
            List<Country> citys = new List<Country>();


            if (!String.IsNullOrEmpty(searchString))
            {
                List<Country> temp = _applicationDbContext.Countries.Where(c => c.Name.Contains(searchString)).ToList();
                foreach (var item in temp)
                {
                    citys.Add(new Country { Id = item.Id, Name = item.Name });
                }

                return Ok(citys);

            }


            return Forbid();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Detaile(int id)
        {
            ReactCountryListViewModel country;
      
            var temp = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == id);

            country = new ReactCountryListViewModel { Id = temp.Id, Name = temp.Name};
            return Ok(country);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Country country = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == id);

            if (country != null)
            {
                _applicationDbContext.Countries.Remove(country);
                _applicationDbContext.SaveChanges();
            }
            country = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
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

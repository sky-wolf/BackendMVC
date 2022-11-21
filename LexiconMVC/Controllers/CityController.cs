using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;

namespace LexiconMVC.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CityController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index(int id)
        {
            var country = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == id);
            var city = _applicationDbContext.Cities.Where(x => x.Country.Id == id).ToList();
            ViewBag.Name = country.Name;
            ViewBag.CountryId = country.Id;
            return View(city);
        }

        public IActionResult Create(int id)
        {
            var country = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == id);

            ViewBag.Country = country.Name;

            return View();
        }


        [HttpPost]
        public IActionResult Create(CityViewModel cityViewModel, int id)
        {

            if (ModelState.IsValid)
            {
                var countries = _applicationDbContext.Countries.FirstOrDefault(x => x.Id == id);
                //_applicationDbContext.Add(new City { Name = cityViewModel.Name, Country = countries });
                countries.Cities.Add(new City { Name = cityViewModel.Name, Country = countries });
                _applicationDbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult RemoveCity(int cityid, string id)
        {
            var city = _applicationDbContext.Cities.FirstOrDefault(x => x.Id == cityid);
            

            _applicationDbContext.Cities.Remove(city);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index", new { id = id });

        }
    }
}

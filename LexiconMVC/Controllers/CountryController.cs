using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace LexiconMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CountryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View(_applicationDbContext.Countries.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CountryViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(new Country { Name = countryViewModel.Name });
                _applicationDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
             var country = _applicationDbContext.Countries.Find(id);
            return View(country);
        }


        [HttpPost]
        public IActionResult Update(Country country)
        {
            if (ModelState.IsValid)
            {
                var _country = _applicationDbContext.Countries.FirstOrDefault(c => c.Id == country.Id);
                if (_country != null)
                {
                    _country.Name = country.Name;
                }
                _applicationDbContext.Update(_country);
                _applicationDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var toBeRemoveCountry = _applicationDbContext.Countries.FirstOrDefault(p => p.Id == id);
            var toBeRemoveCity = _applicationDbContext.Cities.Where(p => p.Id == toBeRemoveCountry.Id).ToList();
            if (toBeRemoveCountry != null)
            {
                if (toBeRemoveCity != null)
                {
                    _applicationDbContext.Cities.RemoveRange(toBeRemoveCity);
                }
                _applicationDbContext.Countries.Remove(toBeRemoveCountry);
                _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

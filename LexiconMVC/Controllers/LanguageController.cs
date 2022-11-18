using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LanguageController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var lang = _applicationDbContext.Languages.ToList();
            
            return View(lang);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(LanguageViewModel languageViewModel)
        {

            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(new Language { Name = languageViewModel.Name });
                _applicationDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var lang = _applicationDbContext.Languages.FirstOrDefault(x => x.Id == id);

            _applicationDbContext.Languages.Remove(lang);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Controllers
{
    public class LanguagePeopelController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LanguagePeopelController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index(string id)
        {

            var person = _applicationDbContext.Persons.Include(x => x.Language).FirstOrDefault(x => x.Id == id);

            ViewBag.Name = person.Name;
            ViewBag.PersonId = person.Id;

            return View(person.Language);
        }

        public IActionResult AddLanguageToPerson(string id)
        {
            var person = _applicationDbContext.Persons.FirstOrDefault(x => x.Id == id);

            ViewBag.Person = person.Id;
            ViewBag.Name = person.Name;

            ViewBag.Langs = new SelectList(_applicationDbContext.Languages, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddLanguageToPerson(int language, string id)
        {
            var person = _applicationDbContext.Persons.Include(x => x.Language).FirstOrDefault(x => x.Id == id);
            var lang = _applicationDbContext.Languages.FirstOrDefault(x => x.Id == language);

            if (!person.Language.Any(c => c.Id == lang.Id))
            {
                person.Language.Add(lang);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", new { id = id });
            }
            else
            {
                ViewBag.Person = person.Id;
                ViewBag.Name = person.Name;

                ViewBag.Langs = new SelectList(_applicationDbContext.Languages, "Id", "Name");

                ViewBag.Message = $"You already have this {lang.Name}!";
                return View();
            }

            
        }

        public IActionResult RemoveFromPerson(int langid, string id)
        {
            var person = _applicationDbContext.Persons.Include(x => x.Language).FirstOrDefault(x => x.Id == id);
            var lang = _applicationDbContext.Languages.FirstOrDefault(x => x.Id == langid);

            person.Language.Remove(lang);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index", new { id = id });

        }
    }
}

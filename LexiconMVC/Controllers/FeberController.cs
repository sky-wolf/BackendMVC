using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace LexiconMVC.Controllers
{
    public class FeberController : Controller
    {

        public IActionResult Check()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(int input)
        {

            ViewBag.Temp = Feber.FeberCheck(input);
            return View();
        }
    }
}

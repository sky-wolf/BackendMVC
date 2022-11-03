using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Formats.Asn1.AsnWriter;

namespace LexiconMVC.Controllers
{
    public class GuessingController : Controller
    {
        private readonly IGuessingRepository _guessingRepository;
        
        public GuessingController(IGuessingRepository guessingRepository)
        {
            _guessingRepository = guessingRepository;
        }

        public IActionResult Guess()
        {

            var tal = HttpContext.Session.GetInt32("SessionKeyGuess");
            var generates = _guessingRepository.Generat();

            if(tal == null)
            {
                HttpContext.Session.SetInt32("SessionKeyGuess", generates);
                ViewBag.Generated = "A new Number has been generated so start the guessing game";
            }


            return View();
        }

        [HttpPost]
        public IActionResult Guess(Guessing guessing , int count)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(15);

            count++;

            if (HttpContext.Session.GetInt32("SessionKeyGuess") != 0)
            {
                var tal = HttpContext.Session.GetInt32("SessionKeyGuess");
                var vinn = _guessingRepository.Guess(guessing, (int)tal);

                if(vinn)
                {
                    ViewBag.Vinn = "Winer winer chicken diner";
                    
                    var generates = _guessingRepository.Generat();
                    HttpContext.Session.SetInt32("SessionKeyGuess", generates);
                    ViewBag.Generated = "A new Number has been generated so start the guessing game";

                    var highscore = HttpContext.Request.Cookies["higscore"];
                    if (highscore == null)
                    {
                        HttpContext.Response.Cookies.Append("higscore", Convert.ToString(count), options);
                        ViewBag.Sethighscore = "New High score";
                    }else
                    {
                        var high = Convert.ToInt32(highscore);

                        if (high < count)
                        {
                            HttpContext.Response.Cookies.Append("higscore", Convert.ToString(count), options);
                            ViewBag.Sethighscore = "New High score";
                        }
                    }
                }
                else
                {
                    ViewBag.Count = count;
                    ViewBag.Message = guessing.Massage;
                }
            }
            
            return View();
        }
    }
}

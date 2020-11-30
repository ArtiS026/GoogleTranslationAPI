using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleTranslationAPI.Models;
using GoogleTranslationAPI.Business;


namespace GoogleTranslationAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITranslator _translator;
        public HomeController(ITranslator translator)
        {
            _translator = translator;
        }

        public IActionResult Index()
        {
            ViewData["Language"] = Business.CultureInfoDetail.GetCultureInfo();

            var text = "Translate using Google";
            var translatedText = _translator.TranslateText(text, "fr");
            return View("Translator", translatedText);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using GoogleTranslationAPI.Business;
using GoogleTranslationAPI.Models;
using GoogleTranslationAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoogleTranslationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : Controller
    {
        private readonly ITranslator _translator;
        public TranslatorController(ITranslator translator)
        {
            _translator = translator;
        }


        [HttpGet]
        [Route("Translate")]
        public ActionResult Translate(string text, string language)
        {
            var translatedText = _translator.TranslateText(text, language);
            return Ok(translatedText);
        }
        [HttpGet]
        [Route("TranslateHtml")]
        public ActionResult TranslateHtml(string html, string language)
        {
            var translatedText = _translator.TranslateHtml(html, language);
            return Ok(translatedText);
        }
    }
}

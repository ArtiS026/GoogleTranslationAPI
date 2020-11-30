using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleTranslationAPI.Models;
using GoogleTranslationAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GoogleTranslationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatePhraseController : Controller
    {
        private readonly ITranslateRepository _translationRepository;
        public TranslatePhraseController(ITranslateRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        //CRUD operation
        [HttpGet]
        [Route("~/api/GetTranslator")]
        public async Task<IActionResult> GetTranslator()
        {
            try
            {
                var translation = await _translationRepository.GetTranslator();
                if (translation == null)
                {
                    return NotFound();
                }

                return Ok(translation);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("~/api/AddPhrases")]
        public async Task<IActionResult> AddPhrases([FromBody]Source model)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    var SourceId = await _translationRepository.AddPhrases(model);
                    if (SourceId > 0)
                    {
                        return Ok(SourceId);
                    }
                    else
                    {
                        return NotFound();
                    }
                } 
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("~/api/DeletePhrases")]
        public async Task<IActionResult> DeletePhrases(int? SourceId)
        {
            int result = 0;

            if (SourceId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _translationRepository.DeletePhrases(SourceId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("~/api/UpdatePhrase")]
        public async Task<IActionResult> UpdatePhrase([FromBody]Source model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _translationRepository.UpdatePhrase(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}
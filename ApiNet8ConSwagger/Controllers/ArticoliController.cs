using Microsoft.AspNetCore.Mvc;
using WaCube.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ApiNet8ConSwagger.Services.Interface;
using BaseLibrary.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNet8ConSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoliController : ControllerBase
    {
        public readonly IArticoliRepository articoRepo;
        public ArticoliController(IArticoliRepository artico)
        {
            this.articoRepo = artico;
        }
        // GET: api/<ArticoliController>
        [HttpGet("Tutti")]
        public async Task<IActionResult> GetArticoli()
        {
            return Ok(await articoRepo.GetAll());
        }

        // GET api/<ArticoliController>/5
        [HttpGet("leggiArticolo/{codice}")]
        public async Task<IActionResult> GetArticolo(string codice)
        {
            var articoResult = await articoRepo.GetByCodiceAsync(codice);
            if (articoResult == null)
                return NotFound();

            return Ok(articoResult);
        }
        [HttpGet("Descr/{descrizione}")]
        public async Task<ActionResult<ICollection<Articoli>>> GetDescrizioneArticolo(string descrizione)
        {
            var articoResult = await articoRepo.GEtByDescrizioneAsync(descrizione);
            if (articoResult == null)
                return NotFound();

            return Ok(articoResult);
        }
        // POST api/<ArticoliController>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateArticolo([FromBody] Articoli artico)
        {
            try
            {
                if( !ModelState.IsValid)
                    return BadRequest(ModelState);

                await this.articoRepo.SaveAsync(artico);

                return CreatedAtAction(nameof(GetArticolo), new { codice = artico.ar_codart }, artico);

            }

            catch (Exception e) when (e.InnerException is SqlServerExpression )
            {

                return StatusCode(500, e.Message);
                //return BadRequest(eu.Exception.Message);
            }

            //Controllerò se esiste
        }

        // PUT api/<ArticoliController>/5
        [HttpPut("UpdateArticolo/{codiceArticolo}")]
        public async Task<IActionResult> Put(string codiceArticolo , [FromBody] ArticoloUpdate artico)
        {
            var art = await articoRepo.GetByCodiceAsync(codiceArticolo);

            art.ar_descr = artico.Descrizone;
            await articoRepo.UpdateAsync(art);
            return Ok();
        }

        // DELETE api/<ArticoliController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

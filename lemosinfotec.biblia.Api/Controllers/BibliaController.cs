using lemosinfotec.biblia.Domain.Entities;
using lemosinfotec.biblia.Repository.Inrterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lemosinfotec.biblia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class BibliaController : ControllerBase
    {
        private readonly IBibliaService _bibliaService;

        public BibliaController(IBibliaService bibliaService)
        {
            _bibliaService = bibliaService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Biblia>>> GetBiblia()
        {
            try
            {
                var biblia = await _bibliaService.GetBiblias();
                return Ok(biblia);
            }
            catch (Exception ex)
            {
                //return BadRequest("Request invalida");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:{ex.Message} ");
            }
        }
        [HttpGet ("BibliaPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Biblia>>> GetBibliaByNome([FromQuery] string nome)
        {
            try
            {
                var biblia = await _bibliaService.GetBibliaByNome(nome);
                if(biblia.Count() == 0)
                
                    return NotFound($"Não existem biblia com o criterio {nome}");
                
                return Ok(biblia);
            }
            catch (Exception ex)
            {
                //return BadRequest("Request invalida");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:{ex.Message} ");
            }
        }

        [HttpGet("{Id:int}",Name ="GetBiblia")]
        public async Task<ActionResult<IAsyncEnumerable<Biblia>>> GetBiblia(int Id)
        {
            try
            {
                var biblia = await _bibliaService.GetBiblia(Id);
                if (biblia == null)

                    return NotFound($"Não existem biblia com este id {Id}");

                return Ok(biblia);
            }
            catch (Exception ex)
            {
                //return BadRequest("Request invalida");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:{ex.Message} ");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(Biblia biblia)
        {
            try
            {
                await _bibliaService.CreateBiblia(biblia);
                return CreatedAtRoute(nameof(GetBiblia), new { Id = biblia.Id }, biblia);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:{ex.Message} ");
            }
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Editar(int Id,[FromBody] Biblia biblia)
        {
            try
            {
                if(biblia.Id == Id)
                {
                   await _bibliaService.UpdateBiblia(biblia);
                    return Ok($"Biblia atualizada com sucesso {Id}");
                }
                else
                {
                    return BadRequest("Dados nao existe");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:{ex.Message} ");
            }
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var biblia = await _bibliaService.GetBiblia(Id);
                if (biblia != null)
                {
                    await _bibliaService.DeleteBiblia(biblia);
                    return Ok($"Biblia de id={Id} excluido com sucesso!");
                }
                else
                {
                    return NotFound($"Error: id={Id} não encontrado");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:{ex.Message} ");
            }
        }
    }
}

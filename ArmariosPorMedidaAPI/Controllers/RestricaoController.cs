using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ArmariosPorMedidaAPI.Models;


namespace ArmariosPorMedidaAPI.Controllers
{
    [Route("api/Restricao")]
    [ApiController]
    public class RestricaoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public RestricaoController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }


        //GET api/restricao
        [HttpGet]
        public IEnumerable<DTOs.RestricaoDTO> GetRestricao()
        {
            var restricao = from r in _context.Restricoes
                            select new DTOs.RestricaoDTO()
                            {
                                ID = r.RestricaoID,
                                Nome = r.Nome
                            };
            return restricao;
        }

        //GET api/restricao/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestricao([FromRoute] int id)
        {
            var restricao = await _context.Restricoes.Select(r =>
            new DTOs.RestricaoDTO()
            {
                ID = r.RestricaoID,
                Nome = r.Nome
            }).SingleOrDefaultAsync(r => r.ID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(restricao == null)
            {
                return NotFound();
            }

            return Ok(restricao);
        }

        //POST api/restricao
        [HttpPost]
        public async Task<IActionResult> PostRestricao([FromBody] Restricao restricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restricoes.Add(restricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestricao", new { id = restricao.RestricaoID }, restricao);
        }


        //PUT api/restricao/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestricao([FromRoute] int id, [FromBody] Restricao restricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restricao.RestricaoID)
            {
                return BadRequest();
            }

            _context.Entry(restricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!RestricaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE api/restricao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestricao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restricao = await _context.Restricoes.SingleOrDefaultAsync(r => r.RestricaoID == id);
            if (restricao == null)
            {
                return NotFound();
            }

            _context.Restricoes.Remove(restricao);
            await _context.SaveChangesAsync();

            return Ok(restricao);
        }


        //Verifica se restricao com ID id já existe
        private bool RestricaoExists(int id)
        {
            return _context.Restricoes.Any(r => r.RestricaoID == id);
        }

    }
}
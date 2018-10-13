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
    [Route("api/Acabamento")]
    [ApiController]
    public class AcabamentoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public AcabamentoController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }


        //GET api/acabamento
        [HttpGet]
        public IEnumerable<DTOs.AcabamentoDTO> GetAcabamento()
        {
            var acabamento = from r in _context.Acabamentos
                            select new DTOs.AcabamentoDTO()
                            {
                                AcabamentoID = r.AcabamentoID,
                                Nome = r.Nome
                            };
            return acabamento;
        }

        //GET api/acabamento/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcabamento([FromRoute] int id)
        {
            var acabamento = await _context.Acabamentos.Select(r =>
            new DTOs.AcabamentoDTO()
            {
                AcabamentoID = r.AcabamentoID,
                Nome = r.Nome
            }).SingleOrDefaultAsync(r => r.AcabamentoID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(acabamento == null)
            {
                return NotFound();
            }

            return Ok(acabamento);
        }

        //POST api/acabamento
        [HttpPost]
        public async Task<IActionResult> Postacabamento([FromBody] Acabamento acabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Acabamentos.Add(acabamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcabamento", new { id = acabamento.AcabamentoID }, acabamento);
        }


        //PUT api/acabamento/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Putacabamento([FromRoute] int id, [FromBody] Acabamento acabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acabamento.AcabamentoID)
            {
                return BadRequest();
            }

            _context.Entry(acabamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!AcabamentoExists(id))
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

        //DELETE api/acabamento/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcabamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acabamento = await _context.Acabamentos.SingleOrDefaultAsync(r => r.AcabamentoID == id);
            if (acabamento == null)
            {
                return NotFound();
            }

            _context.Acabamentos.Remove(acabamento);
            await _context.SaveChangesAsync();

            return Ok(acabamento);
        }


        //Verifica se acabamento com ID id já existe
        private bool AcabamentoExists(int id)
        {
            return _context.Acabamentos.Any(r => r.AcabamentoID == id);
        }

    }
}
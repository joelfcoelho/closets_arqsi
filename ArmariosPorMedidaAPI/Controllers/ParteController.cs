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
    
    [Route("api/parte")]
    [ApiController]
    public class ParteController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public ParteController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }

        //GET api/parte
        [HttpGet]
        public IEnumerable<DTOs.ParteDTO> GetParte()
        {
            var parte = from p in _context.Partes
                            select new DTOs.ParteDTO()
                            {
                                ID = p.ID,
                                Nome = p.Nome
                            };
            return parte;
        }

        //GET api/parte/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParte([FromRoute] int id)
        {
            var parte = await _context.Partes.Select(p =>
            new DTOs.ParteDTO()
            {
                ID = p.ID,
                Nome = p.Nome
            }).SingleOrDefaultAsync(p => p.ID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(parte == null)
            {
                return NotFound();
            }

            return Ok(parte);
        }

        //POST api/parte
        [HttpPost]
        public async Task<IActionResult> PostParte([FromBody] Parte parte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Partes.Add(parte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParte", new { id = parte.ID }, parte);
        }

        //PUT api/parte/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParte([FromRoute] int id, [FromBody] Parte parte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parte.ID)
            {
                return BadRequest();
            }

            _context.Entry(parte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteExists(id))
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

        //DELETE api/parte/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteparte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parte = await _context.Partes.SingleOrDefaultAsync(p => p.ID == id);
            if (parte == null)
            {
                return NotFound();
            }

            _context.Partes.Remove(parte);
            await _context.SaveChangesAsync();

            return Ok(parte);
        }

        //Verifica se parte com ID id já existe
        private bool ParteExists(int id)
        {
            return _context.Partes.Any(p => p.ID == id);
        }


    }

}

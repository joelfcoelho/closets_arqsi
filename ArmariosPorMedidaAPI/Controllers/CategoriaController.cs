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
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public CategoriaController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }

        
        //GET api/categoria
        [HttpGet]
        public IEnumerable<DTOs.CategoriaDTO> GetCategoria()
        {
            var categoria = from c in _context.Categorias
                            select new DTOs.CategoriaDTO()
                            {
                                CategoriaID = c.CategoriaID,
                                Nome = c.Nome
                            };
            return categoria;
        }

        //GET api/categoria/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            var categoria = await _context.Categorias.Select(c =>
            new DTOs.CategoriaDTO()
            {
                CategoriaID = c.CategoriaID,
                Nome = c.Nome
            }).SingleOrDefaultAsync(c => c.CategoriaID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        //POST api/categoria
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.CategoriaID }, categoria);
        }

        //PUT api/categoria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria([FromRoute] int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.CategoriaID)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        //DELETE api/categoria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Categorias.SingleOrDefaultAsync(c => c.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        //Verifica se a categoria com ID id já existe
        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(c => c.CategoriaID == id);
        }

    }
}
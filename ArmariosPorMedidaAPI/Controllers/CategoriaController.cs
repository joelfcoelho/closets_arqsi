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
                                ID = c.ID,
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
                ID = c.ID,
                Nome = c.Nome
            }).SingleOrDefaultAsync(c => c.ID == id);

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

            return CreatedAtAction("GetCategoria", new { id = categoria.ID }, categoria);
        }

/*
        //GET api/categoria
        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            return _context.Categorias.ToList();
        }

        //GET api/categoria/{id}
        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult<Categoria> GetById(int id)
        {
            var cat = _context.Categorias.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return cat;
        }

        //CREATE
        [HttpPost]
        public IActionResult Create(Categoria cat)
        {
            _context.Categorias.Add(cat);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategoria", new { id = cat.ID }, cat);
        }


        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Categorias.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
*/

    }
}
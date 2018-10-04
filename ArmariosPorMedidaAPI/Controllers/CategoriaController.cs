using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

          /* if (_context.Categorias.Count() == 0)
            {
                //Cria nova categoria
                _context.Categorias.Add(new Categoria { ID = 1 });
                _context.SaveChanges();
            }*/

        }

        //GET api/categoria
        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            return _context.Categorias.ToList();
        }

        //GET api/categoria/{id}
        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult<Categoria> GetById(long id)
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
        public IActionResult Delete(long id)
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

    }
}
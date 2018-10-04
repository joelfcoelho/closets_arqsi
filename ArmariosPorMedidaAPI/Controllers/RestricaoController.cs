using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

           /*if (_context.Restricoes.Count() == 0)
            {
                //Cria nova restricao
                _context.Restricoes.Add(new Restricao { ID=1 });
                _context.SaveChanges();
            }*/

        }

        //GET api/restricao
        [HttpGet]
        public ActionResult<List<Restricao>> GetAll()
        {
            return _context.Restricoes.ToList();
        }

        //GET api/restricao/{id}
        [HttpGet("{id}", Name = "GetRestricao")]
        public ActionResult<Restricao> GetById(long id)
        {
            var rest = _context.Restricoes.Find(id);
            if (rest == null)
            {
                return NotFound();
            }
            return rest;
        }

        //CREATE
        [HttpPost]
        public IActionResult Create(Restricao rest)
        {
            _context.Restricoes.Add(rest);
            _context.SaveChanges();

            return CreatedAtRoute("GetRestricao", new { id = rest.ID }, rest);
        }


        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Restricoes.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Restricoes.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
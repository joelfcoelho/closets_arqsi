using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.Controllers
{
    [Route("api/Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public ProdutoController(ArmariosPorMedidaContext context)
        {
            _context = context;

           if (_context.Produtos.Count() == 0)
            {
                //Cria novo produto
                _context.Produtos.Add(new Produto { Nome = "Produto1" });
                _context.SaveChanges();
            }

        }

        //GET api/produto
        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            return _context.Produtos.ToList();
        }

        //GET api/produto/{id}
        [HttpGet("{id}", Name = "GetProduto")]
        public ActionResult<Produto> GetById(long id)
        {
            var prod = _context.Produtos.Find(id);
            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }

        //CREATE
        [HttpPost]
        public IActionResult Create(Produto prod)
        {
            _context.Produtos.Add(prod);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduto", new { id = prod.ID }, prod);
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(long id, Produto prod)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            //Actualiza nome - acrescentar actualizacoes necessarias
            produto.Nome = prod.Nome;

            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Produtos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
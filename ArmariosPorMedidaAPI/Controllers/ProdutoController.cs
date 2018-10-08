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
    
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public ProdutoController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }


        //GET api/produto
        [HttpGet]
        public IEnumerable<DTOs.ProdutoDTO> GetProduto()
        {
            var produto = from p in _context.Produtos
                            select new DTOs.ProdutoDTO()
                            {
                                ID = p.ID,
                                Nome = p.Nome
                            };
            return produto;
        }

        //GET api/produto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto([FromRoute] int id)
        {
            var produto = await _context.Produtos.Select(p =>
            new DTOs.ProdutoDTO()
            {
                ID = p.ID,
                Nome = p.Nome
            }).SingleOrDefaultAsync(p => p.ID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        //POST api/produto
        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.ID }, produto);
        }

        //PUT api/produto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.ID)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        //DELETE api/produto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ID == id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }


        //GET api/produto/{id}/partes
        [HttpGet("{id}/Partes")]
        public IActionResult GetPartes([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = _context.Produtos.SingleOrDefault(p => p.ID == id);

            if(produto == null)
            {
                return NotFound();
            }

            var listPartes = _context.Produtos.Where<Produto>(l => l.ID == id).Select(p => 
            new DTOs.ProdutoDTO()
            {
                ID = p.ID
            }); ;

            return Ok(listPartes);

        }

        //GET api/produto/{id}/parteem

        //GET api/produto/?nome={nome}
        [HttpGet("nome={nome}")]
        public async Task<IActionResult> GetByNameAsync([FromRoute] string nome){

            var produto = await _context.Produtos.Select(p => 
            new DTOs.ProdutoDTO()
            {
                ID = p.ID,
                Nome = p.Nome
            }).SingleOrDefaultAsync(p => p.Nome == nome);


            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);

        }

        //Verifica se produto com ID id já existe
        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(p => p.ID == id);
        }
        
        /*//GET api/produto/{id}
        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var prod = _context.Produtos.Find(id);
            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }*/

        /*//CREATE
        [HttpPost]
        public IActionResult Create(Produto prod)
        {
            _context.Produtos.Add(prod);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduto", new { id = prod.ID }, prod);
        }*/

        /*//UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Produto prod)
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
        }*/

        /*//DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Produtos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }*/

        
        

/*
         [Route("api/MaterialAcabamento")]
        
        
        //GET api/materialAcabamento/{id}
        [HttpGet("{id}", Name = "GetMaterialAcabamento")]
        public ActionResult<string> GetAcabamentoById(int id)
        {
            var acabamento = _context.Acabamentos.Find(id);
            if (acabamento == null)
            {
                return NotFound();
            }

            var material =_context.Materiais.GetAll;
            var matAcab;
            for(int i=0;i<material.Count;i++){
                if(material[i].acabamento==acabamento){
                    matAcab=material[i];
                }
            }

            string result= "MaterialID="+matAcab.ID +"\nMaterialNome:"+matAcab.nome + "\nAcabamentoID="+ id + "\nNomeAcabamento:"+ acabamento.nome;
            return result;
        }
*/

        

    }
}
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

            /*if (_context.Produtos.Count() == 0)
            {
                
                _context.Acabamentos.Add(new Acabamento() {AcabamentoID=1, Nome="Acabamento1"});
                _context.Materiais.Add(new Material() {MaterialID=1, Nome="Material1"});
                _context.Produtos.Add(new Produto() {ProdutoID=1, Nome="product1", Preco=100, MaterialID=1, AcabamentoID=1 });
                _context.Produtos.Add(new Produto() {ProdutoID=2, Nome="product2" });
                _context.Partes.Add(new Parte() {ParteID=1, Nome="part1", Preco=50 });
                _context.Partes.Add(new Parte() {ParteID=2, Nome="part2", Largura=20 });
                _context.Partes.Add(new Parte() {ParteID=3, Nome="part3", Altura=10, Profundidade=15 });
                _context.ProdutoPartes.Add(new ProdutoParte() {ProdutoID=1, ParteID=1 });
                _context.ProdutoPartes.Add(new ProdutoParte() {ProdutoID=2, ParteID=1 });
                _context.ProdutoPartes.Add(new ProdutoParte() {ProdutoID=1, ParteID=2 });
                _context.ProdutoPartes.Add(new ProdutoParte() {ProdutoID=1, ParteID=3 });
                _context.Restricoes.Add(new Restricao() {RestricaoID=1, Nome="caber"});
                _context.Restricoes.Add(new Restricao() {RestricaoID=2, Nome="caber2"});
                _context.ProdutoRestricoes.Add(new ProdutoRestricao() {ProdutoID=1, RestricaoID=1 });
                _context.ProdutoRestricoes.Add(new ProdutoRestricao() {ProdutoID=1, RestricaoID=2 });
                _context.SaveChanges();
            }*/

        }


        //GET api/produto
        [HttpGet]
        public IEnumerable<DTOs.ProdutoDTO> GetProduto()
        {
            var produto = from p in _context.Produtos
                            select new DTOs.ProdutoDTO()
                            {
                                ProdutoID = p.ProdutoID,
                                Nome = p.Nome,
                                Preco = p.Preco,
                                Altura = p.Altura,
                                Largura = p.Largura,
                                Profundidade = p.Profundidade,
                                //Material = p.Material,
                                //Acabamento = p.Acabamento
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
                ProdutoID = p.ProdutoID,
                Nome = p.Nome,
                Preco = p.Preco,
                Altura = p.Altura,
                Largura = p.Largura,
                Profundidade = p.Profundidade,
                //Material = p.Material,
                //Acabamento = p.Acabamento,
                //Categoria = p.Categoria
            }).SingleOrDefaultAsync(p => p.ProdutoID == id);

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

            return CreatedAtAction("GetProduto", new { id = produto.ProdutoID }, produto);
        }

        //PUT api/produto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.ProdutoID)
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

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoID == id);
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

            Produto produto = _context.Produtos.SingleOrDefault(p => p.ProdutoID == id);

            if(produto == null)
            {
                return NotFound();
            }

            //var parts = _context.ProdutoPartes.Where(p => p.ProdutoID == id).Select(p =>p.Parte).ToList();

            var parts = _context.ProdutoPartes.Where(p => p.ProdutoID == id).Select(p => 
            new DTOs.ParteDTO
            {
                
                ParteID = p.ParteID,
                Nome = p.Parte.Nome,
                Preco = p.Parte.Preco,
                Altura = p.Parte.Altura,
                Largura = p.Parte.Largura,
                Profundidade = p.Parte.Profundidade

            }).ToList();
            

            //var parts = _context.Partes.Where(p => p.ProdutoPartes.Any(pp => pp.ProdutoID == id)).ToList();

                     

            return Ok(parts);

        }

        //GET api/produto/{id}/parteEm
        [HttpGet("{id}/ParteEm")]
        public IActionResult GetPartesEm([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Parte parte = _context.Partes.SingleOrDefault(p => p.ParteID == id);

            if(parte == null)
            {
                return NotFound();
            }

            var parts = _context.ProdutoPartes.Where(p => p.ParteID == id).Select(p =>
            new DTOs.ProdutoDTO
            {
                ProdutoID = p.ProdutoID,
                Nome = p.Produto.Nome,
                Preco = p.Produto.Preco,
                Altura = p.Produto.Altura,
                Largura = p.Produto.Largura,
                Profundidade = p.Produto.Profundidade


            }).ToList();

            return Ok(parts);

        }


        //GET api/produto/{id}/Restricoes
        [HttpGet("{id}/Restricoes")]
        public IActionResult GetRestricoes([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = _context.Produtos.SingleOrDefault(p => p.ProdutoID == id);

            if(produto == null)
            {
                return NotFound();
            }

            var restricoes = _context.ProdutoRestricoes.Where(p => p.ProdutoID == id).Select(p =>
            new DTOs.RestricaoDTO
            {
                RestricaoID = p.RestricaoID,
                Nome = p.Restricao.Nome
            }).ToList();

            return Ok(restricoes);

        }


        //GET api/produto/?nome={nome}
        [HttpGet("nome={nome}")]
        public async Task<IActionResult> GetByNameAsync([FromRoute] string nome){

            
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var produto = await _context.Produtos.Select(p => 
            new DTOs.ProdutoDTO()
            {
                ProdutoID = p.ProdutoID,
                Nome = p.Nome,
                Preco = p.Preco,
                Altura = p.Altura,
                Largura = p.Largura,
                Profundidade = p.Profundidade
            }).SingleOrDefaultAsync(p => p.Nome == nome);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);

        }

        

        //Verifica se produto com ID id já existe
        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(p => p.ProdutoID == id);
        }
        
        
       
        [HttpGet("{id}/Material")]
        public IActionResult GetMaterialAcabamento([FromRoute] int id){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
              Produto produto = _context.Produtos.SingleOrDefault(p => p.ProdutoID == id);

            if(produto == null)
            {
                return NotFound();
            }
            var materialProduto = _context.MaterialProdutos.Where(mp => mp.ProdutoID == produto.ProdutoID).Select(mp =>
            new DTOs.MaterialDTO
            {
                MaterialID = mp.MaterialID
            }).ToList();

            if(materialProduto == null)
            {
                return NotFound();
            }
            return Ok(materialProduto);
        }

        


        

    }
}
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
    
    [Route("api/produto/restricao")]
    [ApiController]

     public class ProdutoRestricaoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public ProdutoRestricaoController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }



        
        [HttpGet]
        public IEnumerable<DTOs.ProdutoRestricaoTO> GetProdutoRestricao()
        {
            var produtorestricao = from p in _context.ProdutoRestricoes
                            select new DTOs.ProdutoRestricaoTO()
                            {
                                ProdutoID = p.ProdutoID,
                                RestricaoID = p.RestricaoID
                            };
            return produtorestricao;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoRestricao([FromRoute] int id)
        {
            var produto = await _context.ProdutoRestricoes.Select(p =>
            new DTOs.ProdutoRestricaoTO()
            {
                ProdutoID = p.ProdutoID,
                RestricaoID = p.RestricaoID
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

        //POST api/produto/restricao
        [HttpPost]
        public async Task<IActionResult> PostProdutoRestricao([FromBody] ProdutoRestricao produtorestricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProdutoRestricoes.Add(produtorestricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoRestricao", new { id = produtorestricao.ProdutoID }, produtorestricao);
        }
    }


}


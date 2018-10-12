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
    
    [Route("api/produtoparte")]
    [ApiController]

     public class ProdutoParteController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public ProdutoParteController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }



        //GET api/produto
        [HttpGet]
        public IEnumerable<DTOs.ProdutoParteDTO> GetProdutoParte()
        {
            var produtoparte = from p in _context.ProdutoPartes
                            select new DTOs.ProdutoParteDTO()
                            {
                                ProdutoID = p.ProdutoID,
                                ParteID = p.ParteID
                            };
            return produtoparte;
        }

        //GET api/produto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoParte([FromRoute] int id)
        {
            var produto = await _context.ProdutoPartes.Select(p =>
            new DTOs.ProdutoParteDTO()
            {
                ProdutoID = p.ProdutoID,
                ParteID = p.ParteID
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
        public async Task<IActionResult> PostProdutoParte([FromBody] ProdutoParte produtoparte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProdutoPartes.Add(produtoparte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoParte", new { id = produtoparte.ProdutoID }, produtoparte);
        }
    }


}


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
    
    [Route("api/produto/material")]
    [ApiController]

     public class MaterialProdutoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public MaterialProdutoController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }



        
        [HttpGet]
        public IEnumerable<DTOs.MaterialProdutoDTO> GetMaterialProduto()
        {
            var materialProduto = from mp in _context.MaterialProdutos
                            select new DTOs.MaterialProdutoDTO()
                            {
                                ProdutoID = mp.ProdutoID,
                                MaterialID = mp.MaterialID
                            };
            return materialProduto;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialProduto([FromRoute] int id)
        {
            var materialProduto = await _context.MaterialProdutos.Select(mp =>
            new DTOs.MaterialProdutoDTO()
            {
                ProdutoID = mp.ProdutoID,
                MaterialID = mp.MaterialID
            }).SingleOrDefaultAsync(mp => mp.ProdutoID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(materialProduto == null)
            {
                return NotFound();
            }

            return Ok(materialProduto);
        }

        //POST api/produto/material
        [HttpPost]
        public async Task<IActionResult> PostMaterialProduto([FromBody] MaterialProduto materialProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MaterialProdutos.Add(materialProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialProduto", new { id = materialProduto.MaterialID }, materialProduto);
        }
    }


}


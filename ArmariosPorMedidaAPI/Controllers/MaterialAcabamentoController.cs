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
    
    [Route("api/material/acabamento")]//ver isto
    [ApiController]

     public class MaterialAcabamentoController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public MaterialAcabamentoController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }



        
        [HttpGet]
        public IEnumerable<DTOs.MaterialAcabamentoDTO> GetMaterialAcamento()
        {
            var materialAcabamento = from ma in _context.MaterialAcabamentos
                            select new DTOs.MaterialAcabamentoDTO()
                            {
                                AcabamentoID = ma.AcabamentoID,
                                MaterialID = ma.MaterialID
                            };
            return materialAcabamento;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialAcamento([FromRoute] int id)
        {
            var materialAcabamento = await _context.MaterialAcabamentos.Select(ma =>
            new DTOs.MaterialAcabamentoDTO()
            {
                AcabamentoID = ma.AcabamentoID,
                MaterialID = ma.MaterialID
            }).SingleOrDefaultAsync(ma => ma.MaterialID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(materialAcabamento == null)
            {
                return NotFound();
            }

            return Ok(materialAcabamento);
        }

        //POST api/material/acabamento
        [HttpPost]
        public async Task<IActionResult> PostMaterialAcabamento([FromBody] MaterialAcabamento materialAcabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MaterialAcabamentos.Add(materialAcabamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialAcabamento", new { id = materialAcabamento.AcabamentoID }, materialAcabamento);
        }
    }

}

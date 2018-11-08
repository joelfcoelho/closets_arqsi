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
    
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public MaterialController(ArmariosPorMedidaContext context)
        {
            _context = context;

        }

        //GET api/material
        [HttpGet]
        public IEnumerable<DTOs.MaterialDTO> GetMaterial()
        {
            var material = from p in _context.Materiais
                            select new DTOs.MaterialDTO()
                            {
                                MaterialID = p.MaterialID,
                                Nome = p.Nome
                            };
            return material;
        }

        //GET api/material/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial([FromRoute] int id)
        {
            var material = await _context.Materiais.Select(p =>
            new DTOs.MaterialDTO()
            {
                MaterialID = p.MaterialID,
                Nome = p.Nome
            }).SingleOrDefaultAsync(p => p.MaterialID == id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        //POST api/material
        [HttpPost]
        public async Task<IActionResult> PostMaterial([FromBody] Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Materiais.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.MaterialID }, material);
        }

        //PUT api/material/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial([FromRoute] int id, [FromBody] Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.MaterialID)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        //DELETE api/material/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = await _context.Materiais.SingleOrDefaultAsync(p => p.MaterialID == id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();

            return Ok(material);
        }

        //Verifica se material com ID id já existe
        private bool MaterialExists(int id)
        {
            return _context.Materiais.Any(p => p.MaterialID == id);
        }

            [HttpGet("{id}/Material")]
        public IActionResult GetAcabamento([FromRoute] int id){
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
              Material material = _context.Materiais.SingleOrDefault(p => p.MaterialID == id);

            if(material == null)
            {
                return NotFound();
            }
            var materialAcabamento = _context.MaterialAcabamentos.Where(mp => mp.MaterialID == material.MaterialID).Select(mp =>
            new DTOs.AcabamentoDTO
            {
                AcabamentoID = mp.AcabamentoID
            }).ToList();

            if(materialAcabamento == null)
            {
                return NotFound();
            }
            return Ok(materialAcabamento);
        }

        


    }

}

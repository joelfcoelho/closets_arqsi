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

           if (_context.ProdutoItems.Count() == 0)
            {
                // Create a new ProdutoItem if collection is empty,
                // which means you can't delete all ProdutoItems.
                _context.ProdutoItems.Add(new ProdutoItem { Name = "Item1" });
                _context.SaveChanges();
            }

        }

    }
}
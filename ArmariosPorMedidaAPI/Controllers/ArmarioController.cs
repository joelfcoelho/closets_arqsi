using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.Controllers
{
    [Route("api/Armario")]
    [ApiController]
    public class ArmarioController : ControllerBase
    {
        private readonly ArmariosPorMedidaContext _context;

        public ArmarioController(ArmariosPorMedidaContext context)
        {
            _context = context;

           /* if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            */}

        }

}
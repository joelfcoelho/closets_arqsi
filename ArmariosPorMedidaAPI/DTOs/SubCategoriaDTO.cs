using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.DTOs
{
    public class SubCategoriaDTO
    {
        
       public int SubCategoriaID { get; set; }
       public string Nome { get; set; }
       public Categoria Categoria { get; set; }

    }
}
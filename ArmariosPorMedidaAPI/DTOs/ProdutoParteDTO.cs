using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.DTOs
{
public class ProdutoParteDTO
    {
        
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int ParteID { get; set; }
        public Parte Parte { get; set; }
    }

}
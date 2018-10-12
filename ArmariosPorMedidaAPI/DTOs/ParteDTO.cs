using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.DTOs
{
   public class ParteDTO
    {
        public int ParteID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Altura {get ; set; }
        public double Largura {get ; set; }
        public double Profundidade {get ; set; }

    }
}
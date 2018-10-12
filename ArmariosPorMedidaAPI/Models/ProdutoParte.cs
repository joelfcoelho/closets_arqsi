using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class ProdutoParte
    {
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int ParteID { get; set; }
        public Parte Parte { get; set; }
    }


}
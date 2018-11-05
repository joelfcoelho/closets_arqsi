using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class MaterialProduto
    {
        public int MaterialID { get; set; }
        public Material Material { get; set; }
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

    }


}
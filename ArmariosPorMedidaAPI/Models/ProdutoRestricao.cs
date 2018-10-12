using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class ProdutoRestricao
    {
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int RestricaoID { get; set; }
        public Restricao Restricao { get; set; }
    }


}
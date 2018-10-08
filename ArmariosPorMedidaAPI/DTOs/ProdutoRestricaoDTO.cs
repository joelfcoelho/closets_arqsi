using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.DTOs
{
   public class ProdutoRestricaoDTO {

       public int ID { get; set; }
       public int ProdutoID { get; set; }
       public int RestricaoID { get; set; }

   }
}
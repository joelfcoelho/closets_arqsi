using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class Material {

       public int MaterialID { get; set; }
       public string Nome { get; set; }
       public List<Produto> Produtos { get; set; }

   }
}

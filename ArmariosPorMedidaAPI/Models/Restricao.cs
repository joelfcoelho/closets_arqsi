using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class Restricao {

       public int ID { get; set; }
       public string Nome { get; set; }
       public int IDRestrito { get; set; }

   }
}

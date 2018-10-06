using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class Material {

       public int ID { get; set; }
       public int AcabamentoID { get; set; }
       public string Nome { get; set; }
       public virtual Acabamento Acabamento{ get; set; }

   }
}

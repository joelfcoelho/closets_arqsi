using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public class Categoria {

       public int ID { get; set; }

       public string Nome { get; set; }

       public virtual Categoria SuperCategoria { get; set; }

       public virtual ICollection<Categoria> SubCategorias { get; set; }

   }
}

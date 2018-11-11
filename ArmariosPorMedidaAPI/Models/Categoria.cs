using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class Categoria {

       public int CategoriaID { get; set; }

       public string Nome { get; set; }

       public virtual ICollection<Categoria> SubCategorias { get; set; }
       //public List<Produto> Produtos { get; set; }

   }
}

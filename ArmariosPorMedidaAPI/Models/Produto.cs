using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Altura {get ; set; }
        public double Largura {get ; set; }
        public double Profundidade {get ; set; }
        /*public virtual ICollection<int> Partes { get; set; }
        public virtual ICollection<int> ParteEm { get; set; }
        public virtual ICollection<int> Restricoes { get; set; }*/
        public virtual Categoria Categoria { get; set; }
        public virtual Material Material { get; set; }
        public virtual Acabamento Acabamento{ get; set; }
    }
}

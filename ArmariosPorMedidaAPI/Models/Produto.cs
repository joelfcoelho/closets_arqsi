using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public class Produto
    {
        public int ID { get; set; }
        public int CategoriaID { get; set; }
        public int MaterialID { get; set; }
        public int AcabamentoID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Altura {get ; set; }
        public double Largura {get ; set; }
        public double Profundidade {get ; set; }
        public virtual ICollection<Produto> Partes { get; set; }
        public virtual ICollection<Produto> ParteEm { get; set; }
        public virtual ICollection<Restricao> Restricoes { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Material Material { get; set; }
        public virtual Acabamento Acabamento{ get; set; }
    }
}

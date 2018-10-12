using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class Parte
    {
        public int ParteID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Altura {get ; set; }
        public double Largura {get ; set; }
        public double Profundidade {get ; set; }
        public virtual ICollection<ProdutoParte> ProdutoPartes { get; set; }
    }
}
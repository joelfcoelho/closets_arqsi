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
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Altura {get ; set; }
        public double Largura {get ; set; }
        public double Profundidade {get ; set; }

        public virtual ICollection<ProdutoParte> ProdutoPartes { get; set; }
        
        public virtual ICollection<ProdutoRestricao> ProdutoRestricoes { get; set; }

         public virtual ICollection<MaterialProduto> MaterialProdutos { get; set; }

       /* public int? MaterialID { get; set; }
        public virtual Material Material { get; set; } */
        public int? CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        
       /* public int? AcabamentoID { get; set; }
        public virtual Acabamento Acabamento { get; set; }*/


    }
}

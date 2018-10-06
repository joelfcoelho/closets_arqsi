using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.DTOs
{
    public class ProdutoDTO
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


    }
}
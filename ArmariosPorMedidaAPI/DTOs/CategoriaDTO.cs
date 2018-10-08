using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmariosPorMedidaAPI.Models;

namespace ArmariosPorMedidaAPI.DTOs
{
    public class CategoriaDTO
    {
        
       public int ID { get; set; }

       public string Nome { get; set; }

       public virtual int SuperCategoriaID { get; set; }

       public virtual ICollection<int> SubCategorias { get; set; }      


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmariosPorMedidaAPI.Models
{
   public class MaterialAcabamento
    {
        public int MaterialID { get; set; }
        public Material Material { get; set; }
        public int AcabamentoID { get; set; }
        public Acabamento Acabamento { get; set; }

    }


}
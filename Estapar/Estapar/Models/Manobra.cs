using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Models
{
    public partial class Manobra
    {
        public long ManobraId { get; set; }

        [Display(Name = "Manobrista")]
        public long ManobristaId { get; set; }

        [Display(Name = "Veículo")]
        public long VeiculoId { get; set; }

        [Display(Name = "Data da manobra")]
        public DateTime DataManobra { get; set; }

        public virtual Manobrista Manobrista { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}

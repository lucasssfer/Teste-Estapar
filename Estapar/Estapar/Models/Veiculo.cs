using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Manobra = new HashSet<Manobra>();
        }

        public long VeiculoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Marca/Modelo/Placa")]
        public string Placa { get; set; }

        public string Descricao
        {
            get
            {
                return $"{Marca} {"/"} {Modelo} {"/"} {Placa}";
            }
        }

        public virtual ICollection<Manobra> Manobra { get; set; }
    }
}

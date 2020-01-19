using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Models
{
    public partial class Manobrista
    {
        public Manobrista()
        {
            Manobra = new HashSet<Manobra>();
        }

        public long ManobristaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Text)]

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Você deve digitar um cpf no formato ###.###.###-##")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Manobra> Manobra { get; set; }
    }
}

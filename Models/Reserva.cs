using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoHemobancoWeb.Models
{
    [Table("Reserva")]
    public class Reserva : BaseModel
    {
        [Display(Name = "Tipo de Sangue")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string TipoSangue { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public Funcionario Funcionario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoHemobancoWeb.Models
{
    [Table("Estoque")]
    public class Estoque : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public Sangue Sangue { get; set; }

        [Display(Name = "Unidades")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Quantidade { get; set; }

        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string UnidadeMedida { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public Funcionario Funcionario { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public float QuantidadeLitros { get; set; }
        public DateTime AlteradoEm { get; set; }

        public Estoque()
        {
            Sangue = new Sangue();
            AlteradoEm = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoHemobancoWeb.Models
{
    [Table("Doacao")]
    public class Doacao : BaseModel
    {
        public Doador Doador { get; set; }

        [Display(Name = "Quantidade de Sangue")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int QuantidadeSangue { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public Sangue Sangue { get; set; }

        public Doacao()
        {
            Sangue = new Sangue();
            QuantidadeSangue = 450;
        }
    }
}

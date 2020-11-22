using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoHemobancoWeb.Models
{
    [Table("Doador")]
    public class Doador : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Celular { get; set; }
    }
}

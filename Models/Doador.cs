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

        [Display(Name = "CEP:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cep { get; set; }

        [Display(Name = "Rua:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Localidade { get; set; }

        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Celular { get; set; }
    }
}

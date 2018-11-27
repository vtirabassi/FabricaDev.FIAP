using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap03.Web.MVC.Models
{
    
    public class MarcaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, digite um nome."), StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O CNPJ tem que ter 18 caracter com ."), StringLength(18, MinimumLength = 18)]
        public string Cnpj { get; set; }

        public MarcaModel(MarcaMOD marca)
        {
            Id = marca.Id;
            Nome = marca.Nome;
            DataCriacao = marca.DataCriacao;
            Cnpj = marca.Cnpj;
        }

        public MarcaModel() { }
    }
}
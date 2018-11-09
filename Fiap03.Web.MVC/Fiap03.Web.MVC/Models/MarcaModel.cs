using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.MVC.Models
{

    /*
     * 
     * Criar Tabela
     * Criar Crud
     * 
     */
    public class MarcaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Cnpj { get; set; }
    }
}
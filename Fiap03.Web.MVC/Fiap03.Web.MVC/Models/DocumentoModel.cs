using Fiap03.MOD;
using Fiap03.MOD.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap03.Web.MVC.Models
{
    public class DocumentoModel
    {
        public int Renavam { get; set; }
        public Categoria? Categoria { get; set; }

        [Display(Name = "Data de Fabricação")]
        public DateTime DataFabricacao { get; set; }

        public DocumentoModel(DocumentoMOD documento)
        {
            Renavam = documento.Renavam;
            Categoria = Categoria;
            DataFabricacao = documento.DataFabricacao;
        }

        public DocumentoModel() { }
    }
}
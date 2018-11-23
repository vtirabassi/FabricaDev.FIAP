using Fiap03.MOD;
using Fiap03.MOD.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap03.Web.MVC.Models
{
    public class CarroModel
    {

        public int Id { get; set; }

        [Display(Name = "Marca")]
        //FK
        public int MarcaId { get; set; }
        public int Ano { get; set; }
        public bool Esportivo { get; set; }
        public string Placa { get; set; }


        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Combustível")]
        public Combustivel? Combustivel { get; set; }

        //FK
        public DocumentoModel Documento { get; set; }

        public int Renavam { get; set; }


        public CarroModel(CarroMOD carro)
        {
            Id = carro.Id;
            MarcaId = carro.MarcaId;
            Ano = carro.Ano;
            Esportivo = carro.Esportivo;
            Placa = carro.Placa;
            Descricao = carro.Descricao;
            Combustivel = carro.Combustivel;
            if (carro.Documento != null)
                Documento = new DocumentoModel(carro.Documento);
            Renavam = carro.Renavam;
        }

        public CarroModel() { }
    }
}
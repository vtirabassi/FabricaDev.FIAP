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

        //FK
        [Required(ErrorMessage = "Por favor, selecione uma marca"), Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Digite o ano do carro"), Range(minimum: 1960, maximum:3000)]
        public int Ano { get; set; }
        public bool Esportivo { get; set; }

        [Required(ErrorMessage = "Por favor, digite a placa com 7 digios e com hiffen"), StringLength(8, MinimumLength = 8)]
        public string Placa { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Combustível")]
        public Combustivel? Combustivel { get; set; }

        //FK
        public DocumentoModel Documento { get; set; }

        public int ModeloId { get; set; }


        public CarroModel(CarroMOD carro)
        {
            Id = carro.Id;
            MarcaId = carro.MarcaId;
            Ano = carro.Ano;
            Esportivo = carro.Esportivo;
            Placa = carro.Placa;
            Descricao = carro.Descricao;
            Combustivel = carro.Combustivel;
            ModeloId = carro.ModeloId;
            if (carro.Documento != null)
                Documento = new DocumentoModel(carro.Documento);
        }

        public CarroModel() { }
    }
}
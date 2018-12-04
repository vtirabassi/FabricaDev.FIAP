using Fiap03.MOD;
using Fiap03.MOD.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.Web.API.Models
{
    public class CarroDTO
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public int Ano { get; set; }
        public bool Esportivo { get; set; }
        public string Placa { get; set; }
        public string Descricao { get; set; }
        public Combustivel? Combustivel { get; set; }

        //FK

        public int Renavam { get; set; }

        public DocumentoDTO Documento { get; set; }
        public int ModeloId { get; set; }

        public CarroDTO() { }

        public CarroDTO(CarroMOD carro)
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
                Documento = new DocumentoDTO(carro.Documento);
        }
    }
}
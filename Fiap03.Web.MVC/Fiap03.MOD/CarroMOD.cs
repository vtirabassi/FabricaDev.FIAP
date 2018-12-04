using Fiap03.MOD.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap03.MOD
{
    public class CarroMOD
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

        public DocumentoMOD Documento { get; set; }
        public int ModeloId { get; set; }

        public CarroMOD() { }
    }
}
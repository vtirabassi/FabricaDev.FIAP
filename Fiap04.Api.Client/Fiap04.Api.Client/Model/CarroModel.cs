using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.Model
{
    public class CarroModel
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

        public DocumentoModel Documento { get; set; }
        public int ModeloId { get; set; }

    }
}

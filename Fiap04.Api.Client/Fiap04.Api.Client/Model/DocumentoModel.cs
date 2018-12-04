using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.Model
{
    public class DocumentoModel
    {
        public int Renavam { get; set; }
        public Categoria? Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.Exercicio01.Exception
{
    public class DiversasException : System.Exception
    {
        public DiversasException() { }
        public DiversasException(string message) : base(message) { }
        public DiversasException(string message, System.Exception inner) : base(message, inner) { }
        protected DiversasException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
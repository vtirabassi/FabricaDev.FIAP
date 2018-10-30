using Fiap01.Fabrica.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI.Models
{
    public class Professor : Pessoa, IColaborador
    {
        public Professor(string nome) : base(nome)
        {
        }

        public override void VerBoletim()
        {
            Console.WriteLine("Professor vendo boletim...");
        }

        public void BaterPonto()
        {
            if (DateTime.Now.Hour > 10)
            {
                throw new HorarioInvalidoException("Fora do horario");
            }
            Console.WriteLine("Professor batendo o ponto...");
        }

    }
}

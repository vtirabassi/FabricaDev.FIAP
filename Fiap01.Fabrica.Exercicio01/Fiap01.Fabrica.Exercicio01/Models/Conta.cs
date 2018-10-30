using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.Exercicio01.Models
{
    public abstract class Conta
    {
        public int Agencia { get; set; }
        public DateTime DataAbertura { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }

        public abstract void Depositar(decimal valor);

        public abstract void Retirar(decimal valor);
    }
}

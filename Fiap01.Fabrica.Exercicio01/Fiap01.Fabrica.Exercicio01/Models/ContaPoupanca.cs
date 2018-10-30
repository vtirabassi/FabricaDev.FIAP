using Fiap01.Fabrica.Exercicio01.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.Exercicio01.Models
{
    public class ContaPoupanca : Conta, IContaInvestimento
    {
        public decimal Taxa { get; set; }
        private readonly decimal _rendimento;

        public decimal CalculaContaInvestimento()
        {
            return Saldo * _rendimento;
        }

        public ContaPoupanca(decimal valor)
        {
            _rendimento = valor;
        }


        public override void Depositar(decimal valor)
        {
            Console.WriteLine("Deposita na conta poupança");
            Saldo += valor;
        }

        public override void Retirar(decimal valor)
        {
            Console.WriteLine("Retira da conta poupança");
            if (Saldo > 0)
            {
                Saldo = Saldo - (valor + Taxa);
                Console.WriteLine("Seu saldo é {0}", Saldo);
            }
            else
                throw new DiversasException("Saldo insuficiente");
        }

    }
}

using Fiap01.Fabrica.Exercicio01.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.Exercicio01.Models
{
    //sealed -> não permite a herança
    public sealed class ContaCorrente : Conta
    {
        public TipoConta Tipo { get; set; }

       

        public override void Retirar(decimal valor)
        {
            Console.WriteLine("Retira da conta corrente");
            var saldoAtual = Saldo;
            Saldo -= valor;

            if(Tipo != TipoConta.Comum && Saldo < 0)
            {
                Saldo = saldoAtual;
                throw new DiversasException("Saldo insuficiente");
            }

            Console.WriteLine("Seu saldo é {0}", Saldo);

            /*
             if (Tipo == TipoConta.Comum && Saldo-valor < 0)
                throw new DiversasException("Saldo insuficiente");
            Saldo -= valor;
             */

        }
    }
}

using Fiap01.Fabrica.Exercicio01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente cCorrente = new ContaCorrente()
            {
                Agencia = 2,
                DataAbertura = DateTime.Now,
                Numero = 5,
                Saldo = 10000,
                Tipo = TipoConta.Especial
            };

            ContaPoupanca cPoupanca = new ContaPoupanca(100)
            {
                Agencia = 2,
                DataAbertura = DateTime.Now,
                Numero = 5,
                Saldo = 10000,
                Taxa = 5
            };

            cCorrente.Retirar(100);
            cPoupanca.Retirar(100);

            Console.Read();
        }
    }
}

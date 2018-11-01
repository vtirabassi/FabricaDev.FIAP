using Fiap01.Fabrica.Exercicio01.Exception;
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
                Saldo = 200,
                Tipo = TipoConta.Especial
            };

            ContaPoupanca cPoupanca = new ContaPoupanca(0.05m)
            {
                Agencia = 2,
                DataAbertura = new DateTime(2010, 10, 20),
                Numero = 5,
                Saldo = 200,
                Taxa = 5,
            };

            try
            {
                cCorrente.Retirar(200);
            }
            catch (DiversasException e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}

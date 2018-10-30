using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI.Models
{
    public class Aluno : Pessoa
    {
        //Prioridade
        public string Rm { get; set; }

        //Construtor
        public Aluno(string rm, string nome) : base (nome)
        {
            this.Rm = rm; //o this ele se refere a classe 
        }

        public override void VerBoletim()
        {
            Console.Write("Aluno vendo boletim...");
        }

        public override void Cadastrar()
        {
            base.Cadastrar();
        }

    }
}

using Fiap01.Fabrica.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Objeto aluno
            Aluno aluno = new Aluno("74353", "Vinicius")
            {
                Idade = 21
            };

            aluno.Sexo = Genero.Masculino;

            IList<Aluno> turma = new List<Aluno>();
            turma.Add(new Aluno("74353", "Angelo")
            {
                Rm = "74353",
                Nome = "Angelo",
                Idade = 21
            });

            turma.Add(aluno);

            foreach (var item in turma)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Fabrica.UI.Models
{
    public abstract class Pessoa
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Idade { get; set; }
        public Genero Sexo { get; set; }


        public Pessoa(string nome)
        {
            Nome = nome;
        }

        //---------------metodos------------------
        public abstract void VerBoletim();

        public virtual void Cadastrar() //virtual permite a suprescrita do metodo
        {
            Console.Write("Pessoa se cadastrando...");
        } 
    }
}

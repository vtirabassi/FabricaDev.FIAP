using System;
using System.Data.SqlClient;
using Fiap03.DAL.Interfaces;
using Fiap03.DAL.Repositorios;
using Fiap03.MOD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiap03.DAL.Test
{
    [TestClass]
    public class MarcaRepositoryTest
    {

        private IMarcaRepository rep;


        //executa antes dos testes
        [TestInitialize]
        public void init()
        {
            rep = new MarcaRepository();
        }

        [TestMethod]
        public void Cadastrar_Marca_Test()
        {
            var marca = new MarcaMOD()
            {
                Cnpj = "555555555",
                Nome = "Teste",
                DataCriacao = new DateTime(2010,1,19)
            };

            rep.Cadastrar(marca);
            //valida se deu ok
            Assert.IsNotNull(marca.Id);
            Assert.AreNotEqual(0, marca.Id);
        }

        [TestMethod]
        public void Lista_Marca_Test()
        {
            //chama metodo que sera testado
            var lista = rep.Listar();
            //valida
            Assert.IsNotNull(lista);
            Assert.AreNotEqual(0, lista.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Cadastrar_Sem_Nome()
        {
            var marca = new MarcaMOD()
            {
                Cnpj = "6666666666",
                Nome = null,
                DataCriacao = new DateTime(2010, 1, 19)
            };

            rep.Cadastrar(marca);
        }


    }
}

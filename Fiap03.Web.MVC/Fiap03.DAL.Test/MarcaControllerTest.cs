using System;
using System.Web.Mvc;
using Fiap03.MOD;
using Fiap03.Web.MVC.Controllers;
using Fiap03.Web.MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiap03.DAL.Test
{
    [TestClass]
    public class MarcaControllerTest
    {
        [TestMethod]
        public void Cadastro_Post_Test()
        {
            MarcaController controller = new MarcaController();
            var marca = new MarcaModel()
            {
                Cnpj = "555555555",
                Nome = "Teste",
                DataCriacao = new DateTime(2010, 1, 19)
            };

            controller.Cadastrar(marca);

            Assert.AreEqual(controller.TempData["msg"],
                "Marca criada");

        }
    }
}

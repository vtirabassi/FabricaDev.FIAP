using Dapper;
using Fiap03.DAL.ConnectionFactories;
using Fiap03.DAL.ConnectionFactory;
using Fiap03.DAL.Repositorios;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class CarroController : Controller
    {
        private ICarroRepository _carroRepository;

        //simula o BD
        //private static IList<string> _marcasCarros = new List<string>() {
        //    "Hyndai",
        //    "FIAT",
        //    "Toyota",
        //    "Honda",
        //    "Jeep"
        //};

        private void CarregarMarcas()
        {
            using (IDbConnection db = ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Marca";

                var marcas = db.Query<MarcaModel>(sql).ToList();

                ViewBag.marcas = new SelectList(marcas, "Id", "Nome");
            }
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregarMarcas();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CarroModel carro)
        {
            var x = Regex.Match(carro.Placa, "[A-Z]{3}-[0-9]{4}");
            if (x.Success)
            {
                _carroRepository.Cadastrar(new CarroModel(carro));
                TempData["msg"] = "Carro registrado";
            }
            else
            {
                TempData["msg"] = "Placa invalida";
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_carroRepository.Listar());
        }

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            _carroRepository.Excluir(codigo);
            TempData["msgApagar"] = "Carro excluido";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public PartialViewResult ListarCarro(int codigo)
        {
            CarregarMarcas();

            return PartialView("_EditarPartial", _carroRepository.ListarCarro(codigo));
        }

        [HttpGet]
        public ActionResult Buscar(int ano)
        {
            return View("Listar", _carroRepository.Buscar(ano));
        }

        [HttpPost]
        public ActionResult Editar(CarroModel carro)
        {
            var a = _carroRepository.Editar(carro);

            if (a != false)
                TempData["msg"] = "Carro alterado";
            else
                TempData["msg"] = "Erro ao alterar carro";
            return RedirectToAction("Listar");
        }
    }
}


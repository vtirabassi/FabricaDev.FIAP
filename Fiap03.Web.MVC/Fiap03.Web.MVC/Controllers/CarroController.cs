using Dapper;
using Fiap03.DAL.ConnectionFactories;
using Fiap03.DAL.Repositorios;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.MOD;
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
        private ICarroRepository _carroRepository = new CarroRepository();

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
            //var x = Regex.Match(carro.Placa, "[A-Z]{3}-[0-9]{4}");
            if (!ModelState.IsValid)
            {
                return Cadastrar();
            }

            _carroRepository.Cadastrar(new CarroMOD()
            {
                Id = carro.Id,
                MarcaId = carro.MarcaId,
                Ano = carro.Ano,
                Esportivo = carro.Esportivo,
                Placa = carro.Placa,
                Descricao = carro.Descricao,
                Combustivel = carro.Combustivel,
                Renavam = carro.Renavam,
                Documento = new DocumentoMOD()
                {
                    Renavam = carro.Documento.Renavam,
                    Categoria = carro.Documento.Categoria,
                    DataFabricacao = carro.Documento.DataFabricacao
                }
            });

            TempData["msg"] = "Carro registrado";

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var carros = _carroRepository.Listar().Select(c => new CarroModel(c)).ToList();
            return View(carros);
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

            var carro = new CarroModel(_carroRepository.ListarCarro(codigo));
            return PartialView("_EditarPartial", carro);
        }

        [HttpGet]
        public ActionResult Buscar(int ano)
        {
            return View("Listar", _carroRepository.Buscar(ano).Select(c => new CarroModel(c)).ToList());
        }

        [HttpPost]
        public ActionResult Editar(CarroModel carro)
        {
            var a = _carroRepository.Editar(new CarroMOD()
            {
                Id = carro.Id,
                MarcaId = carro.MarcaId,
                Ano = carro.Ano,
                Esportivo = carro.Esportivo,
                Placa = carro.Placa,
                Descricao = carro.Descricao,
                Combustivel = carro.Combustivel,
                Renavam = carro.Renavam,
                Documento = new DocumentoMOD()
                {
                    Renavam = carro.Documento.Renavam,
                    Categoria = carro.Documento.Categoria,
                    DataFabricacao = carro.Documento.DataFabricacao
                }
            });

            if (a != false)
                TempData["msg"] = "Carro alterado";
            else
                TempData["msg"] = "Erro ao alterar carro";
            return RedirectToAction("Listar");
        }
    }
}


using Dapper;
using Fiap03.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class CarroController : Controller
    {
        //simula o BD
        private static IList<string> _marcasCarros = new List<string>() {
            "Hyndai",
            "FIAT",
            "Toyota",
            "Honda",
            "Jeep"
        };

        [HttpGet]
        public ActionResult Cadastrar()
        {
            ViewBag.marcas = new SelectList(_marcasCarros);
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CarroModel carro)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "INSERT INTO Carro VALUES (@Marca, @Ano, @Esportivo, @Placa, @Descricao, @Combustivel); SELECT CAST(SCOPE_IDENTITY() as int)";

                int id = db.Query<int>(sql, carro).Single();

                TempData["msg"] = "Carro registrado";
                return RedirectToAction("Listar");
            }
        }

        [HttpGet]
        public ActionResult Listar()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Carro";

                var carros = db.Query<CarroModel>(sql).ToList();
                    return View(carros);
            }
        }
    }
}
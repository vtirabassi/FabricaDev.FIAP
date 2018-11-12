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
    public class MarcaController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(MarcaModel marca)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "INSERT INTO Marca VALUES (@Nome, @Cnpj, @DataCriacao); SELECT CAST(SCOPE_IDENTITY() as int)";

                int id = db.Query<int>(sql, marca).Single();

                TempData["msg"] = "Marca criada";
                return RedirectToAction("Listar");
            }
        }

        [HttpGet]
        public ActionResult Listar()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Marca";

                var marcas = db.Query<MarcaModel>(sql).ToList();
                return View(marcas);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "DELETE FROM Marca WHERE Id = @Id";

                var deletado = db.Execute(sql, new { Id = codigo });

                TempData["msgApagar"] = "Carro excluido";
                return RedirectToAction("Listar");
            }
        }

        [HttpGet]
        public PartialViewResult ListarMarca(int codigo)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Marca WHERE Id = @Id";

                var carro = db.Query<MarcaModel>(sql, new { Id = codigo }).FirstOrDefault();
                return PartialView("_EditarPartial", carro);
            }
        }

        [HttpGet]
        public ActionResult Buscar(int cnpj)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Marca WHERE Cnpj LIKE '%@Cnpj%'";

                var carros = db.Query<MarcaModel>(sql, new { Cnpj = cnpj }).ToList();
                return View("Listar", carros);
            }
        }

        [HttpGet]
        public ActionResult Editar(MarcaModel marca)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {


                string sql = "UPDATE Marca SET Nome = '@Nome', Cnpj = @Cnpj, DataCriacao = @DataCriacao WHERE Id = @Id";

                var a = db.Execute(sql, marca) > 0;
                if (a != false)
                    TempData["msg"] = "Carro alterado";
                TempData["msg"] = "Carro feio";
                return RedirectToAction("Listar");
            }
        }
    }
}
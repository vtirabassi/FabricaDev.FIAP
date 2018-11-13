using Dapper;
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
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
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
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
                {
                    using (var txScope = new TransactionScope())
                    {
                        string sql = "INSERT INTO Documento VALUES(@Renavam, @Categoria, @DataFabricacao)";

                        db.Execute(sql, carro.Documento);

                        string sql2 = "INSERT INTO Carro VALUES (@MarcaId, @Ano, @Esportivo, @Placa, @Descricao, @Combustivel, @Renavam); SELECT CAST(SCOPE_IDENTITY() as int)";

                        carro.Renavam = carro.Documento.Renavam;
                        int id = db.Query<int>(sql2, carro).Single();

                        txScope.Complete();
                    }
                }
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
            CarregarMarcas();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Carro INNER JOIN Documento ON Carro.Renavam = Documento.Renavam";

                var carros = db.Query<CarroModel, DocumentoModel, CarroModel>(sql,
                    (carro, documento) =>
                    {
                        carro.Documento = documento;
                        return carro;
                    }, splitOn: "Renavam, Renavam").ToList();
                return View(carros);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "DELETE FROM Carro WHERE Id = @Id";

                var deletado = db.Execute(sql, new { Id = codigo });

                TempData["msgApagar"] = "Carro excluido";
                return RedirectToAction("Listar");
            }
        }

        [HttpGet]
        public PartialViewResult ListarCarro(int codigo)
        {
            CarregarMarcas();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Carro INNER JOIN Documento ON Carro.Renavam = Documento.Renavam WHERE Id = @Id";

                var carroDet = db.Query<CarroModel, DocumentoModel, CarroModel>(sql,
                    (carro, documento) =>
                    {
                        carro.Documento = documento;
                        return carro; 
                    }, new { Id = codigo }, splitOn: "Renavam, Renavam").FirstOrDefault();
                return PartialView("_EditarPartial", carroDet);
            }
        }

        [HttpGet]
        public ActionResult Buscar(int ano)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "SELECT * FROM Carro WHERE Ano = @Ano OR 0 = @Ano";

                var carros = db.Query<CarroModel>(sql, new { Ano = ano }).ToList();
                return View("Listar", carros);
            }
        }

        [HttpPost]
        public ActionResult Editar(CarroModel carro)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {
                string sql = "UPDATE Carro SET Marca = @MarcaId, Combustivel = @Combustivel, Esportivo = @Esportivo, Placa = @Placa, Ano = @Ano, Descricao = @Descricao WHERE Id = @Id";

                var a = db.Execute(sql, carro) > 0;
                if (a != false)
                    TempData["msg"] = "Carro alterado";
                else
                    TempData["msg"] = "Erro ao alterar carro";
                return RedirectToAction("Listar");
            }
        }
    }
}

//AJUSTAR O BUSCA
//AJUSTAR O EDITAR

//LISTAR TODOS OS CARROS CADASTRADOS NA MARCA
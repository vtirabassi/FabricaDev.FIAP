using Dapper;
using Fiap03.DAL.Repositorios;
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

        MarcaRepository _marcaRepositor = new MarcaRepository();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(MarcaModel marca)
        {


            TempData["msg"] = "Marca criada";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {

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
            return PartialView("_EditarPartial", _marcaRepositor.ListarMarca(codigo));
        }

        [HttpGet]
        public ActionResult Buscar(int cnpj)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {

                return View("Listar", carros);
            }
        }

        [HttpPost]
        public ActionResult Editar(MarcaModel marca)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {

                if (a != false)
                {
                    TempData["msg"] = "Marca alterada";
                }
                else
                {
                    TempData["msg"] = "Erro ao alterar marca";
                }
                return RedirectToAction("Listar");
            }
        }

        [HttpGet]
        public ActionResult ListarCarrosAtrelados(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFabrica"].ConnectionString))
            {

                return PartialView(carros);
            }
        }
    }
}
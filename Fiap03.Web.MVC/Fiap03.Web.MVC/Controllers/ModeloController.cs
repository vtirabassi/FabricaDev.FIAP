using Fiap03.DAL.Repositorios;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class ModeloController : Controller
    {
        IModeloRepository _modeloRepositorio = new ModeloRepository();

        [HttpPost]
        public ActionResult Cadastrar(ModeloMOD modelo)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar(int marcaId)
        {
            var modelos = _modeloRepositorio.Listar(marcaId);
            return PartialView("ModalModelos", modelos);
        }
    }
}
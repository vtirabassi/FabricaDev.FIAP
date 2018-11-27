using Fiap03.DAL.Repositorios;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.MOD;
using Fiap03.Web.MVC.Models;
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
            _modeloRepositorio.Cadastrar(new ModeloMOD()
            {
                Nome = modelo.Nome,
                MarcaId = modelo.MarcaId
            });
            return RedirectToAction("Listar", "Marca");
        }

        [HttpGet]
        public ActionResult Listar(int marcaId)
        {
            TempData["MarcaId"] = marcaId;
            var modelos = _modeloRepositorio.Listar(marcaId);
            return PartialView("ModalModelos", modelos.Select(m => new ModeloModel(m)).ToList());
        }
    }
}
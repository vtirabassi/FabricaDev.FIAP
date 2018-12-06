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
        ICarroRepository _carroRepositorio = new CarroRepository();

        [HttpPost]
        public ActionResult Cadastrar(ModeloMOD modelo)
        {
            _modeloRepositorio.Cadastrar(new ModeloMOD()
            {
                Nome = modelo.Nome,
                MarcaId = modelo.MarcaId
            });
            return PartialView("Listar", "Marca");
        }

        [HttpGet]
        public ActionResult Listar(int marcaId)
        {
            TempData["MarcaId"] = marcaId;
            var modelos = _modeloRepositorio.Listar(marcaId);
            return PartialView("ModalModelos", modelos.Select(m => new ModeloModel(m)).ToList());
        }

        [HttpPost]
        public ActionResult Excluir(int id, int marcaId)
        {
            var verificaCarroModelo = _carroRepositorio.VerificaCarroModelo(id);
            if (verificaCarroModelo == true)
            {
                TempData["msgApagar"] = "Erro ao excluir, devido existir um carro com essa marca.";
                var modelos = _modeloRepositorio.Listar(marcaId);
                return PartialView("_PartialTabelaModelo", modelos.Select(m => new ModeloModel(m)).ToList());
            }

            try
            {
                _modeloRepositorio.Excluir(id);
                var modelos = _modeloRepositorio.Listar(marcaId);
                return PartialView("_PartialTabelaModelo", modelos.Select(m => new ModeloModel(m)).ToList());
            }
            catch
            {
                TempData["msgApagar"] = "Erro ao excluir.";
                var modelos = _modeloRepositorio.Listar(marcaId);
                return PartialView("_PartialTabelaModelo", modelos.Select(m => new ModeloModel(m)).ToList());
            }

        }
    }
}
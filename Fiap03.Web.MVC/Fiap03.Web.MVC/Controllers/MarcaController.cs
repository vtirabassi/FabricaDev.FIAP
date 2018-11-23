﻿using Dapper;
using Fiap03.DAL.Interfaces;
using Fiap03.DAL.Repositorios;
using Fiap03.MOD;
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

        IMarcaRepository _marcaRepositor = new MarcaRepository();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(MarcaModel marca)
        {
            _marcaRepositor.Cadastrar(new MarcaMOD()
            {
                Id = marca.Id,
                Nome = marca.Nome,
                Cnpj = marca.Cnpj,
                DataCriacao = marca.DataCriacao
            });

            TempData["msg"] = "Marca criada";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_marcaRepositor.Listar().Select(m => new MarcaModel(m)).ToList());
        }

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            var excluiu = _marcaRepositor.Excluir(codigo);

            if (excluiu != true)
                TempData["msgApagar"] = "Erro ao excluir";
            TempData["msgApagar"] = "Carro excluido";

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public PartialViewResult ListarMarca(int codigo)
        {
            return PartialView("_EditarPartial", new MarcaModel(_marcaRepositor.ListarMarca(codigo)));
        }

        [HttpGet]
        public ActionResult Buscar(int cnpj)
        {
            return View("Listar", _marcaRepositor.Buscar(cnpj).Select(m => new MarcaModel(m)).ToList());
        }

        [HttpPost]
        public ActionResult Editar(MarcaModel marca)
        {
            var a = _marcaRepositor.Editar(new MarcaMOD()
            {
                Id = marca.Id,
                Nome = marca.Nome,
                Cnpj = marca.Cnpj,
                DataCriacao = marca.DataCriacao
            });

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

        [HttpGet]
        public ActionResult ListarCarrosAtrelados(int id)
        {
            return PartialView(_marcaRepositor.ListarCarrosAtrelados(id).Select(c => new CarroModel(c)).ToList());
        }
    }
}
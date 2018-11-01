using Fiap02.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap02.Web.MVC.Controllers
{
    public class AlunoController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new AlunoModel());
        }

        [HttpPost]
        public ActionResult Cadastrar(AlunoModel aluno)
        {
            ViewBag.Nome = aluno.Nome;
            TempData["msg"] = "Cadastrado com sucesso";


            return View(aluno);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }

    }
}
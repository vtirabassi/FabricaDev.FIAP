using Fiap03.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class CarroController : Controller
    {
        //simula o BD
        private static IList<CarroModel> _carros = new List<CarroModel>();
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
            _carros.Add(carro);
            TempData["msg"] = "Carro registrado";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_carros);
        }
    }
}
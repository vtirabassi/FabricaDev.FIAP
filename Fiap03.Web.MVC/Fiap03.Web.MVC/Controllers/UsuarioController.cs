using Fiap03.Web.MVC.App_Start;
using Fiap03.Web.MVC.Models;
using Fiap03.Web.MVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fiap03.Web.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private readonly UserManager<UsuarioModel> _userManager;


        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext(); return ctx.Authentication;
        }

        
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        [HttpGet]
        //Cadastrar um usuario
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return View();

            //criar objeto para persistir no banco de dados
            var usuarioMOD = new UsuarioModel
            {
                UserName = usuario.Login
            };

            var result = await _userManager.CreateAsync(usuarioMOD, usuario.Senha);

            if (result.Succeeded)
            {
                var identity = await _userManager.CreateIdentityAsync(usuarioMOD,
                    DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);
                return RedirectToAction("index", "home");
            }

            foreach (var erro in result.Errors)
                ModelState.AddModelError("", erro);

            return View();
        }

        [HttpGet]
        public ActionResult LogIn(string ReturnUrl)
        {
            var model = new UsuarioViewModel
            {
                Url = ReturnUrl
            };

            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> LogIn(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindAsync(model.Login, model.Senha);

            if (user != null)
            {
                var identity = await _userManager.CreateIdentityAsync(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);
                return Redirect(GetRedirectUrl(model.Url));
            }
            ModelState.AddModelError("", "Usuário e/ou Senha inválidos");

            return View();
        }

        public ActionResult LogOut()
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("index", "home");
        }







        //construtor para inicializar o gerenciado de usuario
        public UsuarioController()
        {
            _userManager = IdentityConfig.UserManagerFactory.Invoke();
        }

        //libera os recursos quando o objeto controller for destruido
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

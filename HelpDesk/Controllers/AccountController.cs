using HelpDesk.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HelpDesk.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly HelpDeskContext helpDeskContext;

        public AccountController(HelpDeskContext helpDeskContext)
        {
            this.helpDeskContext = helpDeskContext;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index() => RedirectToAction(nameof(Login));

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["Erro"] = TempData["Erro"];
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string returnUrl, UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid) return View(usuarioModel);

            // criar sempre o usuário admin para termos acesso
            var usuPadrao = HelpDeskContext.GetUsuarioPadrao();
            var admin = helpDeskContext.Usuarios.Where(x => x.Login.Equals(usuPadrao.Login)).FirstOrDefault();
            if (admin == null)
            {
                helpDeskContext.Usuarios.Add(usuPadrao);
                helpDeskContext.SaveChanges();
            }
            else if (!admin.Senha.Equals(usuPadrao.Senha))
            {
                admin.Senha = usuPadrao.Senha;
                helpDeskContext.Usuarios.Update(admin);
                helpDeskContext.SaveChanges();
            }
            Usuario usuario = null;

            try
            {
                usuarioModel.Senha = HelpDeskContext.GerarHash(usuarioModel.Senha);
                usuario = helpDeskContext.Usuarios
                     .AsNoTracking()
                             .Where(x => x.Login.Equals(usuarioModel.Login) && x.Senha.Equals(usuarioModel.Senha))
                             .FirstOrDefault();

                if (usuario == null) throw new Exception("Usuario ou senha invalida");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(nameof(UsuarioModel.Login), e.Message);
                ModelState.AddModelError(nameof(UsuarioModel.Senha), e.Message);
                return View(usuarioModel);
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim("LoginUsu", usuario.Login),
                new Claim(ClaimTypes.Sid, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome)
            };

            if (!usuarioModel.Login.ToLower().Equals("admin")) claims.Add(new Claim(ClaimTypes.Role, "admin"));

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = true
            };

            // Realizar login na aplicação com cookie e todas as suas configurações
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            // Retorna para a tela de inicio
            if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
            else return Redirect("~/home/index");

        }
        [HttpGet]
        [Route("logoff")]
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }

        [Route("accessdenied")]
        [HttpGet]
        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}


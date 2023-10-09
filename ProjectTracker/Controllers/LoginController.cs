using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;
using System.Security.Claims;

namespace ProjectTracker.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Atividades");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string usuario, string senha, bool manterLogado)
        {
            var usuarioLogin = await _usuarioService.GetUsuario(usuario, senha);

            if (usuarioLogin != null)
            {
                int usuarioId = usuarioLogin.Id;
                string login = usuarioLogin.Login;

                List<Claim> direitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
                    new Claim(ClaimTypes.Name, login)
                };

                var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = manterLogado,
                        ExpiresUtc = DateTime.Now.AddDays(2),
                    });

                //return Json(new { Msg = "Usuario Logado com sucesso!" });
                return RedirectToAction("Index", "Atividades");
            }

            return Json(new { Msg = "Usuario não encontrado! Verifique suas credenciais!" });
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}

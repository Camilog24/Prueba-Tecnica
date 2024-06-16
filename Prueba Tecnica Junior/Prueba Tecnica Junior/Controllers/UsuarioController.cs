using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_Junior.Data;
using Prueba_Tecnica_Junior.Models;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Junior.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Prueba_Tecnica_Junior.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioController(AppDbContext appDbContext)
        {
        _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioVm modeloUsuario)
        {
            if(modeloUsuario.Contraseña != modeloUsuario.ConfirmarContraseña)
            {
                ViewData["Mensaje"] = "Las contraseñas no son iguales";
                return View();
            }
            bool usuarioExistente = await _appDbContext.Usuarios.AnyAsync(u => u.Usuarios == modeloUsuario.Usuarios);

            if (usuarioExistente)
            {
                ViewData["Mensaje"] = "El usuario ya existe.";
                return View(modeloUsuario);
            }
            else
            {

                Usuario NuevoUsuario = new Usuario()
                {
                    Usuarios = modeloUsuario.Usuarios,
                    Contraseña = modeloUsuario.Contraseña,
                    Fecha_Creacion = modeloUsuario.Fecha_Creacion,
                };
                await _appDbContext.Usuarios.AddAsync(NuevoUsuario);
                await _appDbContext.SaveChangesAsync();

                if (NuevoUsuario.IdUsuario != 0)
                {
                    return RedirectToAction("Login", "Usuario");
                }
                ViewData["Mensaje"] = "No Se creo con exito";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modeloUsuario)
        {
            Usuario? Encontrando_Usuario= await _appDbContext.Usuarios.Where(USU=>USU.Usuarios==modeloUsuario.Usuarios && USU.Contraseña== modeloUsuario.Contraseña).FirstOrDefaultAsync();
            if (Encontrando_Usuario == null)
            {
                ViewData["Mensaje"] = "No Se puede encontrar el Usuario";
                return View();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, Encontrando_Usuario.Usuarios)
            };
            ClaimsIdentity claimsIdentity= new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Listar", "Persona");
        }
    }
}

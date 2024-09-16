using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fodun.Models.Dtos;
using Fodun.Services;

namespace Fodun.Controllers
{
    public class UsuariosViewController : Controller
    {
        private readonly IUserService _userService;

        public UsuariosViewController(IUserService userService)
        {
            _userService = userService;
        }

        // Vista de login
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegistroUsuario registerDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos inválidos. Intenta nuevamente.";
                return View(registerDto);
            }

            var result = await _userService.RegisterUser(registerDto);
            if (!result)
            {
                TempData["ErrorMessage"] = "Error al registrar el usuario.";
                return View(registerDto);
            }

            TempData["SuccessMessage"] = "Usuario registrado exitosamente.";
            return RedirectToAction("Login");
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuario loginDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos inválidos. Intenta nuevamente.";
                return View(loginDto);
            }

            var isAuthenticated = await _userService.ValidateUser(loginDto.NroDocumento, loginDto.Clave);
            if (!isAuthenticated)
            {
                TempData["ErrorMessage"] = "Credenciales incorrectas.";
                return View(loginDto);
            }

            // Redirige al usuario a la página deseada después de iniciar sesión exitosamente
            return RedirectToAction("Sedes", "SedeView");
        }




        // Vista de recuperación de contraseña
        public IActionResult RecuperarClave()
        {
            return View();
        }
    }
}

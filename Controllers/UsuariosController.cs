using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fodun.Models.Dtos;
using Fodun.Services;
using Fodun.Data;
using Microsoft.EntityFrameworkCore;

namespace Fodun.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public AuthController(ApplicationDbContext context, IUserService userService, EmailService emailService)
        {
            _userService = userService;
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuario loginDto)
        {
            if (ModelState.IsValid)
            {
                var isAuthenticated = await _userService.ValidateUser(loginDto.NroDocumento, loginDto.Clave);
                if (isAuthenticated)
                {
                    return Ok(new { message = "Autenticación exitosa" });
                }
                return Unauthorized(new { message = "Credenciales incorrectas" });
            }
            return BadRequest(ModelState);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistroUsuario registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerDto);
                if (result)
                {
                    return Ok(new { message = "Usuario registrado exitosamente" });
                }
                return BadRequest(new { message = "Error al registrar el usuario" });
            }
            return BadRequest(ModelState);
        }

        [HttpPost("enviarCorreoRecuperacion")]
        public async Task<IActionResult> EnviarCorreoRecuperacion([FromBody] RecuperacionContraseñaRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("El correo electrónico es requerido.");
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (usuario == null)
            {
                return NotFound("No se encontró un usuario con este correo.");
            }

            var emailSubject = "Recuperación de contraseña";
            var emailBody = $"Su contraseña es: {usuario.Clave}";
            await _emailService.SendAsync(request.Email, emailSubject, emailBody);

            return Ok(new { message = "Correo enviado con éxito." });
        }
    }
}

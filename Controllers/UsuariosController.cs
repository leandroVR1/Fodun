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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isAuthenticated = await _userService.ValidateUser(loginDto.NroDocumento, loginDto.Clave);
            if (!isAuthenticated) return Unauthorized(new { message = "Credenciales incorrectas" });

            return Ok(new { message = "Autenticación exitosa" });
        }

        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistroUsuario registerDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userService.RegisterUser(registerDto);
            if (!result) return BadRequest(new { message = "Error al registrar el usuario" });

            return Ok(new { message = "Usuario registrado exitosamente" });
        }

        [HttpPost("RecuperarClave")]
public async Task<IActionResult> RecuperarClave([FromBody] RecuperacionContraseñaRequest request)
{
    if (string.IsNullOrEmpty(request.NroDocumento))
        return BadRequest("El número de documento es requerido.");

    var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.NroDocumento == request.NroDocumento);
    if (usuario == null) return NotFound("No se encontró un usuario con este número de documento.");

    var emailSubject = "Recuperación de contraseña";
    var emailBody = $"Su contraseña es: {usuario.Clave}";
    await _emailService.SendAsync(usuario.Email, emailSubject, emailBody);

    return Ok(new { message = "Correo enviado con éxito." });
}

    }
}

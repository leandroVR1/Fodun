using System.Threading.Tasks;
using Fodun.Data;
using Fodun.Models;
using Fodun.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fodun.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUser(string nroDocumento, string clave)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NroDocumento == nroDocumento && u.Clave == clave);

            return usuario != null;
        }

        public async Task<bool> RegisterUser(RegistroUsuario registroDto)
        {
            var usuario = new Usuario
            {
                NroDocumento = registroDto.NroDocumento,
                Nombre = registroDto.Nombre,
                FechaNacimiento = registroDto.FechaNacimiento,
                Celular = registroDto.Celular,
                Email = registroDto.Email,
                Departamento = registroDto.Departamento,
                Municipio = registroDto.Municipio,
                Barrio = registroDto.Barrio,
                Direccion = registroDto.Direccion,
                Telefono = registroDto.Telefono,
                Clave = registroDto.Clave,
                PreguntaClave = registroDto.PreguntaClave,
                RespuestaClave = registroDto.RespuestaClave
            };

            _context.Usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RecuperarClave(string emailOrDocumento)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == emailOrDocumento || u.NroDocumento == emailOrDocumento);

            if (usuario == null) return false;

            // Lógica para enviar el correo
            return true;
        }
    }
}
